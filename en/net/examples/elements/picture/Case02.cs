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

        // A valid packaged PNG supplies a deterministic editable picture.
        using var imageStream = new MemoryStream(File.ReadAllBytes(Context.Input("Picture.png")));

        // Add the image to the presentation.
        var image = presentation.Images.AddImage(imageStream);
        slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

        // Access the first picture frame on the slide.
        var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IPictureFrame>().Single().Width == 40 && p.Slides[0].Shapes.OfType<IPictureFrame>().Single().Height == 40, "AccessPicture: semantic check 1 failed.");
        });
        Context.Pass("elements/picture/block-002", "AccessPicture", "save-reopen-structure");
    }
}
