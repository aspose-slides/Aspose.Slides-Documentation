---
title: Διαχείριση βιβλιοθηκών γραφημάτων σε παρουσιάσεις με PHP
linktitle: Βιβλιοθήκη Γραφήματος
type: docs
weight: 70
url: /el/php-java/chart-workbook/
keywords:
- βιβλιοθήκη γραφήματος
- δεδομένα γραφήματος
- κελί βιβλιοθήκης
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερική βιβλιοθήκη
- εξωτερικά δεδομένα
- κρυφή μνήμη γραφήματος
- ανάκτηση βιβλιοθήκης
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για PHP μέσω Java: διαχειριστείτε με ευκολία τις βιβλιοθήκες γραφημάτων σε μορφές PowerPoint και OpenDocument, ώστε να βελτιστοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλιοθήκες γραφημάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα γραφήματος μέσω ροών βιβλιοθηκών, να χρησιμοποιείτε κελιά βιβλιοθήκης ως ετικέτες δεδομένων γραφήματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του γραφήματος.

Επίσης καλύπτει την εργασία με εξωτερικές βιβλιοθήκες ως πηγές δεδομένων γραφήματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να εκχωρήσετε μια εξωτερική βιβλιοθήκη, να ανακτήσετε τη διαδρομή μιας εξωτερικής βιβλιοθήκης που συνδέεται με ένα γράφημα και να επεξεργαστείτε τα δεδομένα του γραφήματος όταν η βιβλιοθήκη είναι διαθέσιμη.

Για κελιά βιβλιοθήκης που αντιπροσωπεύουν ελλιπή δεδομένα, δείτε [Έλεγχος της Εμφάνισης Κενού Κελιού](/slides/el/php-java/chart-series/) για τη διαφορά μεταξύ κενού κελιού και μηδενός, καθώς και για σύγκριση σε διάγραμμα γραμμής των διαθέσιμων τρόπων προβολής.

## **Συμπερίληψη Δεδομένων από Κρυμμένες Γραμμές και Στήλες**

Χρησιμοποιήστε [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/setplotvisiblecellsonly/) για να ελέγξετε αν ένα γράφημα σχεδιάζει δεδομένα από κρυμμένες γραμμές και στήλες φύλλου εργασίας. Ορίστε το σε `true` για να σχεδιάζει μόνο τα ορατά κελιά, ή σε `false` για να περιλαμβάνει τόσο τα ορατά όσο και τα κρυμμένα κελιά. Αυτή η ρύθμιση ελέγχει τη σχεδίαση του γραφήματος· δεν κρύβει ή αποκρύβει γραμμές ή στήλες φύλλου εργασίας.

Κατεβάστε [hidden-source-data.pptx](hidden-source-data.pptx) και τοποθετήστε το στον φάκελο εργασίας. Η πρώτη του διαφάνεια περιέχει ένα διάγραμμα στήλης ως το πρώτο σχήμα. Το ενσωματωμένο φύλλο εργασίας, `Sheet1`, περιέχει το εξής εύρος πηγής, `A1:C4`. Η γραμμή 3 και η στήλη C είναι κρυφές, αλλά τα κελιά τους εξακολουθούν να περιέχουν τιμές.

| Γραμμή φύλλου | A: Μήνας | B: Λιανική | C: Χονδρική (κρυφή στήλη) |
| --- | --- | --- | --- |
| 2 | Ιανουάριος | 10 | 30 |
| 3 (hidden row) | Φεβρουάριος | 40 | 60 |
| 4 | Μάρτιος | 20 | 50 |

Προσπελάστε τα κελιά πηγής μέσω [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/getchartdataworkbook/) και διαβάστε [ChartDataCell::isHidden](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatacell/ishidden/) για να ελέγξετε την κρυφή τους κατάσταση. Αυτή η μέθοδος αναφέρει την κατάσταση χωρίς να την αλλάξει. Στο αρχείο αυτό, το B2 είναι ορατό, το B3 ανήκει στη κρυφή γραμμή και το C2 στην κρυφή στήλη· το παράδειγμα εκτυπώνει `false`, `true` και `true`, αντίστοιχα.

Για αυτό το παράδειγμα, ανανεώστε τα δεδομένα του γραφήματος μετά την αλλαγή της ρύθμισης σχεδίασης: διατηρήστε τη ενσωματωμένη βιβλιοθήκη με [readWorkbookStream](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/readworkbookstream/) και επαναφορτώστε την με [writeWorkbookStream](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/writeworkbookstream/). Όταν περιλαμβάνονται όλα τα κελιά, χρησιμοποιήστε επίσης το [setRange](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/setrange/) για να επαναφέρετε το πλήρες εύρος, συμπεριλαμβανομένης της κρυφής κατηγορίας Φεβρουάριου. Η απλή αλλαγή της σημαίας δεν αρκεί για την ενημέρωση των δεδομένων και ετικετών κατηγορίας που είναι αποθηκευμένα στην κρυφή μνήμη του δείγματος.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // Ανανέωση των δεδομένων γραφήματος από την ενσωματωμένη βιβλιοθήκη.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Επαναφορά του πλήρους εύρους πηγής, συμπεριλαμβανομένων των κρυφών κατηγοριών.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Το παράδειγμα αποθηκεύει το `hidden_cells_true.pptx` μόνο με τις ορατές τιμές λιανικής (10 και 20), και το `hidden_cells_false.pptx` με όλες τις έξι τιμές. Οι εικόνες παρακάτω απεικονίζουν τις δύο λειτουργίες σχεδίασης. Η γραμμή 3 και η στήλη C παραμένουν κρυφές και στα δύο ενσωματωμένα βιβλιοθήκες.

| Μόνο τα ορατά κελιά (`true`) | Όλα τα κελιά (`false`) |
| --- | --- |
| ![Μόνα τα ορατά κελιά: τιμές λιανικής 10 και 20 για Ιανουάριο και Μάρτιο.](hidden_cells_True.png) | ![Όλα τα κελιά: τιμές λιανικής και χονδρικής για Ιανουάριο, Φεβρουάριο και Μάρτιο.](hidden_cells_False.png) |

Ένα κρυφό κελί που περιέχει τιμή διαφέρει από ένα κενό κελί. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/setdisplayblanksas/) ελέγχει πώς εμφανίζονται οι ελλιπείς τιμές· δεν περιλαμβάνει ή εξαιρεί κρυφά δεδομένα πηγής. Δείτε [Έλεγχος της Εμφάνισης Κενού Κελιού](/slides/el/php-java/chart-series/#control-the-display-of-empty-cells) για ένα παράδειγμα.

## **Ανάγνωση και Εγγραφή Δεδομένων Γραφήματος από Βιβλιοθήκη**

Aspose.Slides for PHP via Java παρέχει τις μεθόδους [readWorkbookStream](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/readworkbookstream/) και [writeWorkbookStream](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/writeworkbookstream/) που επιτρέπουν την ανάγνωση και εγγραφή βιβλιοθηκών δεδομένων γραφήματος (περιέχουσες δεδομένα γραφήματος επεξεργασμένα με Aspose.Cells). **Σημείωση** ότι τα δεδομένα γραφήματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν παρόμοια δομή με την πηγή.

Αυτό το παράδειγμα ανοίγει το `chart.pptx`, το οποίο πρέπει να περιέχει ένα γράφημα ως το πρώτο σχήμα στην πρώτη του διαφάνεια. Διαβάζει την ενσωματωμένη βιβλιοθήκη σε ένα πίνακα byte, καθαρίζει τις υπάρχουσες σειρές και κατηγορίες, και γράφει την ίδια βιβλιοθήκη πίσω. Οι αλλαγές παραμένουν στη μνήμη· το παράδειγμα δεν αποθηκεύει την παρουσίαση.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Επικύρωση Διάταξης Γραφήματος μετά την Τροποποίηση της Βιβλιοθήκης**

Όταν αντικαθιστάτε μια ενσωματωμένη βιβλιοθήκη με μια τροποποιημένη, το γράφημα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυμφωνία μπορεί να προκαλέσει αποτυχία του [Chart::validateChartLayout](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/validatechartlayout/) με σφάλμα «index-out-of-range». Καθαρίστε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε τη ενημερωμένη βιβλιοθήκη πίσω στο γράφημα. Αυτό το παράδειγμα απαιτεί το `chart.pptx` με γράφημα ως το πρώτο σχήμα στην πρώτη διαφάνειά του. Το σχόλιο δείχνει πού θα γινόταν η επεξεργασία της βιβλιοθήκης· το εκτελέσιμο παράδειγμα γράφει την αρχική βιβλιοθήκη πίσω και επικυρώνει τη διάταξη στη μνήμη.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // Τροποποιήστε τα byte της βιβλιοθήκης εδώ, για παράδειγμα, χρησιμοποιώντας το Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Η εκκαθάριση των συλλογών αφαιρεί παλαιές αναφορές δεδομένων πριν τη βιβλιοθήκη γραφεί πίσω. Ανακατασκευάστε τυχόν απαιτούμενες αντιστοιχίες σειρών και κατηγοριών για την ενημερωμένη βιβλιοθήκη πριν χρησιμοποιήσετε το γράφημα.

## **Ορισμός Κελιού Βιβλιοθήκης ως Ετικέτα Δεδομένων Γραφήματος**

Μπορείτε να χρησιμοποιήσετε κείμενο από κελιά βιβλιοθήκης ως ετικέτες δεδομένων γραφήματος. Τα παρακάτω βήματα δείχνουν πώς να συνδέσετε τις ετικέτες σε ένα διάγραμμα φυσαλίδων με κελιά στο βιβλιοθήκη δεδομένων του.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Προσπελάστε την πρώτη διαφάνεια με βάση το μηδενικό της δείκτη.
3. Προσθέστε ένα διάγραμμα φυσαλίδων με προεπιλεγμένα δεδομένα.
4. Προσπελάστε τις σειρές του γραφήματος.
5. Ορίστε το κελί της βιβλιοθήκης ως ετικέτα δεδομένων.
6. Αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα ανοίγει το `chart2.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια, και προσθέτει ένα διάγραμμα φυσαλίδων με προεπιλεγμένα δεδομένα. Χρησιμοποιεί τα κελιά A10:A12 στο φύλλο 0 για τις τρεις πρώτες ετικέτες στην πρώτη σειρά, ενεργοποιεί ετικέτες από κελιά, και αποθηκεύει το αποτέλεσμα στο `resultchart.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Διαχείριση Φύλλων Εργασίας**

Η μέθοδος [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/getworksheets/) παρέχει πρόσβαση στα φύλλα εργασίας μιας βιβλιοθήκης γραφήματος. Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα πίτας με προεπιλεγμένα δεδομένα και εκτυπώνει το όνομα κάθε φύλλου στην κονσόλα.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Καθορισμός Τύπου Πηγής Δεδομένων**

Αυτό το παράδειγμα δημιουργεί ένα τρισδιάστατο διάγραμμα στήλης με προεπιλεγμένα δεδομένα και ορίζει δύο ονόματα σειρών χρησιμοποιώντας διαφορετικές πηγές δεδομένων. Το πρώτο όνομα χρησιμοποιεί αλφαριθμητικό κυρίως· το δεύτερο χρησιμοποιεί το κελί C1 στο φύλλο 0. Η αρίθμηση [DataSourceType](https://reference.aspose.com/slides/el/php-java/aspose.slides/datasourcetype/) επιλέγει την πηγή για κάθε όνομα. Το αποτέλεσμα αποθηκεύεται στο `pres.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλιοθήκης**

Το Aspose.Slides δεν υποστηρίζει τη μορφή εργασίας Excel δυαδικού αρχείου (.xlsb) που μπορεί να ενσωματωθεί σε ορισμένα γραφήματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο `getEmbeddedWorkbookType` στο [ChartData](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/) μαζί με την αρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/php-java/aspose.slides/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα γραφήματα. Αυτό το παράδειγμα εξετάζει τα σχήματα στην πρώτη διαφάνεια του `sample.pptx`, παραλείπει μη‑γράφημα σχήματα, και εκτυπώνει ένα διαγνωστικό μήνυμα για κάθε γράφημα με ενσωματωμένη βιβλιοθήκη .xlsb.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // Διαβάστε ή τροποποιήστε τα υποστηριζόμενα δεδομένα βιβλιοθήκης γραφήματος εδώ.
    }
} finally {
    $presentation->dispose();
}
```

## **Εξωτερική Βιβλιοθήκη**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλιοθηκών ως πηγή δεδομένων για γραφήματα.

### **Δημιουργία Εξωτερικής Βιβλιοθήκης**

Χρησιμοποιήστε τα [readWorkbookStream](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/readworkbookstream/) και [setExternalWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/setexternalworkbook/) για να εξάγετε μια ενσωματωμένη βιβλιοθήκη γραφήματος σε αρχείο και να συνδέσετε το γράφημα με αυτήν την εξωτερική βιβλιοθήκη.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα πίτας με προεπιλεγμένα δεδομένα, γράφει τη βιβλιοθήκη του σε `externalWorkbook1.xlsx`, και ολοκληρώνει την εγγραφή του αρχείου πριν το αντιστοιχίσει ως πηγή δεδομένων γραφήματος. Αποθηκεύει την ενωμένη παρουσίαση στο `externalWorkbook.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Ορισμός Εξωτερικής Βιβλιοθήκης**

Με τη μέθοδο [setExternalWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/setexternalworkbook/) μπορείτε να εκχωρήσετε μια εξωτερική βιβλιοθήκη σε ένα γράφημα ως πηγή δεδομένων του. Η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για την ενημέρωση της διαδρομής προς την εξωτερική βιβλιοθήκη (αν αυτή έχει μετακινηθεί).

Αν και δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλιοθήκες που βρίσκονται σε απομακρυσμένες θέσεις ή πόρους, μπορείτε να τις χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για εξωτερική βιβλιοθήκη, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτό το παράδειγμα απαιτεί το `externalWorkbook.xlsx` στον φάκελο εργασίας. Το φύλλο του με όνομα `Sheet1` πρέπει να περιέχει ένα όνομα σειράς στο B1, ονόματα κατηγοριών στο A2:A4 και αριθμητικές τιμές στο B2:B4. Το παράδειγμα δημιουργεί ένα διάγραμμα πίτας, συνδέει τη βιβλιοθήκη, και χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/setrange/) για να αντιστοιχίσει το A1:B4 σε μία σειρά και τρεις κατηγορίες. Αποθηκεύει το αποτέλεσμα στο `Presentation_with_externalWorkbook.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η παράμετρος `updateChartData` της [setExternalWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/setexternalworkbook/) ελέγχει αν η βιβλιοθήκη θα φορτωθεί.

* Όταν το `updateChartData` είναι `false`, ενημερώνεται μόνο η διαδρομή της βιβλιοθήκης. Τα δεδομένα του γραφήματος δεν φορτώνονται ούτε ενημερώνονται από τη βιβλιοθήκη προορισμού, ώστε η βιβλιοθήκη να μπορεί να μην είναι διαθέσιμη.
* Όταν το `updateChartData` είναι `true`, τα δεδομένα του γραφήματος ενημερώνονται από τη βιβλιοθήκη προορισμού.

Το παρακάτω παράδειγμα αντιστοιχίζει μια εικονική διεύθυνση URL με `updateChartData` ορισμένο σε `false`. Διατηρεί τα προεπιλεγμένα δεδομένα του διαγράμματος πίτας και αποθηκεύει την παρουσίαση χωρίς να φορτώσει τη μη διαθέσιμη βιβλιοθήκη.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ανάκτηση Διαδρομής Εξωτερικής Βιβλιοθήκης Πηγής Δεδομένων ενός Γραφήματος**

Για να προσδιορίσετε τη βιβλιοθήκη που συνδέεται με ένα γράφημα, πρώτα ελέγξτε αν το γράφημα χρησιμοποιεί εξωτερική πηγή δεδομένων. Εάν ναι, μπορείτε να ανακτήσετε τη διαδρομή της βιβλιοθήκης ακολουθώντας τα παρακάτω βήματα.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Προσπελάστε την πρώτη διαφάνεια με βάση το μηδενικό της δείκτη.
3. Ελέγξτε ότι το πρώτο σχήμα είναι γράφημα.
4. Διαβάστε τον τύπο πηγής δεδομένων του γραφήματος.
5. Εάν η πηγή είναι εξωτερική βιβλιοθήκη, διαβάστε τη διαδρομή της.

Αυτό το παράδειγμα ανοίγει το `externalWorkbook.pptx`, που δημιουργήθηκε στο προηγούμενο παράδειγμα, και εξετάζει το πρώτο σχήμα στην πρώτη διαφάνεια. Εάν είναι γράφημα συνδεδεμένο σε εξωτερική βιβλιοθήκη, το παράδειγμα εκτυπώνει το [getExternalWorkbookPath](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/getexternalworkbookpath/) στην κονσόλα. Στη συνέχεια αποθηκεύει ένα αντίγραφο της παρουσίασης στο `Result.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Επεξεργασία Δεδομένων Γραφήματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικές βιβλιοθήκες με τον ίδιο τρόπο που κάνετε αλλαγές στα εσωτερικά αρχεία βιβλιοθήκης. Όταν μια εξωτερική βιβλιοθήκη δεν μπορεί να φορτωθεί, προκαλείται εξαίρεση.

Αυτό το παράδειγμα απαιτεί το `presentation.pptx` με ένα γράφημα ως το πρώτο σχήμα στην πρώτη διαφάνεια και μια προσβάσιμη εξωτερική βιβλιοθήκη. Ορίζει την τιμή του πρώτου σημείου δεδομένων στην πρώτη σειρά σε 100 και αποθηκεύει την παρουσίαση στο `presentation_out.pptx`. Η επεξεργασία τιμών κελιών μπορεί να ενημερώσει το συνδεδεμένο εξωτερικό αρχείο XLSX· χρησιμοποιήστε ένα αντίγραφο εάν πρέπει να διατηρήσετε την αρχική βιβλιοθήκη.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Ανάκτηση Βιβλιοθήκης από την Κρυφή Μνήμη Γραφήματος**

Εάν ένα γράφημα χρησιμοποιεί εξωτερική βιβλιοθήκη που λείπει ή δεν είναι διαθέσιμη, το Aspose.Slides μπορεί να ανασυνθέσει τη βιβλιοθήκη γραφήματος από τα δεδομένα που είναι αποθηκευμένα στην κρυφή μνήμη της παρουσίασης. Δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/), καλέστε το [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), και ορίστε το [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/el/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) σε `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα PHP ανοίγει το `presentation.pptx`, του οποίου το πρώτο σχήμα στην πρώτη διαφάνεια πρέπει να είναι ένα γράφημα που αναφέρεται σε μη διαθέσιμη εξωτερική βιβλιοθήκη, και προσπελάζει τα ανακτημένα δεδομένα μέσω του [Chart::getChartData](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/getchartdata/) και του [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/getchartdataworkbook/):

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // Διαβάστε ή τροποποιήστε τα ανακτημένα δεδομένα βιβλιοθήκης εδώ.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Εάν η εξωτερική βιβλιοθήκη δεν είναι διαθέσιμη και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides προκαλεί εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων από την κρυφή μνήμη του γραφήματος αποτελεί αποδεκτό εναλλακτικό σενάριο, επειδή η κρυφή μνήμη μπορεί να μην περιέχει αλλαγές που έγιναν στη βιβλιοθήκη μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω αν ένα συγκεκριμένο γράφημα είναι συνδεδεμένο με εξωτερική ή ενσωματωμένη βιβλιοθήκη;**

Ναι. Ένα γράφημα διαθέτει έναν [τύπο πηγής δεδομένων](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/getdatasourcetype/) και μια [διαδρομή σε εξωτερική βιβλιοθήκη](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Εάν η πηγή είναι εξωτερική βιβλιοθήκη, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται οι σχετικές διαδρομές προς εξωτερικές βιβλιοθήκες και πώς αποθηκεύονται;**

Ναι. Εάν ορίσετε σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη. Η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX, οπότε η μετακίνηση της βιβλιοθήκης μπορεί να απαιτεί ενημέρωση του συνδέσμου.

**Μπορώ να χρησιμοποιήσω βιβλιοθήκες που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους δίσκους;**

Ναι, τέτοιες βιβλιοθήκες μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η άμεση επεξεργασία απομακρυσμένων βιβλιοθηκών από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό XLSX όταν αποθηκεύει την παρουσίαση;**

Η παρουσίαση αποθηκεύει έναν [σύνδεσμο στο εξωτερικό αρχείο](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Η επεξεργασία δεδομένων γραφήματος που βασίζονται σε κελιά μπορεί επίσης να ενημερώσει το τοπικό αρχείο XLSX. Χρησιμοποιήστε ένα αντίγραφο της βιβλιοθήκης εάν το αρχικό πρέπει να παραμείνει αμετάβλητο.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης όταν γίνεται σύνδεση. Μια κοινή προσέγγιση είναι η αφαίρεση της προστασίας εκ των προτέρων ή η δημιουργία ενός αποκρυπτογραφημένου αντιγράφου (π.χ. με τη χρήση [Aspose.Cells](https://reference.aspose.com/cells/java/)) και η σύνδεση σε αυτό το αντίγραφο.

**Μπορούν πολλά γραφήματα να αναφέρονται στην ίδια εξωτερική βιβλιοθήκη;**

Ναι. Κάθε γράφημα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντανακλάται σε κάθε γράφημα την επόμενη φορά που θα φορτωθούν τα δεδομένα.