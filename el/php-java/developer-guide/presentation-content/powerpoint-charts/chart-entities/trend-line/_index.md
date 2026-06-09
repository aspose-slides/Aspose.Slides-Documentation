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
- γραμμή τάσης κυλιόμενου μέσου
- πολυωνυμική γραμμή τάσης
- γραμμή τάσης δύναμης
- προσαρμοσμένη γραμμή τάσης
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Προσθέστε και προσαρμόστε γρήγορα γραμμές τάσης σε διαγράμματα PowerPoint με το Aspose.Slides for PHP via Java — ένας πρακτικός οδηγός για να εντυπωσιάσετε το κοινό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης σε σειρές διαγράμματος και να εργαστείτε με διάφορους τύπους γραμμών τάσης, συμπεριλαμβανομένων των εκθετικών, γραμμικών, λογαριθμικών, κυλιόμενου μέσου, πολυωνυμικών και δύναμης.

Επίσης περιγράφει πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε διάγραμμα εισάγοντας ένα σχήμα γραμμής, και περιλαμβάνει μια σύντομη ενότητα FAQ σχετικά με τις τιμές προβολής της γραμμής τάσης «forward» και «backward» και εάν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG καθώς και κατά την απόδοση διαγραμμάτων ως εικόνες.

## **Προσθήκη Γραμμής Τάσης**
Aspose.Slides for PHP via Java provides a simple API for managing different chart Trend Lines:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα και έναν από τους επιθυμητούς τύπους (σε αυτό το παράδειγμα χρησιμοποιείται ChartType::ClusteredColumn).
4. Προσθήκη εκθετικής γραμμής τάσης για τη σειρά διαγράμματος 1.
5. Προσθήκη γραμμής τάσης γραμμικού τύπου για τη σειρά διαγράμματος 1.
6. Προσθήκη λογαριθμικής γραμμής τάσης για τη σειρά διαγράμματος 2.
7. Προσθήκη γραμμής τάσης κυλιόμενου μέσου για τη σειρά διαγράμματος 2.
8. Προσθήκη πολυωνυμικής γραμμής τάσης για τη σειρά διαγράμματος 3.
9. Προσθήκη γραμμής τάσης τύπου δύναμης για τη σειρά διαγράμματος 3.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Ο παρακάτω κώδικας χρησιμοποιείται για τη δημιουργία διαγράμματος με Γραμμές Τάσης.

```php
  # Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
  $pres = new Presentation();
  try {
    # Δημιουργία διαγράμματος δεσμευμένων στηλών
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Προσθήκη εκθετικής γραμμής τάσης για τη σειρά διαγράμματος 1
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Προσθήκη γραμμής τάσης γραμμική για τη σειρά διαγράμματος 1
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Προσθήκη λογαριθμικής γραμμής τάσης για τη σειρά διαγράμματος 2
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # Προσθήκη γραμμής τάσης κυλιόμενου μέσου για τη σειρά διαγράμματος 2
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # Προσθήκη πολυωνυμικής γραμμής τάσης για τη σειρά διαγράμματος 3
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Προσθήκη γραμμής τάσης δύναμης για τη σειρά διαγράμματος 3
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Αποθήκευση παρουσίασης
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη Προσαρμοσμένης Γραμμής**
Aspose.Slides for PHP via Java provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation)
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Δείκτη της
- Δημιουργήστε ένα νέο διάγραμμα χρησιμοποιώντας τη μέθοδο AddChart που εκτίθεται από το αντικείμενο Shapes
- Προσθέστε ένα AutoShape τύπου Γραμμής χρησιμοποιώντας τη μέθοδο AddAutoShape που εκτίθεται από το αντικείμενο Shapes
- Ορίστε το Χρώμα των γραμμών του σχήματος.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX

Ο παρακάτω κώδικας χρησιμοποιείται για τη δημιουργία διαγράμματος με Προσαρμοσμένες Γραμμές.

```php
  # Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Τι σημαίνουν οι όροι 'forward' και 'backward' για μια γραμμή τάσης;**

Αυτά είναι τα μήκη της γραμμής τάσης που προβλέπουν προς τα εμπρός/πίσω: για διαγράμματα διασποράς (XY) — σε μονάδες άξονα· για μη διαγράμματα διασποράς — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη αρνητικές τιμές.

**Θα διατηρείται η γραμμή τάσης κατά την εξαγωγή της παρουσίασης σε PDF ή SVG, ή κατά την απόδοση μιας διαφάνειας ως εικόνα;**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/el/php-java/render-a-slide-as-an-svg-image/) και αποδίδει τα διαγράμματα ως εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά τη διάρκεια αυτών των λειτουργιών. Διατίθεται επίσης μια μέθοδος για [εξαγωγή εικόνας του διαγράμματος](/slides/el/php-java/create-shape-thumbnails/).