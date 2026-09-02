---
title: Διαχείριση Φυλλαδίων Γραφημάτων σε Παρουσιάσεις με Python
linktitle: Φύλλο Εργασίας Γραφήματος
type: docs
weight: 70
url: /el/python-net/chart-workbook/
keywords:
- φύλλο εργασίας γραφήματος
- δεδομένα γραφήματος
- κελί φύλλου εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερικό φύλλο εργασίας
- εξωτερικά δεδομένα
- κρυφή μνήμη γραφήματος
- ανάκτηση φύλλου εργασίας
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Python μέσω .NET: διαχειριστείτε εύκολα τα φύλλα εργασίας γραφήματος σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με φύλλα εργασίας γραφημάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα γραφήματος μέσω ροών φύλλου εργασίας, να χρησιμοποιείτε κελιά φύλλου εργασίας ως ετικέτες δεδομένων γραφήματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του γραφήματος.

Καλύπτει επίσης τη δουλειά με εξωτερικά φύλλα εργασίας ως πηγές δεδομένων γραφήματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να εκχωρήσετε ένα εξωτερικό φύλλο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού φύλλου εργασίας που συνδέεται με ένα γράφημα και να επεξεργαστείτε τα δεδομένα του γραφήματος όταν το φύλλο εργασίας είναι διαθέσιμο.

## **Ανάγνωση και Εγγραφή Δεδομένων Γραφήματος από Φύλλο Εργασίας**

Το Aspose.Slides παρέχει μεθόδους για την ανάγνωση και εγγραφή βιβλίων εργασίας δεδομένων γραφήματος (που περιέχουν δεδομένα γραφήματος επεξεργασμένα με Aspose.Cells). **Σημείωση:** Τα δεδομένα γραφήματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

Ο παρακάτω κώδικας Python δείχνει μια παράδειγμα λειτουργία:

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

## **Ορισμός Κελιού Φύλλου Εργασίας ως Ετικέτας Δεδομένων Γραφήματος**

Κάποιες φορές χρειάζεστε ετικέτες γραφήματος που προέρχονται απευθείας από κελιά στο υποκείμενο φύλλο εργασίας δεδομένων. Το Aspose.Slides σας επιτρέπει να συνδέσετε ετικέτες δεδομένων με συγκεκριμένα κελιά φύλλου εργασίας ώστε το κείμενο της ετικέτας να αντανακλά πάντα την τιμή του κελιού. Το παρακάτω παράδειγμα δείχνει πώς να ενεργοποιήσετε ετικέτες τιμής-από-κελί και να κατευθύνετε επιλεγμένες ετικέτες σε προσαρμοσμένα κελιά στο φύλλο εργασίας του γραφήματος.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/) .
2. Λάβετε αναφορά στη διαφάνεια κατά δείκτη.
3. Προσθέστε ένα γράφημα φυσαλίδων με δείγματα δεδομένων.
4. Πρόσβαση στη σειρά του γραφήματος.
5. Χρησιμοποιήστε ένα κελί φύλλου εργασίας ως ετικέτα δεδομένων.
6. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας Python δείχνει πώς να ορίσετε ένα κελί φύλλου εργασίας ως ετικέτα δεδομένων γραφήματος:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Φύλλου Εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη μορφή δυαδικού φύλλου εργασίας Excel (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα γραφήματα. Μπορείτε να χρησιμοποιήσετε την ιδιότητα `embedded_workbook_type` στο [ChartData](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/) μαζί με την αριθμομηχανή [WorkbookType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/workbooktype/) για να ανιχνεύετε μη υποστηριζόμενες μορφές και να παραλείπετε αυτά τα γραφήματα.

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
            # Το ενσωματωμένο φύλλο εργασίας είναι σε μορφή .xlsb, η οποία δεν υποστηρίζεται.
            continue

        # Διαβάστε ή τροποποιήστε εδώ τα δεδομένα του φύλλου εργασίας του γραφήματος.
```

## **Εξωτερικά Φύλλα Εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών φύλλων εργασίας ως πηγή δεδομένων για γραφήματα.

### **Ορισμός Εξωτερικών Φύλλων Εργασίας**

Χρησιμοποιώντας τη μέθοδο [ChartData.set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) μπορείτε να εκχωρήσετε ένα εξωτερικό φύλλο εργασίας σε ένα γράφημα ως πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να ενημερώσει τη διαδρομή σε ένα εξωτερικό φύλλο εργασίας εάν αυτό έχει μετακινηθεί.

Παρόλο που δεν μπορείτε να επεξεργαστείτε δεδομένα σε φύλλα εργασίας που αποθηκεύονται σε απομακρυσμένες θέσεις ή πόρους, μπορείτε ακόμη να τα χρησιμοποιήσετε ως εξωτερικές πηγές δεδομένων. Εάν παρέχετε μια σχετική διαδρομή για ένα εξωτερικό φύλλο εργασίας, μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Ο παρακάτω κώδικας Python δείχνει πώς να ορίσετε ένα εξωτερικό φύλλο εργασίας:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Η παράμετρος `update_chart_data` της μεθόδου [set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) καθορίζει εάν το Excel φύλλο εργασίας θα φορτωθεί.

- Όταν το `update_chart_data` οριστεί σε `False`, ενημερώνεται μόνο η διαδρομή του φύλλου εργασίας· τα δεδομένα του γραφήματος δεν φορτώνονται ή ενημερώνονται από το στόχο. Χρησιμοποιήστε αυτήν τη ρύθμιση όταν το στόχο φύλλου εργασίας δεν υπάρχει ή δεν είναι διαθέσιμο.
- Όταν το `update_chart_data` οριστεί σε `True`, τα δεδομένα του γραφήματος φορτώνονται και ενημερώνονται από το στόχο.

### **Δημιουργία Εξωτερικών Φύλλων Εργασίας**

Χρησιμοποιώντας τις μεθόδους [read_workbook_stream](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) και [set_external_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/set_external_workbook/) μπορείτε είτε να δημιουργήσετε ένα εξωτερικό φύλλο εργασίας από το μηδέν είτε να μετατρέψετε ένα εσωτερικό φύλλο εργασίας σε εξωτερικό.

Αυτός ο κώδικας Python επιδεικνύει τη διαδικασία δημιουργίας εξωτερικού φύλλου εργασίας:

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

### **Ανάκτηση της Διαδρομής του Εξωτερικού Φύλλου Εργασίας Πηγής Δεδομένων για ένα Γράφημα**

Κάποια φορές τα δεδομένα ενός γραφήματος συνδέονται με ένα εξωτερικό φύλλο εργασίας Excel αντί για τα ενσωματωμένα δεδομένα της παρουσίασης. Με το Aspose.Slides, μπορείτε να εξετάσετε την πηγή δεδομένων του γραφήματος και, εάν είναι εξωτερικό φύλλο εργασίας, να διαβάσετε τη πλήρη διαδρομή του.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/) .
2. Λάβετε αναφορά στη διαφάνεια κατά δείκτη.
3. Λάβετε αναφορά στο σχήμα γραφήματος.
4. Αποκτήστε την πηγή ([ChartDataSourceType](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdatasourcetype/)) που αντιπροσωπεύει την πηγή δεδομένων του γραφήματος.
5. Ελέγξτε εάν ο τύπος πηγής ταιριάζει με τον τύπο εξωτερικού φύλλου εργασίας.

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

### **Επεξεργασία Δεδομένων Γραφήματος**

Μπορείτε να επεξεργαστείτε δεδομένα σε εξωτερικά φύλλα εργασίας με τον ίδιο τρόπο που επεξεργάζεστε δεδομένα σε εσωτερικά φύλλα εργασίας. Εάν ένα εξωτερικό φύλλο εργασίας δεν μπορεί να φορτωθεί, εκβάλλεται εξαίρεση.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Ανάκτηση Φύλλου Εργασίας από την Κρυφή Μνήμη Γραφήματος**

Εάν ένα γράφημα χρησιμοποιεί ένα εξωτερικό φύλλο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να ανακατασκευάσει το φύλλο εργασίας του γραφήματος από τα δεδομένα που είναι αποθηκευμένα στην παρουσίαση. Δημιουργήστε ένα αντικείμενο [LoadOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/), στη συνέχεια ενεργοποιήστε το [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/el/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) μέσω του [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/spreadsheet_options/) πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα Python ανοίγει μια παρουσίαση που το γράφημα της αναφέρεται σε μη διαθέσιμο εξωτερικό φύλλο εργασίας και αποκτά πρόσβαση στα ανακτημένα δεδομένα μέσω του [Chart.chart_data](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/chart_data/) και του [ChartData.chart_data_workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Διαβάστε ή τροποποιήστε εδώ τα δεδομένα του ανακτημένου βιβλίου εργασίας.
```

Εάν το εξωτερικό φύλλο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides εγείρει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των κρυφών δεδομένων γραφήματος είναι αποδεκτή εναλλακτική λύση, επειδή η κρυφή μνήμη ενδέχεται να μην περιέχει αλλαγές που έγιναν στο εξωτερικό φύλλο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο γράφημα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο φύλλο εργασίας;**

Ναι. Ένα γράφημα διαθέτει έναν [data source type](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/data_source_type/) και μια [path to an external workbook](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Εάν η πηγή είναι εξωτερικό φύλλο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά φύλλα εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη. Αυτό είναι χρήσιμο για φορητότητα του έργου· ωστόσο, η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω φύλλα εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους φακέλους;**

Ναι, τέτοια φύλλα εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων φύλλων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται· μπορούν να χρησιμοποιηθούν μόνο ως πηγή.

**Αντικαθιστά το Aspose.Slides το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Όχι. Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/) και το χρησιμοποιεί για ανάγνωση δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται όταν η παρουσίαση αποθηκεύεται.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια κοινή προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα αποκρυπτογραφημένο αντίγραφο (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/python-net/)) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορούν πολλά γραφήματα να αναφέρονται στο ίδιο εξωτερικό φύλλο εργασίας;**

Ναι. Κάθε γράφημα αποθηκεύει τη δική του σύνδεση. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε γράφημα την επόμενη φορά που θα φορτωθούν τα δεδομένα.