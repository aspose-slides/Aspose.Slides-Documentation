using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();
        var rectangle = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Clone the rectangle onto the slide, then remove its original from the group.
        slide.Shapes.AddClone(rectangle);
        group.Shapes.Remove(rectangle);

        VerifyCase04(presentation);
    }
}
