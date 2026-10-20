---
title: Περιορισμός Επεξεργασιών Παρουσίασης με Κλειδώματα Σχημάτων σε Java
linktitle: Περιορισμός Επεξεργασιών Παρουσίασης
type: docs
weight: 60
url: /el/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides for Java για να περιορίσετε την επιλογή, την κίνηση, την αλλαγή μεγέθους και την ομαδοποίηση."
---
## **Ιστορικό**

Μια κοινή χρήση του Aspose.Slides for Java είναι η δημιουργία, η ενημέρωση και η αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός των αλλαγών στα σχήματα μπορεί να βοηθήσει στη διατήρηση της προγραμματισμένης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόσετε και να αφαιρέσετε κλειδώματα σχήματος σε μια παρουσίαση PPTX. Αυτά τα κλειδώματα σας επιτρέπουν να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση μιας Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνων, πλαίσια βίντεο, συνδέσμους, και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides for Java, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) ή κληρονομεί από μια κλάση που το κάνει.

Διαφορετικοί τύποι σχημάτων εκθέτουν διαφορετικές επιλογές κλειδαριάς. Η διεπαφή [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) είναι η βασική διεπαφή για κλειδώματα σχήματος. Το Aspose.Slides for Java παρέχει τις ακόλουθες διεπαφές κλειδωμάτων:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) κλειδώνει αυτόματα σχήματα.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) κλειδώνει σχήματα συνδέσμων.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) κλειδώνει γραφικά αντικείμενα.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) κλειδώνει ομαδικά σχήματα.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) κλειδώνει πλαίσια εικόνας.  

Για να εφαρμόσετε κλειδώματα σε όλη τη [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), επαναλάβετε τις διαφάνειες της και ορίστε τα κατάλληλα κλειδώματα σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και Απομάκρυνση Προστασίας**

Τα κλειδώματα σχήματος περιορίζουν λειτουργίες όπως η επιλογή, η μετακίνηση και η αλλαγή μεγέθους των σχημάτων. Δεν κάνουν ολόκληρη την παρουσίαση μη επεξεργάσιμη.

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for Java παρέχει τη διεπαφή [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα καλεί τις [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), και [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) με `true` για αυτόματα σχήματα, με αντίστοιχα κλειδώματα για ομαδικά σχήματα, συνδέσμους και πλαίσια εικόνας. Οι σύνδεσμοι χρησιμοποιούν την [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) για κίνηση· οι ομάδες χρησιμοποιούν επίσης την [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) για περιορισμό ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχημάτων κάθε διαφάνειας και αποθηκεύει ένα αντίγραφο με εφαρμοσμένους αυτούς τους περιορισμούς. Τα σχήματα εκτός των τεσσάρων επεξεργαζόμενων τύπων παραμένουν αμετάβλητα. Η επανάληψη δεν διασχίζει τα παιδικά σχήματα εντός μιας ομάδας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Αφαίρεση Προστασίας**

Για να αφαιρέσετε ένα κλείδωμα σχήματος, ορίστε την τιμή του σε `false`. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση με κλειδώματα σχημάτων και καθαρίζει τους περιορισμούς επιλογής, κίνησης και αλλαγής μεγέθους μέσω των [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), και [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Αφαιρεί επίσης τον περιορισμό ομαδοποίησης περνώντας `false` στη [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) και αποθηκεύει ένα αντίγραφο της παρουσίασης. Οι άλλες ρυθμίσεις κλειδωμάτων παραμένουν αμετάβλητες.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Συμπέρασμα**

Το Aspose.Slides for Java σας επιτρέπει να περιορίσετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόσετε τους ίδιους περιορισμούς σε όλες τις διαφάνειες. Επιλέξτε τα κλειδώματα που υποστηρίζονται από κάθε τύπο σχήματος και ορίστε τις τιμές τους σε `false` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **FAQ**

**Μπορώ να συνδυάσω κλειδώματα σχήματος και προστασία με κωδικό στην ίδια παρουσίαση;**

Ναι. Τα κλειδώματα σχήματος περιορίζουν συγκεκριμένες λειτουργίες επεξεργασίας, ενώ η [προστασία με κωδικό](/slides/el/java/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδώματος σε άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Περιηγηθείτε στη συλλογή που επιστρέφει η μέθοδος [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) της ομάδας και εφαρμόστε τα κατάλληλα κλειδώματα σε κάθε παιδικό σχήμα. Επαναλάβετε αυτό για οποιεσδήποτε ενσωματωμένες ομάδες. Τα παραπάνω παραδείγματα επεξεργάζονται μόνο τη συλλογή σχημάτων της διαφάνειας, επομένως δεν θέτουν κλειδώματα σε μεμονωμένα μέλη της ομάδας.