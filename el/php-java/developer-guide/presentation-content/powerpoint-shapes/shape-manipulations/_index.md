---
title: Διαχείριση Σχημάτων Παρουσίασης σε PHP
linktitle: Διαχείριση Σχημάτων
type: docs
weight: 40
url: /el/php-java/shape-manipulations/
keywords:
- Σχήμα PowerPoint
- Σχήμα παρουσίασης
- Σχήμα σε διαφάνεια
- Εύρεση σχήματος
- Κλωνοποίηση σχήματος
- Αφαίρεση σχήματος
- Απόκρυψη σχήματος
- Αλλαγή σειράς σχήματος
- Λήψη Interop Shape ID
- Εναλλακτικό κείμενο σχήματος
- Μορφές διάταξης σχήματος
- Σχήμα ως SVG
- Μετατροπή σχήματος σε SVG
- Στοίχιση σχήματος
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε να δημιουργείτε, επεξεργάζεστε και βελτιστοποιείτε σχήματα στο Aspose.Slides για PHP μέσω Java και να παραδίδετε παρουσιάσεις PowerPoint υψηλής απόδοσης."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με σχήματα σε παρουσιάσεις χρησιμοποιώντας Aspose.Slides. Δείχνει πώς να βρείτε ένα σχήμα σε μια διαφάνεια, να το κλωνοποιήσετε, να το αφαιρέσετε, να το κρύψετε, να αλλάξετε τη σειρά του, να λάβετε το Interop shape ID του και να ορίσετε εναλλακτικό κείμενο για την ταυτοποίηση και περαιτέρω επεξεργασία.

Καλύπτει επίσης πώς να προσπελάσετε μορφές διάταξης για σχήματα, να αποδώσετε ένα σχήμα ως SVG, να ευθυγραμμίσετε σχήματα σε μια διαφάνεια και να χρησιμοποιήσετε τις ιδιότητες flipping για οριζόντια και κάθετη κατοπτρισμό. Επιπλέον, το άρθρο περιλαμβάνει σύντομο FAQ σχετικά με τη συνένωση σχημάτων, τη σειρά στρώσης και το κλείδωμα σχημάτων.

## **Εύρεση σχήματος σε διαφάνεια**
Αυτό το θέμα θα περιγράψει μια απλή τεχνική για να διευκολύνει τους προγραμματιστές να βρουν ένα συγκεκριμένο σχήμα σε μια διαφάνεια χωρίς τη χρήση του εσωτερικού του Id. Είναι σημαντικό να γνωρίζετε ότι τα αρχεία παρουσίασης PowerPoint δεν διαθέτουν κανένα τρόπο να ταυτοποιήσουν σχήματα σε μια διαφάνεια εκτός από ένα εσωτερικό μοναδικό Id. Φαίνεται δύσκολο για τους προγραμματιστές να βρουν ένα σχήμα χρησιμοποιώντας το εσωτερικό μοναδικό Id του. Όλα τα σχήματα που προστίθενται στις διαφάνειες έχουν κάποιο Alt Text. Προτείνουμε στους προγραμματιστές να χρησιμοποιούν εναλλακτικό κείμενο για την εύρεση ενός συγκεκριμένου σχήματος. Μπορείτε να χρησιμοποιήσετε το MS PowerPoint για να ορίσετε το εναλλακτικό κείμενο για αντικείμενα που σκοπεύετε να αλλάξετε στο μέλλον.

Αφού ορίσετε το εναλλακτικό κείμενο του επιθυμητού σχήματος, μπορείτε να ανοίξετε την παρουσίαση χρησιμοποιώντας Aspose.Slides for PHP via Java και να επαναλάβετε όλα τα σχήματα που προστέθηκαν σε μια διαφάνεια. Σε κάθε επανάληψη, μπορείτε να ελέγξετε το εναλλακτικό κείμενο του σχήματος και το σχήμα με το αντίστοιχο εναλλακτικό κείμενο θα είναι το σχήμα που χρειάζεστε. Για να δείξουμε αυτήν την τεχνική με καλύτερο τρόπο, δημιουργήσαμε τη μέθοδο [findShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) που κάνει το τέχνασμα για να βρεί ένα συγκεκριμένο σχήμα σε μια διαφάνεια και επιστρέφει απλώς αυτό το σχήμα.

```php
  # Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει το αρχείο παρουσίασης
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Εναλλακτικό κείμενο του σχήματος που πρέπει να βρεθεί
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Κλωνοποίηση σχήματος**
Για να κλωνοποιήσετε ένα σχήμα σε μια διαφάνεια χρησιμοποιώντας Aspose.Slides for PHP via Java:

1. Δημιουργήστε μια παρουσία του [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
1. Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Πρόσβαση στη συλλογή σχημάτων της πηγής διαφάνειας.
1. Προσθήκη νέας διαφάνειας στην παρουσία.
1. Κλωνοποιήστε σχήματα από τη συλλογή σχημάτων της πηγής διαφάνειας στη νέα διαφάνεια.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει ένα γκρουπ σχήμα σε μια διαφάνεια.

```php
  # Δημιουργία αντικειμένου Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Αποθήκευση αρχείου PPTX στο δίσκο
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αφαίρεση σχήματος**
Aspose.Slides for PHP via Java επιτρέπει στους προγραμματιστές να αφαιρέσουν οποιοδήποτε σχήμα. Για να αφαιρέσετε το σχήμα από οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία του [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Εντοπίστε το σχήμα με συγκεκριμένο AlternativeText.
1. Αφαιρέστε το σχήμα.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```php
  # Δημιουργία αντικειμένου Presentation
  $pres = new Presentation();
  try {
    # Λήψη της πρώτης διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθήκη αυτόματου σχήματος τύπου ορθογώνιο
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Αποθήκευση παρουσίασης στο δίσκο
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Απόκρυψη σχήματος**
Aspose.Slides for PHP via Java επιτρέπει στους προγραμματιστές να κρύψουν οποιοδήποτε σχήμα. Για να κρύψετε το σχήμα από οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία του [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Εντοπίστε το σχήμα με συγκεκριμένο AlternativeText.
1. Κρύψτε το σχήμα.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```php
  # Δημιουργία κλάσης Presentation που εκπροσωπεί το PPTX
  $pres = new Presentation();
  try {
    # Λήψη της πρώτης διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθήκη αυτόματου σχήματος τύπου ορθογωνίου
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Αποθήκευση παρουσίασης στο δίσκο
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αλλαγή σειράς σχήματος**
Aspose.Slides for PHP via Java επιτρέπει στους προγραμματιστές να αλλάξουν τη σειρά των σχημάτων. Η αλλαγή σειράς καθορίζει ποιο σχήμα είναι μπροστά ή ποιο στο πίσω μέρος. Για να αλλάξετε τη σειρά του σχήματος σε οποιαδήποτε διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία του [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε ένα σχήμα.
1. Προσθέστε κάποιο κείμενο στο πλαίσιο κειμένου του σχήματος.
1. Προσθέστε ένα ακόμη σχήμα με τις ίδιες συντεταγμένες.
1. Αλλάξτε τη σειρά των σχημάτων.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Λήψη Interop Shape ID**
Aspose.Slides for PHP via Java επιτρέπει στους προγραμματιστές να λάβουν ένα μοναδικό αναγνωριστικό σχήματος στο επίπεδο της διαφάνειας σε αντίθεση με τη μέθοδο [getUniqueId](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getuniqueid/) που επιτρέπει την απόκτηση μοναδικού αναγνωριστικού στο επίπεδο της παρουσίασης. Η μέθοδος [getOfficeInteropShapeId](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getofficeinteropshapeid/) προστέθηκε στην κλάση [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) αντίστοιχα. Η τιμή που επιστρέφεται από τη μέθοδο [getOfficeInteropShapeId](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getofficeinteropshapeid/) αντιστοιχεί στην τιμή του Id του αντικειμένου Microsoft.Office.Interop.PowerPoint.Shape. Παρακάτω δίνεται ένα παράδειγμα κώδικα.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Λήψη μοναδικού αναγνωριστικού σχήματος στο επίπεδο της διαφάνειας
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός εναλλακτικού κειμένου για σχήμα**
Aspose.Slides for PHP via Java επιτρέπει στους προγραμματιστές να ορίσουν AlternateText για οποιοδήποτε σχήμα.
Τα σχήματα σε μια παρουσίαση μπορούν να διακριθούν με το `Alternative Text` ή τη μέθοδο [Shape Name](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/setname/).
Οι μέθοδοι [setAlternativeText](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/setalternativetext/) και [getAlternativeText](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getalternativetext/) μπορούν να διαβαστούν ή να οριστούν χρησιμοποιώντας το Aspose.Slides καθώς και το Microsoft PowerPoint.
Χρησιμοποιώντας αυτή τη μέθοδο, μπορείτε να επισημάνετε ένα σχήμα και να εκτελέσετε διαφορετικές λειτουργίες όπως αφαίρεση σχήματος,
απόκρυψη σχήματος ή αλλαγή σειράς σχημάτων σε μια διαφάνεια.
Για να ορίσετε το AlternateText ενός σχήματος, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία του [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε οποιοδήποτε σχήμα στη διαφάνεια.
1. Εκτελέστε κάποιες εργασίες με το νεοσυγκεντρωμένο σχήμα.
1. Διασχίστε τα σχήματα για να βρείτε ένα σχήμα.
1. Ορίστε το AlternativeText.
1. Αποθηκεύστε το αρχείο στο δίσκο.

```php
  # Δημιουργία κλάσης Presentation που εκπροσωπεί το PPTX
  $pres = new Presentation();
  try {
    # Λήψη της πρώτης διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθήκη αυτόματου σχήματος τύπου ορθογωνίου
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Αποθήκευση παρουσίασης στο δίσκο
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Πρόσβαση σε μορφές διάταξης για σχήμα**
Aspose.Slides for PHP via Java παρέχει μια απλή API για πρόσβαση σε μορφές διάταξης για ένα σχήμα. Αυτό το άρθρο δείχνει πώς μπορείτε να προσπελάσετε τις μορφές διάταξης.

Παρακάτω δίνεται το δείγμα κώδικα.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Απόδοση σχήματος ως SVG**
Τώρα το Aspose.Slides for PHP via Java υποστηρίζει την απόδοση ενός σχήματος ως svg. Η μέθοδος [writeAsSvg](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/writeassvg/) (και η υπερφόρτωσή της) προστέθηκε στην κλάση [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/). Αυτή η μέθοδος επιτρέπει την αποθήκευση του περιεχομένου του σχήματος ως αρχείο SVG. Το παρακάτω απόσπασμα κώδικα δείχνει πώς να εξάγετε το σχήμα μιας διαφάνειας σε αρχείο SVG.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ευθυγράμμιση σχήματος**
Το Aspose.Slides επιτρέπει την ευθυγράμμιση σχημάτων είτε σχετικά με τα περιθώρια της διαφάνειας είτε μεταξύ τους. Για το σκοπό αυτό, προστέθηκε η υπερφορτωμένη μέθοδος [SlidesUtil::alignShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideutil/alignshapes/). Η απαρίθμηση [ShapesAlignmentType](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapesalignmenttype/) ορίζει τις πιθανές επιλογές ευθυγράμμισης.

**Παράδειγμα 1**

Ο κώδικας παρακάτω ευθυγραμμίζει σχήματα με δείκτες 1,2 και 4 κατά το άνω όριο της διαφάνειας.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Παράδειγμα 2**

Το παρακάτω παράδειγμα δείχνει πώς να ευθυγραμμίσετε ολόκληρη τη συλλογή σχημάτων σε σχέση με το πιο κάτω σχήμα της συλλογής.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ιδιότητες Flip**

Στο Aspose.Slides, η κλάση [ShapeFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapeframe/) παρέχει έλεγχο για οριζόντια και κάθετη κατοπτρισμό των σχημάτων μέσω των ιδιοτήτων `flipH` και `flipV`. Και οι δύο ιδιότητες είναι τύπου [NullableBool](https://reference.aspose.com/slides/el/php-java/aspose.slides/nullablebool/) και επιτρέπουν τις τιμές `True` για να υποδείξουν κατοπτρισμό, `False` για καμία ενέργεια, ή `NotDefined` για χρήση προεπιλεγμένου συστήματος. Αυτές οι τιμές είναι προσβάσιμες από το [Frame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getFrame) ενός σχήματος.

Για να τροποποιήσετε τις ρυθμίσεις flip, δημιουργείται μια νέα εμφάνιση του [ShapeFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapeframe/) με την τρέχουσα θέση και μέγεθος του σχήματος, τις επιθυμητές τιμές για `flipH` και `flipV` και τη γωνία περιστροφής. Αναθέτοντας αυτήν την παρουσία στο [Frame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getFrame) του σχήματος και αποθηκεύοντας την παρουσία εφαρμόζονται οι μετασχηματισμοί κατοπτρισμού και καταγράφονται στο αρχείο εξόδου.

Ας πούμε ότι έχουμε ένα αρχείο sample.pptx στο οποίο η πρώτη διαφάνεια περιέχει ένα μόνο σχήμα με προεπιλεγμένες ρυθμίσεις flip, όπως φαίνεται παρακάτω.

![The shape to be flipped](shape_to_be_flipped.png)

Ο ακόλουθος κώδικας παίρνει τις τρέχουσες ιδιότητες flip του σχήματος και το περιστρέφει τόσο οριζόντια όσο και κάθετος.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Ανάκτηση της ιδιότητας οριζόντιας αντιστροφής του σχήματος.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Ανάκτηση της ιδιότητας κάθετης αντιστροφής του σχήματος.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Αντιστροφή οριζόντια.
    $flipV = NullableBool::True; // Αντιστροφή οριζόντια.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Μπορώ να συνδυάσω σχήματα (ένωση/τομή/αφαίρεση) σε μια διαφάνεια όπως σε έναν επιτραπέζιο επεξεργαστή;**

Δεν υπάρχει ενσωματωμένο API για Boolean λειτουργίες. Μπορείτε να προσεγγίσετε το αποτέλεσμα δημιουργώντας το επιθυμητό περίγραμμα μόνοι σας—π.χ. υπολογίζοντας τη γεωμετρία (μέσω [GeometryPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/geometrypath/)) και δημιουργώντας ένα νέο σχήμα με αυτό το περιγράμματα, προαιρετικά αφαιρώντας τα αρχικά.

**Πώς μπορώ να ελέγξω τη σειρά στρώσης (z-order) ώστε ένα σχήμα να παραμένει πάντα «στην κορυφή»;**

Αλλάξτε τη σειρά εισαγωγής/μετάθεσης μέσα στη συλλογή [shapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/#getShapes) της διαφάνειας. Για προβλέψιμα αποτελέσματα, τελειώστε το z-order μετά από όλες τις άλλες τροποποιήσεις της διαφάνειας.

**Μπορώ να «κλειδώσω» ένα σχήμα ώστε να αποτρέψω τους χρήστες από το να το επεξεργαστούν στο PowerPoint;**

Ναι. Ορίστε σημαίες προστασίας επιπέδου σχήματος (π.χ. κλείδωμα επιλογής, κίνησης, αλλαγής μεγέθους, επεξεργασίας κειμένου). Αν χρειαστεί, εφαρμόστε περιορισμούς στον κύριο ή τη διάταξη. Σημειώστε ότι αυτή είναι προστασία σε επίπεδο UI, όχι λειτουργία ασφαλείας· για ισχυρότερη προστασία, συνδυάστε με περιορισμούς σε επίπεδο αρχείου όπως [read-only recommendations or passwords](/slides/el/php-java/password-protected-presentation/).