using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var author = presentation.CommentAuthors.AddAuthor("User", "U1");
        author.Comments.AddModernComment("Note", slide, null, new PointF(100, 100), new DateTime(2026, 1, 1));

        presentation.Save("modern_comment.pptx", SaveFormat.Pptx);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.CommentAuthors.Count == 1 && p.CommentAuthors[0].Comments.Count == 1 && p.CommentAuthors[0].Comments[0].Text == "Note", "AddModernComment: semantic check 1 failed.");
        });
        Context.Pass("elements/comment/block-001", "AddModernComment", "save-reopen-structure");
    }
}
