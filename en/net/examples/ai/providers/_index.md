---
title: "Configure an AI Provider"
type: docs
weight: 40
url: /net/examples/ai/providers/
description: "Runnable C# example to configure an ai provider, with a complete project, real model calls and editable PowerPoint output."
---

Run the same generation request through the default Aspose client and a caller-configured OpenAI-compatible endpoint. The complete project reads the endpoint, model identifier, API key and timeout from environment variables and saves separate editable results.

## **Prerequisites and input**

Use a current supported .NET10 SDK/runtime and the supplied flexible SDK settings; no exact patch is required.

The example uses only synthetic prompts and creates its input presentation where needed. Generation and translation contact the selected model service. Set `SLIDES_AI_BASE_URL`, `SLIDES_AI_MODEL` and `SLIDES_AI_API_KEY` for your compatible service. Optional `SLIDES_AI_TIMEOUT_SECONDS` controls the HTTP timeout. Use `--configured-only` after `--` when running only that provider.


## **Complete C# example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
Set `ASPOSE_LICENSE_PATH` and run `dotnet run -- --mode licensed --allow-network` to make the model call. Configure the provider as described on this page.
The copied program writes its files under `example-output` by default.

The copied program requires an authorized Aspose.Slides license in `ASPOSE_LICENSE_PATH` and explicit `--allow-network` consent. Missing either prevents all model requests. Set `SLIDES_AI_TIMEOUT_SECONDS` to change the 180-second timeout. Run the copied file with `dotnet run -- --allow-network`; generation requires service access and may take time. The program reports error types without printing credentials. Set `SLIDES_AI_BASE_URL`, `SLIDES_AI_MODEL`, and `SLIDES_AI_API_KEY` for your OpenAI-compatible service. `dotnet run -- --allow-network` runs the default and configured providers; add `--configured-only` to call only your configured provider.

```csharp
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

internal static class Program
{
    private static async Task<int> Main(string[] args)
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (string.IsNullOrWhiteSpace(licensePath) || !args.Contains("--allow-network"))
        {
            Console.Error.WriteLine("Set ASPOSE_LICENSE_PATH to an authorized license and pass --allow-network. No request was sent.");
            return 2;
        }

        var timeoutSeconds = 180.0;
        var timeoutSetting = Environment.GetEnvironmentVariable("SLIDES_AI_TIMEOUT_SECONDS");
        if (timeoutSetting != null && (!double.TryParse(timeoutSetting, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out timeoutSeconds) || !double.IsFinite(timeoutSeconds) || timeoutSeconds <= 0))
        {
            Console.Error.WriteLine("SLIDES_AI_TIMEOUT_SECONDS must be a finite positive number.");
            return 2;
        }

        try
        {
            var license = new License();
            license.SetLicense(licensePath);
            if (!license.IsLicensed())
            {
                Console.Error.WriteLine("The license was not applied. No request was sent.");
                return 2;
            }

            Directory.CreateDirectory("example-output");
            using var http = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(timeoutSeconds)
            };
            var configuredOnly = args.Contains("--configured-only");
            var baseUrl = Environment.GetEnvironmentVariable("SLIDES_AI_BASE_URL");
            var model = Environment.GetEnvironmentVariable("SLIDES_AI_MODEL");
            var apiKey = Environment.GetEnvironmentVariable("SLIDES_AI_API_KEY");
            if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(apiKey))
            {
                Console.Error.WriteLine("Set SLIDES_AI_BASE_URL, SLIDES_AI_MODEL, and SLIDES_AI_API_KEY. No request was sent.");
                return 2;
            }

            if (!configuredOnly)
            {
                using var defaultHttp = new HttpClient
                {
                    Timeout = http.Timeout
                };
                using var defaultProvider = new AsposeAIWebClient(defaultHttp);
                var defaultAgent = new SlidesAIAgent(defaultProvider);
                using var defaultPresentation = await defaultAgent.GeneratePresentationAsync(Prompt, PresentationContentAmountType.Brief);
                if (!SaveEditablePresentation(defaultPresentation, "example-output/default-generated.pptx"))
                    return 1;
            }

            using var configuredProvider = new OpenAICompatibleWebClient(model, apiKey, baseUrl, http);
            var configuredAgent = new SlidesAIAgent(configuredProvider);
            using var configuredPresentation = await configuredAgent.GeneratePresentationAsync(Prompt, PresentationContentAmountType.Brief);
            if (!SaveEditablePresentation(configuredPresentation, "example-output/configured-generated.pptx"))
                return 1;
            return 0;
        }
        catch (OperationCanceledException)
        {
            Console.Error.WriteLine("The AI request timed out or was cancelled.");
            return 4;
        }
        catch (HttpRequestException)
        {
            Console.Error.WriteLine("The AI service rejected the request or could not be reached. Check provider settings and authorization.");
            return 3;
        }
        catch (Exception error)
        {
            Console.Error.WriteLine("AI operation failed: " + error.GetType().Name + ". Check the license and service configuration.");
            return 2;
        }
    }

    private const string Prompt = "Create a short English presentation about the water cycle. Cover evaporation, condensation and precipitation. Use ordinary text slides with a title and a short paragraph. No charts, tables or images. For every section in the JSON, use the integer 0 for its type field instead of a type name. Return raw JSON without Markdown code fences or commentary.";
    private static string ReadPresentationText(IPresentation deck)
    {
        var text = new StringBuilder();
        void Read(IShapeCollection shapes)
        {
            foreach (IShape shape in shapes)
            {
                if (shape is IAutoShape auto && auto.TextFrame != null)
                    text.AppendLine(auto.TextFrame.Text);
                if (shape is IGroupShape group)
                    Read(group.Shapes);
                if (shape is ITable table)
                    for (int row = 0; row < table.Rows.Count; row++)
                        for (int column = 0; column < table.Columns.Count; column++)
                            text.AppendLine(table[column, row].TextFrame.Text);
            }
        }

        foreach (ISlide slide in deck.Slides)
            Read(slide.Shapes);
        return text.ToString();
    }

    private static bool SaveEditablePresentation(IPresentation generated, string outputPath)
    {
        var generatedText = ReadPresentationText(generated);
        generated.Save(outputPath, SaveFormat.Pptx);
        using var reopened = new Presentation(outputPath);
        if (reopened.Slides.Count == 0 || ReadPresentationText(reopened) != generatedText)
        {
            Console.Error.WriteLine("The generated text was not retained after reopening.");
            return false;
        }

        using var preview = reopened.Slides[0].GetImage(new Size(640, 360));
        preview.Save(Path.ChangeExtension(outputPath, ".png"), Aspose.Slides.ImageFormat.Png);
        Console.WriteLine($"Saved editable presentation: {outputPath}, {reopened.Slides.Count} slides.");
        return true;
    }
}
```

## **Run and inspect the downloaded project**

```text
dotnet run --project Example.csproj --configuration Release
```

The program writes "default-generated.pptx", "default-generated.png", "configured-generated.pptx", "configured-generated.png" and a result.json summary in the current directory. Open the PPTX files to edit their text and review the PNG previews at normal size. The source and the generated output are kept separate. Wording varies between model responses; successful execution checks structure and saved text, not a byte-identical deck.

## **Limitations**

Provide a compatible service you are authorized to use and its real model identifier. The compatible client is an adapter, not a bundled AI model. Service authentication, request limits and model fees belong to the chosen provider. The program reports configuration, HTTP and cancellation failures without printing keys; --configured-only skips the default-service demonstration.

Continue with the [detailed guide](/slides/net/ai/generator/).


## **Download, prerequisites and run**

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
