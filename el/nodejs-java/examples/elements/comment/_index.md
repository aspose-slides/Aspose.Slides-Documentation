---
title: Σχόλιο
type: docs
weight: 230
url: /el/nodejs-java/examples/elements/comment/
keywords:
- παράδειγμα κώδικα
- σχόλιο
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δουλέψτε με τα σχόλια διαφανειών στο Aspose.Slides for Node.js: προσθέστε, απαντήστε, επεξεργαστείτε, επιλύστε και εξαγάγετε σχόλια σε παρουσιάσεις PPT, PPTX και ODP με παραδείγματα κώδικα."
---
Αυτό το άρθρο παρουσιάζει την προσθήκη, την ανάγνωση, τη διαγραφή και την απάντηση σε σύγχρονα σχόλια χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη Σύγχρονου Σχολίου**

Δημιουργήστε ένα σχόλιο που έχει συνταχθεί από χρήστη και αποθηκεύστε την παρουσίαση.

```js
function addModernComment() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let author = presentation.getCommentAuthors().addAuthor("Jhon Smith", "JS");
        let position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100));
        let date = java.newInstanceSync("java.util.Date");

        author.getComments().addModernComment("This is a modern comment", slide, null, position, date);

        presentation.save("modern_comment.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε Σύγχρονο Σχόλιο**

Διαβάστε ένα σύγχρονο σχόλιο από υπάρχουσα παρουσίαση.

```js
function accessModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let author = presentation.getCommentAuthors().get_Item(0);
        let comment = author.getComments().get_Item(0);
        
        console.log("Author: " + author.getName() + ", Comment: " + comment.getText());
    } finally {
        presentation.dispose();
    }
}
```

## **Διαγραφή Σύγχρονου Σχολίου**

Διαγράψτε ένα σχόλιο και αποθηκεύστε το ενημερωμένο αρχείο.

```js
function removeModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let author = presentation.getCommentAuthors().get_Item(0);

        let comment = author.getComments().get_Item(0);
        comment.remove();

        presentation.save("modern_comment_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Απάντηση σε Σύγχρονο Σχόλιο**

Προσθέστε απαντήσεις σε γονικό σύγχρονο σχόλιο.

```js
function replyToModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let author = presentation.getCommentAuthors().get_Item(0);
        let comment = author.getComments().get_Item(0);

        let position1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(110), java.newFloat(100));
        let date1 = java.newInstanceSync("java.util.Date");
        let reply1 = author.getComments().addModernComment("Reply 1", slide, null, position1, date1);

        let position2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(120), java.newFloat(100));
        let date2 = java.newInstanceSync("java.util.Date");
        let reply2 = author.getComments().addModernComment("Reply 2", slide, null, position2, date2);

        reply1.setParentComment(comment);
        reply2.setParentComment(comment);

        presentation.save("modern_comment_replies.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```