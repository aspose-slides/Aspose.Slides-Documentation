---
title: Gestionar comentarios de presentación en PHP
linktitle: Comentarios de presentación
type: docs
weight: 100
url: /es/php-java/presentation-comments/
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
- PHP
- Aspose.Slides
description: "Domine los comentarios de presentaciones con Aspose.Slides para PHP a través de Java: añada, lea, edite y elimine comentarios en archivos PowerPoint de forma rápida y sencilla."
---

En PowerPoint, un comentario aparece como una nota o anotación en una diapositiva. Al hacer clic en un comentario, se revelan sus contenidos o mensajes. 

## **¿Por qué añadir comentarios a las presentaciones?**

Puede que desee usar los comentarios para ofrecer retroalimentación o comunicarse con sus colegas al revisar presentaciones.

Para permitirle usar comentarios en presentaciones de PowerPoint, Aspose.Slides para PHP a través de Java proporciona

* La clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) que contiene las colecciones de autores (de la clase [CommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/)). Los autores añaden comentarios a las diapositivas.
* La clase [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) que contiene la colección de comentarios de autores individuales.
* La clase [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) que contiene información sobre los autores y sus comentarios: quién añadió el comentario, la hora en que se añadió, la posición del comentario, etc.
* La clase [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) que contiene información sobre autores individuales: el nombre del autor, sus iniciales, los comentarios asociados al nombre del autor, etc.

## **Añadir comentarios a diapositivas**
Este código PHP le muestra cómo añadir un comentario a una diapositiva en una presentación de PowerPoint:
```php
  # Instancia la clase Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Añade una diapositiva vacía
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Añade un autor
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Establece la posición de los comentarios
    $point = new Point2DFloat(0.2, 0.2);
    # Añade un comentario de diapositiva para un autor en la diapositiva 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Añade un comentario de diapositiva para un autor en la diapositiva 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Accede a ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Cuando se pasa null como argumento, se traen los comentarios de todos los autores a la diapositiva seleccionada
    $Comments = $slide->getSlideComments($author);
    # Accesses the comment at index 0 for slide 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Selecciona la colección de comentarios del autor en el índice 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Acceder a los comentarios de diapositivas**
Este código PHP le muestra cómo acceder a un comentario existente en una diapositiva de una presentación de PowerPoint:
```php
  # Instancia la clase Presentation
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " has comment: " . $comment->getText() . " with Author: " . $comment->getAuthor()->getName() . " posted on time :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Responder a comentarios**
Un comentario padre es el comentario superior u original en una jerarquía de comentarios o respuestas. Usando los métodos [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) o [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) (de la clase [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/)), puede establecer o obtener un comentario padre.

Este código PHP le muestra cómo añadir comentarios y obtener sus respuestas:
```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Añade un comentario
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Añade una respuesta al comentario1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Añade otra respuesta al comentario1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Añade una respuesta a una respuesta existente
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Muestra la jerarquía de comentarios en la consola
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)) ; $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # Elimina el comentario1 y todas sus respuestas
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" title="Attention" %}} 

* Cuando se usa el método [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) (de la clase [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/)) para eliminar un comentario, también se eliminan las respuestas al comentario.
* Si la configuración [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) produce una referencia circular, se lanzará una [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/).

{{% /alert %}}

## **Añadir comentarios modernos**

En 2021, Microsoft introdujo los *comentarios modernos* en PowerPoint. La función de comentarios modernos mejora significativamente la colaboración en PowerPoint. A través de los comentarios modernos, los usuarios de PowerPoint pueden resolver comentarios, anclar comentarios a objetos y textos, y participar en interacciones de forma mucho más fácil que antes. 

Aspose Slides admite comentarios modernos mediante la clase [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/). Se añadieron los métodos [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) e [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/insertmoderncomment/) a la clase [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/).

Este código PHP le muestra cómo añadir un comentario moderno a una diapositiva en una presentación de PowerPoint:
```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eliminar comentarios**

### **Eliminar todos los comentarios y autores**
Este código PHP le muestra cómo eliminar todos los comentarios y autores en una presentación:
```php
  $presentation = new Presentation("example.pptx");
  try {
    # Elimina todos los comentarios de la presentación
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Elimina todos los autores
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


### **Eliminar comentarios específicos**
Este código PHP le muestra cómo eliminar comentarios específicos en una diapositiva:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # añadir comentarios...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # eliminar todos los comentarios que contengan el texto "comment 1"
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comment 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado como 'resuelto' para los comentarios modernos?**

Sí. Los [comentarios modernos](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) exponen un método [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/); puede establecer el [estado del comentario](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) (por ejemplo, marcarlo como resuelto), y este estado se guarda en el archivo y es reconocido por PowerPoint.

**¿Se admiten discusiones en hilo (cadenas de respuestas) y existe un límite de anidamiento?**

Sí. Cada comentario puede referenciar su [comentario padre](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), lo que permite cadenas de respuestas arbitrarias. La API no declara un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de comentario en una diapositiva?**

La posición se almacena como un punto de coma flotante en el sistema de coordenadas de la diapositiva. Esto le permite colocar el marcador de comentario exactamente donde lo necesite.