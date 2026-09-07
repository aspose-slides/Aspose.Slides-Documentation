---
title: Μετάβαση διαφάνειας
type: docs
weight: 110
url: /el/python-java/examples/elements/slide-transition/
keywords:
- παράδειγμα κώδικα
- μετάβαση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εφαρμόστε και αφαιρέστε μεταβάσεις διαφάνειας και ορίστε αυτόματους χρονισμούς προώθησης διαφάνειας με παραδείγματα κώδικα Aspose.Slides για Python μέσω Java για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εφαρμόζετε εφέ μετάβασης διαφάνειας και χρονισμούς με **Aspose.Slides για Python μέσω Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Εγκατάσταση](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει `asposeslides` πριν ξεκινήσει το JVM, στη συνέχεια εισάγει το API μετά την εκκίνηση του JVM.

## **Προσθήκη μετάβασης διαφάνειας**

Εφαρμόστε το εφέ μετάβασης ξεθώριασης στη πρώτη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Εφαρμόστε μια μετάβαση ξεθώριασης.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε μετάβαση διαφάνειας**

Διαβάστε τον τύπο μετάβασης που είναι αυτήν τη στιγμή εκχωρημένος σε μια διαφάνεια.

```python
import jpype
import asposeslides

if not jpide.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # Πρόσβαση στον τύπο της μετάβασης.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Αφαίρεση μετάβασης διαφάνειας**

Καθαρίστε οποιοδήποτε εφέ μετάβασης. Το JPype εκθέτει τη σταθερά της Java με όνομα `None` ως `None_` επειδή το `None` είναι δεσμευμένη λέξη στην Python.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # Αφαίρεση του εφέ μετάβασης.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Ορισμός διάρκειας μετάβασης**

Καθορίστε για πόσο χρόνο εμφανίζεται η διαφάνεια πριν προχωρήσει αυτόματα. Αυτό το παράδειγμα προχωρά μετά από δύο δευτερόλεπτα και επιτρέπει επίσης την προώθηση με κλικ του ποντικιού. Αυτός ο συγχρονισμός ελέγχει την αυτόματη προώθηση της διαφάνειας, όχι την ταχύτητα του εφέ μετάβασης.

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # Σε χιλιοστά του δευτερολέπτου.
finally:
    presentation.dispose()
```