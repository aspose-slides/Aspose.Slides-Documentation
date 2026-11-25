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
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides for Java ώστε να περιορίζετε την επιλογή, τη μετακίνηση, την αλλαγή μεγέθους και την ομαδοποίηση."
---
## **Ιστορικό**

Μία κοινή χρήση του Aspose.Slides for Java είναι η δημιουργία, ενημέρωση και αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός των αλλαγών σε σχήματα μπορεί να βοηθήσει στη διατήρηση της προγραμματισμένης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόσετε και να αφαιρέσετε κλειδώματα σχήματος σε μια παρουσίαση PPTX. Αυτά τα κλειδώματα σάς επιτρέπουν να περιορίσετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση μιας Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνας, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για την κατασκευή μιας παρουσίασης. Στο Aspose.Slides for Java, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που υλοποιεί τη διεπαφή [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) ή κληρονομείται από μια κλάση που το κάνει.

Διαφορετικοί τύποι σχήματος εκθέτουν διαφορετικές επιλογές κλειδώματος. Η διεπαφή [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) είναι η βασική διεπαφή για κλειδώματα σχήματος. Το Aspose.Slides for Java παρέχει τις ακόλουθες διεπαφές κλειδώματος:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) κλειδώνει αυτόματα σχήματα.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) κλειδώνει σχήματα συνδέσμων.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) κλειδώνει γραφικά αντικείμενα.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) κλειδώνει ομαδοποιημένα σχήματα.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) κλειδώνει πλαίσια εικόνας.  

Για να εφαρμόσετε κλειδώματα σε όλη τη [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), επαναλάβετε τις διαφάνειες της και ορίστε τα κατάλληλα κλειδώματα σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και Αφαίρεση Προστασίας**

Συμβατικοί επεξεργαστές παρουσιάσεων χρησιμοποιούν κλειδώματα σχήματος για να περιορίσουν μεμονωμένες λειτουργίες επεξεργασίας. Η κρυπτογράφηση αρχείων και η προστασία εγγραφής σε επίπεδο εγγράφου είναι ξεχωριστές [ρυθμίσεις προστασίας παρουσίασης](/slides/el/java/password-protected-presentation/).

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for Java παρέχει τη διεπαφή [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα καλεί τις μεθόδους [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), και [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) με `true` για αυτόματα σχήματα, με ισοδύναμα κλειδώματα για ομαδοποιημένα σχήματα, συνδέσμους και πλαίσια εικόνας. Οι σύνδεσμοι χρησιμοποιούν τη [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) για κίνηση· οι ομάδες χρησιμοποιούν επίσης τη [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) για περιορισμό ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχήματος κάθε διαφάνειας και αποθηκεύει ένα αντίγραφο με αυτές τις περιοριστικές ρυθμίσεις. Σχήματα εκτός των τεσσάρων τύπων που υποστηρίζονται παραμένουν αμετάβλητα. Ο βρόχος δεν διασχίζει τα παιδικά σχήματα μέσα σε μια ομάδα.

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

Για να αφαιρέσετε ένα κλείδωμα σχήματος, ορίστε την τιμή του σε `false`. Το ακόλουθο παράδειγμα φορτώνει μια παρουσίαση με κλειδώματα σχήματος και καθαρίζει τους περιορισμούς επιλογής, κίνησης και αλλαγής μεγέθους μέσω των [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) και [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Αφαιρεί επίσης τον περιορισμό ομαδοποίησης περνώντας `false` στη μέθοδο [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) και αποθηκεύει ένα αντίγραφο της παρουσίασης. Οι υπόλοιπες ρυθμίσεις κλειδώματος παραμένουν αμετάβλητες.

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

### **Διατήρηση Περικοπής Εικόνας**

Τοποθετήστε μια φωτογραφία με όνομα `photo.jpg` στον τρέχοντα φάκελο εργασίας. Το παράδειγμα περικόπτει 12 % από αριστερά και 8 % από δεξιά, στη συνέχεια καλεί τη [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) στο κλείδωμα του πλαισίου εικόνας. Η παράμετρος `true` περιορίζει περαιτέρω περικοπή και διατηρεί την υπάρχουσα περικοπή.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το `PictureLocked.pptx` αποθηκεύει το κλείδωμα περικοπής ως `true`. Στο PowerPoint, η εντολή **Crop** είναι ανενεργή όταν η φωτογραφία είναι επιλεγμένη.

### **Διατήρηση Διαγράμματος Ομαδοποιημένου**

Το παράδειγμα ομαδοποιεί ένα ορθογώνιο και ένα βέλος, στη συνέχεια καλεί τη [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) στο κλείδωμα της ομάδας για να διατηρήσει τα στοιχεία του διαγράμματος μαζί. Άλλες επεμβάσεις, όπως η μετακίνηση της ομάδας ή η αλλαγή γεμίσματος ενός στοιχείου, παραμένουν διαθέσιμες.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το `DiagramLocked.pptx` αποθηκεύει το κλείδωμα αποομαδοποίησης ως `true`. Στο PowerPoint, η εντολή **Ungroup** είναι ανενεργή όταν ολόκληρο το διάγραμμα είναι επιλεγμένο.

### **Αναφορά Υπάρχοντων Κλειδωμάτων Σχήματος**

Για να ελέγξετε ένα πρότυπο, ανοίξτε το και διαβάστε το αντικείμενο κλειδώματος για κάθε σχήμα. Η μέθοδος [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) επιστρέφει `true` όταν όλες οι σημαίες σε αυτό το αντικείμενο είναι απενεργοποιημένες και `false` όταν τουλάχιστον μία είναι ενεργή. Μια ομάδα και τα παιδιά της έχουν ξεχωριστά αντικείμενα κλειδώματος, επομένως εξετάστε τα παιδιά ακόμα και όταν η ομάδα δεν έχει κλειδώματα.

Το παράδειγμα ελέγχει την κίνηση για αυτόματα σχήματα, πλαίσια εικόνας και ομάδες. Ελέγχει επίσης τη περικοπή για εικόνες και την αποομαδοποίηση για ομάδες. Η αναφορά καταγράφει τις ενεργές σημαίες που αναγνωρίζει και επισημαίνει τύπους σχήματος που δεν εξετάζει.

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Υποθέτουμε ότι η διαφάνεια 1 του `Sample.pptx` περιέχει μια ομάδα με όνομα `Layout` με κλείδωμα αποομαδοποίησης, μια εικόνα με όνομα `Photo` μέσα σε αυτήν με κλείδωμα περικοπής, και ένα μη κλειδωμένο ορθογώνιο με όνομα `Free`. Η αναφορά παραλείπει το `Free` και εκτυπώνει τις δύο παρακάτω γραμμές:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Η αναφορά διαβάζει τις αποθηκευμένες σημαίες επεξεργασίας σε επίπεδο σχήματος χωρίς να τις αλλάξει ή να αποθηκεύσει την παρουσίαση. Η προστασία εγγραφής σε επίπεδο εγγράφου είναι ξεχωριστή ρύθμιση και η εφαρμογή κάθε σημαίας εξαρτάται από τον επεξεργαστή.

### **Συμπέρασμα**

Το Aspose.Slides for Java σας επιτρέπει να περιορίσετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόσετε τους ίδιους περιορισμούς σε όλες τις διαφάνειες. Επιλέξτε τα κλειδώματα που υποστηρίζει κάθε τύπος σχήματος και ορίστε τις τιμές τους σε `false` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **Συχνές Ερωτήσεις**

**Μπορώ να συνδυάσω κλειδώματα σχήματος και προστασία με κωδικό πρόσβασης στην ίδια παρουσίαση;**

Ναι. Τα κλειδώματα σχήματος περιορίζουν συγκεκριμένες λειτουργίες επεξεργασίας, ενώ η [προστασία κωδικού πρόσβασης](/slides/el/java/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδώματος στις άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Περνάτε τη συλλογή που επιστρέφεται από τη μέθοδο [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) της ομάδας και εφαρμόζετε τα κατάλληλα κλειδώματα σε κάθε παιδικό σχήμα. Επαναλάβετε τη διαδικασία για τυχόν ένθετες ομάδες, ακολουθώντας τη διαδρομή του παραδείγματος αναφοράς.