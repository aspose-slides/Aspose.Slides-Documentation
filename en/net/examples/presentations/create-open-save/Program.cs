using System.Drawing;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static void RunExample()
    {
        const string originalPath = "original.pptx";
        const string editedPath = "edited.pptx";
        using (var created = new Presentation())
        {
            created.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
            Label(created.Slides[0], "Quarterly results");
            created.Save(originalPath, SaveFormat.Pptx);
        }

        string originalHash = Hash(originalPath);
        using (var editable = new Presentation(originalPath))
        {
            editable.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "content-title").TextFrame.Text = "Updated results";
            editable.Save(editedPath, SaveFormat.Pptx);
        }

        using (var result = new Presentation(editedPath))
        {
            Require(result.Slides.Count == 1, "Unexpected slide count.");
            Require(Text(result.Slides[0]) == Context.ExpectedText("Updated results"), "Edited text did not survive saving.");
            using var image = result.Slides[0].GetImage(new Size(640, 360));
            image.Save("preview.png", Aspose.Slides.ImageFormat.Png);
        }

        Require(Hash(originalPath) == originalHash, "The input was overwritten.");
        using (var original = new Presentation(originalPath))
            Require(Text(original.Slides[0]) == Context.ExpectedText("Quarterly results"), "Original content changed.");
        Report(new { slide_count = 1, edited_text = Context.ExpectedText("Updated results"), original_unchanged = true });
    }
}
