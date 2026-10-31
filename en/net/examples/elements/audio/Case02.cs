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
        using var audioStream = File.OpenRead(Context.Input("tone.wav"));

        slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);

        // Access the first audio frame on the slide.
        var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAudioFrame>().Single().EmbeddedAudio.BinaryData.Length > 44, "AccessAudio: semantic check 1 failed.");
        });
        Context.Pass("elements/audio/block-002", "AccessAudio", "save-reopen-structure");
    }
}
