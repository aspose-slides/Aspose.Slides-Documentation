using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static IEnumerable<ITextFrame> ShapeTextFrames(IShapeCollection shapes)
    {
        foreach (var shape in shapes)
        {
            if (shape is IAutoShape auto && auto.TextFrame != null)
                yield return auto.TextFrame;
            if (shape is IGroupShape group)
                foreach (var frame in ShapeTextFrames(group.Shapes))
                    yield return frame;
            if (shape is ITable table)
                for (int row = 0; row < table.Rows.Count; row++)
                    for (int column = 0; column < table.Columns.Count; column++)
                        yield return table[column, row].TextFrame;
        }
    }

    private static IEnumerable<ITextFrame> SlideNotesAndMasterText(Presentation p)
    {
        foreach (var slide in p.Slides)
        {
            foreach (var frame in ShapeTextFrames(slide.Shapes))
                yield return frame;
            if (slide.NotesSlideManager.NotesSlide?.NotesTextFrame is ITextFrame notes)
                yield return notes;
        }

        foreach (var master in p.Masters)
            foreach (var frame in ShapeTextFrames(master.Shapes))
                yield return frame;
    }

    private static void ReplacePresentationText()
    {
        CreateInput();
        string originalHash = Hash("input.pptx");
        using (var editable = new Presentation("input.pptx"))
        {
            var options = new TextSearchOptions
            {
                CaseSensitive = true
            };
            var yearPattern = new Regex(@"\b2025\b", RegexOptions.Compiled);
            foreach (var frame in SlideNotesAndMasterText(editable))
            {
                frame.ReplaceText("OLD", "NEW", options, null);
                frame.ReplaceRegex(yearPattern, "2026", null);
            }

            Require(SlideNotesAndMasterText(editable).Count(f => f.Text == Context.ExpectedText("NEW 2026")) == 5, "A target location was missed.");
            string beforeNoMatch = string.Join("|", SlideNotesAndMasterText(editable).Select(f => f.Text));
            foreach (var frame in SlideNotesAndMasterText(editable))
                frame.ReplaceText("NO-SUCH-MARKER", "ignored", options, null);
            Require(beforeNoMatch == string.Join("|", SlideNotesAndMasterText(editable).Select(f => f.Text)), "No-match replacement changed text.");
            editable.Save("output.pptx", SaveFormat.Pptx);
        }

        VerifyOutput(originalHash);
    }
}
