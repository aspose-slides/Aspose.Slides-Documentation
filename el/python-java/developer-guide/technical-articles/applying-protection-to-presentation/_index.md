---
title: Αποτροπή Επεξεργασίας Παρουσίασης με Κλείδωμα Σχημάτων
linktitle: Αποτροπή Επεξεργασίας Παρουσίασης
type: docs
weight: 60
url: /el/python-java/applying-protection-to-presentation/
keywords:
- αποτροπή επεξεργασιών
- προστασία από επεξεργασία
- κλείδωμα σχήματος
- κλείδωμα θέσης
- κλείδωμα επιλογής
- κλείδωμα μεγέθους
- κλείδωμα ομαδοποίησης
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides for Python via Java κλειδώνει ή ξεκλειδώνει σχήματα σε αρχεία PPT, PPTX και ODP, ασφαλίζοντας τις παρουσιάσεις ενώ επιτρέπει ελεγχόμενες επεμβάσεις και ταχύτερη παράδοση."
---
## **Υπόβαθρο**

Μια συνηθισμένη χρήση του Aspose.Slides είναι η δημιουργία, η ενημέρωση και η αποθήκευση παρουσιάσεων Microsoft PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Οι χρήστες εφαρμογών που χρησιμοποιούν το Aspose.Slides με αυτόν τον τρόπο έχουν πρόσβαση στις παραγόμενες παρουσιάσεις, επομένως η προστασία τους από επεξεργασία αποτελεί κοινή ανησυχία. Είναι σημαντικό οι αυτόματα παραγόμενες παρουσιάσεις να διατηρούν την αρχική μορφοποίηση και το περιεχόμενό τους.

Αυτό το άρθρο εξηγεί πώς είναι δομημένες οι παρουσιάσεις και οι διαφάνειες και πώς το Aspose.Slides for Python via Java μπορεί να εφαρμόσει προστασία σε μια παρουσίαση και αργότερα να την αφαιρέσει. Παρέχει στους προγραμματιστές έναν τρόπο ελέγχου του τρόπου χρήσης των παρουσιάσεων που δημιουργούν οι εφαρμογές τους.

## **Σύνθεση μιας διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνας, πλαίσια βίντεο, συνδετικούς γραφικούς και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides for Python via Java, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που κληρονομεί από την κλάση [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/).

Η δομή του PPTX είναι περίπλοκη, οπότε, σε αντίθεση με το PPT, όπου μπορεί να χρησιμοποιηθεί ένας γενικός κλειδωτής για όλους τους τύπους σχημάτων, διαφορετικοί τύποι σχημάτων απαιτούν διαφορετικούς κλειδωτές. Η κλάση [BaseShapeLock](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseshapelock/) είναι η γενική κλάση κλειδώματος για PPTX. Οι ακόλουθοι τύποι κλειδωτών υποστηρίζονται στο Aspose.Slides for Python via Java για PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/el/python-java/aspose.slides/autoshapelock/) κλειδώνει αυτόματα σχήματα.  
- [ConnectorLock](https://reference.aspose.com/slides/el/python-java/aspose.slides/connectorlock/) κλειδώνει συνδετικά σχήματα.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/el/python-java/aspose.slides/graphicalobjectlock/) κλειδώνει γραφικά αντικείμενα.  
- [GroupShapeLock](https://reference.aspose.com/slides/el/python-java/aspose.slides/groupshapelock/) κλειδώνει ομαδικά σχήματα.  
- [PictureFrameLock](https://reference.aspose.com/slides/el/python-java/aspose.slides/pictureframelock/) κλειδώνει πλαίσια εικόνας.  

Οποιαδήποτε ενέργεια εκτελείται σε όλα τα αντικείμενα σχήματος σε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) εφαρμόζεται σε όλη την παρουσίαση.

## **Εφαρμογή και αφαίρεση προστασίας**

Η εφαρμογή προστασίας εξασφαλίζει ότι μια παρουσίαση δεν μπορεί να επεξεργαστεί. Είναι μια χρήσιμη τεχνική για την προστασία του περιεχομένου της παρουσίασης.

### **Εφαρμογή προστασίας σε σχήματα PPTX**

Το Aspose.Slides for Python via Java παρέχει την κλάση [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/) για εργασία με σχήματα σε μια διαφάνεια.

Όπως αναφέρθηκε παραπάνω, κάθε κλάση σχήματος έχει μια σχετική κλάση κλειδώματος σχήματος για προστασία. Αυτό το άρθρο επικεντρώνεται στα κλειδώματα NoSelect, NoMove και NoResize. Αυτά τα κλειδώματα εξασφαλίζουν ότι τα σχήματα δεν μπορούν να επιλεχθούν (μέσω κλικ του ποντικιού ή άλλων μεθόδων επιλογής) και ότι δεν μπορούν να μετακινηθούν ή να αλλαγούν το μέγεθός τους.

Το παρακάτω παράδειγμα κώδικα εφαρμόζει προστασία σε όλους τους τύπους σχημάτων σε μια παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX.
presentation = Presentation("Sample.pptx")
try:
    # Διασχίστε όλες τις διαφάνειες στην παρουσίαση.
    for slide in presentation.getSlides():
        # Διασχίστε όλα τα σχήματα στη διαφάνεια.
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

    # Αποθήκευση του αρχείου παρουσίασης.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Αφαίρεση προστασίας**

Για να ξεκλειδώσετε ένα σχήμα, ορίστε την τιμή του κλειδωμένου στοιχείου σε `False`. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να ξεκλειδώσετε σχήματα σε μια κλειδωμένη παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Διασχίστε όλες τις διαφάνειες στην παρουσίαση.
    for slide in presentation.getSlides():
        # Διασχίστε όλα τα σχήματα στη διαφάνεια.
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

    # Αποθήκευση του αρχείου παρουσίασης.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συμπέρασμα**

Το Aspose.Slides προσφέρει αρκετές επιλογές για την προστασία σχημάτων σε μια παρουσίαση. Μπορείτε να κλειδώσετε ένα ξεχωριστό σχήμα ή να διασχίσετε όλα τα σχήματα σε μια παρουσίαση και να κλειδώσετε το καθένα για να εξασφαλίσετε αποτελεσματικά ολόκληρο το αρχείο. Μπορείτε να αφαιρέσετε την προστασία ορίζοντας την τιμή του κλειδώματος σε `False`.

## **Συχνές ερωτήσεις**

**Μπορώ να συνδυάσω κλειδώματα σχήματος και προστασία με κωδικό πρόσβασης στην ίδια παρουσίαση;**

Ναι. Τα κλειδώματα περιορίζουν την επεξεργασία αντικειμένων μέσα στο αρχείο, ενώ η [password protection](/slides/el/python-java/password-protected-presentation/) ελέγχει την πρόσβαση στο άνοιγμα και/ή την αποθήκευση αλλαγών. Αυτοί οι μηχανισμοί συμπληρώνουν ο ένας τον άλλο και λειτουργούν από κοινού.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα στα σχήματα των επιλεγμένων διαφανειών· οι υπόλοιπες διαφάνειες θα παραμείνουν επεξεργάσιμες.

**Εφαρμόζονται τα κλειδώματα σχήματος σε ομαδοποιημένα αντικείμενα και συνδέσμους;**

Ναι. Υποστηρίζονται ειδικοί τύποι κλειδ ωμάτων για ομάδες, συνδέσμους, γραφικά αντικείμενα και άλλους τύπους σχημάτων.