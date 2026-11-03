using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var firstSlide = presentation.Slides[0];

        // Add a clone of the first slide (created by default).
        var clonedSlide = presentation.Slides.AddClone(firstSlide);

        clonedSlide.Name = "Clone";

        // Move the cloned slide to the first position (others shift down).
        presentation.Slides.Reorder(index: 0, clonedSlide);

        VerifyCase04(presentation);
    }
}
