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
        using var audioStream = File.OpenRead(Context.Input("tone.wav"));
        
        var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);

        // Play automatically when the slide appears.
        audioFrame.PlayMode = AudioPlayModePreset.Auto;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAudioFrame>().Single().PlayMode == AudioPlayModePreset.Auto, "SetAudioPlayback: semantic check 1 failed.");
        });
        Context.Pass("elements/audio/block-004", "SetAudioPlayback", "save-reopen-structure");
    }
}
