using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var startShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        var endShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.StartShapeConnectedTo = startShape;
        connector.EndShapeConnectedTo = endShape;

        VerifyCase04(presentation);
    }
}
