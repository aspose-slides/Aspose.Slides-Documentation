using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        var headerFooter = slide.HeaderFooterManager;

        headerFooter.SetDateTimeVisibility(isVisible: true);
        headerFooter.SetDateTimeText("Today");

        VerifyCase02(presentation);
    }
}
