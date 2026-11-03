using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);

        VerifyCase01(presentation);
    }
}
