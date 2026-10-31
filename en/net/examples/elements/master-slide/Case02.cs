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

        // Access the first master slide.
        var firstMasterSlide = presentation.Masters[0];

        // Change the background type.
        firstMasterSlide.Background.Type = BackgroundType.OwnBackground;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Masters[0].Background.Type == BackgroundType.OwnBackground, "AccessMasterSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/master-slide/block-002", "AccessMasterSlide", "save-reopen-structure");
    }
}
