---
title: Comentario
type: docs
weight: 230
url: /es/python-net/examples/elements/comment/
keywords:
- comentario
- comentario moderno
- añadir comentario
- acceder comentario
- eliminar comentario
- responder comentario
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Gestiona los comentarios de diapositivas en Python con Aspose.Slides: añade, lee, responde, edita, elimina y trabaja con comentarios en cadena para PowerPoint y OpenDocument."
---
Demuestra cómo añadir, leer, eliminar y responder a comentarios modernos usando **Aspose.Slides for Python via .NET**.

## **Agregar un comentario moderno**

Crea un comentario creado por un usuario y guarda la presentación.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Añadir un autor de comentario.
        author = presentation.comment_authors.add_author("User", "U1")

        # Añadir un comentario moderno.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a un comentario moderno**

Lee un comentario moderno de una presentación existente.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Acceder al primer comentario moderno.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Eliminar un comentario moderno**

Elimina un comentario y guarda el archivo actualizado.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Eliminar el comentario.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Responder a un comentario moderno**

Añade respuestas a un comentario moderno principal.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Añadir comentario principal.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Añadir primera respuesta.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Añadir segunda respuesta.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```