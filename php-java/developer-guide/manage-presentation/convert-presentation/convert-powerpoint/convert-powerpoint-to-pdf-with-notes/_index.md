---
title: Convert PowerPoint to PDF Notes
type: docs
weight: 50
url: /php-java/convert-powerpoint-to-pdf-with-notes/
keywords: "convert powerpoint to pdf with notes in java"
description: "Convert PowerPoint to PDF with notes "
---

## **Convert PowerPoint to PDF with Custom Slide Size**
The following example shows how to convert a presentation to a PDF notes document with custom slide size. Where each inch equals 72.

```php
// Instantiate a Presentation object that represents a presentation file
  $presIn = new Presentation("SelectedSlides.pptx");
  $presOut = new Presentation();
  try {
    $slide = $presIn->getSlides()->get_Item(0);
    $presOut->getSlides()->insertClone(0, $slide);
    // Setting Slide Type and Size
    $presOut->getSlideSize()->setSize(612.0, 792.0, SlideSizeScaleType::EnsureFit);
    $pdfOptions = new PdfOptions();
    $pdfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $presOut->save("PDF-SelectedSlide.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($presIn)) {
      $presIn->dispose();
    }
    if (!java_is_null($presOut)) {
      $presOut->dispose();
    }
  }
```

## **Convert PowerPoint to PDF in Notes Slide View**
The [**Save**](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation#save-java.lang.String-int-) method exposed by [**Presentation**](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class can be used to convert the whole presentation in Notes Slide view to PDF. The code snippets below update the sample presentation to PDF in Notes Slide view.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $pres->save($resourcesOutputPath . "PDF-Notes.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

You may to want to check out Aspose [PowerPoint to PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) or [PPT to PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) converter. 

{{% /alert %}}