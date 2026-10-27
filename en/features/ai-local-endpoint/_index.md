---
title: Connect a self-hosted AI endpoint
description: Use a self-hosted OpenAI-compatible endpoint for library AI calls.
type: docs
url: /features/ai-local-endpoint/
weight: 1540
feature_id: ai-local-endpoint
feature_group: ai
translationKey: slides-feature-ai-local-endpoint
feature_catalogue_version: 3
feature_guides:
- /slides/net/ai/
---

## **Overview**

Point the library's compatible AI client at a model endpoint running on infrastructure you control. The Slides workflow sends its requests to that endpoint, which can be local to the application or on your own network. The model service is supplied and managed separately.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/). Optionally set ASPOSE_SLIDES_LICENSE to your license file to avoid evaluation limits. Start a caller-managed model server with an OpenAI-compatible chat-completions API before running this example. Set SLIDES_AI_BASE_URL to its API base URL, SLIDES_AI_MODEL to its served model name and SLIDES_AI_API_KEY to its configured token. The [compatible client](https://reference.aspose.com/slides/net/aspose.slides.ai/openaicompatiblewebclient/openaicompatiblewebclient/) sends the synthetic prompt to that service. A local model and server are separate prerequisites, and compatibility depends on the selected model and response format.

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

### **Does the Slides library include an offline language model?**

No. You provide the model server. Compatibility depends on the endpoint and on the model returning the response structure the workflow expects.

### **What response compatibility does a local endpoint need?**

It needs the chat-completions request and response format expected by the selected client, including generated message content. Generation also needs model responses that follow the requested content schema.

### **Can the model service run on a separate machine on my network?**

Yes. Point the client at a reachable server your organization controls, with appropriate network access and authentication. The model does not have to run inside the presentation process.

## **Guides**

- [AI Features in Aspose.Slides (.NET)](/slides/net/ai/)

Related feature: [Connect your own AI model provider](/slides/features/ai-model-provider/).
