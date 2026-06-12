---
title: Opmerking
type: docs
weight: 230
url: /nl/php-java/examples/elements/comment/
keywords:
- opmerking
- moderne opmerking
- opmerking toevoegen
- opmerking openen
- opmerking verwijderen
- opmerking beantwoorden
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer dia‑opmerkingen in PHP met Aspose.Slides: toevoegen, lezen, beantwoorden, bewerken, verwijderen en werken met geneste opmerkingen voor PowerPoint en OpenDocument."
---
Toont het toevoegen, lezen, verwijderen en beantwoorden van moderne opmerkingen met **Aspose.Slides for PHP via Java**.

## **Moderne opmerking toevoegen**
Maak een opmerking aangemaakt door een gebruiker en sla de presentatie op.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Voeg een moderne opmerking toe.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Moderne opmerking openen**
Lees een moderne opmerking uit een bestaande presentatie.

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

## **Moderne opmerking verwijderen**
Verwijder een opmerking en sla het bijgewerkte bestand op.

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

## **Antwoorden op een moderne opmerking**
Voeg antwoorden toe aan een bovenliggende moderne opmerking.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Voeg een opmerkingauteur toe.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Voeg een bovenliggende opmerking en antwoorden toe.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Stel de bovenliggende opmerking in voor antwoorden.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Sla de presentatie op met antwoorden.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```