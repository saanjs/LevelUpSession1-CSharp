using Azure;
using Azure.AI.OpenAI;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using RAGWinApp.Helpers;
using RAGWinApp.Services;
using System.Configuration;

namespace RAGWinApp
{
    public partial class Form1 : Form
    {
        private readonly RagService _ragService;

        public Form1()
        {
            InitializeComponent();

            // 🔑 Load config
            var openAiEndpoint = ConfigurationManager.AppSettings["OpenAI:Endpoint"];
            var openAiKey = ConfigurationManager.AppSettings["OpenAI:Key"];
            var chatDeployment = ConfigurationManager.AppSettings["OpenAI:ChatDeployment"];
            var embeddingDeployment = ConfigurationManager.AppSettings["OpenAI:EmbeddingDeployment"];

            var searchEndpoint = ConfigurationManager.AppSettings["Search:Endpoint"];
            var searchKey = ConfigurationManager.AppSettings["Search:Key"];
            var indexName = ConfigurationManager.AppSettings["Search:IndexName"];

            // ✅ Initialize services
            var openAI = new OpenAIService(openAiEndpoint, openAiKey, chatDeployment, embeddingDeployment);
            var search = new SearchService(searchEndpoint, indexName, searchKey);

            _ragService = new RagService(openAI, search);
        }

        private async void btnAsk_Click(object sender, EventArgs e)
        {
            var question = txtQuestion.Text;

            if (string.IsNullOrWhiteSpace(question))
            {
                txtAnswer.Text = "Please enter a question.";
                return;
            }

            try
            {
                txtAnswer.Text = "🔄 Thinking...";

                // 🚀 Call RAG pipeline
                var answer = await _ragService.AskAsync(question);

                // 🎨 Format output
                ResponseFormatter.Format(txtAnswer, answer);
            }
            catch (Exception ex)
            {
                txtAnswer.Text = "❌ Error:\n" + ex.Message;
            }
        }
    }
}