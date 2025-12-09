---
title: Convertir presentaciones de PowerPoint en modo folleto en .NET
linktitle: Modo Folleto
type: docs
weight: 150
url: /es/net/convert-powerpoint-in-Handout-mode/
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
description: "Convertir presentaciones en folletos en .NET. Configurar diapositivas por página, conservar notas, exportar a PDF o imágenes con Aspose.Slides, con código de ejemplo en C#. Pruébelo gratis."
---

## **Exportación en modo folleto**

Aspose.Slides proporciona la capacidad de convertir presentaciones a varios formatos, incluida la creación de folletos para imprimir en modo Folleto. Este modo le permite configurar cómo aparecen varias diapositivas en una sola página, lo que lo hace útil para conferencias, seminarios y otros eventos. Puede habilitar este modo estableciendo la propiedad `SlidesLayoutOptions` en las interfaces [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/) y [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/).

Para configurar el modo Folleto, use el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/), que determina cuántas diapositivas se colocan en una sola página y otros parámetros de visualización.

A continuación se muestra un ejemplo de código que convierte una presentación a PDF en modo Folleto.
```c#
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
Tenga en cuenta que la propiedad `SlidesLayoutOptions` está disponible solo para ciertos formatos de salida, como PDF, HTML, TIFF y al renderizar como imágenes.
{{% /alert %}} 

## **Preguntas frecuentes**

**¿Cuál es el número máximo de miniaturas de diapositivas por página en el modo Folleto?**

Aspose.Slides admite [preajustes](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) de hasta 9 miniaturas por página con orden horizontal o vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) y 9 (horizontal/vertical).

**¿Puedo definir una cuadrícula personalizada, como 5 o 8 diapositivas por página?**

No. El número y el orden de las miniaturas están controlados estrictamente por la enumeración [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/); no se admiten diseños arbitrarios.

**¿Puedo incluir diapositivas ocultas en la salida del folleto?**

Sí. Habilite la opción `ShowHiddenSlides` en la configuración de exportación para el formato de destino, como [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).