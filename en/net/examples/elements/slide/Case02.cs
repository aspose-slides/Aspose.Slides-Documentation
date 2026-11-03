using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        // By default, a presentation is created with one empty slide.
        using var presentation = new Presentation();

        // Add another empty slide.
        var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        presentation.Slides.AddEmptySlide(layout: blankLayout);

        // Access slides by index.
        var firstSlide = presentation.Slides[0];
        var secondSlide = presentation.Slides[1];

        // Get slide index from a reference, then access it by index.
        var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
        var secondSlideByIndex = presentation.Slides[secondSlideIndex];

        VerifyCase02(presentation);
    }
}
