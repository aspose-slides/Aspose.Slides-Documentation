---
title: Περιορισμός Επεξεργασιών Παρουσίασης με Κλειδώματα Σχημάτων σε Node.js
linktitle: Περιορισμός Επεξεργασιών Παρουσίασης
type: docs
weight: 60
url: /el/nodejs-java/applying-protection-to-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να κλειδώνετε και να ξεκλειδώνετε σχήματα σε παρουσιάσεις PPTX με το Aspose.Slides for Node.js via Java για να περιορίσετε την επιλογή, τη μετακίνηση, την αλλαγή μεγέθους και την ομαδοποίηση."
---
## **Επισκόπηση**

Μια συνηθισμένη χρήση του Aspose.Slides for Node.js via Java είναι η δημιουργία, η ενημέρωση και η αποθήκευση παρουσιάσεων PowerPoint (PPTX) ως μέρος μιας αυτοματοποιημένης ροής εργασίας. Όταν οι χρήστες λαμβάνουν αυτές τις παρουσιάσεις, ο περιορισμός των αλλαγών σε σχήματα μπορεί να βοηθήσει στη διατήρηση της προγραμματισμένης διάταξης και του περιεχομένου.

Αυτό το άρθρο εξηγεί πώς οργανώνονται τα σχήματα στις διαφάνειες και πώς να εφαρμόζετε και να αφαιρείτε τα κλειδώματα σχημάτων σε μια παρουσίαση PPTX. Αυτά τα κλειδώματα σας επιτρέπουν να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα.

## **Σύνθεση μιας Διαφάνειας**

Μια διαφάνεια παρουσίασης αποτελείται από στοιχεία όπως αυτόματα σχήματα, πίνακες, αντικείμενα OLE, ομαδοποιημένα σχήματα, πλαίσια εικόνας, πλαίσια βίντεο, συνδέσμους και άλλα στοιχεία που χρησιμοποιούνται για τη δημιουργία μιας παρουσίασης. Στο Aspose.Slides for Node.js via Java, κάθε στοιχείο σε μια διαφάνεια αντιπροσωπεύεται από ένα αντικείμενο που κληρονομεί από την κλάση [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

Διαφορετικοί τύποι σχημάτων εκθέτουν διαφορετικές επιλογές κλειδώματος. Η κλάση [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) είναι η βασική κλάση για τα κλειδώματα σχημάτων. Το Aspose.Slides for Node.js via Java παρέχει τις ακόλουθες κλάσεις κλειδώματος:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) κλειδώνει αυτόματα σχήματα.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) κλειδώνει σχήματα συνδέσμων.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) κλειδώνει γραφικά αντικείμενα.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) κλειδώνει ομαδοποιημένα σχήματα.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) κλειδώνει πλαίσια εικόνας.  

Για να εφαρμόσετε κλειδώματα σε όλη τη [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), επαναλάβετε τις διαφάνειες της και ορίστε τα κατάλληλα κλειδώματα σε κάθε υποστηριζόμενο σχήμα.

## **Εφαρμογή και Κατάργηση Προστασίας**

Συμβατά προγράμματα επεξεργασίας παρουσιάσεων χρησιμοποιούν κλειδώματα σχημάτων για να περιορίζουν μεμονωμένες λειτουργίες επεξεργασίας. Η κρυπτογράφηση αρχείων και η προστασία εγγραφής επιπέδου εγγράφου είναι ξεχωριστές [presentation protection settings](/slides/el/nodejs-java/password-protected-presentation/).

### **Εφαρμογή Προστασίας σε Σχήματα PPTX**

Το Aspose.Slides for Node.js via Java παρέχει την κλάση [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) για εργασία με σχήματα σε μια διαφάνεια.

Το παράδειγμα καλεί τις μεθόδους [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) και [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) με `true` για αυτόματα σχήματα, με ισοδύναμα κλειδώματα για ομαδοποιημένα σχήματα, συνδέσμους και πλαίσια εικόνας. Οι σύνδεσμοι χρησιμοποιούν το [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) για κίνηση· οι ομάδες χρησιμοποιούν επίσης το [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) για περιορισμό ομαδοποίησης.

Το παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση PPTX, ελέγχει τα σχήματα στη συλλογή σχημάτων κάθε διαφάνειας και αποθηκεύει ένα αντίγραφο με αυτές τις περιορισμούς εφαρμοσμένα. Τα σχήματα εκτός των τεσσάρων υποστηριζόμενων τύπων παραμένουν αμετάβλητα. Η βρόχος δεν διασχίζει τα παιδικά σχήματα μέσα σε μια ομάδα.

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

Για να αφαιρέσετε ένα κλείδωμα σχήματος, ορίστε την τιμή του σε `false`. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση με κλειδώματα σχημάτων και καταργεί τις περιορισμούς επιλογής, κίνησης και αλλαγής μεγέθους μέσω των [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) και [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Επίσης αφαιρεί τον περιορισμό ομαδοποίησης περάσσοντας `false` στη μέθοδο [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) και αποθηκεύει ένα αντίγραφο της παρουσίασης. Τα άλλα κλειδώματα παραμένουν αμετάβλητα.

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

### **Διατήρηση της Περικοπής Εικόνας**

Τοποθετήστε μια φωτογραφία με όνομα `photo.jpg` στον τρέχοντα φάκελο εργασίας. Το παράδειγμα περικόπτει το 12 % από την αριστερή πλευρά και το 8 % από τη δεξιά, έπειτα καλεί το [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) στο κλείδωμα του πλαισίου εικόνας. Η μετάδοση `true` περιορίζει περαιτέρω την περικοπή και διατηρεί την υπάρχουσα περικοπή.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` αποθηκεύει το κλείδωμα περικοπής ως `true`. Στο PowerPoint, η εντολή **Crop** είναι ανενεργή όταν η φωτογραφία είναι επιλεγμένη.

### **Διατήρηση Διαγράμματος Ομαδοποιημένου**

Το παράδειγμα ομαδοποιεί ένα ορθογώνιο και ένα βέλος, έπειτα καλεί το [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) στο κλείδωμα της ομάδας για να διατηρήσει τα στοιχεία του διαγράμματος μαζί. Άλλες επεμβάσεις, όπως η μετακίνηση της ομάδας ή η αλλαγή γεμίσματος ενός στοιχείου, παραμένουν διαθέσιμες.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` αποθηκεύει το κλείδωμα αποομαδοποίησης ως `true`. Στο PowerPoint, η εντολή **Ungroup** είναι ανενεργή όταν ολόκληρο το διάγραμμα είναι επιλεγμένο.

### **Αναφορά Υπάρχουσας Κλειδώματος Σχημάτων**

Για να ελέγξετε ένα πρότυπο, ανοίξτε το και διαβάστε το αντικείμενο κλειδώματος για κάθε σχήμα. Η μέθοδος [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) επιστρέφει `true` όταν όλα τα σημαίες σε αυτό το αντικείμενο είναι απενεργοποιημένα και `false` όταν τουλάχιστον μία είναι ενεργή. Μια ομάδα και τα παιδικά της στοιχεία έχουν ξεχωριστά αντικείμενα κλειδώματος, επομένως ελέγξτε τα παιδικά ακόμη και αν η ομάδα δεν έχει κλειδώματα.

Αυτό το παράδειγμα ελέγχει κίνηση για αυτόματα σχήματα, πλαίσια εικόνας και ομάδες. Επίσης ελέγχει περικοπή για εικόνες και αποομαδοποίηση για ομάδες. Η αναφορά απαριθμεί τις ενεργές σημαίες που αναγνωρίζει και επισημαίνει τύπους σχημάτων που δεν ελέγχει.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Υποθέστε ότι η διαφάνεια 1 του `Sample.pptx` περιέχει μια ομάδα με όνομα `Layout` με κλείδωμα αποομαδοποίησης, μια εικόνα με όνομα `Photo` μέσα σε αυτήν με κλείδωμα περικοπής, και ένα ανοιχτό ορθογώνιο με όνομα `Free`. Η αναφορά παραλείπει το `Free` και εκτυπώνει αυτές τις δύο γραμμές:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Η αναφορά διαβάζει τις αποθηκευμένες σημαίες επεξεργασίας επιπέδου σχήματος χωρίς να τις αλλάξει ή να αποθηκεύσει την παρουσίαση. Η προστασία εγγραφής σε επίπεδο εγγράφου είναι ξεχωριστή ρύθμιση και η εφαρμογή κάθε σημαίας εξαρτάται από το πρόγραμμα επεξεργασίας.

### **Συμπέρασμα**

Το Aspose.Slides for Node.js via Java σας επιτρέπει να περιορίζετε συγκεκριμένες λειτουργίες επεξεργασίας σε μεμονωμένα σχήματα ή να εφαρμόζετε τις ίδιες περιορισμούς σε όλες τις διαφάνειες. Επιλέξτε τα κλειδώματα που υποστηρίζει κάθε τύπος σχήματος και ορίστε τις τιμές τους σε `false` όταν χρειάζεται να αφαιρέσετε αυτούς τους περιορισμούς.

## **FAQ**

**Μπορώ να συνδυάσω τα κλειδώματα σχημάτων και την προστασία με κωδικό στην ίδια παρουσίαση;**

Ναι. Τα κλειδώματα σχημάτων περιορίζουν συγκεκριμένες λειτουργίες επεξεργασίας, ενώ η [password protection](/slides/el/nodejs-java/password-protected-presentation/) μπορεί να περιορίσει το άνοιγμα ή την τροποποίηση της παρουσίασης. Μπορείτε να χρησιμοποιήσετε και τα δύο στο ίδιο αρχείο.

**Μπορώ να περιορίσω την επεξεργασία σε συγκεκριμένες διαφάνειες χωρίς να επηρεάσω τις άλλες;**

Ναι. Εφαρμόστε κλειδώματα μόνο στα σχήματα των επιλεγμένων διαφανειών. Αυτό δεν αλλάζει τις ρυθμίσεις κλειδώματος στις άλλες διαφάνειες.

**Πώς μπορώ να εφαρμόσω κλειδώματα σε μεμονωμένα σχήματα μέσα σε μια ομάδα;**

Περνάτε από τη συλλογή που επιστρέφει η μέθοδος [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) της ομάδας και εφαρμόζετε τα κατάλληλα κλειδώματα σε κάθε παιδικό σχήμα. Επαναλάβετε τη διαδικασία για τυχόν ενσωματωμένες ομάδες, ακολουθώντας τη διάσχιση του παραδείγματος αναφοράς.