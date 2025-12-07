---
title: Convertir presentaciones de PowerPoint en modo folleto usando C++
linktitle: Modo folleto
type: docs
weight: 150
url: /es/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- convertir PowerPoint
- convertir presentación
- modo folleto
- folleto
- PPT
- PPTX
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Convertir presentaciones a folletos en C++. Establecer diapositivas por página, conservar notas, exportar a PDF o imágenes con Aspose.Slides, con código de ejemplo. Pruébalo gratis."
---

## **Exportación en modo de folleto**

Aspose.Slides ofrece la capacidad de convertir presentaciones a varios formatos, incluida la creación de folletos para imprimir en modo de folleto. Este modo le permite configurar cómo aparecen varias diapositivas en una sola página, lo que resulta útil para conferencias, seminarios y otros eventos. Puede habilitar este modo estableciendo el método `set_SlidesLayoutOptions` en las interfaces [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/) y [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/).

Para configurar el modo de folleto, utilice el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/), que determina cuántas diapositivas se colocan en una sola página y otros parámetros de visualización.

A continuación se muestra un ejemplo de código que convierte una presentación a PDF en modo de folleto.
```cpp
// Cargar una presentación.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Establecer las opciones de exportación.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 diapositivas en una página horizontalmente
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // imprimir números de diapositiva
slidesLayoutOptions->set_PrintFrameSlide(true);                      // imprimir un marco alrededor de las diapositivas
slidesLayoutOptions->set_PrintComments(false);                       // sin comentarios

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Exportar la presentación a PDF con el diseño elegido.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 
Tenga en cuenta que el método `set_SlidesLayoutOptions` solo está disponible para ciertos formatos de salida, como PDF, HTML, TIFF, y al renderizar como imágenes.
{{% /alert %}} 

## **Preguntas frecuentes**

**¿Cuál es el número máximo de miniaturas de diapositivas por página en el modo de folleto?**

Aspose.Slides admite configuraciones predefinidas de hasta 9 miniaturas por página con ordenamiento horizontal o vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) y 9 (horizontal/vertical).

**¿Puedo definir una cuadrícula personalizada, como 5 o 8 diapositivas por página?**

No. El número y el orden de las miniaturas están controlados estrictamente por la enumeración [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/); no se admiten diseños arbitrarios.

**¿Puedo incluir diapositivas ocultas en la salida del folleto?**

Sí. Utilice el método `set_ShowHiddenSlides` en la configuración de exportación para el formato de destino, como [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).