using System.Threading.Tasks;
using System.Drawing;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static void RenderSlides(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        for (int i = 0; i < source.Slides.Count; i++)
        {
            var slide = source.Slides[i];
            var fullSize = new Size(640, 360);
            var thumbnailSize = new Size(160, 90);
            using var image = slide.GetImage(fullSize);
            image.Save($"slide-{i + 1}.png", Aspose.Slides.ImageFormat.Png);
            image.Save($"slide-{i + 1}.jpg", Aspose.Slides.ImageFormat.Jpeg);
            using var thumbnail = slide.GetImage(thumbnailSize);
            thumbnail.Save($"thumbnail-{i + 1}.png", Aspose.Slides.ImageFormat.Png);
        }

        Report(new { rendered_slides = source.Slides.Count, width = 640, height = 360, thumbnail_width = 160, thumbnail_height = 90 });
    }
}
