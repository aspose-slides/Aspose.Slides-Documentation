using System.Threading.Tasks;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static void ReplaceFonts()
    {
        LoadVerifiedFonts("NotoSans-Regular.ttf");
        try
        {
            using (var source = new Presentation())
            {
                source.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
                var explicitText = Label(source.Slides[0], "Explicit font");
                explicitText.Name = "explicit";
                explicitText.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Arial");
                var defaultText = Label(source.Slides[0], "Paragraph default", 175);
                defaultText.Name = "default";
                defaultText.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
                source.Save("input.pptx", SaveFormat.Pptx);
            }

            string inputHash = Hash("input.pptx");
            using (var editable = new Presentation("input.pptx"))
            {
                Require(editable.Slides[0].Shapes.OfType<IAutoShape>().Single(shape => shape.Name == "explicit").TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont.FontName == "Arial", "The input must contain the original explicit font reference.");
                Require(editable.Slides[0].Shapes.OfType<IAutoShape>().Single(shape => shape.Name == "default").TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.LatinFont.FontName == "Arial", "The input must contain the original paragraph font reference.");
                editable.FontsManager.ReplaceFont(new FontData("Arial"), new FontData("Noto Sans"));
                editable.Save("output.pptx", SaveFormat.Pptx);
            }

            using (var result = new Presentation("output.pptx"))
            {
                var a = result.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "explicit");
                var b = result.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "default");
                Require(a.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont.FontName == "Noto Sans", "Explicit reference was not replaced.");
                Require(b.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.LatinFont.FontName == "Noto Sans", "Paragraph default was not replaced.");
                Require(a.TextFrame.Text == Context.ExpectedText("Explicit font") && b.TextFrame.Text == Context.ExpectedText("Paragraph default"), "Text changed.");
                Render(result.Slides[0], "preview.png");
            }

            Require(Hash("input.pptx") == inputHash, "Original changed.");
            Report(new { explicit_replaced = true, paragraph_default_replaced = true, saved_text_retained = true, original_unchanged = true });
        }
        finally
        {
            FontsLoader.ClearCache();
        }
    }
}
