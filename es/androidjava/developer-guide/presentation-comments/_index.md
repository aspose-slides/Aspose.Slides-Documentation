---
title: Gestionar comentarios de presentaciones en Android
linktitle: Comentarios de la presentación
type: docs
weight: 100
url: /es/androidjava/presentation-comments/
keywords:
- comentario
- comentario moderno
- comentarios de PowerPoint
- comentarios de presentación
- comentarios de diapositiva
- agregar comentario
- acceder al comentario
- editar comentario
- responder comentario
- eliminar comentario
- borrar comentario
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Domina los comentarios de presentaciones con Aspose.Slides para Android vía Java: agrega, lee, edita y elimina comentarios en archivos PowerPoint de forma rápida y sencilla."
---

En PowerPoint, un comentario aparece como una nota o anotación en una diapositiva. Cuando se hace clic en un comentario, se revelan sus contenidos o mensajes. 

### **¿Por qué agregar comentarios a las presentaciones?**

Puede que desee usar comentarios para proporcionar retroalimentación o comunicarse con sus colegas al revisar presentaciones.

Para permitirle usar comentarios en presentaciones de PowerPoint, Aspose.Slides para Android a través de Java proporciona

* La clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), que contiene las colecciones de autores (de la interfaz [ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection)). Los autores añaden comentarios a las diapositivas.
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection), que contiene la colección de comentarios para autores individuales.
* La clase [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment), que contiene información sobre los autores y sus comentarios: quién añadió el comentario, la hora en que se añadió, la posición del comentario, etc.
* La clase [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor), que contiene información sobre autores individuales: el nombre del autor, sus iniciales, los comentarios asociados al nombre del autor, etc.

## **Agregar un comentario a una diapositiva**
Este código Java le muestra cómo agregar un comentario a una diapositiva en una presentación de PowerPoint:
```java
// Instancia la clase Presentation
Presentation pres = new Presentation();
try {
    // Agrega una diapositiva vacía
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Agrega un autor
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Establece la posición para los comentarios
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Agrega un comentario de diapositiva para un autor en la diapositiva 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Agrega un comentario de diapositiva para un autor en la diapositiva 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Accede a ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Cuando se pasa null como argumento, los comentarios de todos los autores se traen a la diapositiva seleccionada
    IComment[] Comments = slide.getSlideComments(author);

    // Accede al comentario en el índice 0 para la diapositiva 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Selecciona la colección de comentarios del autor en el índice 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Acceder a los comentarios de la diapositiva**
Este código Java le muestra cómo acceder a un comentario existente en una diapositiva de una presentación de PowerPoint:
```java
// Instancia la clase Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Responder a los comentarios**

Un comentario principal es el comentario superior u original en una jerarquía de comentarios o respuestas. Usando los métodos [getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--) o [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (de la interfaz [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)), puede establecer u obtener un comentario principal.

Este código Java le muestra cómo agregar comentarios y obtener respuestas a ellos:
```java
Presentation pres = new Presentation();
try {
    // Añade un comentario
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Añade una respuesta a comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Añade otra respuesta a comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Añade una respuesta a una respuesta existente
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Muestra la jerarquía de comentarios en la consola
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // Elimina comment1 y todas sus respuestas
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" title="Atención" %}} 

* Cuando se usa el método [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--) (de la interfaz [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)) para eliminar un comentario, también se eliminan las respuestas al comentario.
* Si la configuración [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) genera una referencia circular, se lanzará [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

## **Agregar un comentario moderno**

En 2021, Microsoft introdujo los *comentarios modernos* en PowerPoint. La característica de comentarios modernos mejora significativamente la colaboración en PowerPoint. A través de los comentarios modernos, los usuarios de PowerPoint pueden resolver comentarios, anclar comentarios a objetos y textos, y participar en interacciones mucho más fácilmente que antes. 

En [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-11-release-notes/), implementamos soporte para comentarios modernos añadiendo la clase [ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment). Se añadieron los métodos [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) y [insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) a la clase [CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection).

Este código Java le muestra cómo agregar un comentario moderno a una diapositiva en una presentación de PowerPoint: 
```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eliminar un comentario**

### **Eliminar todos los comentarios y autores**

Este código Java le muestra cómo eliminar todos los comentarios y autores en una presentación:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Elimina todos los comentarios de la presentación
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Elimina todos los autores
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


### **Eliminar comentarios específicos**

Este código Java le muestra cómo eliminar comentarios específicos en una diapositiva:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // agregar comentarios...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // eliminar todos los comentarios que contengan el texto "comment 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado como 'resuelto' para los comentarios modernos?**

Sí. Los [comentarios modernos](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/) exponen un método [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-); puede escribir el [estado del comentario](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) (por ejemplo, marcarlo como resuelto), y este estado se guarda en el archivo y es reconocido por PowerPoint.

**¿Se admiten discusiones en hilos (cadenas de respuestas) y hay un límite de anidamiento?**

Sí. Cada comentario puede referenciar su [comentario padre](https://reference.aspose.com/slides/androidjava/com.aspose.slides/comment/#getParentComment--), lo que permite cadenas de respuestas arbitrarias. La API no declara un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de comentario en una diapositiva?**

La posición se almacena como un punto de coma flotante en el sistema de coordenadas de la diapositiva. Esto le permite colocar el marcador de comentario con precisión donde lo necesite.