---
title: Πρόσθεση Ορθογωνίων σε Παρουσιάσεις σε JavaScript
linktitle: Ορθογώνιο
type: docs
weight: 80
url: /el/nodejs-java/rectangle/
keywords:
- προσθήκη ορθογωνίου
- δημιουργία ορθογωνίου
- σχήμα ορθογωνίου
- απλό ορθογώνιο
- διαμορφωμένο ορθογώνιο
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Αυξήστε τις παρουσιάσεις PowerPoint προσθέτοντας ορθογώνια με JavaScript και Aspose.Slides για Node.js—Σχεδιάζετε και τροποποιείτε σχήματα προγραμματιστικά με ευκολία."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να προσθέσετε σχήματα ορθογωνίου στις διαφάνειες του PowerPoint χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη δημιουργία ενός απλού ορθογωνίου, τη δημιουργία ενός διαμορφωμένου ορθογωνίου και την αποθήκευση της ενημερωμένης παρουσίασης ως αρχείο PPTX.

Θα δείτε επίσης πώς να εφαρμόσετε βασική μορφοποίηση ορθογωνίου, όπως γεμισμό στερεόχρωμο, χρώμα γραμμής και πάχος γραμμής. Επιπλέον, οι Συχνές Ερωτήσεις του άρθρου παραπέμπουν σε σχετικές εργασίες με ορθογώνια, όπως στρογγυλεμένες γωνίες, γεμίσματα εικόνας, οπτικά εφέ, υπερσυνδέσεις, κλειδώματα σχημάτων, επιλογές εξαγωγής και αποτελεσματικές ιδιότητες. 

## **Προσθήκη Ορθογωνίου στη Διαφάνεια**

Όπως και στα προηγούμενα θέματα, αυτό αφορά επίσης την προσθήκη ενός σχήματος και αυτή τη φορά το σχήμα που θα συζητήσουμε είναι το Ορθογώνιο. Σε αυτό το θέμα, περιγράψαμε πώς οι προγραμματιστές μπορούν να προσθέσουν απλά ή διαμορφωμένα ορθογώνια στις διαφάνειές τους χρησιμοποιώντας το Aspose.Slides. 

Για να προσθέσετε ένα απλό ορθογώνιο στη επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) τύπου Rectangle χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection).
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ανάκτηση της πρώτης διαφάνειας
    var sld = pres.getSlides().get_Item(0);
    // Προσθήκη AutoShape τύπου έλλειψης
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Αποθήκευση του αρχείου PPTX στο δίσκο
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Προσθήκη Διαμορφωμένου Ορθογωνίου στη Διαφάνεια**

Για να προσθέσετε ένα διαμορφωμένο ορθογώνιο σε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/AutoShape) τύπου Rectangle χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection).
- Ορίστε το [Fill Type](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FillType) του Ορθογωνίου σε Solid.
- Ορίστε το χρώμα του Ορθογωνίου χρησιμοποιώντας τη μέθοδο [SolidFillColor.setColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) όπως εκτίθεται από το αντικείμενο [FillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FillFormat) που συνδέεται με το αντικείμενο [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape).
- Ορίστε το χρώμα των γραμμών του Ορθογωνίου.
- Ορίστε το πάχος των γραμμών του Ορθογωνίου.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ανάκτηση της πρώτης διαφάνειας
    var sld = pres.getSlides().get_Item(0);
    // Προσθήκη AutoShape τύπου έλλειψης
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Εφαρμογή κάποιων μορφοποιήσεων στο σχήμα έλλειψης
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Εφαρμογή κάποιων μορφοποιήσεων στη γραμμή της έλλειψης
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Αποθήκευση του αρχείου PPTX στο δίσκο
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να προσθέσω ένα ορθογώνιο με στρογγυλεμένες γωνίες;**

Χρησιμοποιήστε τον τύπο σχήματος με στρογγυλεμένες γωνίες [shape type](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapetype/) και ρυθμίστε την ακτίνα των γωνιών στις ιδιότητες του σχήματος· η στρογγυλοποίηση μπορεί επίσης να εφαρμοστεί σε κάθε γωνία μέσω γεωμετρικών ρυθμίσεων.

**Πώς γεμίζω ένα ορθογώνιο με εικόνα (υφή);**

Επιλέξτε τον τύπο γεμίσματος εικόνας [fill type](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/), παρέχετε την πηγή της εικόνας και διαμορφώστε τις [stretching/tiling modes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillmode/).

**Μπορεί ένα ορθογώνιο να έχει σκιά και λάμψη;**

Ναι. Τα [Outer/inner shadow, glow, and soft edges](/slides/el/nodejs-java/shape-effect/) είναι διαθέσιμα με ρυθμιζόμενες παραμέτρους.

**Μπορώ να μετατρέψω ένα ορθογώνιο σε κουμπί με υπερσύνδεσμο;**

Ναι. [Assign a hyperlink](/slides/el/nodejs-java/manage-hyperlinks/) στο κλικ του σχήματος (μετάβαση σε διαφάνεια, αρχείο, διεύθυνση ιστού ή email).

**Πώς μπορώ να προστατέψω ένα ορθογώνιο από τη μετακίνηση και τις αλλαγές;**

Χρησιμοποιήστε κλειδώματα σχήματος: μπορείτε να απαγορεύσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή ή την επεξεργασία κειμένου για να διατηρήσετε τη διάταξη.

**Μπορώ να μετατρέψω ένα ορθογώνιο σε εικόνα raster ή SVG;**

Ναι. Μπορείτε να [render the shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getImage) σε εικόνα με συγκεκριμένο μέγεθος/κλίμακα ή να [export it as SVG](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/writeassvg/) για χρήση ως διανυσματική.

**Πώς μπορώ γρήγορα να λάβω τις πραγματικές (αποτελεσματικές) ιδιότητες ενός ορθογωνίου λαμβάνοντας υπόψη το θέμα και την κληρονομικότητα;**

[Χρησιμοποιήστε τις αποτελεσματικές ιδιότητες του σχήματος](/slides/el/nodejs-java/shape-effective-properties/): το API επιστρέφει υπολογισμένες τιμές που λαμβάνουν υπόψη τα στυλ θεμάτων, τη διάταξη και τις τοπικές ρυθμίσεις, απλοποιώντας την ανάλυση μορφοποίησης.