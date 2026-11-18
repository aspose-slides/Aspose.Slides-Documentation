---
title: Δημιουργία ή Ενημέρωση Γραφημάτων Παρουσίασης PowerPoint σε PHP
linktitle: Δημιουργία ή Ενημέρωση Γραφημάτων
type: docs
weight: 10
url: /el/php-java/create-chart/
keywords:
  - προσθήκη γραφήματος
  - δημιουργία γραφήματος
  - επεξεργασία γραφήματος
  - αλλαγή γραφήματος
  - ενημέρωση γραφήματος
  - διασκορπισμένο γράφημα
  - κυκλικό γράφημα
  - γράφημα γραμμής
  - γράφημα δένδρου
  - γράφημα μετοχής
  - γράφημα κουτιού‑γραμμής
  - γράφημα χωνίου
  - γράφημα ηλιακού κύκλου
  - ιστογράφημα
  - γράφημα ραδιοσυχνότητας
  - γράφημα πολλαπλών κατηγοριών
  - PowerPoint
  - παρουσίαση
  - PHP
  - Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε γραφήματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Προσθέστε, μορφοποιήστε και επεξεργαστείτε γραφήματα με πρακτικά παραδείγματα κώδικα σε PHP."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργήσετε και να προσαρμόσετε γραφήματα χρησιμοποιώντας το Aspose.Slides for PHP via Java. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα γράφημα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει στις συγκεκριμένες απαιτήσεις σχεδίασής σας. Καθ' όλη τη διάρκεια του άρθρου, λεπτομερή παραδείγματα κώδικα δείχνουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου γραφήματος μέχρι τη διαμόρφωση σειρών, αξόνων και υπομνήματος. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε μια στέρεη κατανόηση του πώς να ενσωματώσετε δυναμική δημιουργία γραφημάτων στις εφαρμογές PHP, απλοποιώντας τη διαδικασία δημιουργίας παρουσιάσεων με δεδομένα.

## **Δημιουργία γραφήματος**

Τα γραφήματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα τα δεδομένα και να αποκτούν επιγνώσεις που ενδέχεται να μην είναι άμεσα εμφανείς από έναν πίνακα ή υπολογιστικό φύλλο.

**Γιατί να δημιουργήσετε γραφήματα;**

Χρησιμοποιώντας γραφήματα, μπορείτε:

* να συγκεντρώνετε, συμπτύσσετε ή συνοψίζετε μεγάλες ποσότητες δεδομένων σε μία διαφάνεια μιας παρουσίασης·
* να αποκαλύπτετε πρότυπα και τάσεις στα δεδομένα·
* να συναγάγετε την κατεύθυνση και τη δυναμική των δεδομένων κατά το χρόνο ή σε σχέση με μια συγκεκριμένη μονάδα μέτρησης·
* να εντοπίζετε ακραίες τιμές, αποκλίσεις, σφάλματα και άσχετα δεδομένα·
* να επικοινωνείτε ή να παρουσιάζετε πολύπλοκα δεδομένα.

Στο PowerPoint, μπορείτε να δημιουργήσετε γραφήματα μέσω της λειτουργίας *Εισαγωγή*, η οποία παρέχει πρότυπα για το σχεδιασμό πολλών τύπων γραφημάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο κανονικά γραφήματα (βασισμένα σε δημοφιλείς τύπους) όσο και προσαρμοσμένα γραφήματα.

{{% alert color="info" title="Note" %}}
Χρησιμοποιήστε την απαρίθμηση [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) στο χώρο ονομάτων [aspose\slides](https://reference.aspose.com/slides/php-java/aspose.slides/). Οι τιμές σε αυτήν την απαρίθμηση αντιστοιχούν σε διαφορετικούς τύπους γραφημάτων.
{{% /alert %}}

### **Δημιουργία συσσωματωμένων γραφημάτων στηλών**

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) για να δημιουργήσει ένα συσσωματωμένο γράφημα στηλών που συγκρίνει δύο σειρές σε τρεις κατηγορίες. Οι σειρές χρησιμοποιούν κόκκινες και πράσινες γέμισεις, και οι μεμονωμένες ετικέτες εμφανίζουν τα ονόματα των κατηγοριών, τις ονομασίες σειρών και τις τιμές. Ο δείκτης φύλλου εργασίας 0 αναφέρεται στο πρώτο φύλλο στο ενσωματωμένο βιβλίο εργασίας του γραφήματος.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $categoryCell = $workbook->getCell($worksheetIndex, 1, 0, "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 2, 0, "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 3, 0, "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 20);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 50);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 0, 0);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $series = $chart->getChartData()->getSeries()->get_Item(1);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 2, 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 2, 10);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 2, 60);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 128, 0);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $label = $series->getDataPoints()->get_Item(0)->getLabel();
    $label->getDataLabelFormat()->setShowCategoryName(true);

    $label = $series->getDataPoints()->get_Item(1)->getLabel();
    $label->getDataLabelFormat()->setShowSeriesName(true);

    $label = $series->getDataPoints()->get_Item(2)->getLabel();
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setShowSeriesName(true);
    $label->getDataLabelFormat()->setSeparator("/");

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το γράφημα Συσσωματωμένη Στήλη](clustered_column_chart.png)

### **Δημιουργία διασκορπισμένων γραφημάτων**

Διασκορπισμένα γραφήματα (επίσης γνωστά ως scatter plots ή διαγράμματα x‑y) χρησιμοποιούνται συχνά για να ελέγξουν πρότυπα ή να δείξουν συσχετίσεις μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε ένα διασκορπισμένο γράφημα όταν:

* Διαθέτετε ζευγαρωμένα αριθμητικά δεδομένα·
* Διαθέτετε δύο μεταβλητές που ταιριάζουν καλά μεταξύ τους·
* Θέλετε να προσδιορίσετε εάν οι δύο μεταβλητές είναι σχετιζόμενες·
* Έχετε μια ανεξάρτητη μεταβλητή που έχει πολλαπλές τιμές για μια εξαρτημένη μεταβλητή.

Αυτό το παράδειγμα σχεδιάζει δύο σύνολα τιμών x‑y. Η πρώτη σειρά χρησιμοποιεί ευθείες γραμμές με αστερόσημα, ενώ η δεύτερη χρησιμοποιεί λείες γραμμές με κυκλικά σημεία· και οι δύο χρησιμοποιούν μέγεθος σημείου 10, ρυθμισμένο με τη [setSize](https://reference.aspose.com/slides/php-java/aspose.slides/marker/setsize/). Η μέθοδος [setSymbol](https://reference.aspose.com/slides/php-java/aspose.slides/marker/setsymbol/) ελέγχει το σχήμα του σημείου.

```php
use aspose\slides\ChartType;
use aspose\slides\MarkerStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 20, 20, 500, 300);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, 1, 1, "Series 1");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());
    $seriesNameCell = $workbook->getCell($worksheetIndex, 1, 3, "Series 2");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $xValueCell = $workbook->getCell($worksheetIndex, 2, 1, 1);
    $yValueCell = $workbook->getCell($worksheetIndex, 2, 2, 3);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 3, 1, 2);
    $yValueCell = $workbook->getCell($worksheetIndex, 3, 2, 10);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);

    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);

    $series = $chart->getChartData()->getSeries()->get_Item(1);

    $xValueCell = $workbook->getCell($worksheetIndex, 2, 3, 5);
    $yValueCell = $workbook->getCell($worksheetIndex, 2, 4, 2);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 3, 3, 3);
    $yValueCell = $workbook->getCell($worksheetIndex, 3, 4, 1);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 4, 3, 2);
    $yValueCell = $workbook->getCell($worksheetIndex, 4, 4, 2);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 5, 3, 5);
    $yValueCell = $workbook->getCell($worksheetIndex, 5, 4, 1);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το διασκορπισμένο γράφημα](scatter_chart.png)

### **Δημιουργία κυκλικών γραφημάτων**

Κυκλικά γραφήματα είναι ιδανικά για την εμφάνιση της σχέσης μέρος‑προς‑όλο στα δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγορικές ετικέτες με αριθμητικές τιμές. Ωστόσο, αν τα δεδομένα σας περιέχουν πολλά τμήματα ή ετικέτες, ίσως θελήσετε να εξετάσετε τη χρήση ραβδωτού γραφήματος αντί για αυτό.

Αυτό το παράδειγμα δημιουργεί ένα κυκλικό γράφημα με τρεις τριμηνιαίες τιμές. Κάθε φέτα έχει προσαρμοσμένη γέμισμα και περίγραμμα, και οι ετικέτες εμφανίζουν διαφορετικούς συνδυασμούς τιμών, ποσοστών και πληροφοριών σειράς. Η μέθοδος [setFirstSliceAngle](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setfirstsliceangle/) θέτει την πρώτη φέτα να ξεκινάει στο 180°.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 20, 20, 500, 300);

    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $categoryCell = $workbook->getCell(0, 1, 0, "1st Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 2, 0, "2nd Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 3, 0, "3rd Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 20);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 50);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 30);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);

    $firstSlice = $series->getDataPoints()->get_Item(0);
    $firstSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 255, 255);
    $firstSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $firstSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 128, 128, 128);
    $firstSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $firstSlice->getFormat()->getLine()->setWidth(3.0);
    $firstSlice->getFormat()->getLine()->setStyle(LineStyle::ThinThick);
    $firstSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDash);

    $secondSlice = $series->getDataPoints()->get_Item(1);
    $secondSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $secondSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $secondSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 0, 255);
    $secondSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $secondSlice->getFormat()->getLine()->setWidth(3.0);
    $secondSlice->getFormat()->getLine()->setStyle(LineStyle::Single);
    $secondSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDashDot);

    $thirdSlice = $series->getDataPoints()->get_Item(2);
    $thirdSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 127, 80);
    $thirdSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $thirdSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 0, 0);
    $thirdSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $thirdSlice->getFormat()->getLine()->setWidth(2.0);
    $thirdSlice->getFormat()->getLine()->setStyle(LineStyle::ThinThin);
    $thirdSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDashDotDot);

    $firstLabel = $series->getDataPoints()->get_Item(0)->getLabel();
    $firstLabel->getDataLabelFormat()->setShowValue(true);

    $secondLabel = $series->getDataPoints()->get_Item(1)->getLabel();
    $secondLabel->getDataLabelFormat()->setShowValue(true);
    $secondLabel->getDataLabelFormat()->setShowLegendKey(true);
    $secondLabel->getDataLabelFormat()->setShowPercentage(true);

    $thirdLabel = $series->getDataPoints()->get_Item(2)->getLabel();
    $thirdLabel->getDataLabelFormat()->setShowSeriesName(true);
    $thirdLabel->getDataLabelFormat()->setShowPercentage(true);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);

    $presentation->save("PieChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το κυκλικό γράφημα](pie_chart.png)

Για να βελτιώσετε την αναγνωσιμότητα των ετικετών εκτός του κυκλικού γραφήματος, δείτε το άρθρο [Format Leader Lines](/slides/el/php-java/chart-data-label/#format-leader-lines) για παράδειγμα που τοποθετεί τις ετικέτες και προσαρμόζει το χρώμα, το πάχος, τη διαφάνεια και το σχήμα διακεκομμένων γραμμών.

### **Δημιουργία γραφημάτων γραμμής**

Γραφήματα γραμμής (επίσης γνωστά ως line graphs) είναι ιδανικά σε καταστάσεις όπου θέλετε να δείξετε αλλαγές στην τιμή με την πάροδο του χρόνου. Χρησιμοποιώντας ένα γράφημα γραμμής, μπορείτε να συγκρίνετε μεγάλη ποσότητα δεδομένων ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις με το χρόνο, να αναδείξετε ανωμαλίες σε σειρές δεδομένων και πολλά άλλα.

Αυτό το παράδειγμα χρησιμοποιεί τη [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) για να δημιουργήσει ένα γράφημα γραμμής με τις προεπιλεγμένες σειρές και κατηγορίες, και στη συνέχεια αποθηκεύει την παρουσίαση ως PPTX.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $lineChart = $slide->getShapes()->addChart(ChartType::Line, 20, 20, 500, 300);

    $presentation->save("lineChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Από προεπιλογή, τα σημεία σε ένα γράφημα γραμμής ενώνονται με ευθείες συνεχείς γραμμές. Εάν θέλετε τα σημεία να ενώνονται με παύλες, καλέστε τη μέθοδο [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) με τιμή από το [LineDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/):

```php
use aspose\slides\ChartType;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $lineChart = $slide->getShapes()->addChart(ChartType::Line, 20, 20, 500, 300);

    for ($i = 0; $i < java_values($lineChart->getChartData()->getSeries()->size()); $i++)
    {
        $series = $lineChart->getChartData()->getSeries()->get_Item($i);
        $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
}
finally
{
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το γράφημα Γραμμής](line_chart.png)

### **Δημιουργία γραφημάτων δέντρο‑χάρτη**

Γραφήματα δέντρο‑χάρτη είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών και να εστιάσετε γρήγορα σε στοιχεία που συμβάλλουν σημαντικά εντός κάθε κατηγορίας.

Αυτό το παράδειγμα δημιουργεί έναν δέντρο‑χάρτη με οκτώ φύλλα ομαδοποιημένα σε τέσσερα στελέχη και δύο κλαδιά. Η μέθοδος [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) εκχωρεί στελέχη στο επίπεδο ομαδοποίησης 1 και κλαδιά στο επίπεδο 2. Οι τιμές καθορίζουν τα σχετικά μεγέθη των ορθογωνίων, ενώ οι ετικέτες κατηγοριών και οι επαναλαμβανόμενες ετικέτες γονέα προσδιορίζουν τη ιεραρχία.

```php
use aspose\slides\ChartType;
use aspose\slides\ParentLabelLayoutType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Treemap, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Κλαδί 1
    $categoryCell = $workbook->getCell(0, "C1", "Leaf1");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");

    $categoryCell = $workbook->getCell(0, "C2", "Leaf2");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C3", "Leaf3");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");

    $categoryCell = $workbook->getCell(0, "C4", "Leaf4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    // Κλαδί 2
    $categoryCell = $workbook->getCell(0, "C5", "Leaf5");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");

    $categoryCell = $workbook->getCell(0, "C6", "Leaf6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C7", "Leaf7");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");

    $categoryCell = $workbook->getCell(0, "C8", "Leaf8");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $valueCell = $workbook->getCell(0, "D1", 4);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D2", 5);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D3", 3);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D4", 6);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D5", 9);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D6", 9);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D7", 4);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D8", 3);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);

    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);

    $presentation->save("Treemap.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το γράφημα Treemap](treemap_chart.png)

### **Δημιουργία γραφημάτων καταρράκτη**

Γράφημα καταρράκτη εμφανίζει πώς οι θετικές και αρνητικές αλλαγές συμβάλλουν σε μια τελική τιμή. Για παράδειγμα, η ανάλυση κέρδους μπορεί να ξεκινά με τα έσοδα, να αφαιρέσει τα κόστη και να προσθέσει άλλα έσοδα. Οι στήλες αλλαγής «επιπλέουν» μεταξύ της προηγούμενης και της νέας τρέχουσας τιμής, ενώ οι συνολικές στήλες εκτείνονται από το μηδέν μέχρι τη συσσωρευμένη τιμή.

Ακολουθεί το παράδειγμα με ποσά σε χιλιάδες δολάρια ΗΠΑ:

| Κατηγορία | Τιμή φύλλου εργασίας | Τύπος στήλης |
| --- | ---: | --- |
| Έσοδα | 1000 | Αύξηση |
| Κόστος πωλήσεων | -400 | Μείωση |
| Ακαθάριστο κέρδος | 600 | Ενδιάμεσο σύνολο |
| Λειτουργικά έξοδα | -200 | Μείωση |
| Άλλα έσοδα | 50 | Αύξηση |
| Καθαρό κέρδος | 450 | Τελικό σύνολο |

Για να σημαδέψετε ένα σημείο ως ενδιάμεσο ή τελικό σύνολο, καλέστε τη μέθοδο [setSetAsTotal](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setsetastotal/) με `true`. Στη θέση του σημείου παρέχετε την πραγματική συσσωρευμένη τιμή στο κελί του βιβλίου εργασίας: `600` για το ακαθάριστο κέρδος (`1000 - 400`) και `450` για το καθαρό κέρδος (`600 - 200 + 50`). Η μέθοδος σημαδεύει τη στήλη ως σύνολο· δεν υπολογίζει ούτε γεμίζει την τιμή του κελιού. Μην χρησιμοποιείτε το μηδέν ως σύμβολο κράτησης ή προμηθεύετε άλλη αλλαγή για σημείο σύνολο. Μια στήλη σύνολο εμφανίζει τη συσσωρευμένη τιμή χωρίς να την προσθέτει ξανά στην τρέχουσα τιμή.

Αυτό το πλήρες παράδειγμα PHP δημιουργεί ένα γράφημα χρησιμοποιώντας το μέλος `Waterfall` του [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/), διαγράφει τα προεπιλεγμένα δεδομένα και γεμίζει το ενσωματωμένο βιβλίο εργασίας. Ο δείκτης φύλλου εργασίας `0` επιλέγει το πρώτο φύλλο; η στήλη A περιέχει τα ονόματα κατηγοριών και η στήλη B τις τιμές. Κάθε κελί τιμής προστίθεται με τη [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/adddatapointforwaterfallseries/). Οι δείκτες σημείων `2` και `5` (από το μηδέν) προσδιορίζουν τα ενδιάμεσα και τα τελικά σύνολα. Καλώντας τη [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) με `true` εμφανίζονται τα ποσά στις στήλες. Δεν απαιτείται εισαγωγή παρουσίασης ή βιβλίου εργασίας.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Waterfall, 20, 20, 680, 200);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Profit breakdown (USD thousands)");
    $chart->getChartTitle()->setOverlay(false);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $workbook->clear($worksheetIndex);

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Profit");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Waterfall);
    $categories = [ "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" ];
    $values = [ 1000, -400, 600, -200, 50, 450 ];

    for ($i = 0; $i < count($categories); $i++)
    {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categories[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForWaterfallSeries($valueCell);
    }

    // Το τρίτο και το έκτο σημείο αντιπροσωπεύουν σύνολα, όχι επιπλέον αλλαγές.
    $series->getDataPoints()->get_Item(2)->setSetAsTotal(true);
    $series->getDataPoints()->get_Item(5)->setSetAsTotal(true);
    $series->setShowConnectorLines(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("WaterfallChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Καλέστε τη μέθοδο επιπέδου σειράς [setShowConnectorLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setshowconnectorlines/) με `true` για να δείξετε τις γραμμές σύνδεσης των διαδοχικών στηλών και να κάνετε την τρέχουσα τιμή πιο εύκολα παρακολουθούμενη. Για να κρύψετε αυτές τις γραμμές, αντικαταστήστε την κλήση με `$series->setShowConnectorLines(false);` πριν την αποθήκευση. Αυτό αλλάζει μόνο την ορατότητα των γραμμών, όχι τα δεδομένα ή τα σύνολα.

Η αποθηκευμένη παρουσίαση δείχνει το ακαθάριστο κέρδος των 600 και το καθαρό κέρδος των 450, με τα δύο σύνολα να ξεκινούν από το μηδέν:

![Γράφημα καταρράκτη που δείχνει έσοδα, κόστη, ακαθάριστο κέρδος 600 και καθαρό κέρδος 450, με ετικέτες τιμών και γραμμές σύνδεσης](waterfall_chart.png)

### **Δημιουργία γραφημάτων μετοχών**

Γραφήματα μετοχών χρησιμοποιούνται για την εμφάνιση χρηματοοικονομικών δεδομένων όπως τιμές ανοίγματος, υψηλής, χαμηλής και κλεισίματος, βοηθώντας στην ανάλυση των τάσεων της αγοράς και της μεταβλητότητας. Παρέχουν ουσιώδεις πληροφορίες για την απόδοση των μετοχών, υποστηρίζοντας επενδυτές και αναλυτές στην λήψη τεκμηριωμένων αποφάσεων.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα ανοίγματος‑υψηλής‑χαμηλής‑κλεισίματος με τέσσερις σειρές με τη σειρά αυτή και τρεις κατηγορίες. Η μέθοδος [setUpDownBars](https://reference.aspose.com/slides/php-java/aspose.slides/updownbarsmanager/setupdownbars/) ενεργοποιεί τις ράβδους ανοικτό‑κλειστό, και η [getHiLowLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/gethilowlinesformat/) ελέγχει τις γραμμές υψηλό‑χαμηλό που δείχνουν τα εύρη τιμών, ενώ οι ατομικές γραμμές σειρών και οι μικρές οριζόντιες γραμμές πλέγματος κρύβονται.

Ο διαχειριστής που επιστρέφει η [getUpDownBars](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getupdownbars/) εκθέτει ξεχωριστά αντικείμενα μορφοποίησης μέσω των [getUpBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/updownbarsmanager/getupbarsformat/) και [getDownBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/updownbarsmanager/getdownbarsformat/). Χρησιμοποιήστε τις μεθόδους [getFill](https://reference.aspose.com/slides/php-java/aspose.slides/format/getfill/) και [getLine](https://reference.aspose.com/slides/php-java/aspose.slides/format/getline/) κάθε αντικειμένου για να ορίσετε ανεξάρτητα τη γέμιση και το περίγραμμα. Το παράδειγμα χρησιμοποιεί πράσινες ράβδους με σκοτεινό πράσινο περίγραμμα για τις αυξήσεις και πορτοκαλο‑κόκκινες ράβδους με σκοτεινό κόκκινο περίγραμμα για τις μειώσεις.

Παρέχετε αριθμητικές τιμές για όλες τις τέσσερις σειρές σε κάθε κατηγορία, με το Υψηλό και το Χαμηλό να περικλείουν το Άνοιγμα και το Κλείσιμο. Οι ράβδοι συγκρίνουν το Κλείσιμο με το Άνοιγμα **μέσα στην ίδια κατηγορία**, όχι με την προηγούμενη κατηγορία: το A πέφτει από 72 σε 25, ενώ το B ανέρχεται από 25 σε 38 και το C από 38 σε 50. Ισάριθμες τιμές Άνοιγμα‑Κλείσιμο δεν παράγουν ορατό γεμάτο τμήμα. Οι ράβδοι ανοίγματος‑κλεισίματος καλύπτουν το διάστημα Άνοιγμα‑Κλείσιμο· οι γραμμές υψηλό‑χαμηλό καλύπτουν το διάστημα Χαμηλό‑Υψηλό. Αυτές οι ράβδοι ανήκουν στην ομάδα σειρών και δεν είναι κανονικές σειρές γραφήματος ράβδων.

Αυτή η μορφοποίηση λειτουργεί επίσης με γραφήματα [Line and LineWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) που περιέχουν τουλάχιστον δύο σειρές στην ίδια ομάδα και αντίστοιχες αριθμητικές τιμές για κάθε κατηγορία. Για αυτά τα μη‑σωματοποιημένα γραφήματα γραμμής, οι ράβδοι ανοίγματος‑κλεισίματος συγκρίνουν την πρώτη και την τελευταία σειρά: μια υψηλότερη τελευταία τιμή παράγει ράβδο ανοικτή, και μια χαμηλότερη τελευταία τιμή παράγει ράβδο κλειστή. Η αντιστροφή των σειρών αντιστρέφει την ταξινόμηση. Το παράδειγμα παρακάτω χρησιμοποιεί το [OpenHighLowClose](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/); μην υποθέτετε ότι άλλες παραλλαγές μετοχών, γραμμών‑στοιχείων ή 3D χρησιμοποιούν την ίδια διάταξη δεδομένων ή ερμηνεία τμημάτων.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::OpenHighLowClose, 20, 20, 500, 150, false);

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $categoryCell = $workbook->getCell(0, 1, 0, "A");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 2, 0, "B");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 3, 0, "C");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Open");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 2, "High");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 3, "Low");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 4, "Close");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $valueCell = $workbook->getCell(0, 1, 1, 72);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 1, 25);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 1, 38);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $valueCell = $workbook->getCell(0, 1, 2, 172);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 2, 57);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 2, 57);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $valueCell = $workbook->getCell(0, 1, 3, 12);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 3, 12);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 3, 13);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $valueCell = $workbook->getCell(0, 1, 4, 25);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 4, 38);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 4, 50);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $upDownBars = $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars();
    $upDownBars->setUpDownBars(true);

    $upDownBars->getUpBarsFormat()->getFill()->setFillType(FillType::Solid);
    $upDownBars->getUpBarsFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 50, 205, 50));
    $upDownBars->getUpBarsFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $upDownBars->getUpBarsFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 100, 0));
    $upDownBars->getUpBarsFormat()->getLine()->setWidth(2);

    $upDownBars->getDownBarsFormat()->getFill()->setFillType(FillType::Solid);
    $upDownBars->getDownBarsFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 69, 0));
    $upDownBars->getDownBarsFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $upDownBars->getDownBarsFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $upDownBars->getDownBarsFormat()->getLine()->setWidth(2);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++)
    {
        $stockSeries = $chart->getChartData()->getSeries()->get_Item($i);
        $stockSeries->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    $presentation->save("Stock-chart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Το αποτέλεσμα, εξαγόμενο από το PowerPoint:

![Γράφημα μετοχών με πορτοκαλο‑κόκκινο τμήμα πτώσης για το A και πράσινα τμήματα ανόδου για τα B και C](stock_chart.png)

### **Δημιουργία γραφημάτων κουτιού‑και‑γραμμού**

Γραφήματα κουτιού‑και‑γραμμού χρησιμοποιούνται για την εμφάνιση της κατανομής των δεδομένων, συνοψίζοντας βασικά στατιστικά μέτρα όπως η διάμεσος, τα τεταρτημόρια και οι ενδεχόμενες ακραίες τιμές. Είναι ιδιαίτερα χρήσιμα στην εξερευνητική ανάλυση δεδομένων και στις στατιστικές μελέτες για την γρήγορη κατανόηση της μεταβλητότητας των δεδομένων και την αναγνώριση πιθανών ανωμαλιών.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα κουτιού‑και‑γραμμού από έξι τιμές. Η μέθοδος [setQuartileMethod](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setquartilemethod/) επιλέγει τον αποκλειστικό υπολογισμό τεταρτημορίων. Το παράδειγμα ενεργοποιεί επίσης τις γραμμές μέσου όρου, τα σημεία μέσου, τα εσωτερικά σημεία και τα σημεία ακραίων τιμών.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\QuartileMethodType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::BoxAndWhisker, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A1", "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A2", "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A3", "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A4", "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A5", "Category 5");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A6", "Category 6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);

    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);

    $valueCell = $workbook->getCell(0, "B1", 15);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B2", 41);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B3", 16);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B4", 10);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B5", 23);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B6", 16);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);

    $presentation->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

### **Δημιουργία γραφημάτων χωνίου**

Γραφήματα χωνίου χρησιμοποιούνται για την οπτικοποίηση διαδικασιών που περιλαμβάνουν διαδοχικά στάδια, όπου ο όγκος των δεδομένων μειώνεται καθώς προχωρά από το ένα βήμα στο επόμενο. Είναι ιδιαίτερα χρήσιμα για την ανάλυση ποσοστών μετατροπής, την ταυτοποίηση «σ bottleneck» και την παρακολούθηση της αποδοτικότητας των πωλήσεων ή των δραστηριοτήτων μάρκετινγκ.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) για να προσθέσει ένα γράφημα χωνίου στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Αντικαθιστά τα προεπιλεγμένα δεδομένα με έξι κατηγορίες και τιμές από 50 έως 500, και στη συνέχεια αποθηκεύει την ενημερωμένη παρουσίαση. Η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A1", "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A2", "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A3", "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A4", "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A5", "Category 5");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A6", "Category 6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);

    $valueCell = $workbook->getCell(0, "B1", 50);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B2", 100);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B3", 200);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B4", 300);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B5", 400);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B6", 500);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);

    $presentation->save("Funnel.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το γράφημα Χωνίου](funnel_chart.png)

### **Δημιουργία γραφημάτων ηλιακού κύκλου**

Γραφήματα ηλιακού κύκλου χρησιμοποιούνται για την οπτικοποίηση ιεραρχικών δεδομένων, παρουσιάζοντας τα επίπεδα ως συγκρότημα δακτυλίων. Βοηθούν στην απεικόνιση σχέσεων μέρος‑προς‑όλο και είναι ιδανικά για την αναπαράσταση ένθετων κατηγοριών και υποκατηγοριών με σαφή, συμπαγή μορφή.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα ηλιακού κύκλου με οκτώ φύλλα ομαδοποιημένα σε τέσσερα στελέχη και δύο κλαδιά. Η μέθοδος [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) εκχωρεί στελέχη στο επίπεδο ομαδοποίησης 1 και κλαδιά στο επίπεδο 2. Οι ετικέτες κατηγοριών προσδιορίζουν τα τμήματα, και οι τιμές καθορίζουν τα σχετικά μεγέθη τους.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Sunburst, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Κλαδί 1
    $categoryCell = $workbook->getCell(0, "C1", "Leaf1");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");

    $categoryCell = $workbook->getCell(0, "C2", "Leaf2");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C3", "Leaf3");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");

    $categoryCell = $workbook->getCell(0, "C4", "Leaf4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    // Κλαδί 2
    $categoryCell = $workbook->getCell(0, "C5", "Leaf5");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");

    $categoryCell = $workbook->getCell(0, "C6", "Leaf6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C7", "Leaf7");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");

    $categoryCell = $workbook->getCell(0, "C8", "Leaf8");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $valueCell = $workbook->getCell(0, "D1", 4);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D2", 5);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D3", 3);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D4", 6);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D5", 9);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D6", 9);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D7", 4);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D8", 3);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);

    $presentation->save("Sunburst.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το γράφημα Ηλιακού Κύκλου](sunburst_chart.png)

### **Δημιουργία ιστογραμματικών γραφημάτων**

Ιστογράμματα δείχνουν πώς οι αριθμητικές τιμές κατανέμονται σε διαστήματα (bins). Για μηνιαίες αναφορές χρόνων επεξεργασίας παραγγελιών, χρησιμοποιήστε το ίδιο πλάτος διαστήματος και τα ίδια όρια ώστε τα διαστήματα να παραμένουν συνεπή και οι κατανομές εύκολα συγκρίσιμες.

Καλέστε τη μέθοδο [setAggregationType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaggregationtype/) στον οριζόντιο άξονα με λειτουργία από το [AxisAggregationType](https://reference.aspose.com/slides/php-java/aspose.slides/axisaggregationtype/). Η [setBinWidth](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setbinwidth/) εφαρμόζεται μόνο στο `ByBinWidth`; η [setNumberOfBins](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberofbins/) εφαρμόζεται μόνο στο `ByNumberOfBins`. Χρησιμοποιήστε `Automatic` για να αφήσετε το γράφημα να επιλέξει τα διαστήματα.

#### **Χρήση σταθερού πλάτους διαστήματος**

Αυτό το παράδειγμα ομαδοποιεί χρόνους επεξεργασίας σε διαστήματα των 10 λεπτών, με ξεχωριστά διαστήματα για χρόνους ≤10 λεπτά και >40 λεπτά. Ενεργοποιήστε αυτά τα διαστήματα με τις [setUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setunderflowbin/) και [setOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setoverflowbin/). Όταν παρέχετε ρητά όρια μέσω των [setUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setunderflowbin/) και [setOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setoverflowbin/), καλέστε τις [setAutomaticUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticunderflowbin/) και [setAutomaticOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticoverflowbin/) με `false`.

```php
use aspose\slides\AxisAggregationType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Histogram, 20, 20, 680, 200);

    $chart->setLegend(false);
    $chart->setTitle(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
    $values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for ($i = 0; $i < count($values); $i++)
    {
        $valueCell = $workbook->getCell(0, $i, 0, $values[$i]);
        $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setAggregationType(AxisAggregationType::ByBinWidth);
    $axis->setBinWidth(10);
    $axis->setUnderflowBin(true);
    $axis->setAutomaticUnderflowBin(false);
    $axis->setUnderflowBin(10);
    $axis->setOverflowBin(true);
    $axis->setAutomaticOverflowBin(false);
    $axis->setOverflowBin(40);

    $presentation->save("Histogram-bin-width.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Η παρουσίαση που εμφανίζεται στο PowerPoint δείχνει πλήθος επιμέρους διαστημάτων **3, 4, 4, 4 και 2**. Το κάτω όριο του διαστήματος υποροής περιλαμβάνει `5, 10, 10`, οπότε το όριο είναι περιληπτικό. Το πάνω όριο του διαστήματος υπερχείλισης περιλαμβάνει μόνο `41, 50`, οπότε το όριο είναι αποκλειστικό· οι τιμές ίσες με `40` παραμένουν στο προηγούμενο διάστημα. Τα ενδοδιαστήματα περιέχουν τιμές μεγαλύτερες από το κατώτερο όριο και μικρότερες ή ίσες με το ανώτερο όριο.

![Ιστόγραμμα με διαστήματα 10 λεπτών και ρητά όρια υποροής και υπερχείλισης](histogram_bin_width.png)

#### **Καθορισμός αριθμού διαστημάτων**

Για σταθερό επίπεδο λεπτομέρειας αντί για σταθερά διαστήματα, ζητήστε πέντε διαστήματα για τα ίδια δεδομένα. Αυτό το παράδειγμα αφήνει απενεργοποιημένα τα διαστήματα υποροής και υπερχείλισης. Το γράφημα καθορίζει το πλάτος από το εύρος των δεδομένων, οπότε τα όρια μπορούν να αλλάξουν μεταξύ των αναφορών.

```php
use aspose\slides\AxisAggregationType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Histogram, 20, 20, 680, 200);

    $chart->setLegend(false);
    $chart->setTitle(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
    $values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for ($i = 0; $i < count($values); $i++)
    {
        $valueCell = $workbook->getCell(0, $i, 0, $values[$i]);
        $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setAggregationType(AxisAggregationType::ByNumberOfBins);
    $axis->setNumberOfBins(5);

    $presentation->save("Histogram-bin-count.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Τα πέντε διαστήματα έχουν πλήθος **4, 4, 4, 4 και 1**. Συγκρίνετε αυτή την κατανομή με το αποτέλεσμα σταθερού πλάτους παραπάνω: οι εισαγόμενες τιμές είναι ίδιες, αλλά τα όρια διαφέρουν.

![Ιστόγραμμα με πέντε διαστήματα υπολογισμένα από τα ίδια δεδομένα](histogram_bin_count.png)

### **Δημιουργία διαγραμμάτων ραδιοσυχνότητας**

Διαγράμματα ραδιοσυχνότητας χρησιμοποιούνται για την εμφάνιση πολυμεταβλητών δεδομένων σε δισδιάστατη μορφή, επιτρέποντας εύκολη σύγκριση πολλαπλών μεταβλητών ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα για την ταυτοποίηση προτύπων, δυνατών σημείων και αδυναμιών σε πολλαπλές μετρικές απόδοσης ή χαρακτηριστικά.

Αυτό το παράδειγμα χρησιμοποιεί τη [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) για να δημιουργήσει ένα διάγραμμα ραδιοσυχνότητας με τις προεπιλεγμένες σειρές και κατηγορίες, και στη συνέχεια αποθηκεύει την παρουσίαση ως PPTX.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addChart(ChartType::Radar, 20, 20, 500, 300);

    $presentation->save("Radar-chart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το διάγραμμα Ραδιοσυχνότητας](radar_chart.png)

### **Δημιουργία γραφημάτων πολλαπλών κατηγοριών**

Γραφήματα πολλαπλών κατηγοριών χρησιμοποιούνται για την εμφάνιση δεδομένων που περιλαμβάνουν περισσότερες από μία κατηγορίες ομαδοποίησης, επιτρέποντάς σας να συγκρίνετε τιμές σε πολλές διαστάσεις ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα όταν πρέπει να αναλύσετε τάσεις και σχέσεις μέσα σε σύνθετα, πολυεπίπεδα σύνολα δεδομένων.

Αυτό το παράδειγμα δημιουργεί ένα συσσωματωμένο γράφημα στηλών με οκτώ κατηγορίες οργανωμένες σε τέσσερα ζεύγη. Η μέθοδος [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) δίνει σε κάθε ζεύγος μια κοινή ετικέτα στο επίπεδο ομαδοποίησης 1, δημιουργώντας έναν άξονα κατηγοριών με ατομικές και ομαδικές ετικέτες.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $worksheetIndex = 0;

    $categoryCell = $workbook->getCell(0, "c2", "A");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $categoryCell = $workbook->getCell(0, "c3", "B");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c4", "C");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $categoryCell = $workbook->getCell(0, "c5", "D");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c6", "E");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $categoryCell = $workbook->getCell(0, "c7", "F");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c8", "G");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $categoryCell = $workbook->getCell(0, "c9", "H");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, "D1", "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $valueCell = $workbook->getCell($worksheetIndex, "D2", 10);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D3", 20);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D4", 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D5", 40);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D6", 50);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D7", 60);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D8", 70);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D9", 80);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το γράφημα πολλαπλών κατηγοριών](multi_category_chart.png)

#### **Κατάργηση ετικέτας τριμήνου**

Κατεβάστε το αρχείο [quarters.pptx](quarters.pptx) και τοποθετήστε το στον ίδιο φάκελο με το σκριπτ PHP. Το γράφημα του δείχνει εννιά μήνες και μία σειρά πωλήσεων με τιμές από 10 έως 18. Στον άξονα κατηγοριών, το Q1 καλύπτει τον Ιανουάριο‑Μάρτιο, το Q2 τον Απρίλιο‑Ιούνιο και το Q3 τον Ιούλιο‑Σεπτέμβριο.

Ο Απρίλιος είναι η τέταρτη κατηγορία (δείκτης 3) και φέρει την ετικέτα Q2. Χρησιμοποιήστε τη [getGroupingLevels](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/getgroupinglevels/) για να έχετε πρόσβαση στα επίπεδα ομαδοποίησης του Απριλίου, και κατόπιν καλέστε τη [deleteGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/deletegroupingitem/) με επίπεδο 1 για να αφαιρέσετε την ετικέτα τριμήνου. Το επίπεδο 0 αντιπροσωπεύει τον ίδιο τον μήνα και δεν μπορεί να αφαιρεθεί με αυτή τη μέθοδο.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/quarters.pptx");
try
{
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $april = $chart->getChartData()->getCategories()->get_Item(3);
    $april->getGroupingLevels()->deleteGroupingItem(1);

    $presentation->save(__DIR__ . "/quarters-updated.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}

$reopened = new Presentation(__DIR__ . "/quarters-updated.pptx");
try
{
    $updatedChart = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $updatedChart->getChartData();

    $months = [];
    $categories = $data->getCategories();
    
    for ($i = 0; $i < java_values($categories->size()); $i++)
    {
        $months[] = (string)$categories->get_Item($i)->getAsCell()->getValue();
    }

    $sales = [];
    $points = $data->getSeries()->get_Item(0)->getDataPoints();
    for ($i = 0; $i < java_values($points->size()); $i++)
    {
        $sales[] = (string)$points->get_Item($i)->getValue()->getData();
    }

    echo implode(", ", $months), PHP_EOL;
    echo implode(", ", $sales), PHP_EOL;
}
finally
{
    $reopened->dispose();
}
```

Μετά το άνοιγμα ξανά του γραφήματος, το παράδειγμα εκτυπώνει τους αρχικούς μήνες (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) και τις τιμές πωλήσεων (`10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0`) με την ίδια σειρά. Ανοίξτε το `quarters-updated.pptx` στο PowerPoint για να συγκρίνετε τις ετικέτες άξονα. Η ετικέτα Q2 και το όριο ομάδας πριν τον Απρίλιο εξαφανίζονται, έτσι το Q1 καλύπτει τον Ιανουάριο‑Ιούνιο. Το Q3 εξακολουθεί να ξεκινάει τον Ιούλιο.

![Ετικέτες τριμήνων πριν και μετά την αφαίρεση. Στα αριστερά, το Q2 καλύπτει Απρίλιο‑Ιούνιο. Στα δεξιά, το Q1 καλύπτει Ιανουάριο‑Ιούνιο.](quarter-label-comparison.png)

### **Δημιουργία γραφημάτων χάρτη**

Γραφήματα χάρτη χρησιμοποιούνται για την οπτικοποίηση γεωγραφικών δεδομένων χαρτογραφώντας πληροφορίες σε συγκεκριμένες τοποθεσίες όπως χώρες, πολιτείες ή πόλεις. Είναι ιδιαίτερα χρήσιμα για την ανάλυση περιφερειακών τάσεων, δημογραφικών δεδομένων και χωρικών κατανομών με σαφή, οπτικά ελκυστικό τρόπο.

Αυτό το παράδειγμα χρησιμοποιεί τη [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) για να δημιουργήσει ένα γράφημα χάρτη με τα προεπιλεγμένα γεωγραφικά δεδομένα και το αποθηκεύει για προβολή στο PowerPoint.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Map, 20, 20, 500, 300);

    $presentation->save("mapChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το γράφημα Χάρτη](map_chart.png)

{{% alert color="info" title="Note" %}}
Η παραπάνω εικόνα δείχνει την αποθηκευμένη παρουσίαση ανοιγμένη στο PowerPoint. Το Aspose.Slides γράφει σωστά το γράφημα χάρτη και τα δεδομένα του, αλλά δεν σχεδιάζει το ίδιο το γράφημα χάρτη: όταν μια διαφάνεια που το περιέχει αποδίδεται ως εικόνα ή μετατρέπεται σε PDF ή SVG, η περιοχή του γραφήματος εμφανίζεται κενή. Τα άλλα σχήματα στην ίδια διαφάνεια δεν επηρεάζονται.
{{% /alert %}}

### **Δημιουργία συνδυαστικών γραφημάτων**

Συνδυαστικό γράφημα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους γραφημάτων σε ένα ενιαίο γράφημα. Αυτό το γράφημα σάς επιτρέπει να αναδείξετε, να συγκρίνετε ή να εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας σας να εντοπίσετε σχέσεις μεταξύ τους.

![Το συνδυαστικό γράφημα](combination_chart.png)

Αυτό το παράδειγμα συνδυάζει δύο συσσωματωμένες στήλες με μία σειρά γραμμής σε τέσσερις κατηγορίες. Οι στήλες χρησιμοποιούν τον πρωτεύοντα κατακόρυφο άξονα, ενώ η μέθοδος [setPlotOnSecondAxis](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setplotonsecondaxis/) τοποθετεί τη γραμμή σε έναν δευτερεύοντα κατακόρυφο άξονα στα δεξιά. Οι βοηθητικές συναρτήσεις διαμορφώνουν τον τίτλο, το υπόμνημα, τις ετικέτες άξονα και τις γραμμές πλέγματος.

```php
use aspose\slides\AxisPositionType;
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\FillType;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function createComboChart()
{
    $presentation = new Presentation();
    try
    {
        $chart = createChartWithFirstSeries($presentation->getSlides()->get_Item(0));

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    }
    finally
    {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide)
{
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $portionFormat = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $portionFormat->setFontBold(NullableBool::False);
    $portionFormat->setFontHeight(18);

    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $categoryCell = $workbook->getCell($worksheetIndex, 1, 0, "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 2, 0, "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 3, 0, "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 4, 0, "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 4.3);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 2.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 3.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 1, 4.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    return $chart;
}

function addSecondSeriesToChart($chart)
{
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 2, 2.4);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 2, 4.4);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 2, 1.8);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 2, 2.8);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
}

function addThirdSeriesToChart($chart)
{
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 3, 2.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 3, 2.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 3, 3.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 3, 5.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart)
{
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 217, 217, 217);
    $majorGridLinesFormat->getSolidFillColor()->setColor($color);
}

function setSecondaryAxesFormat($chart)
{
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle)
{
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titlePortionFormat = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $titlePortionFormat->setFontBold(NullableBool::False);
    $titlePortionFormat->setFontHeight(12);
}

createComboChart();
```

## **Ενημέρωση γραφημάτων**

Το Aspose.Slides for PHP via Java επιτρέπει την ενημέρωση γραφημάτων PowerPoint τροποποιώντας δεδομένα γραφήματος, μορφοποίηση και στυλ. Αυτή η λειτουργία απλοποιεί τη διαδικασία διατήρησης των παρουσιάσεων ενημερωμένων με δυναμικό περιεχόμενο και διασφαλίζει ότι τα γραφήματα αντικατοπτρίζουν ακριβώς τα τρέχοντα δεδομένα και τα οπτικά πρότυπα.

Αυτό το παράδειγμα ενημερώνει το γράφημα με όνομα «My chart» στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Απαιτούνται δύο σειρές στήλης με τρία σημεία δεδομένων η κάθε μία, με ετικέτες κατηγοριών στη στήλη A και ονόματα σειρών στην πρώτη γραμμή του πρώτου φύλλου εργασίας. Το παράδειγμα χρησιμοποιεί τη [getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) για να αλλάξει τα κελιά του βιβλίου εργασίας, ενημερώνει τις τιμές σειρών, προσθέτει τρίτη σειρά και αλλάζει το γράφημα σε συσσωματωμένους κυλίνδρους μέσω της [setType](https://reference.aspose.com/slides/php-java/aspose.slides/chart/settype/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$chartName = "My chart";
$chartClass = new JavaClass("com.aspose.slides.IChart");

$presentation = new Presentation("ExistingChart.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++)
    {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartClass) && $chartName === java_values($shape->getName()))
        {
            $chart = $shape;
            $worksheetIndex = 0;

            $workbook = $chart->getChartData()->getChartDataWorkbook();

            $workbook->getCell($worksheetIndex, 1, 0, "Modified Category 1");
            $workbook->getCell($worksheetIndex, 2, 0, "Modified Category 2");

            $series = $chart->getChartData()->getSeries()->get_Item(0);

            $workbook->getCell($worksheetIndex, 0, 1, "New_Series 1");
            $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
            $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
            $series->getDataPoints()->get_Item(2)->getValue()->setData(44);

            $series = $chart->getChartData()->getSeries()->get_Item(1);

            $workbook->getCell($worksheetIndex, 0, 2, "New_Series 2");
            $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
            $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
            $series->getDataPoints()->get_Item(2)->getValue()->setData(99);

            $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
            $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

            $valueCell = $workbook->getCell($worksheetIndex, 1, 3, 20);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
            $valueCell = $workbook->getCell($worksheetIndex, 2, 3, 50);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
            $valueCell = $workbook->getCell($worksheetIndex, 3, 3, 30);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);

            $chart->setType(ChartType::ClusteredCylinder);
        }
    }

    $presentation->save("AsposeChartModified.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **Ορισμός περιοχής δεδομένων για ένα γράφημα**

Για να ελέγξετε την περιοχή που χρησιμοποιείται ήδη από ένα υπάρχον γράφημα, δείτε τη σελίδα [Retrieve a Chart's Data Range](/slides/el/php-java/chart-workbook/#retrieve-a-charts-data-range).

Το Aspose.Slides for PHP via Java παρέχει την ευελιξία να ορίσετε μια συγκεκριμένη περιοχή δεδομένων από ένα φύλλο εργασίας ως πηγή για τα δεδομένα του γραφήματος σας. Αυτό σημαίνει ότι μπορείτε άμεσα να αντιστοιχίσετε ένα τμήμα του φύλλου εργασίας σας στο γράφημα, ελέγχοντας ποια κελιά συμβάλλουν στις σειρές και τις κατηγορίες του γραφήματος. Ως αποτέλεσμα, μπορείτε εύκολα να ενημερώνετε και να συγχρονίζετε τα γραφήματά σας με τις πιο πρόσφατες αλλαγές στα δεδομένα του φύλλου εργασίας, διασφαλίζοντας ότι οι παρουσιάσεις PowerPoint αντικατοπτρίζουν τρέχουσες και ακριβείς πληροφορίες.

Αυτό το παράδειγμα χρησιμοποιεί τη [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) για να θέσει την πηγή δεδομένων του γραφήματος με όνομα «My chart» στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης στο `Sheet1!A1:B4`. Το βιβλίο εργασίας του γραφήματος πρέπει να περιέχει αυτό το φύλλο και μια συμπληρωμένη περιοχή με επικεφαλίδα σειράς στην πρώτη γραμμή, ετικέτες κατηγοριών στη στήλη A και τρεις τιμές στη στήλη B.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$chartName = "My chart";
$chartClass = new JavaClass("com.aspose.slides.IChart");

$presentation = new Presentation("ExistingChart.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++)
    {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartClass) && $chartName === java_values($shape->getName()))
        {
            $chart = $shape;
            $chart->getChartData()->setRange("Sheet1!A1:B4");
        }
    }

    $presentation->save("SetDataRange.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **Χρήση προεπιλεγμένων δεικτών σε γραφήματα**

Όταν χρησιμοποιείτε προεπιλεγμένους δείκτες σε γραφήματα, κάθε σειρά γραφήματος λαμβάνει αυτόματα διαφορετικό προεπιλεγμένο σύμβολο δείκτη.

Αυτό το παράδειγμα χρησιμοποιεί τη [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) για να δημιουργήσει ένα γράφημα με δύο σειρές γραμμής και ένα υπόμνημα. Οι ρυθμίσεις δείκτη που προβάλλονται μέσω της [getMarker](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getmarker/) διατηρούν τα αυτόματα εκχωρημένα σύμβολα δείκτη. Η πρώτη σειρά περιλαμβάνει μια αρνητική τιμή και μια τιμή που λείπει, που αντιπροσωπεύεται από `null`, ενώ η δεύτερη έχει τιμή για κάθε κατηγορία.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $categoryCell = $workbook->getCell(0, 1, 0, "C1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 1, 1, 24);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 2, 0, "C2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 2, 1, 23);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 3, 0, "C3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 3, 1, -10);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 4, 0, "C4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 4, 1, null);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $seriesNameCell = $workbook->getCell(0, 0, 2, "Series 2");
    $secondSeries = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $valueCell = $workbook->getCell(0, 1, 2, 30);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 2, 10);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 2, 60);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 4, 2, 40);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);

    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);

    $presentation->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **Συχνές ερωτήσεις**

**Ποιοι τύποι γραφημάτων υποστηρίζονται από το Aspose.Slides for PHP via Java;**

Το Aspose.Slides for PHP via Java υποστηρίζει μια ευρεία γκάμα τύπων γραφημάτων, συμπεριλαμβανομένων των ράβδων, γραμμών, κυκλικών, περιοχών, διασκορπισμένων, ιστογραμμάτων, ραδιοσυχνοτήτων και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο γραφήματος για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς προσθέτω νέο γράφημα σε μια διαφάνεια;**

Για να προσθέσετε ένα γράφημα, δημιουργείτε πρώτα μια παρουσίαση με τη κλάση [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), ανακτάτε τη διαφάνεια που θέλετε με το δείκτη της και, στη συνέχεια, καλείτε τη μέθοδο για την προσθήκη γραφήματος, καθορίζοντας τον τύπο γραφήματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το γράφημα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα γράφημα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός γραφήματος προσπελαύνοντας το βιβλίο εργασίας δεδομένων του ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)), διαγράφοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες, και προσθέτοντας τα δικά σας προσαρμοσμένα δεδομένα. Αυτό επιτρέπει την προγραμματισμένη ανανέωση του γραφήματος ώστε να αντικατοπτρίζει τα πιο πρόσφατα δεδομένα.

**Μπορώ να προσαρμόσω την εμφάνιση του γραφήματος;**

Ναι, το Aspose.Slides for PHP via Java παρέχει εκτεταμένες επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα στοιχεία μορφοποίησης για να προσαρμόσετε την εμφάνιση του γραφήματος στις δικές σας απαιτήσεις σχεδίασης.