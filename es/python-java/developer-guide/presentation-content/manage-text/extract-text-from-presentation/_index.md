---
title: Extracción avanzada de texto de presentaciones en Python mediante Java
linktitle: Extraer texto
type: docs
weight: 90
url: /es/python-java/extract-text-from-presentation/
keywords:
- extraer texto
- extraer texto de la diapositiva
- extraer texto de la presentación
- extraer texto de PowerPoint
- extraer texto de OpenDocument
- extraer texto de PPT
- extraer texto de PPTX
- extraer texto de ODP
- recuperar texto
- recuperar texto de la diapositiva
- recuperar texto de la presentación
- recuperar texto de PowerPoint
- recuperar texto de OpenDocument
- recuperar texto de PPT
- recuperar texto de PPTX
- recuperar texto de ODP
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Extrae rápidamente texto de presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Python mediante Java. Sigue nuestra guía simple, paso a paso, para ahorrar tiempo."
---
## **Resumen**

Extraer texto de presentaciones es una tarea común pero esencial para los desarrolladores que trabajan con contenido de diapositivas. Ya sea que estés manejando archivos de Microsoft PowerPoint en formato PPT o PPTX, o presentaciones OpenDocument (ODP), acceder y recuperar datos textuales puede ser fundamental para análisis, automatización, indexación o migración de contenido.

Este artículo ofrece una guía completa sobre cómo extraer texto de manera eficiente de varios formatos de presentación, incluidos PPT, PPTX y ODP, usando Aspose.Slides for Python via Java. Aprenderás a iterar sistemáticamente a través de los elementos de la presentación para obtener con precisión el contenido textual que necesitas.

## **Extraer texto de una diapositiva**

Aspose.Slides for Python via Java proporciona la clase [SlideUtil](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideutil/). Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer texto de una diapositiva en una presentación, usa el método [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideutil/#getAllTextBoxes). Este método acepta un objeto de tipo [BaseSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/) como parámetro. Al ejecutarse, el método recorre toda la diapositiva en busca de texto y devuelve una matriz de objetos de tipo [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/), conservando cualquier formato de texto.

El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Extraer texto de una presentación**

Para escanear el texto de toda la presentación, usa el método estático [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideutil/#getAllTextFrames) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideutil/). Acepta dos parámetros:

1. Primero, un objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) que representa una presentación PowerPoint u OpenDocument de la cual se extraerá el texto.  
2. Segundo, un valor `bool` que indica si se deben incluir las diapositivas maestras al escanear el texto de la presentación.

El método devuelve una matriz de objetos de tipo [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/), incluida la información de formato del texto. El código a continuación escanea el texto y los detalles de formato de una presentación, incluidas las diapositivas maestras.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Extracción de texto categorizada y rápida**

La clase [PresentationFactory](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationfactory/) también ofrece métodos para extraer todo el texto de presentaciones:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Extraer el texto de un archivo.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Extraer el texto de un flujo.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Extraer el texto de un flujo usando opciones de carga.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

El argumento enumerado [TextExtractionArrangingMode](https://reference.aspose.com/slides/es/python-java/aspose.slides/textextractionarrangingmode/) indica el modo para organizar el resultado de la extracción de texto y puede establecerse en los siguientes valores:

- [Unarranged](https://reference.aspose.com/slides/es/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) – El texto bruto sin tener en cuenta su posición en la diapositiva.  
- [Arranged](https://reference.aspose.com/slides/es/python-java/aspose.slides/textextractionarrangingmode/#Arranged) – El texto se organiza en el mismo orden que aparece en la diapositiva.

El modo *Unarranged* puede usarse cuando la velocidad es crítica; es más rápido que el modo *Arranged*.

[PresentationText](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationtext/) representa el texto bruto extraído de la presentación. Su método [getSlidesText](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationtext/#getSlidesText) devuelve una matriz de objetos de tipo `SlideText`. Cada objeto representa el texto de la diapositiva correspondiente. El objeto de tipo `SlideText` dispone de los siguientes métodos:

- `getText` – El texto dentro de las formas de la diapositiva.  
- `getMasterText` – El texto dentro de las formas de la diapositiva maestra asociada a esta diapositiva.  
- `getLayoutText` – El texto dentro de las formas de la diapositiva de diseño asociada a esta diapositiva.  
- `getNotesText` – El texto dentro de las formas de la diapositiva de notas asociada a esta diapositiva.  
- `getCommentsText` – El texto dentro de los comentarios asociados a esta diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **Preguntas frecuentes**

**¿Qué tan rápido procesa Aspose.Slides presentaciones grandes durante la extracción de texto?**

Aspose.Slides está optimizado para alto rendimiento y puede procesar incluso [presentaciones grandes](/slides/es/python-java/open-presentation/), lo que lo hace adecuado para escenarios de procesamiento en tiempo real o por lotes.

**¿Puede Aspose.Slides extraer texto de tablas y gráficos dentro de las presentaciones?**

Sí. Aspose.Slides puede extraer texto de muchos elementos de diapositiva, incluidas tablas y objetos relacionados con gráficos, de modo que puedas acceder y analizar el contenido textual en estructuras comunes de presentaciones.

**¿Necesito una licencia especial de Aspose.Slides para extraer texto de presentaciones?**

Puedes extraer texto usando la versión de prueba gratuita de Aspose.Slides, aunque tendrá [ciertas limitaciones](/slides/es/python-java/licensing/), como procesar solo un número limitado de diapositivas. Para un uso sin restricciones y para manejar presentaciones más grandes, se recomienda adquirir una licencia completa.