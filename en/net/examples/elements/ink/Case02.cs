using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Ink;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(Context.Input("ink.pptx"));
        var slide = presentation.Slides[0];

        if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
        {
            slide.Shapes.Remove(ink);
        }

        VerifyCase02(presentation);
    }
}
