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
        using var audioStream = File.OpenRead(Context.Input("tone.wav"));

        // Embed the complete packaged PCM WAV tone.
        var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAudioFrame>().Single().EmbeddedAudio.BinaryData.SequenceEqual(File.ReadAllBytes(Context.Input("tone.wav"))), "AddAudio: semantic check 1 failed.");
        });
        Context.Pass("elements/audio/block-001", "AddAudio", "save-reopen-structure");
    }
}
