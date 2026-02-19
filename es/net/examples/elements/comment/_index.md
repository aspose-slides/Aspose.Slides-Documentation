---
title: Comentario
type: docs
weight: 230
url: /es/net/examples/elements/comment/
keywords:
- comentario
- comentario moderno
- añadir comentario
- acceder al comentario
- eliminar comentario
- responder al comentario
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con los comentarios de diapositivas en Aspose.Slides for .NET: añada, responda, edite, resuelva y exporte comentarios en presentaciones PPT, PPTX y ODP con ejemplos de código en C#."
---
Este artículo muestra cómo añadir, leer, eliminar y responder a comentarios modernos utilizando **Aspose.Slides for .NET**.

## **Añadir un comentario moderno**

Cree un comentario escrito por un usuario y guarde la presentación.

```csharp
static void AddModernComment()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var author = presentation.CommentAuthors.AddAuthor("User", "U1");
    author.Comments.AddModernComment("This is a modern comment", slide, null, new PointF(100, 100), DateTime.Now);

    presentation.Save("modern_comment.pptx", SaveFormat.Pptx);
}
```

## **Acceder a un comentario moderno**

Lea un comentario moderno de una presentación existente.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Eliminar un comentario moderno**

Elimine un comentario y guarde el archivo actualizado.

```csharp
static void RemoveModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = author.Comments[0];
    comment.Remove();

    presentation.Save("modern_comment_removed.pptx", SaveFormat.Pptx);
}
```

## **Responder a un comentario moderno**

Añada respuestas a un comentario moderno principal.

```csharp
static void ReplyToModernComment()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var author = presentation.CommentAuthors.AddAuthor("User", "U1");

    var parentComment = author.Comments.AddModernComment("Parent comment", slide, null, new PointF(100, 100), DateTime.Now);
    var reply1 = author.Comments.AddModernComment("Reply 1", slide, null, new PointF(110, 100), DateTime.Now);
    var reply2 = author.Comments.AddModernComment("Reply 2", slide, null, new PointF(120, 100), DateTime.Now);

    reply1.ParentComment = parentComment;
    reply2.ParentComment = parentComment;

    presentation.Save("modern_comment_replies.pptx", SaveFormat.Pptx);
}
```