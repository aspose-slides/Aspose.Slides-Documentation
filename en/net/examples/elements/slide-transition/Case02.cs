using Aspose.Slides;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.SlideShowTransition.Type = TransitionType.Push;

        // Access the transition type.
        var type = slide.SlideShowTransition.Type;

        VerifyCase02(presentation);
    }
}
