using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(Seed("comment"));
        var author = presentation.CommentAuthors[0];

        var comment = (IModernComment)author.Comments[0];
        Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.CommentAuthors[0].Comments[0] is IModernComment && p.CommentAuthors[0].Comments[0].Text == "Note", "AccessModernComment: semantic check 1 failed.");
        });
        Context.Pass("elements/comment/block-002", "AccessModernComment", "save-reopen-structure");
    }
}
