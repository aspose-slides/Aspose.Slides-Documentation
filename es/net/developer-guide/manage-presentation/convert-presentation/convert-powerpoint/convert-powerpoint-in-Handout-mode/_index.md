---
title: Convertir presentaciones de PowerPoint en modo de folleto en .NET
linktitle: Modo de folleto
type: docs
weight: 150
url: /es/net/convert-powerpoint-in-Handout-mode/
keywords:
- convertir PowerPoint
- convertir presentación
- modo de folleto
- folleto
- PowerPoint
- presentación
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Convertir presentaciones a folletos en .NET. Configurar diapositivas por página, conservar notas, exportar a PDF o imágenes con Aspose.Slides, con código de ejemplo en C#. Prueba gratis."
---

## **Exportación en modo de folleto**

Aspose.Slides ofrece la capacidad de convertir presentaciones a varios formatos, incluida la creación de folletos para imprimir en modo de folleto. Este modo le permite configurar cómo aparecen varias diapositivas en una sola página, lo que resulta útil para conferencias, seminarios y otros eventos. Puede habilitar este modo estableciendo la propiedad `SlidesLayoutOptions` en las interfaces [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/) y [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/).

Para configurar el modo de folleto, use el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/), que determina cuántas diapositivas se colocan en una sola página y otros parámetros de visualización.

A continuación se muestra un ejemplo de código que muestra cómo convertir una presentación a PDF en modo de folleto.
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
Tenga en cuenta que la propiedad `SlidesLayoutOptions` está disponible solo para ciertos formatos de salida, como PDF, HTML, TIFF, y al renderizar como imágenes.
{{% /alert %}} 

## **Preguntas frecuentes**

**¿Cuál es el número máximo de miniaturas de diapositivas por página en modo de folleto?**

Aspose.Slides admite [preajustes](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) de hasta 9 miniaturas por página con ordenación horizontal o vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) y 9 (horizontal/vertical).

**¿Puedo definir una cuadrícula personalizada, como 5 u 8 diapositivas por página?**

No. El número y la ordenación de las miniaturas están controlados estrictamente por la enumeración [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/); no se admiten diseños arbitrarios.

**¿Puedo incluir diapositivas ocultas en la salida del folleto?**

Sí. Habilite la opción `ShowHiddenSlides` en la configuración de exportación para el formato de destino, como [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).