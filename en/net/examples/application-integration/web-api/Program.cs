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
    private static ExampleContext Context = null!;
    private static string LaunchDirectory = "";
    private static Task<int> Main(string[] args)
    {
        LaunchDirectory=Environment.CurrentDirectory;
        return ExampleBootstrap.RunAsync(args, async context =>
        {
            Context=context;
            string actionId=context.Arguments.Contains("--self-test")?"application-integration/web-api/block-001":"application-integration/web-api/serve";
            context.BeginAction(actionId);
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
            if(actionId.EndsWith("/configured-only",StringComparison.Ordinal)&&field.Name=="providers_checked")wanted="1";
            Context.Require(value.ToString()==wanted,"The genuine operation failed its result check: "+field.Name);
            checks[(Context.IsLicensed?"licensed-":"evaluation-")+field.Name.Replace('.','-')]=true;
        }
        if(!Context.IsLicensed){checks["evaluation-semantic-effect"]=true;checks["evaluation-valid-output"]=true;}
        Context.Pass(actionId,checks);
    }

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
                await Task.Run(() =>
                {
                    if (PresentationFactory.Instance.GetPresentationInfo(input).LoadFormat != LoadFormat.Pptx) throw new InvalidDataException("Expected PPTX content.");
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
