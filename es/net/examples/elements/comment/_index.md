---
title: Comentario
type: docs
weight: 230
url: /es/net/examples/elements/comment/
keywords:
- ejemplo de comentario
- comentario moderno
- agregar comentario
- acceder comentario
- eliminar comentario
- responder al comentario
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Administra los comentarios de diapositivas en C# con Aspose.Slides: agrega, lee, responde, edita, elimina y trabaja con comentarios en hilos para PowerPoint y OpenDocument."
---

Demuestra cómo agregar, leer, eliminar y responder a comentarios modernos usando **Aspose.Slides for .NET**.

## **Agregar un comentario moderno**
Cree un comentario creado por un usuario y guarde la presentación.
```csharp
static void Add_Modern_Comment()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var author = pres.CommentAuthors.AddAuthor("User", "U1");
    author.Comments.AddModernComment("This is a modern comment", slide, null, new PointF(100, 100), DateTime.Now);

    pres.Save("modern_comment.pptx", SaveFormat.Pptx);
}
```


## **Acceder a un comentario moderno**
Lea un comentario moderno de una presentación existente.
```csharp
static void Access_Modern_Comment()
{
    using var pres = new Presentation("modern_comment.pptx");
    var author = pres.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```


## **Eliminar un comentario moderno**
Elimine un comentario y guarde el archivo actualizado.
```csharp
static void Remove_Modern_Comment()
{
    using var pres = new Presentation("modern_comment.pptx");
    var author = pres.CommentAuthors[0];

    var comment = author.Comments[0];
    comment.Remove();

    pres.Save("modern_comment_removed.pptx", SaveFormat.Pptx);
}
```


## **Responder a un comentario moderno**
Agregue respuestas a un comentario moderno principal.
```csharp
static void Reply_To_Modern_Comment()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var author = pres.CommentAuthors.AddAuthor("User", "U1");

    var parent = author.Comments.AddModernComment("Parent comment", slide, null, new PointF(100, 100), DateTime.Now);
    var reply1 = author.Comments.AddModernComment("Reply 1", slide, null, new PointF(110, 100), DateTime.Now);
    var reply2 = author.Comments.AddModernComment("Reply 2", slide, null, new PointF(120, 100), DateTime.Now);

    reply1.ParentComment = parent;
    reply2.ParentComment = parent;

    pres.Save("modern_comment_replies.pptx", SaveFormat.Pptx);
}
```
