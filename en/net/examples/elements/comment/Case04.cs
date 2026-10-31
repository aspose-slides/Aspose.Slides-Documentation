using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var author = presentation.CommentAuthors.AddAuthor("User", "U1");

        var parentComment = author.Comments.AddModernComment("Root", slide, null, new PointF(100, 100), new DateTime(2026, 1, 1));
        var reply1 = author.Comments.AddModernComment("One", slide, null, new PointF(110, 100), new DateTime(2026, 1, 1));
        var reply2 = author.Comments.AddModernComment("Two", slide, null, new PointF(120, 100), new DateTime(2026, 1, 1));

        reply1.ParentComment = parentComment;
        reply2.ParentComment = parentComment;

        presentation.Save("modern_comment_replies.pptx", SaveFormat.Pptx);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.CommentAuthors[0].Comments.Count == 3 && p.CommentAuthors[0].Comments[1].ParentComment == p.CommentAuthors[0].Comments[0] && p.CommentAuthors[0].Comments[2].ParentComment == p.CommentAuthors[0].Comments[0], "ReplyToModernComment: semantic check 1 failed.");
        });
        Context.Pass("elements/comment/block-004", "ReplyToModernComment", "save-reopen-structure");
    }
}
