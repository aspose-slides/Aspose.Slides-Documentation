using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
        slide.HeaderFooterManager.SetDateTimeText("Today");

        VerifyCase02(presentation);
    }
}
