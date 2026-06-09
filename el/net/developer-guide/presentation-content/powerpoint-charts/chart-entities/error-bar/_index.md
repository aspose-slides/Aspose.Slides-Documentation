---
title: Προσαρμογή γραμμών σφάλματος σε διαγράμματα παρουσίασης στο .NET
linktitle: Γραμμή σφάλματος
type: docs
url: /el/net/error-bar/
keywords:
- γραμμή σφάλματος
- προσαρμοσμένη τιμή
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να προσθέσετε και να προσαρμόσετε γραμμές σφάλματος σε διαγράμματα με το Aspose.Slides για .NET - βελτιώστε την οπτική παρουσίαση των δεδομένων σε παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με γραμμές σφάλματος σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να προσθέσετε γραμμές σφάλματος σε μια σειρά διαγράμματος, να διαμορφώσετε τις ρυθμίσεις των γραμμών σφάλματος X και Y και να εφαρμόσετε διαφορετικούς τύπους τιμών όπως σταθερές, ποσοστιαίες και προσαρμοσμένες τιμές.

Επίσης, επιδεικνύει πώς να αντιστοιχίσετε προσαρμοσμένες τιμές γραμμών σφάλματος για μεμονωμένα σημεία δεδομένων σε μια σειρά χρησιμοποιώντας την αντίστοιχη συλλογή σημείων δεδομένων. Επιπλέον, το άρθρο περιλαμβάνει σύντομες σημειώσεις για το πώς οι γραμμές σφάλματος συμπεριφέρονται κατά την εξαγωγή, τη συμβατότητά τους με σημεία σήμανσης και ετικέτες δεδομένων, καθώς και πού μπορείτε να βρείτε τις σχετικές κλάσεις αναφοράς API και τις απαριθμήσεις.

## **Προσθήκη Γραμμών Σφάλματος**
Το Aspose.Slides for .NET παρέχει ένα απλό API για τη διαχείριση τιμών γραμμών σφάλματος. Ο κώδικας παραδείγματος εφαρμόζεται όταν χρησιμοποιείται προσαρμοσμένος τύπος τιμής. Για να καθορίσετε μια τιμή, χρησιμοποιήστε την ιδιότητα **ErrorBarCustomValues** ενός συγκεκριμένου σημείου δεδομένων στη συλλογή **DataPoints** της σειράς:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Προσθέστε ένα γράφημα φυσαλίδων στη ζητούμενη διαφάνεια.
1. Πρόσβαση στην πρώτη σειρά γραφήματος και ορισμός της μορφής της γραμμής σφάλματος X.
1. Πρόσβαση στην πρώτη σειρά γραφήματος και ορισμός της μορφής της γραμμής σφάλματος Y.
1. Ορισμός τιμών και μορφής των γραμμών.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```c#
// Δημιουργία κενής παρουσίασης
using (Presentation presentation = new Presentation())
{
    // Δημιουργία γραφήματος φυσαλίδων
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Προσθήκη γραμμών σφάλματος και ρύθμιση της μορφής τους
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // Αποθήκευση παρουσίασης
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Προσθήκη Προσαρμοσμένων Τιμών Γραμμών Σφάλματος**
Το Aspose.Slides for .NET παρέχει ένα απλό API για τη διαχείριση προσαρμοσμένων τιμών γραμμών σφάλματος. Ο κώδικας παραδείγματος εφαρμόζεται όταν η ιδιότητα **IErrorBarsFormat.ValueType** είναι ίση με **Custom**. Για να καθορίσετε μια τιμή, χρησιμοποιήστε την ιδιότητα **ErrorBarCustomValues** ενός συγκεκριμένου σημείου δεδομένων στη συλλογή **DataPoints** της σειράς:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Προσθέστε ένα γράφημα φυσαλίδων στη ζητούμενη διαφάνεια.
1. Πρόσβαση στην πρώτη σειρά γραφήματος και ορισμός της μορφής της γραμμής σφάλματος X.
1. Πρόσβαση στην πρώτη σειρά γραφήματος και ορισμός της μορφής της γραμμής σφάλματος Y.
1. Πρόσβαση στα μεμονωμένα σημεία δεδομένων της σειράς γραφήματος και ορισμός των τιμών της γραμμής σφάλματος για κάθε σημείο δεδομένων.
1. Ορισμός τιμών και μορφής των γραμμών.
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```c#
// Δημιουργία κενής παρουσίασης
using (Presentation presentation = new Presentation())
{
    // Δημιουργία γραφήματος φυσαλίδων
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Προσθήκη προσαρμοσμένων γραμμών σφάλματος και ρύθμιση της μορφής τους
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Πρόσβαση στο σημείο δεδομένων σειράς γραφήματος και ρύθμιση των τιμών των γραμμών σφάλματος για μεμονωμένο σημείο
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Ρύθμιση γραμμών σφάλματος για τα σημεία της σειράς γραφήματος
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Αποθήκευση παρουσίασης
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

## **Συχνές ερωτήσεις**

**Τι συμβαίνει με τις γραμμές σφάλματος κατά την εξαγωγή μιας παρουσίασης σε PDF ή εικόνες;**

Απεικονίζονται ως μέρος του γραφήματος και διατηρούνται κατά τη μετατροπή μαζί με την υπόλοιπη μορφοποίηση του γραφήματος, εφόσον χρησιμοποιηθεί συμβατή έκδοση ή μηχανή απόδοσης.

**Μπορούν οι γραμμές σφάλματος να συνδυαστούν με σημεία σήμανσης και ετικέτες δεδομένων;**

Ναι. Οι γραμμές σφάλματος είναι ξεχωριστό στοιχείο και είναι συμβατές με σημεία σήμανσης και ετικέτες δεδομένων· εάν τα στοιχεία επικαλύπτονται, ίσως χρειαστεί να προσαρμόσετε τη μορφοποίηση.

**Πού μπορώ να βρω τη λίστα των ιδιοτήτων και των απαριθμήσεων για τη δουλειά με τις γραμμές σφάλματος στο API;**

Στην αναφορά API: η κλάση [ErrorBarsFormat](https://reference.aspose.com/slides/el/net/aspose.slides.charts/errorbarsformat/) και οι σχετικές απαριθμήσεις [ErrorBarType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/errorbartype/) και [ErrorBarValueType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/errorbarvaluetype/).