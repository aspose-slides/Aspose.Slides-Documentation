using Aspose.Slides.Export;
using Aspose.Slides;
using System.Drawing;
using System.IO;
using System.Linq;
using System;

internal static partial class Program
{
    private static void VerifyCase01(Presentation presentation)
    {
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.CommentAuthors.Count == 1 && p.CommentAuthors[0].Comments.Count == 1 && p.CommentAuthors[0].Comments[0].Text == "Note", "AddModernComment: semantic check 1 failed.");
        });
        Context.Pass("elements/comment/block-001", "AddModernComment", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.CommentAuthors[0].Comments[0] is IModernComment && p.CommentAuthors[0].Comments[0].Text == "Note", "AccessModernComment: semantic check 1 failed.");
        });
        Context.Pass("elements/comment/block-002", "AccessModernComment", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.CommentAuthors[0].Comments.Count == 0, "RemoveModernComment: semantic check 1 failed.");
        });
        Context.Pass("elements/comment/block-003", "RemoveModernComment", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.CommentAuthors[0].Comments.Count == 3 && p.CommentAuthors[0].Comments[1].ParentComment == p.CommentAuthors[0].Comments[0] && p.CommentAuthors[0].Comments[2].ParentComment == p.CommentAuthors[0].Comments[0], "ReplyToModernComment: semantic check 1 failed.");
        });
        Context.Pass("elements/comment/block-004", "ReplyToModernComment", "save-reopen-structure");
    }
}
