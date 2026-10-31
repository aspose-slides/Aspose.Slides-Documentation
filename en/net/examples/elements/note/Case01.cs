using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var notesSlide = slide.NotesSlideManager.AddNotesSlide();
        slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Note";

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Trim() == "Note", "AddNote: semantic check 1 failed.");
        });
        Context.Pass("elements/note/block-001", "AddNote", "save-reopen-structure");
    }
}
