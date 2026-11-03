using System.IO;
using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a video.
        var video = presentation.Videos.AddVideo(File.ReadAllBytes(Context.Input("video.mp4")));
        var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

        VerifyCase01(presentation);
    }
}
