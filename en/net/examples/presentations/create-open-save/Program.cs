using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static void RunExample()
    {
        using (var created = new Presentation())
        {
            created.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
            Label(created.Slides[0], "Quarterly results");
            created.Save("original.pptx", SaveFormat.Pptx);
        }
        string originalHash = Hash("original.pptx");
        using (var editable = new Presentation("original.pptx"))
        {
            editable.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name.StartsWith("content-", StringComparison.Ordinal)).TextFrame.Text = "Updated results";
            editable.Save("edited.pptx", SaveFormat.Pptx);
        }
        using (var result = new Presentation("edited.pptx"))
        {
            Require(result.Slides.Count == 1, "Unexpected slide count.");
            Require(Text(result.Slides[0]) == Context.ExpectedText("Updated results"), "Edited text did not survive saving.");
            using var image = result.Slides[0].GetImage(new Size(640, 360));
            image.Save("preview.png", Aspose.Slides.ImageFormat.Png);
        }
        Require(Hash("original.pptx") == originalHash, "The input was overwritten.");
        using (var original = new Presentation("original.pptx"))
            Require(Text(original.Slides[0]) == Context.ExpectedText("Quarterly results"), "Original content changed.");
        Report(new { slide_count = 1, edited_text = Context.ExpectedText("Updated results"), original_unchanged = true });
    }
}
