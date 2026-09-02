---
title: Save Presentations in PHP
linktitle: Save Presentation
type: docs
weight: 80
url: /php-java/save-presentation/
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
- PHP
- Aspose.Slides
description: "Save PowerPoint and OpenDocument presentations to files or streams in PHP with Aspose.Slides, and configure PPTX output and progress reporting."
---

## **Overview**

After you create a presentation or [open an existing one](/slides/php-java/open-presentation/), use the [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) method to write the result. Aspose.Slides for PHP via Java can save a presentation to a file or stream in PowerPoint, OpenDocument, PDF, and other formats. The following sections cover the standard save operations and the options available for PPTX output.

## **Save Presentations to Files**

To save a presentation to a file, pass the output path and a [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) value to the [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) method. The format value determines the type of file that Aspose.Slides creates.

The following example creates a presentation and saves it as a PPTX file:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Add or modify presentation content here.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Save Presentations in Their Original Format**

In a batch-processing application, the input format may not be known in advance. After loading a file, read its original format from the [Presentation::getSourceFormat](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSourceFormat) method. Pass the resulting [SourceFormat](https://reference.aspose.com/slides/php-java/aspose.slides/sourceformat/) value to [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/#toSaveFormat) to obtain the corresponding [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) value, and then use [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) to write the modified presentation.

The following complete example processes every file in an input directory, updates its title, and saves it to an output directory in the format from which it was loaded:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/#toSaveFormat) maps PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, and PowerPoint XML to their corresponding presentation save formats. It maps presentation source formats only; it is not intended to select export formats such as PDF, HTML, TIFF, or images. Passing an unsupported or invalid [SourceFormat](https://reference.aspose.com/slides/php-java/aspose.slides/sourceformat/) value results in an [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Legacy PPT, PPS, and POT files use the same binary container. When such a presentation is loaded from a stream without a file extension, a PPS or POT file may therefore be identified as PPT. If preserving these legacy subtypes is required, retain the original filename or format metadata separately and use it when choosing the output filename and format.

## **Save Presentations to Streams**

To write a presentation without relying on a final file path, pass a writable stream and a [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) value to the [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) method. This approach is useful when the output must be returned from a web service, stored in a database, or processed in memory.

The following example saves a new presentation to a file stream:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Save Presentations with a Predefined View Type**

You can specify the view in which PowerPoint initially opens a saved presentation. Use the [ViewProperties::setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/#setLastView) method with a [ViewType](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/) value before saving.

The following example configures Slide Master view as the initial view:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Save Presentations in the Strict Office Open XML Format**

To create a PPTX file that conforms to the Strict profile of Office Open XML, create a [PptxOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/) instance and use its [PptxOptions::setConformance](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setConformance) method with [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Then pass the options to the [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) method.

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Save Presentations in Office Open XML Format in Zip64 Mode**

A standard ZIP archive limits the compressed and uncompressed size of each entry, the total archive size, and the number of entries. Because a PPTX file is a ZIP archive, a very large presentation can exceed those limits. ZIP64 extensions raise the applicable size and entry-count limits.

Use the [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setZip64Mode) method to control whether Aspose.Slides writes ZIP64 extensions:

- [IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) uses ZIP64 only when the presentation exceeds standard ZIP limits. This is the default mode.
- [Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) disables ZIP64 extensions.
- [Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) always writes ZIP64 extensions.

The following example always enables ZIP64 extensions for the output presentation:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}

If [Zip64Mode::Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) is used and the presentation cannot fit within standard ZIP limits, the save operation throws a [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/).

{{% /alert %}}

## **Save Presentations in Office Open XML Format with Compression Levels**

For PPTX output, you can balance saving speed against file size by using the [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setCompressionLevel) method. The [CompressionLevel](https://reference.aspose.com/slides/php-java/aspose.slides/compressionlevel/) class provides these values:

- [None](https://reference.aspose.com/slides/php-java/aspose.slides/compressionlevel/#None) stores data without compression.
- [Level1](https://reference.aspose.com/slides/php-java/aspose.slides/compressionlevel/#Level1) provides the fastest compression and the largest compressed output.
- [Level2](https://reference.aspose.com/slides/php-java/aspose.slides/compressionlevel/#Level2) through [Level5](https://reference.aspose.com/slides/php-java/aspose.slides/compressionlevel/#Level5) progressively favor smaller output over saving speed.
- [Level6](https://reference.aspose.com/slides/php-java/aspose.slides/compressionlevel/#Level6) balances saving speed and file size. This is the default level.
- [Level7](https://reference.aspose.com/slides/php-java/aspose.slides/compressionlevel/#Level7) and [Level8](https://reference.aspose.com/slides/php-java/aspose.slides/compressionlevel/#Level8) further favor smaller output over saving speed.
- [Level9](https://reference.aspose.com/slides/php-java/aspose.slides/compressionlevel/#Level9) provides the strongest compression and requires the most processing time.

The following example saves a presentation without compression:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

The following example uses the maximum compression level:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Save Presentations without Refreshing the Thumbnail**

When a presentation is saved as PPTX, the [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) method controls its document thumbnail:

- `true` regenerates the thumbnail during the save operation. This is the default value.
- `false` preserves the existing thumbnail. If the presentation has no thumbnail, Aspose.Slides does not generate one.

The following example saves a presentation without refreshing its thumbnail:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Disabling thumbnail refresh can reduce the time required to save a PPTX file.

{{% /alert %}}

## **Save Progress Updates in Percentage**

To monitor a save operation, provide a Java proxy that implements the [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/) interface and pass the proxy to the [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setProgressCallback) method. Aspose.Slides then calls the [IProgressCallback::reporting](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/#reporting-double-) method with progress values during the export.

The following example reports the progress of a PDF export to the console:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose provides a free [PowerPoint Splitter](https://products.aspose.app/slides/splitter) built with the Aspose.Slides API. It saves selected slides from a presentation as separate PPT or PPTX files.

{{% /alert %}}

## **FAQ**

**Does Aspose.Slides support incremental or “fast save”?**

No. Each save operation writes a complete output file rather than updating only the changed parts.

**Can multiple threads save the same Presentation instance?**

No. A [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) instance [is not thread-safe](/slides/php-java/multithreading/). Access and save each instance from only one thread at a time.

**What happens to hyperlinks and externally linked files when I save a presentation?**

[Hyperlinks](/slides/php-java/manage-hyperlinks/) remain in the presentation. Aspose.Slides does not copy externally linked files, so the saved presentation must still be able to access their locations.

**Can I save document metadata such as the author, title, company, and creation date?**

Yes. Set the appropriate [document properties](/slides/php-java/presentation-properties/) before saving, and Aspose.Slides writes them to the output file.
