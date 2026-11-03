using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var section = presentation.Sections.AddSection("Temporary Section", slide);

        // Remove the first section.
        presentation.Sections.RemoveSection(section);

        VerifyCase03(presentation);
    }
}
