using Aspose.Slides;
using Aspose.Slides.SmartArt;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        VerifyCase01(presentation);
    }
}
