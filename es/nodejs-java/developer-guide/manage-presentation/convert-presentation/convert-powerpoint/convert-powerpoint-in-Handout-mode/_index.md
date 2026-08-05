---
title: Convertir presentaciones de PowerPoint en modo Folleto usando JavaScript
linktitle: Modo Folleto
type: docs
weight: 150
url: /es/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir presentación
- modo folleto
- folleto
- PPT
- PPTX
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir presentaciones en folletos. Establezca diapositivas por página, mantenga notas, exporte a PDF o imágenes con Aspose.Slides para Node.js, con código de ejemplo. Pruébelo gratis."
---
## **Introducción**

Aspose.Slides ofrece la capacidad de convertir presentaciones a varios formatos, incluida la creación de folletos para imprimir en modo Handout. Este modo le permite configurar cómo aparecen varias diapositivas en una sola página, lo que resulta útil para conferencias, seminarios y otros eventos. Puede activar este modo estableciendo el método `setSlidesLayoutOptions` en las clases [PdfOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmloptions/) y [TiffOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tiffoptions/).

## **Exportación en modo Handout**

Para configurar el modo Handout, utilice el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/handoutlayoutingoptions/), que determina cuántas diapositivas se colocan en una sola página y otros parámetros de visualización.

A continuación se muestra un ejemplo de código que demuestra cómo convertir una presentación a PDF en modo Handout.

```js
// Cargar una presentación.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 diapositivas en una página horizontalmente
slidesLayoutOptions.setPrintSlideNumbers(true);                                // imprimir números de diapositiva
slidesLayoutOptions.setPrintFrameSlide(true);                                  // imprimir un marco alrededor de las diapositivas
slidesLayoutOptions.setPrintComments(false);                                   // sin comentarios

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Tenga en cuenta que el método `setSlidesLayoutOptions` está disponible solo para ciertos formatos de salida, como PDF, HTML, TIFF y al renderizar como imágenes.
{{% /alert %}} 

## **Preguntas frecuentes**

**¿Cuál es el número máximo de miniaturas de diapositiva por página en modo Handout?**

Aspose.Slides admite [preajustes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/handouttype/) hasta 9 miniaturas por página con ordenamiento horizontal o vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) y 9 (horizontal/vertical).

**¿Puedo definir una cuadrícula personalizada, como 5 u 8 diapositivas por página?**

No. El número y el orden de las miniaturas están controlados estrictamente por la enumeración [HandoutType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/handouttype/); no se admiten disposiciones arbitrarias.

**¿Puedo incluir diapositivas ocultas en la salida Handout?**

Sí. Utilice el método `setShowHiddenSlides` en la configuración de exportación del formato de destino, como [PdfOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tiffoptions/).