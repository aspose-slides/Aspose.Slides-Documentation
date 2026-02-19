---
title: Комментарий
type: docs
weight: 230
url: /ru/java/examples/elements/comment/
keywords:
- пример кода
- комментарий
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Работайте с комментариями к слайдам в Aspose.Slides for Java: добавляйте, отвечайте, редактируйте, разрешайте и экспортируйте комментарии в презентациях PPT, PPTX и ODP с примерами кода на Java."
---
В этой статье демонстрируется добавление, чтение, удаление и ответы на современные комментарии с использованием **Aspose.Slides for Java**.

## **Добавить современный комментарий**

Создайте комментарий, написанный пользователем, и сохраните презентацию.

```java
static void addModernComment() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ICommentAuthor author = presentation.getCommentAuthors().addAuthor("User", "U1");
        author.getComments().addModernComment(
                "This is a modern comment", slide, null, new Point2D.Float(100, 100), new java.util.Date());

        presentation.save("modern_comment.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Получить современный комментарий**

Прочитайте современный комментарий из существующей презентации.

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

## **Удалить современный комментарий**

Удалите комментарий и сохраните обновлённый файл.

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

## **Ответить на современный комментарий**

Добавьте ответы к родительскому современному комментарию.

```java
static void replyToModernComment() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ICommentAuthor author = presentation.getCommentAuthors().addAuthor("User", "U1");

        IModernComment parentComment = author.getComments().addModernComment(
                "Parent comment", slide, null, new Point2D.Float(100, 100), new java.util.Date());
        
        IModernComment reply1 = author.getComments().addModernComment(
                "Reply 1", slide, null, new Point2D.Float(110, 100), new java.util.Date());
        
        IModernComment reply2 = author.getComments().addModernComment(
                "Reply 2", slide, null, new Point2D.Float(120, 100), new java.util.Date());

        reply1.setParentComment(parentComment);
        reply2.setParentComment(parentComment);

        presentation.save("modern_comment_replies.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```