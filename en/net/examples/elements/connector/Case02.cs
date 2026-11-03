using System.Linq;
using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        var connector = slide.Shapes.OfType<IConnector>().First();

        VerifyCase02(presentation);
    }
}
