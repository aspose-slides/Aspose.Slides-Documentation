---
title: Εφαρμογή Τύπων Φύλλου Εργασίας Διαγραμμάτων σε Παρουσιάσεις σε .NET
linktitle: Τύποι Φύλλου Εργασίας
type: docs
weight: 70
url: /el/net/chart-worksheet-formulas/
keywords:
- λογιστικό φύλλο διαγράμματος
- φύλλο εργασίας διαγράμματος
- τύπος διαγράμματος
- τύπος φύλλου εργασίας
- τύπος υπολογιστικού φύλλου
- βιβλίο δεδομένων διαγράμματος
- υπολογισμός τύπου
- προτιμώμενος πολιτισμός
- τύπος ειδικού πολιτισμού
- DBCS
- λογική σταθερά
- αριθμητική σταθερά
- σταθερά συμβολοσειράς
- σταθερά σφάλματος
- αριθμητικός τελεστής
- τελεστής σύγκρισης
- στυλ A1
- στυλ R1C1
- προκαθορισμένη συνάρτηση
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εφαρμογή τύπων τύπου Excel σε φύλλα εργασίας διαγραμμάτων Aspose.Slides για .NET, επανυπολογισμός τιμών και χρήση των αποτελεσμάτων στα διαγράμματα PowerPoint."
---
## **Επισκόπηση**

Τα διαγράμματα του PowerPoint συνήθως αποθηκεύουν τα αρχικά τους δεδομένα σε ένα ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides για .NET, μπορείτε να έχετε πρόσβαση σε αυτό το φύλλο μέσω του βιβλίου εργασίας δεδομένων διαγράμματος, να γράψετε τιμές εισόδου, να αντιστοιχίσετε τύπους σε κελιά, να υπολογίσετε τους υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα διαγράμματος.

Αυτό το άρθρο εξηγεί τη πλήρη ροή εργασίας τύπων: δημιουργία διαγράμματος, πληρότητα του φύλλου εργασίας, ανάθεση τύπων τύπου A1 ή R1C1, επανυπολογισμός τους, ανάγνωση των υπολογισμένων τιμών, σύνδεση αυτών των κελιών με μια σειρά διαγράμματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη συντακτική υποστήριξη τύπων, το ενσωματωμένο υποσύνολο συναρτήσεων, τις αποθηκευμένες τιμές, τους μη υποστηριζόμενους τύπους και τα σφάλματα ειδικά για λογιστικά φύλλα.

## **Φύλλα Εργασίας Διαγράμματος και Τύποι**

Ένα φύλλο εργασίας διαγράμματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιούνται από ένα διάγραμμα. Στο PowerPoint, μπορείτε να εξετάσετε το φύλλο ανοίγοντας τον επεξεργαστή δεδομένων διαγράμματος:

![Διάγραμμα PowerPoint με ανοιχτό το ενσωματωμένο φύλλο εργασίας, εμφανίζοντας δεδομένα κατηγοριών και σειρών](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εκτίθεται μέσω του [chart data workbook](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/). Χρησιμοποιήστε την ιδιότητα [Formula](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/formula/) για τύπους στυλ A1 και την ιδιότητα [R1C1Formula](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/r1c1formula/) για τύπους στυλ R1C1. Αφού αλλάξετε κελιά εισόδου ή τύπους, καλέστε [CalculateFormulas](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) για να επανυπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω της ιδιότητας [Value](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/value/). Αυτό είναι σημαντικό όταν χρειάζεται να εξετάσετε το αποτέλεσμα ενός τύπου στον κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων διαγράμματος.

## **Δημιουργία Διαγράμματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το παρακάτω παράδειγμα δείχνει μια ολοκληρωμένη ροή εργασίας. Δημιουργεί ένα διάγραμμα στήλης με ομάδες, διαγράφει τα δείγματα δεδομένων, γράφει τριμηνιαίες τιμές εσόδων και εξόδων, υπολογίζει το κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές διαγράμματος και αποθηκεύει την παρουσίαση.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

Τα σημεία δεδομένων του διαγράμματος αναφέρονται στο `D2:D4`, έτσι το διάγραμμα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση για ανανέωση του διαγράμματος σε αυτή τη ροή: επανυπολογίστε πρώτα το βιβλίο εργασίας, έπειτα χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα διαγράμματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων Στυλ A1**

Η σημειογραφία A1 προσδιορίζει τις στήλες με γράμματα και τις γραμμές με αριθμούς. Αναθέστε εκφράσεις στυλ A1 μέσω του [IChartDataCell.Formula](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

Κοινές μορφές αναφοράς A1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Κελί | `A2` | `$A$2` | `A$2`, `$A2` |
| Γραμμή | `2:2` | `$2:$2` | — |
| Στήλη | `A:A` | `$A:$A` | — |
| Περιοχή | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινείται ή αντιγράφεται από ένα λογιστικό φύλλο. Οι απόλυτες αναφορές κρατούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές κρατούν μόνο μια γραμμή ή μια στήλη σταθερή.

## **Χρήση Τύπων Στυλ R1C1**

Η σημειογραφία R1C1 προσδιορίζει τόσο τις γραμμές όσο και τις στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε αγκύλες. Αναθέστε αυτή τη σύνταξη μέσω του [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

Κοινές μορφές αναφοράς R1C1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Κελί | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Γραμμή | `R[2]` | `R2` | — |
| Στήλη | `C[3]` | `C3` | — |
| Περιοχή | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια γραμμή δύο στήλες αριστερά (`B2`).

## **Σταθερές Τύπων και Τελεστές**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικά λογικά, συμβολοσειρές, τιμές σφάλματος λογιστικού φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Λογοτύπων**

| Τύπος | Παραδείγματα | Σημειώσεις |
|---|---|---|
| Λογική | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί απευθείας σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητική | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται κοινή και επιστημονική σημειογραφία. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Οι λεκτικές σταθερές περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Αποτέλεσμα σφάλματος | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί σε τιμή σφάλματος λογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί διάφορους τύπους σταθερών:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // Ψευδές
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Αριθμητικοί Τελεστές**

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `+` | Πρόσθεση ή μοναδικό θετικό | `2+3` |
| `-` | Αφαίρεση ή αρνητικό | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Εκθέτης | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να κάνετε ρητή τη σειρά αξιολόγησης, π.χ. `(A2+B2)*C2`.

### **Τελεστές Σύγκρισης**

Οι εκφράσεις σύγκρισης επιστρέφουν λογικές τιμές.

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ισοδυναμία | `A2=3` |
| `<>` | Μη ισοδυναμία | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας διαγράμματος, αλλά δεν είναι πλήρης μηχανή υπολογισμού Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται στις παρακάτω. Μην υποθέετε ότι ένας αυθαίρετος τύπος Excel μπορεί να επανυπολογιστεί από το [CalculateFormulas](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής με δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συνένωση κειμένων | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συνένωση κειμένων | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας με σύστημα 1900 | `DATE(2026,8,19)` |
| `DAYS` | Πλήθος ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εύρεση μιας τιμής κειμένου μέσα σε άλλη | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου ανά byte | `FINDB("a",A2)` |
| `IF` | Συνθήκη | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Μορφή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Μορφή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροισμα | `SUM(B2:B5)` |
| `VLOOKUP` | Κάθετη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί στον πίνακα είναι σημαντικοί: το `INDEX` τεκμηριώνεται σε μορφή αναφοράς, ενώ το `LOOKUP` και το `MATCH` σε μορφές διανύσματος. Το `DATE` χρησιμοποιεί το σύστημα 1900. Λειτουργίες που δεν αναφέρονται εδώ πρέπει να θεωρούνται μη υποστηριζόμενες από τον αξιολογητή τύπων του Aspose.Slides, εκτός εάν τεκμηριώνονται ξεχωριστά.

## **Υπολογισμός Τύπων με Προτιμώμενο Πολιτισμό**

Μερικές λειτουργίες του βιβλίου εργασίας διαγράμματος ερμηνεύουν το κείμενο σύμφωνα με κανόνες πολιτισμού. Αυτό είναι ιδιαίτερα σημαντικό για συναρτήσεις που προορίζονται για γλώσσες με σύνολα χαρακτήρων διπλού byte (DBCS). Για σωστό υπολογισμό, δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/), ορίστε το [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/el/net/aspose.slides/ispreadsheetoptions/preferredculture/) μέσω του [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/spreadsheetoptions/), και έπειτα φορτώστε την παρουσίαση.

Το παρακάτω παράδειγμα επιλέγει τον Ιαπωνικό πολιτισμό, ανοίγει μια παρουσίαση με τις ρυθμισμένες επιλογές φόρτωσης και καλεί το [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) για κάθε βιβλίο εργασίας διαγράμματος:

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

Ο προτιμώμενο πολιτισμός αποτελεί μέρος της διαμόρφωσης φόρτωσης της παρουσίασης, επομένως ορίστε τον πριν δημιουργήσετε το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Χρησιμοποιήστε τον πολιτισμό που αναμένεται από τους τύπους του βιβλίου εργασίας· για παράδειγμα, `ja-JP` για τύπους που πρέπει να ακολουθούν τους Ιαπωνικούς κανόνες DBCS.

## **Επαναϋπολογισμός και Αποθηκευμένες Τιμές**

Τα αρχεία λογιστικών φύλλων συνήθως αποθηκεύουν τόσο τον τύπο όσο και την τελευταία υπολογισμένη τιμή του. Το Aspose.Slides μπορεί επομένως να διαβάσει μια αποθηκευμένη τιμή από το [IChartDataCell.Value](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/value/) όταν φορτώνεται η παρουσίαση και τα σχετικά δεδομένα διαγράμματος δεν έχουν τροποποιηθεί.

Αφού αλλάξετε κελιά εισόδου ή τύπους, μην βασίζεστε σε παλιά αποθηκευμένα αποτελέσματα. Καλέστε το [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) πριν διαβάσετε υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα διαγράμματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποστηριζόμενου υποσυνόλου, το Aspose.Slides ίσως να μην μπορέσει να αναλύσει τον τύπο ή να εντοπίσει τις εξαρτήσεις του. Εάν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη αποθηκευμένη τιμή δεν μπορεί πλέον να θεωρηθεί αξιόπιστη. Σε αυτήν την περίπτωση, η ανάγνωση της τιμής ενός κελιού με μη υποστηριζόμενα δεδομένα μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Εάν το διάγραμμά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε αυτούς τους τύπους με μια μηχανή λογιστικού φύλλου που τους υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο βιβλίο εργασίας διαγράμματος. Μην αντικαθιστάτε τους μη υποστηριζόμενους τύπους με εικαστικές τιμές.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικά είδη προβλημάτων που πρέπει να διακρίνετε.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει σφάλμα λογιστικού φύλλου όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτήν την περίπτωση, το token σφάλματος είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του `Value`.

Ένας τύπος μπορεί επίσης να αποτύχει κατά την ανάλυση, την αναφορά, την εξάρτηση ή το επίπεδο υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει εξαιρέσεις ειδικές για λογιστικά φύλλα: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή εισροή χρήστη, διαχειριστείτε αυτές τις εξαιρέσεις γύρω από τον επανυπολογισμό και την πρόσβαση στην τιμή:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Πρακτικοί Περιορισμοί**

Η υποστήριξη τύπων στα φύλλα εργασίας διαγράμματος προορίζεται για ένα περιορισμένο υποσύνολο υπολογισμών λογιστικών φύλλων, όχι για πλήρη συμβατότητα με το Excel. Λάβετε υπόψη αυτούς τους περιορισμούς κατά το σχεδιασμό μιας ροής εργασίας αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεται το Aspose.Slides να επανυπολογίσει τύπους.
- Επαναϋπολογίστε μετά την αλλαγή των κελιών από τα οποία εξαρτώνται τα αποτελέσματα των τύπων.
- Θεωρήστε τις αποθηκευμένες τιμές από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως αντικατάσταση του επανυπολογισμού μετά από τροποποιήσεις.
- Δοκιμάστε τους τύπους από υπάρχοντα πρότυπα πριν βασιστείτε στις υπολογισμένες τιμές τους, ιδιαίτερα όταν χρησιμοποιούν συναρτήσεις εκτός της τεκμηριωμένης λίστας.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού λογιστικού φύλλου, υπολογίστε τους εξωτερικά και κατόπιν ενημερώστε το βιβλίο εργασίας διαγράμματος με τις προεξόφλητες τιμές.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ `Formula` και `R1C1Formula`;**

[Formula](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/formula/) αποθηκεύει μια έκφραση στυλ A1 όπως `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/r1c1formula/) αποθηκεύει μια έκφραση στυλ R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειογραφία που ταιριάζει καλύτερα στον τρόπο που δημιουργείτε ή αντιγράφετε τύπους.

**Πρέπει να διαβάσω το κελί ίδιο ή την τιμή του μετά τον υπολογισμό;**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/getcell/) επιστρέφει ένα `IChartDataCell`. Για να λάβετε το υπολογισμένο αποτέλεσμα, διαβάστε την ιδιότητα [Value](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/value/) του κελιού μετά τον επανυπολογισμό.

**Πότε πρέπει να καλέσω το `CalculateFormulas`;**

Καλέστε το [CalculateFormulas](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν εξαρτηθείτε από τα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζει ο ενσωματωμένος αξιολογητής.

**Υποστηρίζει το Aspose.Slides κάθε συνάρτηση του Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Οι συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να θεωρούνται ότι επανυπολογίζονται σωστά. Εάν απαιτείται πλήρης συμβατότητα τύπων Excel, εκτελέστε τον υπολογισμό με μια κατάλληλη μηχανή λογιστικού φύλλου και γράψτε τις τελικές τιμές στο βιβλίο εργασίας διαγράμματος.

**Τι συμβαίνει εάν μια φορτωμένη παρουσίαση περιέχει μη υποστηριζόμενο τύπο;**

Αν τα δεδομένα διαγράμματος δεν έχουν αλλάξει, το βιβλίο εργασίας μπορεί ακόμη να περιέχει μια προηγουμένως υπολογισμένη αποθηκευμένη τιμή. Μετά την τροποποίηση των σχετικών δεδομένων, αυτή η αποθηκευμένη τιμή μπορεί να μην είναι πλέον έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να αντιμετωπιστεί μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Είναι οι τιμές σφάλματος τύπου ίδιες με τις εξαιρέσεις .NET;**

Όχι. Ένα αποτέλεσμα όπως `#DIV/0!` είναι τιμή λογιστικού φύλλου που παράγεται από έγκυρο υπολογισμό. Εξαιρέσεις όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) υποδεικνύουν ότι ο τύπος δεν μπορεί να επεξεργαστεί κανονικά.

**Ενημερώνεται το διάγραμμα αυτόματα όταν αλλάζει ένα κελί τύπου;**

Μια σειρά διαγράμματος μπορεί να αναφέρεται σε κελιά βιβλίου εργασίας. Επαναϋπολογίστε πρώτα το βιβλίο εργασίας, έπειτα αποθηκεύστε ή αποδώστε την παρουσίαση. Εάν τα σημεία δεδομένων του διαγράμματος αναφέρονται στα υπολογισμένα κελιά, το διάγραμμα χρησιμοποιεί αυτές τις ενημερωμένες τιμές· δεν απαιτείται ξεχωριστή μέθοδος ανανέωσης διαγράμματος για αυτή τη ροή.

**Μπορούν τα διαγράμματα να χρησιμοποιούν εξωτερικό βιβλίο εργασίας Excel;**

Ναι, τα δεδομένα διαγράμματος μπορούν να ρυθμιστούν να χρησιμοποιούν εξωτερικό βιβλίο εργασίας μέσω του API δεδομένων διαγράμματος. Ωστόσο, η ροή υπολογισμού τύπων που περιγράφεται σ' αυτό το άρθρο αφορά το βιβλίο εργασίας δεδομένων διαγράμματος και το υποσύνολο τύπων που αξιολογείται από το Aspose.Slides. Μην υποθέετε ότι το [CalculateFormulas](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) παρέχει πλήρη επανυπολογισμό αυθαίρετων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο ή βιβλίο εργασίας;**

Οι αναφορές τύπων τύπου Excel μπορεί να υπάρχουν σε βιβλία εργασίας διαγράμματος, αλλά η αξιολόγηση περιορίζεται από τον υποστηριζόμενο αναλυτή και το σύνολο των συναρτήσεων. Εάν μια διασύνδεση φύλλου ή εξωτερική αναφορά είναι απαραίτητη, επικυρώστε τον ακριβή τύπο με την έκδοση του Aspose.Slides που χρησιμοποιείτε. Για ροές εργασίας που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το βιβλίο εργασίας εξωτερικά και γράψτε τις επιλυμένες τιμές πίσω στα δεδομένα διαγράμματος.

**Θα πρέπει οι συμβολοσειρές τύπων να ξεκινούν με `=`;**

Τα παραδείγματα του API Aspose.Slides αναθέτουν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς πρώτο `=`. Η χρήση αυτής της μορφής διατηρεί τους παραγόμενους τύπους συνεπείς με τα τεκμηριωμένα παραδείγματα API.