using Aspose.Slides.Export;
using Aspose.Slides;
using System.Drawing;
using System.IO;
using System.Linq;
using System;

internal static partial class Program
{
    private static void VerifyCase01(Presentation presentation)
    {
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame.Text == "Text" && s.FillFormat.FillType == FillType.NoFill), "AddTextBox: semantic check 1 failed.");
        });
        Context.Pass("elements/text-box/block-001", "AddTextBox", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Count(s => s.Name == "DemoText" && s.TextFrame.Text == "Slide") == 1, "AccessTextBox: semantic check 1 failed.");
        });
        Context.Pass("elements/text-box/block-002", "AccessTextBox", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.Any(s => s.Name == "DemoText"), "RemoveTextBox: semantic check 1 failed.");
        });
        Context.Pass("elements/text-box/block-003", "RemoveTextBox", "save-reopen-structure");
    }
}
