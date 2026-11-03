using System;
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

        var secondSlide = presentation.Slides[1];
        var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
        Console.WriteLine($"Zero-based index: {secondSlideIndex}");
        Console.WriteLine($"Slide number: {secondSlide.SlideNumber}");

        VerifyCase02(presentation);
    }
}
