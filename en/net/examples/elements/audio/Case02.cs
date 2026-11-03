using System.IO;
using System.Linq;
using Aspose.Slides;

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

        VerifyCase02(presentation);
    }
}
