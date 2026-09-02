---
title: Convert PowerPoint Presentations to XML in PHP
linktitle: PowerPoint to XML
type: docs
weight: 145
url: /php-java/convert-powerpoint-to-xml/
keywords:
- convert PowerPoint to XML
- convert presentation to XML
- PPT to XML
- PPTX to XML
- ODP to XML
- PowerPoint XML Presentation
- SaveFormat.Xml
- save presentation as XML
- export presentation to XML
- XML stream
- PHP
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument presentations to PowerPoint XML files or streams in PHP with Aspose.Slides for PHP via Java."
---

## **Overview**

Aspose.Slides for PHP via Java can convert PowerPoint presentations to the PowerPoint XML Presentation format. XML output is useful when you need a text-based representation for inspecting presentation structure, troubleshooting generated documents, comparing output in automated tests, or integrating with a workflow that consumes XML instead of a presentation package.

Use the [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) method with the `Xml` value from the [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) enumeration. You can write the result directly to a file or to a stream.

{{% alert color="info" title="Note" %}}

`SaveFormat::Xml` creates a PowerPoint XML Presentation. It does not extract the individual Office Open XML parts stored inside a PPTX package. If you need the exact PPTX package parts, such as `ppt/presentation.xml` or individual slide XML files, inspect the PPTX package itself.

{{% /alert %}}

## **Convert a Presentation to an XML File**

Load a source presentation with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class, and then pass the output path and `SaveFormat::Xml` to [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). The source can be any presentation format supported for loading, such as PPT, PPTX, or ODP.

The following example converts a PPTX presentation to an XML file:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **Write the XML Output to a Stream**

Use the stream overload of [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) when the XML must remain in memory or be passed to another component, such as a web service, storage provider, or XML processing pipeline. The following example writes the result to a [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) and obtains the generated XML as a byte array:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Pass $xmlBytes to the next component in the workflow.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

A `ByteArrayOutputStream` stores all generated data in memory, so no position reset is required before calling `toByteArray`.

## **Compare XML with Presentation and Export Formats**

Choose the output format according to how the result will be used:

| Format | Output | Typical use |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | A PowerPoint XML Presentation | Inspecting structure, troubleshooting, comparing generated output, and XML-based integration |
| PPT (`.ppt`) | A legacy binary presentation file | Compatibility with older PowerPoint workflows |
| PPTX (`.pptx`) | An Office Open XML package containing multiple parts | Regular PowerPoint editing and presentation exchange |
| PDF or TIFF | Fixed-layout pages or a multi-page image | Viewing, printing, and archiving |
| PNG, JPEG, or SVG | A rendered representation of an individual slide | Thumbnails, previews, and image assets |
| HTML or HTML5 | Web-oriented presentation output | Browser viewing and web publishing |

Unlike PPT and PPTX, XML output is primarily intended for inspection and data-oriented workflows. Unlike PDF, TIFF, HTML, and slide image formats, it represents presentation data rather than rendering slides as pages or visual assets. The [supported file formats](/slides/php-java/supported-file-formats/) table lists PowerPoint XML Presentation as a save-only format, so do not use it when a workflow must load the exported file back into Aspose.Slides for continued editing.

## **FAQ**

**Is `SaveFormat::Xml` the same as saving a PPTX file?**

No. PPTX is a package containing multiple Office Open XML parts, whereas `SaveFormat::Xml` creates a PowerPoint XML Presentation file.

**Can I save the XML output without creating a file on disk?**

Yes. Pass a writable stream to [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). For example, use a [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) for in-memory processing.

**Can Aspose.Slides load the exported XML file again?**

No. PowerPoint XML Presentation is currently supported for saving but not for loading. Use PPTX or another supported presentation format when round-trip editing is required.

**Does XML conversion render each slide as a page or image?**

No. XML conversion writes structured presentation data. Use PDF or TIFF for page-oriented output, or PNG, JPEG, and SVG for individual slide images.
