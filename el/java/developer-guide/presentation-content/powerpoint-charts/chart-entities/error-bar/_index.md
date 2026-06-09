---
title: Προσαρμογή Γραμμών Σφάλματος σε Διαγράμματα Παρουσίασης Χρησιμοποιώντας Java
linktitle: Γραμμή Σφάλματος
type: docs
url: /el/java/error-bar/
keywords:
- γραμμή σφάλματος
- προσαρμοσμένη τιμή
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να προσαρμόζετε γραμμές σφάλματος σε διαγράμματα με το Aspose.Slides for Java—βελτιώστε την απεικόνιση δεδομένων σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με γραμμές σφάλματος σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσθέσετε γραμμές σφάλματος σε μια σειρά διαγράμματος, να διαμορφώσετε τις ρυθμίσεις X και Y των γραμμών σφάλματος και να εφαρμόσετε διαφορετικούς τύπους τιμών όπως σταθερές, ποσοστιαίες και προσαρμοσμένες τιμές.

Επίσης, επιδεικνύει πώς να ορίσετε προσαρμοσμένες τιμές γραμμών σφάλματος για ατομικά σημεία δεδομένων σε μια σειρά χρησιμοποιώντας τη σχετική συλλογή σημείων δεδομένων. Επιπρόσθετα, το άρθρο περιλαμβάνει σύντομες σημειώσεις για τη συμπεριφορά των γραμμών σφάλματος κατά την εξαγωγή, τη συμβατότητά τους με δείκτες και ετικέτες δεδομένων, και πού να βρείτε τις σχετικές κλάσεις και enums στην αναφορά API.

## **Προσθήκη Γραμμών Σφάλματος**
Aspose.Slides for Java παρέχει ένα απλό API για τη διαχείριση τιμών γραμμών σφάλματος. Το παράδειγμα κώδικα ισχύει όταν χρησιμοποιείται προσαρμοσμένος τύπος τιμής. Για να καθορίσετε μια τιμή, χρησιμοποιήστε την ιδιότητα **ErrorBarCustomValues** ενός συγκεκριμένου σημείου δεδομένων στη συλλογή [**DataPoints**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartSeriesCollection) της σειράς:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Προσθέστε ένα διάγραμμα φυσαλίδων στη ζητούμενη διαφάνεια.
3. Πρόσβαση στην πρώτη σειρά διαγράμματος και ορισμός μορφοποίησης X των γραμμών σφάλματος.
4. Πρόσβαση στην πρώτη σειρά διαγράμματος και ορισμός μορφοποίησης Y των γραμμών σφάλματος.
5. Ορισμός τιμών και μορφοποίησης γραμμών.
6. Εγγραφή της τροποποιημένης παρουσίασης σε αρχείο PPTX.

```java
// Δημιουργία ενός αντικειμένου της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Δημιουργία διαγράμματος φυσαλίδων
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Προσθήκη γραμμών σφάλματος και ρύθμιση μορφής τους
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
Aspose.Slides for Java παρέχει ένα απλό API για τη διαχείριση προσαρμοσμένων τιμών γραμμών σφάλματος. Το παράδειγμα κώδικα ισχύει όταν η ιδιότητα [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IErrorBarsFormat#getValue--) είναι ίση με **Custom**. Για να καθορίσετε μια τιμή, χρησιμοποιήστε την ιδιότητα **ErrorBarCustomValues** ενός συγκεκριμένου σημείου δεδομένων στη συλλογή [**DataPoints**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IChartSeriesCollection) της σειράς:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Προσθέστε ένα διάγραμμα φυσαλίδων στη ζητούμενη διαφάνεια.
3. Πρόσβαση στην πρώτη σειρά διαγράμματος και ορισμός μορφοποίησης X των γραμμών σφάλματος.
4. Πρόσβαση στην πρώτη σειρά διαγράμματος και ορισμός μορφοποίησης Y των γραμμών σφάλματος.
5. Πρόσβαση στα ατομικά σημεία δεδομένων της σειράς διαγράμματος και ορισμός τιμών Γραμμής Σφάλματος για κάθε σημείο δεδομένων.
6. Ορισμός τιμών και μορφοποίησης γραμμών.
7. Εγγραφή της τροποποιημένης παρουσίασης σε αρχείο PPTX.

```java
// Δημιουργία ενός αντικειμένου της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Δημιουργία διαγράμματος φυσαλίδων
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Προσθήκη προσαρμοσμένων γραμμών σφάλματος και ρύθμιση μορφής τους
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Πρόσβαση σε σημείο δεδομένων σειράς διαγράμματος και ορισμός τιμών γραμμών σφάλματος για
    // ατομικό σημείο
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

## **Συχνές Ερωτήσεις**

**Τι συμβαίνει με τις γραμμές σφάλματος όταν εξάγετε μια παρουσίαση σε PDF ή εικόνες;**

Απόδοση ως μέρος του διαγράμματος και διατηρούνται κατά τη μετατροπή μαζί με την υπόλοιπη μορφοποίηση του διαγράμματος, υπό προϋπόθεση συμβατής έκδοσης ή μηχανής απόδοσης.

**Μπορούν οι γραμμές σφάλματος να συνδυαστούν με δείκτες και ετικέτες δεδομένων;**

Ναι. Οι γραμμές σφάλματος είναι ξεχωριστό στοιχείο και είναι συμβατές με δείκτες και ετικέτες δεδομένων· εάν τα στοιχεία επικαλύπτονται, ίσως χρειαστεί να προσαρμόσετε τη μορφοποίηση.

**Πού μπορώ να βρω τη λίστα των ιδιοτήτων και κλάσεων για εργασία με γραμμές σφάλματος στο API;**

Στην αναφορά API: η κλάση [ErrorBarsFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/errorbarsformat/) και οι σχετικές κλάσεις [ErrorBarType](https://reference.aspose.com/slides/el/java/com.aspose.slides/errorbartype/) και [ErrorBarValueType](https://reference.aspose.com/slides/el/java/com.aspose.slides/errorbarvaluetype/).