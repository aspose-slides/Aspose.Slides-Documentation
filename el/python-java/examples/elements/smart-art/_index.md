---
title: SmartArt
type: docs
weight: 140
url: /el/python-java/examples/elements/smart-art/
keywords:
- παράδειγμα κώδικα
- SmartArt
- προσθήκη SmartArt
- πρόσβαση SmartArt
- αφαίρεση SmartArt
- διάταξη SmartArt
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δουλέψτε με SmartArt στο Aspose.Slides για Python μέσω Java: προσθέστε, προσπελάστε, αφαιρέστε και αλλάξτε τις διατάξεις διαγραμμάτων σε παρουσιάσεις PowerPoint και OpenDocument."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε γραφικά SmartArt, να τα προσπελάσετε, να τα καταργήσετε και να αλλάξετε τις διατάξεις χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει το JVM, και στη συνέχεια εισάγει το API μετά την εκκίνηση του JVM.

## **Add SmartArt**

Εισάγετε ένα γραφικό SmartArt χρησιμοποιώντας μία από τις ενσωματωμένες διατάξεις.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **Access SmartArt**

Ανακτήστε το πρώτο αντικείμενο SmartArt σε μια διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **Remove SmartArt**

Διαγράψτε ένα σχήμα SmartArt από τη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **Change SmartArt Layout**

Ενημερώστε τον τύπο διάταξης ενός υπάρχοντος γραφικού SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```