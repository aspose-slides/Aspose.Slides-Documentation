---
title: Extracción avanzada de texto de presentaciones en Python
linktitle: Extraer texto
type: docs
weight: 90
url: /es/python-net/extract-text-from-presentation/
keywords:
- extraer texto
- extraer texto de la diapositiva
- extraer texto de la presentación
- extraer texto de PowerPoint
- extraer texto de OpenDocument
- extraer texto de PPT
- extraer texto de PPTX
- extraer texto de ODP
- obtener texto
- obtener texto de la diapositiva
- obtener texto de la presentación
- obtener texto de PowerPoint
- obtener texto de OpenDocument
- obtener texto de PPT
- obtener texto de PPTX
- obtener texto de ODP
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Extrae texto rápidamente de presentaciones PowerPoint y OpenDocument utilizando Aspose.Slides para Python vía .NET. Sigue nuestra guía sencilla, paso a paso, para ahorrar tiempo."
---
## **Visión general**

Extraer texto de presentaciones es una tarea común pero esencial para los desarrolladores que trabajan con contenido de diapositivas. Ya sea que manejes archivos de Microsoft PowerPoint en formato PPT o PPTX, o presentaciones OpenDocument (ODP), acceder y recuperar datos textuales puede ser crucial para el análisis, la automatización, la indexación o la migración de contenido.

Este artículo proporciona una guía completa sobre cómo extraer texto de forma eficiente de varios formatos de presentación, incluidos PPT, PPTX y ODP, utilizando Aspose.Slides for Python via .NET. Aprenderás a iterar sistemáticamente a través de los elementos de la presentación para obtener con precisión el contenido de texto que necesitas.

## **Extraer texto de una diapositiva**

Aspose.Slides for Python via .NET proporciona el [aspose.slides.util](https://reference.aspose.com/slides/es/python-net/aspose.slides.util/) namespace, que incluye la clase [SlideUtil](https://reference.aspose.com/slides/es/python-net/aspose.slides.util/slideutil/). Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer texto de una diapositiva en una presentación, utiliza el método [get_all_text_boxes](https://reference.aspose.com/slides/es/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Este método acepta como parámetro un objeto de tipo [BaseSlide](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/). Al ejecutarse, el método escanea toda la diapositiva en busca de texto y devuelve una matriz de objetos de tipo [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/), preservando cualquier formato de texto.

El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Extraer texto de una presentación**

Para escanear texto de toda la presentación, utiliza el método estático [get_all_text_frames](https://reference.aspose.com/slides/es/python-net/aspose.slides.util/slideutil/get_all_text_frames/) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/es/python-net/aspose.slides.util/slideutil/). Acepta dos parámetros:

1. Primero, un objeto [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) que representa una presentación de PowerPoint o OpenDocument de la que se extraerá el texto.
1. Segundo, un valor `Boolean` que indica si las diapositivas maestras deben incluirse al escanear el texto de la presentación.

El método devuelve una matriz de objetos de tipo [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/), incluida la información de formato del texto. El código a continuación escanea el texto y los detalles de formato de una presentación, incluidas las diapositivas maestras.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Extracción de texto categorizada y rápida**

La clase [PresentationFactory](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationfactory/) también proporciona métodos para extraer todo el texto de presentaciones:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

El argumento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/es/python-net/aspose.slides/textextractionarrangingmode/) indica el modo de organización del resultado de la extracción de texto y puede establecerse en los siguientes valores:
- `UNARRANGED` - El texto sin procesar sin tener en cuenta su posición en la diapositiva.
- `ARRANGED` - El texto se organiza en el mismo orden que aparece en la diapositiva.

El modo `UNARRANGED` puede usarse cuando la velocidad es crítica; es más rápido que el modo `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationtext/) representa el texto sin procesar extraído de la presentación. Su propiedad `slides_text` devuelve una matriz de objetos de texto de diapositiva. Cada objeto representa el texto de la diapositiva correspondiente y tiene las siguientes propiedades:

- `text` - El texto dentro de las formas de la diapositiva.
- `master_text` - El texto dentro de las formas de la diapositiva maestra asociada a esta diapositiva.
- `layout_text` - El texto dentro de las formas de la diapositiva de diseño asociada a esta diapositiva.
- `notes_text` - El texto dentro de las formas de la diapositiva de notas asociada a esta diapositiva.
- `comments_text` - El texto dentro de los comentarios asociados a esta diapositiva.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **Preguntas frecuentes**

**¿Qué rapidez tiene Aspose.Slides al procesar presentaciones grandes durante la extracción de texto?**

Aspose.Slides está optimizado para alto rendimiento y puede procesar incluso [presentaciones grandes](/slides/es/python-net/open-presentation/), lo que lo hace adecuado para escenarios de procesamiento en tiempo real o por lotes.

**¿Puede Aspose.Slides extraer texto de tablas y gráficos dentro de presentaciones?**

Sí. Aspose.Slides puede extraer texto de muchos elementos de diapositiva, incluidas tablas y objetos relacionados con gráficos, para que