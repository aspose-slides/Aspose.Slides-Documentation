using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

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

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Trim() == "Note", "AccessNote: semantic check 1 failed.");
        });
        Context.Pass("elements/note/block-002", "AccessNote", "save-reopen-structure");
    }
}
