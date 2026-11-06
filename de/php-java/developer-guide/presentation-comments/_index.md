---
title: Präsentationskommentare verwalten in PHP
linktitle: Präsentationskommentare
type: docs
weight: 100
url: /de/php-java/presentation-comments/
keywords:
- Kommentar
- Moderner Kommentar
- PowerPoint-Kommentare
- Präsentationskommentare
- Folienkommentare
- Kommentar hinzufügen
- Kommentar lesen
- Kommentar bearbeiten
- Kommentar antworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für PHP via Java: Kommentare in PowerPoint-Präsentationen schnell und einfach hinzufügen, lesen, bearbeiten, darauf antworten und entfernen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationskommentare mit Aspose.Slides für PHP via Java verwaltet. Er führt die wichtigsten kommentarbezogenen Typen ein und demonstriert, wie Kommentare zu Folien hinzugefügt, vorhandene Kommentare abgerufen, mit Antworten und modernen Kommentaren gearbeitet und Kommentare aus einer Präsentation entfernt werden.

Die Beispiele decken gängige Überprüfungs‑ und Zusammenarbeitsszenarien in PowerPoint ab, wie das Zuordnen von Kommentaren zu Autoren, das Lesen von Kommentartext und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter Kommentare oder aller Kommentare.

In PowerPoint erscheinen Kommentare als Anmerkungen auf Folien. Das Auswählen eines Kommentars zeigt dessen Text und die zugehörige Diskussion an.

Um Kommentare beim Öffnen einer Präsentation ein- oder ausblenden zu lassen, ohne die Kommentare selbst zu ändern, siehe [Kommentare beim Öffnen einer Präsentation ein- oder ausblenden](/slides/de/php-java/presentation-view-properties/).

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und bei der Durchsicht von Präsentationen mit Kollegen zusammenzuarbeiten.

Aspose.Slides für PHP via Java bietet die folgenden APIs zur Arbeit mit Kommentaren:

* Die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse, die Zugriff auf die Kommentar‑Autoren der Präsentation bietet.
* Die [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) Klasse, die die mit einem einzelnen Autor verknüpften Kommentare darstellt.
* Die [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) Klasse, die Informationen zu einem Kommentar bereitstellt, einschließlich Autor, Erstellungszeit, Position und Text.
* Die [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) Klasse, die Informationen zu einem Autor bereitstellt, einschließlich Name, Initialen und zugehöriger Kommentare.

## **Folienkommentare hinzufügen**

Das Beispiel erstellt zwei Folien und registriert einen Kommentar‑Autor mit [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/). Es verwendet [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/), um auf jeder Folie einen Kommentar zu platzieren, und ruft dann die Kommentare der ersten Folie für diesen Autor mit [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) ab. Die Konsole gibt den Text des ersten Kommentars zweimal aus, was den Zugriff sowohl über die Folie als auch über den Autor demonstriert, und die gespeicherte Präsentation enthält beide Kommentare.

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

## **Einen Kommentar‑Autor finden oder erstellen**

Wenn eine automatisierte Überprüfung dieselbe Präsentation wiederholt verarbeitet, durchsuchen Sie die von [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) zurückgegebene Sammlung, bevor Sie einen Autor hinzufügen. [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) stimmt sowohl Name als auch Initialen überein und gibt ein Array passender Autoren zurück, bzw. ein leeres Array, wenn keine Übereinstimmungen existieren. Im Gegensatz dazu sucht [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) nur nach dem Namen, unabhängig von Initialen. Der Aufruf von [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) mit einem bereits in der Sammlung vorhandenen Namen und Initialen löst eine Ausnahme aus.

Das Beispiel erfordert eine Präsentationsdatei mit mindestens einer Folie. In jedem der beiden Durchläufe verwendet es den zuerst passenden Autor erneut oder erstellt einen, nur wenn das Ergebnis leer ist. Vorhandene mehrere Treffer werden das erste Array‑Element ausgewählt, ohne die anderen Autoren zu zusammenzuführen oder zu entfernen. Anschließend wird [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) für den ausgewählten Autor aufgerufen und die Präsentation gespeichert. Der zweite Durchlauf öffnet die Ausgabe des ersten Durchlaufs und wiederholt die Operation.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$authorName = "Reviewer";
$authorInitials = "RV";

$inputFile = "input.pptx";
$position = new Point2DFloat(20, 20);
$arrayClass = new JavaClass("java.lang.reflect.Array");

for ($pass = 1; $pass <= 2; $pass++) {
    $presentation = new Presentation($inputFile);
    try {
        $matches = $presentation->getCommentAuthors()->findByNameAndInitials($authorName, $authorInitials);
        $matchCount = java_values($arrayClass->getLength($matches));

        $author = $matchCount > 0 ? $matches[0] : $presentation->getCommentAuthors()->addAuthor($authorName, $authorInitials);
        $createdTime = new Java("java.util.Date");
        $author->getComments()->addComment("Please review this slide.", $presentation->getSlides()->get_Item(0), $position, $createdTime);

        $outputFile = "review_pass_" . $pass . ".pptx";
        $presentation->save($outputFile, SaveFormat::Pptx);
        $inputFile = $outputFile;
    } finally {
        $presentation->dispose();
    }
}
```

Der zweite Durchlauf fügt einen weiteren Kommentar hinzu, ohne einen weiteren Autor hinzuzufügen oder bestehende Kommentare zu entfernen. Die endgültige Datei, `review_pass_2.pptx`, enthält beide neuen Kommentare zusammen mit etwaigen Originalkommentaren. Das erneute Verwenden eines Autors führt nicht zu einer Duplikatsbereinigung von Kommentaren: Um das wiederholte Hinzufügen desselben Kommentars zu vermeiden, implementieren Sie eine separate Duplikaterkennung, bevor Sie ihn hinzufügen.

## **Zugriff auf Folienkommentare**

Das Beispiel öffnet eine vorhandene Präsentation und liest die von [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) zurückgegebene Sammlung. Für jeden Autor iteriert es durch die von [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) zurückgegebene Sammlung und gibt die Foliennummer, den Kommentartext, den Autorennamen und die Erstellungszeit aus. Die Eingabe‑Präsentation muss Kommentare enthalten, um Konsolenausgaben zu erzeugen.

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

Ein übergeordneter Kommentar ist der ursprüngliche Kommentar an der Spitze einer Antwort‑Hierarchie. Die Methoden [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) und [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) ermöglichen das Abrufen bzw. Festlegen des übergeordneten Kommentars.

Das Beispiel erstellt Kommentare von zwei Autoren und verwendet [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/), um Antworten zu erstellen, einschließlich einer Antwort auf eine andere Antwort. Das Übergeben von `null` an [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) ruft Kommentare aller Autoren ab; die Konsole rückt jeden Eintrag entsprechend seiner Tiefe in der Antwort‑Hierarchie ein. Das Beispiel speichert die vollständige Diskussion, ruft [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) für den ersten Hauptkommentar auf und speichert eine zweite Präsentation, in der dieser Kommentar und seine Antworten entfernt wurden.

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
* Wenn die Methode [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) verwendet wird, um einen Kommentar zu löschen, werden alle Antworten auf diesen Kommentar ebenfalls gelöscht.
* Wenn [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) eine zirkuläre Referenz erzeugt, wird eine [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/) ausgelöst.
{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können mit der Folie selbst, einer bestimmten Form oder einem Textbereich innerhalb einer AutoShape verknüpft werden. Die Methode [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) akzeptiert ein [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)‑Argument zusätzlich zu den Folien‑ und Kommentar‑Marker‑Koordinaten.

Wenn für das Shape‑Argument `null` übergeben wird, handelt es sich um einen Folien‑Kommentar. Sein Marker wird anhand der angegebenen Koordinaten positioniert, ist jedoch keiner bestimmten Form zugeordnet, sodass [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) `null` zurückgibt. Wird ein [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) übergeben, wird der Kommentar an dieser Form verankert. Die Koordinaten bestimmen weiterhin die Position des Kommentar‑Markers auf der Folie, während die Form‑Zuordnung über [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) abgerufen werden kann.

### **Einen modernen Kommentar an einer Form verankern**

Das Beispiel ruft [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) zweimal auf: einmal mit einer `null`‑Form für einen Folien‑Kommentar und einmal mit einem Rechteck als Anker. Das Auslesen von [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) gibt `true` für die Null‑Prüfung des Folien‑Kommentars und `Revenue title` für den verankerten Kommentar aus. Beide Kommentare werden zusammen mit der Präsentation gespeichert.

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

### **Kommentare an verschiedene Formtypen verankern**

Jedes Folienobjekt, das durch die Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) dargestellt wird, kann als Form‑Anker verwendet werden. Häufige Beispiele sind [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) und [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/)‑Instanzen wie Diagramme.

Das Beispiel verwendet [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/), um einen Kommentar mit jedem der fünf Formtypen zu verknüpfen: einer AutoShape, einem Bildrahmen, einer Gruppe, einem Verbinder und einem Diagramm. Das Bild verwendet eingebettete Bilddaten, sodass kein externes Bild benötigt wird. Jeder Kommentar hat seine eigene Marker‑Position, und die gespeicherte Präsentation behält alle fünf Form‑Zuordnungen bei.

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

Für einen modernen Kommentar, der mit einer [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) verknüpft ist, greifen [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) und [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) auf die Startposition des ausgewählten Textes im Textfeld der Form zu. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) und [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) geben die Länge der Auswahl zurück. Zusammen verknüpfen diese Werte den Kommentar mit einem bestimmten Textbereich innerhalb der AutoShape.

Die Methoden [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) und [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) greifen auf einen Wert aus den Konstanten [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) zu:

- `NotDefined` — kein spezifischer Modern‑Comment‑Status ist definiert.
- `Active` — der Kommentar ist aktiv.
- `Resolved` — der Kommentar wurde gelöst.
- `Closed` — der Kommentar ist geschlossen.

Das Beispiel verankert einen modernen Kommentar an den Wörtern „quarterly revenue“ im Text eines Rechtecks. Es berechnet den nullbasierten Auswahl‑Start aus dem Text und übergibt ihn an [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) sowie verwendet [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/), um die Anzahl der ausgewählten Zeichen festzulegen. Nach dem Aufruf von [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) mit `Resolved` wird die Präsentation gespeichert und erneut geöffnet. Die vier Konsolen‑Prüfungen sollten jeweils `true` ausgeben, wodurch bestätigt wird, dass das Form‑Anker, der Textbereich und der Status erhalten geblieben sind.

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

### **Bestehende moderne Kommentare inspizieren**

Das Beispiel benötigt eine vorhandene Präsentation, die moderne Kommentare enthält, und gibt deren Text, Status und Ankerdetails aus. Zur Inspektion prüft man, ob jeder Kommentar ein [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) ist, und untersucht anschließend [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) und [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/). Eine `null`‑Form kennzeichnet einen Folien‑Kommentar. Für einen [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)‑Anker identifizieren die Text‑Auswahl‑Methoden den zugehörigen Bereich im Textfeld der Form.

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

Aspose.Slides für PHP via Java ermöglicht das Entfernen aller Kommentare und ihrer Autoren aus einer Präsentation oder das Löschen ausgewählter Kommentare, wobei der Rest erhalten bleibt. Die folgenden Beispiele zeigen beide Vorgehensweisen und speichern die aktualisierte Präsentation.

### **Alle Kommentare und Kommentar‑Autoren entfernen**

Das Beispiel öffnet eine vorhandene Präsentation und ruft für jeden Autor [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) auf, anschließend wird [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) aufgerufen, um die Autoren selbst zu entfernen. Die gespeicherte Präsentation enthält weder Kommentare noch Kommentar‑Autoren. Verwenden Sie eine Präsentation mit Kommentaren, um die Entfernung zu beobachten.

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

Das Beispiel erstellt zwei Kommentare auf einer Folie und verwendet [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/), um Kommentare jedes Autors zu finden. Es sammelt Kommentare, deren Text „comment 1“ entspricht, bevor [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/) aufgerufen wird, um Änderungen an der Sammlung während der Auswahl zu vermeiden. Die gespeicherte Präsentation enthält nur „comment 2“.

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

**Unterstützt Aspose.Slides einen gelösten Status für moderne Kommentare?**

Ja. [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) und [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) greifen auf einen [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/)‑Wert zu, einschließlich `Resolved`. Der Status wird in der Präsentation gespeichert und kann nach dem erneuten Öffnen der Datei erneut ausgelesen werden.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt und gibt es eine Begrenzung der Verschachtelungstiefe?**

Ja. Jeder Kommentar kann sein [übergeordneter Kommentar](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) referenzieren, wodurch Antwortketten ermöglicht werden. Die API definiert keine spezifische Begrenzung der Verschachtelungstiefe.

**In welchem Koordinatensystem ist die Position eines Kommentar‑Markers auf einer Folie definiert?**

Die Position des Markers wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie ihn exakt auf der Folie platzieren können.