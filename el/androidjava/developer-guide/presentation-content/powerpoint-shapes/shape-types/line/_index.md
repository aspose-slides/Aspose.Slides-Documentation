---
title: Προσθήκη Σχημάτων Γραμμής σε Παρουσιάσεις στο Android
linktitle: Γραμμή
type: docs
weight: 50
url: /el/androidjava/line/
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
description: "Μάθετε πώς να χειρίζεστε τη μορφοποίηση γραμμής σε παρουσιάσεις PowerPoint με το Aspose.Slides for Android. Ανακαλύψτε ιδιότητες, μεθόδους και παραδείγματα Java."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να προσθέτετε σχήματα γραμμής στις διαφάνειες PowerPoint προγραμματιστικά. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια απλή γραμμή και πώς να προσαρμόσετε μια γραμμή ώστε να εμφανίζεται ως βέλος.

Θα μάθετε πώς να προσθέσετε ένα σχήμα γραμμής σε μια διαφάνεια, να προσαρμόσετε την οπτική του εμφάνιση και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Τα παραδείγματα εστιάζουν σε πρακτικές ρυθμίσεις μορφοποίησης γραμμής όπως στυλ, πλάτος, μοτίβο παύλας, επιλογές κεφαλής βέλους και χρώμα γεμίσματος.

## **Δημιουργία Απλής Γραμμής**

Για να προσθέσετε μια απλή γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection).
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε μια γραμμή στην πρώτη διαφάνεια της παρουσίασης.

```java
// Δημιουργία αντικειμένου PresentationEx που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Προσθήκη AutoShape τύπου γραμμή
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Αποθήκευση του PPTX στο δίσκο
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Δημιουργία Γραμμής σε Σχήμα Βέλους**

Το Aspose.Slides for Android μέσω Java επιτρέπει επίσης στους προγραμματιστές να διαμορφώσουν ορισμένες ιδιότητες της γραμμής ώστε να φαίνεται πιο ελκυστική. Ας προσπαθήσουμε να ρυθμίσουμε μερικές ιδιότητες μιας γραμμής ώστε να εμφανίζεται ως βέλος. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection).
- Ορίστε το [Line Style](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LineStyle) σε ένα από τα στυλ που προσφέρει το Aspose.Slides for Android μέσω Java.
- Ορίστε το Width της γραμμής.
- Ορίστε το [Dash Style](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LineDashStyle) της γραμμής σε ένα από τα στυλ που προσφέρει το Aspose.Slides for Android μέσω Java.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LineArrowheadStyle) και το [Length](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LineArrowheadLength) του σημείου εκκίνησης της γραμμής.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LineArrowheadStyle) και το [Length](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/LineArrowheadLength) του σημείου λήξης της γραμμής.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργία αντικειμένου PresentationEx που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη AutoShape τύπου γραμμή
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

    // Αποθήκευση του PPTX στο δίσκο
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια κανονική γραμμή σε σύνδεσμο ώστε να «προσαρμόζεται» σε σχήματα;**

Όχι. Μια κανονική γραμμή (ένα [AutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/autoshape/) τύπου [Line](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapetype/)) δεν μετατρέπεται αυτόματα σε σύνδεσμο. Για να την κάνετε να προσαρμόζεται σε σχήματα, χρησιμοποιήστε τον ειδικό τύπο [Connector](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/connector/) και τις [corresponding APIs](/slides/el/androidjava/connector/) για συνδέσεις.

**Τι πρέπει να κάνω εάν οι ιδιότητες μιας γραμμής κληρονομούνται από το θέμα και είναι δύσκολο να προσδιοριστούν οι τελικές τιμές;**

[Read the effective properties](/slides/el/androidjava/shape-effective-properties/) μέσω των διεπαφών [ILineFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — αυτές ήδη λαμβάνουν υπόψη την κληρονομικότητα και τα στυλ του θέματος.

**Μπορώ να κλειδώσω μια γραμμή ώστε να μην επεξεργαστεί (μετακίνηση, αλλαγή μεγέθους);**

Ναι. Τα σχήματα παρέχουν [lock objects](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) που σας επιτρέπουν να απαγορεύσετε λειτουργίες επεξεργασίας.