---
title: Comentário
type: docs
weight: 230
url: /pt/net/examples/elements/comment/
keywords:
- comentário
- comentário moderno
- adicionar comentário
- acessar comentário
- remover comentário
- responder ao comentário
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Trabalhe com comentários de slides em Aspose.Slides for .NET: adicione, responda, edite, resolva e exporte comentários em apresentações PPT, PPTX e ODP com exemplos de código C#."
---
Este artigo demonstra como adicionar, ler, remover e responder a comentários modernos usando **Aspose.Slides for .NET**.

## **Adicionar um Comentário Moderno**

Crie um comentário criado por um usuário e salve a apresentação.

```csharp
static void AddModernComment()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var author = presentation.CommentAuthors.AddAuthor("User", "U1");
    author.Comments.AddModernComment("This is a modern comment", slide, null, new PointF(100, 100), DateTime.Now);

    presentation.Save("modern_comment.pptx", SaveFormat.Pptx);
}
```

## **Acessar um Comentário Moderno**

Leia um comentário moderno de uma apresentação existente.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Remover um Comentário Moderno**

Remova um comentário e salve o arquivo atualizado.

```csharp
static void RemoveModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = author.Comments[0];
    comment.Remove();

    presentation.Save("modern_comment_removed.pptx", SaveFormat.Pptx);
}
```

## **Responder a um Comentário Moderno**

Adicione respostas a um comentário moderno principal.

```csharp
static void ReplyToModernComment()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var author = presentation.CommentAuthors.AddAuthor("User", "U1");

    var parentComment = author.Comments.AddModernComment("Parent comment", slide, null, new PointF(100, 100), DateTime.Now);
    var reply1 = author.Comments.AddModernComment("Reply 1", slide, null, new PointF(110, 100), DateTime.Now);
    var reply2 = author.Comments.AddModernComment("Reply 2", slide, null, new PointF(120, 100), DateTime.Now);

    reply1.ParentComment = parentComment;
    reply2.ParentComment = parentComment;

    presentation.Save("modern_comment_replies.pptx", SaveFormat.Pptx);
}
```