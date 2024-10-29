---
title: Präsentationskommentare
type: docs
weight: 100
url: /de/php-java/presentation-comments/
keywords: "Kommentare, PowerPoint-Kommentare, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Kommentare und Antworten in PowerPoint-Präsentation hinzufügen"
---

In PowerPoint erscheint ein Kommentar als Notiz oder Anmerkung auf einer Folie. Wenn auf einen Kommentar geklickt wird, werden dessen Inhalte oder Nachrichten angezeigt.

### **Warum Kommentare zu Präsentationen hinzufügen?**

Sie möchten möglicherweise Kommentare verwenden, um Feedback zu geben oder mit Ihren Kollegen zu kommunizieren, wenn Sie Präsentationen überprüfen.

Um Ihnen die Verwendung von Kommentaren in PowerPoint-Präsentationen zu ermöglichen, bietet Aspose.Slides für PHP über Java 

* Die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse, die die Sammlungen von Autoren (aus der [ICommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentAuthorCollection) Schnittstelle) enthält. Die Autoren fügen den Folien Kommentare hinzu.
* Die [ICommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICommentCollection) Schnittstelle, die die Sammlung von Kommentaren für einzelne Autoren enthält.
* Die [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) Klasse, die Informationen über Autoren und deren Kommentare enthält: wer den Kommentar hinzugefügt hat, wann der Kommentar hinzugefügt wurde, die Position des Kommentars usw.
* Die [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/CommentAuthor) Klasse, die Informationen über einzelne Autoren enthält: den Namen des Autors, seine Initialen, Kommentare, die mit dem Namen des Autors verknüpft sind, usw.

## **Kommentar zur Folie hinzufügen**
Dieser PHP-Code zeigt Ihnen, wie Sie einen Kommentar zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

```php
  # Instanziiert die Presentation-Klasse
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Fügt eine leere Folie hinzu
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Fügt einen Autor hinzu
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Setzt die Position für Kommentare
    $point = new Point2DFloat(0.2, 0.2);
    # Fügt einen Folienkommentar für einen Autor auf Folie 1 hinzu
    $author->getComments()->addComment("Hallo Jawad, dies ist ein Folienkommentar", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Fügt einen Folienkommentar für einen Autor auf Folie 2 hinzu
    $author->getComments()->addComment("Hallo Jawad, dies ist der zweite Folienkommentar", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Greift auf ISlide 1 zu
    $slide = $pres->getSlides()->get_Item(0);
    # Wenn null als Argument übergeben wird, werden die Kommentare aller Autoren zur ausgewählten Folie gebracht
    $Comments = $slide->getSlideComments($author);
    # Greift auf den Kommentar an Index 0 für Folie 1 zu
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Wählt die Kommentar-Sammlung des Autors an Index 0 aus
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zugriff auf Folienkommentare**
Dieser PHP-Code zeigt Ihnen, wie Sie auf einen vorhandenen Kommentar auf einer Folie in einer PowerPoint-Präsentation zugreifen:

```php
  # Instanziiert die Presentation-Klasse
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " hat Kommentar: " . $comment->getText() . " mit Autor: " . $comment->getAuthor()->getName() . " gepostet um: " . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Antworten auf Kommentare**
Ein übergeordneter Kommentar ist der oberste oder ursprüngliche Kommentar in einer Hierarchie von Kommentaren oder Antworten. Mit den Methoden [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#getParentComment--) oder [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (aus der [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) Schnittstelle) können Sie einen übergeordneten Kommentar festlegen oder abrufen.

Dieser PHP-Code zeigt Ihnen, wie Sie Kommentare hinzufügen und Antworten darauf erhalten:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Fügt einen Kommentar hinzu
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("Kommentar 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Fügt eine Antwort zu Kommentar 1 hinzu
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("Antwort 1 für Kommentar 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Fügt eine weitere Antwort zu Kommentar 1 hinzu
    $reply2 = $author2->getComments()->addComment("Antwort 2 für Kommentar 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Fügt eine Antwort auf eine vorhandene Antwort hinzu
    $subReply = $author1->getComments()->addComment("Unterantwort 3 für Antwort 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("Kommentar 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("Kommentar 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("Antwort 4 für Kommentar 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Zeigt die Kommentahierarchie auf der Konsole an
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
    # Entfernt Kommentar 1 und alle Antworten darauf
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Achtung" %}} 

* Wenn die [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#remove--) Methode (aus der [IComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment) Schnittstelle) verwendet wird, um einen Kommentar zu löschen, werden auch die Antworten auf den Kommentar gelöscht.
* Wenn die [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) Einstellung zu einer zirkulären Referenz führt, wird eine [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

## **Modernen Kommentar hinzufügen**

Im Jahr 2021 führte Microsoft *moderne Kommentare* in PowerPoint ein. Die Funktion der modernen Kommentare verbessert die Zusammenarbeit in PowerPoint erheblich. Durch moderne Kommentare können PowerPoint-Benutzer Kommentare lösen, Kommentare an Objekte und Texte anheften und viel einfacher interagieren als zuvor.

In [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-11-release-notes/) haben wir die Unterstützung für moderne Kommentare implementiert, indem wir die [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/ModernComment) Klasse hinzugefügt haben. Die Methoden [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) und [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2DFloat-java.util.Date-) wurden zur [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/CommentCollection) Klasse hinzugefügt.

Dieser PHP-Code zeigt Ihnen, wie Sie einen modernen Kommentar zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Ein Autor", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("Dies ist ein moderner Kommentar", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kommentar entfernen**

### **Alle Kommentare und Autoren löschen**

Dieser PHP-Code zeigt Ihnen, wie Sie alle Kommentare und Autoren in einer Präsentation entfernen:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Löscht alle Kommentare aus der Präsentation
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Löscht alle Autoren
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Bestimmte Kommentare löschen**

Dieser PHP-Code zeigt Ihnen, wie Sie spezifische Kommentare auf einer Folie löschen:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Kommentare hinzufügen...
    $author = $presentation->getCommentAuthors()->addAuthor("Autor", "A");
    $author->getComments()->addComment("Kommentar 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("Kommentar 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # Entfernt alle Kommentare, die den Text "Kommentar 1" enthalten
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("Kommentar 1")) {
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