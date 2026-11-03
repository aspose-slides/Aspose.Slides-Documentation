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

        VerifyCase03(presentation);
    }
}
