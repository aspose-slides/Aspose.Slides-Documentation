---
title: Generate slides using an existing deck's style
description: Reuse an existing presentation's design for AI-generated slides.
type: docs
url: /features/ai-match-style/
weight: 1560
feature_id: ai-match-style
feature_group: ai
translationKey: slides-feature-ai-match-style
feature_catalogue_version: 3
feature_guides:
- /slides/net/ai/generator/
---

## **Overview**

Use an existing deck as the design template for presentation generation. Its theme colors, font choices, masters and layouts provide the visual structure for the new content. This is useful when a recurring report should follow a familiar presentation design.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/). Optionally set ASPOSE_SLIDES_LICENSE to your license file to avoid evaluation limits. Build a small existing report deck with a distinctive theme color and Arial font scheme. Reopen that file as the style source, then use the [default Aspose AI client](https://reference.aspose.com/slides/net/aspose.slides.ai/asposeaiwebclient/asposeaiwebclient/) to generate new water-cycle content with the supplied design. The generation can modify the loaded instance, so this example keeps its source file on disk and saves to generated.pptx.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var licensePath = Environment.GetEnvironmentVariable("ASPOSE_SLIDES_LICENSE");
if (!string.IsNullOrWhiteSpace(licensePath))
{
    var license = new License();
    license.SetLicense(licensePath);
}
using (var design = new Presentation())
{
    design.MasterTheme.ColorScheme.Accent1.Color = System.Drawing.Color.FromArgb(106, 43, 130);
    design.MasterTheme.FontScheme.Major.LatinFont = new FontData("Arial");
    design.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
    design.Masters[0].Background.Type = BackgroundType.OwnBackground;
    design.Masters[0].Background.FillFormat.FillType = FillType.Solid;
    design.Masters[0].Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(247, 238, 250);
    var title = design.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 100);
    title.AddTextFrame("Existing report design");
    design.Save("style-source.pptx", SaveFormat.Pptx);
}
using var template = new Presentation("style-source.pptx");
using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(120) };
using var client = new AsposeAIWebClient(http);
var agent = new SlidesAIAgent(client);
var instruction = "Create a short English presentation about the water cycle. Cover evaporation, condensation, and precipitation. Use ordinary text slides with a title and one short paragraph. No tables, charts or images. For every section in the JSON, use the integer 0 for its type field instead of a type name. Return only raw JSON without Markdown code fences or commentary.";
using IPresentation presentation = await agent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Brief, template);
presentation.Save("generated.pptx", SaveFormat.Pptx);
Console.WriteLine("Generated slides: " + presentation.Slides.Count);
```

## **FAQ**

### **Does this require the source deck to be a special brand-kit format?**

No. The design comes from a presentation file used as the template for the generation workflow.

### **How does using an existing deck differ from writing a text-only prompt?**

The existing deck supplies a presentation design, including theme and layouts. A text-only prompt describes content but does not supply that same file-based design.

### **Should I pass a fresh presentation instance for each generation?**

Yes, when you need to retain the source. Load a fresh copy for each request because generation can modify the instance passed as the template.

## **Guides**

- [AI-Powered Multilingual Slide Generator (.NET)](/slides/net/ai/generator/)

Related feature: [Generate presentations from a template](/slides/features/ai-template-generation/).
