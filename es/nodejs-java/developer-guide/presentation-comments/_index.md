---
title: Gestionar comentarios de presentaciones en JavaScript
linktitle: Comentarios de presentación
type: docs
weight: 100
url: /es/nodejs-java/presentation-comments/
keywords:
- comentario
- comentario moderno
- comentarios de PowerPoint
- comentarios de presentación
- comentarios de diapositiva
- añadir comentario
- acceder comentario
- editar comentario
- responder comentario
- eliminar comentario
- borrar comentario
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Domina los comentarios de presentaciones con Aspose.Slides para Node.js: agrega, lee, edita y elimina comentarios en archivos PowerPoint usando JavaScript de forma rápida y sencilla."
---

En PowerPoint, un comentario aparece como una nota o anotación en una diapositiva. Cuando se hace clic en un comentario, se revelan sus contenidos o mensajes. 

## **¿Por qué añadir comentarios a las presentaciones?**

Puede que desee usar los comentarios para proporcionar retroalimentación o comunicarse con sus colegas al revisar presentaciones.

Para permitirle usar comentarios en presentaciones de PowerPoint, Aspose.Slides para Node.js a través de Java ofrece

* La [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) clase, que contiene las colecciones de autores (de la clase [CommentAuthorCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthorCollection)). Los autores añaden comentarios a las diapositivas.
* La [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection) clase, que contiene la colección de comentarios para autores individuales.
* La [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) clase, que contiene información sobre los autores y sus comentarios: quién añadió el comentario, la hora en que se añadió, la posición del comentario, etc.
* La [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthor) clase, que contiene información sobre autores individuales: el nombre del autor, sus iniciales, los comentarios asociados al nombre del autor, etc.

## **Añadir comentario a la diapositiva**
Este código JavaScript le muestra cómo añadir un comentario a una diapositiva en una presentación de PowerPoint:
```javascript
// Instancia la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Añade una diapositiva vacía
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Añade un autor
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Establece la posición de los comentarios
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Añade un comentario a la diapositiva para un autor en la diapositiva 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Añade un comentario a la diapositiva para un autor en la diapositiva 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Accede a ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // Cuando se pasa null como argumento, se traen los comentarios de todos los autores a la diapositiva seleccionada
    var Comments = slide.getSlideComments(author);
    // Accede al comentario en el índice 0 de la diapositiva 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Selecciona la colección de comentarios del autor en el índice 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Acceder a los comentarios de la diapositiva**
Este código JavaScript le muestra cómo acceder a un comentario existente en una diapositiva en una presentación de PowerPoint:
```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Responder a los comentarios**
Un comentario padre es el comentario superior u original en una jerarquía de comentarios o respuestas. Usando los métodos [getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#getParentComment--) o [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (de la clase [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment)), puede establecer o obtener un comentario padre.

Este código JavaScript le muestra cómo añadir comentarios y obtener sus respuestas:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Añade un comentario
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Añade una respuesta al comentario1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Añade otra respuesta al comentario1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Añade una respuesta a una respuesta existente
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Muestra la jerarquía de comentarios en la consola
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // Elimina el comentario1 y todas sus respuestas
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" title="Atención" %}} 

* Cuando se utiliza el método [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#remove--) (de la clase [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment)) para eliminar un comentario, también se eliminan las respuestas al comentario.
* Si la configuración de [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) produce una referencia circular, se lanzará una [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **Añadir comentario moderno**

En 2021, Microsoft introdujo los *comentarios modernos* en PowerPoint. La función de comentarios modernos mejora significativamente la colaboración en PowerPoint. A través de los comentarios modernos, los usuarios de PowerPoint pueden resolver comentarios, anclar comentarios a objetos y textos, y participar en interacciones de forma mucho más sencilla que antes. 

Aspose.Slides admite los comentarios modernos mediante la clase [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ModernComment). Los métodos [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) y [insertModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) se añadieron a la clase [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection).

Este código JavaScript le muestra cómo añadir un comentario moderno a una diapositiva en una presentación de PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Eliminar comentario**

### **Eliminar todos los comentarios y autores**

Este código JavaScript le muestra cómo eliminar todos los comentarios y autores en una presentación:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Elimina todos los comentarios de la presentación
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Elimina todos los autores
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


### **Eliminar comentarios específicos**

Este código JavaScript le muestra cómo eliminar comentarios específicos en una diapositiva:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // añadir comentarios...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // eliminar todos los comentarios que contengan el texto "comment 1"
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado como 'resuelto' para los comentarios modernos?**

Sí. Los [comentarios modernos](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) exponen los métodos [getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) y [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setStatus/); puede leer y establecer el [estado del comentario](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) (por ejemplo, marcarlo como resuelto), y este estado se guarda en el archivo y es reconocido por PowerPoint.

**¿Se admiten discusiones en hilo (cadenas de respuestas) y existe un límite de anidamiento?**

Sí. Cada comentario puede hacer referencia a su [comentario padre](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/), lo que permite cadenas de respuestas arbitrarias. La API no declara un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de comentario en una diapositiva?**

La posición se almacena como un punto de punto flotante en el sistema de coordenadas de la diapositiva. Esto le permite colocar el marcador de comentario exactamente donde lo necesite.