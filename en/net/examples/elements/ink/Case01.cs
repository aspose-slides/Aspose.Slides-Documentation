using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Ink;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation(Context.Input("ink.pptx"));
        var slide = presentation.Slides[0];

        var inkShape = slide.Shapes.OfType<Ink>().First();
        inkShape.CustomData.Tags["kind"] = "Ink";
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            Context.Require(tags[tagName] == "Ink", "Read the known Ink tag value.");
        }

        VerifyCase01(presentation);
    }
}
