using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static IEnumerable<ITextFrame> Frames(IShapeCollection shapes)
    {
        foreach (var shape in shapes)
        {
            if (shape is IAutoShape auto && auto.TextFrame != null) yield return auto.TextFrame;
            if (shape is IGroupShape group)
                foreach (var frame in Frames(group.Shapes)) yield return frame;
            if (shape is ITable table)
                for (int row = 0; row < table.Rows.Count; row++)
                    for (int column = 0; column < table.Columns.Count; column++) yield return table[column, row].TextFrame;
        }
    }

    private static IEnumerable<ITextFrame> AllFrames(Presentation p)
    {
        foreach (var slide in p.Slides)
        {
            foreach (var frame in Frames(slide.Shapes)) yield return frame;
            if (slide.NotesSlideManager.NotesSlide?.NotesTextFrame is ITextFrame notes) yield return notes;
        }
        foreach (var master in p.Masters)
            foreach (var frame in Frames(master.Shapes)) yield return frame;
    }

    private static void ReplacePresentationText()
    {
        CreateInput();
        string originalHash = Hash("input.pptx");
        using (var editable = new Presentation("input.pptx"))
        {
            var options = new TextSearchOptions { CaseSensitive = true };
            foreach (var frame in AllFrames(editable))
            {
                frame.ReplaceText("OLD", "NEW", options, null);
                frame.ReplaceRegex(new Regex(@"\b2025\b"), "2026", null);
            }
            Require(AllFrames(editable).Count(f => f.Text == Context.ExpectedText("NEW 2026")) == 5, "A target location was missed.");
            string beforeNoMatch = string.Join("|", AllFrames(editable).Select(f => f.Text));
            foreach (var frame in AllFrames(editable)) frame.ReplaceText("NO-SUCH-MARKER", "ignored", options, null);
            Require(beforeNoMatch == string.Join("|", AllFrames(editable).Select(f => f.Text)), "No-match replacement changed text.");
            editable.Save("output.pptx", SaveFormat.Pptx);
        }
        VerifyOutput(originalHash);
    }
}
