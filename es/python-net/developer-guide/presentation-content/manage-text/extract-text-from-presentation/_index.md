---
title: Extracción avanzada de texto de presentaciones PowerPoint en Python
linktitle: Extraer texto
type: docs
weight: 90
url: /es/python-net/extract-text-from-presentation/
keywords:
- extraer texto
- extraer texto de diapositiva
- extraer texto de presentación
- extraer texto de PowerPoint
- extraer texto de OpenDocument
- extraer texto de PPT
- extraer texto de PPTX
- extraer texto de ODP
- recuperar texto
- recuperar texto de diapositiva
- recuperar texto de presentación
- recuperar texto de PowerPoint
- recuperar texto de OpenDocument
- recuperar texto de PPT
- recuperar texto de PPTX
- recuperar texto de ODP
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo extraer texto rápida y fácilmente de presentaciones PowerPoint usando Aspose.Slides para Python a través de .NET. Siga nuestra guía simple, paso a paso, para ahorrar tiempo y acceder eficientemente al contenido de las diapositivas en sus aplicaciones."
---

## **Resumen**

Extraer texto de presentaciones es una tarea común pero esencial para los desarrolladores que trabajan con contenido de diapositivas. Tanto si manejas archivos de Microsoft PowerPoint en formato PPT o PPTX, como presentaciones OpenDocument (ODP), acceder y recuperar datos textuales puede ser fundamental para análisis, automatización, indexación o migración de contenido.

Este artículo ofrece una guía completa sobre cómo extraer texto de manera eficiente de varios formatos de presentación, incluidos PPT, PPTX y ODP, usando Aspose.Slides para Python. Aprenderás a iterar sistemáticamente a través de los elementos de la presentación para obtener con precisión el contenido textual que necesitas.

## **Extraer texto de una diapositiva**

Aspose.Slides para Python proporciona el espacio de nombres [aspose.slides.util](https://reference.aspose.com/slides/python-net/aspose.slides.util/) , que incluye la clase [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/). Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer texto de una diapositiva en una presentación, utiliza el método [get_all_text_boxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Este método acepta un objeto del tipo [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) como parámetro. Cuando se ejecuta, el método escanea toda la diapositiva en busca de texto y devuelve una matriz de objetos del tipo [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), conservando cualquier formato de texto.

El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Obtener una matriz de objetos TextFrame de todas las diapositivas del archivo PPTX.
    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)
    # Recorrer la matriz de los marcos de texto.
    for text_frame in text_frames:
        # Recorrer los párrafos en el marco de texto actual.
        for paragraph in text_frame.paragraphs:
            # Recorrer las porciones de texto en el párrafo actual.
            for portion in paragraph.portions:
                # Mostrar el texto en la porción actual.
                print(portion.text)
                # Mostrar la altura de fuente del texto.
                print(portion.portion_format.font_height)
                # Mostrar el nombre de la fuente del texto.
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **Extraer texto de una presentación**

Para escanear texto de toda la presentación, usa el método estático [get_all_text_frames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_frames/) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/). Acepta dos parámetros:

1. Un objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que representa una presentación PowerPoint u OpenDocument de la cual se extraerá el texto.  
1. Un valor `Boolean` que indica si las diapositivas maestras deben incluirse al escanear el texto de la presentación.

El método devuelve una matriz de objetos del tipo [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), incluyendo información de formato de texto. El código a continuación escanea el texto y los detalles de formato de una presentación, incluidas las diapositivas maestras.
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation("pres.pptx") as presentation:
    # Obtener una matriz de objetos TextFrame de todas las diapositivas del archivo PPTX.
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, True)
    # Recorrer la matriz de marcos de texto.
    for text_frame in text_frames:
        # Recorrer los párrafos en el marco de texto actual.
        for paragraph in text_frame.paragraphs:
            # Recorrer las porciones de texto en el párrafo actual.
            for portion in paragraph.portions:
                # Mostrar el texto en la porción actual.
                print(portion.text)
                # Mostrar la altura de fuente del texto.
                print(portion.portion_format.font_height)
                # Mostrar el nombre de la fuente del texto.
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **Extracción de texto categorizada y rápida**

La clase [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationfactory/) también proporciona métodos estáticos para extraer todo el texto de presentaciones:
```py
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```


El argumento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/python-net/aspose.slides/textextractionarrangingmode/) indica el modo de organización del resultado de la extracción de texto y puede establecerse en los siguientes valores:
- `UNARRANGED` – El texto bruto sin considerar su posición en la diapositiva.  
- `ARRANGED` – El texto se organiza en el mismo orden que aparece en la diapositiva.

El modo `UNARRANGED` puede usarse cuando la velocidad es crítica; es más rápido que el modo `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/python-net/aspose.slides/presentationtext/) representa el texto bruto extraído de la presentación. Contiene la propiedad `slides_text`, que devuelve una matriz de objetos del tipo [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/). Cada objeto representa el texto de la diapositiva correspondiente. El objeto del tipo [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/) tiene las siguientes propiedades:

- `text` – El texto dentro de las formas de la diapositiva.  
- `master_text` – El texto dentro de las formas de la diapositiva maestra asociada a esta diapositiva.  
- `layout_text` – El texto dentro de las formas de la diapositiva de diseño asociada a esta diapositiva.  
- `notes_text` – El texto dentro de las formas de la diapositiva de notas asociada a esta diapositiva.  
- `comments_text` – El texto dentro de los comentarios asociados a esta diapositiva.  
```py
import aspose.slides as slides

arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory().get_presentation_text("sample.pptx", arranging_mode)
slide_text = presentation_text.slides_text[0]
print(slide_text.text)
print(slide_text.layout_text)
print(slide_text.master_text)
print(slide_text.notes_text)
```


## **Preguntas frecuentes**

**¿Qué tan rápido procesa Aspose.Slides presentaciones grandes al extraer texto?**

Aspose.Slides está optimizado para alto rendimiento y procesa eficientemente incluso [presentaciones grandes](/slides/es/python-net/open-presentation/), lo que lo hace adecuado para escenarios de procesamiento en tiempo real o por lotes.

**¿Puede Aspose.Slides extraer texto de tablas y gráficos dentro de presentaciones?**

Sí, Aspose.Slides admite completamente la extracción de texto de tablas, gráficos y otros elementos complejos de diapositivas, permitiéndote acceder y analizar todo el contenido textual con facilidad.

**¿Necesito una licencia especial de Aspose.Slides para extraer texto de presentaciones?**

Puedes extraer texto usando la versión de prueba gratuita de Aspose.Slides, aunque tendrá [ciertas limitaciones](/slides/es/python-net/licensing/), como procesar solo un número limitado de diapositivas. Para uso sin restricciones y para manejar presentaciones más grandes, se recomienda adquirir una licencia completa.