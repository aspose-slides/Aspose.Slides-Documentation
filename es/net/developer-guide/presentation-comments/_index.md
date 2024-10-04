---
title: Comentarios de Presentación
type: docs
weight: 100
url: /net/presentation-comments/
keywords: "Comentarios, comentarios de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Añadir comentarios y respuestas en presentaciones de PowerPoint en C# o .NET"
---

En PowerPoint, un comentario aparece como una nota o anotación en una diapositiva. Cuando se hace clic en un comentario, se revelan su contenido o mensajes.

## **¿Por qué añadir comentarios a las presentaciones?**

Es posible que desees utilizar comentarios para proporcionar retroalimentación o comunicarte con tus colegas al revisar presentaciones.

Para permitirte utilizar comentarios en presentaciones de PowerPoint, Aspose.Slides para .NET proporciona

* La clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), que contiene las colecciones de autores (de la propiedad [CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index)). Los autores añaden comentarios a las diapositivas.
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection), que contiene la colección de comentarios para autores individuales.
* La clase [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment), que contiene información sobre los autores y sus comentarios: quién añadió el comentario, la hora en que se añadió el comentario, la posición del comentario, etc.
* La clase [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor), que contiene información sobre autores individuales: el nombre del autor, sus iniciales, comentarios asociados con el nombre del autor, etc.

## **Añadir comentario en la diapositiva**
Este código C# te muestra cómo añadir un comentario a una diapositiva en una presentación de PowerPoint:

```c#
// Instancia la clase Presentation
using (Presentation presentation = new Presentation())
{
    // Añade una diapositiva vacía
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Añade un autor
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Establece la posición para los comentarios
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Añade un comentario en la diapositiva para un autor en la diapositiva 1
    author.Comments.AddComment("Hola Jawad, este es un comentario de la diapositiva", presentation.Slides[0], point, DateTime.Now);

    // Añade un comentario en la diapositiva para un autor en la diapositiva 2
    author.Comments.AddComment("Hola Jawad, este es el segundo comentario de la diapositiva", presentation.Slides[1], point, DateTime.Now);

    // Accede a ISlide 1
    ISlide slide = presentation.Slides[0];

    // Cuando se pasa null como argumento, se traen los comentarios de todos los autores a la diapositiva seleccionada
    IComment[] Comments = slide.GetSlideComments(author);

    // Accede al comentario en el índice 0 para la diapositiva 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Selecciona la colección de comentarios del autor en el índice 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Acceder a los Comentarios de la Diapositiva**
Este código C# te muestra cómo acceder a un comentario existente en una diapositiva en una presentación de PowerPoint:

```c#
// Instancia la clase Presentation
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " tiene el comentario: " + comment.Text + " con Autor: " + comment.Author.Name + " publicado en la hora :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **Responder Comentarios**
Un comentario padre es el comentario principal u original en una jerarquía de comentarios o respuestas. Usando la propiedad [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) (de la interfaz [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)), puedes establecer o obtener un comentario padre.

Este código C# te muestra cómo añadir comentarios y obtener respuestas a ellos:

```c#
using (Presentation pres = new Presentation())
{
    // Añade un comentario
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comentario1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Añade una respuesta al comentario1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("respuesta 1 para el comentario 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Añade otra respuesta al comentario1
    IComment reply2 = author2.Comments.AddComment("respuesta 2 para el comentario 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Añade una respuesta a una respuesta existente
    IComment subReply = author1.Comments.AddComment("subrespuesta 3 para la respuesta 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comentario 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comentario 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("respuesta 4 para el comentario 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Muestra la jerarquía de comentarios en la consola
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // Elimina comment1 y todas las respuestas a él
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Atención" %}} 

* Cuando se utiliza el método [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) (de la interfaz [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)) para eliminar un comentario, las respuestas al comentario también se eliminan.
* Si la configuración de [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) resulta en una referencia circular, se lanzará [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **Añadir Comentario Moderno**

En 2021, Microsoft introdujo *comentarios modernos* en PowerPoint. La función de comentarios modernos mejora significativamente la colaboración en PowerPoint. A través de los comentarios modernos, los usuarios de PowerPoint pueden resolver comentarios, anclar comentarios a objetos y textos, y participar en interacciones de manera mucho más fácil que antes.

En [Aspose Slides para .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/), implementamos soporte para comentarios modernos al agregar la clase [ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment). Se añadieron los métodos [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) y [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) a la clase [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection).

Este código C# te muestra cómo añadir un comentario moderno a una diapositiva en una presentación de PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Algún Autor", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("Este es un comentario moderno", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Eliminar Comentario**

### **Eliminar Todos los Comentarios y Autores**

Este código C# te muestra cómo eliminar todos los comentarios y autores en una presentación:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Elimina todos los comentarios de la presentación
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Elimina todos los autores
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Eliminar Comentarios Específicos**

Este código C# te muestra cómo eliminar comentarios específicos en una diapositiva:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // agregar comentarios...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Autor", "A");
    author.Comments.AddComment("comentario 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comentario 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // eliminar todos los comentarios que contienen el texto "comentario 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comentario 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```