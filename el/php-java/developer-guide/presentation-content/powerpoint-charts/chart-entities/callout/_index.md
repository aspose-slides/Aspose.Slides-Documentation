---
title: Διαχείριση επεξηγήσεων σε διαγράμματα παρουσίασης με PHP
linktitle: Επεξήγηση
type: docs
url: /el/php-java/callout/
keywords:
- επεξήγηση διαγράμματος
- χρήση επεξήγησης
- ετικέτα δεδομένων
- μορφή ετικέτας
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε και μορφοποιήστε επεξηγήσεις στο Aspose.Slides for PHP via Java με σύντομα παραδείγματα κώδικα, συμβατά με PPT και PPTX, για την αυτοματοποίηση των ροών εργασίας παρουσίασης."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με τις επεξηγήσεις για τις ετικέτες δεδομένων διαγράμματος στο Aspose.Slides. Δείχνει πώς να χρησιμοποιήσετε τη μέθοδο `setShowLabelAsDataCallout` για να εμφανίζετε τις ετικέτες ως επεξηγήσεις, πώς να διαμορφώσετε τις ρυθμίσεις ετικετών που σχετίζονται με επεξηγήσεις για ένα διάγραμμα δακτυλίου, και σημειώνει ότι οι επεξηγήσεις και η εμφάνισή τους διατηρούνται όταν οι παρουσιάσεις εξάγονται σε PDF, HTML5, SVG και μορφές ραστερ εικόνων.

## **Χρήση Επεξηγήσεων**

Νέες μέθοδοι [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/el/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) και [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/el/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/) προστέθηκαν στην κλάση [DataLabelFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/datalabelformat). Αυτές οι μέθοδοι καθορίζουν αν η ετικέτα δεδομένων του συγκεκριμένου διαγράμματος θα εμφανίζεται ως επεξήγηση δεδομένων ή ως ετικέτα δεδομένων.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 500, 400);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowLabelAsDataCallout(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->get_Item(2)->getDataLabelFormat()->setShowLabelAsDataCallout(false);
    $pres->save("DisplayCharts.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός Επεξήγησης για Διάγραμμα Δακτυλίου**

Το Aspose.Slides for PHP via Java παρέχει υποστήριξη για ορισμό του σχήματος επεξήγησης ετικέτας δεδομένων σειράς για ένα διάγραμμα δακτυλίου. Ένα παράδειγμα δείγματος παρέχεται παρακάτω.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Doughnut, 10, 10, 500, 500, false);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(false);
    $seriesIndex = 0;
    while ($seriesIndex < 15) {
      $series = $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, $seriesIndex + 1, "SERIES " . $seriesIndex), $chart->getType());
      $series->setExplosion(0);
      $series->getParentSeriesGroup()->setDoughnutHoleSize(20);
      $series->getParentSeriesGroup()->setFirstSliceAngle(351);
      $seriesIndex++;
    } 
    $categoryIndex = 0;
    while ($categoryIndex < 15) {
      $chart->getChartData()->getCategories()->add($workBook->getCell(0, $categoryIndex + 1, 0, "CATEGORY " . $categoryIndex));
      $i = 0;
      while ($i < java_values($chart->getChartData()->getSeries()->size())) {
        $iCS = $chart->getChartData()->getSeries()->get_Item($i);
        $dataPoint = $iCS->getDataPoints()->addDataPointForDoughnutSeries($workBook->getCell(0, $categoryIndex + 1, $i + 1, 1));
        $dataPoint->getFormat()->getFill()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
        $dataPoint->getFormat()->getLine()->setWidth(1);
        $dataPoint->getFormat()->getLine()->setStyle(LineStyle->Single);
        $dataPoint->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
        if ($i == java_values($chart->getChartData()->getSeries()->size()) - 1) {
          $lbl = $dataPoint->getLabel();
          $lbl->getTextFormat()->getTextBlockFormat()->setAutofitType(TextAutofitType::Shape);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setLatinFont(new FontData("DINPro-Bold"));
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(12);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
          $lbl->getDataLabelFormat()->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
          $lbl->getDataLabelFormat()->setShowValue(false);
          $lbl->getDataLabelFormat()->setShowCategoryName(true);
          $lbl->getDataLabelFormat()->setShowSeriesName(false);
          $lbl->getDataLabelFormat()->setShowLeaderLines(true);
          $lbl->getDataLabelFormat()->setShowLabelAsDataCallout(false);
          $chart->validateChartLayout();
          $lbl->setX($lbl->getX() + 0.5);
          $lbl->setY($lbl->getY() + 0.5);
        }
        $i++;
      } 
      $categoryIndex++;
    } 
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι επεξηγήσεις κατά τη μετατροπή μιας παρουσίασης σε PDF, HTML5, SVG ή εικόνες;**

Ναι. Οι επεξηγήσεις αποτελούν μέρος της απόδοσης του διαγράμματος, οπότε όταν εξάγετε σε [PDF](/slides/el/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/el/php-java/export-to-html5/), [SVG](/slides/el/php-java/render-a-slide-as-an-svg-image/), ή [εξαγόμενες εικόνες](/slides/el/php-java/convert-powerpoint-to-png/), διατηρούνται μαζί με τη μορφοποίηση της διαφάνειας.

**Λειτουργούν οι προσαρμοσμένες γραμματοσειρές στις επεξηγήσεις και μπορεί η εμφάνισή τους να διατηρηθεί στην εξαγωγή;**

Ναι. Το Aspose.Slides υποστηρίζει την [ενσωμάτωση γραμματοσειρών](/slides/el/php-java/embedded-font/) στην παρουσίαση και ελέγχει την ενσωμάτωση γραμματοσειρών κατά τις εξαγωγές, όπως σε [PDF](/slides/el/php-java/convert-powerpoint-to-pdf/), εξασφαλίζοντας ότι οι επεξηγήσεις διατηρούν την ίδια εμφάνιση σε διαφορετικά συστήματα.