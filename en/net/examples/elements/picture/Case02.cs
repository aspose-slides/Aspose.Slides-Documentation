using System.IO;
using System.Linq;
using Aspose.Slides;

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

        VerifyCase02(presentation);
    }
}
