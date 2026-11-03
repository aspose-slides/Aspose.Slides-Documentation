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
    private static void CreateInput()
    {
        using (var source = new Presentation())
        {
            source.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
            var split = Label(source.Slides[0], "");
            split.TextFrame.Paragraphs.Clear();
            var paragraph = new Paragraph();
            paragraph.Portions.Add(new Portion("OL"));
            paragraph.Portions.Add(new Portion("D 2025"));
            paragraph.Portions[0].PortionFormat.FontBold = NullableBool.True;
            split.TextFrame.Paragraphs.Add(paragraph);
            var group = source.Slides[0].Shapes.AddGroupShape();
            var grouped = group.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 155, 200, 40);
            grouped.TextFrame.Text = "OLD 2025";
            var table = source.Slides[0].Shapes.AddTable(300, 155, new[] { 250.0 }, new[] { 40.0 });
            table[0, 0].TextFrame.Text = "OLD 2025";
            var masterText = Label(source.Masters[0], "OLD 2025", 310);
            masterText.Height = 40;
            source.Slides[0].NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = "OLD 2025";
            var keep = Label(source.Slides[0], "Keep this", 210);
            keep.Name = "keep";
            keep.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold = NullableBool.True;
            source.Save("input.pptx", SaveFormat.Pptx);
        }
    }

    private static IAutoShape Label(IBaseSlide slide, string text, float y = 50)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, y, 560, 90);
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
        return shape;
    }
}
