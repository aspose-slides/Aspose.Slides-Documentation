---
title: AI-Powered Multilingual Slide Generator
linktitle: AI-Powered Generator
type: docs
weight: 40
url: /nodejs-java/ai/generator/
keywords:
- multilingual presentation
- multilingual slide
- AI presentation generator
- AI slide generator
- AI-powered feature
- AI agent
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Generate multilingual slides from text with Aspose.Slides for Node.js. Apply your template and export polished decks to PowerPoint and OpenDocument. Learn more."
---

## **Aspose.Slides Presentation AI API: AI-Powered Slide Generator**

Aspose.Slides introduces a new AI-powered feature, the Presentation Generator, which enables developers to automatically create well-structured PowerPoint presentations from simple text inputs such as topic descriptions, summaries, quotations, or bullet points.

Users can adjust the level of content detail and optionally apply a custom presentation template to define the visual design.

Currently, the AI Presentation Generator structures content using text blocks, bullet lists, and tables. Image generation is not yet supported; however, images can be easily added afterward using Aspose.Slides tools or manually.

The output is a complete PowerPoint presentation that can be used as-is or exported to any format supported by the Aspose.Slides API. While the generator produces high-quality results, minor post-editing may be required to meet specific requirements.

## **How it Works**

Aspose.Slides does not include built-in AI models; instead, it integrates with external AI services over the internet. This integration is handled by the [SlidesAIAgent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesaiagent/) class.

You can use the built-in [OpenAIWebClient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/openaiwebclient/), which connects to OpenAI’s API. Aspose.Slides manages all communication with the AI service and processes the AI’s responses to generate slides. Note that the OpenAI API is a paid service, so an account and API key are required when using the built-in [OpenAIWebClient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/openaiwebclient/).

## **Let's Code**

### **Example 1**

This example demonstrates how to generate a presentation on the topic Aspose.Slides using the built-in [OpenAIWebClient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Create an instance of OpenAIWebClient, the built-in implementation of the OpenAI web client.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Create an instance of SlidesAIAgent, which provides access to AI-powered features.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Define the instruction for generating the presentation.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Generate a presentation with a medium amount of content based on the instruction.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // Save the generated presentation to the local disk as a PowerPoint (.pptx) file.
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Example 2**

The following example demonstrates the overloads of the [generatePresentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation) method. In this case, an externally managed [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) instance and the user’s `master presentation` are used.

By default, the built-in [OpenAIWebClient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/openaiwebclient/) creates and manages its own internal [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) instance, handling its lifecycle automatically. However, if you prefer to manage the [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) yourself—for example, when using an [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) or [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) for improved resource management and performance—you can supply your own [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) instance when constructing the [OpenAIWebClient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Pass the HttpURLConnection to the OpenAIWebClient constructor.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Create an instance of SlidesAIAgent.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Define the instruction for generating the presentation.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Load a master presentation from the local disk to use as the design template.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // Generate a detailed presentation using the instruction and master template.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Save the generated presentation as a PDF.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

It is worth noting that many customers use Aspose.Slides in synchronous contexts. To support this, the [SlidesAIAgent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesaiagent/) class provides both synchronous and asynchronous methods, allowing you to choose the approach that best fits your application’s workflow.

## **Key Benefits**

The new AI Presentation Generator in Aspose.Slides provides a fast and flexible way to produce structured slide decks from simple text prompts. With support for custom templates, externally managed [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) instances, and both synchronous and asynchronous workflows, it can be seamlessly integrated into a wide range of applications.

Typical use cases include creating marketing presentations, educational materials, client reports, and internal slide decks. Although image generation is not yet supported, the tool already offers a strong foundation for automating presentation creation, with further enhancements expected in the future.
