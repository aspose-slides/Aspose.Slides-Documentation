using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static void ExportGif(bool licensed)
    {
        using var presentation = CreateSource(licensed);
        var options = new GifOptions
        {
            FrameSize = new Size(320, 180),
            DefaultDelay = 1000,
            TransitionFps = 10
        };

        presentation.Save("source.pptx", SaveFormat.Pptx);
        const string gifPath = "slides.gif";
        presentation.Save(gifPath, SaveFormat.Gif, options);

        Report(new
        {
            gif_created = File.Exists(gifPath),
            frame_width = options.FrameSize.Width,
            frame_height = options.FrameSize.Height,
            slide_delay_ms = options.DefaultDelay
        });
    }
}
