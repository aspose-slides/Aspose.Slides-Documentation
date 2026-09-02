---
title: Gestionar comentarios de presentación en Python
linktitle: Comentarios de presentación
type: docs
weight: 100
url: /es/python-net/presentation-comments/
keywords:
- comentario
- comentario moderno
- comentarios de PowerPoint
- comentarios de presentación
- comentarios de diapositiva
- añadir comentario
- acceder al comentario
- editar comentario
- responder al comentario
- eliminar comentario
- borrar comentario
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Gestiona los comentarios de presentaciones con Aspose.Slides para Python a través de .NET: añade, lee, edita, responde y elimina comentarios en presentaciones de PowerPoint."
---
## **Descripción general**

Este artículo explica cómo administrar los comentarios de una presentación con Aspose.Slides for Python via .NET. Presenta los principales tipos relacionados con los comentarios y muestra cómo añadir comentarios a las diapositivas, acceder a los comentarios existentes, trabajar con respuestas y comentarios modernos, y eliminar comentarios de una presentación.

Los ejemplos cubren escenarios comunes de revisión y colaboración en PowerPoint, como asignar comentarios a autores, leer el texto y los metadatos de los comentarios, crear cadenas de respuestas y eliminar comentarios seleccionados o todos los comentarios.

En PowerPoint, los comentarios aparecen como anotaciones en las diapositivas. Seleccionar un comentario muestra su texto y la discusión relacionada.

## **¿Por qué añadir comentarios a las presentaciones?**

Puede utilizar los comentarios para proporcionar retroalimentación y colaborar con colegas al revisar presentaciones.

Aspose.Slides for Python via .NET proporciona las siguientes API para trabajar con comentarios:

* La clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) que proporciona acceso a los autores de comentarios de la presentación.
* La clase [CommentCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/commentcollection/) que representa los comentarios asociados a un autor individual.
* La clase [Comment](https://reference.aspose.com/slides/es/python-net/aspose.slides/comment/) que proporciona información sobre un comentario, incluido su autor, hora de creación, posición y texto.
* La clase [CommentAuthor](https://reference.aspose.com/slides/es/python-net/aspose.slides/commentauthor/) que proporciona información sobre un autor, incluido su nombre, iniciales y comentarios asociados.

## **Añadir comentarios a diapositivas**

El siguiente ejemplo muestra cómo añadir comentarios a diapositivas en una presentación de PowerPoint:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a los comentarios de diapositivas**

El siguiente ejemplo muestra cómo acceder a los comentarios existentes en una presentación de PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **Responder a los comentarios**

Un comentario principal es el comentario original en la parte superior de una jerarquía de respuestas. La propiedad [parent_comment](https://reference.aspose.com/slides/es/python-net/aspose.slides/comment/parent_comment/) de la clase [Comment](https://reference.aspose.com/slides/es/python-net/aspose.slides/comment/) permite obtener o establecer el comentario principal de un comentario.

El siguiente ejemplo muestra cómo añadir respuestas e inspeccionar la jerarquía de comentarios resultante:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Advertencia" %}}
* Cuando se utiliza el método [remove](https://reference.aspose.com/slides/es/python-net/aspose.slides/comment/remove/) de la clase [Comment](https://reference.aspose.com/slides/es/python-net/aspose.slides/comment/) para eliminar un comentario, también se eliminan todas las respuestas a ese comentario.
* Si la propiedad [parent_comment](https://reference.aspose.com/slides/es/python-net/aspose.slides/comment/parent_comment/) crea una referencia circular, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Añadir comentarios modernos**

Los comentarios modernos pueden asociarse a la propia diapositiva, a una forma concreta o a un rango de texto dentro de un AutoShape. El método [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/es/python-net/aspose.slides/commentcollection/add_modern_comment/) acepta un argumento [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/) además de la diapositiva y las coordenadas del marcador del comentario.

Cuando se pasa `None` para el argumento de forma, el comentario es un comentario a nivel de diapositiva. Su marcador se posiciona mediante las coordenadas suministradas, pero no está asociado a una forma concreta, por lo que [ModernComment.shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncomment/shape/) devuelve `None`. Cuando se proporciona una [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/), el comentario se ancla a esa forma. Las coordenadas siguen definiendo la posición del marcador del comentario en la diapositiva, mientras que la asociación a la forma puede obtenerse a través de [ModernComment.shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncomment/shape/).

### **Anclar un comentario moderno a una forma**

El siguiente ejemplo crea tanto un comentario moderno a nivel de diapositiva como un comentario moderno anclado a un AutoShape específico. A continuación lee la forma asociada de cada comentario.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Anclar comentarios a diferentes tipos de forma**

Cualquier objeto de diapositiva derivado de [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/) puede usarse como ancla de forma. Los ejemplos más habituales incluyen [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/es/python-net/aspose.slides/connector/) y [GraphicalObject](https://reference.aspose.com/slides/es/python-net/aspose.slides/graphicalobject/) como gráficos.

El siguiente ejemplo crea varios tipos de forma comunes y asocia un comentario moderno a cada una.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Anclar un comentario a texto y establecer su estado**

Para un comentario moderno asociado a un [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncomment/text_selection_start/) indica la posición inicial del texto seleccionado en el marco de texto de la forma, mientras que [ModernComment.text_selection_length](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncomment/text_selection_length/) indica la longitud de la selección. Juntas, estas propiedades asocian el comentario a un rango de texto concreto dentro del AutoShape.

La propiedad [ModernComment.status](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncomment/status/) puede leerse o actualizarse con un valor de la enumeración [ModernCommentStatus](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — no se ha definido un estado concreto para el comentario moderno.
- `ACTIVE` — el comentario está activo.
- `RESOLVED` — el comentario ha sido resuelto.
- `CLOSED` — el comentario está cerrado.

El siguiente ejemplo crea un comentario moderno anclado a una forma, lo asocia a una selección de texto, lo marca como resuelto, guarda la presentación y verifica los valores después de volver a abrir el archivo.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = draw.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **Inspeccionar comentarios modernos existentes**

Para inspeccionar una presentación existente, compruebe qué comentarios son instancias de [ModernComment](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncomment/), luego examine [ModernComment.shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncomment/text_selection_length/) y [ModernComment.status](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncomment/status/). Una forma `None` indica un comentario a nivel de diapositiva. Para una ancla de [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/), las propiedades de selección de texto identifican el rango asociado en el marco de texto de la forma.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **Eliminar comentarios**

### **Eliminar todos los comentarios y autores de comentarios**

El siguiente ejemplo muestra cómo eliminar todos los comentarios y los autores de comentarios de una presentación:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Eliminar comentarios específicos**

El siguiente ejemplo muestra cómo eliminar comentarios específicos de una diapositiva:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado resuelto para los comentarios modernos?**

Sí. [ModernComment.status](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncomment/status/) puede leerse y establecerse con un valor de [ModernCommentStatus](https://reference.aspose.com/slides/es/python-net/aspose.slides/moderncommentstatus/), incluido `RESOLVED`. El estado se almacena en la presentación y puede leerse nuevamente después de volver a abrir el archivo.

**¿Se admiten conversaciones en hilos (cadenas de respuestas) y hay un límite de anidamiento?**

Sí. Cada comentario puede hacer referencia a su [parent comment](https://reference.aspose.com/slides/es/python-net/aspose.slides/comment/parent_comment/), lo que permite crear cadenas de respuestas. La API no define un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de comentario en una diapositiva?**

La posición del marcador se define mediante coordenadas de punto flotante en el sistema de coordenadas de la diapositiva, lo que permite colocarlo con precisión en la diapositiva.