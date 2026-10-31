using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a video.
        var video = presentation.Videos.AddVideo(File.ReadAllBytes(Context.Input("video.mp4")));
        var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IVideoFrame>().Single().EmbeddedVideo.BinaryData.SequenceEqual(File.ReadAllBytes(Context.Input("video.mp4"))), "AddVideo: semantic check 1 failed.");
        });
        Context.Pass("elements/video/block-001", "AddVideo", "save-reopen-structure");
    }
}
