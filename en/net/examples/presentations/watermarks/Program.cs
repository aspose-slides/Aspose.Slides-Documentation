using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private const string WatermarkTag = "example-watermark:";

    private static void MarkText(Presentation presentation)
    {
        foreach (var slide in presentation.Slides)
        {
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 150, 440, 70);
            shape.AlternativeText = WatermarkTag + "text";
            shape.FillFormat.FillType = FillType.NoFill;
            shape.LineFormat.FillFormat.FillType = FillType.NoFill;
            shape.Rotation = -25;
            shape.TextFrame.Text = "DRAFT";
            var format = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
            format.FontHeight = 52;
            format.FillFormat.FillType = FillType.Solid;
            format.FillFormat.SolidFillColor.Color = Color.FromArgb(90, Color.Gray);
        }
    }

    private static void MarkImage(Presentation presentation)
    {
        var image = presentation.Images.AddImage(File.ReadAllBytes("watermark.png"));
        foreach (var slide in presentation.Slides)
        {
            var frame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 460, 270, 150, 50, image);
            frame.AlternativeText = WatermarkTag + "image";
        }
    }

    private static void RemoveOurWatermarks(Presentation presentation)
    {
        foreach (var slide in presentation.Slides)
            for (int i = slide.Shapes.Count - 1; i >= 0; i--)
                if (slide.Shapes[i].AlternativeText.StartsWith(WatermarkTag, StringComparison.Ordinal))
                    slide.Shapes.RemoveAt(i);
    }

    private static void RunExample()
    {
        using (var logo = new Presentation())
        {
            logo.SlideSize.SetSize(150, 50, SlideSizeScaleType.DoNotScale);
            var slide = logo.Slides[0];
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.LightGoldenrodYellow;
            var circle = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 8, 8, 34, 34);
            circle.FillFormat.FillType = FillType.Solid;
            circle.FillFormat.SolidFillColor.Color = Color.DarkOrange;
            var bar = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 52, 17, 84, 16);
            bar.FillFormat.FillType = FillType.Solid;
            bar.FillFormat.SolidFillColor.Color = Color.DarkSlateBlue;
            using var rendered = slide.GetImage(new Size(150, 50));
            rendered.Save("watermark.png", Aspose.Slides.ImageFormat.Png);
        }
        using (var created = new Presentation())
        {
            created.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
            Label(created.Slides[0], "Original DRAFT content"); // Must survive removal.
            var second = created.Slides.AddEmptySlide(created.LayoutSlides.GetByType(SlideLayoutType.TitleOnly));
            Label(second, "Second layout");
            created.Save("input.pptx", SaveFormat.Pptx);
        }
        string inputHash = Hash("input.pptx");
        using (var text = new Presentation("input.pptx"))
        {
            MarkText(text);
            text.Save("text-watermark.pptx", SaveFormat.Pptx);
            using var preview = text.Slides[0].GetImage(new Size(640, 360));
            preview.Save("preview-text.png", Aspose.Slides.ImageFormat.Png);
        }
        using (var image = new Presentation("text-watermark.pptx"))
        {
            MarkImage(image);
            image.Save("image-watermark.pptx", SaveFormat.Pptx);
            for (int i = 0; i < image.Slides.Count; i++)
            {
                Require(image.Slides[i].Shapes.Count(s => s.AlternativeText.StartsWith(WatermarkTag, StringComparison.Ordinal)) == 2, "A watermark is missing.");
                using var preview = image.Slides[i].GetImage(new Size(640, 360));
                preview.Save($"preview-image-{i + 1}.png", Aspose.Slides.ImageFormat.Png);
            }
            RemoveOurWatermarks(image);
            image.Save("removed.pptx", SaveFormat.Pptx);
        }
        using (var original = new Presentation("input.pptx"))
        using (var removed = new Presentation("removed.pptx"))
        {
            Require(removed.Slides.Count == original.Slides.Count, "Slide count changed.");
            Require(removed.Slides.All(s => !s.Shapes.Any(x => x.AlternativeText.StartsWith(WatermarkTag, StringComparison.Ordinal))), "A tagged application watermark remains.");
            for (int i = 0; i < original.Slides.Count; i++)
            {
                Require(ApplicationShapes(removed.Slides[i]).Count() == ApplicationShapes(original.Slides[i]).Count(), "Original shape count changed.");
                Require(Text(removed.Slides[i]) == Text(original.Slides[i]), "Original text changed.");
                Require(ApplicationShapes(removed.Slides[i]).Select(s => s.Name).SequenceEqual(ApplicationShapes(original.Slides[i]).Select(s => s.Name)), "Original shape identities changed.");
            }
        }
        Require(Hash("input.pptx") == inputHash, "The source was overwritten.");
        Report(new { slides = 2, text_and_image_applied = true, multiple_layouts_rendered = true, originals_retained = true, tagged_removal_only = true, original_unchanged = true });
    }
}
