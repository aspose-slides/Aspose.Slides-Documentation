---
title: Διαχείριση βιβλιοθηκών γραφημάτων σε παρουσιάσεις με Python
linktitle: Βιβλιοθήκη Γραφήματος
type: docs
weight: 70
url: /el/python-net/chart-workbook/
keywords:
- βιβλιοθήκη γραφήματος
- δεδομένα γραφήματος
- κελί βιβλιοθήκης
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερική βιβλιοθήκη
- εξωτερικά δεδομένα
- κρύπτη γραφήματος
- αποκατάσταση βιβλιοθήκης
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Python μέσω .NET: διαχειριστείτε εύκολα τις βιβλιοθήκες γραφημάτων στο PowerPoint και σε μορφές OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλιοθήκες γραφημάτων (chart workbooks) στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα γραφήματος μέσω ροών βιβλιοθήκης (workbook streams), να χρησιμοποιείτε κελιά βιβλιοθήκης ως ετικέτες δεδομένων γραφήματος, να προσπελάζετε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του γραφήματος.

Επίσης καλύπτει την εργασία με εξωτερικές βιβλιοθήκες ως πηγές δεδομένων για γραφήματα. Τα παραδείγματα επιδεικνύουν πώς να δημιουργήσετε και να αναθέσετε μια εξωτερική βιβλιοθήκη, να ανακτήσετε τη διαδρομή μιας εξωτερικής βιβλιοθήκης που συνδέεται με ένα γράφημα, και να επεξεργαστείτε τα δεδομένα γραφήματος όταν η βιβλιοθήκη είναι διαθέσιμη.

Για κελιά βιβλιοθήκης που αντιπροσωπεύουν ελλιπή δεδομένα, δείτε [Control the Display of Empty Cells](/slides/el/python-net/chart-series/) για τη διαφορά μεταξύ κενών κελιών και μηδενός, καθώς και για μια σύγκριση σε διάγραμμα γραμμής των διαθέσιμων τρόπων εμφάνισης.

## **Συμπερίληψη Δεδομένων από Κρυφές Γραμμές και Στήλες**

Χρησιμοποιήστε [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) για να ελέγξετε εάν ένα γράφημα σχεδιάζει δεδομένα από κρυφές γραμμές και στήλες φύλλου εργασίας. Ορίστε το σε `True` για να σχεδιάζονται μόνο τα ορατά κελιά, ή σε `False` για να συμπεριλαμβάνονται τόσο τα ορατά όσο και τα κρυφά κελιά. Αυτή η ρύθμιση ελέγχει τη σχεδίαση του γραφήματος· δεν κρύβει ή αποκαλύπτει γραμμές ή στήλες του φύλλου.

Κατεβάστε το [hidden-source-data.pptx](hidden-source-data.pptx) και τοποθετήστε το στον κατάλογο εργασίας. Η πρώτη διαφάνειά του περιλαμβάνει ένα διάγραμμα στήλης ως το πρώτο σχήμα. Το ενσωματωμένο φύλλο εργασίας, `Sheet1`, περιέχει την ακόλουθη περιοχή πηγής, `A1:C4`. Η γραμμή 3 και η στήλη C είναι κρυφές, αλλά τα κελιά τους εξακολουθούν να περιέχουν τιμές.

| Γραμμή φύλλου | A: Μήνας | B: Λιανική | C: Χονδρική (κρυστή στήλη) |
| --- | --- | --- | --- |
| 2 | Ιανουάριος | 10 | 30 |
| 3 (κρυφή γραμμή) | Φεβρουάριος | 40 | 60 |
| 4 | Μάρτιος | 20 | 50 |

Προσπελάστε τα κελιά πηγής μέσω του [ChartData.chart_data_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) και διαβάστε το [ChartDataCell.is_hidden](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatacell/is_hidden/) για να ελέγξετε την κρυφή κατάσταση τους. Αυτή η ιδιότητα είναι μόνο για ανάγνωση. Σε αυτό το αρχείο, το B2 είναι ορατό, το B3 ανήκει στη κρυφή γραμμή, και το C2 ανήκει στη κρυφή στήλη· το παράδειγμα εκτυπώνει `False`, `True` και `True`, αντίστοιχα.

Για αυτό το παράδειγμα, ανανεώστε τα δεδομένα του γραφήματος μετά την αλλαγή της ρύθμισης σχεδίασης: διατηρήστε την ενσωματωμένη βιβλιοθήκη με το [read_workbook_stream](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) και φορτώστε την ξανά με το [write_workbook_stream](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Όταν συμπεριλαμβάνονται όλα τα κελιά, χρησιμοποιήστε επίσης το [set_range](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_range/) για να επαναφέρετε την πλήρη περιοχή, συμπεριλαμβανομένης της κρυφής κατηγορίας Φεβρουάριος. Απλώς η αλλαγή της σημαίας δεν αρκεί για την ανανέωση των προσωρινά αποθηκευμένων δεδομένων και ετικετών κατηγοριών σε αυτό το δείγμα.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Ανανέωση των δεδομένων του γραφήματος από την ενσωματωμένη βιβλιοθήκη.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Επαναφορά της πλήρους περιοχής πηγής, συμπεριλαμβανομένων των κρυφών κατηγοριών.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Το παράδειγμα αποθηκεύει το `hidden_cells_True.pptx` μόνο με τις ορατές τιμές Λιανικής (10 και 20), και το `hidden_cells_False.pptx` με όλες τις έξι τιμές. Οι εικόνες παρακάτω δημιουργήθηκαν από τις αποθηκευμένες παρουσιάσεις μετά το άνοιγμα τους· και τα δύο αρχεία διατηρούν τη δοσμένη ρύθμιση σχεδίασης. Η γραμμή 3 και η στήλη C παραμένουν κρυφές και στις δύο ενσωματωμένες βιβλιοθήκες.

| Μόνο ορατά κελιά (`True`) | Όλα τα κελιά (`False`) |
| --- | --- |
| ![Μόνο ορατά κελιά: τιμές λιανικής 10 και 20 για Ιανουάριο και Μάρτιο.](hidden_cells_True.png) | ![Όλα τα κελιά: τιμές λιανικής και χονδρικής για Ιανουάριο, Φεβρουάριο και Μάρτιο.](hidden_cells_False.png) |

Ένα κρυφό κελί που περιέχει τιμή διαφέρει από ένα κενό κελί. Η μέθοδος [Chart.display_blanks_as](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/display_blanks_as/) ελέγχει πώς εμφανίζονται οι ελλιπείς τιμές· δεν περιλαμβάνει ή εξαιρεί κρυφά δεδομένα πηγής. Δείτε [Control the Display of Empty Cells](/slides/el/python-net/chart-series/#control-the-display-of-empty-cells) για παράδειγμα.

## **Ανάγνωση και Εγγραφή Δεδομένων Γραφήματος από Βιβλιοθήκη**

Aspose.Slides for Python μέσω .NET παρέχει τις μεθόδους [read_workbook_stream](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) και [write_workbook_stream](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) που επιτρέπουν την ανάγνωση και εγγραφή βιβλιοθηκών δεδομένων γραφήματος (που περιέχουν δεδομένα γραφήματος επεξεργασμένα με Aspose.Cells). **Σημείωση** ότι τα δεδομένα του γραφήματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

Αυτό το παράδειγμα ανοίγει το `chart.pptx`, το οποίο πρέπει να περιέχει ένα γράφημα ως το πρώτο σχήμα στην πρώτη του διαφάνεια. Διαβάζει την ενσωματωμένη βιβλιοθήκη σε μια ροή, διαγράφει τις υπάρχουσες σειρές και κατηγορίες, και γράφει ξανά την ίδια βιβλιοθήκη. Οι αλλαγές παραμένουν στη μνήμη· το παράδειγμα δεν αποθηκεύει την παρουσία.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Επικύρωση Διάταξης Γραφήματος μετά την Τροποποίηση της Βιβλιοθήκης**

Όταν αντικαθιστάτε μια ενσωματωμένη βιβλιοθήκη με μια τροποποιημένη, το γράφημα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυμφωνία μπορεί να προκαλέσει αποτυχία του [Chart.validate_chart_layout](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/validate_chart_layout/) με σφάλμα index-out-of-range. Διαγράψτε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε την ενημερωμένη βιβλιοθήκη πίσω στο γράφημα. Αυτό το παράδειγμα απαιτεί το `chart.pptx` με ένα γράφημα ως το πρώτο σχήμα στην πρώτη του διαφάνεια. Το σχόλιο υποδεικνύει πού θα γινόταν η επεξεργασία της βιβλιοθήκης· το εκτελέσιμο παράδειγμα γράφει ξανά την αρχική βιβλιοθήκη και επικυρώνει τη διάταξη στη μνήμη.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Τροποποιήστε τη ροή βιβλιοθήκης εδώ, για παράδειγμα, χρησιμοποιώντας το Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Η εκκαθάριση των συλλογών αφαιρεί παλαιές αναφορές δεδομένων πριν η βιβλιοθήκη γραφεί ξανά. Ανακατασκευάστε τυχόν απαραίτητες αντιστοιχίες σειρών και κατηγοριών για την ενημερωμένη βιβλιοθήκη πριν χρησιμοποιήσετε το γράφημα.

## **Ορισμός Κελιού Βιβλιοθήκης ως Ετικέτα Δεδομένων Γραφήματος**

Μπορείτε να χρησιμοποιήσετε κείμενο από κελιά βιβλιοθήκης ως ετικέτες δεδομένων γραφήματος. Τα παρακάτω βήματα δείχνουν πώς να συνδέσετε τις ετικέτες σε ένα διάγραμμα φυσαλίδων με κελιά του βιβλιοθήκης δεδομένων του.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Προσπελάστε την πρώτη διαφάνεια με το μηδενικό δείκτη της.
3. Προσθέστε ένα διάγραμμα φυσαλίδων με προεπιλεγμένα δεδομένα.
4. Προσπελάστε τις σειρές του γραφήματος.
5. Ορίστε το κελί βιβλιοθήκης ως ετικέτα δεδομένων.
6. Αποθηκεύστε την παρουσία.

Αυτό το παράδειγμα ανοίγει το `chart2.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια, και προσθέτει ένα διάγραμμα φυσαλίδων με προεπιλεγμένα δεδομένα. Χρησιμοποιεί τα κελιά A10:A12 στο φύλλο 0 για τις πρώτες τρεις ετικέτες στην πρώτη σειρά, ενεργοποιεί ετικέτες από κελιά, και αποθηκεύει το αποτέλεσμα στο `resultchart.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση Φύλλων Εργασίας**

Η ιδιότητα [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) παρέχει πρόσβαση στα φύλλα εργασίας σε μια βιβλιοθήκη γραφήματος. Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα πίτας με προεπιλεγμένα δεδομένα και εκτυπώνει το όνομα κάθε φύλλου στην κονσόλα.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Καθορισμός Τύπου Πηγής Δεδομένων**

Αυτό το παράδειγμα δημιουργεί ένα 3D διάγραμμα στήλης με προεπιλεγμένα δεδομένα και ορίζει δύο ονόματα σειρών χρησιμοποιώντας διαφορετικές πηγές δεδομένων. Το πρώτο όνομα χρησιμοποιεί κυριολεκτικό συμβολοσειρά· το δεύτερο χρησιμοποιεί το κελί C1 στο φύλλο 0. Η απαρίθμηση [DataSourceType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/datasourcetype/) επιλέγει την πηγή για κάθε όνομα. Το αποτέλεσμα αποθηκεύεται στο `pres.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλιοθήκης**

Το Aspose.Slides δεν υποστηρίζει τη δυαδική μορφή βιβλιοθήκης Excel (.xlsb) που μπορεί να ενσωματωθεί σε ορισμένα γραφήματα. Μπορείτε να χρησιμοποιήσετε την ιδιότητα [embedded_workbook_type](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) στην [ChartData](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/workbooktype/) για να ανιχνεύσετε μη υποστηριζόμενες μορφές και να παραλείψετε εκείνα τα γραφήματα. Αυτό το παράδειγμα ελέγχει τα σχήματα στην πρώτη διαφάνεια του `sample.pptx`, παραλείπει μη-γράφημα σχήματα, και εκτυπώνει μήνυμα διαγνώσεως για κάθε γράφημα με ενσωματωμένη βιβλιοθήκη .xlsb.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Διαβάστε ή τροποποιήστε εδώ τα υποστηριζόμενα δεδομένα βιβλιοθήκης γραφήματος.
```

## **Εξωτερική Βιβλιοθήκη**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλιοθηκών ως πηγή δεδομένων για γραφήματα.

### **Δημιουργία Εξωτερικής Βιβλιοθήκης**

Χρησιμοποιήστε το [read_workbook_stream](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) και το [set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) για να εξάγετε μια ενσωματωμένη βιβλιοθήκη γραφήματος σε αρχείο και να συνδέσετε το γράφημα με αυτήν την εξωτερική βιβλιοθήκη.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα πίτας με προεπιλεγμένα δεδομένα, γράφει τη βιβλιοθήκη του σε `externalWorkbook1.xlsx`, και κλείνει τη ροή εξόδου πριν αναθέσει το αρχείο ως πηγή δεδομένων του γραφήματος. Αποθηκεύει την συνδεδεμένη παρουσία στο `externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)
    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Ορισμός Εξωτερικής Βιβλιοθήκης**

Με τη μέθοδο [set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) μπορείτε να αναθέσετε μια εξωτερική βιβλιοθήκη σε ένα γράφημα ως πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για την ενημέρωση της διαδρομής προς την εξωτερική βιβλιοθήκη (αν αυτή μετακινήθηκε).

Αν και δεν μπορείτε να επεξεργαστείτε τα δεδομένα στις βιβλιοθήκες που αποθηκεύονται σε απομακρυσμένες θέσεις ή πόρους, μπορείτε ακόμη να τις χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για μια εξωτερική βιβλιοθήκη, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτό το παράδειγμα απαιτεί το `externalWorkbook.xlsx` στον κατάλογο εργασίας. Το φύλλο του, με όνομα `Sheet1`, πρέπει να περιέχει ένα όνομα σειράς στο B1, ονόματα κατηγοριών στο A2:A4, και αριθμητικές τιμές στο B2:B4. Το παράδειγμα δημιουργεί ένα διάγραμμα πίτας, συνδέει τη βιβλιοθήκη, και χρησιμοποιεί το [set_range](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_range/) για να αντιστοιχίσει το A1:B4 σε μία σειρά και τρεις κατηγορίες. Αποθηκεύει το αποτέλεσμα στο `Presentation_with_externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

Η παράμετρος `update_chart_data` της [set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ελέγχει εάν η βιβλιοθήκη θα φορτωθεί.

* Όταν `update_chart_data` είναι `False`, ενημερώνεται μόνο η διαδρομή της βιβλιοθήκης. Τα δεδομένα του γραφήματος δεν φορτώνονται ή ενημερώνονται από τη στοχευμένη βιβλιοθήκη, ώστε η βιβλιοθήκη να μπορεί να είναι μη διαθέσιμη.
* Όταν `update_chart_data` είναι `True`, τα δεδομένα του γραφήματος ενημερώνονται από τη στοχευμένη βιβλιοθήκη.

Το παρακάτω παράδειγμα αναθέτει μια εικονική URL με `update_chart_data` ορισμένο σε `False`. Διατηρεί τα προεπιλεγμένα δεδομένα του διαγράμματος πίτας και αποθηκεύει την παρουσία χωρίς να φορτώσει τη μη διαθέσιμη βιβλιοθήκη.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Λήψη Διαδρομής Βιβλιοθήκης Πηγής Δεδομένων Εξωτερικού Γραφήματος**

Για να εντοπίσετε τη βιβλιοθήκη που συνδέεται με ένα γράφημα, πρώτα ελέγξτε αν το γράφημα χρησιμοποιεί εξωτερική πηγή δεδομένων. Αν ναι, μπορείτε να ανακτήσετε τη διαδρομή της βιβλιοθήκης ακολουθώντας τα παρακάτω βήματα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
2. Προσπελάστε την πρώτη διαφάνεια με το μηδενικό δείκτη.
3. Ελέγξτε ότι το πρώτο σχήμα είναι γράφημα.
4. Διαβάστε τον τύπο πηγής δεδομένων του γραφήματος.
5. Αν η πηγή είναι εξωτερική βιβλιοθήκη, διαβάστε τη διαδρομή της.

Αυτό το παράδειγμα ανοίγει το `externalWorkbook.pptx`, που δημιουργήθηκε στο προηγούμενο παράδειγμα, και εξετάζει το πρώτο σχήμα στην πρώτη διαφάνεια. Αν είναι γράφημα συνδεδεμένο με εξωτερική βιβλιοθήκη, το παράδειγμα εκτυπώνει το [external_workbook_path](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/) στην κονσόλα. Στη συνέχεια αποθηκεύει ένα αντίγραφο της παρουσίασης στο `Result.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Επεξεργασία Δεδομένων Γραφήματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικές βιβλιοθήκες με τον ίδιο τρόπο που επεξεργάζεστε τα περιεχόμενα των εσωτερικών βιβλιοθηκών. Όταν μια εξωτερική βιβλιοθήκη δεν μπορεί να φορτωθεί, γίνεται εξαίρεση.

Αυτό το παράδειγμα απαιτεί το `presentation.pptx` με ένα γράφημα ως το πρώτο σχήμα στην πρώτη διαφάνεια και μια προσβάσιμη εξωτερική βιβλιοθήκη. Ορίζει την τιμή του πρώτου σημείου δεδομένων στην πρώτη σειρά σε 100 και αποθηκεύει την παρουσία στο `presentation_out.pptx`. Η επεξεργασία των τιμών κελιών μπορεί να ενημερώσει το συνδεδεμένο εξωτερικό αρχείο XLSX, οπότε χρησιμοποιήστε ένα αντίγραφο εάν πρέπει να διατηρήσετε την αρχική βιβλιοθήκη.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Αποκατάσταση Βιβλιοθήκης από την Κρυφή Μνήμη Γραφήματος**

Αν ένα γράφημα χρησιμοποιεί εξωτερική βιβλιοθήκη που λείπει ή δεν είναι διαθέσιμη, το Aspose.Slides μπορεί να ανακατασκευάσει τη βιβλιοθήκη του γραφήματος από τα δεδομένα που είναι κρυμμένα στην παρουσία. Δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/), διαμορφώστε το [spreadsheet_options](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/spreadsheet_options/), και ορίστε το [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/el/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) σε `True` πριν ανοίξετε την παρουσία.

Το παρακάτω παράδειγμα Python ανοίγει το `presentation.pptx`, του οποίου το πρώτο σχήμα στην πρώτη διαφάνεια πρέπει να είναι ένα γράφημα που παραπέμπει σε μη διαθέσιμη εξωτερική βιβλιοθήκη, και προσπελαύνει τα αποκατεστημένα δεδομένα μέσω του [Chart.chart_data](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/chart_data/) και του [ChartData.chart_data_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Διαβάστε ή τροποποιήστε τα δεδομένα της αποκατεστημένης βιβλιοθήκης εδώ.
    else:
        print("The first shape is not a chart.")
```

Αν η εξωτερική βιβλιοθήκη δεν είναι διαθέσιμη και η αποκατάσταση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει εξαίρεση. Ενεργοποιήστε την αποκατάσταση μόνο όταν η χρήση των κρυφών δεδομένων του γραφήματος είναι αποδεκτή εναλλακτική λύση, επειδή η κρύπτη μπορεί να μην περιέχει αλλαγές που έγιναν στην εξωτερική βιβλιοθήκη μετά την τελευταία ενημέρωση της παρουσίασης.

## **FAQ**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο γράφημα συνδέεται με εξωτερική ή ενσωματωμένη βιβλιοθήκη;**

Ναι. Ένα γράφημα έχει έναν [data source type](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/data_source_type/) και μια [path to an external workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Εάν η πηγή είναι εξωτερική βιβλιοθήκη, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται οι σχετικές διαδρομές σε εξωτερικές βιβλιοθήκες και πώς αποθηκεύονται;**

Ναι. Εάν ορίσετε σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Η παρουσία αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX, έτσι η μετακίνηση της βιβλιοθήκης μπορεί να απαιτεί ενημέρωση του συνδέσμου.

**Μπορώ να χρησιμοποιήσω βιβλιοθήκες που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοιες βιβλιοθήκες μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλιοθηκών απευθείας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό αρχείο XLSX κατά την αποθήκευση της παρουσίασης;**

Η παρουσία αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Η επεξεργασία των δεδομένων γραφήματος που προέρχονται από κελιά μπορεί επίσης να ενημερώσει το συνδεδεμένο τοπικό αρχείο XLSX. Χρησιμοποιήστε ένα αντίγραφο της βιβλιοθήκης εάν το αρχικό πρέπει να παραμείνει αμετάβλητο.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό πρόσβασης;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μία κοινή προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (για παράδειγμα, χρησιμοποιώντας το [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορούν πολλαπλά γραφήματα να αναφέρονται στην ίδια εξωτερική βιβλιοθήκη;**

Ναι. Κάθε γράφημα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε γράφημα την επόμενη φορά που θα φορτωθούν τα δεδομένα.