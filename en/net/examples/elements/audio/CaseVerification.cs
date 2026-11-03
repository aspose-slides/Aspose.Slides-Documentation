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
            Context.Require(p.Slides[0].Shapes.OfType<IAudioFrame>().Single().EmbeddedAudio.BinaryData.SequenceEqual(File.ReadAllBytes(Context.Input("tone.wav"))), "AddAudio: semantic check 1 failed.");
        });
        Context.Pass("elements/audio/block-001", "AddAudio", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAudioFrame>().Single().EmbeddedAudio.BinaryData.Length > 44, "AccessAudio: semantic check 1 failed.");
        });
        Context.Pass("elements/audio/block-002", "AccessAudio", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IAudioFrame>().Any(), "RemoveAudio: semantic check 1 failed.");
        });
        Context.Pass("elements/audio/block-003", "RemoveAudio", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAudioFrame>().Single().PlayMode == AudioPlayModePreset.Auto, "SetAudioPlayback: semantic check 1 failed.");
        });
        Context.Pass("elements/audio/block-004", "SetAudioPlayback", "save-reopen-structure");
    }
}
