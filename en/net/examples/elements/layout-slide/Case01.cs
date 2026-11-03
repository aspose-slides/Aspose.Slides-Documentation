using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        
        var masterSlide = presentation.Masters[0];

        // Create a layout slide with a blank layout type and a custom name.
        var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Add a text box to the layout slide.
        var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
        layoutTextBox.TextFrame.Text = "Base";

        // Add two slides using this layout; both will inherit the text from the layout.
        presentation.Slides.AddEmptySlide(layoutSlide);
        presentation.Slides.AddEmptySlide(layoutSlide);

        VerifyCase01(presentation);
    }
}
