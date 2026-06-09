---
title: Διαχείριση Σχολίων Παρουσίασης σε Java
linktitle: Σχόλια Παρουσίασης
type: docs
weight: 100
url: /el/java/presentation-comments/
keywords:
- σχόλιο
- σύγχρονο σχόλιο
- σχόλια PowerPoint
- σχόλια παρουσίασης
- σχόλια διαφάνειας
- προσθήκη σχολίου
- πρόσβαση σε σχόλιο
- επεξεργασία σχολίου
- απάντηση σχολίου
- αφαίρεση σχολίου
- διαγραφή σχολίου
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε σχολιάσεις παρουσίασης με το Aspose.Slides for Java: προσθέστε, διαβάστε, επεξεργαστείτε και διαγράψτε σχόλια σε αρχεία PowerPoint γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε σχόλια παρουσίασης στο Aspose.Slides. Εμφανίζει τους κύριους τύπους που σχετίζονται με σχόλια και δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες, να έχετε πρόσβαση σε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις, να χρησιμοποιείτε σύγχρονα σχόλια και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα εστιάζουν σε συνήθεις σεναριακές περιπτώσεις ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση του περιεχομένου και των μεταδεδομένων των σχολίων, η δημιουργία αλυσίδων απαντήσεων και η εκκαθάριση όλων των σχολίων ή η διαγραφή επιλεγμένων.

Στο PowerPoint, ένα σχόλιο εμφανίζεται ως σημείωση ή επισήμανση σε μια διαφάνεια. Όταν κάνετε κλικ σε ένα σχόλιο, αποκαλύπτεται το περιεχόμενό του ή τα μηνύματά του.

## **Γιατί να Προσθέτετε Σχόλια σε Παρουσιάσεις;**

Μπορεί να θέλετε να χρησιμοποιήσετε σχόλια για να παρέχετε σχόλια ή να επικοινωνήσετε με τους συναδέλφους σας όταν ελέγχετε παρουσιάσεις.

Για να μπορείτε να χρησιμοποιείτε σχόλια σε παρουσιάσεις PowerPoint, το Aspose.Slides for Java παρέχει:

* Η [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) κλάση, η οποία περιέχει τις συλλογές συγγραφέων (από το [ICommentAuthorCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICommentAuthorCollection) interface). Οι συγγραφείς προσθέτουν σχόλια σε διαφάνειες. 
* Το [ICommentCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICommentCollection) interface, το οποίο περιέχει τη συλλογή σχολίων για μεμονωμένους συγγραφείς. 
* Το [IComment](https://reference.aspose.com/slides/el/java/com.aspose.slides/IComment) κλάση, το οποίο περιέχει πληροφορίες για τους συγγραφείς και τα σχόλιά τους: ποιος πρόσθεσε το σχόλιο, η ώρα προσθήκης, η θέση του σχολίου κ.λπ. 
* Το [CommentAuthor](https://reference.aspose.com/slides/el/java/com.aspose.slides/CommentAuthor) κλάση, το οποίο περιέχει πληροφορίες για μεμονωμένους συγγραφείς: το όνομα του συγγραφέα, τα αρχικά του, τα σχόλια που σχετίζονται με το όνομα του κ.ά. 

## **Προσθήκη Σχολίων σε Διαφάνεια**
Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε ένα σχόλιο σε μια διαφάνεια σε παρουσίαση PowerPoint:

```java
// Δημιουργεί την κλάση Presentation
Presentation pres = new Presentation();
try {
    // Προσθέτει μια κενή διαφάνεια
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Προσθέτει έναν συγγραφέα
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Ορίζει τη θέση για τα σχόλια
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Προσθέτει σχόλιο διαφάνειας για έναν συγγραφέα στη διαφάνεια 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Προσθέτει σχόλιο διαφάνειας για έναν συγγραφέα στη διαφάνεια 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Αποκτά πρόσβαση στη διαφάνεια ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Όταν περαστεί null ως όρισμα, τα σχόλια από όλους τους συγγραφείς φέρνονται στη επιλεγμένη διαφάνεια
    IComment[] Comments = slide.getSlideComments(author);

    // Αποκτά πρόσβαση στο σχόλιο με δείκτη 0 για τη διαφάνεια 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Επιλέγει τη συλλογή σχολίων του Συγγραφέα με δείκτη 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Πρόσβαση σε Σχόλια Διαφάνειας**
Αυτός ο κώδικας Java δείχνει πώς να έχετε πρόσβαση σε ένα υπάρχον σχόλιο σε μια διαφάνεια σε παρουσίαση PowerPoint:

```java
// Δημιουργεί την κλάση Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Απαντήσεις σε Σχόλια**
Ένα γονικό σχόλιο είναι το αρχικό ή ανώτερο σχόλιο σε μια ιεραρχία σχολίων ή απαντήσεων. Χρησιμοποιώντας τις μεθόδους [getParentComment](https://reference.aspose.com/slides/el/java/com.aspose.slides/IComment#getParentComment--) ή [setParentComment](https://reference.aspose.com/slides/el/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (από το [IComment](https://reference.aspose.com/slides/el/java/com.aspose.slides/IComment) interface), μπορείτε να ορίσετε ή να λάβετε ένα γονικό σχόλιο.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε σχόλια και να λάβετε απαντήσεις σε αυτά:

```java
Presentation pres = new Presentation();
try {
    // Προσθέτει ένα σχόλιο
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Προσθέτει μια απάντηση στο comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Προσθέτει άλλη μια απάντηση στο comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Προσθέτει μια απάντηση σε υπάρχουσα απάντηση
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Εμφανίζει την ιεραρχία των σχολίων στην κονσόλα
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // Αφαιρεί το comment1 και όλες τις απαντήσεις του
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 

* Όταν η μέθοδος [Remove](https://reference.aspose.com/slides/el/java/com.aspose.slides/IComment#remove--) (από το [IComment](https://reference.aspose.com/slides/el/java/com.aspose.slides/IComment) interface) χρησιμοποιείται για να διαγράψει ένα σχόλιο, οι απαντήσεις στο σχόλιο επίσης διαγράφονται. 
* Εάν η ρύθμιση [setParentComment](https://reference.aspose.com/slides/el/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) δημιουργεί κυκλική αναφορά, θα ριχτεί η εξαίρεση [PptxEditException](https://reference.aspose.com/slides/el/java/com.aspose.slides/PptxEditException). 

{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Το 2021, η Microsoft εισήγαγε *σύγχρονα σχόλια* στο PowerPoint. Η δυνατότητα σύγχρονων σχολίων βελτιώνει σημαντικά τη συνεργασία στο PowerPoint. Μέσω των σύγχρονων σχολίων, οι χρήστες του PowerPoint μπορούν να επιλύουν σχόλια, να συνδέουν σχόλια σε αντικείμενα και κείμενα και να αλληλεπιδρούν πολύ πιο εύκολα από πριν.

Στο [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/el/java/aspose-slides-for-java-21-11-release-notes/), υλοποιήσαμε υποστήριξη για σύγχρονα σχόλια προσθέτοντας την κλάση [ModernComment](https://reference.aspose.com/slides/el/java/com.aspose.slides/ModernComment). Προστέθηκαν οι μέθοδοι [addModernComment](https://reference.aspose.com/slides/el/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) και [insertModernComment](https://reference.aspose.com/slides/el/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) στην κλάση [CommentCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/CommentCollection).

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε ένα σύγχρονο σχόλιο σε μια διαφάνεια σε παρουσίαση PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αφαίρεση Σχολίων**

### **Διαγραφή Όλων των Σχολίων και Συγγραφέων**

Αυτός ο κώδικας Java δείχνει πώς να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς σε μια παρουσίαση:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Διαγράφει όλα τα σχόλια από την παρουσίαση
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Διαγράφει όλους τους συγγραφείς
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Διαγραφή Συγκεκριμένων Σχολίων**

Αυτός ο κώδικας Java δείχνει πώς να διαγράψετε συγκεκριμένα σχόλια σε μια διαφάνεια:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // προσθέτει σχόλια...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // αφαιρεί όλα τα σχόλια που περιέχουν το κείμενο "comment 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides μια κατάσταση όπως «επιλυμένο» για σύγχρονα σχόλια;**

Ναι. Τα [Modern comments](https://reference.aspose.com/slides/el/java/com.aspose.slides/moderncomment/) εκθέτουν τη μέθοδο [setStatus](https://reference.aspose.com/slides/el/java/com.aspose.slides/moderncomment/#setStatus-byte-); μπορείτε να ορίσετε την κατάσταση ενός σχολίου (για παράδειγμα, να το σημειώσετε ως επιλυμένο) και αυτή η κατάσταση αποθηκεύεται στο αρχείο και αναγνωρίζεται από το PowerPoint.

**Υποστηρίζονται οι αλληλουχίες απαντήσεων (threaded discussions) και υπάρχει όριο εσωτερικής στοίχισης;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρεται στο [parent comment](https://reference.aspose.com/slides/el/java/com.aspose.slides/comment/#getParentComment--), επιτρέποντας αυθαίρετες αλυσίδες απαντήσεων. Το API δεν δηλώνει συγκεκριμένο όριο βάθους στοίχισης.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση αποθηκεύεται ως σημείο κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας. Αυτό σας επιτρέπει να τοποθετήσετε τον δείκτη σχολίου με ακρίβεια στο σημείο που χρειάζεστε.