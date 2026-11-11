---
title: Convertir presentaciones de PowerPoint en modo Folleto con Java
linktitle: Modo Folleto
type: docs
weight: 150
url: /es/java/convert-powerpoint-in-handout-mode/
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
description: "Convertir presentaciones a folletos en Java. Establezca diapositivas por página, conserve notas, exporte a PDF o imágenes con Aspose.Slides, con código de ejemplo en Java. Pruébelo gratis."
---
## **Introducción**

Aspose.Slides le permite convertir presentaciones a formatos de salida que admiten el modo Folleto. En este modo, varias diapositivas se disponen en una sola página, lo que resulta útil para imprimir material de presentaciones para conferencias, seminarios y eventos similares.

El modo Folleto se configura mediante el método `setSlidesLayoutOptions`, que está disponible en [IPdfOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/ihtmloptions/), y [ITiffOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiffoptions/). Para definir el diseño del folleto, utilice el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/handoutlayoutingoptions/).

Para establecer las dimensiones y la orientación de la página del folleto antes de la exportación, consulte [Notes Page Size](/slides/es/java/notes-size/).

## **Exportación en modo Folleto**

Para exportar una presentación en modo Folleto, configure el método `setSlidesLayoutOptions` en las opciones de exportación de destino y asigne una instancia de [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/handoutlayoutingoptions/) que defina el número de diapositivas por página y los parámetros de visualización relacionados.

A continuación se muestra un ejemplo de código que ilustra cómo convertir una presentación a PDF en modo Folleto.

```java
import com.aspose.slides.*;

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

{{% alert color="warning" title="Warning" %}}
Tenga en cuenta que el método `setSlidesLayoutOptions` solo está disponible para ciertos formatos de salida, como PDF, HTML, TIFF y al renderizar como imágenes.
{{% /alert %}} 

## **Preguntas frecuentes**

**¿Cuál es el número máximo de miniaturas de diapositivas por página en modo Folleto?**

Aspose.Slides admite [presets](https://reference.aspose.com/slides/es/java/com.aspose.slides/handouttype/) de hasta 9 miniaturas por página con ordenación horizontal o vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) y 9 (horizontal/vertical).

**¿Puedo definir una cuadrícula personalizada, como 5 o 8 diapositivas por página?**

No. El número y el orden de las miniaturas están controlados estrictamente por la clase [HandoutType](https://reference.aspose.com/slides/es/java/com.aspose.slides/handouttype/); no se admiten disposiciones arbitrarias.

**¿Puedo incluir diapositivas ocultas en la salida del Folleto?**

Sí. Active las diapositivas ocultas mediante el método `setShowHiddenSlides` en la configuración de exportación del formato de destino, como [PdfOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/htmloptions/), o [TiffOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/tiffoptions/).