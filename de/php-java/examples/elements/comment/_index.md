---
title: Kommentar
type: docs
weight: 230
url: /de/php-java/examples/elements/comment/
keywords:
- Kommentar
- moderner Kommentar
- Kommentar hinzufügen
- Kommentar abrufen
- Kommentar entfernen
- Auf Kommentar antworten
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Folienkommentare in PHP mit Aspose.Slides: Hinzufügen, Lesen, Antworten, Bearbeiten, Löschen und Arbeiten mit verschachtelten Kommentaren für PowerPoint und OpenDocument."
---
Demonstriert das Hinzufügen, Lesen, Entfernen und Antworten auf moderne Kommentare mit **Aspose.Slides for PHP via Java**.

## **Einen modernen Kommentar hinzufügen**

Erstellen Sie einen vom Benutzer verfassten Kommentar und speichern Sie die Präsentation.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Einen modernen Kommentar hinzufügen.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Zugriff auf einen modernen Kommentar**

Lesen Sie einen modernen Kommentar aus einer vorhandenen Präsentation.

```php
function accessModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);
        echo "Author: " . $author->getName() . ", Comment: " . $comment->getText() . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
}
```

## **Einen modernen Kommentar entfernen**

Entfernen Sie einen Kommentar und speichern Sie die aktualisierte Datei.

```php
function removeModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);

        $comment->remove();

        $presentation->save("modern_comment_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Auf einen modernen Kommentar antworten**

Fügen Sie Antworten zu einem übergeordneten modernen Kommentar hinzu.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Einen Kommentarautor hinzufügen.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Einen übergeordneten Kommentar und Antworten hinzufügen.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Den übergeordneten Kommentar für Antworten festlegen.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Die Präsentation mit Antworten speichern.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```