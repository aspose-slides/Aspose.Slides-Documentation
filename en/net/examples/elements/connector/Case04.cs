using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.StartShapeConnectedTo = shape1;
        connector.EndShapeConnectedTo = shape2;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IConnector>().Single().StartShapeConnectedTo != null && p.Slides[0].Shapes.OfType<IConnector>().Single().EndShapeConnectedTo != null, "ReconnectShapes: semantic check 1 failed.");
        });
        Context.Pass("elements/connector/block-004", "ReconnectShapes", "save-reopen-structure");
    }
}
