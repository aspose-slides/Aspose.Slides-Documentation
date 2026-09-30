---
title: Προσαρμογή υπομνημάτων γραφημάτων σε παρουσιάσεις χρησιμοποιώντας PHP
linktitle: Υπόμνημα γραφήματος
type: docs
url: /el/php-java/chart-legend/
keywords:
- υπόμνημα γραφήματος
- θέση υπομνήματος
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Προσαρμόστε τα υπομνήματα γραφημάτων με Aspose.Slides για PHP μέσω Java ώστε να βελτιστοποιήσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση υπομνήματος."
---
## **Επισκόπηση**

Το Aspose.Slides για PHP μέσω Java παρέχει επιλογές για προσαρμογή των υπομνημάτων γραφημάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να ορίσετε το μέγεθος ενός υπομνήματος, να ρυθμίσετε το μέγεθος γραμματοσειράς για ολόκληρο το υπόμνημα, να μορφοποιήσετε μια μεμονωμένη εγγραφή υπομνήματος και να κρύψετε ή να επαναφέρετε επιλεγμένες εγγραφές.

Το FAQ καλύπτει σχετικές συμπεριφορές, συμπεριλαμβανομένου του διατήρησης χώρου για το υπόμνημα, της εμφάνισης ετικετών πολλαπλών γραμμών και της κληρονομιάς μορφοποίησης από το θέμα της παρουσίασης.

## **Τοποθέτηση Υπομνήματος**

Χρησιμοποιήστε τις μεθόδους [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/), και [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) του υπομνήματος για να καθορίσετε τη θέση και το μέγεθός του ως κλάσματα των διαστάσεων του γραφήματος.

Αυτό το παράδειγμα δημιουργεί μια παρουσίαση και προσθέτει ένα σύμπλεγμα στηλών σε στήλες με προεπιλεγμένα δεδομένα στη πρώτη διαφάνεια. Η διαίρεση των επιθυμητών μετατοπίσεων και διαστάσεων του υπομνήματος με το πλάτος και το ύψος του γραφήματος τα μετατρέπει σε σχετικές τιμές: το υπόμνημα μετατοπίζεται κατά 50 σημεία από την πάνω‑αριστερή γωνία του γραφήματος και έχει μέγεθος 100 × 100 σημεία. Το παράδειγμα χρησιμοποιεί java_values για να μετατρέψει τις διαστάσεις του γραφήματος που επιστρέφει το PHP/Java Bridge σε αριθμούς PHP πριν τη διαίρεση.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Εκφράστε τη θέση και το μέγεθος του υπομνήματος σε σχέση με το γράφημα.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Μεγέθους Γραμματοσειράς Υπομνήματος**

Χρησιμοποιήστε το [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) του υπομνήματος για να αποκτήσετε πρόσβαση στη μορφοποίηση κειμένου του και χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) για να ορίσετε το μέγεθος γραμματοσειράς σε πόντους.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα με προεπιλεγμένα δεδομένα και ορίζει το κείμενο του υπομνήματος σε 20 πόντους. Επίσης απενεργοποιεί τα αυτόματα όρια για τον κατακόρυφο άξονα και ορίζει το εύρος του από -5 έως 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός Μεγέθους Γραμματοσειράς Μιας Μεμονωμένης Εγγραφής Υπομνήματος**

Χρησιμοποιήστε τη συλλογή που επιστρέφεται από τη μέθοδο [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) του υπομνήματος για να αποκτήσετε πρόσβαση στη μορφοποίηση μιας συγκεκριμένης εγγραφής. Οι δείκτες εγγραφών είναι μηδενικής βάσης, έτσι ο δείκτης `1` αναφέρεται στη δεύτερη εγγραφή.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Απόκρυψη Ατομικών Εγγραφών Υπομνήματος**

Για να εξαιρέσετε μια δευτερεύουσα σειρά από το υπόμνημα ενώ διατηρείτε τα δεδομένα της ορατά, καλέστε το [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) με `true` μέσω του [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). Αυτό κρύβει μόνο την επιλεγμένη εγγραφή υπομνήματος· δεν αφαιρεί τη σειρά ή τα σημεία δεδομένων της. Η κλήση του [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) με `false`, αντίθετα, κρύβει ολόκληρο το υπόμνημα.

Το παρακάτω παράδειγμα δημιουργεί ένα σύμπλεγμα στηλών σε στήλες με πολλαπλές σειρές χρησιμοποιώντας προεπιλεγμένα δεδομένα. Κρύβει τη δεύτερη σειρά του υπομνήματος (δείκτης `1`) και αποθηκεύει την παρουσίαση. Στη συνέχεια επαναφέρει την εγγραφή καλώντας το [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) με `false` και αποθηκεύει ένα δεύτερο αντίγραφο. Οι στήλες παραμένουν ορατές και στα δύο αρχεία.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Αποκαταστήστε την ίδια εγγραφή χωρίς να αλλάξετε τα δεδομένα του γραφήματος.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η σύγκριση παρακάτω δείχνει το ίδιο γράφημα με όλες τις εγγραφές υπομνήματος ορατές και με τη δεύτερη εγγραφή κρυμμένη. Οι στήλες της δεύτερης σειράς παραμένουν αμετάβλητες.

![Σύγκριση γραφήματος με όλες τις εγγραφές υπομνήματος ορατές και με τη Σειρά 2 κρυμμένη από το υπόμνημα· όλες οι στήλες παραμένουν ορατές.](hide-legend-entry.png)

Σε γραφήματα στήλης, μπάρας και γραμμής, οι εγγραφές υπομνήματος προσδιορίζουν σειρές. Για διαγράμματα πίτας, προσδιορίζουν μεμονωμένα σημεία δεδομένων (κομμάτια), οπότε χρησιμοποιήστε το [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) στο επιλεγμένο κομμάτι. Το API τεκμηριώνεται για τις μεθόδους σημείου δεδομένων στους τύπους γραφημάτων `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` και `BarOfPie`. Μην υποθέτετε ότι εφαρμόζεται σε διαγράμματα δακτυλίου, που δεν περιλαμβάνονται σε αυτή τη λίστα.

## **Συχνές Ερωτήσεις**

**Μπορώ να κάνω το γράφημα να διατηρεί χώρο για το υπόμνημα αντί να το επικαλύπτει;**  
Ναι. Καλέστε το [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) με `false` για να διατηρήσετε χώρο για το υπόμνημα αντί να το επιτρέψετε να επικαλύπτει την περιοχή γραφήματος.

**Μπορώ να δημιουργήσω ετικέτες υπομνήματος πολλαπλών γραμμών;**  
Ναι. Μερικές ετικέτες μπορούν να σενάρουν όταν το διαθέσιμο πλάτος είναι ανεπαρκές. Μπορείτε επίσης να χρησιμοποιήσετε χαρακτήρες αλλαγής γραμμής σε ονόματα σειρών για να ζητήσετε αλλαγές γραμμής.

**Πώς μπορώ να κάνω το υπόμνημα να ακολουθεί το χρωματολόγιο του θέματος της παρουσίασης;**  
Αφήστε τα χρώματα, τα γεμίσματα και τις γραμματοσειρές του υπομνήματος ακαθορισμένα ώστε να κληρονομεί τη μορφοποίηση του θέματος. Η ρητή μορφοποίηση υπερισχύει των αντίστοιχων ρυθμίσεων του θέματος.