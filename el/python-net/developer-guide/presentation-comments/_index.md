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

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε σχόλια παρουσίασης με το Aspose.Slides for Python μέσω .NET. Παρουσιάζει τους κύριους τύπους σχετικούς με τα σχόλια και δείχνει πώς να προσθέτετε σχόλια σε διαφάνειες, να έχετε πρόσβαση σε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις και σύγχρονα σχόλια, και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα καλύπτουν συνηθισμένα σενάρια ελέγχου και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση κειμένου σχολίου και μεταδεδομένων, η δημιουργία αλυσίδων απαντήσεων και η αφαίρεση επιλεγμένων σχολίων ή όλων των σχολίων.

Στο PowerPoint, τα σχόλια εμφανίζονται ως σημειώσεις στις διαφάνειες. Η επιλογή ενός σχολίου εμφανίζει το κείμενο του και τη σχετική συζήτηση.

Για να ζητήσετε να εμφανίζονται ή να αποκρύπτονται τα σχόλια όταν ανοίγει μια παρουσίαση χωρίς να αλλάξετε τα ίδια τα σχόλια, δείτε [Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης](/slides/el/python-net/presentation-view-properties/).

## **Γιατί Προσθέτετε Σχόλια σε Παρουσιάσεις;**

Μπορείτε να χρησιμοποιήσετε τα σχόλια για να παρέχετε ανατροφοδότηση και να συνεργαστείτε με συναδέλφους κατά την ανασκόπηση παρουσιάσεων.

Aspose.Slides for Python μέσω .NET παρέχει τα παρακάτω API για εργασία με σχόλια:

* Η [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) κλάση, η οποία παρέχει πρόσβαση στους συγγραφείς σχολίων της παρουσίασης.
* Η [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) κλάση, η οποία αντιπροσωπεύει τα σχόλια που σχετίζονται με έναν μεμονωμένο συγγραφέα.
* Η [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) κλάση, η οποία παρέχει πληροφορίες σχετικά με ένα σχόλιο, συμπεριλαμβανομένου του συγγραφέα, του χρόνου δημιουργίας, της θέσης και του κειμένου.
* Η [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) κλάση, η οποία παρέχει πληροφορίες για έναν συγγραφέα, συμπεριλαμβανομένων του ονόματός του, των αρχικών και των σχετικών σχολίων.

## **Προσθήκη Σχολίων σε Διαφάνειες**

Το παράδειγμα δημιουργεί δύο διαφάνειες και καταχωρεί έναν συγγραφέα σχολίου με την [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). Χρησιμοποιεί την [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) για να τοποθετήσει ένα σχόλιο σε κάθε διαφάνεια, κατόπιν ανακτά τα σχόλια της πρώτης διαφάνειας για αυτόν τον συγγραφέα με την [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/). Η κονσόλα εμφανίζει το κείμενο του πρώτου σχολίου δύο φορές, δείχνοντας την πρόσβαση μέσω της διαφάνειας και του συγγραφέα, και η αποθηκευμένη παρουσίαση περιέχει και τα δύο σχόλια.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
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

## **Εύρεση ή Δημιουργία Συγγραφέα Σχολίου**

Όταν μια αυτοματοποιημένη αξιολόγηση επεξεργάζεται την ίδια παρουσίαση επανειλημμένα, ψάξτε στη συλλογή [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) πριν προσθέσετε έναν συγγραφέα. Η [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) ταιριάζει τόσο με το όνομα όσο και με τις αρχικές και επιστρέφει έναν πίνακα με τους αντίστοιχους συγγραφείς, ή έναν κενό πίνακα αν δεν υπάρχουν αντιστοιχίες. Σε αντίθεση, η [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) αναζητά μόνο με βάση το όνομα, αγνοώντας τις αρχικές. Η κλήση της [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) με όνομα και αρχικές που υπάρχουν ήδη στη συλλογή ρίχνει εξαίρεση.

Το παράδειγμα απαιτεί ένα αρχείο παρουσίασης με τουλάχιστον μία διαφάνεια. Σε κάθε διπλό πέρασμα, επαναχρησιμοποιεί τον πρώτο ταιριαστό συγγραφέα, ή δημιουργεί έναν μόνο όταν το αποτέλεσμα είναι κενό. Αν υπάρχουν πολλαπλές αντιστοιχίες, επιλέγει το πρώτο στοιχείο του πίνακα χωρίς να συγχωνεύει ή να αφαιρεί τους υπόλοιπους συγγραφείς. Στη συνέχεια καλεί την [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) για τον επιλεγμένο συγγραφέα και αποθηκεύει την παρουσίαση. Το δεύτερο πέρασμα ανοίγει το αποτέλεσμα του πρώτου περάσματος και επαναλαμβάνει τη λειτουργία.

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

Το δεύτερο πέρασμα προσθέτει άλλο σχόλιο χωρίς να προσθέτει νέο συγγραφέα ή να αφαιρεί υπάρχοντα σχόλια. Το τελικό αρχείο, `review_pass_2.pptx`, περιέχει και τα νέα σχόλια και τυχόν αρχικά σχόλια. Η επαναχρησιμοποίηση ενός συγγραφέα δεν αφαιρεί διπλότυπα σχόλια: για να αποφύγετε την επανειλημμένη προσθήκη του ίδιου σχολίου, υλοποιήστε ξεχωριστό μηχανισμό ανίχνευσης διπλότυπων πριν το προσθέσετε.

## **Πρόσβαση σε Σχόλια Διαφάνειας**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και διαβάζει τη συλλογή [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/). Για κάθε συγγραφέα, επαναλαμβάνει τα [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) και εκτυπώνει τον αριθμό της διαφάνειας, το κείμενο του σχολίου, το όνομα του συγγραφέα και την ώρα δημιουργίας. Η εισερχόμενη παρουσίαση πρέπει να περιέχει σχόλια για να παραχθεί έξοδος στην κονσόλα.

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

Ένα γονικό σχόλιο είναι το αρχικό σχόλιο στην κορυφή μιας ιεραρχίας απαντήσεων. Η ιδιότητα [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) της κλάσης [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) επιτρέπει να λάβετε ή να ορίσετε το γονικό σχόλιο.

Το παράδειγμα δημιουργεί σχόλια από δύο συγγραφείς και χρησιμοποιεί την [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) για να δημιουργήσει απαντήσεις, συμπεριλαμβανομένης μιας απάντησης σε άλλη απάντηση. Η παράδοση `None` στην [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) ανακτά σχόλια από όλους τους συγγραφείς· η κονσόλα εσοχές κάθε καταχώριση ανάλογα με το βάθος της στη ιεραρχία απαντήσεων. Το παράδειγμα αποθηκεύει τη συζήτηση, καλεί τη [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) στο πρώτο ριζικό σχόλιο και αποθηκεύει δεύτερη παρουσίαση με αυτό το σχόλιο και τις απαντήσεις του αφαιρεμένες.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}

* Όταν η μέθοδος [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) της κλάσης [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) χρησιμοποιείται για διαγραφή ενός σχολίου, όλες οι απαντήσεις σε αυτό το σχόλιο διαγράφονται επίσης.
* Εάν η ιδιότητα [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) δημιουργεί κυκλική αναφορά, ρίχνεται ένα [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).

{{% /alert %}}

## **Προσθήκη Σύγχρονων Σχολίων**

Τα σύγχρονα σχόλια μπορούν να συνδεθούν με την ίδια τη διαφάνεια, με ένα συγκεκριμένο σχήμα ή με μια περιοχή κειμένου μέσα σε AutoShape. Η μέθοδος [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) δέχεται ένα όρισμα [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) εκτός από τη διαφάνεια και τις συντεταγμένες του δείκτη σχολίου.

Όταν περνιέται `None` για το όρισμα shape, το σχόλιο είναι σχολίαση επιπέδου διαφάνειας. Ο δείκτης τοποθετείται με τις δοθείσες συντεταγμένες, αλλά δεν συνδέεται με συγκεκριμένο σχήμα, έτσι η ιδιότητα [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) επιστρέφει `None`. Όταν παρέχεται ένα [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), το σχόλιο αγκυροβολείται σε αυτό το σχήμα. Οι συντεταγμένες εξακολουθούν να ορίζουν τη θέση του δείκτη σχολίου στη διαφάνεια, ενώ η σύνδεση σχήματος μπορεί να ανακτηθεί μέσω της [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/).

### **Αγκίστρωση Σύγχρονου Σχολίου σε Σχήμα**

Το παράδειγμα καλεί την [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) δύο φορές: μία με `None` shape για σχόλιο επιπέδου διαφάνειας και μία με ορθογώνιο ως άγκυρα. Η ανάγνωση του [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) εκτυπώνει `True` για τον έλεγχο μηδενικού του σχόλιου επιπέδου διαφάνειας και `Revenue title` για το αγκυροβόλησμένο σχόλιο. Και τα δύο σχόλια αποθηκεύονται με την παρουσίαση.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Αγκίστρωση Σχολίων σε Διάφορους Τύπους Σχημάτων**

Οποιοδήποτε αντικείμενο διαφάνειας που προέρχεται από την κλάση [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) μπορεί να χρησιμοποιηθεί ως άγκυρα σχήματος. Συνήθεις παραδείγματα περιλαμβάνουν [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/), και [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) όπως τα γραφήματα.

Το παράδειγμα χρησιμοποιεί την [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) για να συνδέσει ένα σχόλιο με καθένα από πέντε τύπους σχημάτων: ένα AutoShape, ένα picture frame, μια ομάδα, έναν connector και ένα γράφημα. Η εικόνα ενσωματώνει δεδομένα εικόνας, οπότε δεν απαιτείται εξωτερική εικόνα. Κάθε σχόλιο έχει τη δική του θέση δείκτη, και η αποθηκευμένη παρουσίαση διατηρεί όλες τις πέντε συνδέσεις σχήματος.

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Αγκίστρωση Σχολίου σε Κείμενο και Ορισμός Κατάστασης**

Για ένα σύγχρονο σχόλιο που σχετίζεται με ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), η ιδιότητα [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) ορίζει τη θέση έναρξης του επιλεγμένου κειμένου στο πλαίσιο κειμένου του σχήματος, ενώ η ιδιότητα [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) ορίζει το μήκος της επιλογής. Μαζί, αυτές οι ιδιότητες συνδέουν το σχόλιο με ένα συγκεκριμένο εύρος κειμένου μέσα στο AutoShape.

Η ιδιότητα [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) μπορεί να διαβαστεί ή να ενημερωθεί με τιμή από την απαρίθμηση [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — δεν έχει οριστεί συγκεκριμένη κατάσταση σύγχρονου σχολίου.
- `ACTIVE` — το σχόλιο είναι ενεργό.
- `RESOLVED` — το σχόλιο έχει επιλυθεί.
- `CLOSED` — το σχόλιο είναι κλειστό.

Το παράδειγμα αγκυροβολεί ένα σύγχρονο σχόλιο στις λέξεις «quarterly revenue» σε κείμενο ορθογωνίου. Υπολογίζει τη μηδενική θέση του [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) από το κείμενο και ορίζει το [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) στον αριθμό των επιλεγμένων χαρακτήρων. Μετά τον ορισμό του [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) σε `RESOLVED`, αποθηκεύει και ανοίγει ξανά την παρουσίαση. Οι τέσσερις έλεγχοι στην κονσόλα θα πρέπει να εκτυπώνουν `True`, επιβεβαιώνοντας ότι η άγκυρα σχήματος, το εύρος κειμένου και η κατάσταση διατηρήθηκαν.

```python
from datetime import datetime

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
    comment_position = slides.PointF(60, 60)
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

### **Έλεγχος Υπάρχοντων Σύγχρονων Σχολίων**

Το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση που περιέχει σύγχρονα σχόλια και εκτυπώνει το κείμενό τους, την κατάσταση και τις λεπτομέρειες άγκυρας. Για να τα εξετάσετε, ελέγξτε ποια σχόλια είναι στιγμιότυπα της κλάσης [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/), κατόπιν εξετάστε τις ιδιότητες [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/), και [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). Ένα σχήμα `None` υποδεικνύει σχόλιο επιπέδου διαφάνειας. Για άγκυρα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), οι ιδιότητες επιλογής κειμένου προσδιορίζουν το σχετικό εύρος στο πλαίσιο κειμένου του σχήματος.

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

## **Αφαίρεση Σχολίων**

Aspose.Slides for Python μέσω .NET επιτρέπει την αφαίρεση όλων των σχολίων και των συγγραφέων τους από μια παρουσίαση ή τη διαγραφή επιλεγμένων σχολίων διατηρώντας τα υπόλοιπα. Τα παρακάτω παραδείγματα δείχνουν και τις δύο προσεγγίσεις και αποθηκεύουν την ενημερωμένη παρουσίαση.

### **Αφαίρεση Όλων των Σχολίων και των Συγγραφέων Σχολίων**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και καλεί την [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) για κάθε συγγραφέα, στη συνέχεια καλεί την [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) για να αφαιρέσει τους ίδιους τους συγγραφείς. Η αποθηκευμένη παρουσίαση δεν περιέχει ούτε σχόλια ούτε συγγραφείς σχολίων. Χρησιμοποιήστε μια παρουσίαση που περιέχει σχόλια για να παρατηρήσετε την αφαίρεση.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Αφαίρεση Συγκεκριμένων Σχολίων**

Το παράδειγμα δημιουργεί δύο σχόλια σε μία διαφάνεια και χρησιμοποιεί την [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) για να βρει σχόλια ανά συγγραφέα. Συλλέγει σχόλια των οποίων το κείμενο ισούται με «comment 1» πριν καλέσει την [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/), αποφεύγοντας αλλαγές στη συλλογή κατά την επιλογή. Η αποθηκευμένη παρουσίαση διατηρεί μόνο το «comment 2».

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
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

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Υποστηρίζει το Aspose.Slides κατάσταση resolved για σύγχρονα σχόλια;**

Ναι. Η [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) μπορεί να διαβαστεί και να οριστεί με τιμή του [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/), συμπεριλαμβανομένου του `RESOLVED`. Η κατάσταση αποθηκεύεται στην παρουσίαση και μπορεί να διαβαστεί ξανά μετά το άνοιγμα του αρχείου.

**Υποστηρίζονται οι αλληλουχίες συζητήσεων (αλυσίδες απαντήσεων) και υπάρχει όριο βάθους;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρεται στο [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/), επιτρέποντας αλυσίδες απαντήσεων. Το API δεν ορίζει συγκεκριμένο όριο βάθους.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση του δείκτη ορίζεται από συντεταγμένες κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας, επιτρέποντάς σας να τοποθετήσετε ακριβώς τον δείκτη στην διαφάνεια.