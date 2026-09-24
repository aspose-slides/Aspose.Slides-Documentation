---
title: "Διαχείριση βιβλίων εργασίας διαγράμματος σε παρουσιάσεις χρησιμοποιώντας Python μέσω Java"
linktitle: "Βιβλίο εργασίας διαγράμματος"
type: docs
weight: 70
url: /el/python-java/chart-workbook/
keywords:
- "βιβλίο εργασίας διαγράμματος"
- "δεδομένα διαγράμματος"
- "κελί βιβλίου εργασίας"
- "ετικέτα δεδομένων"
- "φύλλο εργασίας"
- "πηγή δεδομένων"
- "εξωτερικό βιβλίο εργασίας"
- "εξωτερικά δεδομένα"
- "απόθεμα διαγράμματος"
- "ανάκτηση βιβλίου εργασίας"
- "PowerPoint"
- "παρουσίαση"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Ανακαλύψτε το Aspose.Slides για Python μέσω Java: διαχειριστείτε με ευκολία βιβλία εργασίας διαγράμματος σε μορφές PowerPoint και OpenDocument για να βελτιστοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλιάρια διαγραμμάτων στην Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να ορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Επιπλέον, καλύπτει τη χρήση εξωτερικών βιβλιών εργασίας ως πηγών δεδομένων διαγράμματος. Τα παραδείγματα επιδεικνύουν πώς να δημιουργήσετε και να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που είναι συνδεδεμένο με ένα διάγραμμα και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

Για κελιά βιβλίου εργασίας που αντιπροσωπεύουν ελλιπή δεδομένα, δείτε [Control the Display of Empty Cells](/slides/el/python-java/chart-series/) για τη διαφορά μεταξύ κενού κελιού και μηδενός, καθώς και μια σύγκριση γραμμικού διαγράμματος των διαθέσιμων τρόπων εμφάνισης.

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Βιβλίο Εργασίας**
Aspose.Slides παρέχει τις μεθόδους [readWorkbookStream](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#readWorkbookStream) και [writeWorkbookStream](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#writeWorkbookStream) που σάς επιτρέπουν να διαβάζετε και να γράφετε βιβλία εργασίας δεδομένων διαγράμματος (περιέχοντας δεδομένα διαγράμματος που έχουν επεξεργαστεί με Aspose.Cells). **Note** ότι τα δεδομένα του διαγράμματος πρέπει να οργανωθούν με τον ίδιο τρόπο ή να έχουν δομή παρόμοια με την πηγή.

Αυτός ο κώδικας Python δείχνει μια δείγμα λειτουργίας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Επικύρωση Διάταξης Διαγράμματος μετά την Τροποποίηση Βιβλίου Εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το διάγραμμα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυνέπεια μπορεί να προκαλέσει το [Chart.validateChartLayout](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#validateChartLayout) να ρίξει μια `ArgumentOutOfRangeException` (parameter: index). Για να αποφύγετε την εξαίρεση, καθαρίστε τις υπάρχουσες σειρές και κατηγορίες **before** γράφοντας το ενημερωμένο βιβλίο εργασίας πίσω στο διάγραμμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Διαβάστε το βιβλίο εργασίας μετά την τροποποίησή του (π.χ., χρησιμοποιώντας Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Καθαρίστε τις υπάρχουσες αναφορές δεδομένων.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Ο καθαρισμός των συλλογών διασφαλίζει ότι η δομή των δεδομένων του διαγράμματος ευθυγραμμίζεται με το νέο βιβλίο εργασίας, επιτρέποντας στο [validateChartLayout](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#validateChartLayout) να ολοκληρωθεί χωρίς σφάλματα.

## **Ορισμός Κελιού Βιβλίου Εργασίας ως Ετικέτας Δεδομένων Διαγράμματος**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
1. Προσθέστε ένα διάγραμμα Bubble με κάποιον αριθμό δεδομένων.
1. Πρόσβαση στη σειρά του διαγράμματος.
1. Ορίστε το κελί του βιβλίου εργασίας ως ετικέτα δεδομένων.
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε ένα κελί βιβλίου εργασίας ως ετικέτα δεδομένων διαγράμματος:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)
    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Διαχείριση Φύλλων Εργασίας**

Αυτός ο κώδικας Python επιδεικνύει μια λειτουργία όπου η μέθοδος [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/#getWorksheets) χρησιμοποιείται για πρόσβαση σε συλλογή φύλλων εργασίας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Καθορισμός Τύπου Πηγής Δεδομένων**

Αυτός ο κώδικας Python δείχνει πώς να καθορίσετε έναν τύπο για μία πηγή δεδομένων:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλίου Εργασίας**

Η Aspose.Slides δεν υποστηρίζει τη μορφή δυαδικού βιβλίου εργασίας Excel (.xlsb) που μπορεί να είναι ενσωματωμένη σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [getEmbeddedWorkbookType](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) στην κλάση [ChartData](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/python-java/aspose.slides/workbooktype/) για την ανίχνευση μη υποστηριζόμενων μορφών και τη παράλειψη αυτών των διαγραμμάτων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue
        chart_data = shape.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Το ενσωματωμένο βιβλίο εργασίας είναι σε μορφή .xlsb, η οποία δεν υποστηρίζεται.
            continue
        # Διαβάστε ή τροποποιήστε τα δεδομένα του βιβλίου εργασίας του διαγράμματος εδώ.
finally:
    presentation.dispose()
```

## **Εξωτερικό Βιβλίο Εργασίας**

Η Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για διαγράμματα.

### **Δημιουργία Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τις μεθόδους [readWorkbookStream](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#readWorkbookStream) και [setExternalWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#setExternalWorkbook), μπορείτε είτε να δημιουργήσετε ένα εξωτερικό βιβλίο εργασίας από το μηδέν είτε να μετατρέψετε ένα εσωτερικό βιβλίο εργασίας σε εξωτερικό.

Αυτός ο κώδικας Python επιδεικνύει τη διαδικασία δημιουργίας εξωτερικού βιβλίου εργασίας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ορισμός Εξωτερικού Βιβλίου Εργασίας**

Με τη μέθοδο [setExternalWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#setExternalWorkbook) μπορείτε να αντιστοιχίσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για ενημέρωση της διαδρομής προς το εξωτερικό βιβλίο εργασίας (εάν έχει μετακινηθεί).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας που αποθηκεύονται σε απομακρυσμένες θέσεις ή πόρους, μπορείτε να τα χρησιμοποιήσετε ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για το εξωτερικό βιβλίο εργασίας, αυτή μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Αυτός ο κώδικας Python δείχνει πώς να ορίσετε ένα εξωτερικό βιβλίο εργασίας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η δεύτερη (`bool`) παράμετρος της μεθόδου [setExternalWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#setExternalWorkbook) χρησιμοποιείται για τον καθορισμό εάν θα φορτωθεί ή όχι ένα βιβλίο εργασίας Excel.

* Όταν η τιμή της θέτεται σε `False`, μόνο η διαδρομή του βιβλίου εργασίας ενημερώνεται — τα δεδομένα του διαγράμματος δεν θα φορτωθούν ή ενημερωθούν από το προορισμένο βιβλίο εργασίας. Μπορείτε να χρησιμοποιήσετε αυτή τη ρύθμιση όταν το προορισμένο βιβλίο εργασίας δεν υπάρχει ή δεν είναι διαθέσιμο.
* Όταν η τιμή της θέτεται σε `True`, τα δεδομένα του διαγράμματος ενημερώνονται από το προορισμένο βιβλίο εργασίας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Λήψη Διαδρομής Εξωτερικής Πηγής Δεδομένων Βιβλίου Εργασίας για Διάγραμμα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
1. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
1. Δημιουργήστε ένα αντικείμενο για το σχήμα του διαγράμματος.
1. Δημιουργήστε ένα αντικείμενο για τον τύπο πηγής ([ChartDataSourceType](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatasourcetype/)) που αντιπροσωπεύει την πηγή δεδομένων του διαγράμματος.
1. Καθορίστε τη σχετική κατάσταση βάσει του αν ο τύπος πηγής είναι ίδιος με τον τύπο εξωτερικής πηγής δεδομένων βιβλίου εργασίας.

Αυτός ο κώδικας Python επιδεικνύει τη λειτουργία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Επεξεργασία Δεδομένων Διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στα περιεχόμενα εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, ρίχνεται εξαίρεση.

Αυτός ο κώδικας Python υλοποιεί τη διαδικασία που περιγράφηκε:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ανάκτηση Βιβλίου Εργασίας από την Κάναφη του Διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, η Aspose.Slides μπορεί να κατασκευάσει εκ νέου το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που είναι αποθηκευμένα στην παρουσίαση. Δημιουργήστε ένα αντικείμενο [LoadOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/), ρυθμίστε το με [SpreadsheetOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/spreadsheetoptions/), και καλέστε τη μέθοδο [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/el/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) με `True` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα Python ανοίγει μια παρουσίαση της οποίας το διάγραμμα αναφέρεται σε εξωτερικό βιβλίο εργασίας που δεν είναι διαθέσιμο και προσπελάζει τα ανακτημένα δεδομένα μέσω των μεθόδων [Chart.getChartData](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#getChartData) και [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Διαβάστε ή τροποποιήστε τα δεδομένα του ανακτημένου βιβλίου εργασίας εδώ.
finally:
    presentation.dispose()
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, η Aspose.Slides ρίχνει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων από την κάναφη του διαγράμματος είναι αποδεκτό εναλλακτικό σενάριο, επειδή η κάναφη μπορεί να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **FAQ**

**Μπορώ να προσδιορίσω αν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα διαθέτει έναν [data source type](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getDataSourceType) και μια [path to an external workbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Αυτό είναι βολικό για τη φορητότητα του έργου· ωστόσο, σημειώστε ότι η παρουσίαση θα αποθηκεύσει την απόλυτη διαδρομή στο αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/μάρτυρες;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από την Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Η Aspose.Slides αντικαθιστά το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Όχι. Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) και το χρησιμοποιεί για ανάγνωση δεδομένων. Το εξωτερικό αρχείο δεν τροποποιείται όταν η παρουσίαση αποθηκεύεται.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Η Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια κοινή προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα ανοιγμένο αντίγραφο (π.χ., χρησιμοποιώντας [Aspose.Cells](/cells/python-java/)) και να συνδέσετε σε αυτό το αντίγραφο.

**Μπορούν πολλαπλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει τον δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση εκείνου του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα την επόμενη φορά που θα φορτωθούν τα δεδομένα.