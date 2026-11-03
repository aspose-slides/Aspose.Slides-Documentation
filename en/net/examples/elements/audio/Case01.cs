using System.IO;
using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        using var audioStream = File.OpenRead(Context.Input("tone.wav"));

        // Embed the complete packaged PCM WAV tone.
        slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);

        VerifyCase01(presentation);
    }
}
