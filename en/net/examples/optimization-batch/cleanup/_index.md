---
title: Remove Unused Presentation Resources
type: docs
weight: 20
url: /net/examples/optimization-batch/cleanup/
description: "Remove unused layouts and masters, then remove a nominated unreferenced image part while preserving the retained slide content."
---

Remove unused layouts and masters, then remove a nominated unreferenced image part while preserving the retained slide content.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

The generated input contains an unused master/layout and one deliberately unreferenced PNG part. SDK cleanup and this narrowly guarded package repair are separate operations. The package helper refuses referenced images; it is not a general unused-media detector.

```csharp
using System.Drawing;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System;
using Aspose.Slides.Export;
using Compress = Aspose.Slides.LowCode.Compress;
using Aspose.Slides;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        CreateCleanupInput();
        int mastersBefore;
        int layoutsBefore;
        using (var presentation = new Presentation("example-output/input.pptx"))
        {
            mastersBefore = presentation.Masters.Count;
            layoutsBefore = presentation.LayoutSlides.Count;
            SavePreview(presentation, "example-output/before.png");
            // SDK cleanup removes unused layout and master slides.
            Compress.RemoveUnusedLayoutSlides(presentation);
            Compress.RemoveUnusedMasterSlides(presentation);
            presentation.Save("example-output/cleaned.pptx", SaveFormat.Pptx);
        }

        // Package repair is separate and restricted to the known synthetic orphan.
        if (!RemoveKnownUnreferencedImage("example-output/cleaned.pptx", "ppt/media/orphan.png"))
            return;
        using var reopened = new Presentation("example-output/cleaned.pptx");
        SavePreview(reopened, "example-output/after.png");
        Console.WriteLine($"SDK cleanup: masters {mastersBefore} to {reopened.Masters.Count}; layouts {layoutsBefore} to {reopened.LayoutSlides.Count}");
        Console.WriteLine("Package cleanup: removed the nominated orphan.png.");
        string referencedPart;
        using (var archive = ZipFile.OpenRead("example-output/cleaned.pptx"))
            referencedPart = archive.Entries.Single(part => part.FullName.StartsWith("ppt/media/", StringComparison.Ordinal)).FullName;
        var removedReferencedPart = RemoveKnownUnreferencedImage("example-output/cleaned.pptx", referencedPart);
        Console.WriteLine($"Referenced image deletion refused: {!removedReferencedPart}");
        Console.WriteLine("Output: " + outputDirectory);
    }

    private static void CreateCleanupInput()
    {
        var pngBytes = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAIAAACQkWg2AAAAGUlEQVR4nGNkaGhgIAUwkaR6VMOohiGlAQBBvQEg5hFlkQAAAABJRU5ErkJggg==");
        using (var source = new Presentation())
        using (var unusedMaster = new Presentation())
        {
            var title = source.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 35, 35, 600, 70);
            title.TextFrame.Text = "Keep referenced content";
            source.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, 150, 100, source.Images.AddImage(pngBytes));
            source.Masters.AddClone(unusedMaster.Masters[0]);
            source.Save("example-output/input.pptx", SaveFormat.Pptx);
        }

        // This known fixture part is intentionally not referenced by any relationship.
        using var archive = ZipFile.Open("example-output/input.pptx", ZipArchiveMode.Update);
        using var orphanPart = archive.CreateEntry("ppt/media/orphan.png").Open();
        orphanPart.Write(pngBytes);
    }

    private static bool RemoveKnownUnreferencedImage(string package, string part)
    {
        if (!part.StartsWith("ppt/media/", StringComparison.Ordinal) || !part.EndsWith(".png", StringComparison.Ordinal))
        {
            Console.Error.WriteLine("Only a nominated PNG media part is supported.");
            return false;
        }

        using var zip = ZipFile.Open(package, ZipArchiveMode.Update);
        foreach (var relationPart in zip.Entries.Where(e => e.FullName.EndsWith(".rels", StringComparison.Ordinal)).ToArray())
        {
            string relationshipPartName = relationPart.FullName;
            int split = relationshipPartName.LastIndexOf("/_rels/", StringComparison.Ordinal);
            string owner = relationshipPartName == "_rels/.rels" ? "" : relationshipPartName[..split] + "/" + relationshipPartName[(split + 7)..^5];
            using var stream = relationPart.Open();
            var xml = System.Xml.Linq.XDocument.Load(stream);
            foreach (var relationship in xml.Root!.Elements())
            {
                if ((string?)relationship.Attribute("TargetMode") == "External")
                    continue;
                string? target = (string?)relationship.Attribute("Target");
                if (target == null)
                    continue;
                var absolute = new Uri(new Uri("https://package.invalid/" + owner), target);
                if (absolute.Host == "package.invalid" && Uri.UnescapeDataString(absolute.AbsolutePath.TrimStart('/')) == part)
                {
                    Console.WriteLine("Refusing to remove referenced image part.");
                    return false;
                }
            }
        }

        var entry = zip.GetEntry(part);
        if (entry == null)
        {
            Console.Error.WriteLine("Nominated image part is absent.");
            return false;
        }

        entry.Delete();
        return true;
    }

    private static void SavePreview(Presentation presentation, string path)
    {
        using var image = presentation.Slides[0].GetImage(new Size(640, 360));
        image.Save(path, Aspose.Slides.ImageFormat.Png);
    }
}
```

## **Expected result and checks**

The reopened `cleaned.pptx` and its `after.png` preview retain the visible text and referenced image. The console reports SDK removals, the nominated package removal, and refusal to delete the referenced image. The download additionally compares previews and source bytes.

## **Learn more**

- [Manage Presentation Slide Masters in .NET](/slides/net/slide-master/)
- [Apply or Change Slide Layouts in .NET](/slides/net/slide-layout/)
- [Save Presentations in .NET](/slides/net/save-presentation/)


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
