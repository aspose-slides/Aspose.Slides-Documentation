---
title: ActiveX
type: docs
weight: 200
url: /el/python-java/examples/elements/activex/
keywords:
- παράδειγμα κώδικα
- ActiveX
- έλεγχος ActiveX
- ιδιότητες ActiveX
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides for Python via Java για να προσθέσετε, να έχετε πρόσβαση, να αφαιρέσετε και να διαμορφώσετε ελέγχους ActiveX σε παρουσιάσεις PowerPoint με πρακτικά παραδείγματα κώδικα."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε, να έχετε πρόσβαση, να αφαιρέσετε και να διαμορφώσετε ελέγχους ActiveX σε μια παρουσίαση χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, και στη συνέχεια εισάγει το API αφού η JVM λειτουργεί. Τα παραδείγματα πρόσβασης και αφαίρεσης χρησιμοποιούν το `add_activex.pptm`, το οποίο δημιουργήθηκε από το πρώτο παράδειγμα.

## **Προσθήκη ελέγχου ActiveX**

Εισάγετε έναν έλεγχο Windows Media Player στην πρώτη διαφάνεια και αποθηκεύστε την παρουσίαση ως αρχείο PPTM.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη ελέγχου Windows Media Player.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε έλεγχο ActiveX**

Αναγνώστε το όνομα και τη ρύθμιση αυτόματης αναπαραγωγής του πρώτου ελέγχου ActiveX στη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Πρόσβαση στον πρώτο έλεγχο ActiveX.
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **Αφαίρεση ελέγχου ActiveX**

Διαγράψτε τον πρώτο έλεγχο ActiveX από τη διαφάνεια και αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Αφαίρεση του πρώτου ελέγχου ActiveX.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Ρύθμιση ιδιοτήτων ActiveX**

Προσθέστε έναν έλεγχο Windows Media Player, απενεργοποιήστε την αυτόματη αναπαραγωγή και κρύψτε τα στοιχεία ελέγχου αναπαραγωγής του. Χρησιμοποιήστε το [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/el/python-java/aspose.slides/controlpropertiescollection/#set_Item) για να ορίσετε τις τιμές ιδιοτήτων ως συμβολοσειρές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη ελέγχου Windows Media Player και διαμόρφωση των ιδιοτήτων του.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```