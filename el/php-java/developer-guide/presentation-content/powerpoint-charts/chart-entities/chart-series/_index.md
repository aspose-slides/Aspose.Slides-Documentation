---
title: Διαχείριση Σειρών Δεδομένων Γραφήματος σε Παρουσιάσεις με PHP
linktitle: Σειρές Δεδομένων
type: docs
url: /el/php-java/chart-series/
keywords:
- σειρά γραφήματος
- επικάλυψη σειράς
- χρώμα σειράς
- όνομα σειράς
- σημείο δεδομένων
- κελί βιβλίου εργασίας
- κενό σειράς
- αρνητική τιμή
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις σειρές γραφήματος, τα σημεία δεδομένων, τα κελιά βιβλίου εργασίας, τη μορφοποίηση, την επικάλυψη, το πλάτος κενών και τις αρνητικές τιμές σε παρουσιάσεις με PHP."
---
## **Επισκόπηση**

Ένα γράφημα μπορεί να αποθηκεύσει τις σχεδιασμένες τιμές του σε κελιά του βιβλίου εργασίας ή απευθείας ως αριθμητικά κυριολεκτικά. Ένα [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) αντιπροσωπεύει ένα σύνολο σχετικών τιμών, και κάθε [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) αντιπροσωπεύει ένα σημείο σε αυτή τη σειρά. Τα αντικείμενα [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) παρέχουν τις ετικέτες ή τις τιμές ομαδοποίησης που μοιράζονται οι σειρές. Σε γραφήματα που δημιουργούνται με προεπιλεγμένα δεδομένα, τα ονόματα σειρών, οι κατηγορίες και οι τιμές σημείων χρησιμοποιούν αντικείμενα [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) από το βιβλίο εργασίας του γραφήματος.

Για ένα τυπικό γράφημα κατηγορίας, το προεπιλεγμένο βιβλίο εργασίας χρησιμοποιεί τη γραμμή 0 για ονόματα σειρών, τη στήλη 0 για ονόματα κατηγοριών και τα υπόλοιπα κελιά για τιμές σειρών. Οι δείκτες φύλλου εργασίας, γραμμής και στήλης που περνιούνται στο [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) είναι μηδενικής βάσης. Αυτή η διάταξη είναι χρήσιμη όταν δημιουργείτε ένα γράφημα με προεπιλεγμένα δεδομένα, αλλά δεν υποθέτετε ότι κάθε υπάρχον γράφημα το χρησιμοποιεί. Για μια φορτωμένη παρουσίαση, εξετάστε τα κελιά στα οποία αναφέρονται οι σειρές, οι κατηγορίες και τα σημεία δεδομένων πριν αλλάξετε τις τιμές του βιβλίου εργασίας.

Οι ρυθμίσεις του γραφήματος έχουν τρεις διαφορετικές εμβέλειες:

- Ρυθμίσεις επιπέδου σειράς, όπως [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), παρέχουν την προεπιλεγμένη εμφάνιση για όλα τα σημεία σε μία σειρά.
- Ρυθμίσεις σημείου δεδομένων, όπως [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), παρακάμπτουν την εμφάνιση της σειράς για ένα σημείο.
- Οι ρυθμίσεις ομάδας εφαρμόζονται σε συμβατές σειρές που ανήκουν στην ίδια [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/). Πρόσβαση στην ομάδα μέσω [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) όταν χρειάζεται να ορίσετε επιλογές όπως η επικάλυψη ή το πλάτος κενών.

Όταν δεν έχει οριστεί ρητό γέμισμα σημείου ή σειράς, το στυλ και το θέμα του γραφήματος καθορίζουν την αυτόματη εμφάνιση. Όταν υπάρχουν τόσο μορφοποίηση σειράς όσο και σημείου, η μορφοποίηση του σημείου έχει προτεραιότητα για εκείνο το σημείο.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός Τιμών Σειράς Χρησιμοποιώντας Αριθμητικά Κυριολεκτικά**

Χρησιμοποιήστε αριθμητικά κυριολεκτικά όταν οι τιμές της σειράς προέρχονται από δεδομένα ή υπολογισμούς της εφαρμογής και δεν χρειάζονται αναφορές σε κελιά φύλλου εργασίας. Καλέστε [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) με [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) πριν εκχωρήσετε το αποτέλεσμα του [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) κάθε σημείου μέσω του [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Η ρύθμιση της συλλογής ελέγχει τον τύπο πηγής όλων των τιμών σημείων σε εκείνη τη σειρά. Κάθε μέθοδος [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) της τιμής σημείου αναφέρει τον επιλεγμένο τύπο· αλλάξτε το μέσω της ρύθμισης της συλλογής. Με `Worksheet`, χρησιμοποιήστε [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) για πρόσβαση στο αναφερόμενο κελί. Με `DoubleLiterals`, χρησιμοποιήστε [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) ή `setAsLiteralDouble` για ανάγνωση ή εγγραφή του αριθμού άμεσα.

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα στηλών με προεπιλεγμένες σειρές και κατηγορίες, στη συνέχεια εκχωρεί υπολογισμένες τιμές 10, 20 κ.λπ. στα υπάρχοντα σημεία της πρώτης σειράς. Αποθηκεύει την παρουσίαση, τη ξαναφορτώνει και εκτυπώνει τις αποθηκευμένες τιμές.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Ο τύπος πηγής τιμής σημείου είναι ξεχωριστός από το [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), που προσδιορίζει τη διαμόρφωση του εσωτερικού ή εξωτερικού βιβλίου εργασίας του γραφήματος. Η χρήση αριθμητικών κυριολεξικών δεν αφαιρεί από μόνο του το ενσωματωμένο βιβλίο εργασίας. Σε αυτό το παράδειγμα, το βιβλίο εργασίας παραμένει διαθέσιμο για ετικέτες κατηγοριών, ονόματα σειρών και τις άλλες σειρές. Δείτε το [Chart Workbook](/slides/el/php-java/chart-workbook/) για διαχείριση βιβλίου εργασίας.

Για διασυνταχτικά και φυσαλίδες γραφήματα, χρησιμοποιήστε [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) και [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) για να επιλέξετε τις πηγές των [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) και [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/). Τα γραφήματα φυσαλίδων χρησιμοποιούν επίσης [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) για το [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/). Ορίστε κάθε εφαρμοστέο τύπο σε `DoubleLiterals` πριν εκχωρήσετε αριθμούς μέσω της μεθόδου `setAsLiteralDouble` της τιμής.

## **Ορισμός Επικάλυψης Σειράς Γραφήματος**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) αναφέρει πόσο οι μπάρες ή οι στήλες επικαλύπτονται σε ένα 2Δ γράφημα, από -100 έως 100 τοις εκατό. Είναι μια ανάγνωση μόνο της ρύθμισης στην γονική ομάδα σειράς. Χρησιμοποιήστε [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) για να ενημερώσετε κάθε συμβατή σειρά σε αυτήν την ομάδα. Αυτή η επιλογή εφαρμόζεται σε τύπους γραφήματος που εμφανίζουν ομαδοποιημένες μπάρες ή στήλες· δεν επηρεάζει άσχετες ομάδες σειρών σε συνδυαστικό γράφημα.

Το παρακάτω παράδειγμα ορίζει την επικάλυψη για την ομάδα που περιλαμβάνει την πρώτη σειρά:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Το νέο γράφημα περιέχει δείγμα σειρών, κατηγοριών και τιμών.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Το αποτέλεσμα:

![The series overlap](series_overlap.png)

## **Αλλαγή Χρώματος Γέμισης Σειράς**

Χρησιμοποιήστε [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) για να ορίσετε το προεπιλεγμένο γέμισμα ολόκληρης μιας σειράς. Εάν ένα σημείο έχει ήδη ρητό γέμισμα, η ρύθμιση του [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) παρακάμπτει το γέμισμα της σειράς για εκείνο το σημείο.

Το παρακάτω παράδειγμα εφαρμόζει στερεό μπλε γέμισμα στην πρώτη σειρά:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Το αποτέλεσμα:

![The color of the series](series_color.png)

## **Αλλαγή Ονόματος Σειράς**

Το όνομα μιας σειράς αποθηκεύεται στο βιβλίο εργασίας δεδομένων του γραφήματος και εμφανίζεται κανονικά στη legenda. Στο προεπιλεγμένο βιβλίο εργασίας που δημιουργείται για ένα γράφημα στήλης με ομαδοποίηση, το κελί B1 βρίσκεται στη γραμμή 0, στήλη 1 και περιέχει το όνομα της πρώτης σειράς. Οι ονομαστικές μεταβλητές στο παρακάτω παράδειγμα κάνουν αυτή τη δομή ρητή:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Μπορείτε επίσης να ενημερώσετε το κελί που ήδη αναφέρεται από το [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/). Αυτή η προσέγγιση αποφεύγει την υπόθεση συγκεκριμένης γραμμής και στήλης σε ένα υπάρχον γράφημα:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Το αποτέλεσμα:

![The series name](series_name.png)

### **Δημιουργία Σειράς με Όνομα από Πολλά Κελιά**

Ένα σύνθετο όνομα σειράς είναι χρήσιμο όταν το όνομα προϊόντος και η χρονική περίοδος αναφοράς αποθηκεύονται σε ξεχωριστά κελιά του βιβλίου εργασίας. Για παράδειγμα, μπορείτε να συνδυάσετε το `Product A` στο B1 και το `2026` στο C1 σε ένα ενιαίο όνομα σειράς, διατηρώντας και τα δύο μέρη συνδεμένα με τα πηγαία κελιά τους.

Χρησιμοποιήστε [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) για να ανακτήσετε την περιοχή ονομάτων, έπειτα περάστε αυτή τη συλλογή στο [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/). Το όρισμα `skipHiddenCells` ελέγχει αν τα κρυφά κελιά συμπεριλαμβάνονται: `true` τα εξαιρεί, ενώ `false` τα περιλαμβάνει. Σε αυτό το παράδειγμα χρησιμοποιείται `false` για να συμπεριληφθούν όλα τα κελιά της περιοχής ονομάτων.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση με μία σειρά και δύο σημεία δεδομένων. Τα κελιά B1:C1 παρέχουν μόνο το όνομα σειράς· τα A2:A3 παρέχουν τις ετικέτες κατηγοριών, και τα B2:B3 παρέχουν τις αριθμητικές τιμές.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Αυτά τα δύο κελιά παρέχουν το όνομα της σειράς.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Ξεχωριστά κελιά παρέχουν τις κατηγορίες και τα αριθμητικά σημεία δεδομένων.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το προκύπτον όνομα σειράς είναι `Product A 2026`, με ένα κενό μεταξύ των δύο τιμών κελιών. Η legenda το εμφανίζει ως μία καταχώρηση και για τις δύο στήλες. Η παρακάτω εικόνα απεικονίζει το αποτέλεσμα:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Λήψη Αυτόματου Χρώματος Γέμισης Σειράς**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) επιστρέφει το χρώμα που υπολογίζεται από τον δείκτη σειράς και το στυλ του γραφήματος. Αυτό είναι το χρώμα που χρησιμοποιείται όταν το γέμισμα της σειράς δεν έχει οριστεί ρητά. Η κλήση της μεθόδου διαβάζει το υπολογισμένο χρώμα· δεν εκχωρεί νέο γέμισμα.

Το παρακάτω παράδειγμα εκτυπώνει το αυτόματο χρώμα κάθε προεπιλεγμένης σειράς:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Αποτέλεσμα εκτέλεσης για το προεπιλεγμένο στυλ γραφήματος:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Τα ακριβή χρώματα εξαρτώνται από το στυλ και το θέμα του γραφήματος.

## **Ορισμός Αντίστροφου Χρώματος Γέμισης για Σειρά Γραφήματος**

Για σειρές μπαρών, στηλών και φυσαλίδων, το [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) μπορεί να εμφανίζει αρνητικές τιμές με διαφορετικό γέμισμα. Ορίστε το κανονικό γέμισμα σειράς σε στερεό, ενεργοποιήστε την αντιστροφή και εκχωρήστε το χρώμα της αρνητικής τιμής μέσω του [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Οι αρνητικοί αριθμοί παραμένουν αμετάβλητοι στο βιβλίο εργασίας· αλλάζει μόνο το χρώμα εμφάνισης.

Το παρακάτω παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα γραφήματος με μία σειρά. Η γραμμή 0 του φύλλου εργασίας περιέχει το όνομα της σειράς, η στήλη 0 τις ετικέτες κατηγοριών και η στήλη 1 τις τιμές:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Το αποτέλεσμα:

![The inverted solid fill color](inverted_solid_fill_color.png)

Μπορείτε να ενεργοποιήσετε την αντιστροφή για ένα σημείο μέσω του [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Στο παρακάτω παράδειγμα, η αντιστροφή είναι απενεργοποιημένη για τη σειρά και ενεργοποιημένη μόνο για το επιλεγμένο σημείο. Το σημείο εκχωρείται επίσης μια αρνητική τιμή ώστε η επίδραση να είναι ορατή:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Καθαρισμός Συγκεκριμένης Τιμής Σημείου Δεδομένων**

Για να αφήσετε ένα σημείο κενό χωρίς να αφαιρέσετε τα άλλα, ορίστε το κελί του βιβλίου εργασίας σε `null`. Σε γράφημα στήλης, η σχεδιασμένη τιμή είναι διαθέσιμη μέσω του [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/). Το σημείο παραμένει στην ίδια θέση κατηγορίας, αλλά το γράφημα το θεωρεί κενό σύμφωνα με τις ρυθμίσεις κενών τιμών του γραφήματος.

Το παρακάτω παράδειγμα καθαρίζει μόνο το δεύτερο σημείο στην πρώτη σειρά:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Τα διασυνταχτικά γραφήματα χρησιμοποιούν ξεχωριστά κελιά X και Y, ενώ τα γραφήματα φυσαλίδων χρησιμοποιούν επίσης κελί μεγέθους. Καθαρίστε μόνο το κελί που αντιπροσωπεύει την τιμή που θέλετε να αφαιρέσετε. Μην καλέσετε το [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) όταν θέλετε να διατηρήσετε τα άλλα σημεία, επειδή αυτή η μέθοδος αφαιρεί όλα τα σημεία δεδομένων από τη συλλογή.

## **Έλεγχος Προβολής Κενού Κελιού**

Τα κρυφά κελιά που περιέχουν τιμές αποτελούν διαφορετική περίπτωση από τα κενά κελιά. Για να περιλάβετε ή να εξαιρέσετε δεδομένα από κρυφές γραμμές και στήλες φύλλου εργασίας, δείτε το [Include Data from Hidden Rows and Columns](/slides/el/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Ένα κενό κελί βιβλίου εργασίας αντιπροσωπεύει εσφαλμένα δεδομένα· ένα κελί που περιέχει `0` αντιπροσωπεύει γνωστή αριθμητική τιμή. Καλέστε το [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) με `null` για να κάνετε ένα κελί κενό. Ένα αριθμητικό μηδέν παραμένει μηδέν ανεξαρτήτως της ρύθμισης κενών κελιών.

Χρησιμοποιήστε το [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) για να επιλέξετε πώς θα εμφανίζει το γράφημα τα κενά κελιά. Αυτή η ρύθμιση ισχύει για ολόκληρο το γράφημα. Αλλάζει τον τρόπο που σχεδιάζονται τα κενά, χωρίς να γεμίζει το κενό κελί του βιβλίου εργασίας με μηδέν ή με παρεμβαλλόμενη τιμή.

Το παρακάτω αυτό-συμπεριλαμβάνον παράδειγμα δημιουργεί ένα γράφημα γραμμής με μία σειρά, αφαιρεί την τιμή για την Ημέρα 3 και αποθηκεύει το ίδιο γράφημα με κάθε λειτουργία. Δεν απαιτείται αρχείο εισόδου. Το [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) χρησιμοποιεί το φύλλο εργασίας 0, στήλη 0 για ετικέτες κατηγοριών και στήλη 1 για τιμές· η γραμμή 0 περιέχει το όνομα της σειράς. Τα τελικά δεδομένα είναι `10, 20, empty, 30, 40`.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Αφήστε την Ημέρα 3 πραγματικά κενή, διατηρώντας την κατηγορία και το σημείο δεδομένων.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Κάθε αρχείο εξόδου αποθηκεύει τη λειτουργία που είχε οριστεί πριν την αποθήκευση: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` και `empty_cells_Span.pptx`. Για να αποθηκεύσετε μόνο μία έκδοση, ορίστε τη ζητούμενη λειτουργία και αποθηκεύστε την παρουσίαση μία φορά αντί να επαναλάβετε τις λειτουργίες.

Η σύγκριση παρακάτω δείχνει τα ίδια δεδομένα και στα τρία αρχεία. Η Ημέρα 3 είναι κενή στο βιβλίο εργασίας σε όλες τις περιπτώσεις:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Το ορατό αποτέλεσμα εξαρτάται από τον τύπο του γραφήματος. Ένα γράφημα γραμμής κάνει εύκολη τη σύγκριση και των τριών λειτουργιών. Τα γραφήματα μπαρ και στήλης δεν έχουν γραμμή για σύνδεση σε μια ελλιπή κατηγορία, οπότε το `Span` δεν μπορεί να δημιουργήσει το συνδετικό τμήμα που φαίνεται παραπάνω· μια ελλιπής στήλη και μια στήλη μηδενικού ύψους μπορεί επίσης να φαίνονται όμοιες. Ανάλογα, ένα διασυνταχτικό γράφημα μόνο με δείκτες δεν έχει γραμμή σύνδεσης. Μην περιμένετε τρία διαφορετικά αποτελέσματα για κάθε τύπο γραφήματος· ελέγξτε την έξοδο για τον τύπο που χρησιμοποιείτε.

## **Ορισμός Πλάτους Κενού Μεταξύ Σειρών**

Το πλάτος κενού είναι ο χώρος μεταξύ γειτονικών ομάδων μπαρ ή στηλών, εκφρασμένος σαν ποσοστό του πλάτους της μπάρας ή της στήλης. Όπως και η επικάλυψη, ανήκει στη γονική ομάδα σειρών αντί σε μία σειρά. Καλέστε το [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) μία φορά για την ομάδα. Μία μεγαλύτερη τιμή δημιουργεί περισσότερο χώρο μεταξύ των ομάδων· μία μικρότερη τιμή τις κάνει πιο πυκνές.

Το παρακάτω παράδειγμα αλλάζει το πλάτος κενού και αποθηκεύει μόνο την τελική παρουσίαση:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Το αποτέλεσμα:

![The gap width](gap_width.png)

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι γραφήματος υποστηρίζουν σειρές δεδομένων;**

Όλοι οι τύποι γραφήματος που αντιπροσωπεύονται από την απαρίθμηση [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) χρησιμοποιούν δεδομένα γραφήματος, αλλά οι σειρές τους δεν έχουν όλες την ίδια δομή τιμών ή ρυθμίσεις. Για παράδειγμα, τα γραφήματα κατηγορίας χρησιμοποιούν κατηγορίες και τιμές, τα διασυνταχτικά χρησιμοποιούν τιμές X και Y, και τα γραφήματα φυσαλίδων προσθέτουν μεγέθη φυσαλίδων. Χρησιμοποιήστε τη μέθοδο δημιουργίας σημείου δεδομένων που ταιριάζει με τον τύπο σειράς. Οι επιλογές όπως η επικάλυψη και το πλάτος κενού εφαρμόζονται μόνο σε συμβατές ομάδες μπαρ ή στηλών.

**Τι είναι μια ομάδα σειρών γραφήματος;**

Μια [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) περιέχει συμβατές σειρές που μοιράζονται ρυθμίσεις απεικόνισης σε επίπεδο ομάδας. Ένα συνδυαστικό γράφημα μπορεί να περιέχει περισσότερες από μία ομάδες, οπότε η αλλαγή της ομάδας μέσω μιας σειράς δεν αλλάζει υποχρεωτικά όλες τις σειρές στο γράφημα.

**Μέσα από προεπιλεγμένα δεδομένα δημιουργείται νέο γράφημα;**

Ναι. Από προεπιλογή, η μέθοδος [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) δημιουργεί δείγμα σειρών, κατηγοριών και τιμών. Μπορείτε να επεξεργαστείτε αυτά τα κελιά ή να αφαιρέσετε και τις συλλογές σειρών και κατηγοριών πριν προσθέσετε ένα εντελώς προσαρμοσμένο σύνολο δεδομένων. Υπάρχει επίσης υπερφόρτωση που μπορεί να δημιουργήσει ένα γράφημα χωρίς προεπιλεγμένα δεδομένα.

**Πώς συνδέονται τα αντικείμενα γραφήματος με κελιά βιβλίου εργασίας;**

Τα ονόματα σειρών, οι ετικέτες κατηγοριών και οι τιμές σημείων δεδομένων αναφέρονται σε κελιά ενός [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Η αλλαγή ενός αναφερόμενου κελιού ενημερώνει το αντίστοιχο στοιχείο του γραφήματος. Όταν δημιουργείτε προσαρμοσμένα δεδομένα, διατηρήστε τις γραμμές κατηγοριών και σειρών τιμών συγχρονισμένες ώστε κάθε σημείο να σχεδιάζεται κάτω από την προοριζόμενη κατηγορία.

**Πώς μπορώ να αφαιρέσω ένα σημείο αντί όλης της σειράς;**

Ορίστε το σχετικό κελί τιμής σε `null` ώστε να διατηρηθεί η θέση της κατηγορίας του σημείου ως κενό σημείο. Χρησιμοποιήστε το [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) μόνο όταν θέλετε να αφαιρέσετε όλα τα σημεία από τη σειρά. Εάν αφαιρείτε επίσης κατηγορίες, ενημερώστε κάθε σειρά ώστε οι τιμές τους να παραμείνουν ευθυγραμμισμένες με τη συλλογή κατηγοριών.

**Πώς εμφανίζονται τα κενά σημεία;**

Το αποτέλεσμα εξαρτάται από τον τύπο του γραφήματος και τη ρύθμιση που έχει οριστεί μέσω του [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/). Τα υποστηριζόμενα γραφήματα μπορούν να εμφανίζουν κενά ως κενά, ως μηδενικές τιμές ή συνδέοντας τα γειτονικά σημεία. Επιλέξτε τη ρύθμιση που ταιριάζει με το νόημα των ελλιπών δεδομένων στην παρουσίασή σας. Δείτε το [Control the Display of Empty Cells](#control-the-display-of-empty-cells) για ένα πλήρες παράδειγμα και οπτική σύγκριση.

**Πώς διαμορφώνονται οι αρνητικές τιμές;**

Για υποστηριζόμενες σειρές μπαρ, στήλης και φυσαλίδων, καλέστε το [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) και ορίστε το χρώμα που επιστρέφεται από το [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Μπορείτε να παρακάμψετε τη συμπεριφορά για ένα μεμονωμένο σημείο με το [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Αυτές οι μέθοδοι επηρεάζουν τη μορφοποίηση, όχι τις αποθηκευμένες αριθμητικές τιμές.

**Ποια μορφοποίηση «κερδίζει» όταν τόσο η σειρά όσο και το σημείο μορφοποιούνται;**

Η ρητή μορφοποίηση σημείου δεδομένων έχει προτεραιότητα για εκείνο το σημείο. Τα άλλα σημεία συνεχίζουν να χρησιμοποιούν τη ρητή μορφοποίηση σειράς ή, όταν η μορφοποίηση σειράς δεν είναι ορισμένη, το αυτόματο στυλ και θέμα του γραφήματος. Οι ρυθμίσεις ομάδας όπως η επικάλυψη και το πλάτος κενού ελέγχουν τη διάταξη και δεν είναι παρακάμψεις μορφοποίησης επιπέδου σημείου.

**Υπάρχει όριο στον αριθμό σειρών που μπορεί να περιέχει ένα γράφημα;**

Το Aspose.Slides δεν επιβάλλει ξεχωριστό σταθερό όριο αριθμού σειρών. Στην πράξη, περιορισμοί του αρχείου παρουσίασης, διαθέσιμη μνήμη, χρόνος απόδοσης και η αναγνωσιμότητα του γραφήματος καθορίζουν ένα λογικό όριο.

**Τι πρέπει να αλλάξω όταν οι στήλες είναι πολύ κοντά ή πολύ μακριά;**

Καλέστε το [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) στη σωστή γονική ομάδα σειρών. Αυξήστε την τιμή για να διευρύνετε το κενό μεταξύ των ομάδων ή μειώστε την για να φέρετε τις ομάδες πιο κοντά.