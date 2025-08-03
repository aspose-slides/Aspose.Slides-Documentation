---
title: "AI-Powered Presentation Translator"
linktitle: "AI-Powered Presentation Translator"
type: docs
weight: 20
url: /net/ai/generator/
---

# Aspose.Slides Presentation Translation API: AI-Powered Multilingual Slide Translation

Aspose.Slides is a powerful API for programmatically managing PowerPoint presentations. In addition to creating, editing, and converting slides, it now offers AI-driven features - such as the [Presentation Translation API](https://reference.aspose.com/slides/net/aspose.slides.ai/) for multilingual slide content.

## How it Works

Aspose.Slides does not include built-in AI capabilities but integrates with external AI models over the internet. This functionality is exposed via the [`SlidesAIAgent`](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent) class, which uses an implementation of the [`IAIWebClient`](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) interface to communicate with AI services.

You can use the built-in [`OpenAIWebClient`](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) to connect to OpenAI’s API or implement your own [`IAIWebClient`](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) to use a different AI provider or language model.

Aspose.Slides handles the communication, parses the AI responses, and intelligently inserts translated content while preserving the original slide layout and formatting.

{{% alert color="primary" %}}

Note that the OpenAI API is a paid service, so you will need to create an account and supply your API key when using the built-in [`OpenAIWebClient`](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

{{% /alert %}}

## Example

In this example, we translate a PowerPoint presentation into Japanese using the built-in [`OpenAIWebClient`](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) with a specified OpenAI [model](https://platform.openai.com/docs/models).

```csharp
// Load the presentation to translate.
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Create an AI client using OpenAIWebClient with your model and API key.
    using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

    // Initialize SlidesAIAgent with the AI client.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Translate the presentation to Japanese.
    await aiAgent.TranslateAsync(pres, "japanese");

    // Save the translated presentation as a PDF.
    pres.Save("presentation_jp.pdf", SaveFormat.Pdf);
}
```

By default, the built-in [`OpenAIWebClient`](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) creates and manages its own internal [`HttpClient`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) instance, handling its lifecycle and disposal automatically. However, if you prefer to manage the [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) yourself - such as when using an [`IHttpClientFactory`](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) for better resource management and performance - you can provide your own HttpClient instance when constructing the [`OpenAIWebClient`](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Assume you have an IHttpClientFactory instance (e.g., injected via dependency injection).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);
```

Aspose.Slides is commonly used in synchronous environments. To support this, the [`SlidesAIAgent`](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) class offers both synchronous and asynchronous methods - allowing you to choose the approach that best fits your application’s workflow.

## Key Benefits

The Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/net/aspose.slides.ai/) offers an AI-powered solution for delivering multilingual PowerPoint presentations. By automating translation while preserving layout and design, it saves time and minimizes errors compared to manual workflows. Whether you're a developer, educator, or business professional, this API enables you to create engaging, localized presentations for global audiences - expanding your reach and improving communication.