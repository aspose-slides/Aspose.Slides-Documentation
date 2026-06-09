---
title: Διαχείριση βιβλίων εργασίας διαγραμμάτων σε παρουσιάσεις με Python
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
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Python μέσω .NET: διαχειριστείτε εύκολα τα βιβλία εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να αποκτάτε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Επίσης καλύπτει την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα επιδεικνύουν πώς να δημιουργήσετε και να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας συνδεδεμένου με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Βιβλίο Εργασίας**

Το Aspose.Slides παρέχει μεθόδους για ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Σημείωση:** Τα δεδομένα διαγράμματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν παρόμοια δομή με την πηγή.

Ο παρακάτω κώδικας Python παρουσιάζει μια ενδεικτική λειτουργία:

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

## **Ορισμός Κελιού Βιβλίου Εργασίας ως Ετικέτα Δεδομένων Διαγράμματος**

Μερικές φορές χρειάζονται ετικέτες διαγράμματος που προέρχονται άμεσα από κελιά στο υποκείμενο βιβλίο εργασίας. Το Aspose.Slides σας επιτρέπει να δεσμεύετε ετικέτες δεδομένων σε συγκεκριμένα κελιά βιβλίου εργασίας ώστε το κείμενο της ετικέτας να αντανακλά πάντα την τιμή του κελιού. Το παρακάτω παράδειγμα δείχνει πώς να ενεργοποιήσετε ετικέτες τιμής-από-κελί και να κατευθύνετε επιλεγμένες ετικέτες σε προσαρμοσμένα κελιά στο βιβλίο εργασίας του διαγράμματος.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/) .
2. Λάβετε αναφορά στη διαφάνεια με βάση το ευρετήριο.
3. Προσθέστε ένα διάγραμμα φούσκας με δείγμα δεδομένων.
4. Προσπελάστε τις σειρές του διαγράμματος.
5. Χρησιμοποιήστε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων.
6. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας Python δείχνει πώς να ορίσετε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων διαγράμματος:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Δημιουργήστε μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλίου Εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη μορφή βιβλίου εργασίας Excel δυφής (.xlsb) που μπορεί να είναι ενσωματωμένη σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε την ιδιότητα `embedded_workbook_type` στο [ChartData](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα διαγράμματα.

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

        # Διαβάστε ή τροποποιήστε τα δεδομένα βιβλίου εργασίας του διαγράμματος εδώ.
```

## **Εξωτερικά Βιβλία Εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για διαγράμματα.

### **Ορισμός Εξωτερικών Βιβλίων Εργασίας**

Με τη μέθοδο [ChartData.set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) μπορείτε να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να ενημερώσει τη διαδρομή σε ένα εξωτερικό βιβλίο εργασίας εάν έχει μετακινηθεί.

Παρόλο που δεν μπορείτε να επεξεργαστείτε δεδομένα σε βιβλία που αποθηκεύονται σε απομακρυσμένες θέσεις ή πόρους, μπορείτε ακόμη να χρησιμοποιήσετε αυτά τα βιβλία ως εξωτερικές πηγές δεδομένων. Εάν παρέχετε μια σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Ο παρακάτω κώδικας Python δείχνει πώς να ορίσετε ένα εξωτερικό βιβλίο εργασίας:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Η παράμετρος `update_chart_data` της μεθόδου [set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) καθορίζει εάν το βιβλίο εργασίας Excel θα φορτωθεί.

- Όταν η `update_chart_data` οριστεί σε `False`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας· τα δεδομένα διαγράμματος δεν φορτώνονται ούτε ανανεώνονται από το στοχευόμενο βιβλίο εργασίας. Χρησιμοποιήστε αυτή τη ρύθμιση όταν το στοχευόμενο βιβλίο εργασίας δεν υπάρχει ή είναι μη διαθέσιμο.
- Όταν η `update_chart_data` οριστεί σε `True`, τα δεδομένα διαγράμματος φορτώνονται και ενημερώνονται από το στοχευόμενο βιβλίο εργασίας.

### **Δημιουργία Εξωτερικών Βιβλίων Εργασίας**

Με τις μεθόδους [read_workbook_stream](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) και [set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) μπορείτε είτε να δημιουργήσετε ένα εξωτερικό βιβλίο εργασίας από την αρχή είτε να μετατρέψετε ένα εσωτερικό βιβλίο εργασίας σε εξωτερικό.

Ο παρακάτω κώδικας Python επιδεικνύει τη διαδικασία δημιουργίας εξωτερικού βιβλίου εργασίας:

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

### **Ανάκτηση Διαδρομής Εξωτερικού Πηγής Βιβλίου Εργασίας για Διάγραμμα**

Μερικές φορές τα δεδομένα ενός διαγράμματος είναι συνδεδεμένα με ένα εξωτερικό βιβλίο εργασίας Excel αντί για τα ενσωματωμένα δεδομένα της παρουσίασης. Με το Aspose.Slides μπορείτε να εξετάσετε την πηγή δεδομένων του διαγράμματος και, εάν είναι εξωτερικό βιβλίο εργασίας, να διαβάσετε τη πλήρη διαδρομή του βιβλίου εργασίας.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/) .
2. Λάβετε αναφορά στη διαφάνεια με βάση το ευρετήριο της.
3. Λάβετε αναφορά στο σχήμα του διαγράμματος.
4. Αποκτήστε την πηγή ([ChartDataSourceType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatasourcetype/)) που αντιπροσωπεύει την πηγή δεδομένων του διαγράμματος.
5. Ελέγξτε εάν ο τύπος πηγής ταιριάζει με τον τύπο πηγής εξωτερικού βιβλίου εργασίας.

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

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα έχει έναν [data source type](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/data_source_type/) και μια [path to an external workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές σε εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε μια σχετική διαδρομή, μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Αυτό είναι βολικό για φορητότητα του έργου· ωστόσο, έχετε υπόψη ότι η παρουσίαση θα αποθηκεύσει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Αντιγράφει το Aspose.Slides το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Όχι. Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/) και το χρησιμοποιεί για ανάγνωση δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται όταν η παρουσίαση αποθηκεύεται.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό πρόσβασης;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μία κοινή προσέγγιση είναι η αφαίρεση της προστασίας εκ των προτέρων ή η προετοιμασία ενός αποκρυπτογραφημένου αντιγράφου (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/python-net/)) και η σύνδεση σε αυτό το αντίγραφο.

**Μπορούν πολλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα την επόμενη φορά που θα φορτωθούν τα δεδομένα.