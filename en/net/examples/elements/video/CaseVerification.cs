using Aspose.Slides.Export;
using Aspose.Slides;
using System.IO;
using System.Linq;
using System;

internal static partial class Program
{
    private static void VerifyCase01(Presentation presentation)
    {
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IVideoFrame>().Single().EmbeddedVideo.BinaryData.SequenceEqual(File.ReadAllBytes(Context.Input("video.mp4"))), "AddVideo: semantic check 1 failed.");
        });
        Context.Pass("elements/video/block-001", "AddVideo", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IVideoFrame>().Single().EmbeddedVideo.BinaryData.Length > 100, "AccessVideo: semantic check 1 failed.");
        });
        Context.Pass("elements/video/block-002", "AccessVideo", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IVideoFrame>().Any(), "RemoveVideo: semantic check 1 failed.");
        });
        Context.Pass("elements/video/block-003", "RemoveVideo", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IVideoFrame>().Single().PlayMode == VideoPlayModePreset.Auto, "SetVideoPlayback: semantic check 1 failed.");
        });
        Context.Pass("elements/video/block-004", "SetVideoPlayback", "save-reopen-structure");
    }
}
