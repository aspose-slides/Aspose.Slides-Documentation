---
title: "Translate Presentation Text with AI"
type: docs
weight: 20
url: /net/examples/ai/translate/
description: "Runnable C# example to translate presentation text with ai, with a complete project, real model calls and editable PowerPoint output."
---

Create a small English deck with ordinary shape text, grouped text and a table cell, translate it to Spanish, and save a separate copy. The program verifies the changed text and retained source, then renders before/after previews.

## Prerequisites and input

Use a current supported .NET10 SDK/runtime and the supplied flexible SDK settings; no exact patch is required.

The example uses only synthetic prompts and creates its input presentation where needed. Generation and translation contact the selected model service.
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
    private static async Task<int> RunExample()
    {
        try
        {
            using (var original = new Presentation())
            {
                original.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
                var shape = original.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 30, 550, 65);
                shape.TextFrame.Text = "Hello world";
                var group = original.Slides[0].Shapes.AddGroupShape();
                group.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 130, 550, 65).TextFrame.Text = "Good morning";
                var table = original.Slides[0].Shapes.AddTable(40, 230, new double[] { 550 }, new double[] { 65 });
                table[0, 0].TextFrame.Text = "Thank you";
                original.Save("original.pptx", SaveFormat.Pptx);
                using var image = original.Slides[0].GetImage(new Size(640, 360));
                image.Save("original.png", Aspose.Slides.ImageFormat.Png);
            }
            byte[] originalHash = System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes("original.pptx"));
            using var deck = new Presentation("original.pptx");
            double originalX = deck.Slides[0].Shapes[0].X;
            using var http = Http("default");
            using var client = new AsposeAIWebClient(http);
            await new SlidesAIAgent(client).TranslateAsync(deck, "Spanish");
            string translated = AllText(deck);
            Require(translated.Contains("hola", StringComparison.OrdinalIgnoreCase) && translated.Contains("buen", StringComparison.OrdinalIgnoreCase) && translated.Contains("gracias", StringComparison.OrdinalIgnoreCase), "Expected Spanish shape, group and table text.");
            deck.Save("translated.pptx", SaveFormat.Pptx);
            using var reopened = new Presentation("translated.pptx");
            Require(AllText(reopened) == translated, "Translated text changed after reopening.");
            Require(reopened.Slides[0].Shapes[0].X == originalX, "Shape position changed.");
            Require(originalHash.SequenceEqual(System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes("original.pptx"))), "Original input changed.");
            using var preview = reopened.Slides[0].GetImage(new Size(640, 360));
            preview.Save("translated.png", Aspose.Slides.ImageFormat.Png);
            Require(Requests.Any(r => r.StatusCode == 200), "No real translation response.");
            Report(new { translated_shape_group_table = true, original_unchanged = true, reopened_text_matches = true, position_retained = true, text = translated, requests = Requests.ToArray() });
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

The program writes "original.pptx", "original.png", "translated.pptx", "translated.png" and a result.json summary in the current directory. Open the PPTX files to edit their text and review the PNG previews at normal size. The source and the generated output are kept separate. Wording varies between model responses; successful execution checks structure and saved text, not a byte-identical deck.

## Limitations

This fixture has no charts or speaker notes. Speaker notes are outside this workflow, and charts can prevent translation. Review language quality and text expansion; retained shape coordinates do not guarantee that every translated paragraph fits.

Continue with the [detailed guide](/slides/net/ai/translator/).


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
