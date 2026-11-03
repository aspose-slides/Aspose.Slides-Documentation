using System.Linq;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();

        VerifyCase02(presentation);
    }
}
