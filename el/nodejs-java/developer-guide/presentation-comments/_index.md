---
title: Διαχείριση Σχολίων Παρουσίασης σε Node.js
linktitle: Σχόλια Παρουσίασης
type: docs
weight: 100
url: /el/nodejs-java/presentation-comments/
keywords:
- σχόλιο
- σύγχρονο σχόλιο
- σχόλια PowerPoint
- σχόλια παρουσίασης
- σχόλια διαφάνειας
- προσθήκη σχολίου
- πρόσβαση σε σχόλιο
- επεξεργασία σχολίου
- απάντηση σε σχόλιο
- αφαίρεση σχολίου
- διαγραφή σχολίου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχείριση σχολίων παρουσίασης με το Aspose.Slides για Node.js μέσω Java: προσθήκη, ανάγνωση, επεξεργασία, απάντηση και αφαίρεση σχολίων σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε σχόλια παρουσίασης με το Aspose.Slides for Node.js via Java. Παρουσιάζει τους κύριους τύπους σχετικού με τα σχόλια και δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες, να έχετε πρόσβαση σε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις και σύγχρονα σχόλια, και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν κοινές περιπτώσεις ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση του κειμένου σχολίου και των μεταδεδομένων, η δημιουργία αλυσίδων απαντήσεων, και η αφαίρεση επιλεγμένων σχολίων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις σε διαφάνειες. Η επιλογή ενός σχολίου προβάλλει το κείμενο του και τη σχετική συζήτηση.

Για να ζητήσετε τα σχόλια να εμφανίζονται ή να αποκρύπτονται κατά το άνοιγμα μιας παρουσίασης χωρίς να αλλάξετε τα ίδια τα σχόλια, δείτε [Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης](/slides/el/nodejs-java/presentation-view-properties/).

## **Γιατί να Προσθέσετε Σχόλια σε Παρουσιάσεις;**

Μπορείτε να χρησιμοποιήσετε σχόλια για να παρέχετε ανατροφοδότηση και να συνεργαστείτε με συναδέλφους κατά την ανασκόπηση παρουσιάσεων.

Το Aspose.Slides for Node.js via Java παρέχει τα ακόλουθα API για εργασία με σχόλια:

* The [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class, που παρέχει πρόσβαση στους συγγραφείς σχολίων της παρουσίασης.
* The [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) class, που αντιπροσωπεύει τα σχόλια που σχετίζονται με έναν επιμέρους συγγραφέα.
* The [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) class, που παρέχει πληροφορίες για ένα σχόλιο, συμπεριλαμβανομένου του συγγραφέα, του χρόνου δημιουργίας, της θέσης και του κειμένου.
* The [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) class, που παρέχει πληροφορίες για έναν συγγραφέα, συμπεριλαμβανομένου του ονόματός του, των αρχικών και των σχετικών σχολίων.

## **Προσθήκη Σχολίων σε Διαφάνειες**

Το παράδειγμα δημιουργεί δύο διαφάνειες και καταχωρεί έναν συγγραφέα σχολίου με την [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/). Χρησιμοποιεί την [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) για να τοποθετήσει ένα σχόλιο σε κάθε διαφάνεια, στη συνέχεια ανακτά τα σχόλια της πρώτης διαφάνειας για εκείνον τον συγγραφέα με την [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/). Η κονσόλα εμφανίζει το κείμενο του πρώτου σχολίου δύο φορές, δείχνοντας πρόσβαση μέσω τόσο της διαφάνειας όσο και του συγγραφέα, και η αποθηκευμένη παρουσίαση περιέχει και τα δύο σχόλια.

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

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εύρεση ή Δημιουργία Συγγραφέα Σχολίου**

Όταν μια αυτοματοποιημένη αξιολόγηση επεξεργάζεται την ίδια παρουσίαση επανειλημμένα, αναζητήστε τη συλλογή που επιστρέφεται από την [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) πριν προσθέσετε έναν συγγραφέα. Η [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) ταιριάζει τόσο με το όνομα όσο και με τις αρχικές και επιστρέφει έναν πίνακα με τους αντίστοιχους συγγραφείς, ή έναν κενό πίνακα αν δεν υπάρχουν ταιριάσματα. Αντίθετα, η [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) ψάχνει μόνο με βάση το όνομα, ανεξαρτήτως αρχικών. Η κλήση της [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) με όνομα και αρχικές που ήδη υπάρχουν στη συλλογή ρίχνει εξαίρεση.

Το παράδειγμα απαιτεί ένα αρχείο παρουσίασης με τουλάχιστον μία διαφάνεια. Σε κάθε μία από τις δύο περάσεις, επαναχρησιμοποιεί τον πρώτο ταιριαστό συγγραφέα, ή δημιουργεί έναν μόνο όταν το αποτέλεσμα είναι κενό. Εάν υπάρχουν πολλαπλά ταιριάσματα, επιλέγει το πρώτο στοιχείο του πίνακα χωρίς να συγχωνεύει ή να αφαιρεί τους άλλους συγγραφείς. Στη συνέχεια καλεί την [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) για τον επιλεγμένο συγγραφέα και αποθηκεύει την παρουσίαση. Η δεύτερη περάδα ανοίγει το αποτέλεσμα της πρώτης περάδας και επαναλαμβάνει τη λειτουργία.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

Η δεύτερη περάδα προσθέτει ένα ακόμη σχόλιο χωρίς να προσθέσει νέο συγγραφέα ή να αφαιρέσει υπάρχοντα σχόλια. Το τελικό αρχείο, `review_pass_2.pptx`, περιέχει και τα δύο νέα σχόλια μαζί με τυχόν αρχικά σχόλια. Η επαναχρήση ενός συγγραφέα δεν αφαιρεί διπλότυπα σχόλια: για να αποφύγετε την επαναλαμβανόμενη προσθήκη του ίδιου σχολίου, υλοποιήστε ξεχωριστή ανίχνευση διπλότυπων πριν το προσθέσετε.

## **Πρόσβαση σε Σχόλια Διαφάνειας**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και διαβάζει τη συλλογή που επιστρέφεται από την [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/). Για κάθε συγγραφέα, διατρέχει τη συλλογή που επιστρέφεται από την [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) και εκτυπώνει τον αριθμό της διαφάνειας, το κείμενο του σχολίου, το όνομα του συγγραφέα και την ώρα δημιουργίας. Η παρουσίαση εισόδου πρέπει να περιέχει σχόλια για να παραχθεί έξοδος στην κονσόλα.

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

## **Απάντηση σε Σχόλια**

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Οι μέθοδοι [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) και [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) σάς επιτρέπουν να αποκτήσετε ή να ορίσετε το γονικό στοιχείο ενός σχολίου.

Το παράδειγμα δημιουργεί σχόλια από δύο συγγραφείς και χρησιμοποιεί την [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) για να δημιουργήσει απαντήσεις, συμπεριλαμβανομένης μιας απάντησης σε άλλη απάντηση. Η μετάδοση του `null` στην [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) ανακτά σχόλια από όλους τους συγγραφείς· η κονσόλα εσοχεύει κάθε καταχώρηση ανάλογα με το βάθος της στην ιεραρχία απαντήσεων. Το παράδειγμα αποθηκεύει τη συνολική συζήτηση, καλεί το [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) στο πρώτο ριζικό σχόλιο, και αποθηκεύει μια δεύτερη παρουσίαση με το σχόλιο αυτό και τις απαντήσεις του αφαιρεμένα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Όταν η μέθοδος [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) χρησιμοποιείται για τη διαγραφή ενός σχολίου, όλες οι απαντήσεις σε αυτό το σχόλιο διαγράφονται επίσης.
* Εάν η [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) δημιουργήσει κυκλική αναφορά, θα γίνει ρίψη μιας [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Τα σύγχρονα σχόλια μπορούν να συνδεθούν με την ίδια τη διαφάνεια, με ένα συγκεκριμένο σχήμα, ή με μια περιοχή κειμένου μέσα σε AutoShape. Η μέθοδος [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) δέχεται ένα όρισμα τύπου [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) επιπλέον των συντεταγμένων της διαφάνειας και του δείκτη σχολίου.

Όταν περάσει `null` ως όρισμα σχήματος, το σχόλιο είναι σχόλιο επιπέδου διαφάνειας. Ο δείκτης του καθορίζεται από τις δοσμένες συντεταγμένες, αλλά δεν συνδέεται με κάποιο συγκεκριμένο σχήμα, έτσι η [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) επιστρέφει `null`. Όταν παρέχεται ένα [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), το σχόλιο αγκυροβολείται σε εκείνο το σχήμα. Οι συντεταγμένες εξακολουθούν να καθορίζουν τη θέση του δείκτη σχολίου στη διαφάνεια, ενώ η σύνδεση με το σχήμα μπορεί να ανακτηθεί μέσω της [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Αγκύρωση Σύγχρονου Σχολίου σε Σχήμα**

Το παράδειγμα καλεί την [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) δύο φορές: μία με ένα σχήμα `null` για σχόλιο επιπέδου διαφάνειας και μία με ένα ορθογώνιο ως αγκίστρωση. Η ανάγνωση της [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) εκτυπώνει `true` για τον έλεγχο null του σχολίου επιπέδου διαφάνειας και `Revenue title` για το αγκυροβολημένο σχόλιο. Και τα δύο σχόλια αποθηκεύονται με την παρουσίαση.

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

### **Αγκύρωση Σχολίων σε Διαφορετικούς Τύπους Σχημάτων**

Οποιοδήποτε αντικείμενο διαφάνειας που προέρχεται από το [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) μπορεί να χρησιμοποιηθεί ως αγκίστρωση σχήματος. Κοινά παραδείγματα περιλαμβάνουν [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/), και αντικείμενα [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) όπως γραφήματα.

Το παράδειγμα χρησιμοποιεί την [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) για να συσχετίσει ένα σχόλιο με καθέναν από τους πέντε τύπους σχημάτων: ένα AutoShape, ένα πλαίσιο εικόνας, μια ομάδα, έναν σύνδεσμο και ένα γράφημα. Η εικόνα χρησιμοποιεί ενσωματωμένα δεδομένα εικόνας, έτσι δεν απαιτείται εξωτερική εικόνα. Κάθε σχόλιο έχει τη δική του θέση δείκτη, και η αποθηκευμένη παρουσίαση διατηρεί όλες τις πέντε συνδέσεις σχημάτων.

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

### **Αγκύρωση Σχολίου σε Κείμενο και Ορισμός Κατάστασής του**

Για ένα σύγχρονο σχόλιο που συσχετίζεται με ένα [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), οι [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) και [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) προσπελαύνουν τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος. Οι [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) και [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) προσπελαύνουν το μήκος της επιλογής. Μαζί, αυτές οι τιμές συνδέουν το σχόλιο με μια συγκεκριμένη περιοχή κειμένου μέσα στο AutoShape.

Οι [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) και [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) προσεγγίζουν μια τιμή του [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/)·
- `NotDefined` — δεν έχει οριστεί συγκεκριμένη κατάσταση σύγχρονου σχολίου.
- `Active` — το σχόλιο είναι ενεργό.
- `Resolved` — το σχόλιο έχει επιλυθεί.
- `Closed` — το σχόλιο είναι κλειστό.

Το παράδειγμα αγκαλιάζει ένα σύγχρονο σχόλιο στις λέξεις "quarterly revenue" στο κείμενο ενός ορθογωνίου. Υπολογίζει τη μηδενική θέση έναρξης της επιλογής από το κείμενο και τη περνά στην [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/), και χρησιμοποιεί την [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) για να ορίσει τον αριθμό των επιλεγμένων χαρακτήρων. Μετά την κλήση της [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) με `Resolved`, αποθηκεύει και ανοίγει ξανά την παρουσίαση. Οι τέσσερις έλεγχοι στην κονσόλα πρέπει να εκτυπώσουν `true`, επιβεβαιώνοντας ότι η αγκίστρωση σχήματος, η περιοχή κειμένου και η κατάσταση διατηρήθηκαν.

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
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

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

### **Επιθεώρηση Υπάρχων Σύγχρονων Σχολίων**

Το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση που περιέχει σύγχρονα σχόλια και εκτυπώνει το κείμενό τους, την κατάσταση και τις λεπτομέρειες της αγκίστρωσης. Για να το επιθεωρήσετε, ελέγξτε ποια σχόλια είναι περιπτώσεις του [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/), στη συνέχεια εξετάστε τις [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), και [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/). Ένα σχήμα `null` υποδηλώνει σχόλιο επιπέδου διαφάνειας. Για μια αγκίστρωση [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), οι μέθοδοι επιλογής κειμένου εντοπίζουν την αντίστοιχη περιοχή στο πλαίσιο κειμένου του σχήματος.

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

## **Αφαίρεση Σχολίων**

Το Aspose.Slides for Node.js via Java σας επιτρέπει να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς τους από μια παρουσίαση ή να διαγράψετε επιλεγμένα σχόλια διατηρώντας τα υπόλοιπα. Τα παρακάτω παραδείγματα δείχνουν και τις δύο προσεγγίσεις και αποθηκεύουν την ενημερωμένη παρουσίαση.

### **Αφαίρεση Όλων των Σχολίων και των Συγγραφέων Σχολίων**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και καλεί την [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) για κάθε συγγραφέα, στη συνέχεια καλεί την [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) για τη διαγραφή των ίδιων των συγγραφέων. Η αποθηκευμένη παρουσίαση δεν περιέχει ούτε σχόλια ούτε συγγραφείς σχολίων. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχόλια για να παρατηρήσετε την αφαίρεση.

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

### **Αφαίρεση Συγκεκριμένων Σχολίων**

Το παράδειγμα δημιουργεί δύο σχόλια σε μία διαφάνεια και χρησιμοποιεί την [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) για να βρει σχόλια ανά συγγραφέα. Συλλέγει σχόλια του οποίου το κείμενο ισούται με "comment 1" πριν καλέσει την [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/), αποφεύγοντας αλλαγές στη συλλογή κατά την επιλογή. Η αποθηκευμένη παρουσίαση διατηρεί μόνο το "comment 2".

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

**Υποστηρίζει το Aspose.Slides κατάσταση επιλύτη για σύγχρονα σχόλια;**

Ναι. Οι [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) και [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) προσπελαύνουν μια τιμή του [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/), συμπεριλαμβανομένου του `Resolved`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να διαβαστεί ξανά μετά το άνοιγμα του αρχείου.

**Υποστηρίζονται συζητήσεις σε νήμα (αλυσιδωτές απαντήσεις) και υπάρχει όριο εσωτερικότητας;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρει το [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/), επιτρέποντας αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους εσωτερικότητας.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση του δείκτη ορίζεται από συντεταγμένες κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντάς σας να τοποθετήσετε ακριβώς το σημείο στη διαφάνεια.