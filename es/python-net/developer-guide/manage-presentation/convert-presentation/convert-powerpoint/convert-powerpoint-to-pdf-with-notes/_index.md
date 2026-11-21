---
title: Convertir presentaciones a PDF con notas en Python
linktitle: Presentación a PDF con notas
type: docs
weight: 50
url: /es/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- convertir PowerPoint
- convertir OpenDocument
- convertir presentación
- convertir PPT
- convertir PPTX
- convertir ODP
- PowerPoint a PDF
- OpenDocument a PDF
- presentación a PDF
- PPT a PDF
- PPTX a PDF
- ODP a PDF
- notas del orador
- PDF con notas
- Python
- Aspose.Slides
description: "Convertir los formatos PPT, PPTX y ODP a PDF con notas utilizando Aspose.Slides para Python. Conservar diseños y notas del orador para presentaciones profesionales."
---
## **Visión general**

En este artículo, aprenderá cómo convertir presentaciones de PowerPoint a formato PDF con notas del orador utilizando Aspose.Slides. Esta guía cubrirá los pasos necesarios y proporcionará ejemplos de código para ayudarle a realizar esta tarea de forma eficiente. Al final de este artículo, podrá:

- Implementar el proceso de conversión para transformar diapositivas de PowerPoint en documentos PDF manteniendo las notas del orador.
- Personalizar el PDF de salida para garantizar que las notas del orador se incluyan y se formateen según sus requisitos.

Para establecer las dimensiones y la orientación de la página de notas antes de la exportación, consulte [Tamaño de la página de notas](/slides/es/python-net/notes-size/).

## **Convertir PowerPoint a PDF con notas**

El método `save` de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) puede usarse para convertir una presentación PPT o PPTX a PDF con notas del orador. Con Aspose.Slides, simplemente carga la presentación, configura las opciones de diseño mediante la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/notescommentslayoutingoptions/) para incluir las notas del orador y, a continuación, guarda el archivo como PDF. El siguiente fragmento de código muestra cómo convertir una presentación de ejemplo a PDF en la vista de diapositiva de notas.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # Configurar opciones PDF para renderizar notas del orador.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Guardar la presentación en PDF con notas del orador.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
Es posible que desee consultar el [Conversor en línea de PowerPoint a PDF](https://products.aspose.app/slides/es/conversion) de Aspose.
{{% /alert %}}