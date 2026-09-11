---
title: Διαχείριση γραφικών SmartArt σε παρουσιάσεις χρησιμοποιώντας Python
linktitle: Γραφικά SmartArt
type: docs
weight: 20
url: /el/python-java/manage-smartart-shape/
keywords:
- Αντικείμενο SmartArt
- Γραφικό SmartArt
- Στυλ SmartArt
- Χρώμα SmartArt
- Δημιουργία SmartArt
- Προσθήκη SmartArt
- Επεξεργασία SmartArt
- Αλλαγή SmartArt
- Πρόσβαση SmartArt
- Τύπος διάταξης SmartArt
- PowerPoint
- Παρουσίαση
- Python
- Aspose.Slides
description: "Αυτοματοποιήστε τη δημιουργία, επεξεργασία και στυλιζάρισμα SmartArt σε PowerPoint με τη χρήση Python και Aspose.Slides, προσφέροντας σύντομα παραδείγματα κώδικα και οδηγίες προσανατολισμένες στην απόδοση."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να δημιουργείτε και να διαχειρίζεστε γραφικά SmartArt σε παρουσιάσεις PowerPoint προγραμματιστικά. Αυτό το άρθρο εξηγεί πώς να προσθέσετε ένα σχήμα SmartArt σε διαφάνεια, πώς να έχετε πρόσβαση σε υπάρχοντα σχήματα SmartArt, πώς να βρείτε SmartArt με συγκεκριμένο τύπο διάταξης και πώς να ενημερώσετε την εμφάνισή του αλλάζοντας το στυλ SmartArt ή το στυλ χρώματος.

Τα παραδείγματα δείχνουν πώς να εργάζεστε με σχήματα SmartArt μέσω της συλλογής σχημάτων της διαφάνειας, να ελέγχετε εάν ένα σχήμα είναι SmartArt και, στη συνέχεια, να τροποποιείτε ή να ελέγχετε τις ιδιότητές του.

## **Δημιουργία σχήματος SmartArt**
Το Aspose.Slides for Python via Java παρέχει ένα API για τη δημιουργία σχημάτων SmartArt. Για να δημιουργήσετε ένα σχήμα SmartArt σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Λάβετε μια διαφάνεια με το δείκτη της.
1. [Προσθήκη SmartArt σχήματος](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addSmartArt) καθορίζοντας έναν [SmartArtLayoutType](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartartlayouttype/).
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Λάβετε την πρώτη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη σχήματος SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Αποθήκευση της παρουσίασης.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Σχήμα: SmartArt σχήμα προστέθηκε στη διαφάνεια**|

## **Πρόσβαση σε σχήμα SmartArt σε διαφάνεια**
Το παρακάτω παράδειγμα αποκτά πρόσβαση σε σχήματα SmartArt σε μια διαφάνεια παρουσίασης. Διατρέχει κάθε σχήμα στη διαφάνεια και ελέγχει εάν το σχήμα είναι ένα αντικείμενο [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Πρόσβαση σε σχήμα SmartArt με συγκεκριμένο τύπο διάταξης**
Το παρακάτω παράδειγμα αποκτά πρόσβαση σε ένα σχήμα [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/) με συγκεκριμένο τύπο διάταξης, που επιστρέφεται από το [SmartArt.getLayout](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/#getLayout).

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσία που περιέχει σχήμα SmartArt.
1. Λάβετε την πρώτη διαφάνεια με το δείκτη της.
1. Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι ένα αντικείμενο [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/).
1. Ελέγξτε εάν το σχήμα SmartArt έχει τον καθορισμένο τύπο διάταξης και εκτελέστε την απαιτούμενη λειτουργία.

```python
import jpype
import asposeslides

if not jpame.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Ελέγξτε τη διάταξη SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **Αλλαγή στυλ σχήματος SmartArt**
Αυτό το παράδειγμα δείχνει πώς να αλλάξετε το γρήγορο στυλ ενός σχήματος SmartArt.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσία που περιέχει σχήμα SmartArt.
1. Λάβετε την πρώτη διαφάνεια με το δείκτη της.
1. Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι ένα αντικείμενο [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/).
1. Βρείτε το σχήμα SmartArt με το καθορισμένο στυλ.
1. Ορίστε το νέο στυλ για το σχήμα SmartArt.
1. Αποθηκεύστε την παρουσία.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Ελέγξτε και αλλάξτε το στυλ SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Σχήμα: SmartArt σχήμα με αλλαγμένο στυλ**|

## **Αλλαγή στυλ χρώματος σχήματος SmartArt**
Αυτό το παράδειγμα αποκτά πρόσβαση σε σχήμα SmartArt με συγκεκριμένο στυλ χρώματος και αλλάζει αυτό το στυλ.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσία που περιέχει σχήμα SmartArt.
1. Λάβετε την πρώτη διαφάνεια με το δείκτη της.
1. Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι ένα αντικείμενο [SmartArt](https://reference.aspose.com/slides/el/python-java/aspose.slides/smartart/).
1. Βρείτε το σχήμα SmartArt με το καθορισμένο στυλ χρώματος.
1. Ορίστε το νέο στυλ χρώματος για το σχήμα SmartArt.
1. Αποθηκεύστε την παρουσία.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Διατρέξτε κάθε σχήμα στην πρώτη διαφάνεια.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Ελέγξτε και αλλάξτε το στυλ SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Σχήμα: SmartArt σχήμα με αλλαγμένο στυλ χρώματος**|

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ανιματώνω το SmartArt ως ένα ενιαίο αντικείμενο;**

Ναι. Το SmartArt είναι σχήμα, επομένως μπορείτε να εφαρμόσετε [τυπικές κινήσεις](/slides/el/python-java/powerpoint-animation/) μέσω του API κινήσεων (εισόδους, εξόδους, έμφαση, διαδρομές κίνησης) όπως και σε άλλα σχήματα.

**Πώς μπορώ να βρω ένα συγκεκριμένο SmartArt σε μια διαφάνεια αν δεν γνωρίζω το εσωτερικό του ID;**

Ορίστε και χρησιμοποιήστε το [εναλλακτικό κείμενο](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#setAlternativeText) και αναζητήστε το σχήμα με αυτήν την τιμή — αυτή είναι μια συνιστώμενη μέθοδος για τον εντοπισμό του στόχου.

**Μπορώ να ομαδοποιήσω το SmartArt με άλλα σχήματα;**

Ναι. Μπορείτε να ομαδοποιήσετε το SmartArt με άλλα σχήματα (εικόνες, πίνακες κ.λπ.) και έπειτα να [χειριστείτε την ομάδα](/slides/el/python-java/group/).

**Πώς θα πάρω εικόνα ενός συγκεκριμένου SmartArt (π.χ. για προεπισκόπηση ή αναφορά);**

Εξάγετε μια μικρογραφία/εικόνα του σχήματος· η βιβλιοθήκη μπορεί να [αποδώσει μεμονωμένα σχήματα](/slides/el/python-java/create-shape-thumbnails/) σε αρχεία raster (PNG/JPG/TIFF).

**Θα διατηρηθεί η εμφάνιση του SmartArt όταν μετατρέψω ολόκληρη την παρουσίαση σε PDF;**

Ναι. Η μηχανή απόδοσης στοχεύει σε υψηλή πιστότητα για την [εξαγωγή PDF](/slides/el/python-java/convert-powerpoint-to-pdf/), με μια σειρά επιλογών ποιότητας και συμβατότητας.