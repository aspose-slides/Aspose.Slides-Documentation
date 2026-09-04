---
title: Μελάνη
type: docs
weight: 180
url: /el/python-java/examples/elements/ink/
keywords:
- παράδειγμα κώδικα
- μελάνη
- πρόσβαση σε μελάνη
- αφαίρεση μελάνης
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Πρόσβαση και αφαίρεση σχημάτων μελάνης σε παρουσιάσεις Aspose.Slides για Python μέσω Java, συμπεριλαμβανομένων των αρχείων PPT, PPTX και ODP."
---
Αυτό το άρθρο παρέχει παραδείγματα πρόσβασης σε υπάρχουσες σχήματα μελάνης και αφαίρεσής τους χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, και, στη συνέχεια, εισάγει το API αφού η JVM είναι σε λειτουργία.

{{% alert color="info" title="Note" %}}
Τα σχήματα μελάνης αντιπροσωπεύουν είσοδο χρήστη από εξειδικευμένες συσκευές. Το Aspose.Slides δεν μπορεί να δημιουργήσει νέα στίγματα μελάνης προγραμματιστικά, αλλά μπορείτε να διαβάσετε και να τροποποιήσετε την υπάρχουσα μελάνη.
{{% /alert %}}

## **Πρόσβαση σε Μελάνη**

Διαβάστε τις ετικέτες από το πρώτο σχήμα μελάνης σε μια διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # Χρησιμοποιήστε το tag_name όπως χρειάζεται.
finally:
    presentation.dispose()
```

## **Αφαίρεση Μελάνης**

Διαγράψτε ένα σχήμα μελάνης από τη διαφάνεια αν υπάρχει.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```