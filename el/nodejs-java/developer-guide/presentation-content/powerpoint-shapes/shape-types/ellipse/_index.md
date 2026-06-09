---
title: Προσθήκη ελλείψεων σε παρουσιάσεις με JavaScript
linktitle: Έλλειψη
type: docs
weight: 30
url: /el/nodejs-java/ellipse/
keywords:
- έλλειψη
- σχήμα
- προσθήκη έλλειψης
- δημιουργία έλλειψης
- σχεδίαση έλλειψης
- μορφοποιημένη έλλειψη
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε, μορφοποιείτε και να διαχειρίζεστε σχήματα έλλειψης στο Aspose.Slides για Node.js σε παρουσιάσεις PPT και PPTX — περιλαμβάνονται παραδείγματα κώδικα JavaScript."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να προσθέσετε σχήματα έλλειψης σε διαφάνειες PowerPoint χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη δημιουργία μιας απλής έλλειψης, τη δημιουργία μιας μορφοποιημένης έλλειψης και την αποθήκευση της ενημερωμένης παρουσίασης ως αρχείο PPTX. Επίσης, αγγίζει σχετικές ερωτήσεις όπως η εργασία με τη θέση και το μέγεθος της έλλειψης, ο έλεγχος της σειράς στρώσης και η εφαρμογή εφέ κίνησης.

## **Δημιουργία Έλλειψης**
Για να προσθέσετε μια απλή έλλειψη σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Ellipse χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) που εκφράζεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection) .
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε μια έλλειψη στην πρώτη διαφάνεια

```javascript
// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει το PPTX
var pres = new aspose.slides.Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Προσθέτει AutoShape τύπου έλλειψης
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Γράφει το αρχείο PPTX στο δίσκο
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Δημιουργία Μορφοποιημένης Έλλειψης**
Για να προσθέσετε μια καλύτερα μορφοποιημένη έλλειψη σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) .
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Ellipse χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) που εκφράζεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection) .
- Ορίστε τον τύπο γεμίσματος της Έλλειψης σε Solid.
- Ορίστε το χρώμα της Έλλειψης χρησιμοποιώντας την ιδιότητα SolidFillColor.Color όπως εκτίθεται από το αντικείμενο [FillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/FillFormat) που σχετίζεται με το αντικείμενο [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Shape) .
- Ορίστε το χρώμα των γραμμών της Έλλειψης.
- Ορίστε το πλάτος των γραμμών της Έλλειψης.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε μια μορφοποιημένη έλλειψη στην πρώτη διαφάνεια της παρουσίασης.

```javascript
// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει το PPTX
var pres = new aspose.slides.Presentation();
try {
    // Αποκτά την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Προσθέτει AutoShape τύπου έλλειψης
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Εφαρμόζει κάποια μορφοποίηση στο σχήμα έλλειψης
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Εφαρμόζει κάποια μορφοποίηση στη γραμμή της έλλειψης
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Γράφει το αρχείο PPTX στο δίσκο
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **Συχνές ερωτήσεις**

**Πώς ορίζω την ακριβή θέση και μέγεθος μιας έλλειψης σε σχέση με τις μονάδες της διαφάνειας;**

Οι συντεταγμένες και τα μεγέθη συνήθως καθορίζονται **σε σημεία**. Για προβλέψιμα αποτελέσματα, βασίστε τους υπολογισμούς σας στο μέγεθος της διαφάνειας και μετατρέψτε τα απαιτούμενα χιλιοστά ή ίντσες σε σημεία πριν εκχωρήσετε τις τιμές.

**Πώς μπορώ να τοποθετήσω μια έλλειψη πάνω ή κάτω από άλλα αντικείμενα (έλεγχος σειράς στρώσης);**

Ρυθμίστε τη σειρά σχεδίασης του αντικειμένου φέρνοντάς το μπροστά ή στέλνοντάς το πίσω. Αυτό επιτρέπει στην έλλειψη να επικαλύπτει άλλα αντικείμενα ή να αποκαλύπτει αυτά που βρίσκονται κάτω από αυτήν.

**Πώς μπορώ να δημιουργήσω κίνηση για την εμφάνιση ή την ένταση μιας έλλειψης;**

[Apply](/slides/el/nodejs-java/shape-animation/) εφέ εισόδου, έντασης ή εξόδου στο σχήμα, και διαμορφώστε ενεργοποιητές και χρονοδιάγραμμα για να οργανώσετε πότε και πώς θα εκτελείται η κίνηση.