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

        var section = presentation.Sections.AddSection("Temporary Section", slide);

        // Remove the first section.
        presentation.Sections.RemoveSection(section);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Sections.Count == 0, "RemoveSection: semantic check 1 failed.");
        });
        Context.Pass("elements/section/block-003", "RemoveSection", "save-reopen-structure");
    }
}
