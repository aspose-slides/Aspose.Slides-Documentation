using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var section = presentation.Sections.AddSection("Temporary Section", slide);

        // Remove the section returned when it was added; keep its slide.
        presentation.Sections.RemoveSection(section);

        VerifyCase03(presentation);
    }
}
