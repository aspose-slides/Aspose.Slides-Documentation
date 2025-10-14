---
title: Comment
type: docs
weight: 230
url: /androidjava/examples/elements/comment/
keywords:
- code example
- comment
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Work with slide comments in Aspose.Slides for Android: add, reply, edit, resolve, and export comments in PPT, PPTX, and ODP presentations with Java code examples."
---

This article demonstrates adding, reading, removing, and replying to modern comments using **Aspose.Slides for Android via Java**.

## **Add a Modern Comment**

Create a comment authored by a user and save the presentation.

```java
static void addModernComment() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ICommentAuthor author = presentation.getCommentAuthors().addAuthor("User", "U1");
        author.getComments().addModernComment(
                "This is a modern comment", slide, null, new PointF(100, 100), new Date());

        presentation.save("modern_comment.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Modern Comment**

Read a modern comment from an existing presentation.

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

## **Remove a Modern Comment**

Remove a comment and save the updated file.

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

## **Reply to a Modern Comment**

Add replies to a parent modern comment.

```java
static void replyToModernComment() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ICommentAuthor author = presentation.getCommentAuthors().addAuthor("User", "U1");

        IModernComment parentComment = author.getComments().addModernComment(
                "Parent comment", slide, null, new PointF(100, 100), new Date());
        
        IModernComment reply1 = author.getComments().addModernComment(
                "Reply 1", slide, null, new PointF(110, 100), new java.util.Date());
        
        IModernComment reply2 = author.getComments().addModernComment(
                "Reply 2", slide, null, new PointF(120, 100), new java.util.Date());

        reply1.setParentComment(parentComment);
        reply2.setParentComment(parentComment);

        presentation.save("modern_comment_replies.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```
