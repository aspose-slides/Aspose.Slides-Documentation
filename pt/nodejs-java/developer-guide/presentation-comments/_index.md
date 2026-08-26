---
title: Gerenciar comentários de apresentação em Node.js
linktitle: Comentários de apresentação
type: docs
weight: 100
url: /pt/nodejs-java/presentation-comments/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie comentários de apresentação com Aspose.Slides para Node.js via Java: adicione, leia, edite, responda e remova comentários em apresentações do PowerPoint."
---
## **Visão geral**

Este artigo explica como gerenciar comentários de apresentação com Aspose.Slides for Node.js via Java. Ele apresenta os principais tipos relacionados a comentários e demonstra como adicionar comentários a slides, acessar comentários existentes, trabalhar com respostas e comentários modernos, e remover comentários de uma apresentação.

Os exemplos cobrem cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o texto e os metadados dos comentários, construir cadeias de respostas e remover comentários selecionados ou todos os comentários.

No PowerPoint, os comentários aparecem como anotações nos slides. Selecionar um comentário exibe seu texto e a discussão relacionada.

## **Por que adicionar comentários às apresentações?**

Você pode usar comentários para fornecer feedback e colaborar com colegas ao revisar apresentações.

Aspose.Slides for Node.js via Java oferece as seguintes APIs para trabalhar com comentários:

* A classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) que fornece acesso aos autores de comentários da apresentação.
* A classe [CommentCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/commentcollection/) que representa os comentários associados a um autor específico.
* A classe [Comment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/comment/) que fornece informações sobre um comentário, incluindo autor, horário de criação, posição e texto.
* A classe [CommentAuthor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/commentauthor/) que fornece informações sobre um autor, incluindo nome, iniciais e comentários associados.

## **Adicionar comentários a slides**

O exemplo a seguir mostra como adicionar comentários a slides em uma apresentação do PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acessar comentários de slides**

O exemplo a seguir mostra como acessar comentários existentes em uma apresentação do PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Responder a comentários**

Um comentário pai é o comentário original no topo de uma hierarquia de respostas. Os métodos [Comment.getParentComment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/comment/getparentcomment/) e [Comment.setParentComment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/comment/setparentcomment/) permitem obter ou definir o pai de um comentário.

O exemplo a seguir mostra como adicionar respostas e inspecionar a hierarquia de comentários resultante:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Aviso" %}}

* Quando o método [Comment.remove](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/comment/remove/) é usado para excluir um comentário, todas as respostas desse comentário também são excluídas.
* Se [Comment.setParentComment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/comment/setparentcomment/) criar uma referência circular, uma [PptxEditException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxeditexception/) é lançada.

{{% /alert %}}

## **Adicionar comentários modernos**

Comentários modernos podem ser associados ao próprio slide, a uma forma específica ou a um intervalo de texto dentro de um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/). O método [CommentCollection.addModernComment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) aceita um argumento [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) além do slide e das coordenadas do marcador de comentário.

Quando `null` é passado para o argumento shape, o comentário é um comentário ao nível do slide. Seu marcador é posicionado pelas coordenadas fornecidas, mas não está associado a uma forma específica, de modo que [ModernComment.getShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/getshape/) devolve `null`. Quando uma [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) é fornecida, o comentário é ancorado a essa forma. As coordenadas ainda definem a posição do marcador de comentário no slide, enquanto a associação à forma pode ser obtida via [ModernComment.getShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Ancorar um comentário moderno a uma forma**

O exemplo a seguir cria tanto um comentário moderno ao nível do slide quanto um comentário moderno ancorado a um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) específico. Em seguida, lê a forma associada de cada comentário.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ancorar comentários a diferentes tipos de forma**

Qualquer objeto de slide derivado de [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) pode ser usado como âncora de forma. Exemplos comuns incluem [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/connector/) e instâncias de [GraphicalObject](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/graphicalobject/) como gráficos.

O exemplo a seguir cria vários tipos de forma comuns e associa um comentário moderno a cada um deles.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ancorar um comentário a texto e definir seu status**

Para um comentário moderno associado a um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/), os métodos [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) e [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) acessam a posição inicial do texto selecionado na moldura de texto da forma. Os métodos [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) e [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) acessam o comprimento da seleção. Juntos, esses valores associam o comentário a um intervalo de texto específico dentro do [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/).

Os métodos [ModernComment.getStatus](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/getstatus/) e [ModernComment.setStatus](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/setstatus/) acessam um valor da enumeração [ModernCommentStatus](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — nenhum status específico de comentário moderno está definido.
- `Active` — o comentário está ativo.
- `Resolved` — o comentário foi resolvido.
- `Closed` — o comentário está fechado.

O exemplo a seguir cria um comentário moderno ancorado a uma forma, o associa a uma seleção de texto, marca-o como resolvido, salva a apresentação e verifica os valores após reabrir o arquivo.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Inspecionar comentários modernos existentes**

Para inspecionar uma apresentação existente, verifique quais comentários são instâncias de [ModernComment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/), então examine [ModernComment.getShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) e [ModernComment.getStatus](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/getstatus/). Uma forma `null` indica um comentário ao nível do slide. Para uma âncora de [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/), os métodos de seleção de texto identificam o intervalo associado na moldura de texto da forma.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Remover comentários**

### **Remover todos os comentários e autores de comentários**

O exemplo a seguir mostra como remover todos os comentários e autores de comentários de uma apresentação:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Remover comentários específicos**

O exemplo a seguir mostra como remover comentários específicos de um slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**O Aspose.Slides oferece suporte a um status resolvido para comentários modernos?**

Sim. Os métodos [ModernComment.getStatus](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/getstatus/) e [ModernComment.setStatus](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/setstatus/) acessam um valor de [ModernCommentStatus](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncommentstatus/), incluindo `Resolved`. O status é armazenado na apresentação e pode ser lido novamente após o arquivo ser reaberto.

**As discussões em tópicos (cadeias de respostas) são suportadas e há um limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [parent comment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/comment/getparentcomment/), permitindo cadeias de respostas. A API não define um limite específico de profundidade de aninhamento.

**Em que sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição do marcador é definida por coordenadas de ponto flutuante no sistema de coordenadas do slide, permitindo que você o posicione com precisão no slide.