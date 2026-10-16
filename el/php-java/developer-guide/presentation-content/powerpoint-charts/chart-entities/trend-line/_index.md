---
title: Προσθήκη Γραμμών Τάσης σε Διαγράμματα Παρουσίασης σε PHP
linktitle: Γραμμή Τάσης
type: docs
url: /el/php-java/trend-line/
keywords:
- διάγραμμα
- γραμμή τάσης
- εκθετική γραμμή τάσης
- γραμμική γραμμή τάσης
- λογαριθμική γραμμή τάσης
- γραμμή τάσης κινητού μέσου
- πολυωνυμική γραμμή τάσης
- γραμμή τάσης δύναμης
- προσαρμοσμένη γραμμή τάσης
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Προσθέστε και προσαρμόστε γρήγορα γραμμές τάσης σε διαγράμματα PowerPoint με το Aspose.Slides για PHP μέσω Java — έναν πρακτικό οδηγό για να εντυπωσιάσετε το κοινό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης στις σειρές του διαγράμματος και να εργαστείτε με διάφορους τύπους γραμμών τάσης, συμπεριλαμβανομένων των εκθετικών, γραμμικών, λογαριθμικών, κινητού μέσου, πολυωνυμικών και δύναμης.

Επίσης περιγράφει πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε ένα διάγραμμα εισάγοντας σχήμα γραμμής και περιλαμβάνει μια σύντομη Συχνές Ερωτήσεις (FAQ) σχετικά με τις τιμές προβολής των γραμμών τάσης προς μπροστά και προς τα πίσω και αν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά την απόδοση των διαγραμμάτων ως εικόνες.

## **Προσθήκη Γραμμής Τάσης**

Χρησιμοποιήστε [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) για να προσθέσετε μια γραμμή τάσης σε μια σειρά διαγράμματος, επιλέγοντας τον τύπο της με το [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). Το παράδειγμα δημιουργεί ένα σύμπλεγμα ραβδογράφηματος με προεπιλεγμένα δεδομένα και προσθέτει δύο γραμμές τάσης σε καθεμία από τις τρεις σειρές του.

Η εκθετική γραμμή τάσης κρύβει την εξίσωση και την τιμή του R‑τετράγωνου μέσω του [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) και του [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/), ενώ η γραμμική γραμμή τάσης είναι κόκκινη. Η λογαριθμική γραμμή τάσης χρησιμοποιεί το [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) για ένα προσαρμοσμένο ετικέτα. Η γραμμή κινητού μέσου χρησιμοποιεί ένα [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) τριών σημείων δεδομένων και ένα προσαρμοσμένο [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/).

Η πολυωνυμική γραμμή τάσης έχει τάξη τριών, που ορίζεται μέσω του [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), και επεκτείνεται μία κατηγορία προς τα μπροστά μέσω του [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). Η γραμμή τάσης δύναμης επεκτείνεται μία κατηγορία προς τα πίσω μέσω του [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Σημείου Τομής Γραμμής Τάσης**

Χρησιμοποιήστε το [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) για να καθορίσετε την τιμή Y μιας γραμμής τάσης στο X = 0. Αυτή η ρύθμιση υποστηρίζεται για γραμμικές, εκθετικές και πολυωνυμικές γραμμές τάσης.

Για παράδειγμα, ένα μοντέλο κόστους παραγωγής ίσως χρειάζεται να ξεκινά με γνωστά σταθερά κόστη 100, ακόμη και όταν μετρήσεις σε μη μηδενικούς όγκους παραγωγής υποδηλώνουν διαφορετική βάση. Για μια γραμμική γραμμή τάσης, η καθορισμένη τομή περιορίζει την εξίσωση `y = ax + b` στο `b = 100`; η κλίση προσαρμόζεται στα δεδομένα υπό αυτόν τον περιορισμό. Αυτό δεν μετακινεί απλώς μια ήδη προσαρμοσμένη γραμμή. Οι ρυθμίσεις διασταύρωσης άξονα ελέγχουν πού συναντώνται οι άξονες του διαγράμματος, όχι τους συντελεστές της προσαρμοσμένης γραμμής τάσης.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα διασκορπισμού (XY) με όγκους παραγωγής από 1 έως 4 και κόστη 170, 200, 230 και 260. Αποθηκεύει το διάγραμμα με την προεπιλεγμένη αυτόματη τομή, ορίζει τη τομή στο 100 και αποθηκεύει ένα δεύτερο αρχείο PPTX. Τα δύο αρχεία διαφέρουν μόνο στη ρύθμιση της τομής. Η γραμμή τάσης εμφανίζει την εξίσωσή της και επεκτείνεται πίσω στο X = 0.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Με αυτόματο υπολογισμό, αυτά τα δεδομένα παράγουν `y = 30x + 140`. Ορίζοντας τη τομή στο 100 αντίθετα παράγει περίπου `y = 43.33x + 100`: η προσαρμοσμένη τιμή στο μηδέν ταιριάζει με τη γνωστή βάση, ενώ η γραμμή δεν περνά πλέον από κάθε σημείο δεδομένων.

| Αυτόματη τομή | Σταθερή τομή 100 |
| --- | --- |
| ![Γραμμική γραμμή τάσης με αυτόματα υπολογισμένη τομή 140](intercept-automatic.png) | ![Γραμμική γραμμή τάσης με σταθερή τομή 100](intercept-fixed.png) |

Και τα δύο εικόνες χρησιμοποιούν τα ίδια δεδομένα και κλίμακες άξονα. Οι γραμμές τάσης επεκτείνονται πίσω στο X = 0 για να εμφανίσουν τις τομές τους.

Από προεπιλογή, το [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) επιστρέφει `NaN`, που αντιπροσωπεύει μια ακαθόριστη τομή αντί για μηδέν. Η τομή στη συνέχεια υπολογίζεται αυτόματα από τα δεδομένα.

## **Προσθήκη Προσαρμοσμένης Γραμμής**

Μια προσαρμοσμένη γραμμή είναι ένα σχήμα σχεδιασμένο πάνω στο διάγραμμα αντί για γραμμή τάσης που υπολογίζεται από τα δεδομένα της σειράς. Αυτό το παράδειγμα χρησιμοποιεί το [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) για να προσθέσει μια οριζόντια γραμμή στη διαφάνεια πάνω από το διάγραμμα. Η θέση της γραμμής καθορίζεται σε συντεταγμένες διαφάνειας, μετρημένα σε πόντοι, έτσι ώστε να ξεκινά στο αριστερό άκρο του διαγράμματος και να βρίσκεται στο μέσο του ύψους του διαγράμματος. Το πλάτος της ταιριάζει με το πλάτος του διαγράμματος. Το [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) δίνει στη γραμμή ένα συμπαγές κόκκινο χρώμα.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Τι σημαίνουν τα 'forward' και 'backward' για μια γραμμή τάσης;**

Αυτές είναι οι διαδρομές της γραμμής τάσης που προβάλλονται προς τα εμπρός ή προς τα πίσω: για διαγράμματα διασποράς (XY) — σε μονάδες άξονα· για μη‑διαγράμματα διασποράς — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη‑αρνητικές τιμές.

**Will the trend line be preserved when exporting the presentation to PDF or SVG, or when rendering a slide to an image?**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/php-java/convert-powerpoint-to-pdf/) ή [SVG](/slides/el/php-java/render-a-slide-as-an-svg-image/) και αποδίδει τα διαγράμματα ως εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά αυτές τις λειτουργίες. Υπάρχει επίσης μια μέθοδος για να [export an image of the chart](/slides/el/php-java/create-shape-thumbnails/) itself.