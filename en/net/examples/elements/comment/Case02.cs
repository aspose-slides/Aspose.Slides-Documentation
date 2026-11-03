using System;
using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(Seed("comment"));
        var author = presentation.CommentAuthors[0];

        var comment = (IModernComment)author.Comments[0];
        Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");

        VerifyCase02(presentation);
    }
}
