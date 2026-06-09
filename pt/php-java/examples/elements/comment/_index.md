---
title: Comentário
type: docs
weight: 230
url: /pt/php-java/examples/elements/comment/
keywords:
- comentário
- comentário moderno
- adicionar comentário
- acessar comentário
- remover comentário
- responder ao comentário
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie comentários de slides em PHP com Aspose.Slides: adicione, leia, responda, edite, exclua e trabalhe com comentários em thread para PowerPoint e OpenDocument."
---
Demonstrar como adicionar, ler, remover e responder a comentários modernos usando **Aspose.Slides for PHP via Java**.

## **Adicionar um Comentário Moderno**

Crie um comentário escrito por um usuário e salve a apresentação.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Adicionar um comentário moderno.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acessar um Comentário Moderno**

Leia um comentário moderno de uma apresentação existente.

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

## **Remover um Comentário Moderno**

Remova um comentário e salve o arquivo atualizado.

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

## **Responder a um Comentário Moderno**

Adicione respostas a um comentário moderno pai.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Adicionar um autor de comentário.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Adicionar um comentário pai e respostas.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Definir o comentário pai para as respostas.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Salvar a apresentação com respostas.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```