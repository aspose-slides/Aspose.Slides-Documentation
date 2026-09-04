---
title: Διαφάνεια Διάταξης
type: docs
weight: 20
url: /el/python-java/examples/elements/layout-slide/
keywords:
- παράδειγμα κώδικα
- διαφάνεια διάταξης
- προσθήκη διαφάνειας διάταξης
- πρόσβαση διαφάνειας διάταξης
- αφαίρεση διαφάνειας διάταξης
- αχρησιμοποίητη διαφάνεια διάταξης
- κλωνοποίηση διαφάνειας διάταξης
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις διαφάνειες διάταξης με το Aspose.Slides για Python μέσω Java: προσθέστε, αποκτήστε πρόσβαση, αφαιρέστε, καθαρίστε και κλωνοποιήστε διαμορφώσεις σε παρουσιάσεις PowerPoint και OpenDocument."
---
Αυτό το άρθρο δείχνει πώς να εργάζεστε με **layout slides** χρησιμοποιώντας το Aspose.Slides για Python μέσω Java. Μια διαφάνεια διάταξης ορίζει το σχεδιασμό και τη μορφοποίηση που κληρονομούνται από τις κανονικές διαφάνειες. Μπορείτε να προσθέσετε, να αποκτήσετε πρόσβαση, να κλωνοποιήσετε και να αφαιρέσετε διαφάνειες διάταξης, καθώς και να καθαρίσετε τις αχρησιμοποίητες για να μειώσετε το μέγεθος της παρουσίασης.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM και έπειτα εισάγει το API αφού η JVM είναι ενεργή.

## **Προσθήκη διαφάνειας διάταξης**

Δημιουργήστε μια προσαρμοσμένη διαφάνεια διάταξης για να ορίσετε επαναχρησιμοποιήσιμη μορφοποίηση. Το παρακάτω παράδειγμα προσθέτει ένα πλαίσιο κειμένου σε μια νέα διάταξη και στη συνέχεια δημιουργεί δύο διαφάνειες που τη χρησιμοποιούν.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Δημιουργία διαφάνειας διάταξης με κενό τύπο διάταξης και προσαρμοσμένο όνομα.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Προσθήκη πλαισίου κειμένου στη διαφάνεια διάταξης.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Προσθήκη δύο διαφανειών που κληρονομούν το κείμενο από τη διάταξη.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Σημείωση 1:** Οι διαφάνειες διάταξης λειτουργούν ως πρότυπα για μεμονωμένες διαφάνειες. Μπορείτε να ορίσετε κοινά στοιχεία μία φορά και να τα επαναχρησιμοποιήσετε σε πολλές διαφάνειες.

> 💡 **Σημείωση 2:** Όταν προσθέτετε σχήματα ή κείμενο σε μια διαφάνεια διάταξης, όλες οι διαφάνειες που βασίζονται σε αυτήν την διάταξη εμφανίζουν αυτόματα το κοινό περιεχόμενο.  
> Η παρακάτω εικόνα δείχνει δύο διαφάνειες που κληρονομούν ένα πλαίσιο κειμένου από την ίδια διαφάνεια διάταξης.

![Διαφάνειες που κληρονομούν περιεχόμενο διάταξης](layout-slide-result.png)

## **Πρόσβαση σε διαφάνεια διάταξης**

Προσπελάστε τις διαφάνειες διάταξης με βάση το δείκτη ή τον τύπο διάταξης, όπως κενή, τίτλου ή κεφαλίδας ενότητας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Πρόσβαση σε διαφάνεια διάταξης με βάση το δείκτη.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Πρόσβαση σε διαφάνεια διάταξης με βάση τον τύπο.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Αφαίρεση διαφάνειας διάταξης**

Αφαιρέστε μια συγκεκριμένη διαφάνεια διάταξης όταν δεν χρειάζεται πλέον.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Αφαίρεση αχρησιμοποίητων διαφάνειων διάταξης**

Αφαιρέστε τις διαφάνειες διάταξης που δεν χρησιμοποιούνται από καμία κανονική διαφάνεια για να μειώσετε το μέγεθος της παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Κλωνοποίηση διαφάνειας διάταξης**

Δημιουργήστε αντίγραφο μιας διαφάνειας διάταξης και προσθέστε το στο τέλος της συλλογής διαφάνειας διάταξης.

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Σύνοψη:** Οι διαφάνειες διάταξης βοηθούν στη διατήρηση συνεπούς μορφοποίησης σε όλη την παρουσίαση. Το Aspose.Slides σας επιτρέπει να δημιουργείτε, διαχειρίζεστε, επαναχρησιμοποιείτε και καθαρίζετε τις διατάξεις όπως χρειάζεται.