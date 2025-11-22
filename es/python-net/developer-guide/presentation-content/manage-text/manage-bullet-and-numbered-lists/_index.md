---
title: Gestionar listas con viñetas y numeradas en presentaciones en Python
linktitle: Gestionar listas
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
- añadir viñeta
- añadir lista
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Aprenda cómo gestionar listas con viñetas y listas numeradas en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Python a través de .NET. Guía paso a paso con ejemplos de código para ayudarle a comenzar rápidamente."
---

## **Visión general**

Gestionar listas con viñetas y numeradas de manera eficaz es importante al crear presentaciones impactantes. Con Aspose.Slides for Python, puedes automatizar fácilmente el formato de listas en tus diapositivas de forma programática. Este artículo te guía mediante ejemplos claros sobre cómo crear, modificar y personalizar listas con viñetas y numeradas usando Python. Descubre formas simples pero potentes de controlar la sangría, el estilo, los esquemas de numeración y los símbolos de viñeta, permitiendo que tus presentaciones se vean profesionales y consistentes en todo momento.

**¿Por qué usar listas con viñetas?**

Las listas con viñetas te ayudan a organizar y presentar la información de forma clara, mejorando la legibilidad y el compromiso. Normalmente, una lista con viñetas cumple tres propósitos clave:

- Destaca información importante, captando la atención de inmediato.
- Permite a los lectores escanear rápidamente e identificar los puntos principales.
- Comunica de manera concisa los detalles esenciales.

**¿Por qué usar listas numeradas?**

Las listas numeradas son otra herramienta valiosa para organizar y presentar tu contenido de forma clara. Son especialmente útiles cuando el orden o la jerarquía de los elementos importa. Usa listas numeradas en lugar de viñetas cuando los pasos o ítems deben seguir un orden específico (por ejemplo, *Paso 1, Paso 2, Paso 3,* etc.), o cuando necesitas referirte a pasos concretos más adelante en el texto (como, *volver al Paso 3*). Esto hace que tus instrucciones o explicaciones sean más claras, fáciles de seguir y permite a los lectores navegar y referenciar tu contenido con facilidad.

## **Crear viñetas de símbolo**

Para crear una lista con viñetas, sigue estos pasos:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
1. Accede a la diapositiva (en la que deseas agregar la lista) desde la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva seleccionada.
1. Accede al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma añadida.
1. Elimina el párrafo predeterminado del cuadro de texto.
1. Crea el primer párrafo usando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Establece el tipo de viñeta a `SYMBOL` y define el carácter de la viñeta.
1. Asigna el texto del párrafo.
1. Configura la sangría del párrafo para controlar la posición de la viñeta.
1. Define el color de la viñeta.
1. Define la altura de la viñeta.
1. Añade el párrafo creado a la colección de párrafos del cuadro de texto.
1. Añade un segundo párrafo y repite los pasos 7‑12.
1. Guarda la presentación.

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

![Las viñetas de símbolo](symbol_bullets.png)

## **Crear viñetas de imagen**

Aspose.Slides for Python via .NET te permite personalizar las viñetas en listas con viñetas. Puedes reemplazar las viñetas estándar por símbolos o imágenes personalizadas. Si deseas agregar interés visual a una lista o destacar más ciertos elementos, puedes usar tu propia imagen como viñeta.

{{% alert color="primary" %}}

Idealmente, si planeas sustituir el símbolo de viñeta regular por una imagen, es mejor elegir un gráfico sencillo con fondo transparente. Ese tipo de imágenes funciona bien como símbolos de viñeta personalizados.

Ten en cuenta que la imagen se reducirá a un tamaño muy pequeño. Por esa razón, recomendamos encarecidamente seleccionar una imagen que siga siendo clara y visualmente eficaz cuando se use como viñeta en una lista.

{{% /alert %}}

Para crear una viñeta de imagen, sigue estos pasos:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
1. Accede a la diapositiva deseada desde la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva seleccionada mediante el método `add_auto_shape`.
1. Accede al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma añadida.
1. Elimina el párrafo predeterminado del cuadro de texto.
1. Carga una imagen desde disco, añádela a [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/), y obtén la instancia [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) devuelta por el método [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/#methods).
1. Crea la primera instancia de [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Establece el tipo de viñeta a `PICTURE` y asigna la imagen.
1. Asigna el texto del párrafo.
1. Configura la sangría del párrafo para posicionar la viñeta.
1. Define el color de la viñeta.
1. Define la altura de la viñeta.
1. Añade el párrafo a la colección de párrafos del cuadro de texto.
1. Añade un segundo párrafo y repite los pasos 8‑13.
1. Guarda la presentación.

Supongamos que tenemos un **image.png**:

![Una imagen para las viñetas](picture_for_bullets.png)

El siguiente código Python muestra cómo crear viñetas de imagen en una diapositiva:
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

![Las viñetas de imagen](picture_bullets.png)

## **Crear listas multinivel**

Para crear una lista con viñetas que contenga elementos en varios niveles (sub‑listas bajo viñetas principales), sigue estos pasos:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
1. Accede a la diapositiva deseada desde la colección de diapositivas usando el objeto [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a la diapositiva seleccionada mediante el método `add_auto_shape`.
1. Accede al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma añadida.
1. Elimina el párrafo predeterminado del cuadro de texto.
1. Crea la primera instancia de [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y establece su profundidad a 0 (nivel principal).
1. Crea el segundo párrafo y establece su profundidad a 1 (primer subnivel).
1. Crea el tercer párrafo y establece su profundidad a 2 (segundo subnivel).
1. Crea el cuarto párrafo y establece su profundidad a 3 (tercer subnivel).
1. Añade todos los párrafos creados a la colección de párrafos del cuadro de texto.
1. Guarda la presentación.

El siguiente código Python muestra cómo crear una lista multinivel con viñetas:
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

![La lista multinivel](multilevel_list.png)

## **Crear viñetas numeradas**

Crear listas numeradas claras y organizadas es sencillo con Aspose.Slides for Python. Las listas numeradas mejoran significativamente la legibilidad y ayudan a guiar a tu audiencia a través de pasos o información ordenada de forma clara. Ya sea que estés preparando diapositivas instructivas, documentando procesos o estructurando presentaciones, las listas numeradas garantizan que tu mensaje permanezca estructurado y fácil de seguir.

Aspose.Slides permite agregar, personalizar y formatear listas numeradas programáticamente. Puedes especificar diferentes estilos de numeración —como numérico (1, 2, 3), alfabético (A, B, C) o números romanos (I, II, III)— para adaptarlos al contexto o al estilo deseado de tus presentaciones.

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

![Las viñetas numeradas](numbered_bullets.png)

## **Preguntas frecuentes**

**¿Pueden exportarse las listas con viñetas y numeradas creadas con Aspose.Slides a otros formatos como PDF o imágenes?**

Sí, Aspose.Slides conserva completamente el formato y la estructura de las listas con viñetas y numeradas al exportar presentaciones a formatos como PDF, imágenes y otros, garantizando resultados consistentes.

**¿Es posible importar listas con viñetas o numeradas desde presentaciones existentes?**

Sí, Aspose.Slides permite importar y editar listas con viñetas o numeradas de presentaciones existentes manteniendo su formato y apariencia originales.

**¿Aspose.Slides admite listas con viñetas y numeradas en presentaciones creadas en varios idiomas?**

Sí, Aspose.Slides admite completamente presentaciones multilingües, permitiendo crear listas con viñetas y numeradas en cualquier idioma, incluido el uso de caracteres especiales o no latinos.