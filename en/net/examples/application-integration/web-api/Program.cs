using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
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
    private static readonly SemaphoreSlim RequestSlots = new(2);
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
        try
        {
            await Verify(app.Urls.Single());
        }
        finally
        {
            await app.StopAsync();
        }
    }

    private static async Task<IResult> ConvertPresentation(HttpContext context)
    {
        if (context.Request.ContentLength > RequestLimit)
            return Results.Json(new { error = "request_too_large" }, statusCode: 413);
        bool admitted = false;
        string? workspace = null;
        try
        {
            await RequestSlots.WaitAsync(context.RequestAborted);
            admitted = true;
            int current = Interlocked.Increment(ref active);
            int previous;
            do { previous = maximumActive; }
            while (current > previous && Interlocked.CompareExchange(ref maximumActive, current, previous) != previous);
            byte[]? requestBytes = await ReadBoundedRequest(context);
            if (requestBytes == null)
                return Results.Json(new { error = "request_too_large" }, statusCode: 413);
            if (requestBytes.Length == 0)
                return Results.Json(new { error = "empty_presentation" }, statusCode: 400);
            workspace = Directory.CreateTempSubdirectory("slides-api-").FullName;
            Workspaces.TryAdd(workspace, 0);
            byte[]? pdf = await ConvertPptx(requestBytes, workspace, context.RequestAborted);
            return pdf == null
                ? Results.Json(new { error = "invalid_presentation" }, statusCode: 400)
                : Results.File(pdf, "application/pdf", "presentation.pdf");
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
            try
            {
                if (workspace != null) Directory.Delete(workspace, recursive: true);
            }
            finally
            {
                if (workspace != null) Workspaces.TryRemove(workspace, out _);
                if (admitted)
                {
                    Interlocked.Decrement(ref active);
                    RequestSlots.Release();
                }
            }
        }
    }

    private static async Task<byte[]?> ReadBoundedRequest(HttpContext context)
    {
        using var input = new MemoryStream();
        var buffer = new byte[81920];
        while (true)
        {
            int read = await context.Request.Body.ReadAsync(buffer, context.RequestAborted);
            if (read == 0) return input.ToArray();
            if (input.Length + read > RequestLimit) return null;
            await input.WriteAsync(buffer.AsMemory(0, read), context.RequestAborted);
        }
    }

    private static async Task<byte[]?> ConvertPptx(byte[] requestBytes, string workspace, CancellationToken cancellation)
    {
        var interruption = new InterruptionTokenSource();
        using var registration = cancellation.Register(interruption.Interrupt);
        await SdkGate.WaitAsync(cancellation);
        int sdkCurrent = Interlocked.Increment(ref nativeActive);
        int sdkPrevious;
        do { sdkPrevious = maxSdkActive; }
        while (sdkCurrent > sdkPrevious && Interlocked.CompareExchange(ref maxSdkActive, sdkCurrent, sdkPrevious) != sdkPrevious);
        try
        {
            using var input = new MemoryStream(requestBytes);
            if (PresentationFactory.Instance.GetPresentationInfo(input).LoadFormat != LoadFormat.Pptx) return null;
            string output = Path.Combine(workspace, "result.pdf");
            await Task.Run(() =>
            {
                input.Position = 0;
                using var presentation = new Presentation(input, new LoadOptions
                {
                    LoadFormat = LoadFormat.Pptx,
                    InterruptionToken = interruption.Token
                });
                presentation.Save(output, SaveFormat.Pdf);
            });
            cancellation.ThrowIfCancellationRequested();
            byte[] pdf = await File.ReadAllBytesAsync(output, cancellation);
            return pdf.Length > 500 && pdf.AsSpan(0, 5).SequenceEqual("%PDF-"u8) ? pdf : null;
        }
        finally
        {
            Interlocked.Decrement(ref nativeActive);
            SdkGate.Release();
        }
    }
}
