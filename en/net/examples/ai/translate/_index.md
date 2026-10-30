---
title: "Translate Presentation Text with AI"
type: docs
weight: 20
url: /net/examples/ai/translate/
description: "Runnable C# example to translate presentation text with ai, with a complete project, real model calls and editable PowerPoint output."
---

Create a small English deck with ordinary shape text, grouped text and a table cell, translate it to Spanish, and save a separate copy. The program verifies the changed text and retained source, then renders before/after previews.

## Prerequisites and input

[Download the complete project](example.zip). It includes every source file, SDK settings and locked dependencies. Install the pinned .NET SDK and set `ASPOSE_LICENSE_PATH` to your valid license file before running the full-content checks. See [installation](/slides/net/installation/) and [licensing](/slides/net/licensing/).

The example uses only synthetic prompts and creates its input presentation where needed. Generation and translation contact the selected model service. 
## Complete C# example

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

internal static class Program
{
    private const string Prompt = "Create a short English presentation about the water cycle. Cover evaporation, condensation and precipitation. Use ordinary text slides with a title and a short paragraph. No charts, tables or images. For every section in the JSON, use the integer 0 for its type field instead of a type name. Return raw JSON without Markdown code fences or commentary.";
    private static readonly ConcurrentBag<RequestResult> Requests = new();

    private static async Task<int> Main(string[] args)
    {
        try
        {
            string licensePath = Required("ASPOSE_LICENSE_PATH");
            new License().SetLicense(licensePath);
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

    private static string Required(string name)
    {
        string? value = Environment.GetEnvironmentVariable(name);
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidOperationException("Set " + name + " before running this example.");
        return value;
    }

    private static HttpClient Http(string provider)
    {
        double timeout = 180;
        if (double.TryParse(Environment.GetEnvironmentVariable("SLIDES_AI_TIMEOUT_SECONDS"), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double configured)) timeout = configured;
        if (timeout <= 0) throw new InvalidOperationException("Timeout must be positive.");
        return new HttpClient(new TraceHandler(provider)) { Timeout = TimeSpan.FromSeconds(timeout) };
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    private static string AllText(IPresentation deck)
    {
        var text = new StringBuilder();
        void Read(IShapeCollection shapes)
        {
            foreach (IShape shape in shapes)
            {
                if (shape is IAutoShape auto && auto.TextFrame != null) text.AppendLine(auto.TextFrame.Text);
                if (shape is IGroupShape group) Read(group.Shapes);
                if (shape is ITable table)
                    for (int row = 0; row < table.Rows.Count; row++)
                        for (int column = 0; column < table.Columns.Count; column++) text.AppendLine(table[column, row].TextFrame.Text);
            }
        }
        foreach (ISlide slide in deck.Slides) Read(slide.Shapes);
        return text.ToString();
    }

    private static int VerifyGenerated(IPresentation deck, string path)
    {
        string live = AllText(deck);
        Require(deck.Slides.Count >= 2 && live.Length > 150 && live.Contains("water", StringComparison.OrdinalIgnoreCase), "Generated content did not describe the requested topic.");
        deck.Save(path, SaveFormat.Pptx);
        using var reopened = new Presentation(path);
        Require(reopened.Slides.Count == deck.Slides.Count && AllText(reopened) == live, "Generated editable text changed after reopening.");
        using var image = reopened.Slides[0].GetImage(new Size(640, 360));
        image.Save(Path.ChangeExtension(path, ".png"), Aspose.Slides.ImageFormat.Png);
        return reopened.Slides.Count;
    }

    private static void Report(object result)
    {
        string json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }

    private sealed record RequestResult(string Provider, int StatusCode);
    private sealed class TraceHandler : DelegatingHandler
    {
        private readonly string provider;
        public TraceHandler(string provider) : base(new HttpClientHandler()) { this.provider = provider; }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            HttpResponseMessage response = await base.SendAsync(request, token);
            Requests.Add(new RequestResult(provider, (int)response.StatusCode));
            return response;
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
