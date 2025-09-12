---
title: AI-Powered Presentation Translator
linktitle: AI-Powered Translator
type: docs
weight: 20
url: /nodejs-java/ai/translator/
keywords:
- AI presentation translator
- AI slide translator
- AI-powered feature
- multilingual presentation
- multilingual slide
- presentation translation
- slide translation
- AI-driven features
- AI capabilities
- AI agent
- Web client
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Translate PowerPoint slides with AI using Aspose.Slides for Node.js. Localize PPT, PPTX and ODP while preserving layout—fast and developer-friendly. Try it."
---

## **Aspose.Slides Presentation Translation API: AI-Powered Multilingual Slide Translation**

Aspose.Slides is a powerful API for programmatically managing PowerPoint presentations. In addition to creating, editing, and converting slides, it offers AI-driven features - such as the Presentation Translation API for multilingual slide content.

## **How it Works**

Aspose.Slides does not include built-in AI capabilities but integrates with external AI models over the internet. This functionality is exposed via the [SlidesAIAgent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesaiagent/) class to communicate with AI services.

You can use the built-in [OpenAIWebClient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/openaiwebclient/) to connect to OpenAI’s API.

Aspose.Slides handles the communication, parses the AI responses, and intelligently inserts translated content while preserving the original slide layout and formatting.

{{% alert color="primary" %}}

Note that the OpenAI API is a paid service, so you will need to create an account and supply your API key when using the built-in [OpenAIWebClient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/openaiwebclient/).

{{% /alert %}}

## **Example**

In this example, we translate a PowerPoint presentation into Japanese using the built-in [OpenAIWebClient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/openaiwebclient/) with a specified OpenAI [model](https://platform.openai.com/docs/models).

```js
// Load a presentation to translate.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialize SlidesAIAgent with the AI client.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Translate the presentation to Japanese.
    aiAgent.translate(presentation, "japanese");

    // Save the translated presentation as a PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

By default, the built-in [OpenAIWebClient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/openaiwebclient/) creates and manages its own internal [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) instance, handling its lifecycle automatically. However, if you prefer to manage the [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) yourself — primarily to configure essential settings like a proxy, or to use an [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) or a different [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) for better resource management and performance — you can provide your own `HttpURLConnection` instance when constructing the [OpenAIWebClient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Assume you have a pre-configured HttpURLConnection instance (e.g., with custom timeouts, proxy settings, etc.)
let urlConnection = yourPreconfiguredConnection;
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Key Benefits**

The Aspose.Slides Presentation Translation API offers an AI-powered solution for delivering multilingual PowerPoint presentations. By automating translation while preserving layout and design, it saves time and minimizes errors compared to manual workflows. Whether you're a developer, educator, or business professional, this API enables you to create engaging, localized presentations for global audiences - expanding your reach and improving communication.
