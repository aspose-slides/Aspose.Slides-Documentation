---
title: Reduce Presentation Size
type: docs
weight: 10
url: /net/examples/optimization-batch/compression/
description: "Compress an intentionally oversized picture at 96 DPI, save a new presentation and compare file size and representative renders."
---

Compress an intentionally oversized picture at 96 DPI, save a new presentation and compare file size and representative renders.

## Run the example

Download the [complete project](example.zip), extract it, and run it with the .NET 8 SDK.
The project pins Aspose.Slides.NET6.CrossPlatform 26.10.0. The complete project uses portable image fixtures and the CrossPlatform package.
For the complete data assertions, set `ASPOSE_LICENSE_PATH` to your own valid license;
the visible helper loads it when supplied. Evaluation mode may truncate text or add watermarks.

```text
dotnet restore Example.csproj
dotnet run --project Example.csproj --configuration Release --no-restore
```

The download contains [Program.cs](Program.cs), [Example.cs](Example.cs), the project,
dependency lock, and any JSON/CSV input. The helper source contains fixture generation,
license loading, serialization and assertions; it is part of the runnable project.
All presentation inputs are generated from original synthetic data. Results go to `output/`.

## Example

```csharp
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;
using Aspose.Slides.Warnings;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static void CompressPicture()
    {
        CreateInput();
        long before=new FileInfo("output/input.pptx").Length;
        bool compressed;
        using (var presentation = new Presentation("output/input.pptx"))
        {
            var frame = Example.Named<IPictureFrame>(presentation.Slides[0], "Oversized image");
            compressed = frame.PictureFormat.CompressImage(true, PicturesCompression.Dpi96);
            presentation.Save("output/compressed.pptx", SaveFormat.Pptx);
            Example.Render(presentation, "output/after.png");
        }
        VerifyOutput(before, compressed);
    }
}
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "fixture_shrank": true,
  "geometry_preserved": true,
  "render_difference_within_limit": true,
  "reopened": true
}
```

Compression is a quality choice: this fixture is deliberately much larger than its display frame. The result must shrink while its measured mean RGB render difference remains small. Real files may shrink less or not at all. Keep the original when quality requirements may change; the sample reports actual byte counts rather than a universal savings claim.

## Learn more

- [Optimize Image Management in Presentations in .NET](https://docs.aspose.com/slides/net/image/)
- [Save Presentations in .NET](https://docs.aspose.com/slides/net/save-presentation/)


## Open and run the complete project

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
The portable PNG helper creates original synthetic pixels without a Windows bitmap engine.
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
