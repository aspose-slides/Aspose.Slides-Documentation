---
title: Kommentar
type: docs
weight: 230
url: /sv/php-java/examples/elements/comment/
keywords:
- kommentar
- modern kommentar
- lägg till kommentar
- åtkomst till kommentar
- ta bort kommentar
- svara på kommentar
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera bildkommentarer i PHP med Aspose.Slides: lägga till, läsa, svara, redigera, ta bort och arbeta med trådade kommentarer för PowerPoint och OpenDocument."
---
Visar hur man lägger till, läser, tar bort och svarar på moderna kommentarer med hjälp av **Aspose.Slides for PHP via Java**.

## **Lägg till en modern kommentar**

Skapa en kommentar skriven av en användare och spara presentationen.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Lägg till en modern kommentar.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Åtkomst till en modern kommentar**

Läs en modern kommentar från en befintlig presentation.

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

## **Ta bort en modern kommentar**

Ta bort en kommentar och spara den uppdaterade filen.

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

## **Svara på en modern kommentar**

Lägg till svar på en överordnad modern kommentar.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Lägg till en kommentarförfattare.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Lägg till en föräldrakommentar och svar.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Ange föräldrakommentaren för svaren.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Spara presentationen med svar.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```