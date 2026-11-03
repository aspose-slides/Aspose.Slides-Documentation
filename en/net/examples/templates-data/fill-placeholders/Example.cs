using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

    public static string ExpectedText(string value) => Context.IsLicensed || value.Length <= 5 ? value : value[..5] + "... text has been truncated due to evaluation version limitation.";
    public static void VerifySavedText(string path, string shapeName, string expected)
    {
        using var zip = System.IO.Compression.ZipFile.OpenRead(path);
        foreach (var entry in zip.Entries.Where(e => e.FullName.StartsWith("ppt/slides/slide", StringComparison.Ordinal) && e.FullName.EndsWith(".xml", StringComparison.Ordinal)))
        {
            using var stream = entry.Open();
            var document = System.Xml.Linq.XDocument.Load(stream);
            foreach (var shape in document.Descendants().Where(e => e.Name.LocalName == "sp"))
            {
                if (!shape.Descendants().Any(e => e.Name.LocalName == "cNvPr" && (string? )e.Attribute("name") == shapeName))
                    continue;
                string stored = string.Concat(shape.Descendants().Where(e => e.Name.LocalName == "t").Select(e => e.Value));
                Require(stored == expected, "Saved XML text differs from the intended transformation.");
                return;
            }
        }

        throw new InvalidDataException("Named saved shape is absent.");
    }

    public static void Require(bool value, string message)
    {
        if (!value)
            throw new InvalidOperationException(message);
    }

    public static string Hash(byte[] data) => Convert.ToHexString(SHA256.HashData(data)).ToLowerInvariant();
    public static string HashFile(string path) => Hash(File.ReadAllBytes(path));
    public static void Result(object checks)
    {
        File.WriteAllText("output/result.json", JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true }), new UTF8Encoding(false));
    }

    public static IAutoShape Text(IShapeCollection shapes, string name, string value, float x = 35, float y = 35, float width = 600, float height = 70)
    {
        var shape = shapes.AddAutoShape(ShapeType.Rectangle, x, y, width, height);
        shape.Name = name;
        shape.TextFrame.Text = value;
        shape.FillFormat.FillType = FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.White;
        foreach (var para in shape.TextFrame.Paragraphs)
            foreach (var portion in para.Portions)
            {
                portion.PortionFormat.LatinFont = new FontData("Noto Sans");
                portion.PortionFormat.FontHeight = 20;
                portion.PortionFormat.FillFormat.FillType = FillType.Solid;
                portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(35, 65, 100);
            }

        return shape;
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

    public static IEnumerable<ITextFrame> Frames(ISlide slide)
    {
        foreach (var shape in Walk(slide.Shapes))
        {
            if (shape is IAutoShape auto)
                yield return auto.TextFrame;
            if (shape is ITable table)
                for (int r = 0; r < table.Rows.Count; r++)
                    for (int c = 0; c < table.Columns.Count; c++)
                        yield return table[c, r].TextFrame;
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
    public static bool Throws(Action action)
    {
        try
        {
            action();
            return false;
        }
        catch (InvalidDataException)
        {
            return true;
        }
    }
}
