using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var section = presentation.Sections.AddSection("Old Name", slide);
        section.Name = "New Name";

        VerifyCase04(presentation);
    }
}
