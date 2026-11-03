---
title: "Build a Presentation Conversion Endpoint"
type: docs
weight: 10
url: /net/examples/application-integration/web-api/
description: "Complete runnable C# application for build a presentation conversion endpoint, with real host execution and reproducible input."
---

The complete ASP.NET Core application accepts a PPTX presentation as the raw POST body at /convert and returns application/pdf. It limits uploads to 8 MiB, bounds active HTTP processing to two requests and serializes SDK conversion within each process, uses a unique temporary directory per request, and connects request cancellation to the library interruption token.

## Prerequisites

Use a current supported .NET10 SDK/runtime and the supplied flexible SDK settings; no exact patch is required.

## Complete application

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
Use an ASP.NET Core project, or add a framework reference to `Microsoft.AspNetCore.App`.
The copied program writes its files under `example-output` by default.

```csharp
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using System;
using Aspose.Slides.Export;
using Aspose.Slides;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

internal static class Program
{
    private const int RequestLimit = 8 * 1024 * 1024;

    private static readonly SemaphoreSlim Slots = new(2);

    private static readonly SemaphoreSlim SdkGate = new(1);

    private static int nativeActive;

    private static int maxSdkActive;

    private static readonly ConcurrentDictionary<string, byte> Workspaces = new();

    private static int active;

    private static int maximumActive;

    private static async Task RunExample(string[] args)
    {
        bool selfTest = args.Contains("--self-test");
        var builder = WebApplication.CreateBuilder(args.Where(a => a != "--self-test").ToArray());
        builder.WebHost.UseUrls(selfTest ? "http://127.0.0.1:0" : "http://127.0.0.1:5088");
        builder.WebHost.ConfigureKestrel(options => options.Limits.MaxRequestBodySize = null);
        await using var app = builder.Build();
        app.MapPost("/convert", (Func<HttpContext, Task<IResult>>)ConvertPresentation);
        if (!selfTest)
        {
            await app.StartAsync();
            await app.WaitForShutdownAsync();
            return;
        }
        await app.StartAsync();
        try { await Verify(app.Urls.Single()); }
        finally { await app.StopAsync(); }
    }

    private static async Task<IResult> ConvertPresentation(HttpContext context)
    {
        if (context.Request.ContentLength > RequestLimit)
            return Results.Json(new { error = "request_too_large" }, statusCode: 413);
        using var input = new MemoryStream();
        var buffer = new byte[81920];
        while (true)
        {
            int read = await context.Request.Body.ReadAsync(buffer, context.RequestAborted);
            if (read == 0) break;
            if (input.Length + read > RequestLimit)
                return Results.Json(new { error = "request_too_large" }, statusCode: 413);
            await input.WriteAsync(buffer.AsMemory(0, read), context.RequestAborted);
        }
        if (input.Length == 0) return Results.Json(new { error = "empty_presentation" }, statusCode: 400);
        await Slots.WaitAsync(context.RequestAborted);
        string workspace = Path.Combine(Path.GetTempPath(), "slides-api-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(workspace);
        Workspaces.TryAdd(workspace, 0);
        int current = Interlocked.Increment(ref active);
        int previous;
        do { previous = maximumActive; } while (current > previous && Interlocked.CompareExchange(ref maximumActive, current, previous) != previous);
        var interruption = new InterruptionTokenSource();
        using var registration = context.RequestAborted.Register(interruption.Interrupt);
        try
        {
            input.Position = 0;
            string output = Path.Combine(workspace, "result.pdf");
            await SdkGate.WaitAsync(context.RequestAborted);
            int sdkCurrent = Interlocked.Increment(ref nativeActive);
            int sdkPrevious;
            do { sdkPrevious = maxSdkActive; } while (sdkCurrent > sdkPrevious && Interlocked.CompareExchange(ref maxSdkActive, sdkCurrent, sdkPrevious) != sdkPrevious);
            try
            {
                if (PresentationFactory.Instance.GetPresentationInfo(input).LoadFormat != LoadFormat.Pptx) throw new InvalidDataException("Expected PPTX content.");
                await Task.Run(() =>
                {
                    input.Position = 0;
                    using var presentation = new Presentation(input, new LoadOptions { LoadFormat = LoadFormat.Pptx, InterruptionToken = interruption.Token });
                    presentation.Save(output, SaveFormat.Pdf);
                });
            }
            finally
            {
                Interlocked.Decrement(ref nativeActive);
                SdkGate.Release();
            }
            byte[] pdf = await File.ReadAllBytesAsync(output, context.RequestAborted);
            return Results.File(pdf, "application/pdf", "presentation.pdf");
        }
        catch (Exception) when (context.RequestAborted.IsCancellationRequested)
        {
            return Results.Json(new { error = "request_cancelled" }, statusCode: 499);
        }
        catch (Exception)
        {
            return Results.Json(new { error = "invalid_presentation" }, statusCode: 400);
        }
        finally
        {
            Directory.Delete(workspace, recursive: true);
            Workspaces.TryRemove(workspace, out _);
            Interlocked.Decrement(ref active);
            Slots.Release();
        }
    }

    private static ExampleContext Context = null!;

    private static string LaunchDirectory = "";

    private static Task<int> Main(string[] args)
    {
        LaunchDirectory=Environment.CurrentDirectory;
        return ExampleBootstrap.RunAsync(args, async context =>
        {
            Context=context;
            string actionId=context.Arguments.Contains("--self-test")?"application-integration/web-api/block-001":"application-integration/web-api/serve";
            await RunExample(context.Arguments);
            if(context.Arguments.Contains("--self-test"))VerifyResult(actionId);
        });
    }

    private static void VerifyResult(string actionId)
    {
        using var actual=JsonDocument.Parse(File.ReadAllText("result.json"));
        using var expected=JsonDocument.Parse("{\"valid_responses\":3,\"invalid_rejected\":true,\"oversized_rejected\":true,\"cancellation_observed\":true,\"temporary_workspaces_cleaned\":true,\"concurrency_bound\":2,\"sdk_concurrency_bound\":1,\"maximum_sdk_active\":1}");
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

    private static byte[] Fixture(int slides)
    {
        using var presentation = new Presentation();
        var layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        for (int i = 0; i < slides; i++)
        {
            var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(layout);
            slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 100).TextFrame.Text = "API Alpha " + (i + 1);
        }
        using var bytes = new MemoryStream();
        presentation.Save(bytes, SaveFormat.Pptx);
        return bytes.ToArray();
    }

    private static async Task Verify(string address)
    {
        using var client = new HttpClient { BaseAddress = new Uri(address), Timeout = TimeSpan.FromSeconds(90) };
        byte[] input = Fixture(2);
        await File.WriteAllBytesAsync("input.pptx", input);
        var simultaneous = await Task.WhenAll(Enumerable.Range(0, 3).Select(async i =>
        {
            using var response = await client.PostAsync("/convert", new ByteArrayContent(input));
            byte[] pdf = await response.Content.ReadAsByteArrayAsync();
            Require(response.StatusCode == HttpStatusCode.OK && response.Content.Headers.ContentType?.MediaType == "application/pdf", "Expected a PDF response.");
            Require(pdf.Length > 500 && System.Text.Encoding.ASCII.GetString(pdf, 0, 5) == "%PDF-", "Expected PDF bytes.");
            await File.WriteAllBytesAsync("response-" + i + ".pdf", pdf);
            return true;
        }));
        using var invalid = await client.PostAsync("/convert", new ByteArrayContent(new byte[] { 1, 2, 3 }));
        Require(invalid.StatusCode == HttpStatusCode.BadRequest && (await invalid.Content.ReadAsStringAsync()).Contains("invalid_presentation"), "Invalid upload needs a stable 400 response.");
        using var oversized = await client.PostAsync("/convert", new ByteArrayContent(new byte[RequestLimit + 1]));
        Require((int)oversized.StatusCode == 413, "Oversized upload must be rejected.");
        using var cancellation = new CancellationTokenSource();
        var pending = client.PostAsync("/convert", new ByteArrayContent(Fixture(100)), cancellation.Token);
        for (int i = 0; i < 500 && Volatile.Read(ref active) == 0; i++) await Task.Delay(2);
        Require(Volatile.Read(ref active) > 0, "Cancellation test must reach presentation processing.");
        cancellation.Cancel();
        bool cancelled = false;
        try { using var unused = await pending; } catch (OperationCanceledException) { cancelled = true; }
        for (int i = 0; i < 1000 && Volatile.Read(ref active) > 0; i++) await Task.Delay(5);
        Require(cancelled && active == 0 && Workspaces.IsEmpty, "Cancellation must clean its workspace.");
        Require(maximumActive <= 2, "Concurrency bound exceeded.");
        Require(maxSdkActive == 1 && nativeActive == 0, "The SDK conversion section must finish with maximum concurrency one.");
        string json = JsonSerializer.Serialize(new { valid_responses = simultaneous.Length, invalid_rejected = true, oversized_rejected = true, cancellation_observed = true, temporary_workspaces_cleaned = Workspaces.IsEmpty, maximum_active = maximumActive, concurrency_bound = 2, sdk_concurrency_bound = 1, maximum_sdk_active = maxSdkActive });
        await File.WriteAllTextAsync("result.json", json);
        Console.WriteLine(json);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
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

## Run and verify

```text
dotnet run --project Example.csproj --configuration Release -- --self-test
```

Run normally to listen on http://127.0.0.1:5088. POST the file bytes with your HTTP client. Add --self-test to start a real ephemeral local server, upload valid/invalid/oversized files concurrently, cancel an active job, and verify temporary-directory cleanup. The sample uses loopback hosting and stable error codes. Add authentication, operational limits and deployment configuration appropriate to your own application before exposing it.

The verification run writes result.json plus "input.pptx", "response-0.pdf", "response-1.pdf", "response-2.pdf". Inspect the returned PDF files and the manifest or image preview. Exit 0 requires the named assertions to pass; an invalid input is reported explicitly.

Read the [detailed Docker guide](/slides/net/how-to-run-aspose-slides-in-docker/) for package and native-library choices when adapting Linux hosting.


## Download, prerequisites and run

[Download the complete project](example.zip) and open `Example.sln`. The stable
net8.0/C#12 project accepts compatible installed release SDKs and explicitly runs
on the current .NET10 runtime. No exact SDK patch or locked restore is required.
Bundled Noto Sans fonts include their redistribution notice. See
[setup and supported environments](/slides/net/examples/getting-started/).

The bootstrap prints the separate output workspace. Explicit `--mode evaluation`
ignores all license settings; `--mode licensed` accepts your authorized license
through `--license PATH` or ASPOSE_LICENSE_PATH. No license or credential is included.

Default Run/F5 starts the real loopback API. Use `--self-test` for the finite genuine HTTP/cancellation checks; startup alone does not claim those checks passed.

HTTP request processing is bounded to two active requests. Recognition, presentation loading, PDF saving and disposal are serialized in one SDK critical section per process. This is a mitigation for an observed intermittent native fontconfig crash, not a proven vendor fix. For parallel SDK conversions, use separate worker processes; see [the official multithreading guidance](https://docs.aspose.com/slides/net/multithreading/).
