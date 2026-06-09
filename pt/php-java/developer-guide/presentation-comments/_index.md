---
title: Gerenciar comentários de apresentação em PHP
linktitle: Comentários de apresentação
type: docs
weight: 100
url: /pt/php-java/presentation-comments/
keywords:
- comentário
- comentário moderno
- comentários do PowerPoint
- comentários da apresentação
- comentários de slide
- adicionar comentário
- acessar comentário
- editar comentário
- responder comentário
- remover comentário
- excluir comentário
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Domine os comentários de apresentação com Aspose.Slides for PHP via Java: adicione, leia, edite e exclua comentários em arquivos PowerPoint de forma rápida e fácil."
---
## **Visão geral**

Este artigo explica como gerenciar comentários de apresentação no Aspose.Slides. Ele mostra os principais tipos relacionados a comentários e demonstra como adicionar comentários a slides, acessar comentários existentes, trabalhar com respostas, usar comentários modernos e remover comentários de uma apresentação.

Os exemplos focam em cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o conteúdo e os metadados dos comentários, construir cadeias de respostas e limpar todos os comentários ou excluir os selecionados.

No PowerPoint, um comentário aparece como uma nota ou anotação em um slide. Quando um comentário é clicado, seu conteúdo ou mensagens são revelados. 

## **Por que adicionar comentários às apresentações?**

Você pode querer usar comentários para fornecer feedback ou se comunicar com seus colegas ao revisar apresentações.

Para permitir que você use comentários em apresentações do PowerPoint, o Aspose.Slides for PHP via Java fornece

* A classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) que contém as coleções de autores (da classe [CommentAuthorCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commentauthorcollection/)). Os autores adicionam comentários aos slides.
* A classe [CommentCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commentcollection/) que contém a coleção de comentários de autores individuais.
* A classe [Comment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/) que contém informações sobre autores e seus comentários: quem adicionou o comentário, a hora em que o comentário foi adicionado, a posição do comentário etc.
* A classe [CommentAuthor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commentauthor/) que contém informações sobre autores individuais: o nome do autor, suas iniciais, comentários associados ao nome do autor etc.

## **Adicionar comentários ao slide**
Este código PHP mostra como adicionar um comentário a um slide em uma apresentação do PowerPoint:

```php
  # Instancia a classe Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Adiciona um slide vazio
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Adiciona um autor
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Define a posição dos comentários
    $point = new Point2DFloat(0.2, 0.2);
    # Adiciona comentário de slide para um autor no slide 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Adiciona comentário de slide para um autor no slide 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Acessa ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Quando null é passado como argumento, comentários de todos os autores são trazidos para o slide selecionado
    $Comments = $slide->getSlideComments($author);
    # Acessa o comentário no índice 0 do slide 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Seleciona a coleção de comentários do Autor no índice 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acessar comentários do slide**
Este código PHP mostra como acessar um comentário existente em um slide em uma apresentação do PowerPoint:

```php
  # Instancia a classe Presentation
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " has comment: " . $comment->getText() . " with Author: " . $comment->getAuthor()->getName() . " posted on time :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Responder a comentários**
Um comentário pai é o comentário superior ou original em uma hierarquia de comentários ou respostas. Usando os métodos [getParentComment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/getparentcomment/) ou [setParentComment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/setparentcomment/) (da classe [Comment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/)), você pode definir ou obter um comentário pai.

Este código PHP mostra como adicionar comentários e obter respostas a eles:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Adiciona um comentário
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Adiciona uma resposta ao comentário1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Adiciona outra resposta ao comentário1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Adiciona uma resposta a uma resposta existente
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Exibe a hierarquia de comentários no console
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)) ; $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # Remove o comentário1 e todas as respostas a ele
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Attention" %}} 
* Quando o método [remove](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/remove/) (da classe [Comment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/)) é usado para excluir um comentário, as respostas ao comentário também são excluídas.
* Se a configuração [setParentComment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/setparentcomment/) resultar em uma referência circular, será lançada a exceção [PptxEditException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Adicionar comentários modernos**

Em 2021, a Microsoft introduziu *comentários modernos* no PowerPoint. O recurso de comentários modernos melhora significativamente a colaboração no PowerPoint. Por meio dos comentários modernos, os usuários do PowerPoint podem resolver comentários, ancorar comentários a objetos e textos e interagir de forma muito mais fácil do que antes. 

O Aspose Slides oferece suporte a comentários modernos pela classe [ModernComment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/). Os métodos [addModernComment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commentcollection/addmoderncomment/) e [insertModernComment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commentcollection/insertmoderncomment/) foram adicionados à classe [CommentCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commentcollection/).

Este código PHP mostra como adicionar um comentário moderno a um slide em uma apresentação do PowerPoint:

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remover comentários**

### **Excluir todos os comentários e autores**

Este código PHP mostra como remover todos os comentários e autores em uma apresentação:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Exclui todos os comentários da apresentação
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Exclui todos os autores
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Excluir comentários específicos**

Este código PHP mostra como excluir comentários específicos em um slide:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # adiciona comentários...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # remove todos os comentários que contenham o texto "comment 1"
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comment 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Perguntas frequentes**

**O Aspose.Slides oferece suporte a um status como 'resolvido' para comentários modernos?**

Sim. Os [comentários modernos](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/) expõem o método [setStatus](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/setstatus/); você pode definir o [estado do comentário](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncommentstatus/) (por exemplo, marcá‑lo como resolvido), e esse estado é salvo no arquivo e reconhecido pelo PowerPoint.

**Discussões em forma de árvore (cadeias de respostas) são suportadas e há um limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [comentário pai](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/getparentcomment/), permitindo cadeias de respostas arbitrárias. A API não declara um limite específico de profundidade de aninhamento.

**Em que sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição é armazenada como um ponto de ponto flutuante no sistema de coordenadas do slide. Isso permite que você posicione o marcador de comentário exatamente onde precisar.