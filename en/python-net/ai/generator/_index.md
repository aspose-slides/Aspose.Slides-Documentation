---
title: AI-Powered Multilingual Slide Generator
linktitle: AI-Powered Generator
type: docs
weight: 40
url: /python-net/ai/generator/
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
- Python
- Aspose.Slides
description: "Generate multilingual slides from text with Aspose.Slides for Python. Apply your template and export polished decks to PowerPoint and OpenDocument. Learn more."
---

## **Aspose.Slides Presentation AI API: AI-Powered Slide Generator**

Aspose.Slides introduces a new AI-powered feature, the Presentation Generator, which enables developers to automatically create well-structured PowerPoint presentations from simple text inputs such as topic descriptions, summaries, quotations, or bullet points.

Users can adjust the level of content detail and optionally apply a custom presentation template to define the visual design.

Currently, the AI Presentation Generator structures content using text blocks, bullet lists, and tables. Image generation is not yet supported; however, images can be easily added afterward using Aspose.Slides tools or manually.

The output is a complete PowerPoint presentation that can be used as-is or exported to any format supported by the Aspose.Slides API. While the generator produces high-quality results, minor post-editing may be required to meet specific requirements.

## **How it Works**

Aspose.Slides does not include built-in AI models; instead, it integrates with external AI services over the internet. This integration is handled by the [SlidesAIAgent](https://reference.aspose.com/slides/python-net/aspose.slides.ai/slidesaiagent/) class, which uses an implementation of the [IAIWebClient](https://reference.aspose.com/slides/python-net/aspose.slides.ai/iaiwebclient/) class to communicate with the AI model.

You can use the built-in [OpenAIWebClient](https://reference.aspose.com/slides/python-net/aspose.slides.ai/openaiwebclient/), which connects to OpenAI’s API, or provide a custom implementation of [IAIWebClient](https://reference.aspose.com/slides/python-net/aspose.slides.ai/iaiwebclient/) to work with another AI provider or language model. Aspose.Slides manages all communication with the AI service and processes the AI’s responses to generate slides. Note that the OpenAI API is a paid service, so an account and API key are required when using the built-in [OpenAIWebClient](https://reference.aspose.com/slides/python-net/aspose.slides.ai/openaiwebclient/).

## **Let's Code**

### **Example 1**

This example demonstrates how to generate a presentation on the topic Aspose.Slides using the built-in [OpenAIWebClient](https://reference.aspose.com/slides/python-net/aspose.slides.ai/openaiwebclient/).

```py
# Create an instance of OpenAIWebClient, the built-in implementation of the OpenAI web client.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # Create an instance of SlidesAIAgent, which provides access to AI-powered features.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Define the instruction for generating the presentation.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Generate a presentation with a medium amount of content based on the instruction.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # Save the generated presentation to the local disk as a PowerPoint (.pptx) file.
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **Example 2**

The following example demonstrates the overloads of the [generate_presentation](https://reference.aspose.com/slides/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation) method. In this case, the user’s `master presentation` is used.

```py
# Pass the HttpClient to the OpenAIWebClient constructor.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # Create an instance of SlidesAIAgent.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Define the instruction for generating the presentation.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Load a master presentation from the local disk to use as the design template.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # Generate a detailed presentation using the instruction and master template.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # Save the generated presentation as a PDF.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **Key Benefits**

The new AI Presentation Generator in Aspose.Slides provides a fast and flexible way to produce structured slide decks from simple text prompts. With support for custom templates, it can be seamlessly integrated into a wide range of applications.

Typical use cases include creating marketing presentations, educational materials, client reports, and internal slide decks. Although image generation is not yet supported, the tool already offers a strong foundation for automating presentation creation, with further enhancements expected in the future.
