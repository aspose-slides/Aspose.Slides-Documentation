---
title: Προσαρμογή των αξόνων γραφήματος σε παρουσιάσεις χρησιμοποιώντας PHP
linktitle: Άξονας γραφήματος
type: docs
url: /el/php-java/chart-axis/
keywords:
- άξονας γραφήματος
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
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides for PHP via Java για την προσαρμογή των αξόνων γραφήματος σε παρουσιάσεις PowerPoint για εκθέσεις και απεικονίσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόζετε τους άξονες γραφημάτων στην Aspose.Slides. Δείχνει πώς να λαμβάνετε τις πραγματικές τιμές των αξόνων, να ανταλλάζετε δεδομένα μεταξύ αξόνων, να κρύβετε τον κατακόρυφο ή οριζόντιο άξονα για γραφήματα γραμμής, να αλλάζετε τον τύπο του άξονα κατηγορίας, να ορίζετε τη μορφή ημερομηνίας για τις τιμές του άξονα κατηγορίας, να περιστρέφετε τον τίτλο του άξονα, να ορίζετε τη θέση του άξονα και να εμφανίζετε ετικέτα μονάδας στον άξονα τιμών.

## **Λήψη των μέγιστων τιμών στον κατακόρυφο άξονα στα γραφήματα**
Aspose.Slides for PHP via Java σας επιτρέπει να λαμβάνετε τις ελάχιστες και μέγιστες τιμές σε έναν κατακόρυφο άξονα. Ακολουθήστε αυτά τα βήματα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Προσπελάστε τη πρώτη διαφάνεια.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα.
1. Λάβετε την πραγματική μέγιστη τιμή στον άξονα.
1. Λάβετε την πραγματική ελάχιστη τιμή στον άξονα.
1. Λάβετε τη πραγματική κύρια μονάδα του άξονα.
1. Λάβετε τη πραγματική δευτερεύουσα μονάδα του άξονα.
1. Λάβετε την πραγματική κλίμακα της κύριας μονάδας του άξονα.
1. Λάβετε την πραγματική κλίμακα της δευτερεύουσας μονάδας του άξονα.

Αυτό το παράδειγμα κώδικα—μια υλοποίηση των παραπάνω βημάτων—δείχνει πώς να λαμβάνονται οι απαιτούμενες τιμές :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Αποθηκεύει την παρουσίαση
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ανταλλαγή των δεδομένων μεταξύ αξόνων**
Aspose.Slides σας επιτρέπει να ανταλλάξετε γρήγορα τα δεδομένα μεταξύ αξόνων—τα δεδομένα που απεικονίζονται στον κατακόρυφο άξονα (y‑axis) μετακινούνται στον οριζόντιο άξονα (x‑axis) και αντίστροφα.

Αυτός ο κώδικας PHP σας δείχνει πώς να εκτελέσετε την αλλαγή θέσης των δεδομένων μεταξύ αξόνων σε ένα γράφημα:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Αλλάζει γραμμές και στήλες
    $chart->getChartData()->switchRowColumn();
    # Αποθηκεύει την παρουσίαση
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Απενεργοποίηση του κατακόρυφου άξονα για γραφήματα γραμμής**
Αυτός ο κώδικας PHP σας δείχνει πώς να κρύψετε τον κατακόρυφο άξονα για ένα γράφημα γραμμής:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Απενεργοποίηση του οριζόντιου άξονα για γραφήματα γραμμής**
Αυτός ο κώδικας σας δείχνει πώς να κρύψετε τον οριζόντιο άξονα για ένα γράφημα γραμμής:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αλλαγή του άξονα κατηγορίας**
Χρησιμοποιώντας την ιδιότητα **CategoryAxisType**, μπορείτε να καθορίσετε τον προτιμώμενο τύπο άξονα κατηγορίας (**date** ή **text**). Αυτός ο κώδικας επιδεικνύει τη λειτουργία:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ορισμός της μορφής ημερομηνίας για τις τιμές του άξονα κατηγορίας**
Η Aspose.Slides for PHP via Java σας επιτρέπει να ορίσετε τη μορφή ημερομηνίας για μια τιμή άξονα κατηγορίας. Η λειτουργία επιδεικνύεται σε αυτόν τον κώδικα PHP:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Ορισμός της γωνίας περιστροφής για τον τίτλο άξονα γραφήματος**
Η Aspose.Slides for PHP via Java σας επιτρέπει να ορίσετε τη γωνία περιστροφής για τον τίτλο άξονα ενός γραφήματος. Αυτός ο κώδικας PHP επιδεικνύει τη λειτουργία:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός της θέσης του άξονα σε άξονα κατηγορίας ή τιμής**
Η Aspose.Slides for PHP via Java σας επιτρέπει να ορίσετε τη θέση του άξονα σε άξονα κατηγορίας ή τιμής. Αυτός ο κώδικας PHP δείχνει πώς να εκτελέσετε την εργασία:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ενεργοποίηση της ετικέτας μονάδας εμφάνισης στον άξονα τιμών του γραφήματος**
Η Aspose.Slides for PHP via Java σας επιτρέπει να ρυθμίσετε ένα γράφημα ώστε να εμφανίζει ετικέτα μονάδας στον άξονα τιμών του. Αυτός ο κώδικας PHP επιδεικνύει τη λειτουργία:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλον (διασύνδεση αξόνων);**

Οι άξονες παρέχουν μια [ρύθμιση διασύνδεσης](https://reference.aspose.com/slides/el/php-java/aspose.slides/axis/setcrosstype/): μπορείτε να επιλέξετε να διασχίζουν στο μηδέν, στο μέγιστο της κατηγορίας/τιμής, ή σε συγκεκριμένη αριθμητική τιμή. Αυτό είναι χρήσιμο για τη μετακίνηση του άξονα X προς τα πάνω ή κάτω ή για την ανάδειξη μιας βασικής γραμμής.

**Πώς μπορώ να τοποθετήσω τις ετικέτες των σημείων αναφοράς σε σχέση με τον άξονα (πλάι, έξω, μέσα);**

Ορίστε τη [θέση ετικέτας](https://reference.aspose.com/slides/el/php-java/aspose.slides/axis/setmajortickmark/) σε "cross", "outside" ή "inside". Αυτό επηρεάζει την αναγνωσιμότητα και βοηθά στη εξοικονόμηση χώρου, ιδιαίτερα σε μικρά γραφήματα.