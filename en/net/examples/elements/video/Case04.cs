using System.IO;
using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var video = presentation.Videos.AddVideo(File.ReadAllBytes(Context.Input("video.mp4")));
        var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

        // Configure the video to play automatically.
        videoFrame.PlayMode = VideoPlayModePreset.Auto;

        VerifyCase04(presentation);
    }
}
