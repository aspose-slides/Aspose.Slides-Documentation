using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var notesSlide = slide.NotesSlideManager.AddNotesSlide();

        slide.NotesSlideManager.RemoveNotesSlide();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides[0].NotesSlideManager.NotesSlide == null, "RemoveNote: semantic check 1 failed.");
        });
        Context.Pass("elements/note/block-003", "RemoveNote", "save-reopen-structure");
    }
}
