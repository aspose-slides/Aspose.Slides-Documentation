---
title: Μελάνη
type: docs
weight: 180
url: /el/python-net/examples/elements/ink/
keywords:
- μελάνη
- πρόσβαση μελάνης
- αφαίρεση μελάνης
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε την ψηφιακή μελάνη στις διαφάνειες με Python και Aspose.Slides: προσθέστε γραμμές στυλό, επεξεργαστείτε διαδρομές, ορίστε χρώμα και πλάτος, και εξάγετε τα αποτελέσματα για PowerPoint και OpenDocument."
---
Παρέχει παραδείγματα πρόσβασης σε υπάρχουσες σχήματα μελάνης και αφαίρεσής τους χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

> ❗ **Σημείωση:** Τα σχήματα μελάνης αντιπροσωπεύουν είσοδο χρήστη από εξειδικευμένες συσκευές. Το Aspose.Slides δεν μπορεί να δημιουργήσει νέες γραμμές μελάνης προγραμματιστικά, αλλά μπορείτε να διαβάσετε και να τροποποιήσετε την υπάρχουσα μελάνη.

## **Πρόσβαση στη Μελάνη**

Αποκτήστε το πρώτο σχήμα μελάνης από μια διαφάνεια.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Αφαίρεση Μελάνης**

Διαγράψτε ένα σχήμα μελάνης από τη διαφάνεια.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτοντας ότι το πρώτο σχήμα είναι αντικείμενο Ink.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```