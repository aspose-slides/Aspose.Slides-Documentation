---
title: Comentarios de Presentación
type: docs
weight: 100
url: /es/androidjava/presentation-comments/
keywords: "Comentarios, comentarios de PowerPoint, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Agregar comentarios y respuestas en la presentación de PowerPoint en Java"
---

En PowerPoint, un comentario aparece como una nota o anotación en una diapositiva. Al hacer clic en un comentario, se revelan su contenido o mensajes.

### **¿Por qué agregar comentarios a las presentaciones?**

Es posible que desee utilizar comentarios para proporcionar retroalimentación o comunicarse con sus colegas al revisar presentaciones.

Para permitirle utilizar comentarios en presentaciones de PowerPoint, Aspose.Slides para Android a través de Java proporciona

* La clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), que contiene las colecciones de autores (de la interfaz [ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection)). Los autores agregan comentarios a las diapositivas.
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection), que contiene la colección de comentarios para autores individuales.
* La clase [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment), que contiene información sobre los autores y sus comentarios: quién agregó el comentario, la hora en que se agregó el comentario, la posición del comentario, etc.
* La clase [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor), que contiene información sobre autores individuales: el nombre del autor, sus iniciales, comentarios asociados con el nombre del autor, etc.

## **Agregar Comentario a la Diapositiva**
Este código Java te muestra cómo agregar un comentario a una diapositiva en una presentación de PowerPoint:

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

    // Agrega un comentario a la diapositiva para un autor en la diapositiva 1
    author.getComments().addComment("Hola Jawad, este es un comentario de diapositiva", pres.getSlides().get_Item(0), point, new Date());

    // Agrega un comentario a la diapositiva para un autor en la diapositiva 2
    author.getComments().addComment("Hola Jawad, este es el segundo comentario de diapositiva", pres.getSlides().get_Item(1), point, new Date());

    // Accede a la ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Cuando se pasa nulo como argumento, se traen comentarios de todos los autores a la diapositiva seleccionada
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

## **Acceder a Comentarios de la Diapositiva**
Este código Java te muestra cómo acceder a un comentario existente en una diapositiva en una presentación de PowerPoint:

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
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " tiene comentario: " + comment.getText() +
                    " con Autor: " + comment.getAuthor().getName() + " publicado a la hora :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Responder Comentarios**
Un comentario padre es el comentario principal o original en una jerarquía de comentarios o respuestas. Utilizando los métodos [getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--) o [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (de la interfaz [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)), puedes establecer o obtener un comentario padre.

Este código Java te muestra cómo agregar comentarios y obtener respuestas a ellos:

```java
Presentation pres = new Presentation();
try {
    // Agrega un comentario
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comentario1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Agrega una respuesta al comentario1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("respuesta 1 para el comentario 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Agrega otra respuesta al comentario1
    IComment reply2 = author2.getComments().addComment("respuesta 2 para el comentario 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Agrega una respuesta a una respuesta existente
    IComment subReply = author1.getComments().addComment("subrespuesta 3 para respuesta 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comentario 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comentario 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("respuesta 4 para el comentario 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
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

    // Elimina comment1 y todas las respuestas a él
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Atención" %}} 

* Cuando se utiliza el método [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--) (de la interfaz [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)) para eliminar un comentario, las respuestas al comentario también se eliminan.
* Si la configuración de [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) resulta en una referencia circular, se lanzará [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

## **Agregar Comentario Moderno**

En 2021, Microsoft introdujo *comentarios modernos* en PowerPoint. La función de comentarios modernos mejora significativamente la colaboración en PowerPoint. A través de los comentarios modernos, los usuarios de PowerPoint pueden resolver comentarios, anclar comentarios a objetos y textos, y participar en interacciones mucho más fácilmente que antes. 

En [Aspose Slides para Java 21.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-11-release-notes/), implementamos soporte para comentarios modernos al agregar la clase [ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment). Se añadieron los métodos [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) y [insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) a la clase [CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection).

Este código Java te muestra cómo agregar un comentario moderno a una diapositiva en una presentación de PowerPoint: 

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Algún Autor", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("Este es un comentario moderno", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eliminar Comentario**

### **Eliminar Todos los Comentarios y Autores**

Este código Java te muestra cómo eliminar todos los comentarios y autores en una presentación:

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

### **Eliminar Comentarios Específicos**

Este código Java te muestra cómo eliminar comentarios específicos en una diapositiva:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // agrega comentarios...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comentario 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comentario 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // elimina todos los comentarios que contienen el texto "comentario 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comentario 1"))
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