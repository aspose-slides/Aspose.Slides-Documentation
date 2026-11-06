---
title: Διαχείριση Σχολίων Παρουσίασης στο Android
linktitle: Σχόλια Παρουσίασης
type: docs
weight: 100
url: /el/androidjava/presentation-comments/
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
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides για Android μέσω Java: προσθέστε, διαβάστε, επεξεργαστείτε, απαντήστε και αφαιρέστε σχόλια σε παρουσιάσεις PowerPoint γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε σχόλια παρουσιάσεων με το Aspose.Slides για Android μέσω Java. Παρουσιάζει τους κύριους τύπους που σχετίζονται με τα σχόλια και δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες, να έχετε πρόσβαση σε υπάρχοντα σχόλια, να εργάζεστε με τις απαντήσεις και τα σύγχρονα σχόλια, και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν κοινά σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση κειμένου σχολίου και μεταδεδομένων, η δημιουργία αλυσίδων απαντήσεων, και η αφαίρεση επιλεγμένων σχολίων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις στις διαφάνειες. Η επιλογή ενός σχολίου εμφανίζει το κείμενό του και τη σχετική συζήτηση.

Για να ζητήσετε τα σχόλια να εμφανίζονται ή να κρύβονται όταν ανοίγει μια παρουσίαση χωρίς να αλλάξουν τα ίδια τα σχόλια, δείτε [Εμφάνιση ή Απόκρυψη Σχόλων Κατά το Άνοιγμα Παρουσίασης](/slides/el/androidjava/presentation-view-properties/).

## **Γιατί να Προσθέσετε Σχόλια σε Παρουσιάσεις;**

Μπορείτε να χρησιμοποιήσετε σχόλια για να παρέχετε ανατροφοδότηση και να συνεργάζεστε με συναδέλφους κατά την αξιολόγηση παρουσιάσεων.

Το Aspose.Slides για Android μέσω Java παρέχει τα ακόλουθα API για εργασία με σχόλια:

* Τη **[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)** κλάση, η οποία παρέχει πρόσβαση στους συγγραφείς σχολίων της παρουσίασης.
* Το **[ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/)** interface, το οποίο αντιπροσωπεύει τα σχόλια που σχετίζονται με έναν συγκεκριμένο συγγραφέα.
* Το **[IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/)** interface, το οποίο παρέχει πληροφορίες για ένα σχόλιο, συμπεριλαμβανομένου του συγγραφέα, της ώρας δημιουργίας, της θέσης και του κειμένου.
* Το **[CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentauthor/)** κλάση, η οποία παρέχει πληροφορίες για έναν συγγραφέα, όπως το όνομα, τα αρχικά και τα σχετικά σχόλια.

## **Προσθήκη Σχολίων σε Διαφάνειες**

Το παράδειγμα δημιουργεί δύο διαφάνειες και καταχωρεί έναν συγγραφέα σχολίων με τη μέθοδο [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-). Χρησιμοποιεί τη μέθοδο [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) για να τοποθετήσει ένα σχόλιο σε κάθε διαφάνεια, στη συνέχεια ανακτά τα σχόλια της πρώτης διαφάνειας για εκείνο το συγγραφέα με τη μέθοδο [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-). Η κονσόλα εμφανίζει το κείμενο του πρώτου σχολίου δύο φορές, δείχνοντας πρόσβαση μέσω της διαφάνειας και του συγγραφέα, και η αποθηκευμένη παρουσίαση περιέχει και τα δύο σχόλια.

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    PointF position = new PointF(0.2f, 0.2f);
    Date createdTime = new Date();

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    IComment[] comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        IComment firstComment = comments[0];
        System.out.println(firstComment.getText());

        String commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εύρεση ή Δημιουργία Συγγραφέα Σχολίου**

Όταν μια αυτοματοποιημένη αξιολόγηση επεξεργάζεται την ίδια παρουσίαση επανειλημμένα, ψάξτε στη συλλογή που επιστρέφεται από τη μέθοδο [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) πριν προσθέσετε έναν συγγραφέα. Η μέθοδος [findByNameAndInitials](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) ταιριάζει τόσο στο όνομα όσο και στα αρχικά και επιστρέφει έναν πίνακα με τους αντίστοιχους συγγραφείς, ή έναν κενό πίνακα αν δεν υπάρχουν αντιστοιχίες. Αντίθετα, η μέθοδος [findByName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) αναζητά μόνο με βάση το όνομα, ανεξάρτητα από τα αρχικά. Η κλήση της [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) με όνομα και αρχικά που ήδη υπάρχουν στη συλλογή προκαλεί εξαίρεση.

Το παράδειγμα απαιτεί ένα αρχείο παρουσίασης με τουλάχιστον μία διαφάνι. Σε κάθε μία από τις δύο επαναλήψεις, χρησιμοποιεί ξανά τον πρώτο ταιριαστό συγγραφέα, ή δημιουργεί έναν νέο μόνο όταν το αποτέλεσμα είναι κενό. Αν υπάρχουν πολλαπλές αντιστοιχίες, επιλέγει το πρώτο στοιχείο του πίνακα χωρίς συγχώνευση ή αφαίρεση των άλλων συγγραφέων. Στη συνέχεια καλεί τη [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) για τον επιλεγμένο συγγραφέα και αποθηκεύει την παρουσίαση. Η δεύτερη επανάληψη ανοίγει το αποτέλεσμα της πρώτης επανάληψης και επαναλαμβάνει τη λειτουργία.

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

final String authorName = "Reviewer";
final String authorInitials = "RV";

String inputFile = "input.pptx";
PointF position = new PointF(20, 20);

for (int pass = 1; pass <= 2; pass++) {
    Presentation presentation = new Presentation(inputFile);
    try {
        ICommentAuthor[] matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        ICommentAuthor author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, new Date());

        String outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

Η δεύτερη επανάληψη προσθέτει ακόμη ένα σχόλιο χωρίς να προσθέτει νέο συγγραφέα ή να αφαιρεί υπάρχοντα σχόλια. Το τελικό αρχείο, `review_pass_2.pptx`, περιέχει και τα νέα σχόλια και τυχόν αρχικά σχόλια. Η επαναχρησιμοποίηση ενός συγγραφέα δεν αφαιρεί διπλότυπα σχόλια: για να αποφύγετε την επανειλημμένη προσθήκη του ίδιου σχολίου, υλοποιήστε ξεχωριστό μηχανισμό ανίχνευσης διπλοτύπων πριν το προσθέσετε.

## **Πρόσβαση σε Σχόλια Διαφάνειας**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και διαβάζει τη συλλογή που επιστρέφεται από τη μέθοδο [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--). Για κάθε συγγραφέα, κάνει επανάληψη στη συλλογή που επιστρέφεται από τη μέθοδο [getComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthor/#getComments--) και εκτυπώνει τον αριθμό διαφάνειας, το κείμενο του σχολίου, το όνομα του συγγραφέα και την ώρα δημιουργίας. Η είσοδος παρουσίασης πρέπει να περιέχει σχόλια για να παραχθεί έξοδος στην κονσόλα.

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        for (IComment comment : author.getComments()) {
            System.out.println("Slide: " + comment.getSlide().getSlideNumber());
            System.out.println("Comment: " + comment.getText());
            System.out.println("Author: " + comment.getAuthor().getName());
            System.out.println("Posted at: " + comment.getCreatedTime());
            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Απάντηση σε Σχόλια**

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Οι μέθοδοι [IComment.getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) και [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) επιτρέπουν την ανάκτηση ή την ορισμό του γονέα ενός σχολίου.

Το παράδειγμα δημιουργεί σχόλια από δύο συγγραφείς και χρησιμοποιεί τη μέθοδο [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) για να δημιουργήσει απαντήσεις, συμπεριλαμβανομένης μιας απάντησης σε άλλη απάντηση. Η κλήση του `null` στη μέθοδο [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) ανακτά σχόλια από όλους τους συγγραφείς· η κονσόλα εσοχής κάθε εγγραφής σύμφωνα με το βάθος της ιεραρχίας απαντήσεων. Το παράδειγμα αποθηκεύει τη συνολική συζήτηση, καλεί τη μέθοδο [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) στο πρώτο ριζικό σχόλιο, και αποθηκεύει μια δεύτερη παρουσίαση με εκείνο το σχόλιο και τις απαντήσεις του αφαιρεμένες.

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    PointF position = new PointF(10, 10);
    Date createdTime = new Date();

    ICommentAuthor originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    IComment secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    IComment subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    IComment separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    IComment separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++) {
        IComment comment = comments[i];
        while (comment.getParentComment() != null) {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() + ": " + comments[i].getText());
    }

    presentation.save("parent_comment.pptx", SaveFormat.Pptx);

    rootComment.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Όταν χρησιμοποιείται η μέθοδος [IComment.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) για τη διαγραφή ενός σχολίου, διαγράφονται επίσης όλες οι απαντήσεις σε αυτό το σχόλιο.
* Εάν η [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) δημιουργήσει κυκλική αναφορά, εγείρεται μια [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Τα σύγχρονα σχόλια μπορούν να συσχετιστούν με τη διαφάνεια, με ένα συγκεκριμένο σχήμα ή με ένα εύρος κειμένου μέσα σε AutoShape. Η μέθοδος [ICommentCollection.addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) δέχεται ένα όρισμα **[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)** εκτός από τη διαφάνεια και τις συντεταγμένες του σημειωτή σχολίου.

Όταν το `null` περνιέται ως όρισμα σχήματος, το σχόλιο είναι σχόλιο σε επίπεδο διαφάνειας. Ο σημειωτής του τοποθετείται με τις δοσμένες συντεταγμένες, αλλά δεν συνδέεται με κάποιο συγκεκριμένο σχήμα, οπότε η μέθοδος [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) επιστρέφει `null`. Όταν παρέχεται ένα **[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)**, το σχόλιο αγκυροβολείται σε αυτό το σχήμα. Οι συντεταγμένες εξακολουθούν να ορίζουν τη θέση του σημειωτή του σχολίου στη διαφάνεια, ενώ η συσχέτιση σχήματος μπορεί να ανακτηθεί μέσω της [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) μεθόδου.

### **Αγκυροβολία Σύγχρονου Σχολίου σε Σχήμα**

Το παράδειγμα καλεί τη μέθοδο [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) δύο φορές: μία φορά με `null` σχήμα για σχόλιο σε επίπεδο διαφάνειας και μία φορά με ένα ορθογώνιο ως άγκυρα. Η ανάγνωση της μεθόδου [getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) εκτυπώνει `true` για το έλεγχο null του σχολίου διαφάνειας και `Revenue title` για το αγκυροβολημένο σχόλιο. Και τα δύο σχόλια αποθηκεύονται με την παρουσίαση.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    PointF slideCommentPosition = new PointF(20, 20);
    PointF shapeCommentPosition = new PointF(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Αγκυροβολία Σχολίων σε Διαφορετικούς Τύπους Σχημάτων**

Οποιοδήποτε αντικείμενο διαφάνειας που υλοποιεί το **[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)** μπορεί να χρησιμοποιηθεί ως άγκυρα σχήματος. Συνηθισμένα παραδείγματα περιλαμβάνουν **[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)**, **[IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/)**, **[IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/)**, **[IConnector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnector/)** και **[IGraphicalObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobject/)** όπως διαγράμματα.

Το παράδειγμα χρησιμοποιεί τη μέθοδο [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) για να συσχετίσει ένα σχόλιο με καθέναν από πέντε τύπους σχημάτων: AutoShape, πλαίσιο εικόνας, ομάδα, σύνδεσμο και διάγραμμα. Η εικόνα ενσωματώνεται ως δεδομένα, οπότε δεν απαιτείται εξωτερική εικόνα. Κάθε σχόλιο έχει τη δική του θέση σημειωτή, και η αποθηκευμένη παρουσίαση διατηρεί όλες τις πέντε συσχετίσεις σχημάτων.

```java
import com.aspose.slides.ChartType;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IChart;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IConnector;
import com.aspose.slides.IGroupShape;
import com.aspose.slides.IPPImage;
import com.aspose.slides.IPictureFrame;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import android.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");

    PointF autoShapeCommentPosition = new PointF(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.decode(imageBase64, Base64.DEFAULT);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    PointF pictureCommentPosition = new PointF(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    PointF groupCommentPosition = new PointF(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    PointF connectorCommentPosition = new PointF(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    PointF chartCommentPosition = new PointF(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Αγκυροβολία Σχόλιου σε Κείμενο και Ορισμός Κατάστασής του**

Για ένα σύγχρονο σχόλιο που συσχετίζεται με **[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)**, οι μέθοδοι [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) και [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) προσπελάζουν τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος. Οι μέθοδοι [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) και [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) προσπελάζουν το μήκος της επιλογής. Μαζί, αυτές οι τιμές συσχετίζουν το σχόλιο με ένα συγκεκριμένο εύρος κειμένου μέσα στο AutoShape.

Οι μέθοδοι [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) και [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) προσπελάζουν μια τιμή από τις σταθερές **[ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/)**:

- `NotDefined` — δεν ορίζεται συγκεκριμένη κατάσταση σύγχρονου σχολίου.
- `Active` — το σχόλιο είναι ενεργό.
- `Resolved` — το σχόλιο έχει επιλυθεί.
- `Closed` — το σχόλιο είναι κλειστό.

Το παράδειγμα αγκυροβολεί ένα σύγχρονο σχόλιο στις λέξεις «quarterly revenue» σε κείμενο ενός ορθογωνίου. Υπολογίζει τη μηδενική θέση έναρξης επιλογής από το κείμενο και τη μεταβιβάζει στη μέθοδο [setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-), χρησιμοποιεί τη [setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) για να ορίσει τον αριθμό των επιλεγμένων χαρακτήρων. Μετά την κλήση του [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) με `Resolved`, αποθηκεύει και ξαναανοίγει την παρουσίαση. Οι τέσσερις έλεγχοι στην κονσόλα θα πρέπει να εκτυπώσουν `true`, επιβεβαιώνοντας ότι η άγκυρα σχήματος, το εύρος κειμένου και η κατάσταση διατηρήθηκαν.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.ModernCommentStatus;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

String outputFile = "modern_comment_text_anchor.pptx";
String shapeText = "Review the quarterly revenue forecast.";
String selectedText = "quarterly revenue";
int expectedSelectionStart = shapeText.indexOf(selectedText);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    PointF commentPosition = new PointF(60, 60);
    IModernComment comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, new Date());
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length());
    comment.setStatus(ModernCommentStatus.Resolved);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IComment[] reopenedComments = reopenedSlide.getSlideComments(null);

    for (IComment reopenedComment : reopenedComments) {
        if (!(reopenedComment instanceof IModernComment)) {
            continue;
        }

        IModernComment modernComment = (IModernComment) reopenedComment;
        boolean shapeMatches = modernComment.getShape() != null && "Forecast text".equals(modernComment.getShape().getName());
        boolean selectionStartMatches = modernComment.getTextSelectionStart() == expectedSelectionStart;
        boolean selectionLengthMatches = modernComment.getTextSelectionLength() == selectedText.length();
        boolean statusMatches = modernComment.getStatus() == ModernCommentStatus.Resolved;

        System.out.println("Shape anchor preserved: " + shapeMatches);
        System.out.println("Text selection start preserved: " + selectionStartMatches);
        System.out.println("Text selection length preserved: " + selectionLengthMatches);
        System.out.println("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Επιθεώρηση Υφιστάμενων Σύγχρονων Σχολίων**

Το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση που περιέχει σύγχρονα σχόλια και εκτυπώνει το κείμενο, την κατάσταση και τις λεπτομέρειες άγκυρας. Για να το εξετάσετε, ελέγξτε ποια σχόλια υλοποιούν το **[IModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/)**, έπειτα εξετάστε τις μεθόδους **[IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--)**, **[IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--)**, **[IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--)** και **[IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--)**. Ένα `null` σχήμα υποδεικνύει σχόλιο σε επίπεδο διαφάνειας. Για άγκυρα **[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)**, οι μέθοδοι επιλογής κειμένου εντοπίζουν το αντίστοιχο εύρος στο πλαίσιο κειμένου του σχήματος.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.IModernComment;
import com.aspose.slides.IShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("comments.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        IComment[] comments = slide.getSlideComments(null);
        for (IComment comment : comments) {
            if (!(comment instanceof IModernComment)) {
                continue;
            }

            IModernComment modernComment = (IModernComment) comment;
            System.out.println("Slide: " + slide.getSlideNumber());
            System.out.println("Text: " + modernComment.getText());
            System.out.println("Status: " + modernComment.getStatus());

            IShape shape = modernComment.getShape();
            if (shape == null) {
                System.out.println("Anchor: slide level");
            } else {
                System.out.println("Anchor shape: " + shape.getName());
                System.out.println("Anchor type: " + shape.getClass().getSimpleName());

                if (shape instanceof IAutoShape) {
                    System.out.println("Text selection start: " + modernComment.getTextSelectionStart());
                    System.out.println("Text selection length: " + modernComment.getTextSelectionLength());
                }
            }

            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Αφαίρεση Σχολίων**

Το Aspose.Slides για Android μέσω Java σας επιτρέπει να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς τους από μια παρουσίαση ή να διαγράψετε επιλεγμένα σχόλια διατηρώντας τα υπόλοιπα. Τα παρακάτω παραδείγματα δείχνουν και τις δύο προσεγγίσεις και αποθηκεύουν την ενημερωμένη παρουσίαση.

### **Αφαίρεση Όλων των Σχολίων και των Συγγραφέων Σχολίων**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και καλεί τη μέθοδο [ICommentCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#clear--) για κάθε συγγραφέα, στη συνέχεια καλεί τη μέθοδο [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#clear--) για να αφαιρέσει τους ίδιους τους συγγραφείς. Η αποθηκευμένη παρουσίαση δεν περιέχει ούτε σχόλια ούτε συγγραφείς σχολίων. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχόλια για να παρατηρήσετε την αφαίρεση.

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("example.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        author.getComments().clear();
    }

    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Αφαίρεση Συγκεκριμένων Σχολίων**

Το παράδειγμα δημιουργεί δύο σχόλια σε μία διαφάνεια και χρησιμοποιεί τη μέθοδο [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) για να βρει σχόλια ανά συγγραφέα. Συλλέγει τα σχόλια των οποίων το κείμενο ισούται με «comment 1» πριν καλέσει τη μέθοδο [ICommentCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-), αποφεύγοντας αλλαγές στη συλλογή κατά την επιλογή. Η αποθηκευμένη παρουσίαση διατηρεί μόνο το «comment 2».

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    PointF firstCommentPosition = new PointF(0.2f, 0.2f);
    PointF secondCommentPosition = new PointF(0.3f, 0.2f);
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors()) {
        List<IComment> commentsToRemove = new ArrayList<IComment>();
        IComment[] comments = slide.getSlideComments(commentAuthor);

        for (IComment comment : comments) {
            if ("comment 1".equals(comment.getText())) {
                commentsToRemove.add(comment);
            }
        }

        for (IComment comment : commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides κατάσταση επιλυμένο για σύγχρονα σχόλια;**

Ναι. Οι μέθοδοι [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) και [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) προσπελάζουν μια τιμή του **[ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/)**, συμπεριλαμβανομένου του `Resolved`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να διαβαστεί ξανά μετά το άνοιγμα του αρχείου.

**Υποστηρίζονται συζητήσεις με κλάδους (αλυσίδες απαντήσεων) και υπάρχει όριο εμβάθους;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρεται στο [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--), επιτρέποντας αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του σημειωτή σχολίου σε μια διαφάνεια;**

Η θέση του σημειωτή ορίζεται από συντεταγμένες κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντας ακριβή τοποθέτηση.