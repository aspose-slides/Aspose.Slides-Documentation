---
title: Αποτροπή επεξεργασιών παρουσίασης με κλειδώματα σχήματος
linktitle: Αποτροπή επεξεργασιών παρουσίασης
type: docs
weight: 60
url: /el/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides for Java κλειδώνει ή ξεκλειδώνει σχήματα σε αρχεία PPT, PPTX και ODP, εξασφαλίζοντας τις παρουσιάσεις ενώ επιτρέπει ελεγχόμενες επεξεργασίες και ταχύτερη διανομή."
---
## **Ιστορικό**

Η κοινή χρήση του Aspose.Slides είναι η δημιουργία, η ενημέρωση και η αποθήκευση παρουσιάσεων Microsoft PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Οι χρήστες εφαρμογών που χρησιμοποιούν το Aspose.Slides με αυτόν τον τρόπο έχουν πρόσβαση στις παραγόμενες παρουσιάσεις, επομένως η προστασία τους από επεξεργασία είναι μια συνήθης ανησυχία. Είναι σημαντικό οι αυτόματα δημιουργημένες παρουσιάσεις να διατηρούν την αρχική μορφοποίηση και το περιεχόμενό τους.

Αυτό το άρθρο εξηγεί πώς δομούνται οι παρουσιάσεις και οι διαφάνειες και πώς το Aspose.Slides for Java μπορεί να εφαρμόσει προστασία σε μια παρουσίαση και στη συνέχεια να την αφαιρέσει. Παρέχει στους προγραμματιστές έναν τρόπο ελέγχου του τρόπου χρήσης των παρουσιάσεων που οι εφαρμογές τους δημιουργούν.

## **Σύνθεση μιας Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, περιοχές εικόνας, περιοχές βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για την κατασκευή μιας παρουσίασης. Στο Aspose.Slides for Java, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) ή κληρονομεί από μια κλάση που το κάνει.

Η δομή του PPTX είναι περίπλοκη, έτσι σε αντίθεση με το PPT, όπου μπορεί να χρησιμοποιηθεί ένα γενικό κλείδωμα για όλους τους τύπους σχημάτων, διαφορετικοί τύποι σχημάτων απαιτούν διαφορετικά κλειδώματα. Η διεπαφή [IBaseShapeLock](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseshapelock/) είναι η γενική κλάση κλειδώματος για το PPTX. Οι ακόλουθοι τύποι κλειδωμάτων υποστηρίζονται στο Aspose.Slides for Java για PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshapelock/) κλειδώνει τα αυτόματα σχήματα.  
- [IConnectorLock](https://reference.aspose.com/slides/el/java/com.aspose.slides/iconnectorlock/) κλειδώνει τα σχήματα συνδέσεων.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/el/java/com.aspose.slides/igraphicalobjectlock/) κλειδώνει τα γραφικά αντικείμενα.  
- [IGroupShapeLock](https://reference.aspose.com/slides/el/java/com.aspose.slides/igroupshapelock/) κλειδώνει τα ομαδοποιημένα σχήματα.  
- [IPictureFrameLock](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframelock/) κλειδώνει τις περιοχές εικόνας.  

Κάθε ενέργεια που εκτελείται σε όλα τα αντικείμενα σχήματος σε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) εφαρμόζεται σε ολόκληρη την παρουσίαση.

## **Εφαρμογή και Αφαίρεση Προστασίας**

Η εφαρμογή προστασίας διασφαλίζει ότι μια παρουσίαση δεν μπορεί να επεξεργαστεί. Είναι μια χρήσιμη τεχνική για την προστασία του περιεχομένου της παρουσίασης.

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for Java παρέχει τη διεπαφή [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) για εργασία με σχήματα σε μια διαφάνεια.

Όπως αναφέρθηκε προηγουμένως, κάθε κλάση σχήματος διαθέτει μια σχετική κλάση κλειδώματος σχήματος για προστασία. Αυτό το άρθρο εστιάζει στα κλειδώματα NoSelect, NoMove και NoResize. Αυτά τα κλειδώματα εξασφαλίζουν ότι τα σχήματα δεν μπορούν να επιλεγούν (μέσω κλικ του ποντικιού ή άλλων μεθόδων επιλογής) και ότι δεν μπορούν να μετακινηθούν ή να αλλάξουν μέγεθος.

Το παρακάτω δείγμα κώδικα εφαρμόζει προστασία σε όλους τους τύπους σχημάτων σε μια παρουσίαση.

```java
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
Presentation presentation = new Presentation("Sample.pptx");

// Διέλευση όλων των διαφανειών στην παρουσίαση.
for (ISlide slide : presentation.getSlides()) {

    // Διέλευση όλων των σχημάτων στη διαφάνεια.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Μετατροπή του σχήματος σε αυτόματο σχήμα και λήψη του κλειδώματος του σχήματος.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Μετατροπή του σχήματος σε ομαδοποιημένο σχήμα και λήψη του κλειδώματος του σχήματος.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Μετατροπή του σχήματος σε σχήμα σύνδεσμου και λήψη του κλειδώματος του σχήματος.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Μετατροπή του σχήματος σε πλαίσιο εικόνας και λήψη του κλειδώματος του σχήματος.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Αποθήκευση του αρχείου παρουσίασης.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Αφαίρεση Προστασίας**

Για να ξεκλειδώσετε ένα σχήμα, ορίστε την τιμή του εφαρμόζουσας κλειδαριάς σε `false`. Το παρακάτω δείγμα κώδικα δείχνει πώς να ξεκλειδώσετε σχήματα σε μια κλειδωμένη παρουσίαση.

```java
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Διέλευση όλων των διαφανειών στην παρουσίαση.
for (ISlide slide : presentation.getSlides()) {

    // Διέλευση όλων των σχημάτων στη διαφάνεια.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Μετατροπή του σχήματος σε αυτόματο σχήμα και λήψη του κλειδώματος του σχήματος.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Μετατροπή του σχήματος σε ομαδοποιημένο σχήμα και λήψη του κλειδώματος του σχήματος.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Μετατροπή του σχήματος σε σχήμα συνδέσμου και λήψη του κλειδώματος του σχήματος.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Μετατροπή του σχήματος σε πλαίσιο εικόνας και λήψη του κλειδώματος του σχήματος.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Αποθήκευση του αρχείου παρουσίασης.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Συμπέρασμα**

Το Aspose.Slides προσφέρει πολλές επιλογές για την προστασία σχημάτων σε μια παρουσίαση. Μπορείτε να κλειδώσετε ένα μεμονωμένο σχήμα ή να διατρέξετε όλα τα σχήματα σε μια παρουσίαση και να κλειδώσετε καθένα για να ασφαλίσετε αποτελεσματικά ολόκληρο το αρχείο. Μπορείτε να αφαιρέσετε την προστασία ορίζοντας την τιμή του κλειδώματος σε `false`.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να συνδυάσω τα κλειδώματα σχήματος και την προστασία με κωδικό σε μια ίδια παρουσίαση;**

Ναι. Τα κλειδώματα περιορίζουν την επεξεργασία των αντικειμένων μέσα στο αρχείο, ενώ η [προστασία με κωδικό](/slides/el/java/password-protected-presentation/) ελέγχει την πρόσβαση στο άνοιγμα και/ή στην αποθήκευση αλλαγών. Αυτοί οι μηχανισμοί συμπληρώνουν ο ένας τον άλλο και λειτουργούν μαζί.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα στα σχήματα των επιλεγμένων διαφανειών· οι υπόλοιπες διαφάνειες θα παραμείνουν επεξεργάσιμες.

**Ισχύουν τα κλειδώματα σχήματος για ομαδοποιημένα αντικείμενα και συνδέσμους;**

Ναι. Υποστηρίζονται ειδικοί τύποι κλειδωμάτων για ομάδες, συνδέσμους, γραφικά αντικείμενα και άλλες κατηγορίες σχήματος.