---
title: Administrar comentarios de presentación en PHP
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
- agregar comentario
- acceder al comentario
- editar comentario
- responder comentario
- eliminar comentario
- borrar comentario
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Domina los comentarios de presentación con Aspose.Slides para PHP a través de Java: agrega, lee, edita y elimina comentarios en archivos de PowerPoint de forma rápida y sencilla."
---

En PowerPoint, un comentario aparece como una nota o anotación en una diapositiva. Cuando se hace clic en un comentario, su contenido o mensajes se revelan. 

## **¿Por qué agregar comentarios a las presentaciones?**

Es posible que desee usar comentarios para proporcionar retroalimentación o comunicarse con sus colegas al revisar presentaciones.

Para permitirle usar comentarios en presentaciones de PowerPoint, Aspose.Slides para PHP a través de Java proporciona

* La clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), que contiene las colecciones de autores (de la interfaz [ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection)). Los autores añaden comentarios a las diapositivas.
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection), que contiene la colección de comentarios para autores individuales.
* La clase [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment), que contiene información sobre los autores y sus comentarios: quién añadió el comentario, la hora en que se añadió, la posición del comentario, etc.
* La clase [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor), que contiene información sobre autores individuales: el nombre del autor, sus iniciales, los comentarios asociados al nombre del autor, etc.

## **Agregar comentarios a diapositivas**
Este código PHP le muestra cómo agregar un comentario a una diapositiva en una presentación de PowerPoint:
```php
  # Instancia la clase Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Añade una diapositiva vacía
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Añade un autor
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Establece la posición para los comentarios
    $point = new Point2DFloat(0.2, 0.2);
    # Añade un comentario de diapositiva para un autor en la diapositiva 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Añade un comentario de diapositiva para un autor en la diapositiva 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Accede a ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Cuando se pasa null como argumento, se traen los comentarios de todos los autores a la diapositiva seleccionada
    $Comments = $slide->getSlideComments($author);
    # Accede al comentario en el índice 0 para la diapositiva 1
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


## **Acceder a los comentarios de la diapositiva**
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


## **Responder a los comentarios**
Un comentario padre es el comentario principal u original en una jerarquía de comentarios o respuestas. Usando los métodos [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--) o [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (de la interfaz [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)), puede establecer u obtener un comentario padre.

Este código PHP le muestra cómo agregar comentarios y obtener respuestas a ellos:
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


{{% alert color="warning" title="Atención" %}} 

* Cuando se utiliza el método [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--) (de la interfaz [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)) para eliminar un comentario, también se eliminan las respuestas al comentario.
* Si la configuración del método [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) produce una referencia circular, se lanzará una [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **Agregar comentarios modernos**

En 2021, Microsoft introdujo los *comentarios modernos* en PowerPoint. La función de comentarios modernos mejora significativamente la colaboración en PowerPoint. A través de los comentarios modernos, los usuarios de PowerPoint pueden resolver comentarios, anclar comentarios a objetos y textos, y participar en interacciones mucho más fácilmente que antes. 

En [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/), implementamos soporte para comentarios modernos añadiendo la clase [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment). Se añadieron los métodos [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) y [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) a la clase [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection).

Este código PHP le muestra cómo agregar un comentario moderno a una diapositiva en una presentación de PowerPoint:
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
    # agregar comentarios...
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

**¿Se admiten discusiones en hilo (cadenas de respuestas) y existe un límite de anidación?**

Sí. Cada comentario puede referenciar su [comentario padre](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), lo que permite cadenas de respuestas arbitrarias. La API no declara un límite específico de profundidad de anidación.

**¿En qué sistema de coordenadas se define la posición del marcador de comentario en una diapositiva?**

La posición se almacena como un punto de punto flotante en el sistema de coordenadas de la diapositiva. Esto le permite colocar el marcador de comentario exactamente donde lo necesite.