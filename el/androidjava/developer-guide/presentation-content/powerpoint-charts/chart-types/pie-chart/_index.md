---  
title: Προσαρμογή διαγραμμάτων πίτας σε παρουσιάσεις στο Android  
linktitle: Διάγραμμα Πίτας  
type: docs  
url: /el/androidjava/pie-chart/  
keywords:  
- διάγραμμα πίτας  
- διαχείριση διαγράμματος  
- προσαρμογή διαγράμματος  
- επιλογές διαγράμματος  
- ρυθμίσεις διαγράμματος  
- επιλογές απεικόνισης  
- χρώμα φέτας  
- PowerPoint  
- παρουσίαση  
- Android  
- Java  
- Aspose.Slides  
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα πίτας σε Java με το Aspose.Slides για Android, εξαγώγιμα σε PowerPoint, ενισχύοντας την αφήγηση των δεδομένων σας σε δευτερόλεπτα."  
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με διαγράμματα πίτας στο Aspose.Slides. Εμφανίζει πώς να διαμορφώσετε τις επιλογές δευτερεύουσας σειράς για διαγράμματα Pie of Pie και Bar of Pie, και πώς να ενεργοποιήσετε τον αυτόματο χρωματισμό των φετών σε ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα επικεντρώνονται σε πρακτικά βήματα προσαρμογής διαγράμματος όπως η προσθήκη διαγράμματος σε διαφάνεια, η ρύθμιση σειρών και ετικετών, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Επιλογές Δευτερεύουσας Σειράς για Διαγράμματα Pie of Pie και Bar of Pie**
Το Aspose.Slides για Android μέσω Java υποστηρίζει πλέον επιλογές δευτερεύουσας σειράς για το διάγραμμα Pie of Pie ή Bar of Pie. Σε αυτό το θέμα, θα σας δείξουμε πώς να καθορίσετε αυτές τις επιλογές χρησιμοποιώντας το Aspose.Slides. Για να καθορίσετε τις ιδιότητες, κάντε το εξής:

1. Δημιουργήστε ένα αντικείμενο κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Προσθέστε γράφημα στη διαφάνεια.
1. Καθορίστε τις επιλογές δευτερεύουσας σειράς του γραφήματος.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε ορίσει διαφορετικές ιδιότητες του διαγράμματος Pie of Pie.

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Προσθέστε διάγραμμα στη διαφάνεια
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Ορίστε διαφορετικές ιδιότητες
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Αποθηκεύστε την παρουσίαση στο δίσκο
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Αυτόματων Χρωμάτων Φέτας σε Διάγραμμα Πίτας**
Το Aspose.Slides για Android μέσω Java παρέχει ένα απλό API για τον ορισμό αυτόματων χρωμάτων φέτας σε διάγραμμα πίτας. Ο κώδικας παραδείγματος εφαρμόζει τον ορισμό των παραπάνω ιδιοτήτων.

1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε γράφημα με προεπιλεγμένα δεδομένα.
1. Ορίστε τον τίτλο του γραφήματος.
1. Ορίστε την πρώτη σειρά σε Εμφάνιση Τιμών.
1. Ορίστε το δείκτη του φύλλου δεδομένων του γραφήματος.
1. Λήψη του φύλλου εργασίας δεδομένων του γραφήματος.
1. Διαγράψτε τις προεπιλεγμένες δημιουργημένες σειρές και κατηγορίες.
1. Προσθέστε νέες κατηγορίες.
1. Προσθέστε νέες σειρές.

Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Ορίζοντας τον τίτλο του διαγράμματος
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Ορίστε την πρώτη σειρά για Εμφάνιση Τιμών
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Ορισμός του δείκτη του φύλλου δεδομένων του διαγράμματος
    int defaultWorksheetIndex = 0;

    // Λήψη του φύλλου εργασίας δεδομένων του διαγράμματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Διαγραφή των προεπιλεγμένα δημιουργημένων σειρών και κατηγοριών
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Προσθήκη νέων κατηγοριών
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Προσθήκη νέων σειρών
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Τώρα συμπλήρωση δεδομένων σειράς
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζονται οι παραλλαγές 'Pie of Pie' και 'Bar of Pie';**

Ναι, η βιβλιοθήκη [υποστηρίζει](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/) μια δευτερεύουσα σειρά για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων 'Pie of Pie' και 'Bar of Pie'.

**Μπορώ να εξάγω μόνο το γράφημα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξάγετε το ίδιο το γράφημα ως εικόνα](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (π.χ. PNG) χωρίς ολόκληρη την παρουσίαση.