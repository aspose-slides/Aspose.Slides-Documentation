---
title: Import Presentations from PDF or HTML in PHP
linktitle: Import Presentation
type: docs
weight: 60
url: /php-java/import-presentation/
keywords:
- import presentation
- import slide
- import PDF
- import HTML
- PDF to presentation
- PDF to PPT
- PDF to PPTX
- PDF to ODP
- HTML to presentation
- HTML to PPT
- HTML to PPTX
- HTML to ODP
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Learn how to import PDF and HTML content into PowerPoint presentations in PHP with Aspose.Slides and save the results as PPTX files."
---

## **Introduction**

Aspose.Slides for PHP via Java can turn PDF pages or HTML content into PowerPoint slides without Microsoft PowerPoint. The [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) class provides [SlideCollection::addFromPdf](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) and [SlideCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) for appending imported content to a presentation.

For more control over HTML placement, [SlideCollection::insertFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) can insert generated slides at a collection index or begin filling available space on an existing slide. Long HTML is paginated across additional slides automatically, the source can be supplied as a string or stream, and external assets can be loaded through [ExternalResourceResolver](https://reference.aspose.com/slides/php-java/aspose.slides/externalresourceresolver/) with a base URI. The returned [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) array identifies the affected and newly created slides.

## **Import from PDF**

To convert a PDF document to a PowerPoint presentation, import its content into the slide collection and save the result as a PPTX file.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Create a new [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) object.
2. Call [SlideCollection::addFromPdf](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) with the path to the PDF file.
3. Call [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) with [SaveFormat::Pptx](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) to write the presentation to a PPTX file.

The following PHP example imports a PDF document and saves the generated slides as a PowerPoint presentation:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlides()->addFromPdf("document.pdf");
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The [SlideCollection::addFromPdf](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) method returns the slides it adds, which is useful when you need to process only the imported slides.

{{% alert title="Tip" color="success" %}}

Try the free [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app to see this conversion workflow in action.

{{% /alert %}}

## **Import from HTML**

Aspose.Slides can also create slides from an HTML document. The source can be supplied as HTML text or a stream. The following steps use a file stream:

1. Create a new [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) object.
2. Open the HTML file for reading and pass the stream to [SlideCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/).
3. Call [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) with [SaveFormat::Pptx](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) to write the result to a PPTX file.

The following PHP example imports an HTML document and saves the generated slides as a PowerPoint presentation:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
        $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
        $htmlStream->close();
    }
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Insert HTML Content**

Use [SlideCollection::insertFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) when HTML-generated slides must be placed at a specific position instead of appended. The index is zero-based and identifies the position at which the import starts.

The `useSlideWithIndexAsStart` argument controls how the importer uses that position:

- When it is `false`, the importer creates new slides at the specified index and shifts the slides that follow them.
- When it is `true`, the importer starts placing content in the available space on the existing slide at that index. If the HTML does not fit, Aspose.Slides paginates it automatically and inserts additional slides immediately after the starting slide.

[SlideCollection::insertFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) returns an array of [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) objects. When insertion starts on new slides, every returned item is newly created. When an existing slide is used as the start, the array includes that affected slide followed by any new overflow slides. You can inspect this array instead of calculating the affected range from the presentation's slide count.

### **Insert HTML as New Slides**

The following example supplies HTML as a string and inserts the generated slides at collection index `1`. Passing `false` leaves the existing slides unchanged except for shifting them to make room.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $insertIndex = 1;
    $html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>";
    $insertedSlides = $presentation->getSlides()->insertFromHtml($insertIndex, $html, false);

    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $insertedSlideCount = java_values($arrayClass->getLength($insertedSlides));
    for ($slideIndex = 0; $slideIndex < $insertedSlideCount; $slideIndex++) {
        $slide = $insertedSlides[$slideIndex];
        echo "Inserted slide index: " . java_values($presentation->getSlides()->indexOf($slide)) . PHP_EOL;
    }

    $presentation->save("presentation-with-inserted-html.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Start on an Existing Slide**

The next example supplies the HTML through a stream. It keeps a header shape on the existing template slide, starts importing below the occupied area, and lets the long body continue onto new slides.

The HTML also contains a relative image URL. An [ExternalResourceResolver](https://reference.aspose.com/slides/php-java/aspose.slides/externalresourceresolver/) obtains the resource, while the base URI tells the importer how to resolve `images/logo.png`. In this example, that file is expected at `html-assets/images/logo.png`.

```php
use aspose\slides\ExternalResourceResolver;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $templateSlide = $presentation->getSlides()->get_Item(0);
    $header = $templateSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 680, 60);
    $header->getTextFrame()->setText("Product roadmap");

    $html = "<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>";
    for ($itemIndex = 1; $itemIndex <= 60; $itemIndex++) {
        $html .= "<p style='font-size:24pt'>Roadmap item " . $itemIndex . ": detailed implementation notes.</p>";
    }
    $html .= "</body></html>";

    $javaHtml = new Java("java.lang.String", $html);
    $htmlData = $javaHtml->getBytes("UTF-8");
    $htmlStream = new Java("java.io.ByteArrayInputStream", $htmlData);
    $resolver = new ExternalResourceResolver();
    $baseDirectory = new Java("java.io.File", "html-assets");
    $baseUri = java_values($baseDirectory->toURI()->toString());

    try {
        $affectedSlides = $presentation->getSlides()->insertFromHtml(0, $htmlStream, $resolver, $baseUri, true);
        $arrayClass = new JavaClass("java.lang.reflect.Array");
        $affectedSlideCount = java_values($arrayClass->getLength($affectedSlides));
        for ($slideIndex = 0; $slideIndex < $affectedSlideCount; $slideIndex++) {
            $slide = $affectedSlides[$slideIndex];
            echo "Affected slide index: " . java_values($presentation->getSlides()->indexOf($slide)) . PHP_EOL;
        }
    } finally {
        $htmlStream->close();
    }

    $presentation->save("presentation-with-html-overflow.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}

An unrestricted external resource resolver can read local or network resources referenced by the HTML. For untrusted input, implement a restricted resolver that allows only permitted schemes, directories, and hosts, and rejects all other URIs.

{{% /alert %}}

## **FAQ**

**Can Aspose.Slides detect tables when importing a PDF?**

Yes. Create a [PdfImportOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfimportoptions/) object, call [PdfImportOptions::setDetectTables](https://reference.aspose.com/slides/php-java/aspose.slides/pdfimportoptions/) with `true`, and pass the options to [SlideCollection::addFromPdf](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/). The quality of table recognition depends on the structure and complexity of the source PDF.

{{% alert title="Note" color="info" %}}

You can also use Aspose.Slides to convert HTML content to other formats:

- [HTML to image](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
- [HTML to JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
- [HTML to XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
- [HTML to TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}
