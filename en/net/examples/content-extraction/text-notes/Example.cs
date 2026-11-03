using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

    public static string Choice(string licensed, string evaluation) => Context.IsLicensed ? licensed : evaluation;
    public static void Require(bool value, string message)
    {
        if (!value)
            throw new InvalidOperationException(message);
    }

    public static void Result(object checks)
    {
        File.WriteAllText("output/result.json", JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true }), new UTF8Encoding(false));
    }

    public static void Json(string path, object value)
    {
        File.WriteAllText(path, JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true }), new UTF8Encoding(false));
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
}
