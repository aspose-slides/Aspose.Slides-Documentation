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

internal static partial class Program
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
            Context.Pass("application-integration/web-api/serve", "real loopback Kestrel listener started");
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
}
