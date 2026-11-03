using Aspose.Slides;

internal static partial class Program
{
    static void Case05()
    {
        using var presentation = new Presentation();
        // Add a new empty slide in addition to the default first slide.
        var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        var survivingSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);
        survivingSlide.Name = "Survivor";

        // Remove the first slide; only the newly added slide will remain.
        var firstSlide = presentation.Slides[0];
        presentation.Slides.Remove(firstSlide);

        VerifyCase05(presentation);
    }
}
