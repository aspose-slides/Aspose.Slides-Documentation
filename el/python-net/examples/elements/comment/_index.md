---
title: Σχόλιο
type: docs
weight: 230
url: /el/python-net/examples/elements/comment/
keywords:
- σχόλιο
- μοντέρνο σχόλιο
- προσθήκη σχολίου
- πρόσβαση σε σχόλιο
- αφαίρεση σχολίου
- απάντηση σε σχόλιο
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχείριση σχολίων διαφανειών σε Python με Aspose.Slides: προσθήκη, ανάγνωση, απάντηση, επεξεργασία, διαγραφή και εργασία με συνδεδεμένα σχόλια για PowerPoint και OpenDocument."
---
Δείχνει πώς να προσθέσετε, να διαβάσετε, να καταργήσετε και να απαντήσετε σε μοντέρνα σχόλια χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη μοντέρνου σχολίου**

Δημιουργήστε ένα σχόλιο που γράφτηκε από έναν χρήστη και αποθηκεύστε την παρουσίαση.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Προσθήκη συγγραφέα σχολίου.
        author = presentation.comment_authors.add_author("User", "U1")

        # Προσθήκη μοντέρνου σχολίου.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε μοντέρνο σχόλιο**

Διαβάστε ένα μοντέρνο σχόλιο από μια υπάρχουσα παρουσίαση.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Πρόσβαση στο πρώτο μοντέρνο σχόλιο.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Αφαίρεση μοντέρνου σχολίου**

Αφαιρέστε ένα σχόλιο και αποθηκεύστε το ενημερωμένο αρχείο.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Αφαίρεση του σχολίου.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Απάντηση σε μοντέρνο σχόλιο**

Προσθέστε απαντήσεις σε ένα γονικό μοντέρνο σχόλιο.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Προσθήκη γονικού σχολίου.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Προσθήκη πρώτης απάντησης.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Προσθήκη δεύτερης απάντησης.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```