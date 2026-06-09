---
title: Διαχειριστείτε τις Σειρές Δεδομένων Διαγράμματος σε Παρουσιάσεις με JavaScript
linktitle: Σειρές Δεδομένων
type: docs
url: /el/nodejs-java/chart-series/
keywords:
- σειρά διαγράμματος
- επικαλυπτική σειρά
- χρώμα σειράς
- χρώμα κατηγορίας
- όνομα σειράς
- σημείο δεδομένων
- κενό σειράς
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις σειρές διαγράμματος σε JavaScript για PowerPoint (PPT/PPTX) με πρακτικά παραδείγματα κώδικα και βέλτιστες πρακτικές για τη βελτίωση των παρουσιάσεων δεδομένων σας."
---
## **Επισκόπηση**

Αυτό το άρθρο περιγράφει το ρόλο του ChartSeries στο Aspose.Slides, εστιάζοντας στο πώς τα δεδομένα δομούνται και απεικονίζονται μέσα σε παρουσιάσεις. Αυτά τα αντικείμενα παρέχουν τα θεμέλια στοιχεία που ορίζουν μεμονωμένα σύνολα σημείων δεδομένων, κατηγοριών και παραμέτρων εμφάνισης σε ένα διάγραμμα. Εργαζόμενοι με το ChartSeries, οι προγραμματιστές μπορούν αδιάλειπτα να ενσωματώσουν τις υποκείμενες πηγές δεδομένων και να διατηρούν πλήρη έλεγχο του τρόπου παρουσίασης των πληροφοριών, οδηγώντας σε δυναμικές, δεδομενο‑προσανατολισμένες παρουσιάσεις που μεταδίδουν σαφώς ιδέες και ανάλυση.

Μία σειρά είναι μια γραμμή ή στήλη αριθμών που σχεδιάζονται σε ένα διάγραμμα.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ορισμός Επικάλυψης Σειράς Διαγράμματος**

Με τη μέθοδο ChartSeries.getOverlap, μπορείτε να καθορίσετε πόσο πρέπει να επικαλύπτονται οι μπάρες και οι στήλες σε ένα δισδιάστατο διάγραμμα (εύρος: -100 έως 100). Αυτή η ιδιότητα εφαρμόζεται σε όλες τις σειρές της γονικής ομάδας σειρών: πρόκειται για μια προβολή της αντίστοιχης ιδιότητας ομάδας. Συνεπώς, αυτή η ιδιότητα είναι μόνο για ανάγνωση.

Χρησιμοποιήστε την ιδιότητα ανάγνωσης/εγγραφής `ParentSeriesGroup.getOverlap` για να ορίσετε την προτιμώμενη τιμή της `Overlap`.

1. Δημιουργήστε μια νέα παρουσία της κλάσης Presentation.  
1. Προσθέστε ένα συγκεντρωτικό ραβδόγραμμα σε μια διαφάνεια.  
1. Προσπελάστε την πρώτη σειρά διαγράμματος.  
1. Προσπελάστε την `ParentSeriesGroup` της σειράς διαγράμματος και ορίστε την προτιμώμενη τιμή επικάλυψης για τη σειρά.  
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει γράφημα
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Ορίζει την επικάλυψη της σειράς
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Γράφει το αρχείο παρουσίασης στο δίσκο
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αλλαγή Χρώματος Σειράς**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να αλλάξετε το χρώμα μιας σειράς με αυτόν τον τρόπο:

1. Δημιουργήστε μια νέα παρουσία της κλάσης Presentation.  
1. Προσθέστε διάγραμμα στη διαφάνεια.  
1. Προσπελάστε τη σειρά της οποίας το χρώμα θέλετε να αλλάξετε.  
1. Ορίστε τον προτιμώμενο τύπο γεμίσματος και το χρώμα γεμίσματος.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αλλαγή Χρώματος Κατηγορίας Σειράς**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να αλλάξετε το χρώμα μιας κατηγορίας σειράς με αυτόν τον τρόπο:

1. Δημιουργήστε μια νέα παρουσία της κλάσης Presentation.  
1. Προσθέστε διάγραμμα στη διαφάνεια.  
1. Προσπελάστε την κατηγορία της σειράς της οποίας το χρώμα θέλετε να αλλάξετε.  
1. Ορίστε τον προτιμώμενο τύπο γεμίσματος και το χρώμα γεμίσματος.  
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αλλαγή Ονόματος Σειράς** 

Από προεπιλογή, τα ονόματα του υπομνήματος ενός διαγράμματος είναι τα περιεχόμενα των κελιών πάνω από κάθε στήλη ή γραμμή δεδομένων. 

Στο παράδειγμά μας (δείγμα εικόνας),

* οι στήλες είναι *Series 1, Series 2,* και *Series 3*;
* οι γραμμές είναι *Category 1, Category 2, Category 3,* και *Category 4.* 

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να ενημερώσετε ή να αλλάξετε το όνομα μιας σειράς στα δεδομένα διαγράμματος και στο υπόμνημα.

Αυτός ο κώδικας JavaScript δείχνει πώς να αλλάξετε το όνομα μιας σειράς στα δεδομένα διαγράμματος `ChartDataWorkbook`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Αυτός ο κώδικας JavaScript δείχνει πώς να αλλάξετε το όνομα μιας σειράς στο υπόμνημα μέσω του `Series`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Χρώματος Γέμισματος Σειράς Διαγράμματος**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να ορίσετε το αυτόματο χρώμα γέμισματος για τις σειρές διαγράμματος εντός περιοχής σχεδίασης με αυτόν τον τρόπο:

1. Δημιουργήστε μια νέα παρουσία της κλάσης Presentation.  
1. Αποκτήστε την αναφορά μιας διαφάνειας με βάση τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα βάσει του προτιμώμενου τύπου σας (στο παρακάτω παράδειγμα, χρησιμοποιήσαμε το `ChartType.ClusteredColumn`).  
1. Προσπελάστε τη σειρά διαγράμματος και ορίστε το χρώμα γέμισματος σε Automatic.  
1. Αποθηκεύστε την παρουσίαση σε αρχείο PPTX.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Δημιουργεί συγκεντρωτικό ραβδόγραμμα
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Ορίζει τη μορφή γεμίσματος της σειράς σε αυτόματη
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Γράφει το αρχείο παρουσίασης στο δίσκο
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Αντιστροφής Χρωμάτων Γέμισματος Σειράς Διαγράμματος**

Το Aspose.Slides σας επιτρέπει να ορίσετε την αντιστροφή του χρώματος γέμισματος για τις σειρές διαγράμματος εντός περιοχής σχεδίασης με αυτόν τον τρόπο:

1. Δημιουργήστε μια νέα παρουσία της κλάσης Presentation.  
1. Αποκτήστε την αναφορά μιας διαφάνειας με βάση τον δείκτη της.  
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα βάσει του προτιμώμενου τύπου σας (στο παρακάτω παράδειγμα, χρησιμοποιήσαμε το `ChartType.ClusteredColumn`).  
1. Προσπελάστε τη σειρά διαγράμματος και ορίστε το χρώμα γέμισματος σε invert.  
1. Αποθηκεύστε την παρουσίαση σε αρχείο PPTX.  

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Προσθέτει νέες σειρές και κατηγορίες
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Παίρνει την πρώτη σειρά διαγράμματος και γεμίζει τα δεδομένα της σειράς.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Αντιστροφής Σειράς Όταν Η Τιμή Είναι Αρνητική**

Το Aspose.Slides σάς επιτρέπει να ορίσετε αντιστροφές μέσω της μεθόδου `ChartDataPoint.setInvertIfNegative`. Όταν ορίζεται μια αντιστροφή χρησιμοποιώντας τις ιδιότητες, το σημείο δεδομένων αντιστρέφει τα χρώματά του όταν λαμβάνει αρνητική τιμή. 

Αυτός ο κώδικας JavaScript δείχνει τη λειτουργία:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Καθαρισμός Δεδομένων Συγκεκριμένων Σημείων Δεδομένων**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να αφαιρέσετε τα δεδομένα `DataPoints` για μια συγκεκριμένη σειρά διαγράμματος με αυτόν τον τρόπο:

1. Δημιουργήστε μια νέα παρουσία της κλάσης Presentation.  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Αποκτήστε την αναφορά ενός διαγράμματος μέσω του δείκτη του.  
4. Επαναλάβετε σε όλα τα `DataPoints` του διαγράμματος και ορίστε τα `XValue` και `YValue` σε null.  
5. Καθαρίστε όλα τα `DataPoints` για συγκεκριμένη σειρά διαγράμματος.  
6. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.  

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Πλάτους Κενού Σειράς**

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να ορίσετε το Πλάτος Κενού μιας σειράς μέσω της ιδιότητας `GapWidth` με αυτόν τον τρόπο:

1. Δημιουργήστε μια νέα παρουσία της κλάσης Presentation.  
1. Προσπελάστε την πρώτη διαφάνεια.  
1. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα.  
1. Προσπελάστε οποιαδήποτε σειρά διαγράμματος.  
1. Ορίστε την ιδιότητα `GapWidth`.  
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.  

```javascript
// Δημιουργεί κενή παρουσίαση
var pres = new aspose.slides.Presentation();
try {
    // Προσπελάζει την πρώτη διαφάνεια της παρουσίασης
    var slide = pres.getSlides().get_Item(0);
    // Προσθέτει γράφημα με προεπιλεγμένα δεδομένα
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Ορίζει τον δείκτη του φύλλου δεδομένων του γραφήματος
    var defaultWorksheetIndex = 0;
    // Λαμβάνει το φύλλο εργασίας δεδομένων του γραφήματος
    var fact = chart.getChartData().getChartDataWorkbook();
    // Προσθέτει σειρές
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Προσθέτει κατηγορίες
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Παίρνει τη δεύτερη σειρά του γραφήματος
    var series = chart.getChartData().getSeries().get_Item(1);
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
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Υπάρχει όριο στον αριθμό των σειρών που μπορεί να περιέχει ένα μεμονωμένο διάγραμμα;**

Το Aspose.Slides δεν θέτει κάποιο σταθερό όριο στον αριθμό των σειρών που προσθέτετε. Το πρακτικό όριο καθορίζεται από την αναγνωσιμότητα του διαγράμματος και από τη μνήμη που διατίθεται στην εφαρμογή σας.

**Τι γίνεται αν οι στήλες μέσα σε ένα σύνολο είναι πολύ κοντά μεταξύ τους ή πολύ μακριά;**

Ρυθμίστε την παράμετρο Gap Width για εκείνη τη σειρά (ή για την γονική ομάδα σειρών). Η αύξηση της τιμής διευρύνει το κενό μεταξύ των στηλών, ενώ η μείωσή της τις φέρνει πιο κοντά μεταξύ τους.