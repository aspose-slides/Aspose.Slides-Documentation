using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static void RunExample()
    {
        Example.Setup();
        byte[] portrait = Example.Png(100, 240, Color.DarkOrange), landscape = Example.Png(260, 100, Color.Teal);
        File.WriteAllBytes("output/portrait.png", portrait);
        File.WriteAllBytes("output/landscape.png", landscape);
        using (var p = new Presentation())
        {
            var image = p.Images.AddImage(Example.Png(100, 100, Color.SlateGray));
            p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 80, 250, 200, image).Name = "Contain";
            p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 350, 80, 250, 200, image).Name = "Crop";
            p.Save("output/template.pptx", SaveFormat.Pptx);
        }

        bool preserved = true;
        foreach (var fixture in new[]
        {
            (Name: "portrait", Bytes: portrait, Width: 100, Height: 240, Color: Color.DarkOrange),
            (Name: "landscape", Bytes: landscape, Width: 260, Height: 100, Color: Color.Teal)
        }

        )
        {
            using var p = new Presentation("output/template.pptx");
            foreach (var target in new[]
            {
                (Name: "Contain", Crop: false),
                (Name: "Crop", Crop: true)
            }

            )
            {
                var frame = Example.Named<IPictureFrame>(p.Slides[0], target.Name);
                var position = (frame.X, frame.Y, frame.Width, frame.Height);
                frame.PictureFormat.Picture.Image = p.Images.AddImage(FittedBitmap(fixture.Width, fixture.Height, fixture.Color, 500, 400, target.Crop));
                preserved &= position == (frame.X, frame.Y, frame.Width, frame.Height);
            }

            p.Save("output/" + fixture.Name + ".pptx", SaveFormat.Pptx);
            Example.Render(p, "output/" + fixture.Name + "-preview.png");
            using var reopened = new Presentation("output/" + fixture.Name + ".pptx");
            foreach (var target in new[]
            {
                (Name: "Contain", X: 40f),
                (Name: "Crop", X: 350f)
            }

            )
            {
                var saved = Example.Named<IPictureFrame>(reopened.Slides[0], target.Name);
                Example.Require((saved.X, saved.Y, saved.Width, saved.Height) == (target.X, 80f, 250f, 200f), "Frame geometry changed: " + target.Name);
            }
        }

        Example.Require(preserved, "Frame geometry changed.");
        Example.Result(new { frame_geometry_preserved = true, portrait_and_landscape_checked = true });
    }

    private static byte[] FittedBitmap(int sourceWidth, int sourceHeight, Color color, int width, int height, bool crop)
    {
        double horizontalScale = (double)width / sourceWidth;
        double verticalScale = (double)height / sourceHeight;
        double scale = crop ? Math.Max(horizontalScale, verticalScale) : Math.Min(horizontalScale, verticalScale);
        double left = (width - sourceWidth * scale) / 2;
        double top = (height - sourceHeight * scale) / 2;
        int stride = (width * 3 + 3) & ~3;
        // A bounded 24-bit BMP writer for our original synthetic pixels, not an image decoder.
        using var stream = new MemoryStream();
        using var writer = new BinaryWriter(stream);
        writer.Write((ushort)0x4D42);
        writer.Write(54 + stride * height);
        writer.Write(0);
        writer.Write(54);
        writer.Write(40);
        writer.Write(width);
        writer.Write(height);
        writer.Write((ushort)1);
        writer.Write((ushort)24);
        writer.Write(0);
        writer.Write(stride * height);
        writer.Write(new byte[16]);
        for (int y = height - 1; y >= 0; y--)
        {
            for (int x = 0; x < width; x++)
            {
                int sourceX = (int)Math.Floor((x - left) / scale);
                int sourceY = (int)Math.Floor((y - top) / scale);
                var pixel = Color.White;
                if (sourceX >= 0 && sourceX < sourceWidth && sourceY >= 0 && sourceY < sourceHeight)
                {
                    double dx = (sourceX - sourceWidth / 2.0) / (sourceWidth / 4.0);
                    double dy = (sourceY - sourceHeight / 2.0) / (sourceHeight / 4.0);
                    pixel = dx * dx + dy * dy <= 1 ? Color.White : color;
                }

                writer.Write(pixel.B);
                writer.Write(pixel.G);
                writer.Write(pixel.R);
            }

            writer.Write(new byte[stride - width * 3]);
        }

        return stream.ToArray();
    }
}
