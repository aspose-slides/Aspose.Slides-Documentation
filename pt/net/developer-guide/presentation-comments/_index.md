---
title: Gerenciar Comentários de Apresentação em .NET
linktitle: Comentários de Apresentação
type: docs
weight: 100
url: /pt/net/presentation-comments/
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
- .NET
- C#
- Aspose.Slides
description: "Domine os comentários de apresentações com Aspose.Slides para .NET: adicione, leia, edite e exclua comentários em arquivos PowerPoint de forma rápida e fácil."
---
## **Visão geral**

Este artigo explica como gerenciar comentários de apresentações no Aspose.Slides. Ele mostra os principais tipos relacionados a comentários e demonstra como adicionar comentários a slides, acessar comentários existentes, trabalhar com respostas, usar comentários modernos e remover comentários de uma apresentação.

Os exemplos se concentram em cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o conteúdo e os metadados dos comentários, criar cadeias de respostas e limpar todos os comentários ou excluir os selecionados.

No PowerPoint, um comentário aparece como uma nota ou anotação em um slide. Quando um comentário é clicado, seu conteúdo ou mensagens são revelados.

## **Por que adicionar comentários às apresentações?**

Você pode querer usar comentários para fornecer feedback ou se comunicar com seus colegas ao revisar apresentações.

Para permitir que você use comentários em apresentações do PowerPoint, o Aspose.Slides para .NET oferece

* A classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) que contém as coleções de autores (da propriedade [CommentAuthorCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/icommentauthorcollection/properties/index)). Os autores adicionam comentários aos slides. 
* A interface [ICommentCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/icommentcollection) que contém a coleção de comentários para autores individuais. 
* A classe [IComment](https://reference.aspose.com/slides/pt/net/aspose.slides/icomment) que contém informações sobre os autores e seus comentários: quem adicionou o comentário, a hora em que o comentário foi adicionado, a posição do comentário etc. 
* A classe [CommentAuthor](https://reference.aspose.com/slides/pt/net/aspose.slides/commentauthor) que contém informações sobre autores individuais: o nome do autor, suas iniciais, comentários associados ao nome do autor etc. 

## **Adicionar comentários aos slides**
Este código C# mostra como adicionar um comentário a um slide em uma apresentação PowerPoint:

```c#
// Instancia a classe Presentation
using (Presentation presentation = new Presentation())
{
    // Adiciona um slide vazio
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Adiciona um autor
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Define a posição dos comentários
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Adiciona comentário de slide para um autor no slide 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Adiciona comentário de slide para um autor no slide 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Acessa ISlide 1
    ISlide slide = presentation.Slides[0];

    // Quando null é passado como argumento, comentários de todos os autores são trazidos para o slide selecionado
    IComment[] Comments = slide.GetSlideComments(author);

    // Acessa o comentário no índice 0 para o slide 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Seleciona a coleção de comentários do Autor no índice 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Acessar comentários dos slides**
Este código C# mostra como acessar um comentário existente em um slide em uma apresentação PowerPoint:

```c#
// Instancia a classe Presentation
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **Responder a comentários**
Um comentário principal é o comentário superior ou original em uma hierarquia de comentários ou respostas. Usando a propriedade [ParentComment](https://reference.aspose.com/slides/pt/net/aspose.slides/icomment/properties/parentcomment) (da interface [IComment](https://reference.aspose.com/slides/pt/net/aspose.slides/icomment)), você pode definir ou obter um comentário principal.

Este código C# mostra como adicionar comentários e obter respostas a eles:

```c#
using (Presentation pres = new Presentation())
{
    // Adiciona um comentário
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Adiciona uma resposta ao comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Adiciona outra resposta ao comment1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Adiciona uma resposta a uma resposta existente
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Exibe a hierarquia de comentários no console
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // Remove o comment1 e todas as respostas a ele
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Atenção" %}} 
* Quando o método [Remove](https://reference.aspose.com/slides/pt/net/aspose.slides/icomment/methods/remove) (da interface [IComment](https://reference.aspose.com/slides/pt/net/aspose.slides/icomment)) é usado para excluir um comentário, as respostas ao comentário também são excluídas. 
* Se a configuração [ParentComment](https://reference.aspose.com/slides/pt/net/aspose.slides/icomment/properties/parentcomment) resultar em uma referência circular, a [PptxEditException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxeditexception) será lançada.
{{% /alert %}}

## **Adicionar comentários modernos**

Em 2021, a Microsoft introduziu *comentários modernos* no PowerPoint. O recurso de comentários modernos melhora significativamente a colaboração no PowerPoint. Por meio dos comentários modernos, os usuários do PowerPoint podem resolver comentários, ancorar comentários a objetos e textos e interagir de forma muito mais fácil do que antes. 

Na versão [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/pt/net/aspose-slides-for-net-21-11-release-notes/), implementamos suporte a comentários modernos adicionando a classe [ModernComment](https://reference.aspose.com/slides/pt/net/aspose.slides/moderncomment). Os métodos [AddModernComment](https://reference.aspose.com/slides/pt/net/aspose.slides/commentcollection/methods/addmoderncomment) e [InsertModernComment](https://reference.aspose.com/slides/pt/net/aspose.slides/commentcollection/methods/insertmoderncomment) foram adicionados à classe [CommentCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/commentcollection). 

Este código C# mostra como adicionar um comentário moderno a um slide em uma apresentação PowerPoint: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Remover comentários**

### **Excluir todos os comentários e autores**
Este código C# mostra como remover todos os comentários e autores em uma apresentação:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Exclui todos os comentários da apresentação
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Exclui todos os autores
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Excluir comentários específicos**
Este código C# mostra como excluir comentários específicos em um slide:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // adiciona comentários...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // remove todos os comentários que contêm o texto "comment 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**O Aspose.Slides oferece suporte a um status como 'resolvido' para comentários modernos?**

Sim. Os *comentários modernos* expõem uma propriedade [Status](https://reference.aspose.com/slides/pt/net/aspose.slides/moderncomment/status/) ; você pode ler e definir o estado de um comentário (por exemplo, marcá‑lo como resolvido), e esse estado é salvo no arquivo e reconhecido pelo PowerPoint.

**As discussões em threads (cadeias de respostas) são suportadas e há um limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [parent comment](https://reference.aspose.com/slides/pt/net/aspose.slides/comment/parentcomment/), permitindo cadeias de respostas arbitrárias. A API não declara um limite específico de profundidade de aninhamento.

**Em qual sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição é armazenada como um ponto de ponto flutuante no sistema de coordenadas do slide. Isso permite posicionar o marcador de comentário exatamente onde for necessário.