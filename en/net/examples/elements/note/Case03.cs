using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.NotesSlideManager.AddNotesSlide();

        slide.NotesSlideManager.RemoveNotesSlide();

        VerifyCase03(presentation);
    }
}
