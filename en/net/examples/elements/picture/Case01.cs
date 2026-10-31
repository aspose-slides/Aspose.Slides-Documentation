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

        // Load the small authored PNG into memory without platform-specific drawing.
        using var imageStream = new MemoryStream(File.ReadAllBytes(Context.Input("Picture.png")));

        // Add the image to the presentation.
        var image = presentation.Images.AddImage(imageStream);

        // Insert a picture frame showing the image on the first slide.
        slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
            x: 50, y: 50, width: 40, height: 40, image);

        presentation.Save("picture.pptx", SaveFormat.Pptx);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IPictureFrame>().Single().PictureFormat.Picture.Image.BinaryData.SequenceEqual(File.ReadAllBytes(Context.Input("Picture.png"))), "AddPicture: semantic check 1 failed.");
        });
        Context.Pass("elements/picture/block-001", "AddPicture", "save-reopen-structure");
    }
}
