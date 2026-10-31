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

        presentation.Sections.AddSection("Old Name", slide);

        var section = presentation.Sections[0];
        section.Name = "New Name";

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Sections[0].Name == "New Name", "RenameSection: semantic check 1 failed.");
        });
        Context.Pass("elements/section/block-004", "RenameSection", "save-reopen-structure");
    }
}
