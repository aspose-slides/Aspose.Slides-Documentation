---
title: Αποτροπή Επεξεργασίας Παρουσιάσεων με Κλειδώματα Σχημάτων στην Python
linktitle: Αποτροπή Επεξεργασίας Παρουσιάσεων
type: docs
weight: 70
url: /el/python-net/applying-protection-to-presentation/
keywords:
- αποτροπή επεξεργασίας
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
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides for Python μέσω .NET κλειδώνει ή ξεκλειδώνει σχήματα σε αρχεία PPT, PPTX και ODP, εξασφαλίζοντας τις παρουσιάσεις ενώ επιτρέπει ελεγχόμενες επεμβάσεις και ταχύτερη παράδοση."
---
## **Ιστορικό**

Μια κοινή χρήση του Aspose.Slides είναι η δημιουργία, η ενημέρωση και η αποθήκευση παρουσιάσεων Microsoft PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Οι χρήστες εφαρμογών που χρησιμοποιούν το Aspose.Slides με αυτόν τον τρόπο έχουν πρόσβαση στις παραγόμενες παρουσιάσεις, οπότε η προστασία τους από τροποποίηση αποτελεί συχνή ανησυχία. Είναι σημαντικό οι αυτόματα δημιουργημένες παρουσιάσεις να διατηρούν την αρχική μορφοποίηση και το περιεχόμενό τους.

Αυτό το άρθρο εξηγεί πώς δομούνται οι παρουσιάσεις και οι διαφάνειες και πώς το Aspose.Slides for Python μπορεί να εφαρμόσει προστασία σε μια παρουσίαση και στη συνέχεια να την αφαιρέσει. Παρέχει στους προγραμματιστές έναν τρόπο ελέγχου του πώς χρησιμοποιούνται οι παρουσιάσεις που δημιουργούν οι εφαρμογές τους.

## **Σύνθεση μιας Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνας, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides for Python, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που κληρονομεί την κλάση [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) .

Η δομή του PPTX είναι πολύπλοκη, οπότε, σε αντίθεση με το PPT, όπου μπορεί να χρησιμοποιηθεί ένας γενικός κλειδώματος για όλα τα είδη σχημάτων, διαφορετικοί τύποι σχημάτων απαιτούν διαφορετικά κλειδώματα. Η κλάση [BaseShapeLock](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseshapelock/) είναι η γενική κλάση κλειδώματος για το PPTX. Οι ακόλουθοι τύποι κλειδωμάτων υποστηρίζονται στο Aspose.Slides for Python για PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/el/python-net/aspose.slides/autoshapelock/) κλειδώνει τα αυτόματα σχήματα.  
- [ConnectorLock](https://reference.aspose.com/slides/el/python-net/aspose.slides/connectorlock/) κλειδώνει τα σχήματα συνδέσμων.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/el/python-net/aspose.slides/graphicalobjectlock/) κλειδώνει τα γραφικά αντικείμενα.  
- [GroupShapeLock](https://reference.aspose.com/slides/el/python-net/aspose.slides/groupshapelock/) κλειδώνει τα ομαδοποιημένα σχήματα.  
- [PictureFrameLock](https://reference.aspose.com/slides/el/python-net/aspose.slides/pictureframelock/) κλειδώνει τα πλαίσια εικόνας.  

Οποιαδήποτε ενέργεια εκτελείται σε όλα τα αντικείμενα σχήματος σε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) εφαρμόζεται σε ολόκληρη την παρουσίαση.

## **Εφαρμογή και Αφαίρεση Προστασίας**

Η εφαρμογή προστασίας εξασφαλίζει ότι μια παρουσίαση δεν μπορεί να επεξεργαστεί. Είναι μια χρήσιμη τεχνική για την προστασία του περιεχομένου της παρουσίασης.

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for Python παρέχει την κλάση [Shape](https://reference.aspose.com/slides/el/python-net/aspose.slides/shape/) για εργασία με σχήματα σε μια διαφάνεια.

Όπως αναφέρθηκε νωρίτερα, κάθε κλάση σχήματος έχει μια συσχετισμένη κλάση κλειδώματος σχήματος για προστασία. Αυτό το άρθρο εστιάζει στα κλειδώματα NoSelect, NoMove και NoResize. Αυτά τα κλειδώματα εξασφαλίζουν ότι τα σχήματα δεν μπορούν να επιλεγούν (μέσω κλικ του ποντικιού ή άλλων μεθόδων επιλογής) και ότι δεν μπορούν να μετακινηθούν ή να αλλάξουν μέγεθος.

Το παρακάτω δείγμα κώδικα εφαρμόζει προστασία σε όλους τους τύπους σχημάτων σε μια παρουσίαση.

```py
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation("Sample.pptx") as presentation:
    # Διαπέρνατε όλες τις διαφάνειες της παρουσίασης.
    for slide in presentation.slides:
        # Διαπέρνατε όλα τα σχήματα στη διαφάνεια.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Αποθήκευση του αρχείου παρουσίασης.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Αφαίρεση Προστασίας**

Για να ξεκλειδώσετε ένα σχήμα, ορίστε την τιμή του εφαρμοσμένου κλειδώματος σε `False`. Το παρακάτω δείγμα κώδικα δείχνει πώς να ξεκλειδώσετε σχήματα σε μια κλειδωμένη παρουσίαση.

```py
import aspose.slides as slides

# Δημιουργήστε το αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Διαπέρνατε όλες τις διαφάνειες της παρουσίασης.
    for slide in presentation.slides:
        # Διαπέρνατε όλα τα σχήματα στη διαφάνεια.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Αποθήκευση του αρχείου παρουσίασης.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Συμπέρασμα**

Το Aspose.Slides προσφέρει αρκετές επιλογές για την προστασία σχημάτων σε μια παρουσίαση. Μπορείτε να κλειδώσετε ένα μεμονωμένο σχήμα ή να περάσετε από όλα τα σχήματα σε μια παρουσίαση και να κλειδώσετε καθένα ξεχωριστά για να ασφαλίσετε αποτελεσματικά ολόκληρο το αρχείο. Μπορείτε να αφαιρέσετε την προστασία ορίζοντας την τιμή του κλειδώματος σε `False`.

## **Συχνές Ερωτήσεις**

**Μπορώ να συνδυάσω κλειδώματα σχήματος και προστασία με κωδικό σε μία και την ίδια παρουσίαση;**

Ναι. Τα κλειδώματα περιορίζουν την επεξεργασία αντικειμένων μέσα στο αρχείο, ενώ η [password protection](/slides/el/python-net/password-protected-presentation/) ελέγχει την πρόσβαση στο άνοιγμα και/ή την αποθήκευση αλλαγών. Αυτοί οι μηχανισμοί συμπληρώνουν ο ένας τον άλλο και λειτουργούν μαζί.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα στα σχήματα των επιλεγμένων διαφανειών· οι υπόλοιπες διαφάνειες θα παραμείνουν επεξεργάσιμες.

**Ισχύουν τα κλειδώματα σχήματος για ομαδοποιημένα αντικείμενα και συνδέσμους;**

Ναι. Υποστηρίζονται ειδικοί τύποι κλειδωμάτων για ομάδες, συνδέσμους, γραφικά αντικείμενα και άλλους τύπους σχημάτων.