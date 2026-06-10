---
title: Megjegyzés
type: docs
weight: 230
url: /hu/php-java/examples/elements/comment/
keywords:
- megjegyzés
- modern megjegyzés
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés eltávolítása
- megjegyzésre válasz
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje a diák megjegyzéseit PHP-ben az Aspose.Slides segítségével: hozzáadás, olvasás, válasz, szerkesztés, törlés, valamint szálas megjegyzésekkel való munka PowerPoint és OpenDocument esetén."
---
Bemutatja a modern kommentek hozzáadását, olvasását, eltávolítását és válaszadást a **Aspose.Slides for PHP via Java** használatával.

## **Modern komment hozzáadása**

Hozzon létre egy felhasználó által írt kommentet, és mentse a prezentációt.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Modern megjegyzés hozzáadása.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Modern komment elérése**

Olvasson egy modern kommentet egy meglévő prezentációból.

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

## **Modern komment eltávolítása**

Távolítson el egy kommentet, és mentse a frissített fájlt.

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

## **Válasz a modern kommentre**

Adjon válaszokat egy szülő modern kommenthez.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Megjegyzés szerző hozzáadása.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Szülő megjegyzés és válaszok hozzáadása.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // A válaszok szülő megjegyzésének beállítása.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // A prezentáció mentése válaszokkal.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```