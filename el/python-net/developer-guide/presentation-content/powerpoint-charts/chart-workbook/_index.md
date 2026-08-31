---
title: Διαχείριση Βιβλίων Εργασίας Διαγραμμάτων σε Παρουσιάσεις με Python
linktitle: Βιβλίο Εργασίας Διαγράμματος
type: docs
weight: 70
url: /el/python-net/chart-workbook/
keywords:
- βιβλίο εργασίας διαγράμματος
- δεδομένα διαγράμματος
- κελί βιβλίου εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερικό βιβλίο εργασίας
- εξωτερικά δεδομένα
- cache διαγράμματος
- ανάκτηση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Python μέσω .NET: διαχειριστείτε εύκολα βιβλία εργασίας διαγράμματος σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να αποκτάτε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης τη χρήση εξωτερικών βιβλίων εργασίας ως πηγών δεδομένων διαγραμμάτων. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αναθέσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που συνδέεται με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Βιβλίο Εργασίας**

Το Aspose.Slides παρέχει μεθόδους για την ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Σημείωση:** Τα δεδομένα διαγράμματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

Ο παρακάτω κώδικας Python δείχνει ένα παράδειγμα λειτουργίας:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **Επικύρωση Διάταξης Διαγράμματος μετά την Τροποποίηση του Βιβλίου Εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το διάγραμμα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυμφωνία μπορεί να προκαλέσει αποτυχία του [IChart.validate_chart_layout](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichart/validate_chart_layout/) με σφάλμα «index‑out‑of‑range». Καθαρίστε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο διάγραμμα.

```python
# Μετά την τροποποίηση της ροής βιβλίου εργασίας (π.χ., χρησιμοποιώντας Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Καθαρίστε τις υπάρχουσες αναφορές δεδομένων.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Ο καθαρισμός των συλλογών διασφαλίζει ότι η δομή των δεδομένων διαγράμματος είναι σύμφωνη με το νέο βιβλίο εργασίας, επιτρέποντας στο `validate_chart_layout` να ολοκληρωθεί χωρίς σφάλματα.

## **Ορισμός Κελιού του Workbook ως Ετικέτας Δεδομένων Διαγράμματος**

Μερικές φορές χρειάζεστε ετικέτες διαγράμματος που προέρχονται απευθείας από κελιά του υποκείμενου βιβλίου εργασίας. Το Aspose.Slides σας επιτρέπει να δεσμεύσετε ετικέτες δεδομένων σε συγκεκριμένα κελιά ώστε το κείμενο της ετικέτας να αντανακλά πάντα την τιμή του κελιού. Το παρακάτω παράδειγμα δείχνει πώς να ενεργοποιήσετε ετικέτες τιμής‑από‑κελί και να κατευθύνετε τις επιλεγμένες ετικέτες σε προσαρμοσμένα κελιά στο βιβλίο εργασίας του διαγράμματος.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/).
1. Λάβετε μια αναφορά στη διαφάνεια με βάση τον δείκτη.
1. Προσθέστε ένα διάγραμμα φυσαλίδων με δείγμα δεδομένων.
1. Πρόσβαση στη σειρά του διαγράμματος.
1. Χρησιμοποιήστε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Python δείχνει πώς να ορίσετε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων διαγράμματος:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαχείριση Φύλλων Εργασίας**

Ο παρακάτω κώδικας Python δείχνει πώς να χρησιμοποιήσετε την ιδιότητα `worksheets` για πρόσβαση στη συλλογή φύλλων εργασίας:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Καθορισμός Τύπου Πηγής Δεδομένων**

Ο παρακάτω κώδικας Python δείχνει πώς να καθορίσετε τύπο πηγής δεδομένων:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλίου Εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη μορφή δυαδικού βιβλίου εργασίας Excel (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε την ιδιότητα `embedded_workbook_type` στην [ChartData](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε εκείνα τα διαγράμματα.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # Το ενσωματωμένο βιβλίο εργασίας είναι σε μορφή .xlsb, η οποία δεν υποστηρίζεται.
            continue

        # Διαβάστε ή τροποποιήστε τα δεδομένα του βιβλίου εργασίας διαγράμματος εδώ.
```

## **Εξωτερικά Βιβλία Εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για διαγράμματα.

### **Ορισμός Εξωτερικών Βιβλίων Εργασίας**

Με τη μέθοδο [ChartData.set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) μπορείτε να αναθέσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Η μέθοδος αυτή μπορεί επίσης να ενημερώσει τη διαδρομή προς ένα εξωτερικό βιβλίο εργασίας εάν έχει μετακινηθεί.

Αν και δεν μπορείτε να επεξεργαστείτε δεδομένα σε βιβλία εργασίας που βρίσκονται σε απομακρυσμένες θέσεις ή πόρους, μπορείτε ακόμη να τα χρησιμοποιήσετε ως εξωτερικές πηγές δεδομένων. Εάν δώσετε σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Ο παρακάτω κώδικας Python δείχνει πώς να ορίσετε ένα εξωτερικό βιβλίο εργασίας:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Δώστε False ώστε να αποθηκεύεται μόνο η διαδρομή: το στοχευόμενο βιβλίο εργασίας δεν χρειάζεται να υπάρχει ακόμη.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Η παράμετρος `update_chart_data` της μεθόδου [set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) καθορίζει εάν το βιβλίο εργασίας Excel θα φορτωθεί.

- Όταν `update_chart_data` είναι `False`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας· τα δεδομένα του διαγράμματος δεν φορτώνονται ούτε ανανεώνονται από το στοχευμένο βιβλίο εργασίας. Χρησιμοποιήστε αυτή τη ρύθμιση όταν το στοχευμένο βιβλίο εργασίας δεν υπάρχει ή δεν είναι διαθέσιμο.
- Όταν `update_chart_data` είναι `True` (η προεπιλογή), τα δεδομένα του διαγράμματος φορτώνονται και ενημερώνονται από το στοχευμένο βιβλίο εργασίας. Εάν αυτό το βιβλίο εργασίας δεν μπορεί να ανοίξει, ρίχνεται εξαίρεση με το μήνυμα «External workbook is not available».

### **Δημιουργία Εξωτερικών Βιβλίων Εργασίας**

Με τις μεθόδους [read_workbook_stream](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) και [set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) μπορείτε είτε να δημιουργήσετε ένα εξωτερικό βιβλίο εργασίας από το μηδέν είτε να μετατρέψετε ένα εσωτερικό βιβλίο εργασίας σε εξωτερικό.

Αυτός ο κώδικας Python επιδεικνύει τη διαδικασία δημιουργίας εξωτερικού βιβλίου εργασίας:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Ανάκτηση Διαδρομής Εξωτερικής Πηγής Βιβλίου Εργασίας για Διάγραμμα**

Μερικές φορές τα δεδομένα ενός διαγράμματος είναι συνδεδεμένα με ένα εξωτερικό βιβλίο εργασίας Excel αντί για τα ενσωματωμένα δεδομένα της παρουσίασης. Με το Aspose.Slides μπορείτε να ελέγξετε την πηγή δεδομένων του διαγράμματος και, εάν είναι εξωτερικό βιβλίο εργασίας, να διαβάσετε τη πλήρη διαδρομή του.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/).
1. Λάβετε μια αναφορά στη διαφάνεια με τον δείκτη της.
1. Λάβετε μια αναφορά στο σχήμα του διαγράμματος.
1. Αποκτήστε την πηγή ([ChartDataSourceType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatasourcetype/)) που αντιπροσωπεύει την πηγή δεδομένων του διαγράμματος.
1. Ελέγξτε εάν ο τύπος πηγής ταιριάζει με τον τύπο εξωτερικού βιβλίου εργασίας.

Ο παρακάτω κώδικας Python δείχνει τη λειτουργία:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Επεξεργασία Δεδομένων Διαγράμματος**

Μπορείτε να επεξεργαστείτε δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που επεξεργάζεστε δεδομένα σε εσωτερικά βιβλία εργασίας. Εάν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, ρίχνεται εξαίρεση.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Ανάκτηση Βιβλίου Εργασίας από την Cache του Διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να επανασυνθέσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που είναι cache στην παρουσίαση. Δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/), στη συνέχεια ενεργοποιήστε το [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/el/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) μέσω του [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/spreadsheet_options/) πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα Python ανοίγει μια παρουσίαση της οποίας το διάγραμμα αναφέρει ένα μη διαθέσιμο εξωτερικό βιβλίο εργασίας και προσπελαύνει τα ανακτημένα δεδομένα μέσω του [Chart.chart_data](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/chart_data/) και του [ChartData.chart_data_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Διαβάστε ή τροποποιήστε τα δεδομένα του ανακτημένου βιβλίου εργασίας εδώ.
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των cache δεδομένων διαγράμματος αποτελεί αποδεκτό εναλλακτικό σενάριο, επειδή η cache μπορεί να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συνήθεις Ερωτήσεις (FAQ)**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα διαθέτει έναν [data source type](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/data_source_type/) και μια [path to an external workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Αυτό είναι βολικό για τη φορητότητα του έργου· ωστόσο, η παρουσίαση θα αποθηκεύσει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους δίσκους;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η άμεση επεξεργασία απομακρυσμένων βιβλίων εργασίας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Αντικαθιστά το Aspose.Slides το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Μόνο εάν έχετε επεξεργαστεί τα δεδομένα του διαγράμματος. Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/) και τον χρησιμοποιεί για ανάγνωση δεδομένων, οπότε το άνοιγμα και η αποθήκευση της παρουσίασης δεν τροποποιούν το βιβλίο εργασίας. Ωστόσο, οι τιμές που αλλάζετε μέσω των δεδομένων του διαγράμματος (δείτε το **Edit Chart Data** πιο πάνω) γράφονται πίσω στο εξωτερικό βιβλίο εργασίας όταν αποθηκεύεται η παρουσίαση· δουλέψτε με αντίγραφο εάν το αρχικό πρέπει να παραμείνει αμετάβλητο.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια συνήθης προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (για παράδειγμα, χρησιμοποιώντας [Aspose.Cells](/cells/python-net/)) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα την επόμενη φορά που θα φορτωθούν τα δεδομένα.