---
title: Προσθήκη σχημάτων γραμμής σε παρουσιάσεις σε PHP
linktitle: Γραμμή
type: docs
weight: 50
url: /el/php-java/Line/
keywords:
- γραμμή
- δημιουργία γραμμής
- προσθήκη γραμμής
- απλή γραμμή
- διαμόρφωση γραμμής
- προσαρμογή γραμμής
- στυλ παύλας
- κεφαλή βέλους
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τη μορφοποίηση γραμμών σε παρουσιάσεις PowerPoint με το Aspose.Slides for PHP via Java. Ανακαλύψτε ιδιότητες, μεθόδους και παραδείγματα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να προσθέτετε σχήματα γραμμής σε διαφάνειες PowerPoint προγραμματιστικά. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια απλή γραμμή και πώς να προσαρμόσετε μια γραμμή ώστε να εμφανίζεται ως βέλος.

Θα μάθετε πώς να προσθέσετε ένα σχήμα γραμμής σε μια διαφάνεια, πώς να ρυθμίσετε την οπτική της εμφάνιση και πώς να αποθηκεύσετε την ενημερωμένη παρουσίαση. Τα παραδείγματα εστιάζουν σε πρακτικές ρυθμίσεις μορφοποίησης γραμμής όπως στυλ, πλάτος, μοτίβο παύλας, επιλογές κεφαλής βέλους και χρώμα γεμίσματος.

## **Δημιουργία Απλής Γραμμής**

Για να προσθέσετε μια απλή απλή γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#addAutoShape) που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/).
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε μια γραμμή στην πρώτη διαφάνεια της παρουσίασης.

```php
  # Δημιουργήστε κλάση PresentationEx που αντιπροσωπεύει το αρχείο PPTX
  $pres = new Presentation();
  try {
    # Λήψη της πρώτης διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθήκη AutoShape τύπου line
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Αποθήκευση του PPTX στον δίσκο
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Δημιουργία Γραμμής Σχήματος Βέλους**

Το Aspose.Slides for PHP via Java επιτρέπει επίσης στους προγραμματιστές να ρυθμίζουν ορισμένες ιδιότητες της γραμμής ώστε να φαίνεται πιο ελκυστική. Ας προσπαθήσουμε να ρυθμίσουμε λίγες ιδιότητες μιας γραμμής ώστε να μοιάζει με βέλος. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#addAutoShape) που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/).
- Ορίστε το [Line Style](https://reference.aspose.com/slides/el/php-java/aspose.slides/LineStyle) σε ένα από τα στυλ που προσφέρει το Aspose.Slides for PHP via Java.
- Ορίστε το Πλάτος της γραμμής.
- Ορίστε το [Dash Style](https://reference.aspose.com/slides/el/php-java/aspose.slides/LineDashStyle) της γραμμής σε ένα από τα στυλ που προσφέρει το Aspose.Slides for PHP via Java.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/php-java/aspose.slides/LineArrowheadStyle) και το [Length](https://reference.aspose.com/slides/el/php-java/aspose.slides/LineArrowheadLength) του σημείου έναρξης της γραμμής.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/php-java/aspose.slides/LineArrowheadStyle) και το [Length](https://reference.aspose.com/slides/el/php-java/aspose.slides/LineArrowheadLength) του σημείου λήξης της γραμμής.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  # Δημιουργία κλάσης PresentationEx που αντιπροσωπεύει το αρχείο PPTX
  $pres = new Presentation();
  try {
    # Λήψη της πρώτης διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθήκη AutoShape τύπου line
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Εφαρμογή κάποιων μορφοποιήσεων στη γραμμή
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Αποθήκευση του PPTX στον δίσκο
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια κανονική γραμμή σε σύνδεσμο ώστε να «κολλά» σε σχήματα;**

Δεν. Μια κανονική γραμμή (ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) τύπου [Line](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapetype/)) δεν γίνεται αυτόματα σύνδεσμος. Για να την κάνετε να κολλάει σε σχήματα, χρησιμοποιήστε τον ειδικό τύπο [Connector](https://reference.aspose.com/slides/el/php-java/aspose.slides/connector/) και τα [corresponding APIs](/slides/el/php-java/connector/) για συνδέσεις.

**Τι πρέπει να κάνω αν οι ιδιότητες μιας γραμμής κληρονομούνται από το θέμα και είναι δύσκολο να προσδιοριστούν οι τελικές τιμές;**

[Read the effective properties](/slides/el/php-java/shape-effective-properties/) μέσω των `LineFormatEffectiveData`/`LineFillFormatEffectiveData`—αυτά λαμβάνουν ήδη υπόψη την κληρονομικότητα και τα στυλ του θέματος.

**Μπορώ να κλειδώσω μια γραμμή ώστε να μην μπορεί να επεξεργαστεί (να μετακινηθεί, να αλλάξει μέγεθος);**

Ναι. Τα σχήματα παρέχουν [lock objects](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/getautoshapelock/) που σας επιτρέπουν να απαγορεύσετε τις λειτουργίες επεξεργασίας.