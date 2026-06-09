---
title: Gerenciar comentários de apresentação em JavaScript
linktitle: Comentários de Apresentação
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
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine comentários de apresentação com Aspose.Slides para Node.js: adicione, leia, edite e exclua comentários em arquivos PowerPoint usando JavaScript de forma rápida e fácil."
---
## **Visão geral**

Este artigo explica como gerenciar comentários em apresentações no Aspose.Slides. Ele mostra os principais tipos relacionados a comentários e demonstra como adicionar comentários a slides, acessar comentários existentes, trabalhar com respostas, usar comentários modernos e remover comentários de uma apresentação.

Os exemplos se concentram em cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o conteúdo e os metadados dos comentários, construir cadeias de respostas e limpar todos os comentários ou excluir os selecionados.

No PowerPoint, um comentário aparece como uma nota ou anotação em um slide. Quando um comentário é clicado, seu conteúdo ou mensagens são revelados.

## **Por que adicionar comentários a apresentações?**

Você pode querer usar comentários para fornecer feedback ou se comunicar com seus colegas ao revisar apresentações.

Para permitir que você use comentários em apresentações do PowerPoint, o Aspose.Slides for Node.js via Java oferece
* The [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) class, que contém as coleções de autores (da classe [CommentAuthorCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/CommentAuthorCollection)). Os autores adicionam comentários aos slides.
* The  [CommentCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/CommentCollection) class, que contém a coleção de comentários para autores individuais.
* The  [Comment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Comment) class, que contém informações sobre os autores e seus comentários: quem adicionou o comentário, a hora em que o comentário foi adicionado, a posição do comentário, etc.
* The [CommentAuthor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/CommentAuthor) class, que contém informações sobre autores individuais: o nome do autor, suas iniciais, comentários associados ao nome do autor, etc.

## **Adicionar comentário ao slide**

Este código JavaScript mostra como adicionar um comentário a um slide em uma apresentação do PowerPoint:

```javascript
// Instancia a classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Adiciona um slide vazio
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Adiciona um autor
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Define a posição para os comentários
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Adiciona comentário de slide para um autor no slide 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Adiciona comentário de slide para um autor no slide 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Acessa ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // Quando null é passado como argumento, comentários de todos os autores são trazidos para o slide selecionado
    var Comments = slide.getSlideComments(author);
    // Acessa o comentário no índice 0 do slide 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Seleciona a coleção de comentários do Autor no índice 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Acessar comentários do slide**

Este código JavaScript mostra como acessar um comentário existente em um slide em uma apresentação do PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Responder a comentários**

Um comentário pai é o comentário superior ou original em uma hierarquia de comentários ou respostas. Usando os métodos [getParentComment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Comment#getParentComment--) ou [setParentComment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (da classe [Comment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Comment)), você pode definir ou obter um comentário pai.

Este código JavaScript mostra como adicionar comentários e obter respostas a eles:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adiciona um comentário
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Adiciona uma resposta ao comment1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Adiciona outra resposta ao comment1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Adiciona uma resposta a uma resposta existente
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Exibe a hierarquia de comentários no console
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // Remove comment1 e todas as respostas a ele
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Atenção" %}} 
* Quando o método [Remove](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Comment#remove--) (da classe [Comment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Comment)) é usado para excluir um comentário, as respostas ao comentário também são excluídas.
* Se a definição de [setParentComment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) resultar em uma referência circular, será lançada a exceção [PptxEditException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PptxEditException).
{{% /alert %}}

## **Adicionar comentário moderno**

Em 2021, a Microsoft introduziu *comentários modernos* no PowerPoint. O recurso de comentários modernos melhora significativamente a colaboração no PowerPoint. Por meio dos comentários modernos, os usuários do PowerPoint podem resolver comentários, ancorar comentários a objetos e textos e interagir de forma muito mais fácil do que antes. 

O Aspose.Slides oferece suporte a comentários modernos por meio da classe [ModernComment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ModernComment). Os métodos [addModernComment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) e [insertModernComment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) foram adicionados à classe [CommentCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/CommentCollection).

Este código JavaScript mostra como adicionar um comentário moderno a um slide em uma apresentação do PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Remover comentário**

### **Excluir todos os comentários e autores**

Este código JavaScript mostra como remover todos os comentários e autores em uma apresentação:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Exclui todos os comentários da apresentação
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Exclui todos os autores
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Excluir comentários específicos**

Este código JavaScript mostra como excluir comentários específicos em um slide:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // adiciona comentários...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // remove todos os comentários que contêm o texto "comment 1"
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Perguntas frequentes**

**O Aspose.Slides oferece suporte a um status como 'resolvido' para comentários modernos?**

Sim. [Modern comments](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/) expõem os métodos [getStatus](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/getstatus/) e [setStatus](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncomment/setStatus/); você pode ler e definir o [estado do comentário](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/moderncommentstatus/) (por exemplo, marcá‑lo como resolvido), e esse estado é salvo no arquivo e reconhecido pelo PowerPoint.

**As discussões em tópicos (cadeias de respostas) são suportadas e há um limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [parent comment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/comment/getparentcomment/), permitindo cadeias de respostas arbitrárias. A API não declara um limite específico de profundidade de aninhamento.

**Em qual sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição é armazenada como um ponto de ponto flutuante no sistema de coordenadas do slide. Isso permite posicionar o marcador de comentário exatamente onde for necessário.