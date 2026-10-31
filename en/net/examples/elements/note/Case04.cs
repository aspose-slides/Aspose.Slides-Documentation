using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var notesSlide = slide.NotesSlideManager.AddNotesSlide();

        slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
        slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "New";

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Trim() == "New", "UpdateNoteText: semantic check 1 failed.");
        });
        Context.Pass("elements/note/block-004", "UpdateNoteText", "save-reopen-structure");
    }
}
