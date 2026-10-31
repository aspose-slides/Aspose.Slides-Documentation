using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context=context;
        string actionId="ai/templates-style/block-001";
        context.BeginAction(actionId);

        context.Prerequisite(context.IsLicensed,"Real AI generation/translation requires an authorized license covering this release. Use --mode licensed with --license PATH or ASPOSE_LICENSE_PATH; evaluation performs no model call.");
        context.Prerequisite(context.Arguments.Contains("--allow-network"),"This recipe contacts a real model service. Add --allow-network only for a service you are authorized to use; no model or credentials are included.");

        int code=await RunExample(context.Arguments);
        context.Require(code==0,"The real AI operation failed. See error.json for the error type and observed HTTP statuses; credentials are never written.");
        VerifyResult(actionId);
    });

    private static void VerifyResult(string actionId)
    {
        using var actual=JsonDocument.Parse(File.ReadAllText("result.json"));
        using var expected=JsonDocument.Parse("{\"designs_checked\":2,\"theme_and_font_retained\":true,\"source_files_unchanged\":true}");
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

    private const string Prompt = "Create a short English presentation about the water cycle. Cover evaporation, condensation and precipitation. Use ordinary text slides with a title and a short paragraph. No charts, tables or images. For every section in the JSON, use the integer 0 for its type field instead of a type name. Return raw JSON without Markdown code fences or commentary.";
    private static readonly ConcurrentBag<RequestResult> Requests = new();

    private static async Task<int> RunExample(string[] args)
    {
        try
        {
            int completed = 0;
            foreach (string kind in new[] { "template", "existing-style" })
            {
                string sourcePath = kind == "template" ? "template.potx" : "style-source.pptx";
                Color accent = kind == "template" ? Color.FromArgb(12, 110, 120) : Color.FromArgb(106, 43, 130);
                using (var design = new Presentation())
                {
                    design.MasterTheme.ColorScheme.Accent1.Color = accent;
                    design.MasterTheme.FontScheme.Major.LatinFont = new FontData("Noto Sans");
                    design.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Noto Sans");
                    design.Masters[0].Background.Type = BackgroundType.OwnBackground;
                    design.Masters[0].Background.FillFormat.FillType = FillType.Solid;
                    design.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.FromArgb(240, 246, 248);
                    if (kind == "existing-style")
                    {
                        var titleLayout = design.LayoutSlides.GetByType(SlideLayoutType.Title);
                        design.Slides.AddEmptySlide(titleLayout);
                        design.Slides.RemoveAt(0);
                        foreach (var placeholder in design.Slides[0].Shapes.OfType<IAutoShape>())
                            if (placeholder.Placeholder != null && placeholder.TextFrame != null) placeholder.TextFrame.Text = "Existing report design";
                    }
                    design.Save(sourcePath, kind == "template" ? SaveFormat.Potx : SaveFormat.Pptx);
                }
                byte[] sourceHash = System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes(sourcePath));
                using var template = new Presentation(sourcePath);
                using var http = Http(kind);
                using var client = new AsposeAIWebClient(http);
                using IPresentation generated = await new SlidesAIAgent(client).GeneratePresentationAsync(Prompt, PresentationContentAmountType.Brief, template);
                VerifyGenerated(generated, kind + "-generated.pptx");
                Require(generated.MasterTheme.ColorScheme.Accent1.Color.ToArgb() == accent.ToArgb(), "Expected source theme color.");
                Require(generated.MasterTheme.FontScheme.Major.LatinFont.FontName == "Noto Sans", "Expected source font scheme.");
                Require(sourceHash.SequenceEqual(System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes(sourcePath))), "Design source changed.");
                using var retainedSource = new Presentation(sourcePath);
                Require(retainedSource.Slides.Count == 1, "Stored design source gained generated slides.");
                completed++;
            }
            Require(Requests.Count(r => r.StatusCode == 200) >= 2, "Both design paths need actual model responses.");
            Report(new { designs_checked = completed, theme_and_font_retained = true, source_files_unchanged = true, requests = Requests.ToArray() });
            return 0;
        }
        catch (Exception error)
        {
            int exit = error is OperationCanceledException ? 4 : error is HttpRequestException ? 3 : 2;
            File.WriteAllText("error.json", JsonSerializer.Serialize(new { error_type = error.GetType().Name, requests = Requests.ToArray(), exit_code = exit }));
            Console.Error.WriteLine("AI example failed: " + error.GetType().Name + ". Check configuration and provider access.");
            return exit;
        }
    }

    private static string Required(string name)
    {
        string? value = Environment.GetEnvironmentVariable(name);
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidOperationException("Set " + name + " before running this example.");
        return value;
    }

    private static HttpClient Http(string provider)
    {
        double timeout = 180;
        if (double.TryParse(Environment.GetEnvironmentVariable("SLIDES_AI_TIMEOUT_SECONDS"), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double configured)) timeout = configured;
        if (timeout <= 0) throw new InvalidOperationException("Timeout must be positive.");
        return new HttpClient(new TraceHandler(provider)) { Timeout = TimeSpan.FromSeconds(timeout) };
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    private static string AllText(IPresentation deck)
    {
        var text = new StringBuilder();
        void Read(IShapeCollection shapes)
        {
            foreach (IShape shape in shapes)
            {
                if (shape is IAutoShape auto && auto.TextFrame != null) text.AppendLine(auto.TextFrame.Text);
                if (shape is IGroupShape group) Read(group.Shapes);
                if (shape is ITable table)
                    for (int row = 0; row < table.Rows.Count; row++)
                        for (int column = 0; column < table.Columns.Count; column++) text.AppendLine(table[column, row].TextFrame.Text);
            }
        }
        foreach (ISlide slide in deck.Slides) Read(slide.Shapes);
        return text.ToString();
    }

    private static int VerifyGenerated(IPresentation deck, string path)
    {
        string live = AllText(deck);
        Require(deck.Slides.Count >= 2 && live.Length > 150 && live.Contains("water", StringComparison.OrdinalIgnoreCase), "Generated content did not describe the requested topic.");
        deck.Save(path, SaveFormat.Pptx);
        using var reopened = new Presentation(path);
        Require(reopened.Slides.Count == deck.Slides.Count && AllText(reopened) == live, "Generated editable text changed after reopening.");
        using var image = reopened.Slides[0].GetImage(new Size(640, 360));
        image.Save(Path.ChangeExtension(path, ".png"), Aspose.Slides.ImageFormat.Png);
        return reopened.Slides.Count;
    }

    private static void Report(object result)
    {
        string json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }

    private sealed record RequestResult(string Provider, int StatusCode);
    private sealed class TraceHandler : DelegatingHandler
    {
        private readonly string provider;
        public TraceHandler(string provider) : base(new HttpClientHandler()) { this.provider = provider; }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            HttpResponseMessage response = await base.SendAsync(request, token);
            Requests.Add(new RequestResult(provider, (int)response.StatusCode));
            return response;
        }
    }
}
