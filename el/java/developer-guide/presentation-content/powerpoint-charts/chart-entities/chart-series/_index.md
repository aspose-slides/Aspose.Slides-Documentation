---
title: "Διαχείριση Σειρών Δεδομένων Διαγράμματος σε Παρουσιάσεις με Java"
linktitle: "Σειρές Δεδομένων"
type: docs
url: /el/java/chart-series/
keywords:
- "Σειρές διαγράμματος"
- "Επικάλυψη σειρών"
- "Χρώμα σειράς"
- "Χρώμα κατηγορίας"
- "Όνομα σειράς"
- "Σημείο δεδομένων"
- "Κενό σειράς"
- "PowerPoint"
- "Παρουσίαση"
- "Java"
- "Aspose.Slides"
description: "Μάθετε πώς να διαχειρίζεστε τις σειρές διαγράμματος σε Java για PowerPoint (PPT/PPTX) με πρακτικά παραδείγματα κώδικα και βέλτιστες πρακτικές για τη βελτίωση των παρουσιάσεων δεδομένων σας."
---
## **Επισκόπηση**

Αυτό το άρθρο περιγράφει τον ρόλο του [ChartSeries](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartseries/) στο Aspose.Slides, εστιάζοντας στο πώς δομούνται και απεικονίζονται τα δεδομένα μέσα στις παρουσιάσεις. Αυτά τα αντικείμενα παρέχουν τα βασικά στοιχεία που ορίζουν μεμονωμένα σύνολα σημείων δεδομένων, κατηγορίες και παραμέτρους εμφάνισης σε ένα διάγραμμα. Εργαζόμενοι με το [ChartSeries](https://reference.aspose.com/slides/el/java/com.aspose.slides/chartseries/), οι προγραμματιστές μπορούν να ενσωματώσουν απρόσκοπτα τις υποκείμενες πηγές δεδομένων και να διατηρήσουν πλήρη έλεγχο πάνω στο πώς εμφανίζονται οι πληροφορίες, δημιουργώντας δυναμικές, δεδομενο‑κατευθυνόμενες παρουσιάσεις που μεταφέρουν σαφώς ιδέες και αναλύσεις.

Μια σειρά είναι μια γραμμή ή στήλη αριθμών που απεικονίζεται σε διάγραμμα.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός της Επικάλυψης Σειράς Διαγράμματος**

Με την ιδιότητα [IChartSeriesOverlap](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartseries/properties/overlap) μπορείτε να καθορίσετε πόση επικάλυψη πρέπει να έχουν οι ράβδοι και οι στήλες σε ένα 2D διάγραμμα (περιοχή: -100 έως 100). Αυτή η ιδιότητα εφαρμόζεται σε όλες τις σειρές της γονικής ομάδας σειρών: αποτελεί προβολή της αντίστοιχης ιδιότητας ομάδας. Συνεπώς, αυτή η ιδιότητα είναι μόνο για ανάγνωση.

Χρησιμοποιήστε την ιδιότητα ανάγνωσης/εγγραφής `ParentSeriesGroup.Overlap` για να ορίσετε την προτιμώμενη τιμή του `Overlap`.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Προσθέστε ένα συγκεντρωτικό διάγραμμα στηλών σε μια διαφάνεια.
1. Αποκτήστε πρόσβαση στην πρώτη σειρά διαγράμματος.
1. Αποκτήστε πρόσβαση στο `ParentSeriesGroup` της σειράς διαγράμματος και ορίστε την προτιμώμενη τιμή επικάλυψης για τη σειρά.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```java
Presentation pres = new Presentation();
try {
    // Προσθέτει διάγραμμα
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Ορίζει επικάλυψη σειράς
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Γράφει το αρχείο παρουσίασης στο δίσκο
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αλλαγή Χρώματος Σειράς**

Το Aspose.Slides for Java σας επιτρέπει να αλλάξετε το χρώμα μιας σειράς με τον εξής τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Προσθέστε διάγραμμα στη διαφάνεια.
1. Αποκτήστε πρόσβαση στη σειρά του οποίου το χρώμα θέλετε να αλλάξετε.
1. Ορίστε τον προτιμώμενο τύπο γεμίσματος και το χρώμα γεμίσματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

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

## **Αλλαγή Χρώματος Κατηγορίας Σειράς**

Το Aspose.Slides for Java σας επιτρέπει να αλλάξετε το χρώμα μιας κατηγορίας σειράς με τον εξής τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Προσθέστε διάγραμμα στη διαφάνεια.
1. Αποκτήστε πρόσβαση στην κατηγορία σειράς του οποίου το χρώμα θέλετε να αλλάξετε.
1. Ορίστε τον προτιμώμενο τύπο γεμίσματος και το χρώμα γεμίσματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

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

## **Αλλαγή Ονόματος Σειράς** 

Από προεπιλογή, τα ονόματα του υπομνήματος για ένα διάγραμμα είναι τα περιεχόμενα των κελιών πάνω από κάθε στήλη ή γραμμή δεδομένων. 

Στο παράδειγμά μας (εικόνα δείγματος),

* οι στήλες είναι *Series 1, Series 2,* και *Series 3*;
* οι γραμμές είναι *Category 1, Category 2, Category 3,* και *Category 4.* 

Το Aspose.Slides for Java σας επιτρέπει να ενημερώσετε ή να αλλάξετε το όνομα μιας σειράς στα δεδομένα του διαγράμματος και στο υπόμνημα.

Αυτός ο κώδικας Java σας δείχνει πώς να αλλάξετε το όνομα μιας σειράς στα δεδομένα του διαγράμματος `ChartDataWorkbook`:

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

Αυτός ο κώδικας Java σας δείχνει πώς να αλλάξετε το όνομα μιας σειράς στο υπόμνημα μέσω του`Series`:

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

## **Ορισμός Χρώματος Γέμισης Σειράς Διαγράμματος**

Το Aspose.Slides for Java σας επιτρέπει να ορίσετε το αυτόματο χρώμα γέμισης για σειρές διαγράμματος μέσα στην περιοχή σχεδίασης με τον εξής τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα βάσει του προτιμώμενου τύπου σας (στο παρακάτω παράδειγμα, χρησιμοποιήσαμε `ChartType.ClusteredColumn`).
1. Αποκτήστε πρόσβαση στη σειρά του διαγράμματος και ορίστε το χρώμα γέμισης σε Automatic.
1. Αποθηκεύστε την παρουσίαση σε αρχείο PPTX.

```java
Presentation pres = new Presentation();
try {
    // Δημιουργεί ένα συγκεντρωτικό διάγραμμα στηλών
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Ορίζει το γέμισμα της σειράς σε αυτόματο
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

## **Ορισμός Αντιστροφής Χρώματος Γέμισης για Σειρά Διαγράμματος**

Το Aspose.Slides σας επιτρέπει να ορίσετε την αντιστροφή χρώματος γέμισης για σειρές διαγράμματος μέσα στην περιοχή σχεδίασης με τον εξής τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Αποκτήστε αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα βάσει του προτιμώμενου τύπου σας (στο παρακάτω παράδειγμα, χρησιμοποιήσαμε `ChartType.ClusteredColumn`).
1. Αποκτήστε πρόσβαση στη σειρά του διαγράμματος και ορίστε το χρώμα γέμισης σε invert.
1. Αποθηκεύστε την παρουσίαση σε αρχείο PPTX.

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

    // Παίρνει την πρώτη σειρά διαγράμματος και γεμίζει τα δεδομένα της σειράς.
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

## **Ορισμός Σειράς να Αντιστρέφεται Όταν η Τιμή είναι Αρνητική**

Το Aspose.Slides επιτρέπει τον ορισμό αντιστροφών μέσω των ιδιοτήτων `IChartDataPoint.InvertIfNegative` και `ChartDataPoint.InvertIfNegative`. Όταν μια αντιστροφή ορίζεται με χρήση των ιδιοτήτων, το σημείο δεδομένων αντιστρέφει τα χρώματά του όταν λαβάνει αρνητική τιμή.

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

## **Καθαρισμός Στοιχείων Συγκεκριμένου Σημείου**

Το Aspose.Slides for Java σας επιτρέπει να καθαρίσετε τα δεδομένα `DataPoints` για μια συγκεκριμένη σειρά διαγράμματος με τον εξής τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Αποκτήστε την αναφορά ενός διαγράμματος μέσω του δείκτη του.
4. Διασχίστε όλα τα `DataPoints` του διαγράμματος και ορίστε τις τιμές `XValue` και `YValue` σε null.
5. Καθαρίστε όλα τα`DataPoints` για τη συγκεκριμένη σειρά διαγράμματος.
6. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

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

## **Ορισμός Πλάτους Κενού Σειράς**

Το Aspose.Slides for Java σας επιτρέπει να ορίσετε το πλάτος κενού μιας σειράς μέσω της ιδιότητας **`GapWidth`** με τον εξής τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
1. Αποκτήστε πρόσβαση στην πρώτη διαφάνεια.
1. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα.
1. Αποκτήστε πρόσβαση σε οποιαδήποτε σειρά διαγράμματος.
1. Ορίστε την ιδιότητα `GapWidth`.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```java
// Δημιουργεί κενή παρουσίαση 
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθέτει διάγραμμα με προεπιλεγμένα δεδομένα
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Ορίζει τον δείκτη του φύλλου δεδομένων διαγράμματος
    int defaultWorksheetIndex = 0;
    
    // Λαμβάνει το φύλλο εργασίας δεδομένων διαγράμματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Προσθέτει σειρές
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Προσθέτει κατηγορίες
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Πάει τη δεύτερη σειρά διαγράμματος
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Γεμίζει τα δεδομένα της σειράς
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

**Υπάρχει όριο στον αριθμό των σειρών που μπορεί να περιέχει ένα μόνο διάγραμμα;**

Το Aspose.Slides δεν επιβάλλει σταθερό όριο στον αριθμό των σειρών που μπορείτε να προσθέσετε. Το πρακτικό όριο καθορίζεται από την αναγνωσιμότητα του διαγράμματος και από τη μνήμη που είναι διαθέσιμη στην εφαρμογή σας.

**Τι γίνεται αν οι στήλες μέσα σε ένα σύμπλεγμα είναι πολύ κοντά ή πολύ μακριά μεταξύ τους;**

Ρυθμίστε την παράμετρο `GapWidth` για αυτή τη σειρά (ή για την γονική ομάδα σειρών). Η αύξηση της τιμής διευρύνει το κενό μεταξύ των στηλών, ενώ η μείωσή της τις φέρνει πιο κοντά.