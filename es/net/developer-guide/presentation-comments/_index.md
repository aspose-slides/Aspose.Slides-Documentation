---
title: Administrar comentarios de presentación en .NET
linktitle: Comentarios de presentación
type: docs
weight: 100
url: /es/net/presentation-comments/
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
- .NET
- C#
- Aspose.Slides
description: "Domina los comentarios de presentación con Aspose.Slides para .NET: agrega, lee, edita y elimina comentarios en archivos de PowerPoint de forma rápida y sencilla."
---

En PowerPoint, un comentario aparece como una nota o anotación en una diapositiva. Cuando se hace clic en un comentario, se revelan sus contenidos o mensajes. 

## **¿Por qué agregar comentarios a las presentaciones?**

Puede que desee usar comentarios para proporcionar retroalimentación o comunicarse con sus colegas al revisar presentaciones.

Para permitirle usar comentarios en presentaciones de PowerPoint, Aspose.Slides para .NET ofrece

* La clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contiene las colecciones de autores (de la propiedad [CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index)). Los autores añaden comentarios a las diapositivas. 
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) que contiene la colección de comentarios para autores individuales. 
* La clase [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) que contiene información sobre los autores y sus comentarios: quién agregó el comentario, la hora en que se agregó, la posición del comentario, etc. 
* La clase [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) que contiene información sobre autores individuales: el nombre del autor, sus iniciales, los comentarios asociados al nombre del autor, etc. 

## **Agregar comentarios a diapositivas**
Este código C# le muestra cómo agregar un comentario a una diapositiva en una presentación de PowerPoint:
```c#
// Instancia la clase Presentation
using (Presentation presentation = new Presentation())
{
    // Añade una diapositiva vacía
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Añade un autor
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Establece la posición de los comentarios
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Añade un comentario de diapositiva para un autor en la diapositiva 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Añade un comentario de diapositiva para un autor en la diapositiva 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

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


## **Acceder a los comentarios de diapositivas**
Este código C# le muestra cómo acceder a un comentario existente en una diapositiva de una presentación de PowerPoint:
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
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```


## **Responder a los comentarios**
Un comentario principal es el comentario superior u original en una jerarquía de comentarios o respuestas. Usando la propiedad [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) (de la interfaz [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)), puede establecer u obtener un comentario principal. 

Este código C# le muestra cómo agregar comentarios y obtener sus respuestas:
```c#
using (Presentation pres = new Presentation())
{
    // Añade un comentario
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Añade una respuesta al comentario1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Añade otra respuesta al comentario1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Añade una respuesta a la respuesta existente
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
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

    // Elimina comment1 y todas sus respuestas
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" title="Atención" %}} 

* Cuando se usa el método [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) (de la interfaz [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)) para eliminar un comentario, también se eliminan las respuestas al comentario. 
* Si la configuración [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) produce una referencia circular, se lanzará una [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **Agregar comentarios modernos**

En 2021, Microsoft introdujo *comentarios modernos* en PowerPoint. La función de comentarios modernos mejora significativamente la colaboración en PowerPoint. A través de los comentarios modernos, los usuarios de PowerPoint pueden resolver comentarios, anclar comentarios a objetos y textos, y participar en interacciones de forma mucho más sencilla que antes. 

En [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/), implementamos soporte para comentarios modernos mediante la adición de la clase [ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment). Se agregaron los métodos [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) y [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) a la clase [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection). 

Este código C# le muestra cómo agregar un comentario moderno a una diapositiva en una presentación de PowerPoint: 
```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Eliminar comentarios**

### **Eliminar todos los comentarios y autores**

Este código C# le muestra cómo eliminar todos los comentarios y autores de una presentación:
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


### **Eliminar comentarios específicos**

Este código C# le muestra cómo eliminar comentarios específicos de una diapositiva:
```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // agregar comentarios...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // eliminar todos los comentarios que contengan el texto "comment 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
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


## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado como “resuelto” para los comentarios modernos?**

Sí. Los [comentarios modernos](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/) exponen una propiedad [Status](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/status/); puede leer y establecer el [estado del comentario](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) (por ejemplo, marcarlo como resuelto), y este estado se guarda en el archivo y es reconocido por PowerPoint.

**¿Se admiten discusiones en hilos (cadenas de respuestas) y existe un límite de anidamiento?**

Sí. Cada comentario puede referenciar su [comentario principal](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), lo que permite cadenas de respuestas arbitrarias. La API no declara un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de un comentario en una diapositiva?**

La posición se almacena como un punto de coma flotante en el sistema de coordenadas de la diapositiva. Esto le permite colocar el marcador de comentario exactamente donde lo necesite.