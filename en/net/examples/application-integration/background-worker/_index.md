---
title: "Process Presentations in a Background Worker"
type: docs
weight: 20
url: /net/examples/application-integration/background-worker/
description: "Complete runnable C# application for process presentations in a background worker, with real host execution and reproducible input."
---

The .NET Worker Service snapshots an input folder of PPTX files and queues jobs through a bounded channel. Two consumers each own and dispose a presentation. Every input receives a succeeded, failed or cancelled entry in the final manifest; a corrupt file does not stop later jobs. The loader explicitly requires PPTX rather than treating an arbitrary text file as another supported input format.

## Prerequisites

[Download the complete project](example.zip). Install the pinned .NET SDK and set `ASPOSE_LICENSE_PATH` to your valid file license for the full-content checks. See [installation](/slides/net/installation/) and [licensing](/slides/net/licensing/). The project generates synthetic inputs in self-test mode; no private input or credential is included.

## Complete application

```csharp
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
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
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath)) new License().SetLicense(licensePath);
        bool selfTest = args.Contains("--self-test");
        if (selfTest)
        {
            PrepareInput("input");
            await Run("input", "normal-output", stopAfter: 0);
            var complete = JsonSerializer.Deserialize<JobResult[]>(await File.ReadAllTextAsync("normal-output/manifest.json"))!;
            Require(complete.Length == 4 && complete.Count(j => j.State == "succeeded") == 3 && complete.Count(j => j.State == "failed") == 1, "Mixed inputs need three successes and one explicit failure.");
            await Run("input", "shutdown-output", stopAfter: 1);
            var stopped = JsonSerializer.Deserialize<JobResult[]>(await File.ReadAllTextAsync("shutdown-output/manifest.json"))!;
            Require(stopped.Length == 4 && stopped.All(j => j.State != "pending") && stopped.Any(j => j.State == "cancelled"), "Shutdown must account for every job.");
            PrepareActiveInput();
            await Run("active-input", "active-output", stopAfter: 0, stopDuringActive: true);
            var activeStopped = JsonSerializer.Deserialize<JobResult[]>(await File.ReadAllTextAsync("active-output/manifest.json"))!;
            using var metrics = JsonDocument.Parse(await File.ReadAllTextAsync("active-output/metrics.json"));
            Require(activeStopped.Length == 1 && activeStopped[0].State == "cancelled" && !File.Exists("active-output/active.pdf"), "Cancelled active conversion must not be recorded successful or retain an output.");
            Require(metrics.RootElement.GetProperty("active_cancellation_requested").GetBoolean(), "The stop request must reach active conversion.");
            string json = JsonSerializer.Serialize(new { mixed_jobs = complete.Length, successful_jobs = 3, failed_jobs = 1, shutdown_accounted_for_every_job = true, cancellation_recorded = true, active_conversion_cancelled = true, partial_output_removed = true, queue_capacity = 2, concurrency = 2 });
            await File.WriteAllTextAsync("result.json", json);
            Console.WriteLine(json);
            return;
        }
        string input = args.Length > 0 ? args[0] : "input";
        string output = args.Length > 1 ? args[1] : "output";
        await Run(input, output, stopAfter: 0);
    }

    private static async Task Run(string input, string output, int stopAfter, bool stopDuringActive = false)
    {
        Directory.CreateDirectory(output);
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton(new WorkSettings(input, output, stopAfter, stopDuringActive));
        builder.Services.AddHostedService<ConversionWorker>();
        using var host = builder.Build();
        await host.RunAsync();
    }

    private static void PrepareInput(string folder)
    {
        Directory.CreateDirectory(folder);
        for (int i = 1; i <= 3; i++)
        {
            using var presentation = new Presentation();
            presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 100).TextFrame.Text = "Worker item " + i;
            presentation.Save(Path.Combine(folder, i + "-valid.pptx"), SaveFormat.Pptx);
        }
        File.WriteAllText(Path.Combine(folder, "4-corrupt.pptx"), "This is not a presentation.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    private static void PrepareActiveInput()
    {
        Directory.CreateDirectory("active-input");
        using var presentation = new Presentation();
        var layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        for (int i = 0; i < 120; i++)
        {
            var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(layout);
            slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 100).TextFrame.Text = "Active conversion page " + i;
        }
        presentation.Save("active-input/active.pptx", SaveFormat.Pptx);
    }

    private sealed record WorkSettings(string Input, string Output, int StopAfter, bool StopDuringActive);
    private sealed record JobResult(string Name, string State, string? Error);

    private sealed class ConversionWorker : BackgroundService
    {
        private readonly WorkSettings settings;
        private readonly IHostApplicationLifetime lifetime;
        public ConversionWorker(WorkSettings settings, IHostApplicationLifetime lifetime) { this.settings = settings; this.lifetime = lifetime; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string[] paths = Directory.GetFiles(settings.Input, "*.pptx").OrderBy(p => p, StringComparer.Ordinal).ToArray();
            var results = new ConcurrentDictionary<string, JobResult>(paths.Select(p => new System.Collections.Generic.KeyValuePair<string, JobResult>(p, new JobResult(Path.GetFileName(p), "pending", null))));
            var queue = Channel.CreateBounded<string>(new BoundedChannelOptions(2) { FullMode = BoundedChannelFullMode.Wait, SingleWriter = true, SingleReader = false });
            int completed = 0;
            int active = 0;
            int maximumActive = 0;
            int activeCancellationRequested = 0;
            using var linked = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);

            async Task Consume()
            {
                try
                {
                    await foreach (string path in queue.Reader.ReadAllAsync(linked.Token))
                    {
                        linked.Token.ThrowIfCancellationRequested();
                        int running = Interlocked.Increment(ref active);
                        int previous;
                        do { previous = maximumActive; } while (running > previous && Interlocked.CompareExchange(ref maximumActive, running, previous) != previous);
                        string destination = Path.Combine(settings.Output, Path.GetFileNameWithoutExtension(path) + ".pdf");
                        var interrupt = new InterruptionTokenSource();
                        using var registration = linked.Token.Register(interrupt.Interrupt);
                        try
                        {
                            await Task.Run(() =>
                            {
                                if (PresentationFactory.Instance.GetPresentationInfo(path).LoadFormat != LoadFormat.Pptx) throw new InvalidDataException("Expected PPTX content.");
                                using var presentation = new Presentation(path, new LoadOptions { LoadFormat = LoadFormat.Pptx, InterruptionToken = interrupt.Token });
                                if (settings.StopDuringActive)
                                {
                                    _ = Task.Run(async () =>
                                    {
                                        await Task.Delay(20);
                                        Interlocked.Exchange(ref activeCancellationRequested, 1);
                                        linked.Cancel();
                                        lifetime.StopApplication();
                                    });
                                }
                                presentation.Save(destination, SaveFormat.Pdf);
                                linked.Token.ThrowIfCancellationRequested();
                            });
                            linked.Token.ThrowIfCancellationRequested();
                            using (var pdf = File.OpenRead(destination))
                            {
                                var header = new byte[5];
                                Require(pdf.Length > 500 && pdf.Read(header, 0, header.Length) == 5 && System.Text.Encoding.ASCII.GetString(header) == "%PDF-", "Conversion did not produce a PDF.");
                            }
                            results[path] = new JobResult(Path.GetFileName(path), "succeeded", null);
                        }
                        catch (Exception) when (linked.IsCancellationRequested)
                        {
                            if (File.Exists(destination)) File.Delete(destination);
                            results[path] = new JobResult(Path.GetFileName(path), "cancelled", null);
                        }
                        catch (Exception error)
                        {
                            if (File.Exists(destination)) File.Delete(destination);
                            results[path] = new JobResult(Path.GetFileName(path), "failed", error.GetType().Name);
                        }
                        finally { Interlocked.Decrement(ref active); }
                        if (settings.StopAfter > 0 && Interlocked.Increment(ref completed) >= settings.StopAfter)
                        {
                            linked.Cancel();
                            lifetime.StopApplication();
                        }
                    }
                }
                catch (OperationCanceledException) { }
            }

            Task[] consumers = Enumerable.Range(0, 2).Select(_ => Consume()).ToArray();
            try
            {
                foreach (string path in paths) await queue.Writer.WriteAsync(path, linked.Token);
            }
            catch (OperationCanceledException) { }
            finally { queue.Writer.TryComplete(); }
            await Task.WhenAll(consumers);
            foreach (string path in paths)
                if (results[path].State == "pending") results[path] = new JobResult(Path.GetFileName(path), "cancelled", "not_started_before_shutdown");
            Require(maximumActive <= 2 && active == 0, "Worker concurrency or disposal failed.");
            string manifest = JsonSerializer.Serialize(results.Values.OrderBy(r => r.Name), new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(Path.Combine(settings.Output, "manifest.json"), manifest, CancellationToken.None);
            await File.WriteAllTextAsync(Path.Combine(settings.Output, "metrics.json"), JsonSerializer.Serialize(new { queue_capacity = 2, maximum_active = maximumActive, active_cancellation_requested = activeCancellationRequested != 0 }), CancellationToken.None);
            lifetime.StopApplication();
        }
    }
}
```

## Run and verify

```text
dotnet run --project Example.csproj --configuration Release -- --self-test
```

Pass input and output folder paths to run your own batch. Add --self-test to generate three valid decks and one corrupt file, process them through a real Generic Host, then start a second host and request graceful shutdown after the first completed item. A third host interrupts a120-slide conversion while processing and proves that a cancelled job retains no PDF. Inspect normal-output and shutdown-output manifests. This local queue is held in memory; the manifest identifies unstarted/cancelled jobs for an application-managed retry. It is not a durable message broker.

The verification run writes result.json plus "normal-output/manifest.json", "normal-output/metrics.json", "normal-output/1-valid.pdf", "normal-output/2-valid.pdf", "normal-output/3-valid.pdf", "shutdown-output/manifest.json", "shutdown-output/metrics.json". Inspect the returned PDF files and the manifest or image preview. Exit 0 requires the named assertions to pass; an invalid input is reported explicitly.

Read the [detailed Docker guide](/slides/net/how-to-run-aspose-slides-in-docker/) for package and native-library choices when adapting Linux hosting.
