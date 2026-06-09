---
title: Gerenciar Comentários de Apresentação em Java
linktitle: Comentários de Apresentação
type: docs
weight: 100
url: /pt/java/presentation-comments/
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
- Java
- Aspose.Slides
description: "Domine comentários de apresentação com Aspose.Slides for Java: adicione, leia, edite e exclua comentários em arquivos PowerPoint rápida e facilmente."
---
## **Visão geral**

Este artigo explica como gerenciar comentários de apresentação no Aspose.Slides. Ele mostra os principais tipos relacionados a comentários e demonstra como adicionar comentários aos slides, acessar comentários existentes, trabalhar com respostas, usar comentários modernos e remover comentários de uma apresentação.

Os exemplos focam em cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o conteúdo e metadados dos comentários, construir cadeias de respostas e limpar todos os comentários ou excluir os selecionados.

No PowerPoint, um comentário aparece como uma nota ou anotação em um slide. Quando um comentário é clicado, seu conteúdo ou mensagens são revelados.

## **Por que adicionar comentários às apresentações?**

Você pode querer usar comentários para fornecer feedback ou se comunicar com seus colegas ao revisar apresentações.

Para permitir que você use comentários em apresentações do PowerPoint, o Aspose.Slides for Java fornece

* A classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation), que contém as coleções de autores (da interface [ICommentAuthorCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICommentAuthorCollection)). Os autores adicionam comentários aos slides. 
* A interface [ICommentCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICommentCollection), que contém a coleção de comentários para autores individuais. 
* A classe [IComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IComment), que contém informações sobre autores e seus comentários: quem adicionou o comentário, a hora em que o comentário foi adicionado, a posição do comentário, etc. 
* A classe [CommentAuthor](https://reference.aspose.com/slides/pt/java/com.aspose.slides/CommentAuthor), que contém informações sobre autores individuais: o nome do autor, suas iniciais, comentários associados ao nome do autor, etc. 

## **Adicionar comentários ao slide**
Este código Java mostra como adicionar um comentário a um slide em uma apresentação do PowerPoint:

```java
// Instancia a classe Presentation
Presentation pres = new Presentation();
try {
    // Adiciona um slide vazio
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Adiciona um autor
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Define a posição dos comentários
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Adiciona comentário de slide para um autor no slide 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Adiciona comentário de slide para um autor no slide 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Acessa o ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Quando null é passado como argumento, os comentários de todos os autores são trazidos para o slide selecionado
    IComment[] Comments = slide.getSlideComments(author);

    // Acessa o comentário no índice 0 do slide 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Seleciona a coleção de comentários do autor no índice 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acessar comentários do slide**
Este código Java mostra como acessar um comentário existente em um slide em uma apresentação do PowerPoint:

```java
// Instancia a classe Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Responder a comentários**
Um comentário pai é o comentário superior ou original em uma hierarquia de comentários ou respostas. Usando os métodos [getParentComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IComment#getParentComment--) ou [setParentComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (da interface [IComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IComment)), você pode definir ou obter um comentário pai. 

Este código Java mostra como adicionar comentários e obter respostas a eles:

```java
Presentation pres = new Presentation();
try {
    // Adiciona um comentário
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Adiciona uma resposta ao comentário1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Adiciona outra resposta ao comentário1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Adiciona uma resposta a uma resposta existente
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Exibe a hierarquia de comentários no console
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // Remove o comentário1 e todas as respostas a ele
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Atenção" %}} 

* Quando o método [Remove](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IComment#remove--) (da interface [IComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IComment)) é usado para excluir um comentário, as respostas ao comentário também são excluídas. 
* Se a configuração de [setParentComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) resultar em uma referência circular, será lançada a exceção [PptxEditException](https://reference.aspose.com/slides/pt/java/com.aspose.slides/PptxEditException).

{{% /alert %}}

## **Adicionar comentários modernos**

Em 2021, a Microsoft introduziu *comentários modernos* no PowerPoint. O recurso de comentários modernos melhora significativamente a colaboração no PowerPoint. Por meio de comentários modernos, os usuários do PowerPoint podem resolver comentários, ancorar comentários a objetos e textos e interagir muito mais facilmente do que antes. 

Na [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/pt/java/aspose-slides-for-java-21-11-release-notes/), implementamos suporte a comentários modernos adicionando a classe [ModernComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ModernComment). Os métodos [addModernComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) e [insertModernComment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) foram adicionados à classe [CommentCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/CommentCollection). 

Este código Java mostra como adicionar um comentário moderno a um slide em uma apresentação do PowerPoint: 

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remover comentários**

### **Excluir todos os comentários e autores**

Este código Java mostra como remover todos os comentários e autores em uma apresentação:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Exclui todos os comentários da apresentação
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Exclui todos os autores
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Excluir comentários específicos**

Este código Java mostra como excluir comentários específicos em um slide:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // adiciona comentários...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // remove todos os comentários que contêm o texto "comment 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Aspose.Slides suporta um status como 'resolvido' para comentários modernos?**

Sim. [Comentários modernos](https://reference.aspose.com/slides/pt/java/com.aspose.slides/moderncomment/) expõem um método [setStatus](https://reference.aspose.com/slides/pt/java/com.aspose.slides/moderncomment/#setStatus-byte-); você pode definir o [estado do comentário](https://reference.aspose.com/slides/pt/java/com.aspose.slides/moderncommentstatus/) (por exemplo, marcá-lo como resolvido), e esse estado é salvo no arquivo e reconhecido pelo PowerPoint.

**As discussões em árvore (cadeias de respostas) são suportadas e há um limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [parent comment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/comment/#getParentComment--), permitindo cadeias de respostas arbitrárias. A API não declara um limite específico de profundidade de aninhamento.

**Em que sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição é armazenada como um ponto de ponto flutuante no sistema de coordenadas do slide. Isso permite que você posicione o marcador de comentário exatamente onde precisar.