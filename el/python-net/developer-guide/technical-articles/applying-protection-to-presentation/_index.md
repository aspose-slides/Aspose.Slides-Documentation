---
title: Περιορισμός Επεξεργασιών Παρουσίασης με Κλειδώματα Σχημάτων σε Python
linktitle: Περιορισμός Επεξεργασιών Παρουσίασης
type: docs
weight: 70
url: /el/python-net/applying-protection-to-presentation/
keywords:
- αποτροπή επεξεργασιών
- προστασία από επεξεργασία
- κλείδωμα σχήματος
- κλείδωμα θέσης
- κλείδωμα επιλογής
- κλείδωμα αλλαγής μεγέθους
- κλείδωμα ομαδοποίησης
- PowerPoint
- PPTX
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides for Python via .NET για να περιορίσετε την επιλογή, τη μετακίνηση, την αλλαγή μεγέθους και την ομαδοποίηση."
---
## **Ιστορικό**

Μία κοινή χρήση του Aspose.Slides for Python via .NET είναι η δημιουργία, ενημέρωση και αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός αλλαγών στα σχήματα μπορεί να βοηθήσει στη διατήρηση της προβλεπόμενης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόσετε και να αφαιρέσετε κλειδώσεις σχήματος σε μια παρουσίαση PPTX. Αυτά τα κλειδώματα σας επιτρέπουν να περιορίσετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση μιας Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνας, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides for Python via .NET, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που κληρονομεί από την κλάση [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Διαφορετικοί τύποι σχημάτων εκθέτουν διαφορετικές επιλογές κλειδώματος. Η κλάση [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) είναι η βασική κλάση για κλειδώματα σχημάτων. Το Aspose.Slides for Python via .NET παρέχει τις ακόλουθες κλάσεις κλειδώματος:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) κλειδώνει αυτόματα σχήματα.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) κλειδώνει σχήματα συνδέσμων.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) κλειδώνει γραφικά αντικείμενα.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) κλειδώνει ομαδοποιημένα σχήματα.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) κλειδώνει πλαίσια εικόνας.  

Για να εφαρμόσετε κλειδώματα σε όλη τη [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), επαναλάβετε τις διαφάνειες της και ορίστε τα κατάλληλα κλειδώματα σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και Αφαίρεση Προστασίας**

Συμβατά προγράμματα επεξεργασίας παρουσίασης χρησιμοποιούν κλειδώματα σχήματος για να περιορίσουν μεμονωμένες λειτουργίες επεξεργασίας. Η κρυπτογράφηση αρχείων και η προστασία εγγραφής σε επίπεδο εγγράφου είναι ξεχωριστές [presentation protection settings](/slides/el/python-net/password-protected-presentation/).

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for Python via .NET παρέχει την κλάση [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα ορίζει τα [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) και [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) σε `True` για αυτόματα σχήματα, με ισοδύναμα κλειδώματα για ομαδοποιημένα σχήματα, συνδέσμους και πλαίσια εικόνας. Οι σύνδεσμοι χρησιμοποιούν [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) για κίνηση· οι ομάδες επίσης χρησιμοποιούν [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) για περιορισμό ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχημάτων της κάθε διαφάνειας και αποθηκεύει ένα αντίγραφο με τις περιοριστικές ρυθμίσεις εφαρμοσμένες. Σχήματα εκτός των τεσσάρων επεξεργασμένων τύπων παραμένουν αμετάβλητα. Η επανάληψη δεν διασχίζει τα παιδικά σχήματα μέσα σε μια ομάδα.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Αφαίρεση Προστασίας**

Για να αφαιρέσετε ένα κλείδωμα σχήματος, ορίστε την τιμή του σε `False`. Το ακόλουθο παράδειγμα φορτώνει μια παρουσίαση με κλειδώματα σχήματος και αφαιρεί τους περιορισμούς επιλογής, κίνησης και αλλαγής μεγέθους μέσω των [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) και [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Καθαρίζεται επίσης το [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) και αποθηκεύεται ένα αντίγραφο της παρουσίασης. Άλλες ρυθμίσεις κλειδώματος παραμένουν αμετάβλητες.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Διατήρηση Περικοπής Εικόνας**

Τοποθετήστε μια φωτογραφία με όνομα `photo.jpg` στον φάκελο εργασίας. Το παράδειγμα περικόπτει 12 % από τα αριστερά και 8 % από τα δεξιά, στη συνέχεια ορίζει το [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) στο πλαίσιο εικόνας. Αυτή η σημαία περιορίζει περαιτέρω περικοπή και διατηρεί την υπάρχουσα περικοπή.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

Το `PictureLocked.pptx` αποθηκεύει το κλείδωμα περικοπής ως `True`. Στο PowerPoint, η εντολή **Crop** είναι απενεργοποιημένη όταν η φωτογραφία είναι επιλεγμένη.

### **Διατήρηση Διαγράμματος Ομαδοποιημένου**

Το παράδειγμα ομαδοποιεί ένα ορθογώνιο και ένα βέλος, έπειτα ορίζει το [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) στην ίδια την ομάδα για να διατηρήσει τα συστατικά του διαγράμματος μαζί. Άλλες επεξεργασίες, όπως η μετακίνηση της ομάδας ή η αλλαγή γεμίσματος ενός στοιχείου, παραμένουν διαθέσιμες.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

Το `DiagramLocked.pptx` αποθηκεύει το κλείδωμα αποομαδοποίησης ως `True`. Στο PowerPoint, η εντολή **Ungroup** είναι απενεργοποιημένη όταν ολόκληρο το διάγραμμα είναι επιλεγμένο.

### **Αναφορά Υπάρχοντος Κλειδώματος Σχημάτων**

Για να ελέγξετε ένα πρότυπο, ανοίξτε το και διαβάστε το αντικείμενο κλειδώματος για κάθε σχήμα. Το [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) είναι `True` όταν όλες οι σημαίες σε αυτό το αντικείμενο είναι απενεργοποιημένες και `False` όταν τουλάχιστον μία είναι ενεργή. Μια ομάδα και τα παιδικά της στοιχεία έχουν ξεχωριστά αντικείμενα κλειδώματος, γι’ αυτό εξετάστε τα παιδιά ακόμη και όταν η ομάδα δεν έχει κλειδώματα.

Αυτό το παράδειγμα ελέγχει κίνηση για αυτόματα σχήματα, πλαίσια εικόνας και ομάδες, περικοπή για εικόνες και αποομαδοποίηση για ομάδες. Αναφέρει τις σημαίες που αναγνωρίζει και σημειώνει τύπους σχημάτων που δεν εξετάζει.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Υποθέστε ότι η διαφάνεια 1 του `Sample.pptx` περιέχει μια ομάδα με όνομα `Layout` με κλείδωμα αποομαδοποίησης, μια εικόνα με όνομα `Photo` μέσα σε αυτήν με κλείδωμα περικοπής, και ένα μη κλειδωμένο ορθογώνιο με όνομα `Free`. Η αναφορά παραλείπει το `Free` και εκτυπώνει τις δύο παρακάτω γραμμές:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

Η αναφορά διαβάζει τις αποθηκευμένες σημαίες επεξεργασίας σε επίπεδο σχήματος χωρίς να τις αλλάξει ή να αποθηκεύσει την παρουσίαση. Η προστασία εγγραφής σε επίπεδο εγγράφου είναι ξεχωριστή ρύθμιση, και η εφαρμογή κάθε σημαίας εξαρτάται από τον επεξεργαστή.

### **Συμπέρασμα**

Το Aspose.Slides for Python via .NET σας επιτρέπει να περιορίσετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόσετε τις ίδιες περιοριστικές ρυθμίσεις σε όλες τις διαφάνειες. Επιλέξτε τα κλειδώματα που υποστηρίζει κάθε τύπος σχήματος και θέστε τις τιμές τους σε `False` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **ΣΥ.Ρ.Ρ.**

**Μπορώ να συνδυάσω κλειδώματα σχημάτων και προστασία κωδικού σε μία παρουσίαση;**

Ναι. Τα κλειδώματα σχημάτων περιορίζουν συγκεκριμένες λειτουργίες επεξεργασίας, ενώ η [password protection](/slides/el/python-net/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδώματος στις άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Περάστε τη συλλογή [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) της ομάδας και εφαρμόστε τα κατάλληλα κλειδώματα σε κάθε παιδικό σχήμα. Επαναλάβετε τη διαδικασία για τυχόν ένθετες ομάδες, ακολουθώντας τη διαδρομή στο παράδειγμα αναφοράς.