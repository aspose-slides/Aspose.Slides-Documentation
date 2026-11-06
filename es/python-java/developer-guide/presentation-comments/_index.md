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
- agregar comentario
- acceder comentario
- editar comentario
- responder comentario
- eliminar comentario
- borrar comentario
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Gestionar los comentarios de una presentación con Aspose.Slides para Python mediante Java: añadir, leer, editar, responder y eliminar comentarios en presentaciones de PowerPoint de forma rápida y sencilla."
---
## **Visión general**

Este artículo explica cómo administrar los comentarios de una presentación con Aspose.Slides for Python via Java. Presenta los tipos principales relacionados con los comentarios y muestra cómo añadir comentarios a diapositivas, acceder a los comentarios existentes, trabajar con respuestas y comentarios modernos, y eliminar comentarios de una presentación.

Los ejemplos cubren escenarios comunes de revisión y colaboración en PowerPoint, como asignar comentarios a autores, leer el texto y los metadatos de los comentarios, crear cadenas de respuestas y eliminar comentarios seleccionados o todos los comentarios.

En PowerPoint, los comentarios aparecen como anotaciones en las diapositivas. Seleccionar un comentario muestra su texto y la discusión relacionada.

Para solicitar que los comentarios se muestren u oculten al abrir una presentación sin modificar los propios comentarios, consulte [Mostrar u ocultar comentarios al abrir una presentación](/slides/es/python-java/presentation-view-properties/).

## **¿Por qué añadir comentarios a las presentaciones?**

Puede utilizar los comentarios para proporcionar retroalimentación y colaborar con colegas al revisar presentaciones.

Aspose.Slides for Python via Java ofrece las siguientes API para trabajar con comentarios:

* La clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) , que proporciona acceso a los autores de comentarios de la presentación.
* La clase [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) , que representa los comentarios asociados a un autor individual.
* La clase [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) , que brinda información sobre un comentario, incluido su autor, hora de creación, posición y texto.
* La clase [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) , que brinda información sobre un autor, incluido su nombre, iniciales y comentarios asociados.

## **Añadir comentarios a diapositivas**

El ejemplo crea dos diapositivas y registra un autor de comentario con [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor). Utiliza [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) para colocar un comentario en cada diapositiva, y luego recupera los comentarios de la primera diapositiva para ese autor con [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments). La consola muestra el texto del primer comentario dos veces, demostrando el acceso tanto a través de la diapositiva como del autor, y la presentación guardada contiene ambos comentarios.

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

## **Buscar o crear un autor de comentario**

Cuando una revisión automatizada procesa la misma presentación repetidamente, busque en la colección devuelta por [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) antes de añadir un autor. [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) coincide tanto con el nombre como con las iniciales y devuelve una matriz de autores coincidentes, o una matriz vacía si no existen coincidencias. En contraste, [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) busca solo por nombre, independientemente de las iniciales. Llamar a [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) con un nombre e iniciales ya presentes en la colección lanza una excepción.

El ejemplo necesita un archivo de presentación con al menos una diapositiva. En cada una de dos pasadas, reutiliza el primer autor coincidente, o crea uno solo cuando el resultado está vacío. Si hay varias coincidencias, selecciona el primer elemento de la matriz sin combinar ni eliminar los demás autores. Después llama a [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) para el autor seleccionado y guarda la presentación. La segunda pasada abre la salida de la primera pasada y repite la operación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

La segunda pasada añade otro comentario sin añadir otro autor ni eliminar los comentarios existentes. El archivo final, `review_pass_2.pptx`, contiene ambos comentarios nuevos junto con los comentarios originales. Reutilizar un autor no deduplica los comentarios: para evitar añadir repetidamente el mismo comentario, implemente una detección de duplicados separada antes de añadirlo.

## **Acceder a los comentarios de diapositivas**

El ejemplo abre una presentación existente y lee la colección devuelta por [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors). Para cada autor, itera a través de la colección devuelta por [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments) e imprime el número de diapositiva, el texto del comentario, el nombre del autor y la hora de creación. La presentación de entrada debe contener comentarios para producir salida en la consola.

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

Un comentario padre es el comentario original en la parte superior de una jerarquía de respuestas. Los métodos [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) y [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) le permiten obtener o establecer el padre de un comentario.

El ejemplo crea comentarios de dos autores y utiliza [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) para crear respuestas, incluida una respuesta a otra respuesta. Pasar `None` a [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) recupera los comentarios de todos los autores; la consola sangra cada entrada según su profundidad en la jerarquía de respuestas. El ejemplo guarda la discusión completa, llama a [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) sobre el primer comentario raíz y guarda una segunda presentación con ese comentario y sus respuestas eliminados.

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
* Cuando se usa el método [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) para eliminar un comentario, también se eliminan todas las respuestas a ese comentario.
* Si [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) crea una referencia circular, se lanza una [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Añadir comentarios modernos**

Los comentarios modernos pueden asociarse a la propia diapositiva, a una forma específica o a un rango de texto dentro de un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). El método [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) acepta un argumento [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) además de la diapositiva y las coordenadas del marcador del comentario.

Cuando se pasa `None` para el argumento de forma, el comentario es un comentario a nivel de diapositiva. Su marcador se posiciona mediante las coordenadas suministradas, pero no está asociado a una forma concreta, por lo que [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) devuelve `None`. Cuando se proporciona una [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/), el comentario se ancla a esa forma. Las coordenadas siguen definiendo la posición del marcador del comentario en la diapositiva, mientras que la asociación de forma puede recuperarse mediante [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape).

### **Anclar un comentario moderno a una forma**

El ejemplo llama a [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) dos veces: una vez con una forma `None` para un comentario a nivel de diapositiva y una vez con un rectángulo como ancla. Leer [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) imprime `True` para la comprobación `None` del comentario a nivel de diapositiva y `Revenue title` para el comentario anclado. Ambos comentarios se guardan con la presentación.

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

Cualquier objeto de diapositiva que herede de [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) puede usarse como ancla de forma. Los ejemplos más habituales incluyen [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/) y [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) como instancias de gráficos.

El ejemplo usa [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) para asociar un comentario a cada uno de cinco tipos de forma: un AutoShape, un marco de imagen, un grupo, un conector y un gráfico. La imagen utiliza datos de imagen incrustados, por lo que no se requiere una imagen externa. Cada comentario tiene su propia posición de marcador, y la presentación guardada conserva las cinco asociaciones de forma.

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

Para un comentario moderno asociado a un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), los métodos [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) y [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) acceden a la posición inicial del texto seleccionado en el marco de texto de la forma. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) y [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) acceden a la longitud de la selección. Juntos, estos valores asocian el comentario a un rango de texto específico dentro del AutoShape.

Los métodos [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) y [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) acceden a un valor de las constantes [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) :

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — no se ha definido un estado específico para el comentario moderno.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — el comentario está activo.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — el comentario ha sido resuelto.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — el comentario está cerrado.

El ejemplo ancla un comentario moderno a las palabras "quarterly revenue" en el texto de un rectángulo. Calcula el inicio de selección basado en cero a partir del texto y lo pasa a [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) y usa [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) para establecer el número de caracteres seleccionados. Después de llamar a [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) con `Resolved`, guarda y vuelve a abrir la presentación. Las cuatro comprobaciones en consola deben imprimir `True`, confirmando que el ancla de forma, el rango de texto y el estado se conservaron.

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

El ejemplo necesita una presentación existente que contenga comentarios modernos e imprime su texto, estado y detalles de anclaje. Para inspeccionarla, compruebe qué comentarios son instancias de [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/), luego examine [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) y [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus). Una forma `None` indica un comentario a nivel de diapositiva. Para un ancla de [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), los métodos de selección de texto identifican el rango asociado en el marco de texto de la forma.

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

Aspose.Slides for Python via Java le permite eliminar todos los comentarios y sus autores de una presentación o borrar comentarios seleccionados manteniendo el resto. Los ejemplos siguientes demuestran ambos enfoques y guardan la presentación actualizada.

### **Eliminar todos los comentarios y los autores de comentarios**

El ejemplo abre una presentación existente y llama a [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) para cada autor, luego llama a [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) para eliminar a los propios autores. La presentación guardada no contiene ni comentarios ni autores de comentarios. Use una presentación que contenga comentarios para observar la eliminación.

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

El ejemplo crea dos comentarios en una diapositiva y usa [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) para encontrar los comentarios de cada autor. Recopila los comentarios cuyo texto sea igual a "comment 1" antes de llamar a [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove), evitando cambios en la colección durante la selección. La presentación guardada conserva solo "comment 2".

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

**¿Aspose.Slides admite un estado resuelto para los comentarios modernos?**

Sí. [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) y [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) acceden a un valor de [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/), incluido `Resolved`. El estado se almacena en la presentación y puede leerse nuevamente después de volver a abrir el archivo.

**¿Se admiten discusiones en hilos (cadenas de respuestas) y existe un límite de anidamiento?**

Sí. Cada comentario puede hacer referencia a su [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment), lo que permite cadenas de respuestas. La API no define un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de un comentario en una diapositiva?**

La posición del marcador se define mediante coordenadas de punto flotante en el sistema de coordenadas de la diapositiva, lo que permite colocarlo con precisión en la diapositiva.