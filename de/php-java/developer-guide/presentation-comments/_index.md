---
title: Verwalten von Präsentationskommentaren in PHP
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
- Kommentar beantworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für PHP via Java: Kommentare in PowerPoint-Präsentationen schnell und einfach hinzufügen, lesen, bearbeiten, beantworten und entfernen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationskommentare mit Aspose.Slides für PHP via Java verwalten. Er stellt die wichtigsten kommentarbezogenen Typen vor und zeigt, wie Kommentare zu Folien hinzugefügt, vorhandene Kommentare abgerufen, Antworten und moderne Kommentare bearbeitet sowie Kommentare aus einer Präsentation entfernt werden.

Die Beispiele decken gängige Prüfungs‑ und Zusammenarbeitsszenarien in PowerPoint ab, wie das Zuweisen von Kommentaren zu Autoren, das Auslesen von Kommentartext und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter Kommentare oder aller Kommentare.

In PowerPoint erscheinen Kommentare als Anmerkungen auf Folien. Durch Auswählen eines Kommentars werden dessen Text und die zugehörige Diskussion angezeigt.

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und mit Kollegen bei der Durchsicht von Präsentationen zusammenzuarbeiten.

Aspose.Slides für PHP via Java bietet die folgenden APIs für die Arbeit mit Kommentaren:

* Die [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) Klasse, die Zugriff auf die Kommentarautoren der Präsentation bietet.
* Die [CommentCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/commentcollection/) Klasse, die die Kommentare eines einzelnen Autors darstellt.
* Die [Comment](https://reference.aspose.com/slides/de/php-java/aspose.slides/comment/) Klasse, die Informationen über einen Kommentar bereitstellt, einschließlich Autor, Erstellungszeit, Position und Text.
* Die [CommentAuthor](https://reference.aspose.com/slides/de/php-java/aspose.slides/commentauthor/) Klasse, die Informationen über einen Autor liefert, einschließlich Name, Initialen und zugehörige Kommentare.

## **Folienkommentare hinzufügen**

Das folgende Beispiel zeigt, wie Kommentare zu Folien in einer PowerPoint‑Präsentation hinzugefügt werden:

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($presentation->getLayoutSlides()->get_Item(0));
    $author = $presentation->getCommentAuthors()->addAuthor("Jawad", "MF");
    $position = new Point2DFloat(0.2, 0.2);
    $createdTime = new Java("java.util.Date");

    $author->getComments()->addComment("Hello Jawad, this is a slide comment", $firstSlide, $position, $createdTime);
    $author->getComments()->addComment("Hello Jawad, this is the second slide comment", $secondSlide, $position, $createdTime);

    $comments = $firstSlide->getSlideComments($author);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    if ($commentCount > 0) {
        $firstComment = $comments[0];
        echo java_values($firstComment->getText()) . PHP_EOL;

        $authorComments = $firstComment->getAuthor()->getComments();
        $commentText = $authorComments->get_Item(0)->getText();
        echo java_values($commentText) . PHP_EOL;
    }

    $presentation->save("Comments_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Folienkommentare abrufen**

Das folgende Beispiel zeigt, wie vorhandene Kommentare in einer PowerPoint‑Präsentation abgerufen werden:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Comments1.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        foreach ($author->getComments() as $comment) {
            echo "Slide: " . java_values($comment->getSlide()->getSlideNumber()) . PHP_EOL;
            echo "Comment: " . java_values($comment->getText()) . PHP_EOL;
            echo "Author: " . java_values($comment->getAuthor()->getName()) . PHP_EOL;
            echo "Posted at: " . java_values($comment->getCreatedTime()->toString()) . PHP_EOL;
            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Auf Kommentare antworten**

Ein übergeordneter Kommentar ist der ursprüngliche Kommentar an der Spitze einer Antworthierarchie. Die Methoden [Comment::getParentComment](https://reference.aspose.com/slides/de/php-java/aspose.slides/comment/getparentcomment/) und [Comment::setParentComment](https://reference.aspose.com/slides/de/php-java/aspose.slides/comment/setparentcomment/) ermöglichen das Abrufen bzw. Festlegen des übergeordneten Kommentars.

Das folgende Beispiel zeigt, wie Antworten hinzugefügt und die resultierende Kommentarhierarchie untersucht werden:

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $position = new Point2DFloat(10, 10);
    $createdTime = new Java("java.util.Date");

    $author1 = $presentation->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment 1", $slide, $position, $createdTime);

    $author2 = $presentation->getCommentAuthors()->addAuthor("Author_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $slide, $position, $createdTime);
    $reply1->setParentComment($comment1);

    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $slide, $position, $createdTime);
    $reply2->setParentComment($comment1);

    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $slide, $position, $createdTime);
    $subReply->setParentComment($reply2);

    $author2->getComments()->addComment("comment 2", $slide, $position, $createdTime);
    $comment3 = $author2->getComments()->addComment("comment 3", $slide, $position, $createdTime);

    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $slide, $position, $createdTime);
    $reply3->setParentComment($comment3);

    $comments = $slide->getSlideComments(null);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    for ($i = 0; $i < $commentCount; $i++) {
        $comment = $comments[$i];
        while (!java_is_null($comment->getParentComment())) {
            echo "\t";
            $comment = $comment->getParentComment();
        }

        echo java_values($comments[$i]->getAuthor()->getName()) . ": " . java_values($comments[$i]->getText()) . PHP_EOL;
    }

    $presentation->save("parent_comment.pptx", SaveFormat::Pptx);

    $comment1->remove();
    $presentation->save("remove_comment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Wenn die Methode [Comment::remove](https://reference.aspose.com/slides/de/php-java/aspose.slides/comment/remove/) verwendet wird, um einen Kommentar zu löschen, werden auch alle Antworten auf diesen Kommentar gelöscht.
* Erzeugt [Comment::setParentComment](https://reference.aspose.com/slides/de/php-java/aspose.slides/comment/setparentcomment/) eine zirkuläre Referenz, wird eine [PptxEditException](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxeditexception/) ausgelöst.
{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können der Folie selbst, einer bestimmten Form oder einem Textbereich innerhalb einer AutoShape zugeordnet werden. Die Methode [CommentCollection::addModernComment](https://reference.aspose.com/slides/de/php-java/aspose.slides/commentcollection/addmoderncomment/) akzeptiert zusätzlich zu Folie und Kommentar‑Marker‑Koordinaten ein [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/)‑Argument.

Wenn für das Shape‑Argument `null` übergeben wird, handelt es sich um einen Folien‑Kommentar. Sein Marker wird durch die angegebenen Koordinaten positioniert, ist jedoch keiner bestimmten Form zugeordnet, sodass [ModernComment::getShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/getshape/) `null` zurückgibt. Wird ein [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/) übergeben, ist der Kommentar an diese Form verankert. Die Koordinaten bestimmen weiterhin die Position des Kommentar‑Markers auf der Folie, während die Formzuordnung über [ModernComment::getShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/getshape/) abgerufen werden kann.

### **Einen modernen Kommentar an einer Form verankern**

Das folgende Beispiel erstellt sowohl einen Folien‑Kommentar als auch einen an einer bestimmten AutoShape verankerten modernen Kommentar. Anschließend wird die zugehörige Form aus jedem Kommentar ausgelesen.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 300, 80);
    $shape->setName("Revenue title");
    $shape->getTextFrame()->setText("Quarterly revenue");

    $createdTime = new Java("java.util.Date");
    $slideCommentPosition = new Point2DFloat(20, 20);
    $shapeCommentPosition = new Point2DFloat(60, 60);
    $slideComment = $author->getComments()->addModernComment("Review the overall slide layout.", $slide, null, $slideCommentPosition, $createdTime);
    $shapeComment = $author->getComments()->addModernComment("Check this title.", $slide, $shape, $shapeCommentPosition, $createdTime);

    echo (java_is_null($slideComment->getShape()) ? "true" : "false") . PHP_EOL;
    echo java_values($shapeComment->getShape()->getName()) . PHP_EOL;

    $presentation->save("modern_comments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Kommentare an verschiedenen Formtypen verankern**

Jedes Folienobjekt, das durch die [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/) Klasse repräsentiert wird, kann als Anker verwendet werden. Gängige Beispiele sind [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/de/php-java/aspose.slides/connector/) und [GraphicalObject](https://reference.aspose.com/slides/de/php-java/aspose.slides/graphicalobject/)‑Instanzen wie Diagramme.

Das folgende Beispiel erstellt mehrere gängige Formtypen und verknüpft jeweils einen modernen Kommentar damit.

```php
use aspose\slides\ChartType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $createdTime = new Java("java.util.Date");

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 180, 60);
    $autoShape->getTextFrame()->setText("AutoShape");
    $autoShapeCommentPosition = new Point2DFloat(30, 30);
    $author->getComments()->addModernComment("Comment on an AutoShape.", $slide, $autoShape, $autoShapeCommentPosition, $createdTime);

    $imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    $base64Class = new JavaClass("java.util.Base64");
    $imageData = $base64Class->getDecoder()->decode($imageBase64);
    $image = $presentation->getImages()->addImage($imageData);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 120, 80, $image);
    $pictureCommentPosition = new Point2DFloat(230, 30);
    $author->getComments()->addModernComment("Comment on a picture.", $slide, $pictureFrame, $pictureCommentPosition, $createdTime);

    $groupShape = $slide->getShapes()->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 80, 40);
    $groupShape->getShapes()->addAutoShape(ShapeType::Ellipse, 100, 0, 80, 40);
    $groupCommentPosition = new Point2DFloat(40, 150);
    $author->getComments()->addModernComment("Comment on a group.", $slide, $groupShape, $groupCommentPosition, $createdTime);

    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 220, 150, 140, 40);
    $connectorCommentPosition = new Point2DFloat(240, 150);
    $author->getComments()->addModernComment("Comment on a connector.", $slide, $connector, $connectorCommentPosition, $createdTime);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 400, 20, 250, 180);
    $chartCommentPosition = new Point2DFloat(420, 40);
    $author->getComments()->addModernComment("Comment on a graphical object.", $slide, $chart, $chartCommentPosition, $createdTime);

    $presentation->save("modern_comment_shape_types.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Einen Kommentar an Text verankern und seinen Status festlegen**

Für einen modernen Kommentar, der einer [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) zugeordnet ist, greifen [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/gettextselectionstart/) und [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/settextselectionstart/) auf die Startposition des ausgewählten Textes im Text‑Frame der Form zu. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/gettextselectionlength/) und [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/settextselectionlength/) geben die Länge der Auswahl zurück. Zusammen verknüpfen diese Werte den Kommentar mit einem bestimmten Textbereich innerhalb der AutoShape.

Die Methoden [ModernComment::getStatus](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/getstatus/) und [ModernComment::setStatus](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/setstatus/) greifen auf einen Wert aus den Konstanten [ModernCommentStatus](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncommentstatus/) zu:

- `NotDefined` — kein spezifischer moderner Kommentar‑Status ist definiert.
- `Active` — der Kommentar ist aktiv.
- `Resolved` — der Kommentar wurde aufgelöst.
- `Closed` — der Kommentar ist geschlossen.

Das folgende Beispiel erstellt einen an einer Form verankerten modernen Kommentar, verknüpft ihn mit einer Textauswahl, markiert ihn als aufgelöst, speichert die Präsentation und prüft die Werte nach dem erneuten Öffnen der Datei.

```php
use aspose\slides\ModernCommentStatus;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$outputFile = "modern_comment_text_anchor.pptx";
$shapeText = "Review the quarterly revenue forecast.";
$selectedText = "quarterly revenue";
$expectedSelectionStart = strpos($shapeText, $selectedText);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->setName("Forecast text");
    $shape->getTextFrame()->setText($shapeText);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $commentPosition = new Point2DFloat(60, 60);
    $comment = $author->getComments()->addModernComment("Verify this forecast wording.", $slide, $shape, $commentPosition, new Java("java.util.Date"));
    $comment->setTextSelectionStart($expectedSelectionStart);
    $comment->setTextSelectionLength(strlen($selectedText));
    $comment->setStatus(ModernCommentStatus::Resolved);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedComments = $reopenedSlide->getSlideComments(null);
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");

    foreach ($reopenedComments as $reopenedComment) {
        if (!java_instanceof($reopenedComment, $modernCommentClass)) {
            continue;
        }

        $shape = $reopenedComment->getShape();
        $shapeMatches = !java_is_null($shape) && java_values($shape->getName()) === "Forecast text";
        $selectionStartMatches = java_values($reopenedComment->getTextSelectionStart()) === $expectedSelectionStart;
        $selectionLengthMatches = java_values($reopenedComment->getTextSelectionLength()) === strlen($selectedText);
        $statusMatches = java_values($reopenedComment->getStatus()) === ModernCommentStatus::Resolved;

        echo "Shape anchor preserved: " . ($shapeMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection start preserved: " . ($selectionStartMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection length preserved: " . ($selectionLengthMatches ? "true" : "false") . PHP_EOL;
        echo "Resolved status preserved: " . ($statusMatches ? "true" : "false") . PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

### **Vorhandene moderne Kommentare prüfen**

Um eine bestehende Präsentation zu untersuchen, prüfen Sie zunächst, ob jeder Kommentar ein [ModernComment](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/) ist, dann untersuchen Sie [ModernComment::getShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/gettextselectionlength/) und [ModernComment::getStatus](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/getstatus/). Ein `null`‑Shape weist auf einen Folien‑Kommentar hin. Bei einem [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/)‑Anker identifizieren die Text‑Auswahl‑Methoden den zugehörigen Bereich im Text‑Frame der Form.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("comments.pptx");
try {
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    foreach ($presentation->getSlides() as $slide) {
        $comments = $slide->getSlideComments(null);
        foreach ($comments as $comment) {
            if (!java_instanceof($comment, $modernCommentClass)) {
                continue;
            }

            echo "Slide: " . java_values($slide->getSlideNumber()) . PHP_EOL;
            echo "Text: " . java_values($comment->getText()) . PHP_EOL;
            echo "Status: " . java_values($comment->getStatus()) . PHP_EOL;

            $shape = $comment->getShape();
            if (java_is_null($shape)) {
                echo "Anchor: slide level" . PHP_EOL;
            } else {
                echo "Anchor shape: " . java_values($shape->getName()) . PHP_EOL;
                echo "Anchor type: " . java_values($shape->getClass()->getSimpleName()) . PHP_EOL;

                if (java_instanceof($shape, $autoShapeClass)) {
                    echo "Text selection start: " . java_values($comment->getTextSelectionStart()) . PHP_EOL;
                    echo "Text selection length: " . java_values($comment->getTextSelectionLength()) . PHP_EOL;
                }
            }

            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Kommentare entfernen**

### **Alle Kommentare und Kommentarautoren entfernen**

Das folgende Beispiel zeigt, wie alle Kommentare und Kommentarautoren aus einer Präsentation entfernt werden:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("example.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        $author->getComments()->clear();
    }

    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Bestimmte Kommentare entfernen**

Das folgende Beispiel zeigt, wie bestimmte Kommentare von einer Folie entfernt werden:

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $createdTime = new Java("java.util.Date");

    $firstCommentPosition = new Point2DFloat(0.2, 0.2);
    $secondCommentPosition = new Point2DFloat(0.3, 0.2);
    $author->getComments()->addComment("comment 1", $slide, $firstCommentPosition, $createdTime);
    $author->getComments()->addComment("comment 2", $slide, $secondCommentPosition, $createdTime);

    foreach ($presentation->getCommentAuthors() as $commentAuthor) {
        $commentsToRemove = new Java("java.util.ArrayList");
        $comments = $slide->getSlideComments($commentAuthor);

        foreach ($comments as $comment) {
            if ($comment->getText()->equals("comment 1")) {
                $commentsToRemove->add($comment);
            }
        }

        foreach ($commentsToRemove as $comment) {
            $commentAuthor->getComments()->remove($comment);
        }
    }

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Unterstützt Aspose.Slides einen aufgelösten Status für moderne Kommentare?**

Ja. [ModernComment::getStatus](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/getstatus/) und [ModernComment::setStatus](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncomment/setstatus/) greifen auf einen [ModernCommentStatus](https://reference.aspose.com/slides/de/php-java/aspose.slides/moderncommentstatus/)‑Wert zu, einschließlich `Resolved`. Der Status wird in der Präsentation gespeichert und kann nach erneutem Öffnen der Datei wieder ausgelesen werden.

**Werden Thread‑Diskussionen (Antwortketten) unterstützt und gibt es eine Begrenzungsgrenze?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/de/php-java/aspose.slides/comment/getparentcomment/) verweisen, wodurch Antwortketten ermöglicht werden. Die API definiert keine spezifische Begrenzung der Verschachtelungstiefe.

**In welchem Koordinatensystem ist die Position eines Kommentarmarkers auf einer Folie definiert?**

Die Marker‑Position wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie sie exakt auf der Folie platzieren können.