using System;
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

        VerifyCase01(presentation);
    }
}
