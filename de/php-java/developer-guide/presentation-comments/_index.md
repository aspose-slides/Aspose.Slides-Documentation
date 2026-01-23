---
title: Präsentationskommentare verwalten in PHP
linktitle: Präsentationskommentare
type: docs
weight: 100
url: /de/php-java/presentation-comments/
keywords:
- Kommentar
- moderner Kommentar
- PowerPoint-Kommentare
- Präsentationskommentare
- Folienkommentare
- Kommentar hinzufügen
- Kommentar abrufen
- Kommentar bearbeiten
- Kommentar antworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für PHP via Java: Kommentare in PowerPoint-Dateien schnell und einfach hinzufügen, lesen, bearbeiten und löschen."
---

In PowerPoint erscheint ein Kommentar als Notiz oder Anmerkung auf einer Folie. Wenn ein Kommentar angeklickt wird, werden sein Inhalt oder seine Nachrichten angezeigt. 

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie möchten Kommentare möglicherweise verwenden, um Feedback zu geben oder mit Ihren Kollegen zu kommunizieren, wenn Sie Präsentationen prüfen.

Um Ihnen die Verwendung von Kommentaren in PowerPoint‑Präsentationen zu ermöglichen, stellt Aspose.Slides für PHP über Java bereit

* Die Klasse [Präsentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) enthält die Sammlungen von Autoren (aus der Klasse [CommentAuthorCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/)). Die Autoren fügen Folien Kommentare hinzu.
* Die Klasse [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) enthält die Sammlung von Kommentaren für einzelne Autoren.
* Die Klasse [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) enthält Informationen zu Autoren und deren Kommentaren: wer den Kommentar hinzugefügt hat, wann der Kommentar hinzugefügt wurde, die Position des Kommentars usw.
* Die Klasse [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) enthält Informationen zu einzelnen Autoren: Name des Autors, seine Initialen, dem Autor zugeordnete Kommentare usw.

## **Folienkommentare hinzufügen**
Dieser PHP‑Code zeigt, wie Sie einem Folie in einer PowerPoint‑Präsentation einen Kommentar hinzufügen können:
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
    # Fügt einen Folien-Kommentar für einen Autor auf Folie 1 hinzu
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Fügt einen Folien-Kommentar für einen Autor auf Folie 2 hinzu
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Greift auf ISlide 1 zu
    $slide = $pres->getSlides()->get_Item(0);
    # Wenn null als Argument übergeben wird, werden Kommentare aller Autoren zur ausgewählten Folie gebracht
    $Comments = $slide->getSlideComments($author);
    # Greift auf den Kommentar an Index 0 für Folie 1 zu
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Wählt die Kommentare‑Sammlung des Autors an Index 0 aus
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
Dieser PHP‑Code zeigt, wie Sie auf einen vorhandenen Kommentar einer Folie in einer PowerPoint‑Präsentation zugreifen können:
```php
  # Instanziert die Presentation-Klasse
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


## **Antwortkommentare**
Ein übergeordneter Kommentar ist der oberste bzw. ursprüngliche Kommentar in einer Hierarchie von Kommentaren oder Antworten. Mit den Methoden [getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) bzw. [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) (aus der Klasse [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/)) können Sie einen übergeordneten Kommentar festlegen oder abrufen.

Dieser PHP‑Code zeigt, wie Sie Kommentare hinzufügen und Antworten darauf erhalten:
```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Fügt einen Kommentar hinzu
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Fügt eine Antwort zu comment1 hinzu
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Fügt eine weitere Antwort zu comment1 hinzu
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Fügt eine Antwort zu einer bestehenden Antwort hinzu
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Gibt die Kommentarhierarchie auf der Konsole aus
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
    # Entfernt comment1 und alle dazugehörigen Antworten
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" title="Attention" %}} 

* Wenn die Methode [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) (aus der Klasse [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/)) verwendet wird, um einen Kommentar zu löschen, werden auch die Antworten auf den Kommentar gelöscht.
* Führt die Einstellung [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) zu einer zirkulären Referenz, wird eine [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/) ausgelöst.

{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Im Jahr 2021 hat Microsoft *moderne Kommentare* in PowerPoint eingeführt. Die Funktion moderne Kommentare verbessert die Zusammenarbeit in PowerPoint erheblich. Durch moderne Kommentare können PowerPoint‑Benutzer Kommentare auflösen, Kommentare an Objekte und Texte verankern und viel einfacher interagieren als zuvor. 

Aspose Slides unterstützt moderne Kommentare über die Klasse [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/). Die Methoden [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) und [insertModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/insertmoderncomment/) wurden zur Klasse [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) hinzugefügt.

Dieser PHP‑Code zeigt, wie Sie einem Folie in einer PowerPoint‑Präsentation einen modernen Kommentar hinzufügen:
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


## **Kommentare entfernen**

### **Alle Kommentare und Autoren löschen**

Dieser PHP‑Code zeigt, wie Sie alle Kommentare und Autoren in einer Präsentation entfernen:
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

Dieser PHP‑Code zeigt, wie Sie bestimmte Kommentare einer Folie löschen:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Kommentare hinzufügen...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # Entferne alle Kommentare, die den Text "comment 1" enthalten
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


## **FAQ**

**Unterstützt Aspose.Slides einen Status wie „gelöst“ für moderne Kommentare?**

Ja. [Moderne Kommentare](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) stellen eine Methode [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) bereit; Sie können den Zustand eines Kommentars festlegen (z. B. ihn als gelöst markieren), und dieser Zustand wird in der Datei gespeichert und von PowerPoint erkannt.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt und gibt es eine Begrenzung der Verschachtelungstiefe?**

Ja. Jeder Kommentar kann seinen [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) referenzieren, wodurch beliebig tiefe Antwortketten ermöglicht werden. Die API definiert keine spezifische Begrenzung der Verschachtelungstiefe.

**In welchem Koordinatensystem ist die Position eines Kommentarmarkers auf einer Folie definiert?**

Die Position wird als Gleitkomma‑Punkt in dem Koordinatensystem der Folie gespeichert. Dadurch können Sie den Kommentarmarker genau dort platzieren, wo Sie ihn benötigen.