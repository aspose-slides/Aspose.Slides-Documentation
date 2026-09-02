---
title: Εφαρμογή Τύπων Φύλλου Εργασίας Διαγράμματος σε Παρουσιάσεις με Python
linktitle: Τύποι Φύλλου Εργασίας
type: docs
weight: 70
url: /el/python-net/chart-worksheet-formulas/
keywords:
- φύλλο εργασίας διαγράμματος
- φύλλο εργασίας διαγράμματος
- τύπος διαγράμματος
- τύπος φύλλου εργασίας
- τύπος υπολογιστικού φύλλου
- βιβλίο δεδομένων διαγράμματος
- υπολογισμός τύπου
- προτιμώμενος πολιτισμός
- τύπος ειδικός για πολιτισμό
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
- Python
- Aspose.Slides
description: "Εφαρμόστε τύπους Excel‑style σε φύλλα εργασίας διαγράμματος του Aspose.Slides για Python μέσω .NET, επαναϋπολογίστε τιμές και χρησιμοποιήστε τα αποτελέσματα σε διαγράμματα PowerPoint."
---
## **Επισκόπηση**

Τα διαγράμματα PowerPoint συνήθως αποθηκεύουν τα δεδομένα πηγής τους σε ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides για Python μέσω .NET, μπορείτε να αποκτήσετε πρόσβαση σε αυτό το φύλλο εργασίας μέσω του βιβλίου δεδομένων διαγράμματος, να γράψετε τιμές εισόδου, να εκχωρήσετε τύπους σε κελιά, να υπολογίσετε υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα διαγράμματος.

Αυτό το άρθρο εξηγεί τη πλήρη ροή εργασίας τύπων: δημιουργία διαγράμματος, συμπλήρωση του φύλλου εργασίας, εκχώρηση τύπων στυλ A1 ή R1C1, επαναϋπολογισμός τους, ανάγνωση των υπολογισμένων τιμών, σύνδεση αυτών των κελιών με σειρά διαγράμματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη σύνταξη των υποστηριζόμενων τύπων, το ενσωματωμένο υποσύνολο συναρτήσεων, τις ενσωματωμένες τιμές, τους μη υποστηριζόμενους τύπους και τα σφάλματα που σχετίζονται με φύλλα εργασίας.

## **Φύλλα Εργασίας Διαγράμματος και Τύποι**

Ένα φύλλο εργασίας διαγράμματος περιέχει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιεί ένα διάγραμμα. Στο PowerPoint, μπορείτε να επιθεωρήσετε το φύλλο εργασίας ανοίγοντας τον επεξεργαστή δεδομένων διαγράμματος:

![Διάγραμμα PowerPoint με το ενσωματωμένο φύλλο εργασίας ανοιχτό, εμφανίζοντας δεδομένα κατηγοριών και σειρών](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εργασίας εκτίθεται μέσω του [βιβλίου δεδομένων διαγράμματος](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdataworkbook/). Χρησιμοποιήστε την ιδιότητα [formula](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/formula/) για τύπους στυλ A1 και την ιδιότητα [r1c1_formula](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) για τύπους στυλ R1C1. Μετά την αλλαγή των κελιών εισόδου ή των τύπων, καλέστε [calculate_formulas](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) για να επαναϋπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω της ιδιότητας [value](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/value/). Αυτό είναι σημαντικό όταν χρειάζεται να ελέγξετε το αποτέλεσμα ενός τύπου σε κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένων διαγράμματος.

## **Δημιουργία Διαγράμματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το παρακάτω παράδειγμα δείχνει μια ολοκληρωμένη ροή εργασίας. Δημιουργεί ένα σύμπτυκτο διάγραμμα στηλών, διαγράφει τα δείγματα δεδομένων, γράφει τριμηνιαίες τιμές εσόδων και εξόδων, υπολογίζει κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές διαγράμματος και αποθηκεύει την παρουσίαση.

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

Τα σημεία δεδομένων του διαγράμματος αναφέρονται στο `D2:D4`, επομένως το διάγραμμα χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ανανέωσης διαγράμματος σε αυτή τη ροή εργασίας: επαναϋπολογίστε πρώτα το βιβλίο εργασίας, έπειτα χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα διαγράμματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων Στυλ A1**

Η σημειογραφία A1 ταυτοποιεί στήλες με γράμματα και σειρές με αριθμούς. Εκχωρήστε εκφράσεις στυλ A1 μέσω του [IChartDataCell.formula](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/formula/).

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

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινηθεί ή αντιγραφεί από μια εφαρμογή φύλλου εργασίας. Οι απόλυτες αναφορές διατηρούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές αναφορές σταθεροποιούν μόνο μια σειρά ή μια στήλη.

## **Χρήση Τύπων Στυλ R1C1**

Η σημειογραφία R1C1 ταυτοποιεί τόσο τις σειρές όσο και τις στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε αγκύλες. Εκχωρήστε αυτή τη σύνταξη μέσω του [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

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

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια σειρά δύο στήλες αριστερά (`B2`).

## **Σταθερές Τύπων και Τελεστές**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικούς κυριολεκτικούς, συμβολοσειρές, τιμές σφαλμάτων φύλλου εργασίας, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Κυριολεκτικά**

| Τύπος | Παραδείγματα | Σημειώσεις |
|---|---|---|
| Logical | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί άμεσα σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται η κοινή και η επιστημονική σημειογραφία. |
| String | `"abc"`, `"2/3/2020 12:00"` | Τα κυριολεκτικά κείμενα περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί σε τιμή σφάλματος φύλλου εργασίας αντί για φυσικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί διάφορους τύπους σταθερών:

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

### **Αριθμητικοί Τελεστές**

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `+` | Πρόσθεση ή μονικός θετικός | `2+3` |
| `-` | Αφαίρεση ή αρνητικό | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Εκθέτης | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να κάνετε ρητό τη σειρά αξιολόγησης, π.χ. `(A2+B2)*C2`.

### **Τελεστές Σύγκρισης**

Οι εκφράσεις σύγκρισης επιστρέ φουν λογικές τιμές.

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ισοδυναμία | `A2=3` |
| `<>` | Ανισότητα | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας διαγράμματος, αλλά δεν είναι πλήρες μηχανισμό υπολογισμού Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται στις παρακάτω συναρτήσεις. Μην υποθέτετε ότι ένας αυθαίρετος τύπος Excel μπορεί να επαναϋπολογιστεί με το [calculate_formulas](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής με δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συγχώνευση κειμενικών τιμών | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συγχώνευση κειμενικών τιμών | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας με σύστημα 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστρέφει τον αριθμό ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εύρεση ενός κειμένου μέσα σε άλλο | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου με βάση τα byte | `FINDB("a",A2)` |
| `IF` | Συνθηματικό αποτέλεσμα | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Μορφή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Μορφή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροισμα τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κατακόρυφη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί που εμφανίζονται στον πίνακα είναι σημαντικοί: το `INDEX` τεκμηριώνεται σε μορφή αναφοράς, ενώ τα `LOOKUP` και `MATCH` τεκμηριώνονται σε μορφές διανύσματος. Το `DATE` χρησιμοποιεί το σύστημα 1900. Λειτουργίες και συναρτήσεις που δεν αναφέρονται εδώ θεωρούνται μη υποστηριζόμενες από τον αξιολογητή τύπων Aspose.Slides, εκτός εάν τεκμηριώνονται ξεχωριστά.

## **Υπολογισμός Τύπων με Προτιμώμενο Πολιτισμό**

Ορισμένες συναρτήσεις βιβλίου διαγραμμάτων ερμηνεύουν το κείμενο σύμφωνα με πολιτιστικές ρυθμίσεις. Αυτό είναι ιδιαίτερα σημαντικό για συναρτήσεις που προορίζονται για γλώσσες που χρησιμοποιούν σύνολα χαρακτήρων διπλού byte (DBCS). Για να υπολογίσετε σωστά τέτοιους τύπους, δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/), ορίστε το [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/el/python-net/aspose.slides/spreadsheetoptions/) μέσω του [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/spreadsheet_options/) και, στη συνέχεια, φορτώστε την παρουσίαση.

Το παρακάτω παράδειγμα επιλέγει τον Ιαπωνικό πολιτισμό, ανοίγει μια παρουσίαση με τις ρυθμισμένες επιλογές φόρτωσης και καλεί το [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) για κάθε βιβλίο διαγράμματος:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

Ο προτιμώμενος πολιτισμός αποτελεί μέρος της ρύθμισης φόρτωσης παρουσίασης, οπότε ορίστε τον πριν δημιουργήσετε το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Χρησιμοποιήστε τον πολιτισμό που απαιτούν οι τύποι του βιβλίου εργασίας· π.χ., `ja-JP` για τύπους που πρέπει να ακολουθούν τους Ιαπωνικούς κανόνες DBCS.

## **Επαναϋπολογισμός και Τιμές Ενταγμένες**

Τα αρχεία φύλλων εργασίας συνήθως αποθηκεύουν και τον τύπο και την τελευταία υπολογισμένη τιμή του. Το Aspose.Slides μπορεί επομένως να διαβάσει μια ενσωματωμένη τιμή από το [IChartDataCell.value](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/value/) όταν φορτώνεται μια παρουσίαση και τα σχετικά δεδομένα διαγράμματος δεν έχουν τροποποιηθεί.

Αφού αλλάξετε κελιά εισόδου ή τύπους, μην βασίζεστε σε παλιό ενσωματωμένο αποτέλεσμα. Καλέστε το [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα διαγράμματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποσυνόλου που υποστηρίζεται, το Aspose.Slides ενδέχεται να μην μπορεί να αναλύσει τον τύπο ή να καθορίσει τις εξαρτήσεις του. Εάν το βιβλίο εργασίας έχει τροποποιηθεί, η προηγούμενη ενσωματωμένη τιμή δεν μπορεί πια να θεωρηθεί αξιόπιστη. Σε αυτή την κατάσταση, η ανάγνωση της τιμής ενός κελιού με μη υποστηριζόμενα δεδομένα μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Εάν το διάγραμμά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε αυτούς τους τύπους με μια μηχανή φύλλου εργασίας που τους υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο βιβλίο διαγράμματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με εικαστικές τιμές.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικές κατηγορίες προβλημάτων που πρέπει να διακρίνετε.

* Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει ένα σφάλμα φύλλου εργασίας όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτήν την περίπτωση, το σφάλμα είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του `value`.
* Ένας τύπος μπορεί επίσης να αποτύχει κατά την ανάλυση, την αναφορά, την εξάρτηση ή το επίπεδο των υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει εξαιρέσεις ειδικές για φύλλο εργασίας: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή εισροές χρήστη, αντιμετωπίστε αυτές τις εξαιρέσεις γύρω από τον επαναϋπολογισμό και την πρόσβαση στην τιμή:

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

Η υποστήριξη τύπων σε φύλλα εργασίας διαγράμματος προορίζεται για ένα καθορισμένο υποσύνολο υπολογισμών φύλλων εργασίας, όχι για πλήρη συμβατότητα με το Excel. Λάβετε υπόψη αυτούς τους περιορισμούς όταν σχεδιάζετε μια ροή εργασίας αναφοράς:

- Χρησιμοποιήστε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεται το Aspose.Slides να επαναϋπολογίσει τύπους.
- Επαναϋπολογίστε μετά από την αλλαγή των κελιών από τα οποία εξαρτώνται τα αποτελέσματα τύπων.
- Θεωρήστε τις ενσωματωμένες τιμές από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως αντικατάσταση του επαναϋπολογισμού μετά από επεξεργασίες.
- Δοκιμάστε τους τύπους από υπάρχοντα πρότυπα πριν βασιστείτε στις υπολογισμένες τιμές τους, ιδιαίτερα όταν χρησιμοποιούν συναρτήσεις εκτός του τεκμηριωμένου καταλόγου.
- Για τύπους που απαιτούν πλήρη μηχανισμό υπολογισμού φύλλου εργασίας, υπολογίστε τους εξωτερικά και, στη συνέχεια, ενημερώστε το βιβλίο διαγράμματος με τις προκύπτουσες τιμές.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποια είναι η διαφορά μεταξύ `formula` και `r1c1_formula`;**

[formula](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/formula/) αποθηκεύει μια έκφραση στυλ A1 όπως `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) αποθηκεύει μια έκφραση στυλ R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειογραφία που ταιριάζει καλύτερα στον τρόπο δημιουργίας ή αντιγραφής τύπων.

**Πρέπει να διαβάσω το κελί ή την τιμή του μετά τον υπολογισμό;**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) επιστρέφει ένα `IChartDataCell`. Για να λάβετε το υπολογισμένο αποτέλεσμα, διαβάστε την ιδιότητα [value](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichartdatacell/value/) του κελιού μετά τον επαναϋπολογισμό.

**Πότε πρέπει να καλέσω `calculate_formulas`;**

Καλέστε το [calculate_formulas](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν εξαρτηθείτε από τα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζονται από τον ενσωματωμένο αξιολογητή.

**Υποστηρίζει το Aspose.Slides κάθε συνάρτηση του Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να θεωρούνται ότι θα επαναϋπολογιστούν σωστά. Εάν απαιτείται πλήρης συμβατότητα τύπων Excel, εκτελέστε τον υπολογισμό με κατάλληλη μηχανή φύλλου εργασίας και γράψτε τις τελικές τιμές στο βιβλίο διαγράμματος.

**Τι συμβαίνει εάν μια φορτωμένη παρουσίαση περιέχει μη υποστηριζόμενο τύπο;**

Εάν τα δεδομένα του διαγράμματος δεν έχουν αλλάξει, το βιβλίο εργασίας μπορεί ακόμη να περιέχει μια προγενέστερη ενσωματωμένη τιμή. Μετά την τροποποίηση των σχετικών δεδομένων, αυτή η ενσωματωμένη τιμή μπορεί να μην είναι πλέον έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να επεξεργαστεί μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Είναι οι τιμές σφαλμάτων τύπου οι ίδιες με εξαιρέσεις Python;**

Όχι. Ένα αποτέλεσμα όπως `#DIV/0!` είναι τιμή φύλλου εργασίας που παράγεται από έγκυρο υπολογισμό. Εξαιρέσεις όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) υποδεικνύουν ότι ο τύπος δεν μπορεί να επεξεργαστεί κανονικά.

**Ενημερώνεται αυτόματα το σχέδιο όταν αλλάζει ένα κελί τύπου;**

Μια σειρά διαγράμματος μπορεί να αναφέρεται σε κελιά βιβλίου εργασίας. Επαναϋπολογίστε πρώτα το βιβλίο εργασίας, έπειτα αποθηκεύστε ή αποδώστε την παρουσίαση. Εάν τα σημεία δεδομένων του διαγράμματος αναφέρονται στα υπολογισμένα κελιά, το διάγραμμα χρησιμοποιεί τις ενημερωμένες τιμές κελιών· δεν απαιτείται ξεχωριστή μέθοδος ανανέωσης διαγράμματος για αυτήν τη ροή εργασίας.

**Μπορούν τα διαγράμματα να χρησιμοποιούν εξωτερικό βιβλίο Excel;**

Ναι, τα δεδομένα διαγράμματος μπορούν να διαμορφωθούν ώστε να χρησιμοποιούν εξωτερικό βιβλίο μέσω του API δεδομένων διαγράμματος. Ωστόσο, η ροή εργασίας υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το βιβλίο δεδομένων διαγράμματος και το υποσύνολο τύπων που αξιολογείται από το Aspose.Slides. Μην υποθέτετε ότι το [calculate_formulas](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) παρέχει πλήρη επαναϋπολογισμό αυθαίρετων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο εργασίας ή βιβλίο;**

Οι αναφορές στυλ Excel μπορεί να υπάρχουν σε βιβλία διαγραμμάτων, αλλά η αξιολόγηση τύπων περιορίζεται από τον υποστηριζόμενο αναλυτή και το σύνολο συναρτήσεων. Εάν είναι απαραίτητη μια αναφορά μεταξύ φύλλων ή εξωτερική αναφορά, ελέγξτε ακριβώς τον τύπο με την έκδοση του Aspose.Slides που χρησιμοποιείτε. Για ροές εργασίας που απαιτούν ευρεία συμβατότητα των αναφορών Excel, υπολογίστε το βιβλίο εξωτερικά και γράψτε τις λύσεις πίσω στα δεδομένα διαγράμματος.

**Πρέπει τα συμβολοσειρά τύπου να ξεκινούν με `=`;**

Τα παραδείγματα του API Aspose.Slides εκχωρούν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς αρχικό `=`. Η χρήση αυτής της μορφής διατηρεί τους τύπους συνεπείς με τα τεκμηριωμένα παραδείγματα API.