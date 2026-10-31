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

        presentation.Sections.AddSection("My Section", slide);

        // Access a section by index.
        var section = presentation.Sections[0];
        var sectionName = section.Name;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Sections.Count == 1 && p.Sections[0].Name == "My Section", "AccessSection: semantic check 1 failed.");
        });
        Context.Pass("elements/section/block-002", "AccessSection", "save-reopen-structure");
    }
}
