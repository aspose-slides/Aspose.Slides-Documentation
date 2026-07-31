---
title: Πρόσθεση Σχημάτων Γραμμής σε Παρουσιάσεις σε Java
linktitle: Γραμμή
type: docs
weight: 50
url: /el/java/line/
keywords:
- γραμμή
- δημιουργία γραμμής
- προσθήκη γραμμής
- απλή γραμμή
- διαμόρφωση γραμμής
- προσαρμογή γραμμής
- στυλ παύλας
- κεφαλή βέλους
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τη μορφοποίηση γραμμών σε παρουσιάσεις PowerPoint με το Aspose.Slides για Java. Ανακαλύψτε ιδιότητες, μεθόδους και παραδείγματα."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να προσθέσετε σχήματα γραμμής σε διαφάνειες PowerPoint προγραμματιστικά. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια απλή γραμμή και πώς να προσαρμόσετε μια γραμμή ώστε να εμφανίζεται ως βέλος.

Θα μάθετε πώς να προσθέσετε ένα σχήμα γραμμής σε μια διαφάνεια, να προσαρμόσετε την οπτική του εμφάνιση και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Τα παραδείγματα εστιάζουν σε πρακτικές ρυθμίσεις μορφοποίησης γραμμής όπως στυλ, πλάτος, μοτίβο παύλας, επιλογές κεφαλής βέλους και χρώμα γεμίσματος.

## **Δημιουργία Απλής Γραμμής**

Για να προσθέσετε μια απλή γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection) .
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε μια γραμμή στην πρώτη διαφάνεια της παρουσίασης.

```java
// Δημιουργία αντικειμένου PresentationEx που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Προσθήκη AutoShape τύπου γραμμής
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Αποθήκευση του PPTX στον δίσκο
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Δημιουργία Γραμμής σε Σχήμα Βέλους**

Το Aspose.Slides για Java επιτρέπει επίσης στους προγραμματιστές να διαμορφώσουν ορισμένες ιδιότητες της γραμμής ώστε να είναι πιο ελκυστική. Ας προσπαθήσουμε να διαμορφώσουμε μερικές ιδιότητες μιας γραμμής ώστε να φαίνεται σαν βέλος. Ακολουθήστε τα παρακάτω βήματα για να το κάνετε:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection) .
- Ορίστε το [Line Style](https://reference.aspose.com/slides/el/java/com.aspose.slides/LineStyle) σε ένα από τα στυλ που προσφέρει το Aspose.Slides για Java.
- Ορίστε το Πλάτος της γραμμής.
- Ορίστε το [Dash Style](https://reference.aspose.com/slides/el/java/com.aspose.slides/LineDashStyle) της γραμμής σε ένα από τα στυλ που προσφέρει το Aspose.Slides για Java.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/java/com.aspose.slides/LineArrowheadStyle) και το [Length](https://reference.aspose.com/slides/el/java/com.aspose.slides/LineArrowheadLength) του σημείου εκκίνησης της γραμμής.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/java/com.aspose.slides/LineArrowheadStyle) και το [Length](https://reference.aspose.com/slides/el/java/com.aspose.slides/LineArrowheadLength) του τελικού σημείου της γραμμής.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργία κλάσης PresentationEx που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη AutoShape τύπου γραμμής
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Εφαρμογή κάποιου μορφοποίησης στη γραμμή
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Αποθήκευση του PPTX στον δίσκο
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια κανονική γραμμή σε συνδετήρα ώστε να «προσαρμόζεται» στα σχήματα;**

Όχι. Μια κανονική γραμμή (ένα [AutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/autoshape/) τύπου [Line](https://reference.aspose.com/slides/el/java/com.aspose.slides/shapetype/)) δεν μετατρέπεται αυτόματα σε συνδετήρα. Για να την προσαρμόσετε στα σχήματα, χρησιμοποιήστε τον ειδικό τύπο [Connector](https://reference.aspose.com/slides/el/java/com.aspose.slides/connector/) και τα [corresponding APIs](/slides/el/java/connector/) για συνδέσεις.

**Τι πρέπει να κάνω αν οι ιδιότητες μιας γραμμής κληρονομούνται από το θέμα και είναι δύσκολο να προσδιορίσω τις τελικές τιμές;**

Διαβάστε τις αποτελεσματικές ιδιότητες (/slides/el/java/shape-effective-properties/) μέσω των διεπαφών [ILineFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinefillformateffectivedata/) — αυτές λαμβάνουν ήδη υπόψη την κληρονόμηση και τα στυλ του θέματος.

**Μπορώ να κλειδώσω μια γραμμή απέναντι στην επεξεργασία (μετακίνηση, αλλαγή μεγέθους);**

Ναι. Τα σχήματα παρέχουν [lock objects](https://reference.aspose.com/slides/el/java/com.aspose.slides/autoshape/#getAutoShapeLock--) που σας επιτρέπουν να [disallow editing operations](/slides/el/java/applying-protection-to-presentation/).