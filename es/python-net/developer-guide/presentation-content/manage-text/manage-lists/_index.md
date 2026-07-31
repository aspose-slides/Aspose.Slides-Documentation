---
title: Gestionar listas con viñetas y numeradas en presentaciones en Python
linktitle: Gestionar listas
type: docs
weight: 70
url: /es/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
- viñeta
- lista con viñetas
- lista numerada
- viñeta de símbolo
- viñeta con imagen
- viñeta personalizada
- lista multinivel
- crear viñeta
- añadir viñeta
- añadir lista
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a crear y dar formato a listas con viñetas, con imágenes, multinivel y numeradas en presentaciones PowerPoint y OpenDocument utilizando Aspose.Slides para Python a través de .NET."
---
## **Visión general**

Aspose.Slides for Python a través de .NET le permite crear y dar formato a listas con viñetas y numeradas en presentaciones PowerPoint y OpenDocument. Un elemento de lista es un párrafo cuyas configuraciones de viñeta se controlan mediante el formato de párrafo.

Utilice la propiedad [Paragraph.paragraph_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/paragraph_format/) para acceder a la configuración de listas a nivel de párrafo. El punto de entrada principal es [ParagraphFormat.bullet](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/bullet/), que devuelve un objeto [BulletFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/). Con este objeto, puede establecer el tipo de viñeta, símbolo, imagen, color, tamaño, estilo de numeración y número de inicio.

Este artículo muestra cómo:

- crear una lista con viñetas usando un símbolo personalizado
- crear una viñeta con imagen
- crear una lista multinivel estableciendo la profundidad del párrafo
- crear una lista numerada
- inspeccionar y cambiar el formato de listas en una presentación existente

## **Crear una lista con viñetas**

Para crear una lista con viñetas, añada objetos [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/) a un [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) y establezca [BulletFormat.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/type/) a [BulletType.SYMBOL](https://reference.aspose.com/slides/es/python-net/aspose.slides/bullettype/). Después podrá definir [BulletFormat.char](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/color/) y [BulletFormat.height](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/height/) para controlar la apariencia de la viñeta.

El siguiente código Python muestra cómo crear una lista con viñetas en una diapositiva:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Viñetas de símbolo](symbol_bullets.png)

## **Crear una lista numerada**

Utilice listas numeradas cuando el orden de los elementos sea importante. Establezca [BulletFormat.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/type/) a [BulletType.NUMBERED](https://reference.aspose.com/slides/es/python-net/aspose.slides/bullettype/). También puede elegir un formato de numeración con [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/numbered_bullet_style/) o definir [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) cuando la lista deba comenzar en un valor distinto de 1.

El siguiente código Python muestra cómo crear una lista numerada en una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Viñetas numeradas](numbered_bullets.png)

## **Crear una viñeta con imagen**

Aspose.Slides permite sustituir un símbolo de viñeta normal por una imagen. Las viñetas con imágenes funcionan mejor con gráficos sencillos que sigan siendo legibles a un tamaño pequeño, como iconos o archivos PNG transparentes de dimensiones reducidas.

{{% alert color="primary" %}}
Idealmente, si planea sustituir el símbolo de viñeta normal por una imagen, lo mejor es elegir un gráfico sencillo con fondo transparente. Ese tipo de imágenes funciona bien como símbolos de viñeta personalizados.

Tenga en cuenta que la imagen se reducirá a un tamaño muy pequeño. Por esa razón, recomendamos encarecidamente seleccionar una imagen que mantenga su claridad y efectividad visual al usarse como viñeta en una lista.
{{% /alert %}}

Para crear una viñeta con imagen, añada una imagen a [Presentation.images](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/images/) y asigne el objeto de imagen devuelto a [BulletFormat.picture](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/picture/). Establezca [BulletFormat.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/bulletformat/type/) a [BulletType.PICTURE](https://reference.aspose.com/slides/es/python-net/aspose.slides/bullettype/) antes de asignar la imagen.

Supongamos que disponemos de un “image.png”:

![Una imagen para las viñetas](picture_for_bullets.png)

El siguiente código Python muestra cómo crear viñetas con imagen en una diapositiva:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Viñetas con imagen](picture_bullets.png)

## **Crear una lista multinivel**

Utilice [ParagraphFormat.depth](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/depth/) para colocar los elementos de la lista en diferentes niveles. El nivel 0 es el nivel superior, el nivel 1 está anidado debajo de él, y así sucesivamente.

El siguiente código Python muestra cómo crear una lista con viñetas multinivel:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Lista multinivel](multilevel_list.png)

## **Cambiar una lista existente**

Para modificar el formato de una lista en una presentación existente, acceda al párrafo deseado y actualice sus configuraciones de [ParagraphFormat.bullet](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/bullet/). Las mismas propiedades usadas para crear listas pueden emplearse para inspeccionar o modificar listas cargadas desde un archivo PPT, PPTX o ODP.

El siguiente código Python cambia el primer párrafo de un marco de texto para usar un estilo de lista numerada:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Se pueden exportar las listas con viñetas y numeradas a PDF o imágenes?**

Sí. Aspose.Slides conserva el formato de la lista cuando el formato de destino admite el diseño de texto y las características de viñetas correspondientes.

**¿Puedo editar listas en presentaciones existentes?**

Sí. Cargue la presentación, acceda al párrafo objetivo, inspeccione o actualice sus configuraciones de [ParagraphFormat.bullet](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraphformat/bullet/), y guarde la presentación.

**¿Pueden las listas contener texto no latino?**

Sí. El texto de los elementos de lista puede contener caracteres Unicode, por lo que puede crear listas en presentaciones multilingües. Asegúrese de que las fuentes utilizadas en la presentación soporten los caracteres que necesita.