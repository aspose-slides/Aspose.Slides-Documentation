---
title: Σχόλιο
type: docs
weight: 230
url: /el/androidjava/examples/elements/comment/
keywords:
- παράδειγμα κώδικα
- σχόλιο
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δουλέψτε με τα σχόλια διαφανειών στο Aspose.Slides for Android: προσθέστε, απαντήστε, επεξεργαστείτε, επιλύστε και εξάγετε σχόλια σε παρουσιάσεις PPT, PPTX και ODP με παραδείγματα κώδικα Java."
---
Αυτό το άρθρο δείχνει την προσθήκη, ανάγνωση, αφαίρεση και απάντηση σε σύγχρονα σχόλια χρησιμοποιώντας **Aspose.Slides for Android via Java**.

## **Προσθήκη Σύγχρονου Σχολίου**

Δημιουργήστε ένα σχόλιο που συντάσσεται από χρήστη και αποθηκεύστε την παρουσίαση.

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

## **Πρόσβαση σε Σύγχρονο Σχόλιο**

Διαβάστε ένα σύγχρονο σχόλιο από υπάρχουσα παρουσίαση.

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

## **Αφαίρεση Σύγχρονου Σχολίου**

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

## **Απάντηση σε Σύγχρονο Σχόλιο**

Προσθέστε απαντήσεις σε ένα γονικό σύγχρονο σχόλιο.

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