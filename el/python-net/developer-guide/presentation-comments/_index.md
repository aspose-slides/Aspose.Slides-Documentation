---
title: Διαχείριση σχολίων παρουσίασης σε Python
linktitle: Σχόλια παρουσίασης
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
description: "Διαχειριστείτε τα σχόλια παρουσίασης με το Aspose.Slides για Python μέσω .NET: προσθέστε, διαβάστε, επεξεργαστείτε και διαγράψτε σχόλια σε αρχεία PowerPoint γρήγορα και εύκολα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τα σχόλια παρουσίασης στο Aspose.Slides. Δείχνει τους κύριους τύπους που σχετίζονται με τα σχόλια και παρουσιάζει πώς να προσθέτετε σχόλια σε διαφάνειες, να έχετε πρόσβαση σε υπάρχοντα σχόλια, να εργάζεστε με απαντήσεις, να χρησιμοποιείτε σύγχρονα σχόλια και να αφαιρείτε σχόλια από μια παρουσίαση.

Τα παραδείγματα εστιάζουν σε κοινά σενάρια αξιολόγησης και συνεργασίας στο PowerPoint, όπως η ανάθεση σχολίων σε συγγραφείς, η ανάγνωση του περιεχομένου και των μεταδεδομένων των σχολίων, η δημιουργία αλυσίδων απαντήσεων και η εκκαθάριση όλων των σχολίων ή η διαγραφή των επιλεγμένων.

Στο PowerPoint, ένα σχόλιο εμφανίζεται ως σημείωση ή επεξήγηση σε μια διαφάνεια. Όταν κάνετε κλικ σε ένα σχόλιο, το περιεχόμενό του ή τα μηνύματα του αποκαλύπτονται.

## **Γιατί να προσθέσετε σχόλια σε παρουσιάσεις;**

Μπορεί να θέλετε να χρησιμοποιήσετε σχόλια για να παρέχετε ανατροφοδότηση ή να επικοινωνήσετε με τους συναδέλφους σας όταν αξιολογείτε παρουσιάσεις.

Για να μπορείτε να χρησιμοποιείτε σχόλια σε παρουσιάσεις PowerPoint, το Aspose.Slides for Python via .NET παρέχει

* Η κλάση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) , η οποία περιέχει τις συλλογές των συγγραφέων (από την ιδιότητα [CommentAuthorCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/commentauthorcollection/) ). Οι συγγραφείς προσθέτουν σχόλια στις διαφάνειες. 
* Η κλάση [CommentCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/commentcollection/) , η οποία περιέχει τη συλλογή των σχολίων για μεμονωμένους συγγραφείς. 
* Η κλάση [Comment](https://reference.aspose.com/slides/el/python-net/aspose.slides/comment/) , η οποία περιέχει πληροφορίες σχετικά με τους συγγραφείς και τα σχόλιά τους: ποιος πρόσθεσε το σχόλιο, η ώρα που προστέθηκε το σχόλιο, η θέση του σχολίου κ.λπ. 
* Η κλάση [CommentAuthor](https://reference.aspose.com/slides/el/python-net/aspose.slides/commentauthor/) , η οποία περιέχει πληροφορίες για μεμονωμένους συγγραφείς: το όνομα του συγγραφέα, τα αρχικά του, τα σχόλια που σχετίζονται με το όνομα του συγγραφέα κ.λπ. 

## **Προσθήκη Σχολίου σε Διαφάνεια**
Αυτός ο κώδικας Python σας δείχνει πώς να προσθέσετε ένα σχόλιο σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

    # Δημιουργεί ένα αντικείμενο της κλάσης Presentation
    with slides.Presentation() as presentation:
        # Προσθέτει μια κενή διαφάνεια
        presentation.slides.add_empty_slide(presentation.layout_slides[0])

        # Προσθέτει έναν συγγραφέα
        author = presentation.comment_authors.add_author("Jawad", "MF")

        # Ορίζει τη θέση για τα σχόλια
        point = draw.PointF(0.2, 0.2)

        # Προσθέτει σχόλιο διαφάνειας για έναν συγγραφέα στη διαφάνεια 1
        author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

        # Προσθέτει σχόλιο διαφάνειας για έναν συγγραφέα στη διαφάνεια 2
        author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

        # Πρόσβαση στη διαφάνεια 1
        slide = presentation.slides[0]

        # Όταν περνιέται null ως όρισμα, τα σχόλια όλων των συγγραφέων φέρνονται στη συγκεκριμένη διαφάνεια
        comments = slide.get_slide_comments(author)

        # Πρόσβαση στο σχόλιο στη θέση 0 για τη διαφάνεια 1
        str = comments[0].text

        presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

        if comments.length > 0:
            # Επιλέγει τη συλλογή σχολίων του συγγραφέα στη θέση 0
            commentCollection = comments[0].author.comments
            print(commentCollection[0].text)
```

## **Πρόσβαση σε Σχόλια Διαφάνειας**
Αυτός ο κώδικας Python σας δείχνει πώς να αποκτήσετε πρόσβαση σε ένα υπάρχον σχόλιο σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο της κλάσης Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```

## **Απάντηση σε Σχόλια**
Ένα γονικό σχόλιο είναι το αρχικό σχόλιο σε μια ιεραρχία σχολίων ή απαντήσεων. Χρησιμοποιώντας την ιδιότητα `parent_comment` (από την κλάση [Comment](https://reference.aspose.com/slides/el/python-net/aspose.slides/comment/) ), μπορείτε να ορίσετε ή να λάβετε ένα γονικό σχόλιο. 

Αυτός ο κώδικας Python σας δείχνει πώς να προσθέσετε σχόλια και να λάβετε απαντήσεις σε αυτά:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Προσθέτει ένα σχόλιο
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Προσθέτει μια απάντηση στο comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Προσθέτει ακόμη μια απάντηση στο comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Προσθέτει μια απάντηση σε υπάρχουσα απάντηση
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Εμφανίζει την ιεραρχία των σχολίων στην κονσόλα
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # Αφαιρεί το comment1 και όλες τις απαντήσεις του
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Προσοχή" %}} 

* Όταν η μέθοδος `remove` (από την κλάση [Comment](https://reference.aspose.com/slides/el/python-net/aspose.slides/comment/) ) χρησιμοποιείται για τη διαγραφή ενός σχολίου, οι απαντήσεις στο σχόλιο επίσης διαγράφονται. 
* Εάν η ρύθμιση `parent_comment` δημιουργεί κυκλική αναφορά, θα εξαχθεί `PptxEditException`.

{{% /alert %}}

## **Προσθήκη Σύγχρονου Σχολίου**

Το 2021, η Microsoft εισήγαγε *σύγχρονα σχόλια* στο PowerPoint. Η λειτουργία των σύγχρονων σχολίων βελτιώνει σημαντικά τη συνεργασία στο PowerPoint. Μέσω των σύγχρονων σχολίων, οι χρήστες του PowerPoint μπορούν να επιλύουν σχόλια, να αγκυροβολούν σχόλια σε αντικείμενα και κείμενα και να αλληλεπιδρούν πολύ πιο εύκολα από πριν. 

Υλοποιήσαμε υποστήριξη για σύγχρονα σχόλια προσθέτοντας την κλάση [ModernComment](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/). Προστέθηκαν οι μέθοδοι `add_modern_comment` και `insert_modern_comment` στην κλάση [CommentCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/commentcollection/). 

Αυτός ο κώδικας Python σας δείχνει πώς να προσθέσετε ένα σύγχρονο σχόλιο σε μια διαφάνεια σε μια παρουσίαση PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Αφαίρεση Σχολίου**

### **Διαγραφή Όλων των Σχολίων και των Συγγραφέων**

Αυτός ο κώδικας Python σας δείχνει πώς να αφαιρέσετε όλα τα σχόλια και τους συγγραφείς σε μια παρουσίαση:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Διαγράφει όλα τα σχόλια από την παρουσίαση
    for author in presentation.comment_authors:
        author.comments.clear()

    # Διαγράφει όλους τους συγγραφείς
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Διαγραφή Συγκεκριμένων Σχολίων**

Αυτός ο κώδικας Python σας δείχνει πώς να διαγράψετε συγκεκριμένα σχόλια σε μια διαφάνεια:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # προσθήκη σχολίων...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # διαγραφή όλων των σχολίων που περιέχουν το κείμενο "comment 1"
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Υποστηρίζει το Aspose.Slides κατάσταση όπως «επιλυμένο» για σύγχρονα σχόλια;**

Ναι. Τα [Σύγχρονα σχόλια](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/) εκθέτουν μια ιδιότητα [status](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/status/); μπορείτε να διαβάσετε και να ορίσετε την [κατάσταση σχολίου](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncommentstatus/) (για παράδειγμα, να το σημάνετε ως επιλυμένο), και αυτή η κατάσταση αποθηκεύεται στο αρχείο και αναγνωρίζεται από το PowerPoint.

**Υποστηρίζονται οι αλυσίδες συζητήσεων (απαντήσεις) και υπάρχει όριο ένθεσης;**

Ναι. Κάθε σχόλιο μπορεί να αναφέρεται στο [parent comment](https://reference.aspose.com/slides/el/python-net/aspose.slides/moderncomment/parent_comment/), επιτρέποντας αυθαίρετες αλυσίδες απαντήσεων. Το API δεν δηλώνει συγκεκριμένο όριο βάθους ένθεσης.

**Σε ποιο σύστημα συντεταγμένων ορίζεται η θέση του δείκτη σχολίου σε μια διαφάνεια;**

Η θέση αποθηκεύεται ως σημείο κινητής υποδιαστολής στο σύστημα συντεταγμένων της διαφάνειας. Αυτό σας επιτρέπει να τοποθετήσετε τον δείκτη σχολίου με ακρίβεια όπου χρειάζεται.