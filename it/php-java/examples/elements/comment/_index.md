---
title: Commento
type: docs
weight: 230
url: /it/php-java/examples/elements/comment/
keywords:
- commento
- commento moderno
- aggiungi commento
- accedi al commento
- rimuovi commento
- rispondi al commento
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci i commenti delle diapositive in PHP con Aspose.Slides: aggiungi, leggi, rispondi, modifica, elimina e lavora con commenti a thread per PowerPoint e OpenDocument."
---
Dimostra come aggiungere, leggere, rimuovere e rispondere a commenti moderni usando **Aspose.Slides for PHP via Java**.

## **Aggiungi un commento moderno**

Crea un commento scritto da un utente e salva la presentazione.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aggiungi un commento moderno.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accedi a un commento moderno**

Leggi un commento moderno da una presentazione esistente.

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

## **Rimuovi un commento moderno**

Rimuovi un commento e salva il file aggiornato.

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

## **Rispondi a un commento moderno**

Aggiungi risposte a un commento moderno genitore.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aggiungi un autore del commento.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Aggiungi un commento genitore e le risposte.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Imposta il commento genitore per le risposte.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Salva la presentazione con le risposte.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```