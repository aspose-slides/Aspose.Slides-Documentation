using System.Threading.Tasks;
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static void ExportHtml(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        source.Save("classic.html", SaveFormat.Html, new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new ResponsiveHtmlController()) });
        using var web = new Presentation("source.pptx");
        for (int i = web.Slides.Count - 1; i >= 0; i--)
            if (web.Slides[i].Hidden)
                web.Slides.RemoveAt(i);
        foreach (var slide in web.Slides)
        {
            slide.SlideShowTransition.Type = TransitionType.Fade;
            slide.Timeline.MainSequence.Clear();
            var title = slide.Shapes.OfType<IAutoShape>().Single(shape => shape.Name == "RecipeTitle");
            slide.Timeline.MainSequence.AddEffect(title, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
        }

        web.Save("slides.html", SaveFormat.Html5, new Html5Options { AnimateShapes = true, AnimateTransitions = true, EmbedImages = false });
        Report(new { classic_html = File.Exists("classic.html"), html5 = File.Exists("slides.html"), asset_files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories).Count(path => new[] { ".png", ".jpg", ".css", ".js" }.Contains(Path.GetExtension(path))) });
    }
}
