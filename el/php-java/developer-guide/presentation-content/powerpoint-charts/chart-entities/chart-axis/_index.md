---
title: Προσαρμογή αξόνων διαγράμματος σε παρουσιάσεις με PHP
linktitle: Άξονας διαγράμματος
type: docs
url: /el/php-java/chart-axis/
keywords:
- άξονας διαγράμματος
- κατακόρυφος άξονας
- οριζόντιος άξονας
- προσαρμογή άξονα
- χειρισμός άξονα
- διαχείριση άξονα
- ιδιότητες άξονα
- μέγιστη τιμή
- ελάχιστη τιμή
- γραμμή άξονα
- μορφή ημερομηνίας
- τίτλος άξονα
- θέση άξονα
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για PHP μέσω Java για να προσαρμόσετε τους άξονες διαγράμματος σε παρουσιάσεις PowerPoint για εκθέσεις και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε τους άξονες των διαγραμμάτων με το Aspose.Slides για PHP μέσω Java. Καλύπτει υπολογισμένες τιμές άξονα, εναλλαγή γραμμών και στηλών διαγράμματος, ορατότητα άξονα, διαστήματα ετικετών κατηγορίας και σημείων σκαλαρίσματος, ημερολογιακές κατηγορίες και μορφοποίηση, περιστροφή τίτλου, θέση άξονα, μονάδες εμφάνισης και λογαριθμική κλιμάκωση.

## **Λήψη των μέγιστων τιμών στον κάθετο άξονα στα διαγράμματα**

Δημιουργήστε μια [Παρουσίαση](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) και προσθέστε ένα διάγραμμα περιοχής με προεπιλεγμένα δεδομένα. Κλήστε το [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) πριν διαβάσετε τις υπολογισμένες τιμές άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) και [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) για τα όρια του άξονα, και [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) και [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) για τα διαστήματα σημείων. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) και [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) παρέχουν κλίμακες χρονικής μονάδας, οι οποίες αφορούν τους ημερολογιακούς άξονες. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το διάγραμμα.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Αντιστροφή των δεδομένων μεταξύ των αξόνων**

Χρησιμοποιήστε το [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα του διαγράμματος. Κάθε προηγούμενη κατηγορία γίνεται σειρά, και κάθε προηγούμενη σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κατακόρυφους άξονες. Το παράδειγμα χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) για να συνδέσει τα προεπιλεγμένα δεδομένα με `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής κεφαλίδας και της στήλης κατηγορίας, πριν ανταλλάξει γραμμές και στήλες. Αποθηκεύει ένα διάγραμμα με τέσσερις σειρές και τρεις κατηγορίες.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Απενεργοποίηση του κατακόρυφου άξονα για διαγράμματα γραμμής**

Κλήστε το [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) με `false` στον κατακόρυφο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον κατακόρυφο άξονα κρυφό.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Απενεργοποίηση του οριζόντιου άξονα για διαγράμματα γραμμής**

Κλήστε το [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) με `false` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον οριζόντιο άξονα κρυφό.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Αλλαγή άξονα κατηγορίας**

Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) για να επιλέξετε έναν ημερολογιακό ή κειμενικό άξονα κατηγορίας. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας του Excel. Αλλάζει τον οριζόντιο άξονα σε ημερολογιακό άξονα. Καλώντας το [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) με `false`, το [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) με `1` και το [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) με `TimeUnitType::Months` τοποθετούνται οι κύριες τιμές σήματος σε διαστήματα ενός μηνός.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Έλεγχος διαστημάτων ετικετών άξονα κατηγορίας**

Όταν ένα διάγραμμα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών του άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Κλήστε το [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) με `false`, στη συνέχεια περάστε το επιθυμητό διάστημα κατηγορίας στο [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Για κειμενικές κατηγορίες στη φυσική τους σειρά, η καταμέτρηση ξεκινά από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Κατηγορία 1, Κατηγορία 2, Κατηγορία 3, ... Κατηγορία 24 |
| `2` | Κατηγορία 1, Κατηγορία 3, Κατηγορία 5, ... Κατηγορία 23 |
| `3` | Κατηγορία 1, Κατηγορία 4, Κατηγορία 7, ... Κατηγορία 22 |

Ένα διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυμμένες μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη απόσταση επιλέγει διάστημα με βάση τον διαθέσιμο χώρο· δεν εμφανίζει απαραίτητα κάθε ετικέτα.

Τα σημεία σκαλαρίσματος έχουν ξεχωριστό έλεγχο. Κλήστε το [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) με `false` και χρησιμοποιήστε το [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) για να ορίσετε το διάστημά τους. Για παράδειγμα, το `1` διατηρεί ένα σημείο σκαλαρίσματος σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) με ορατό στυλ ώστε να δείτε το αποτέλεσμα. Καλώντας οποιοδήποτε αυτόματο setter με `true` ξανά επιτρέπει στο διάγραμμα να επιλέξει πάλι εκείνο το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, στη συνέχεια αποθηκεύει τρεις διαφάνειες στο `CategoryAxisIntervals.pptx`: αυτόματο διάστημα, χειροκίνητο διάστημα ετικέτας με ανεξάρτητα σημεία σκαλαρίσματος, και επαναφορά του αυτόματου διαστήματος. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του διαγράμματος. Δεν απαιτείται εισαγωγική παρουσίαση. Το οριζόντιο κείμενο ετικέτας καθιστά εύκολη την αντίληψη της διασποράς.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // Διαφάνεια 2: εμφάνιση κάθε τρίτης ετικέτας, αλλά διατήρηση σημείου σκαλαρίσματος για κάθε κατηγορία.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Διαφάνεια 3: αφήστε το διάγραμμα να επιλέξει ξανά και τα δύο διαστήματα.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Αυτόματο διάστημα (διαφάνεια 1):** Σε αυτήν την απόδοση, κάθε δεύτερη ετικέτα κατηγορίας εμφανίζεται και αναδιπλώνεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και τον μηχανισμό απόδοσης.

![Αυτόματο διάστημα ετικετών κατηγορίας με όλες τις 24 στήλες ορατές](category-axis-automatic.png)

**Χειροκίνητο διάστημα (διαφάνεια 2):** Κάθε τρίτη ετικέτα εμφανίζεται σε μία γραμμή, ενώ τα σημεία σκαλαρίσματος παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων των χωρίς ετικέτες, παραμένουν ορατές με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Χειροκίνητο διάστημα ετικέτας κατηγορίας τριών με όλες τις 24 στήλες ορατές](category-axis-manual.png)

### **Επιλογή του σωστού άξονα και διαστήματος**

Χρησιμοποιήστε αυτό το διάστημα καταμέτρησης κατηγοριών για έναν κειμενικό άξονα κατηγορίας, όπως ο άξονας κατηγορίας ενός διαγράμματος στήλης, γραμμής, περιοχής ή ράβδου. Σε διάγραμμα στήλης, είναι ο οριζόντιος άξονας. Σε οριζόντιο διάγραμμα ράβδων, ο άξονας κατηγορίας είναι κάθετος, οπότε εφαρμόστε αυτές τις ρυθμίσεις στον άξονα που επιστρέφεται από το [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Η απόσταση σημείων σκαλαρίσματος ισχύει επίσης για άξονα σειράς σε διαγράμματα που το διαθέτουν.

Μην χρησιμοποιήσετε τη ρύθμιση διαστήματος ετικέτας κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμής. Σε άξονα τιμής, το [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) ορίζει μια διαφορά στις τιμές: π.χ., μια κύρια μονάδα `10` παράγει σημεία σκαλαρίσματος στα 0, 10, 20 κ.λπ. όταν ο άξονας ξεκινά από το μηδέν. Ένα διάστημα ετικέτας κατηγορίας `3` μετρά αντίθετα τις θέσεις κατηγορίας, ανεξάρτητα από τις τιμές δεδομένων. Τα διαγράμματα διασποράς και φυσαλίδων χρησιμοποιούν άξονες τιμής αντί για κειμενικό άξονα κατηγορίας. Για άξονα ημερομηνίας, χρησιμοποιήστε τις βασισμένες στο χρόνο κύριες μονάδες και κλίμακες όπως περιγράφεται στην ενότητα [Αλλαγή άξονα κατηγορίας](#change-a-category-axis).

## **Ορισμός μορφής ημερομηνίας για τιμές άξονα κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα του διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο εργασίας (δείκτης `0`), υπολογιζόμενοι ως ο αριθμός ημερών από τις 30 Δεκεμβρίου 1899 για αυτές τις ημερομηνίες. Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) με `CategoryAxisType::Date`, καλέστε το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) με `false` και περάστε `yyyy` στο [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) ώστε οι ετικέτες κατηγορίας να εμφανίζουν τέσσερα ψηφία του έτους ανεξάρτητα από τη μορφοποίηση των κελιών.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός γωνίας περιστροφής για τίτλο άξονα διαγράμματος**

Κλήστε το [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) με `true` στον κατακόρυφο άξονα, δώστε το κείμενο του τίτλου και χρησιμοποιήστε το [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) για να περιστρέψετε τον τίτλο. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα στήλης με τον τίτλο του άξονα τιμής περιστραμμένο κατά 90 μοίρες.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός θέσης άξονα σε άξονα κατηγορίας ή τιμής**

Χρησιμοποιήστε το [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) για να ελέγξετε εάν ο άξονας τιμής διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα σημεία σήματος κατηγορίας. Αυτή η ρύθμιση ισχύει για άξονες κατηγορίας. Το παράδειγμα το ορίζει σε `true` στον οριζόντιο άξονα κατηγορίας ενός διαγράμματος στήλης και αποθηκεύει το αποτέλεσμα.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός μονάδας εμφάνισης σε άξονα τιμής διαγράμματος**

Χρησιμοποιήστε το [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) για να κλιμακώσετε τις ετικέτες ενός άξονα τιμής χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) ορισμένο σε `Millions`, μια τιμή των 60 000 000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα διάγραμμα στήλης και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κάθετο άξονά του.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Διαμόρφωση λογαριθμικού άξονα τιμής**

Ένας λογαριθμικός άξονας τιμής είναι χρήσιμος όταν οι θετικές τιμές καλύπτουν πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λαμβάνει 10, 100, 1 000, 10 000 και 100 000 αιτήματα σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται πολύ κοντά μεταξύ τους κοντά στο μηδέν. Μια λογαριθμική κλίμακα κάνει την σχετική τους αύξηση πιο εύκολη στην σύγκριση: ίδιες αποστάσεις αντιπροσωπεύουν ίσους λόγους αντί για ίσες διαφορές.

Κλήστε το [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) με `true` στον άξονα τιμής και χρησιμοποιήστε το [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υφιστάμενων τιμών· δεν αλλάζει τα δεδομένα ούτε προσθέτει λογαριθμική γραμμή τάσης. Μια γραμμή τάσης αντιπροσωπεύει μια προσαρμοσμένη σχέση στα δεδομένα και είναι ξεχωριστό χαρακτηριστικό.

### **Επιλογή του άξονα τιμής και βάσης**

Για διάγραμμα γραμμής ή στήλης, ο άξονας τιμής επιστρέφεται από το [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Για οριζόντιο διάγραμμα ράβδων, επιστρέφεται από το [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Τα διαγράμματα διασποράς και φυσαλίδων έχουν δύο άξονες τιμής, οπότε επιλέξτε τον οριζόντιο άξονα για τις τιμές X, τον κατακόρυφο για τις τιμές Y, ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για διαγράμματα PPTX, χρησιμοποιήστε βάση από `2` έως `1000`, συμπεριλαμβανομένου· υποστηρίζονται επίσης κλασματικές βάσεις όπως `2.5`. Με τη βάση `10`, οι διαδοχικές δυνάμεις 10, 100, 1 000 και 10 000 είναι εξίσου διαστημένες.

### **Σύγκριση γραμμικής και λογαριθμικής κλιμάκωσης**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με τις πέντε μετρήσεις αιτημάτων στην πρώτη διαφάνεια, στη συνέχεια κλωνοποιεί αυτή τη διαφάνεια και ενεργοποιεί λογαριθμικό άξονα τιμής βάσης‑10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Διατηρήστε την πρώτη διαφάνεια γραμμική και αλλάξτε μόνο την κλίμακα του άξονα τιμής του αντιγράφου.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Γραμμική κλίμακα (διαφάνεια 1):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτημάτων. Η μεγαλύτερη τιμή κυριαρχεί στο διάγραμμα, καθιστώντας τις μικρότερες τιμές δύσκολες στην διάκριση.

![Διάγραμμα γραμμής στο PowerPoint που εμφανίζει πέντε μετρήσεις αιτημάτων σε γραμμικό άξονα τιμής](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφάνεια 2):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσους λόγους. Κάθε περίοδος έχει δέκα φορές περισσότερα αιτήματα από την προηγούμενη, έτσι τα σημεία σχηματίζουν μια ευθεία ανερχόμενη γραμμή στη βάση‑10 κλίμακα. Οι ετικέτες του άξονα εξακολουθούν να δείχνουν τις αρχικές μετρήσεις αιτημάτων.

![Οι ίδιες πέντε μετρήσεις αιτημάτων στο PowerPoint σε λογαριθμικό άξονα τιμής βάσης 10](value-axis-logarithmic.png)

### **Διαχείριση μηδενικών και αρνητικών τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο αυστηρά θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Εάν μηδενικές ή αρνητικές τιμές έχουν νόημα, διατηρήστε μια γραμμική κλίμακα ή εμφανίστε τις χωριστά. Εάν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παράλειψη. Μην τις αντικαθιστάτε αθόρυβα με μικρούς θετικούς αριθμούς, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιαδήποτε χειροκίνητη ρύθμιση ελάχιστου ή μέγιστου για λογαριθμικό άξονα πρέπει επίσης να είναι θετική.

## **FAQ**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Χρησιμοποιήστε το [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να καθορίσετε μια αριθμητική τιμή διασταύρωσης, χρησιμοποιήστε το [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασταύρωση του άξονα σε κατάλληλη βάση.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σημείων σκαλαρίσματος σχετικά με τον άξονα;**

Κλήστε το [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ή `None`. Για έλεγχο των ίδιων των σημείων σκαλαρίσματος, χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) ή το [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); αυτά είναι ξεχωριστά από τη θέση των ετικετών.