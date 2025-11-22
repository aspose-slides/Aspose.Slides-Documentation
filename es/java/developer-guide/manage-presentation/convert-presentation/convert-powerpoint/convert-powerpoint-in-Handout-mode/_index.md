---
title: Convertir presentaciones de PowerPoint en modo Folleto en Java
linktitle: Modo Folleto
type: docs
weight: 150
url: /es/java/convert-powerpoint-in-Handout-mode/
keywords:
- convertir PowerPoint
- convertir presentación
- modo folleto
- folleto
- PPT
- PPTX
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Convertir presentaciones a folletos en Java. Configurar diapositivas por página, conservar notas, exportar a PDF o imágenes con Aspose.Slides, con código de ejemplo en Java. Pruébalo gratis."
---

Aspose.Slides proporciona la capacidad de convertir presentaciones a varios formatos, incluida la creación de folletos para imprimir en modo Handout. Este modo le permite configurar cómo aparecen varias diapositivas en una sola página, lo que resulta útil para conferencias, seminarios y otros eventos. Puede habilitar este modo estableciendo el método `setSlidesLayoutOptions` en las interfaces [IPdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ihtmloptions/) y [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/).

Para configurar el modo Handout, use el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/handoutlayoutingoptions/), que determina cuántas diapositivas se colocan en una sola página y otros parámetros de visualización.

A continuación se muestra un ejemplo de código que muestra cómo convertir una presentación a PDF en modo Handout.
```java
// Cargar una presentación.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Establecer las opciones de exportación.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 diapositivas en una página horizontalmente
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // imprimir números de diapositiva
    slidesLayoutOptions.setPrintFrameSlide(true);                     // imprimir un marco alrededor de las diapositivas
    slidesLayoutOptions.setPrintComments(false);                      // sin comentarios

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Exportar la presentación a PDF con el diseño seleccionado.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```


{{% alert color="warning" %}} 
Tenga en cuenta que el método `setSlidesLayoutOptions` está disponible solo para ciertos formatos de salida, como PDF, HTML, TIFF, y al renderizar como imágenes.
{{% /alert %}}