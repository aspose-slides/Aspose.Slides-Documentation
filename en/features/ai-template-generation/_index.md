---
title: Generate presentations from a template
description: Use a template presentation when generating slides with AI.
type: docs
url: /features/ai-template-generation/
weight: 1550
feature_id: ai-template-generation
feature_group: ai
translationKey: slides-feature-ai-template-generation
feature_catalogue_version: 3
feature_guides:
- /slides/net/ai/generator/
---

## **Overview**

Pass a presentation template to the AI generator so the output can use its theme, fonts, masters and layouts. This gives generated slides a starting design drawn from your presentation file. It is a template-based library workflow, not a separately stored brand-kit service.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/). Optionally set ASPOSE_SLIDES_LICENSE to your license file to avoid evaluation limits. Create a reusable POTX with a distinctive theme color and Arial font scheme, then load a fresh copy for one generation request. The [default Aspose AI client](https://reference.aspose.com/slides/net/aspose.slides.ai/asposeaiwebclient/asposeaiwebclient/) supplies new water-cycle content; the library uses the supplied presentation design and saves generated.pptx. The stored template remains available for another request.

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
    design.MasterTheme.ColorScheme.Accent1.Color = System.Drawing.Color.FromArgb(12, 110, 120);
    design.MasterTheme.FontScheme.Major.LatinFont = new FontData("Arial");
    design.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
    design.Masters[0].Background.Type = BackgroundType.OwnBackground;
    design.Masters[0].Background.FillFormat.FillType = FillType.Solid;
    design.Masters[0].Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(235, 248, 248);
    design.DocumentProperties.Title = "Reusable demonstration design";
    design.Save("template.potx", SaveFormat.Potx);
}
using var template = new Presentation("template.potx");
using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(120) };
using var client = new AsposeAIWebClient(http);
var agent = new SlidesAIAgent(client);
var instruction = "Create a short English presentation about the water cycle. Cover evaporation, condensation, and precipitation. Use ordinary text slides with a title and one short paragraph. No tables, charts or images. For every section in the JSON, use the integer 0 for its type field instead of a type name. Return only raw JSON without Markdown code fences or commentary.";
using IPresentation presentation = await agent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Brief, template);
presentation.Save("generated.pptx", SaveFormat.Pptx);
Console.WriteLine("Generated slides: " + presentation.Slides.Count);
```

## **FAQ**

### **Can I reuse one in-memory template for every request?**

Load a fresh copy for each generation when the template must stay unchanged. The generation workflow can modify the presentation instance passed to it.

### **Which design elements can a template contribute?**

Its presentation theme, fonts, masters and layouts can provide the design for the generated slides. Inspect the result because the available layouts and generated content still affect the composition.

### **Does choosing a template also determine the amount of generated text?**

No. The template supplies design, while the generation content-amount setting and prompt control the requested detail.

## **Guides**

- [AI-Powered Multilingual Slide Generator (.NET)](/slides/net/ai/generator/)

Related feature: [Generate slides using an existing deck's style](/slides/features/ai-match-style/).
