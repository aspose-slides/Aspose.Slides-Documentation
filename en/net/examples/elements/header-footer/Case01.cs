using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
        slide.HeaderFooterManager.SetFooterText("Foot");

        VerifyCase01(presentation);
    }
}
