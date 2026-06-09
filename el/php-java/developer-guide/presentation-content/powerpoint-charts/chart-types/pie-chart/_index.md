---
title: Προσαρμογή Διαγραμμάτων Πίτας σε Παρουσιάσεις χρησιμοποιώντας PHP
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/php-java/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές απεικόνισης
- χρώμα φέτας
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα πίτας με το Aspose.Slides για PHP μέσω Java, εξαχόμενα σε PowerPoint, ενισχύοντας την αφήγηση των δεδομένων σας σε δευτερόλεπτα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με διαγράμματα πίτας στο Aspose.Slides. Δείχνει πώς να διαμορφώσετε επιλογές δευτερεύουσας απεικόνισης για διαγράμματα Pie of Pie και Bar of Pie, καθώς και πώς να ενεργοποιήσετε την αυτόματη χρωματισμό των φέταδων για ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα εστιάζουν σε πρακτικά βήματα προσαρμογής διαγράμματος, όπως η προσθήκη διαγράμματος σε μια διαφάνεια, η ρύθμιση σειρών και ετικετών, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Δεύτερες Επιλογές Απεικόνισης για Διαγράμματα Pie of Pie και Bar of Pie**

Το Aspose.Slides for PHP μέσω Java υποστηρίζει πλέον επιλογές δευτερεύουσας απεικόνισης για διαγράμματα Pie of Pie ή Bar of Pie. Σε αυτό το θέμα, θα σας δείξουμε πώς να καθορίσετε αυτές τις επιλογές χρησιμοποιώντας το Aspose.Slides. Για να καθορίσετε τις ιδιότητες, κάντε το εξής:

1. Δημιουργήστε ένα αντικείμενο κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Προσθέστε διάγραμμα στη διαφάνεια.
1. Καθορίστε τις επιλογές δευτέρας απεικόνισης του διαγράμματος.
1. Γράψτε την παρουσίαση στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε ορίσει διάφορες ιδιότητες του διαγράμματος Pie of Pie.

```php
  # Δημιουργία ενός αντικειμένου της κλάσης Presentation
  $pres = new Presentation();
  try {
    # Προσθήκη διαγράμματος στη διαφάνεια
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Ορισμός διαφόρων ιδιοτήτων
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Αποθήκευση παρουσίασης στο δίσκο
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός Αυτόματων Χρωμάτων Φέτας Διαγράμματος Πίτας**

Το Aspose.Slides for PHP μέσω Java παρέχει ένα απλό API για τον καθορισμό αυτόματων χρωμάτων φέτας διαγράμματος πίτας. Ο κώδικας παραδείγματος εφαρμόζει τον καθορισμό των παραπάνω ιδιοτήτων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα.
1. Ορίστε τον τίτλο του διαγράμματος.
1. Ορίστε την πρώτη σειρά σε Εμφάνιση Τιμών.
1. Ορίστε το ευρετήριο του φύλλου δεδομένων του διαγράμματος.
1. Απόκτηση του φύλλου εργασίας δεδομένων του διαγράμματος.
1. Διαγράψτε τις προεπιλεγμένες σειρές και κατηγορίες που δημιουργήθηκαν.
1. Προσθέστε νέες κατηγορίες.
1. Προσθέστε νέες σειρές.

Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```php
  # Δημιουργία ενός αντικειμένου της κλάσης Presentation
  $pres = new Presentation();
  try {
    # Προσθήκη διαγράμματος με προεπιλεγμένα δεδομένα
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Ορισμός τίτλου διαγράμματος
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Ορισμός πρώτης σειράς σε Εμφάνιση Τιμών
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Ορισμός του ευρετηρίου του φύλλου δεδομένων του διαγράμματος
    $defaultWorksheetIndex = 0;
    # Απόκτηση του φύλλου εργασίας δεδομένων του διαγράμματος
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Διαγραφή προεπιλεγμένων παραγόμενων σειρών και κατηγοριών
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Προσθήκη νέων κατηγοριών
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Προσθήκη νέων σειρών
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Τώρα γεμίζονται τα δεδομένα της σειράς
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζονται οι παραλλαγές 'Pie of Pie' και 'Bar of Pie';**

Ναι, η βιβλιοθήκη [υποστηρίζει](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/) μια δευτερεύουσα απεικόνιση για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων 'Pie of Pie' και 'Bar of Pie'.

**Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξάγετε το ίδιο το διάγραμμα ως εικόνα](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getImage) (π.χ. PNG) χωρίς ολόκληρη την παρουσίαση.