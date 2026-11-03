using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        presentation.Sections.AddSection("My Section", slide);

        // Access a section by index.
        var section = presentation.Sections[0];
        var sectionName = section.Name;

        VerifyCase02(presentation);
    }
}
