---
title: Gerenciar Comentários de Apresentação em PHP
linktitle: Comentários da Apresentação
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
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie comentários de apresentação com Aspose.Slides para PHP via Java: adicione, leia, edite, responda e remova comentários em apresentações do PowerPoint de forma rápida e fácil."
---
## **Visão geral**

Este artigo explica como gerenciar comentários de apresentação com Aspose.Slides para PHP via Java. Ele apresenta os principais tipos relacionados a comentários e demonstra como adicionar comentários a slides, acessar comentários existentes, trabalhar com respostas e comentários modernos e remover comentários de uma apresentação.

Os exemplos cobrem cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o texto e os metadados dos comentários, construir cadeias de respostas e remover comentários selecionados ou todos os comentários.

No PowerPoint, os comentários aparecem como anotações nos slides. Selecionar um comentário exibe seu texto e a discussão relacionada.

Para solicitar que os comentários sejam mostrados ou ocultados quando uma apresentação é aberta sem alterar os próprios comentários, veja [Exibir ou ocultar comentários ao abrir uma apresentação](/slides/pt/php-java/presentation-view-properties/).

## **Por que adicionar comentários às apresentações?**

Você pode usar comentários para fornecer feedback e colaborar com colegas ao revisar apresentações.

Aspose.Slides para PHP via Java fornece as seguintes APIs para trabalhar com comentários:

* The [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class, que fornece acesso aos autores de comentários da apresentação.
* The [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) class, que representa os comentários associados a um autor individual.
* The [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) class, que fornece informações sobre um comentário, incluindo seu autor, horário de criação, posição e texto.
* The [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) class, que fornece informações sobre um autor, incluindo seu nome, iniciais e comentários associados.

## **Adicionar Comentários aos Slides**

O exemplo cria dois slides e registra um autor de comentário com [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/). Ele usa [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) para colocar um comentário em cada slide, então recupera os comentários do primeiro slide para esse autor com [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/). O console exibe o texto do primeiro comentário duas vezes, demonstrando o acesso tanto através do slide quanto do autor, e a apresentação salva contém ambos os comentários.

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

## **Encontrar ou Criar um Autor de Comentário**

Quando uma revisão automatizada processa a mesma apresentação repetidamente, pesquise na coleção retornada por [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) antes de adicionar um autor. [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) corresponde tanto ao nome quanto às iniciais e devolve um array de autores correspondentes, ou um array vazio se não houver correspondências. Em contraste, [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) procura apenas pelo nome, independentemente das iniciais. Chamar [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) com um nome e iniciais já presentes na coleção lança uma exceção.

O exemplo requer um arquivo de apresentação com pelo menos um slide. Em cada uma das duas passagens, ele reutiliza o primeiro autor correspondente, ou cria um apenas quando o resultado está vazio. Se houver várias correspondências, ele seleciona o primeiro elemento do array sem mesclar ou remover os demais autores. Em seguida, ele chama [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) para o autor selecionado e salva a apresentação. A segunda passagem abre a saída da primeira passagem e repete a operação.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$authorName = "Reviewer";
$authorInitials = "RV";

$inputFile = "input.pptx";
$position = new Point2DFloat(20, 20);
$arrayClass = new JavaClass("java.lang.reflect.Array");

for ($pass = 1; $pass <= 2; $pass++) {
    $presentation = new Presentation($inputFile);
    try {
        $matches = $presentation->getCommentAuthors()->findByNameAndInitials($authorName, $authorInitials);
        $matchCount = java_values($arrayClass->getLength($matches));

        $author = $matchCount > 0 ? $matches[0] : $presentation->getCommentAuthors()->addAuthor($authorName, $authorInitials);
        $createdTime = new Java("java.util.Date");
        $author->getComments()->addComment("Please review this slide.", $presentation->getSlides()->get_Item(0), $position, $createdTime);

        $outputFile = "review_pass_" . $pass . ".pptx";
        $presentation->save($outputFile, SaveFormat::Pptx);
        $inputFile = $outputFile;
    } finally {
        $presentation->dispose();
    }
}
```

A segunda passagem adiciona outro comentário sem adicionar outro autor nem remover comentários existentes. O arquivo final, `review_pass_2.pptx`, contém ambos os novos comentários junto a quaisquer comentários originais. Reutilizar um autor não deduplica comentários: para evitar a adição repetida do mesmo comentário, implemente detecção de duplicatas separada antes de adicioná‑lo.

## **Acessar Comentários dos Slides**

O exemplo abre uma apresentação existente e lê a coleção retornada por [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/). Para cada autor, ele itera pela coleção retornada por [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) e imprime o número do slide, o texto do comentário, o nome do autor e o horário de criação. A apresentação de entrada deve conter comentários para produzir saída no console.

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

## **Responder a Comentários**

Um comentário pai é o comentário original no topo de uma hierarquia de respostas. Os métodos [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) e [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) permitem obter ou definir o pai de um comentário.

O exemplo cria comentários de dois autores e usa [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) para construir respostas, inclusive uma resposta a outra resposta. Passar `null` para [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) recupera comentários de todos os autores; o console recua cada entrada de acordo com sua profundidade na hierarquia de respostas. O exemplo salva a discussão completa, chama [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) no primeiro comentário raiz e salva uma segunda apresentação com esse comentário e suas respostas removidos.

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

{{% alert color="warning" title="Warning" %}}
* Quando o método [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) é usado para excluir um comentário, todas as respostas a esse comentário também são excluídas.
* Se [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) criar uma referência circular, uma [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/) é lançada.
{{% /alert %}}

## **Adicionar Comentários Modernos**

Comentários modernos podem ser associados ao próprio slide, a uma forma específica ou a um intervalo de texto dentro de uma AutoShape. O método [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) aceita um argumento [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) além do slide e das coordenadas do marcador do comentário.

Quando `null` é passado para o argumento shape, o comentário é um comentário ao nível do slide. Seu marcador é posicionado pelas coordenadas fornecidas, mas não é associado a uma forma específica, de modo que [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) devolve `null`. Quando uma [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) é fornecida, o comentário é ancorado a essa forma. As coordenadas ainda definem a posição do marcador do comentário no slide, enquanto a associação à forma pode ser recuperada por meio de [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/).

### **Ancorar um Comentário Moderno a uma Forma**

O exemplo chama [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) duas vezes: uma vez com uma forma `null` para um comentário ao nível do slide e outra vez com um retângulo como âncora. Ler [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) imprime `true` para a verificação nula do comentário ao nível do slide e `Revenue title` para o comentário ancorado. Ambos os comentários são salvos com a apresentação.

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

### **Ancorar Comentários a Diferentes Tipos de Forma**

Qualquer objeto de slide representado pela classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) pode ser usado como âncora de forma. Exemplos comuns incluem [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) e instâncias de [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) como gráficos.

O exemplo usa [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) para associar um comentário a cada um de cinco tipos de forma: uma AutoShape, um quadro de imagem, um grupo, um conector e um gráfico. A imagem é incorporada como dados de imagem, portanto não é necessária imagem externa. Cada comentário tem sua própria posição de marcador, e a apresentação salva retém todas as cinco associações de forma.

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

### **Ancorar um Comentário a Texto e Definir Seu Status**

Para um comentário moderno associado a uma [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), os métodos [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) e [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) acessam a posição inicial do texto selecionado no quadro de texto da forma. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) e [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) acessam o comprimento da seleção. Juntos, esses valores associam o comentário a um intervalo de texto específico dentro da AutoShape.

Os métodos [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) e [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) acessam um valor dos constantes [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — nenhum status de comentário moderno específico está definido.
- `Active` — o comentário está ativo.
- `Resolved` — o comentário foi resolvido.
- `Closed` — o comentário está fechado.

O exemplo ancora um comentário moderno às palavras “quarterly revenue” no texto de um retângulo. Ele calcula o início da seleção baseado em zero a partir do texto e o passa para [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) e usa [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) para definir o número de caracteres selecionados. Após chamar [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) com `Resolved`, ele salva e reabre a apresentação. As quatro verificações no console devem imprimir `true`, confirmando que a âncora da forma, o intervalo de texto e o status foram preservados.

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

### **Inspecionar Comentários Modernos Existentes**

O exemplo requer uma apresentação existente contendo comentários modernos e imprime seu texto, status e detalhes de âncora. Para inspecioná‑los, verifique se cada comentário é um [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/), então examine [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) e [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/). Uma forma `null` indica um comentário ao nível do slide. Para uma âncora [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), os métodos de seleção de texto identificam o intervalo associado no quadro de texto da forma.

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

## **Remover Comentários**

Aspose.Slides para PHP via Java permite remover todos os comentários e seus autores de uma apresentação ou excluir comentários selecionados mantendo os demais. Os exemplos a seguir demonstram ambas as abordagens e salvam a apresentação atualizada.

### **Remover Todos os Comentários e Autores de Comentário**

O exemplo abre uma apresentação existente e chama [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) para cada autor, então chama [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) para remover os próprios autores. A apresentação salva não contém nem comentários nem autores de comentários. Use uma apresentação que contenha comentários para observar a remoção.

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

### **Remover Comentários Específicos**

O exemplo cria dois comentários em um slide e usa [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) para encontrar comentários de cada autor. Ele coleta comentários cujo texto seja igual a “comment 1” antes de chamar [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/), evitando alterações na coleção durante a seleção. A apresentação salva retém apenas “comment 2”.

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

## **FAQ**

**Aspose.Slides suporta um status resolvido para comentários modernos?**

Sim. [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) e [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) acessam um valor de [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/), incluindo `Resolved`. O status é armazenado na apresentação e pode ser lido novamente após o arquivo ser reaberto.

**As discussões em cadeia (respostas) são suportadas e há um limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), permitindo cadeias de respostas. A API não define um limite específico de profundidade de aninhamento.

**Em que sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição do marcador é definida por coordenadas de ponto flutuante no sistema de coordenadas do slide, permitindo posicioná‑lo precisamente no slide.