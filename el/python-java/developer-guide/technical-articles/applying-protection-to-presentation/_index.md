---
title: Περιορισμός επεξεργασιών παρουσίασης με κλειδώματα σχήματος σε Python
linktitle: Περιορισμός επεξεργασιών παρουσίασης
type: docs
weight: 60
url: /el/python-java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides for Python via Java για να περιορίσετε την επιλογή, τη κίνηση, την αλλαγή μεγέθους και την ομαδοποίηση."
---
## **Ιστορικό**

Μια κοινή χρήση του Aspose.Slides for Python via Java είναι η δημιουργία, η ενημέρωση και η αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός των αλλαγών στα σχήματα μπορεί να βοηθήσει στη διατήρηση της προβλεπόμενης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόσετε και να αφαιρέσετε τους κλειδώσεις σχήματος σε μια παρουσίαση PPTX. Αυτοί οι κλειδώσεις σας επιτρέπουν να περιορίσετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνας, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για την δημιουργία μιας παρουσίασης. Στο Aspose.Slides for Python via Java, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που κληρονομεί από την κλάση [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) .

Different shape types expose different locking options. The [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) class is the base class for shape locks. Aspose.Slides for Python via Java provides the following lock classes:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) κλειδώνει τα αυτόματα σχήματα.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) κλειδώνει τα σχήματα συνδέσμων.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) κλειδώνει τα γραφικά αντικείμενα.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) κλειδώνει τα ομαδοποιημένα σχήματα.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) κλειδώνει τα πλαίσια εικόνας.  

Για να εφαρμόσετε κλειδώσεις σε ολόκληρη μια [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), επαναλάβετε τις διαφάνειες της και ορίστε τις κατάλληλες κλειδώσεις σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και αφαίρεση προστασίας**

Οι κλειδώσεις σχήματος περιορίζουν λειτουργίες όπως η επιλογή, η μετακίνηση και η αλλαγή μεγέθους των σχημάτων. Δεν κάνουν ολόκληρη την παρουσίαση μη επεξεργάσιμη.

### **Εφαρμογή προστασίας σε σχήματα PPTX**

Το Aspose.Slides for Python via Java παρέχει την κλάση [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα καλεί τις μεθόδους [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) και [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) με `True` για αυτόματα σχήματα, με αντίστοιχες κλειδώσεις για ομαδοποιημένα σχήματα, συνδέσμους και πλαίσια εικόνας. Οι σύνδεσμοι χρησιμοποιούν τη μέθοδο [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) για κίνηση· οι ομάδες χρησιμοποιούν επίσης τη μέθοδο [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) για περιορισμό ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχημάτων κάθε διαφάνειας και αποθηκεύει ένα αντίγραφο με αυτές τις περιοριστικές ρυθμίσεις εφαρμοσμένες. Τα σχήματα εκτός των τεσσάρων επεξεργασμένων τύπων αφήνονται αμετάβλητα. Η επανάληψη δεν διασχίζει τα παιδικά σχήματα μέσα σε μία ομάδα.

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

### **Αφαίρεση προστασίας**

Για να αφαιρέσετε μια κλειδωση σχήματος, ορίστε την τιμή της σε `False`. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση με κλειδώσεις σχήματος και αφαιρεί τους περιορισμούς επιλογής, κίνησης και αλλαγής μεγέθους μέσω των [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) και [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Επίσης αφαιρεί τον περιορισμό ομαδοποίησης περνώντας `False` στη μέθοδο [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) και αποθηκεύει ένα αντίγραφο της παρουσίασης. Οι άλλες ρυθμίσεις κλειδώσεων παραμένουν αμετάβλητες.

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

### **Συμπέρασμα**

Το Aspose.Slides for Python via Java σάς επιτρέπει να περιορίσετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόσετε τις ίδον περιοριστικές ρυθμίσεις σε όλες τις διαφάνειες. Επιλέξτε τις κλειδώσεις που υποστηρίζει κάθε τύπος σχήματος και ορίστε τις τιμές τους σε `False` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **Συχνές ερωτήσεις**

**Μπορώ να συνδυάσω κλειδώματα σχήματος και προστασία με κωδικό σε μία παρουσίαση;**

Ναι. Τα κλειδώματα σχήματος περιορίζουν συγκεκριμένες λειτουργίες επεξεργασίας, ενώ η [password protection](/slides/el/python-java/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδωμάτων στις άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Περιηγηθείτε στη συλλογή που επιστρέφεται από τη μέθοδο [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) της ομάδας και εφαρμόστε τις κατάλληλες κλειδώσεις σε κάθε παιδικό σχήμα. Επαναλάβετε τη διαδικασία για τυχόν εσωτερικές ομάδες. Τα παραπάνω παραδείγματα επεξεργάζονται μόνο τη συλλογή σχημάτων της διαφάνειας, οπότε δεν θέτουν κλειδώσεις σε μεμονωμένα μέλη της ομάδας.