---
title: Προσθήκη Ελλειψών σε Παρουσιάσεις με Java
linktitle: Έλλειψη
type: docs
weight: 30
url: /el/java/ellipse/
keywords:
- έλλειψη
- σχήμα
- προσθήκη έλλειψης
- δημιουργία έλλειψης
- σχεδίαση έλλειψης
- μορφοποιημένη έλλειψη
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε, μορφοποιείτε και να χειρίζεστε σχήματα έλλειψης στο Aspose.Slides για Java σε παρουσιάσεις PPT και PPTX — περιλαμβάνονται παραδείγματα κώδικα Java."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να προσθέσετε σχήματα έλλειψης σε διαφάνειες PowerPoint χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη δημιουργία ενός απλού έλλειψης, τη δημιουργία ενός μορφοποιημένου έλλειψης και την αποθήκευση της ενημερωμένης παρουσίασης ως αρχείο PPTX. Επίσης, αγγίζει σχετικές ερωτήσεις, όπως η εργασία με τη θέση και το μέγεθος του έλλειψης, ο έλεγχος της σειράς επικάλυψης και η εφαρμογή εφέ κίνησης.

## **Δημιουργία Έλλειψης**
Για να προσθέσετε ένα απλό έλλειψη σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Έλλειψη χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection) .
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, έχουμε προσθέσει ένα έλλειψη στην πρώτη διαφάνεια

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Προσθέστε AutoShape τύπου έλλειψης
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Γράψτε το αρχείο PPTX στο δίσκο
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Δημιουργία Μορφοποιημένου Έλλειψης**
Για να προσθέσετε ένα καλύτερα μορφοποιημένο έλλειψη σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Έλλειψη χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) που εκτίθεται από το αντικείμενο [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection) .
- Ορίστε τον τύπο γεμίσματος του έλλειψη ως Στερεό.
- Ορίστε το χρώμα του έλλειψη χρησιμοποιώντας την ιδιότητα SolidFillColor.Color όπως εκτίθεται από το αντικείμενο [FillFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/IFillFormat) που σχετίζεται με το αντικείμενο [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShape) .
- Ορίστε το χρώμα των γραμμών του έλλειψη.
- Ορίστε το πλάτος των γραμμών του έλλειψη.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, έχουμε προσθέσει ένα μορφοποιημένο έλλειψη στην πρώτη διαφάνεια της παρουσίασης.

```java
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
Presentation pres = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια
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

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να ορίσω την ακριβή θέση και μέγεθος ενός έλλειψη σε σχέση με τις μονάδες της διαφάνειας;**

Οι συντεταγμένες και τα μεγέθη συνήθως ορίζονται **σε σημεία**. Για προβλέψιμα αποτελέσματα, βασίστε τους υπολογισμούς σας στο μέγεθος της διαφάνειας και μετατρέψτε τα απαιτούμενα χιλιοστά ή ίντσες σε σημεία πριν αναθέσετε τις τιμές.

**Πώς μπορώ να τοποθετήσω ένα έλλειψη πάνω ή κάτω από άλλα αντικείμενα (έλεγχος σειράς επικάλυψης);**

Ρυθμίστε τη σειρά σχεδίασης του αντικειμένου φέρνοντάς το στην κορυφή ή στέλνοντάς το στο παρασκήνιο. Αυτό επιτρέπει στο έλλειψη να επικαλύπτει άλλα αντικείμενα ή να αποκαλύπτει αυτά που βρίσκονται κάτω από αυτό.

**Πώς μπορώ να κινηματογραφήσω την εμφάνιση ή έμφαση ενός έλλειψη;**

[Apply](/slides/el/java/shape-animation/) εφέ εισόδου, έμφασης ή εξόδου στο σχήμα, και ρυθμίστε τα triggers και το χρονοδιάγραμμα ώστε να καθορίσετε πότε και πώς θα εκτελείται η κίνηση.