---
title: Save Presentations in Java
linktitle: Save Presentation
type: docs
weight: 80
url: /java/save-presentation/
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
- Java
- Aspose.Slides
description: "Save PowerPoint and OpenDocument presentations to files or streams in Java with Aspose.Slides, and configure PPTX output and progress reporting."
---

## **Overview**

After you create a presentation or [open an existing one](/slides/java/open-presentation/), use the [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) method to write the result. Aspose.Slides for Java can save a presentation to a file or stream in PowerPoint, OpenDocument, PDF, and other formats. The following sections cover the standard save operations and the options available for PPTX output.

## **Save Presentations to Files**

To save a presentation to a file, pass the output path and a [SaveFormat](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/) value to the [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) method. The format value determines the type of file that Aspose.Slides creates.

The following example creates a presentation and saves it as a PPTX file:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Add or modify presentation content here.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Save Presentations in Their Original Format**

In a batch-processing application, the input format may not be known in advance. After loading a file, read its original format from the [IPresentation.getSourceFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getSourceFormat--) method. Pass the resulting [SourceFormat](https://reference.aspose.com/slides/java/com.aspose.slides/sourceformat/) value to [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/java/com.aspose.slides/slideutil/#toSaveFormat-int-) to obtain the corresponding [SaveFormat](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/) value, and then use [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) to write the modified presentation.

The following complete example processes every file in an input directory, updates its title, and saves it to an output directory in the format from which it was loaded:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/java/com.aspose.slides/slideutil/#toSaveFormat-int-) maps PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, and PowerPoint XML to their corresponding presentation save formats. It maps presentation source formats only; it is not intended to select export formats such as PDF, HTML, TIFF, or images. Passing an unsupported or invalid [SourceFormat](https://reference.aspose.com/slides/java/com.aspose.slides/sourceformat/) value results in an [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Legacy PPT, PPS, and POT files use the same binary container. When such a presentation is loaded from a stream without a file extension, a PPS or POT file may therefore be identified as PPT. If preserving these legacy subtypes is required, retain the original filename or format metadata separately and use it when choosing the output filename and format.

## **Save Presentations to Streams**

To write a presentation without relying on a final file path, pass a writable stream and a [SaveFormat](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/) value to the [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) method. This approach is useful when the output must be returned from a web service, stored in a database, or processed in memory.

The following example saves a new presentation to a file stream:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Save Presentations with a Predefined View Type**

You can specify the view in which PowerPoint initially opens a saved presentation. Use the [ViewProperties.setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/viewproperties/#setLastView-int-) method with a [ViewType](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/) value before saving.

The following example configures Slide Master view as the initial view:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Save Presentations in the Strict Office Open XML Format**

To create a PPTX file that conforms to the Strict profile of Office Open XML, create a [PptxOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions/) instance and use its [setConformance](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions/#setConformance-int-) method with [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/java/com.aspose.slides/conformance/#Iso29500-2008-Strict). Then pass the options to the [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method.

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Save Presentations in Office Open XML Format in Zip64 Mode**

A standard ZIP archive limits the compressed and uncompressed size of each entry, the total archive size, and the number of entries. Because a PPTX file is a ZIP archive, a very large presentation can exceed those limits. ZIP64 extensions raise the applicable size and entry-count limits.

Use the [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) method to control whether Aspose.Slides writes ZIP64 extensions:

- [IfNecessary](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#IfNecessary) uses ZIP64 only when the presentation exceeds standard ZIP limits. This is the default mode.
- [Never](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Never) disables ZIP64 extensions.
- [Always](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Always) always writes ZIP64 extensions.

The following example always enables ZIP64 extensions for the output presentation:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}

If [Zip64Mode.Never](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Never) is used and the presentation cannot fit within standard ZIP limits, the save operation throws a [PptxException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxexception/).

{{% /alert %}}

## **Save Presentations in Office Open XML Format with Compression Levels**

For PPTX output, you can balance saving speed against file size by using the [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) method. The [CompressionLevel](https://reference.aspose.com/slides/java/com.aspose.slides/compressionlevel/) class provides these values:

- [None](https://reference.aspose.com/slides/java/com.aspose.slides/compressionlevel/#None) stores data without compression.
- [Level1](https://reference.aspose.com/slides/java/com.aspose.slides/compressionlevel/#Level1) provides the fastest compression and the largest compressed output.
- [Level2](https://reference.aspose.com/slides/java/com.aspose.slides/compressionlevel/#Level2) through [Level5](https://reference.aspose.com/slides/java/com.aspose.slides/compressionlevel/#Level5) progressively favor smaller output over saving speed.
- [Level6](https://reference.aspose.com/slides/java/com.aspose.slides/compressionlevel/#Level6) balances saving speed and file size. This is the default level.
- [Level7](https://reference.aspose.com/slides/java/com.aspose.slides/compressionlevel/#Level7) and [Level8](https://reference.aspose.com/slides/java/com.aspose.slides/compressionlevel/#Level8) further favor smaller output over saving speed.
- [Level9](https://reference.aspose.com/slides/java/com.aspose.slides/compressionlevel/#Level9) provides the strongest compression and requires the most processing time.

The following example saves a presentation without compression:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

The following example uses the maximum compression level:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Save Presentations without Refreshing the Thumbnail**

When a presentation is saved as PPTX, the [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) method controls its document thumbnail:

- `true` regenerates the thumbnail during the save operation. This is the default value.
- `false` preserves the existing thumbnail. If the presentation has no thumbnail, Aspose.Slides does not generate one.

The following example saves a presentation without refreshing its thumbnail:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Disabling thumbnail refresh can reduce the time required to save a PPTX file.

{{% /alert %}}

## **Save Progress Updates in Percentage**

To monitor a save operation, implement the [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/) interface and pass the implementation to the [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) method. Aspose.Slides then calls the [IProgressCallback.reporting](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/#reporting-double-) method with progress values during the export.

The following example reports the progress of a PDF export to the console:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose provides a free [PowerPoint Splitter](https://products.aspose.app/slides/splitter) built with the Aspose.Slides API. It saves selected slides from a presentation as separate PPT or PPTX files.

{{% /alert %}}

## **FAQ**

**Does Aspose.Slides support incremental or “fast save”?**

No. Each save operation writes a complete output file rather than updating only the changed parts.

**Can multiple threads save the same Presentation instance?**

No. A [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instance [is not thread-safe](/slides/java/multithreading/). Access and save each instance from only one thread at a time.

**What happens to hyperlinks and externally linked files when I save a presentation?**

[Hyperlinks](/slides/java/manage-hyperlinks/) remain in the presentation. Aspose.Slides does not copy externally linked files, so the saved presentation must still be able to access their locations.

**Can I save document metadata such as the author, title, company, and creation date?**

Yes. Set the appropriate [document properties](/slides/java/presentation-properties/) before saving, and Aspose.Slides writes them to the output file.
