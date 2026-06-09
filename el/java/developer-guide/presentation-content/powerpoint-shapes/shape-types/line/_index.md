---
title: "Προσθήκη σχημάτων γραμμής σε παρουσιάσεις Java"
linktitle: "Γραμμή"
type: docs
weight: 50
url: /el/java/Line/
keywords:
- "γραμμή"
- "δημιουργία γραμμής"
- "προσθήκη γραμμής"
- "απλή γραμμή"
- "διαμόρφωση γραμμής"
- "προσαρμογή γραμμής"
- "στυλ διακεκοσμού"
- "κεφαλή βέλους"
- "PowerPoint"
- "παρουσίαση"
- "Java"
- "Aspose.Slides"
description: "Μάθετε πώς να χειρίζεστε τη μορφοποίηση γραμμών σε παρουσιάσεις PowerPoint με το Aspose.Slides για Java. Ανακαλύψτε ιδιότητες, μεθόδους και παραδείγματα."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να προσθέτετε σχήματα γραμμής σε διαφάνειες PowerPoint προγραμματιστικά. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια απλή γραμμή και πώς να προσαρμόσετε μια γραμμή ώστε να εμφανίζεται ως βέλος.

Θα μάθετε πώς να προσθέτετε ένα σχήμα γραμμής σε μια διαφάνεια, να ρυθμίζετε την οπτική του εμφάνιση και να αποθηκεύετε την ενημερωμένη παρουσίαση. Τα παραδείγματα εστιάζουν σε πρακτικές ρυθμίσεις μορφοποίησης γραμμής όπως το στυλ, το πλάτος, το μοτίβο διακεκοσμού, οι επιλογές κεφαλής βέλους και το χρώμα γεμίσματος.

## **Δημιουργία Απλής Γραμμής**

Για να προσθέσετε μια απλή ομαλή γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection).
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε μια γραμμή στην πρώτη διαφάνεια της παρουσίασης.

```java
// Δημιουργία αντικειμένου PresentationEx που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Ανάκτηση της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Προσθήκη AutoShape τύπου line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Αποθήκευση του PPTX στο δίσκο
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Δημιουργία Γραμμής σε Σχήμα Βέλους**

Το Aspose.Slides for Java επιτρέπει επίσης στους προγραμματιστές να διαμορφώσουν ορισμένες ιδιότητες της γραμμής ώστε να είναι πιο ελκυστική. Ας δοκιμάσουμε να διαμορφώσουμε μερικές ιδιότητες μιας γραμμής ώστε να μοιάζει με βέλος. Ακολουθήστε τα παρακάτω βήματα για να το κάνετε:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection).
- Ορίστε το [Line Style](https://reference.aspose.com/slides/el/java/com.aspose.slides/LineStyle) σε ένα από τα στυλ που προσφέρει το Aspose.Slides for Java.
- Ορίστε το Πλάτος της γραμμής.
- Ορίστε το [Dash Style](https://reference.aspose.com/slides/el/java/com.aspose.slides/LineDashStyle) της γραμμής σε ένα από τα στυλ που προσφέρει το Aspose.Slides for Java.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/java/com.aspose.slides/LineArrowheadStyle) και το [Length](https://reference.aspose.com/slides/el/java/com.aspose.slides/LineArrowheadLength) του σημείου έναρξης της γραμμής.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/java/com.aspose.slides/LineArrowheadStyle) και το [Length](https://reference.aspose.com/slides/el/java/com.aspose.slides/LineArrowheadLength) του σημείου λήξης της γραμμής.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργία αντικειμένου PresentationEx που αντιπροσωπεύει το αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Ανάκτηση της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη AutoShape τύπου line
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

Όχι. Μια κανονική γραμμή (ένα [AutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/autoshape/) τύπου [Line](https://reference.aspose.com/slides/el/java/com.aspose.slides/shapetype/)) δεν μετατρέπεται αυτόματα σε σύνδεσμο. Για να προσαρμόζεται σε σχήματα, χρησιμοποιήστε τον ειδικό τύπο [Connector](https://reference.aspose.com/slides/el/java/com.aspose.slides/connector/) και τις [αντίστοιχες API](/slides/el/java/connector/) για συνδέσεις.

**Τι πρέπει να κάνω εάν οι ιδιότητες μιας γραμμής κληρονομούνται από το θέμα και είναι δύσκολο να προσδιοριστούν οι τελικές τιμές;**

Διαβάστε τις αποτελεσματικές ιδιότητες (/slides/el/java/shape-effective-properties/) μέσω των διεπαφών [ILineFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinefillformateffectivedata/) — αυτές λαμβάνουν ήδη υπόψη την κληρονομιά και τα στυλ του θέματος.

**Μπορώ να κλειδώσω μια γραμμή ώστε να μην μπορεί να επεξεργαστεί (μετακινηθεί, τροποποιηθεί);**

Ναι. Τα σχήματα παρέχουν [lock objects](https://reference.aspose.com/slides/el/java/com.aspose.slides/autoshape/#getAutoShapeLock--) που σας επιτρέπουν να [απαγορεύσετε τις λειτουργίες επεξεργασίας](/slides/el/java/applying-protection-to-presentation/).