using System.Threading.Tasks;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static partial class Program
{
    private static void RunExample()
    {
        using (var input = Deck("Quarterly update", "Public summary"))
        {
            input.DocumentProperties.Author = "Example internal author"; input.DocumentProperties.SetCustomPropertyValue("ReviewStatus", "Draft");
            input.Slides[0].NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = "Private example note";
            var author = input.CommentAuthors.AddAuthor("Example reviewer", "ER");
            author.Comments.AddComment("Example review", input.Slides[0], new PointF(10, 10), DateTime.UtcNow);
            input.VbaProject = new VbaProject();
            input.VbaProject.Modules.AddEmptyModule("SampleModule").SourceCode = "Sub Example()\nEnd Sub";
            input.Save("original.pptm", SaveFormat.Pptm);
        }
        string original = Hash("original.pptm");
        using var copy = new Presentation("original.pptm");
        foreach (var slide in copy.Slides)
        {
            if (slide.NotesSlideManager.NotesSlide != null) slide.NotesSlideManager.RemoveNotesSlide();
            Label(slide, "DISTRIBUTION COPY", "DistributionWatermark", 520, 450, 400, 55);
        }
        foreach (var reviewer in copy.CommentAuthors) reviewer.Comments.Clear();
        copy.CommentAuthors.Clear(); copy.VbaProject = null;
        copy.DocumentProperties.Author = ""; copy.DocumentProperties.ClearCustomProperties();
        copy.Save("distribution.pptx", SaveFormat.Pptx);
        string password = Environment.GetEnvironmentVariable("OUTPUT_PDF_PASSWORD") ?? "demonstration-only";
        copy.Save("distribution.pdf", SaveFormat.Pdf, new PdfOptions { Password = password });
        using var reopened = new Presentation("distribution.pptx");
        Require(reopened.VbaProject == null && reopened.CommentAuthors.Count == 0 && reopened.DocumentProperties.CountOfCustomProperties == 0, "Selected removals failed.");
        Require(reopened.Slides.All(s => s.NotesSlideManager.NotesSlide == null), "Notes remain.");
        Require(Hash("original.pptm") == original, "Original was overwritten.");
        Preview(reopened, "preview.png");
        Report(new { notes_removed = true, comments_removed = true, macros_removed = true, custom_properties_removed = true, input_preserved = true });
    }
}
