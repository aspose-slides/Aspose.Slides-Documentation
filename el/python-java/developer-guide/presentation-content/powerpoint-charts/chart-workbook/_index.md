---
title: Διαχείριση Βιβλίων Εργασίας Διαγραμμάτων σε Παρουσιάσεις με Python μέσω Java
linktitle: Βιβλίο Εργασίας Διαγράμματος
type: docs
weight: 70
url: /el/python-java/chart-workbook/
keywords:
- βιβλίο εργασίας διαγράμματος
- δεδομένα διαγράμματος
- κελί βιβλίου εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερικό βιβλίο εργασίας
- εξωτερικά δεδομένα
- κρυφή μνήμη διαγράμματος
- αποκατάσταση βιβλίου εργασίας
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Python μέσω Java: διαχειριστείτε εύκολα τα βιβλία εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να βελτιώσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με βιβλία εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλίου εργασίας, να χρησιμοποιείτε κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης την εργασία με εξωτερικά βιβλία εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να αναθέσετε ένα εξωτερικό βιβλίο εργασίας, να ανακτήσετε τη διαδρομή ενός εξωτερικού βιβλίου εργασίας που είναι συνδεδεμένο με ένα διάγραμμα, και να επεξεργαστείτε τα δεδομένα του διαγράμματος όταν το βιβλίο εργασίας είναι διαθέσιμο.

Για κελιά βιβλίου εργασίας που αντιπροσωπεύουν ελλιπή δεδομένα, δείτε [Έλεγχος της Εμφάνισης Κενών Κυψελών](/slides/el/python-java/chart-series/) για τη διαφορά μεταξύ ενός κενού κελιού και του μηδενός, καθώς και μια σύγκριση διαγράμματος γραμμής των διαθέσιμων τρόπων εμφάνισης.

## **Συμπερίληψη Δεδομένων από Κρυμμένες Γραμμές και Στήλες**

Χρησιμοποιήστε [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) για να ελέγξετε εάν ένα διάγραμμα σχεδιάζει δεδομένα από κρυμμένες γραμμές και στήλες φύλλου εργασίας. Ορίστε το σε `True` για να σχεδιάζει μόνο τα ορατά κελιά ή σε `False` για να συμπεριλάβει τόσο τα ορατά όσο και τα κρυμμένα κελιά. Αυτή η ρύθμιση ελέγχει το σχεδιασμό του διαγράμματος· δεν κρύβει ή αποκρύβει γραμμές ή στήλες του φύλλου εργασίας.

Κατεβάστε [hidden-source-data.pptx](hidden-source-data.pptx) και τοποθετήστε το στον κατάλογο εργασίας. Η πρώτη του διαφάνεια περιέχει ένα ραβδογράφημα ως το πρώτο σχήμα. Το ενσωματωμένο φύλλο εργασίας, `Sheet1`, περιέχει την ακόλουθη περιοχή προέλευσης, `A1:C4`. Η γραμμή 3 και η στήλη C είναι κρυμμένες, αλλά τα κελιά τους εξακολουθούν να περιέχουν τιμές.

| Γραμμή φύλλου εργασίας | A: Μήνας | B: Λιανική | C: Χονδρική (κρυφή στήλη) |
| --- | --- | --- | --- |
| 2 | Ιανουάριος | 10 | 30 |
| 3 (κρυφή γραμμή) | Φεβρουάριος | 40 | 60 |
| 4 | Μάρτιος | 20 | 50 |

Προσπελάστε τα πηγαία κελιά μέσω [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getChartDataWorkbook) και διαβάστε [ChartDataCell.isHidden](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdatacell/#isHidden) για να ελέγξετε την κρυφή κατάσταση τους. Αυτή η μέθοδος αναφέρει την κρυφή κατάσταση χωρίς να την αλλάξει. Σε αυτό το αρχείο, το B2 είναι ορατό, το B3 ανήκει στη κρυφή γραμμή, και το C2 ανήκει στη κρυφή στήλη· το παράδειγμα εκτυπώνει `False`, `True` και `True`, αντίστοιχα.

Για αυτό το παράδειγμα, ανανεώστε τα δεδομένα του διαγράμματος μετά την αλλαγή της ρύθμισης σχεδίασης: διατηρήστε το ενσωματωμένο βιβλίο εργασίας με [readWorkbookStream](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#readWorkbookStream) και επαναφορτώστε το με [writeWorkbookStream](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#writeWorkbookStream). Όταν περιλαμβάνονται όλα τα κελιά, χρησιμοποιήστε επίσης το [setRange](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#setRange) για να αποκαταστήσετε το πλήρες εύρος, συμπεριλαμβανομένης της κρυφής κατηγορίας Φεβρουαρίου. Η απλή αλλαγή της σημαίας δεν επαρκεί για την ανανέωση των προσωρινά αποθηκευμένων δεδομένων του διαγράμματος και των ετικετών κατηγοριών σε αυτό το δείγμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Ανανεώστε τα δεδομένα του διαγράμματος από το ενσωματωμένο βιβλίο εργασίας.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Αναφέρετε το πλήρες εύρος προέλευσης, συμπεριλαμβανομένων των κρυφών κατηγοριών.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Το παράδειγμα αποθηκεύει το `hidden_cells_True.pptx` με μόνο τις ορατές τιμές Λιανικής (10 και 20), και το `hidden_cells_False.pptx` με όλες τις έξι τιμές. Οι παρακάτω εικόνες απεικονίζουν τις δύο λειτουργίες σχεδίασης. Η γραμμή 3 και η στήλη C παραμένουν κρυφές και στα δύο ενσωματωμένα βιβλία εργασίας.

| Μόνο ορατά κελιά (`True`) | Όλα τα κελιά (`False`) |
| --- | --- |
| ![Μόνο ορατά κελιά: Τιμές λιανικής 10 και 20 για Ιανουάριο και Μάρτιο.](hidden_cells_True.png) | ![Όλα τα κελιά: Τιμές λιανικής και χονδρικής για Ιανουάριο, Φεβρουάριο και Μάρτιο.](hidden_cells_False.png) |

Ένα κρυφό κελί που περιέχει τιμή διαφέρει από ένα κενό κελί. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#setDisplayBlanksAs) ελέγχει πώς εμφανίζονται οι ελλιπείς τιμές· δεν περιλαμβάνει ή εξαιρεί κρυφά δεδομένα προέλευσης. Δείτε [Έλεγχος της Εμφάνισης Κενών Κυψελών](/slides/el/python-java/chart-series/#control-the-display-of-empty-cells) για ένα παράδειγμα.

## **Ανάγνωση και Εγγραφή Δεδομένων Διαγράμματος από Βιβλίο Εργασίας**

Το Aspose.Slides για Python μέσω Java παρέχει τις μεθόδους [readWorkbookStream](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#readWorkbookStream) και [writeWorkbookStream](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#writeWorkbookStream) που σας επιτρέπουν να διαβάζετε και να γράφετε βιβλία εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Note** ότι τα δεδομένα του διαγράμματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν παρόμοια δομή με την πηγή.

Αυτό το παράδειγμα ανοίγει το `chart.pptx`, το οποίο πρέπει να περιέχει ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη του διαφάνεια. Διαβάζει το ενσωματωμένο βιβλίο εργασίας σε έναν πίνακα byte, διαγράφει τις υπάρχουσες σειρές και κατηγορίες, και γράφει ξανά το ίδιο βιβλίο εργασίας. Οι αλλαγές παραμένουν στη μνήμη· το παράδειγμα δεν αποθηκεύει την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Επικύρωση Διάταξης Διαγράμματος μετά την Τροποποίηση του Βιβλίου Εργασίας**

Όταν αντικαθιστάτε ένα ενσωματωμένο βιβλίο εργασίας με ένα τροποποιημένο, το διάγραμμα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυμφωνία μπορεί να προκαλέσει το [Chart.validateChartLayout](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#validateChartLayout) να αποτύχει με σφάλμα εκτός ορίων δείκτη. Διαγράψτε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε το ενημερωμένο βιβλίο εργασίας πίσω στο διάγραμμα. Αυτό το παράδειγμα απαιτεί το `chart.pptx` με διάγραμμα ως το πρώτο σχήμα στην πρώτη του διαφάνεια. Το σχόλιο υποδεικνύει πού θα συμβεί η επεξεργασία του βιβλίου εργασίας· το εκτελέσιμο παράδειγμα γράφει ξανά το αρχικό βιβλίο εργασίας και επικυρώνει τη διάταξη στη μνήμη.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Τροποποιήστε τα byte του βιβλίου εργασίας εδώ, για παράδειγμα, χρησιμοποιώντας Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Η εκκαθάριση των συλλογών αφαιρεί παλιορροϊκές αναφορές δεδομένων πριν το βιβλίο εργασίας γραφτεί ξανά. Αναδημιουργήστε τυχόν απαιτούμενους χάρτες σειρών και κατηγοριών για το ενημερωμένο βιβλίο εργασίας πριν χρησιμοποιήσετε το διάγραμμα.

## **Ορισμός Κελιού Βιβλίου Εργασίας ως Ετικέτας Δεδομένων Διαγράμματος**

Μπορείτε να χρησιμοποιήσετε κείμενο από κελιά βιβλίου εργασίας ως ετικέτες δεδομένων διαγράμματος. Τα παρακάτω βήματα δείχνουν πώς να συνδέσετε τις ετικέτες σε ένα διάγραμμα φυσαλίδων με κελιά του βιβλίου δεδομένων του.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
1. Πρόσβαση στην πρώτη διαφάνεια με το μηδενικό δείκτη της.
1. Προσθέστε ένα διάγραμμα φυσαλίδων με προεπιλεγμένα δεδομένα.
1. Πρόσβαση στις σειρές του διαγράμματος.
1. Ορίστε το κελί του βιβλίου εργασίας ως ετικέτα δεδομένων.
1. Αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα ανοίγει το `chart2.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια, και προσθέτει ένα διάγραμμα φυσαλίδων με προεπιλεγμένα δεδομένα. Χρησιμοποιεί τα κελιά A10:A12 στο φύλλο εργασίας 0 για τις πρώτες τρεις ετικέτες στην πρώτη σειρά, ενεργοποιεί ετικέτες από κελιά, και αποθηκεύει το αποτέλεσμα στο `resultchart.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
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

Η μέθοδος [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdataworkbook/#getWorksheets) παρέχει πρόσβαση στα φύλλα εργασίας ενός βιβλίου εργασίας διαγράμματος. Αυτό το παράδειγμα δημιουργεί ένα πίτας διάγραμμα με προεπιλεγμένα δεδομένα και εκτυπώνει κάθε όνομα φύλλου εργασίας στην κονσόλα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Καθορισμός Τύπου Πηγής Δεδομένων**

Αυτό το παράδειγμα δημιουργεί ένα 3Δ στήλης γράφημα με προεπιλεγμένα δεδομένα και ορίζει δύο ονόματα σειρών χρησιμοποιώντας διαφορετικές πηγές δεδομένων. Το πρώτο όνομα χρησιμοποιεί μια αλφαριθμητική σταθερά· το δεύτερο χρησιμοποιεί το κελί C1 στο φύλλο εργασίας 0. Η απαρίθμηση [DataSourceType](https://reference.aspose.com/slides/el/python-java/aspose.slides/datasourcetype/) επιλέγει την πηγή για κάθε όνομα. Το αποτέλεσμα αποθηκεύεται στο `pres.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ανίχνευση Μη Υποστηριζόμενων Ενσωματωμένων Μορφών Βιβλίου Εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη δυαδική μορφή Excel (.xlsb) που μπορεί να ενσωματωθεί σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [getEmbeddedWorkbookType](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) στην κλάση [ChartData](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/el/python-java/aspose.slides/workbooktype/) για να εντοπίσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα διαγράμματα. Αυτό το παράδειγμα εξετάζει τα σχήματα στην πρώτη διαφάνεια του `sample.pptx`, παραλείπει τα μη διάγραμμα σχήματα, και εκτυπώνει ένα διαγνωστικό μήνυμα για κάθε διάγραμμα με ενσωματωμένο βιβλίο εργασίας .xlsb.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpame.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Διαβάστε ή τροποποιήστε τα υποστηριζόμενα δεδομένα βιβλίου εργασίας διαγράμματος εδώ.
finally:
    presentation.dispose()
```

## **Εξωτερικό Βιβλίο Εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλίων εργασίας ως πηγή δεδομένων για διαγράμματα.

### **Δημιουργία Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιήστε τις [readWorkbookStream](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#readWorkbookStream) και [setExternalWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#setExternalWorkbook) για να εξάγετε ένα ενσωματωμένο βιβλίο εργασίας διαγράμματος σε αρχείο και να συνδέσετε το διάγραμμα με αυτό το εξωτερικό βιβλίο εργασίας.

Αυτό το παράδειγμα δημιουργεί ένα πίτας διάγραμμα με προεπιλεγμένα δεδομένα, γράφει το βιβλίο εργασίας του στο `externalWorkbook1.xlsx`, και ολοκληρώνει τη γραφή του αρχείου πριν αναθέσει το αρχείο ως πηγή δεδομένων του διαγράμματος. Αποθηκεύει την συνδεδεμένη παρουσίαση στο `externalWorkbook.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ορισμός Εξωτερικού Βιβλίου Εργασίας**

Χρησιμοποιώντας τη μέθοδο [setExternalWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#setExternalWorkbook), μπορείτε να εκχωρήσετε ένα εξωτερικό βιβλίο εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Αυτή η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για την ενημέρωση της διαδρομής προς το εξωτερικό βιβλίο εργασίας (αν αυτό έχει μετακινηθεί).

Αν και δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλία εργασίας που αποθηκεύονται σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμη να χρησιμοποιήσετε τέτοια βιβλία εργασίας ως εξωτερική πηγή δεδομένων. Εάν παρέχεται σχετική διαδρομή για ένα εξωτερικό βιβλίο εργασίας, μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Απαιτείται αυτό το παράδειγμα το `externalWorkbook.xlsx` στον κατάλογο εργασίας. Το φύλλο εργασίας του με όνομα `Sheet1` πρέπει να περιέχει ένα όνομα σειράς στο B1, ονόματα κατηγοριών στο A2:A4, και αριθμητικές τιμές στο B2:B4. Το παράδειγμα δημιουργεί ένα πίτας διάγραμμα, συνδέει το βιβλίο εργασίας, και χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#setRange) για να αντιστοιχίσει το A1:B4 σε μία σειρά και τρεις κατηγορίες. Αποθηκεύει το αποτέλεσμα στο `Presentation_with_externalWorkbook.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η παράμετρος `updateChartData` της [setExternalWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#setExternalWorkbook) ελέγχει αν το βιβλίο εργασίας θα φορτωθεί.

· Όταν το `updateChartData` είναι `False`, ενημερώνεται μόνο η διαδρομή του βιβλίου εργασίας. Τα δεδομένα του διαγράμματος δεν φορτώνονται ή ενημερώνονται από το βιβλίο εργασίας-στόχο, ώστε το βιβλίο εργασίας να μπορεί να είναι μη διαθέσιμο.  
· Όταν το `updateChartData` είναι `True`, τα δεδομένα του διαγράμματος ενημερώνονται από το βιβλίο εργασίας-στόχο.

Το παρακάτω παράδειγμα εκχωρεί μια URL κράτησης θέσης με το `updateChartData` ορισμένο σε `False`. Διατηρεί τα προεπιλεγμένα δεδομένα του πίτας διαγράμματος και αποθηκεύει την παρουσίαση χωρίς να φορτώσει το μη διαθέσιμο βιβλίο εργασίας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Λήψη Διαδρομής Βιβλίου Εργασίας Εξωτερικής Πηγής Δεδομένων ενός Διαγράμματος**

Για να εντοπίσετε το βιβλίο εργασίας που συνδέεται με ένα διάγραμμα, πρώτα ελέγξτε αν το διάγραμμα χρησιμοποιεί εξωτερική πηγή δεδομένων. Εάν το κάνει, μπορείτε να ανακτήσετε τη διαδρομή του βιβλίου εργασίας ακολουθώντας τα παρακάτω βήματα.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Πρόσβαση στην πρώτη διαφάνεια με το μηδενικό δείκτη.
3. Ελέγξτε ότι το πρώτο σχήμα είναι διάγραμμα.
4. Διαβάστε τον τύπο πηγής δεδομένων του διαγράμματος.
5. Εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, διαβάστε τη διαδρομή του.

Αυτό το παράδειγμα ανοίγει το `externalWorkbook.pptx`, που δημιουργήθηκε στο προηγούμενο παράδειγμα, και εξετάζει το πρώτο σχήμα στην πρώτη διαφάνεια. Εάν είναι διάγραμμα συνδεδεμένο με εξωτερικό βιβλίο εργασίας, το παράδειγμα εκτυπώνει το [getExternalWorkbookPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) στην κονσόλα. Στη συνέχεια αποθηκεύει ένα αντίγραφο της παρουσίασης στο `Result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Επεξεργασία Δεδομένων Διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικά βιβλία εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στα περιεχόμενα εσωτερικών βιβλίων εργασίας. Όταν ένα εξωτερικό βιβλίο εργασίας δεν μπορεί να φορτωθεί, προκύπτει εξαίρεση.

Αυτό το παράδειγμα απαιτεί το `presentation.pptx` με διάγραμμα ως το πρώτο σχήμα στην πρώτη διαφάνεια και ένα προσβάσιμο εξωτερικό βιβλίο εργασίας. Ορίζει την τιμή του κελιού του πρώτου σημείου δεδομένων στην πρώτη σειρά σε 100 και αποθηκεύει την παρουσίαση στο `presentation_out.pptx`. Η επεξεργασία τιμών κελιών μπορεί να ενημερώσει το συνδεδεμένο εξωτερικό αρχείο XLSX, επομένως χρησιμοποιήστε ένα αντίγραφο εάν χρειάζεται να διατηρήσετε το αρχικό βιβλίο εργασίας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Ανάκτηση Βιβλίου Εργασίας από την Κρυφή Μνήμη Διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί ένα εξωτερικό βιβλίο εργασίας που λείπει ή δεν είναι διαθέσιμο, το Aspose.Slides μπορεί να ανακατασκευάσει το βιβλίο εργασίας του διαγράμματος από τα δεδομένα που είναι αποθηκευμένα στην κρύπτη της παρουσίασης. Δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/), καλέστε το [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), και ορίστε το [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/el/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) σε `True` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα Python ανοίγει το `presentation.pptx`, του οποίου το πρώτο σχήμα στην πρώτη διαφάνεια πρέπει να είναι ένα διάγραμμα που αναφέρεται σε μη διαθέσιμο εξωτερικό βιβλίο εργασίας, και προσπελαύνει τα ανακτημένα δεδομένα μέσω των [Chart.getChartData](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#getChartData) και [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Διαβάστε ή τροποποιήστε τα δεδομένα του ανακτημένου βιβλίου εργασίας εδώ.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Εάν το εξωτερικό βιβλίο εργασίας δεν είναι διαθέσιμο και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides πετάει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των δεδομένων από την κρύπτη του διαγράμματος είναι αποδεκτό εναλλακτικό σενάριο, επειδή η κρύπτη μπορεί να μην περιέχει αλλαγές που έγιναν στο εξωτερικό βιβλίο εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερικό ή ενσωματωμένο βιβλίο εργασίας;**

Ναι. Ένα διάγραμμα έχει έναν [data source type](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getDataSourceType) και μια [path to an external workbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); εάν η πηγή είναι εξωτερικό βιβλίο εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται οι σχετικές διαδρομές σε εξωτερικά βιβλία εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν καθορίσετε μια σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Η παρουσίαση αποθηκεύει την απόλυτη διαδρομή στο αρχείο PPTX, οπότε η μετακίνηση του βιβλίου εργασίας μπορεί να απαιτήσει ενημέρωση του συνδέσμου.

**Μπορώ να χρησιμοποιήσω βιβλία εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους δίσκους;**

Ναι, τέτοια βιβλία εργασίας μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλίων εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται· μπορούν μόνο να χρησιμοποιηθούν ως πηγή.

**Αντικαθιστά το Aspose.Slides το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Η παρουσίαση αποθηκεύει έναν [link to the external file](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Η επεξεργασία δεδομένων διαγράμματος που προέρχονται από κελιά μπορεί επίσης να ενημερώσει το συνδεδεμένο τοπικό αρχείο XLSX. Χρησιμοποιήστε ένα αντίγραφο του βιβλίου εργασίας εάν το αρχικό πρέπει να παραμείνει αμετάβλητο.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης κατά τη σύνδεση. Μια συνηθισμένη προσέγγιση είναι η αφαίρεση της προστασίας εκ των προτέρων ή η προετοιμασία ενός αποκρυπτογραφημένου αντιγράφου (π.χ., χρησιμοποιώντας [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) και η σύνδεση σε αυτό το αντίγραφο.

**Μπορούν πολλαπλά διαγράμματα να αναφέρονται στο ίδιο εξωτερικό βιβλίο εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα την επόμενη φορά που θα φορτωθούν τα δεδομένα.