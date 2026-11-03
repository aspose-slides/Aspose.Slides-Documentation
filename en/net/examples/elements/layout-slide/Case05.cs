using Aspose.Slides;

internal static partial class Program
{
    static void Case05()
    {
        using var presentation = new Presentation();
        
        // Get an existing layout slide by type.
        var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        
        // Clone the layout slide to the end of the layout slide collection.
        var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
        clonedLayoutSlide.Name = "Clone";

        VerifyCase05(presentation);
    }
}
