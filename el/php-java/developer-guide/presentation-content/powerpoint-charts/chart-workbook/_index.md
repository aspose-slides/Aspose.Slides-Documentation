---
title: Διαχείριση Βιβλίων Εργασίας Διαγραμμάτων σε Παρουσιάσεις με PHP
linktitle: Βιβλίο Εργασίας Διαγράμματος
type: docs
weight: 70
url: /el/php-java/chart-workbook/
keywords:
- βιβλίο εργασίας διαγράμματος
- δεδομένα διαγράμματος
- κελί βιβλίου εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερικό βιβλίο εργασίας
- εξωτερικά δεδομένα
- κρυφή μνήμη διαγράμματος
- αποκατάσταση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για PHP μέσω Java: διαχειριστείτε εύκολα τα βιβλία εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά του βιβλίου ως ετικέτες δεδομένων διαγράμματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης τη χρήση εξωτερικών βιβλίων εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που είναι συνδεδεμένο σε ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο είναι διαθέσιμο.

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Βιβλίο Εργασίας**
Aspose.Slides παρέχει τις μεθόδους [readWorkbookStream](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/#readWorkbookStream) και [writeWorkbookStream](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/#writeWorkbookStream) που επιτρέπουν την ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Σημείωση** ότι τα δεδομένα διαγράμματος πρέπει να οργανώνονται με τον ίδιο τρόπο ή να έχουν παρόμοια δομή με την πηγή.

Αυτός ο κώδικας PHP δείχνει μία ενδεικτική λειτουργία:

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Επικύρωση Διάταξης Διαγράμματος μετά την Τροποποίηση του Βιβλίου Εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το διάγραμμα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυμφωνία μπορεί να προκαλέσει αποτυχία του [Chart::validateChartLayout](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/validatechartlayout/) με σφάλμα «index-out-of-range». Καθαρίστε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο διάγραμμα.

```php
// Μετά την τροποποίηση της ροής του βιβλίου εργασίας (π.χ., χρησιμοποιώντας Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// Καθαρίστε τις υπάρχουσες αναφορές δεδομένων.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

Ο καθαρισμός των συλλογών διασφαλίζει ότι η δομή των δεδομένων διαγράμματος είναι σύμφωνη με το νέο βιβλίο εργασίας, επιτρέποντας στο `validateChartLayout` να ολοκληρωθεί χωρίς σφάλματα.

## **Ορισμός Κελιού Βιβλίου Εργασίας ως Ετικέτας Δεδομένων Διαγράμματος**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://apireference.aspose.com/slides/el/php-java/aspose.slides/presentation).
2. Αποκτήστε μια παραπομπή σε μια διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα Bubble με κάποια δεδομένα.
4. Προβάλετε τις σειρές του διαγράμματος.
5. Ορίστε το κελί του βιβλίου εργασίας ως ετικέτα δεδομένων.
6. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων διαγράμματος:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Δημιουργεί ένα αντικείμενο παρουσίασης που αντιπροσωπεύει αρχείο παρουσίασης
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Διαχείριση Φύλλων Εργασίας**

Αυτός ο κώδικας PHP δείχνει μια λειτουργία όπου χρησιμοποιείται η μέθοδος [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/#getWorksheets) για πρόσβαση σε μια συλλογή φύλλων εργασίας:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Καθορισμός Τύπου Πηγής Δεδομένων**

Αυτός ο κώδικας PHP δείχνει πώς να καθορίσετε έναν τύπο για μια πηγή δεδομένων:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλίου Εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη μορφή βιβλίου εργασίας Excel binary (.xlsb) που μπορεί να ενσωματωθεί σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο `getEmbeddedWorkbookType` στο [ChartData](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/php-java/aspose.slides/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα διαγράμματα.

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # Το ενσωματωμένο βιβλίο εργασίας είναι σε μορφή .xlsb, η οποία δεν υποστηρίζεται.
      continue;
    }

    # Διαβάστε ή τροποποιήστε τα δεδομένα του βιβλίου εργασίας του διαγράμματος εδώ.
  }
} finally {
  $presentation->dispose();
}
```

## **Εξωτερικό Βιβλίο Εργασίας**

Το Aspose.Slides υποστηρίζει εξωτερικά βιβλία εργασίας ως πηγή δεδομένων για διαγράμματα.

### **Δημιουργία Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τις μεθόδους **`readWorkbookStream`** και **`setExternalWorkbook`**, μπορείτε είτε να δημιουργήσετε ένα εξωτερικό βιβλίο εργασίας από το μηδέν είτε να κάνετε ένα εσωτερικό βιβλίο εργασίας εξωτερικό.

Αυτός ο κώδικας PHP δείχνει τη διαδικασία δημιουργίας εξωτερικού βιβλίου εργασίας:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ορισμός Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τη μέθοδο **`setExternalWorkbook`**, μπορείτε να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για να ενημερώσετε μια διαδρομή προς το εξωτερικό βιβλίο εργασίας (εάν το τελευταίο έχει μετακινηθεί).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας που αποθηκεύονται σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμη να χρησιμοποιήσετε τέτοια βιβλία ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για το εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε ένα εξωτερικό βιβλίο εργασίας:

```php
  # Δημιουργεί ένα αντίτυπο της κλάσης Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Η παράμετρος `ChartData` (στη μέθοδο `setExternalWorkbook`) χρησιμοποιείται για να καθοριστεί εάν ένα βιβλίο εργασίας Excel θα φορτωθεί ή όχι.

* Όταν η τιμή του `ChartData` είναι `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου—τα δεδομένα διαγράμματος δεν θα φορτωθούν ή ενημερωθούν από το βιβλίο προορισμού. Αυτό είναι χρήσιμο όταν το βιβλίο προορισμού δεν υπάρχει ή είναι μη διαθέσιμο.
* Όταν η τιμή του `ChartData` είναι `true`, τα δεδομένα διαγράμματος ενημερώνονται από το βιβλίο προορισμού.

```php
  # Δημιουργεί ένα αντίτυπο της κλάσης Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Λήψη Διαδρομής Εξωτερικής Πηγής Βιβλίου Εργασίας για Διάγραμμα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://apireference.aspose.com/slides/el/php-java/aspose.slides/presentation).
2. Αποκτήστε μια παραπομπή σε μια διαφάνεια μέσω του δείκτη της.
3. Δημιουργήστε ένα αντικείμενο για το σχήμα του διαγράμματος.
4. Δημιουργήστε ένα αντικείμενο για τον τύπο πηγής (`ChartDataSourceType`) που αντιπροσωπεύει την πηγή δεδομένων του διαγράμματος.
5. Καθορίστε τη σχετική συνθήκη με βάση το εάν ο τύπος πηγής είναι ο ίδιος με τον τύπο εξωτερικής πηγής βιβλίου εργασίας.

Αυτός ο κώδικας PHP δείχνει τη λειτουργία:

```php
  # Δημιουργεί ένα αντίτυπο της κλάσης Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Αποθηκεύει την παρουσίαση
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Επεξεργασία Δεδομένων Διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που τροποποιείτε τα περιεχόμενα εσωτερικών βιβλίων. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, εξαίρεση ρίχνεται.

Αυτή η υλοποίηση PHP δείχνει τη διαδικασία:

```php
  # Δημιουργεί ένα αντίτυπο της κλάσης Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ανάκτηση Βιβλίου Εργασίας από την Cache του Διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να επανακατασκευάσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που είναι στην cache της παρουσίασης. Δημιουργήστε ένα αντικείμενο [LoadOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/), ρυθμίστε το με [SpreadsheetOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/spreadsheetoptions/), και καλέστε το [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/el/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) με `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα PHP ανοίγει μια παρουσίαση του οποίου το διάγραμμα αναφέρεται σε ένα μη διαθέσιμο εξωτερικό βιβλίο εργασίας και προσπελαύνει τα ανακτημένα δεδομένα μέσω του [Chart::getChartData](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/#getChartData) και του [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Διαβάστε ή τροποποιήστε τα δεδομένα του ανακτημένου βιβλίου εργασίας εδώ.
} finally {
    $presentation->dispose();
}
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων της cache του διαγράμματος αποτελεί αποδεκτό εναλλακτικό σενάριο, καθώς η cache ενδέχεται να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα διαθέτει έναν [τύπο πηγής δεδομένων](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/getdatasourcetype/) και μια [διαδρομή προς εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Αυτό διευκολύνει τη φορητότητα του έργου· ωστόσο, η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια βιβλία μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η άμεση επεξεργασία απομακρυσμένων βιβλίων από το Aspose.Slides δεν υποστηρίζεται· μπορούν να χρησιμοποιηθούν μόνο ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Όχι. Η παρουσίαση αποθηκεύει έναν [σύνδεσμο προς το εξωτερικό αρχείο](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/getexternalworkbookpath/) και τον χρησιμοποιεί για ανάγνωση των δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται κατά την αποθήκευση.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό κατά την σύνδεση. Συνήθης προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/php-java/)) και να συνδέσετε σε αυτό.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει τον δικό του σύνδεσμο. Αν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα την επόμενη φορά που θα φορτωθούν τα δεδομένα.