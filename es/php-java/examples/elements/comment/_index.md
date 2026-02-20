---
title: Comentario
type: docs
weight: 230
url: /es/php-java/examples/elements/comment/
keywords:
- comentario
- comentario moderno
- añadir comentario
- acceder comentario
- eliminar comentario
- responder al comentario
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Gestione los comentarios de diapositivas en PHP con Aspose.Slides: añada, lea, responda, edite, elimine y trabaje con comentarios en hilos para PowerPoint y OpenDocument."
---
Demuestra cómo agregar, leer, eliminar y responder a los comentarios modernos usando **Aspose.Slides for PHP via Java**.

## **Añadir un comentario moderno**

Cree un comentario creado por un usuario y guarde la presentación.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Añadir un comentario moderno.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acceder a un comentario moderno**

Lea un comentario moderno de una presentación existente.

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

## **Eliminar un comentario moderno**

Elimine un comentario y guarde el archivo actualizado.

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

## **Responder a un comentario moderno**

Añada respuestas a un comentario moderno principal.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Añadir un autor de comentario.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Añadir un comentario principal y respuestas.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Establecer el comentario principal para las respuestas.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Guardar la presentación con respuestas.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```