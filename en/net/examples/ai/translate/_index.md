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

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
Set `ASPOSE_LICENSE_PATH` and run `dotnet run -- --mode licensed --allow-network` to make the model call. Configure the provider as described on this page.
The copied program writes its files under `example-output` by default.

```csharp
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
using Aspose.Slides.AI;
using Aspose.Slides.Export;
using Aspose.Slides;

internal static class Program
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

    private static ExampleContext Context = null!;

    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context=context;
        string actionId="ai/translate/block-001";

        context.Prerequisite(context.IsLicensed,"Real AI generation/translation requires an authorized license covering this release. Use --mode licensed with --license PATH or ASPOSE_LICENSE_PATH; evaluation performs no model call.");
        context.Prerequisite(context.Arguments.Contains("--allow-network"),"This recipe contacts a real model service. Add --allow-network only for a service you are authorized to use; no model or credentials are included.");

        int code=await RunExample();
        context.Require(code==0,"The real AI operation failed. See error.json for the error type and observed HTTP statuses; credentials are never written.");
        VerifyResult(actionId);
    });

    private static void VerifyResult(string actionId)
    {
        using var actual=JsonDocument.Parse(File.ReadAllText("result.json"));
        using var expected=JsonDocument.Parse("{\"translated_shape_group_table\":true,\"original_unchanged\":true,\"reopened_text_matches\":true,\"position_retained\":true}");
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        foreach(var field in expected.RootElement.EnumerateObject())
        {
            var value=actual.RootElement;foreach(string part in field.Name.Split('.'))value=value.GetProperty(part);
            string wanted=field.Value.ToString();
            Context.Require(value.ToString()==wanted,"The genuine operation failed its result check: "+field.Name);
            checks[(Context.IsLicensed?"licensed-":"evaluation-")+field.Name.Replace('.','-')]=true;
        }
        if(!Context.IsLicensed){checks["evaluation-semantic-effect"]=true;checks["evaluation-valid-output"]=true;}
    }

    private static readonly ConcurrentBag<RequestResult> Requests = new();

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

internal static class ExampleBootstrap
{
    public static async Task<int> RunAsync(string[] args, Func<ExampleContext, Task> run)
    {
        string start = Environment.CurrentDirectory;
        string output = Path.Combine(start, "example-output");
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        string? mode = null;
        var recipeArgs = new List<string>();

        try
        {
            for (int i = 0; i < args.Length; i++)
            {
                string option = args[i];
                if (option is not ("--output" or "--license" or "--mode"))
                {
                    recipeArgs.Add(option);
                    continue;
                }
                if (++i == args.Length)
                    throw new ExamplePrerequisiteException("Supply a value for " + option);
                if (option == "--output")
                    output = Path.GetFullPath(args[i], start);
                else if (option == "--license")
                    licensePath = args[i];
                else
                    mode = args[i];
            }

            mode ??= string.IsNullOrWhiteSpace(licensePath) ? "evaluation" : "licensed";
            if (mode is not ("evaluation" or "licensed"))
                throw new ExamplePrerequisiteException("Use --mode evaluation or --mode licensed.");
            if (mode == "licensed")
            {
                if (string.IsNullOrWhiteSpace(licensePath))
                    throw new ExamplePrerequisiteException("Set ASPOSE_LICENSE_PATH to a valid Aspose.Slides license.");
                var license = new License();
                license.SetLicense(Path.GetFullPath(licensePath, start));
                if (!license.IsLicensed())
                    throw new ExamplePrerequisiteException("The supplied license could not be applied.");
            }

            Directory.CreateDirectory(output);
            Console.WriteLine("Output: " + output);
            Environment.CurrentDirectory = output;
            await run(new ExampleContext(output, mode, recipeArgs.ToArray()));
            return 0;
        }
        catch (ExamplePrerequisiteException error)
        {
            Console.Error.WriteLine(error.Message);
            return 2;
        }
        finally
        {
            Environment.CurrentDirectory = start;
        }
    }
}

internal sealed class ExampleContext(string output, string mode, string[] arguments)
{
    public string OutputRoot { get; } = output;
    public string Mode { get; } = mode;
    public bool IsLicensed => Mode == "licensed";
    public string[] Arguments { get; } = arguments;

    public string ExpectedText(string text) => IsLicensed || text.Length <= 5
        ? text
        : text[..5] + "... text has been truncated due to evaluation version limitation.";

    public void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    public void Prerequisite(bool condition, string message)
    {
        if (!condition) throw new ExamplePrerequisiteException(message);
    }
}

internal sealed class ExamplePrerequisiteException(string message) : Exception(message);
```

## Run and inspect the downloaded project

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
