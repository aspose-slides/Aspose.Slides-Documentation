using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        // This new layout is safe to remove because no slide uses it.
        var unusedLayout = presentation.LayoutSlides.Add(presentation.Masters[0], SlideLayoutType.Blank, "Unused");
        presentation.LayoutSlides.Remove(unusedLayout);

        VerifyCase03(presentation);
    }
}
