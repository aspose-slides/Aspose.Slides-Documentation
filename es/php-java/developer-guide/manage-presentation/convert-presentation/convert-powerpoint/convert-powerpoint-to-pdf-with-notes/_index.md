---
title: Convertir PowerPoint a PDF con Notas
type: docs
weight: 50
url: /php-java/convert-powerpoint-to-pdf-with-notes/
keywords: "convertir powerpoint a pdf con notas en java"
description: "Convertir PowerPoint a PDF con notas"
---

## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**
El siguiente ejemplo muestra cómo convertir una presentación a un documento PDF con notas y un tamaño de diapositiva personalizado. Donde cada pulgada equivale a 72.

```php
// Instanciar un objeto Presentation que representa un archivo de presentación
  $presIn = new Presentation("SelectedSlides.pptx");
  $presOut = new Presentation();
  try {
    $slide = $presIn->getSlides()->get_Item(0);
    $presOut->getSlides()->insertClone(0, $slide);
    # Establecer tipo y tamaño de diapositiva
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

## **Convertir PowerPoint a PDF en Vista de Diapositivas con Notas**
El [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) método expuesto por la clase [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) se puede utilizar para convertir toda la presentación en vista de Diapositivas con Notas a PDF. Los fragmentos de código a continuación actualizan la presentación de muestra a PDF en vista de Diapositivas con Notas.

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

Puede que desee consultar el convertidor de Aspose [PowerPoint a PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) o [PPT a PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}}