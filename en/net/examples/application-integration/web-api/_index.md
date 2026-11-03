---
title: "Build a Presentation Conversion Endpoint"
type: docs
weight: 10
url: /net/examples/application-integration/web-api/
description: "Complete runnable C# application for build a presentation conversion endpoint, with real host execution and reproducible input."
---

The complete ASP.NET Core application accepts a PPTX presentation as the raw POST body at /convert and returns application/pdf. It limits uploads to 8 MiB, bounds active HTTP processing to two requests and serializes SDK conversion within each process, uses a unique temporary directory per request, and connects request cancellation to the library interruption token.

## **Prerequisites**

Use a current supported .NET10 SDK/runtime and the supplied flexible SDK settings; no exact patch is required.

## **Complete application**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
Use an ASP.NET Core project, or add a framework reference to `Microsoft.AspNetCore.App`.
The copied program writes its files under `example-output` by default.

Use a .NET web project (or add the `Microsoft.AspNetCore.App` framework reference). The loopback endpoint accepts raw PPTX bytes, with an 8 MiB limit enforced for both Content-Length and streaming bodies. Start it with `dotnet run`, then POST a PPTX to `http://127.0.0.1:5088/convert`. The download includes the HTTP self-test.

```csharp
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var builder = WebApplication.CreateBuilder(args);
        builder.WebHost.UseUrls("http://127.0.0.1:5088");
        // The handler checks both declared and streamed sizes and returns its own 413 response.
        builder.WebHost.ConfigureKestrel(options => options.Limits.MaxRequestBodySize = null);
        await using var app = builder.Build();
        app.MapPost("/convert", (Func<HttpContext, Task<IResult>>)ConvertPresentation);
        await app.RunAsync();
    }

    private const int MaximumInputBytes = 8 * 1024 * 1024;
    private static readonly SemaphoreSlim RequestSlots = new(2); // Bound admitted requests and buffers.
    private static readonly SemaphoreSlim SdkGate = new(1); // Serialize native SDK conversion.
    private static async Task<IResult> ConvertPresentation(HttpContext context)
    {
        if (context.Request.ContentLength > MaximumInputBytes)
            return Results.Json(new { error = "request_too_large" }, statusCode: 413);
        var admitted = false;
        string? workspace = null;
        try
        {
            await RequestSlots.WaitAsync(context.RequestAborted);
            admitted = true;
            var inputBytes = await ReadBoundedBody(context);
            if (inputBytes == null)
                return Results.Json(new { error = "request_too_large" }, statusCode: 413);
            if (inputBytes.Length == 0)
                return Results.Json(new { error = "empty_presentation" }, statusCode: 400);
            workspace = Directory.CreateTempSubdirectory("slides-api-").FullName;
            var pdfBytes = await ConvertPptx(inputBytes, workspace, context.RequestAborted);
            return pdfBytes == null ? Results.Json(new { error = "invalid_presentation" }, statusCode: 400) : Results.File(pdfBytes, "application/pdf", "presentation.pdf");
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
                if (workspace != null)
                    Directory.Delete(workspace, recursive: true);
            }
            finally
            {
                if (admitted)
                    RequestSlots.Release();
            }
        }
    }

    private static async Task<byte[]?> ReadBoundedBody(HttpContext context)
    {
        using var input = new MemoryStream();
        var buffer = new byte[81920];
        while (true)
        {
            var read = await context.Request.Body.ReadAsync(buffer, context.RequestAborted);
            if (read == 0)
                return input.ToArray();
            if (input.Length + read > MaximumInputBytes)
                return null;
            await input.WriteAsync(buffer.AsMemory(0, read), context.RequestAborted);
        }
    }

    private static async Task<byte[]?> ConvertPptx(byte[] inputBytes, string workspace, CancellationToken cancellation)
    {
        var interruption = new InterruptionTokenSource();
        using var registration = cancellation.Register(interruption.Interrupt);
        await SdkGate.WaitAsync(cancellation);
        try
        {
            using var input = new MemoryStream(inputBytes);
            if (PresentationFactory.Instance.GetPresentationInfo(input).LoadFormat != LoadFormat.Pptx)
                return null;
            var outputPath = Path.Combine(workspace, "result.pdf");
            await Task.Run(() =>
            {
                input.Position = 0;
                using var presentation = new Presentation(input, new LoadOptions { LoadFormat = LoadFormat.Pptx, InterruptionToken = interruption.Token });
                presentation.Save(outputPath, SaveFormat.Pdf);
            });
            cancellation.ThrowIfCancellationRequested();
            var pdfBytes = await File.ReadAllBytesAsync(outputPath, cancellation);
            return pdfBytes.Length > 500 && pdfBytes.AsSpan(0, 5).SequenceEqual("%PDF-"u8) ? pdfBytes : null;
        }
        finally
        {
            SdkGate.Release();
        }
    }
}
```

## **Run and verify**

```text
dotnet run --project Example.csproj --configuration Release -- --self-test
```

Run normally to listen on http://127.0.0.1:5088. POST the file bytes with your HTTP client. Add --self-test to start a real ephemeral local server, upload valid/invalid/oversized files concurrently, cancel an active job, and verify temporary-directory cleanup. The sample uses loopback hosting and stable error codes. Add authentication, operational limits and deployment configuration appropriate to your own application before exposing it.

The verification run writes result.json plus "input.pptx", "response-0.pdf", "response-1.pdf", "response-2.pdf". Inspect the returned PDF files and the manifest or image preview. Exit 0 requires the named assertions to pass; an invalid input is reported explicitly.

Read the [detailed Docker guide](/slides/net/how-to-run-aspose-slides-in-docker/) for package and native-library choices when adapting Linux hosting.


## **Download, prerequisites and run**

[Download the complete project](example.zip) and open `Example.sln`. The stable
net8.0/C#12 project accepts compatible installed release SDKs and explicitly runs
on the current .NET10 runtime. No exact SDK patch or locked restore is required.
Bundled Noto Sans fonts include their redistribution notice. See
[setup and supported environments](/slides/net/examples/getting-started/).

The bootstrap prints the separate output workspace. Explicit `--mode evaluation`
ignores all license settings; `--mode licensed` accepts your authorized license
through `--license PATH` or ASPOSE_LICENSE_PATH. No license or credential is included.

Default Run/F5 starts the real loopback API. Use `--self-test` for the finite genuine HTTP/cancellation checks; startup alone does not claim those checks passed.

HTTP request processing is bounded to two active requests. Recognition, presentation loading, PDF saving and disposal are serialized in one SDK critical section per process. This is a mitigation for an observed intermittent native fontconfig crash, not a proven vendor fix. For parallel SDK conversions, use separate worker processes; see [the official multithreading guidance](/slides/net/multithreading/).
