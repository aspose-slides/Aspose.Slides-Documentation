---
title: Convertir presentaciones de PowerPoint en modo folleto usando Python
linktitle: Modo folleto
type: docs
weight: 150
url: /es/python-java/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir presentación
- modo folleto
- folleto
- PPT
- PPTX
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint a folletos en Python a través de Java. Organizar varias diapositivas por página y exportar a PDF con Aspose.Slides."
---
## **Introducción**

Aspose.Slides for Python via Java le permite exportar presentaciones en modo folleto, disponiendo varias diapositivas en una sola página. Esto es útil para imprimir materiales de presentación para conferencias, seminarios y eventos similares.

Configure el diseño mediante el método [setSlidesLayoutOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Los diseños de folleto son compatibles con [PdfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/), y [TiffOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/tiffoptions/). Utilice un objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/handoutlayoutingoptions/) para especificar la disposición y la configuración de visualización.

## **Exportación en modo folleto**

Para exportar una presentación en modo folleto, cree una instancia de [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/handoutlayoutingoptions/) y asígnela a las opciones de exportación de destino mediante [setSlidesLayoutOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

El siguiente ejemplo carga `sample.pptx` y lo exporta a PDF con cuatro diapositivas por página en orden horizontal. Incluye números de diapositiva y marcos alrededor de las diapositivas, y excluye los comentarios.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Cargar una presentación.
presentation = Presentation("sample.pptx")
try:
    # Configurar el diseño del folleto.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Exportar la presentación a PDF con el diseño seleccionado.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}

Los ajustes de diseño de folleto se aplican a los formatos de salida compatibles, como PDF, HTML, TIFF y las imágenes renderizadas. No reorganizan las diapositivas en la presentación original.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es el número máximo de miniaturas de diapositivas por página en modo folleto?**

Aspose.Slides admite hasta nueve miniaturas por página. Los valores predefinidos de [HandoutType](https://reference.aspose.com/slides/es/python-java/aspose.slides/handouttype/) ofrecen una, dos, tres, cuatro, seis o nueve diapositivas por página. Los valores predefinidos de cuatro, seis y nueve diapositivas permiten ordenación horizontal y vertical.

**¿Puedo definir una cuadrícula personalizada, como cinco o ocho diapositivas por página?**

No. El número y el orden de las miniaturas están controlados por los valores predefinidos de [HandoutType](https://reference.aspose.com/slides/es/python-java/aspose.slides/handouttype/). No se admiten cuadrículas arbitrarias con estas configuraciones de diseño de folleto.

**¿Puedo incluir diapositivas ocultas en la salida del folleto?**

Sí. Active las diapositivas ocultas en la configuración de exportación para el formato de destino. Para PDF, llame a [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) con `True` antes de guardar la presentación.