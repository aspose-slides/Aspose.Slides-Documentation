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
            Context.Require(p.Slides[0].Shapes.OfType<IPictureFrame>().Single().PictureFormat.Picture.Image.BinaryData.SequenceEqual(File.ReadAllBytes(Context.Input("Picture.png"))), "AddPicture: semantic check 1 failed.");
        });
        Context.Pass("elements/picture/block-001", "AddPicture", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IPictureFrame>().Single().Width == 40 && p.Slides[0].Shapes.OfType<IPictureFrame>().Single().Height == 40, "AccessPicture: semantic check 1 failed.");
        });
        Context.Pass("elements/picture/block-002", "AccessPicture", "save-reopen-structure");
    }
}
