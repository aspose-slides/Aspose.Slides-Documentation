---
title: Προσαρμογή Γραμμών Σφάλματος σε Διαγράμματα Παρουσίασης με JavaScript
linktitle: Γραμμή Σφάλματος
type: docs
url: /el/nodejs-java/error-bar/
keywords:
- γραμμή σφάλματος
- προσαρμοσμένη τιμή
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να προσαρμόζετε γραμμές σφάλματος σε διαγράμματα με JavaScript και Aspose.Slides για Node.js μέσω Java—βελτιώστε τις οπτικές απεικονίσεις δεδομένων σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με γραμμές σφάλματος σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσθέσετε γραμμές σφάλματος σε μια σειρά διαγράμματος, να ρυθμίσετε τις ρυθμίσεις γραμμής σφάλματος X και Y, και να εφαρμόσετε διαφορετικούς τύπους τιμών όπως σταθερές, ποσοστιαίες και προσαρμοσμένες τιμές.

Δείχνει επίσης πώς να αντιστοιχίσετε προσαρμοσμένες τιμές γραμμής σφάλματος για μεμονωμένα σημεία δεδομένων σε μια σειρά χρησιμοποιώντας τη αντίστοιχη συλλογή σημείων δεδομένων. Επιπλέον, το άρθρο περιλαμβάνει σύντομες σημειώσεις για το πώς συμπεριφέρονται οι γραμμές σφάλματος κατά την εξαγωγή, τη συμβατότητά τους με τα σημεία σήμανσης και τις ετικέτες δεδομένων, καθώς και πού μπορείτε να βρείτε τις σχετικές κλάσεις και τις απαριθμήσεις αναφοράς API.

## **Προσθήκη γραμμής σφάλματος**

Aspose.Slides for Node.js via Java παρέχει ένα απλό API για τη διαχείριση τιμών γραμμής σφάλματος. Ο κώδικας παραδείγματος εφαρμόζεται όταν χρησιμοποιείται προσαρμοσμένος τύπος τιμής. Για να καθορίσετε μια τιμή, χρησιμοποιήστε την ιδιότητα **ErrorBarCustomValues** ενός συγκεκριμένου σημείου δεδομένων στη συλλογή [**DataPoints**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartSeriesCollection) της σειράς:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Προσθέστε ένα διάγραμμα φούσκας στη ζητηθείσα διαφάνεια.
1. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή της γραμμής σφάλματος X.
1. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή της γραμμής σφάλματος Y.
1. Ορίστε τις τιμές των γραμμών και τη μορφοποίησή τους.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```javascript
// Δημιουργήστε μια παρουσία της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Δημιουργία διαγράμματος φούσκας
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Προσθήκη γραμμών σφάλματος και ρύθμιση της μορφής τους
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Αποθήκευση παρουσίασης
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Προσθήκη προσαρμοσμένης τιμής γραμμής σφάλματος**

Aspose.Slides for Node.js via Java παρέχει ένα απλό API για τη διαχείριση προσαρμοσμένων τιμών γραμμής σφάλματος. Ο κώδικας παραδείγματος εφαρμόζεται όταν η ιδιότητα [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) είναι ίση με **Custom**. Για να καθορίσετε μια τιμή, χρησιμοποιήστε την ιδιότητα **ErrorBarCustomValues** ενός συγκεκριμένου σημείου δεδομένων στη συλλογή [**DataPoints**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ChartSeriesCollection) της σειράς:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
1. Προσθέστε ένα διάγραμμα φούσκας στη ζητηθείσα διαφάνεια.
1. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή της γραμμής σφάλματος X.
1. Προσπελάστε την πρώτη σειρά διαγράμματος και ορίστε τη μορφή της γραμμής σφάλματος Y.
1. Προσπελάστε τα μεμονωμένα σημεία δεδομένων της σειράς και ορίστε τις τιμές γραμμής σφάλματος για κάθε σημείο.
1. Ορίστε τις τιμές των γραμμών και τη μορφοποίησή τους.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```javascript
// Δημιουργήστε μια παρουσία της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Δημιουργία διαγράμματος φούσκας
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Προσθήκη προσαρμοσμένων γραμμών σφάλματος και ρύθμιση της μορφής τους
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Πρόσβαση στο σημείο δεδομένων της σειράς διαγράμματος και ορισμός τιμών γραμμών σφάλματος για
    // μεμονωμένο σημείο
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Ορισμός γραμμών σφάλματος για τα σημεία της σειράς διαγράμματος
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Αποθήκευση παρουσίασης
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές ερωτήσεις**

**Τι συμβαίνει με τις γραμμές σφάλματος όταν εξάγετε μια παρουσίαση σε PDF ή εικόνες;**

Απαντώνται ως μέρος του διαγράμματος και διατηρούνται κατά τη μετατροπή μαζί με την υπόλοιπη μορφοποίηση του διαγράμματος, εφόσον χρησιμοποιείται συμβατή έκδοση ή μηχανή απόδοσης.

**Μπορούν οι γραμμές σφάλματος να συνδυαστούν με σημεία σήμανσης και ετικέτες δεδομένων;**

Ναι. Οι γραμμές σφάλματος είναι ξεχωριστό στοιχείο και είναι συμβατές με σημεία σήμανσης και ετικέτες δεδομένων· εάν τα στοιχεία επικαλύπτονται, ίσως χρειαστεί να προσαρμόσετε τη μορφοποίηση.

**Πού μπορώ να βρω τη λίστα των ιδιοτήτων και των απαριθμήσεων για τη χρήση των γραμμών σφάλματος στο API;**

Στην αναφορά API: η κλάση [ErrorBarsFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/errorbarsformat/) και οι σχετικές απαριθμήσεις [ErrorBarType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/errorbartype/) και [ErrorBarValueType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/errorbarvaluetype/).