using Aspose.Slides.Export;
using Aspose.Slides;
using System.IO;
using System.Linq;
using System;

internal static partial class Program
{
    private static void VerifyCase01(Presentation presentation)
    {
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Trim() == "Note", "AddNote: semantic check 1 failed.");
        });
        Context.Pass("elements/note/block-001", "AddNote", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Trim() == "Note", "AccessNote: semantic check 1 failed.");
        });
        Context.Pass("elements/note/block-002", "AccessNote", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides[0].NotesSlideManager.NotesSlide == null, "RemoveNote: semantic check 1 failed.");
        });
        Context.Pass("elements/note/block-003", "RemoveNote", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Trim() == "New", "UpdateNoteText: semantic check 1 failed.");
        });
        Context.Pass("elements/note/block-004", "UpdateNoteText", "save-reopen-structure");
    }
}
