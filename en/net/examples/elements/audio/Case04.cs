using System.IO;
using Aspose.Slides;

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

        VerifyCase04(presentation);
    }
}
