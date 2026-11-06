---
title: Διαχείριση Σχολίων Παρουσίασης σε Python μέσω Java
linktitle: Σχόλια Παρουσίασης
type: docs
weight: 100
url: /el/python-java/presentation-comments/
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
- Python
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides for Python via Java: προσθέστε, διαβάστε, επεξεργαστείτε, απαντήστε σε, και αφαιρέστε σχόλια σε παρουσιάσεις PowerPoint γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides for Python via Java. Παρουσιάζει τους κύριους τύπους σχετικούς με τα σχόλια και δείχνει πώς να προσθέτετε σχόλια στις διαφάνειες, να έχετε πρόσβαση σε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις και σύγχρονα σχόλια, και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν κοινά σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση του κειμένου και των μεταδεδομένων του σχολίου, η δημιουργία αλυσίδων απαντήσεων, και η αφαίρεση επιλεγμένων σχολίων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις στις διαφάνειες. Η επιλογή ενός σχολίου εμφανίζει το κείμενό του και τη σχετική συζήτηση.

Για να ζητήσετε να εμφανίζονται ή να αποκρύπτονται τα σχόλια κατά το άνοιγμα μιας παρουσίασης χωρίς να αλλάξετε τα ίδια τα σχόλια, δείτε [Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης](/slides/el/python-java/presentation-view-properties/).

## **Γιατί να Προσθέσετε Σχόλια σε Παρουσιάσεις;**

Μπορείτε να χρησιμοποιήσετε τα σχόλια για να παρέχετε ανατροφοδότηση και να συνεργαστείτε με συναδέλφους κατά την αναθεώρηση παρουσιάσεων.

Το Aspose.Slides for Python via Java παρέχει τα ακόλουθα API για εργασία με σχόλια:

* Η κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) παρέχει πρόσβαση στους συγγραφείς σχολίων της παρουσίασης.
* Η κλάση [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) αντιπροσωπεύει τα σχόλια που σχετίζονται με έναν συγκεκριμένο συγγραφέα.
* Η κλάση [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) παρέχει πληροφορίες για ένα σχόλιο, συμπεριλαμβανομένου του συγγραφέα, της ώρας δημιουργίας, της θέσης και του κειμένου.
* Η κλάση [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) παρέχει πληροφορίες για έναν συγγραφέα, συμπεριλαμβανομένων του ονόματος, των αρχικών και των σχετικών σχολίων.

## **Προσθήκη Σχολίων σε Διαφάνειες**

Το παράδειγμα δημιουργεί δύο διαφάνειες και εγγράφει έναν συγγραφέα σχολίου με τη μέθοδο [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor). Χρησιμοποιεί τη [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) για να τοποθετήσει ένα σχόλιο σε κάθε διαφάνεια, στη συνέχεια ανακτά τα σχόλια της πρώτης διαφάνειας για αυτόν τον συγγραφέα με τη [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments). Η κονσόλα εμφανίζει το κείμενο του πρώτου σχολίου δυο φορές, δείχοντας την πρόσβαση τόσο μέσω της διαφάνειας όσο και του συγγραφέα, και η αποθηκευμένη παρουσίαση περιέχει και τα δύο σχόλια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))

    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Εύρεση ή Δημιουργία Συγγραφέα Σχολίου**

Όταν μια αυτοματοποιημένη αξιολόγηση επεξεργάζεται την ίδια παρουσίαση επανειλημμένα, ψάξτε στη συλλογή που επιστρέφει η [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) πριν προσθέσετε έναν συγγραφέα. Η [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) ταιριάζει τόσο με το όνομα όσο και με τα αρχικά και επιστρέφει έναν πίνακα με τους αντίστοιχους συγγραφείς, ή έναν κενό πίνακα αν δεν υπάρχουν αντιστοιχίες. Αντίθετα, η [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) ψάχνει μόνο με βάση το όνομα, ανεξάρτητα από τα αρχικά. Η κλήση της [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) με όνομα και αρχικά που ήδη υπάρχουν στη συλλογή ρίχνει εξαίρεση.

Το παράδειγμα απαιτεί ένα αρχείο παρουσίασης με τουλάχιστον μια διαφάνεια. Σε κάθε μια από τις δύο διεργασίες, επαναχρησιμοποιεί τον πρώτο ταιριαστό συγγραφέα, ή δημιουργεί έναν μόνο όταν το αποτέλεσμα είναι κενό. Αν υπάρχουν πολλαπλές αντιστοιχίες, επιλέγει το πρώτο στοιχείο του πίνακα χωρίς να συγχωνεύσει ή να αφαιρέσει τους άλλους συγγραφείς. Στη συνέχεια καλεί τη [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) για τον επιλεγμένο συγγραφέα και αποθηκεύει την παρουσίαση. Η δεύτερη διεργασία ανοίγει το αποτέλεσμα της πρώτης και επαναλαμβάνει τη λειτουργία.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

Η δεύτερη διεργασία προσθέτει ένα ακόμη σχόλιο χωρίς να προσθέσει νέο συγγραφέα ή να αφαιρέσει υπάρχοντα σχόλια. Το τελικό αρχείο, `review_pass_2.pptx`, περιέχει και τα νέα σχόλια μαζί με τυχόν αρχικά σχόλια. Η επαναχρησιμοποίηση ενός συγγραφέα δεν αφαιρεί διπλότυπα σχόλια: για να αποφύγετε την επαναλαμβανόμενη προσθήκη του ίδιου σχολίου, εφαρμόστε ξεχωριστή ανίχνευση διπλοτύπων πριν το προσθέσετε.

## **Πρόσβαση σε Σχόλια Διαφάνειας**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και διαβάζει τη συλλογή που επιστρέφει η [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors). Για κάθε συγγραφέα, περνάει τη συλλογή που επιστρέφει η [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments) και εκτυπώνει τον αριθμό της διαφάνειας, το κείμενο του σχολίου, το όνομα του συγγραφέα και την ώρα δημιουργίας. Η παρουσίαση εισόδου πρέπει να περιέχει σχόλια για να παραχθεί έξοδος στην κονσόλα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **Απάντηση σε Σχόλια**

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Οι μέθοδοι [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) και [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) σας επιτρέπουν να λάβετε ή να ορίσετε το γονικό σχόλιο.

Το παράδειγμα δημιουργεί σχόλια από δύο συγγραφείς και χρησιμοποιεί τη [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) για να δημιουργήσει απαντήσεις, συμπεριλαμβανομένης μιας απάντησης σε άλλη απάντηση. Π Passing `None` στην [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) ανασύρει τα σχόλια από όλους τους συγγραφείς· η κονσόλα εσοχή κάθε καταχώριση ανάλογα με το βάθος της ιεραρχίας απαντήσεων. Το παράδειγμα αποθηκεύει τη συνολική συζήτηση, καλεί τη [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) στο πρώτο ριζικό σχόλιο, και αποθηκεύει μια δεύτερη παρουσίαση με το εν λόγω σχόλιο και τις απαντήσεις του απομακρυσμένες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* Όταν η μέθοδος [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) χρησιμοποιείται για τη διαγραφή ενός σχολίου, όλες οι απαντήσεις σε εκείνο το σχόλιο διαγράφονται επίσης.
* Εάν η [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) δημιουργεί κυκλική αναφορά, ρίχνεται μια [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Τα σύγχρονα σχόλια μπορεί να συνδέονται με την ίδια τη διαφάνεια, με ένα συγκεκριμένο σχήμα ή με μια περιοχή κειμένου μέσα σε ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Η μέθοδος [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) δέχεται ένα επιχείρημα τύπου [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) εκτός από τη διαφάνεια και τις συντεταγμένες του δείκτη σχολίου.

Όταν παρασχέται `None` ως το επιχείρημα shape, το σχόλιο είναι σχόλια επιπέδου διαφάνειας. Ο δείκτης του τοποθετείται με τις δοθείσες συντεταγμένες, αλλά δεν συνδέεται με κάποιο συγκεκριμένο σχήμα, έτσι η [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) επιστρέφει `None`. Όταν παρέχεται ένα [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/), το σχόλιο αγκυροβολείται σε αυτό το σχήμα. Οι συντεταγμένες εξακολουθούν να ορίζουν τη θέση του δείκτη του σχολίου στη διαφάνεια, ενώ η σύνδεση σχήματος μπορεί να ανακτηθεί μέσω της [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape).

### **Αγκίστρωση Σύγχρονου Σχολίου σε Σχήμα**

Το παράδειγμα καλεί τη [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) δύο φορές: μια φορά με σχήμα `None` για σχόλιο επιπέδου διαφάνειας και μια φορά με ένα παραλληλόγραμμο ως άγκυρα. Η ανάγνωση της [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) εκτυπώνει `True` για τον έλεγχο `None` του σχολίου επιπέδου διαφάνειας και `Revenue title` για το αγκυροβολημένο σχόλιο. Και τα δύο σχόλια αποθηκεύονται με την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Αγκίστρωση Σχολίων σε Διάφορους Τύπους Σχημάτων**

Οποιοδήποτε αντικείμενο διαφάνειας που κληρονομεί από την [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) μπορεί να χρησιμοποιηθεί ως άγκυρα σχήματος. Συνηθισμένα παραδείγματα περιλαμβάνουν [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/), και [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) αντικείμενα όπως διαγράμματα.

Το παράδειγμα χρησιμοποιεί τη [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) για να συσχετίσει ένα σχόλιο με καθέναν από τους πέντε τύπους σχημάτων: ένα AutoShape, ένα picture frame, μια ομάδα, έναν connector και ένα διάγραμμα. Η εικόνα χρησιμοποιεί ενσωματωμένα δεδομένα εικόνας, οπότε δεν απαιτείται εξωτερική εικόνα. Κάθε σχόλιο έχει τη δική του θέση δείκτη, και η αποθηκευμένη παρουσίαση διατηρεί και τις πέντε συνδέσεις σχήματος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")

    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Αγκίστρωση Σχολίου σε Κείμενο και Ορισμός Κατάστασής του**

Για ένα σύγχρονο σχολίου που σχετίζεται με ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), οι μέθοδοι [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) και [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) προσπελάζουν τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος. Οι [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) και [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) προσπελάζουν το μήκος της επιλογής. Μαζί, αυτές οι τιμές συσχετίζουν το σχόλιο με ένα συγκεκριμένο εύρος κειμένου μέσα στο AutoShape.

Οι μέθοδοι [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) και [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) προσπελάζουν μια τιμή από τις σταθερές του [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — δεν έχει καθοριστεί συγκεκριμένη κατάσταση σύγχρονου σχολίου.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — το σχόλιο είναι ενεργό.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — το σχόλιο έχει επιλυθεί.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — το σχόλιο είναι κλειστό.

Το παράδειγμα αγκυροβολεί ένα σύγχρονο σχόλιο στις λέξεις «quarterly revenue» στο κείμενο ενός παραλληλογράμμου. Υπολογίζει την αρχή της επιλογής μηδενικής βάσης από το κείμενο και τη περνά στη [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart), και χρησιμοποιεί τη [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) για να ορίσει τον αριθμό των επιλεγμένων χαρακτήρων. Μετά την κλήση της [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) με `Resolved`, αποθηκεύει και ανοίγει ξανά την παρουσίαση. Οι τέσσερις έλεγχοι της κονσόλας θα πρέπει να εκτυπώσουν `True`, επιβεβαιώνοντας ότι η άγκυρα του σχήματος, το εύρος κειμένου και η κατάσταση διατηρήθηκαν.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **Επιθεώρηση Υπάρχοντων Σύγχρονων Σχολίων**

Το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση που περιέχει σύγχρονα σχόλια και εκτυπώνει το κείμενό τους, την κατάσταση και τα στοιχεία άγκυρας. Για την επιθεώρηση, ελέγξτε ποια σχόλια είναι στιγμιότυπα του [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/), έπειτα εξετάστε τις [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) και [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus). Ένα σχήμα `None` υποδηλώνει σχόλιο επιπέδου διαφάνειας. Για άγκυρα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), οι μέθοδοι επιλογής κειμένου εντοπίζουν το σχετικό εύρος στο πλαίσιο κειμένου του σχήματος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **Αφαίρεση Σχολίων**

Το Aspose.Slides for Python via Java σας επιτρέπει να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς τους από μια παρουσίαση ή να διαγράψετε επιλεγμένα σχόλια ενώ διατηρείτε τα υπόλοιπα. Τα παρακάτω παραδείγματα δείχνουν και τις δύο προσεγγίσεις και αποθηκεύουν την ενημερωμένη παρουσίαση.

### **Αφαίρεση Όλων των Σχολίων και των Συγγραφέων Σχολίων**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και καλεί τη [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) για κάθε συγγραφέα, στη συνέχεια καλεί τη [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) για να αφαιρέσει τους ίδιους τους συγγραφείς. Η αποθηκευμένη παρουσίαση δεν περιέχει ούτε σχόλια ούτε συγγραφείς σχολίων. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχόλια για να παρατηρήσετε την αφαίρεση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Αφαίρεση Συγκεκριμένων Σχολίων**

Το παράδειγμα δημιουργεί δύο σχόλια σε μια διαφάνεια και χρησιμοποιεί τη [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) για να βρει σχόλια από κάθε συγγραφέα. Συλλέγει σχόλια του οποίου το κείμενο ισούται με «comment 1» πριν καλέσει τη [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove), αποφεύγοντας αλλαγές στη συλλογή κατά την επιλογή. Η αποθηκευμένη παρουσίαση διατηρεί μόνο το «comment 2».

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides κατάσταση επιλυμένου για σύγχρονα σχόλια;**

Ναι. Η [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) και η [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) προσπελάζουν μια τιμή του [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/), συμπεριλαμβανομένης της `Resolved`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να διαβαστεί ξανά μετά το άνοιγμα του αρχείου.

**Υπάρχουν υποστηριζόμενες συζητήσεις με νηματοποίηση (αλυσίδες απαντήσεων), και υπάρχει όριο βάθους;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρεται στο [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment), επιτρέποντας αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους ενσωμάτωσης.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση του δείκτη ορίζεται από συντεταγμένες κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντάς σας να τοποθετήσετε ακριβώς το δείκτη στη διαφάνεια.