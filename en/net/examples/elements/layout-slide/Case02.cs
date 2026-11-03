using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        
        // Access a layout slide by index.
        var firstLayoutSlide = presentation.LayoutSlides[0];
        
        // Access a layout slide by type.
        var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

        VerifyCase02(presentation);
    }
}
