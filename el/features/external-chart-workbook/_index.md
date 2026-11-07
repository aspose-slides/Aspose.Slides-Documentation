---
title: Σύνδεση διαγραμμάτων με εξωτερικά βιβλία εργασίας
description: Σύνδεση δεδομένων διαγράμματος με εξωτερικό βιβλίο εργασίας και ανανέωση του.
type: docs
url: /el/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: διαγράμματα
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Επισκόπηση**

Δείξτε ένα διάγραμμα σε εξωτερικό βιβλίο εργασίας αντί να διατηρείτε όλα τα δεδομένα πηγής ενσωματωμένα στην παρουσίαση. Μπορείτε να ορίσετε τη διαδρομή του βιβλίου εργασίας και να επιλέξετε αν θα ενημερώνεται το διάγραμμα από αυτό το αρχείο. Το αποθηκευμένο διάγραμμα μπορεί επίσης να μεταφέρει δεδομένα εμφάνισης σε cache.

## **Παράδειγμα χρήσης**

Αυτό το παράδειγμα C# χρησιμοποιεί το Aspose.Slides for .NET. Δημιουργήστε ένα έγκυρο βιβλίο εργασίας πωλήσεων με Βόρεια = 55 και Νότια = 40 και αποθηκεύστε το ως sales.xlsx δίπλα στο αποτέλεσμα. Επαναφέρετε την τιμή Βόρεια του διαγράμματος σε 20, στη συνέχεια συνδέστε το διάγραμμα στην απόλυτη διαδρομή του βιβλίου εργασίας και ανανεώστε: η Βόρεια γίνεται ξανά 55. Η ρητή περιοχή καλύπτει την κεφαλίδα και δύο γραμμές δεδομένων. Διατηρήστε το sales.xlsx διαθέσιμο κατά το άνοιγμα ή την ενημέρωση του συνδεδεμένου διαγράμματος· η παρουσίαση δεν ενσωματώνει αυτό το εξωτερικό αρχείο. Δεν απαιτείται αρχείο εισόδου. Αποθηκεύει *external-chart-workbook.pptx* και *external-chart-workbook.png*. Εγκαταστήστε τη βιβλιοθήκη χρησιμοποιώντας τον [οδηγό εγκατάστασης](/slides/el/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **Συχνές ερωτήσεις**

### **Μπορώ να διαβάσω κάθε αποθηκευμένη τιμή όταν λείπει το συνδεδεμένο αρχείο;**

Το Aspose.Slides for .NET 26.11 μπορεί να [διαβάσει αποθηκευμένες τιμές διαγράμματος](/slides/el/net/chart-workbook/#read-cached-chart-values-without-a-workbook) απευθείας χωρίς το άνοιγμα του συνδεδεμένου βιβλίου εργασίας. Αυτό περιλαμβάνει κανονικές τιμές, τιμές X/Y, μεγέθη φυσαλίδων και τιμές κατηγοριών όταν υπάρχουν αυτά τα caches. Τα δεδομένα σε cache μπορεί να λείπουν ή να είναι παλιά· δεν αποτελούν πλήρες βιβλίο εργασίας. Η ανανέωση από την πηγή εξακολουθεί να απαιτεί διαθέσιμο υποστηριζόμενο βιβλίο εργασίας. Για άλλα SDK και εκδόσεις, ελέγξτε τον αντίστοιχο οδηγό διαγραμμάτων.

### **Τι συμβαίνει αν το εξωτερικό βιβλίο εργασίας μετακινηθεί;**

Ενημερώστε τη διαδρομή του εξωτερικού βιβλίου εργασίας του διαγράμματος στη νέα του τοποθεσία και κάντε το αρχείο διαθέσιμο όπου επεξεργάζεται η παρουσίαση. Μην βασίζεστε στα δεδομένα σε cache για πλήρεις λειτουργίες πρόσβασης δεδομένων όταν λείπουν.

### **Μπορώ να επιλέξω αν θα ανανεώσω τα αποθηκευμένα δεδομένα του διαγράμματος κατά τη σύνδεση;**

Ναι. Επιλέξτε αν θα ενημερώνετε τα δεδομένα του διαγράμματος όταν ορίζετε τη σύνδεση. Η ανανέωση απαιτεί διαθέσιμο υποστηριζόμενο βιβλίο εργασίας· η παράλειψη της ανανέωσης καταγράφει τη σύνδεση χωρίς να διαβάσει νέες τιμές από το αρχείο.

## **Οδηγοί**

- [Διαχείριση βιβλίων εργασίας διαγραμμάτων σε παρουσιάσεις στο .NET](/slides/el/net/chart-workbook/)

Σχετικό χαρακτηριστικό: [Συμπλήρωση επεξεργάσιμων διαγραμμάτων με δεδομένα](/slides/el/features/chart-data-binding/).