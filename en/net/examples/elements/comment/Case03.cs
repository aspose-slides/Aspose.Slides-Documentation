using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation(Seed("comment"));
        var author = presentation.CommentAuthors[0];

        var comment = author.Comments[0];
        comment.Remove();

        presentation.Save("modern_comment_removed.pptx", SaveFormat.Pptx);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.CommentAuthors[0].Comments.Count == 0, "RemoveModernComment: semantic check 1 failed.");
        });
        Context.Pass("elements/comment/block-003", "RemoveModernComment", "save-reopen-structure");
    }
}
