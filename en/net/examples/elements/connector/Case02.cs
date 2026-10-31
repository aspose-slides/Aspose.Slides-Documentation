using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        var connector = slide.Shapes.OfType<IConnector>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IConnector>().Count() == 1, "AccessConnector: semantic check 1 failed.");
        });
        Context.Pass("elements/connector/block-002", "AccessConnector", "save-reopen-structure");
    }
}
