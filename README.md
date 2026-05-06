# 🧠 Azure RAG WinForms App (C#)

A simple, end-to-end **Retrieval-Augmented Generation (RAG)** demo using:

* Azure OpenAI (Chat + Embeddings)
* Azure AI Search (Vector + Hybrid Search)
* C# WinForms UI

---

## ✨ What This Project Demonstrates

This app shows how to move from **AI guessing → AI knowing** by grounding responses in your own enterprise data.

### 🔁 RAG Flow

1. User asks a question
2. Convert question → embedding (vector)
3. Search relevant documents from Azure AI Search
4. Send retrieved context to Azure OpenAI
5. Generate **accurate, grounded answer**

---

## 🏗️ Architecture Overview

```
User (WinForms UI)
        ↓
RagService (Orchestrator)
        ↓
 ┌───────────────┬────────────────┐
 │               │                │
OpenAIService   SearchService
 │               │
Embeddings       Vector + Hybrid Search
 │               │
 └──────→ Context + Question ←────┘
                ↓
         Azure OpenAI (GPT)
                ↓
          Grounded Answer
```

---

## ☁️ Azure Services Used

### 1. Azure OpenAI

* Chat model (e.g., `gpt-4.1-mini`)
* Embedding model (e.g., `text-embedding-3-large`)

### 2. Azure AI Search

* Stores indexed documents
* Supports:

  * Vector search
  * Keyword search
  * Semantic ranking

### 3. Blob Storage (Optional)

* Source of documents (PDFs, policies, etc.)

---

## 📦 NuGet Dependencies

Install these packages:

```bash
dotnet add package Azure.AI.OpenAI
dotnet add package Azure.Search.Documents
dotnet add package Azure.Identity
```

---

## ⚙️ Configuration (App.config)

Update with your Azure resources:

```xml
<appSettings>
  <add key="OpenAI:Endpoint" value="https://YOUR-OPENAI.openai.azure.com/" />
  <add key="OpenAI:Key" value="YOUR_OPENAI_KEY" />
  <add key="OpenAI:ChatDeployment" value="YOUR_CHAT_MODEL" />
  <add key="OpenAI:EmbeddingDeployment" value="YOUR_EMBEDDING_MODEL" />

  <add key="Search:Endpoint" value="https://YOUR-SEARCH.search.windows.net" />
  <add key="Search:IndexName" value="YOUR_INDEX_NAME" />
  <add key="Search:Key" value="YOUR_SEARCH_KEY" />
</appSettings>
```

---

## 🔍 Azure AI Search Index Schema

Example fields:

| Field Name    | Type              | Purpose          |
| ------------- | ----------------- | ---------------- |
| `chunk_id`    | String            | Unique ID        |
| `chunk`       | String            | Text content     |
| `title`       | String            | Document title   |
| `text_vector` | Collection(float) | Embedding vector |

---

## 🧩 Code Structure

```
/Services
  OpenAIService.cs     → Embeddings + Chat
  SearchService.cs     → Retrieval (vector + hybrid)
  RagService.cs        → RAG pipeline orchestration

/Helpers
  ResponseFormatter.cs → UI formatting

Form1.cs               → UI layer only
```

---

## 🧠 Key Concepts Explained

### 🔹 Embeddings

Convert text into vectors so similar meanings are close together.

### 🔹 Vector Search

Finds semantically similar content (not just keyword match).

### 🔹 Hybrid Search

Combines:

* Keyword search
* Vector similarity
* Semantic ranking

👉 This is why results are accurate.

---

## ⚠️ Common Pitfalls (Solved in this repo)

| Issue                         | Fix                                  |
| ----------------------------- | ------------------------------------ |
| Always getting "I don't know" | Use hybrid search (not vector only)  |
| Wrong field name              | Match index (`chunk`, `text_vector`) |
| Vector type errors            | Use `ReadOnlyMemory<float>`          |
| Empty results                 | Ensure data is indexed properly      |

---

## 🧪 Sample Query

```
contoso refund policy
```

### ✅ Output

* Structured response
* Bullet points
* Grounded in actual document

---

## 🎯 Use Cases

This pattern is used in:

* Enterprise chatbots
* Knowledge base assistants
* Customer support automation
* Internal AI copilots

---

## 🚀 Future Improvements

* Add citations (like Azure AI Foundry)
* Highlight source documents
* Streaming responses
* Chat history memory
* GraphRAG integration

---

## 🙌 Key Takeaway

> **RAG transforms AI from guessing → knowing**
> by grounding every response in your real data.

---

## 🤝 Contributions

Feel free to fork, improve, and experiment!

---

## 📬 Contact

If you have questions or ideas, feel free to connect.

---

⭐ If this helped you, consider giving it a star!
