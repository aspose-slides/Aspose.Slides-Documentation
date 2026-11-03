using Aspose.Slides;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.SlideShowTransition.Type = TransitionType.Fade;

        slide.SlideShowTransition.Type = TransitionType.None;

        VerifyCase03(presentation);
    }
}
