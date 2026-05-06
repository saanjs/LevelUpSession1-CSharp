namespace RAGWinApp.Services
{
    /// <summary>
    /// Core RAG pipeline:
    /// 1. Convert question → embedding
    /// 2. Retrieve relevant chunks from search
    /// 3. Generate grounded answer using OpenAI
    /// </summary>
    public class RagService
    {
        private readonly OpenAIService _openAI;
        private readonly SearchService _search;

        public RagService(OpenAIService openAI, SearchService search)
        {
            _openAI = openAI;
            _search = search;
        }

        public async Task<string> AskAsync(string question)
        {
            // =========================
            // 1️⃣ EMBEDDING
            // =========================
            var embedding = await _openAI.GetEmbeddingAsync(question);

            // =========================
            // 2️⃣ RETRIEVAL
            // =========================
            var chunks = await _search.SearchAsync(question, embedding);

            if (chunks.Count == 0)
                return "I don't know."; // aligns with system prompt

            // Combine retrieved chunks into context
            var context = string.Join("\n---\n", chunks);

            // =========================
            // 3️⃣ GENERATION
            // =========================
            var answer = await _openAI.GetChatCompletionAsync(context, question);

            return answer;
        }
    }
}