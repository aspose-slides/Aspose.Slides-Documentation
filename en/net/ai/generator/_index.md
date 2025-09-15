---
title: AI-Powered Multilingual Slide Generator
linktitle: AI-Powered Generator
type: docs
weight: 40
url: /net/ai/generator/
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
- .NET
- C#
- Aspose.Slides
description: "Generate multilingual slides from text with Aspose.Slides for .NET. Apply your template and export polished decks to PowerPoint and OpenDocument. Learn more."
---

## **Aspose.Slides Presentation AI API: AI-Powered Slide Generator**

Aspose.Slides introduces a new AI-powered feature, the Presentation Generator, which enables developers to automatically create well-structured PowerPoint presentations from simple text inputs such as topic descriptions, summaries, quotations, or bullet points.

Users can adjust the level of content detail and optionally apply a custom presentation template to define the visual design.

Currently, the AI Presentation Generator structures content using text blocks, bullet lists, and tables. Image generation is not yet supported; however, images can be easily added afterward using Aspose.Slides tools or manually.

The output is a complete PowerPoint presentation that can be used as-is or exported to any format supported by the Aspose.Slides API. While the generator produces high-quality results, minor post-editing may be required to meet specific requirements.

## **How it Works**

Aspose.Slides does not include built-in AI models; instead, it integrates with external AI services over the internet. This integration is handled by the [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) class, which uses an implementation of the [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) interface to communicate with the AI model.

You can use the built-in [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/), which connects to OpenAI’s API, or provide a custom implementation of [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) to work with another AI provider or language model. Aspose.Slides manages all communication with the AI service and processes the AI’s responses to generate slides. Note that the OpenAI API is a paid service, so an account and API key are required when using the built-in [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

## **Let's Code**

### **Example 1**

This example demonstrates how to generate a presentation on the topic Aspose.Slides using the built-in [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Create an instance of OpenAIWebClient, the built-in implementation of the OpenAI web client.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Create an instance of SlidesAIAgent, which provides access to AI-powered features.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Generate a presentation with a medium amount of content based on the instruction.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Save the generated presentation to the local disk as a PowerPoint (.pptx) file.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Example 2**

The following example demonstrates the overloads of the [GeneratePresentation](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/generatepresentation/) method. In this case, an externally managed [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) instance and the user’s `master presentation` are used.

By default, the built-in [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) creates and manages its own internal [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) instance, handling its lifecycle and disposal automatically. However, if you prefer to manage the [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) yourself—for example, when using an [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) for improved resource management and performance—you can supply your own [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) instance when constructing the [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Create an externally managed HttpClient instance.
using var httpClient = new HttpClient();

// Pass the HttpClient to the OpenAIWebClient constructor.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Create an instance of SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Load a master presentation from the local disk to use as the design template.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Generate a detailed presentation using the instruction and master template.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Save the generated presentation as a PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

It is worth noting that many customers use Aspose.Slides in synchronous contexts. To support this, the [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) class provides both synchronous and asynchronous methods, allowing you to choose the approach that best fits your application’s workflow.

## **Key Benefits**

The new AI Presentation Generator in Aspose.Slides provides a fast and flexible way to produce structured slide decks from simple text prompts. With support for custom templates, externally managed [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) instances, and both synchronous and asynchronous workflows, it can be seamlessly integrated into a wide range of applications.

Typical use cases include creating marketing presentations, educational materials, client reports, and internal slide decks. Although image generation is not yet supported, the tool already offers a strong foundation for automating presentation creation, with further enhancements expected in the future.
