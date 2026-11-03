using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        presentation.Sections.AddSection("Old Name", slide);

        var section = presentation.Sections[0];
        section.Name = "New Name";

        VerifyCase04(presentation);
    }
}
