---
title: Προσθήκη Ελλείψεων σε Παρουσιάσεις σε PHP
linktitle: Έλλειψη
type: docs
weight: 30
url: /el/php-java/ellipse/
keywords:
- έλλειψη
- σχήμα
- προσθήκη έλλειψης
- δημιουργία έλλειψης
- σχεδίαση έλλειψης
- μορφοποιημένη έλλειψη
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να δημιουργήσετε, μορφοποιήσετε και να διαχειριστείτε σχήματα έλλειψης στο Aspose.Slides για PHP μέσω Java σε παρουσιάσεις PPT και PPTX — περιλαμβάνονται παραδείγματα κώδικα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να προσθέσετε σχήματα έλλειψης σε διαφάνειες PowerPoint χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη δημιουργία μιας απλής έλλειψης, τη δημιουργία μιας μορφοποιημένης έλλειψης και την αποθήκευση της ενημερωμένης παρουσίασης ως αρχείο PPTX. Επίσης, αγγίζει σχετικά ερωτήματα όπως η εργασία με τη θέση και το μέγεθος της έλλειψης, ο έλεγχος της σειράς στοίβαξης και η εφαρμογή εφέ κίνησης.

## **Δημιουργία Έλλειψης**
Για να προσθέσετε μια απλή έλλειψη στην επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Ellipse χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#addAutoShape) που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/).
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, έχουμε προσθέσει μια έλλειψη στην πρώτη διαφάνεια

```php
  # Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
  $pres = new Presentation();
  try {
    # Λήψη της πρώτης διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθήκη AutoShape τύπου έλλειψης
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Αποθήκευση του αρχείου PPTX στον δίσκο
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Δημιουργία Μορφοποιημένης Έλλειψης**
Για να προσθέσετε μια πιο μορφοποιημένη έλλειψη σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Ellipse χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#addAutoShape) που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/).
- Ορίστε τον τύπο γεμίσματος της Έλλειψης σε Solid.
- Ορίστε το χρώμα της Έλλειψης χρησιμοποιώντας τη μέθοδο `SolidFillColor::setColor` που εκτίθεται από το αντικείμενο [FillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/) το οποίο συσχετίζεται με το αντικείμενο [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/).
- Ορίστε το χρώμα των γραμμών της Έλλειψης.
- Ορίστε το πλάτος των γραμμών της Έλλειψης.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, έχουμε προσθέσει μια μορφοποιημένη έλλειψη στην πρώτη διαφάνεια της παρουσίασης.

```php
  # Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το PPTX
  $pres = new Presentation();
  try {
    # Λήψη της πρώτης διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθήκη AutoShape τύπου έλλειψης
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Εφαρμογή κάποιου μορφοποιήματος στο σχήμα έλλειψης
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Εφαρμογή κάποιου μορφοποιήματος στη γραμμή της Έλλειψης
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Αποθήκευση του αρχείου PPTX στον δίσκο
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ορίσω την ακριβή θέση και μέγεθος μιας έλλειψης σε σχέση με τις μονάδες της διαφάνειας;**

Οι συντεταγμένες και τα μεγέθη συνήθως καθορίζονται **σε points**. Για προβλέψιμα αποτελέσματα, βασίστε τους υπολογισμούς σας στο μέγεθος της διαφάνειας και μετατρέψτε τα απαιτούμενα χιλιοστά ή ίντσες σε points πριν αναθέσετε τις τιμές.

**Πώς μπορώ να τοποθετήσω μια έλλειψη πάνω ή κάτω από άλλα αντικείμενα (έλεγχος σειράς στοίβαξης);**

Ρυθμίστε τη σειρά σχεδίασης του αντικειμένου φέρνοντάς το στην επιφάνεια ή στέλνοντάς το στο παρασκήνιο. Αυτό επιτρέπει στην έλλειψη να επικαλύψει άλλα αντικείμενα ή να αποκαλύψει αυτά που βρίσκονται κάτω από αυτή.

**Πώς μπορώ να δημιουργήσω κίνηση για την εμφάνιση ή τον τονισμό μιας έλλειψης;**

[Εφαρμογή](/slides/el/php-java/shape-animation/) εφέ εισόδου, έμφασης ή εξόδου στο σχήμα, και ρυθμίστε τα triggers και το χρονοδιάγραμμα για να καθορίσετε πότε και πώς θα εκτελεστεί η κίνηση.