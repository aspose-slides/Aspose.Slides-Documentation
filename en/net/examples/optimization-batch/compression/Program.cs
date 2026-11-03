using System.Threading.Tasks;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static void CompressPicture()
    {
        CreateInput();
        long before = new FileInfo("output/input.pptx").Length;
        bool compressed;
        using (var presentation = new Presentation("output/input.pptx"))
        {
            var frame = Example.Named<IPictureFrame>(presentation.Slides[0], "Oversized image");
            compressed = frame.PictureFormat.CompressImage(true, PicturesCompression.Dpi96);
            presentation.Save("output/compressed.pptx", SaveFormat.Pptx);
            Example.Render(presentation, "output/after.png");
        }

        VerifyOutput(before, compressed);
    }
}
