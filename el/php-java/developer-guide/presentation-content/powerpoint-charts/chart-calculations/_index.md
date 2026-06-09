---
title: Βελτιστοποίηση Υπολογισμών Διαγραμμάτων για Παρουσιάσεις σε PHP
linktitle: Υπολογισμοί Διαγραμμάτων
type: docs
weight: 50
url: /el/php-java/chart-calculations/
keywords:
- υπολογισμοί διαγραμμάτων
- στοιχεία διαγράμματος
- θέση στοιχείου
- πραγματική θέση
- παιδικό στοιχείο
- γονικό στοιχείο
- τιμές διαγράμματος
- πραγματική τιμή
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Κατανοήστε τους υπολογισμούς διαγραμμάτων, τις ενημερώσεις δεδομένων και τον έλεγχο ακρίβειας στην Aspose.Slides for PHP μέσω Java για PPT και PPTX, με πρακτικά παραδείγματα κώδικα."
---
## **Επισκόπηση**

Η Aspose.Slides παρέχει API για εργασία με υπολογισμούς διαγραμμάτων και δεδομένα διάταξης σε παρουσιάσεις. Αυτό το άρθρο δείχνει πώς να ανακτήσετε τις πραγματικές τιμές των στοιχείων του διαγράμματος, συμπεριλαμβανομένης της πραγματικής θέσης και του μεγέθους των στοιχείων καθώς και των πραγματικών τιμών των αξόνων του διαγράμματος. Εξηγεί επίσης ότι αυτές οι τιμές πληρώνονται μετά την επικύρωση της διάταξης του διαγράμματος.

Επιπλέον, το άρθρο δείχνει πώς να λάβετε τη πραγματική θέση των γονικών στοιχείων του διαγράμματος και πώς να αποκρύψετε στοιχεία του διαγράμματος όπως ο τίτλος, οι άξονες, η υπόμνηση και οι γραμμές πλέγματος. Μαζί, αυτά τα παραδείγματα σας βοηθούν να ελέγξετε τις πληροφορίες διάταξης του διαγράμματος και να ελέγξετε την ορατότητα των στοιχείων του διαγράμματος σε παρουσιάσεις PowerPoint προγραμματιστικά.

## **Υπολογισμός Πραγματικών Τιμών Στοιχείων Διαγράμματος**
Η Aspose.Slides for PHP μέσω Java παρέχει ένα απλό API για τη λήψη αυτών των ιδιοτήτων. Οι μέθοδοι της κλάσης [Axis](https://reference.aspose.com/slides/el/php-java/aspose.slides/axis/) παρέχουν πληροφορίες σχετικά με την πραγματική θέση του στοιχείου άξονα του διαγράμματος ([getActualMaxValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/el/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/el/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/el/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/el/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/el/php-java/aspose.slides/axis/getactualminorunitscale/)). Είναι απαραίτητο να κληθεί η μέθοδος [Chart.validateChartLayout](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/validatechartlayout/) προηγουμένως για να γεμίσουν οι ιδιότητες με τις πραγματικές τιμές.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Υπολογισμός Πραγματικής Θέσης Γονικών Στοιχείων Διαγράμματος**
Η Aspose.Slides for PHP μέσω Java παρέχει ένα απλό API για τη λήψη αυτών των ιδιοτήτων. Οι μέθοδοι της κλάσης `ActualLayout` παρέχουν πληροφορίες για την πραγματική θέση του γονικού στοιχείου του διαγράμματος (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). Είναι απαραίτητο να κληθεί η μέθοδος [Chart.validateChartLayout](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/validatechartlayout/) προηγουμένως για να γεμίσουν οι ιδιότητες με τις πραγματικές τιμές.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Απόκρυψη Στοιχείων Διαγράμματος**
Αυτό το θέμα σας βοηθά να καταλάβετε πώς να αποκρύψετε πληροφορίες από το διάγραμμα. Χρησιμοποιώντας την Aspose.Slides for PHP μέσω Java μπορείτε να αποκρύψετε **Τίτλο, Κατακόρυφο Άξονα, Οριζόντιο Άξονα** και **Γραμμές Πλέγματος** από το διάγραμμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να χρησιμοποιήσετε αυτές τις ιδιότητες.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Απόκρυψη τίτλου διαγράμματος
    $chart->setTitle(false);
    # /Απόκρυψη άξονα τιμών
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Ορατότητα άξονα κατηγορίας
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Απόκρυψη υπομνήματος
    $chart->setLegend(false);
    # Απόκρυψη κύριων γραμμών πλέγματος
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Ορισμός χρώματος γραμμής σειράς
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Λειτουργούν τα εξωτερικά βιβλία εργασίας Excel ως πηγή δεδομένων και πώς αυτό επηρεάζει τον επαναϋπολογισμό;**

Ναι. Ένα διάγραμμα μπορεί να αναφορά σε εξωτερικό βιβλίο εργασίας: όταν συνδέεστε ή ανανεώνετε την εξωτερική πηγή, οι τύποι και οι τιμές προέρχονται από αυτό το βιβλίο εργασίας και το διάγραμμα αντικατοπτρίζει τις ενημερώσεις κατά τις λειτουργίες ανοίγματος/επεξεργασίας. Το API σάς επιτρέπει να [specify the external workbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/setexternalworkbook/) διαδρομή και να διαχειριστείτε τα συνδεδεμένα δεδομένα.

**Μπορώ να υπολογίσω και να εμφανίσω γραμμές τάσεων χωρίς να υλοποιήσω εγώ τη παλινδρόμηση;**

Ναι. Οι [Trendlines](/slides/el/php-java/trend-line/) (γραμμικές, εκθετικές και άλλες) προστίθενται και ενημερώνονται από την Aspose.Slides· οι παράμετροι τους επανυπολογίζονται αυτόματα από τα δεδομένα των σειρών, έτσι δεν χρειάζεται να υλοποιήσετε δικούς σας υπολογισμούς.

**Εάν μια παρουσίαση έχει πολλά διαγράμματα με εξωτερικούς συνδέσμους, μπορώ να ελέγξω ποιο βιβλίο εργασίας χρησιμοποιεί κάθε διάγραμμα για τις υπολογιζόμενες τιμές;**

Ναι. Κάθε διάγραμμα μπορεί να επισημάνει το δικό του [external workbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdata/setexternalworkbook/), ή μπορείτε να δημιουργήσετε/αντικαταστήσετε ένα εξωτερικό βιβλίο εργασίας ανά διάγραμμα ανεξάρτητα από τα άλλα.