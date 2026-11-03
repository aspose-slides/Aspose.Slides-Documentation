using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Specify the slide that marks the beginning of the section.
        presentation.Sections.AddSection("New Section", slide);

        VerifyCase01(presentation);
    }
}
