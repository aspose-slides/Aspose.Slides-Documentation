---
title: Convertir presentaciones de PowerPoint a PDF con notas en Python
linktitle: PowerPoint a PDF con notas
type: docs
weight: 50
url: /es/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir PPT
- convertir PPTX
- PowerPoint a PDF
- presentación a PDF
- PPT a PDF
- PPTX a PDF
- guardar presentación como PDF
- exportar PPT a PDF
- exportar PPTX a PDF
- notas del presentador
- PDF con notas
- Python
- Java
- Aspose.Slides
description: "Convertir presentaciones PPT y PPTX a PDF con notas del presentador usando Aspose.Slides para Python a través de Java. Configurar la ubicación de las notas y preservar notas largas."
---
## **Visión general**

Este artículo explica cómo convertir presentaciones de PowerPoint a PDF con notas del presentador usando Aspose.Slides para Python a través de Java. Puede incluir notas debajo de cada diapositiva y permitir que las notas largas continúen en páginas adicionales. Para otras configuraciones de exportación a PDF, consulte [Convertir PowerPoint a PDF](/slides/es/python-java/convert-powerpoint-to-pdf/).

Para establecer las dimensiones y la orientación de la página de notas antes de la exportación, consulte [Tamaño de página de notas](/slides/es/python-java/notes-size/).

## **Convertir PowerPoint a PDF con notas**

Utilice el método [save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) para exportar una presentación PPT o PPTX a PDF. Para incluir notas del presentador, cree un objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/notescommentslayoutingoptions/) y configure la posición de la nota con su método [setNotesPosition](https://reference.aspose.com/slides/es/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Asigne este diseño a [PdfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/) mediante [setSlidesLayoutOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

El siguiente ejemplo carga `sample.pptx` y lo exporta a `output.pdf` con notas del presentador debajo de las diapositivas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Configurar opciones PDF para renderizar notas del presentador.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Guardar la presentación en PDF con notas del presentador.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
También puede probar el [Convertidor en línea de PowerPoint a PDF](https://products.aspose.app/slides/es/conversion).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo evitar que las notas largas del presentador se corten?**

Utilice [NotesPositions.BottomFull](https://reference.aspose.com/slides/es/python-java/aspose.slides/notespositions/#BottomFull), como en el ejemplo anterior. Esta configuración muestra las notas completas, utilizando páginas adicionales cuando sea necesario.

**¿Puedo mantener cada diapositiva y sus notas en una sola página?**

Utilice [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/es/python-java/aspose.slides/notespositions/#BottomTruncated). Esta configuración limita las notas a una página, de modo que las notas que no quepan pueden truncarse.

**¿Cómo exporto diapositivas sin notas del presentador?**

Omita la configuración del diseño de notas y utilice la exportación estándar a PDF descrita en [Convertir PowerPoint a PDF](/slides/es/python-java/convert-powerpoint-to-pdf/).