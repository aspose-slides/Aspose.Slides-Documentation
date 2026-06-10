---
title: Megjegyzés
type: docs
weight: 230
url: /hu/java/examples/elements/comment/
keywords:
- kódpélda
- megjegyzés
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Slide-megjegyzésekkel való munka az Aspose.Slides for Java-ban: megjegyzések hozzáadása, válasz, szerkesztés, megoldás és exportálás PPT, PPTX és ODP bemutatókba Java kódpéldákkal."
---
Ez a cikk bemutatja a modern megjegyzések hozzáadását, olvasását, eltávolítását és a rájuk való válaszadást az **Aspose.Slides for Java** használatával.

## **Modern megjegyzés hozzáadása**

Hozzon létre egy felhasználó által írt megjegyzést, és mentse el a bemutatót.

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

## **Modern megjegyzés elérése**

Olvassa el a modern megjegyzést egy meglévő bemutatóból.

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

## **Modern megjegyzés eltávolítása**

Távolítsa el a megjegyzést, és mentse el a frissített fájlt.

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

## **Válasz a modern megjegyzésre**

Adjon hozzá válaszokat egy szülő modern megjegyzéshez.

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