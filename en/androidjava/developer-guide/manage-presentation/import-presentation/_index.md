---
title: Import Presentations from PDF or HTML on Android
linktitle: Import Presentation
type: docs
weight: 60
url: /androidjava/import-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Learn how to import PDF and HTML content into PowerPoint presentations on Android with Aspose.Slides for Android via Java and save the results as PPTX files."
---

## **Introduction**

Aspose.Slides for Android via Java can turn PDF pages or HTML content into PowerPoint slides without Microsoft PowerPoint. The [SlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) class provides [addFromPdf](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) and [addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) for appending imported content to a presentation.

For more control over HTML placement, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-boolean-) can insert generated slides at a collection index or begin filling available space on an existing slide. Long HTML is paginated across additional slides automatically, the source can be supplied as a string or stream, and external assets can be loaded through [IExternalResourceResolver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iexternalresourceresolver/) with a base URI. The returned [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) array identifies the affected and newly created slides.

## **Import from PDF**

To convert a PDF document to a PowerPoint presentation, import its content into the slide collection and save the result as a PPTX file.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Create a new [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) object.
2. Call [addFromPdf](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) with the path to the PDF file.
3. Call [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) with [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/#Pptx) to write the presentation to a PPTX file.

The following Java example imports a PDF document and saves the generated slides as a PowerPoint presentation:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().addFromPdf("document.pdf");
    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The [addFromPdf](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) method returns the slides it adds, which is useful when you need to process only the imported slides.

{{% alert title="Tip" color="success" %}}

Try the free [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app to see this conversion workflow in action.

{{% /alert %}}

## **Import from HTML**

Aspose.Slides can also create slides from an HTML document. The source can be supplied as HTML text or a stream. The following steps use a file stream:

1. Create a new [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) object.
2. Open the HTML file for reading and pass the stream to [addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-).
3. Call [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) with [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/#Pptx) to write the result to a PPTX file.

The following Java example imports an HTML document and saves the generated slides as a PowerPoint presentation:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.InputStream;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    try (InputStream htmlStream = Files.newInputStream(Paths.get("page.html"))) {
        presentation.getSlides().addFromHtml(htmlStream);
    }
    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Insert HTML Content**

Use [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-boolean-) when HTML-generated slides must be placed at a specific position instead of appended. The index is zero-based and identifies the position at which the import starts. The method is also available through [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/).

The `useSlideWithIndexAsStart` argument controls how the importer uses that position:

- When it is `false`, the importer creates new slides at the specified index and shifts the slides that follow them.
- When it is `true`, the importer starts placing content in the available space on the existing slide at that index. If the HTML does not fit, Aspose.Slides paginates it automatically and inserts additional slides immediately after the starting slide.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-boolean-) returns an array of [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) objects. When insertion starts on new slides, every returned item is newly created. When an existing slide is used as the start, the array includes that affected slide followed by any new overflow slides. You can inspect this array instead of calculating the affected range from the presentation's slide count.

### **Insert HTML as New Slides**

The following example supplies HTML as a string and inserts the generated slides at collection index `1`. Passing `false` leaves the existing slides unchanged except for shifting them to make room.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    int insertIndex = 1;
    String html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>";
    ISlide[] insertedSlides = presentation.getSlides().insertFromHtml(insertIndex, html, false);

    for (ISlide slide : insertedSlides) {
        System.out.println("Inserted slide index: " + presentation.getSlides().indexOf(slide));
    }

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Start on an Existing Slide**

The next example supplies the HTML through a stream. It keeps a header shape on the existing template slide, starts importing below the occupied area, and lets the long body continue onto new slides.

The HTML also contains a relative image URL. An [IExternalResourceResolver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iexternalresourceresolver/) obtains the resource, while the base URI tells the importer how to resolve `images/logo.png`. In this example, that file is expected at `html-assets/images/logo.png`.

```java
import com.aspose.slides.ExternalResourceResolver;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IExternalResourceResolver;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.nio.charset.StandardCharsets;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide templateSlide = presentation.getSlides().get_Item(0);
    IAutoShape header = templateSlide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60);
    header.getTextFrame().setText("Product roadmap");

    StringBuilder htmlBuilder = new StringBuilder("<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>");
    for (int itemIndex = 1; itemIndex <= 60; itemIndex++) {
        htmlBuilder.append("<p style='font-size:24pt'>Roadmap item ").append(itemIndex).append(": detailed implementation notes.</p>");
    }
    htmlBuilder.append("</body></html>");

    String html = htmlBuilder.toString();
    byte[] htmlData = html.getBytes(StandardCharsets.UTF_8);
    IExternalResourceResolver resolver = new ExternalResourceResolver();
    Path baseDirectory = Paths.get("html-assets").toAbsolutePath();
    String baseUri = baseDirectory.toUri().toString();
    if (!baseUri.endsWith("/")) {
        baseUri += "/";
    }

    try (InputStream htmlStream = new ByteArrayInputStream(htmlData)) {
        ISlide[] affectedSlides = presentation.getSlides().insertFromHtml(0, htmlStream, resolver, baseUri, true);
        for (ISlide slide : affectedSlides) {
            System.out.println("Affected slide index: " + presentation.getSlides().indexOf(slide));
        }
    }

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}

An unrestricted external resource resolver can read local or network resources referenced by the HTML. For untrusted input, implement [IExternalResourceResolver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iexternalresourceresolver/) with an allowlist for permitted schemes, directories, and hosts, and reject all other URIs.

{{% /alert %}}

## **FAQ**

**Can Aspose.Slides detect tables when importing a PDF?**

Yes. Create a [PdfImportOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/) object, call [setDetectTables](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) with `true`, and pass the options to [addFromPdf](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-com.aspose.slides.PdfImportOptions-). The quality of table recognition depends on the structure and complexity of the source PDF.

{{% alert title="Note" color="info" %}}

For details about supported presentation conversion and rendering features on Android, see [Aspose.Slides for Android via Java](https://products.aspose.com/slides/android-java/).

{{% /alert %}}
