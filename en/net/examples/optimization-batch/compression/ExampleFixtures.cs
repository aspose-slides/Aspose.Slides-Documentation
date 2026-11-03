using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static void CreateInput()
    {
        Example.Setup();
        using (var p = new Presentation())
        {
            Example.Text(p.Slides[0].Shapes, "Title", "Reduce an oversized raster image", 30, 20, 620, 60);
            p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 80, 110, 500, 300, p.Images.AddImage(Example.Png(4000, 2400, Color.Teal))).Name = "Oversized image";
            p.Save("output/input.pptx", SaveFormat.Pptx);
            Example.Render(p, "output/before.png");
        }
    }
}
