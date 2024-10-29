---
title: Comentarios de Presentación
type: docs
weight: 100
url: /es/php-java/presentation-comments/
keywords: "Comentarios, comentarios de PowerPoint, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Agrega comentarios y respuestas en la presentación de PowerPoint"
---

En PowerPoint, un comentario aparece como una nota o anotación en una diapositiva. Cuando se hace clic en un comentario, se revelan su contenido o mensajes.

### **¿Por qué agregar comentarios a las presentaciones?**

Es posible que desee usar comentarios para proporcionar retroalimentación o comunicarse con sus colegas al revisar presentaciones.

Para permitirle usar comentarios en las presentaciones de PowerPoint, Aspose.Slides para PHP a través de Java proporciona

* La clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), que contiene las colecciones de autores (de la interfaz [ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection)). Los autores añaden comentarios a las diapositivas.
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection), que contiene la colección de comentarios para autores individuales.
* La clase [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment), que contiene información sobre los autores y sus comentarios: quién añadió el comentario, la hora en que se añadió el comentario, la posición del comentario, etc.
* La clase [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor), que contiene información sobre autores individuales: el nombre del autor, sus iniciales, comentarios asociados con el nombre del autor, etc.

## **Agregar comentario a la diapositiva**
Este código PHP le muestra cómo agregar un comentario a una diapositiva en una presentación de PowerPoint:

```php
  # Instancia la clase Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Agrega una diapositiva vacía
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Agrega un autor
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Establece la posición para los comentarios
    $point = new Point2DFloat(0.2, 0.2);
    # Agrega comentario de diapositiva para un autor en la diapositiva 1
    $author->getComments()->addComment("Hola Jawad, este es un comentario de diapositiva", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Agrega comentario de diapositiva para un autor en la diapositiva 2
    $author->getComments()->addComment("Hola Jawad, este es el segundo comentario de diapositiva", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Accede a la diapositiva ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Cuando se pasa null como argumento, se traen los comentarios de todos los autores a la diapositiva seleccionada
    $Comments = $slide->getSlideComments($author);
    # Accede al comentario en el índice 0 para la diapositiva 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Selecciona la colección de comentarios del Autor en el índice 0
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
Este código PHP le muestra cómo acceder a un comentario existente en una diapositiva en una presentación de PowerPoint:

```php
  # Instancia la clase Presentation
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " tiene el comentario: " . $comment->getText() . " con Autor: " . $comment->getAuthor()->getName() . " publicado a la hora :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Responder comentarios**
Un comentario padre es el comentario original o superior en una jerarquía de comentarios o respuestas. Usando los métodos [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--) o [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (de la interfaz [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment)), puede establecer o obtener un comentario padre.

Este código PHP le muestra cómo agregar comentarios y obtener respuestas a ellos:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Agrega un comentario
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comentario1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Agrega una respuesta al comentario1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autor_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("respuesta 1 para comentario 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Agrega otra respuesta al comentario1
    $reply2 = $author2->getComments()->addComment("respuesta 2 para comentario 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Agrega una respuesta a una respuesta existente
    $subReply = $author1->getComments()->addComment("subrespuesta 3 para respuesta 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comentario 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comentario 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("respuesta 4 para comentario 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
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
    # Elimina comentario1 y todas las respuestas a él
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Atención" %}} 

* Cuando se utiliza el método [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--) (de la interfaz [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) para eliminar un comentario, las respuestas al comentario también se eliminan.
* Si la configuración [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) resulta en una referencia circular, se lanzará [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **Agregar comentario moderno**

En 2021, Microsoft introdujo *comentarios modernos* en PowerPoint. La función de comentarios modernos mejora significativamente la colaboración en PowerPoint. A través de los comentarios modernos, los usuarios de PowerPoint pueden resolver comentarios, anclar comentarios a objetos y textos, y participar en interacciones de manera mucho más fácil que antes. 

En [Aspose Slides para Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/), implementamos soporte para comentarios modernos al agregar la clase [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment). Se añadieron los métodos [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) y [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) a la clase [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection).

Este código PHP le muestra cómo agregar un comentario moderno a una diapositiva en una presentación de PowerPoint:

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Algún Autor", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("Este es un comentario moderno", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Eliminar comentario**

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
    $author = $presentation->getCommentAuthors()->addAuthor("Autor", "A");
    $author->getComments()->addComment("comentario 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comentario 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # elimina todos los comentarios que contienen el texto "comentario 1"
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comentario 1")) {
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