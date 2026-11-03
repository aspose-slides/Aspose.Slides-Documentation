using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();
        var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Move shape out of the group.
        slide.Shapes.AddClone(rect);
        group.Shapes.Remove(rect);

        VerifyCase04(presentation);
    }
}
