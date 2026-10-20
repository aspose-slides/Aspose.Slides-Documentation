---
title: Περιορισμός Επεξεργασιών Παρουσίασης με Κλείδωμα Σχημάτων σε PHP
linktitle: Περιορισμός Επεξεργασιών Παρουσίασης
type: docs
weight: 60
url: /el/php-java/applying-protection-to-presentation/
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
- PHP
- Aspose.Slides
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides for PHP via Java για να περιορίσετε την επιλογή, την κίνηση, την αλλαγή μεγέθους και την ομαδοποίηση."
---
## **Επισκόπηση**

Μια κοινή χρήση του Aspose.Slides for PHP via Java είναι η δημιουργία, ενημέρωση και αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός αλλαγών στα σχήματα μπορεί να βοηθήσει στη διατήρηση της προοριζόμενης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόσετε και να αφαιρέσετε κλειδώματα σχήματος σε παρουσίαση PPTX. Αυτά τα κλειδώματα σας επιτρέπουν να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από συστατικά όπως αυτοσχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνων, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides for PHP via Java, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που κληρονομεί από την κλάση [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Διαφορετικοί τύποι σχημάτων εκθέτουν διαφορετικές επιλογές κλείδωσης. Η κλάση [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) είναι η βασική κλάση για τα κλειδώματα σχημάτων. Το Aspose.Slides for PHP via Java παρέχει τις ακόλουθες κλάσεις κλειδώματος:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) κλειδώνει τα αυτοσχήματα.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) κλειδώνει τα σχήματα συνδέσμων.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) κλειδώνει τα γραφικά αντικείμενα.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) κλειδώνει τα ομαδοποιημένα σχήματα.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) κλειδώνει τα πλαίσια εικόνων.  

Για να εφαρμόσετε κλειδώματα σε όλη τη [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), επαναλάβετε τις διαφάνειες της και ορίστε τα κατάλληλα κλειδώματα σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και αφαίρεση προστασίας**

Τα κλειδώματα σχημάτων περιορίζουν λειτουργίες όπως η επιλογή, η μετακίνηση και η αλλαγή μεγέθους των σχημάτων. Δεν κάνουν ολόκληρη την παρουσίαση μη επεξεργάσιμη.

### **Εφαρμογή προστασίας σε σχήματα PPTX**

Το Aspose.Slides for PHP via Java παρέχει την κλάση [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα καλεί τις μεθόδους [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) και [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) με `true` για τα αυτοσχήματα, με ισοδύναμα κλειδώματα για ομαδοποιημένα σχήματα, συνδέσμους και πλαίσια εικόνων. Οι σύνδεσμοι χρησιμοποιούν [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) για κίνηση· οι ομάδες επίσης χρησιμοποιούν [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) για περιορισμό ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχημάτων κάθε διαφάνειας και αποθηκεύει ένα αντίγραφο με αυτές τις περιοριστικές ρυθμίσεις ενεργοποιημένες. Σχήματα εκτός των τεσσάρων τύπων που διαχειρίζονται αφήνονται αμετάβλητα. Ο βρόχος δεν διασχίζει τα παιδικά σχήματα μέσα σε μια ομάδα.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Αφαίρεση προστασίας**

Για να αφαιρέσετε ένα κλείδωμα σχήματος, ορίστε την τιμή του σε `false`. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση με κλειδώματα σχημάτων και αφαιρεί τους περιορισμούς επιλογής, κίνησης και αλλαγής μεγέθους μέσω των [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) και [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Αφαιρεί επίσης τον περιορισμό ομαδοποίησης περνώντας `false` στη μέθοδο [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) και αποθηκεύει ένα αντίγραφο της παρουσίασης. Οι άλλες ρυθμίσεις κλειδωμάτων παραμένουν αμετάβλητες.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Συμπέρασμα**

Το Aspose.Slides for PHP via Java σας επιτρέπει να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόζετε τους ίδιους περιορισμούς σε όλες τις διαφάνειες. Επιλέξτε τα κλειδώματα που υποστηρίζονται από κάθε τύπο σχήματος και ορίστε τις τιμές τους σε `false` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να συνδυάσω κλειδώματα σχήματος και προστασία με κωδικό σε ίδια παρουσίαση;**

Ναι. Τα κλειδώματα σχήματος περιορίζουν συγκεκριμένες λειτουργίες επεξεργασίας, ενώ η [password protection](/slides/el/php-java/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδώματος στις άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Περιηγηθείτε στη συλλογή που επιστρέφει η μέθοδος [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) της ομάδας και εφαρμόστε τα κατάλληλα κλειδώματα σε κάθε παιδικό σχήμα. Επαναλάβετε τη διαδικασία για τυχόν ένθετες ομάδες. Τα παραπάνω παραδείγματα επεξεργάζονται μόνο τη συλλογή σχημάτων της διαφάνειας, επομένως δεν ορίζουν κλειδώματα σε μεμονωμένα μέλη της ομάδας.