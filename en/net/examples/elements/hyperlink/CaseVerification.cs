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
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame?.Paragraphs.Any(q => q.Portions.Any(t => t.PortionFormat.HyperlinkClick?.ExternalUrl == "https://www.aspose.com")) == true), "AddHyperlink: semantic check 1 failed.");
        });
        Context.Pass("elements/hyperlink/block-001", "AddHyperlink", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame?.Paragraphs.Any(q => q.Portions.Any(t => t.PortionFormat.HyperlinkClick?.ExternalUrl == "https://www.aspose.com")) == true), "AccessHyperlink: semantic check 1 failed.");
        });
        Context.Pass("elements/hyperlink/block-002", "AccessHyperlink", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame?.Paragraphs.Any(q => q.Portions.Any(t => t.PortionFormat.HyperlinkClick != null)) == true), "RemoveHyperlink: semantic check 1 failed.");
        });
        Context.Pass("elements/hyperlink/block-003", "RemoveHyperlink", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame?.Paragraphs.Any(q => q.Portions.Any(t => t.PortionFormat.HyperlinkClick?.ExternalUrl == "https://new.example.com")) == true), "UpdateHyperlink: semantic check 1 failed.");
        });
        Context.Pass("elements/hyperlink/block-004", "UpdateHyperlink", "save-reopen-structure");
    }
}
