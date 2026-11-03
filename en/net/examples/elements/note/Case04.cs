using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var notesSlide = slide.NotesSlideManager.AddNotesSlide();

        notesSlide.NotesTextFrame.Text = "Old";
        notesSlide.NotesTextFrame.Text = "New";

        VerifyCase04(presentation);
    }
}
