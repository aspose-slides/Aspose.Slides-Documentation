using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        ApplyLicense();
        byte[] inputBytes;
        using (var created = new Presentation())
        using (var output = new MemoryStream())
        {
            Label(created.Slides[0], "Stream input");
            created.Save(output, SaveFormat.Pptx);
            inputBytes = output.ToArray(); // Independent bytes survive stream disposal.
        }
        File.WriteAllBytes("input.pptx", inputBytes);
        string originalHash = Hash("input.pptx");
        byte[] editedBytes;
        using (var input = new MemoryStream(inputBytes))
        using (var output = new MemoryStream())
        {
            input.Position = input.Length; // A reused stream need not be positioned at its start.
            input.Position = 0;            // Explicitly reset before passing it to the reader.
            using (var editable = new Presentation(input))
            {
                editable.Slides[0].Shapes.OfType<IAutoShape>().Single().TextFrame.Text = "Stream output";
                editable.Save(output, SaveFormat.Pptx);
            }
            Require(input.CanRead && output.CanWrite, "Caller-owned streams unexpectedly closed.");
            editedBytes = output.ToArray();
        }
        using (var returnedInput = new MemoryStream(editedBytes))
        using (var afterDisposal = new Presentation(returnedInput))
            Require(Text(afterDisposal.Slides[0]) == "Stream output", "Returned bytes are not independent.");
        using (var file = File.OpenRead("input.pptx"))
        {
            file.Position = Math.Min(10, file.Length);
            file.Position = 0;
            using (var loaded = new Presentation(file))
                Require(Text(loaded.Slides[0]) == "Stream input", "File stream did not load correctly.");
            Require(file.CanRead, "The caller must retain ownership of the file stream.");
        }
        File.WriteAllBytes("output.pptx", editedBytes);
        Require(Hash("input.pptx") == originalHash, "Input bytes changed.");
        Report(new { bytes_reopened = true, streams_owned_by_caller = true, position_reset = true, original_unchanged = true });
    }

    private static void ApplyLicense()
    {
        string? path = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        var license = new Aspose.Slides.License();
        if (!string.IsNullOrWhiteSpace(path)) license.SetLicense(path);
        if (!license.IsLicensed())
            throw new InvalidOperationException("Set ASPOSE_LICENSE_PATH to a valid license file for this complete example.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    private static IAutoShape Label(ISlide slide, string text)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 80, 540, 100);
        shape.Name = "content-" + text;
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 28;
        return shape;
    }

    private static string Text(ISlide slide) => string.Join("|", slide.Shapes.OfType<IAutoShape>().Select(s => s.TextFrame.Text));
    private static string Hash(string file) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(file)));
    private static void Report(object checks)
    {
        string json = JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }
}
