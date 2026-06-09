---
title: Comentário
type: docs
weight: 230
url: /pt/androidjava/examples/elements/comment/
keywords:
  - exemplo de código
  - comentário
  - PowerPoint
  - OpenDocument
  - apresentação
  - Android
  - Java
  - Aspose.Slides
description: "Trabalhe com comentários de slides no Aspose.Slides para Android: adicione, responda, edite, resolva e exporte comentários em apresentações PPT, PPTX e ODP com exemplos de código Java."
---
Este artigo demonstra como adicionar, ler, remover e responder a comentários modernos usando **Aspose.Slides for Android via Java**.

## **Adicionar um Comentário Moderno**

Crie um comentário criado por um usuário e salve a apresentação.

```java
static void addModernComment() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ICommentAuthor author = presentation.getCommentAuthors().addAuthor("User", "U1");
        author.getComments().addModernComment(
                "This is a modern comment", slide, null, new android.graphics.PointF(100, 100), new java.util.Date());

        presentation.save("modern_comment.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar um Comentário Moderno**

Leia um comentário moderno de uma apresentação existente.

```java
static void accessModernComment() {
    Presentation presentation = new Presentation("modern_comment.pptx");
    try {
        ICommentAuthor author = presentation.getCommentAuthors().get_Item(0);
        IModernComment comment = (IModernComment) author.getComments().get_Item(0);
        System.out.println("Author: " + author.getName() + ", Comment: " + comment.getText() + ", Position: " + comment.getPosition());
    } finally {
        presentation.dispose();
    }
}
```

## **Remover um Comentário Moderno**

Remova um comentário e salve o arquivo atualizado.

```java
static void removeModernComment() {
    Presentation presentation = new Presentation("modern_comment.pptx");
    try {
        ICommentAuthor author = presentation.getCommentAuthors().get_Item(0);

        IComment comment = author.getComments().get_Item(0);
        comment.remove();

        presentation.save("modern_comment_removed.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Responder a um Comentário Moderno**

Adicione respostas a um comentário moderno pai.

```java
static void replyToModernComment() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ICommentAuthor author = presentation.getCommentAuthors().addAuthor("User", "U1");

        IModernComment parentComment = author.getComments().addModernComment(
                "Parent comment", slide, null, new android.graphics.PointF(100, 100), new java.util.Date());
        
        IModernComment reply1 = author.getComments().addModernComment(
                "Reply 1", slide, null, new android.graphics.PointF(110, 100), new java.util.Date());
        
        IModernComment reply2 = author.getComments().addModernComment(
                "Reply 2", slide, null, new android.graphics.PointF(120, 100), new java.util.Date());

        reply1.setParentComment(parentComment);
        reply2.setParentComment(parentComment);

        presentation.save("modern_comment_replies.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```