---
title: "Build a Presentation Conversion Endpoint"
type: docs
weight: 10
url: /net/examples/application-integration/web-api/
description: "Complete runnable C# application for build a presentation conversion endpoint, with real host execution and reproducible input."
---

The complete ASP.NET Core application accepts a PPTX presentation as the raw POST body at /convert and returns application/pdf. It limits uploads to 8 MiB, bounds processing to two independent presentation instances, uses a unique temporary directory per request, and connects request cancellation to the library interruption token.

## Prerequisites

[Download the complete project](example.zip). Install the pinned .NET SDK and set `ASPOSE_LICENSE_PATH` to your valid file license for the full-content checks. See [installation](/slides/net/installation/) and [licensing](/slides/net/licensing/). The project generates synthetic inputs in self-test mode; no private input or credential is included.

## Complete application

```csharp
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

internal static class Program
{
    private const int RequestLimit = 8 * 1024 * 1024;
    private static readonly SemaphoreSlim Slots = new(2);
    private static readonly ConcurrentDictionary<string, byte> Workspaces = new();
    private static int active;
    private static int maximumActive;

    private static async Task Main(string[] args)
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath)) new License().SetLicense(licensePath);
        bool selfTest = args.Contains("--self-test");
        var builder = WebApplication.CreateBuilder(args.Where(a => a != "--self-test").ToArray());
        builder.WebHost.UseUrls(selfTest ? "http://127.0.0.1:0" : "http://127.0.0.1:5088");
        builder.WebHost.ConfigureKestrel(options => options.Limits.MaxRequestBodySize = null);
        await using var app = builder.Build();
        app.MapPost("/convert", (Func<HttpContext, Task<IResult>>)ConvertPresentation);
        if (!selfTest) { await app.RunAsync(); return; }
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
            await Task.Run(() =>
            {
                if (PresentationFactory.Instance.GetPresentationInfo(input).LoadFormat != LoadFormat.Pptx) throw new InvalidDataException("Expected PPTX content.");
                input.Position = 0;
                using var presentation = new Presentation(input, new LoadOptions { LoadFormat = LoadFormat.Pptx, InterruptionToken = interruption.Token });
                presentation.Save(output, SaveFormat.Pdf);
            });
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
        string json = JsonSerializer.Serialize(new { valid_responses = simultaneous.Length, invalid_rejected = true, oversized_rejected = true, cancellation_observed = true, temporary_workspaces_cleaned = Workspaces.IsEmpty, maximum_active = maximumActive, concurrency_bound = 2 });
        await File.WriteAllTextAsync("result.json", json);
        Console.WriteLine(json);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }
}
```

## Run and verify

```text
dotnet run --project Example.csproj --configuration Release -- --self-test
```

Run normally to listen on http://127.0.0.1:5088. POST the file bytes with your HTTP client. Add --self-test to start a real ephemeral local server, upload valid/invalid/oversized files concurrently, cancel an active job, and verify temporary-directory cleanup. The sample uses loopback hosting and stable error codes. Add authentication, operational limits and deployment configuration appropriate to your own application before exposing it.

The verification run writes result.json plus "input.pptx", "response-0.pdf", "response-1.pdf", "response-2.pdf". Inspect the returned PDF files and the manifest or image preview. Exit 0 requires the named assertions to pass; an invalid input is reported explicitly.

Read the [detailed Docker guide](/slides/net/how-to-run-aspose-slides-in-docker/) for package and native-library choices when adapting Linux hosting.
