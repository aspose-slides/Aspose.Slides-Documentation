---
title: Διαχείριση Σχολίων Παρουσίασης σε JavaScript
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
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Κατακτήστε τη διαχείριση σχολίων παρουσίασης με το Aspose.Slides για Node.js: προσθέστε, διαβάστε, επεξεργαστείτε και διαγράψτε σχόλια σε αρχεία PowerPoint χρησιμοποιώντας JavaScript γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε τα σχόλια παρουσίασης στο Aspose.Slides. Δείχνει τους κύριους τύπους σχετιζόμενους με τα σχόλια και παρουσιάζει πώς να προσθέτετε σχόλια σε διαφάνειες, να προσπελάζετε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις, να χρησιμοποιείτε σύγχρονα σχόλια και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα εστιάζουν σε συνήθεις σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση του περιεχομένου και των μεταδεδομένων των σχολίων, η δημιουργία αλυσίδων απαντήσεων, και η εκκαθάριση όλων των σχολίων ή η διαγραφή επιλεγμένων.

Στο PowerPoint, ένα σχόλιο εμφανίζεται ως σημείωση ή επικόπηση σε μια διαφάνεια. Όταν κάνετε κλικ σε ένα σχόλιο, το περιεχόμενό του ή τα μηνύματά του αποκαλύπτονται.

## **Γιατί να Προσθέτετε Σχόλια σε Παρουσιάσεις;**

Μπορεί να θέλετε να χρησιμοποιήσετε σχόλια για να παρέχετε ανατροφοδότηση ή να επικοινωνήσετε με τους συναδέλφους σας όταν ελέγχετε παρουσιάσεις.

Για να μπορείτε να χρησιμοποιήσετε σχόλια σε παρουσιάσεις PowerPoint, το Aspose.Slides για Node.js μέσω Java παρέχει

* Την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation), η οποία περιέχει τις συλλογές συγγραφέων (από την κλάση [CommentAuthorCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/CommentAuthorCollection)). Οι συγγραφείς προσθέτουν σχόλια σε διαφάνειες.
* Την κλάση [CommentCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/CommentCollection), η οποία περιέχει τη συλλογή σχολίων για μεμονωμένους συγγραφείς.
* Την κλάση [Comment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Comment), η οποία περιέχει πληροφορίες για τους συγγραφείς και τα σχόλιά τους: ποιος πρόσθεσε το σχόλιο, η ώρα προσθήκης, η θέση του σχολίου κ.λπ.
* Την κλάση [CommentAuthor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/CommentAuthor), η οποία περιέχει πληροφορίες για μεμονωμένους συγγραφείς: το όνομα του συγγραφέα, τα αρχικά του, τα σχόλια που σχετίζονται με το όνομα του συγγραφέα κ.λπ.

## **Προσθήκη Σχολίου σε Διαφάνεια**
Αυτός ο κώδικας JavaScript σας δείχνει πώς να προσθέσετε ένα σχόλιο σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```javascript
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει μια κενή διαφάνεια
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Προσθέτει έναν συγγραφέα
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Ορίζει τη θέση για τα σχόλια
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Προσθέτει σχόλιο διαφάνειας για έναν συγγραφέα στη διαφάνεια 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Προσθέτει σχόλιο διαφάνειας για έναν συγγραφέα στη διαφάνεια 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Προσπελαύνει την ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // Όταν μεταβιβάζεται null ως όρισμα, τα σχόλια όλων των συγγραφέων φέρνονται στην επιλεγμένη διαφάνεια
    var Comments = slide.getSlideComments(author);
    // Προσπελαύνει το σχόλιο στο δείκτη 0 για τη διαφάνεια 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Επιλέγει τη συλλογή σχολίων του συγγραφέα στο δείκτη 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Πρόσβαση σε Σχόλια Διαφάνειας**
Αυτός ο κώδικας JavaScript σας δείχνει πώς να προσπελάσετε ένα υπάρχον σχόλιο σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Απάντηση σε Σχόλια**
Ένα γονικό σχόλιο είναι το κορυφαίο ή αρχικό σχόλιο σε μια ιεραρχία σχολίων ή απαντήσεων. Χρησιμοποιώντας τις μεθόδους [getParentComment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Comment#getParentComment--) ή [setParentComment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (από την κλάση [Comment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Comment)), μπορείτε να ορίσετε ή να λάβετε ένα γονικό σχόλιο.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να προσθέσετε σχόλια και να λάβετε απαντήσεις σε αυτά:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει ένα σχόλιο
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Προσθέτει μια απάντηση στο comment1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Προσθέτει άλλη απάντηση στο comment1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Προσθέτει απάντηση σε υπάρχουσα απάντηση
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Εμφανίζει την ιεραρχία των σχολίων στην κονσόλα
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // Αφαιρεί το comment1 και όλες τις απαντήσεις του
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Προσοχή" %}} 
* Όταν χρησιμοποιείται η μέθοδος [Remove](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Comment#remove--) (από την κλάση [Comment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Comment)), για διαγραφή ενός σχολίου, οι απαντήσεις στο σχόλιο επίσης διαγράφονται.
* Εάν η ρύθμιση [setParentComment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) προκαλεί κυκλική αναφορά, θα εξαχθεί το [PptxEditException](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PptxEditException).
{{% /alert %}}

## **Προσθήκη Σύγχρονου Σχολίου**

Το 2021, η Microsoft εισήγαγε τα σύγχρονα σχόλια στο PowerPoint. Η λειτουργία των σύγχρονων σχολίων βελτιώνει σημαντικά τη συνεργασία στο PowerPoint. Μέσω των σύγχρονων σχολίων, οι χρήστες του PowerPoint μπορούν να επιλύουν σχόλια, να συνδέουν σχόλια με αντικείμενα και κείμενα, και να αλληλεπιδρούν πολύ πιο εύκολα από πριν. 

Το Aspose.Slides υποστηρίζει σύγχρονα σχόλια μέσω της κλάσης [ModernComment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ModernComment). Οι μέθοδοι [addModernComment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) και [insertModernComment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) προστέθηκαν στην κλάση [CommentCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/CommentCollection).

Αυτός ο κώδικας JavaScript σας δείχνει πώς να προσθέσετε ένα σύγχρονο σχόλιο σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αφαίρεση Σχολίου**

### **Διαγραφή Όλων των Σχολίων και Συγγραφέων**

Αυτός ο κώδικας JavaScript σας δείχνει πώς να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς σε μια παρουσίαση:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Διαγράφει όλα τα σχόλια από την παρουσίαση
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Διαγράφει όλους τους συγγραφείς
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Διαγραφή Συγκεκριμένων Σχολίων**

Αυτός ο κώδικας JavaScript σας δείχνει πώς να διαγράψετε συγκεκριμένα σχόλια σε μια διαφάνεια:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // προσθήκη σχολίων...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // αφαίρεση όλων των σχολίων που περιέχουν το κείμενο "comment 1" text
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Υποστηρίζει το Aspose.Slides μια κατάσταση όπως 'επιλυμένο' για τα σύγχρονα σχόλια;**

Ναι. Τα σύγχρονα σχόλια εκθέτουν τις μεθόδους [getStatus](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/getstatus/) και [setStatus](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/moderncomment/setStatus/); μπορείτε να διαβάσετε και να ορίσετε την κατάσταση ενός σχολίου (π.χ., να το σημειώσετε ως επιλυμένο), και αυτή η κατάσταση αποθηκεύεται στο αρχείο και αναγνωρίζεται από το PowerPoint.

**Υπάρχουν υποστηριζόμενες συζητήσεις με νήματα (αλυσίδες απαντήσεων) και υπάρχει όριο σε βάθος εμφώλευσης;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρει το γονικό του σχόλιο, επιτρέποντας αλυσίδες απαντήσεων αυθαίρετου μήκους. Το API δεν δηλώνει συγκεκριμένο όριο βάθους εμφώλευσης.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση αποθηκεύεται ως σημείο κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας. Αυτό σας επιτρέπει να τοποθετήσετε τον δείκτη σχολίου ακριβώς όπου το χρειάζεστε.