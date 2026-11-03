using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;

internal static partial class Program
{
    private static Presentation CreateSource(bool licensed)
    {
        var presentation = new Presentation();
        presentation.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        var blank = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        string[] labels = licensed ? ["Alpha", "Bravo", "Charlie", "Hidden"] : ["Alpha", "Bravo", "C", "Hide"];
        for (int i = 0; i < labels.Length; i++)
        {
            var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(blank);
            AddTitle(slide, labels[i]);
            slide.Hidden = i == labels.Length - 1;
        }

        byte[] imageBytes = SampleImage();
        var image = presentation.Images.AddImage(imageBytes);
        presentation.Slides[2].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 120, 200, 120, image);
        return presentation;
    }

    private static IAutoShape AddTitle(ISlide slide, string text)
    {
        var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 580, 55);
        title.Name = "RecipeTitle";
        title.TextFrame.Text = text;
        title.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 26;
        return title;
    }

    private static byte[] SampleImage()
    {
        using var fixture = new Presentation();
        fixture.SlideSize.SetSize(600, 360, SlideSizeScaleType.DoNotScale);
        var slide = fixture.Slides[0];
        slide.Background.Type = BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;
        var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 90, 300, 180);
        ellipse.FillFormat.FillType = FillType.Solid;
        ellipse.FillFormat.SolidFillColor.Color = Color.White;
        ellipse.LineFormat.FillFormat.FillType = FillType.NoFill;
        using var image = slide.GetImage(new Size(600, 360));
        using var bytes = new MemoryStream();
        image.Save(bytes, Aspose.Slides.ImageFormat.Png);
        return bytes.ToArray();
    }
}
