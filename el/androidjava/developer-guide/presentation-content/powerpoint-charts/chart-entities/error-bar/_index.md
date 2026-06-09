---
title: Προσαρμογή Γραμμών Σφάλματος σε Διαγράμματα Παρουσίασης στο Android
linktitle: Γραμμή Σφάλματος
type: docs
url: /el/androidjava/error-bar/
keywords:
- γραμμή σφάλματος
- προσαρμοσμένη τιμή
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να προσαρμόζετε τις γραμμές σφάλματος στα διαγράμματα με το Aspose.Slides για Android μέσω Java—βελτιώστε τις οπτικές παρουσίασης δεδομένων σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με γραμμές σφάλματος σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσθέσετε γραμμές σφάλματος σε μια σειρά διαγράμματος, να ρυθμίσετε τις ρυθμίσεις γραμμών σφάλματος X και Y, και να εφαρμόσετε διαφορετικούς τύπους τιμών όπως σταθερές, ποσοστιαίες και προσαρμοσμένες τιμές.

Επίσης, δείχνει πώς να ορίσετε προσαρμοσμένες τιμές γραμμών σφάλματος για μεμονωμένα σημεία δεδομένων σε μια σειρά χρησιμοποιώντας τη σχετική συλλογή σημείων δεδομένων. Επιπλέον, το άρθρο περιλαμβάνει σύντομες σημειώσεις σχετικά με το πώς συμπεριφέρονται οι γραμμές σφάλματος κατά την εξαγωγή, τη συμβατότητά τους με δείκτες και ετικέτες δεδομένων, και πού να βρείτε τις σχετικές κλάσεις και enums της αναφοράς API.

## **Προσθήκη Γραμμών Σφάλματος**
Aspose.Slides για Android μέσω Java παρέχει ένα απλό API για τη διαχείριση τιμών γραμμών σφάλματος. Ο κώδικας δείγματος ισχύει όταν χρησιμοποιείται προσαρμοσμένος τύπος τιμής. Για να ορίσετε μια τιμή, χρησιμοποιήστε την ιδιότητα **ErrorBarCustomValues** ενός συγκεκριμένου σημείου δεδομένων στη συλλογή [**DataPoints**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChartSeriesCollection) της σειράς:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Προσθέστε ένα διάγραμμα φυσαλίδας στη επιθυμητή διαφάνεια.
1. Αποκτήστε πρόσβαση στην πρώτη σειρά διαγράμματος και ορίστε τη μορφή γραμμής σφάλματος X.
1. Αποκτήστε πρόσβαση στην πρώτη σειρά διαγράμματος και ορίστε τη μορφή γραμμής σφάλματος Y.
1. Ορισμός τιμών και μορφής των γραμμών.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Δημιουργία διαγράμματος φυσαλίδας
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Προσθήκη γραμμών σφάλματος και ορισμός της μορφής τους
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Αποθήκευση παρουσίασης
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Προσθήκη Προσαρμοσμένων Τιμών Γραμμών Σφάλματος**
Aspose.Slides για Android μέσω Java παρέχει ένα απλό API για τη διαχείριση προσαρμοσμένων τιμών γραμμών σφάλματος. Ο κώδικας δείγματος ισχύει όταν η ιδιότητα [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) είναι ίση με **Custom**. Για να ορίσετε μια τιμή, χρησιμοποιήστε την ιδιότητα **ErrorBarCustomValues** ενός συγκεκριμένου σημείου δεδομένων στη συλλογή [**DataPoints**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IChartSeriesCollection) της σειράς:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Προσθέστε ένα διάγραμμα φυσαλίδας στη επιθυμητή διαφάνεια.
1. Αποκτήστε πρόσβαση στην πρώτη σειρά διαγράμματος και ορίστε τη μορφή γραμμής σφάλματος X.
1. Αποκτήστε πρόσβαση στην πρώτη σειρά διαγράμματος και ορίστε τη μορφή γραμμής σφάλματος Y.
1. Αποκτήστε πρόσβαση στα μεμονωμένα σημεία δεδομένων της σειράς διαγράμματος και ορίστε τις τιμές γραμμής σφάλματος για κάθε σημείο δεδομένων.
1. Ορισμός τιμών και μορφής των γραμμών.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```java
// Δημιουργήστε μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Δημιουργία διαγράμματος φυσαλίδας
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Προσθήκη προσαρμοσμένων γραμμών σφάλματος και ορισμός της μορφής τους
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Πρόσβαση σε σημείο δεδομένων σειράς διαγράμματος και ορισμός τιμών γραμμών σφάλματος για
    // μεμονωμένο σημείο
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Ορισμός γραμμών σφάλματος για σημεία σειράς διαγράμματος
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Αποθήκευση παρουσίασης
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Τι συμβαίνει με τις γραμμές σφάλματος όταν εξάγετε μια παρουσίαση σε PDF ή εικόνες;**

Απεικονίζονται ως μέρος του διαγράμματος και διατηρούνται κατά τη μετατροπή μαζί με την υπόλοιπη μορφοποίηση του διαγράμματος, εφόσον υπάρχει συμβατή έκδοση ή μηχανή απόδοσης.

**Μπορούν οι γραμμές σφάλματος να συνδυαστούν με δείκτες και ετικέτες δεδομένων;**

Ναι. Οι γραμμές σφάλματος είναι ξεχωριστό στοιχείο και είναι συμβατές με δείκτες και ετικέτες δεδομένων· εάν τα στοιχεία επικαλύπτονται, ενδέχεται να χρειαστεί να προσαρμόσετε τη μορφοποίηση.

**Πού μπορώ να βρω τη λίστα των ιδιοτήτων και κλάσεων για εργασία με γραμμές σφάλματος στο API;**

Στην αναφορά API: η κλάση [ErrorBarsFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/errorbarsformat/) και οι σχετικές κλάσεις [ErrorBarType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/errorbartype/) και [ErrorBarValueType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/errorbarvaluetype/).