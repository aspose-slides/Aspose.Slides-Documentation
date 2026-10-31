using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var video = presentation.Videos.AddVideo(File.ReadAllBytes(Context.Input("video.mp4")));
        var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

        // Access the first video frame on the slide.
        var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IVideoFrame>().Single().EmbeddedVideo.BinaryData.Length > 100, "AccessVideo: semantic check 1 failed.");
        });
        Context.Pass("elements/video/block-002", "AccessVideo", "save-reopen-structure");
    }
}
