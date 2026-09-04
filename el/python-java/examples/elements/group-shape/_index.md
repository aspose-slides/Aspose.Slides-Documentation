---
title: Σχήμα Ομάδας
type: docs
weight: 170
url: /el/python-java/examples/elements/group-shape/
keywords:
- παράδειγμα κώδικα
- σχήμα ομάδας
- προσθήκη σχήματος ομάδας
- πρόσβαση σε σχήμα ομάδας
- αφαίρεση σχήματος ομάδας
- απο-ομαδοποίηση σχημάτων
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα σχήματα ομάδας σε παρουσιάσεις με το Aspose.Slides για Python μέσω Java: προσθέστε, προσπελάστε, αφαιρέστε και απο-ομαδοποιήστε σχήματα σε αρχεία PowerPoint και OpenDocument."
---
Αυτό το άρθρο δείχνει πώς να δημιουργείτε ομάδες σχημάτων, να τις προσπελάζετε, να τις διαγράφετε και να απο-ομαδοποιείτε τα περιεχόμενά τους χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει το JVM, και στη συνέχεια εισάγει το API αφού το JVM είναι σε λειτουργία.

## **Προσθήκη Σχήματος Ομάδας**

Δημιουργήστε μια ομάδα που περιέχει δύο βασικά σχήματα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε Σχήμα Ομάδας**

Ανακτήστε το πρώτο σχήμα ομάδας από μια διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    first_group = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, GroupShape):
            first_group = shape
            break
finally:
    presentation.dispose()
```

## **Αφαίρεση Σχήματος Ομάδας**

Διαγράψτε ένα σχήμα ομάδας από τη διαφάνεια.

```python
import jpile
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()

    slide.getShapes().remove(group)
finally:
    presentation.dispose()
```

## **Απο-ομαδοποίηση Σχημάτων**

Μετακινήστε ένα σχήμα έξω από το κοντέινερ της ομάδας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    rectangle = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    # Μετακινήστε το σχήμα έξω από την ομάδα.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```