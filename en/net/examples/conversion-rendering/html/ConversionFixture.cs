using System;
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

        var table = presentation.Slides[0].Shapes.AddTable(30, 100, [140, 100], [35, 35]);
        table[0, 0].TextFrame.Text = "Item";
        table[1, 0].TextFrame.Text = "Units";
        table[0, 1].TextFrame.Text = "Pens";
        table[1, 1].TextFrame.Text = "12";
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

    // Original blue-and-white fixture; no image library or download is needed.
    private static byte[] SampleImage() => Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAwAAAAICAYAAADN5B7xAAAAI0lEQVR4nGNImfr2PymYgWoaQIAoDdgATg34AHVsIMsPhDAAMPMqpQBAkJ0AAAAASUVORK5CYII=");
}
