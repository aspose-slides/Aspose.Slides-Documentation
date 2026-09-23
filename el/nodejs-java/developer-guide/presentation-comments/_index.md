---
title: "Διαχείριση σχολίων παρουσίασης σε Node.js"
linktitle: "Σχόλια παρουσίασης"
type: docs
weight: 100
url: /el/nodejs-java/presentation-comments/
keywords:
- "σχόλιο"
- "σύγχρονο σχόλιο"
- "σχόλια PowerPoint"
- "σχόλια παρουσίασης"
- "σχόλια διαφάνειας"
- "προσθήκη σχολίου"
- "πρόσβαση σε σχόλιο"
- "επεξεργασία σχολίου"
- "απάντηση σε σχόλιο"
- "αφαίρεση σχολίου"
- "διαγραφή σχολίου"
- "PowerPoint"
- "παρουσίαση"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides για Node.js μέσω Java: προσθέστε, διαβάστε, επεξεργαστείτε, απαντήστε και αφαιρέστε σχόλια σε παρουσιάσεις PowerPoint."
---
## **Overview**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε σχόλια παρουσίασης με το Aspose.Slides για Node.js μέσω Java. Παρουσιάζει τους κύριους τύπους που σχετίζονται με τα σχόλια και δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες, να προσπελαύετε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις και σύγχρονα σχόλια, και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν κοινά σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση κειμένου σχολίου και μεταδεδομένων, η δημιουργία αλυσίδων απαντήσεων, και η αφαίρεση επιλεγμένων σχολίων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις πάνω στις διαφάνειες. Η επιλογή ενός σχολίου εμφανίζει το κείμενό του και τη σχετική συζήτηση.

Για να ζητήσετε να εμφανίζονται ή να κρύβονται τα σχόλια όταν ανοίγει μια παρουσίαση χωρίς να αλλάξετε τα ίδια τα σχόλια, δείτε [Show or Hide Comments When Opening a Presentation](/slides/el/nodejs-java/presentation-view-properties/).

## **Why Add Comments to Presentations?**

Μπορείτε να χρησιμοποιήσετε σχόλια για να παρέχετε feedback και να συνεργάζεστε με συναδέλφους κατά την αξιολόγηση παρουσιάσεων.

Το Aspose.Slides για Node.js μέσω Java παρέχει τις ακόλουθες API για εργασία με σχόλια:

* Την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) που παρέχει πρόσβαση στους συγγραφείς σχολίων της παρουσίασης.
* Την κλάση [CommentCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/commentcollection/) που αντιπροσωπεύει τα σχόλια που σχετίζονται με έναν συγκεκριμένο συγγραφέα.
* Την κλάση [Comment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/comment/) που παρέχει πληροφορίες για ένα σχόλιο, συμπεριλαμβανομένου του συγγραφέα, του χρόνου δημιουργίας, της θέσης και του κειμένου.
* Την κλάση [CommentAuthor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/commentauthor/) που παρέχει πληροφορίες για έναν συγγραφέα, όπως το όνομα, τα αρχικά και τα συσχετισμένα σχόλια.

## **Add Slide Comments**

Το ακόλουθο παράδειγμα δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες σε μια παρουσίαση PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Access Slide Comments**

Το ακόλουθο παράδειγμα δείχνει πώς να προσπελάζετε υπάρχοντα σχόλια σε μια παρουσίαση PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Reply to Comments**

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Οι μέθοδοι [Comment.getParentComment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/comment/getparentcomment/) και [Comment.setParentComment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/comment/setparentcomment/) σάς επιτρέπουν να λάβετε ή να ορίσετε το γονιό ενός σχολίου.

Το ακόλουθο παράδειγμα δείχνει πώς να προσθέτετε απαντήσεις και να εξετάζετε τη δημιουργούμενη ιεραρχία σχολίων:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Όταν χρησιμοποιείται η μέθοδος [Comment.remove](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/comment/remove/) για τη διαγραφή ενός σχολίου, όλες οι απαντήσεις σε αυτό το σχόλιο διαγράφονται επίσης.
* Εάν η [Comment.setParentComment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/comment/setparentcomment/) δημιουργεί κυκλική αναφορά, πετιέται μια [PptxEditException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Add Modern Comments**

Τα σύγχρονα σχόλια μπορούν να συσχετιστούν είτε με τη διαφάνεια αυτή καθ' αυτή, είτε με ένα συγκεκριμένο σχήμα, είτε με μια περιοχή κειμένου μέσα σε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/). Η μέθοδος [CommentCollection.addModernComment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) δέχεται ένα όρισμα τύπου [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) εκτός από τη διαφάνεια και τις συντεταγμένες του σημειωτή σχολίου.

Όταν περνιέται `null` για το όρισμα shape, το σχόλιο είναι σχόλιο επιπέδου διαφάνειας. Ο σημενέας του τοποθετείται με τις δοθείσες συντεταγμένες, αλλά δεν σχετίζεται με κάποιο συγκεκριμένο σχήμα, έτσι η [ModernComment.getShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/getshape/) επιστρέφει `null`. Όταν παρέχεται ένα [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/), το σχόλιο αγκυροβολείται σε αυτό το σχήμα. Οι συντεταγμένες εξακολουθούν να ορίζουν τη θέση του σημειωτή του σχολίου στη διαφάνεια, ενώ η συσχέτιση με το σχήμα μπορεί να ληφθεί μέσω της [ModernComment.getShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Anchor a Modern Comment to a Shape**

Το ακόλουθο παράδειγμα δημιουργεί τόσο ένα σχόλιο σύγχρονο επιπέδου διαφάνειας όσο και ένα σχόλιο σύγχρονο αγκυροβολημένο σε ένα συγκεκριμένο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/). Στη συνέχεια διαβάζει το συσχετισμένο σχήμα από κάθε σχόλιο.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Anchor Comments to Different Shape Types**

Οποιοδήποτε αντικείμενο διαφάνειας που προέρχεται από το [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) μπορεί να χρησιμοποιηθεί ως άγκυρα σχήματος. Συνηθισμένα παραδείγματα περιλαμβάνουν [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/connector/), και παραδείγματα [GraphicalObject](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/graphicalobject/) όπως διαγράμματα.

Το ακόλουθο παράδειγμα δημιουργεί αρκετούς κοινούς τύπους σχημάτων και συσχετίζει ένα σύγχρονο σχόλιο με το καθένα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Anchor a Comment to Text and Set Its Status**

Για ένα σύγχρονο σχόλιο που σχετίζεται με ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/), οι μέθοδοι [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) και [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) προσπελαύνουν τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος. Οι [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) και [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) προσπελαύνουν το μήκος της επιλογής. Μαζί, αυτές οι τιμές συσχετίζουν το σχόλιο με μια συγκεκριμένη περιοχή κειμένου μέσα στο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/).

Οι μέθοδοι [ModernComment.getStatus](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/getstatus/) και [ModernComment.setStatus](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/setstatus/) προσπελαύνουν μια τιμή από την απαρίθμηση [ModernCommentStatus](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — δεν έχει οριστεί συγκεκριμένη κατάσταση σύγχρονου σχολίου.
- `Active` — το σχόλιο είναι ενεργό.
- `Resolved` — το σχόλιο έχει επιλυθεί.
- `Closed` — το σχόλιο είναι κλειστό.

Το ακόλουθο παράδειγμα δημιουργεί ένα σχήμα‑αγκυροβολημένο σύγχρονο σχόλιο, το συσχετίζει με μια επιλογή κειμένου, το σημειώνει ως επιλυμένο, αποθηκεύει την παρουσίαση και ελέγχει τις τιμές μετά το άνοιγμα του αρχείου.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Inspect Existing Modern Comments**

Για να εξετάσετε μια υπάρχουσα παρουσίαση, ελέγξτε ποια σχόλια είναι αντικείμενα [ModernComment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/), έπειτα δείτε τις [ModernComment.getShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), και [ModernComment.getStatus](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/getstatus/). Ένα σχήμα `null` υποδεικνύει σχόλιο επιπέδου διαφάνειας. Για σχήμα‑άγκυρα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/), οι μέθοδοι επιλογής κειμένου προσδιορίζουν τη σχετική περιοχή στο πλαίσιο κειμένου του σχήματος.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Remove Comments**

### **Remove All Comments and Comment Authors**

Το ακόλουθο παράδειγμα δείχνει πώς να αφαιρέσετε όλα τα σχόλια και όλους τους συγγραφείς σχολίων από μια παρουσίαση:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Remove Specific Comments**

Το ακόλουθο παράδειγμα δείχνει πώς να αφαιρέσετε συγκεκριμένα σχόλια από μια διαφάνεια:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Υπάρχει υποστήριξη για κατάσταση “επιλυμένο” σε σύγχρονα σχόλια;**

Ναι. Οι [ModernComment.getStatus](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/getstatus/) και [ModernComment.setStatus](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/setstatus/) προσπελαύνουν μια τιμή του [ModernCommentStatus](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncommentstatus/), συμπεριλαμβανομένου του `Resolved`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να διαβαστεί ξανά μετά το άνοιγμα του αρχείου.

**Υποστηρίζονται αλληλουχίες συζητήσεων (αλυσίδες απαντήσεων) και υπάρχει όριο στο βάθος εμφώλευσης;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρεται στο [parent comment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/comment/getparentcomment/), επιτρέποντας αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους εμφώλευσης.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του σημειωτή του σχολίου στη διαφάνεια;**

Η θέση του σημειωτή ορίζεται από συντεταγμένες κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντάς σας να τοποθετήσετε ακριβώς το σημείο στη διαφάνεια.