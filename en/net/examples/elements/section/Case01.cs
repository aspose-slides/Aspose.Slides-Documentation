using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Specify the slide that marks the beginning of the section.
        presentation.Sections.AddSection("New Section", slide);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Sections.Count == 1 && p.Sections[0].Name == "New Section", "AddSection: semantic check 1 failed.");
        });
        Context.Pass("elements/section/block-001", "AddSection", "save-reopen-structure");
    }
}
