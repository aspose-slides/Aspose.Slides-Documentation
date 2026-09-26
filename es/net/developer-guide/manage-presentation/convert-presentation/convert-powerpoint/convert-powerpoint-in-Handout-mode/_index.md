---
title: Convertir presentaciones de PowerPoint en modo Folleto en .NET
linktitle: Modo Folleto
type: docs
weight: 150
url: /es/net/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir presentación
- modo folleto
- folleto
- PowerPoint
- presentación
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Convierta presentaciones a folletos en .NET. Establezca diapositivas por página, conserve las notas, exporte a PDF o imágenes con Aspose.Slides, con código de muestra en C#. Pruébelo gratis."
---
## **Introducción**

Aspose.Slides le permite convertir presentaciones a formatos de salida que admiten el modo Folleto. En este modo, varias diapositivas se organizan en una sola página, lo que resulta útil para imprimir material de presentación para conferencias, seminarios y eventos similares.

El modo Folleto se configura mediante la propiedad `SlidesLayoutOptions`, que está disponible en [IPdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/ihtmloptions/) y [ITiffOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/itiffoptions/). Para definir el diseño del folleto, utilice el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/handoutlayoutingoptions/).

Para establecer las dimensiones y la orientación de la página del folleto antes de la exportación, consulte [Tamaño de página de notas](/slides/es/net/notes-size/).

## **Exportación en modo Folleto**

Para exportar una presentación en modo Folleto, establezca la propiedad `SlidesLayoutOptions` en las opciones de exportación de destino y asigne una instancia de [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/handoutlayoutingoptions/) que define el número de diapositivas por página y los parámetros de visualización relacionados.

A continuación se muestra un ejemplo de código que demuestra cómo convertir una presentación a PDF en modo Folleto.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Cargar una presentación.
using var presentation = new Presentation("sample.pptx");

// Establecer las opciones de exportación.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 diapositivas en una página horizontalmente
        PrintSlideNumbers = true,                   // imprimir números de diapositiva
        PrintFrameSlide = true,                     // imprimir un marco alrededor de las diapositivas
        PrintComments = false                       // sin comentarios
    }
};

// Exportar la presentación a PDF con el diseño elegido.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Tenga en cuenta que la propiedad `SlidesLayoutOptions` está disponible solo para ciertos formatos de salida, como PDF, HTML, TIFF, y al renderizar como imágenes.
{{% /alert %}} 

## **Preguntas frecuentes**

### ¿Cuál es el número máximo de miniaturas de diapositivas por página en modo Folleto?

Aspose.Slides admite [presets](https://reference.aspose.com/slides/es/net/aspose.slides.export/handouttype/) de hasta 9 miniaturas por página con ordenación horizontal o vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) y 9 (horizontal/vertical).

### ¿Puedo definir una cuadrícula personalizada, como 5 o 8 diapositivas por página?

No. El número y orden de las miniaturas está controlado estrictamente por la enumeración [HandoutType](https://reference.aspose.com/slides/es/net/aspose.slides.export/handouttype/); los diseños arbitrarios no son compatibles.

### ¿Puedo incluir diapositivas ocultas en la salida del Folleto?

Sí. Active la opción `ShowHiddenSlides` en la configuración de exportación del formato de destino, como [PdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/tiffoptions/).