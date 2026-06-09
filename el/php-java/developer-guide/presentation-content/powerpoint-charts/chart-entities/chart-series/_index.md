---
title: Διαχείριση Σειρών Δεδομένων Διαγράμματος σε Παρουσιάσεις με PHP
linktitle: Σειρές Δεδομένων
type: docs
url: /el/php-java/chart-series/
keywords:
- σειρές διαγράμματος
- επικάλυψη σειρών
- χρώμα σειράς
- χρώμα κατηγορίας
- όνομα σειράς
- σημείο δεδομένων
- κενό σειράς
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις σειρές δεδομένων διαγράμματος σε PHP για PowerPoint (PPT/PPTX) με πρακτικά παραδείγματα κώδικα και βέλτιστες πρακτικές για τη βελτίωση των παρουσιάσεων δεδομένων σας."
---
## **Επισκόπηση**

Αυτό το άρθρο περιγράφει τον ρόλο του [ChartSeries](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseries/) στο Aspose.Slides, εστιάζοντας στο πώς τα δεδομένα δομούνται και απεικονίζονται μέσα σε παρουσιάσεις. Αυτά τα αντικείμενα παρέχουν τα θεμέλια στοιχεία που ορίζουν μεμονωμένα σύνολα σημείων δεδομένων, κατηγορίες και παραμέτρους εμφάνισης σε ένα γράφημα. Εργαζόμενοι με το [ChartSeries](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseries/), οι προγραμματιστές μπορούν να ενσωματώσουν άψογα τις υποκείμενες πηγές δεδομένων και να διατηρήσουν πλήρη έλεγχο πάνω στον τρόπο που εμφανίζονται οι πληροφορίες, δημιουργώντας δυναμικές, δεδομενοκεντρικές παρουσιάσεις που μεταδίδουν σαφώς γνώσεις και αναλύσεις.

Μια σειρά είναι μια γραμμή ή στήλη αριθμών που σχεδιάζονται σε ένα διάγραμμα.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός επικάλυψης σειράς διαγράμματος**

Με τη μέθοδο [getParentSeriesGroup](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseries/#getParentSeriesGroup) μπορείτε να ορίσετε πόσο πρέπει να επικαλύπτονται οι ράβδοι και οι στήλες σε ένα 2D διάγραμμα (εύρος: -100 έως 100). Αυτή η ιδιότητα εφαρμόζεται σε όλες τις σειρές της γονικής ομάδας σειρών: πρόκειται για μια προβολή της αντίστοιχης ιδιότητας ομάδας. Συνεπώς, αυτή η ιδιότητα είναι μόνο για ανάγνωση.

Χρησιμοποιήστε τη μέθοδο `ChartSeriesGroup::setOverlap` για να ορίσετε την προτιμώμενη τιμή για το `Overlap`.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Προσθέστε ένα συγκεντρωτικό γράφημα στηλών σε μια διαφάνεια.
1. Προσπελάστε την πρώτη σειρά διαγράμματος.
1. Προσπελάστε το `ParentSeriesGroup` της σειράς διαγράμματος και ορίστε την προτιμώμενη τιμή επικάλυψης για τη σειρά.
1. Γράψτε την τροποποιημένη παρουσίαση σε ένα αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    # Προσθέτει γράφημα
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Ορίζει την επικάλυψη σειράς
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Γράφει το αρχείο παρουσίασης στο δίσκο
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αλλαγή χρώματος σειράς**
Το Aspose.Slides for PHP μέσω Java σας επιτρέπει να αλλάξετε το χρώμα μιας σειράς με αυτόν τον τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Προσθέστε γράφημα στη διαφάνεια.
1. Προσπελάστε τη σειρά της οποίας το χρώμα θέλετε να αλλάξετε.
1. Ορίστε τον προτιμώμενο τύπο γεμίσματος και το χρώμα γεμίσματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αλλαγή χρώματος κατηγορίας σειράς**
Το Aspose.Slides for PHP μέσω Java σας επιτρέπει να αλλάξετε το χρώμα μιας κατηγορίας σειράς με αυτόν τον τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Προσθέστε γράφημα στη διαφάνεια.
1. Προσπελάστε την κατηγορία σειράς της οποίας το χρώμα θέλετε να αλλάξετε.
1. Ορίστε τον προτιμώμενο τύπο γεμίσματος και το χρώμα γεμίσματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αλλαγή ονόματος σειράς**

Από προεπιλογή, τα ονόματα του υπομνήματος για ένα γράφημα είναι τα περιεχόμενα των κελιών πάνω από κάθε στήλη ή γραμμή δεδομένων.

Στο παράδειγμά μας (εικόνα δείγματος),

* οι στήλες είναι *Series 1, Series 2,* και *Series 3*·
* οι γραμμές είναι *Category 1, Category 2, Category 3,* και *Category 4*·

Το Aspose.Slides for PHP μέσω Java σας επιτρέπει να ενημερώσετε ή να αλλάξετε το όνομα μιας σειράς στα δεδομένα του γραφήματος και στο υπόμνημα.

Αυτός ο κώδικας PHP δείχνει πώς να αλλάξετε το όνομα μιας σειράς στα δεδομένα γραφήματος `ChartDataWorkbook`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Αυτός ο κώδικας PHP δείχνει πώς να αλλάξετε το όνομα μιας σειράς στο υπόμνημα μέσω του `Series`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός χρώματος γεμίσματος σειράς διαγράμματος**

Το Aspose.Slides for PHP μέσω Java σας επιτρέπει να ορίσετε το αυτόματο χρώμα γεμίσματος για σειρές διαγράμματος μέσα στην περιοχή σχεδίασης με αυτόν τον τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας βάσει του δείκτη της.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα βάσει του προτιμώμενου τύπου (στο παρακάτω παράδειγμα χρησιμοποιήσαμε το `ChartType::ClusteredColumn`).
1. Προσπελάστε τη σειρά διαγράμματος και ορίστε το χρώμα γεμίσματος σε Automatic.
1. Αποθηκεύστε την παρουσίαση σε αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    # Δημιουργεί συγκεντρωτικό γράφημα στηλών
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Ορίζει τη μορφή γεμίσματος σειράς σε αυτόματο
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Γράφει το αρχείο παρουσίασης στο δίσκο
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός αντιστροφής χρώματος γεμίσματος για σειρά διαγράμματος**
Το Aspose.Slides σας επιτρέπει να ορίσετε την αντιστροφή του χρώματος γεμίσματος για σειρές διαγράμματος μέσα στην περιοχή σχεδίασης με αυτόν τον τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας βάσει του δείκτη της.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα βάσει του προτιμώμενου τύπου (στο παρακάτω παράδειγμα χρησιμοποιήσαμε το `ChartType::ClusteredColumn`).
1. Προσπελάστε τη σειρά διαγράμματος και ορίστε το χρώμα γεμίσματος σε invert.
1. Αποθηκεύστε την παρουσίαση σε αρχείο PPTX.

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Προσθέτει νέες σειρές και κατηγορίες
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Παίρνει την πρώτη σειρά γραφήματος και γεμίζει τα δεδομένα της σειράς.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός αντιστροφής σειράς όταν η τιμή είναι αρνητική**
Το Aspose.Slides σας επιτρέπει να ορίσετε αντιστροφές μέσω των ιδιοτήτων `IChartDataPoint.InvertIfNegative` και `ChartDataPoint.InvertIfNegative`. Όταν μια αντιστροφή οριστεί με αυτές τις ιδιότητες, το σημείο δεδομένων αντιστρέφει τα χρώματά του όταν λαμβάνει μια αρνητική τιμή.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Καθαρισμός δεδομένων συγκεκριμένου σημείου**
Το Aspose.Slides for PHP μέσω Java σας επιτρέπει να καθαρίσετε τα δεδομένα `DataPoints` για μια συγκεκριμένη σειρά διαγράμματος με αυτόν τον τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Αποκτήστε την αναφορά ενός διαγράμματος μέσω του δείκτη του.
4. Επανάλαβε όλα τα `DataPoints` του διαγράμματος και ορίστε τα `XValue` και `YValue` σε null.
5. Καθαρίστε όλα τα `DataPoints` για συγκεκριμένη σειρά διαγράμματος.
6. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός πλάτους κενών (Gap Width) σειράς**
Το Aspose.Slides for PHP μέσω Java σας επιτρέπει να ορίσετε το πλάτος κενών μιας σειράς μέσω της ιδιότητας **`GapWidth`** με αυτόν τον τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Προσπελάστε την πρώτη διαφάνεια.
1. Προσθέστε γράφημα με προεπιλεγμένα δεδομένα.
1. Προσπελάστε οποιαδήποτε σειρά διαγράμματος.
1. Ορίστε την ιδιότητα `GapWidth`.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```php
  # Δημιουργεί κενή παρουσίαση
  $pres = new Presentation();
  try {
    # Προσπελάζει την πρώτη διαφάνεια της παρουσίασης
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθέτει γράφημα με προεπιλεγμένα δεδομένα
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Ορίζει το δείκτη του φύλλου δεδομένων του γραφήματος
    $defaultWorksheetIndex = 0;
    # Λαμβάνει το φύλλο εργασίας δεδομένων του γραφήματος
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Προσθέτει σειρές
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Προσθέτει Κατηγορίες
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Παίρνει τη δεύτερη σειρά γραφήματος
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Γεμίζει τα δεδομένα της σειράς
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Ορίζει την τιμή GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Αποθηκεύει την παρουσίαση στο δίσκο
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές ερωτήσεις**

**Υπάρχει κάποιο όριο στον αριθμό σειρών που μπορεί να περιέχει ένα μόνο γράφημα;**

Το Aspose.Slides δεν επιβάλλει κανένα σταθερό όριο στον αριθμό των σειρών που προσθέτετε. Το πρακτικό ανώτατο όριο καθορίζεται από την αναγνωσιμότητα του διαγράμματος και από τη μνήμη που είναι διαθέσιμη στην εφαρμογή σας.

**Τι γίνεται αν οι στήλες μέσα σε ένα σύνολο είναι πολύ κοντά ή πολύ μακριά η μία από την άλλη;**

Ρυθμίστε την ιδιότητα `GapWidth` για εκείνη τη σειρά (ή την γονική της ομάδα σειρών). Η αύξηση της τιμής αυξάνει το κενό μεταξύ των στηλών, ενώ η μείωση της τιμής τις φέρνει πιο κοντά.