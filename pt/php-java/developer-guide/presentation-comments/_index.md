---
title: Gerenciar Comentários de Apresentação em PHP
linktitle: Comentários de Apresentação
type: docs
weight: 100
url: /pt/php-java/presentation-comments/
keywords:
- comentário
- comentário moderno
- comentários do PowerPoint
- comentários de apresentação
- comentários de slide
- adicionar comentário
- acessar comentário
- editar comentário
- responder comentário
- remover comentário
- excluir comentário
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie comentários de apresentação com Aspose.Slides for PHP via Java: adicione, leia, edite, responda e remova comentários em apresentações do PowerPoint rápida e facilmente."
---
## **Visão geral**

Este artigo explica como gerenciar comentários de apresentação com Aspose.Slides for PHP via Java. Ele apresenta os principais tipos relacionados a comentários e demonstra como adicionar comentários aos slides, acessar comentários existentes, trabalhar com respostas e comentários modernos, e remover comentários de uma apresentação.

Os exemplos cobrem cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o texto e os metadados dos comentários, construir cadeias de respostas e remover comentários selecionados ou todos os comentários.

No PowerPoint, os comentários aparecem como anotações nos slides. Selecionar um comentário exibe seu texto e a discussão relacionada.

## **Por que adicionar comentários às apresentações?**

Você pode usar comentários para fornecer feedback e colaborar com colegas ao revisar apresentações.

Aspose.Slides for PHP via Java oferece as seguintes APIs para trabalhar com comentários:

* A classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/), que fornece acesso aos autores de comentários da apresentação.
* A classe [CommentCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commentcollection/), que representa os comentários associados a um autor específico.
* A classe [Comment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/), que fornece informações sobre um comentário, incluindo seu autor, hora de criação, posição e texto.
* A classe [CommentAuthor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commentauthor/), que fornece informações sobre um autor, incluindo seu nome, iniciais e comentários associados.

## **Adicionar comentários ao slide**

O exemplo a seguir mostra como adicionar comentários aos slides em uma apresentação do PowerPoint:

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($presentation->getLayoutSlides()->get_Item(0));
    $author = $presentation->getCommentAuthors()->addAuthor("Jawad", "MF");
    $position = new Point2DFloat(0.2, 0.2);
    $createdTime = new Java("java.util.Date");

    $author->getComments()->addComment("Hello Jawad, this is a slide comment", $firstSlide, $position, $createdTime);
    $author->getComments()->addComment("Hello Jawad, this is the second slide comment", $secondSlide, $position, $createdTime);

    $comments = $firstSlide->getSlideComments($author);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    if ($commentCount > 0) {
        $firstComment = $comments[0];
        echo java_values($firstComment->getText()) . PHP_EOL;

        $authorComments = $firstComment->getAuthor()->getComments();
        $commentText = $authorComments->get_Item(0)->getText();
        echo java_values($commentText) . PHP_EOL;
    }

    $presentation->save("Comments_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Acessar comentários do slide**

O exemplo a seguir mostra como acessar comentários existentes em uma apresentação do PowerPoint:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Comments1.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        foreach ($author->getComments() as $comment) {
            echo "Slide: " . java_values($comment->getSlide()->getSlideNumber()) . PHP_EOL;
            echo "Comment: " . java_values($comment->getText()) . PHP_EOL;
            echo "Author: " . java_values($comment->getAuthor()->getName()) . PHP_EOL;
            echo "Posted at: " . java_values($comment->getCreatedTime()->toString()) . PHP_EOL;
            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Responder a comentários**

Um comentário pai é o comentário original no topo de uma hierarquia de respostas. Os métodos [Comment::getParentComment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/getparentcomment/) e [Comment::setParentComment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/setparentcomment/) permitem obter ou definir o pai de um comentário.

O exemplo a seguir mostra como adicionar respostas e inspecionar a hierarquia de comentários resultante:

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $position = new Point2DFloat(10, 10);
    $createdTime = new Java("java.util.Date");

    $author1 = $presentation->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment 1", $slide, $position, $createdTime);

    $author2 = $presentation->getCommentAuthors()->addAuthor("Author_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $slide, $position, $createdTime);
    $reply1->setParentComment($comment1);

    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $slide, $position, $createdTime);
    $reply2->setParentComment($comment1);

    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $slide, $position, $createdTime);
    $subReply->setParentComment($reply2);

    $author2->getComments()->addComment("comment 2", $slide, $position, $createdTime);
    $comment3 = $author2->getComments()->addComment("comment 3", $slide, $position, $createdTime);

    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $slide, $position, $createdTime);
    $reply3->setParentComment($comment3);

    $comments = $slide->getSlideComments(null);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    for ($i = 0; $i < $commentCount; $i++) {
        $comment = $comments[$i];
        while (!java_is_null($comment->getParentComment())) {
            echo "\t";
            $comment = $comment->getParentComment();
        }

        echo java_values($comments[$i]->getAuthor()->getName()) . ": " . java_values($comments[$i]->getText()) . PHP_EOL;
    }

    $presentation->save("parent_comment.pptx", SaveFormat::Pptx);

    $comment1->remove();
    $presentation->save("remove_comment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Aviso" %}}
* Quando o método [Comment::remove](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/remove/) é usado para excluir um comentário, todas as respostas a esse comentário também são excluídas.
* Se [Comment::setParentComment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/setparentcomment/) criar uma referência circular, uma [PptxEditException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxeditexception/) é lançada.
{{% /alert %}}

## **Adicionar comentários modernos**

Comentários modernos podem ser associados ao próprio slide, a uma forma específica ou a um intervalo de texto dentro de um AutoShape. O método [CommentCollection::addModernComment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commentcollection/addmoderncomment/) aceita um argumento [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) além do slide e das coordenadas do marcador de comentário.

Quando `null` é passado para o argumento shape, o comentário é um comentário de nível de slide. Seu marcador é posicionado pelas coordenadas fornecidas, mas não está associado a uma forma específica, portanto [ModernComment::getShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/getshape/) retorna `null`. Quando uma [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) é fornecida, o comentário fica ancorado a essa forma. As coordenadas ainda definem a posição do marcador de comentário no slide, enquanto a associação à forma pode ser obtida através de [ModernComment::getShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/getshape/).

### **Ancorar um comentário moderno a uma forma**

O exemplo a seguir cria tanto um comentário moderno de nível de slide quanto um comentário moderno ancorado a um AutoShape específico. Em seguida, lê a forma associada a cada comentário.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 300, 80);
    $shape->setName("Revenue title");
    $shape->getTextFrame()->setText("Quarterly revenue");

    $createdTime = new Java("java.util.Date");
    $slideCommentPosition = new Point2DFloat(20, 20);
    $shapeCommentPosition = new Point2DFloat(60, 60);
    $slideComment = $author->getComments()->addModernComment("Review the overall slide layout.", $slide, null, $slideCommentPosition, $createdTime);
    $shapeComment = $author->getComments()->addModernComment("Check this title.", $slide, $shape, $shapeCommentPosition, $createdTime);

    echo (java_is_null($slideComment->getShape()) ? "true" : "false") . PHP_EOL;
    echo java_values($shapeComment->getShape()->getName()) . PHP_EOL;

    $presentation->save("modern_comments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ancorar comentários a diferentes tipos de forma**

Qualquer objeto de slide representado pela classe [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) pode ser usado como âncora de forma. Exemplos comuns incluem [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/pt/php-java/aspose.slides/connector/) e instâncias de [GraphicalObject](https://reference.aspose.com/slides/pt/php-java/aspose.slides/graphicalobject/) como gráficos.

O exemplo a seguir cria vários tipos de forma comuns e associa um comentário moderno a cada um deles.

```php
use aspose\slides\ChartType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $createdTime = new Java("java.util.Date");

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 180, 60);
    $autoShape->getTextFrame()->setText("AutoShape");
    $autoShapeCommentPosition = new Point2DFloat(30, 30);
    $author->getComments()->addModernComment("Comment on an AutoShape.", $slide, $autoShape, $autoShapeCommentPosition, $createdTime);

    $imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    $base64Class = new JavaClass("java.util.Base64");
    $imageData = $base64Class->getDecoder()->decode($imageBase64);
    $image = $presentation->getImages()->addImage($imageData);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 120, 80, $image);
    $pictureCommentPosition = new Point2DFloat(230, 30);
    $author->getComments()->addModernComment("Comment on a picture.", $slide, $pictureFrame, $pictureCommentPosition, $createdTime);

    $groupShape = $slide->getShapes()->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 80, 40);
    $groupShape->getShapes()->addAutoShape(ShapeType::Ellipse, 100, 0, 80, 40);
    $groupCommentPosition = new Point2DFloat(40, 150);
    $author->getComments()->addModernComment("Comment on a group.", $slide, $groupShape, $groupCommentPosition, $createdTime);

    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 220, 150, 140, 40);
    $connectorCommentPosition = new Point2DFloat(240, 150);
    $author->getComments()->addModernComment("Comment on a connector.", $slide, $connector, $connectorCommentPosition, $createdTime);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 400, 20, 250, 180);
    $chartCommentPosition = new Point2DFloat(420, 40);
    $author->getComments()->addModernComment("Comment on a graphical object.", $slide, $chart, $chartCommentPosition, $createdTime);

    $presentation->save("modern_comment_shape_types.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ancorar um comentário a texto e definir seu status**

Para um comentário moderno associado a um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/), os métodos [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/gettextselectionstart/) e [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/settextselectionstart/) acessam a posição inicial do texto selecionado na caixa de texto da forma. Os métodos [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/gettextselectionlength/) e [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/settextselectionlength/) acessam o comprimento da seleção. Juntos, esses valores associam o comentário a um intervalo de texto específico dentro do AutoShape.

Os métodos [ModernComment::getStatus](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/getstatus/) e [ModernComment::setStatus](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/setstatus/) acessam um valor da constante [ModernCommentStatus](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — nenhum status de comentário moderno específico está definido.
- `Active` — o comentário está ativo.
- `Resolved` — o comentário foi resolvido.
- `Closed` — o comentário está fechado.

O exemplo a seguir cria um comentário moderno ancorado a uma forma, associa‑o a uma seleção de texto, marca‑o como resolvido, salva a apresentação e verifica os valores após reabrir o arquivo.

```php
use aspose\slides\ModernCommentStatus;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$outputFile = "modern_comment_text_anchor.pptx";
$shapeText = "Review the quarterly revenue forecast.";
$selectedText = "quarterly revenue";
$expectedSelectionStart = strpos($shapeText, $selectedText);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->setName("Forecast text");
    $shape->getTextFrame()->setText($shapeText);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $commentPosition = new Point2DFloat(60, 60);
    $comment = $author->getComments()->addModernComment("Verify this forecast wording.", $slide, $shape, $commentPosition, new Java("java.util.Date"));
    $comment->setTextSelectionStart($expectedSelectionStart);
    $comment->setTextSelectionLength(strlen($selectedText));
    $comment->setStatus(ModernCommentStatus::Resolved);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedComments = $reopenedSlide->getSlideComments(null);
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");

    foreach ($reopenedComments as $reopenedComment) {
        if (!java_instanceof($reopenedComment, $modernCommentClass)) {
            continue;
        }

        $shape = $reopenedComment->getShape();
        $shapeMatches = !java_is_null($shape) && java_values($shape->getName()) === "Forecast text";
        $selectionStartMatches = java_values($reopenedComment->getTextSelectionStart()) === $expectedSelectionStart;
        $selectionLengthMatches = java_values($reopenedComment->getTextSelectionLength()) === strlen($selectedText);
        $statusMatches = java_values($reopenedComment->getStatus()) === ModernCommentStatus::Resolved;

        echo "Shape anchor preserved: " . ($shapeMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection start preserved: " . ($selectionStartMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection length preserved: " . ($selectionLengthMatches ? "true" : "false") . PHP_EOL;
        echo "Resolved status preserved: " . ($statusMatches ? "true" : "false") . PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

### **Inspecionar comentários modernos existentes**

Para inspecionar uma apresentação existente, verifique se cada comentário é um [ModernComment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/), então examine [ModernComment::getShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/gettextselectionlength/) e [ModernComment::getStatus](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/getstatus/). Uma forma `null` indica um comentário de nível de slide. Para uma âncora [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/), os métodos de seleção de texto identificam o intervalo associado na caixa de texto da forma.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("comments.pptx");
try {
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    foreach ($presentation->getSlides() as $slide) {
        $comments = $slide->getSlideComments(null);
        foreach ($comments as $comment) {
            if (!java_instanceof($comment, $modernCommentClass)) {
                continue;
            }

            echo "Slide: " . java_values($slide->getSlideNumber()) . PHP_EOL;
            echo "Text: " . java_values($comment->getText()) . PHP_EOL;
            echo "Status: " . java_values($comment->getStatus()) . PHP_EOL;

            $shape = $comment->getShape();
            if (java_is_null($shape)) {
                echo "Anchor: slide level" . PHP_EOL;
            } else {
                echo "Anchor shape: " . java_values($shape->getName()) . PHP_EOL;
                echo "Anchor type: " . java_values($shape->getClass()->getSimpleName()) . PHP_EOL;

                if (java_instanceof($shape, $autoShapeClass)) {
                    echo "Text selection start: " . java_values($comment->getTextSelectionStart()) . PHP_EOL;
                    echo "Text selection length: " . java_values($comment->getTextSelectionLength()) . PHP_EOL;
                }
            }

            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Remover comentários**

### **Remover todos os comentários e autores de comentários**

O exemplo a seguir mostra como remover todos os comentários e autores de comentários de uma apresentação:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("example.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        $author->getComments()->clear();
    }

    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Remover comentários específicos**

O exemplo a seguir mostra como remover comentários específicos de um slide:

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $createdTime = new Java("java.util.Date");

    $firstCommentPosition = new Point2DFloat(0.2, 0.2);
    $secondCommentPosition = new Point2DFloat(0.3, 0.2);
    $author->getComments()->addComment("comment 1", $slide, $firstCommentPosition, $createdTime);
    $author->getComments()->addComment("comment 2", $slide, $secondCommentPosition, $createdTime);

    foreach ($presentation->getCommentAuthors() as $commentAuthor) {
        $commentsToRemove = new Java("java.util.ArrayList");
        $comments = $slide->getSlideComments($commentAuthor);

        foreach ($comments as $comment) {
            if ($comment->getText()->equals("comment 1")) {
                $commentsToRemove->add($comment);
            }
        }

        foreach ($commentsToRemove as $comment) {
            $commentAuthor->getComments()->remove($comment);
        }
    }

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Perguntas frequentes**

**O Aspose.Slides oferece suporte a um status resolvido para comentários modernos?**

Sim. Os métodos [ModernComment::getStatus](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/getstatus/) e [ModernComment::setStatus](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncomment/setstatus/) acessam um valor [ModernCommentStatus](https://reference.aspose.com/slides/pt/php-java/aspose.slides/moderncommentstatus/), incluindo `Resolved`. O status é armazenado na apresentação e pode ser lido novamente após o arquivo ser reaberto.

**Discussões em árvore (cadeias de respostas) são suportadas e há um limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [parent comment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/comment/getparentcomment/), permitindo cadeias de respostas. A API não define um limite específico de profundidade de aninhamento.

**Em que sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição do marcador é definida por coordenadas de ponto flutuante no sistema de coordenadas do slide, permitindo posicioná‑lo com precisão no slide.