---
title: "AI-Powered Multilingual Slide Generator"
linktitle: "AI-Powered Generator"
type: docs
weight: 40
url: /net/ai/generator/
---

# Aspose.Slides Adds New AI-Powered Presentation Generator

Aspose.Slides introduces a new AI-powered feature: the Presentation Generator. This tool allows developers to automatically generate well-structured PowerPoint presentations from simple input text—such as topic descriptions, summaries, quotes, or bullet points.

Users can control the level of content detail and optionally apply a custom presentation template as the visual design.

Currently, the AI Presentation Generator structures content using text blocks, bullet lists, and tables. Unfortunately, image generation is not yet supported, but you can easily add images afterward using the Aspose.Slides tools or manually.

The output is a complete PowerPoint presentation that can be used as-is or saved in any of the file formats supported by the Aspose.Slides API. While the generator produces high-quality results, some minor post-editing may be necessary depending on your specific needs.

## How it Works

Aspose.Slides does not include built-in AI models but integrates with external AI services over the internet. This integration is managed by the SlidesAIAgent class, which uses an implementation of the IAIWebClient interface to communicate with the AI model.

You can either use the built-in `OpenAIWebClient`, which connects to OpenAI’s API, or provide your own custom implementation of IAIWebClient if you want to work with a different AI provider or language model.
Aspose.Slides manages all communication with the AI service and intelligently handles the AI’s responses—creating slides.
Note that the OpenAI API is a paid service, so you will need to create an account and supply your API key when using the built-in `OpenAIWebClient`.

## Let's Code
### Example 1
This example demonstrates how to generate a presentation on the topic Aspose.Slides using the built-in OpenAIWebClient.

```csharp
//Create an instance of OpenAIWebClient, which is the built-in implementation of the OpenAI web client
using OpenAIWebClient openAiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

//Create an instance of SlidesAIAgent, which provides access to AI-powered features
SlidesAIAgent slidesAiAgent = new SlidesAIAgent(openAiWebClient);

//Define the instruction for generating the presentation
string instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

//Generate a presentation with a medium amount of content based on the instruction
using IPresentation presentation = await slidesAiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

//Save the generated presentation to the local disk as a PowerPoint (.pptx) file
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### Example 2
The next example demonstrates the overloads of the GeneratePresentation method. In this example, we will use an externally `managed HttpClient` instance and the user's `master presentation`.

By default, the built-in OpenAIWebClient creates and manages its own internal `HttpClient` instance, handling its lifecycle and disposal automatically. However, if you prefer to manage the HttpClient yourself—such as when using an IHttpClientFactory for better resource management and performance—you can provide your own HttpClient instance when constructing the OpenAIWebClient.

```csharp
// Create an externally managed HttpClient instance
using HttpClient httpClient = new HttpClient();

// Provide the HttpClient to the OpenAIWebClient constructor
using OpenAIWebClient openAiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Create an instance of SlidesAIAgent
SlidesAIAgent slidesAiAgent = new SlidesAIAgent(openAiWebClient);

// Define the instruction for generating the presentation
string instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Load a master presentation from the local disk to use as the design template
using Presentation masterPresentation = new Presentation("masterPresentation.pptx");

// Generate a presentation with a detailed amount of content using the instruction and master template
using IPresentation presentation = await slidesAiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Generate a presentation with a detailed amount of content using the instruction and master template
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

It’s important to mention that many customers use Aspose.Slides in synchronous contexts. To accommodate this, the SlidesAIAgent class offers both `synchronous` and `asynchronous` methods, allowing you to choose the best approach for your application’s workflow.

## Conclusion
The new AI Presentation Generator in Aspose.Slides offers a fast and flexible way to create structured slide decks from simple text prompts. With support for custom templates, externally managed HttpClient instances, and both sync and async workflows, it's easy to integrate into various applications.

Common use cases include generating marketing decks, educational content, client reports, and internal presentations. While image generation isn't supported yet, the tool already provides a solid foundation for automating presentation creation—with more enhancements likely to come.