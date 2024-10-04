---
title: Administrar Marcadores
type: docs
weight: 10
url: /python-net/manage-placeholder/
keywords: "Marcador, Texto de marcador, Texto de indicación, Presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Cambiar el texto del marcador y el texto de indicación en presentaciones de PowerPoint en Python"
---

## **Cambiar Texto en Marcador**

Usando [Aspose.Slides para Python a través de .NET](/slides/python-net/), puedes encontrar y modificar marcadores en diapositivas de presentaciones. Aspose.Slides te permite realizar cambios en el texto de un marcador.

**Requisito previo**: Necesitas una presentación que contenga un marcador. Puedes crear tal presentación en la aplicación estándar de Microsoft PowerPoint.

Así es como usas Aspose.Slides para reemplazar el texto en el marcador en esa presentación:

1. Instancia la clase [`Presentation`](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y pasa la presentación como argumento.
2. Obtén una referencia de la diapositiva a través de su índice.
3. Itera a través de las formas para encontrar el marcador.
4. Convierte la forma del marcador a un [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) y cambia el texto usando el [`TextFrame`](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) asociado con el [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
5. Guarda la presentación modificada.

Este código Python muestra cómo cambiar el texto en un marcador:

```python
import aspose.slides as slides

# Instancia una clase Presentation
with slides.Presentation(path + "ReplacingText.pptx") as pres:
    # Accede a la primera diapositiva
    sld = pres.slides[0]

    # Itera a través de las formas para encontrar el marcador
    for shp in sld.shapes:
        if shp.placeholder != None:
            # Cambia el texto en cada marcador
            shp.text_frame.text = "Este es un Marcador"

    # Guarda la presentación en disco
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer Texto de Indicación en un Marcador**
Los diseños estándar y predefinidos contienen textos de indicación de marcadores como ***Haga clic para agregar un título*** o ***Haga clic para agregar un subtítulo***. Usando Aspose.Slides, puedes insertar tus textos de indicación preferidos en los diseños de marcadores.

Este código Python te muestra cómo establecer el texto de indicación en un marcador:

```python
import aspose.slides as slides

with slides.Presentation(path + "Presentation2.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.slide.shapes: # Itera a través de la diapositiva
        if shape.placeholder != None and type(shape) is slides.AutoShape:
            text = ""
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE: # PowerPoint muestra "Haga clic para agregar título". 
                text = "Agregar Título"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE: # Agrega subtítulo.
                text = "Agregar Subtítulo"

            shape.text_frame.text = text

            print("Marcador con texto: {text}".format(text = text))

    pres.save("Placeholders_PromptText.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Transparencia de Imagen de Marcador**

Aspose.Slides te permite establecer la transparencia de la imagen de fondo en un marcador de texto. Al ajustar la transparencia de la imagen en dicho marco, puedes hacer que el texto o la imagen se destaquen (dependiendo de los colores del texto y la imagen).

Este código Python te muestra cómo establecer la transparencia para un fondo de imagen (dentro de una forma):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoShape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    
    autoShape.fill_format.fill_type = slides.FillType.PICTURE
    with open("image.png", "rb") as in_file:
        autoShape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(in_file)

        autoShape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        autoShape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)

```