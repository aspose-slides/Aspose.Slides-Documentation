---
title: Determine the Original Presentation Format in .NET
linktitle: Source Format
type: docs
weight: 35
url: /net/detect-presentation-source-format/
keywords:
- source format
- detect presentation format
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Read the original format of a loaded presentation in C# with Aspose.Slides for .NET, compare detection APIs, and handle files, streams, and legacy formats."
---

## **Overview**

After loading a presentation, read the read-only [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) property to determine its original format. The property is also available through [IPresentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/sourceformat/). Use it when subsequent processing depends on the format from which the current instance was loaded.

The source format is distinct from the [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) selected for an output file. Saving to another format does not change the source format of the existing instance.

## **Read the Source Format of a File**

This example requires an existing `sample.pptx` file. It loads the file and selects an application processing policy using [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/), rather than the filename. Change the input path to try other formats. The example prints the selected policy; replace the messages with your application logic.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **Recognize the Supported Values**

The [SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/sourceformat/) enumeration distinguishes the following presentation formats. The extensions below are conventional extensions, not a reconstruction of the original filename.

| SourceFormat value | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 presentation |
| `Pptx` | `.pptx` | Office Open XML presentation |
| `Pptm` | `.pptm` | Macro-enabled Office Open XML presentation |
| `Pps` | `.pps` | PowerPoint 97–2003 slide show |
| `Ppsx` | `.ppsx` | Office Open XML slide show |
| `Ppsm` | `.ppsm` | Macro-enabled Office Open XML slide show |
| `Pot` | `.pot` | PowerPoint 97–2003 template |
| `Potx` | `.potx` | Office Open XML template |
| `Potm` | `.potm` | Macro-enabled Office Open XML template |
| `Odp` | `.odp` | OpenDocument presentation |
| `Otp` | `.otp` | OpenDocument presentation template |
| `Fodp` | `.fodp` | Flat XML ODF presentation |
| `Xml` | `.xml` | PowerPoint XML presentation |

## **Read the Source Format of a Stream**

This example requires an existing `sample.pps` file. Reading its bytes into a memory stream models input received without a filename, such as a database value or an uploaded byte array. The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) constructor receives only the stream.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS, and POT use the same underlying binary format. When loading by file path, the extension can help distinguish a slide show or template. Without a filename, legacy PPS and POT content may be reported as `SourceFormat.Ppt`; the PPS example above reports `Ppt`.

If your application must preserve the distinction, keep the original filename or subtype metadata separately. An extension is a useful hint for these legacy subtypes, but should not be the only basis for identifying arbitrary presentation content.

## **Compare Detection Before and After Loading**

Use [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) and [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/loadformat/) when you need to inspect a file before loading its complete presentation object model. Use [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) when the instance already exists.

This example requires `sample.pptx` and prints `Pptx` for both checks. In production, choose the API appropriate to your processing stage; an already loaded presentation does not need a second inspection solely to obtain its source format.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

The results have different enumeration types: [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/) and [SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/sourceformat/). Do not compare them by casting their numeric values or assume that every format has identical detection results. In the save-and-reopen check described below, PowerPoint XML was reported as `LoadFormat.Unknown` before loading and `SourceFormat.Xml` after loading.

## **Keep Source and Output Formats Separate**

This example requires `sample.pptx` and writes `converted.odp`. It prints `Pptx` both before and after saving the original instance. Only the new instance loaded from the ODP output reports `Odp`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

A presentation created from scratch with `new Presentation()` reports `SourceFormat.Pptx`. It has no input file: this is the default value for a newly created instance, not evidence that a PPTX file was loaded. Track whether your application created or loaded the instance separately if that distinction matters.

## **Map a Source Format to an Extension**

The following example requires `sample.pptx`. It maps every currently supported [SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/sourceformat/) value to a conventional extension, without parsing the input filename. The fallback avoids silently assigning an extension to an unrecognized value.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

This mapping does not convert a file or recover a legacy PPS/POT subtype lost during stream loading. For actual saving, select a [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) explicitly, or use the conversion shown in [Save Presentations in Their Original Format](/slides/net/save-presentation/#save-presentations-in-their-original-format).

## **Verify Formats by Saving and Reopening**

This self-contained example creates a presentation and writes three files in the working directory, overwriting files with the same names. It reopens each output both by path and through a memory stream. For PPTX and ODP, both routes report the saved format. For PPS, loading by path reports `Pps`, while loading the same bytes without a filename reports `Ppt`.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

The same check with all the formats listed above produced these results for generated presentations with matching extensions:

| Saved format | SourceFormat from a file path | SourceFormat from a nameless stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

In these checks, the only source-format normalization was PPS/POT to `Ppt` for nameless streams. The table describes format identification, not preservation of every presentation feature during conversion.

## **FAQ**

**Does saving to ODP change the source format of a presentation loaded from PPTX?**

No. The existing instance still reports `Pptx`. An instance loaded from the saved ODP file reports `Odp`.

**Can a stream always distinguish a legacy presentation, slide show, and template?**

No. PPT, PPS, and POT share the binary format. Keep filename or subtype metadata separately when that distinction is required.

**Which API should I use if the presentation is already loaded?**

Read [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/). Use [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) for inspection before loading.
