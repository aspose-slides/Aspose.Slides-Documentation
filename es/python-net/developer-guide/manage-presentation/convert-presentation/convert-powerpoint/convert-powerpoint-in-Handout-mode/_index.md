---
title: Convertir presentaciones en modo Handout con Python
linktitle: Modo Handout
type: docs
weight: 150
url: /es/python-net/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir presentación
- modo Handout
- folleto
- PowerPoint
- presentación
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Convertir presentaciones a folletos en Python. Establezca diapositivas por página, conserve notas, exporte a PDF o imágenes con Aspose.Slides, con código de ejemplo. Pruébelo gratis."
---
## **Introducción**

Aspose.Slides ofrece la capacidad de convertir presentaciones a varios formatos, incluida la creación de folletos para imprimir en modo Handout. Este modo le permite configurar cómo aparecen varias diapositivas en una sola página, lo que resulta útil para conferencias, seminarios y otros eventos. Puede activar este modo estableciendo la propiedad `slides_layout_options` en las clases [PdfOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmloptions/) y [TiffOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/tiffoptions/).

Para establecer las dimensiones y la orientación de la página de folleto antes de la exportación, vea [Tamaño de página de notas](/slides/es/python-net/notes-size/).

## **Exportación en modo Handout**

Para configurar el modo Handout, utilice el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/handoutlayoutingoptions/), que determina cuántas diapositivas se colocan en una sola página y otros parámetros de visualización.

A continuación se muestra un ejemplo de código que muestra cómo convertir una presentación a PDF en modo Handout.

```py
import aspose.slides as slides

# Cargar una presentación.
with slides.Presentation("sample.pptx") as presentation:

    # Establecer las opciones de exportación.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 diapositivas en una página horizontalmente
    slides_layout_options.print_slide_numbers = True                                 # imprimir números de diapositiva
    slides_layout_options.print_frame_slide = True                                   # imprimir un marco alrededor de las diapositivas
    slides_layout_options.print_comments = False                                     # sin comentarios

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Exportar la presentación a PDF con el diseño elegido.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
Tenga en cuenta que la propiedad `slides_layout_options` solo está disponible para ciertos formatos de salida, como PDF, HTML, TIFF, y al renderizar como imágenes.
{{% /alert %}} 

## **Preguntas frecuentes**

**¿Cuál es el número máximo de miniaturas de diapositivas por página en modo Handout?**

Aspose.Slides admite [preajustes](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/handouttype/) de hasta 9 miniaturas por página con ordenamiento horizontal o vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) y 9 (horizontal/vertical).

**¿Puedo definir una cuadrícula personalizada, como 5 u 8 diapositivas por página?**

No. El número y el orden de las miniaturas están controlados estrictamente por la enumeración [HandoutType](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/handouttype/); no se admiten diseños arbitrarios.

**¿Puedo incluir diapositivas ocultas en la salida del Handout?**

Sí. Active la opción `show_hidden_slides` en la configuración de exportación para el formato de destino, como [PdfOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/tiffoptions/).