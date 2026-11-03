---
title: "Configure an AI Provider"
type: docs
weight: 40
url: /net/examples/ai/providers/
description: "Runnable C# example to configure an ai provider, with a complete project, real model calls and editable PowerPoint output."
---

Run the same generation request through the default Aspose client and a caller-configured OpenAI-compatible endpoint. The complete project reads the endpoint, model identifier, API key and timeout from environment variables and saves separate editable results.

## Prerequisites and input

Use a current supported .NET10 SDK/runtime and the supplied flexible SDK settings; no exact patch is required.

The example uses only synthetic prompts and creates its input presentation where needed. Generation and translation contact the selected model service. Set `SLIDES_AI_BASE_URL`, `SLIDES_AI_MODEL` and `SLIDES_AI_API_KEY` for your compatible service. Optional `SLIDES_AI_TIMEOUT_SECONDS` controls the HTTP timeout. Use `--configured-only` after `--` when running only that provider.


## Complete C# example

The code below shows the main operation. The runnable download includes [ExampleSupport.cs](ExampleSupport.cs) with the entry point and supporting code.

```csharp
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

internal static partial class Program
{
    private const string Prompt = "Create a short English presentation about the water cycle. Cover evaporation, condensation and precipitation. Use ordinary text slides with a title and a short paragraph. No charts, tables or images. For every section in the JSON, use the integer 0 for its type field instead of a type name. Return raw JSON without Markdown code fences or commentary.";

    private static async Task<int> RunExample(string[] args)
    {
        try
        {
            string baseUrl = Required("SLIDES_AI_BASE_URL");
            string model = Required("SLIDES_AI_MODEL");
            string key = Required("SLIDES_AI_API_KEY");
            bool configuredOnly = args.Contains("--configured-only");
            int completed = 0;
            if (!configuredOnly)
            {
                using var defaultHttp = Http("default");
                using var defaultClient = new AsposeAIWebClient(defaultHttp);
                using IPresentation deck = await new SlidesAIAgent(defaultClient).GeneratePresentationAsync(Prompt, PresentationContentAmountType.Brief);
                VerifyGenerated(deck, "default-generated.pptx");
                completed++;
            }
            using var configuredHttp = Http("configured");
            using var configuredClient = new OpenAICompatibleWebClient(model, key, baseUrl, configuredHttp);
            using IPresentation configuredDeck = await new SlidesAIAgent(configuredClient).GeneratePresentationAsync(Prompt, PresentationContentAmountType.Brief);
            VerifyGenerated(configuredDeck, "configured-generated.pptx");
            completed++;
            Require(Requests.Any(r => r.Provider == "configured" && r.StatusCode == 200), "Configured provider did not return a model response.");
            Report(new { providers_checked = completed, configured_provider_succeeded = true, reopened_text_matches = true, requests = Requests.ToArray() });
            return 0;
        }
        catch (Exception error)
        {
            int exit = error is OperationCanceledException ? 4 : error is HttpRequestException ? 3 : 2;
            File.WriteAllText("error.json", JsonSerializer.Serialize(new { error_type = error.GetType().Name, requests = Requests.ToArray(), exit_code = exit }));
            Console.Error.WriteLine("AI example failed: " + error.GetType().Name + ". Check configuration and provider access.");
            return exit;
        }
    }
}
```

## Run and inspect the result

```text
dotnet run --project Example.csproj --configuration Release
```

The program writes "default-generated.pptx", "default-generated.png", "configured-generated.pptx", "configured-generated.png" and a result.json summary in the current directory. Open the PPTX files to edit their text and review the PNG previews at normal size. The source and the generated output are kept separate. Wording varies between model responses; successful execution checks structure and saved text, not a byte-identical deck.

## Limitations

Provide a compatible service you are authorized to use and its real model identifier. The compatible client is an adapter, not a bundled AI model. Service authentication, request limits and model fees belong to the chosen provider. The program reports configuration, HTTP and cancellation failures without printing keys; --configured-only skips the default-service demonstration.

Continue with the [detailed guide](/slides/net/ai/generator/).


## Download, prerequisites and run

[Download the complete project](example.zip) and open `Example.sln`. The stable
net8.0/C#12 project accepts compatible installed release SDKs and explicitly runs
on the current .NET10 runtime. No exact SDK patch or locked restore is required.
Bundled Noto Sans fonts include their redistribution notice. See
[setup and supported environments](/slides/net/examples/getting-started/).

The bootstrap prints the separate output workspace. Explicit `--mode evaluation`
ignores all license settings; `--mode licensed` accepts your authorized license
through `--license PATH` or ASPOSE_LICENSE_PATH. No license or credential is included.

Default evaluation performs no model request and reports the missing prerequisite
with exit2. To execute the real generation/translation, opt in explicitly:

```text
dotnet run --project Example.csproj -- --mode licensed --allow-network
```

Configured providers also need their endpoint, real model identifier and API key.
A prerequisite diagnostic never counts as a generated or translated presentation.
