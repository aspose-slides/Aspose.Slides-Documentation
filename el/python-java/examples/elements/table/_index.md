---
title: Πίνακας
type: docs
weight: 120
url: /el/python-java/examples/elements/table/
keywords:
- παράδειγμα κώδικα
- πίνακας
- προσθήκη πίνακα
- πρόσβαση σε πίνακα
- διαγραφή πίνακα
- συγχώνευση κελιών
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εργαστείτε με πίνακες στο Aspose.Slides για Python μέσω Java: προσθήκη, πρόσβαση, διαγραφή και συγχώνευση κελιών σε παρουσιάσεις PowerPoint και OpenDocument."
---
Παραδείγματα προσθήκης πινάκων, πρόσβασης σε αυτούς, διαγραφής τους και συγχώνευσης κελιών με χρήση **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, και στη συνέχεια εισάγει το API αφού η JVM λειτουργεί.

## **Προσθήκη Πίνακα**

Δημιουργήστε έναν απλό πίνακα με δύο γραμμές και δύο στήλες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε Πίνακα**

Ανακτήστε το πρώτο σχήμα πίνακα στη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # Πρόσβαση στον πρώτο πίνακα στη διαφάνεια.
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **Αφαίρεση Πίνακα**

Διαγράψτε έναν πίνακα από μια διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    slide.getShapes().remove(table)
finally:
    presentation.dispose()
```

## **Συγχώνευση Κελιών Πίνακα**

Συγχωνεύστε τα γειτονικά κελιά ενός πίνακα σε ένα ενιαίο κελί.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # Συγχώνευση κελιών.
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```