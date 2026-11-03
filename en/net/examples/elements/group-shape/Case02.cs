using System.Linq;
using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        var firstGroup = slide.Shapes.OfType<IGroupShape>().First();

        VerifyCase02(presentation);
    }
}
