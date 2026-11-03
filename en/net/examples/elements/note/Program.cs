using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    public static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, context =>
    {
        Context = context;
        string? selected = null;
        if (context.Arguments.Length != 0)
        {
            context.Prerequisite(context.Arguments.Length == 2 && context.Arguments[0] == "--action", "Use --action block-001, or omit it to run all cases.");
            selected = context.Arguments[1];
        }
        var cases = new (string Id, Action Run)[]
        {
            ("block-001", Case01),
            ("block-002", Case02),
            ("block-003", Case03),
            ("block-004", Case04),
        };
        context.Prerequisite(selected == null || cases.Any(item => item.Id == selected), "Unknown action. Use one of: " + string.Join(", ", cases.Select(item => item.Id)));
        foreach (var item in cases.Where(item => selected == null || item.Id == selected))
        {
            context.BeginAction("elements/note/" + item.Id);
            item.Run();
        }
        return Task.CompletedTask;
    });

    private static ExampleContext Context = null!;

    private static void RoundTrip(Presentation presentation, string name, Action<Presentation> verify, SaveFormat format = SaveFormat.Pptx)
    {
        // LoadExternalFonts runs in the bootstrap. Select the bundled family explicitly.
        foreach (var source in presentation.Masters.Cast<IBaseSlide>().Concat(presentation.LayoutSlides.Cast<IBaseSlide>()).Concat(presentation.Slides.Cast<IBaseSlide>()))
            SelectFonts(source.Shapes);
        try { verify(presentation); }
        catch (Exception error) { throw new InvalidOperationException("Before save: " + error.Message, error); }
        string path = Path.Combine(Context.OutputRoot, name + (format == SaveFormat.Pptm ? ".pptm" : ".pptx"));
        presentation.Save(path, format);
        Context.Require(new FileInfo(path).Length > 100, "Saved presentation must contain real data.");
        using var reopened = new Presentation(path);
        try { verify(reopened); }
        catch (Exception error) { throw new InvalidOperationException("After reopen: " + error.Message, error); }
        if (name == "block-001")
        {
            using var image = reopened.Slides[0].GetImage(1f, 1f);
            Context.Require(image.Width > 0 && image.Height > 0, "Representative render has valid dimensions.");
            image.Save(Path.Combine(Context.OutputRoot, name + ".png"), Aspose.Slides.ImageFormat.Png);
        }
        if (Context.IsLicensed)
            Context.Require(!reopened.Slides.SelectMany(s => s.Shapes).OfType<IAutoShape>()
                .Any(s => s.TextFrame?.Text.Contains("Evaluation only", StringComparison.OrdinalIgnoreCase) == true),
                "Licensed output must not contain the evaluation watermark.");
    }

    private static void SelectFonts(IShapeCollection shapes)
    {
        foreach (var shape in shapes)
        {
            if (shape is IGroupShape group) SelectFonts(group.Shapes);
            if (shape is IAutoShape textShape && textShape.TextFrame != null)
                foreach (var paragraph in textShape.TextFrame.Paragraphs)
                {
                    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Noto Sans");
                    foreach (var portion in paragraph.Portions) portion.PortionFormat.LatinFont = new FontData("Noto Sans");
                }
        }
    }
}
