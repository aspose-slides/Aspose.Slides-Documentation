---
title: Διαχείριση βιβλίων εργασίας διαγραμμάτων σε παρουσιάσεις με χρήση PHP
linktitle: Βιβλίο εργασίας διαγράμματος
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
- cache διαγράμματος
- ανάκτηση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για PHP μέσω Java: διαχειριστείτε εύκολα τα βιβλία εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που συνδέεται με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

Για κελιά βιβλίου εργασίας που αντιπροσωπεύουν ελλιπείς τιμές, δείτε [Control the Display of Empty Cells](/slides/el/php-java/chart-series/) για τη διαφορά μεταξύ κενού κελιού και μηδενικού, καθώς και μια σύγκριση γραμμικού διαγράμματος των διαθέσιμων τρόπων εμφάνισης.

## **Συμπερίληψη Δεδομένων από Κρυφές Γραμμές και Στήλες**

Χρησιμοποιήστε [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) για να ελέγξετε εάν ένα διάγραμμα σχεδιάζει δεδομένα από κρυφές γραμμές και στήλες φύλλου εργασίας. Ορίστε το σε `true` για να σχεδιάζονται μόνο ορατά κελιά ή σε `false` για να συμπεριλαμβάνονται και τα ορατά και τα κρυφά κελιά. Αυτή η ρύθμιση ελέγχει την σχεδίαση του διαγράμματος· δεν κρύβει ή εμφανίζει γραμμές ή στήλες του φύλλου εργασίας.

Η [sample presentation](hidden-source-data.pptx) περιέχει ένα ραβδοδιάγραμμα ως το πρώτο σχήμα στην πρώτη διαφάνειά της. Το ενσωματωμένο φύλλο εργασίας, `Sheet1`, περιέχει την εξής περιοχή προέλευσης, `A1:C4`. Η γραμμή 3 και η στήλη C είναι κρυφές, αλλά τα κελιά τους εξακολουθούν να περιέχουν τιμές.

| Γραμμή φύλλου εργασίας | A: Μήνας | B: Λιανική | C: Χονδρική (κρυφή στήλη) |
| --- | --- | --- | --- |
| 2 | Ιανουάριος | 10 | 30 |
| 3 (κρυφή γραμμή) | Φεβρουάριος | 40 | 60 |
| 4 | Μάρτιος | 20 | 50 |

Πρόσβαση στα κελιά προέλευσης μέσω [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) και ανάγνωση του [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) για έλεγχο της κρυφής κατάστασής τους. Αυτή η μέθοδος αναφέρει την κρυφή κατάσταση χωρίς να την αλλάξει. Σε αυτό το αρχείο, το B2 είναι ορατό, το B3 ανήκει στην κρυφή γραμμή και το C2 ανήκει στην κρυφή στήλη· το παράδειγμα εκτυπώνει `false`, `true` και `true`, αντίστοιχα.

Για το παράδειγμα, ανανεώστε τα δεδομένα του διαγράμματος μετά την αλλαγή της ρύθμισης σχεδίασης: διατηρήστε το ενσωματωμένο βιβλίο εργασίας με [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) και φορτώστε το ξανά με [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Όταν συμπεριλαμβάνονται όλα τα κελιά, χρησιμοποιήστε επίσης το [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) για να αποκαταστήσετε το πλήρες εύρος, συμπεριλαμβανομένης της κρυφής κατηγορίας Φεβρουαρίου. Η απλή αλλαγή της σημαίας δεν αρκεί για την ανανέωση των δεδομένων και των ετικετών κατηγορίας του δείγματος.

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

            // Ανανέωση των δεδομένων του διαγράμματος από το ενσωματωμένο βιβλίο εργασίας.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Επαναφορά του πλήρους εύρους προέλευσης, συμπεριλαμβανομένων των κρυφών κατηγοριών.
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

Το παράδειγμα αποθηκεύει δύο εκδόσεις της παρουσίασης: μία με μόνο τις ορατές τιμές Λιανικής (10 και 20) και μια άλλη με όλες τις έξι τιμές. Οι εικόνες παρακάτω δείχνουν τους δύο τρόπους σχεδίασης. Η γραμμή 3 και η στήλη C παραμένουν κρυφές και στα δύο ενσωματωμένα βιβλία εργασίας.

| Μόνο ορατά κελιά (`true`) | Όλα τα κελιά (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Ένα κρυφό κελί που περιέχει τιμή διαφέρει από ένα κενό κελί. Το [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) ελέγχει πώς εμφανίζονται οι ελλιπείς τιμές· δεν περιλαμβάνει ή εξαιρεί κρυφά δεδομένα προέλευσης. Δείτε [Control the Display of Empty Cells](/slides/el/php-java/chart-series/#control-the-display-of-empty-cells) για παράδειγμα.

## **Ανάκτηση Εύρους Δεδομένων Διαγράμματος**

Πριν ενημερώσετε δεδομένα βιβλίου εργασίας σε υπάρχουσα παρουσίαση, εξετάστε τα εύρη προέλευσης για να εντοπίσετε ποια κελιά φύλλου εργασίας χρησιμοποιεί το κάθε διάγραμμα. Η μέθοδος [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) επιστρέφει το τρέχον εύρος δεδομένων ως τύπο τύπου φύλλου εργασίας, π.χ. `Sheet1!$A$1:$D$5`. Εδώ, `Sheet1` είναι το όνομα του φύλλου, το `!` το χωρίζει από το εύρος κελιών και το `$A$1:$D$5` ορίζει τα κελιά A1 έως D5, συμπεριλαμβανομένων. Τα σύμβολα δολαρίου δηλώνουν απόλυτες αναφορές γραμμής και στήλης.

Η μέθοδος διαβάζει το τρέχον εύρος χωρίς να αλλάζει το διάγραμμα ή το βιβλίο εργασίας του. Εάν το διάγραμμα δεν χρησιμοποιεί βιβλίο εργασίας ως πηγή δεδομένων, ρίχνει εξαίρεση. Για περισσότερες πληροφορίες, δείτε το [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Αυτό το παράδειγμα ανοίγει μια παρουσίαση και ελέγχει τα σχήματα απευθείας σε κάθε διαφάνεια για διαγράμματα. Εκτυπώνει το όνομα και το εύρος προέλευσης του κάθε διαγράμματος. Εάν ένα διάγραμμα δεν χρησιμοποιεί βιβλίο εργασίας, εκτυπώνει ένα μήνυμα και προχωρά στο επόμενο διάγραμμα.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Βιβλίο Εργασίας**

Το Aspose.Slides for PHP via Java παρέχει τις μεθόδους [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) και [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) που επιτρέπουν την ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων διαγράμματος (περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Note** ότι τα δεδομένα του διαγράμματος πρέπει να οργανωθούν με τον ίδιο τρόπο ή να έχουν παρόμοια δομή με την πηγή.

Αυτό το παράδειγμα χρησιμοποιεί μια παρουσίαση με διάγραμμα ως πρώτο σχήμα στην πρώτη διαφάνειά της. Διαβάζει το ενσωματωμένο βιβλίο εργασίας σε πίνακα byte, διαγράφει τις υπάρχουσες σειρές και κατηγορίες και γράφει ξανά το ίδιο βιβλίο εργασίας. Οι αλλαγές παραμένουν στη μνήμη· το παράδειγμα δεν αποθηκεύει την παρουσίαση.

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

### **Επικύρωση Διάταξης Διαγράμματος μετά την Τροποποίηση του Βιβλίου Εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το διάγραμμα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτό το ασυμφωνία μπορεί να κάνει το [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) να αποτύχει με σφάλμα εκτός εύρους ευρετήρων. Διαγράψτε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε ξανά το ενημερωμένο βιβλίο εργασίας στο διάγραμμα. Το παράδειγμα χρησιμοποιεί ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια. Η σημείωση δείχνει πού θα γινόταν η επεξεργασία του βιβλίου εργασίας· το εκτελέσιμο παράδειγμα γράφει το αρχικό βιβλίο εργασίας πίσω και επικυρώνει τη διάταξη στη μνήμη.

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

        // Τροποποιήστε τα byte του βιβλίου εργασίας εδώ, για παράδειγμα χρησιμοποιώντας το Aspose.Cells.

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

Η διαγραφή των συλλογών αφαιρεί παλαιές αναφορές δεδομένων πριν το βιβλίο εργασίας γραφτεί ξανά. Ξαναχτίστε τυχόν απαιτούμενες αντιστοιχίσεις σειρών και κατηγοριών για το ενημερωμένο βιβλίο εργασίας πριν χρησιμοποιήσετε το διάγραμμα.

## **Ορισμός Προσαρμοσμένων Μορφών Αριθμών για Κελιά Βιβλίου Εργασίας**

Χρησιμοποιήστε [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) για να ελέγξετε πώς εμφανίζονται οι αριθμητικές τιμές στο ενσωματωμένο βιβλίο εργασίας ενός διαγράμματος. Για παράδειγμα, μια αναφορά μπορεί να χρειάζεται το ποσοστό μετατροπής εμφανιζόμενο ως ποσοστό με τέσσερα δεκαδικά ψηφία και έναν συντελεστή με πέντε δεκαδικά ψηφία. Διατηρήστε και τις δύο τιμές αριθμητικές ώστε να παραμένουν διαθέσιμες για υπολογισμούς και σχεδίαση διαγράμματος.

Μια μορφή αριθμού αλλάζει την εμφάνιση, όχι την αποθηκευμένη τιμή. Η μορφή `0.0000%` εμφανίζει το `0.125` ως `12.5000%`; δεν αντικαθιστά τον αποθηκευμένο αριθμό με `12.5`. Ομοίως, το `0.00000` εμφανίζει το `0.1234567` ως `0.12346` χωρίς στρογγυλοποίηση της αποθηκευμένης τιμής. Εάν η προσαρμοσμένη μορφή είναι κενή συμβολοσειρά (`""`), χρησιμοποιείται η μορφή που επιστρέφει το [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/).

Το παρακάτω παράδειγμα δημιουργεί ένα ραβδοδιάγραμμα και προσπελάζει τα κελιά του μέσω [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). Στο φύλλο εργασίας 0, το B2 περιέχει το ποσοστό μετατροπής και το C2 περιέχει τον συντελεστή. Και τα δύο κελιά παρέχουν τιμές στο διάγραμμα. Το παράδειγμα ενεργοποιεί επίσης ετικέτες τιμών συνδεδεμένες με τις μορφές προέλευσης.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Οι μορφές κελιών βιβλίου εργασίας είναι ξεχωριστές από τις μορφές που ορίζονται απευθείας σε άξονες ή ετικέτες δεδομένων διαγράμματος. Σε αυτό το παράδειγμα, κάθε ετικέτα εμφανίζει την τιμή του κελιού προέλευσης επειδή το [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) είναι ορισμένο σε `true` και ακολουθεί τη μορφή αριθμού προέλευσης επειδή το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) είναι επίσης `true`. Μετά την αποθήκευση και το άνοιγμα ξανά της παρουσίασης, οι ετικέτες εμφανίζουν `12.5000%` και `0.12346`, όπως φαίνεται παρακάτω. Ο κατακόρυφος άξονας χρησιμοποιεί τη δική του μορφή αριθμού, ορισμένη με το [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) ως `0.00`, με το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) ορισμένο σε `false`.

Για ανεξάρτητη μορφοποίηση ετικέτας, ορίστε τη σημαία σύνδεσης προέλευσης σε `false` και ορίστε μια μορφή με το [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). Αυτό δεν αλλάζει τη μορφή του κελιού βιβλίου εργασίας. Για παράδειγμα, μια ανεξάρτητη μορφή ετικέτας `0.00` εμφανίζει την πρώτη τιμή ως `0.13`, ενώ το B2 εξακολουθεί να εμφανίζει `12.5000%`. Δείτε [Chart Data Labels](/slides/el/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) για άμεση μορφοποίηση ετικετών.

Η παρακάτω εικόνα δημιουργήθηκε από την αποθηκευμένη παρουσίαση μετά το άνοιγμα της:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **Ορισμός Κελιού Βιβλίου Εργασίας ως Ετικέτας Δεδομένων Διαγράμματος**

Μπορείτε να χρησιμοποιήσετε κείμενο από κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος.

Αυτό το παράδειγμα προσθέτει ένα διάγραμμα φυσαλίδων με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Χρησιμοποιεί τα κελιά A10:A12 στο φύλλο εργασίας 0 για τις τρεις πρώτες ετικέτες της πρώτης σειράς, ενεργοποιεί ετικέτες από κελιά και αποθηκεύει την ενημερωμένη παρουσίαση.

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

Η μέθοδος [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) παρέχει πρόσβαση στα φύλλα εργασίας ενός βιβλίου εργασίας διαγράμματος. Αυτό το παράδειγμα δημιουργεί ένα κυκλικό διάγραμμα με προεπιλεγμένα δεδομένα και εκτυπώνει το όνομα κάθε φύλλου εργασίας στην κονσόλα.

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

Οι τιμές σημείων σειράς μπορούν επίσης να αποθηκευτούν απευθείας ως αριθμητικά literals. Δείτε το [Set Series Values Using Numeric Literals](/slides/el/php-java/chart-series/#set-series-values-using-numeric-literals) για ένα πλήρες παράδειγμα που τις αποθηκεύει και τις διαβάζει. Ο τύπος πηγής των τιμών σημείου είναι ξεχωριστός από την εσωτερική ή εξωτερική διαμόρφωση βιβλίου εργασίας του διαγράμματος· η χρήση αριθμητικών literals δεν αφαιρεί, από μόνη της, το ενσωματωμένο βιβλίο εργασίας.

Αυτό το παράδειγμα δημιουργεί ένα 3Δ διάγραμμα στήλης με προεπιλεγμένα δεδομένα και ορίζει δύο ονόματα σειρών χρησιμοποιώντας διαφορετικές πηγές δεδομένων. Το πρώτο όνομα χρησιμοποιεί string literal· το δεύτερο χρησιμοποιεί το κελί C1 στο φύλλο εργασίας 0. Η απαρίθμηση [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) επιλέγει την πηγή για κάθε όνομα. Το παράδειγμα αποθηκεύει την παρουσίαση με τα ενημερωμένα ονόματα σειρών.

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

## **Εντοπισμός Μη Υποστηριζόμενων Μορφών Ενσωματωμένου Βιβλίου Εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη μορφή βιβλίου εργασίας Excel binary (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο `getEmbeddedWorkbookType` στο [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε εκείνα τα διαγράμματα. Το παράδειγμα εξετάζει τα σχήματα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης, παραλείπει μη-διάγραμμα σχήματα και εκτυπώνει ένα διαγνωστικό μήνυμα για κάθε διάγραμμα με ενσωματωμένο βιβλίο εργασίας .xlsb.

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

        // Διαβάστε ή τροποποιήστε τα υποστηριζόμενα δεδομένα βιβλίου εργασίας διαγράμματος εδώ.
    }
} finally {
    $presentation->dispose();
}
```

## **Εξωτερικό Βιβλίο Εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για διαγράμματα.

### **Δημιουργία Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιήστε τα [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) και [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) για να εξάγετε ένα ενσωματωμένο βιβλίο εργασίας διαγράμματος σε αρχείο και να συνδέσετε το διάγραμμα με αυτό το εξωτερικό βιβλίο εργασίας.

Αυτό το παράδειγμα δημιουργεί ένα κυκλικό διάγραμμα με προεπιλεγμένα δεδομένα και εξάγει το βιβλίο εργασίας του. Ολοκληρώνει τη εγγραφή του αρχείου πριν αντιστοιχίσει το εξωτερικό βιβλίο εργασίας ως πηγή δεδομένων του διαγράμματος, στη συνέχεια αποθηκεύει την συνδεδεμένη παρουσίαση.

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

### **Ορισμός Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τη μέθοδο [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), μπορείτε να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για την ενημέρωση διαδρομής προς το εξωτερικό βιβλίο εργασίας (αν αυτό έχει μετακινηθεί).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας αποθηκευμένα σε απομακρυσμένες θέσεις ή πόρους, μπορείτε ακόμα να τα χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτό το παράδειγμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας του οποίου το φύλλο εργασίας με όνομα `Sheet1` περιέχει ένα όνομα σειράς στο B1, ονόματα κατηγοριών στο A2:A4 και αριθμητικές τιμές στο B2:B4. Το παράδειγμα δημιουργεί ένα κυκλικό διάγραμμα, συνδέει το βιβλίο εργασίας και χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) για να χαρτογραφήσει το A1:B4 σε μια σειρά και τρεις κατηγορίες. Αποθηκεύει την παρουσίαση με το συνδεδεμένο διάγραμμα.

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

Η παράμετρος `updateChartData` της μεθόδου [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) ελέγχει εάν το βιβλίο εργασίας φορτώνεται.

* Όταν `updateChartData` είναι `false`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας. Τα δεδομένα του διαγράμματος δεν φορτώνονται ή ενημερώνονται από το προοριζόμενο βιβλίο εργασίας, ώστε το βιβλίο εργασίας να μπορεί να είναι μη διαθέσιμο.
* Όταν `updateChartData` είναι `true`, τα δεδομένα του διαγράμματος ενημερώνονται από το προοριζόμενο βιβλίο εργασίας.

Το παρακάτω παράδειγμα αντιστοιχίζει μια εικονική διεύθυνση URL με `updateChartData` ορισμένο σε `false`. Διατηρεί τα προεπιλεγμένα δεδομένα του κυκλικού διαγράμματος και αποθηκεύει την παρουσίαση χωρίς τη φόρτωση του μη διαθέσιμου βιβλίου εργασίας.

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

### **Λήψη Διαδρομής Εξωτερικού Πηγής Βιβλίου Εργασίας ενός Διαγράμματος**

Για να εντοπίσετε το βιβλίο εργασίας που συνδέεται με ένα διάγραμμα, ελέγξτε εάν το διάγραμμα χρησιμοποιεί εξωτερική πηγή δεδομένων και ανακτήστε τη διαδρομή του βιβλίου εργασίας.

Αυτό το παράδειγμα εξετάζει το πρώτο σχήμα στην πρώτη διαφάνεια μιας παρουσίασης με εξωτερικό βιβλίο εργασίας συνδεδεμένο. Εάν πρόκειται για διάγραμμα συνδεδεμένο με εξωτερικό βιβλίο εργασίας, το παράδειγμα εκτυπώνει το [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) στην κονσόλα. Στη συνέχεια αποθηκεύει ένα αντίγραφο της παρουσίασης.

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

### **Επεξεργασία Δεδομένων Διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας όπως θα κάνατε με εσωτερικά βιβλία εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, ρίχνεται εξαίρεση.

Αυτό το παράδειγμα χρησιμοποιεί ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και είναι συνδεδεμένο με προσβάσιμο εξωτερικό βιβλίο εργασίας. Ορίζει την τιμή του πρώτου σημείου δεδομένων στην πρώτη σειρά σε 100 και αποθηκεύει την ενημερωμένη παρουσίαση. Η επεξεργασία τιμών κελιών μπορεί να ενημερώσει το συνδεδεμένο εξωτερικό αρχείο XLSX· χρησιμοποιήστε ένα αντίγραφο εάν πρέπει να διατηρήσετε το αρχικό βιβλίο εργασίας.

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

### **Ανάκτηση Βιβλίου Εργασίας από την Cache του Διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να ανακατασκευάσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που έχουν αποθηκευτεί στην cache της παρουσίασης. Δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), καλέστε το [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) και ορίστε το [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) σε `true` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα PHP ανακτά δεδομένα βιβλίου εργασίας για ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και αναφέρεται σε μη διαθέσιμο εξωτερικό βιβλίο εργασίας. Πρόσβαση στα δεδομένα γίνεται μέσω του [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) και του [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Διαβάστε ή τροποποιήστε τα ανακτημένα δεδομένα του βιβλίου εργασίας εδώ.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Εάν το εξωτερικό βιβλίο εργασίας είναι μη διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων της cache του διαγράμματος είναι αποδεκτή εναλλακτική λύση, επειδή η cache μπορεί να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Μπορώ να καθορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα έχει έναν [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) και μια [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX, επομένως η μετακίνηση του βιβλίου εργασίας μπορεί να απαιτεί ενημέρωση του συνδέσμου.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/μοιράσματα;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η άμεση επεξεργασία απομακρυσμένων βιβλίων εργασίας από το Aspose.Slides δεν υποστηρίζεται — μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Η επεξεργασία τιμών που προέρχονται από κελιά μπορεί επίσης να ενημερώσει το τοπικό αρχείο XLSX. Χρησιμοποιήστε ένα αντίγραφο του βιβλίου εργασίας εάν το αρχικό πρέπει να παραμείνει αμετάβλητο.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης όταν συνδέεται. Μία συνήθης προσέγγιση είναι η αφαίρεση της προστασίας εκ των προτέρων ή η προετοιμασία ενός αποκρυπτογραφημένου αντιγράφου (π.χ., χρησιμοποιώντας το [Aspose.Cells](https://reference.aspose.com/cells/java/)) και η σύνδεση στο αντίγραφο αυτό.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτριστεί σε κάθε διάγραμμα την επόμενη φορά που τα δεδομένα θα φορτωθούν.