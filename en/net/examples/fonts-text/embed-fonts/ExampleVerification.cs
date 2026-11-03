using System.Buffers.Binary;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Aspose.Slides;

internal static partial class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> RunChecked(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context = context;
        context.BeginAction("fonts-text/embed-fonts/block-001");
        EmbedFonts();
        await Task.CompletedTask;
        context.Pass("fonts-text/embed-fonts/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });
    // EOT fields follow https://www.w3.org/submissions/EOT/; this checks actual font bytes, not only a family name.
    private static void ValidateEmbeddedPayload(string path, byte[] sourceFont, bool full)
    {
        using var archive = ZipFile.OpenRead(path);
        var entries = archive.Entries.Where(entry => entry.FullName.StartsWith("ppt/fonts/", StringComparison.Ordinal) && entry.FullName.EndsWith(".fntdata", StringComparison.Ordinal)).ToArray();
        Require(entries.Length == 1, "Expected one real embedded font payload.");
        using var stream = entries[0].Open();
        using var memory = new MemoryStream();
        stream.CopyTo(memory);
        byte[] eot = memory.ToArray();
        Require(eot.Length > 1000 && BinaryPrimitives.ReadUInt32LittleEndian(eot.AsSpan(0, 4)) == eot.Length, "Embedded EOT size is invalid.");
        uint dataSize = BinaryPrimitives.ReadUInt32LittleEndian(eot.AsSpan(4, 4));
        Require(dataSize > 1000 && dataSize < eot.Length && BinaryPrimitives.ReadUInt16LittleEndian(eot.AsSpan(34, 2)) == 0x504c, "Embedded EOT payload/header is invalid.");
        Require(Encoding.Unicode.GetString(eot, 0, (int)(eot.Length - dataSize)).Contains("Noto Sans", StringComparison.Ordinal), "Embedded EOT identifies the wrong family.");
        if (full)
        {
            int tables = BinaryPrimitives.ReadUInt16BigEndian(sourceFont.AsSpan(4, 2));
            int head = Enumerable.Range(0, tables).Select(i => 12 + i * 16).Single(offset => Encoding.ASCII.GetString(sourceFont, offset, 4) == "head");
            int headOffset = (int)BinaryPrimitives.ReadUInt32BigEndian(sourceFont.AsSpan(head + 8, 4));
            uint checksum = BinaryPrimitives.ReadUInt32BigEndian(sourceFont.AsSpan(headOffset + 8, 4));
            Require(BinaryPrimitives.ReadUInt32LittleEndian(eot.AsSpan(60, 4)) == checksum, "Full embedded font checksum differs from the verified source font.");
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
            throw new InvalidOperationException(message);
    }

    private static string Hash(string path) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path))).ToLowerInvariant();
    private static void Report(object checks)
    {
        string json = JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }

    private static void Render(ISlide slide, string output)
    {
        using var image = slide.GetImage(new Size(640, 360));
        image.Save(output, Aspose.Slides.ImageFormat.Png);
    }
}
