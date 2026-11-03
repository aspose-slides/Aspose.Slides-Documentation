using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        // Each slide is based on a layout, which itself is based on a master slide.
        // Use the Blank layout to create a new slide.
        var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

        // Add a new empty slide using the selected layout.
        presentation.Slides.AddEmptySlide(layout: blankLayout);

        VerifyCase01(presentation);
    }
}
