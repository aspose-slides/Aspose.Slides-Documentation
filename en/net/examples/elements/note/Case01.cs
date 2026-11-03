using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var notesSlide = slide.NotesSlideManager.AddNotesSlide();
        slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Note";

        VerifyCase01(presentation);
    }
}
