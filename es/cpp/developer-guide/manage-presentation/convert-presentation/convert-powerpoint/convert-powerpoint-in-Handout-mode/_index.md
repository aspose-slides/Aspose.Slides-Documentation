---
title: Convertir presentaciones de PowerPoint en modo Handout usando C++
linktitle: Modo Handout
type: docs
weight: 150
url: /es/cpp/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir presentación
- modo handout
- folleto
- PPT
- PPTX
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Convertir presentaciones a folletos en C++. Establecer diapositivas por página, mantener notas, exportar a PDF o imágenes con Aspose.Slides, con código de ejemplo. Pruébalo gratis."
---
## **Introducción**

Aspose.Slides ofrece la capacidad de convertir presentaciones a varios formatos, incluido la creación de folletos para imprimir en modo Handout. Este modo permite configurar cómo aparecen varias diapositivas en una sola página, lo que resulta útil para conferencias, seminarios y otros eventos. Puedes habilitar este modo llamando al método `set_SlidesLayoutOptions` en las interfaces [IPdfOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/ihtmloptions/) y [ITiffOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/itiffoptions/).

Para establecer las dimensiones y la orientación de la página del folleto antes de la exportación, consulta [Tamaño de página de notas](/slides/es/cpp/notes-size/).

## **Exportación en modo Handout**

Para configurar el modo Handout, utiliza el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/handoutlayoutingoptions/), que determina cuántas diapositivas se colocan en una sola página y otros parámetros de visualización.

A continuación se muestra un ejemplo de código que convierte una presentación a PDF en modo Handout.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Cargar una presentación.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 diapositivas en una página horizontalmente
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // imprimir números de diapositiva
slidesLayoutOptions->set_PrintFrameSlide(true);                      // imprimir un marco alrededor de las diapositivas
slidesLayoutOptions->set_PrintComments(false);                       // sin comentarios

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Ten en cuenta que el método `set_SlidesLayoutOptions` solo está disponible para ciertos formatos de salida, como PDF, HTML, TIFF y al renderizar como imágenes.
{{% /alert %}} 

## **Preguntas frecuentes**

### ¿Cuál es el número máximo de miniaturas de diapositivas por página en modo Handout?

Aspose.Slides admite [presets](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/handouttype/) de hasta 9 miniaturas por página con ordenación horizontal o vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) y 9 (horizontal/vertical).

### ¿Puedo definir una cuadrícula personalizada, como 5 u 8 diapositivas por página?

No. El número y el orden de las miniaturas están controlados estrictamente por la enumeración [HandoutType](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/handouttype/); no se admiten diseños arbitrarios.

### ¿Puedo incluir diapositivas ocultas en la salida Handout?

Sí. Utiliza el método `set_ShowHiddenSlides` en la configuración de exportación para el formato de destino, como [PdfOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/).