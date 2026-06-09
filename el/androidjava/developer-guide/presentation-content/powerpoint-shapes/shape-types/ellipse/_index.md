---
title: ΠΡΟΣΘΗΚΗ ΕΛΛΕΙΨΩΝ ΣΕ ΠΑΡΟΥΣΙΑΣΕΙΣ ΣΤΟ ANDROID
linktitle: ΈΛΛΕΙΨΗ
type: docs
weight: 30
url: /el/androidjava/ellipse/
keywords:
- έλλειψη
- σχήμα
- προσθήκη έλλειψης
- δημιουργία έλλειψης
- σχεδίαση έλλειψης
- μορφοποιημένη έλλειψη
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε, μορφοποιείτε και να χειρίζεστε σχήματα έλλειψης στο Aspose.Slides για Android σε παρουσιάσεις PPT και PPTX — περιλαμβάνονται παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να προσθέσετε σχήματα έλλειψης σε διαφάνειες PowerPoint χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει τη δημιουργία ενός απλού έλλειψου, τη δημιουργία ενός μορφοποιημένου έλλειψου και την αποθήκευση της ενημερωμένης παρουσίασης ως αρχείο PPTX. Επίσης, καλύπτει σχετικά ερωτήματα όπως η εργασία με τη θέση και το μέγεθος του έλλειψου, ο έλεγχος της σειράς στοίβας και η εφαρμογή εφέ κίνησης.

## **Δημιουργία Έλλειψης**
Για να προσθέσετε ένα απλό έλλειψη σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Δείκτη της.
- Προσθέστε ένα AutoShape τύπου Ellipse χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection) .
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα έλλειψη στην πρώτη διαφάνεια

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Προσθήκη AutoShape τύπου έλλειψης
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Αποθήκευση του αρχείου PPTX στον δίσκο
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Δημιουργία Μορφοποιημένου Έλλειψης**
Για να προσθέσετε ένα καλύτερα μορφοποιημένο έλλειψη σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Δείκτη της.
- Προσθέστε ένα AutoShape τύπου Ellipse χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection) .
- Ορίστε τον τύπο γεμίσματος του έλλειψου σε Solid.
- Ορίστε το χρώμα του έλλειψου χρησιμοποιώντας την ιδιότητα SolidFillColor.Color όπως εκτίθεται από το αντικείμενο [FillFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IFillFormat) που σχετίζεται με το αντικείμενο [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShape) .
- Ορίστε το χρώμα των γραμμών του έλλειψου.
- Ορίστε το πλάτος των γραμμών του έλλειψου.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα μορφοποιημένο έλλειψη στην πρώτη διαφάνεια της παρουσίασης.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθήκη AutoShape τύπου έλλειψης
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Εφαρμογή κάποιου μορφοποίησης στο σχήμα έλλειψης
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Εφαρμογή κάποιου μορφοποίησης στη γραμμή της έλλειψης
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Αποθήκευση του αρχείου PPTX στον δίσκο
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ορίσω τη ακριβή θέση και το μέγεθος ενός έλλειψου σε σχέση με τις μονάδες της διαφάνειας;**

Οι συντεταγμένες και τα μεγέθη συνήθως ορίζονται **σε σημεία**. Για προβλέψιμα αποτελέσματα, βασίστε τους υπολογισμούς σας στο μέγεθος της διαφάνειας και μετατρέψτε τα απαιτούμενα χιλιοστά ή ίντσες σε σημεία πριν αναθέσετε τις τιμές.

**Πώς μπορώ να τοποθετήσω ένα έλλειψη πάνω ή κάτω από άλλα αντικείμενα (έλεγχος σειράς στοίβας);**

Ρυθμίστε τη σειρά σχεδίασης του αντικειμένου φέρνοντας το στο προσκήνιο ή στέλνοντάς το στο παρασκήνιο. Αυτό επιτρέπει στο έλλειψη να επικαλύπτει άλλα αντικείμενα ή να αποκαλύπτει αυτά που βρίσκονται πίσω του.

**Πώς μπορώ να ανιματίσω την εμφάνιση ή την έμφαση ενός έλλειψου;**

Εφαρμόστε [Εφαρμογή](/slides/el/androidjava/shape-animation/) εφέ εισόδου, έμφασης ή εξόδου στο σχήμα και ρυθμίστε τα triggers και το χρονισμό για να καθορίσετε πότε και πώς θα εκτελείται η ανίμαση.