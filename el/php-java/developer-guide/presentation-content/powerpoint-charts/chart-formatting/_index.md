---
title: Μορφοποίηση Διαγραμμάτων Παρουσίασης σε PHP
linktitle: Μορφοποίηση Διαγράμματος
type: docs
weight: 60
url: /el/php-java/chart-formatting/
keywords:
- μορφοποίηση διαγράμματος
- μορφοποίηση διαγράμματος
- οντότητα διαγράμματος
- ιδιότητες διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές διαγράμματος
- ιδιότητες γραμματοσειράς
- στρογγυλεμένο περίγραμμα
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε τη μορφοποίηση διαγραμμάτων στο Aspose.Slides για PHP μέσω Java και ενισχύστε την παρουσίαση PowerPoint σας με προσαρμοσμένους άξονες, γραμματοσειρές, αριθμητικές μορφές και στρογγυλεμένα περιγράμματα διαγράμματος."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μορφοποιείτε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσαρμόζετε βασικά στοιχεία διαγράμματος όπως τους άξονες, τις γραμμές πλέγματος, τους τίτλους, τις λεζάντες, την περιοχή σχεδίασης και τις γεμίσεις τοίχου για να βελτιώσετε την εμφάνιση και την αναγνωσιμότητα των δεδομένων του διαγράμματος. Δείχνει επίσης πώς να ορίσετε ιδιότητες γραμματοσειράς για το κείμενο του διαγράμματος, να εφαρμόσετε προεπιλεγμένες αριθμητικές μορφές σε δεδομένα διαγράμματος και να ενεργοποιήσετε στρογγυλεμένες γωνίες για την περιοχή του διαγράμματος. Μαζί, αυτά τα παραδείγματα δείχνουν πώς να ελέγχετε τόσο το οπτικό στυλ όσο και την παρουσίαση των δεδομένων των διαγραμμάτων σε μια παρουσίαση. Δείτε το [παράδειγμα διαγράμματος μετοχών](/slides/el/php-java/create-chart/#create-stock-charts) για ξεχωριστές γεμίσεις και περιγράμματα σε ανοδικά και καθοδικά διαστήματα.

## **Μορφοποίηση Στοιχείων Διαγράμματος**

Χρησιμοποιήστε το [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) για να μορφοποιήσετε τους τίτλους, τους άξονες, τις γραμμές πλέγματος, τις λεζάντες και την περιοχή σχεδίασης του διαγράμματος. Αυτό το παράδειγμα δημιουργεί ένα διαγράφημα γραμμής με δείκτες και προεπιλεγμένα δεδομένα, στη συνέχεια εφαρμόζει ξεχωριστά στυλ κειμένου και γραμμής στους άξονες τιμών και κατηγοριών. Τα μεγέθη γραμματοσειράς και οι παχύτητες γραμμής καθορίζονται σε πόντους· οι ετικέτες κατηγοριών περιστρέφονται κατά 45 μοίρες. Ο άξονας τιμών χρησιμοποιεί την [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setNumberFormat) ανεξάρτητα από τα κελιά προέλευσης. Η κλίμακά του εκτείνεται από -2 έως 15, με κύρια διαστήματα 2 και δευτερεύματα 0,5. Το παράδειγμα επίσης συνδυάζει μορφοποίηση ποσοστού με την [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setDisplayUnit) ορισμένη σε χίλιες, έτσι προσαρμόστε αυτές τις ρυθμίσεις στο νόημα και το μέγεθος των δεδομένων σας. Η λεζάντα παραμένει έξω από την περιοχή σχεδίασης επειδή η [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#setOverlay) κλήθηκε με `false`. Οι γεμίσεις οπίσθιου τοίχου και floor διαμορφώνονται μέσω των [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getBackWall) και [getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getFloor), αλλά αυτές οι επιφάνειες είναι ορατές μόνο σε 3Δ διαγράμματα.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LineDashStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\TickLabelPositionType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle::DashDot);

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");

    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);

    $chart->getAxes()->getVerticalAxis()->setMaxValue(15);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);

    $valueAxisText = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $valueAxisText->setFontBold(NullableBool::True);
    $valueAxisText->setFontHeight(16);
    $valueAxisText->setFontItalic(NullableBool::True);
    $valueAxisText->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkGreen);
    $valueAxisText->setLatinFont(new FontData("Times New Roman"));

    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valueAxisTitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valueAxisTitle->setText("Primary Axis");
    $valueAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valueAxisTitle->getPortionFormat()->setFontHeight(20);
    $valueAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valueAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 128, 0));
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);

    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $categoryAxisText = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $categoryAxisText->setFontBold(NullableBool::True);
    $categoryAxisText->setFontHeight(16);
    $categoryAxisText->setFontItalic(NullableBool::True);
    $categoryAxisText->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisText->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $categoryAxisText->setLatinFont(new FontData("Arial"));

    $chart->getAxes()->getHorizontalAxis()->setTitle(true);
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");

    $categoryAxisTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $categoryAxisTitle->setText("Sample Category");
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $categoryAxisTitle->getPortionFormat()->setFontHeight(20);
    $categoryAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $categoryAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);

    $legendText = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $legendText->setFontBold(NullableBool::True);
    $legendText->setFontHeight(16);
    $legendText->setFontItalic(NullableBool::True);
    $legendText->getFillFormat()->setFillType(FillType::Solid);
    $legendText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkRed);

    $chart->getLegend()->setOverlay(false);

    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setPresetColor(PresetColor::LightCyan);

    $presentation->save("FormattedChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Ιδιοτήτων Γραμματοσειράς για Διάγραμμα**

Ορίστε το προεπιλεγμένο μέγεθος γραμματοσειράς για το κείμενο του διαγράμματος μέσω του [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getTextFormat). Το παράδειγμα δημιουργεί ένα στήλης σύμπλεξης με γραμματοσειρά 20 πόντων και ενεργοποιεί ετικέτες τιμών για την πρώτη σειρά μέσω του [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue). Τα στοιχεία κειμένου με τις δικές τους ρητές ρυθμίσεις γραμματοσειράς μπορούν να παρακάμψουν το προεπιλεγμένο του διαγράμματος.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Επαναχρησιμοποίηση Μορφοποίησης Πλαισίου Κειμένου για τη Λεζάντα του Διαγράμματος**

Για να ταιριάξετε μια λεζάντα με την επικεφαλίδα μιας διαφάνειας, ορίστε τη γραμματοσειρά της επικεφαλίδας μέσω του [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) στην πρώτη παράγραφο. Κλήστε το [copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyFrom) στη μορφή που επιστρέφεται από το [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#getTextFormat) της λεζάντας. Αντιγράφει τις ρυθμίσεις πλαισίου κειμένου, τη μορφοποίηση της πρώτης παραγράφου και τις προεπιλεγμένες ιδιότητες γραμματοσειράς της παραγράφου. Η μορφοποίηση που εφαρμόζεται απευθείας σε μεμονωμένα τμήματα ή σε μεταγενέστερες παραγράφους παραμένει τοπική στην πηγή. Το παράδειγμα χρησιμοποιεί μια έντονη επικεφαλίδα Calibri 26 πόντων σε ναυτικό χρώμα ως πρότυπο. Μετά το στυλιζάρισμα της λεζάντας, καλεί το [copyTo](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyTo) για να εφαρμόσει την ίδια μορφοποίηση σε ξεχωριστή λεζάντα.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\StyleType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $heading = $shapes->addAutoShape(ShapeType::Rectangle, 40, 20, 640, 40, false);
    $sourceTextFrame = $heading->addTextFrame("Quarterly sales");
    $font = $sourceTextFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $font->setLatinFont(new FontData("Calibri"));
    $font->setFontHeight(26);
    $font->setFontBold(NullableBool::True);
    $font->getFillFormat()->setFillType(FillType::Solid);
    $font->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 32, 64, 96));

    $chart = $shapes->addChart(ChartType::ClusteredColumn, 40, 75, 640, 360);
    $chart->setStyle(StyleType::Style3);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->getCell(0, 0, 1)->setValue("Retail");
    $workbook->getCell(0, 0, 2)->setValue("Online");
    $workbook->getCell(0, 0, 3)->setValue("Wholesale");
    for ($quarter = 1; $quarter <= 4; $quarter++) {
        $workbook->getCell(0, $quarter, 0)->setValue("Q" . $quarter);
    }

    $chart->setLegend(true);
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $legendFormat = $chart->getLegend()->getTextFormat();
    $legendFormat->copyFrom($sourceTextFrame);

    $caption = $shapes->addAutoShape(ShapeType::Rectangle, 40, 460, 640, 40, false);
    $captionTextFrame = $caption->addTextFrame("Sales in millions of dollars");
    $legendFormat->copyTo($captionTextFrame);

    $presentation->save("legend-formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Στην αποθηκευμένη παρουσίαση, η λεζάντα και η υπομνήση ταιριάζουν με την επικεφαλίδα ως προς το μέγεθος, το βάρος και το χρώμα. Η λεζάντα εξακολουθεί να εμφανίζει τα ονόματα των σειρών, και η υπομνήση διατηρεί το δικό της κείμενο. Εάν ένα τμήμα στην υπομνήση έχει ήδη ρητό μέγεθος γραμματοσειράς, αυτό το μέγεθος υπερισχύει του αντιγραμμένου προεπιλεγμένου της παραγράφου.

| Πριν από την αντιγραφή | Μετά την αντιγραφή |
| --- | --- |
| ![Διάγραμμα πωλήσεων κατά τρίμηνο με κανονικές μαύρες ετικέτες λεζάντας και μαύρη υπομνήση](legend-formatting-before.png) | ![Το ίδιο διάγραμμα με μεγαλύτερες, έντονες ναυτικές ετικέτες λεζάντας και αντίστοιχη υπομνήση](legend-formatting.png) |

## **Ορισμός Αριθμητικής Μορφής**

Χρησιμοποιήστε το [ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setPresetNumberFormat) για να εφαρμόσετε μια ενσωματωμένη αριθμητική μορφή σε κελιά του φύλλου εργασίας του διαγράμματος. Αυτό το παράδειγμα δημιουργεί ένα στήλης σύμπλεξης με προεπιλεγμένα δεδομένα που προέρχονται από κελιά και εφαρμόζει το δείκτη μορφής 10 (`0.00%`) σε κάθε κελί τιμής σειράς. Αυτό αλλάζει τον τρόπο εμφάνισης των τιμών στο βιβλίο εργασίας χωρίς να αλλάζει τους υποκείμενους αριθμούς· για παράδειγμα, το 0.25 εμφανίζεται ως 25,00%. Οι μορφές άξονα και ετικετών δεδομένων μπορούν να διαμορφωθούν ξεχωριστά.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries();

    for ($i = 0; $i < java_values($series->size()); $i++) {
        $chartSeries = $series->get_Item($i);
        $dataPoints = $chartSeries->getDataPoints();
        for ($j = 0; $j < java_values($dataPoints->size()); $j++) {
            $dataPoint = $dataPoints->get_Item($j);
            $dataPoint->getValue()->getAsCell()->setPresetNumberFormat(10); // 0.00%
        }
    }

    $presentation->save("PresetNumberFormat_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ο παρακάτω πίνακας παραθέτει ενσωματωμένους δείκτες αριθμητικών μορφών με αντιπροσωπευτικές μορφές Excel για την αγγλική (Ηνωμένες Πολιτείες) περιοχή. Οι ακριβείς αλφαριθμητικές μορφές και η εμφάνισή τους μπορεί να διαφέρουν ανά εφαρμογή και περιοχή, ιδιαίτερα για νομίσματα και ημερομηνίες. Ορισμένες μορφές Excel διαφέρουν επίσης από τα προεπιλεγμένα στο πρότυπο OOXML, όπως περιγράφεται στις [σημειώσεις υλοποίησης αριθμητικών μορφών της Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Δείκτης | Μορφή |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Ορισμός Στρογγυλεμένων Άκρων για την Περιοχή του Διαγράμματος**

Καλέστε το [Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setRoundedCorners) με `true` για να στρογγυλοποιήσετε τις γωνίες της περιοχής του διαγράμματος. Το παράδειγμα δημιουργεί ένα στήλης σύμπλεξης και χρησιμοποιεί το [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) για να δώσει στο περίγραμμα του ένα συμπαγές γκρι χρώμα και μονόστυλο στυλ προ της αποθήκευσης της παρουσίασης.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chart->getLineFormat()->setStyle(LineStyle::Single);
    $chart->setRoundedCorners(true);

    $presentation->save("out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Επεξεργασία Υπάρχουσας Σημειώσεων Διαγράμματος**

Ένα διάγραμμα μπορεί να περιέχει προσαρμοσμένα σχήματα, όπως μια σημείωση κειμένου που εξηγεί την κατάσταση μιας αναφοράς. Πρόσβαση σε αυτά τα σχήματα μέσω του [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getUserShapes). Η συλλογή που επιστρέφεται από το [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) περιέχει τα σχήματα που ανήκουν στο διάγραμμα. Ένα απλό πλαίσιο κειμένου τοποθετημένο πάνω από ένα διάγραμμα ανήκει στη διαφάνεια, ακόμη και αν φαίνεται μέρος του διαγράμματος. Η επανάληψη μέσω του [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) εντοπίζει το διάγραμμα και τα κανονικά σχήματα της διαφάνειας, αλλά δεν απαριθμεί τα μεμονωμένα σχήματα εντός του διαγράμματος. Οι τίτλοι διαγράμματος και οι ετικέτες δεδομένων είναι ξεχωριστά στοιχεία του διαγράμματος, όχι προσαρμοσμένες σημειώσεις σε αυτήν τη συλλογή. Κατεβάστε το [chart-annotations.pptx](chart-annotations.pptx) και τοποθετήστε το στον κατάλογο εργασίας της εφαρμογής. Η πρώτη του διαφάνεια περιέχει ένα διάγραμμα με μια μη ομαδοποιημένη σημείωση με κείμενο «Preliminary results», μια γραμμή που ανήκει στο διάγραμμα και ένα απλό πλαίσιο κειμένου διαφάνειας με κείμενο «Slide overlay». Το παράδειγμα εντοπίζει το πρώτο διάγραμμα σε αυτή τη διαφάνεια και αλλάζει τη σημείωση σε «Final results» όταν η αναφορά είναι έτοιμη για δημοσίευση. Ελέγχει για κενή συλλογή και επεξεργάζεται μόνο ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) με μη‑μηδενικό πλαίσιο κειμένου που επιστρέφεται από το [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) και το αναμενόμενο κείμενο.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-annotations.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chartType = new JavaClass("com.aspose.slides.IChart");
    $autoShapeType = new JavaClass("com.aspose.slides.IAutoShape");
    $chart = null;
    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++) {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartType)) {
            $chart = $shape;
            break;
        }
    }

    if ($chart === null || java_values($chart->getUserShapes()->getShapes()->size()) == 0) {
        echo "No chart or chart-owned shapes found." . PHP_EOL;
        return;
    }

    $updated = false;
    $userShapes = $chart->getUserShapes()->getShapes();
    for ($i = 0; $i < java_values($userShapes->size()); $i++) {
        $shape = $userShapes->get_Item($i);
        if (java_instanceof($shape, $autoShapeType)) {
            $annotation = $shape;
            if (!java_is_null($annotation->getTextFrame()) && java_values($annotation->getTextFrame()->getText()) === "Preliminary results") {
                $annotation->getTextFrame()->setText("Final results");
                $updated = true;
                break;
            }
        }
    }

    if ($updated) {
        $presentation->save("chart-annotations-updated.pptx", SaveFormat::Pptx);
    } else {
        echo "No matching text annotation found." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Η γραμμή και το πλαίσιο κειμένου της διαφάνειας παραμένουν αμετάβλητα. Οι παρακάτω εικόνες δείχνουν την είσοδο και το αποθηκευμένο, ξαναανοιγμένο αποτέλεσμα:

| Πριν την επεξεργασία | Μετά την επεξεργασία |
| --- | --- |
| ![Σημείωση διαγράμματος με κείμενο «Προκαταρκτικά αποτελέσματα»](chart-annotations-before.png) | ![Σημείωση διαγράμματος με κείμενο «Τελικά αποτελέσματα»](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Το παράδειγμα ελέγχει μόνο τα σχήματα που ανήκουν στο διάγραμμα σε ανώτερο επίπεδο. Εάν μια σημείωση βρίσκεται μέσα σε ένα [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), εξετάστε επίσης τη συλλογή [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) αυτής της ομάδας. Επαναλάβετε αυτό αναδρομικά για ενσωματωμένες ομάδες, εφαρμόζοντας τους ίδιους ελέγχους κειμένου στα παιδικά σχήματα. Μια ομάδα από μόνη της είναι ένας δοχείο· μην τη θεωρείτε ως πλαίσιο κειμένου.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Μπορώ να ορίσω ημιδιαφανείς γεμίσεις για στήλες/περιοχές ενώ διατηρώ το περίγραμμα αδιαφανές;**

Ναι. Η διαφάνεια της γεμίσματος και το περίγραμμα διαμορφώνονται ξεχωριστά. Αυτό είναι χρήσιμο για τη βελτίωση της αναγνωσιμότητας του πλέγματος και των δεδομένων σε πυκνές απεικονίσεις.

**Πώς μπορώ να αντιμετωπίσω τις ετικέτες δεδομένων όταν επικαλύπτονται;**

Μειώστε το μέγεθος γραμματοσειράς, απενεργοποιήστε μη απαραίτητα στοιχεία ετικέτας (π.χ., κατηγορίες), προσαρμόστε τη θέση της ετικέτας, δείξτε ετικέτες μόνο για επιλεγμένα σημεία εάν χρειαστεί, ή αλλάξτε τη μορφή σε «τιμή + λεζάντα».

**Μπορώ να εφαρμόσω διαβαθμίσεις ή μοτίβα γεμίσεως σε σειρές;**

Ναι. Οι σειρές υποστηρίζουν γεμίσεις συμπαγούς, διαβαθμισμένης και μοτίβου. Στην πράξη, χρησιμοποιήστε τις διαβαθμίσεις με μέτρο και αποφύγετε συνδυασμούς που μειώνουν την αντίθεση με το πλέγμα και το κείμενο.