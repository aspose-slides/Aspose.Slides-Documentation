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
            Context.Require(value.ToString()==wanted,"The genuine operation failed its result check: "+field.Name);
            checks[(Context.IsLicensed?"licensed-":"evaluation-")+field.Name.Replace('.','-')]=true;
        }
        if(!Context.IsLicensed){checks["evaluation-semantic-effect"]=true;checks["evaluation-valid-output"]=true;}
        Context.Pass(actionId,checks);
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
