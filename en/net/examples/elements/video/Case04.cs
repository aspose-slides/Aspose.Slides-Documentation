using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

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

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IVideoFrame>().Single().PlayMode == VideoPlayModePreset.Auto, "SetVideoPlayback: semantic check 1 failed.");
        });
        Context.Pass("elements/video/block-004", "SetVideoPlayback", "save-reopen-structure");
    }
}
