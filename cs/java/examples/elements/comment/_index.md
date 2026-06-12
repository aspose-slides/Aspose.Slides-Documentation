---
title: Komentář
type: docs
weight: 230
url: /cs/java/examples/elements/comment/
keywords:
- ukázka kódu
- komentář
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Pracujte s komentáři snímků v Aspose.Slides for Java: přidávejte, odpovídejte, upravujte, řešte a exportujte komentáře v prezentacích PPT, PPTX a ODP pomocí ukázek kódu v jazyce Java."
---
Tento článek demonstruje přidávání, čtení, odstraňování a odpovídání na moderní komentáře pomocí **Aspose.Slides for Java**.

## **Přidání moderního komentáře**

Vytvořte komentář vytvořený uživatelem a uložte prezentaci.

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

## **Přístup k modernímu komentáři**

Přečtěte moderní komentář z existující prezentace.

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

## **Odstranění moderního komentáře**

Odstraňte komentář a uložte aktualizovaný soubor.

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

## **Odpověď na moderní komentář**

Přidejte odpovědi k nadřazenému modernímu komentáři.

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