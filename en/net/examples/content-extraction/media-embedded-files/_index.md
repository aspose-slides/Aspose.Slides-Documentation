---
title: Extract Media and Embedded Files
type: docs
weight: 30
url: /net/examples/content-extraction/media-embedded-files/
description: "Extract embedded audio, video and OLE file data, record SHA-256 hashes, and list external media links without opening them."
---

Extract embedded audio, video and OLE file data, record SHA-256 hashes, and list external media links without opening them.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `output/` in the current working directory.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        Directory.CreateDirectory("output");
        ExtractMedia();
    }

    private sealed record Payload(int Slide, string Shape, string Kind, string File, string Sha256);
    private sealed record ExternalLink(int Slide, string Shape, string Url);
    private static string Extension(string contentType) => contentType.ToLowerInvariant() switch
    {
        "audio/wav" or "audio/x-wav" => "wav",
        "audio/mpeg" => "mp3",
        "video/avi" or "video/x-msvideo" or "video/msvideo" => "avi",
        "video/mp4" => "mp4",
        _ => "bin"
    };
    private static string SafeExtension(string extension)
    {
        string clean = extension.TrimStart('.');
        return clean.Length > 0 && clean.Length <= 12 && clean.All(char.IsLetterOrDigit) ? clean.ToLowerInvariant() : "bin";
    }

    private static void ExtractMedia()
    {
        CreateInput();
        using var input = new Presentation("output/input.pptx");
        string outputDirectory = Directory.CreateDirectory("output/extracted").FullName;
        var rows = new List<Payload>();
        var links = new List<ExternalLink>();
        void Save(int slide, IShape shape, string kind, string extension, byte[] data)
        {
            string hash = Hash(data);
            string filename = $"{kind}-{hash}.{SafeExtension(extension)}";
            string? outputPath = SafeOutput(outputDirectory, filename);
            if (outputPath is null)
                return;
            File.WriteAllBytes(outputPath, data);
            rows.Add(new Payload(slide, shape.Name, kind, "extracted/" + filename, hash));
        }

        for (int i = 0; i < input.Slides.Count; i++)
        {
            foreach (var shape in Walk(input.Slides[i].Shapes))
            {
                switch (shape)
                {
                    case IAudioFrame audioFrame:
                        if (audioFrame.EmbeddedAudio is { } embeddedAudio)
                            Save(i + 1, shape, "audio", Extension(embeddedAudio.ContentType), embeddedAudio.BinaryData);
                        else
                            links.Add(new ExternalLink(i + 1, shape.Name, audioFrame.LinkPathLong));
                        break;
                    case IVideoFrame videoFrame:
                        if (videoFrame.EmbeddedVideo is { } embeddedVideo)
                            Save(i + 1, shape, "video", Extension(embeddedVideo.ContentType), embeddedVideo.BinaryData);
                        else
                            links.Add(new ExternalLink(i + 1, shape.Name, videoFrame.LinkPathLong));
                        break;
                    case IOleObjectFrame embeddedObject:
                        if (embeddedObject.IsObjectLink)
                            links.Add(new ExternalLink(i + 1, shape.Name, embeddedObject.LinkPathLong));
                        else
                            Save(i + 1, shape, "ole", embeddedObject.EmbeddedData.EmbeddedFileExtension, embeddedObject.EmbeddedData.EmbeddedFileData);
                        break;
                }
            }
        }

        Json("output/manifest.json", new { payloads = rows, external_links = links });
        Console.WriteLine("Results: " + Path.GetFullPath("output"));
    }

    private static void CreateInput()
    {

        // Original fixtures: 0.1-second silent PCM WAV, one 8x8 RGB AVI frame, and UTF-8 text.
        byte[] silentWav = CreateSilentWav();
        byte[] grayAvi = Convert.FromBase64String("UklGRqABAABBVkkgTElTVMAAAABoZHJsYXZpaDgAAABAQg8AwAAAAAAAAAAQAAAAAQAAAAAAAAABAAAAwAAAAAgAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAExJU1R0AAAAc3RybHN0cmg4AAAAdmlkc0RJQiAAAAAAAAAAAAAAAAABAAAAAQAAAAAAAAABAAAAwAAAAP////8AAAAAAAAAAAgACABzdHJmKAAAACgAAAAIAAAACAAAAAEAGAAAAAAAwAAAAAAAAAAAAAAAAAAAAAAAAABMSVNUzAAAAG1vdmkwMGRiwAAAAFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUA==");
        byte[] note = Encoding.UTF8.GetBytes("Original embedded note â€“ no executable content.\n");
        using var presentation = new Presentation();
        var shapes = presentation.Slides[0].Shapes;
        using var audioStream = new MemoryStream(silentWav);
        shapes.AddAudioFrameEmbedded(20, 20, 60, 60, audioStream).Name = "../audio";
        var video = presentation.Videos.AddVideo(grayAvi);
        shapes.AddVideoFrame(100, 20, 100, 80, video).Name = "Video";
        var data = new OleEmbeddedDataInfo(note, "txt");
        shapes.AddOleObjectFrame(220, 20, 80, 80, data).Name = "../note";
        shapes.AddVideoFrame(320, 20, 100, 80, "https://example.invalid/unfetched.mp4").Name = "Linked video";
        shapes.AddAudioFrameLinked(430, 20, 60, 60, "https://example.invalid/unfetched.wav").Name = "Linked audio";
        presentation.Save("output/input.pptx", SaveFormat.Pptx);
    }

    private static byte[] CreateSilentWav()
    {

        // PCM: mono, 8000 samples/second, 16 bits/sample, 800 silent samples.
        byte[] header = Convert.FromBase64String("UklGRmQGAABXQVZFZm10IBAAAAABAAEAQB8AAIA+AAACABAAZGF0YUAGAAA=");
        return header.Concat(new byte[1600]).ToArray();
    }

    private static IEnumerable<IShape> Walk(IShapeCollection shapes)
    {
        foreach (var shape in shapes)
        {
            yield return shape;
            if (shape is IGroupShape group)
            {
                foreach (var child in Walk(group.Shapes))
                    yield return child;
            }
        }
    }

    private static void Json(string path, object value)
    {
        string json = JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json, new UTF8Encoding(false));
    }

    private static string Hash(byte[] data) => Convert.ToHexString(SHA256.HashData(data)).ToLowerInvariant();
    private static string? SafeOutput(string folder, string filename)
    {
        string root = Path.GetFullPath(folder) + Path.DirectorySeparatorChar;
        string path = Path.GetFullPath(Path.Combine(folder, filename));
        if (!path.StartsWith(root, StringComparison.OrdinalIgnoreCase))
        {
            Console.Error.WriteLine("Output filename must stay inside its directory.");
            return null;
        }

        return path;
    }
}
```

## **Expected result and checks**

`output/manifest.json` maps embedded WAV, AVI and text payloads to content-hash filenames under `output/extracted`. It lists linked audio/video URLs without fetching them. Shape names such as `../audio` never become file paths. Unknown media types use `.bin`.

The downloaded project writes its verification checks to `output/result.json`. The following values describe the ZIP’s checks; the copied program does not write this report:

```json
{
  "embedded_payloads": 3,
  "external_links": 2,
  "payload_hashes_checked": true,
  "path_escape_rejected": true,
  "no_external_fetch": true,
  "no_payload_execution": true
}
```

The sample creates original synthetic WAV, uncompressed AVI and text payloads. It uses generated content-based filenames inside a checked output directory. It never executes extracted files or downloads external links. Shape names are metadata only, even when they contain path separators. Codec playback is outside this extraction example.

## **Learn more**

- [Manage Audio Frames in Presentations in .NET](/slides/net/audio-frame/)
- [Manage Video Frames in Presentations in .NET](/slides/net/video-frame/)
- [Manage OLE Objects in Presentations in .NET](/slides/net/manage-ole/)


## **Open and run the complete project**

[Download the complete project](example.zip), extract it and open `Example.sln`, or run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release -- --mode evaluation
```

Use the current supported .NET 10 SDK/runtime. The project keeps a stable `net8.0`
target and accepts compatible stable SDKs; no exact SDK patch is required.
Evaluation runs without a license and explicitly ignores license environment settings.
It uses bounded fixtures and checks valid output while allowing the evaluation watermark
and documented read-back text truncation. For unrestricted checks, use `--mode licensed`
with your authorized `ASPOSE_LICENSE_PATH`. No license is included.

Inputs are copied from `Fixtures` into a separate output workspace. The program prints
the absolute output path; `execution.json` records the actual runtime and verified action.
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
