---
title: Gestionar comentarios de presentación en Python mediante Java
linktitle: Comentarios de presentación
type: docs
weight: 100
url: /es/python-java/presentation-comments/
keywords:
- comentario
- comentario moderno
- comentarios de PowerPoint
- comentarios de presentación
- comentarios de diapositiva
- añadir comentario
- acceder al comentario
- editar comentario
- responder comentario
- eliminar comentario
- borrar comentario
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Gestiona los comentarios de presentación con Aspose.Slides for Python via Java: añade, lee, edita, responde y elimina comentarios en presentaciones de PowerPoint de forma rápida y sencilla."
---
## **Visión general**

Este artículo explica cómo gestionar los comentarios de una presentación con Aspose.Slides for Python via Java. Presenta los principales tipos relacionados con los comentarios y muestra cómo añadir comentarios a las diapositivas, acceder a los comentarios existentes, trabajar con respuestas y comentarios modernos, y eliminar comentarios de una presentación.

Los ejemplos cubren escenarios habituales de revisión y colaboración en PowerPoint, como asignar comentarios a autores, leer el texto y los metadatos de los comentarios, crear cadenas de respuestas y eliminar comentarios seleccionados o todos los comentarios.

En PowerPoint, los comentarios aparecen como anotaciones en las diapositivas. Al seleccionar un comentario se muestra su texto y la discusión relacionada.

## **¿Por qué añadir comentarios a las presentaciones?**

Puedes usar los comentarios para proporcionar retroalimentación y colaborar con colegas al revisar presentaciones.

Aspose.Slides for Python via Java ofrece las siguientes API para trabajar con comentarios:

* La clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) que proporciona acceso a los autores de los comentarios de la presentación.
* La clase [CommentCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/commentcollection/) que representa los comentarios asociados a un autor individual.
* La clase [Comment](https://reference.aspose.com/slides/es/python-java/aspose.slides/comment/) que proporciona información sobre un comentario, incluido su autor, hora de creación, posición y texto.
* La clase [CommentAuthor](https://reference.aspose.com/slides/es/python-java/aspose.slides/commentauthor/) que proporciona información sobre un autor, incluido su nombre, iniciales y los comentarios asociados.

## **Añadir comentarios a diapositivas**

El siguiente ejemplo muestra cómo añadir comentarios a las diapositivas en una presentación de PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))
    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acceder a los comentarios de las diapositivas**

El siguiente ejemplo muestra cómo acceder a los comentarios existentes en una presentación de PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **Responder a los comentarios**

Un comentario padre es el comentario original en la parte superior de una jerarquía de respuestas. Los métodos [Comment.getParentComment](https://reference.aspose.com/slides/es/python-java/aspose.slides/comment/#getParentComment) y [Comment.setParentComment](https://reference.aspose.com/slides/es/python-java/aspose.slides/comment/#setParentComment) permiten obtener o establecer el padre de un comentario.

El siguiente ejemplo muestra cómo añadir respuestas e inspeccionar la jerarquía de comentarios resultante:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* Cuando se utiliza el método [Comment.remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/comment/#remove) para eliminar un comentario, también se eliminan todas las respuestas a ese comentario.
* Si [Comment.setParentComment](https://reference.aspose.com/slides/es/python-java/aspose.slides/comment/#setParentComment) crea una referencia circular, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/python-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Añadir comentarios modernos**

Los comentarios modernos pueden asociarse a la propia diapositiva, a una forma específica o a un rango de texto dentro de un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/). El método [CommentCollection.addModernComment](https://reference.aspose.com/slides/es/python-java/aspose.slides/commentcollection/#addModernComment) acepta un argumento [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/) además de la diapositiva y las coordenadas del marcador de comentario.

Cuando se pasa `None` como argumento de forma, el comentario es un comentario a nivel de diapositiva. Su marcador se posiciona mediante las coordenadas proporcionadas, pero no está asociado a una forma concreta, por lo que [ModernComment.getShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#getShape) devuelve `None`. Cuando se proporciona una [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/), el comentario se ancla a esa forma. Las coordenadas siguen definiendo la posición del marcador del comentario en la diapositiva, mientras que la asociación de la forma puede recuperarse mediante [ModernComment.getShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#getShape).

### **Anclar un comentario moderno a una forma**

El siguiente ejemplo crea tanto un comentario moderno a nivel de diapositiva como un comentario moderno anclado a un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) específico. Luego lee la forma asociada de cada comentario.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Anclar comentarios a diferentes tipos de forma**

Cualquier objeto de diapositiva que herede de [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/) puede usarse como ancla de forma. Ejemplos comunes incluyen [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/es/python-java/aspose.slides/connector/) y [GraphicalObject](https://reference.aspose.com/slides/es/python-java/aspose.slides/graphicalobject/), como gráficos.

El siguiente ejemplo crea varios tipos de forma comunes y asocia un comentario moderno con cada una.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")
    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Anclar un comentario a texto y establecer su estado**

Para un comentario moderno asociado a un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#getTextSelectionStart) y [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#setTextSelectionStart) acceden a la posición inicial del texto seleccionado en el marco de texto de la forma. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#getTextSelectionLength) y [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#setTextSelectionLength) acceden a la longitud de la selección. Juntos, estos valores asocian el comentario con un rango de texto específico dentro del AutoShape.

Los métodos [ModernComment.getStatus](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#getStatus) y [ModernComment.setStatus](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#setStatus) acceden a un valor de las constantes [ModernCommentStatus](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncommentstatus/#NotDefined) — no se ha definido un estado específico para el comentario moderno.
- [Active](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncommentstatus/#Active) — el comentario está activo.
- [Resolved](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncommentstatus/#Resolved) — el comentario ha sido resuelto.
- [Closed](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncommentstatus/#Closed) — el comentario está cerrado.

El siguiente ejemplo crea un comentario moderno anclado a una forma, lo asocia a una selección de texto, lo marca como resuelto, guarda la presentación y verifica los valores tras volver a abrir el archivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **Inspeccionar comentarios modernos existentes**

Para inspeccionar una presentación existente, verifica cuáles comentarios son instancias de [ModernComment](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/), luego examina [ModernComment.getShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#getTextSelectionLength) y [ModernComment.getStatus](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#getStatus). Una forma `None` indica un comentario a nivel de diapositiva. Para un ancla de [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/), los métodos de selección de texto identifican el rango asociado en el marco de texto de la forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **Eliminar comentarios**

### **Eliminar todos los comentarios y autores de comentarios**

El siguiente ejemplo muestra cómo eliminar todos los comentarios y autores de comentarios de una presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Eliminar comentarios específicos**

El siguiente ejemplo muestra cómo eliminar comentarios específicos de una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado Resuelto para los comentarios modernos?**

Sí. [ModernComment.getStatus](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#getStatus) y [ModernComment.setStatus](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncomment/#setStatus) acceden a un valor de [ModernCommentStatus](https://reference.aspose.com/slides/es/python-java/aspose.slides/moderncommentstatus/), incluido `Resolved`. El estado se almacena en la presentación y puede leerse de nuevo después de volver a abrir el archivo.

**¿Se admiten discusiones en hilos (cadenas de respuestas) y existe un límite de anidación?**

Sí. Cada comentario puede referenciar su [parent comment](https://reference.aspose.com/slides/es/python-java/aspose.slides/comment/#getParentComment), lo que permite cadenas de respuestas. La API no define un límite específico de profundidad de anidación.

**¿En qué sistema de coordenadas se define la posición del marcador de comentario en una diapositiva?**

La posición del marcador se define mediante coordenadas de punto flotante en el sistema de coordenadas de la diapositiva, lo que permite colocarlo con precisión en la diapositiva.