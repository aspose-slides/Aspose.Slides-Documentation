using System;
using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        // By default, the presentation contains one empty slide.
        using var presentation = new Presentation();
        var firstSlide = presentation.Slides[0];

        // Clone the first slide; it will be added at the end of the presentation.
        var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

        // The cloned slide index is 1 (second slide in the presentation).
        var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
        Console.WriteLine($"Clone index: {clonedSlideIndex}");

        VerifyCase03(presentation);
    }
}
