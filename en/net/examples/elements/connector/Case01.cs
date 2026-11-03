using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        VerifyCase01(presentation);
    }
}
