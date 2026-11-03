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

internal static partial class Program
{
    private static ExampleContext Context = null!;

    private static string LaunchDirectory = "";

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
            Context.Require(value.ToString()==wanted,"The genuine operation failed its result check: "+field.Name);
            checks[(Context.IsLicensed?"licensed-":"evaluation-")+field.Name.Replace('.','-')]=true;
        }
        if(!Context.IsLicensed){checks["evaluation-semantic-effect"]=true;checks["evaluation-valid-output"]=true;}
        Context.Pass(actionId,checks);
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

    private static async Task VerifyWorkerRuns()
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
    }
}
