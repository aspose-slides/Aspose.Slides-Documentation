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
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides for Python via .NET ώστε να περιορίζετε την επιλογή, τη μετακίνηση, την αλλαγή μεγέθους και την ομαδοποίηση."
---
## **Ιστορικό**

Μια συνηθισμένη χρήση του Aspose.Slides for Python via .NET είναι η δημιουργία, η ενημέρωση και η αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός των αλλαγών στα σχήματα μπορεί να βοηθήσει στη διατήρηση της προοριζόμενης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόσετε και να αφαιρέσετε κλειδώματα σχήματος σε μια παρουσίαση PPTX. Αυτά τα κλειδώματα σας επιτρέπουν να περιορίσετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση μιας διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνων, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides for Python via .NET, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που κληρονομεί από την κλάση [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Διαφορετικοί τύποι σχημάτων εκθέτουν διαφορετικές επιλογές κλειδωμάτων. Η κλάση [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) είναι η βασική κλάση για τα κλειδώματα σχημάτων. Το Aspose.Slides for Python via .NET παρέχει τις ακόλουθες κλάσεις κλειδωμάτων:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) κλειδώνει αυτόματα σχήματα.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) κλειδώνει σχήματα συνδέσμων.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) κλειδώνει γραφικά αντικείμενα.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) κλειδώνει ομαδοποιημένα σχήματα.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) κλειδώνει πλαίσια εικόνων.  

Για να εφαρμόσετε κλειδώματα σε όλη τη [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), περάστε από τις διαφάνειες της και ορίστε τα κατάλληλα κλειδώματα σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και αφαίρεση προστασίας**

Τα κλειδώματα σχήματος περιορίζουν λειτουργίες όπως η επιλογή, η μετακίνηση και η αλλαγή μεγέθους των σχημάτων. Δεν κάνουν ολόκληρη την παρουσίαση μη επεξεργάσιμη.

### **Εφαρμογή προστασίας σε σχήματα PPTX**

Το Aspose.Slides for Python via .NET παρέχει την κλάση [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα ορίζει τα [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), και [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) σε `True` για αυτόματα σχήματα, με ισοδύναμα κλειδώματα για ομαδοποιημένα σχήματα, συνδέσμους και πλαίσια εικόνων. Οι σύνδεσμοι χρησιμοποιούν το [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) για κίνηση· οι ομάδες επίσης χρησιμοποιούν το [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) για περιορισμό της ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχημάτων κάθε διαφάνειας και αποθηκεύει ένα αντίγραφο με αυτές τις περιορισμούς εφαρμοσμένους. Τα σχήματα εκτός των τεσσάρων επεξεργασμένων τύπων παραμένουν αμετάβλητα. Η βρόχος δεν διατρέχει τα παιδικά σχήματα μέσα σε μια ομάδα.

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

### **Αφαίρεση προστασίας**

Για να αφαιρέσετε ένα κλείδωμα σχήματος, ορίστε την τιμή του σε `False`. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση με κλειδώματα σχήματος και καθαρίζει τις περιορισμούς επιλογής, μετακίνησης και αλλαγής μεγέθους μέσω των [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), και [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Επίσης αφαιρεί το [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) και αποθηκεύει ένα αντίγραφο της παρουσίασης. Οι άλλες ρυθμίσεις κλειδωμάτων παραμένουν αμετάβλητες.

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

### **Συμπέρασμα**

Το Aspose.Slides for Python via .NET σας επιτρέπει να περιορίσετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόσετε τους ίδιους περιορισμούς σε όλες τις διαφάνειες. Επιλέξτε τα κλειδώματα που υποστηρίζονται από κάθε τύπο σχήματος και ορίστε τις τιμές τους σε `False` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **Συχνές Ερωτήσεις**

**Μπορώ να συνδυάσω κλειδώματα σχήματος και προστασία με κωδικό σε μια ίδια παρουσίαση;**

Ναι. Τα κλειδώματα σχήματος περιορίζουν συγκεκριμένες λειτουργίες επεξεργασίας, ενώ η [προστασία με κωδικό](/slides/el/python-net/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδωμάτων στις άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Διασχίστε τη συλλογή [σχήματα](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) της ομάδας και εφαρμόστε τα κατάλληλα κλειδώματα σε κάθε παιδικό σχήμα. Επαναλάβετε αυτό για τυχόν ενσωματωμένες ομάδες. Τα παραπάνω παραδείγματα επεξεργάζονται μόνο τη συλλογή σχημάτων της διαφάνειας, επομένως δεν ορίζουν κλειδώματα σε μεμονωμένα μέλη της ομάδας.