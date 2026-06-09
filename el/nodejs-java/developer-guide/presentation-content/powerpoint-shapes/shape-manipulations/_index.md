---
title: Διαχείριση Σχημάτων Παρουσίασης σε JavaScript
linktitle: Χειρισμός Σχημάτων
type: docs
weight: 40
url: /el/nodejs-java/shape-manipulations/
keywords:
- Σχήμα PowerPoint
- Σχήμα Παρουσίασης
- Σχήμα στη Διαφάνεια
- Εύρεση Σχήματος
- Κλωνοποίηση Σχήματος
- Αφαίρεση Σχήματος
- Απόκρυψη Σχήματος
- Αλλαγή Σειράς Σχήματος
- Λήψη Interop Shape ID
- Εναλλακτικό Κείμενο Σχήματος
- Μορφές Διάταξης Σχήματος
- Σχήμα ως SVG
- Μετατροπή Σχήματος σε SVG
- Στοίχιση Σχήματος
- PowerPoint
- Παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε, επεξεργάζεστε και βελτιστοποιείτε σχήματα χρησιμοποιώντας JavaScript και Aspose.Slides για Node.js μέσω Java και να παραδίδετε παρουσιάσεις PowerPoint υψηλής απόδοσης."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με σχήματα σε παρουσιάσεις χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να βρείτε ένα σχήμα σε μια διαφάνεια, να το κλωνοποιήσετε, να το αφαιρέσετε, να το κρύψετε, να αλλάξετε τη σειρά του, να λάβετε το Interop ID του σχήματος και να ορίσετε εναλλακτικό κείμενο για την ταυτοποίηση και περαιτέρω επεξεργασία.

Επιπλέον, καλύπτει πώς να αποκτήσετε πρόσβαση σε μορφές διάταξης για σχήματα, να αποδώσετε ένα σχήμα ως SVG, να ευθυγραμμίσετε σχήματα σε μια διαφάνεια και να χρησιμοποιήσετε τις ιδιότητες αναστροφής για οριζόντια και κάθετη καθρέφτιση. Επιπλέον, το άρθρο περιλαμβάνει μια σύντομη FAQ σχετικά με τον συνδυασμό σχημάτων, τη σειρά στοίβαξης και το κλείδωμα σχημάτων.

## **Εύρεση Σχήματος σε Διαφάνεια**
Αυτό το θέμα θα περιγράψει μια απλή τεχνική για να διευκολυνθεί η εύρεση ενός συγκεκριμένου σχήματος σε μια διαφάνεια χωρίς τη χρήση του εσωτερικού του αναγνωριστικού. Είναι σημαντικό να γνωρίζετε ότι τα αρχεία παρουσίασης PowerPoint δεν διαθέτουν κανέναν τρόπο να ταυτοποιούν σχήματα σε μια διαφάνεια εκτός από ένα εσωτερικό μοναδικό Id. Φαίνεται δύσκολο για τους προγραμματιστές να βρουν ένα σχήμα χρησιμοποιώντας το εσωτερικό μοναδικό Id. Όλα τα σχήματα που προστίθενται στις διαφάνειες έχουν κάποιο Alt Text. Συνιστούμε στους προγραμματιστές να χρησιμοποιούν εναλλακτικό κείμενο για την εύρεση ενός συγκεκριμένου σχήματος. Μπορείτε να χρησιμοποιήσετε το MS PowerPoint για να ορίσετε το εναλλακτικό κείμενο για αντικείμενα που σκοπεύετε να αλλάξετε στο μέλλον.

Αφού ορίσετε το εναλλακτικό κείμενο σε οποιοδήποτε επιθυμητό σχήμα, μπορείτε στη συνέχεια να ανοίξετε αυτήν την παρουσίαση χρησιμοποιώντας το Aspose.Slides for Node.js via Java και να επαναλάβετε όλα τα σχήματα που έχουν προστεθεί σε μια διαφάνεια. Κατά τη διάρκεια κάθε επανάληψης, μπορείτε να ελέγξετε το εναλλακτικό κείμενο του σχήματος και το σχήμα με το αντίστοιχο εναλλακτικό κείμενο θα είναι το σχήμα που χρειάζεστε. Για να παρουσιάσουμε αυτήν την τεχνική με καλύτερο τρόπο, δημιουργήσαμε τη μέθοδο [findShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) που κάνει την δουλειά να βρει ένα συγκεκριμένο σχήμα σε μια διαφάνεια και στη συνέχεια επιστρέφει απλώς εκείνο το σχήμα.

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Εναλλακτικό κείμενο του σχήματος που θα βρεθεί
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **Κλωνοποίηση Σχήματος**
Για να κλωνοποιήσετε ένα σχήμα σε μια διαφάνεια χρησιμοποιώντας το Aspose.Slides for Node.js via Java:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Πρόσβαση στη συλλογή σχημάτων της πηγαίας διαφάνειας.
1. Προσθήκη νέας διαφάνειας στην παρουσία.
1. Κλωνοποιήστε σχήματα από τη συλλογή σχημάτων της πηγαίας διαφάνειας στη νέα διαφάνεια.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει ένα σχήμα ομάδας σε μια διαφάνεια.

```javascript
// Δημιουργία αντικειμένου Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Αποθήκευση του αρχείου PPTX στο δίσκο
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αφαίρεση Σχήματος**
Το Aspose.Slides for Node.js via Java επιτρέπει στους προγραμματιστές να αφαιρέσουν οποιοδήποτε σχήμα. Για να αφαιρέσετε το σχήμα από οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Βρείτε το σχήμα με συγκεκριμένο AlternativeText.
1. Αφαιρέστε το σχήμα.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```javascript
// Δημιουργία αντικειμένου Presentation
var pres = new aspose.slides.Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    var sld = pres.getSlides().get_Item(0);
    // Προσθήκη αυτόματου σχήματος τύπου ορθογωνίου
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Αποθήκευση παρουσίασης στο δίσκο
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Απόκρυψη Σχήματος**
Το Aspose.Slides for Node.js via Java επιτρέπει στους προγραμματιστές να κρύψουν οποιοδήποτε σχήμα. Για να κρύψετε το σχήμα από οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Βρείτε το σχήμα με συγκεκριμένο AlternativeText.
1. Κρύψτε το σχήμα.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
var pres = new aspose.slides.Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    var sld = pres.getSlides().get_Item(0);
    // Προσθήκη αυτόματου σχήματος τύπου ορθογωνίου
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Αποθήκευση παρουσίασης στο δίσκο
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αλλαγή Σειράς Σχημάτων**
Το Aspose.Slides for Node.js via Java επιτρέπει στους προγραμματιστές να αλλάξουν τη σειρά των σχημάτων. Η αλλαγή σειράς καθορίζει ποιο σχήμα είναι μπροστά ή ποιο είναι στο βάθος. Για να αλλάξετε τη σειρά των σχημάτων σε οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε ένα σχήμα.
1. Προσθέστε κάποιο κείμενο στο πλαίσιο κειμένου του σχήματος.
1. Προσθέστε ένα άλλο σχήμα με τις ίδιες συντεταγμένες.
1. Αλλάξτε τη σειρά των σχημάτων.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Λήψη Interop Shape ID**
Το Aspose.Slides for Node.js via Java επιτρέπει στους προγραμματιστές να λάβουν ένα μοναδικό αναγνωριστικό σχήματος σε επίπεδο διαφάνειας, σε αντίθεση με τη μέθοδο [getUniqueId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getUniqueId--) που παρέχει μοναδικό αναγνωριστικό σε επίπεδο παρουσίασης. Η μέθοδος [getOfficeInteropShapeId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) προστέθηκε στην κλάση [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape) και η τιμή που επιστρέφει αντιστοιχεί στο Id του αντικειμένου Microsoft.Office.Interop.PowerPoint.Shape. Παρακάτω δίνεται ένα δείγμα κώδικα.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Λήψη μοναδικού αναγνωριστικού σχήματος σε επίπεδο διαφάνειας
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Εναλλακτικού Κειμένου για Σχήμα**
Το Aspose.Slides for Node.js via Java επιτρέπει στους προγραμματιστές να ορίσουν AlternateText για οποιοδήποτε σχήμα. Τα σχήματα σε μια παρουσίαση μπορούν να διακριθούν με τη μέθοδο [AlternativeText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) ή [Shape Name](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#setName-java.lang.String-). Οι μέθοδοι [setAlternativeText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) και [getAlternativeText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#getAlternativeText--) μπορούν να διαβαστούν ή να οριστούν χρησιμοποιώντας το Aspose.Slides καθώς και το Microsoft PowerPoint. Χρησιμοποιώντας αυτήν τη μέθοδο, μπορείτε να ετικετοποιήσετε ένα σχήμα και να εκτελέσετε διαφορετικές λειτουργίες όπως Αφαίρεση σχήματος, Απόκρυψη σχήματος ή Αναδιάταξη σχημάτων σε μια διαφάνεια. Για να ορίσετε το AlternateText ενός σχήματος, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε οποιοδήποτε σχήμα στη διαφάνεια.
1. Εκτελέστε κάποιες εργασίες με το νεοπροστεθειμένο σχήμα.
1. Περιηγηθείτε στα σχήματα για να βρείτε ένα σχήμα.
1. Ορίστε το AlternativeText.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
var pres = new aspose.slides.Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    var sld = pres.getSlides().get_Item(0);
    // Προσθήκη αυτόματου σχήματος τύπου ορθογωνίου
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Αποθήκευση παρουσίασης στο δίσκο
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Πρόσβαση σε Μορφές Διάταξης για Σχήμα**
Το Aspose.Slides for Node.js via Java παρέχει ένα απλό API για πρόσβαση σε μορφές διάταξης για ένα σχήμα. Το άρθρο αυτό δείχνει πώς μπορείτε να έχετε πρόσβαση σε μορφές διάταξης.

Παρατίθεται παρακάτω δείγμα κώδικα.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Απόδοση Σχήματος ως SVG**
Τώρα το Aspose.Slides for Node.js via Java υποστηρίζει την απόδοση ενός σχήματος ως SVG. Η μέθοδος [writeAsSvg](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (και η υπερφόρτωσή της) προστέθηκε στην κλάση [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape). Αυτή η μέθοδος επιτρέπει την αποθήκευση του περιεχομένου του σχήματος ως αρχείο SVG. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να εξάγετε το σχήμα της διαφάνειας σε αρχείο SVG.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Στοίχιση Σχημάτων**
Το Aspose.Slides επιτρέπει την στοίχιση σχημάτων είτε σχετικά με τα περιθώρια της διαφάνειας είτε μεταξύ τους. Για το σκοπό αυτό, προστέθηκε η υπερφορτωμένη μέθοδος [SlidesUtil.alignShape()](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-). Η ακολουθία [ShapesAlignmentType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapesAlignmentType) ορίζει τις πιθανές επιλογές στοίχισης.

**Παράδειγμα 1**

Ο κώδικας παρακάτω στοιχίζει τα σχήματα με δείκτες 1,2 και 4 κατά μήκος του άνω άκρου της διαφάνειας.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Παράδειγμα 2**

Το παρακάτω παράδειγμα δείχνει πώς να στοιχίσετε ολόκληρη τη συλλογή σχημάτων σε σχέση με το πιο κάτω σχήμα της συλλογής.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ιδιότητες Αναστροφής**

Στο Aspose.Slides, η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapeframe/) παρέχει έλεγχο πάνω στην οριζόντια και κάθετη καθρέφτιση των σχημάτων μέσω των ιδιοτήτων `flipH` και `flipV`. Και οι δύο ιδιότητες είναι τύπου `byte`, επιτρέποντας τιμές `1` για αναστροφή, `0` για μη αναστροφή ή `-1` για προεπιλεγμένη συμπεριφορά. Αυτές οι τιμές είναι προσβάσιμες από το [Frame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getFrame) ενός σχήματος.

Για να τροποποιήσετε τις ρυθμίσεις αναστροφής, δημιουργείται μια νέα παρουσία της κλάσης [ShapeFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapeframe/) με την τρέχουσα θέση και μέγεθος του σχήματος, τις επιθυμητές τιμές για `flipH` και `flipV` και τη γωνία περιστροφής. Η ανάθεση αυτής της παρουσίας στο [Frame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getFrame) του σχήματος και η αποθήκευση της παρουσίασης εφαρμόζει τις μετασχηματίσεις καθρέφτισης και τις εγγράφει στο αρχείο εξόδου.

Ας υποθέσουμε ότι έχουμε ένα αρχείο sample.pptx στο οποίο η πρώτη διαφάνεια περιέχει ένα μόνο σχήμα με προεπιλεγμένες ρυθμίσεις αναστροφής, όπως φαίνεται παρακάτω.

![Το σχήμα προς αναστροφή](shape_to_be_flipped.png)

Το παρακάτω παράδειγμα κώδικα ανακτά τις τρέχουσες ιδιότητες αναστροφής του σχήματος και το αναστρέφει τόσο οριζόντια όσο και κάθετα.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Ανάγνωση της ιδιότητας οριζόντιας αναστροφής του σχήματος.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Ανάγνωση της ιδιότητας κάθετης αναστροφής του σχήματος.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Αναστροφή οριζόντια.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Αναστροφή κάθετα.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Το αναστραμμένο σχήμα](flipped_shape.png)

## **FAQ**

**Μπορώ να συνδυάσω σχήματα (union/intersect/subtract) σε μια διαφάνεια όπως σε έναν επεξεργαστή επιφάνειας εργασίας;**

Δεν υπάρχει ενσωματωμένο API Boolean λειτουργιών. Μπορείτε να προσεγγίσετε τη λειτουργία δημιουργώντας το επιθυμητό περίγραμμα μόνοι σας — π.χ., υπολογίζοντας τη γεωμετρία (μέσω [GeometryPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/geometrypath/)) και δημιουργώντας νέο σχήμα με αυτό το περίγραμμα, προαιρετικά αφαιρώντας τα αρχικά.

**Πώς μπορώ να ελέγξω τη σειρά στοίβαξης (z-order) ώστε ένα σχήμα να παραμένει πάντα «πάνω»;**

Αλλάξτε τη σειρά εισαγωγής ή μετακίνησης εντός της συλλογής [shapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/#getShapes) της διαφάνειας. Για προβλέψιμα αποτελέσματα, τελειώστε τη σειρά z-order μετά από όλες τις άλλες τροποποιήσεις της διαφάνειας.

**Μπορώ να «κλειδώσω» ένα σχήμα ώστε να αποτρέψω τους χρήστες από το να το επεξεργαστούν στο PowerPoint;**

Ναι. Ορίστε σημαίες προστασίας σε επίπεδο σχήματος (π.χ., κλείδωμα επιλογής, κίνησης, αλλαγής μεγέθους, επεξεργασίας κειμένου). Αν χρειάζεται, επεκτείνετε τους περιορισμούς στον κύριο ή στη διάταξη. Σημειώστε ότι αυτό είναι προστασία σε επίπεδο UI, όχι λειτουργία ασφαλείας· για ισχυρότερη προστασία, συνδυάστε με περιορισμούς αρχείου όπως προτάσεις ανάγνωσης μόνο ή κωδικούς πρόσβασης.