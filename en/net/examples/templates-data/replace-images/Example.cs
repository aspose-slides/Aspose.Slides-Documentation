using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Aspose.Slides;

internal static class Example
{
    public static ExampleContext Context = null!;
    public static void Setup()
    {
        Directory.CreateDirectory("output");
    }

    public static void Require(bool value, string message)
    {
        if (!value)
            throw new InvalidOperationException(message);
    }

    public static void Result(object checks)
    {
        File.WriteAllText("output/result.json", JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true }), new UTF8Encoding(false));
    }

    public static IEnumerable<IShape> Walk(IShapeCollection shapes)
    {
        foreach (IShape shape in shapes)
        {
            yield return shape;
            if (shape is IGroupShape group)
                foreach (var child in Walk(group.Shapes))
                    yield return child;
        }
    }

    public static T Named<T>(ISlide slide, string name)
        where T : class, IShape
    {
        var found = Walk(slide.Shapes).Where(s => s.Name == name).ToArray();
        if (found.Length != 1 || found[0] is not T typed)
            throw new InvalidDataException("Expected one named shape: " + name);
        return typed;
    }

    public static void Render(Presentation p, string path)
    {
        using var image = p.Slides[0].GetImage(new Size(800, 450));
        image.Save(path, Aspose.Slides.ImageFormat.Png);
    }

    public static byte[] Png(int width, int height, Color color) => PortableImage.Png(width, height, color);
}
