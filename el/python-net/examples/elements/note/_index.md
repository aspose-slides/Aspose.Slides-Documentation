---
title: Σημείωση
type: docs
weight: 240
url: /el/python-net/examples/elements/note/
keywords:
- σημείωση
- προσθήκη διαφάνειας σημειώσεων
- πρόσβαση σε διαφάνεια σημειώσεων
- αφαίρεση διαφάνειας σημειώσεων
- ενημέρωση κειμένου σημειώσεων
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Προσθήκη, ανάγνωση, επεξεργασία και εξαγωγή σημειώσεων ομιλητή σε Python με Aspose.Slides: μορφοποίηση κειμένου, διαχείριση σημειώσεων ανά διαφάνεια και έλεγχος ορατότητας σε PowerPoint και OpenDocument."
---
Δείχνει πώς να προσθέσετε, να διαβάσετε, να αφαιρέσετε και να ενημερώσετε διαφάνειες σημειώσεων χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη διαφάνειας σημειώσεων**

Δημιουργήστε μια διαφάνεια σημειώσεων και ορίστε κείμενο σε αυτήν.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε διαφάνεια σημειώσεων**

Διαβάστε κείμενο από μια υπάρχουσα διαφάνεια σημειώσεων.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Αφαίρεση διαφάνειας σημειώσεων**

Αφαιρέστε τη διαφάνεια σημειώσεων που σχετίζεται με μια διαφάνεια.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Αφαίρεση της διαφάνειας σημειώσεων.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ενημέρωση κειμένου σημειώσεων**

Αλλάξτε το κείμενο μιας διαφάνειας σημειώσεων.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Ενημέρωση κειμένου σημείωσης.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```