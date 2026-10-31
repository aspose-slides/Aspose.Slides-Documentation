using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(Seed("control"));
        var slide = presentation.Slides[0];

        // Access the first ActiveX control.
        var control = slide.Controls.FirstOrDefault();
        if (control != null)
        {
            Console.WriteLine($"Control Name: {control.Name}");
            Console.WriteLine($"Value: {control.Properties["Value"]}");
        }

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Controls.Count == 1 && p.Slides[0].Controls[0].Properties["Value"] == "Text", "AccessActiveX: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/activex/block-002", "AccessActiveX", "save-reopen-structure");
    }
}
