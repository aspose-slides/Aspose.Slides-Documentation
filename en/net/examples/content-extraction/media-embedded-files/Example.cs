using System;
using System.Collections.Generic;
using System.IO;
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

    public static void Json(string path, object value)
    {
        File.WriteAllText(path, JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true }), new UTF8Encoding(false));
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

    public static string SafeOutput(string folder, string filename)
    {
        string root = Path.GetFullPath(folder) + Path.DirectorySeparatorChar;
        string path = Path.GetFullPath(Path.Combine(folder, filename));
        if (!path.StartsWith(root, StringComparison.OrdinalIgnoreCase))
            throw new InvalidDataException("Output escapes its directory.");
        return path;
    }

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
