using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var activeLayout = presentation.Slides[0].LayoutSlide;
        activeLayout.Name = "Active layout";
        presentation.LayoutSlides.Add(presentation.Masters[0], SlideLayoutType.Blank, "Unused layout");

        // Keep the referenced active layout and remove unreferenced layouts.
        presentation.LayoutSlides.RemoveUnused();

        VerifyCase04(presentation);
    }
}
