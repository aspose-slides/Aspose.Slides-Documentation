---
title: Connect your own AI model provider
description: Connect the library's AI features to your chosen model endpoint.
type: docs
url: /features/ai-model-provider/
weight: 1530
feature_id: ai-model-provider
feature_group: ai
translationKey: slides-feature-ai-model-provider
feature_catalogue_version: 3
feature_guides:
- /slides/net/ai/
---

## **Overview**

Configure a model client with your provider, model name and credentials, or supply a custom client implementation. This lets the Slides AI workflow use a model endpoint chosen by your application. The presentation-generation or translation operation then uses that client.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/). Optionally set ASPOSE_SLIDES_LICENSE to your license file to avoid evaluation limits. Configure an [OpenAI-compatible client](https://reference.aspose.com/slides/net/aspose.slides.ai/openaicompatiblewebclient/openaicompatiblewebclient/) using SLIDES_AI_BASE_URL, SLIDES_AI_MODEL and SLIDES_AI_API_KEY from your environment. Supply a permitted service and its actual model identifier; the base URL must match that service's API. This standalone example generates a short water-cycle deck through the selected provider, rather than using the default service.

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
var baseUrl = Environment.GetEnvironmentVariable("SLIDES_AI_BASE_URL");
var model = Environment.GetEnvironmentVariable("SLIDES_AI_MODEL");
var apiKey = Environment.GetEnvironmentVariable("SLIDES_AI_API_KEY");
if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(apiKey))
{
    Console.WriteLine("Set SLIDES_AI_BASE_URL, SLIDES_AI_MODEL and SLIDES_AI_API_KEY for your model service.");
    return;
}
using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(120) };
using var client = new OpenAICompatibleWebClient(model, apiKey, baseUrl, http);
var agent = new SlidesAIAgent(client);
var instruction = "Create a short English presentation about the water cycle. Cover evaporation, condensation, and precipitation. Use ordinary text slides with a title and one short paragraph. No tables, charts or images. For every section in the JSON, use the integer 0 for its type field instead of a type name. Return only raw JSON without Markdown code fences or commentary.";
using IPresentation presentation = await agent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Brief);
presentation.Save("generated.pptx", SaveFormat.Pptx);
Console.WriteLine("Generated slides: " + presentation.Slides.Count);
```

## **FAQ**

### **Can I point it at an OpenAI-compatible endpoint?**

Yes. The compatible-client option accepts a configured base URL for such an endpoint.

### **Where should I keep the model API key?**

Keep it in a secret store or environment variable read by your application. Do not put it in presentation text, source control or logs.

### **Can I switch provider clients without rewriting my presentation workflow?**

Yes. Pass the appropriate client to the AI agent. Endpoint authentication, model names and response compatibility still need configuration and testing for the selected provider.

## **Guides**

- [AI Features in Aspose.Slides (.NET)](/slides/net/ai/)

Related feature: [Connect a self-hosted AI endpoint](/slides/features/ai-local-endpoint/).
