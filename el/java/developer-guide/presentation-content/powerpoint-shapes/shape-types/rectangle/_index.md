---
title: Προσθήκη Ορθογωνίων σε Παρουσιάσεις σε Java
linktitle: Ορθογώνιο
type: docs
weight: 80
url: /el/java/rectangle/
keywords:
- προσθήκη ορθογωνίου
- δημιουργία ορθογωνίου
- σχήμα ορθογωνίου
- απλό ορθογώνιο
- μορφοποιημένο ορθογώνιο
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Βελτιώστε τις παρουσιάσεις PowerPoint σας προσθέτοντας ορθογώνια με το Aspose.Slides για Java — σχεδιάστε και τροποποιήστε σχήματα προγραμματιστικά με ευκολία."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να προσθέσετε σχήματα ορθογώνιου σε διαφάνειες PowerPoint χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη δημιουργία ενός απλού ορθογωνίου, τη δημιουργία ενός μορφοποιημένου ορθογωνίου και την αποθήκευση της ενημερωμένης παρουσίασης ως αρχείο PPTX.

Θα δείτε επίσης πώς να εφαρμόσετε βασική μορφοποίηση ορθογωνίου, όπως γεμιστικό χρώμα συμπαγές, χρώμα γραμμής και πάχος γραμμής. Επιπλέον, η ενότητα Συχνές Ερωτήσεις του άρθρου παραπέμπει σε σχετικές εργασίες με ορθογώνια, όπως στρογγυλεμένες γωνίες, γεμίσματα εικόνας, οπτικά εφέ, υπερσυνδέσμους, κλειδώματα σχήματος, επιλογές εξαγωγής και αποτελεσματικές ιδιότητες.

## **Προσθήκη ορθογωνίου σε διαφάνεια**
- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape) τύπου Rectangle χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection) .
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, έχουμε προσθέσει ένα απλό ορθογώνιο στην πρώτη διαφάνεια της παρουσίασης.

```java
// Δημιουργία αντικειμένου κλάσης Presentation που αναπαριστά το PPTX
Presentation pres = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη AutoShape τύπου έλλειψης
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Αποθήκευση του αρχείου PPTX στο δίσκο
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσθήκη μορφοποιημένου ορθογωνίου σε διαφάνεια**
- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape) τύπου Rectangle χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection) .
- Ορίστε τον [Fill Type](https://reference.aspose.com/slides/el/java/com.aspose.slides/FillType) του Ορθογωνίου σε Solid.
- Ορίστε το Χρώμα του Ορθογωνίου χρησιμοποιώντας τη μέθοδο [SolidFillColor.setColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) όπως εκτίθεται από το αντικείμενο [IFillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/IFillFormat) που συνδέεται με το αντικείμενο [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape) .
- Ορίστε το Χρώμα των γραμμών του Ορθογωνίου.
- Ορίστε το Πάχος των γραμμών του Ορθογωνίου.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Τα παραπάνω βήματα υλοποιούνται στο παρακάτω παράδειγμα.

```java
// Δημιουργία αντικειμένου κλάσης Presentation που αναπαριστά το PPTX
Presentation pres = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη AutoShape τύπου έλλειψης
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Εφαρμογή μορφοποίησης στο σχήμα έλλειψης
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Εφαρμογή μορφοποίησης στη γραμμή της έλλειψης
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Αποθήκευση του αρχείου PPTX στο δίσκο
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Πώς να προσθέσω ένα ορθογώνιο με στρογγυλεμένες γωνίες;**

Χρησιμοποιήστε τον τύπο σχήματος με στρογγυλεμένες γωνίες [shape type](https://reference.aspose.com/slides/el/java/com.aspose.slides/shapetype/) και προσαρμόστε την ακτίνα γωνίας στις ιδιότητες του σχήματος· το στρογγυλεμένο μπορεί επίσης να εφαρμοστεί ανά γωνία μέσω γεωμετρικών ρυθμίσεων.

**Πώς να γεμίσω ένα ορθογώνιο με εικόνα (υφή);**

Επιλέξτε τον τύπο γεμίσματος εικόνας [fill type](https://reference.aspose.com/slides/el/java/com.aspose.slides/filltype/), παρέχετε την πηγή της εικόνας και ρυθμίστε τις λειτουργίες [stretching/tiling modes](https://reference.aspose.com/slides/el/java/com.aspose.slides/picturefillmode/) .

**Μπορεί ένα ορθογώνιο να έχει σκιά και λάμψη;**

Ναι. Τα [Outer/inner shadow, glow, and soft edges](/slides/el/java/shape-effect/) είναι διαθέσιμα με παραμετρικές ρυθμίσεις.

**Μπορώ να μετατρέψω ένα ορθογώνιο σε κουμπί με υπερσύνδεσμο;**

Ναι. [Assign a hyperlink](/slides/el/java/manage-hyperlinks/) στο κλικ του σχήματος (μετάβαση σε διαφάνεια, αρχείο, διεύθυνση web ή email).

**Πώς μπορώ να προστατεύσω ένα ορθογώνιο από μετακίνηση και αλλαγές;**

[Use shape locks](/slides/el/java/applying-protection-to-presentation/): μπορείτε να απαγορεύσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή ή την επεξεργασία κειμένου για να διατηρήσετε τη διάταξη.

**Μπορώ να μετατρέψω ένα ορθογώνιο σε ρισταρκό εικόνα ή SVG;**

Ναι. Μπορείτε να [render the shape](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getImage-int-float-float-) σε εικόνα με καθορισμένο μέγεθος/κλίμακα ή να την [export it as SVG](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) για χρήση ως διάνυσμα.

**Πώς να λάβω γρήγορα τις πραγματικές (αποτελεσματικές) ιδιότητες ενός ορθογωνίου λαμβάνοντας υπόψη το θέμα και την κληρονομικότητα;**

[Use the shape’s effective properties](/slides/el/java/shape-effective-properties/): το API επιστρέφει υπολογιζόμενες τιμές που λαμβάνουν υπόψη τα στυλ θέματος, τη διάταξη και τις τοπικές ρυθμίσεις, απλοποιώντας την ανάλυση μορφοποίησης.