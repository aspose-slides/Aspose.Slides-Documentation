---
title: AI-Powered Multilingual Slide Generator
linktitle: AI-Powered Generator
type: docs
weight: 40
url: /python-java/ai/generator/
keywords:
- multilingual presentation
- multilingual slide
- AI presentation generator
- AI slide generator
- presentation template
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Generate multilingual presentations from text with Aspose.Slides for Python via Java. Choose content detail, apply a template, and export to PowerPoint or PDF."
---

## **Introduction**

The AI Presentation Generator in Aspose.Slides for Python via Java creates presentations from topic descriptions, summaries, quotations, or bullet points. Specify the required language in your prompt, choose the amount of content, and optionally supply a presentation template to define the layout and design.

The generator structures content using text blocks, bullet lists, and tables. It does not generate images; you can add them to the resulting presentation afterward. Review the generated content and layout before sharing the presentation.

## **How It Works**

[SlidesAIAgent](https://reference.aspose.com/slides/python-java/aspose.slides/slidesaiagent/) uses an AI client to communicate with an external model. The examples below use the built-in [OpenAIWebClient](https://reference.aspose.com/slides/python-java/aspose.slides/openaiwebclient/). Aspose.Slides processes the model's responses and builds a presentation that you can edit or export.

Use [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesaiagent/#generatePresentation) with a text description and a [PresentationContentAmountType](https://reference.aspose.com/slides/python-java/aspose.slides/presentationcontentamounttype/) value. The overload with a third argument accepts a presentation to use as a design template.

## **Prerequisites**

Follow [Installation](/slides/python-java/installation/) to configure Python, Java, JPype, and Aspose.Slides. Set the `OPENAI_API_KEY` and `OPENAI_MODEL` environment variables before running the examples. Choose a model supported by the built-in client and available to your API account.

{{% alert color="info" title="Note" %}}

The AI service requires an internet connection and separate API access. Prompts are sent to the configured service, and its usage charges apply independently of your Aspose.Slides license.

{{% /alert %}}

Each example starts the JVM only if it is not already running and leaves it available for subsequent operations. See [JVM lifecycle guidance](/slides/python-java/limitations-and-api-differences/#import-the-library) when adapting the code for notebooks.

## **Generate a Presentation from Text**

This example generates an English presentation with a [Medium](https://reference.aspose.com/slides/python-java/aspose.slides/presentationcontentamounttype/#Medium) amount of content and saves it as a PowerPoint file.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Generate a Presentation Using a Template**

Place `masterPresentation.pptx` in the working directory. This example loads it with [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), generates a Spanish presentation with [Detailed](https://reference.aspose.com/slides/python-java/aspose.slides/presentationcontentamounttype/#Detailed) content, and exports it to PDF. Both the template and the generated presentation are released, even if generation or saving fails.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

If you need to configure a proxy or connection timeouts, see [Configure the HTTP Connection](/slides/python-java/ai/translator/#configure-the-http-connection). You can pass the resulting client to the generator as well.

## **Key Benefits**

Generation can reduce the initial drafting work for training materials, product overviews, client reports, and internal presentations. Prompts control the topic and language, while a template lets you reuse an existing presentation design.

## **FAQ**

**How do I control the length of the generated presentation?**

Choose [Brief](https://reference.aspose.com/slides/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/python-java/aspose.slides/presentationcontentamounttype/#Medium), or [Detailed](https://reference.aspose.com/slides/python-java/aspose.slides/presentationcontentamounttype/#Detailed). These settings influence both the number of slides and the detail on each slide; they do not specify an exact slide count.

**Can I generate slides in another language?**

Yes. Include the requested language in the text description. The result depends on the selected model's language capabilities.

**Can I keep an editable version when exporting to PDF?**

Yes. Before disposing of the generated presentation, also save it as PPTX using the approach in the first example.
