---
title: Προσαρμογή 3D γραφημάτων σε παρουσιάσεις στο Android
linktitle: 3D Γράφημα
type: docs
url: /el/androidjava/3d-chart/
keywords:
- 3D γράφημα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε 3‑Δ γραφήματα στο Aspose.Slides για Android μέσω Java, με υποστήριξη αρχείων PPT και PPTX — ενισχύστε τις παρουσιάσεις σας σήμερα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε ένα 3D γράφημα στο Aspose.Slides ρυθμίζοντας τις παραμέτρους `Rotation3D` όπως `RotationX`, `RotationY`, `DepthPercents` και `RightAngleAxes`. Περιγράφεται η δημιουργία παρουσίασης, η προσθήκη 3D γραφήματος με προεπιλεγμένα δεδομένα, η εφαρμογή των απαιτούμενων ρυθμίσεων 3D προβολής και η αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

## **Ορίστε τις ιδιότητες RotationX, RotationY και DepthPercents ενός 3D γραφήματος**
Το Aspose.Slides for Android via Java παρέχει ένα απλό API για τον ορισμό αυτών των ιδιοτήτων. Το παρακάτω άρθρο θα σας βοηθήσει να ορίσετε διαφορετικές ιδιότητες όπως **X,Y Rotation, DepthPercents** κ.λπ. Το δείγμα κώδικα εφαρμόζει τη ρύθμιση των ανωτέρω ιδιοτήτων.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) .
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Προσθήκη γραφήματος με προεπιλεγμένα δεδομένα.
4. Ορισμός ιδιοτήτων Rotation3D.
5. Εγγραφή της τροποποιημένης παρουσίασης σε αρχείο PPTX.

```java
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθήκη γραφήματος με προεπιλεγμένα δεδομένα
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Ορισμός του δείκτη του φύλλου δεδομένων γραφήματος
    int defaultWorksheetIndex = 0;
    
    // Λήψη του φύλλου δεδομένων γραφήματος
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Προσθήκη σειράς
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
    
    // Λήψη δεύτερης σειράς γραφήματος
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Τώρα γεμίζουμε τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Ορισμός τιμής OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Αποθήκευση παρουσίασης στο δίσκο
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Ποιους τύπους γραφημάτων υποστηρίζει η λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές των ραβδογραφημάτων, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, μαζί με σχετικούς 3D τύπους που εκτίθενται μέσω της κλάσης [ChartType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/). Για μια ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/charttype/) στην τεκμηρίωση API της εγκατεστημένης έκδοσής σας.

**Μπορώ να εξάγω μια raster εικόνα ενός 3D γραφήματος για αναφορά ή τον ιστό;**

Ναι. Μπορείτε να εξάγετε ένα γράφημα σε εικόνα μέσω του [API γραφήματος](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) ή να [αποδώσετε ολόκληρη τη διαφάνεια](/slides/el/androidjava/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια τέλεια προεπισκόπηση pixel‑by‑pixel ή θέλετε να ενσωματώσετε το γράφημα σε έγγραφα, πίνακες ελέγχου ή ιστοσελίδες χωρίς την ανάγκη PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3D γραφημάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για βέλτιστα αποτελέσματα, διατηρήστε τις 3D επιδράσεις στο ελάχιστο, αποφύγετε βαριές υφές σε τοίχους και περιοχές σχεδίασης, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όπου είναι δυνατόν και αποδώστε σε κατάλληλο μέγεθος εξόδου (ανάλυση και διαστάσεις) ώστε να ταιριάζει με την προβολή ή τις ανάγκες εκτύπωσης.