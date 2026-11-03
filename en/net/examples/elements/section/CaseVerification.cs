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
            Context.Require(p.Sections.Count == 1 && p.Sections[0].Name == "New Section", "AddSection: semantic check 1 failed.");
        });
        Context.Pass("elements/section/block-001", "AddSection", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Sections.Count == 1 && p.Sections[0].Name == "My Section", "AccessSection: semantic check 1 failed.");
        });
        Context.Pass("elements/section/block-002", "AccessSection", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Sections.Count == 0, "RemoveSection: semantic check 1 failed.");
        });
        Context.Pass("elements/section/block-003", "RemoveSection", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Sections[0].Name == "New Name", "RenameSection: semantic check 1 failed.");
        });
        Context.Pass("elements/section/block-004", "RenameSection", "save-reopen-structure");
    }
}
