---
title: Προσαρμογή 3D Διαγραμμάτων σε Παρουσιάσεις Χρησιμοποιώντας Java
linktitle: 3D Διάγραμμα
type: docs
url: /el/java/3d-chart/
keywords:
- 3D Διάγραμμα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε 3‑Δ διαγράμματα στο Aspose.Slides για Java, με υποστήριξη αρχείων PPT και PPTX — ενισχύστε τις παρουσιάσεις σας σήμερα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε ένα τρισδιάστατο διάγραμμα στο Aspose.Slides ρυθμίζοντας τις ρυθμίσεις `Rotation3D` όπως `RotationX`, `RotationY`, `DepthPercents` και `RightAngleAxes`. Περιγράφει τη δημιουργία μιας παρουσίασης, την προσθήκη ενός τρισδιάστατου διαγράμματος με προεπιλεγμένα δεδομένα, την εφαρμογή των απαιτούμενων ρυθμίσεων τρισδιάστατης προβολής και την αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

## **Ορισμός των Ιδιοτήτων RotationX, RotationY και DepthPercents ενός 3D Διαγράμματος**

Το Aspose.Slides for Java παρέχει ένα απλό API για τον ορισμό αυτών των ιδιοτήτων. Το παρακάτω άρθρο θα σας βοηθήσει να ορίσετε διάφορες ιδιότητες όπως **X,Y Rotation, DepthPercents** κ.λπ. Ο κώδικας του παραδείγματος εφαρμόζει τον ορισμό των παραπάνω ιδιοτήτων.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Προσθέστε διάγραμμα με προεπιλεγμένα δεδομένα.
4. Ορίστε τις ιδιότητες Rotation3D.
5. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```java
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθήκη διαγράμματος με προεπιλεγμένα δεδομένα
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Ορισμός του δείκτη φύλλου δεδομένων διαγράμματος
    int defaultWorksheetIndex = 0;
    
    // Λήψη του φύλλου εργασίας δεδομένων διαγράμματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Προσθήκη σειρών
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Προσθήκη κατηγοριών
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Ορισμός ιδιοτήτων Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Λήψη της δεύτερης σειράς διαγράμματος
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Τώρα γεμίζουμε τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Ορισμός τιμής Overlap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Αποθήκευση παρουσίασης στο δίσκο
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν τη λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές των διαγραμμάτων στήλης, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100% Stacked Column 3D, μαζί με σχετικούς 3D τύπους που εκτίθενται μέσω της κλάσης [ChartType](https://reference.aspose.com/slides/el/java/com.aspose.slides/charttype/). Για μια ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη της κλάσης [ChartType](https://reference.aspose.com/slides/el/java/com.aspose.slides/charttype/) στην αναφορά API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω ένα ραστερ εικόνας ενός 3D διαγράμματος για αναφορά ή τον ιστό;**

Ναι. Μπορείτε να εξάγετε ένα διάγραμμα σε εικόνα μέσω του [chart API](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#getImage-int-float-float-) ή να [render the entire slide](/slides/el/java/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ακριβή προεπισκόπηση pixel‑perfect ή θέλετε να ενσωματώσετε το διάγραμμα σε έγγραφα, πίνακες ελέγχου ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3D διαγραμμάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για βέλτιστα αποτελέσματα, κρατήστε τις επιρροές 3D στο ελάχιστο, αποφύγετε βαριές υφές στους τοίχους και στις περιοχές γραφήματος, περιορίστε τον αριθμό σημείων δεδομένων ανά σειρά όταν είναι δυνατόν, και αποδίδετε σε μια εξαγωγή κατάλληλου μεγέθους (ανάλυση και διαστάσεις) ώστε να ταιριάζει με την επιδιωκόμενη οθόνη ή τις ανάγκες εκτύπωσης.