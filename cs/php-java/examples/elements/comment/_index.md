---
title: Komentář
type: docs
weight: 230
url: /cs/php-java/examples/elements/comment/
keywords:
- komentář
- moderní komentář
- přidat komentář
- přístup ke komentáři
- odstranit komentář
- odpovědět na komentář
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte komentáře snímků v PHP pomocí Aspose.Slides: přidávejte, čtěte, odpovídejte, upravujte, mazejte a pracujte s vlákny komentářů pro PowerPoint a OpenDocument."
---
Ukazuje přidávání, čtení, odstraňování a odpovídání na moderní komentáře pomocí **Aspose.Slides for PHP via Java**.

## **Přidat moderní komentář**

Vytvořte komentář vytvořený uživatelem a uložte prezentaci.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přidat moderní komentář.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Získat moderní komentář**

Přečtěte moderní komentář ze stávající prezentace.

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

## **Odstranit moderní komentář**

Odstraňte komentář a uložte aktualizovaný soubor.

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

## **Odpovědět na moderní komentář**

Přidejte odpovědi k nadřazenému modernímu komentáři.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přidat autora komentáře.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Přidat nadřazený komentář a odpovědi.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Nastavit nadřazený komentář pro odpovědi.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Uložit prezentaci s odpověďmi.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```