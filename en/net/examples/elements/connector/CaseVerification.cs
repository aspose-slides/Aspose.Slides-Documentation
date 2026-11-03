using Aspose.Slides.Export;
using Aspose.Slides;
using System.IO;
using System.Linq;
using System;

internal static partial class Program
{
    private static void VerifyCase01(Presentation presentation)
    {
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IConnector>().Count() == 1, "AddConnector: semantic check 1 failed.");
        });
        Context.Pass("elements/connector/block-001", "AddConnector", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IConnector>().Count() == 1, "AccessConnector: semantic check 1 failed.");
        });
        Context.Pass("elements/connector/block-002", "AccessConnector", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IConnector>().Any(), "RemoveConnector: semantic check 1 failed.");
        });
        Context.Pass("elements/connector/block-003", "RemoveConnector", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IConnector>().Single().StartShapeConnectedTo != null && p.Slides[0].Shapes.OfType<IConnector>().Single().EndShapeConnectedTo != null, "ReconnectShapes: semantic check 1 failed.");
        });
        Context.Pass("elements/connector/block-004", "ReconnectShapes", "save-reopen-structure");
    }
}
