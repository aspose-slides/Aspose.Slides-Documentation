---
title: Διαχείριση ετικετών δεδομένων γραφήματος σε παρουσιάσεις χρησιμοποιώντας PHP
linktitle: Ετικέτα δεδομένων
type: docs
url: /el/php-java/chart-data-label/
keywords:
- γράφημα
- ετικέτα δεδομένων
- ακρίβεια δεδομένων
- ποσοστό
- απόσταση ετικέτας
- θέση ετικέτας
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων γραφήματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας Aspose.Slides για PHP μέσω Java για πιο εντυπωσιακές διαφάνειες."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων σε ένα γράφημα εμφανίζουν λεπτομέρειες σχετικά με τις σειρές δεδομένων του γραφήματος ή μεμονωμένα σημεία δεδομένων. Επιτρέπουν στους αναγνώστες να εντοπίζουν γρήγορα τις σειρές δεδομένων και επίσης κάνουν τα γραφήματα πιο εύκολα στην κατανόηση.

## **Ορισμός Ακρίβειας Δεδομένων στις Ετικέτες Δεδομένων Γραφήματος**

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε την ακρίβεια δεδομένων σε μια ετικέτα δεδομένων γραφήματος:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);
    $chart->getChartData()->getSeries()->get_Item(0)->setNumberFormatOfValues("#,##0.00");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Εμφάνιση Ποσοστών ως Ετικέτες**
Aspose.Slides για PHP μέσω Java επιτρέπει τον ορισμό ετικετών ποσοστών σε εμφανιζόμενα γραφήματα. Αυτός ο κώδικας PHP επιδεικνύει τη λειτουργία:

```php
  # Δημιουργεί ένα αντικείμενο της κλάσης Presentation
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);
    $series;
    $total_for_Cat = new double[$chart->getChartData()->getCategories()->size()];
    for($k = 0; $k < java_values($chart->getChartData()->getCategories()->size()) ; $k++) {
      $cat = $chart->getChartData()->getCategories()->get_Item($k);
      for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
        $total_for_Cat[$k] = $total_for_Cat[$k] + $chart->getChartData()->getSeries()->get_Item($i)->getDataPoints()->get_Item($k)->getValue()->getData();
      }
    }
    $dataPontPercent = 0.0;
    for($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()) ; $x++) {
      $series = $chart->getChartData()->getSeries()->get_Item($x);
      $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);
      for($j = 0; $j < java_values($series->getDataPoints()->size()) ; $j++) {
        $lbl = $series->getDataPoints()->get_Item($j)->getLabel();
        $dataPontPercent = $series->getDataPoints()->get_Item($j)->getValue()->getData() / $total_for_Cat[$j] * 100;
        $port = new Portion();
        $port->setText(sprintf("{0:F2} %.2f", $dataPontPercent));
        $port->getPortionFormat()->setFontHeight(8.0);
        $lbl->getTextFrameForOverriding()->setText("");
        $para = $lbl->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
        $para->getPortions()->add($port);
        $lbl->getDataLabelFormat()->setShowSeriesName(false);
        $lbl->getDataLabelFormat()->setShowPercentage(false);
        $lbl->getDataLabelFormat()->setShowLegendKey(false);
        $lbl->getDataLabelFormat()->setShowCategoryName(false);
        $lbl->getDataLabelFormat()->setShowBubbleSize(false);
      }
    }
    # Αποθηκεύει την παρουσίαση που περιέχει το γράφημα
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός του Συμβόλου Ποσοστού με τις Ετικέτες Δεδομένων Γραφήματος**
Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε το σύμβολο του ποσοστού για μια ετικέτα δεδομένων γραφήματος:

```php
  # Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
  $pres = new Presentation();
  try {
    # Αποκτά την αναφορά μιας διαφάνειας μέσω του ευρετηρίου
    $slide = $pres->getSlides()->get_Item(0);
    # Δημιουργεί το γράφημα PercentsStackedColumn σε μια διαφάνεια
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # Ορίζει το NumberFormatLinkedToSource σε false
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # Λαμβάνει το φύλλο εργασίας δεδομένων του γραφήματος
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # Προσθέτει νέα σειρά
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # Ορίζει το χρώμα γεμίσματος της σειράς
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Ορίζει τις ιδιότητες του LabelFormat
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Προσθέτει νέα σειρά
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # Ορίζει τον τύπο γεμίσματος και το χρώμα
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # Αποθηκεύει την παρουσίαση στο δίσκο
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός Απόστασης Ετικέτας από Άξονα**
Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε την απόσταση της ετικέτας από τον άξονα κατηγορίας όταν εργάζεστε με γράφημα σχεδιασμένο από άξονες:

```php
  # Δημιουργεί ένα στιγμιότυπο της κλάσης Presentation
  $pres = new Presentation();
  try {
    # Λαμβάνει μια αναφορά σε διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Δημιουργεί ένα γράφημα στη διαφάνεια
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # Ορίζει την απόσταση ετικέτας από έναν άξονα
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # Αποθηκεύει την παρουσίαση στο δίσκο
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσαρμογή Θέσης Ετικέτας**

Όταν δημιουργείτε ένα γράφημα που δεν βασίζεται σε κανένα άξονα, όπως ένα διάγραμμα πίτας, οι ετικέτες δεδομένων του γραφήματος μπορεί να καταλήξουν πολύ κοντά στην άκρη του. Σε μια τέτοια περίπτωση, πρέπει να προσαρμόσετε τη θέση της ετικέτας δεδομένων ώστε οι γραμμές οδηγίας να εμφανίζονται καθαρά.

Αυτός ο κώδικας PHP δείχνει πώς να προσαρμόσετε τη θέση της ετικέτας σε ένα διάγραμμα πίτας:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();
    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition->OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αποτρέψω την επικάλυψη των ετικετών δεδομένων σε πυκνά γραφήματα;**

Συνδυάστε την αυτοματοποιημένη τοποθέτηση ετικετών, τις γραμμές οδηγίας και τη μειωμένη μέγεθος γραμματοσειράς· εάν χρειάζεται, κρύψτε ορισμένα πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραία/βασικά σημεία.

**Πώς μπορώ να απενεργοποιήσω τις ετικέτες μόνο για τιμές μηδέν, αρνητικές ή κενές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές τιμές ή ελλιπείς τιμές σύμφωνα με έναν καθορισμένο κανόνα.

**Πώς μπορώ να διασφαλίσω ένα συνεπές στυλ ετικετών κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά τις γραμματοσειρές (οικογένεια, μέγεθος) και επαληθεύστε ότι η γραμματοσειρά είναι διαθέσιμη στην πλευρά απόδοσης για να αποφύγετε την εναλλακτική.