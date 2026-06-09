---
title: Διαχείριση σειρών δεδομένων γραφήματος σε παρουσιάσεις στο Android
linktitle: Σειρές δεδομένων
type: docs
url: /el/androidjava/chart-series/
keywords:
- σειρές γραφήματος
- επικάλυψη σειρών
- χρώμα σειράς
- χρώμα κατηγορίας
- όνομα σειράς
- σημείο δεδομένων
- διάστημα σειράς
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις σειρές γραφήματος σε Android για PowerPoint (PPT/PPTX) με πρακτικά παραδείγματα κώδικα Java και βέλτιστες πρακτικές για τη βελτίωση των παρουσιάσεων δεδομένων σας."
---
## **Overview**

Αυτό το άρθρο περιγράφει το ρόλο του [ChartSeries](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chartseries/) στο Aspose.Slides, εστιάζοντας στο πώς τα δεδομένα δομούνται και οπτικοποιούνται μέσα στις παρουσιάσεις. Αυτά τα αντικείμενα παρέχουν τα θεμελιώδη στοιχεία που ορίζουν μεμονωμένα σύνολα σημείων δεδομένων, κατηγορίες και παραμέτρους εμφάνισης σε ένα γράφημα. Εργαζόμενοι με το [ChartSeries](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chartseries/), οι προγραμματιστές μπορούν να ενσωματώσουν άψογα τις υποκείμενες πηγές δεδομένων και να διατηρούν πλήρη έλεγχο πάνω στο πώς εμφανίζεται η πληροφορία, δημιουργώντας δυναμικές, δεδομενο‑προσανατολισμένες παρουσιάσεις που μεταδίδουν σαφώς ιδέες και αναλύσεις.

Μια σειρά είναι μια γραμμή ή στήλη αριθμών που απεικονίζονται σε ένα γράφημα.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Set the Chart Series Overlap**

Με τη μέθοδο [IChartSeries.getOverlap](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartseries/#getOverlap--) μπορείτε να καθορίσετε πόσο πρέπει να επικαλύπτονται οι μπάρα και οι στήλες σε ένα 2D γράφημα (εύρος: -100 έως 100). Αυτή η ιδιότητα εφαρμόζεται σε όλες τις σειρές της γονικής ομάδας σειρών: πρόκειται για προβολή της αντίστοιχης ιδιότητας της ομάδας. Συνεπώς, αυτή η ιδιότητα είναι μόνο για ανάγνωση.

Χρησιμοποιήστε τη μέθοδο εγγραφής `getParentSeriesGroup().setOverlap()` για να ορίσετε την προτιμώμενη τιμή επικαλύψεως.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Προσθέστε ένα συγκεντρωτικό γράφημα στήλης σε μια διαφάνεια.
1. Προσπελάστε την πρώτη σειρά γραφήματος.
1. Προσπελάστε το `ParentSeriesGroup` της σειράς γραφήματος και ορίστε την προτιμώμενη τιμή επικαλύψεως για τη σειρά.
1. Αποθηκεύστε την τροποποιημένη παρουσία σε αρχείο PPTX.

This Java code shows you how to set the overlap for a chart series:

```java
Presentation pres = new Presentation();
try {
    // Προσθέτει γράφημα
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Ορίζει την επικάλυψη της σειράς
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Γράφει το αρχείο παρουσίασης στο δίσκο
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change the Series Color**
Το Aspose.Slides για Android μέσω Java σας επιτρέπει να αλλάξετε το χρώμα μιας σειράς με τον ακόλουθο τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Προσθέστε γράφημα στη διαφάνεια.
1. Προσπελάστε τη σειρά της οποίας το χρώμα θέλετε να αλλάξετε.
1. Ορίστε τον προτιμώμενο τύπο γεμίσματος και το χρώμα γεμίσματος.
1. Αποθηκεύστε την τροποποιημένη παρουσία.

This Java code shows you how to change a series' color:

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change the Series Category Color**
Το Aspose.Slides για Android μέσω Java σας επιτρέπει να αλλάξετε το χρώμα μιας κατηγορίας σειράς με τον ακόλουθο τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Προσθέστε γράφημα στη διαφάνεια.
1. Προσπελάστε την κατηγορία της σειράς της οποίας το χρώμα θέλετε να αλλάξετε.
1. Ορίστε τον προτιμώμενο τύπο γεμίσματος και το χρώμα γεμίσματος.
1. Αποθηκεύστε την τροποποιημένη παρουσία.

This code in Java shows you how to change a series category's color:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change the Series Name** 

Από προεπιλογή, τα ονόματα του υπομνήματος ενός γραφήματος είναι το περιεχόμενο των κελιών πάνω από κάθε στήλη ή σειρά δεδομένων.

Στο παράδειγμά μας (δείγμα εικόνας),

* οι στήλες είναι *Series 1, Series 2,* και *Series 3*·
* οι γραμμές είναι *Category 1, Category 2, Category 3,* και *Category 4*.

Το Aspose.Slides για Android μέσω Java σας επιτρέπει να ενημερώσετε ή να αλλάξετε το όνομα μιας σειράς στα δεδομένα γραφήματος και στο υπόμνημα.

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε το όνομα μιας σειράς στα δεδομένα γραφήματος `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε το όνομα μιας σειράς στο υπόμνημα μέσω του`Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set the Chart Series Fill Color**

Το Aspose.Slides για Android μέσω Java σας επιτρέπει να ορίσετε αυτόματο χρώμα γεμίσματος για τις σειρές γραφήματος μέσα σε περιοχή σχεδίασης με τον ακόλουθο τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας με βάση το δείκτη της.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα βασισμένο στον προτιμώμενο τύπο σας (στο παρακάτω παράδειγμα, χρησιμοποιήσαμε το `ChartType.ClusteredColumn`).
1. Προσπελάστε τη σειρά γραφήματος και ορίστε το χρώμα γεμίσματος σε Automatic.
1. Αποθηκεύστε την παρουσία σε αρχείο PPTX.

This Java code shows you how to set the automatic fill color for a chart series:

```java
Presentation pres = new Presentation();
try {
    // Δημιουργεί ένα συγκεντρωτικό γράφημα στήλης
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Ορίζει τη μορφή γεμίσματος της σειράς σε αυτόματο
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Γράφει το αρχείο παρουσίασης στο δίσκο
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Invert Fill Color for a Chart Series**
Το Aspose.Slides σας επιτρέπει να ορίσετε αντιστροφή του χρώματος γεμίσματος για τις σειρές γραφήματος μέσα σε περιοχή σχεδίασης με τον ακόλουθο τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας με βάση το δείκτη της.
1. Προσθέστε ένα γράφημα με προεπιλεγμένα δεδομένα βασισμένο στον προτιμώμενο τύπο σας (στο παρακάτω παράδειγμα, χρησιμοποιήσαμε το `ChartType.ClusteredColumn`).
1. Προσπελάστε τη σειρά γραφήματος και ορίστε το χρώμα γεμίσματος σε invert.
1. Αποθηκεύστε την παρουσία σε αρχείο PPTX.

This Java code demonstrates the operation:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Προσθέτει νέες σειρές και κατηγορίες
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Παίρνει την πρώτη σειρά γραφήματος και γεμίζει τα δεδομένα της σειράς.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set a Series to Invert When Value Is Negative**
Το Aspose.Slides σας επιτρέπει να ορίσετε αντιστροφές μέσω των ιδιοτήτων `IChartDataPoint.InvertIfNegative` και `ChartDataPoint.InvertIfNegative`. Όταν μια αντιστροφή ορίζεται με αυτές τις ιδιότητες, το σημείο δεδομένων αντιστρέφει τα χρώματά του όταν λαμβάνει μια αρνητική τιμή.

This Java code demonstrates the operation:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Clear Specific Point Data**
Το Aspose.Slides για Android μέσω Java σας επιτρέπει να διαγράψετε τα δεδομένα `DataPoints` για μια συγκεκριμένη σειρά γραφήματος με τον ακόλουθο τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Αποκτήστε την αναφορά ενός γραφήματος μέσω του δείκτη του.
4. Διατρέξτε όλα τα `DataPoints` του γραφήματος και θέστε τα `XValue` και `YValue` σε null.
5. Διαγράψτε όλα`DataPoints` για τη συγκεκριμένη σειρά γραφήματος.
6. Αποθηκεύστε την τροποποιημένη παρουσία σε αρχείο PPTX.

This Java code demonstrates the operation:

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set the Series Gap Width**
Το Aspose.Slides για Android μέσω Java σας επιτρέπει να ορίσετε το Πλάτος Κενού (Gap Width) μιας σειράς μέσω της ιδιότητας **`GapWidth`** με τον ακόλουθο τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Προσπελάστε την πρώτη διαφάνεια.
1. Προσθέστε γράφημα με προεπιλεγμένα δεδομένα.
1. Προσπελάστε οποιαδήποτε σειρά γραφήματος.
1. Ορίστε την ιδιότητα `GapWidth`.
1. Αποθηκεύστε την τροποποιημένη παρουσία σε αρχείο PPTX.

```java
// Δημιουργεί κενή παρουσίαση
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθέτει γράφημα με προεπιλεγμένα δεδομένα
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Ορίζει το δείκτη του φύλλου δεδομένων γραφήματος
    int defaultWorksheetIndex = 0;
    
    // Λαμβάνει το φύλλο εργασίας δεδομένων του γραφήματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Προσθέτει σειρές
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Προσθέτει κατηγορίες
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Παίρνει τη δεύτερη σειρά γραφήματος
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Συμπληρώνει τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Ορίζει την τιμή GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Υπάρχει όριο στον αριθμό των σειρών που μπορεί να περιέχει ένα μόνο γράφημα;**

Το Aspose.Slides δεν επιβάλλει κάποιο σταθερό όριο στον αριθμό των σειρών που προσθέτετε. Το πρακτικό όριο καθορίζεται από την αναγνωσιμότητα του γραφήματος και από τη μνήμη που διατίθεται στην εφαρμογή σας.

**Τι γίνεται αν οι στήλες μέσα σε ένα σύμπλεγμα είναι πολύ κοντά ή πολύ μακριά μεταξύ τους;**

Ρυθμίστε την παράμετρο `GapWidth` για τη συγκεκριμένη σειρά (ή την γονική ομάδα σειρών). Η αύξηση της τιμής διευρύνει το κενό μεταξύ των στηλών, ενώ η μείωση της τις φέρνει πιο κοντά η μία στην άλλη.