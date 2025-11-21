---
title: Convertir presentaciones en modo Folleto en JavaScript
type: docs
weight: 150
url: /es/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- convertir PowerPoint
- modo folleto
- folleto
- PowerPoint
- PPT
- PPTX
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir presentaciones en modo Folleto en JavaScript"
---

## **Exportación en modo Folleto**

Aspose.Slides proporciona la capacidad de convertir presentaciones a varios formatos, incluida la creación de folletos para imprimir en modo Folleto. Este modo le permite configurar cómo aparecen varias diapositivas en una sola página, lo que resulta útil para conferencias, seminarios y otros eventos. Puede habilitar este modo configurando el método `setSlidesLayoutOptions` en las clases [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/), y [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) .

Para configurar el modo Folleto, utilice el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handoutlayoutingoptions/), que determina cuántas diapositivas se colocan en una sola página y otros parámetros de visualización.

A continuación se muestra un ejemplo de código que convierte una presentación a PDF en modo Folleto.
```js
// Cargar una presentación.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Establecer las opciones de exportación.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 diapositivas en una página horizontalmente
slidesLayoutOptions.setPrintSlideNumbers(true);                                // imprimir números de diapositivas
slidesLayoutOptions.setPrintFrameSlide(true);                                  // imprimir un marco alrededor de las diapositivas
slidesLayoutOptions.setPrintComments(false);                                   // sin comentarios

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Exportar la presentación a PDF con el diseño seleccionado.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```


{{% alert color="warning" %}} 

Tenga en cuenta que el método `setSlidesLayoutOptions` está disponible solo para ciertos formatos de salida, como PDF, HTML, TIFF y al renderizar como imágenes.

{{% /alert %}} 

## **FAQ**

**¿Cuál es el número máximo de miniaturas de diapositivas por página en modo Folleto?**

Aspose.Slides admite [presets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) de hasta 9 miniaturas por página con orden horizontal o vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) y 9 (horizontal/vertical).

**¿Puedo definir una cuadrícula personalizada, como 5 o 8 diapositivas por página?**

No. El número y el orden de las miniaturas están controlados estrictamente por la enumeración [HandoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/); no se admiten diseños arbitrarios.

**¿Puedo incluir diapositivas ocultas en la salida del Folleto?**

Sí. Utilice el método `setShowHiddenSlides` en la configuración de exportación para el formato de destino, como [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/).