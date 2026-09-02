---
title: Save Presentations in .NET
linktitle: Save Presentation
type: docs
weight: 80
url: /net/save-presentation/
keywords:
- save PowerPoint
- save OpenDocument
- save presentation
- save slide
- save PPT
- save PPTX
- save ODP
- presentation to file
- presentation to stream
- predefined view type
- Strict Office Open XML Format
- Zip64 mode
- refreshing thumbnail
- saving progress
- .NET
- C#
- Aspose.Slides
description: "Save PowerPoint and OpenDocument presentations to files or streams in C# with Aspose.Slides for .NET, and configure PPTX output and progress reporting."
---

## **Overview**

After you create a presentation or [open an existing one](/slides/net/open-presentation/), use the [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method to write the result. Aspose.Slides for .NET can save a presentation to a file or stream in PowerPoint, OpenDocument, PDF, and other formats. The following sections cover the standard save operations and the options available for PPTX output.

## **Save Presentations to Files**

To save a presentation to a file, pass the output path and a [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) value to the [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method. The format value determines the type of file that Aspose.Slides creates.

The following example creates a presentation and saves it as a PPTX file:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Save Presentations in Their Original Format**

In a batch-processing application, the input format may not be known in advance. After loading a file, read its original format from the [IPresentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/sourceformat/) property. Pass the resulting [SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/sourceformat/) value to [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/tosaveformat/) to obtain the corresponding [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) value, and then use [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) to write the modified presentation.

The following complete example processes every file in an input directory, updates its title, and saves it to an output directory in the format from which it was loaded:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/tosaveformat/) maps PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, and PowerPoint XML to their corresponding presentation save formats. It maps presentation source formats only; it is not intended to select export formats such as PDF, HTML, TIFF, or images. Passing an unsupported or invalid [SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/sourceformat/) value results in an [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

Legacy PPT, PPS, and POT files use the same binary container. When such a presentation is loaded from a stream without a file extension, a PPS or POT file may therefore be identified as PPT. If preserving these legacy subtypes is required, retain the original filename or format metadata separately and use it when choosing the output filename and format.

## **Save Presentations to Streams**

To write a presentation without relying on a final file path, pass a writable [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) and a [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) value to the [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method. This approach is useful when the output must be returned from a web service, stored in a database, or processed in memory.

The following example saves a new presentation to a file stream:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Save Presentations with a Predefined View Type**

You can specify the view in which PowerPoint initially opens a saved presentation. Set the [ViewProperties.LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) property to a [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) value before saving.

The following example configures Slide Master view as the initial view:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Save Presentations in the Strict Office Open XML Format**

To create a PPTX file that conforms to the Strict profile of Office Open XML, create a [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) instance and set its [Conformance](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/conformance/) property to `Conformance.Iso29500_2008_Strict`. Then pass the options to the [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Save Presentations in Office Open XML Format in Zip64 Mode**

A standard ZIP archive limits the compressed and uncompressed size of each entry, the total archive size, and the number of entries. Because a PPTX file is a ZIP archive, a very large presentation can exceed those limits. ZIP64 extensions raise the applicable size and entry-count limits.

Use the [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/zip64mode/) property to control whether Aspose.Slides writes ZIP64 extensions:

- `IfNecessary` uses ZIP64 only when the presentation exceeds standard ZIP limits. This is the default mode.
- `Never` disables ZIP64 extensions.
- `Always` always writes ZIP64 extensions.

The following example always enables ZIP64 extensions for the output presentation:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}

If `Zip64Mode` is set to `Never` and the presentation cannot fit within standard ZIP limits, the save operation throws a [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/).

{{% /alert %}}

## **Save Presentations in Office Open XML Format with Compression Levels**

For PPTX output, you can balance saving speed against file size by setting the [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/compressionlevel/) property. The [CompressionLevel](https://reference.aspose.com/slides/net/aspose.slides.export/compressionlevel/) enumeration provides these values:

- `None` stores data without compression.
- `Level1` provides the fastest compression and the largest compressed output.
- `Level2` through `Level5` progressively favor smaller output over saving speed.
- `Level6` balances saving speed and file size. This is the default level.
- `Level7` and `Level8` further favor smaller output over saving speed.
- `Level9` provides the strongest compression and requires the most processing time.

The following example saves a presentation without compression:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

The following example uses the maximum compression level:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Save Presentations without Refreshing the Thumbnail**

When a presentation is saved as PPTX, the [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/refreshthumbnail/) property controls its document thumbnail:

- `true` regenerates the thumbnail during the save operation. This is the default value.
- `false` preserves the existing thumbnail. If the presentation has no thumbnail, Aspose.Slides does not generate one.

The following example saves a presentation without refreshing its thumbnail:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}

Disabling thumbnail refresh can reduce the time required to save a PPTX file.

{{% /alert %}}

## **Save Progress Updates in Percentage**

To monitor a save operation, implement the [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) interface and assign the implementation to the [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/progresscallback/) property. Aspose.Slides then calls the [IProgressCallback.Reporting](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/reporting/) method with progress values during the export.

The following example reports the progress of a PDF export to the console:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}

Aspose provides a free [PowerPoint Splitter](https://products.aspose.app/slides/splitter) built with the Aspose.Slides API. It saves selected slides from a presentation as separate PPT or PPTX files.

{{% /alert %}}

## **FAQ**

**Does Aspose.Slides support incremental or “fast save”?**

No. Each save operation writes a complete output file rather than updating only the changed parts.

**Can multiple threads save the same Presentation instance?**

No. A [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) instance [is not thread-safe](/slides/net/multithreading/). Access and save each instance from only one thread at a time.

**What happens to hyperlinks and externally linked files when I save a presentation?**

[Hyperlinks](/slides/net/manage-hyperlinks/) remain in the presentation. Aspose.Slides does not copy externally linked files, so the saved presentation must still be able to access their locations.

**Can I save document metadata such as the author, title, company, and creation date?**

Yes. Set the appropriate [document properties](/slides/net/presentation-properties/) before saving, and Aspose.Slides writes them to the output file.
