---
title: Kommentar
type: docs
weight: 230
url: /de/androidjava/examples/elements/comment/
keywords:
- Codebeispiel
- Kommentar
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Arbeiten Sie mit Folienkommentaren in Aspose.Slides für Android: Hinzufügen, Antworten, Bearbeiten, Auflösen und Exportieren von Kommentaren in PPT-, PPTX- und ODP-Präsentationen mit Java-Codebeispielen."
---
Dieser Artikel demonstriert das Hinzufügen, Lesen, Entfernen und Antworten auf moderne Kommentare mit **Aspose.Slides for Android via Java**.

## **Einen modernen Kommentar hinzufügen**

Erstellen Sie einen von einem Benutzer verfassten Kommentar und speichern Sie die Präsentation.

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

## **Zugriff auf einen modernen Kommentar**

Lesen Sie einen modernen Kommentar aus einer vorhandenen Präsentation.

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

## **Einen modernen Kommentar entfernen**

Entfernen Sie einen Kommentar und speichern Sie die aktualisierte Datei.

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

## **Auf einen modernen Kommentar antworten**

Fügen Sie Antworten zu einem übergeordneten modernen Kommentar hinzu.

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