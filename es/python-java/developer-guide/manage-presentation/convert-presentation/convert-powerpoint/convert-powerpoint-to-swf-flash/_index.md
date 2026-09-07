---
title: Convertir presentaciones de PowerPoint a SWF Flash en Python mediante Java
linktitle: PowerPoint a SWF
type: docs
weight: 80
url: /es/python-java/convert-powerpoint-to-swf-flash/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a SWF
- presentación a SWF
- diapositiva a SWF
- PPT a SWF
- PPTX a SWF
- PowerPoint a Flash
- presentación a Flash
- diapositiva a Flash
- PPT a Flash
- PPTX a Flash
- guardar PPT como SWF
- guardar PPTX como SWF
- exportar PPT a SWF
- exportar PPTX a SWF
- Python
- Java
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint a SWF Flash en Python mediante Java con Aspose.Slides. Configurar el visor, notas, diapositivas ocultas, compresión y fuentes."
---
## **Visión general**

Aspose.Slides for Python via Java le permite convertir presentaciones de PowerPoint a SWF sin Microsoft PowerPoint. Utilice [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) para exportar la presentación y [SwfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/swfoptions/) para configurar la configuración del visor, la calidad de imagen y el diseño de notas o comentarios.

## **Convertir presentaciones a Flash**

Cargue el archivo de origen con [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/), configure [SwfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/swfoptions/), y guárdelo usando [SaveFormat.Swf](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#Swf).

El siguiente ejemplo exporta `presentation.pptx` a `presentation.swf`. Desactiva el visor integrado con [setViewerIncluded](https://reference.aspose.com/slides/es/python-java/aspose.slides/swfoptions/#setViewerIncluded) e incluye las notas del ponente debajo de las diapositivas usando [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Antes de ejecutar el ejemplo, [instale Aspose.Slides for Python via Java](/slides/es/python-java/installation/) y coloque `presentation.pptx` en el directorio de trabajo. La JVM se inicia una vez por proceso de Python.

El ejemplo aplica [NotesPositions.BottomFull](https://reference.aspose.com/slides/es/python-java/aspose.slides/notespositions/#BottomFull) mediante [setNotesPosition](https://reference.aspose.com/slides/es/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) y pasa el diseño a [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). Para incluir también los comentarios, configure [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/es/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) antes de la exportación.

## **Preguntas frecuentes**

**¿Puedo incluir diapositivas ocultas en el SWF?**

Sí. Llame a [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) con `True`. Por defecto, las diapositivas ocultas no se exportan.

**¿Cómo puedo controlar la compresión y el tamaño final del SWF?**

Utilice [SwfOptions.setCompressed](https://reference.aspose.com/slides/es/python-java/aspose.slides/swfoptions/#setCompressed) para habilitar o deshabilitar la compresión y [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/es/python-java/aspose.slides/swfoptions/#setJpegQuality) para ajustar la calidad de imagen JPEG. Una calidad JPEG más baja puede reducir el tamaño del archivo a costa de la fidelidad de la imagen.

**¿Para qué sirve el visor integrado y cuándo debo desactivarlo?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/es/python-java/aspose.slides/swfoptions/#setViewerIncluded) controla si el SWF generado incluye el visor. Pase `False` cuando necesite las diapositivas exportadas sin el visor integrado, como en el ejemplo anterior.

**¿Qué ocurre si una fuente origen falta en la máquina de exportación?**

Puede especificar una fuente regular predeterminada con [setDefaultRegularFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), heredada por [SwfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/swfoptions/). Elija una fuente disponible para el proceso de exportación; la sustitución de fuentes puede cambiar la apariencia del texto y el diseño.