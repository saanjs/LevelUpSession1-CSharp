using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;

namespace RAGWinApp.Services
{
    /// <summary>
    /// Handles retrieval from Azure AI Search
    /// Supports vector + semantic hybrid search
    /// </summary>
    public class SearchService
    {
        private readonly SearchClient _searchClient;

        public SearchService(string endpoint, string indexName, string key)
        {
            _searchClient = new SearchClient(
                new Uri(endpoint),
                indexName,
                new AzureKeyCredential(key));
        }

        /// <summary>
        /// Performs hybrid search:
        /// - Vector similarity (semantic meaning)
        /// - Keyword + semantic ranking
        /// </summary>
        public async Task<List<string>> SearchAsync(
            string question,
            ReadOnlyMemory<float> vector)
        {
            var options = new SearchOptions
            {
                Size = 5,

                // Enables semantic ranking (IMPORTANT)
                QueryType = SearchQueryType.Semantic
            };

            // 🔥 Vector search (core of RAG)
            options.VectorSearch = new VectorSearchOptions
            {
                Queries =
                {
                    new VectorizedQuery(vector)
                    {
                        KNearestNeighborsCount = 5,

                        // MUST match your index field name
                        Fields = { "text_vector" }
                    }
                }
            };

            // Hybrid search: keyword + vector
            var response = await _searchClient.SearchAsync<SearchDocument>(
                question,
                options);

            var chunks = new List<string>();

            await foreach (var result in response.Value.GetResultsAsync())
            {
                // ✅ IMPORTANT: your field name is "chunk", not "content"
                if (result.Document.TryGetValue("chunk", out var content))
                {
                    chunks.Add(content?.ToString());
                }
            }

            return chunks;
        }
    }
}