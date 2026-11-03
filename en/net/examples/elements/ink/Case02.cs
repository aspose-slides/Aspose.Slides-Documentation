using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Ink;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(Context.Input("ink.pptx"));
        var slide = presentation.Slides[0];

        var inkShape = slide.Shapes.OfType<Ink>().FirstOrDefault();
        if (inkShape == null)
        {
            Console.WriteLine("No ink shape was found on the first slide.");
            return;
        }

        slide.Shapes.Remove(inkShape);

        VerifyCase02(presentation);
    }
}
