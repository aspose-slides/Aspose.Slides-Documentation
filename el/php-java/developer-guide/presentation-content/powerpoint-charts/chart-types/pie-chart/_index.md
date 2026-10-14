---
title: Προσαρμογή Διαγραμμάτων Πίτας σε Παρουσιάσεις Χρησιμοποιώντας PHP
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/php-java/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές σχεδίου
- χρώμα φέτας
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα πίτας σε PHP με Aspose.Slides. Διαμορφώστε δευτερεύουσες προβολές, εμφανίστε ετικέτες δεδομένων και εφαρμόστε αυτόματο χρώμα φετών στο PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με πίτες διαγράμματα στο Aspose.Slides. Δείχνει πώς να διαμορφώσετε επιλογές δευτερεύουσας προβολής για διαγράμματα Pie of Pie και Bar of Pie, και πώς να ενεργοποιήσετε αυτόματο χρώμα των φετών για ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα επικεντρώνονται σε εργασίες προσαρμογής διαγράμματος, όπως η προσθήκη διαγράμματος σε μια διαφάνεια, η προσαρμογή ρυθμίσεων σειρών και ετικετών, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Επιλογές Δευτερεύουσας Προβολής για Διαγράμματα Pie of Pie και Bar of Pie**

Το Aspose.Slides for PHP via Java υποστηρίζει επιλογές δευτερεύουσας προβολής για διαγράμματα Pie of Pie και Bar of Pie. Αυτές οι επιλογές ελέγχουν το μέγεθος της δευτερεύουσας προβολής και πώς τα σημεία δεδομένων διαχωρίζονται μεταξύ των δύο προβολών.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα Pie of Pie σε μια νέα παρουσίαση και εμφανίζει τις τιμές των σημείων δεδομένων ως ετικέτες. Η [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) μέθοδος ορίζει το μέγεθος της δευτερεύουσας προβολής στο 149% της κύριας προβολής. Η [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) επιλέγει διαχωρισμό βάσει ποσοστού, και η [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) ορίζει το όριο στο 53%.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // Εμφάνιση τιμών και διαμόρφωση της δευτερεύουσας προβολής.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Επιλογή Κατηγοριών για τη Δευτερεύουσα Προβολή**

Χρησιμοποιήστε προσαρμοσμένο διαχωρισμό όταν θέλετε να ομαδοποιήσετε συγκεκριμένες κατηγορίες στη δευτερεύουσα προβολή ανεξάρτητα από τις τιμές ποσοστού τους. Για παράδειγμα, μια αναφορά πωλήσεων μπορεί να εμφανίζει Online και Events μαζί ώστε οι αναγνώστες να μπορούν να συγκρίνουν αυτά τα δύο κανάλια, ακόμη και αν αντιπροσωπεύουν το 35% και το 10% των συνολικών πωλήσεων.

Κλήστε τη [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) με το [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) και επιλέξτε τα σημεία μέσω της [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Η μέθοδος [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) της συλλογής δέχεται έναν μηδενικό δείκτη στη σειρά· χρησιμοποιήστε το [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) για να προσθέσετε ένα αντικείμενο σημείου δεδομένων. Σε αυτό το παράδειγμα, ο δείκτης 1 επιλέγει το Online, και το σημείο με δείκτη 3 επιλέγει το Events. Η κατηγορία Partners προστίθεται επίσης προσωρινά, και στη συνέχεια εξαιρείται με τη [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // Αντικατάσταση των προεπιλεγμένων δεδομένων με πωλήσεις ανά κανάλι.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Επιλογή του Online με τον μηδενικό δείκτη του και του Events με το αντικείμενο σημείου δεδομένων.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Εξαίρεση του Partners από την επιλογή χωρίς διαγραφή των πηγαίων δεδομένων του.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το Online (35) και το Events (10) εμφανίζονται ως ξεχωριστές φέτες στη δευτερεύουσα προβολή. Στην κύρια προβολή, αντιπροσωπεύονται από μία συνδυασμένη φέτα με τιμή 45, μαζί με το Retail (40) και το Partners (15). Η αφαίρεση του Partners από την προσαρμοσμένη επιλογή το κρατά στην κύρια προβολή· δεν αφαιρεί την κατηγορία ή την τιμή της από τα πηγαία δεδομένα του διαγράμματος.

Η παρακάτω εικόνα δείχνει την αποθηκευμένη παρουσίαση στο PowerPoint:

![Διάγραμμα Pie of Pie με Online και Events στη δευτερεύουσα προβολή και την συνδυασμένη τιμή τους 45 στην κύρια προβολή](pie_of_pie_custom.png)

## **Ορισμός Αυτόματων Χρωμάτων Φετών για Διάγραμμα Πίτας**

Το Aspose.Slides for PHP via Java μπορεί αυτόματα να αναθέτει διαφορετικά χρώματα στις φέτες του διαγράμματος πίτας. Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα πίτας με κεντραρισμένο τίτλο και αντικαθιστά τα προεπιλεγμένα δεδομένα με τρεις τριμηνιαίες κατηγορίες και τις τιμές τους. Η [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) μέθοδος εμφανίζει τις τιμές 20, 50 και 30 ως ετικέτες, ενώ η [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) ενεργοποιεί διαφορετικό χρώμα για κάθε φέτα.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // Προσθήκη κεντραρισμένου τίτλου διαγράμματος.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // Αντικατάσταση των προεπιλεγμένων δεδομένων χρησιμοποιώντας το πρώτο φύλλο εργασίας.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // Εμφάνιση τιμών και εκχώρηση διαφορετικών χρωμάτων στις φέτες.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Είναι οι παραλλαγές Pie of Pie και Bar of Pie υποστηριζόμενες;**

Ναι, η βιβλιοθήκη [υποστηρίζει](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) μια δευτερεύουσα προβολή για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων Pie of Pie και Bar of Pie.

**Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξάγετε το ίδιο το διάγραμμα ως εικόνα](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (όπως PNG) χωρίς να εξάγετε ολόκληρη την παρουσίαση.