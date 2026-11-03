using System.Threading.Tasks;
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static void ExportNotesAndHandouts(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        var notesOptions = new PdfOptions
        {
            SlidesLayoutOptions = new NotesCommentsLayoutingOptions
            {
                NotesPosition = NotesPositions.BottomFull
            }
        };
        source.Save("notes.pdf", SaveFormat.Pdf, notesOptions);
        var handoutOptions = new PdfOptions
        {
            ShowHiddenSlides = false,
            SlidesLayoutOptions = new HandoutLayoutingOptions
            {
                Handout = HandoutType.Handouts2,
                PrintSlideNumbers = true,
                PrintFrameSlide = true
            }
        };
        int[] handoutSlides = [1, 2, 3];
        source.Save("handout.pdf", handoutSlides, SaveFormat.Pdf, handoutOptions);
        Report(new { notes_export = File.Exists("notes.pdf"), handout_export = File.Exists("handout.pdf"), source_notes = source.Slides[0].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Contains("Alpha") });
    }
}
