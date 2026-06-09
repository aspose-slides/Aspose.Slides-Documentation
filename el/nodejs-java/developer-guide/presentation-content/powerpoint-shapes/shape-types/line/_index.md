---
title: Προσθήκη Σχημάτων Γραμμής σε Παρουσιάσεις με JavaScript
linktitle: Γραμμή
type: docs
weight: 50
url: /el/nodejs-java/line/
keywords:
- γραμμή
- δημιουργία γραμμής
- προσθήκη γραμμής
- απλή γραμμή
- διαμόρφωση γραμμής
- προσαρμογή γραμμής
- στυλ παύλας
- άκρο βέλους
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να διαχειριστείτε τη μορφοποίηση γραμμών σε παρουσιάσεις PowerPoint με JavaScript και Aspose.Slides για Node.js. Ανακαλύψτε ιδιότητες, μεθόδους και παραδείγματα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να προσθέτετε σχήματα γραμμών στις διαφάνειες PowerPoint προγραμματιστικά. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια απλή γραμμή και πώς να προσαρμόσετε μια γραμμή ώστε να εμφανίζεται ως βέλος.

Θα μάθετε πώς να προσθέσετε ένα σχήμα γραμμής σε μια διαφάνεια, να προσαρμόσετε την οπτική της εμφάνιση και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Τα παραδείγματα εστιάζουν σε πρακτικές ρυθμίσεις μορφοποίησης γραμμής όπως στυλ, πλάτος, μοτίβο παύλας, επιλογές άκρων βέλους και χρώμα γεμίσματος.

## **Δημιουργία Απλής Γραμμής**

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection).
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε μια γραμμή στην πρώτη διαφάνεια της παρουσίασης.

```javascript
// Δημιουργήστε ένα στιγμιότυπο της κλάσης PresentationEx που αντιπροσωπεύει το αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Προσθέστε ένα AutoShape τύπου γραμμή
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Αποθηκεύστε το PPTX στον δίσκο
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Δημιουργία Γραμμής σε Σχήμα Βέλους**

Το Aspose.Slides για Node.js μέσω Java επιτρέπει επίσης στους προγραμματιστές να διαμορφώσουν ορισμένες ιδιότητες της γραμμής ώστε να φαίνεται πιο ελκυστική. Ας προσπαθήσουμε να διαμορφώσουμε μερικές ιδιότητες μιας γραμμής ώστε να μοιάζει με βέλος. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection).
- Ορίστε το [Line Style](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/LineStyle) σε ένα από τα στυλ που προσφέρει το Aspose.Slides για Node.js μέσω Java.
- Ορίστε το Width της γραμμής.
- Ορίστε το [Dash Style](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/LineDashStyle) της γραμμής σε ένα από τα στυλ που προσφέρει το Aspose.Slides για Node.js μέσω Java.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/LineArrowheadStyle) και το [Length](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/LineArrowheadLength) του αρχικού σημείου της γραμμής.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/LineArrowheadStyle) και το [Length](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/LineArrowheadLength) του τελικού σημείου της γραμμής.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```javascript
// Δημιουργήστε ένα στιγμιότυπο της κλάσης PresentationEx που αντιπροσωπεύει το αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Προσθέστε ένα AutoShape τύπου γραμμή
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Εφαρμόστε κάποιες μορφοποιήσεις στη γραμμή
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Αποθηκεύστε το PPTX στον δίσκο
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια κανονική γραμμή σε σύνδεσμο ώστε να «προσκολλάται» σε σχήματα;**

Όχι. Μια κανονική γραμμή (ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) τύπου [Line](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapetype/)) δεν μετατρέπεται αυτόματα σε σύνδεσμο. Για να προσκολλάται σε σχήματα, χρησιμοποιήστε τον ειδικό τύπο [Connector](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/connector/) και τις [αντίστοιχες API](/slides/el/nodejs-java/connector/) για συνδέσεις.

**Τι πρέπει να κάνω εάν οι ιδιότητες μιας γραμμής κληρονομούνται από το θέμα και είναι δύσκολο να προσδιοριστούν οι τελικές τιμές;**

[Διαβάστε τις αποτελεσματικές ιδιότητες](/slides/el/nodejs-java/shape-effective-properties/) μέσω των κλάσεων `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` — αυτά ήδη λαμβάνουν υπόψη την κληρονομικότητα και τα στυλ του θέματος.

**Μπορώ να κλειδώσω μια γραμμή ώστε να μην μπορεί να επεξεργαστεί (μετακινηθεί, αλλάξει μέγεθος);**

Ναι. Τα σχήματα παρέχουν [lock objects](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/getautoshapelock/) που επιτρέπουν να απαγορεύσετε τις λειτουργίες επεξεργασίας.