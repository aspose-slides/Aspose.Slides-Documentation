using System;
using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        // Access a layout slide by index.
        var firstLayoutSlide = presentation.LayoutSlides[0];
        Console.WriteLine($"Index 0: {firstLayoutSlide.Name}");

        // Access a layout slide by type.
        var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        Console.WriteLine($"Blank layout: {blankLayoutSlide.Name}");

        VerifyCase02(presentation);
    }
}
