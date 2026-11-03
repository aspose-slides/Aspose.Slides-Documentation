using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static (byte[] Blue, byte[] Orange) CreateInput()
    {
        Example.Setup();
        byte[] blue = Example.Png(120, 80, Color.Blue), orange = Example.Png(80, 120, Color.Orange);
        using (var p = new Presentation())
        {
            var shared = p.Images.AddImage(blue);
            p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 120, 80, shared).Name = "First";
            p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 160, 20, 120, 80, shared).Name = "Duplicate";
            var other = p.Slides.AddEmptySlide(p.LayoutSlides[0]);
            other.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 80, 120, p.Images.AddImage(orange)).Name = "Second image";
            var linked = other.Shapes.AddPictureFrame(ShapeType.Rectangle, 150, 20, 80, 80, shared);
            linked.Name = "External";
            linked.PictureFormat.Picture.LinkPathLong = "https://example.invalid/unfetched.png";
            p.Save("output/input.pptx", SaveFormat.Pptx);
        }

        return (blue, orange);
    }
}
