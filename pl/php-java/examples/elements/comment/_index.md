---
title: Komentarz
type: docs
weight: 230
url: /pl/php-java/examples/elements/comment/
keywords:
- komentarz
- nowoczesny komentarz
- dodaj komentarz
- dostęp do komentarza
- usuń komentarz
- odpowiadaj na komentarz
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj komentarzami slajdów w PHP przy użyciu Aspose.Slides: dodawaj, czytaj, odpowiadaj, edytuj, usuwaj oraz pracuj z wątkowanymi komentarzami dla PowerPoint i OpenDocument."
---
Prezentuje dodawanie, odczytywanie, usuwanie i odpowiadanie na nowoczesne komentarze przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj nowoczesny komentarz**
Utwórz komentarz napisany przez użytkownika i zapisz prezentację.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dodaj nowoczesny komentarz.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Uzyskaj dostęp do nowoczesnego komentarza**
Odczytaj nowoczesny komentarz z istniejącej prezentacji.

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

## **Usuń nowoczesny komentarz**
Usuń komentarz i zapisz zaktualizowany plik.

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

## **Odpowiedz na nowoczesny komentarz**
Dodaj odpowiedzi do nadrzędnego nowoczesnego komentarza.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dodaj autora komentarza.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Dodaj komentarz nadrzędny i odpowiedzi.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Ustaw komentarz nadrzędny dla odpowiedzi.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Zapisz prezentację z odpowiedziami.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```