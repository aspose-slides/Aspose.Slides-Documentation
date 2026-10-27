---
title: Generate a presentation from a prompt
description: Generate an editable presentation from a text prompt.
type: docs
url: /features/ai-generate-presentations/
weight: 1510
feature_id: ai-generate-presentations
feature_group: ai
translationKey: slides-feature-ai-generate-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/ai/generator/
---

## **Overview**

Use the Slides AI generator with a configured model client to turn a prompt into presentation slides. The result is a presentation your application can continue editing, save as PPTX or export through the regular library workflow. Supply a prompt that describes the content you need.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/). Optionally set ASPOSE_SLIDES_LICENSE to your license file to avoid evaluation limits. Send a synthetic water-cycle prompt through the documented [default Aspose AI client](https://reference.aspose.com/slides/net/aspose.slides.ai/asposeaiwebclient/asposeaiwebclient/), then save the generated deck. The prompt requests short ordinary text sections and numeric section types so the model response matches the generator's expected format. Content varies between runs; review it before use.

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
using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(120) };
using var client = new AsposeAIWebClient(http);
var agent = new SlidesAIAgent(client);
var instruction = "Create a short English presentation about the water cycle. Cover evaporation, condensation, and precipitation. Use ordinary text slides with a title and one short paragraph. No tables, charts or images. For every section in the JSON, use the integer 0 for its type field instead of a type name. Return only raw JSON without Markdown code fences or commentary.";
using IPresentation presentation = await agent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Brief);
presentation.Save("generated.pptx", SaveFormat.Pptx);
Console.WriteLine("Generated slides: " + presentation.Slides.Count);
```

## **FAQ**

### **Can I use my own model provider?**

Yes. Configure a compatible client or your own provider implementation instead of relying on a single hosted model choice.

### **Where is the prompt processed?**

The configured model service processes it. This example uses the default Aspose service over the network; use synthetic or permitted content and follow your organization's data-handling policy.

### **Can I control the amount of detail in generated slides?**

Yes. Select the content amount when generating. This example requests brief content; the prompt also describes the desired scope.

## **Guides**

- [AI-Powered Multilingual Slide Generator (.NET)](/slides/net/ai/generator/)

Related feature: [Connect your own AI model provider](/slides/features/ai-model-provider/).
