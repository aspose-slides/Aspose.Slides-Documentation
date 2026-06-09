---
title: Προσαρμογή Γραμμών Σφάλματος σε Διαγράμματα Παρουσίασης χρησιμοποιώντας PHP
linktitle: Γραμμή Σφάλματος
type: docs
url: /el/php-java/error-bar/
keywords:
- γραμμή σφάλματος
- προσαρμοσμένη τιμή
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να προσαρμόζετε γραμμές σφάλματος σε διαγράμματα με το Aspose.Slides for PHP via Java — βελτιώστε τις οπτικές απεικονίσεις δεδομένων σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με γραμμές σφάλματος σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσθέσετε γραμμές σφάλματος σε μια σειρά διαγράμματος, να διαμορφώσετε τις ρυθμίσεις γραμμής σφάλματος X και Y, και να εφαρμόσετε διαφορετικούς τύπους τιμών όπως σταθερές, ποσοστό και προσαρμοσμένες τιμές.

Επίσης, παρουσιάζει πώς να ορίζετε προσαρμοσμένες τιμές γραμμών σφάλματος για μεμονωμένα σημεία δεδομένων σε μια σειρά χρησιμοποιώντας τη σχετική συλλογή σημείων δεδομένων. Επιπλέον, το άρθρο περιλαμβάνει σύντομες σημειώσεις σχετικά με το πώς συμπεριφέρονται οι γραμμές σφάλματος κατά την εξαγωγή, τη συμβατότητά τους με σημεία σήμανσης και ετικέτες δεδομένων, και πού να βρείτε τις σχετικές κλάσεις και τις απαριθμήσεις αναφοράς API.

## **Προσθήκη Γραμμών Σφάλματος**
Aspose.Slides for PHP via Java παρέχει ένα απλό API για τη διαχείριση τιμών γραμμών σφάλματος. Ο κώδικας δείγματος εφαρμόζεται όταν χρησιμοποιείται προσαρμοσμένος τύπος τιμής. Για να καθορίσετε μια τιμή, χρησιμοποιήστε την ιδιότητα **ErrorBarCustomValues** ενός συγκεκριμένου σημείου δεδομένων στη συλλογή [**data points**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseriescollection/) της σειράς:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Προσθέστε ένα διάγραμμα φυσαλίδων στη ζητούμενη διαφάνεια.
1. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή γραμμής σφάλματος X.
1. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή γραμμής σφάλματος Y.
1. Ορισμός τιμών και μορφοποίησης των γραμμών.
1. Γράψτε την τροποποιημένη παρουσίαση σε ένα αρχείο PPTX.

```php
  # Δημιουργία ενός στιγμιοτύπου της κλάσης Presentation
  $pres = new Presentation();
  try {
    # Δημιουργία ενός διαγράμματος φυσαλίδων
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Προσθήκη γραμμών σφάλματος και ρύθμιση της μορφής τους
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Αποθήκευση παρουσίασης
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη Προσαρμοσμένων Τιμών Γραμμής Σφάλματος**
Aspose.Slides for PHP via Java παρέχει ένα απλό API για τη διαχείριση προσαρμοσμένων τιμών γραμμών σφάλματος. Ο κώδικας δείγματος εφαρμόζεται όταν η μέθοδος [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/el/php-java/aspose.slides/errorbarsformat/#getValueType) επιστρέφει **Custom**. Για να καθορίσετε μια τιμή, χρησιμοποιήστε την ιδιότητα **ErrorBarCustomValues** ενός συγκεκριμένου σημείου δεδομένων στη συλλογή [**data points**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartseriescollection/) της σειράς:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Προσθέστε ένα διάγραμμα φυσαλίδων στη ζητούμενη διαφάνεια.
1. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή γραμμής σφάλματος X.
1. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή γραμμής σφάλματος Y.
1. Προσπελάστε τα μεμονωμένα σημεία δεδομένων της σειράς διαγράμματος και ορίστε τις τιμές της γραμμής σφάλματος για το μεμονωμένο σημείο.
1. Ορισμός τιμών και μορφοποίησης των γραμμών.
1. Γράψτε την τροποποιημένη παρουσίαση σε ένα αρχείο PPTX.

```php
  # Δημιουργία ενός στιγμιοτύπου της κλάσης Presentation
  $pres = new Presentation();
  try {
    # Δημιουργία ενός διαγράμματος φυσαλίδων
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Προσθήκη προσαρμοσμένων γραμμών σφάλματος και ρύθμιση της μορφής τους
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Πρόσβαση σε σημείο δεδομένων σειράς διαγράμματος και ορισμός τιμών γραμμών σφάλματος για
    # μεμονωμένο σημείο
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Ορισμός γραμμών σφάλματος για τα σημεία σειράς διαγράμματος
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Αποθήκευση παρουσίασης
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ΣΑΡΑΤΑΡΙΑ**

**Τι συμβαίνει με τις γραμμές σφάλματος όταν εξάγετε μια παρουσίαση σε PDF ή εικόνες;**

Αποτυπώνονται ως μέρος του διαγράμματος και διατηρούνται κατά τη μετατροπή μαζί με την υπόλοιπη μορφοποίηση του διαγράμματος, εφόσον χρησιμοποιείται συμβατή έκδοση ή μηχανή απόδοσης.

**Μπορούν οι γραμμές σφάλματος να συνδυαστούν με σημεία σήμανσης και ετικέτες δεδομένων;**

Ναι. Οι γραμμές σφάλματος είναι ξεχωριστό στοιχείο και είναι συμβατές με σημεία σήμανσης και ετικέτες δεδομένων· εάν τα στοιχεία επικαλύπτονται, ίσως χρειαστεί να προσαρμόσετε τη μορφοποίηση.

**Πού μπορώ να βρω τη λίστα των ιδιοτήτων και των κλάσεων για εργασία με γραμμές σφάλματος στο API;**

Στην αναφορά API: η κλάση [ErrorBarsFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/errorbarsformat/) και οι σχετικές κλάσεις [ErrorBarType](https://reference.aspose.com/slides/el/php-java/aspose.slides/errorbartype/) και [ErrorBarValueType](https://reference.aspose.com/slides/el/php-java/aspose.slides/errorbarvaluetype/).