---
title: Σχόλιο
type: docs
weight: 230
url: /el/java/examples/elements/comment/
keywords:
- παράδειγμα κώδικα
- σχόλιο
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Δουλέψτε με σχόλια διαφανειών στο Aspose.Slides for Java: προσθέστε, απαντήστε, επεξεργαστείτε, επιλύστε και εξάγετε σχόλια σε παρουσιάσεις PPT, PPTX και ODP με παραδείγματα κώδικα Java."
---
Αυτό το άρθρο δείχνει την προσθήκη, ανάγνωση, διαγραφή και απάντηση σε σύγχρονα σχόλια χρησιμοποιώντας **Aspose.Slides for Java**.

## **Προσθήκη σύγχρονου σχολίου**

Δημιουργήστε ένα σχόλιο που γράφτηκε από χρήστη και αποθηκεύστε την παρουσίαση.

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

## **Πρόσβαση σε σύγχρονο σχόλιο**

Διαβάστε ένα σύγχρονο σχόλιο από μια υπάρχουσα παρουσίαση.

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

## **Αφαίρεση σύγχρονου σχολίου**

Αφαιρέστε ένα σχόλιο και αποθηκεύστε το ενημερωμένο αρχείο.

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

## **Απάντηση σε σύγχρονο σχόλιο**

Προσθέστε απαντήσεις σε ένα γονικό σύγχρονο σχόλιο.

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