using Azure;
using Azure.AI.OpenAI;

namespace RAGWinApp.Services
{
    /// <summary>
    /// Handles all interactions with Azure OpenAI
    /// (Embeddings + Chat Completions)
    /// </summary>
    public class OpenAIService
    {
        private readonly OpenAIClient _client;
        private readonly string _chatDeployment;
        private readonly string _embeddingDeployment;

        public OpenAIService(string endpoint, string key, string chatDeployment, string embeddingDeployment)
        {
            _client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));
            _chatDeployment = chatDeployment;
            _embeddingDeployment = embeddingDeployment;
        }

        /// <summary>
        /// Converts user query into vector embedding
        /// </summary>
        public async Task<ReadOnlyMemory<float>> GetEmbeddingAsync(string text)
        {
            var response = await _client.GetEmbeddingsAsync(
                new EmbeddingsOptions
                {
                    DeploymentName = _embeddingDeployment,
                    Input = { text }
                });

            return response.Value.Data[0].Embedding;
        }

        /// <summary>
        /// Generates final answer using context + question
        /// </summary>
        public async Task<string> GetChatCompletionAsync(string context, string question)
        {
            var options = new ChatCompletionsOptions
            {
                DeploymentName = _chatDeployment,
                Temperature = 0.2f
            };

            // System message → controls behavior
            options.Messages.Add(new ChatRequestSystemMessage(
@"You are an enterprise assistant.

- Answer ONLY from provided context
- If not found, say 'I don't know'
- Format clearly using bullet points
- Keep answers concise"
            ));

            // User message → includes retrieved context
            options.Messages.Add(new ChatRequestUserMessage(
$@"Context:
{context}

Question:
{question}"
            ));

            var response = await _client.GetChatCompletionsAsync(options);

            return response.Value.Choices[0].Message.Content;
        }
    }
}