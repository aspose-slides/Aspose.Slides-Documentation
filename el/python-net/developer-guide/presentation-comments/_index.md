---
title: Διαχείριση Σχολίων Παρουσίασης σε Python
linktitle: Σχόλια Παρουσίασης
type: docs
weight: 100
url: /el/python-net/presentation-comments/
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
- Aspose.Slides
description: "Διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides for Python μέσω .NET: προσθέστε, διαβάστε, επεξεργαστείτε, απαντήστε και αφαιρέστε σχόλια σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειριστείτε σχόλια παρουσίασης με το Aspose.Slides for Python via .NET. Παρουσιάζει τους κύριους τύπους που σχετίζονται με τα σχόλια και δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες, να έχετε πρόσβαση σε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις και σύγχρονα σχόλια και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν συνήθεις περιπτώσεις αξιολόγησης και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση κειμένου σχολίου και μεταδεδομένων, η δημιουργία αλυσίδων απαντήσεων και η κατάργηση επιλεγμένων σχολίων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις πάνω στις διαφάνειες. Η επιλογή ενός σχολίου εμφανίζει το κείμενό του και τη σχετική συζήτηση.

## **Γιατί να Προσθέτετε Σχόλια σε Παρουσιάσεις;**

Μπορείτε να χρησιμοποιείτε σχόλια για να παρέχετε ανατροφοδότηση και να συνεργάζεστε με συναδέλφους κατά την αξιολόγηση παρουσιάσεων.

Aspose.Slides for Python via .NET παρέχει τα ακόλουθα API για εργασία με σχόλια:

* Η [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κλάση, η οποία παρέχει πρόσβαση στους συγγραφείς σχολίων της παρουσίασης.
* Η [CommentCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/commentcollection/) κλάση, η οποία αντιπροσωπεύει τα σχόλια που σχετίζονται με έναν συγκεκριμένο συγγραφέα.
* Η [Comment](https://reference.aspose.com/slides/el/python-net/aspose.slides/comment/) κλάση, η οποία παρέχει πληροφορίες για ένα σχόλιο, συμπεριλαμβανομένου του συγγραφέα, της ημερομηνίας δημιουργίας, της θέσης και του κειμένου.
* Η [CommentAuthor](https://reference.aspose.com/slides/el/python-net/aspose.slides/commentauthor/) κλάση, η οποία παρέχει πληροφορίες για έναν συγγραφέα, όπως το όνομα, τα αρχικά και τα συσχετισμένα σχόλια.

## **Προσθήκη Σχολίων σε Διαφάνειες**

Το παρακάτω παράδειγμα δείχνει πώς να προσθέσετε σχόλια σε διαφάνειες σε μια παρουσίαση PowerPoint:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε Σχόλια Διαφάνειας**

Το παρακάτω παράδειγμα δείχνει πώς να αποκτήσετε πρόσβαση σε υπάρχοντα σχόλια σε μια παρουσίαση PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **Απάντηση σε Σχόλια**

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Η [parent_comment](https://reference.aspose.com/slides/el/python-net/aspose.slides/comment/parent_comment/) ιδιότητα της [Comment](https://reference.aspose.com/slides/el/python-net/aspose.slides/comment/) κλάσης σάς επιτρέπει να λάβετε ή να ορίσετε το γονικό ενός σχολίου.

Το παρακάτω παράδειγμα δείχνει πώς να προσθέσετε απαντήσεις και να εξετάσετε την προκύπτουσα ιεραρχία σχολίων:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Όταν η [remove](https://reference.aspose.com/slides/el/python-net/aspose.slides/comment/remove/) μέθοδος της [Comment](https://reference.aspose.com/slides/el/python-net/aspose.slides/comment/) κλάσης χρησιμοποιείται για τη διαγραφή ενός σχολίου, όλες οι απαντήσεις σε εκείνο το σχόλιο διαγράφονται επίσης.
* Εάν η ιδιότητα [parent_comment](https://reference.aspose.com/slides/el/python-net/aspose.slides/comment/parent_comment/) δημιουργεί κυκλική αναφορά, προκύπτει μια [PptxEditException](https://reference.aspose.com/slides/el/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Τα σύγχρονα σχόλια μπορούν να συσχετιστούν με την ίδια τη διαφάνεια, με ένα συγκεκριμένο σχήμα ή με ένα εύρος κειμένου μέσα σε ένα AutoShape. Η μέθοδος [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/el/python-net/aspose.slides/commentcollection/add_modern_comment/) δέχεται ένα όρισμα [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) εκτός από τη διαφάνεια και τις συντεταγμένες του δείκτη σχολίου.

Όταν το `None` περνιέται ως όρισμα σχήματος, το σχόλιο είναι σχόλιο σε επίπεδο διαφάνειας. Ο δείκτης του θέτεται από τις δοθείσες συντεταγμένες, αλλά δεν συσχετίζεται με κάποιο συγκεκριμένο σχήμα, έτσι η [ModernComment.shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/shape/) επιστρέφει `None`. Όταν παρέχεται ένα [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/), το σχόλιο αγκυροβολείται σε αυτό το σχήμα. Οι συντεταγμένες συνεχίζουν να ορίζουν τη θέση του δείκτη σχολίου στη διαφάνεια, ενώ η συσχέτιση με το σχήμα μπορεί να ανακτηθεί μέσω της [ModernComment.shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/shape/).

### **Αγκυροβολή ενός Σύγχρονου Σχολίου σε Σχήμα**

Το παρακάτω παράδειγμα δημιουργεί τόσο ένα σχόλιο σε επίπεδο διαφάνειας όσο και ένα σύγχρονο σχόλιο αγκυροβολημένο σε ένα συγκεκριμένο AutoShape. Στη συνέχεια διαβάζει το συσχετισμένο σχήμα από κάθε σχόλιο.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Αγκυροβολή Σχολίων σε Διαφορετικούς Τύπους Σχημάτων**

Οποιοδήποτε αντικείμενο διαφάνειας που προέρχεται από την [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) μπορεί να χρησιμοποιηθεί ως άγκυρα σχήματος. Συνήθεις παράδειγμα περιλαμβάνουν τα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/el/python-net/aspose.slides/connector/) και [GraphicalObject](https://reference.aspose.com/slides/el/python-net/aspose.slides/graphicalobject/) όπως τα διαγράμματα.

Το παρακάτω παράδειγμα δημιουργεί πολλούς κοινούς τύπους σχημάτων και συσχετίζει ένα σύγχρονο σχόλιο με το καθένα.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Αγκυροβολή Σχολίου σε Κείμενο και Ορισμός της Κατάστασής του**

Για ένα σύγχρονο σχόλιο που σχετίζεται με ένα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/), η [ModernComment.text_selection_start](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/text_selection_start/) καθορίζει τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος, ενώ η [ModernComment.text_selection_length](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/text_selection_length/) καθορίζει το μήκος της επιλογής. Μαζί, αυτές οι ιδιότητες συσχετίζουν το σχόλιο με ένα συγκεκριμένο εύρος κειμένου μέσα στο AutoShape.

Η ιδιότητα [ModernComment.status](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/status/) μπορεί να διαβαστεί ή να ενημερωθεί με μια τιμή από την απαρίθμηση [ModernCommentStatus](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — δεν έχει οριστεί συγκεκριμένη κατάσταση σύγχρονου σχολίου.
- `ACTIVE` — το σχόλιο είναι ενεργό.
- `RESOLVED` — το σχόλιο έχει επιλυθεί.
- `CLOSED` — το σχόλιο είναι κλειστό.

Το παρακάτω παράδειγμα δημιουργεί ένα σχόλιο αγκυροβολημένο σε σχήμα, το συσχετίζει με μια επιλογή κειμένου, το σηματοδοτεί ως επιλυμένο, αποθηκεύει την παρουσίαση και επαληθεύει τις τιμές μετά το άνοιγμα του αρχείου.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = draw.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **Επιθεώρηση Υπαρχόντων Σύγχρονων Σχολίων**

Για να επιθεωρήσετε μια υπάρχουσα παρουσίαση, ελέγξτε ποια σχόλια είναι [ModernComment](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/) αντικείμενα, στη συνέχεια εξετάστε τις [ModernComment.shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/text_selection_length/) και [ModernComment.status](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/status/). Ένα σχήμα `None` υποδεικνύει σχόλιο σε επίπεδο διαφάνειας. Για άγκυρα [AutoShape](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshape/), οι ιδιότητες επιλογής κειμένου προσδιορίζουν το συσχετισμένο εύρος στο πλαίσιο κειμένου του σχήματος.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **Κατάργηση Σχολίων**

### **Κατάργηση Όλων των Σχολίων και Συγγραφέων Σχολίων**

Το παρακάτω παράδειγμα δείχνει πώς να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς σχολίων από μια παρουσίαση:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Κατάργηση Συγκεκριμένων Σχολίων**

Το παρακάτω παράδειγμα δείχνει πώς να αφαιρέσετε συγκεκριμένα σχόλια από μια διαφάνεια:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Υποστηρίζει το Aspose.Slides κατάσταση επιλυμένου για σύγχρονα σχόλια;**

Ναι. Η [ModernComment.status](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/status/) μπορεί να διαβαστεί και να οριστεί με μια τιμή του [ModernCommentStatus](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncommentstatus/), συμπεριλαμβανομένου του `RESOLVED`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να διαβαστεί ξανά μετά το άνοιγμα του αρχείου.

**Υποστηρίζονται οι αλληλουχίες συζητήσεων (αλυσίδες απαντήσεων) και υπάρχει όριο εσωτερικής εσοχής;**

Ναι. Κάθε σχόλιο μπορεί να αναφερθεί στο [parent comment](https://reference.aspose.com/slides/el/python-net/aspose.slides/comment/parent_comment/), επιτρέποντας αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους εσωτερικής εσοχής.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση του δείκτη ορίζεται από συντεταγμένες κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντάς σας να το τοποθετήσετε ακριβώς στη διαφάνεια.