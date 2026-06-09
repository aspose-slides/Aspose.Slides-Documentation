---
title: Προσθήκη Ορθογωνίων σε Παρουσιάσεις σε PHP
linktitle: Ορθογώνιο
type: docs
weight: 80
url: /el/php-java/rectangle/
keywords:
- προσθήκη ορθογωνίου
- δημιουργία ορθογωνίου
- σχήμα ορθογωνίου
- απλό ορθογώνιο
- μορφοποιημένο ορθογώνιο
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Βελτιώστε τις παρουσιάσεις PowerPoint προσθέτοντας ορθογώνια με το Aspose.Slides για PHP μέσω Java — σχεδιάστε και τροποποιήστε σχήματα προγραμματιστικά με ευκολία."
---
## **Περίληψη**

Αυτό το άρθρο δείχνει πώς να προσθέσετε σχήματα ορθογωνίου σε διαφάνειες PowerPoint χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει τη δημιουργία ενός απλού ορθογωνίου, τη δημιουργία ενός μορφοποιημένου ορθογωνίου και την αποθήκευση της ενημερωμένης παρουσίασης ως αρχείο PPTX.

Θα δείτε επίσης πώς να εφαρμόσετε βασική μορφοποίηση ορθογωνίου, όπως συμπαγές χρώμα γεμίσματος, χρώμα γραμμής και πάχος γραμμής. Επιπλέον, οι Συχνές Ερωτήσεις του άρθρου παραπέμπουν σε σχετικές εργασίες με ορθογώνια, όπως στρογγυλεμένες γωνίες, γεμίσματα εικόνας, οπτικά εφέ, υπερσυνδέσμους, κλειδαριές σχήματος, επιλογές εξαγωγής και αποτελεσματικές ιδιότητες.

## **Προσθήκη Ορθογωνίου σε Διαφάνεια**
Για να προσθέσετε ένα απλό ορθογώνιο σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) τύπου Rectangle χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#addAutoShape) που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/).
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα απλό ορθογώνιο στην πρώτη διαφάνεια της παρουσίασης.

```php
  # Δημιουργία κλάσης Presentation που αντιπροσωπεύει το PPTX
  $pres = new Presentation();
  try {
    # Ανάκτηση της πρώτης διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθήκη AutoShape τύπου έλλειψης
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Αποθήκευση του αρχείου PPTX στο δίσκο
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη Μορφοποιημένου Ορθογωνίου σε Διαφάνεια**
Για να προσθέσετε ένα μορφοποιημένο ορθογώνιο σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) τύπου Rectangle χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#addAutoShape) που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/).
- Ορίστε τον [Fill Type](https://reference.aspose.com/slides/el/php-java/aspose.slides/FillType) του Ορθογωνίου σε Solid.
- Ορίστε το Χρώμα του Ορθογωνίου χρησιμοποιώντας τη μέθοδο [ColorFormat::setColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/colorformat/#setColor) που εκτίθεται από το αντικείμενο [FillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/) που σχετίζεται με το αντικείμενο [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/).
- Ορίστε το Χρώμα των γραμμών του Ορθογωνίου.
- Ορίστε το Πάχος των γραμμών του Ορθογωνίου.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Τα παραπάνω βήματα υλοποιούνται στο παρακάτω παράδειγμα.

```php
  # Δημιουργία κλάσης Presentation που αντιπροσωπεύει το PPTX
  $pres = new Presentation();
  try {
    # Λήψη της πρώτης διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθήκη AutoShape τύπου έλλειψης
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Εφαρμογή μορφοποίησης στο σχήμα έλλειψης
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Εφαρμογή μορφοποίησης στη γραμμή της έλλειψης
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Αποθήκευση του αρχείου PPTX στο δίσκο
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να προσθέσω ένα ορθογώνιο με στρογγυλεμένες γωνίες;**

Χρησιμοποιήστε τον [τύπο σχήματος] με στρογγυλεμένες γωνίες και ρυθμίστε την ακτίνα των γωνιών στις ιδιότητες του σχήματος· η στρογγυλοποίηση μπορεί επίσης να εφαρμοστεί ανά γωνία μέσω γεωμετρικών ρυθμίσεων.

**Πώς μπορώ να γεμίσω ένα ορθογώνιο με εικόνα (υφή);**

Επιλέξτε τον [τύπο γεμίσματος] εικόνας, παράσχετε την πηγή της εικόνας και διαμορφώστε τις [λειτουργίες τέντωσης/πλακίδωσης](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillmode/).

**Μπορεί ένα ορθογώνιο να έχει σκιά και λάμψη;**

Ναι. Η [εξωτερική/εσωτερική σκιά, η λάμψη και οι μαλακές άκρες](/slides/el/php-java/shape-effect/) είναι διαθέσιμες με παραμετρές ρύθμισης.

**Μπορώ να μετατρέψω ένα ορθογώνιο σε κουμπί με υπερσύνδεσμο;**

Ναι. [Αναθέστε έναν υπερσύνδεσμο](/slides/el/php-java/manage-hyperlinks/) στο κλικ του σχήματος (μετάβαση σε διαφάνεια, αρχείο, διεύθυνση ιστού ή email).

**Πώς μπορώ να προστατεύσω ένα ορθογώνιο από μετακίνηση και αλλαγές;**

Χρησιμοποιήστε κλειδαριές σχήματος: μπορείτε να απαγορεύσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή ή την επεξεργασία κειμένου για να διατηρήσετε τη διάταξη.

**Μπορώ να μετατρέψω ένα ορθογώνιο σε εικόνα raster ή SVG;**

Ναι. Μπορείτε να [αποδώσετε το σχήμα](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getImage) σε εικόνα με καθορισμένο μέγεθος/κλίμακα ή να το [εξάγετε ως SVG](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/writeassvg/) για χρήση ως διάνυσμα.

**Πώς μπορώ γρήγορα να λάβω τις πραγματικές (αποτελεσματικές) ιδιότητες ενός ορθογωνίου λαμβάνοντας υπόψη το θέμα και την κληρονομικότητα;**

[Χρησιμοποιήστε τις αποτελεσματικές ιδιότητες του σχήματος](/slides/el/php-java/shape-effective-properties/): το API επιστρέφει υπολογισμένες τιμές που λαμβάνουν υπόψη τα στυλ θέματος, τη διάταξη και τις τοπικές ρυθμίσεις, απλοποιώντας την ανάλυση μορφοποίησης.