---
title: Διαχείριση βιβλίων εργασίας γραφήματος σε παρουσιάσεις με Python
linktitle: Βιβλίο Εργασίας Γραφήματος
type: docs
weight: 70
url: /el/python-net/chart-workbook/
keywords:
- βιβλίο εργασίας γραφήματος
- δεδομένα γραφήματος
- κελί βιβλίου εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερικό βιβλίο εργασίας
- εξωτερικά δεδομένα
- cache γραφήματος
- ανάκτηση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Python μέσω .NET: διαχειριστείτε άψογα βιβλία εργασίας γραφήματος σε μορφές PowerPoint και OpenDocument για να βελτιστοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας γραφήματος στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα γραφήματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων γραφήματος, να αποκτάτε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του γραφήματος.

Επιπλέον καλύπτει την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων γραφήματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να εκχωρήσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που συνδέεται με ένα γράφημα και να επεξεργαστείτε τα δεδομένα του γραφήματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

Για κελιά βιβλίου εργασίας που αντιπροσωπεύουν ελλείπουσες τιμές, δείτε [Έλεγχος της Εμφάνισης Κενών Κελιών](/slides/el/python-net/chart-series/) για τη διαφορά μεταξύ ενός κενού κελιού και του μηδενός, καθώς και μια σύγκριση διαγράμματος γραμμής των διαθέσιμων λειτουργιών εμφάνισης.

## **Συμπερίληψη Δεδομένων από Κρυφές Γραμμές και Στήλες**

Χρησιμοποιήστε [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) για να ελέγξετε αν ένα γράφημα σχεδιάζει δεδομένα από κρυφές γραμμές και στήλες φύλλου εργασίας. Ορίστε το σε `True` για να σχεδιάσει μόνο τα ορατά κελιά, ή σε `False` για να περιλάβει τόσο τα ορατά όσο και τα κρυφά κελιά. Αυτή η ρύθμιση ελέγχει το σχεδιασμό του γραφήματος· δεν κρύβει ή αποκρύβει γραμμές ή στήλες του φύλλου εργασίας.

Το [παράδειγμα παρουσίασης](hidden-source-data.pptx) περιέχει ένα γράφημα στήλης ως το πρώτο σχήμα στην πρώτη του διαφάνεια. Το ενσωματωμένο φύλλο εργασίας, `Sheet1`, περιέχει την ακόλουθη περιοχή προέλευσης, `A1:C4`. Η γραμμή 3 και η στήλη C είναι κρυφές, αλλά τα κελιά τους εξακολουθούν να περιέχουν τιμές.

| Γραμμή φύλλου | Α: Μήνας | Β: Λιανική | Γ: Χονδρική (κρυφή στήλη) |
| --- | --- | --- | --- |
| 2 | Ιανουάριος | 10 | 30 |
| 3 (κρυφή γραμμή) | Φεβρουάριος | 40 | 60 |
| 4 | Μάρτιος | 20 | 50 |

Προσπελάστε τα κελιά προέλευσης μέσω [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) και διαβάστε [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) για να ελέγξετε την κρυφή κατάσταση τους. Αυτή η ιδιότητα είναι μόνο ανάγνωση. Σε αυτό το αρχείο, το B2 είναι ορατό, το B3 ανήκει στην κρυφή γραμμή και το C2 ανήκει στην κρυφή στήλη· το παράδειγμα εκτυπώνει `False`, `True` και `True` αντίστοιχα.

Για αυτό το παράδειγμα, ανανεώστε τα δεδομένα του γραφήματος μετά την αλλαγή της ρύθμισης σχεδίασης: διατηρήστε το ενσωματωμένο βιβλίο εργασίας με [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) και ξαναφορτώστε το με [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Όταν περιλαμβάνετε όλα τα κελιά, χρησιμοποιήστε επίσης [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) για να επαναφέρετε την πλήρη περιοχή, συμπεριλαμβανομένης της κρυφής κατηγορίας Φεβρουαρίου. Η απλή αλλαγή της σημαίας δεν είναι επαρκής για την ανανέωση των δεδομένων και των ετικετών κατηγοριών του αποθηκευμένου δείγματος.

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

            # Ανανέωση των δεδομένων του γραφήματος από το ενσωματωμένο βιβλίο εργασίας.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Επαναφορά της πλήρους περιοχής προέλευσης, συμπεριλαμβανομένων των κρυφών κατηγοριών.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Το παράδειγμα αποθηκεύει δύο εκδοχές της παρουσίασης: μια μόνο με τις ορατές τιμές λιανικής (10 και 20) και μια άλλη με όλες τις έξι τιμές. Οι εικόνες παρακάτω δημιουργήθηκαν από τις αποθηκευμένες παρουσιάσεις μετά το άνοιγμα τους· και τα δύο αρχεία διατηρούν τη ρυθμισμένη σχεδίαση. Η γραμμή 3 και η στήλη C παραμένουν κρυφές και στα δύο ενσωματωμένα βιβλία εργασίας.

| Μόνο ορατά κελιά (`True`) | Όλα τα κελιά (`False`) |
| --- | --- |
| ![Μόνο ορατά κελιά: Τιμές λιανικής 10 και 20 για Ιανουάριο και Μάρτιο.](hidden_cells_True.png) | ![Όλα τα κελιά: Τιμές λιανικής και χονδρικής για Ιανουάριο, Φεβρουάριο και Μάρτιο.](hidden_cells_False.png) |

Ένα κρυφό κελί που περιέχει τιμή διαφέρει από ένα κενό κελί. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) ελέγχει πώς εμφανίζονται οι ελλιπείς τιμές· δεν περιλαμβάνει ή εξαιρεί κρυφά δεδομένα προέλευσης. Δείτε [Έλεγχος της Εμφάνισης Κενών Κελιών](/slides/el/python-net/chart-series/#control-the-display-of-empty-cells) για ένα παράδειγμα.

## **Ανάκτηση της Περιοχής Δεδομένων ενός Γραφήματος**

Πριν ενημερώσετε τα δεδομένα βιβλίου εργασίας σε μια υπάρχουσα παρουσίαση, εξετάστε τις περιοχές προέλευσης για να εντοπίσετε ποια κελιά φύλλου εργασίας χρησιμοποιεί κάθε γράφημα. Η μέθοδος [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) επιστρέφει την τρέχουσα περιοχή δεδομένων ως τύπο φύλλου εργασίας, π.χ. `Sheet1!$A$1:$D$5`. Εδώ, το `Sheet1` είναι το όνομα του φύλλου, το `!` το διαχωρίζει από την περιοχή κελιών και το `$A$1:$D$5` προσδιορίζει τα κελιά A1 έως D5, συμπεριλαμβανομένων. Τα σύμβολα δολαρίου υποδεικνύουν απόλυτες αναφορές γραμμής και στήλης.

Η μέθοδος διαβάζει την τρέχουσα περιοχή χωρίς να αλλάξει το γράφημα ή το βιβλίο εργασίας του. Εάν το γράφημα δεν χρησιμοποιεί βιβλίο εργασίας ως πηγή δεδομένων, εγείρει εξαίρεση. Για περισσότερες πληροφορίες, δείτε την [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Αυτό το παράδειγμα ανοίγει μια παρουσίαση και ελέγχει άμεσα τα σχήματα σε κάθε διαφάνεια για γραφήματα. Εκτυπώνει το όνομα και την περιοχή προέλευσης κάθε γραφήματος. Εάν η περιοχή δεν μπορεί να ανακτηθεί, εκτυπώνει ένα διαγνωστικό μήνυμα και συνεχίζει με το επόμενο γράφημα.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Ανάγνωση και Εγγραφή Δεδομένων Γραφήματος από Βιβλίο Εργασίας**

Το Aspose.Slides for Python via .NET παρέχει τις μεθόδους [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) και [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) που επιτρέπουν την ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων γραφήματος (που περιέχουν δεδομένα γραφήματος επεξεργασμένα με Aspose.Cells). **Σημείωση** ότι τα δεδομένα του γραφήματος πρέπει να οργανωθούν με τον ίδιο τρόπο ή να έχουν παρόμοια δομή με την πηγή.

Αυτό το παράδειγμα χρησιμοποιεί μια παρουσίαση με ένα γράφημα ως το πρώτο σχήμα στην πρώτη του διαφάνεια. Διαβάζει το ενσωματωμένο βιβλίο εργασίας σε μια ροή, καθαρίζει τις υπάρχουσες σειρές και κατηγορίες, και γράφει ξανά το ίδιο βιβλίο. Οι αλλαγές παραμένουν στη μνήμη· το παράδειγμα δεν αποθηκεύει την παρουσίαση.

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

### **Επικύρωση Διάταξης Γραφήματος μετά την Τροποποίηση του Βιβλίου Εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το γράφημα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυμφωνία μπορεί να προκαλέσει αποτυχία της [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) με σφάλμα «index-out-of-range». Καθαρίστε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο γράφημα. Αυτό το παράδειγμα χρησιμοποιεί ένα γράφημα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια. Το σχόλιο σημειώνει πού θα γινόταν η επεξεργασία του βιβλίου εργασίας· το εκτελέσιμο παράδειγμα γράφει το αρχικό βιβλίο εργασίας πίσω και επικυρώνει τη διάταξη στη μνήμη.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Τροποποιήστε τη ροή βιβλίου εργασίας εδώ, για παράδειγμα, χρησιμοποιώντας το Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Ο καθαρισμός των συλλογών αφαιρεί παλιές αναφορές δεδομένων πριν το βιβλίο εργασίας γραφτεί ξανά. Ανακατασκευάστε τυχόν απαιτούμενες αντιστοιχίες σειρών και κατηγοριών για το ενημερωμένο βιβλίο εργασίας πριν χρησιμοποιήσετε το γράφημα.

## **Ορισμός Κελιού Βιβλίου Εργασίας ως Ετικέτας Δεδομένων Γραφήματος**

Μπορείτε να χρησιμοποιήσετε κείμενο από κελιά βιβλίου εργασίας ως ετικέτες δεδομένων γραφήματος.

Αυτό το παράδειγμα προσθέτει ένα γράφημα φυσαλίδων με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Χρησιμοποιεί τα κελιά A10:A12 στο φύλλο 0 για τις πρώτες τρεις ετικέτες της πρώτης σειράς, ενεργοποιεί ετικέτες από κελιά και αποθηκεύει την ενημερωμένη παρουσίαση.

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

## **Διαχείριση Φυλλαδιών**

Η ιδιότητα [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) παρέχει πρόσβαση στα φύλλα εργασίας ενός βιβλίου εργασίας γραφήματος. Αυτό το παράδειγμα δημιουργεί ένα γράφημα πίτας με προεπιλεγμένα δεδομένα και εκτυπώνει το όνομα κάθε φύλλου στην κονσόλα.

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

Αυτό το παράδειγμα δημιουργεί ένα 3Δ γράφημα στήλης με προεπιλεγμένα δεδομένα και ορίζει δύο ονόματα σειρών χρησιμοποιώντας διαφορετικές πηγές δεδομένων. Το πρώτο όνομα χρησιμοποιεί κυριολεκτικό συμβολοσειρά· το δεύτερο χρησιμοποιεί το κελί C1 στο φύλλο 0. Η απαρίθμηση [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) επιλέγει την πηγή για κάθε όνομα. Το παράδειγμα αποθηκεύει την παρουσίαση με τα ενημερωμένα ονόματα σειρών.

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

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλίου Εργασίας**

Το Aspose.Slides δεν υποστηρίζει την δυαδική μορφή βιβλίου εργασίας Excel (.xlsb) που μπορεί να ενσωματωθεί σε ορισμένα γραφήματα. Μπορείτε να χρησιμοποιήσετε την ιδιότητα [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) στο [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα γραφήματα. Αυτό το παράδειγμα εξετάζει τα σχήματα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης, παραλείπει τα μη-γράφημα σχήματα, και εκτυπώνει ένα διαγνωστικό μήνυμα για κάθε γράφημα με ενσωματωμένο βιβλίο εργασίας .xlsb.

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

        # Διαβάστε ή τροποποιήστε τα υποστηριζόμενα δεδομένα βιβλίου εργασίας γραφήματος εδώ.
```

## **Εξωτερικό Βιβλίο Εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για γραφήματα.

### **Δημιουργία Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιήστε [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) και [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) για να εξάγετε ένα ενσωματωμένο βιβλίο εργασίας γραφήματος σε αρχείο και να συνδέσετε το γράφημα με αυτό το εξωτερικό βιβλίο.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα πίτας με προεπιλεγμένα δεδομένα και εξάγει το βιβλίο του. Κλείνει τη ροή εξόδου πριν εκχωρήσει το εξωτερικό βιβλίο εργασίας ως πηγή δεδομένων γραφήματος, μετά αποθηκεύει την συνδεδεμένη παρουσίαση.

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

### **Ορισμός Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τη μέθοδο [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), μπορείτε να εκχωρήσετε ένα εξωτερικό βιβλίο εργασίας σε ένα γράφημα ως πηγή δεδομένων του. Η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για να ενημερώσει μια διαδρομή σε εξωτερικό βιβλίο εργασίας (αν το τελευταίο μετακινήθηκε).

Αν και δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας αποθηκευμένα σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμη να τα χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτό το παράδειγμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας του οποίου το φύλλο εργασίας με όνομα `Sheet1` περιέχει ένα όνομα σειράς στο B1, ονόματα κατηγοριών στο A2:A4 και αριθμητικές τιμές στο B2:B4. Το παράδειγμα δημιουργεί ένα γράφημα πίτας, συνδέει το βιβλίο εργασίας και χρησιμοποιεί [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) για να χαρτογραφήσει το A1:B4 σε μία σειρά και τρεις κατηγορίες. Αποθηκεύει την παρουσίαση με το συνδεδεμένο γράφημα.

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

Η παράμετρος `update_chart_data` της [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ελέγχει αν το βιβλίο εργασίας θα φορτωθεί.

* Όταν `update_chart_data` είναι `False`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας. Τα δεδομένα του γραφήματος δεν φορτώνονται ή ενημερώνονται από το στοχευμένο βιβλίο εργασίας, ώστε το βιβλίο εργασίας να μπορεί να είναι μη διαθέσιμο.
* Όταν `update_chart_data` είναι `True`, τα δεδομένα του γραφήματος ενημερώνονται από το στοχευμένο βιβλίο εργασίας.

Το παρακάτω παράδειγμα εκχωρεί ένα URL placeholder με `update_chart_data` ορισμένο σε `False`. Διατηρεί τα προεπιλεγμένα δεδομένα του γραφήματος πίτας και αποθηκεύει την παρουσίαση χωρίς να φορτώσει το μη διαθέσιμο βιβλίο εργασίας.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Ανάκτηση Διαδρομής Εξωτερικού Βιβλίου Πηγής Δεδομένων ενός Γραφήματος**

Για τον εντοπισμό του βιβλίου εργασίας που συνδέεται με ένα γράφημα, ελέγξτε εάν το γράφημα χρησιμοποιεί εξωτερική πηγή δεδομένων και ανακτήστε τη διαδρομή του βιβλίου εργασίας.

Αυτό το παράδειγμα εξετάζει το πρώτο σχήμα στην πρώτη διαφάνεια μιας παρουσίασης με συνδεδεμένο εξωτερικό βιβλίο εργασίας. Αν είναι γράφημα συνδεδεμένο σε εξωτερικό βιβλίο, το παράδειγμα εκτυπώνει [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) στην κονσόλα. Στη συνέχεια αποθηκεύει ένα αντίγραφο της παρουσίασης.

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

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στα περιεχόμενα των εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, εκτοξεύεται εξαίρεση.

Αυτό το παράδειγμα χρησιμοποιεί ένα γράφημα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και είναι συνδεδεμένο με ένα προσβάσιμο εξωτερικό βιβλίο εργασίας. Ορίζει την τιμή που προέρχεται από κελί του πρώτου σημείου δεδομένων της πρώτης σειράς σε 100 και αποθηκεύει την ενημερωμένη παρουσίαση. Η επεξεργασία τιμών κελιών μπορεί να ενημερώσει το συνδεδεμένο εξωτερικό αρχείο XLSX, οπότε χρησιμοποιήστε ένα αντίγραφο εάν χρειάζεται να διατηρήσετε το αρχικό βιβλίο εργασίας.

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

### **Ανάκτηση Βιβλίου Εργασίας από την Cache του Γραφήματος**

Εάν ένα γράφημα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να αναδημιουργήσει το βιβλίο εργασίας του γραφήματος από τα δεδομένα που έχουν αποθηκευτεί στην cache της παρουσίασης. Δημιουργήστε [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), ρυθμίστε το [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), και ορίστε [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) σε `True` πριν ανοίξετε την παρουσίαση.

Το ακόλουθο παράδειγμα Python ανακτά δεδομένα βιβλίου εργασίας για ένα γράφημα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και αναφέρεται σε μη διαθέσιμο εξωτερικό βιβλίο εργασίας. Πρόσβαση στα ανακτημένα δεδομένα γίνεται μέσω [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) και [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # Διαβάστε ή τροποποιήστε τα ανακτημένα δεδομένα βιβλίου εργασίας εδώ.
    else:
        print("The first shape is not a chart.")
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides εγείρει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων της cache του γραφήματος αποτελεί αποδεκτό εναλλακτικό σενάριο, επειδή η cache μπορεί να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο γράφημα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα γράφημα έχει έναν [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) και μια [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); εάν η πηγή είναι ένα εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται ένα εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX, έτσι η μετακίνηση του βιβλίου εργασίας μπορεί να απαιτήσει ενημέρωση του συνδέσμου.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια βιβλία μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Το Aspose.Slides αντικαθιστά το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Η επεξεργασία δεδομένων γραφήματος που προέρχονται από κελία μπορεί επίσης να ενημερώσει το συνδεδεμένο τοπικό αρχείο XLSX. Χρησιμοποιήστε ένα αντίγραφο του βιβλίου εργασίας εάν το αρχικό πρέπει να παραμείνει αμετάβλητο.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια συνηθισμένη προσέγγιση είναι η αφαίρεση της προστασίας εκ των προτέρων ή η προετοιμασία ενός αποκρυπτογραφημένου αντιγράφου (π.χ., χρησιμοποιώντας [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) και η σύνδεση με αυτό το αντίγραφο.

**Μπορούν πολλά γραφήματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε γράφημα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντανακλάται σε κάθε γράφημα την επόμενη φορά που θα φορτωθούν τα δεδομένα.