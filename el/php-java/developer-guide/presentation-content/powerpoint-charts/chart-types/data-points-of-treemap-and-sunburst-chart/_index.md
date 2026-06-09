---
title: Προσαρμογή Σημείων Δεδομένων σε Διαγράμματα Treemap και Sunburst χρησιμοποιώντας PHP
linktitle: Σημεία Δεδομένων σε Διαγράμματα Treemap και Sunburst
type: docs
url: /el/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- διάγραμμα Treemap
- διάγραμμα Sunburst
- σημείο δεδομένων
- χρώμα ετικέτας
- χρώμα κλαδίου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σημεία δεδομένων σε διαγράμματα Treemap και Sunburst με το Aspose.Slides για PHP μέσω Java, συμβατό με μορφές PowerPoint."
---
## **Εισαγωγή**

Μεταξύ άλλων τύπων διαγραμμάτων PowerPoint, υπάρχουν δύο «ιεραρχικοί» τύποι – **Treemap** και **Sunburst** διάγραμμα (επίσης γνωστά ως Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph ή Multi Level Pie Chart). Αυτά τα διαγράμματα εμφανίζουν ιεραρχικά δεδομένα οργανωμένα ως δέντρο – από τα φύλλα μέχρι την κορυφή του κλαδιού. Τα φύλλα ορίζονται από τα σημεία δεδομένων της σειράς, και κάθε επακόλουθο ενσωματωμένο επίπεδο ομαδοποίησης ορίζεται από την αντίστοιχη κατηγορία. Aspose.Slides για PHP μέσω Java επιτρέπει τη μορφοποίηση σημείων δεδομένων του διαγράμματος Sunburst και Treemap.

Ακολουθεί ένα διάγραμμα Sunburst, όπου τα δεδομένα στη στήλη Series1 ορίζουν τους κόμβους φύλλων, ενώ οι άλλες στήλες ορίζουν ιεραρχικά σημεία δεδομένων:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Ας ξεκινήσουμε προσθέτοντας ένα νέο διάγραμμα Sunburst στην παρουσίαση:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [**Δημιουργία ή Ενημέρωση Διαγραμμάτων Παρουσίασης PowerPoint σε PHP**](/slides/el/php-java/create-chart/)
{{% /alert %}}

Εάν υπάρχει ανάγκη μορφοποίησης σημείων δεδομένων του διαγράμματος, θα πρέπει να χρησιμοποιήσουμε τα εξής:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapointlevelsmanager/), 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapointlevel/) κλάσεις 
και [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) μέθοδος 
παρέχουν πρόσβαση στη μορφοποίηση σημείων δεδομένων των διαγραμμάτων Treemap και Sunburst. 
Η [**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapointlevelsmanager/)
χρησιμοποιείται για την πρόσβαση σε κατηγορίες πολλαπλών επιπέδων – αντιπροσωπεύει το δοχείο των
[**ChartDataPointLevel**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapointlevel/) αντικειμένων.
Βασικά είναι ένας wrapper για την
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartcategorylevelsmanager/) με
τις ιδιότητες που προστέθηκαν ειδικά για τα σημεία δεδομένων. 
Η κλάση [**ChartDataPointLevel**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapointlevel/) διαθέτει δύο μεθόδους: [**getFormat**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapointlevel/#getFormat) και 
[**getDataLabel**](https://reference.aspose.com/slides/el/php-java/aspose.slides/chartdatapointlevel/#getLabel) που
παρέχουν πρόσβαση στις αντίστοιχες ρυθμίσεις.

## **Προβολή Τιμής Σημείου Δεδομένων**

Εμφάνιση τιμής του σημείου δεδομένων «Leaf 4»:

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ορισμός Ετικέτας και Χρώματος Σημείου Δεδομένων**

Ορίστε την ετικέτα δεδομένων του «Branch 1» ώστε να εμφανίζει το όνομα σειράς («Series1») αντί του ονόματος κατηγορίας. Στη συνέχεια ορίστε το χρώμα κειμένου σε κίτρινο:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ορισμός Χρώματος Κλαδίου Σημείου Δεδομένων**

Αλλάξτε το χρώμα του κλαδίου «Steam 4»:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Συχνές Ερωτήσεις**

**Μπορώ να αλλάξω τη σειρά (ταξινόμηση) των τμημάτων σε Sunburst/Treemap;**

Όχι. Το PowerPoint ταξινομεί αυτόματα τα τμήματα (συνήθως κατά φθίνουσες τιμές, δεξιόστροφα). Η Aspose.Slides αντιγράφει αυτή τη συμπεριφορά: δεν μπορείτε να αλλάξετε τη σειρά απευθείας· μπορείτε να το επιτύχετε με προεπεξεργασία των δεδομένων.

**Πώς επηρεάζει το θέμα της παρουσίασης τα χρώματα των τμημάτων και των ετικετών;**

Τα χρώματα του διαγράμματος κληρονομούν το [theme/palette](/slides/el/php-java/presentation-theme/) της παρουσίασης εκτός εάν ορίσετε ρητά γεμίσματα/γραμματοσειρές. Για συνεπή αποτελέσματα, καθορίστε συμπαγή γεμίσματα και μορφοποίηση κειμένου στα απαιτούμενα επίπεδα.

**Θα διατηρήσει η εξαγωγή σε PDF/PNG τα προσαρμοσμένα χρώματα κλάδων και τις ρυθμίσεις ετικετών;**

Ναι. Κατά την εξαγωγή της παρουσίασης, οι ρυθμίσεις του διαγράμματος (γεμίσματα, ετικέτες) διατηρούνται στις μορφές εξόδου επειδή η Aspose.Slides αποδίδει με την εφαρμοσμένη μορφοποίηση του διαγράμματος.

**Μπορώ να υπολογίσω τις πραγματικές συντεταγμένες μιας ετικέτας/στοιχείου για προσαρμοσμένη τοποθέτηση επικάλυψης πάνω στο διάγραμμα;**

Ναι. Μετά την επικύρωση της διάταξης του διαγράμματος, οι πραγματικές *x* και *y* είναι διαθέσιμες για τα στοιχεία (για παράδειγμα, ένα [DataLabel](https://reference.aspose.com/slides/el/php-java/aspose.slides/datalabel/)), κάτι που βοηθά στην ακριβή τοποθέτηση των επικαλύψεων.