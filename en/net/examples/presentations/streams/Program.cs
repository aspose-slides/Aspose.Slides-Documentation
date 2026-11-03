using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static void RunExample()
    {
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
                editable.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name.StartsWith("content-", StringComparison.Ordinal)).TextFrame.Text = "Stream output";
                editable.Save(output, SaveFormat.Pptx);
            }
            Require(input.CanRead && output.CanWrite, "Caller-owned streams unexpectedly closed.");
            editedBytes = output.ToArray();
        }
        using (var returnedInput = new MemoryStream(editedBytes))
        using (var afterDisposal = new Presentation(returnedInput))
            Require(Text(afterDisposal.Slides[0]) == Context.ExpectedText("Stream output"), "Returned bytes are not independent.");
        using (var file = File.OpenRead("input.pptx"))
        {
            file.Position = Math.Min(10, file.Length);
            file.Position = 0;
            using (var loaded = new Presentation(file))
                Require(Text(loaded.Slides[0]) == Context.ExpectedText("Stream input"), "File stream did not load correctly.");
            Require(file.CanRead, "The caller must retain ownership of the file stream.");
        }
        File.WriteAllBytes("output.pptx", editedBytes);
        Require(Hash("input.pptx") == originalHash, "Input bytes changed.");
        Report(new { bytes_reopened = true, streams_owned_by_caller = true, position_reset = true, original_unchanged = true });
    }
}
