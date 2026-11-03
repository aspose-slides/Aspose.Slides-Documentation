using System.IO;
using System.Linq;
using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var video = presentation.Videos.AddVideo(File.ReadAllBytes(Context.Input("video.mp4")));
        slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

        // Access the first video frame on the slide.
        var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();

        VerifyCase02(presentation);
    }
}
