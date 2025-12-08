---
title: Gestionar marcadores de posición en presentaciones con Python
linktitle: Gestionar marcadores de posición
type: docs
weight: 10
url: /es/python-net/manage-placeholder/
keywords:
- marcador de posición
- marcador de posición de texto
- marcador de posición de imagen
- marcador de posición de gráfico
- texto de sugerencia
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Gestione sin esfuerzo los marcadores de posición en Aspose.Slides para Python a través de .NET: reemplace texto, personalice sugerencias y establezca la transparencia de imágenes en PowerPoint y OpenDocument."
---

## **Resumen**

Los marcadores de posición definen regiones reservadas en maestros, diseños y diapositivas—como título, cuerpo, imagen, gráfico, fecha/hora, número de diapositiva y pie de página—que controlan dónde se coloca el contenido y cómo hereda el formato. Con Aspose.Slides para Python puedes descubrir marcadores de posición en una diapositiva, su diseño o el maestro comprobando que `shape.placeholder` no sea `None`, inspeccionar `placeholder.type` y luego leer o modificar el contenido y el formato asociado. La API permite añadir nuevos marcadores de posición a un maestro o diseño para que se propaguen a diapositivas descendientes, reposicionar y cambiar el tamaño de los existentes, convertir un marcador de posición en una forma normal cuando necesitas control total, o eliminarlo para simplificar el diseño. Los ejemplos a continuación muestran cómo enumerar marcadores de posición, actualizar texto y estilo, y mantener los diseños consistentes aplicando cambios en el nivel apropiado.

## **Cambiar texto en marcadores de posición**

Usando Aspose.Slides para Python, puedes encontrar y modificar marcadores de posición en diapositivas de una presentación. Aspose.Slides permite modificar el texto dentro de un marcador de posición.

**Requisito:** Necesitas una presentación que contenga un marcador de posición. Puedes crear dicha presentación en Microsoft PowerPoint.

Así es como se usa Aspose.Slides para reemplazar el texto en un marcador de posición:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y pasar la presentación como argumento.
2. Obtener una referencia a la diapositiva por su índice.
3. Recorrer las formas para encontrar el marcador de posición.
4. Cambiar el texto usando el [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) asociado con el [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
5. Guardar la presentación modificada.

Este código Python muestra cómo cambiar el texto en un marcador de posición:
```python
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Iterar a través de las formas para encontrar marcadores de posición.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Cambiar el texto en cada marcador de posición.
            shape.text_frame.text = "This is Placeholder"

    # Guardar la presentación en disco.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer texto de sugerencia para un marcador de posición**

Los diseños estándar y predefinidos incluyen texto de sugerencia en los marcadores de posición, como **Click to add a title** o **Click to add a subtitle**. Con Aspose.Slides, puedes reemplazar esas sugerencias con tu propio texto en los diseños de marcadores de posición.

El siguiente ejemplo en Python muestra cómo establecer el texto de sugerencia para un marcador de posición:
```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Iterar a través de las formas para encontrar marcadores de posición.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer transparencia de imagen en un marcador de posición**

Aspose.Slides permite establecer la transparencia de una imagen de fondo en un marcador de posición de texto. Al ajustar la transparencia de la imagen dentro de ese marco, puedes hacer que destaque el texto o la imagen, según sus colores.

El siguiente ejemplo en Python muestra cómo establecer la transparencia del fondo de una imagen dentro de una forma:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```


## **Preguntas frecuentes**

**¿Qué es un marcador de posición base y en qué se diferencia de una forma local en una diapositiva?**

Un marcador de posición base es la forma original en un diseño o maestro del que la forma de la diapositiva hereda—tipo, posición y parte del formato provienen de él. Una forma local es independiente; si no existe un marcador de posición base, la herencia no se aplica.

**¿Cómo puedo actualizar todos los títulos o subtítulos de una presentación sin iterar sobre cada diapositiva?**

Edita el marcador de posición correspondiente en el diseño o en el maestro. Las diapositivas basadas en esos diseños/maestro heredarán automáticamente el cambio.

**¿Cómo controlo los marcadores de posición estándar de encabezado/pie de página—fecha y hora, número de diapositiva y texto del pie de página?**

Utiliza los administradores HeaderFooter en el ámbito adecuado (diapositivas normales, diseños, maestro, notas/folletos) para activar o desactivar esos marcadores de posición y establecer su contenido.