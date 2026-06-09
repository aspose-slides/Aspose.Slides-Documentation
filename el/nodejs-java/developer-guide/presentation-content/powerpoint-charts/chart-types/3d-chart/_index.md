---
title: Προσαρμογή 3D γραφημάτων σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: 3D γράφημα
type: docs
url: /el/nodejs-java/3d-chart/
keywords:
- 3D γράφημα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε 3-Δ γραφήματα στο Aspose.Slides για Node.js μέσω Java, με υποστήριξη αρχείων PPT και PPTX — βελτιώστε τις παρουσιάσεις σας σήμερα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε ένα 3D γράφημα στο Aspose.Slides ρυθμίζοντας τις ρυθμίσεις `Rotation3D` όπως `RotationX`, `RotationY`, `DepthPercents` και `RightAngleAxes`. Περιγράφει τη δημιουργία μιας παρουσίασης, την προσθήκη ενός 3D γραφήματος με προεπιλεγμένα δεδομένα, την εφαρμογή των απαιτούμενων ρυθμίσεων 3D προβολής και την αποθήκευση της τροποποιημένης παρουσίασης ως αρχείο PPTX.

## **Ορισμός ιδιοτήτων RotationX, RotationY και DepthPercents του 3D γραφήματος**

Το Aspose.Slides για Node.js μέσω Java παρέχει ένα απλό API για τον ορισμό αυτών των ιδιοτήτων. Το παρακάτω άρθρο θα σας βοηθήσει να ορίσετε διαφορετικές ιδιότητες όπως **X,Y Rotation, DepthPercents** κ.λπ. Ο κώδικας δείγματος εφαρμόζει τον ορισμό των προαναφερθέντων ιδιοτήτων.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Αποκτήστε πρόσβαση στην πρώτη διαφάνεια.
3. Προσθέστε γράφημα με προεπιλεγμένα δεδομένα.
4. Ορίστε τις ιδιότητες Rotation3D.
5. Γράψτε την τροποποιημένη παρουσίαση σε ένα αρχείο PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    // Προσθήκη γραφήματος με προεπιλεγμένα δεδομένα
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Ορισμός του δείκτη φύλλου δεδομένων γραφήματος
    var defaultWorksheetIndex = 0;
    // Λήψη του φύλλου εργασίας δεδομένων γραφήματος
    var fact = chart.getChartData().getChartDataWorkbook();
    // Προσθήκη σειρών
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Προσθήκη κατηγοριών
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Ορισμός ιδιοτήτων Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Λήψη της δεύτερης σειράς γραφήματος
    var series = chart.getChartData().getSeries().get_Item(1);
    // Τώρα γεμίζουμε τα δεδομένα της σειράς
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Ορισμός τιμής OverLap
    series.getParentSeriesGroup().setOverlap(100);
    // Αποθήκευση παρουσίασης στο δίσκο
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές ερωτήσεις**

**Ποιοι τύποι γραφημάτων υποστηρίζουν τη λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές των γραφημάτων στήλης, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, μαζί με σχετικούς 3D τύπους που εκτίθενται μέσω της απαρίθμησης [ChartType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/). Για ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη της [ChartType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/charttype/) στην αναφορά API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω μια raster εικόνα ενός 3D γραφήματος για αναφορά ή το web;**

Ναι. Μπορείτε να εξάγετε ένα γράφημα σε εικόνα μέσω του [chart API](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getImage) ή να [αποδώσετε ολόκληρη τη διαφάνεια](/slides/el/nodejs-java/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια προεπισκόπηση pixel-perfect ή θέλετε να ενσωματώσετε το γράφημα σε έγγραφα, πίνακες ελέγχου ή ιστοσελίδες χωρίς την ανάγκη PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3D γραφημάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για τα καλύτερα αποτελέσματα, περιορίστε στα ελάχιστα τα εφέ 3D, αποφύγετε βαριές υφές στους τοίχους και στις περιοχές γραφήματος, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όπου είναι δυνατόν, και αποδώστε σε έξοδο κατάλληλου μεγέθους (ανάλυση και διαστάσεις) ώστε να ταιριάζει με την επιθυμητή οθόνη ή τις ανάγκες εκτύπωσης.