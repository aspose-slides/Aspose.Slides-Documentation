using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var notesSlide = slide.NotesSlideManager.AddNotesSlide();

        notesSlide.NotesTextFrame.Text = "Note";
        var notes = notesSlide.NotesTextFrame.Text;
        Context.Require(notes == "Note", "Accessed expected notes text.");

        VerifyCase02(presentation);
    }
}
