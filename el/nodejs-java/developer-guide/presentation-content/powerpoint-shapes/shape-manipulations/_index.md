---
title: Διαχείριση Σχημάτων Παρουσίασης σε JavaScript
linktitle: Διαχείριση Σχήματος
type: docs
weight: 40
url: /el/nodejs-java/shape-manipulations/
keywords:
- Σχήμα PowerPoint
- Σχήμα παρουσίασης
- Σχήμα σε διαφάνεια
- Εύρεση σχήματος
- Κλωνοποίηση σχήματος
- Αφαίρεση σχήματος
- Απόκρυψη σχήματος
- Αλλαγή σειράς σχήματος
- Λήψη ID σχήματος interop
- Εναλλακτικό κείμενο σχήματος
- Μορφές διάταξης σχήματος
- Σχήμα ως SVG
- Σχήμα σε SVG
- Στοίχιση σχήματος
- Αναστροφή σχήματος
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να ταυτοποιείτε, κλωνοποιείτε, αφαιρείτε, κρύβετε, επανατάξιτε, εξάγετε, στοιχίζετε και αναστρέφετε σχήματα παρουσίασης με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides for Node.js via Java αντιπροσωπεύει τα σχήματα σε μια διαφάνεια ως μια ταξινομημένη [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/). Η συλλογή είναι τόσο το σημείο όπου βρίσκετε και τροποποιείτε σχήματα όσο και η πηγή της σειράς στοίβας τους: το ευρετήριο `0` είναι το πιο πίσω σχήμα, ενώ το τελευταίο ευρετήριο είναι το πιο μπροστινό σχήμα.

Αυτό το άρθρο ακολουθεί το μοντέλο αυτό. Πρώτα εξηγεί πώς να προσδιορίζετε αξιόπιστα ένα σχήμα, μετά δείχνει πώς να κλωνοποιήσετε, να αφαιρέσετε, να κρύψετε και να επανατακτήσετε σχήματα. Τα τελικά τμήματα καλύπτουν μορφοποίηση επιπέδου διάταξης, εξαγωγή SVG, στοίχιση και ρυθμίσεις αναστροφής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτεί η ροή εργασίας σας.

## **Αναγνώριση και Εύρεση Σχημάτων**

Τα ευρετήρια της συλλογής είναι βολικά όταν επεξεργάζεστε ένα γνωστό αρχείο, αλλά δεν αποτελούν σταθερά αναγνωριστικά. Η προσθήκη, η κατάργηση ή η επαναταξινόμηση ενός σχήματος μπορεί να αλλάξει το ευρετήριο του. Επιλέξτε ένα αναγνωριστικό σύμφωνα με τον τρόπο με τον οποίο δημιουργείται και συντηρείται η παρουσίαση:

- [Name](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getname/) είναι χρήσιμο για πρότυπα που ελέγχονται από προγραμματιστές και είναι εύκολο να ελεγχθεί στον Πίνακα Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν εγγυώνται μοναδικότητα, οπότε θεσπίστε μια σύμβαση ονοματοδοσίας εάν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getalternativetext/) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα που παρείχε ο δημιουργός ήδη ταυτοποιεί το σχήμα. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να ξαναγραφτεί για προσβασιμότητα, και δεν εγγυάται μοναδικότητα. Μην επαναχρησιμοποιήσετε σιωπηρά το νόημα του κειμένου προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) είναι ένα μόνο‑ανάγνωση αναγνωριστικό που είναι μοναδικό μέσα σε μια διαφάνεια και αντιστοιχεί στο ID σχήματος που χρησιμοποιείται από το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε μια ασαφή αναφορά κατά τη διάρκεια της ζωής ενός σχήματος. Ένα κλωνοποιημένο ή επανδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική μέθοδος [getUniqueId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getuniqueid/) επιστρέφει ένα αναγνωριστικό με εμβέλεια παρουσίασης, αλλά αυτό το αναγνωριστικό προορίζεται για add‑ins και μπορεί να επαναχωρισθεί. Δεν πρέπει να θεωρηθεί μόνιμο εξωτερικό κλειδί. Εάν είναι σημαντική η μακροπρόθεσμη ταυτότητα, κρατήστε την αντιστοίχιση στα δεδομένα της εφαρμογής και επικυρώστε ότι το αναμενόμενο σχήμα υπάρχει ακόμη.

Το παρακάτω παράδειγμα αναζητά με όνομα με ακριβή σύγκριση και αναφέρει το ID interop scoped στη διαφάνεια. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρει το αποτέλεσμα αυτό αντί να συνεχίσει με το λάθος αντικείμενο.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Όταν μια λειτουργία είναι συγκεκριμένη για κάποιο τύπο σχήματος, ελέγξτε την κλάση χρόνου εκτέλεσης πριν χρησιμοποιήσετε μέλη ειδικά για τύπο. Αυτό το παράδειγμα ενημερώνει κείμενο και εναλλακτικό κείμενο μόνο αν το αντικείμενο με όνομα είναι ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και επαναταξινόμησης λειτουργούν στη συλλογή αμέσως. Εάν μια λειτουργία αλλάζει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να βασίζεστε σε ευρετήρια που καταγράφηκαν πριν από αυτή τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/addclone/) δημιουργεί ένα ανεξάρτητο αντίγραφο και το προσαρτά στη συλλογή προορισμού. [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/insertclone/) επίσης δημιουργεί ένα αντίγραφο αλλά το τοποθετεί σε καθορισμένο ευρετήριο z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το κλώνο χωρίς να αλλάζουν το μέγεθός του· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το αλλάξουν σε μέγεθος.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα επισημασμένο ορθογώνιο στο εμπρός μέρος και εισάγει ένα δεύτερο κλώνο στο πίσω μέρος. Οι αλλαγές σε οποιονδήποτε κλώνο δεν επηρεάζουν το σχήμα πηγής.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένων του ονόματος και του εναλλακτικού κειμένου. Ορίστε νέες λογικές ταυτότητες στο κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Οι πόροι που χρησιμοποιούνται από σύνθετα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένα κλώνο παραμένει νέο στοιχείο της συλλογής με νέα ταυτότητα σχήματος.

### **Αφαίρεση Σχημάτων**

[remove](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/remove/) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Όταν αφαιρείτε πολλά ταιριάσματα κατά τη διάρκεια της επαναληπτικής διαδρομής με ευρετήρια, διασχίστε τη συλλογή από το τέλος ώστε κάθε εναπομείναν ευρετήριο να παραμείνει έγκυρο.

Αυτό το παράδειγμα αφαιρεί κάθε σχήμα με καθορισμένο όνομα. Διαβάζει το σχήμα στο τρέχον ευρετήριο και δεν υποθέτει συγκεκριμένο τύπο σχήματος.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μετά την αφαίρεση, ο αριθμός σχημάτων και τα ευρετήρια των μεταγενέστερων σχημάτων αλλάζουν. Οι αναφορές σε μη επηρεασμένα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένα ευρετήρια. Επίσης λάβετε υπόψη συνδέσμους, αναπαραγωγές και άλλα χαρακτηριστικά παρουσίασης που μπορεί να αναφέρονται στο αφαιρεθέν αντικείμενο· η αφαίρεση ενός ορατού σχήματος μπορεί να αλλάξει περισσότερα από την εμφάνιση της διαφάνειας.

### **Απόκρυψη Σχήματος**

Ο ορισμός του [Hidden](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/sethidden/) σε `true` διατηρεί το σχήμα στη συλλογή αλλά εμποδίζει την εμφάνισή του στην κανονική προβολή διαφάνειας. Το ευρετήριο, η μορφοποίηση και το περιεχόμενο παραμένουν διαθέσιμα στον κώδικα, επομένως η απόκρυψη είναι κατάλληλη για προαιρετικά στοιχεία που μπορεί να επαναφερθούν αργότερα.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η απόκρυψη δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί ακόμη να εντοπιστεί και να εμφανιστεί ξανά από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή του Z‑Order**

Τα επικαλυπτόμενα σχήματα ζωγραφίζονται με σειρά της συλλογής. [reorder](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/reorder/) μετακινεί ένα υπάρχον σχήμα σε ένα στόχο ευρετήριο χωρίς κλωνοποίηση. Το ευρετήριο `0` είναι το πίσω μέρος· `size() - 1` είναι το εμπρός μέρος.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από την έλλειψη. Η μετακίνησή του στο τελικό ευρετήριο το θέτει εμπρός. Ολοκληρώστε το z‑order μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορούν να αλλάξουν την προοριζόμενη στοίβα.

## **Έλεγχος Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα σχήμα παρόμοιας θέσης σε κανονική διαφάνεια. Εξετάστε τα σχήματα διάταξης όταν χρειάζεται να κατανοήσετε ή να αλλάξετε τη μορφοποίηση που παρέχεται από μία διάταξη.

Το παρακάτω παράδειγμα διαβάζει το [FillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getfillformat/) και το [LineFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getlineformat/) κάθε σχήματος διάταξης χωρίς να υποθέτει ότι κάθε σχήμα είναι ένα `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, προσδιορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική παράκαμψη, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί αυτήν τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[writeAsSvg](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/writeassvg/) γράφει το αποδιδόμενο περιεχόμενο ενός σχήματος σε ροή. Το αποτέλεσμα περιέχει το σχήμα, όχι ολόκληρο το φόντο της διαφάνειας ή τα γειτονικά σχήματα.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Διατηρήστε την παρουσίαση ανοιχτή κατά τη διάρκεια της απόδοσης. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Εάν χρειάζεστε ολόκληρη τη σύνθεση, εξάγετε τη διαφάνεια αντί για μεμονωμένο σχήμα. Ο καλώντ έχει την ευθύνη της ροής και πρέπει να την κλείσει.

## **Στοίχιση Σχημάτων**

Οι υπερφορτώσεις του [SlideUtil.alignShapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideutil/alignshapes/) ευθυγραμμίζουν είτε όλα τα σχήματα είτε επιλεγμένα ευρετήρια συλλογής. Το [ShapesAlignmentType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapesalignmenttype/) καθορίζει την άκρη, τη γραμμή κέντρου ή τη λειτουργία κατανομής. Ορίστε `alignToSlide` σε `true` για χρήση των άκρων της διαφάνειας· ορίστε το σε `false` για στοίχιση των επιλεγμένων σχημάτων μεταξύ τους.

Αυτό το παράδειγμα ευθυγραμμίζει τρία σχήματα στην πάνω άκρη της διαφάνειας. Οι αναφορές σχήματος που επιστρέφονται μετατρέπονται αμέσως στα τρέχοντα ευρετήρια πριν από τη στοίχιση.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η στοίχιση αλλάζει τις θέσεις, όχι το z‑order. Η σχετική στοίχιση συνήθως απαιτεί τουλάχιστον δύο σχήματα, ενώ η οριζόντια ή κατακόρυφη κατανομή χρειάζεται αρκετά σχήματα για να ορίσει το διάστημα. Επαναϋπολογίστε τα ευρετήρια εάν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντια και κάθετη ρύθμιση αναστροφής, και περιστροφή. Οι τιμές `getFlipH` και `getFlipV` χρησιμοποιούν το [NullableBool](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/nullablebool/): `True` ενεργοποιεί την αναστροφή, `False` την απενεργοποιεί, και `NotDefined` διατηρεί την ακαθόριστη/προεπιλεγμένη κατάσταση.

Η παρακάτω παρουσίαση περιέχει ένα μη αναστραμμένο σχήμα.

![The shape before flipping](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί κάθε άλλη τιμή πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις αναστροφής. Αυτό είναι σημαντικό επειδή η ανάθεση ενός νέου [Frame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/setframe/) αντικαθιστά ολόκληρο το πλαίσιο.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποθηκευμένο σχήμα είναι κατοπτρισμένο οριζόντια και κατακόρυφα ενώ διατηρεί τη θέση, το μέγεθος και την περιστροφή του.

![The shape after flipping](flipped_shape.png)

## **Συχνές Ερωτήσεις**

**Should I use a collection index as a shape identifier?**

Only for short-lived processing when the collection will not change before the index is used. Prefer a validated `Name` or `AlternativeText` convention for authored templates, or `OfficeInteropShapeId` for slide-scoped interop work.

**Does hiding a shape remove it from the z-order?**

No. A hidden shape remains in the collection at the same index. It can be found, reordered, edited, or made visible again.

**Why did a cloned shape appear in front of another shape?**

`addClone` appends the clone to the end of the collection, which is the front of the z-order. Use `insertClone` to choose the initial index or `reorder` after all shapes have been added.