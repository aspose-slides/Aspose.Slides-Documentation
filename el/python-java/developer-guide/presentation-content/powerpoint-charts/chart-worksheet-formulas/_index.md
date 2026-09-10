---
title: Εφαρμογή Τύπων Φύλλου Εργασίας Διαγράμματος στις Παρουσιάσεις σε Python μέσω Java
linktitle: Τύποι Φύλλου Εργασίας
type: docs
weight: 70
url: /el/python-java/chart-worksheet-formulas/
keywords:
- λογιστικό φύλλο διαγράμματος
- φύλλο εργασίας διαγράμματος
- τύπος διαγράμματος
- τύπος φύλλου εργασίας
- τύπος λογιστικού φύλλου
- βιβλίο δεδομένων διαγράμματος
- υπολογισμός τύπου
- προτιμώμενος πολιτισμός
- τύπος εξειδικευμένος πολιτιστικά
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
- Java
- Aspose.Slides
description: "Εφαρμόστε τύπους σε στυλ Excel σε φύλλα εργασίας διαγράμματος Aspose.Slides για Python μέσω Java, επανυπολογίστε τις τιμές και χρησιμοποιήστε τα αποτελέσματα σε διαγράμματα PowerPoint."
---
## **Επισκόπηση**

Τα διαγράμματα PowerPoint συνήθως αποθηκεύουν τα δεδομένα πηγής τους σε ένα ενσωματωμένο φύλλο εργασίας. Στο Aspose.Slides για Python μέσω Java, μπορείτε να έχετε πρόσβαση σε αυτό το φύλλο εργασίας μέσω του [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/), να γράψετε τιμές εισόδου, να αναθέσετε τύπους σε κελιά, να υπολογίσετε υποστηριζόμενους τύπους και να χρησιμοποιήσετε τα υπολογισμένα κελιά ως δεδομένα διαγράμματος.

Αυτό το άρθρο εξηγεί τη συνολική ροή εργασίας τύπων: δημιουργία διαγράμματος, πλήρωση του φύλλου εργασίας, ανάθεση τύπων στυλ A1 ή R1C1, επανυπολογισμό τους, ανάγνωση των υπολογισμένων τιμών, σύνδεση αυτών των κελιών σε σειρά διαγράμματος και αποθήκευση της παρουσίασης. Περιγράφει επίσης τη σύνταξη υποστηριζόμενων τύπων, το ενσωματωμένο υποσύνολο συναρτήσεων, τις αποθηκευμένες τιμές, τους μη υποστηριζόμενους τύπους και τα σφάλματα συγκεκριμένα για λογιστικά φύλλα.

## **Φύλλα Εργασίας Διαγράμματος και Τύποι**

Ένα φύλλο εργασίας διαγράμματος περιλαμβάνει τις κατηγορίες, τα ονόματα σειρών και τις τιμές που χρησιμοποιεί ένα διάγραμμα. Στο PowerPoint, μπορείτε να εξετάσετε το φύλλο εργασίας ανοίγοντας τον επεξεργαστή δεδομένων διαγράμματος:

![Διάγραμμα PowerPoint με ανοιχτό ενσωματωμένο φύλλο εργασίας, εμφανίζοντας δεδομένα κατηγοριών και σειρών](chart-worksheet-formulas_1.png)

Στο Aspose.Slides, το φύλλο εργασίας εκτίθεται μέσω της κλάσης [ChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/). Χρησιμοποιήστε [ChartDataCell.setFormula](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#setFormula) για τύπους στυλ A1 και [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#setR1C1Formula) για τύπους στυλ R1C1. Μετά την αλλαγή κελιών εισόδου ή τύπων, καλέστε [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) για να επανυπολογίσετε τους υποστηριζόμενους τύπους και να ενημερώσετε τις αντίστοιχες τιμές κελιών.

Ένα υπολογισμένο κελί εξακολουθεί να εκθέτει το αποτέλεσμα του μέσω του [ChartDataCell.getValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#getValue). Αυτό είναι σημαντικό όταν χρειάζεστε να επιθεωρήσετε το αποτέλεσμα ενός τύπου στον κώδικα ή να χρησιμοποιήσετε το κελί ως σημείο δεδομένου διαγράμματος.

## **Δημιουργία Διαγράμματος και Υπολογισμός Τύπων Φύλλου Εργασίας**

Το παρακάτω παράδειγμα δείχνει μια ολοκληρωμένη ροή εργασίας. Δημιουργεί ένα συγκεντρωτικό στήλης διάγραμμα, διαγράφει τα δείγματα δεδομένων, γράφει τριμηνιαίες τιμές εσόδων και εξόδων, υπολογίζει κέρδος με τύπους, διαβάζει τα αποτελέσματα, χρησιμοποιεί τα υπολογισμένα κελιά ως τιμές διαγράμματος και αποθηκεύει την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Τα σημεία δεδομένων του διαγράμματος αναφέρονται στο `D2:D4`, έτσι ώστε το διάγραμμα να χρησιμοποιεί τις υπολογισμένες τιμές κέρδους. Δεν υπάρχει ξεχωριστή κλήση ανανέωσης διαγράμματος σε αυτή τη ροή: επανυπολογίστε πρώτα το workbook, μετά χρησιμοποιήστε ή αποθηκεύστε τα δεδομένα διαγράμματος που δείχνουν στα υπολογισμένα κελιά.

## **Χρήση Τύπων Στυλ A1**

Η σημειολογία A1 αναγνωρίζει στήλες με γράμματα και σειρές με αριθμούς. Αναθέστε εκφράσεις στυλ A1 μέσω του [ChartDataCell.setFormula](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#setFormula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

Κοινές μορφές αναφοράς A1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Κελί | `A2` | `$A$2` | `A$2`, `$A2` |
| Σειρά | `2:2` | `$2:$2` | — |
| Στήλη | `A:A` | `$A:$A` | — |
| Περιοχή | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Οι σχετικές αναφορές μπορούν να αλλάξουν όταν ένας τύπος μετακινηθεί ή αντιγραφεί από ένα πρόγραμμα λογιστικού φύλλου. Οι απόλυτες αναφορές κρατούν και τις δύο συντεταγμένες σταθερές, ενώ οι μικτές κρατούν μόνο μια σειρά ή μια στήλη σταθερή.

## **Χρήση Τύπων Στυλ R1C1**

Η σημειολογία R1C1 αναγνωρίζει τόσο σειρές όσο και στήλες αριθμητικά. Οι σχετικές αναφορές χρησιμοποιούν μετατοπίσεις σε αγκύλες. Αναθέστε αυτήν τη σύνταξη μέσω του [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#setR1C1Formula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

Κοινές μορφές αναφοράς R1C1 είναι:

| Αναφορά | Σχετική | Απόλυτη | Μικτή |
|---|---|---|---|
| Κελί | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Σειρά | `R[2]` | `R2` | — |
| Στήλη | `C[3]` | `C3` | — |
| Περιοχή | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Για παράδειγμα, στο κελί `D2`, το `RC[-2]` σημαίνει το κελί στην ίδια σειρά δύο στήλες αριστερά (`B2`).

## **Σταθερές Τύπων και Τελεστές**

Ο ενσωματωμένος αξιολογητής τύπων υποστηρίζει λογικές τιμές, αριθμητικά κυριολεξικά, συμβολοσειρές, τιμές σφάλματος λογιστικού φύλλου, αριθμητικούς τελεστές και τελεστές σύγκρισης.

### **Σταθερές και Κυριολεξικά**

| Τύπος | Παραδείγματα | Σημειώσεις |
|---|---|---|
| Λογική | `TRUE`, `FALSE` | Μπορεί να χρησιμοποιηθεί άμεσα σε λογικές εκφράσεις όπως `A2=TRUE`. |
| Αριθμητική | `1`, `0.5`, `.3`, `1E-2` | Υποστηρίζονται τόσο η κοινή όσο και η επιστημονική σημειογραφία. |
| Συμβολοσειρά | `"abc"`, `"2/3/2020 12:00"` | Τα κυριολεξικά κείμενα περικλείονται σε διπλά εισαγωγικά μέσα στον τύπο. |
| Αποτέλεσμα σφάλματος | `#DIV/0!`, `#N/A`, `#REF!` | Ένας έγκυρος τύπος μπορεί να αξιολογηθεί σε τιμή σφάλματος λογιστικού φύλλου αντί για κανονικό αποτέλεσμα. |

Αυτό το παράδειγμα χρησιμοποιεί διάφορους τύπους σταθερών:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # Ψευδές
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **Αριθμητικοί Τελεστές**

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `+` | Πρόσθεση ή μοναδιαίο πρόσημο | `2+3` |
| `-` | Αφαίρεση ή άρνηση | `2-3`, `-3` |
| `*` | Πολλαπλασιασμός | `2*3` |
| `/` | Διαίρεση | `2/3` |
| `%` | Ποσοστό | `30%` |
| `^` | Εκθέτης | `2^3` |

Χρησιμοποιήστε παρενθέσεις για να καθορίσετε ρητά τη σειρά αξιολόγησης, π.χ. `(A2+B2)*C2`.

### **Τελεστές Σύγκρισης**

Οι συγκριτικές εκφράσεις επιστρέφουν λογικές τιμές.

| Τελεστής | Σημασία | Παράδειγμα |
|---|---|---|
| `=` | Ισότητα | `A2=3` |
| `<>` | Ασυγγένεια | `A2<>3` |
| `>` | Μεγαλύτερο από | `A2>3` |
| `>=` | Μεγαλύτερο ή ίσο | `A2>=3` |
| `<` | Μικρότερο από | `A2<3` |
| `<=` | Μικρότερο ή ίσο | `A2<=3` |

## **Υποστηριζόμενες Προκαθορισμένες Συναρτήσεις**

Το Aspose.Slides περιλαμβάνει έναν ενσωματωμένο αξιολογητή τύπων για φύλλα εργασίας διαγράμματος, αλλά δεν είναι πλήρης μηχανή υπολογισμού Excel. Το τεκμηριωμένο σύνολο συναρτήσεων περιορίζεται σε αυτές που εμφανίζονται παρακάτω. Μην υποθέτετε ότι ένας τυχαίος τύπος Excel μπορεί να επανυπολογιστεί από το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Συνάρτηση | Σκοπός ή υποστηριζόμενη μορφή | Παράδειγμα |
|---|---|---|
| `ABS` | Απόλυτη τιμή | `ABS(A2)` |
| `AVERAGE` | Αριθμητικός μέσος | `AVERAGE(B2:B5)` |
| `CEILING` | Στρογγυλοποίηση προς τα πάνω σε πολλαπλάσιο | `CEILING(A2,5)` |
| `CHOOSE` | Επιλογή τιμής με βάση δείκτη | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Συγχώνευση τιμών κειμένου | `CONCAT(A2,B2)` |
| `CONCATENATE` | Συγχώνευση τιμών κειμένου | `CONCATENATE(A2," ",B2)` |
| `DATE` | Δημιουργία τιμής ημερομηνίας με σύστημα 1900 | `DATE(2026,8,19)` |
| `DAYS` | Επιστρέφει τον αριθμό ημερών μεταξύ ημερομηνιών | `DAYS(B2,A2)` |
| `FIND` | Εύρεση ενός κειμένου μέσα σε άλλο | `FIND("-",A2)` |
| `FINDB` | Αναζήτηση κειμένου ανά byte | `FINDB("a",A2)` |
| `IF` | Συνθήκη | `IF(A2>0,A2,0)` |
| `INDEX` | Μορφή αναφοράς | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Μορφή διανύσματος | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Μορφή διανύσματος | `MATCH(A2,B2:B5,0)` |
| `MAX` | Μέγιστη τιμή | `MAX(B2:B5)` |
| `SUM` | Άθροισμα τιμών | `SUM(B2:B5)` |
| `VLOOKUP` | Κατακόρυφη αναζήτηση | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Οι περιορισμοί του πίνακα είναι σημαντικοί: το `INDEX` τεκμηριώνεται με μορφή αναφοράς, ενώ το `LOOKUP` και το `MATCH` με μορφή διανύσματος. Το `DATE` χρησιμοποιεί το σύστημα ημερομηνίας 1900. Λειτουργίες που δεν αναφέρονται εδώ θεωρούνται μη υποστηριζόμενες από τον αξιολογητή τύπων του Aspose.Slides, εκτός εάν τεκμηριώνονται ξεχωριστά.

## **Υπολογισμός Τύπων με Προτιμώμενο Πολιτισμό**

Ορισμένες συναρτήσεις του workbook διαγράμματος ερμηνεύουν κείμενο σύμφωνα με πολιτισμικούς κανόνες. Αυτό είναι ιδιαίτερα σημαντικό για συναρτήσεις που προορίζονται για γλώσσες με σύστημα διπλού byte (DBCS). Για να υπολογίσετε σωστά τέτοιους τύπους, δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/), ορίστε τον προτιμώμενο πολιτισμό με το [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/el/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), αναθέστε τις επιλογές λογιστικού φύλλου μέσω του [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) και, τελικά, φορτώστε την παρουσίαση.

Το παρακάτω παράδειγμα επιλέγει τον ιαπωνικό πολιτισμό, ανοίγει μια παρουσίαση με τις ρυθμισμένες επιλογές φόρτωσης και καλεί το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) για κάθε workbook διαγράμματος:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

Ο προτιμώμενος πολιτισμός αποτελεί μέρος της ρύθμισης φόρτωσης της παρουσίασης, επομένως ορίστε τον πριν δημιουργήσετε το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/). Χρησιμοποιήστε τον πολιτισμό που απαιτούν οι τύποι του workbook· π.χ., `ja-JP` για τύπους που ακολουθούν κανόνες υπολογισμού ιαπωνικού DBCS.

## **Επανυπολογισμός και Αποθηκευμένες Τιμές**

Τα αρχεία λογιστικών φύλλων συνήθως αποθηκεύουν τόσο τον τύπο όσο και την τελευταία υπολογισμένη τιμή του. Το Aspose.Slides μπορεί επομένως να διαβάσει μια αποθηκευμένη τιμή από το [ChartDataCell.getValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#getValue) όταν φορτώνεται μια παρουσίαση και τα σχετικά δεδομένα διαγράμματος δεν έχουν αλλάξει.

Μετά την αλλαγή κελιών εισόδου ή τύπων, μην βασίζεστε σε παλιά αποθηκευμένα αποτελέσματα. Καλέστε το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) πριν διαβάσετε τις υπολογισμένες τιμές ή αποθηκεύσετε δεδομένα διαγράμματος που εξαρτώνται από αυτές.

Για τύπους εκτός του υποστηριζόμενου υποσυνόλου, το Aspose.Slides μπορεί να μην είναι σε θέση να αναλύσει τον τύπο ή να καθορίσει τις εξαρτήσεις του. Εάν το workbook έχει τροποποιηθεί, η προηγούμενη αποθηκευμένη τιμή δεν μπορεί πλέον να θεωρηθεί αξιόπιστη. Σε αυτή την κατάσταση, η ανάγνωση της τιμής ενός κελιού με μη υποστηριζόμενα δεδομένα μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/python-java/aspose.slides/cellunsupporteddataexception/).

Εάν το διάγραμμά σας εξαρτάται από συναρτήσεις Excel που το Aspose.Slides δεν αξιολογεί, υπολογίστε αυτούς τους τύπους με μια μηχανή λογιστικού φύλλου που τους υποστηρίζει και γράψτε τις προκύπτουσες τιμές πίσω στο workbook του διαγράμματος. Μην αντικαθιστάτε μη υποστηριζόμενους τύπους με εικαστικές τιμές.

## **Διαχείριση Σφαλμάτων Τύπων**

Υπάρχουν δύο διαφορετικά είδη προβλημάτων που πρέπει να διαχωρίσετε.

Ένας τύπος μπορεί να είναι έγκυρος αλλά να παράγει αποτέλεσμα σφάλματος λογιστικού φύλλου όπως `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ή `#VALUE!`. Σε αυτή την περίπτωση, το σφάλμα είναι αποτέλεσμα κελιού και μπορεί να επιστραφεί μέσω του [ChartDataCell.getValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#getValue).

Ένας τύπος μπορεί επίσης να αποτύχει στο στάδιο ανάλυσης, αναφοράς, εξάρτησης ή σε επίπεδο υποστηριζόμενων δεδομένων. Το Aspose.Slides παρέχει εξαιρέσεις ειδικές για λογιστικά φύλλα: [CellInvalidFormulaException](https://reference.aspose.com/slides/el/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/el/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/el/python-java/aspose.slides/cellcircularreferenceexception/) και [CellUnsupportedDataException](https://reference.aspose.com/slides/el/python-java/aspose.slides/cellunsupporteddataexception/).

Όταν οι τύποι προέρχονται από πρότυπα ή εισόδους χρήστη, χειριστείτε αυτές τις εξαιρέσεις γύρω από τον επανυπολογισμό και την πρόσβαση στην τιμή:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **Πρακτικές Περιορισμοί**

Η υποστήριξη τύπων σε φύλλα εργασίας διαγράμματος προορίζεται για ένα καθορισμένο υποσύνολο υπολογισμών λογιστικού φύλλου, όχι για πλήρη συμβατότητα με το Excel. Λάβετε υπόψη τους περιορισμούς αυτούς κατά το σχεδιασμό μιας ροής εργασίας αναφοράς:

- Χρησιμοποιείτε μόνο τις τεκμηριωμένες σταθερές, τελεστές, αναφορές και συναρτήσεις όταν χρειάζεται το Aspose.Slides να επανυπολογίσει τύπους.
- Επανυπολογίστε μετά την αλλαγή των κελιών από τα οποία εξαρτώνται τα αποτελέσματα των τύπων.
- Θεωρείτε τις αποθηκευμένες τιμές από φορτωμένες παρουσιάσεις ως στιγμιότυπα, όχι ως αντικατάσταση του επανυπολογισμού μετά από επεξεργασίες.
- Ελέγξτε τους τύπους από υπάρχοντα πρότυπα πριν βασιστείτε στις υπολογισμένες τους τιμές, ειδικά όταν χρησιμοποιούν συναρτήσεις εκτός της τεκμηριωμένης λίστας.
- Για τύπους που απαιτούν πλήρη μηχανή υπολογισμού λογιστικού φύλλου, υπολογίστε τους εξωτερικά και, στη συνέχεια, ενημερώστε το workbook διαγράμματος με τις προκύπτουσες τιμές.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ [ChartDataCell.setFormula](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#setFormula) και [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#setR1C1Formula);**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#setFormula) αποθηκεύει μια έκφραση στυλ A1 όπως `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#setR1C1Formula) αποθηκεύει μια έκφραση στυλ R1C1 όπως `RC[-2]-RC[-1]`. Χρησιμοποιήστε τη σημειολογία που ταιριάζει καλύτερα με το πώς δημιουργείτε ή αντιγράφετε τύπους.

**Πρέπει να διαβάσω το κελί ή την τιμή του μετά τον υπολογισμό;**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/#getCell) επιστρέφει ένα [ChartDataCell](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/). Για να αποκτήσετε το υπολογισμένο αποτέλεσμα, καλέστε τη μέθοδο [ChartDataCell.getValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#getValue) του κελιού μετά τον επανυπολογισμό.

**Πότε πρέπει να καλέσω [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/#calculateFormulas);**

Καλέστε το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) μετά την αλλαγή τιμών εισόδου ή τύπων και πριν εξαρτηθείτε από τα υπολογισμένα αποτελέσματα. Αυτό ενημερώνει τις τιμές των τύπων που υποστηρίζονται από τον ενσωματωμένο αξιολογητή.

**Το Aspose.Slides υποστηρίζει κάθε συνάρτηση Excel;**

Όχι. Ο ενσωματωμένος αξιολογητής υποστηρίζει ένα τεκμηριωμένο υποσύνολο συναρτήσεων. Οι συναρτήσεις εκτός αυτού του υποσυνόλου δεν πρέπει να θεωρούνται ότι επανυπολογίζονται σωστά. Εάν απαιτείται πλήρης συμβατότητα τύπων Excel, εκτελέστε τον υπολογισμό με κατάλληλη μηχανή λογιστικού φύλλου και γράψτε τις τελικές τιμές στο workbook διαγράμματος.

**Τι συμβαίνει αν μια φορτωμένη παρουσίαση περιέχει μη υποστηριζόμενο τύπο;**

Εάν τα δεδομένα διαγράμματος δεν έχουν αλλάξει, το workbook ενδέχεται να περιέχει ακόμη μια προηγούμενη υπολογισμένη αποθηκευμένη τιμή. Αφού τροποποιηθούν τα σχετικά δεδομένα, αυτή η αποθηκευμένη τιμή μπορεί να μην είναι πλέον έγκυρη. Η πρόσβαση σε κελί του οποίου ο τύπος δεν μπορεί να υποστηριχθεί μπορεί να προκαλέσει το [CellUnsupportedDataException](https://reference.aspose.com/slides/el/python-java/aspose.slides/cellunsupporteddataexception/).

**Οι τιμές σφάλματος τύπου είναι το ίδιο με τις εξαιρέσεις;**

Όχι. Ένα αποτέλεσμα όπως `#DIV/0!` είναι τιμή λογιστικού φύλλου που προκύπτει από έγκυρη αξιολόγηση. Οι εξαιρέσεις όπως [CellInvalidFormulaException](https://reference.aspose.com/slides/el/python-java/aspose.slides/cellinvalidformulaexception/) ή [CellCircularReferenceException](https://reference.aspose.com/slides/el/python-java/aspose.slides/cellcircularreferenceexception/) υποδεικνύουν ότι ο τύπος δεν μπορεί να επεξεργασθεί κανονικά.

**Το διάγραμμα ενημερώνεται αυτόματα όταν αλλάζει το κελί τύπου;**

Μια σειρά διαγράμματος μπορεί να αναφέρεται σε κελιά workbook. Επανυπολογίστε πρώτα το workbook, μετά αποθηκεύστε ή αποδώστε την παρουσίαση. Εάν τα σημεία δεδομένων του διαγράμματος αναφέρονται στα υπολογισμένα κελιά, το διάγραμμα χρησιμοποιεί αυτές τις ενημερωμένες τιμές· δεν απαιτείται ξεχωριστή μέθοδος ανανέωσης διαγράμματος.

**Μπορούν τα διαγράμματα να χρησιμοποιούν εξωτερικό βιβλίο εργασίας Excel;**

Ναι, τα δεδομένα διαγράμματος μπορούν να ρυθμιστούν ώστε να χρησιμοποιούν εξωτερικό βιβλίο εργασίας μέσω του API δεδομένων διαγράμματος. Ωστόσο, η ροή εργασίας υπολογισμού τύπων που περιγράφεται σε αυτό το άρθρο αφορά το workbook δεδομένων διαγράμματος και το υποσύνολο τύπων που αξιολογεί το Aspose.Slides. Μην υποθέτετε ότι το [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) παρέχει πλήρη επανυπολογισμό τυχαίων τύπων σε εξωτερικό αρχείο XLSX.

**Μπορώ να χρησιμοποιήσω τύπους που αναφέρονται σε άλλο φύλλο ή βιβλίο εργασίας;**

Οι αναφορές τύπου Excel μπορεί να υπάρχουν σε workbooks διαγράμματος, αλλά η αξιολόγηση τύπων περιορίζεται από τον υποστηριζόμενο αναλυτή και το σύνολο συναρτήσεων. Εάν είναι απαραίτητη μια διασταυρούμενη αναφορά, επαληθεύστε τον ακριβή τύπο με την έκδοση Aspose.Slides που χρησιμοποιείτε. Για ροές εργασίας που απαιτούν ευρεία συμβατότητα αναφορών Excel, υπολογίστε το workbook εξωτερικά και γράψτε τις επιλυμένες τιμές πίσω στα δεδομένα διαγράμματος.

**Πρέπει τα κείμενα τύπων να ξεκινούν με `=`;**

Παραδείγματα του API Aspose.Slides αναθέτουν εκφράσεις όπως `B2-C2` ή `SUM(B2:B5)` χωρίς προποριστικό `=`. Η χρήση αυτής της μορφής διατηρεί τους τύπους συμβατούς με τα τεκμηριωμένα παραδείγματα API.