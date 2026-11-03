using Aspose.Slides;

internal static partial class Program
{
    private static Presentation CreateSource(bool licensed)
    {
        var presentation = new Presentation();
        presentation.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        var blank = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        string[] labels = ["Alpha"];
        for (int i = 0; i < labels.Length; i++)
        {
            var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(blank);
            AddTitle(slide, labels[i]);
        }

        var table = presentation.Slides[0].Shapes.AddTable(30, 100, [140, 100], [35, 35]);
        table[0, 0].TextFrame.Text = "Item";
        table[1, 0].TextFrame.Text = "Units";
        table[0, 1].TextFrame.Text = "Pens";
        table[1, 1].TextFrame.Text = "12";
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
}
