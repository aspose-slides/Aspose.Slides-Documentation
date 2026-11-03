using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using System.Threading.Tasks;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private sealed record TextItem(string Shape, string Text);
    private sealed record SlideText(int Number, bool Hidden, TextItem[] Text, string Notes);
    private static SlideText[] Extract(Presentation presentation, bool includeHidden)
    {
        var slides = new List<SlideText>();
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            var slide = presentation.Slides[i];
            int originalSlideNumber = i + 1;
            if (!includeHidden && slide.Hidden)
                continue;
            var textItems = new List<TextItem>();
            foreach (var shape in Example.Walk(slide.Shapes).OfType<IAutoShape>())
                textItems.Add(new TextItem(shape.Name, shape.TextFrame.Text));
            string notes = slide.NotesSlideManager.NotesSlide?.NotesTextFrame.Text ?? "";
            slides.Add(new SlideText(originalSlideNumber, slide.Hidden, textItems.ToArray(), notes));
        }

        return slides.ToArray();
    }

    private static void ExtractTextAndNotes()
    {
        CreateInput();
        using var input = new Presentation("output/input.pptx");
        var all = Extract(input, includeHidden: true); // Change to false for visible slides only.
        var visible = Extract(input, includeHidden: false);
        Example.Json("output/text.json", new { include_hidden = true, slides = all });
        VerifyExtraction(all, visible);
    }
}
