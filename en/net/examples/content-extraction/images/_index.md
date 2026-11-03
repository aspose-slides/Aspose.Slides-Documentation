---
title: Extract Presentation Images
type: docs
weight: 20
url: /net/examples/content-extraction/images/
description: "Extract original embedded picture bytes once per content hash, with references back to the slides and shapes using them."
---

Extract original embedded picture bytes once per content hash, with references back to the slides and shapes using them.

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
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        Directory.CreateDirectory("output");
        ExtractImages();
    }

    private sealed record ImageRef(int Slide, string Shape, string File, string Sha256);
    private static string ImageExtension(string contentType) => contentType.ToLowerInvariant() switch
    {
        "image/png" => ".png",
        "image/jpeg" => ".jpg",
        "image/gif" => ".gif",
        "image/bmp" => ".bmp",
        "image/tiff" => ".tiff",
        "image/svg+xml" => ".svg",
        _ => ".bin"
    };
    private static void ExtractImages()
    {
        CreateInput();
        using var input = new Presentation("output/input.pptx");
        string imageRoot = Directory.CreateDirectory("output/images").FullName;
        var seen = new HashSet<string>();
        var refs = new List<ImageRef>();
        var links = new List<object>();
        for (int i = 0; i < input.Slides.Count; i++)
        {
            int slideNumber = i + 1;
            foreach (var frame in Walk(input.Slides[i].Shapes).OfType<IPictureFrame>())
            {
                var picture = frame.PictureFormat.Picture;
                if (!string.IsNullOrWhiteSpace(picture.LinkPathLong))
                {
                    links.Add(new { slide = slideNumber, shape = frame.Name, url = picture.LinkPathLong });
                    continue;
                }

                byte[] bytes = picture.Image.BinaryData;
                string hash = Hash(bytes);
                string filename = hash + ImageExtension(picture.Image.ContentType);
                string relativePath = "images/" + filename;
                if (seen.Add(hash))
                {
                    string? outputPath = SafeOutput(imageRoot, filename);
                    if (outputPath is null)
                        return;
                    File.WriteAllBytes(outputPath, bytes);
                }

                refs.Add(new ImageRef(slideNumber, frame.Name, relativePath, hash));
            }
        }

        Json("output/images.json", new { images = refs, external_links = links });
        Console.WriteLine("Results: " + Path.GetFullPath("output"));
    }

    private static void CreateInput()
    {

        // Original blue and orange PNG fixtures, including a white ellipse.
        byte[] blue = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAwAAAAICAYAAADN5B7xAAAAI0lEQVR4nGNImfr2PymYgWoaQIAoDdgATg34AHVsIMsPhDAAMPMqpQBAkJ0AAAAASUVORK5CYII=");
        byte[] orange = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAgAAAAMCAYAAABfnvydAAAAJElEQVR4nGP4v5ThPz7MQAMFIIBTATIgXQE2QGUriPIFOQEFAOHGFsu+FDRbAAAAAElFTkSuQmCC");
        using var presentation = new Presentation();
        var shared = presentation.Images.AddImage(blue);
        var firstSlide = presentation.Slides[0];
        firstSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 120, 80, shared).Name = "First";
        firstSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 160, 20, 120, 80, shared).Name = "Duplicate";
        var secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        var secondImage = presentation.Images.AddImage(orange);
        secondSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 80, 120, secondImage).Name = "Second image";
        var linked = secondSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 150, 20, 80, 80, shared);
        linked.Name = "External";
        linked.PictureFormat.Picture.LinkPathLong = "https://example.invalid/unfetched.png";
        presentation.Save("output/input.pptx", SaveFormat.Pptx);
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

`output/images.json` maps three embedded image references to two distinct files under `output/images`. Raw image bytes keep an extension based on their media type, with `.bin` for unknown types. SHA-256 names deduplicate repeated images. The linked image is reported without a request to its URL.

The downloaded project writes its verification checks to `output/result.json`. The following values describe the ZIP’s checks; the copied program does not write this report:

```json
{
  "image_references": 3,
  "unique_images": 2,
  "external_links_reported": 1,
  "original_bytes_checked": true,
  "no_network_fetch": true
}
```

The sample deduplicates bytes rather than filenames. External picture links are reported and are never fetched. This extracts picture-frame resources; rendering a slide is a different operation, and other image uses such as background fills require extending the traversal.

## **Learn more**

- [Extract Images from Presentation Shapes in .NET](/slides/net/extracting-images-from-presentation-shapes/)
- [Optimize Image Management in Presentations in .NET](/slides/net/image/)


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
