---
title: Διαχείριση Σχημάτων Παρουσίασης σε JavaScript
linktitle: Διαχείριση Σχημάτων
type: docs
weight: 40
url: /el/nodejs-java/shape-manipulations/
keywords:
- Σχήμα PowerPoint
- Σχήμα παρουσίασης
- Σχήμα στη διαφάνεια
- Εύρεση σχήματος
- Κλωνοποίηση σχήματος
- Αφαίρεση σχήματος
- Απόκρυψη σχήματος
- Αλλαγή σειράς σχήματος
- Λήψη ID σχήματος interop
- Εναλλακτικό κείμενο σχήματος
- Σημείο ρύθμισης σχήματος
- Προρυθμισμένη ρύθμιση σχήματος
- Γεωμετρία σχήματος
- Μορφές διάταξης σχήματος
- Σχήμα ως SVG
- Σχήμα σε SVG
- Ευθυγράμμιση σχήματος
- Αναστροφή σχήματος
- PowerPoint
- Παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να αναγνωρίζετε, προσαρμόζετε, κλωνοποιείτε, αφαιρείτε, κρύβετε, αλλάζετε τη σειρά, εξάγετε, ευθυγραμμίζετε και αναστρέφετε σχήματα παρουσίασης με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Node.js via Java αντιπροσωπεύει τα σχήματα σε μια διαφάνεια ως μια διατεταγμένη [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/). Η συλλογή είναι τόσο το σημείο όπου βρίσκετε και τροποποιείτε σχήματα όσο και η πηγή της σειράς στοίβαξής τους: το δείκτη `0` είναι το πιο πίσω σχήμα, ενώ ο τελευταίος δείκτης είναι το πιο μπροστινό σχήμα.

Αυτό το άρθρο ακολουθεί αυτό το μοντέλο. Πρώτα εξηγεί πώς να αναγνωρίζετε αξιόπιστα ένα σχήμα και να τροποποιείτε προρυθμισμένα σημεία ρύθμισης σχήματος, μετά δείχνει πώς να κλωνοποιείτε, να αφαιρείτε, να κρύβετε και να αναδιατάσσετε σχήματα. Τα τελικά τμήματα καλύπτουν διαμόρφωση επιπέδου διάταξης, εξαγωγή SVG, ευθυγράμμιση και ρυθμίσεις ανάστροφης προβολής. Κάθε παράδειγμα είναι ανεξάρτητο, ώστε να μπορείτε να χρησιμοποιήσετε μόνο τις λειτουργίες που απαιτεί η ροή εργασίας σας.

## **Αναγνώριση και Εύρεση Σχημάτων**

Οι δείκτες της συλλογής είναι βολικοί κατά την επεξεργασία ενός γνωστού αρχείου, αλλά δεν αποτελούν σταθερά αναγνωριστικά. Η προσθήκη, η αφαίρεση ή η αλλαγή σειράς ενός σχήματος μπορεί να αλλάξει τον δείκτη του. Επιλέξτε ένα αναγνωριστικό ανάλογα με το πώς δημιουργείται και συντηρείται η παρουσίαση:

- [Name](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getname/) είναι χρήσιμο για πρότυπα ελεγχόμενα από προγραμματιστές και είναι εύκολο να επιθεωρηθεί στο Πλαίσιο Επιλογής του PowerPoint. Τα ονόματα μπορούν να επεξεργαστούν και δεν εγγυώνται μοναδικότητα, οπότε καθιερώστε ένα σύστημα ονοματοδοσίας εάν ο κώδικας εξαρτάται από αυτά.
- [AlternativeText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getalternativetext/) είναι χρήσιμο όταν μια περιγραφή προσβασιμότητας ή μια ετικέτα που έχει προσθέσει ο δημιουργός ήδη αναγνωρίζει το σχήμα. Είναι ορατό στους χρήστες, μπορεί να μεταφραστεί ή να ξαναγραφτεί για προσβασιμότητα, και δεν εγγυάται μοναδικότητα. Μην επανχρησιμοποιείτε κωδικοποιημένο κείμενο προσβασιμότητας ως κλειδί βάσης δεδομένων.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) είναι ένα αναγνωριστικό μόνο για ανάγνωση το οποίο είναι μοναδικό μέσα σε μια διαφάνεια και αντιστοιχεί στο ID σχήματος που χρησιμοποιεί το PowerPoint interop. Χρησιμοποιήστε το όταν ενσωματώνετε με το PowerPoint ή όταν χρειάζεστε ανεπιφύλακτη αναφορά κατά τη διάρκεια ζωής ενός σχήματος. Ένα κλωνοποιημένο ή ξαναδημιουργημένο σχήμα είναι διαφορετικό σχήμα και λαμβάνει το δικό του ID.

Η σχετική μέθοδος [getUniqueId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/getuniqueid/) επιστρέφει ένα αναγνωριστικό σε επίπεδο παρουσίασης, αλλά αυτό το αναγνωριστικό προορίζεται για πρόσθετα και μπορεί να επανεκχωρηθεί. Δεν πρέπει να αντιμετωπίζεται ως μόνιμο εξωτερικό κλειδί. Εάν η μακροπρόθεσμη ταυτότητα είναι απαραίτητη, κρατήστε τη αντιστοίχιση σε δεδομένα εφαρμογής και επαληθεύστε ότι το αναμενόμενο σχήμα εξακολουθεί να υπάρχει.

Το παρακάτω παράδειγμα ψάχνει με βάση το όνομα με ακριβή σύγκριση και αναφέρει το interop ID σε επίπεδο διαφάνειας. Όταν το πρότυπο δεν περιέχει το αναμενόμενο σχήμα, ο κώδικας αναφέρει αυτό το αποτέλεσμα αντί να προχωρήσει με το λανθασμένο αντικείμενο.

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

Όταν μια λειτουργία είναι ειδική για έναν τύπο σχήματος, ελέγξτε την κλάση εκτέλεσης πριν χρησιμοποιήσετε μέλη ειδικά για τον τύπο. Αυτό το παράδειγμα ενημερώνει κείμενο και εναλλακτικό κείμενο μόνο εάν το ονομαζόμενο αντικείμενο είναι ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/).

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

## **Αναγνώριση και Τροποποίηση Προρυθμισμένων Ρυθμίσεων Σχήματος**

Τα σχήματα προρυθμισμένης γεωμετρίας μπορούν να εκθέτουν σημεία ρύθμισης που ελέγχουν χαρακτηριστικά όπως το μέγεθος γωνίας, τις αναλογίες βέλους ή τις γωνίες τόξου. Πρόσβαση σε αυτά γίνεται μέσω της [GeometryShape.getAdjustments](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/geometryshape/) συλλογής μόνο για ανάγνωση. Η συλλογή παρέχεται από το σχήμα, αλλά κάθε [AdjustValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/adjustvalue/) περιέχει μια τιμή που μπορεί να αλλάξει.

Μην βασίζεστε μόνο σε ένα σταθερό δείκτη συλλογής. Επεξεργαστείτε τις ρυθμίσεις επαναλαμβάνοντας τις προσαρμογές και ελέγχοντας τη μέθοδο μόνο για ανάγνωση [getType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/adjustvalue/) της, της οποίας η τιμή [ShapeAdjustmentType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapeadjustmenttype/) περιγράφει τι ελέγχει η ρύθμιση. Η μέθοδος μόνο για ανάγνωση [getName](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/adjustvalue/getname/) παρέχει επιπλέον πληροφορίες ταυτοποίησης και είναι ιδιαίτερα χρήσιμη όταν ένα πρότυπο περιέχει περισσότερες από μία ρυθμίσεις με τον ίδιο σημασιολογικό τύπο.

Χρησιμοποιήστε τη μέθοδο τιμής που ταιριάζει με το νόημα της ρύθμισης:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | Μέγεθος στρογγυλεμένων γωνιών | [setRawValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Πάχος ουράς βέλους | `setRawValue` |
| `ArrowheadLength` | Μήκος κεφαλής βέλους | `setRawValue` |
| `ArrowheadWidth` | Πλάτος κεφαλής βέλους | `setRawValue` |
| `StartAngle` | Αρχική γωνία πίτας ή τόξου | [setAngleValue](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Τελική γωνία πίτας ή τόξου | `setAngleValue` |

`getType` και `getName` επιστρέφουν πληροφορίες μόνο για ανάγνωση. `getRawValue` και `setRawValue` λειτουργούν με έναν ακέραιο στις εγγενείς μονάδες γεωμετρίας του προτύπου, ενώ `getAngleValue` και `setAngleValue` λειτουργούν με γωνία σε μοίρες. Ο αριθμός, η σειρά, το νόημα και το έγκυρο εύρος των ρυθμίσεων εξαρτώνται από το προρυθμισμένο [GeometryShape.getShapeType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/geometryshape/). Μια τιμή που είναι έγκυρη για ένα πρότυπο μπορεί να είναι άκυρη ή να έχει διαφορετικό αποτέλεσμα για ένα άλλο.

Όταν το `getType` επιστρέφει `ShapeAdjustmentType.Custom`, το API δεν αναγνωρίζει τυπικό σημασιολογικό νόημα. Ελέγξτε το `getName`, τον τύπο προτύπου και την υπάρχουσα τιμή, και αφήστε την ρύθμιση αμετάβλητη εκτός εάν το αναμενόμενο νόημα και το εύρος είναι γνωστά. Ακόμη και για αναγνωρισμένους τύπους, ελέγξτε αν ο ίδιος τύπος εμφανίζεται περισσότερες από μία φορές πριν επιλέξετε τιμή. Το άρθρο [Connector](/slides/el/nodejs-java/connector/) δείχνει αυτή την κατάσταση με ρυθμίσεις κάμψης συνδέσμων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί προεπιλεγμένες και τροποποιημένες εκδοχές τριών προρυθμισμένων σχημάτων. Επεξεργάζεται κάθε ρύθμιση, αναφέρει το όνομά της και τον τύπο, αλλάζει τιμές σχετικές με μέγεθος μέσω `setRawValue`, αλλάζει γωνίες μέσω `setAngleValue` και αποθηκεύει το αποτέλεσμα. Η αριστερή στήλη διατηρεί την προεπιλεγμένη γεωμετρία· η δεξιά στήλη δείχνει το προσαρμοσμένο στρογγυλεμένο ορθογώνιο, το τετραπλό βέλος και την πίτα.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Προσθέτει κεφαλίδες για τις στήλες των προεπιλεγμένων και προσαρμοσμένων σχημάτων.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ο έλεγχος του σημασιολογικού τύπου πριν την αλλαγή τιμής κάνει τον κώδικα σαφή σχετικά με την πρόθεσή του και αποφεύγει την υπόθεση ότι ένας συγκεκριμένος δείκτης συλλογής έχει το ίδιο νόημα σε διαφορετικά προρυθμισμένα σχήματα.

## **Τροποποίηση της Συλλογής Σχημάτων**

Οι μέθοδοι προσθήκης, κλωνοποίησης, αφαίρεσης και αναδιάταξης λειτουργούν άμεσα στη συλλογή. Εάν μια λειτουργία αλλάξει τον αριθμό ή τη σειρά των σχημάτων, μην συνεχίσετε να βασίζεστε σε δείκτες που καταγράφηκαν πριν από αυτή τη λειτουργία.

### **Κλωνοποίηση Σχήματος**

[addClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/addclone/) δημιουργεί ένα ανεξάρτητο αντίγραφο και το προσθέτει στο στόχο συλλογής. [insertClone](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/insertclone/) επίσης δημιουργεί ένα αντίγραφο αλλά το τοποθετεί σε καθορισμένο δείκτη z‑order. Οι υπερφορτώσεις που δέχονται συντεταγμένες μετακινούν το κλώνο χωρίς αλλαγή μεγέθους· οι υπερφορτώσεις με πλάτος και ύψος μπορούν επίσης να το αλλάξουν.

Το παράδειγμα δημιουργεί μια διαφάνεια προορισμού, κλωνοποιεί ένα ορθογώνιο με ετικέτα προς τα εμπρός και εισάγει ένα δεύτερο κλώνο στο πίσω μέρος. Οι αλλαγές σε οποιονδήποτε κλώνο δεν τροποποιούν το αρχικό σχήμα.

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

Η κλωνοποίηση αντιγράφει το περιεχόμενο και τη μορφοποίηση του σχήματος, συμπεριλαμβανομένου του ονόματος και του εναλλακτικού κειμένου. Αναθέστε νέα λογικά αναγνωριστικά στο κλώνο όταν αυτές οι τιμές πρέπει να είναι μοναδικές. Πόροι που χρησιμοποιούνται από σύνθετα σχήματα διαχειρίζονται από την παρουσίαση, αλλά ένα κλώνο παραμένει νέο στοιχείο της συλλογής με νέα ταυτότητα σχήματος.

### **Αφαίρεση Σχημάτων**

[remove](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/remove/) διαγράφει ένα συγκεκριμένο αντικείμενο σχήματος από τη συλλογή του. Όταν αφαιρείτε πολλαπλές αντιστοιχίες κατά τη διάρκεια επανάληψης με δείκτες, περάστε από το τέλος ώστε κάθε υπόλοιπος δείκτης να παραμείνει έγκυρος.

Αυτό το παράδειγμα αφαιρεί κάθε σχήμα με καθορισμένο όνομα. Διαβάζει το σχήμα στον τρέχοντα δείκτη και δεν υποθέτει συγκεκριμένο τύπο σχήματος.

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

Μετά την αφαίρεση, η καταμέτρηση σχήματος και οι δείκτες των επόμενων σχημάτων αλλάζουν. Αναφορές σε αμετάβλητα σχήματα παραμένουν πιο αξιόπιστες από αποθηκευμένους δείκτες. Λάβετε επίσης υπόψη συνδέσμους, κινήσεις και άλλα χαρακτηριστικά παρουσίασης που μπορεί να αναφέρονται στο αφαιρεθέν αντικείμενο· η αφαίρεση ορατού σχήματος μπορεί να αλλάξει περισσότερο από την εμφάνιση της διαφάνειας.

### **Απόκρυψη Σχήματος**

Ορίζοντας το [Hidden](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/sethidden/) σε `true` διατηρεί το σχήμα στη συλλογή αλλά εμποδίζει την εμφάνισή του στην κανονική προβολή διαφάνειας. Ο δείκτης, η μορφοποίηση και το περιεχόμενό του παραμένουν διαθέσιμα στον κώδικα, επομένως η απόκρυψη είναι κατάλληλη για προαιρετικά στοιχεία που μπορεί να επαναφερθούν αργότερα.

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

Η απόκρυψη δεν είναι διαγραφή ή ασφάλεια. Το αντικείμενο μπορεί ακόμη να ανακαλυφθεί και να εμφανιστεί ξανά από χρήστη ή κώδικα, και παραμένει μέρος του αρχείου παρουσίασης.

### **Αλλαγή του Z‑Order**

Τα επικαλυπτόμενα σχήματα ζωγραφίζονται με σειρά συλλογής. [reorder](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/reorder/) μετακινεί ένα υπάρχον σχήμα σε στόχο δείκτη χωρίς κλωνοποίηση. Ο δείκτης `0` είναι το πίσω μέρος· `size() - 1` είναι το μπροστινό.

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

Το ορθογώνιο δημιουργείται πρώτα και αρχικά βρίσκεται πίσω από το έλλειψο. Η μετακίνηση του στον τελικό δείκτη το τοποθετεί μπροστά. Ολοκληρώστε το z‑order μετά την προσθήκη ή κλωνοποίηση όλων των σχετικών σχημάτων, επειδή αυτές οι λειτουργίες προσθέτουν ή εισάγουν νέα στοιχεία στη συλλογή και μπορεί να αλλάξουν την προοριζόμενη στοίβα.

## **Έλεγχος Σχημάτων σε Διαφάνειες Διάταξης**

Οι κανονικές διαφάνειες, οι διαφάνειες διάταξης και οι κύριες διαφάνειες έχουν ξεχωριστές συλλογές σχημάτων. Ένα σχήμα σε συλλογή διάταξης δεν είναι το ίδιο αντικείμενο με ένα σχήμα παρόμοιας θέσης σε κανονική διαφάνεια. Εξετάστε τα σχήματα διάταξης όταν πρέπει να κατανοήσετε ή να αλλάξετε τη μορφοποίηση που παρέχεται από μια διάταξη.

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

Η επεξεργασία μιας διάταξης μπορεί να επηρεάσει πολλαπλές διαφάνειες που τη χρησιμοποιούν. Πριν αλλάξετε ένα σχήμα διάταξης, προσδιορίστε εάν μια κανονική διαφάνεια κληρονομεί το αντικείμενο ή περιέχει τοπική υπερισχυτική ρύθμιση, και δοκιμάστε κάθε διαφάνεια που χρησιμοποιεί αυτή τη διάταξη.

## **Εξαγωγή Σχήματος σε SVG**

[writeAsSvg](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/writeassvg/) γράφει το αποδομένο περιεχόμενο ενός σχήματος σε ροή. Το αποτέλεσμα περιλαμβάνει μόνο το σχήμα, όχι το πλήρες φόντο της διαφάνειας ή τα γειτονικά σχήματα.

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

Διατηρήστε την παρουσίαση ανοιχτή κατά την απόδοση. Η έξοδος εξαρτάται από τη μορφοποίηση του σχήματος και από πόρους όπως γραμματοσειρές και εικόνες. Εάν χρειάζεστε ολόκληρη τη σύνθεση, εξαγάγετε τη διαφάνεια αντί για το μεμονωμένο σχήμα. Ο καλών χρήστης είναι υπεύθυνος για το κλείσιμο της ροής.

## **Ευθυγράμμιση Σχημάτων**

Οι υπερφορτώσεις του [SlideUtil.alignShapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideutil/alignshapes/) ευθυγραμμίζουν είτε όλα τα σχήματα είτε επιλεγμένους δείκτες συλλογής. Το [ShapesAlignmentType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapesalignmenttype/) καθορίζει την άκρη, τη γραμμή κέντρου ή τη λειτουργία κατανομής. Ορίστε `alignToSlide` σε `true` για χρήση των άκρων της διαφάνειας· ορίστε το σε `false` για ευθυγράμμιση των επιλεγμένων σχημάτων μεταξύ τους.

Αυτό το παράδειγμα ευθυγραμμίζει τρία σχήματα στο άνω όριο της διαφάνειας. Οι αναφορές στα σχήματα που επιστρέφονται μετατρέπονται στους τρέχοντες δείκτες τους αμέσως πριν την ευθυγράμμιση.

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

Η ευθυγράμμιση αλλάζει τις θέσεις, όχι το z‑order. Η σχετική ευθυγράμμιση συνήθως απαιτεί τουλάχιστον δύο σχήματα, ενώ η κατανομή οριζόντιας ή κάθετης διεύθυνσης χρειάζεται αρκετά σχήματα για ορισμό διαστημάτων. Επαναϋπολογίστε τους δείκτες εάν τροποποιήσετε τη συλλογή πριν καλέσετε τη μέθοδο.

## **Αναστροφή Σχήματος**

Η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapeframe/) αποθηκεύει θέση, μέγεθος, οριζόντια και κάθετη ρύθμιση αναστροφής, και περιστροφή. Οι τιμές `getFlipH` και `getFlipV` χρησιμοποιούν το [NullableBool](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/nullablebool/): `True` ενεργοποιεί την αναστροφή, `False` την απενεργοποιεί, και `NotDefined` διατηρεί την ακαθόριστη/προεπιλεγμένη κατάσταση.

Η παρακάτω παρουσίαση εισόδου περιέχει ένα σχήμα χωρίς αναστροφή.

![The shape before flipping](shape_to_be_flipped.png)

Το παράδειγμα διατηρεί όλες τις άλλες τιμές του πλαισίου και αντικαθιστά μόνο τις δύο ρυθμίσεις αναστροφής. Αυτό είναι σημαντικό επειδή η ανάθεση ενός νέου [Frame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/setframe/) αντικαθιστά ολόκληρο το πλαίσιο.

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

Το αποθηκευμένο σχήμα αντικατοπτρίζεται οριζόντια και κάθετα ενώ διατηρεί τη θέση, το μέγεθος και τη περιστροφή του.

![The shape after flipping](flipped_shape.png)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Θα πρέπει να χρησιμοποιήσω δείκτη συλλογής ως αναγνωριστικό σχήματος;**

Μόνο για βραχυπρόθεσμη επεξεργασία όταν η συλλογή δεν θα αλλάξει πριν χρησιμοποιηθεί ο δείκτης. Προτιμήστε μια επικυρωμένη σύμβαση `Name` ή `AlternativeText` για πρότυπα που έχουν δημιουργηθεί, ή `OfficeInteropShapeId` για εργασία interop σε επίπεδο διαφάνειας.

**Αφαιρεί η απόκρυψη ενός σχήματος το z‑order;**

Όχι. Ένα κρυμμένο σχήμα παραμένει στη συλλογή με τον ίδιο δείκτη. Μπορεί να βρεθεί, να αναδιαταχθεί, να επεξεργαστεί ή να γίνει ορατό ξανά.

**Γιατί ένα κλωνοποιημένο σχήμα εμφανίστηκε μπροστά από άλλο σχήμα;**

Το `addClone` προσθέτει το κλώνο στο τέλος της συλλογής, που αποτελεί το μπροστινό μέρος του z‑order. Χρησιμοποιήστε `insertClone` για να επιλέξετε τον αρχικό δείκτη ή `reorder` μετά την προσθήκη όλων των σχημάτων.

**Μπορώ να χρησιμοποιήσω σταθερό δείκτη για την ταυτοποίηση προρυθμισμένης ρύθμισης σχήματος;**

Μόνο μετά από επικύρωση του ακριβούς προτύπου και της διάταξης της συλλογής. Προτιμήστε την επανάληψη μέσω `GeometryShape.getAdjustments` και τον έλεγχο του `AdjustValue.getType`; χρησιμοποιήστε το `AdjustValue.getName` ως πρόσθετη πληροφορία όταν εμφανίζεται ο ίδιος σημασιολογικός τύπος περισσότερες από μία φορές.