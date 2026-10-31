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
        };
        context.Prerequisite(selected == null || cases.Any(item => item.Id == selected), "Unknown action. Use one of: " + string.Join(", ", cases.Select(item => item.Id)));
        foreach (var item in cases.Where(item => selected == null || item.Id == selected))
        {
            CurrentCase = item.Id;
            context.BeginAction("elements/ink/" + item.Id);
            item.Run();
        }
        return Task.CompletedTask;
    });

    private static ExampleContext Context = null!;
    private static string CurrentCase = "";

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

    private static string Seed(string kind)
    {
        string directory = Path.Combine(Context.OutputRoot, "inputs");
        Directory.CreateDirectory(directory);
        string path = Path.Combine(directory, CurrentCase + ".pptx");
        using var seed = new Presentation();
        var slide = seed.Slides[0];
        if (kind == "control")
        {
            var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);
            control.Properties["Value"] = "Text";
        }
        if (kind == "comment")
        {
            var author = seed.CommentAuthors.AddAuthor("User", "U1");
            author.Comments.AddModernComment("Note", slide, null, new System.Drawing.PointF(100, 100), new DateTime(2026, 1, 1));
        }
        if (kind == "master")
        {
            // Add two explicitly unused masters; retain the used original at index zero.
            using var other = new Presentation();
            other.Masters[0].Name = "Unused1";
            seed.Masters.AddClone(other.Masters[0]);
            other.Masters[0].Name = "Unused2";
            seed.Masters.AddClone(other.Masters[0]);
            // Keep the existing used master, remove both explicit unused references in the case.
        }
        seed.Save(path, kind == "control" ? SaveFormat.Pptm : SaveFormat.Pptx);
        return path;
    }

    private static string MathFixture()
    {
        string directory = Path.Combine(Context.OutputRoot, "inputs"); Directory.CreateDirectory(directory);
        string path = Path.Combine(directory, CurrentCase + ".pptx");
        using var seed = new Presentation();
        var shape = seed.Slides[0].Shapes.AddMathShape(50, 50, 200, 80);
        ((Aspose.Slides.MathText.MathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph
            .Add(new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("x").Divide("y")));
        seed.Save(path, SaveFormat.Pptx); return path;
    }

    private static Aspose.Slides.MathText.IMathParagraph Maths(Presentation presentation) =>
        ((Aspose.Slides.MathText.MathPortion)presentation.Slides[0].Shapes.OfType<IAutoShape>()
            .First(s => s.TextFrame.Paragraphs.Any(q => q.Portions.Any(t => t is Aspose.Slides.MathText.MathPortion)))
            .TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
}
