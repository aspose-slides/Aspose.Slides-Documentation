---
title: Περιορισμός Επεξεργασιών Παρουσίασης με Κλείδωμα Σχημάτων σε Node.js
linktitle: Περιορισμός Επεξεργασιών Παρουσίασης
type: docs
weight: 60
url: /el/nodejs-java/applying-protection-to-presentation/
keywords:
- αποτροπή επεξεργασίας
- προστασία από επεξεργασία
- κλείδωμα σχήματος
- κλείδωμα θέσης
- κλείδωμα επιλογής
- κλείδωμα αλλαγής μεγέθους
- κλείδωμα ομαδοποίησης
- PowerPoint
- PPTX
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides for Node.js via Java, ώστε να περιορίζετε την επιλογή, κίνηση, αλλαγή μεγέθους και ομαδοποίηση."
---
## **Επισκόπηση**

Μια συχνή χρήση του Aspose.Slides for Node.js via Java είναι η δημιουργία, η ενημέρωση και η αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός των αλλαγών σε σχήματα μπορεί να βοηθήσει στη διατήρηση της προγραμματισμένης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόσετε και να αφαιρέσετε κλειδώματα σχήματος σε μια παρουσίαση PPTX. Αυτά τα κλειδώματα σας επιτρέπουν να περιορίσετε συγκεκριμένες ενέργειες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνων, πλαίσια βίντεο, συνδέτες και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides for Node.js via Java, κάθε στοιχείο σε μια διαφάνεια αναπαριστάται από ένα αντικείμενο που κληρονομεί από την κλάση [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

Διάφοροι τύποι σχημάτων εκθέτουν διαφορετικές επιλογές κλειδωμάτων. Η κλάση [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) είναι η βασική κλάση για τα κλειδώματα σχημάτων. Το Aspose.Slides for Node.js via Java παρέχει τις ακόλουθες κλάσεις κλειδωμάτων:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) κλειδώνει αυτόματα σχήματα.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) κλειδώνει σχήματα συνδέσμων.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) κλειδώνει γραφικά αντικείμενα.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) κλειδώνει ομαδοποιημένα σχήματα.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) κλειδώνει πλαίσια εικόνων.  

Για να εφαρμόσετε κλειδώματα σε όλη την [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), επαναλάβετε τις διαφάνειες της και ορίστε τα κατάλληλα κλειδώματα σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και Κατάργηση Προστασίας**

Τα κλειδώματα σχημάτων περιορίζουν ενέργειες όπως η επιλογή, η μετακίνηση και η αλλαγή μεγέθους των σχημάτων. Δεν κάνουν ολόκληρη την παρουσίαση μη επεξεργάσιμη.

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for Node.js via Java παρέχει την κλάση [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα καλεί τις μεθόδους [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) και [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) με τιμή `true` για αυτόματα σχήματα, με ισοδύναμα κλειδώματα για ομαδοποιημένα σχήματα, συνδέτες και πλαίσια εικόνων. Οι σύνδεσμοι χρησιμοποιούν τη μέθοδο [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) για κίνηση· οι ομάδες επίσης χρησιμοποιούν τη μέθοδο [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) για περιορισμό ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχημάτων κάθε διαφάνειας και αποθηκεύει ένα αντίγραφο με τις περιοριστικές ρυθμίσεις εφαρμόσες. Σχήματα εκτός των τεσσάρων χειρισιζόμενων τύπων παραμένουν αμετάβλητα. Ο βρόχος δεν διασχίζει τα παιδικά σχήματα μέσα σε μια ομάδα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Κατάργηση Προστασίας**

Για να αφαιρέσετε ένα κλείδωμα σχήματος, ορίστε την τιμή του σε `false`. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση με κλειδώματα σχημάτων και αφαιρεί τους περιορισμούς επιλογής, κίνησης και αλλαγής μεγέθους μέσω των [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) και [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Επίσης αφαιρεί τον περιορισμό ομαδοποίησης περνώντας `false` στη μέθοδο [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) και αποθηκεύει ένα αντίγραφο της παρουσίασης. Οι άλλες ρυθμίσεις κλειδωμάτων παραμένουν αμετάβλητες.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Συμπέρασμα**

Το Aspose.Slides for Node.js via Java σας επιτρέπει να περιορίσετε συγκεκριμένες ενέργειες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόσετε τους ίδιους περιορισμούς σε όλες τις διαφάνειες. Επιλέξτε τα κλειδώματα που υποστηρίζει κάθε τύπος σχήματος και ορίστε τις τιμές τους σε `false` όταν χρειάζεται να αφαιρέσετε τους περιορισμούς.

## **Συχνές Ερωτήσεις**

**Μπορώ να συνδυάσω τα κλειδώματα σχήματος και την προστασία με κωδικό στην ίδια παρουσίαση;**

Ναι. Τα κλειδώματα σχήματος περιορίζουν συγκεκριμένες ενέργειες επεξεργασίας, ενώ η [προστασία με κωδικό](/slides/el/nodejs-java/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδωμάτων στις άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Περιηγηθείτε στη συλλογή που επιστρέφεται από τη μέθοδο [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) της ομάδας και εφαρμόστε τα κατάλληλα κλειδώματα σε κάθε παιδικό σχήμα. Επαναλάβετε τη διαδικασία για τυχόν ένθετες ομάδες. Τα παραπάνω παραδείγματα επεξεργάζονται μόνο τη συλλογή σχημάτων της διαφάνειας, έτσι δεν ορίζουν κλειδώματα σε μεμονωμένα μέλη της ομάδας.