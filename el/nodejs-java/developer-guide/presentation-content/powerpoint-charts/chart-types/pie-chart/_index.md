---
title: Προσαρμογή διαγραμμάτων πίτας σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/nodejs-java/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- ρυθμίσεις διαγράμματος
- παραμετροί διαγράμματος
- επιλογές απεικόνισης
- χρώμα φέτας
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα πίτας σε JavaScript με το Aspose.Slides για Node.js, εξαγώγιμα σε PowerPoint, ενισχύοντας την αφήγηση των δεδομένων σας σε δευτερόλεπτα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με διαγράμματα πίτας στο Aspose.Slides. Δείχνει πώς να διαμορφώσετε τις επιλογές δευτεροβάθμιας απεικόνισης για τα διαγράμματα Pie of Pie και Bar of Pie, καθώς και πώς να ενεργοποιήσετε την αυτόματη χρωματίση των φετών σε ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα εστιάζουν σε πρακτικά βήματα προσαρμογής του διαγράμματος, όπως η προσθήκη διαγράμματος σε μια διαφάνεια, η ρύθμιση σειρών και ετικετών, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Δεύτερες Επιλογές Απεικόνισης για Διαγράμματα Pie of Pie και Bar of Pie**
Aspose.Slides για Node.js μέσω Java υποστηρίζει πλέον τις επιλογές δευτεροβάθμιας απεικόνισης για τα διαγράμματα Pie of Pie ή Bar of Pie. Σε αυτό το θέμα, θα σας δείξουμε πώς να καθορίσετε αυτές τις επιλογές χρησιμοποιώντας το Aspose.Slides. Για να ορίσετε τις ιδιότητες, κάντε τα εξής:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Προσθέστε διάγραμμα στη διαφάνεια.
1. Καθορίστε τις επιλογές δευτεροβάθμιας απεικόνισης του διαγράμματος.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε ορίσει διαφορετικές ιδιότητες του διαγράμματος Pie of Pie.

```javascript
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Προσθέστε διάγραμμα στη διαφάνεια
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Ορίστε διαφορετικές ιδιότητες
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Αποθηκεύστε την παρουσίαση στο δίσκο
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Αυτόματων Χρωμάτων Φετών Διαγράμματος Πίτας**
Aspose.Slides για Node.js μέσω Java παρέχει ένα απλό API για τον καθορισμό αυτόματων χρωμάτων φετών διαγράμματος πίτας. Ο κώδικας παραδείγματος εφαρμόζει τις παραπάνω ρυθμίσεις.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Αποκτήστε πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα.
1. Ορίστε τον τίτλο του διαγράμματος.
1. Ορίστε την πρώτη σειρά να εμφανίζει τιμές.
1. Ορίστε το δείκτη του φύλλου δεδομένων του διαγράμματος.
1. Λάβετε το φύλλο εργασίας δεδομένων του διαγράμματος.
1. Διαγράψτε τις προεπιλεγμένες δημιουργημένες σειρές και κατηγορίες.
1. Προσθέστε νέες κατηγορίες.
1. Προσθέστε νέες σειρές.

Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```javascript
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Ορισμός τίτλου διαγράμματος
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Ορίστε την πρώτη σειρά να εμφανίζει τιμές
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Ορισμός δείκτη του φύλλου δεδομένων του διαγράμματος
    var defaultWorksheetIndex = 0;
    // Λήψη φύλλου εργασίας δεδομένων του διαγράμματος
    var fact = chart.getChartData().getChartDataWorkbook();
    // Διαγραφή προεπιλογής παραγόμενων σειρών και κατηγοριών
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Προσθήκη νέων κατηγοριών
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Προσθήκη νέων σειρών
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Τώρα γεμίζουμε τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Υποστηρίζονται οι παραλλαγές 'Pie of Pie' και 'Bar of Pie';**

Ναι, η βιβλιοθήκη [υποστηρίζει](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/) μια δευτεροβάθμια απεικόνιση για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων 'Pie of Pie' και 'Bar of Pie'.

**Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξάγετε το ίδιο το διάγραμμα ως εικόνα](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getImage) (π.χ. PNG) χωρίς ολόκληρη την παρουσίαση.