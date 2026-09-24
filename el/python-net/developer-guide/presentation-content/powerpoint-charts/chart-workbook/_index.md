---
title: Διαχείριση βιβλίων εργασίας διαγράμματος σε παρουσιάσεις με Python
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
- λανθάνουσα μνήμη διαγράμματος
- αποκατάσταση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Python μέσω .NET: διαχειριστείτε με ευκολία τα βιβλία εργασίας διαγράμματος σε μορφές PowerPoint και OpenDocument για να βελτιστοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να προσπελάζετε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να εκχωρήσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας συνδεδεμένου με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

Για κελιά βιβλίου εργασίας που αντιπροσωπεύουν ελλιπή δεδομένα, δείτε [Έλεγχος της εμφάνισης κενών κελιών](/slides/el/python-net/chart-series/) για τη διαφορά μεταξύ κενών κελιών και μηδενικών, καθώς και μια σύγκριση γραμμικού διαγράμματος των διαθέσιμων τρόπων εμφάνισης.

## **Ανάγνωση και εγγραφή δεδομένων διαγράμματος από βιβλίο εργασίας**

Το Aspose.Slides παρέχει μεθόδους για ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Σημείωση:** Τα δεδομένα του διαγράμματος πρέπει να οργανωθούν με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

Ο παρακάτω κώδικας Python παρουσιάζει ένα δείγμα λειτουργίας:

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

### **Επικύρωση διάταξης διαγράμματος μετά την τροποποίηση του βιβλίου εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το διάγραμμα διατηρεί τις αρχικές σειρές και τις συλλογές κατηγοριών του. Αυτή η ασυμφωνία μπορεί να προκαλέσει αποτυχία του [IChart.validate_chart_layout](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/ichart/validate_chart_layout/) με σφάλμα «index‑out‑of‑range». Καθαρίστε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο διάγραμμα.

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

Η εκκαθάριση των συλλογών εξασφαλίζει ότι η δομή των δεδομένων του διαγράμματος είναι σύμφωνη με το νέο βιβλίο εργασίας, επιτρέποντας στο `validate_chart_layout` να ολοκληρωθεί χωρίς σφάλματα.

## **Ορισμός κελιού βιβλίου εργασίας ως ετικέτας δεδομένων διαγράμματος**

Μερικές φορές χρειάζεστε ετικέτες διαγράμματος που προέρχονται απευθείας από κελιά του υποκείμενου βιβλίου εργασίας. Το Aspose.Slides σας επιτρέπει να συνδέσετε ετικέτες δεδομένων με συγκεκριμένα κελιά βιβλίου εργασίας ώστε το κείμενο της ετικέτας να αντανακλά πάντα την τιμή του κελιού. Το παρακάτω παράδειγμα δείχνει πώς να ενεργοποιήσετε ετικέτες τιμής‑από‑κελί και να κατευθύνετε επιλεγμένες ετικέτες σε προσαρμοσμένα κελιά στο βιβλίο εργασίας του διαγράμματος.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/).
1. Λάβετε αναφορά στη διαφάνεια με βάση το δείκτη.
1. Προσθέστε ένα διάγραμμα φυσαλίδων με δείγμα δεδομένων.
1. Προσπελάστε τις σειρές του διαγράμματος.
1. Χρησιμοποιήστε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Python δείχνει πώς να ορίσετε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων διαγράμματος:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Δημιουργήστε την κλάση Presentation η οποία αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

## **Διαχείριση φύλλων εργασίας**

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

## **Καθορισμός τύπου πηγής δεδομένων**

Ο παρακάτω κώδικας Python δείχνει πώς να καθορίσετε έναν τύπο πηγής δεδομένων:

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

## **Ανίχνευση μη υποστηριζόμενων ενσωματωμένων μορφών βιβλίου εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη μορφή βιβλίου εργασίας Excel δυαδικό (.xlsb) που μπορεί να ενσωματωθεί σε κάποια διαγράμματα. Μπορείτε να χρησιμοποιήσετε την ιδιότητα `embedded_workbook_type` στο [ChartData](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/workbooktype/) για να ανιχνεύσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα διαγράμματα.

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

        # Διαβάστε ή τροποποιήστε τα δεδομένα του βιβλίου εργασίας του διαγράμματος εδώ.
```

## **Εξωτερικά βιβλία εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για διαγράμματα.

### **Ορισμός εξωτερικών βιβλίων εργασίας**

Χρησιμοποιώντας τη μέθοδο [ChartData.set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/), μπορείτε να εκχωρήσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή του. Η μέθοδος αυτή μπορεί επίσης να ενημερώσει τη διαδρομή σε ένα εξωτερικό βιβλίο εργασίας εάν έχει μετακινηθεί.

Αν και δεν μπορείτε να επεξεργαστείτε δεδομένα σε βιβλία εργασίας αποθηκευμένα σε απομακρυσμένες θέσεις ή πόρους, μπορείτε να τα χρησιμοποιήσετε ως εξωτερικές πηγές δεδομένων. Εάν παρέχετε σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Ο παρακάτω κώδικας Python δείχνει πώς να ορίσετε ένα εξωτερικό βιβλίο εργασίας:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Περάστε False ώστε να αποθηκεύεται μόνο η διαδρομή: το βιβλίο εργασίας προορισμού δεν χρειάζεται ακόμη να υπάρχει.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Η παράμετρος `update_chart_data` της μεθόδου [set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) καθορίζει εάν θα φορτωθεί το Excel βιβλίο εργασίας.

- Όταν `update_chart_data` ορίζεται σε `False`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας· δεν φορτώνονται ή ανανεώνονται τα δεδομένα του διαγράμματος από το αρχείο προορισμού. Χρησιμοποιήστε αυτή τη ρύθμιση όταν το βιβλίο εργασίας προορισμού δεν υπάρχει ή δεν είναι διαθέσιμο.
- Όταν `update_chart_data` ορίζεται σε `True` (η προεπιλογή), τα δεδομένα του διαγράμματος φορτώνονται και ενημερώνονται από το βιβλίο εργασίας προορισμού. Εάν αυτό το βιβλίο εργασίας δεν μπορεί να ανοιχθεί, εγείρεται εξαίρεση με το μήνυμα «External workbook is not available».

### **Δημιουργία εξωτερικών βιβλίων εργασίας**

Χρησιμοποιώντας τις μεθόδους [read_workbook_stream](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) και [set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/), μπορείτε είτε να δημιουργήσετε ένα εξωτερικό βιβλίο εργασίας από το μηδέν είτε να μετατρέψετε ένα εσωτερικό βιβλίο εργασίας σε εξωτερικό.

Αυτός ο κώδικας Python δείχνει τη διαδικασία δημιουργίας εξωτερικού βιβλίου εργασίας:

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

### **Ανάκτηση διαδρομής εξωτερικού βιβλίου εργασίας πηγής δεδομένων για ένα διάγραμμα**

Μερικές φορές τα δεδομένα ενός διαγράμματος συνδέονται με εξωτερικό βιβλίο εργασίας Excel αντί για τα ενσωματωμένα δεδομένα της παρουσίασης. Με το Aspose.Slides, μπορείτε να εξετάσετε την πηγή δεδομένων του διαγράμματος και, εάν είναι εξωτερικό βιβλίο εργασίας, να διαβάσετε τη πλήρη διαδρομή του.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/).
1. Λάβετε αναφορά στη διαφάνεια με βάση το δείκτη της.
1. Λάβετε αναφορά στο σχήμα του διαγράμματος.
1. Αποκτήστε την πηγή ([ChartDataSourceType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatasourcetype/)) που αντιπροσωπεύει την πηγή δεδομένων του διαγράμματος.
1. Ελέγξτε εάν ο τύπος πηγής ταιριάζει με τον τύπο εξωτερικού βιβλίου εργασίας.

Ο παρακάτω κώδικας Python επιδεικνύει τη λειτουργία:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Επεξεργασία δεδομένων διαγράμματος**

Μπορείτε να επεξεργαστείτε δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που επεξεργάζεστε δεδομένα σε εσωτερικά βιβλία εργασίας. Εάν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, εγείρεται εξαίρεση.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Ανάκτηση βιβλίου εργασίας από τη λανθάνουσα μνήμη διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να ανασυνθέσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που είναι αποθηκευμένα στη λανθάνουσα μνήμη της παρουσίασης. Δημιουργήστε ένα αντικείμενο [LoadOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/), στη συνέχεια ενεργοποιήστε το [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/el/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) μέσω του [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/spreadsheet_options/) πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα Python ανοίγει μια παρουσίαση της οποίας το διάγραμμα αναφέρεται σε μη διαθέσιμο εξωτερικό βιβλίο εργασίας και προσπελάζει τα δεδομένα που ανακτήθηκαν μέσω του [Chart.chart_data](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/chart_data/) και του [ChartData.chart_data_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Διαβάστε ή τροποποιήστε τα δεδομένα του ανακτημένου βιβλίου εργασίας εδώ.
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides εγείρει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων λανθάνουσας μνήμης είναι αποδεκτό εναλλακτικό σενάριο, επειδή η λανθάνουσα μνήμη μπορεί να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές ερωτήσεις**

**Μπορώ να καθορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα διαθέτει έναν [data source type](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/data_source_type/) και μια [path to an external workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές σε εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη. Αυτό είναι βολικό για φορητότητα έργου· ωστόσο, η παρουσίαση θα αποθηκεύσει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια βιβλία μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η άμεση επεξεργασία απομακρυσμένων βιβλίων εργασίας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Αντικαθιστά το Aspose.Slides το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Μόνο εάν επεξεργαστήκατε τα δεδομένα του διαγράμματος. Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/) και τον χρησιμοποιεί για ανάγνωση δεδομένων, έτσι το άνοιγμα και η αποθήκευση μιας παρουσίασης δεν τροποποιούν το βιβλίο εργασίας. Ωστόσο, οι τιμές που αλλάζετε μέσω των δεδομένων του διαγράμματος (δείτε **Edit Chart Data** παραπάνω) γράφονται πίσω στο εξωτερικό βιβλίο εργασίας όταν η παρουσίαση αποθηκεύεται· εργαστείτε σε αντίγραφο εάν πρέπει να διατηρηθεί ανέπαφο το αρχικό.

**Τι να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Συνήθης προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/python-net/)) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορείσαν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντανακλάται σε κάθε διάγραμμα την επόμενη φορά που θα φορτωθούν τα δεδομένα.