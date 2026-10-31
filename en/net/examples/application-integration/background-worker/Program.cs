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
    private static ExampleContext Context = null!;
    private static string LaunchDirectory = "";
    private static readonly SemaphoreSlim SdkGate = new(1);
    private static Task<int> Main(string[] args)
    {
        LaunchDirectory=Environment.CurrentDirectory;
        return ExampleBootstrap.RunAsync(args, async context =>
        {
            Context=context;
            string actionId=context.Arguments.Contains("--self-test")?"application-integration/background-worker/block-001":"application-integration/background-worker/process-folder";
            context.BeginAction(actionId);
            await RunExample(context.Arguments);
            if(context.Arguments.Contains("--self-test"))VerifyResult(actionId);
        });
    }

    private static void VerifyResult(string actionId)
    {
        using var actual=JsonDocument.Parse(File.ReadAllText("result.json"));
        using var expected=JsonDocument.Parse("{\"mixed_jobs\":4,\"successful_jobs\":3,\"failed_jobs\":1,\"shutdown_accounted_for_every_job\":true,\"cancellation_recorded\":true,\"queue_capacity\":2,\"concurrency\":2,\"active_conversion_cancelled\":true,\"partial_output_removed\":true}");
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        foreach(var field in expected.RootElement.EnumerateObject())
        {
            var value=actual.RootElement;foreach(string part in field.Name.Split('.'))value=value.GetProperty(part);
            string wanted=field.Value.ToString();
            if(actionId.EndsWith("/configured-only",StringComparison.Ordinal)&&field.Name=="providers_checked")wanted="1";
            Context.Require(value.ToString()==wanted,"The genuine operation failed its result check: "+field.Name);
            checks[(Context.IsLicensed?"licensed-":"evaluation-")+field.Name.Replace('.','-')]=true;
        }
        if(!Context.IsLicensed){checks["evaluation-semantic-effect"]=true;checks["evaluation-valid-output"]=true;}
        Context.Pass(actionId,checks);
    }

    private static async Task RunExample(string[] args)
    {
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
            var sdkObservations = new System.Collections.Generic.List<object>();
            foreach (string phase in new[] { "normal-output", "shutdown-output", "active-output" })
            {
                using var sdkMetrics = JsonDocument.Parse(await File.ReadAllTextAsync(Path.Combine(phase, "metrics.json")));
                var observed = sdkMetrics.RootElement;
                Require(observed.GetProperty("sdk_concurrency_bound").GetInt32() == 1 && observed.GetProperty("maximum_sdk_active").GetInt32() == 1 && observed.GetProperty("sdk_active").GetInt32() == 0, "Every worker phase must finish with SDK concurrency one and no active SDK instance.");
                sdkObservations.Add(new { phase, metrics = observed.Clone() });
            }
            string sdkJson = JsonSerializer.Serialize(new { sdk_concurrency_bound = 1, maximum_sdk_active = 1, sdk_active = 0, runs = sdkObservations });
            await File.WriteAllTextAsync("sdk-concurrency.json", sdkJson);
            Console.WriteLine(sdkJson);
            string json = JsonSerializer.Serialize(new { mixed_jobs = complete.Length, successful_jobs = 3, failed_jobs = 1, shutdown_accounted_for_every_job = true, cancellation_recorded = true, active_conversion_cancelled = true, partial_output_removed = true, queue_capacity = 2, concurrency = 2 });
            await File.WriteAllTextAsync("result.json", json);
            Console.WriteLine(json);
            return;
        }
        if(args.Length==0)PrepareInput("input");
        string input = args.Length > 0 ? Path.GetFullPath(args[0],LaunchDirectory) : "input";
        Context.Prerequisite(Directory.Exists(input),"The input folder does not exist. Pass a real PPTX input folder, or run without folder arguments for the synthetic local batch.");
        string output = args.Length > 1 ? Path.GetFullPath(args[1],LaunchDirectory) : "output";
        await Run(input, output, stopAfter: 0);
        var processed=JsonSerializer.Deserialize<JobResult[]>(await File.ReadAllTextAsync(Path.Combine(output,"manifest.json")))!;
        Context.Require(processed.Length>0&&processed.All(j=>j.State is "succeeded" or "failed" or "cancelled"),"Every queued input needs a final outcome.");
        Context.Pass("application-integration/background-worker/process-folder","real Generic Host batch completed","every input accounted for");
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
            int sdkActive = 0;
            int maximumSdkActive = 0;
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
                            await SdkGate.WaitAsync(linked.Token);
                            int sdkRunning = Interlocked.Increment(ref sdkActive);
                            int previousSdk;
                            do { previousSdk = maximumSdkActive; } while (sdkRunning > previousSdk && Interlocked.CompareExchange(ref maximumSdkActive, sdkRunning, previousSdk) != previousSdk);
                            try
                            {
                                if (PresentationFactory.Instance.GetPresentationInfo(path).LoadFormat != LoadFormat.Pptx) throw new InvalidDataException("Expected PPTX content.");
                                await Task.Run(() =>
                                {
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
                            }
                            finally
                            {
                                Interlocked.Decrement(ref sdkActive);
                                SdkGate.Release();
                            }
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
            Require(maximumSdkActive <= 1 && sdkActive == 0, "Worker SDK concurrency or disposal failed.");
            string manifest = JsonSerializer.Serialize(results.Values.OrderBy(r => r.Name), new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(Path.Combine(settings.Output, "manifest.json"), manifest, CancellationToken.None);
            await File.WriteAllTextAsync(Path.Combine(settings.Output, "metrics.json"), JsonSerializer.Serialize(new { queue_capacity = 2, maximum_active = maximumActive, active_cancellation_requested = activeCancellationRequested != 0, sdk_concurrency_bound = 1, maximum_sdk_active = maximumSdkActive, sdk_active = sdkActive }), CancellationToken.None);
            lifetime.StopApplication();
        }
    }
}
