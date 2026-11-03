---
title: "Process Presentations in a Background Worker"
type: docs
weight: 20
url: /net/examples/application-integration/background-worker/
description: "Complete runnable C# application for process presentations in a background worker, with real host execution and reproducible input."
---

The .NET Worker Service snapshots an input folder of PPTX files and queues jobs through a bounded channel. Two consumers each own and dispose a presentation. Every input receives a succeeded, failed or cancelled entry in the final manifest; a corrupt file does not stop later jobs. The loader explicitly requires PPTX rather than treating an arbitrary text file as another supported input format.

## **Prerequisites**

Use a current supported .NET10 SDK/runtime and the supplied flexible SDK settings; no exact patch is required.

## **Complete application**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
Use an ASP.NET Core project, or add a framework reference to `Microsoft.AspNetCore.App`.
The copied program writes its files under `example-output` by default.

Add the `Microsoft.Extensions.Hosting` package alongside Aspose.Slides. Run without arguments for three valid generated inputs and one corrupt input, or use `dotnet run -- INPUT_FOLDER OUTPUT_FOLDER`. Press Ctrl+C for graceful shutdown. The bounded queue has two consumers; a separate gate serializes native SDK conversion. A validated temporary PDF is atomically moved to its final path.

```csharp
using System;
using System.IO;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var inputDirectory = Path.GetFullPath(args.Length > 0 ? args[0] : "example-output/input");
        var outputDirectory = Path.GetFullPath(args.Length > 1 ? args[1] : "example-output/output");
        if (args.Length == 0)
            CreateSampleInputs(inputDirectory);
        if (!Directory.Exists(inputDirectory))
        {
            Console.Error.WriteLine("Pass an existing PPTX input folder, or omit arguments to generate sample inputs.");
            return;
        }

        Directory.CreateDirectory(outputDirectory);
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton(new WorkSettings(inputDirectory, outputDirectory));
        builder.Services.AddHostedService<ConversionWorker>();
        using var host = builder.Build();
        await host.RunAsync();
        Console.WriteLine("Job outcomes: " + Path.Combine(outputDirectory, "manifest.json"));
    }

    private sealed record WorkSettings(string Input, string Output);
    private sealed record JobResult(string Name, string State, string? Error);
    private sealed class ConversionWorker(WorkSettings settings, IHostApplicationLifetime lifetime) : BackgroundService
    {
        // Two queue consumers may be active; only one enters the native SDK at a time.
        private static readonly SemaphoreSlim SdkGate = new(1);
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var paths = Directory.GetFiles(settings.Input, "*.pptx").OrderBy(path => path, StringComparer.Ordinal).ToArray();
            var results = new ConcurrentDictionary<string, JobResult>(paths.Select(path => new KeyValuePair<string, JobResult>(path, new(Path.GetFileName(path), "pending", null))));
            var queue = Channel.CreateBounded<string>(new BoundedChannelOptions(2) { FullMode = BoundedChannelFullMode.Wait, SingleWriter = true, SingleReader = false });
            async Task Consume()
            {
                try
                {
                    await foreach (var path in queue.Reader.ReadAllAsync(stoppingToken))
                        results[path] = await ConvertOne(path, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                }
            }

            var consumers = new[]
            {
                Consume(),
                Consume()
            };
            try
            {
                foreach (var path in paths)
                    await queue.Writer.WriteAsync(path, stoppingToken);
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                queue.Writer.TryComplete();
            }

            await Task.WhenAll(consumers);
            // Shutdown must also account for inputs never taken from the queue.
            foreach (var path in paths)
                if (results[path].State == "pending")
                    results[path] = new(Path.GetFileName(path), "cancelled", "not_started_before_shutdown");
            var manifest = JsonSerializer.Serialize(results.Values.OrderBy(result => result.Name), new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(Path.Combine(settings.Output, "manifest.json"), manifest, CancellationToken.None);
            lifetime.StopApplication();
        }

        private async Task<JobResult> ConvertOne(string sourcePath, CancellationToken cancellation)
        {
            var name = Path.GetFileName(sourcePath);
            var destination = Path.Combine(settings.Output, Path.GetFileNameWithoutExtension(sourcePath) + ".pdf");
            var temporaryPath = destination + "." + Guid.NewGuid().ToString("N") + ".partial";
            var interruption = new InterruptionTokenSource();
            using var registration = cancellation.Register(interruption.Interrupt);
            try
            {
                await SdkGate.WaitAsync(cancellation);
                try
                {
                    if (PresentationFactory.Instance.GetPresentationInfo(sourcePath).LoadFormat != LoadFormat.Pptx)
                        return new(name, "failed", "Expected PPTX content.");
                    await Task.Run(() =>
                    {
                        using var presentation = new Presentation(sourcePath, new LoadOptions { LoadFormat = LoadFormat.Pptx, InterruptionToken = interruption.Token });
                        presentation.Save(temporaryPath, SaveFormat.Pdf);
                    });
                }
                finally
                {
                    SdkGate.Release();
                }

                cancellation.ThrowIfCancellationRequested();
                using (var pdf = File.OpenRead(temporaryPath))
                {
                    var header = new byte[5];
                    if (pdf.Length <= 500 || pdf.Read(header, 0, header.Length) != 5 || !header.AsSpan().SequenceEqual("%PDF-"u8))
                        return new(name, "failed", "Conversion did not produce a valid PDF.");
                }

                cancellation.ThrowIfCancellationRequested();
                File.Move(temporaryPath, destination, overwrite: true);
                return new(name, "succeeded", null);
            }
            catch (Exception) when (cancellation.IsCancellationRequested)
            {
                return new(name, "cancelled", null);
            }
            catch (Exception error)
            {
                return new(name, "failed", error.GetType().Name);
            }
            finally
            {
                if (File.Exists(temporaryPath))
                    File.Delete(temporaryPath);
            }
        }
    }

    private static void CreateSampleInputs(string directory)
    {
        Directory.CreateDirectory(directory);
        foreach (var name in new[]
        {
            "01-first",
            "02-second",
            "04-after-error"
        }

        )
        {
            using var presentation = new Presentation();
            presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 600, 80).TextFrame.Text = name;
            presentation.Save(Path.Combine(directory, name + ".pptx"), SaveFormat.Pptx);
        }

        File.WriteAllText(Path.Combine(directory, "03-corrupt.pptx"), "This is not a presentation.");
    }
}
```

## **Run and verify**

```text
dotnet run --project Example.csproj --configuration Release -- --self-test
```

Pass input and output folder paths to run your own batch. Add --self-test to generate three valid decks and one corrupt file, process them through a real Generic Host, then start a second host and request graceful shutdown after the first completed item. A third host interrupts a120-slide conversion while processing and proves that a cancelled job retains no PDF. Inspect normal-output and shutdown-output manifests. This local queue is held in memory; the manifest identifies unstarted/cancelled jobs for an application-managed retry. It is not a durable message broker.

The verification run writes result.json plus "normal-output/manifest.json", "normal-output/metrics.json", "normal-output/1-valid.pdf", "normal-output/2-valid.pdf", "normal-output/3-valid.pdf", "shutdown-output/manifest.json", "shutdown-output/metrics.json". Inspect the returned PDF files and the manifest or image preview. Exit 0 requires the named assertions to pass; an invalid input is reported explicitly.

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

Default Run/F5 processes a synthetic local batch through the real host. Use `--self-test` for the full shutdown/cancellation checks, or pass your input/output folders.
