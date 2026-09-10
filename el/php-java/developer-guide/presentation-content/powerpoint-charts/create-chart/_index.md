---
title: Δημιουργία ή Ενημέρωση Διαγραμμάτων Παρουσίασης PowerPoint σε PHP
linktitle: Δημιουργία ή Ενημέρωση Διαγραμμάτων
type: docs
weight: 10
url: /el/php-java/create-chart/
keywords:
- προσθήκη διαγράμματος
- δημιουργία διαγράμματος
- επεξεργασία διαγράμματος
- αλλαγή διαγράμματος
- ενημέρωση διαγράμματος
- διασπορικό διάγραμμα
- διάγραμμα πίτας
- γραμμικό διάγραμμα
- διάγραμμα χάρτη δέντρου
- χρηματιστηριακό διάγραμμα
- διάγραμμα box-and-whisker
- διάγραμμα χωνιού
- διάγραμμα sunburst
- διάγραμμα ιστογράμματος
- διάγραμμα ραντάρ
- διάγραμμα πολλαπλών κατηγοριών
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργία και προσαρμογή διαγραμμάτων σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Προσθήκη, μορφοποίηση και επεξεργασία διαγραμμάτων με πρακτικά παραδείγματα κώδικα."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργήσετε και να προσαρμόσετε διαγράμματα χρησιμοποιώντας το Aspose.Slides. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει με τις συγκεκριμένες απαιτήσεις σχεδίασής σας. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα δείχνουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου διαγράμματος έως τη ρύθμιση σειρών, αξόνων και υπομνήματος. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε στέρεη κατανόηση του πώς να ενσωματώσετε δυναμική δημιουργία διαγραμμάτων στις εφαρμογές σας, βελτιστοποιώντας τη διαδικασία δημιουργίας παρουσιάσεων βασισμένων σε δεδομένα.

## **Δημιουργία Διαγράμματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα τα δεδομένα και να αποκτούν διορατικότητα που μπορεί να μην είναι άμεσα προφανής από έναν πίνακα ή ένα λογιστικό φύλλο.

**Γιατί να δημιουργήσετε διαγράμματα;**

* συγκεντρώνετε, συμπιέζετε ή συνοψίζετε μεγάλες ποσότητες δεδομένων σε μία ενιαία διαφάνεια σε μια παρουσίαση
* εμφανίζετε μοτίβα και τάσεις στα δεδομένα
* συμπεραίνετε την κατεύθυνση και την ορμή των δεδομένων με την πάροδο του χρόνου ή σε σχέση με μια συγκεκριμένη μονάδα μέτρησης
* εντοπίζετε ακραίες τιμές, αποκλίσεις, σφάλματα, ασυνεπή δεδομένα κ.λπ.
* επικοινωνείτε ή παρουσιάζετε πολύπλοκα δεδομένα

Στο PowerPoint, μπορείτε να δημιουργήσετε διαγράμματα μέσω της *Insert* λειτουργίας, η οποία παρέχει πρότυπα για το σχεδιασμό πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο κανονικά διαγράμματα (βασισμένα σε δημοφιλείς τύπους) όσο και προσαρμοσμένα διαγράμματα.

{{% alert color="info" title="Note" %}}
Για τη δημιουργία διαγραμμάτων, χρησιμοποιήστε την κλάση [ChartType](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/). Τα πεδία σε αυτήν την κλάση αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.
{{% /alert %}}

### **Δημιουργία Συγκεντρωτικών Στήλης Διαγράμματος**

Αυτή η ενότητα εξηγεί πώς να δημιουργήσετε συγκεντρωτικά διαγράμματα στήλης χρησιμοποιώντας το Aspose.Slides. Θα μάθετε να αρχικοποιείτε μια παρουσίαση, να προσθέτετε ένα διάγραμμα και να προσαρμόζετε τα στοιχεία του, όπως τίτλο, δεδομένα, σειρές, κατηγορίες και στυλ. Ακολουθήστε τα παρακάτω βήματα για να δείτε πώς δημιουργείται ένα τυπικό συγκεντρωτικό διάγραμμα στήλης:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
1. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον τύπο `ChartType::ClusteredColumn`.
1. Προσθέστε έναν τίτλο στο διάγραμμα.
1. Προσπελάστε το φύλλο εργασίας δεδομένων του διαγράμματος.
1. Καθαρίστε όλες τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
1. Εφαρμόστε χρώμα γεμίσματος στις σειρές του διαγράμματος.
1. Προσθέστε ετικέτες στις σειρές του διαγράμματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  # Δημιουργεί ένα αντικείμενο παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθήκη διαγράμματος με τα προεπιλεγμένα δεδομένα του
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Ορίζει τον τίτλο του διαγράμματος
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Ορίζει τη πρώτη σειρά να εμφανίζει τιμές
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Ορίζει το ευρετήριο για το φύλλο δεδομένων του διαγράμματος
    $defaultWorksheetIndex = 0;
    # Ανάκτηση του φύλλου εργασίας δεδομένων του διαγράμματος
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Διαγραφή των προεπιλεγμένων σειρών και κατηγοριών που δημιουργήθηκαν
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Προσθήκη νέων σειρών
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Προσθήκη νέων κατηγοριών
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Λήψη της πρώτης σειράς του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Τώρα γεμίζει τα δεδομένα της σειράς
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Ορίζει το χρώμα γεμίσματος για τη σειρά
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Λήψη της δεύτερης σειράς του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Γεμίζει τα δεδομένα της σειράς
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Ορίζει το χρώμα γεμίσματος για τη σειρά
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Δημιουργία προσαρμοσμένων ετικετών για κάθε κατηγορία της νέας σειράς
    # Ορίζει την πρώτη ετικέτα να εμφανίζει το όνομα της κατηγορίας
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Εμφανίζει τιμή για την τρίτη ετικέτα
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Αποθηκεύει την παρουσίαση με το διάγραμμα
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Διασπορικών Διαγραμμάτων**

Τα διασπορικά διαγράμματα (γνωστά επίσης ως scatter plots ή x‑y γραφήματα) χρησιμοποιούνται συχνά για να ελέγξουν μοτίβα ή να αφηγηθούν συσχετίσεις μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε ένα διασπορικό διάγραμμα όταν:

* διαθέτετε αριθμητικά ζευγαρωμένα δεδομένα
* διαθέτετε δύο μεταβλητές που ταιριάζουν καλά μεταξύ τους
* θέλετε να καθορίσετε εάν δύο μεταβλητές σχετίζονται
* έχετε μια ανεξάρτητη μεταβλητή που έχει πολλές τιμές για μια εξαρτημένη μεταβλητή

1. Ακολουθήστε τα βήματα στο [Create Clustered Column Charts](#create-clustered-column-charts).
2. Για το τρίτο βήμα, προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον τύπο διαγράμματος ως έναν από τους παρακάτω:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Αντιπροσωπεύει ένα διασπορικό διάγραμμα._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Αντιπροσωπεύει ένα διασπορικό διάγραμμα συνδεδεμένο με καμπύλες, με σημεία δεδομένων._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Αντιπροσωπεύει ένα διασπορικό διάγραμμα συνδεδεμένο με καμπύλες, χωρίς σημεία δεδομένων._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Αντιπροσωπεύει ένα διασπορικό διάγραμμα συνδεδεμένο με ευθείες γραμμές, με σημεία δεδομένων._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Αντιπροσωπεύει ένα διασπορικό διάγραμμα συνδεδεμένο με ευθείες γραμμές, χωρίς σημεία δεδομένων._

```php
  # Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Δημιουργεί το προεπιλεγμένο διάγραμμα
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Λαμβάνει το ευρετήριο του προεπιλεγμένου φύλλου δεδομένων του διαγράμματος
    $defaultWorksheetIndex = 0;
    # Λαμβάνει το φύλλο δεδομένων του διαγράμματος
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Διαγράφει τις σειρές demo
    $chart->getChartData()->getSeries()->clear();
    # Προσθέτει νέες σειρές
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Παίρνει την πρώτη σειρά του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Προσθέτει νέο σημείο (1:3) στη σειρά
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Προσθέτει νέο σημείο (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Αλλαγή τύπου σειράς
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Αλλάζει το σύμβολο σημεία της σειράς διαγράμματος
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Παίρνει τη δεύτερη σειρά του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Προσθέτει νέο σημείο (5:2) εκεί
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Προσθέτει νέο σημείο (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Προσθέτει νέο σημείο (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Προσθέτει νέο σημείο (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Αλλάζει το σύμβολο σημεία της σειράς διαγράμματος
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Πίτας Διαγραμμάτων**

Τα πίτα διαγράμματα είναι ιδανικά για την εμφάνιση της σχέσης μέρος‑προς‑ολόκληρο στα δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγοριοποιημένες ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιλαμβάνουν πολλά μέρη ή ετικέτες, ίσως θελήσετε να χρησιμοποιήσετε ένα ραβδογράφημα αντ’ αυτού.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType::Pie](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#Pie).
4. Προσπελάστε το βιβλίο εργασίας δεδομένων του διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/).
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
8. Προσθέστε νέα σημεία στο διάγραμμα και εφαρμόστε προσαρμοσμένα χρώματα για τους τομείς του πίτα διαγράμματος.
9. Ορίστε ετικέτες για τις σειρές.
10. Ενεργοποιήστε τις γραμμές οδηγούς για τις ετικέτες των σειρών.
11. Ορίστε τη γωνία περιστροφής για τους τομείς του πίτα διαγράμματος.
12. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  # Δημιουργεί μια κλάση παρουσίασης που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slides = $pres->getSlides()->get_Item(0);
    # Προσθέτει ένα διάγραμμα με προεπιλεγμένα δεδομένα
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Ορίζει τον τίτλο του διαγράμματος
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Ορίζει την πρώτη σειρά να εμφανίζει τιμές
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Ορίζει το ευρετήριο για το φύλλο δεδομένων του διαγράμματος
    $defaultWorksheetIndex = 0;
    # Λαμβάνει το φύλλο εργασίας δεδομένων του διαγράμματος
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Διαγράφει τις προεπιλεγμένες δημιουργημένες σειρές και κατηγορίες
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Προσθέτει νέες κατηγορίες
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Προσθέτει νέες σειρές
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Γεμίζει τα δεδομένα της σειράς
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Δεν λειτουργεί στη νέα έκδοση
    # Προσθήκη νέων σημείων και ορισμός χρώματος τομέα
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Ορίζει το περίγραμμα του τομέα
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Ορίζει το περίγραμμα του τομέα
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Ορίζει το περίγραμμα του τομέα
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Δημιουργεί προσαρμοσμένες ετικέτες για κάθε κατηγορία στη νέα σειρά
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # Εμφανίζει γραμμές οδηγούς για το διάγραμμα
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Ορίζει τη γωνία περιστροφής για τους τομείς του διαγράμματος πίτας
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Αποθηκεύει την παρουσίαση με ένα διάγραμμα
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Γραμμικών Διαγραμμάτων**

Τα γραμμικά διαγράμματα (γνωστά επίσης ως line graphs) είναι ιδανικά σε καταστάσεις όπου θέλετε να δείξετε αλλαγές στην τιμή με την πάροδο του χρόνου. Με ένα γραμμικό διάγραμμα, μπορείτε να συγκρίνετε μεγάλο όγκο δεδομένων ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις, να επισημαίνετε ανωμαλίες σε σειρές δεδομένων και πολλά άλλα.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType::Line](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#Line).
1. Προσπελάστε το βιβλίο εργασίας δεδομένων του διαγράμματος ([ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/)).
1. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
1. Προσθέστε νέες σειρές και κατηγορίες.
1. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Από προεπιλογή, τα σημεία σε ένα γραμμικό διάγραμμα ενώνονται με συνεχείς ευθείες γραμμές. Εάν θέλετε τα σημεία να ενωθούν με παύλες, μπορείτε να ορίσετε τον προτιμώμενο τύπο παύλας ως εξής:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Διαγραμμάτων Tree Map**

Τα διαγράμματα Tree Map είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών δεδομένων και να εστιάσετε γρήγορα σε στοιχεία που αποτελούν μεγάλους συνεισφέρωντες σε κάθε κατηγορία.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType::Treemap](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#Treemap).
4. Προσπελάστε το βιβλίο εργασίας δεδομένων του διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/).
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # κλαδί 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # κλαδί 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Χρηματιστηριακών Διαγραμμάτων**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#OpenHighLowClose).
4. Προσπελάστε το βιβλίο εργασίας δεδομένων του διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/).
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
8. Καθορίστε τη μορφή των γραμμών υψηλού‑χαμηλού.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Διαγραμμάτων Box and Whisker**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#BoxAndWhisker).
4. Προσπελάστε το βιβλίο εργασίας δεδομένων του διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/).
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Διαγράμματος Funnel**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType::Funnel](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#Funnel).
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Διαγραμμάτων Sunburst**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType::Sunburst](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#Sunburst).
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # κλαδί 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # κλαδί 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Ιστογραμμάτων**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType::Histogram](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#Histogram).
4. Προσπελάστε το βιβλίο εργασίας δεδομένων του διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/).
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **Δημιουργία Διαγραμμάτων Radar**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και καθορίστε τον προτιμώμενο τύπο διαγράμματος ([ChartType::Radar](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#Radar) σε αυτήν την περίπτωση).
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Διαγραμμάτων Πολλαπλών Κατηγοριών**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και καθορίστε τον τύπο [ChartType::ClusteredColumn](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#ClusteredColumn).
4. Προσπελάστε το βιβλίο εργασίας δεδομένων του διαγράμματος [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/).
5. Καθαρίστε τις προεπιλεγμένες σειρές και κατηγορίες.
6. Προσθέστε νέες σειρές και κατηγορίες.
7. Προσθέστε νέα δεδομένα διαγράμματος για τις σειρές του διαγράμματος.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # Προσθήκη Σειρών
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Αποθήκευση παρουσίασης με διάγραμμα
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Διαγραμμάτων Χάρτη**

Τα διαγράμματα χάρτη οπτικοποιούν γεωγραφικά δεδομένα και βοηθούν στη σύγκριση τιμών μεταξύ περιοχών.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Συνδυαστικών Διαγραμμάτων**

Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγραμμάτων σε ένα μόνο γράφημα. Αυτό το διάγραμμα σας επιτρέπει να τονίσετε, να συγκρίνετε ή να εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας σας να εντοπίσετε σχέσεις μεταξύ τους.

![Το συνδυαστικό διάγραμμα](combination_chart.png)

Ο παρακάτω κώδικας PHP δείχνει πώς να δημιουργήσετε το συνδυαστικό διάγραμμα που φαίνεται παραπάνω σε μια παρουσίαση PowerPoint:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Ορίστε τον τίτλο του διαγράμματος.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Ορίστε το υπόμνημα του διαγράμματος.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Διαγράψτε τις προεπιλεγμένες δημιουργημένες σειρές και κατηγορίες.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Προσθέστε νέες κατηγορίες.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Προσθέστε την πρώτη σειρά.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // Ορίστε τον οριζόντιο άξονα.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Ορίστε τον κάθετο άξονα.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Ορίστε το χρώμα των κύριων γραμμών πλέγματος του κάθετου άξονα.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Ορίστε τον δευτερεύοντα οριζόντιο άξονα.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Ορίστε τον δευτερεύοντα κάθετο άξονα.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **Ενημέρωση Διαγραμμάτων**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα που θέλετε να ενημερώσετε.
2. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.
4. Προσπελάστε το φύλλο εργασίας δεδομένων του διαγράμματος.
5. Τροποποιήστε τις σειρές δεδομένων του διαγράμματος αλλάζοντας τις τιμές των σειρών.
6. Προσθέστε μια νέα σειρά και γεμίστε τα δεδομένα της.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Λήψη διαγράμματος με προεπιλεγμένα δεδομένα
    $chart = $sld->getShapes()->get_Item(0);
    # Ορισμός του ευρετηρίου του φύλλου δεδομένων του διαγράμματος
    $defaultWorksheetIndex = 0;
    # Λήψη του φύλλου δεδομένων του διαγράμματος
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Αλλαγή ονόματος κατηγορίας του διαγράμματος
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Λήψη της πρώτης σειράς του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Τώρα ενημερώνονται τα δεδομένα της σειράς
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Τροποποίηση ονόματος σειράς

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Λήψη της δεύτερης σειράς του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Τώρα ενημερώνονται τα δεδομένα της σειράς
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Τροποποίηση ονόματος σειράς

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Τώρα, προσθήκη νέας σειράς
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Λήψη της 3ης σειράς του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Τώρα γεμίζονται τα δεδομένα της σειράς
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Αποθήκευση παρουσίασης με διάγραμμα
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ορισμός Περιοχής Δεδομένων για Διάγραμμα**

Για να ορίσετε την περιοχή δεδομένων για ένα διάγραμμα, κάντε τα εξής:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα.
2. Αποκτήστε μια αναφορά σε μια διαφάνεια χρησιμοποιώντας το ευρετήριο της.
3. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.
4. Προσπελάστε τα δεδομένα του διαγράμματος και ορίστε την περιοχή.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Χρήση Προεπιλεγμένων Σημαδιών σε Διαγράμματα**

Όταν χρησιμοποιείτε προεπιλεγμένα σύμβολα σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει αυτόματα διαφορετικό σύμβολο σημείου.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # Λήψη της δεύτερης σειράς του διαγράμματος
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Τώρα γεμίζοντας τα δεδομένα της σειράς
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Ποιοι τύποι διαγραμμάτων υποστηρίζονται από το Aspose.Slides;**

Το Aspose.Slides υποστηρίζει μια ευρεία γκάμα [chart types](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/), συμπεριλαμβανομένων bar, line, pie, area, scatter, histogram, radar και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο διαγράμματος για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς μπορώ να προσθέσω ένα νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε ένα διάγραμμα, πρώτα δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/), ανακτήστε τη ζητούμενη διαφάνεια χρησιμοποιώντας το ευρετήριο της και, στη συνέχεια, καλέστε τη μέθοδο για προσθήκη διαγράμματος, καθορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος προσπερνώντας το βιβλίο εργασίας δεδομένων του ([ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/)), καθαρίζοντας τις προεπιλεγμένες σειρές και κατηγορίες και προσθέτοντας τα προσαρμοσμένα σας δεδομένα. Αυτό σάς επιτρέπει να ανανεώσετε το διάγραμμα ώστε να αντανακλά τα πιο πρόσφατα δεδομένα.

**Μπορεί να προσαρμοστεί η εμφάνιση του διαγράμματος;**

Ναι, το Aspose.Slides παρέχει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα [formatting elements](/slides/el/php-java/chart-entities/) ώστε να προσαρμόσετε την εμφάνιση του διαγράμματος στις συγκεκριμένες απαιτήσεις σχεδίας σας.