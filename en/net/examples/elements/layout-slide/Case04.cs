using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        
        // Automatically removes all layout slides not referenced by any slide.
        presentation.LayoutSlides.RemoveUnused();

        VerifyCase04(presentation);
    }
}
