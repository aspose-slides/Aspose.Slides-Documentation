---
title: Convertir presentaciones de PowerPoint en modo Handout con PHP
linktitle: Modo Handout
type: docs
weight: 150
url: /es/php-java/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir presentación
- modo Handout
- folleto
- PPT
- PPTX
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Convertir presentaciones a folletos en PHP. Establecer diapositivas por página, conservar notas, exportar a PDF o imágenes con Aspose.Slides para PHP, con código de ejemplo. Pruébalo gratis."
---
## **Introducción**

Aspose.Slides ofrece la capacidad de convertir presentaciones a varios formatos, incluida la creación de folletos para imprimir en modo Handout. Este modo le permite configurar cómo aparecen varias diapositivas en una sola página, lo que resulta útil para conferencias, seminarios y otros eventos. Puede habilitar este modo estableciendo el método `setSlidesLayoutOptions` en las clases [PdfOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/) y [TiffOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/tiffoptions/).

Para establecer las dimensiones y la orientación de la página del folleto antes de la exportación, consulte [Tamaño de la página de notas](/slides/es/php-java/notes-size/).

## **Exportación en modo Handout**

Para configurar el modo Handout, utilice el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/handoutlayoutingoptions/) que determina cuántas diapositivas se colocan en una sola página y otros parámetros de visualización.

A continuación se muestra un ejemplo de código que demuestra cómo convertir una presentación a PDF en modo Handout.

```php
// Cargar una presentación.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 diapositivas en una página horizontalmente
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // imprimir números de diapositiva
$slidesLayoutOptions->setPrintFrameSlide(true);                      // imprimir un marco alrededor de las diapositivas
$slidesLayoutOptions->setPrintComments(false);                       // sin comentarios

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
Tenga en cuenta que el método `setSlidesLayoutOptions` está disponible solo para ciertos formatos de salida, como PDF, HTML, TIFF y al renderizar como imágenes.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es el número máximo de miniaturas de diapositivas por página en el modo Handout?**

Aspose.Slides admite [presets](https://reference.aspose.com/slides/es/php-java/aspose.slides/handouttype/) de hasta 9 miniaturas por página con ordenación horizontal o vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) y 9 (horizontal/vertical).

**¿Puedo definir una cuadrícula personalizada, como 5 o 8 diapositivas por página?**

No. El número y el orden de las miniaturas están controlados estrictamente por la clase [HandoutType](https://reference.aspose.com/slides/es/php-java/aspose.slides/handouttype/); no se admiten disposiciones arbitrarias.

**¿Puedo incluir diapositivas ocultas en la salida del Handout?**

Sí. Habilite las diapositivas ocultas utilizando el método `setShowHiddenSlides` en la configuración de exportación para el formato de destino, como [PdfOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/tiffoptions/).