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
- πρόσθεσε σχόλιο
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
description: "Διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides για Python μέσω Java: προσθέστε, διαβάστε, επεξεργαστείτε, απαντήστε και αφαιρέστε σχόλια σε παρουσιάσεις PowerPoint γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τα σχόλια παρουσίασης με το Aspose.Slides για Python μέσω Java. Παρουσιάζει τους κύριους τύπους που σχετίζονται με τα σχόλια και δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες, να προσπελάζετε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις και σύγχρονα σχόλια, και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν κοινά σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση κειμένου σχολίου και μεταδεδομένων, η δημιουργία αλυσίδων απαντήσεων, και η αφαίρεση επιλεγμένων σχολίων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις στις διαφάνειες. Η επιλογή ενός σχολίου εμφανίζει το κείμενό του και τη σχετική συζήτηση.

Για να ζητήσετε τα σχόλια να εμφανίζονται ή να κρύβονται όταν ανοίγει μια παρουσίαση χωρίς να αλλάξουν τα ίδια τα σχόλια, δείτε [Show or Hide Comments When Opening a Presentation](/slides/el/python-java/presentation-view-properties/).

## **Γιατί να Προσθέσετε Σχόλια σε Παρουσιάσεις;**

Μπορείτε να χρησιμοποιήσετε τα σχόλια για να παρέχετε ανατροφοδότηση και να συνεργάζεστε με συναδέλφους κατά την αξιολόγηση παρουσιάσεων.

Aspose.Slides για Python μέσω Java παρέχει τα παρακάτω API για εργασία με σχόλια:

* Η κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που παρέχει πρόσβαση στους συγγραφείς σχολίων της παρουσίασης.
* Η κλάση [CommentCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/commentcollection/) που αντιπροσωπεύει τα σχόλια που σχετίζονται με έναν συγκεκριμένο συγγραφέα.
* Η κλάση [Comment](https://reference.aspose.com/slides/el/python-java/aspose.slides/comment/) που παρέχει πληροφορίες για ένα σχόλιο, συμπεριλαμβανομένου του συγγραφέα, της ώρας δημιουργίας, της θέσης και του κειμένου.
* Η κλάση [CommentAuthor](https://reference.aspose.com/slides/el/python-java/aspose.slides/commentauthor/) που παρέχει πληροφορίες για έναν συγγραφέα, συμπεριλαμβανομένου του ονόματός του, των αρχικών και των σχετικών σχολίων.

## **Προσθήκη Σχολίων σε Διαφάνειες**

Το παρακάτω παράδειγμα δείχνει πώς να προσθέσετε σχόλια σε διαφάνειες σε μια παρουσίαση PowerPoint:

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

## **Πρόσβαση σε Σχόλια Διαφάνειας**

Το παρακάτω παράδειγμα δείχνει πώς να προσπελάσετε υπάρχοντα σχόλια σε μια παρουσίαση PowerPoint:

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

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Οι μέθοδοι [Comment.getParentComment](https://reference.aspose.com/slides/el/python-java/aspose.slides/comment/#getParentComment) και [Comment.setParentComment](https://reference.aspose.com/slides/el/python-java/aspose.slides/comment/#setParentComment) σας επιτρέπουν να λάβετε ή να ορίσετε το γονικό ενός σχολίου.

Το παρακάτω παράδειγμα δείχνει πώς να προσθέσετε απαντήσεις και να εξετάσετε την προκύπτουσα ιεραρχία σχολίων:

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
* Όταν η μέθοδος [Comment.remove](https://reference.aspose.com/slides/el/python-java/aspose.slides/comment/#remove) χρησιμοποιείται για τη διαγραφή ενός σχολίου, όλες οι απαντήσεις σε αυτό το σχόλιο διαγράφονται επίσης.
* Αν η [Comment.setParentComment](https://reference.aspose.com/slides/el/python-java/aspose.slides/comment/#setParentComment) δημιουργήσει κυκλική αναφορά, θα εξαχθεί ένα [PptxEditException](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Τα σύγχρονα σχόλια μπορούν να συνδεθούν με τη διαφάνεια ίδια, με ένα συγκεκριμένο σχήμα ή με ένα εύρος κειμένου μέσα σε ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/). Η μέθοδος [CommentCollection.addModernComment](https://reference.aspose.com/slides/el/python-java/aspose.slides/commentcollection/#addModernComment) δέχεται ένα όρισμα [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/) επιπλέον της διαφάνειας και των συντεταγμένων του δείκτη σχολίου.

Όταν το `None` περνιέται ως όρισμα σχήματος, το σχόλιο είναι σχόλιο επιπέδου διαφάνειας. Ο δείκτης τοποθετείται από τις δοσμένες συντεταγμένες, αλλά δεν συνδέεται με συγκεκριμένο σχήμα, έτσι το [ModernComment.getShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#getShape) επιστρέφει `None`. Όταν παρέχεται ένα [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/), το σχόλιο αγκυρώνεται σε αυτό το σχήμα. Οι συντεταγμένες εξακολουθούν να καθορίζουν τη θέση του δείκτη σχολίου στη διαφάνεια, ενώ η σύνδεση με το σχήμα μπορεί να ανακτηθεί μέσω του [ModernComment.getShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#getShape).

### **Αγκύρωση Σύγχρονου Σχολίου σε Σχήμα**

Το παρακάτω παράδειγμα δημιουργεί τόσο ένα σύγχρονο σχόλιο επιπέδου διαφάνειας όσο και ένα σύγχρονο σχόλιο αγκυρωμένο σε ένα συγκεκριμένο [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/). Στη συνέχεια διαβάζει το συνδεδεμένο σχήμα από κάθε σχόλιο.

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

### **Αγκύρωση Σχολίων σε Διάφορους Τύπους Σχημάτων**

Οποιοδήποτε αντικείμενο διαφάνειας κληρονομεί από τη [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/) μπορεί να χρησιμοποιηθεί ως άγκυρο σχήματος. Συνηθισμένα παραδείγματα περιλαμβάνουν το [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/), το [PictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframe/), το [GroupShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/groupshape/), το [Connector](https://reference.aspose.com/slides/el/python-java/aspose.slides/connector/), και τις παρουσίες [GraphicalObject](https://reference.aspose.com/slides/el/python-java/aspose.slides/graphicalobject/) όπως γραφήματα.

Το παρακάτω παράδειγμα δημιουργεί πολλούς κοινούς τύπους σχημάτων και συσχετίζει ένα σύγχρονο σχόλιο με το καθένα.

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

### **Αγκύρωση Σχολίου σε Κείμενο και Ορισμός Κατάστασής του**

Για ένα σύγχρονο σχόλιο συνδεδεμένο με ένα [AutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshape/), οι μέθοδοι [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#getTextSelectionStart) και [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#setTextSelectionStart) προσπελαύνουν τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος. Οι [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#getTextSelectionLength) και [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#setTextSelectionLength) προσπελαύνουν το μήκος της επιλογής. Μαζί, αυτές οι τιμές συσχετίζουν το σχόλιο με ένα συγκεκριμένο εύρος κειμένου μέσα στο AutoShape.

Οι μέθοδοι [ModernComment.getStatus](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#getStatus) και [ModernComment.setStatus](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#setStatus) προσπερνούν μια τιμή από τις σταθερές [ModernCommentStatus](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncommentstatus/#NotDefined) — δεν έχει οριστεί συγκεκριμένη κατάσταση σύγχρονου σχολίου.
- [Active](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncommentstatus/#Active) — το σχόλιο είναι ενεργό.
- [Resolved](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncommentstatus/#Resolved) — το σχόλιο έχει επιλυθεί.
- [Closed](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncommentstatus/#Closed) — το σχόλιο είναι κλειστό.

Το παρακάτω παράδειγμα δημιουργεί ένα σύγχρονο σχόλιο αγκυρωμένο σε σχήμα, το συνδέει με μια επιλογή κειμένου, το σημειώνει ως επιλυμένο, αποθηκεύει την παρουσίαση και επαληθεύει τις τιμές μετά το άνοιγμα του αρχείου.

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

### **Έλεγχος Υπάρχων Σύγχρονων Σχολίων**

Για να ελέγξετε μια υπάρχουσα παρουσίαση, ελέγξτε ποια σχόλια είναι στιγμιότυπα του [ModernComment](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/), στη συνέχεια εξετάστε το [ModernComment.getShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#getShape), το [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#getTextSelectionStart), το [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#getTextSelectionLength) και το [ModernComment.getStatus](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#getStatus). Ένα σχήμα `None` υποδεικνύει σχόλιο επιπέδου διαφάνειας. Για άγκυρο [AutoShape], οι μέθοδοι επιλογής κειμένου προσδιορίζουν το σχετικό εύρος στο πλαίσιο κειμένου του σχήματος.

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

### **Αφαίρεση Όλων των Σχολίων και Συγγραφέων Σχολίων**

Το παρακάτω παράδειγμα δείχνει πώς να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς σχολίων από μια παρουσίαση:

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

Το παρακάτω παράδειγμα δείχνει πώς να αφαιρέσετε συγκεκριμένα σχόλια από μια διαφάνεια:

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

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Υποστηρίζει το Aspose.Slides κατάσταση 'επιλυμένο' για σύγχρονα σχόλια;**

Ναι. Οι μέθοδοι [ModernComment.getStatus](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#getStatus) και [ModernComment.setStatus](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncomment/#setStatus) προσπερνούν μια τιμή του [ModernCommentStatus](https://reference.aspose.com/slides/el/python-java/aspose.slides/moderncommentstatus/), συμπεριλαμβανομένου του `Resolved`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να διαβαστεί ξανά μετά το άνοιγμα του αρχείου.

**Υποστηρίζονται οι αλληλουχίες συζητήσεων (αλυσίδες απαντήσεων) και υπάρχει όριο εμφώλευσης;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρει το [parent comment](https://reference.aspose.com/slides/el/python-java/aspose.slides/comment/#getParentComment), επιτρέποντας αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους εμφώλευσης.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση του δείκτη ορίζεται από συντεταγμένες κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντάς σας να τοποθετήσετε τον δείκτη ακριβώς στη διαφάνεια.