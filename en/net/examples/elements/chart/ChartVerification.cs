using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class ChartVerification
{
    internal static void SaveAndVerify(
        ExampleContext context, Presentation presentation, string fileName,
        string check, Func<ISlide, bool> verify)
    {
        // The bootstrap loads the bundled fonts before the examples run.
        var slides = presentation.Masters.Cast<IBaseSlide>()
            .Concat(presentation.LayoutSlides.Cast<IBaseSlide>())
            .Concat(presentation.Slides.Cast<IBaseSlide>());
        foreach (var slide in slides)
            SelectFonts(slide.Shapes);

        Verify(context, presentation.Slides[0], verify, check, "Before save");

        string path = Path.Combine(context.OutputRoot, fileName + ".pptx");
        presentation.Save(path, SaveFormat.Pptx);
        context.Require(new FileInfo(path).Length > 100, "Saved presentation must contain real data.");
        using var reopened = new Presentation(path);
        Verify(context, reopened.Slides[0], verify, check, "After reopen");

        if (fileName == "block-001")
        {
            using var image = reopened.Slides[0].GetImage(1f, 1f);
            context.Require(image.Width > 0 && image.Height > 0, "Representative render has valid dimensions.");
            image.Save(Path.Combine(context.OutputRoot, fileName + ".png"), Aspose.Slides.ImageFormat.Png);
        }

        if (context.IsLicensed)
        {
            bool hasWatermark = reopened.Slides.SelectMany(slide => slide.Shapes).OfType<IAutoShape>()
                .Any(shape => shape.TextFrame?.Text.Contains("Evaluation only", StringComparison.OrdinalIgnoreCase) == true);
            context.Require(!hasWatermark, "Licensed output must not contain the evaluation watermark.");
        }
    }

    private static void Verify(
        ExampleContext context, ISlide slide, Func<ISlide, bool> verify, string check, string stage)
    {
        try
        {
            context.Require(verify(slide), check + ": semantic check 1 failed.");
        }
        catch (Exception error)
        {
            throw new InvalidOperationException(stage + ": " + error.Message, error);
        }
    }

    private static void SelectFonts(IShapeCollection shapes)
    {
        foreach (var shape in shapes)
        {
            if (shape is IGroupShape group)
                SelectFonts(group.Shapes);

            if (shape is not IAutoShape textShape || textShape.TextFrame == null)
                continue;

            foreach (var paragraph in textShape.TextFrame.Paragraphs)
            {
                paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Noto Sans");
                foreach (var portion in paragraph.Portions)
                    portion.PortionFormat.LatinFont = new FontData("Noto Sans");
            }
        }
    }
}
