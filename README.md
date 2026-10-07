# .NET & AI Integration Demo

A practical **.NET 9** workshop project that demonstrates how a backend application can integrate AI into a real application.

The repository contains two examples:

- **Console App** — a minimal AI integration example using `IChatClient` and a local Ollama model.
- **ASP.NET Core MVC App** — a practical **AI Product Description Generator** that shows how the same AI capability can be integrated into a real MVC application through a controller, service layer, and `IChatClient`.

The project is designed around a simple idea:

> **AI does not replace your application architecture. AI becomes a capability inside it.**

---

## 📚 Workshop Presentation

The presentation used for the workshop is available here:

**[.NET & AI — From Web APIs to Intelligent Applications](https://gamma.app/docs/NET-AI-t1ieue294enkuxw)**

---

## 🎯 What This Repository Demonstrates

This project focuses on **AI integration from a .NET backend developer's perspective**.

It demonstrates:

- Calling a local AI model from .NET
- Using `IChatClient` as a common interface for AI chat interactions
- Integrating Ollama with a .NET application
- Sending prompts from C# and receiving generated text
- Registering AI services with Dependency Injection
- Separating AI-related logic from controllers
- Using AI inside an ASP.NET Core MVC application
- Building a practical AI feature instead of a standalone chatbot

The project intentionally avoids advanced AI topics such as RAG, embeddings, vector databases, agents, and model training.

---

# 🏗️ Solution Structure

```text
dotnet-ai-integration-demo/
│
├── ConsoleApp/
│   └── Simple Ollama + IChatClient demonstration
│
├── ProductAiDemo/
│   └── ASP.NET Core MVC Product Description Generator
│
└── README.md
