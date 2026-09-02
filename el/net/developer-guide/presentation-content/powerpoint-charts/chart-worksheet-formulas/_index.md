---
title: Εφαρμογή Τύπων Φύλλου Εργασίας Διαγράμματος σε Παρουσιάσεις στο .NET
linktitle: Τύποι Φύλλου Εργασίας
type: docs
weight: 70
url: /el/net/chart-worksheet-formulas/
keywords:
- διάγραμμα υπολογιστικό φύλλο
- φύλλο εργασίας διαγράμματος
- τύπος διαγράμματος
- τύπος φύλλου εργασίας
- τύπος υπολογιστικού φύλλου
- βιβλίο δεδομένων διαγράμματος
- υπολογισμός τύπου
- λογική σταθερά
- αριθμητική σταθερά
- συμβολοσειρά σταθερά
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
description: "Εφαρμόστε τύπους τύπου Excel σε φύλλα εργασίας διαγράμματος Aspose.Slides για .NET, επανυπολογίστε τιμές και χρησιμοποιήστε τα αποτελέσματα σε διαγράμματα PowerPoint."
---
## **Επισκόπηση**

Τα διαγράμματα PowerPoint συνήθως αποθηκεύουν τα δεδομένα πηγής τους σε ένα ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides για .NET, μπορείτε να έχετε πρόσβαση σε αυτό το φύλλο μέσω του βιβλίου δεδομένων διαγράμματος, να γράψετε τιμές εισόδου, να εκχωρήσετε τύπους σε κελιά, να υπολογίσετε τους υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα διαγράμματος.

Αυτό το άρθρο εξηγεί την πλήρη διαδικασία τύπων: δημιουργία διαγράμματος, γέμισμα του φύλλου εργασίας, εκχώρηση τύπων σε μορφή A1 ή R1C1, επανυπολογισμός τους, ανάγνωση των υπολογισμένων τιμών, σύνδεση αυτών των κελιών με σειρά διαγράμματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη σύνταξη των υποστηριζόμενων τύπων, το ενσωματωμένο υποσύνολο συναρτήσεων, τις προσωρινές τιμές, τους μη υποστηριζόμενους τύπους και τα σφάλματα του υπολογιστικού φύλλου.

## **Φύλλα Εργασίας Διαγραμμάτων και Τύποι**

Ένα φύλλο εργασίας διαγράμματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιεί ένα διάγραμμα. Στο PowerPoint, μπορείτε να ελέγξετε το φύλλο ανοίγοντας τον επεξεργαστή δεδομένων διαγράμματος:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εκτίθεται μέσω του [βιβλίου δεδομένων διαγράμματος](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/). Χρησιμοποιήστε την ιδιότητα [Formula](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/formula/) για τύπους στυλ A1 και την ιδιότητα [R1C1Formula](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/r1c1formula/) για τύπους στυλ R1C1. Μετά την αλλαγή των κελιών εισόδου ή των τύπων, καλέστε [CalculateFormulas](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) για να επανυπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω της ιδιότητας [Value](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/value/). Αυτό είναι σημαντικό όταν χρειάζεται να ελέγξετε το αποτέλεσμα ενός τύπου στον κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων διαγράμματος.

## **Δημιουργία Διαγράμματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το ακόλουθο παράδειγμα δείχνει μια ολοκληρωμένη ροή εργασίας. Δημιουργεί ένα συγκεντρωτικό διάγραμμα στηλών, καθαρίζει τα δείγματα δεδομένων, γράφει τριμηνιαίες τιμές εσόδων και εξόδων, υπολογίζει το κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές διαγράμματος και αποθηκεύει την παρουσίαση.

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

Τα σημεία δεδομένων του διαγράμματος αναφέρονται στο `D2:D4`, έτσι το διάγραμμα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ενημέρωσης διαγράμματος σε αυτή τη ροή: επανυπολογίστε πρώτα το βιβλίο εργασίας, στη συνέχεια χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα διαγράμματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων στυλ A1**

Η σημειογραφία A1 προσδιορίζει τις στήλες με γράμματα και τις γραμμές με αριθμούς. Εκχωρήστε εκφράσεις στυλ A1 μέσω του [IChartDataCell.Formula](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/formula/).

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

| Αναφορά | Σχετικό | Απόλυτο | Μικτό |
|---|---|---|---|
| Κελί | `A2` | `$A$2` | `A$2`, `$A2` |
| Γραμμή | `2:2` | `$2:$2` | — |
| Στήλη | `A:A` | `$A:$A` | — |
| Περιοχή | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινείται ή αντιγράφεται από το υπολογιστικό φύλλο. Οι απόλυτες αναφορές κρατούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές κρατούν μόνο μια γραμμή ή στήλη σταθερή.

## **Χρήση Τύπων στυλ R1C1**

Η σημειογραφία R1C1 προσδιορίζει και τις γραμμές και τις στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε αγκύλες. Εκχωρήστε αυτή τη σύνταξη μέσω του [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

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

| Αναφορά | Σχετικό | Απόλυτο | Μικτό |
|---|---|---|---|
| Κελί | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Γραμμή | `R[2]` | `R2` | — |
| Στήλη | `C[3]` | `C3` | — |
| Περιοχή | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια γραμμή δύο στήλες αριστερά (`B2`).

## **Σταθερές Τύπων και Τελεστές**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικές κυριολεκτικές, συμβολοσειρές, τιμές σφάλματος του φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Κυριολεκτικά**

| Τύπος | Παραδείγματα | Σημειώσεις |
|---|---|---|
| Λογικό | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί άμεσα σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητικό | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται η κοινή και η επιστημονική σημειογραφία. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Κυριολεκτικά κείμενα περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Αποτέλεσμα σφάλματος | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αποτιμηθεί σε τιμή σφάλματος του υπολογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί πολλούς τύπους σταθερών:

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
| `+` | Πρόσθεση ή μονός θετικός | `2+3` |
| `-` | Αφαίρεση ή αρνητικό | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Εκθέτης | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να κάνετε ρητό το порядок εκτίμησης, π.χ. `(A2+B2)*C2`.

### **Τελεστές Σύγκρισης**

Οι εκφράσεις σύγκρισης επιστρέφουν λογικές τιμές.

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ίσο με | `A2=3` |
| `<>` | Διαφορετικό από | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο με | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο με | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει έναν ενσωματωμένο αξιολογητή τύπων για φύλλα διαγραμμάτων, αλλά δεν είναι πλήρης μηχανή υπολογισμού Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται στις παρακάτω. Μην υποθέτετε ότι ένας τυχαίος τύπος Excel μπορεί να επανυπολογιστεί με το [CalculateFormulas](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Μέσος όρος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση αριθμού προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής με δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συγκόλληση κειμένων | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συγκόλληση κειμένων | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας με σύστημα 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστρέφει τον αριθμό ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εύρεση ενός κειμένου μέσα σε άλλο | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου σε επίπεδο byte | `FINDB("a",A2)` |
| `IF` | Συνθηματικό αποτέλεσμα | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Μορφή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Μορφή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροιση τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κάθετη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί στον πίνακα είναι ουσιώδεις: το `INDEX` τεκμηριώνεται σε μορφή αναφοράς, ενώ τα `LOOKUP` και `MATCH` σε μορφή διανύσματος. Το `DATE` χρησιμοποιεί σύστημα 1900. Λειτουργίες που δεν αναγράφονται εδώ θεωρούνται μη υποστηριζόμενες από τον αξιολογητή τύπων Aspose.Slides, εκτός εάν τεκμηριώνονται ξεχωριστά.

## **Επαναϋπολογισμός και Προσωρινές Τιμές**

Τα αρχεία υπολογιστικού φύλλου συχνά αποθηκεύουν τόσο τον τύπο όσο και την τελευταία υπολογισμένη τιμή του. Το Aspose.Slides μπορεί επομένως να διαβάσει μια προσωρινή τιμή από το [IChartDataCell.Value](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/value/) όταν φορτώνεται μια παρουσίαση και τα σχετικά δεδομένα διαγράμματος δεν έχουν αλλάξει.

Μετά την αλλαγή κελιών εισόδου ή τύπων, μην βασίζεστε σε παλιά προσωρινή τιμή. Καλέστε το [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα διαγράμματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποστηριζόμενου υποσυνόλου, το Aspose.Slides ενδέχεται να μην μπορεί να αναλύσει τον τύπο ή να προσδιορίσει τις εξαρτήσεις του. Αν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη προσωρινή τιμή δεν μπορεί πια να θεωρηθεί αξιόπιστη. Σε αυτήν την περίπτωση, η ανάγνωση της τιμής ενός κελιού με μη υποστηριζόμενο δεδομένο μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Αν το διάγραμμά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε εκείνους τους τύπους με μια μηχανή υπολογιστικού φύλλου που τους υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο βιβλίο εργασίας του διαγράμματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με εικαστικές τιμές.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικά είδη προβλημάτων που πρέπει να διακρίνετε.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει αποτέλεσμα σφάλματος του φύλλου, όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτή την περίπτωση, το σήμα σφάλματος είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του `Value`.

Ένας τύπος μπορεί επίσης να αποτύχει κατά την ανάλυση, την αναφορά, την εξάρτηση ή στο επίπεδο των υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει εξειδικευμένες εξαιρέσεις φύλλου για αυτές τις περιπτώσεις: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή από είσοδο χρήστη, χειριστείτε αυτές τις εξαιρέσεις γύρω από τον επανυπολογισμό και την πρόσβαση τιμών:

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

Η υποστήριξη τύπων στα φύλλα διαγραμμάτων προορίζεται για ένα καθορισμένο υποσύνολο υπολογισμών φύλλου, όχι για πλήρη συμβατότητα Excel. Λάβετε υπόψη αυτούς τους περιορισμούς κατά το σχεδιασμό μιας ροής αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεται το Aspose.Slides να επανυπολογίσει τύπους.
- Επαναϋπολογίστε μετά την αλλαγή των κελιών από τα οποία εξαρτώνται τα αποτελέσματα των τύπων.
- Θεωρήστε τις προσωρινές τιμές από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως αντικατάσταση του επανυπολογισμού μετά από επεξεργασίες.
- Δοκιμάστε τους τύπους από υπάρχοντα πρότυπα πριν βασιστείτε στις υπολογισμένες τιμές τους, ειδικά αν χρησιμοποιούν συναρτήσεις εκτός του καταγεγραμμένου καταλόγου.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού φύλλου, υπολογίστε τους εξωτερικά και στη συνέχεια ενημερώστε το βιβλίο εργασίας του διαγράμματος με τις προκύπτουσες τιμές.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ `Formula` και `R1C1Formula`;**

[Formula](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/formula/) αποθηκεύει μια έκφραση στυλ A1 όπως `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/r1c1formula/) αποθηκεύει μια έκφραση στυλ R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειογραφία που ταιριάζει καλύτερα στον τρόπο δημιουργίας ή αντιγραφής των τύπων.

**Πρέπει να διαβάσω το ίδιο το κελί ή την τιμή του μετά τον υπολογισμό;**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/getcell/) επιστρέφει ένα `IChartDataCell`. Για να αποκτήσετε το υπολογισμένο αποτέλεσμα, διαβάστε την ιδιότητα [Value](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatacell/value/) του κελιού μετά τον επανυπολογισμό.

**Πότε πρέπει να καλέσω `CalculateFormulas`;**

Καλέστε το [CalculateFormulas](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν εξαρτηθείτε από τα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζει ο ενσωματωμένος αξιολογητής.

**Υποστηρίζει το Aspose.Slides κάθε συνάρτηση του Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Οι συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να θεωρούνται ότι θα επανυπολογιστούν σωστά. Αν απαιτείται πλήρης συμβατότητα τύπων Excel, εκτελέστε τον υπολογισμό με κατάλληλη μηχανή φύλλου και γράψτε τις τελικές τιμές στο βιβλίο εργασίας του διαγράμματος.

**Τι συμβαίνει αν μια φορτωμένη παρουσίαση περιέχει έναν μη υποστηριζόμενο τύπο;**

Αν τα δεδομένα του διαγράμματος δεν έχουν αλλάξει, το βιβλίο εργασίας μπορεί ακόμη να περιέχει μια παλαιότερη υπολογισμένη προσωρινή τιμή. Μετά την τροποποίηση των σχετικών δεδομένων, αυτή η τιμή μπορεί να μην είναι πλέον έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να επεξεργαστεί μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Είναι οι τιμές σφάλματος τύπων ίδιες με εξαιρέσεις .NET;**

Όχι. Μια τιμή όπως `#DIV/0!` είναι μια τιμή του φύλλου που προέρχεται από έγκυρο υπολογισμό. Εξαιρέσεις όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) υποδηλώνουν ότι ο τύπος δεν μπορεί να επεξεργαστεί κανονικά.

**Το διάγραμμα ενημερώνεται αυτόματα όταν αλλάζει ένα κελί τύπου;**

Μια σειρά διαγράμματος μπορεί να αναφέρεται σε κελιά του βιβλίου εργασίας. Επανυπολογίστε πρώτα το βιβλίο εργασίας, στη συνέχεια αποθηκεύστε ή αποδώστε την παρουσίαση. Αν τα σημεία δεδομένων του διαγράμματος αναφέρονται στα υπολογισμένα κελιά, το διάγραμμα χρησιμοποιεί τις ενημερωμένες τιμές· δεν απαιτείται ξεχωριστή μέθοδος ανανέωσης διαγράμματος για αυτή τη ροή.

**Μπορούν τα διαγράμματα να χρησιμοποιούν εξωτερικό βιβλίο εργασίας Excel;**

Ναι, τα δεδομένα διαγράμματος μπορούν να ρυθμιστούν ώστε να χρησιμοποιούν εξωτερικό βιβλίο μέσω του API δεδομένων διαγράμματος. Ωστόσο, η ροή υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το βιβλίο δεδομένων διαγράμματος και το υποσύνολο τύπων που αξιολογείται από το Aspose.Slides. Μην υποθέτετε ότι το [CalculateFormulas](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) παρέχει πλήρη επανυπολογισμό τυχαίων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο ή βιβλίο εργασίας;**

Οι αναφορές τύπων τύπου Excel μπορεί να υπάρχουν σε βιβλία διαγραμμάτων, αλλά η αξιολόγηση περιορίζεται από τον υποστηριζόμενο αναλυτή και το σύνολο συναρτήσεων. Αν μια διασταυρούμενη ή εξωτερική αναφορά είναι απαραίτητη, επαληθεύστε ότι ο συγκεκριμένος τύπος λειτουργεί με την έκδοση του Aspose.Slides που χρησιμοποιείτε. Για ροές που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το βιβλίο εξωτερικά και γράψτε τις επιλυμένες τιμές πίσω στα δεδομένα του διαγράμματος.

**Πρέπει τα κείμενα τύπων να αρχίζουν με `=`;**

Τα παραδείγματα του API Aspose.Slides εκχωρούν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς προποδιαστή `=`. Η χρήση αυτής της μορφής διατηρεί τους τύπους συνεπείς με τα τεκμηριωμένα παραδείγματα του API.