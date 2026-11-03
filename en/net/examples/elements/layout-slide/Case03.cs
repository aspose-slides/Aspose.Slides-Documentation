using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        
        // Get a layout slide by type and remove it.
        var blankLayoutSlide = presentation.LayoutSlides.Add(presentation.Masters[0], SlideLayoutType.Blank, "Unused");
        presentation.LayoutSlides.Remove(blankLayoutSlide);

        VerifyCase03(presentation);
    }
}
