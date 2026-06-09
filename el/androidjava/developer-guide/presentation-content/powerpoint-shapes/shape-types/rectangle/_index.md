---
title: Προσθήκη Παραλληλογράμμων σε Παρουσιάσεις σε Android
linktitle: Παραλληλόγραμμο
type: docs
weight: 80
url: /el/androidjava/rectangle/
keywords:
- προσθήκη παραλληλογράμμου
- δημιουργία παραλληλογράμμου
- σχήμα παραλληλογράμμου
- απλό παραλληλόγραμμο
- μορφοποιημένο παραλληλόγραμμο
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Βελτιώστε τις παρουσιάσεις PowerPoint σας προσθέτοντας παραλληλογράμματα με το Aspose.Slides για Android μέσω Java—σχεδιάζοντας και τροποποιώντας σχήματα προγραμματιστικά με εύκολο τρόπο."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να προσθέσετε σχήματα παραλληλογράμμου σε διαφάνειες PowerPoint χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη δημιουργία ενός απλού παραλληλογράμμου, τη δημιουργία ενός μορφοποιημένου παραλληλογράμμου και την αποθήκευση της ενημερωμένης παρουσίασης ως αρχείο PPTX.

Θα δείτε επίσης πώς να εφαρμόσετε βασική μορφοποίηση παραλληλογράμμου, όπως στερεό χρώμα γεμίσματος, χρώμα γραμμής και πλάτος γραμμής. Επιπλέον, οι Συχνές Ερωτήσεις του άρθρου παραπέμπουν σε σχετικές εργασίες με παραλληλογράμματα, όπως στρογγυλεμένες γωνίες, γεμίσματα εικόνας, οπτικά εφέ, υπερσυνδέσμους, κλειδώματα σχήματος, επιλογές εξαγωγής και αποτελεσματικές ιδιότητες.

## **Προσθήκη Παραλληλογράμμου σε Διαφάνεια**
Για να προσθέσετε ένα απλό παραλληλογράμμο σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape) τύπου Rectangle χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection).
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, έχουμε προσθέσει ένα απλό παραλληλογράμμο στην πρώτη διαφάνεια της παρουσίασης.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη AutoShape τύπου έλλειψης
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Αποθήκευση του αρχείου PPTX στο δίσκο
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσθήκη Μορφοποιημένου Παραλληλογράμμου σε Διαφάνεια**
Για να προσθέσετε ένα μορφοποιημένο παραλληλογράμμο σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IAutoShape) τύπου Rectangle χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection).
- Ορίστε το [Fill Type](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FillType) του Παραλληλογράμμου σε Solid.
- Ορίστε το Χρώμα του Παραλληλογράμμου χρησιμοποιώντας τη μέθοδο [SolidFillColor.setColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) όπως εκτίθεται από το αντικείμενο [IFillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IFillFormat) που σχετίζεται με το αντικείμενο [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape).
- Ορίστε το Χρώμα των γραμμών του Παραλληλογράμμου.
- Ορίστε το Πλάτος των γραμμών του Παραλληλογράμμου.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Τα παραπάνω βήματα εφαρμόζονται στο παρακάτω παράδειγμα.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη AutoShape τύπου έλλειψης
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Εφαρμογή κάποιων μορφοποιήσεων στο σχήμα έλλειψης
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Εφαρμογή κάποιων μορφοποιήσεων στη γραμμή του έλλειψης
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

**Πώς μπορώ να προσθέσω ένα παραλληλογράμμου με στρογγυλεμένες γωνίες;**

Χρησιμοποιήστε τον τύπο σχήματος με στρογγυλεμένες γωνίες [shape type](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shapetype/) και προσαρμόστε την ακτίνα γωνίας στις ιδιότητες του σχήματος· η στρογγυλοποίηση μπορεί επίσης να εφαρμοστεί ανά γωνία μέσω γεωμετρικών προσαρμογών.

**Πώς να γεμίσω ένα παραλληλογράμμου με μια εικόνα (υφή);**

Επιλέξτε τον τύπο γεμίσματος εικόνας [fill type](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/filltype/), καθορίστε την πηγή της εικόνας και διαμορφώστε τις λειτουργίες [stretching/tiling modes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/picturefillmode/).

**Μπορεί ένα παραλληλογράμμου να έχει σκιά και λάμψη;**

Ναι. Τα [Outer/inner shadow, glow, and soft edges](/slides/el/androidjava/shape-effect/) είναι διαθέσιμα με ρύθμιση παραμέτρων.

**Μπορώ να μετατρέψω ένα παραλληλογράμμου σε κουμπί με υπερσύνδεσμο;**

Ναι. [Assign a hyperlink](/slides/el/androidjava/manage-hyperlinks/) στο κλικ του σχήματος (μετάβαση σε διαφάνεια, αρχείο, διεύθυνση ιστού ή e‑mail).

**Πώς μπορώ να προστατεύσω ένα παραλληλογράμμου από μετακίνηση και αλλαγές;**

Χρησιμοποιήστε κλειδώματα σχήματος: μπορείτε να απαγορεύσετε τη μετακίνηση, το αλλαγικό μέγεθος, την επιλογή ή την επεξεργασία κειμένου για να διατηρήσετε τη διάταξη.

**Μπορώ να μετατρέψω ένα παραλληλογράμμου σε εικόνα raster ή SVG;**

Ναι. Μπορείτε να [render the shape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) σε εικόνα με καθορισμένο μέγεθος/κλίμακα ή να [export it as SVG](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) για χρήση ως διανυσματική.

**Πώς μπορώ γρήγορα να λάβω τις πραγματικές (αποτελεσματικές) ιδιότητες ενός παραλληλογράμμου λαμβάνοντας υπόψη το θέμα και την κληρονομιά;**

[Use the shape’s effective properties](/slides/el/androidjava/shape-effective-properties/): η API επιστρέφει υπολογισμένες τιμές που λαμβάνουν υπόψη τα στυλ θέματος, τη διάταξη και τις τοπικές ρυθμίσεις, απλοποιώντας την ανάλυση μορφοποίησης.