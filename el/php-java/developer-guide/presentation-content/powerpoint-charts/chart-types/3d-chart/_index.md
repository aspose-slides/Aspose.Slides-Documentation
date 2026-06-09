---
title: Προσαρμογή 3D γραφημάτων σε παρουσιάσεις χρησιμοποιώντας PHP
linktitle: 3D Διάγραμμα
type: docs
url: /el/php-java/3d-chart/
keywords:
- 3D διάγραμμα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε 3-Δ διαγράμματα στο Aspose.Slides για PHP μέσω Java, με υποστήριξη αρχείων PPT και PPTX — ενισχύστε τις παρουσιάσεις σας σήμερα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε ένα 3D γράφημα στο Aspose.Slides διαμορφώνοντας τις ρυθμίσεις `Rotation3D` όπως `RotationX`, `RotationY`, `DepthPercents` και `RightAngleAxes`. Περιγράφει τη δημιουργία παρουσίασης, την προσθήκη 3D γραφήματος με προεπιλεγμένα δεδομένα, την εφαρμογή των απαιτούμενων ρυθμίσεων προβολής 3D και την αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

## **Ορισμός ιδιοτήτων RotationX, RotationY και DepthPercents ενός 3D γραφήματος**

Το Aspose.Slides for PHP via Java παρέχει ένα απλό API για τον ορισμό αυτών των ιδιοτήτων. Το παρακάτω άρθρο θα σας βοηθήσει να ορίσετε διαφορετικές ιδιότητες όπως **X,Y Rotation, DepthPercents** κ.λπ. Ο δείγματος κώδικας εφαρμόζει την ρύθμιση των προαναφερθέντων ιδιοτήτων.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Αποκτήστε πρόσβαση στην πρώτη διαφάνεια.
3. Προσθέστε γράφημα με προεπιλεγμένα δεδομένα.
4. Ορίστε τις ιδιότητες Rotation3D.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθήκη γραφήματος με προεπιλεγμένα δεδομένα
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Ορισμός του δείκτη του φύλλου δεδομένων γραφήματος
    $defaultWorksheetIndex = 0;
    # Λήψη του φύλλου εργασίας δεδομένων γραφήματος
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Προσθήκη σειράς
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Προσθήκη κατηγοριών
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Ορισμός ιδιοτήτων Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # Λήψη της δεύτερης σειράς γραφήματος
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Τώρα γεμίζουμε τα δεδομένα της σειράς
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Ορισμός τιμής OverLap
    $series->getParentSeriesGroup()->setOverlap(100);
    # Αποθήκευση παρουσίασης στο δίσκο
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές ερωτήσεις**

**Ποιοι τύποι γραφημάτων υποστηρίζουν τη λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές διαγραμμάτων στήλης, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100% Stacked Column 3D, καθώς και σχετικών 3D τύπων που εκτίθενται μέσω της κλάσης [ChartType](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/). Για μια ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη της κλάσης [ChartType](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/) στο API reference της εγκατεστημένης έκδοσης.

**Μπορώ να λάβω ένα ραστερ εικόνα ενός 3D γραφήματος για αναφορά ή το διαδίκτυο;**

Ναι. Μπορείτε να εξάγετε ένα γράφημα σε εικόνα μέσω του [chart API](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getImage) ή να [αποδώσετε ολόκληρη τη διαφάνεια](/slides/el/php-java/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια άψογη προεπισκόπηση ή θέλετε να ενσωματώσετε το γράφημα σε έγγραφα, πίνακες αναφορών ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3D γραφημάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για βέλτιστα αποτελέσματα, διατηρήστε τα 3D εφέ στο ελάχιστο, αποφύγετε βαριές υφές σε τοίχους και περιοχές σχεδιαγράμματος, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όπου είναι δυνατόν, και αποδώστε σε έξοδο κατάλληλου μεγέθους (ανάλυση και διαστάσεις) ώστε να ταιριάζει με την προβολή ή τις ανάγκες εκτύπωσης.