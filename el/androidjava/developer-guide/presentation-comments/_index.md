---
title: Διαχείριση σχολίων παρουσίασης σε Android
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

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε σχόλια παρουσίασης με το Aspose.Slides for Android via Java. Παρουσιάζει τους κύριους τύπους που σχετίζονται με σχόλια και δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες, να έχετε πρόσβαση σε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις και σύγχρονα σχόλια και να καταργείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν κοινά σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση κειμένου σχολίου και μεταδεδομένων, η δημιουργία αλυσίδων απαντήσεων και η κατάργηση επιλεγμένων σχολίων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις στις διαφάνειες. Η επιλογή ενός σχολίου εμφανίζει το κείμενό του και τη σχετική συζήτηση.

## **Γιατί να Προσθέσετε Σχόλια σε Παρουσιάσεις;**

Μπορείτε να χρησιμοποιήσετε σχόλια για να παρέχετε ανατροφοδότηση και να συνεργάζεστε με συναδέλφους κατά την αξιολόγηση παρουσιάσεων.

Το Aspose.Slides for Android via Java παρέχει τα ακόλουθα API για εργασία με σχόλια:

* Η κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) παρέχει πρόσβαση στους συγγραφείς σχολίων της παρουσίασης.
* Η διεπαφή [ICommentCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icommentcollection/) αντιπροσωπεύει τα σχόλια που συνδέονται με έναν συγκεκριμένο συγγραφέα.
* Η διεπαφή [IComment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icomment/) παρέχει πληροφορίες σχετικά με ένα σχόλιο, συμπεριλαμβανομένου του συγγραφέα, του χρόνου δημιουργίας, της θέσης και του κειμένου.
* Η κλάση [CommentAuthor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/commentauthor/) παρέχει πληροφορίες για έναν συγγραφέα, όπως το όνομα, τα αρχικά και τα συνδεδεμένα σχόλια.

## **Προσθήκη Σχολίων σε Διαφάνειες**

Το παρακάτω παράδειγμα δείχνει πώς να προσθέσετε σχόλια σε διαφάνειες σε μια παρουσίαση PowerPoint:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
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

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Πρόσβαση σε Σχόλια Διαφάνειας**

Το παρακάτω παράδειγμα δείχνει πώς να έχετε πρόσβαση σε υπάρχοντα σχόλια σε μια παρουσίαση PowerPoint:

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

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Οι μέθοδοι [IComment.getParentComment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icomment/#getParentComment--) και [IComment.setParentComment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) σάς επιτρέπουν να λάβετε ή να ορίσετε το γονικό σχόλιο.

Το παρακάτω παράδειγμα δείχνει πώς να προσθέσετε απαντήσεις και να εξετάσετε την προκύπτουσα ιεραρχία σχολίων:

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

    ICommentAuthor author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    IComment comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

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

    comment1.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Όταν χρησιμοποιείται η μέθοδος [IComment.remove](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icomment/#remove--) για διαγραφή ενός σχολίου, διαγράψονται επίσης όλες οι απαντήσεις σε αυτό το σχόλιο.
* Εάν η μέθοδος [IComment.setParentComment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) δημιουργεί κυκλική αναφορά, πετιέται μια [PptxEditException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Τα σύγχρονα σχόλια μπορούν να συνδεθούν με την ίδια τη διαφάνεια, με ένα συγκεκριμένο σχήμα ή με μια περιοχή κειμένου μέσα σε AutoShape. Η μέθοδος [ICommentCollection.addModernComment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) δέχεται ένα όρισμα [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) επιπλέον της διαφάνειας και των συντεταγμένων του δείκτη σχολίου.

Όταν περνιέται `null` για το όρισμα του σχήματος, το σχόλιο είναι σχόλιο επιπέδου διαφάνειας. Ο δείκτης του τοποθετείται με τις παρεχόμενες συντεταγμένες, αλλά δεν συνδέεται με συγκεκριμένο σχήμα, έτσι η μέθοδος [IModernComment.getShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#getShape--) επιστρέφει `null`. Όταν παρέχεται ένα [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/), το σχόλιο αγκυροβολείται σε αυτό το σχήμα. Οι συντεταγμένες εξακολουθούν να ορίζουν τη θέση του δείκτη σχολίου στη διαφάνεια, ενώ η σύνδεση του σχήματος μπορεί να ανακτηθεί μέσω της [IModernComment.getShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#getShape--).

### **Σύνδεση Σχόλιου με Σχήμα**

Το παρακάτω παράδειγμα δημιουργεί τόσο ένα σύγχρονο σχόλιο επιπέδου διαφάνειας όσο και ένα σύγχρονο σχόλιο αγκυροβολημένο σε συγκεκριμένο AutoShape. Στη συνέχεια διαβάζει το σχετικό σχήμα από κάθε σχόλιο.

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

### **Σύνδεση Σχολίων σε Διάφορους Τύπους Σχημάτων**

Οποιοδήποτε αντικείμενο διαφάνειας που υλοποιεί το [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) μπορεί να χρησιμοποιηθεί ως άγκυρα σχήματος. Συνηθισμένα παραδείγματα περιλαμβάνουν [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iconnector/) και [IGraphicalObject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/igraphicalobject/) όπως διαγράμματα.

Το παρακάτω παράδειγμα δημιουργεί αρκετούς κοινά τύπους σχημάτων και συνδέει ένα σύγχρονο σχόλιο με το καθένα.

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
import java.util.Base64;
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
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
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

### **Σύνδεση Σχολίου σε Κείμενο και Ορισμός Κατάστασης**

Για ένα σύγχρονο σχόλιο που συνδέεται με ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/), οι μέθοδοι [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) και [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) προσπελάζουν τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος. Οι μέθοδοι [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) και [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) προσπελάζουν το μήκος της επιλογής. Συνολικά, αυτές οι τιμές συνδέουν το σχόλιο με μια συγκεκριμένη περιοχή κειμένου μέσα στο AutoShape.

Οι μέθοδοι [IModernComment.getStatus](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#getStatus--) και [IModernComment.setStatus](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) προσπελάζουν μια τιμή από τις σταθερές [ModernCommentStatus](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — δεν έχει οριστεί συγκεκριμένη κατάσταση σύγχρονου σχολίου.
- `Active` — το σχόλιο είναι ενεργό.
- `Resolved` — το σχόλιο έχει επιλυθεί.
- `Closed` — το σχόλιο είναι κλειστό.

Το παρακάτω παράδειγμα δημιουργεί ένα σχόλιο αγκυροβολημένο σε σχήμα, το συνδέει με μια επιλογή κειμένου, το δηλώνει ως επιλυμένο, αποθηκεύει την παρουσίαση και επαληθεύει τις τιμές μετά το άνοιγμα του αρχείου.

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

Για να επιθεωρήσετε μια υπάρχουσα παρουσίαση, ελέγξτε ποια σχόλια υλοποιούν το [IModernComment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/), στη συνέχεια εξετάστε τις μεθόδους [IModernComment.getShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--), και [IModernComment.getStatus](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#getStatus--). Ένα σχήμα `null` υποδηλώνει σχόλιο επιπέδου διαφάνειας. Για άγκυρα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/), οι μέθοδοι επιλογής κειμένου προσδιορίζουν το σχετικό εύρος στο πλαίσιο κειμένου του σχήματος.

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

## **Κατάργηση Σχολίων**

### **Κατάργηση Όλων των Σχολίων και Συντελεστών Σχολίων**

Το παρακάτω παράδειγμα δείχνει πώς να καταργήσετε όλα τα σχόλια και τους συγγραφείς σχολίων από μια παρουσίαση:

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

### **Κατάργηση Συγκεκριμένων Σχολίων**

Το παρακάτω παράδειγμα δείχνει πώς να καταργήσετε συγκεκριμένα σχόλια από μια διαφάνεια:

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

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Υποστηρίζει το Aspose.Slides κατάσταση επιλυμένου για σύγχρονα σχόλια;**

Ναι. Οι μέθοδοι [IModernComment.getStatus](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#getStatus--) και [IModernComment.setStatus](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) προσπελάζουν μια τιμή του [ModernCommentStatus](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/moderncommentstatus/), συμπεριλαμβανομένου του `Resolved`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να αναγνωστεί ξανά μετά το άνοιγμα του αρχείου.

**Υποστηρίζονται οι αλυσίδες απαντήσεων (threaded discussions) και υπάρχει όριο σε βάθος εμφώλευσης;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρεται στο [parent comment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icomment/#getParentComment--), επιτρέποντας αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους εμφώλευσης.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση του δείκτη ορίζεται από συντεταγμένες τύπου floating‑point στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντάς σας να τοποθετήσετε ακριβώς το δείκτη στη διαφάνεια.