---
title: Εφαρμογή Τύπων Φύλλου Εργασίας Γραφήματος σε Παρουσιάσεις με Python
linktitle: Τύποι Φύλλου Εργασίας
type: docs
weight: 70
url: /el/python-net/chart-worksheet-formulas/
keywords:
- γραφήμα λογιστικού φύλλου
- φύλλο εργασίας γραφήματος
- τύπος γραφήματος
- τύπος φύλλου εργασίας
- τύπος λογιστικού φύλλου
- βιβλίο δεδομένων γραφήματος
- υπολογισμός τύπου
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
- Python
- Aspose.Slides
description: "Εφαρμόστε τύπους σε στυλ Excel σε φύλλα εργασίας γραφήματος Aspose.Slides για Python μέσω .NET, επαναϋπολογίστε τις τιμές και χρησιμοποιήστε τα αποτελέσματα σε γραφήματα PowerPoint."
---
## **Επισκόπηση**

Τα γραφήματα PowerPoint συνήθως αποθηκεύουν τα δεδομένα πηγής τους σε ένα ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides for Python μέσω .NET, μπορείτε να έχετε πρόσβαση σε αυτό το φύλλο εργασίας μέσω του βιβλίου εργασίας δεδομένων γραφήματος, να γράψετε τιμές εισόδου, να ορίσετε τύπους σε κελιά, να υπολογίσετε τους υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα γραφήματος.

Αυτό το άρθρο εξηγεί τη πλήρη ροή εργασίας τύπων: δημιουργήστε ένα γράφημα, γεμίστε το φύλλο εργασίας του, ορίστε τύπους στυλ A1 ή R1C1, επαναϋπολογίστε τα, διαβάστε τις υπολογισμένες τιμές, συνδέστε αυτά τα κελιά με μια σειρά γραφήματος και αποθηκεύστε την παρουσία. Περιγράφει επίσης τη σύνταξη υποστηριζόμενων τύπων, το υποσύνολο ενσωματωμένων συναρτήσεων, τις προσωρινές τιμές, τους μη υποστηριζόμενους τύπους και τα σφάλματα ειδικά για λογιστικά φύλλα.

## **Φύλλα Εργασίας Γραφήματος και Τύποι**

Ένα φύλλο εργασίας γραφήματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιεί ένα γράφημα. Στο PowerPoint, μπορείτε να ελέγξετε το φύλλο εργασίας ανοίγοντας τον επεξεργαστή δεδομένων γραφήματος:

![Γράφημα PowerPoint με το ενσωματωμένο φύλλο εργασίας ανοιχτό, εμφανίζοντας δεδομένα κατηγοριών και σειρών](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εργασίας εκτίθεται μέσω του [εργατικού βιβλίου δεδομένων γραφήματος](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdataworkbook/). Χρησιμοποιήστε την ιδιότητα [formula](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/formula/) για τύπους στυλ A1 και την ιδιότητα [r1c1_formula](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) για τύπους στυλ R1C1. Μετά την αλλαγή κελιών εισόδου ή τύπων, καλέστε [calculate_formulas](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) για επαναϋπολογισμό των υποστηριζόμενων τύπων και ενημέρωση των αντίστοιχων τιμών κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω της ιδιότητας [value](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/value/). Αυτό είναι σημαντικό όταν χρειάζεται να ελέγξετε το αποτέλεσμα ενός τύπου στον κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων γραφήματος.

## **Δημιουργία Γραφήματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το παρακάτω παράδειγμα παρουσιάζει ολοκληρωμένη ροή εργασίας. Δημιουργεί ένα σύμπλεγμα στηλών, διαγράφει τα δείγματα δεδομένων, γράφει τιμές εσόδων και εξόδων ανά τρίμηνο, υπολογίζει το κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές γραφήματος και αποθηκεύει την παρουσία.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

Τα σημεία δεδομένων του γραφήματος αναφέρονται στο `D2:D4`, οπότε το γράφημα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ανανέωσης γραφήματος σε αυτή τη ροή εργασίας: επαναϋπολογίστε πρώτα το βιβλίο εργασίας, έπειτα χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα γραφήματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων Στυλ A1**

Η σημειογραφία A1 προσδιορίζει στήλες με γράμματα και γραμμές με αριθμούς. Ορίστε εκφράσεις στυλ A1 μέσω του [IChartDataCell.formula](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Κοινές μορφές αναφοράς A1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μεικτή |
|---|---|---|---|
| Κελί | `A2` | `$A$2` | `A$2`, `$A2` |
| Γραμμή | `2:2` | `$2:$2` | — |
| Στήλη | `A:A` | `$A:$A` | — |
| Περιοχή | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινηθεί ή αντιγραφεί από την εφαρμογή λογιστικού φύλλου. Οι απόλυτες αναφορές διατηρούν και τις δύο συντεταγμένες σταθερές, ενώ οι μεικτές σταθεροποιούν μόνο μια γραμμή ή μια στήλη.

## **Χρήση Τύπων Στυλ R1C1**

Η σημειογραφία R1C1 προσδιορίζει τόσο γραμμές όσο και στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε αγκύλες. Ορίστε αυτή τη σύνταξη μέσω του [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

Κοινές μορφές αναφοράς R1C1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μεικτή |
|---|---|---|---|
| Κελί | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Γραμμή | `R[2]` | `R2` | — |
| Στήλη | `C[3]` | `C3` | — |
| Περιοχή | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια γραμμή δύο στήλες αριστερά (`B2`).

## **Σταθερές Τύπων και Τελεστές**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικά λεκτικά, συμβολοσειρές, τιμές σφάλματος λογιστικού φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Λεξικά**

| Τύπος | Παραδείγματα | Σημειώσεις |
|---|---|---|
| Λογική | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί απευθείας σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητική | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται κοινή και επιστημονική σημειογραφία. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Οι λεκτικές τιμές περιβάλλονται από διπλά εισαγωγικά μέσα στον τύπο. |
| Αποτέλεσμα σφάλματος | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί σε τιμή σφάλματος λογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί αρκετούς τύπους σταθερών:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # Ψευδές
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Αριθμητικές Ενενεργίες**

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `+` | Πρόσθεση ή μονοπρόσημο συν | `2+3` |
| `-` | Αφαίρεση ή αρνητικό πρόσημο | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Εξάσκηση | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να κάνετε ρητή την σειρά αξιολόγησης, π.χ. `(A2+B2)*C2`.

### **Τελεστές Σύγκρισης**

Οι συγκριτικές εκφράσεις επιστρέφουν λογικές τιμές.

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ισότητα | `A2=3` |
| `<>` | Ασυμφωνία | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει έναν ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας γραφήματος, αλλά δεν είναι πλήρες μηχανισμό υπολογισμού Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται στις παρακάτω. Μην υποθέτετε ότι ένας αυθαίρετος τύπος Excel μπορεί να επαναϋπολογισθεί με το [calculate_formulas](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής βάσει δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συγχώνευση κειμενικών τιμών | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συγχώνευση κειμενικών τιμών | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας με σύστημα 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστρέφει τον αριθμό ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εύρεση κειμένου μέσα σε άλλο | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου κατά byte | `FINDB("a",A2)` |
| `IF` | Συνθήκη | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Μορφή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Μορφή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροιση τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κατακόρυφη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί στον πίνακα είναι σημαντικοί: το `INDEX` τεκμηριώνεται σε μορφή αναφοράς, ενώ τα `LOOKUP` και `MATCH` σε μορφές διανύσματος. Το `DATE` χρησιμοποιεί το σύστημα 1900. Οι λειτουργίες και χαρακτηριστικά που δεν αναφέρονται εδώ θεωρούνται μη υποστηριζόμενα από τον αξιολογητή τύπων του Aspose.Slides, εκτός εάν τεκμηριωθούν ξεχωριστά.

## **Επαναϋπολογισμός και Προσωρινές Τιμές**

Τα αρχεία λογιστικών φύλλων συνήθως αποθηκεύουν τόσο τον τύπο όσο και την τελευταία υπολογισμένη τιμή του. Το Aspose.Slides μπορεί έτσι να διαβάσει μια προσωρινή τιμή από το [IChartDataCell.value](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/value/) όταν η παρουσία φορτώνεται και τα σχετικά δεδομένα γραφήματος δεν έχουν τροποποιηθεί.

Μετά την αλλαγή κελιών εισόδου ή τύπων, μην βασίζεστε σε παλιά προσωρινή τιμή. Καλέστε το [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα γραφήματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποστηριζόμενου υποσυνόλου, το Aspose.Slides μπορεί να μην μπορεί να αναλύσει τον τύπο ή να καθορίσει τις εξαρτήσεις του. Εάν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη προσωρινή τιμή δεν είναι πλέον αξιόπιστη. Σε αυτήν την κατάσταση, η ανάγνωση της τιμής κελιού με μη υποστηριζόμενα δεδομένα μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Αν το γράφημά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε αυτούς τους τύπους με έναν μηχανισμό λογιστικού φύλλου που τις υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο βιβλίο εργασίας του γραφήματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με εικαστικές τιμές.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικά είδη προβλημάτων που πρέπει να διακρίνετε.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει αποτέλεσμα σφάλματος λογιστικού φύλλου όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτήν την περίπτωση, το σφάλμα είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του `value`.

Ένας τύπος μπορεί επίσης να αποτύχει σε επίπεδο ανάλυσης, αναφοράς, εξάρτησης ή υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει εξαιρέσεις ειδικές για λογιστικά φύλλα για αυτές τις περιπτώσεις: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή είσοδο χρήστη, χειριστείτε αυτές τις εξαιρέσεις γύρω από τον επαναϋπολογισμό και την πρόσβαση στην τιμή:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Πρακτικοί Περιορισμοί**

Η υποστήριξη τύπων σε φύλλα εργασίας γραφήματος προορίζεται για ένα ορισμένο υποσύνολο υπολογισμών λογιστικού φύλλου, όχι για πλήρη συμβατότητα με το Excel. Λάβετε υπόψη αυτούς τους περιορισμούς κατά το σχεδιασμό μιας ροής εργασίας αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεστε επαναϋπολογισμό τύπων από το Aspose.Slides.
- Επαναϋπολογίστε μετά την αλλαγή των κελιών από τα οποία εξαρτώνται τα αποτελέσματα τύπων.
- Θεωρείτε τις προσωρινές τιμές από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως υποκατάστατο του επαναϋπολογισμού μετά από επεμβάσεις.
- Δοκιμάστε τους τύπους από υπάρχοντα πρότυπα πριν βασιστείτε στα υπολογισμένα αποτελέσματά τους, ειδικά εάν χρησιμοποιούν συναρτήσεις εκτός του τεκμηριωμένου καταλόγου.
- Για τύπους που απαιτούν πλήρη μηχανισμό υπολογισμού λογιστικού φύλλου, υπολογίστε τους εξωτερικά και στη συνέχεια ενημερώστε το βιβλίο εργασίας του γραφήματος με τις προκύπτουσες τιμές.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ `formula` και `r1c1_formula`;**

[formula](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/formula/) αποθηκεύει μια έκφραση στυλ A1 όπως `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) αποθηκεύει μια έκφραση στυλ R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειογραφία που ταιριάζει καλύτερα στον τρόπο δημιουργίας ή αντιγραφής των τύπων.

**Πρέπει να διαβάσω το κελί ή την τιμή του μετά τον υπολογισμό;**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) επιστρέφει ένα `IChartDataCell`. Για να λάβετε το υπολογισμένο αποτέλεσμα, διαβάστε την ιδιότητα [value](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/value/) του κελιού μετά τον επαναϋπολογισμό.

**Πότε πρέπει να καλέσω `calculate_formulas`;**

Καλέστε το [calculate_formulas](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν εξαρτηθείτε από τα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζονται από τον ενσωματωμένο αξιολογητή.

**Το Aspose.Slides υποστηρίζει κάθε συνάρτηση του Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Οι συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να υποτεθεί ότι υπολογίζονται σωστά. Εάν απαιτείται πλήρης συμβατότητα τύπων Excel, εκτελέστε τον υπολογισμό με κατάλληλο μηχανισμό λογιστικού φύλλου και γράψτε τις τελικές τιμές στο βιβλίο εργασίας του γραφήματος.

**Τι συμβαίνει αν μια φορτωμένη παρουσία περιέχει μη υποστηριζόμενο τύπο;**

Εάν τα δεδομένα του γραφήματος δεν έχουν αλλάξει, το βιβλίο εργασίας μπορεί ακόμα να περιέχει μια προηγούμενη υπολογισμένη προσωρινή τιμή. Αφού τροποποιηθούν τα σχετιζόμενα δεδομένα, αυτή η προσωρινή τιμή μπορεί να μην είναι έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να διαχειριστεί μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Οι τιμές σφάλματος τύπου είναι το ίδιο με τις εξαιρέσεις Python;**

Όχι. Ένα αποτέλεσμα όπως `#DIV/0!` είναι τιμή λογιστικού φύλλου που προκύπτει από έγκυρο υπολογισμό. Εξαιρέσεις όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) υποδεικνύουν ότι ο τύπος δεν μπορεί να επεξεργαστεί κανονικά.

**Το γράφημα ενημερώνεται αυτόματα όταν αλλάζει ένα κελί τύπου;**

Μια σειρά γραφήματος μπορεί να αναφέρεται σε κελιά του βιβλίου εργασίας. Επαναϋπολογίστε πρώτα το βιβλίο εργασίας, έπειτα αποθηκεύστε ή αποδώστε την παρουσία. Εάν τα σημεία δεδομένων του γραφήματος αναφέρονται στα υπολογισμένα κελιά, το γράφημα χρησιμοποιεί τις ενημερωμένες τιμές αυτών· δεν απαιτείται ξεχωριστή μέθοδος ανανέωσης γραφήματος για αυτήν τη ροή εργασίας.

**Μπορούν τα γραφήματα να χρησιμοποιούν εξωτερικό βιβλίο εργασίας Excel;**

Ναι, τα δεδομένα γραφήματος μπορούν να ρυθμιστούν ώστε να χρησιμοποιούν εξωτερικό βιβλίο εργασίας μέσω του API δεδομένων γραφήματος. Ωστόσο, η ροή υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το βιβλίο εργασίας δεδομένων γραφήματος και το υποσύνολο τύπων που αξιολογεί το Aspose.Slides. Μην υποθέτετε ότι το [calculate_formulas](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) παρέχει πλήρη επαναϋπολογισμό αυθαίρετων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο ή βιβλίο εργασίας;**

Οι αναφορές τύπου Excel μπορεί να υπάρχουν σε βιβλία εργασίας γραφήματος, αλλά η αξιολόγηση των τύπων περιορίζεται από τον υποστηριζόμενο διαρθωτή και σύνολο συναρτήσεων. Εάν μια διαπλασιαστική ή εξωτερική αναφορά είναι κρίσιμη, επαληθεύστε τον ακριβή τύπο με την έκδοση του Aspose.Slides που χρησιμοποιείτε. Για ροές εργασίας που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το βιβλίο εργασίας εξωτερικά και γράψτε τις επιλυμένες τιμές πίσω στα δεδομένα του γραφήματος.

**Πρέπει οι συμβολοσειρές τύπων να ξεκινούν με `=`;**

Τα παραδείγματα API του Aspose.Slides ορίζουν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς το αρχικό `=`. Η χρήση αυτής της μορφής διατηρεί τους τύπους συνεπείς με τα τεκμηριωμένα παραδείγματα API.