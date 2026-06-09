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
- διασκορπισμένο διάγραμμα
- διάγραμμα πίτας
- γραμμικό διάγραμμα
- διάγραμμα χάρτη δέντρου
- διάγραμμα μετοχών
- διάγραμμα κουτιού και σαλαπιού
- διάγραμμα χωνίου
- διάγραμμα ηλιακού κύκλου
- ιστόγραμμα
- διάγραμμα ραντάρ
- πολυκατηγορικό διάγραμμα
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργία και προσαρμογή διαγραμμάτων σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java. Προσθήκη, μορφοποίηση και επεξεργασία διαγραμμάτων με πρακτικά παραδείγματα κώδικα."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργήσετε και να προσαρμόσετε διαγράμματα χρησιμοποιώντας το Aspose.Slides. Θα μάθετε πώς να προσθέσετε προγραμματιστικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίσετε με δεδομένα και να εφαρμόσετε διάφορες επιλογές μορφοποίησης ώστε να ταιριάζει με τις συγκεκριμένες απαιτήσεις του σχεδίου σας. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα δείχνουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου διαγράμματος μέχρι τη διαμόρφωση σειρών, αξόνων και υπομνήματος. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε μια σταθερή κατανόηση του πώς να ενσωματώσετε τη δυναμική δημιουργία διαγραμμάτων στις εφαρμογές σας, απλοποιώντας τη διαδικασία δημιουργίας παρουσιάσεων βασισμένων σε δεδομένα.

## **Δημιουργία Διαγράμματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα δεδομένα και να εξάγουν συμπεράσματα, κάτι που μπορεί να μην είναι άμεσα εμφανές από έναν πίνακα ή ένα υπολογιστικό φύλλο.

**Γιατί να δημιουργούμε διαγράμματα;**

Χρησιμοποιώντας διαγράμματα, μπορείτε να:

* συγκεντρώσετε, συμπιέσετε ή συνοψίσετε μεγάλες ποσότητες δεδομένων σε μια μόνο διαφάνειά μιας παρουσίασης
* αποκαλύψετε πρότυπα και τάσεις στα δεδομένα
* εξακριβώσετε την κατεύθυνση και το ρυθμό των δεδομένων με την πάροδο του χρόνου ή σε σχέση με μια συγκεκριμένη μονάδα μέτρησης
* εντοπίσετε ακραίες τιμές, αποκλίσεις, σφάλματα, μη λογικά δεδομένα κ.λπ.
* επικοινωνήσετε ή παρουσιάσετε πολύπλοκα δεδομένα

Στο PowerPoint, μπορείτε να δημιουργήσετε διαγράμματα μέσω της λειτουργίας εισαγωγής, η οποία παρέχει πρότυπα για το σχεδιασμό πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε κανονικά διαγράμματα (βασισμένα σε δημοφιλείς τύπους διαγραμμάτων) και προσαρμοσμένα διαγράμματα.

{{% alert color="primary" %}} 

Για να δημιουργήσετε διαγράμματα, το Aspose.Slides παρέχει την κλάση [ChartType](https://reference.aspose.com/slides/el/php-java/aspose.slides/ChartType). Τα πεδία αυτής της κλάσης αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.

{{% /alert %}} 

### **Δημιουργία Κανονικών Διαγραμμάτων**

_Βήματα: Δημιουργία Διαγράμματος_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Βήματα:</em> Δημιουργία Διαγράμματος PowerPoint </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Βήματα:</em> Δημιουργία Διαγράμματος Παρουσίασης </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Βήματα:</em> Δημιουργία Διαγράμματος PowerPoint Παρουσίασης </strong></a>

_Κώδικας Βημάτων:_

1. Δημιουργήστε ένα αντιτύπωμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον προτιμώμενο τύπο διαγράμματος. 
4. Προσθέστε έναν τίτλο για το διάγραμμα. 
5. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος. 
6. Εκκαθάριση όλων των προεπιλεγμένων σειρών και κατηγοριών. 
7. Προσθήκη νέων σειρών και κατηγοριών. 
8. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές του διαγράμματος. 
9. Προσθήκη χρώματος γεμίσματος για τις σειρές του διαγράμματος. 
10. Προσθήκη ετικετών για τις σειρές του διαγράμματος. 
11. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα κανονικό διάγραμμα:

```php
  # Δημιουργεί αντικείμενο παρουσίασης που αντιπροσωπεύει αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθέτει διάγραμμα με τα προεπιλεγμένα του δεδομένα
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Ορίζει τον τίτλο του διαγράμματος
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Ορίζει την πρώτη σειρά να εμφανίζει τιμές
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Ορίζει τον δείκτη για το φύλλο δεδομένων του διαγράμματος
    $defaultWorksheetIndex = 0;
    # Αποκτά το φύλλο εργασίας δεδομένων του διαγράμματος
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Διαγράφει τις προεπιλεγμένες παραγόμενες σειρές και κατηγορίες
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Προσθέτει νέες σειρές
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Προσθέτει νέες κατηγορίες
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Παίρνει την πρώτη σειρά του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Τώρα γεμίζει τα δεδομένα της σειράς
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Ορίζει το χρώμα γεμίσματος για τη σειρά
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Παίρνει τη δεύτερη σειρά του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Γεμίζει τα δεδομένα της σειράς
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Ορίζει το χρώμα γεμίσματος για τη σειρά
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Δημιουργεί προσαρμοσμένες ετικέτες για κάθε κατηγορία της νέας σειράς
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

### **Δημιουργία Διαγραμμάτων Σκαρδάλισματος**
Τα διαγράμματα σκαρδάλισματος (γνωστά επίσης ως scatter plots ή διαγράμματα x-y) χρησιμοποιούνται συχνά για να ελέγξουν πρότυπα ή να δείξουν συσχετίσεις μεταξύ δύο μεταβλητών.

Μπορεί να θέλετε να χρησιμοποιήσετε διάγραμμα σκαρδάλισματος όταν

* έχετε ζευγάρια αριθμητικών δεδομένων
* έχετε 2 μεταβλητές που ταιριάζουν καλά μεταξύ τους
* θέλετε να διαπιστώσετε εάν 2 μεταβλητές είναι σχετικές
* έχετε μια ανεξάρτητη μεταβλητή με πολλαπλές τιμές για μια εξαρτημένη μεταβλητή

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Βήματα:</em> Δημιουργία Σκαρδάλισματος </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Βήματα:</em> Δημιουργία Σκαρδάλισματος PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Βήματα:</em> Δημιουργία Σκαρδάλισματος PowerPoint Παρουσίασης </strong></a>

1. Παρακαλούμε ακολουθήστε τα βήματα που περιγράφονται παραπάνω στα [Create Normal Charts](#creating-normal-charts)
2. Στο τρίτο βήμα, προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον τύπο διαγράμματος ως έναν από τους παρακάτω
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Αντιπροσωπεύει διάγραμμα σκαρδάλισματος με δείκτες._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Αντιπροσωπεύει διάγραμμα σκαρδάλισματος συνδεδεμένο με καμπύλες, με δείκτες δεδομένων._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Αντιπροσωπεύει διάγραμμα σκαρδάλισματος συνδεδεμένο με καμπύλες, χωρίς δείκτες δεδομένων._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Αντιπροσωπεύει διάγραμμα σκαρδάλισματος συνδεδεμένο με ευθείες γραμμές, με δείκτες δεδομένων._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Αντιπροσωπεύει διάγραμμα σκαρδάλισματος συνδεδεμένο με ευθείες γραμμές, χωρίς δείκτες δεδομένων._

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε σκαρδάλισμα με διαφορετικές σειρές δεικτών:

```php
  # Δημιουργεί αντικείμενο παρουσίασης που αντιπροσωπεύει αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Δημιουργεί το προεπιλεγμένο διάγραμμα
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Αποκτά τον δείκτη του προεπιλεγμένου φύλλου δεδομένων του διαγράμματος
    $defaultWorksheetIndex = 0;
    # Αποκτά το φύλλο δεδομένων του διαγράμματος
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Διαγράφει τις σειρές επίδειξης
    $chart->getChartData()->getSeries()->clear();
    # Προσθέτει νέες σειρές
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Πηγαίνει στην πρώτη σειρά του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Προσθέτει νέο σημείο (1:3) στη σειρά
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Προσθέτει νέο σημείο (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Αλλάζει τον τύπο της σειράς
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Αλλάζει το δείκτη (marker) της σειράς διαγράμματος
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Πηγαίνει στη δεύτερη σειρά του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Προσθέτει νέο σημείο (5:2) εκεί
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Προσθέτει νέο σημείο (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Προσθέτει νέο σημείο (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Προσθέτει νέο σημείο (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Αλλάζει το δείκτη (marker) της σειράς διαγράμματος
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Διάγραμμα Πίτας**

Τα διαγράμματα πίτας χρησιμοποιούνται καλύτερα για την εμφάνιση της σχέσης μέρος‑προς‑ολόκληρο σε δεδομένα, ειδικά όταν τα δεδομένα περιέχουν κατηγορικές ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιέχουν πολλά τμήματα ή ετικέτες, ίσως θελήσετε να χρησιμοποιήσετε ένα διάγραμμα ράβδων αντί γι’ αυτό.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Βήματα:</em> Δημιουργία Διαγράμματος Πίτας </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Βήματα:</em> Δημιουργία Διαγράμματος Πίτας PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Βήματα:</em> Δημιουργία Διαγράμματος Πίτας PowerPoint Παρουσίασης </strong></a>

1. Δημιουργήστε ένα αντιτύπωμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο (σε αυτή την περίπτωση, [ChartType](https://reference.aspose.com/slides/el/php-java/aspose.slides/ChartType).Pie).
4. Πρόσβαση στο [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/).
5. Εκκαθάριση των προεπιλεγμένων σειρών και κατηγοριών.
6. Προσθήκη νέων σειρών και κατηγοριών.
7. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές του διαγράμματος.
8. Προσθήκη νέων σημείων για τα διαγράμματα και προσαρμοσμένων χρωμάτων για τα τμήματα του διαγράμματος πίτας.
9. Ορισμός ετικετών για τις σειρές.
10. Ορισμός γραμμών οδηγού για τις ετικέτες των σειρών.
11. Ορισμός γωνίας περιστροφής για τις διαφάνειες του διαγράμματος πίτας.
12. Αποθήκευση της τροποποιημένης παρουσίασης σε αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα διάγραμμα πίτας:

```php
  # Δημιουργεί αντικείμενο κλάσης παρουσίασης που αντιπροσωπεύει αρχείο PPTX
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slides = $pres->getSlides()->get_Item(0);
    # Προσθέτει διάγραμμα με προεπιλεγμένα δεδομένα
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Ορίζει τον τίτλο του διαγράμματος
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Ορίζει την πρώτη σειρά να εμφανίζει τιμές
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Ορίζει τον δείκτη για το φύλλο δεδομένων του διαγράμματος
    $defaultWorksheetIndex = 0;
    # Αποκτά το φύλλο εργασίας δεδομένων του διαγράμματος
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Διαγράφει τις προεπιλεγμένες παραγόμενες σειρές και κατηγορίες
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Προσθέτει νέες κατηγορίες
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Προσθέτει νέες σειρές
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Συμπληρώνει τα δεδομένα της σειράς
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
    # Δημιουργεί προσαρμοσμένες ετικέτες για κάθε κατηγορία της νέας σειράς
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
    # Εμφανίζει γραμμές οδηγού για το διάγραμμα
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Ορίζει τη γωνία περιστροφής για τους τομείς του διαγράμματος πίτας
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Αποθηκεύει την παρουσίαση με το διάγραμμα
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Δημιουργία Γραμμικών Διαγραμμάτων**

Τα γραμμικά διαγράμματα (επίσης γνωστά ως γραμμικά γραφήματα) χρησιμοποιούνται καλύτερα σε περιπτώσεις όπου θέλετε να παρουσιάσετε αλλαγές τιμής με τον χρόνο. Με ένα γραμμικό διάγραμμα, μπορείτε να συγκρίνετε πολλά δεδομένα ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις με την πάροδο του χρόνου, να επισημάνετε ανωμαλίες σε σειρές δεδομένων κ.λπ.

1. Δημιουργήστε ένα αντιτύπωμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο (σε αυτή την περίπτωση, `ChartType::Line`).
1. Πρόσβαση στο IChartDataWorkbook του διαγράμματος.
1. Εκκαθάριση των προεπιλεγμένων σειρών και κατηγοριών.
1. Προσθήκη νέων σειρών και κατηγοριών.
1. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές του διαγράμματος.
1. Αποθήκευση της τροποποιημένης παρουσίασης σε αρχείο PPTX

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα γραμμικό διάγραμμα:

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

Από προεπιλογή, τα σημεία σε ένα γραμμικό διάγραμμα ενώνουνται με ευθείες συνεχείς γραμμές. Αν θέλετε τα σημεία να ενώνουνται με παύλες, μπορείτε να ορίσετε τον προτιμώμενο τύπο παύλας ως εξής:

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **Δημιουργία Διαγραμμάτων Δέντρου (Tree Map)**

Τα διαγράμματα tree map χρησιμοποιούνται καλύτερα για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών δεδομένων και (ταυτόχρονα) να τραβήξετε γρήγορα την προσοχή σε στοιχεία που συνεισφέρουν σημαντικά σε κάθε κατηγορία.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Βήματα:</em> Δημιουργία Tree Map </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Βήματα:</em> Δημιουργία Tree Map PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Βήματα:</em> Δημιουργία Tree Map PowerPoint Παρουσίασης </strong></a>

1. Δημιουργήστε ένα αντιτύπωμα της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο (σε αυτή την περίπτωση, [ChartType](https://reference.aspose.com/slides/el/php-java/aspose.slides/ChartType).TreeMap).
4. Πρόσβαση στο [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/).
5. Εκκαθάριση των προεπιλεγμένων σειρών και κατηγοριών.
6. Προσθήκη νέων σειρών και κατηγοριών.
7. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές του διαγράμματος.
8. Αποθήκευση της τροποποιημένης παρουσίασης σε αρχείο PPTX

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα tree map διάγραμμα:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # κλάδος 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # κλάδος 2
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

### **Δημιουργία Διάγραμμα Απόθεσης (Stock Chart)**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Βήματα:</em> Δημιουργία Stock Chart </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Βήματα:</em> Δημιουργία Stock Chart PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Βήματα:</em> Δημιουργία Stock Chart PowerPoint Παρουσίασης </strong></a>

1. Δημιουργήστε ένα αντιτύπωμα της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο ([ChartType](https://reference.aspose.com/slides/el/php-java/aspose.slides/ChartType).OpenHighLowClose).
4. Πρόσβαση στο [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/).
5. Εκκαθάριση των προεπιλεγμένων σειρών και κατηγοριών.
6. Προσθήκη νέων σειρών και κατηγοριών.
7. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές του διαγράμματος.
8. Προσδιορισμός μορφής HiLowLines.
9. Αποθήκευση της τροποποιημένης παρουσίασης σε αρχείο PPTX

Δείγμα κώδικα PHP για τη δημιουργία stock chart:

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
    foreach($chart->getChartData()->getSeries() as $ser) {
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

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Βήματα:</em> Δημιουργία Box and Whisker Chart </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Βήματα:</em> Δημιουργία Box and Whisker Chart PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Βήματα:</em> Δημιουργία Box and Whisker Chart PowerPoint Παρουσίασης </strong></a>

1. Δημιουργήστε ένα αντιτύπωμα της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο ([ChartType](https://reference.aspose.com/slides/el/php-java/aspose.slides/ChartType).BoxAndWhisker).
4. Πρόσβαση στο [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/).
5. Εκκαθάριση των προεπιλεγμένων σειρών και κατηγοριών.
6. Προσθήκη νέων σειρών και κατηγοριών.
7. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές του διαγράμματος.
8. Αποθήκευση της τροποποιημένης παρουσίασης σε αρχείο PPTX

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα διάγραμμα Box and Whisker:

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

### **Δημιουργία Διάγραμμα Χωνίου (Funnel Chart)**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Βήματα:</em> Δημιουργία Funnel Chart </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Βήματα:</em> Δημιουργία Funnel Chart PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Βήματα:</em> Δημιουργία Funnel Chart PowerPoint Παρουσίασης </strong></a>


1. Δημιουργήστε ένα αντιτύπωμα της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο ([ChartType](https://reference.aspose.com/slides/el/php-java/aspose.slides/ChartType).Funnel).
4. Αποθήκευση της τροποποιημένης παρουσίασης σε αρχείο PPTX

Ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα funnel chart:

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

### **Δημιουργία Διάγραμμα Ηλιακού Κύκλου (Sunburst Chart)**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Βήματα:</em> Δημιουργία Sunburst Chart </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Βήματα:</em> Δημιουργία Sunburst Chart PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Βήματα:</em> Δημιουργία Sunburst Chart PowerPoint Παρουσίασης </strong></a>

1. Δημιουργήστε ένα αντιτύπωμα της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο (σε αυτή την περίπτωση, [ChartType](https://reference.aspose.com/slides/el/php-java/aspose.slides/ChartType).sunburst).
4. Αποθήκευση της τροποποιημένης παρουσίασης σε αρχείο PPTX

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα sunburst chart:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # κλάδος 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # κλάδος 2
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

### **Δημιουργία Ιστογράμματος (Histogram Chart)**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Βήματα:</em> Δημιουργία Histogram Chart </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Βήματα:</em> Δημιουργία Histogram Chart PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Βήματα:</em> Δημιουργία Histogram Chart PowerPoint Παρουσίασης </strong></a>

1. Δημιουργήστε ένα αντιτύπωμα της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο ([ChartType](https://reference.aspose.com/slides/el/php-java/aspose.slides/ChartType).Histogram).
4. Πρόσβαση στο [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/).
5. Εκκαθάριση των προεπιλεγμένων σειρών και κατηγοριών.
6. Προσθήκη νέων σειρών και κατηγοριών.
7. Αποθήκευση της τροποποιημένης παρουσίασης σε αρχείο PPTX

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα histogram chart:

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

### **Δημιουργία Διάγραμμα Ραδίου (Radar Chart)**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Βήματα:</em> Δημιουργία Radar Chart </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Βήματα:</em> Δημιουργία Radar Chart PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Βήματα:</em> Δημιουργία Radar Chart PowerPoint Παρουσίασης </strong></a>

1. Δημιουργήστε ένα αντιτύπωμα της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα διάγραμμα με κάποια δεδομένα και ορίστε τον προτιμώμενο τύπο διαγράμματος (`ChartType::Radar` σε αυτή την περίπτωση).
4. Αποθήκευση της τροποποιημένης παρουσίασης σε αρχείο PPTX

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα radar chart:

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

### **Δημιουργία Πολυ‑Κατηγορικών Διαγραμμάτων (Multi‑Category Chart)**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Βήματα:</em> Δημιουργία Multi‑Category Chart </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Βήματα:</em> Δημιουργία Multi‑Category Chart PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Βήματα:</em> Δημιουργία Multi‑Category Chart PowerPoint Παρουσίασης </strong></a>

1. Δημιουργήστε ένα αντιτύπωμα της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) κλάσης.
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα μαζί με τον επιθυμητό τύπο ([ChartType](https://reference.aspose.com/slides/el/php-java/aspose.slides/ChartType).ClusteredColumn).
4. Πρόσβαση στο [ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/).
5. Εκκαθάριση των προεπιλεγμένων σειρών και κατηγοριών.
6. Προσθήκη νέων σειρών και κατηγοριών.
7. Προσθήκη νέων δεδομένων διαγράμματος για τις σειρές του διαγράμματος.
8. Αποθήκευση της τροποποιημένης παρουσίασης σε αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα multi‑category chart:

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

### **Δημιουργία Χαρτογραφικών Διαγραμμάτων (Map Chart)**

Ένα χάρτο‑διάγραμμα είναι η οπτικοποίηση μιας περιοχής που περιέχει δεδομένα. Τα χάρτο‑διαγράμματα χρησιμοποιούνται καλύτερα για σύγκριση δεδομένων ή τιμών μεταξύ γεωγραφικών περιοχών.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Βήματα:</em> Δημιουργία Map Chart </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Βήματα:</em> Δημιουργία Map Chart PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Βήματα:</em> Δημιουργία Map Chart PowerPoint Παρουσίασης </strong></a>

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα map chart:

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

### **Δημιουργία Συνδυαστικών Διαγραμμάτων (Combination Chart)**

Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγραμμάτων σε ένα ενιαίο γράφημα. Αυτό το διάγραμμα σας επιτρέπει να τονίσετε, να συγκρίνετε ή να εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας σας να εντοπίσετε σχέσεις μεταξύ τους.

![The combination chart](combination_chart.png)

Ο παρακάτω κώδικας PHP δείχνει πώς να δημιουργήσετε το συνδυαστικό διάγραμμα που παρουσιάζεται παραπάνω σε μια παρουσίαση PowerPoint:

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

    // Ορίζει τον τίτλο του διαγράμματος.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Ορίζει το υπόμνημα του διαγράμματος.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Διαγράφει τις προεπιλεγμένες δημιουργημένες σειρές και κατηγορίες.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Προσθέτει νέες κατηγορίες.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Προσθέτει την πρώτη σειρά.
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
    // Ορίζει τον οριζόντιο άξονα.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Ορίζει τον κατακόρυφο άξονα.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Ορίζει το χρώμα των κύριων γραμμών πλέγματος του κατακόρυφου άξονα.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Ορίζει τον δευτερεύοντα οριζόντιο άξονα.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Ορίζει τον δευτερεύοντα κατακόρυφο άξονα.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Βήματα:</em> Ενημέρωση PowerPoint Chart </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Βήματα:</em> Ενημέρωση Presentation Chart </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Βήματα:</em> Ενημέρωση PowerPoint Presentation Chart </strong></a>

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα που θέλετε να ενημερώσετε.
2. Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
3. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.
4. Πρόσβαση στο φύλλο δεδομένων του διαγράμματος.
5. Τροποποιήστε τα δεδομένα των σειρών του διαγράμματος αλλάζοντας τις τιμές των σειρών.
6. Προσθέστε μια νέα σειρά και γεμίστε την με δεδομένα.
7. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να ενημερώσετε ένα διάγραμμα:

```php
  $pres = new Presentation();
  try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Λήψη διαγράμματος με προεπιλεγμένα δεδομένα
    $chart = $sld->getShapes()->get_Item(0);
    # Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος
    $defaultWorksheetIndex = 0;
    # Λήψη του φύλλου εργασίας δεδομένων του διαγράμματος
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Αλλαγή του ονόματος κατηγορίας του διαγράμματος
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Λήψη της πρώτης σειράς του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Ενημέρωση δεδομένων σειράς
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Τροποποίηση ονόματος σειράς

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Λήψη της δεύτερης σειράς του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Ενημέρωση δεδομένων σειράς
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Τροποποίηση ονόματος σειράς

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Τώρα, προσθήκη νέας σειράς
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Λήψη της τρίτης σειράς του διαγράμματος
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Συμπλήρωση δεδομένων σειράς
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

## **Ορισμός Πεδίου Δεδομένων για Διάγραμμα**

Για να ορίσετε το πεδίο δεδομένων ενός διαγράμματος, κάντε τα εξής:

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation) που αντιπροσωπεύει την παρουσίαση που περιέχει το διάγραμμα.
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Περιηγηθείτε σε όλα τα σχήματα για να βρείτε το επιθυμητό διάγραμμα.
4. Πρόσβαση στα δεδομένα του διαγράμματος και ορίστε το πεδίο.
5. Αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε το πεδίο δεδομένων για ένα διάγραμμα:

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

## **Χρήση Προεπιλεγμένων Δεικτών σε Διαγράμματα**
Όταν χρησιμοποιείτε έναν προεπιλεγμένο δείκτη σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει αυτόματα διαφορετικό προεπιλεγμένο σύμβολο δείκτη.

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε αυτόματα έναν δείκτη σειράς διαγράμματος:

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
    # Τώρα συμπλήρωση δεδομένων της σειράς
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

## **Συχνές Ερωτήσεις (FAQ)**

**Ποιοι τύποι διαγραμμάτων υποστηρίζει το Aspose.Slides;**

Το Aspose.Slides υποστηρίζει μια ευρεία γκάμα [chart types](https://reference.aspose.com/slides/el/php-java/aspose.slides/charttype/), συμπεριλαμβανομένων bar, line, pie, area, scatter, histogram, radar και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο διαγράμματος για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς προσθέτω ένα νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε ένα διάγραμμα, πρώτα δημιουργήστε ένα αντιτύπωμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/)· ανακτήστε τη διαφάνεια που θέλετε μέσω του δείκτη της· έπειτα καλέστε τη μέθοδο για την προσθήκη διαγράμματος, ορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει απευθείας το διάγραμμα στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που εμφανίζονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος προσπελάζοντας το βιβλίο εργασίας δεδομένων του ([ChartDataWorkbook](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdataworkbook/)), εκκαθαρίζοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες, και προσθέτοντας τα προσαρμοσμένα σας δεδομένα. Έτσι μπορείτε να ανανεώσετε το διάγραμμα ώστε να αντικατοπτρίζει τα πιο πρόσφατα δεδομένα.

**Μπορώ να προσαρμόσω την εμφάνιση του διαγράμματος;**

Ναι, το Aspose.Slides παρέχει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπόμνημα και άλλα [formatting elements](/slides/el/php-java/chart-entities/) ώστε να προσαρμόσετε την εμφάνιση του διαγράμματος στις ειδικές σχεδιαστικές σας απαιτήσεις.