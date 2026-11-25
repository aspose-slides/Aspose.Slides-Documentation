---
title: Περιορισμός επεξεργασιών παρουσίασης με κλειδώματα σχημάτων σε Python
linktitle: Περιορισμός επεξεργασιών παρουσίασης
type: docs
weight: 60
url: /el/python-java/applying-protection-to-presentation/
keywords:
- αποτροπή επεξεργασιών
- προστασία από την επεξεργασία
- κλείδωμα σχήματος
- κλείδωμα θέσης
- κλείδωμα επιλογής
- κλείδωμα αλλαγής μεγέθους
- κλείδωμα ομαδοποίησης
- PowerPoint
- PPTX
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides for Python via Java για να περιορίσετε την επιλογή, τη μετακίνηση, την αλλαγή μεγέθους και την ομαδοποίηση."
---
## **Ιστορικό**

Μια κοινή χρήση του Aspose.Slides for Python via Java είναι η δημιουργία, η ενημέρωση και η αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός των αλλαγών στα σχήματα μπορεί να βοηθήσει στη διατήρηση της προοριζόμενης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόζετε και να αφαιρείτε κλειδώματα σχήματος σε μια παρουσίαση PPTX. Αυτά τα κλειδώματα σας επιτρέπουν να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε ατομικά σχήματα.

## **Σύνθεση μιας διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνων, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides for Python via Java, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που κληρονομεί από την κλάση [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/).

Διαφορετικοί τύποι σχημάτων εκθέτουν διαφορετικές επιλογές κλειδώματος. Η κλάση [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) είναι η βασική κλάση για κλειδώματα σχημάτων. Το Aspose.Slides for Python via Java παρέχει τις ακόλουθες κλάσεις κλειδωμάτων:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) κλειδώνει αυτόματα σχήματα.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) κλειδώνει σχήματα συνδέσμων.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) κλειδώνει γραφικά αντικείμενα.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) κλειδώνει ομαδοποιημένα σχήματα.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) κλειδώνει πλαίσια εικόνων.  

Για να εφαρμόσετε κλειδώματα σε ένα [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), διατρέξτε τις διαφάνειές του και ορίστε τα κατάλληλα κλειδώματα σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και κατάργηση προστασίας**

Συμβατά επεξεργαστικά παρουσίασης χρησιμοποιούν κλειδώματα σχημάτων για να περιορίσουν ατομικές λειτουργίες επεξεργασίας. Η κρυπτογράφηση αρχείων και η προστασία εγγράφου σε επίπεδο εγγραφής είναι ξεχωριστές [presentation protection settings](/slides/el/python-java/password-protected-presentation/).

### **Εφαρμογή προστασίας σε σχήματα PPTX**

Το Aspose.Slides for Python via Java παρέχει την κλάση [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα καλεί την [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) και [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) με `True` για αυτόματα σχήματα, με ισοδύναμα κλειδώματα για ομαδοποιημένα σχήματα, συνδέσμους και πλαίσια εικόνων. Οι σύνδεσμοι χρησιμοποιούν την [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) για κίνηση· οι ομάδες επίσης χρησιμοποιούν την [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) για περιορισμό ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχημάτων της κάθε διαφάνειας και αποθηκεύει αντίγραφο με αυτές τις περιορισμούς εφαρμοσμένους. Σχήματα εκτός των τεσσάρων επεξεργαζόμενων τύπων αφήνονται αμετάβλητα. Ο βρόχος δεν διασχίζει τα παιδικά σχήματα μέσα σε μια ομάδα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Κατάργηση προστασίας**

Για να καταργήσετε ένα κλείδωμα σχήματος, ορίστε την τιμή του σε `False`. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση με κλειδώματα σχήματος και αφαιρεί τους περιορισμούς επιλογής, κίνησης και αλλαγής μεγέθους μέσω [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) και [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Αφαιρεί επίσης τον περιορισμό ομαδοποίησης περνώντας `False` στην [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) και αποθηκεύει αντίγραφο της παρουσίασης. Άλλες ρυθμίσεις κλειδώματος παραμένουν αμετάβλητες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Διατήρηση περικοπής εικόνας**

Τοποθετήστε μια φωτογραφία με όνομα `photo.jpg` στον τρέχοντα φάκελο. Το παράδειγμα περικόπτει 12 % από αριστερά και 8 % από δεξιά, έπειτα καλεί το [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) με `True` για να διατηρήσει την περικοπή.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Στο `PictureLocked.pptx`, το PowerPoint απενεργοποιεί την εντολή **Crop** όταν επιλέγετε τη φωτογραφία.

### **Διατήρηση ομάδας διαγράμματος**

Το παράδειγμα ομαδοποιεί ένα ορθογώνιο και ένα βέλος, έπειτα καλεί το [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) με `True` για να διατηρηθούν τα δύο σχήματα μαζί. Μπορείτε ακόμα να μετακινήσετε την ομάδα ή να αλλάξετε το γέμισμα ενός στοιχείου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Στο `DiagramLocked.pptx`, το PowerPoint απενεργοποιεί την εντολή **Ungroup** όταν επιλέγετε ολόκληρο το διάγραμμα.

### **Αναφορά υπαρχόντων κλειδωμάτων σχήματος**

Για να εξετάσετε ένα πρότυπο, ανοίξτε το και διαβάστε το αντικείμενο κλειδώματος για κάθε σχήμα. Η μέθοδος [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) επιστρέφει `True` όταν όλα τα σημαίες σε αυτό το αντικείμενο είναι απενεργοποιημένα και `False` όταν τουλάχιστον ένα είναι ενεργό. Μια ομάδα και τα παιδιά της έχουν ξεχωριστά αντικείμενα κλειδωμάτων, επομένως εξετάστε τα παιδιά ακόμη και όταν η ομάδα δεν έχει κλειδώματα.

Αυτό το παράδειγμα ελέγχει κίνηση για αυτόματα σχήματα, πλαίσια εικόνων και ομάδες. Ελέγχει επίσης την περικοπή για εικόνες και το ξε-ομαδοποιήση για ομάδες. Η αναφορά καταχωρεί τις ενεργοποιημένες σημαίες που αναγνωρίζει και σημειώνει τύπους σχημάτων που δεν εξετάζει.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Υποθέστε ότι η διαφάνεια 1 του `Sample.pptx` περιέχει μια ομάδα με όνομα `Layout` με κλειδωμένο το ξε-ομαδοποιήση, μια εικόνα με όνομα `Photo` μέσα στην ομάδα με κλειδωμένη την περικοπή, και ένα αξελείωτο ορθογώνιο με όνομα `Free`. Η αναφορά παραλείπει το `Free` και εκτυπώνει τις δύο αυτές γραμμές:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Η αναφορά διαβάζει τις αποθηκευμένες σημαίες επεξεργασίας σε επίπεδο σχήματος χωρίς να τις αλλάξει ή να αποθηκεύσει την παρουσίαση. Η προστασία εγγράφου σε επίπεδο εγγραφής είναι ξεχωριστή ρύθμιση, και η εφαρμογή κάθε σημαίας εξαρτάται από τον επεξεργαστή.

### **Συμπέρασμα**

Το Aspose.Slides for Python via Java σας επιτρέπει να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε ατομικά σχήματα ή να εφαρμόζετε τις ίδιες περιορισμούς σε όλες τις διαφάνειες. Επιλέξτε τα κλειδώματα που υποστηρίζονται από κάθε τύπο σχήματος και ορίστε τις τιμές τους σε `False` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να συνδυάσω τα κλειδώματα σχημάτων και την προστασία με κωδικό σε μία παρουσίαση;**

Ναι. Τα κλειδώματα σχημάτων περιορίζουν συγκεκριμένες λειτουργίες επεξεργασίας, ενώ η [password protection](/slides/el/python-java/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο σε σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδώματος στις άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε ατομικά σχήματα μέσα σε μια ομάδα;**

Διατρέξτε τη συλλογή που επιστρέφει η μέθοδος [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) της ομάδας και εφαρμόστε τα κατάλληλα κλειδώματα σε κάθε παιδικό σχήμα. Επαναλάβετε αυτή τη διαδικασία για τυχόν ενσωματωμένες ομάδες, ακολουθώντας τη διάσχιση στο παράδειγμα αναφοράς.