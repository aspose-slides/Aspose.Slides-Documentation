using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        slide.Shapes.Remove(connector);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IConnector>().Any(), "RemoveConnector: semantic check 1 failed.");
        });
        Context.Pass("elements/connector/block-003", "RemoveConnector", "save-reopen-structure");
    }
}
