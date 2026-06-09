---
title: Προσθήκη Σχημάτων Γραμμής σε Παρουσιάσεις στο Android
linktitle: Γραμμή
type: docs
weight: 50
url: /el/androidjava/Line/
keywords:
- γραμμή
- δημιουργία γραμμής
- προσθήκη γραμμής
- απλή γραμμή
- ρύθμιση γραμμής
- προσαρμογή γραμμής
- στυλ παύλας
- κεφαλή βέλους
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να χειρίζεστε τη μορφοποίηση γραμμών σε παρουσιάσεις PowerPoint με το Aspose.Slides για Android. Ανακαλύψτε ιδιότητες, μεθόδους και παραδείγματα Java."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να προσθέτετε σχήματα γραμμών σε διαφάνειες PowerPoint προγραμματιστικά. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια απλή γραμμή και πώς να προσαρμόσετε μια γραμμή ώστε να εμφανίζεται ως βέλος.

Θα μάθετε πώς να προσθέσετε ένα σχήμα γραμμής σε μια διαφάνεια, να ρυθμίσετε την οπτική της εμφάνιση και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Τα παραδείγματα εστιάζουν σε πρακτικές ρυθμίσεις μορφοποίησης γραμμής όπως στυλ, πλάτος, μοτίβο παύλας, επιλογές κεφαλής βέλους και χρώμα γεμίσματος.

## **Δημιουργία Απλής Γραμμής**

Για να προσθέσετε μια απλή γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
- Αποκτήστε τη αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που παρέχεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection).
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε μια γραμμή στην πρώτη διαφάνεια της παρουσίασης.

```java
// Δημιουργία εμφάνισης της κλάσης PresentationEx που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Προσθήκη AutoShape τύπου γραμμής
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Γράψιμο του PPTX στο δίσκο
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Δημιουργία Γραμμής Σχήματος Βέλους**

Aspose.Slides for Android μέσω Java επίσης επιτρέπει στους προγραμματιστές να ρυθμίζουν ορισμένες ιδιότητες της γραμμής ώστε να φαίνεται πιο ελκυστική. Ας δοκιμάσουμε να ρυθμίσουμε μερικές ιδιότητες μιας γραμμής ώστε να μοιάζει με βέλος. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
- Αποκτήστε τη αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που παρέχεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection).
- Ορίστε το [Line Style](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LineStyle) σε ένα από τα στυλ που προσφέρει το Aspose.Slides for Android μέσω Java.
- Ορίστε το Width της γραμμής.
- Ορίστε το [Dash Style](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LineDashStyle) της γραμμής σε ένα από τα στυλ που προσφέρει το Aspose.Slides for Android μέσω Java.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LineArrowheadStyle) και το [Length](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LineArrowheadLength) του σημείου εκκίνησης της γραμμής.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LineArrowheadStyle) και το [Length](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LineArrowheadLength) του σημείου τερματισμού της γραμμής.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργία αντικειμένου PresentationEx που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη AutoShape τύπου γραμμής
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Εφαρμογή κάποιων μορφοποιήσεων στη γραμμή
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Γράψιμο του PPTX στο δίσκο
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια κανονική γραμμή σε σύνδεσμο ώστε να "προσαρμόζεται" σε σχήματα;**

Όχι. Μια κανονική γραμμή (ένα [AutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/autoshape/) τύπου [Line](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapetype/)) δεν γίνεται αυτόματα σύνδεσμος. Για να προσαρμοστεί σε σχήματα, χρησιμοποιήστε τον ειδικό τύπο [Connector](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/connector/) και τις [corresponding APIs](/slides/el/androidjava/connector/) για συνδέσεις.

**Τι πρέπει να κάνω αν οι ιδιότητες μιας γραμμής κληρονομούνται από το θέμα και είναι δύσκολο να προσδιοριστούν οι τελικές τιμές;**

Διαβάστε τις αποτελεσματικές ιδιότητες [/slides/el/androidjava/shape-effective-properties/] μέσω των διεπαφών [ILineFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — αυτές λαμβάνουν ήδη υπόψη την κληρονομικότητα και τα στυλ του θέματος.

**Μπορώ να κλειδώσω μια γραμμή ώστε να μην μπορεί να επεξεργαστεί (μετακίνηση, αλλαγή μεγέθους);**

Ναι. Τα σχήματα παρέχουν [lock objects](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) που σας επιτρέπουν να απαγορεύσετε λειτουργίες επεξεργασίας.