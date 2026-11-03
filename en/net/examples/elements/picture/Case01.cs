using System.IO;
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

        VerifyCase01(presentation);
    }
}
