using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        var headerFooter = slide.HeaderFooterManager;

        headerFooter.SetFooterVisibility(isVisible: true);
        headerFooter.SetFooterText("Foot");

        VerifyCase01(presentation);
    }
}
