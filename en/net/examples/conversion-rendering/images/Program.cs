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

    private static void RenderSlides(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        for (int i = 0; i < source.Slides.Count; i++)
        {
            using var image = source.Slides[i].GetImage(new Size(640, 360));
            image.Save($"slide-{i + 1}.png", Aspose.Slides.ImageFormat.Png);
            image.Save($"slide-{i + 1}.jpg", Aspose.Slides.ImageFormat.Jpeg);
            using var thumbnail = source.Slides[i].GetImage(new Size(160, 90));
            thumbnail.Save($"thumbnail-{i + 1}.png", Aspose.Slides.ImageFormat.Png);
        }
        Report(new { rendered_slides = source.Slides.Count, width = 640, height = 360, thumbnail_width = 160, thumbnail_height = 90 });
    }
}
