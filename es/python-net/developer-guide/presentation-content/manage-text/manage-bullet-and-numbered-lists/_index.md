---
title: Administrar listas con viñetas y numeradas en presentaciones en Python
linktitle: Administrar listas
type: docs
weight: 70
url: /es/python-net/manage-bullet-and-numbered-lists/
keywords:
- viñeta
- lista con viñetas
- lista numerada
- viñeta de símbolo
- viñeta de imagen
- viñeta personalizada
- lista multinivel
- crear viñeta
- agregar viñeta
- agregar lista
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a gestionar listas con viñetas y numeradas en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides for Python via .NET. Guía paso a paso con ejemplos de código para ayudarle a empezar rápidamente."
---

En **Microsoft PowerPoint**, puedes crear listas con viñetas y numeradas de la misma manera que lo haces en Word y otros editores de texto. **Aspose.Slides para Python a través de .NET** también te permite usar viñetas y números en las diapositivas de tus presentaciones. 

### ¿Por qué usar listas con viñetas?

Las listas con viñetas te ayudan a organizar y presentar información de manera rápida y eficiente.

**Ejemplo de lista con viñetas**

En la mayoría de los casos, una lista con viñetas cumple estas tres funciones principales:

- llama la atención de tus lectores o espectadores hacia información importante
- permite que tus lectores o espectadores busquen fácilmente los puntos clave
- comunica y entrega detalles importantes de manera eficiente.

### ¿Por qué usar listas numeradas?

Las listas numeradas también ayudan a organizar y presentar información. Idealmente, deberías usar números (en lugar de viñetas) cuando el orden de las entradas (por ejemplo, *paso 1, paso 2*, etc.) es importante o cuando una entrada debe ser referenciada (por ejemplo, *ver paso 3*).

**Ejemplo de lista numerada**

Este es un resumen de los pasos (paso 1 al paso 15) en el procedimiento **Crear viñetas** a continuación:

1. Crea una instancia de la clase presentación.
2. Realiza varias tareas (paso 3 al paso 14).
3. Guarda la presentación.

## Crear viñetas 

Para crear una lista con viñetas, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accede a la diapositiva (en la que deseas agregar una lista con viñetas) en la colección de diapositivas a través del objeto [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Agrega una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) en la diapositiva seleccionada.
4. Accede al [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma añadida.
5. Elimina el párrafo predeterminado en el [text_frame]().
6. Crea la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
8. Establece el tipo de viñeta a Símbolo y luego establece el carácter de viñeta.
9. Establece el Texto del Párrafo.
10. Establece la sangría del Párrafo para definir la viñeta.
11. Establece el Color de la viñeta.
12. Establece la Altura de la viñeta.
13. Agrega el párrafo creado en la colección de párrafos del [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
14. Agrega el segundo párrafo y repite los pasos 7-12.
15. Guarda la presentación.

Este código de muestra en Python—una implementación de los pasos anteriores—te muestra cómo crear una lista con viñetas en una diapositiva:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1
    paragraph.paragraph_format.bullet.color.color = draw.Color.red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "Mi texto"

    textFrame.paragraphs.add(paragraph)
    
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

 

## Crear viñetas con imagen

Aspose.Slides para Python a través de .NET te permite cambiar las viñetas en listas con viñetas. Puedes reemplazar las viñetas con símbolos o imágenes personalizadas. Si deseas agregar interés visual a una lista o atraer aún más la atención a las entradas en una lista, puedes usar tu propia imagen como viñeta. 

 {{% alert color="primary" %}} 

Idealmente, si intentas reemplazar el símbolo de viñeta regular con una imagen, deberías seleccionar una imagen gráfica simple con un fondo transparente. Este tipo de imágenes funciona mejor como símbolos de viñetas personalizados. 

En cualquier caso, la imagen que elijas será reducida a un tamaño muy pequeño, por lo que te recomendamos encarecidamente que selecciones una imagen que se vea bien (como un reemplazo para el símbolo de viñeta) en una lista. 

{{% /alert %}} 

Para crear una viñeta con imagen, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accede a la diapositiva deseada en la colección de diapositivas utilizando el objeto [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Agrega un [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) en la diapositiva seleccionada.
4. Accede al [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma añadida.
5. Elimina el párrafo predeterminado en el [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
6. Crea la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
7. Carga la imagen desde el disco y añádela a [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y luego utiliza la instancia [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) que se devolvió del método [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/).
8. Establece el tipo de viñeta a Imagen y luego establece la imagen.
9. Establece el Texto del Párrafo.
10. Establece la sangría del Párrafo para definir la viñeta.
11. Establece el Color de la viñeta.
12. Establece la Altura de las viñetas.
13. Agrega el párrafo creado en la colección de párrafos del [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
14. Agrega el segundo párrafo y repite los pasos 7-13.
15. Guarda la presentación.

Este código de Python muestra cómo crear una viñeta con imagen en una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "Mi texto"

    textFrame.paragraphs.add(paragraph)
    
    pres.save("pres-bullets.pptx", slides.export.SaveFormat.PPTX)
```

 

## Crear viñetas de varios niveles

Para crear una lista con viñetas que contenga elementos en diferentes niveles—listas adicionales bajo la lista principal—sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accede a la diapositiva deseada en la colección de diapositivas utilizando el objeto [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Agrega un [auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) en la diapositiva seleccionada.
4. Accede al [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma añadida.
5. Elimina el párrafo predeterminado en el [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
6. Crea la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y establece la profundidad en 0.
7. Crea la segunda instancia de párrafo utilizando la clase Paragraph y establece la profundidad en 1.
8. Crea la tercera instancia de párrafo utilizando la clase Paragraph y establece la profundidad en 2.
9. Crea la cuarta instancia de párrafo utilizando la clase Paragraph y establece la profundidad en 3.
10. Agrega los párrafos creados en la colección de párrafos del [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
11. Guarda la presentación.

Este código, que es una implementación de los pasos anteriores, muestra cómo crear una lista con viñetas de varios niveles en Python:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 300, 300)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.depth = 0
    paragraph.text = "Mi texto Profundidad 0"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 0
    paragraph2.text = "Mi texto Profundidad 1"
    textFrame.paragraphs.add(paragraph2)
    
    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "Mi texto Profundidad 2"
    textFrame.paragraphs.add(paragraph3)
    
    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "Mi texto Profundidad 3"
    textFrame.paragraphs.add(paragraph4)
    
    pres.save("pres-bullets2.pptx", slides.export.SaveFormat.PPTX)
```

 

## Crear números

Este código de Python muestra cómo crear una lista numerada en una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.text = "Mi texto 1"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Mi texto 2"
    textFrame.paragraphs.add(paragraph2)
    
    pres.save("pres-bullets3.pptx", slides.export.SaveFormat.PPTX)
```