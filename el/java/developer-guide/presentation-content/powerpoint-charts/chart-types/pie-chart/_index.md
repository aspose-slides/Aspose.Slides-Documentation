---
title: Προσαρμογή διαγραμμάτων πίτας σε παρουσιάσεις χρησιμοποιώντας Java
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/java/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές απεικόνισης
- χρώμα φετών
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα πίτας σε Java με το Aspose.Slides, εξαγώγιμα σε PowerPoint, ενισχύοντας την αφήγηση των δεδομένων σας μέσα σε δευτερόλεπτα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με διαγράμματα πίτας στο Aspose.Slides. Δείχνει πώς να διαμορφώσετε τις επιλογές δευτερεύουσας απεικόνισης για διαγράμματα Pie of Pie και Bar of Pie, και πώς να ενεργοποιήσετε την αυτόματη χρωματισμό των φετών για ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα εστιάζουν σε πρακτικά βήματα προσαρμογής διαγράμματος όπως η προσθήκη διαγράμματος σε διαφάνεια, η προσαρμογή ρυθμίσεων σειρών και ετικετών, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Επιλογές Δεύτερης Απεικόνισης για Διαγράμματα Pie of Pie και Bar of Pie**

Aspose.Slides for Java τώρα υποστηρίζει επιλογές δεύτερης απεικόνισης για διάγραμμα Pie of Pie ή Bar of Pie. Σε αυτό το θέμα, θα σας δείξουμε πώς να καθορίσετε αυτές τις επιλογές χρησιμοποιώντας το Aspose.Slides. Για να καθορίσετε τις ιδιότητες, κάντε τα εξής:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Προσθέστε διάγραμμα στη διαφάνεια.
1. Καθορίστε τις επιλογές δεύτερης απεικόνισης του διαγράμματος.
1. Γράψτε την παρουσίαση στο δίσκο.

Στο παρακάτω παράδειγμα, έχουμε ορίσει διαφορετικές ιδιότητες του διαγράμματος Pie of Pie.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Προσθέστε διάγραμμα στη διαφάνεια
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Ορίστε διαφορετικές ιδιότητες
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Γράψτε την παρουσίαση στο δίσκο
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Αυτόματων Χρωμάτων Φετών Διαγράμματος Πίτας**

Aspose.Slides for Java παρέχει ένα απλό API για τον ορισμό αυτόματων χρωμάτων φετών διαγράμματος πίτας. Ο κώδικας παραδείγματος εφαρμόζει τον ορισμό των παραπάνω ιδιοτήτων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Προσπελάστε την πρώτη διαφάνεια.
1. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα.
1. Ορίστε τον τίτλο του διαγράμματος.
1. Ορίστε την πρώτη σειρά σε Εμφάνιση Τιμών.
1. Ορίστε το ευρετήριο του φύλλου δεδομένων διαγράμματος.
1. Ανάκτηση του φύλλου εργασίας δεδομένων διαγράμματος.
1. Διαγράψτε τις προεπιλεγμένες παραγόμενες σειρές και κατηγορίες.
1. Προσθέστε νέες κατηγορίες.
1. Προσθέστε νέες σειρές.

Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Ορισμός τίτλου διαγράμματος
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Ορίστε την πρώτη σειρά σε Εμφάνιση Τιμών
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Ορισμός του δείκτη φύλλου δεδομένων διαγράμματος
    int defaultWorksheetIndex = 0;

    // Λήψη του φύλλου εργασίας δεδομένων διαγράμματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Διαγραφή των προεπιλεγμένων παραγόμενων σειρών και κατηγοριών
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Προσθήκη νέων κατηγοριών
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Προσθήκη νέων σειρών
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Τώρα γεμίζουμε τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Υποστηρίζονται οι παραλλαγές 'Pie of Pie' και 'Bar of Pie';**

Ναι, η βιβλιοθήκη [υποστηρίζει](https://reference.aspose.com/slides/el/java/com.aspose.slides/charttype/) μια δευτερεύουσα απεικόνιση για διαγράμματα πίτας, συμπεριλαμβανομένων των τύπων 'Pie of Pie' και 'Bar of Pie'.

**Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξάγετε το ίδιο το διάγραμμα ως εικόνα](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getImage-int-float-float-) (όπως PNG) χωρίς ολόκληρη την παρουσίαση.