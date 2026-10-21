---
title: Διαχείριση βιβλιοθηκών εργασίας διαγραμμάτων σε παρουσιάσεις χρησιμοποιώντας Python μέσω Java
linktitle: Βιβλιοθήκη εργασίας διαγράμματος
type: docs
weight: 70
url: /el/python-java/chart-workbook/
keywords:
- βιβλιοθήκη εργασίας διαγράμματος
- δεδομένα διαγράμματος
- κελί βιβλιοθήκης εργασίας
- ετικέτα δεδομένων
- φύλλο εργασίας
- πηγή δεδομένων
- εξωτερική βιβλιοθήκη εργασίας
- εξωτερικά δεδομένα
- προσωρινή μνήμη διαγράμματος
- επαναφορά βιβλιοθήκης εργασίας
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Ανακαλύψτε το Aspose.Slides για Python μέσω Java: διαχειριστείτε με ευκολία τις βιβλιοθήκες εργασίας διαγραμμάτων σε μορφές PowerPoint και OpenDocument για να βελτιστοποιήσετε τα δεδομένα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργαστείτε με βιβλιοθήκες εργασίας διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να διαβάζετε και να γράφετε δεδομένα διαγράμματος μέσω ροών βιβλιοθήκης εργασίας, να χρησιμοποιείτε κελιά βιβλιοθήκης εργασίας ως ετικέτες δεδομένων διαγράμματος, να έχετε πρόσβαση σε συλλογές φύλλων εργασίας και να καθορίζετε τον τύπο πηγής δεδομένων για τις τιμές του διαγράμματος.

Καλύπτει επίσης την εργασία με εξωτερικές βιβλιοθήκες εργασίας ως πηγές δεδομένων διαγράμματος. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε και να εκχωρήσετε μια εξωτερική βιβλιοθήκη εργασίας, να ανακτήσετε τη διαδρομή μιας εξωτερικής βιβλιοθήκης εργασίας συνδεδεμένης με ένα διάγραμμα και να επεξεργαστείτε δεδομένα διαγράμματος όταν η βιβλιοθήκη είναι διαθέσιμη.

Για κελιά βιβλιοθήκης εργασίας που αντιπροσωπεύουν ελλιπή δεδομένα, δείτε [Control the Display of Empty Cells](/slides/el/python-java/chart-series/) για τη διαφορά μεταξύ κελιού κενής τιμής και μηδέν, καθώς και σύγκριση γραμμικού διαγράμματος των διαθέσιμων τρόπων εμφάνισης.

## **Συμπερίληψη δεδομένων από κρυφές γραμμές και στήλες**

Χρησιμοποιήστε [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) για να ελέγξετε εάν ένα διάγραμμα σχεδιάζει δεδομένα από κρυφές γραμμές και στήλες φύλλου εργασίας. Ορίστε το σε `True` για να σχεδιάζονται μόνο ορατά κελιά ή σε `False` για να περιλαμβάνονται τόσο ορατά όσο και κρυφά κελιά. Αυτή η ρύθμιση ελέγχει τη σχεδίαση του διαγράμματος· δεν κρύβει ή αποκρύβει γραμμές ή στήλες του φύλλου εργασίας.

Η [sample presentation](hidden-source-data.pptx) περιέχει ένα διάγραμμα στήλης ως το πρώτο σχήμα στην πρώτη διαφάνειά της. Το ενσωματωμένο φύλλο εργασίας, `Sheet1`, περιλαμβάνει την ακόλουθη περιοχή προέλευσης, `A1:C4`. Η γραμμή 3 και η στήλη C είναι κρυφές, αλλά τα κελιά τους εξακολουθούν να περιέχουν τιμές.

| Γραμμή φύλλου | A: Μήνας | B: Λιανική | C: Χονδρική (κρυφή στήλη) |
| --- | --- | --- | --- |
| 2 | Ιανουάριος | 10 | 30 |
| 3 (κρυφή γραμμή) | Φεβρουάριος | 40 | 60 |
| 4 | Μάρτιος | 20 | 50 |

Προσπελάστε τα κελιά προέλευσης μέσω [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) και διαβάστε [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) για να ελέγξετε την κρυφή κατάσταση τους. Αυτή η μέθοδος αναφέρει την κρυφή κατάσταση χωρίς να την αλλάξει. Σε αυτό το αρχείο, το B2 είναι ορατό, το B3 ανήκει στην κρυφή γραμμή και το C2 στην κρυφή στήλη· το παράδειγμα εμφανίζει `False`, `True` και `True` αντίστοιχα.

Για αυτό το παράδειγμα, ανανεώστε τα δεδομένα του διαγράμματος μετά την αλλαγή της ρύθμισης σχεδίασης: διατηρήστε την ενσωματωμένη βιβλιοθήκη εργασίας με [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) και φορτώστε την ξανά με [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Όταν συμπεριλαμβάνετε όλα τα κελιά, χρησιμοποιήστε επίσης το [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) για να επαναφέρετε την πλήρη περιοχή, συμπεριλαμβανομένης της κρυφής κατηγορίας Φεβρουαρίου. Η απλή αλλαγή της σημαίας δεν επαρκεί για την ανανέωση των αποθηκευμένων δεδομένων διαγράμματος και των ετικετών κατηγοριών σε αυτό το παράδειγμα.

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

            # Ανανεώστε τα δεδομένα του διαγράμματος από την ενσωματωμένη βιβλιοθήκη εργασίας.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Αποκαταστήστε την πλήρη περιοχή προέλευσης, συμπεριλαμβανομένων των κρυφών κατηγοριών.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Το παράδειγμα αποθηκεύει δύο εκδοχές της παρουσίασης: μια μόνο με τις ορατές τιμές Λιανικής (10 και 20) και μια άλλη με όλες τις έξι τιμές. Οι εικόνες παρακάτω δείχνουν τις δύο λειτουργίες σχεδίασης. Η γραμμή 3 και η στήλη C παραμένουν κρυφές σε αμφότερες τις ενσωματωμένες βιβλιοθήκες εργασίας.

| Μόνο ορατά κελιά (`True`) | Όλα τα κελιά (`False`) |
| --- | --- |
| ![Μόνο ορατά κελιά: Τιμές λιανικής 10 και 20 για Ιανουάριο και Μάρτιο.](hidden_cells_True.png) | ![Όλα τα κελιά: Τιμές λιανικής και χονδρικής για Ιανουάριο, Φεβρουάριο και Μάρτιο.](hidden_cells_False.png) |

Ένα κρυφό κελί που περιέχει τιμή διαφέρει από ένα κενό κελί. Η μέθοδος [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) ελέγχει πώς εμφανίζονται οι ελλιπείς τιμές· δεν περιλαμβάνει ή εξαιρεί κρυφά δεδομένα προέλευσης. Δείτε [Control the Display of Empty Cells](/slides/el/python-java/chart-series/#control-the-display-of-empty-cells) για ένα παράδειγμα.

## **Ανάκτηση περιοχής δεδομένων ενός διαγράμματος**

Προτού ενημερώσετε τα δεδομένα βιβλιοθήκης εργασίας σε μια υπάρχουσα παρουσίαση, ελέγξτε τις περιοχές προέλευσης για να προσδιορίσετε ποια κελιά φύλλου εργασίας χρησιμοποιεί κάθε διάγραμμα. Η μέθοδος [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) επιστρέφει την τρέχουσα περιοχή δεδομένων ως τύπο επιτρεπόμενης φόρμουλας φύλλου, όπως `Sheet1!$A$1:$D$5`. Εδώ, το `Sheet1` είναι το όνομα του φύλλου εργασίας, το `!` το διαχωρίζει από την περιοχή κελιών και το `$A$1:$D$5` προσδιορίζει τα κελιά A1 έως D5, συμπεριλαμβανομένων. Τα σύμβολα δολαρίου υποδεικνύουν απόλυτες αναφορές γραμμής και στήλης.

Η μέθοδος διαβάζει την τρέχουσα περιοχή χωρίς να αλλάξει το διάγραμμα ή τη βιβλιοθήκη εργασίας του. Εάν το διάγραμμα δεν χρησιμοποιεί βιβλιοθήκη εργασίας ως πηγή δεδομένων, πετάει `InvalidOperationException`. Για περισσότερες πληροφορίες, δείτε την [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Αυτό το παράδειγμα ανοίγει μια παρουσίαση και ελέγχει τα σχήματα απευθείας σε κάθε διαφάνεια για διαγράμματα. Εκτυπώνει το όνομα και την περιοχή προέλευσης κάθε διαγράμματος. Εάν ένα διάγραμμα δεν χρησιμοποιεί βιβλιοθήκη εργασίας, εκτυπώνει ένα μήνυμα και συνεχίζει στο επόμενο διάγραμμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Ανάγνωση και Εγγραφή δεδομένων διαγράμματος από βιβλιοθήκη εργασίας**

Το Aspose.Slides for Python via Java παρέχει τις μεθόδους [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) και [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) που επιτρέπουν την ανάγνωση και εγγραφή βιβλιοθηκών εργασίας δεδομένων διαγράμματος (που περιέχουν δεδομένα διαγράμματος επεξεργασμένα με Aspose.Cells). **Σημείωση** ότι τα δεδομένα διαγράμματος πρέπει να είναι οργανωμένα με τον ίδιο τρόπο ή να έχουν παρόμοια δομή με την πηγή.

Το παράδειγμα χρησιμοποιεί μια παρουσίαση με διάγραμμα ως το πρώτο σχήμα στην πρώτη της διαφάνεια. Διαβάζει την ενσωματωμένη βιβλιοθήκη εργασίας σε έναν πίνακα byte, καθαρίζει τις υπάρχουσες σειρές και κατηγορίες, και γράφει ξανά την ίδια βιβλιοθήκη εργασίας. Οι αλλαγές παραμένουν στη μνήμη· το παράδειγμα δεν αποθηκεύει την παρουσίαση.

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

### **Επικύρωση διάταξης διαγράμματος μετά την τροποποίηση της βιβλιοθήκης εργασίας**

Όταν αντικαθιστάτε μια ενσωματωμένη βιβλιοθήκη εργασίας με μια τροποποιημένη, το διάγραμμα διατηρεί τις αρχικές συλλογές σειρών και κατηγοριών. Αυτή η ασυμφωνία μπορεί να κάνει την [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) να αποτύχει με σφάλμα δείκτη εκτός περιοχής. Καθαρίστε τις υπάρχουσες σειρές και κατηγορίες πριν γράψετε την ενημερωμένη βιβλιοθήκη εργασίας πίσω στο διάγραμμα. Αυτό το παράδειγμα χρησιμοποιεί ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια. Το σχόλιο σημειώνει πού θα γινόταν η επεξεργασία της βιβλιοθήκης εργασίας· το εκτελέσιμο παράδειγμα γράφει την αρχική βιβλιοθήκη εργασίας πίσω και επικυρώνει τη διάταξη στη μνήμη.

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

        # Τροποποιήστε τα byte της βιβλιοθήκης εργασίας εδώ, για παράδειγμα, χρησιμοποιώντας Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Ο καθαρισμός των συλλογών αφαιρεί παλιές αναφορές δεδομένων πριν η βιβλιοθήκη εργασίας γράφεται ξανά. Αναδημιουργήστε τυχόν απαιτούμενες αντιστοιχίες σειρών και κατηγοριών για την ενημερωμένη βιβλιοθήκη εργασίας πριν χρησιμοποιήσετε το διάγραμμα.

## **Ορισμός προσαρμοσμένων μορφών αριθμών για κελιά βιβλιοθήκης εργασίας**

Χρησιμοποιήστε [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) για να ελέγξετε πώς εμφανίζονται οι αριθμητικές τιμές σε ενσωματωμένη βιβλιοθήκη εργασίας διαγράμματος. Για παράδειγμα, μια αναφορά ενδέχεται να χρειάζεται το ποσοστό μετατροπής να εμφανίζεται ως ποσοστό με τέσσερα δεκαδικά ψηφία και ένας συντελεστής να εμφανίζεται με πέντε δεκαδικά ψηφία. Διατηρήστε και τις δύο τιμές αριθμητικές ώστε να παραμένουν διαθέσιμες για υπολογισμούς και σχεδίαση διαγράμματος.

Μια μορφή αριθμού αλλάζει την εμφάνιση, όχι την αποθηκευμένη τιμή. Η μορφή `0.0000%` εμφανίζει το `0.125` ως `12.5000%`; δεν αντικαθιστά τον αποθηκευμένο αριθμό με `12.5`. Παρόμοια, το `0.00000` εμφανίζει το `0.1234567` ως `0.12346` χωρίς στρογγυλοποίηση της αποθηκευμένης τιμής. Εάν η προσαρμοσμένη μορφή είναι κενή συμβολοσειρά (`""`), χρησιμοποιείται η μορφή που επιστρέφει το [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat).

Το ακόλουθο παράδειγμα δημιουργεί ένα διάγραμμα στήλης και προσπελάζει τα κελιά του μέσω του [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook). Στο φύλλο εργασίας 0, το B2 περιέχει το ποσοστό μετατροπής και το C2 το συντελεστή. Και τα δύο κελιά τροφοδοτούν τις τιμές του διαγράμματος. Το παράδειγμα ενεργοποιεί επίσης ετικέτες τιμών που συνδέονται με τις μορφές προέλευσης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Οι μορφές κελιών της βιβλιοθήκης εργασίας είναι ξεχωριστές από τις μορφές που ορίζονται απευθείας στους άξονες διαγράμματος ή στις ετικέτες δεδομένων. Σε αυτό το παράδειγμα, κάθε ετικέτα εμφανίζει την τιμή του κελιού προέλευσής της επειδή το [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) είναι ορισμένο σε `True`, και ακολουθεί τη μορφή αριθμού προέλευσης επειδή το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) είναι επίσης `True`. Μετά την αποθήκευση και ξαναφόρτωση της παρουσίασης, οι ετικέτες εμφανίζουν `12.5000%` και `0.12346`, όπως φαίνεται παρακάτω. Ο κατακόρυφος άξονας χρησιμοποιεί τη δική του μορφή αριθμού, ορισμένη με το [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) ως `0.00`, με το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) ορισμένο σε `False`.

Για τη μορφοποίηση μιας ετικέτας δεδομένων ανεξάρτητα, ορίστε τη σημαία σύνδεσης προέλευσης σε `False` και ορίστε μια μορφή με το [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat). Αυτό δεν αλλάζει τη μορφή του κελιού της βιβλιοθήκης εργασίας. Για παράδειγμα, μια ανεξάρτητη μορφή ετικέτας `0.00` εμφανίζει την πρώτη τιμή ως `0.13`, ενώ το B2 εξακολουθεί να εμφανίζει `12.5000%`. Δείτε [Chart Data Labels](/slides/el/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) για άμεση μορφοποίηση ετικετών.

Η παρακάτω εικόνα δημιουργήθηκε από την αποθηκευμένη παρουσίαση μετά την επαναφόρτωσή της:

![Διάγραμμα στήλης με ετικέτες συνδεδεμένες στην προέλευση που εμφανίζουν 12.5000% και 0.12346 και άξονα αριθμών μορφοποιημένο ανεξάρτητα.](custom-cell-formats.png)

## **Ορισμός κελιού βιβλιοθήκης εργασίας ως ετικέτα δεδομένων διαγράμματος**

Μπορείτε να χρησιμοποιήσετε κείμενο από κελιά βιβλιοθήκης εργασίας ως ετικέτες δεδομένων διαγράμματος.

Το παράδειγμα προσθέτει ένα διάγραμμα φυσαλίδων με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Χρησιμοποιεί τα κελιά A10:A12 στο φύλλο εργασίας 0 για τις πρώτες τρεις ετικέτες της πρώτης σειράς, ενεργοποιεί ετικέτες από κελιά και αποθηκεύει την ενημερωμένη παρουσίαση.

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

## **Διαχείριση φύλλων εργασίας**

Η μέθοδος [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) παρέχει πρόσβαση στα φύλλα εργασίας μιας βιβλιοθήκης εργασίας διαγράμματος. Το παράδειγμα δημιουργεί ένα διάγραμμα πίτας με προεπιλεγμένα δεδομένα και εκτυπώνει το όνομα κάθε φύλλου εργασίας στην κονσόλα.

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

## **Καθορισμός τύπου πηγής δεδομένων**

Το παράδειγμα δημιουργεί ένα τρισδιάστατο διάγραμμα στήλης με προεπιλεγμένα δεδομένα και ορίζει δύο ονόματα σειρών χρησιμοποιώντας διαφορετικές πηγές δεδομένων. Το πρώτο όνομα χρησιμοποιεί κυριολεκτικό κείμενο· το δεύτερο χρησιμοποιεί το κελί C1 στο φύλλο εργασίας 0. Η απαρίθμηση [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) επιλέγει την πηγή για κάθε όνομα. Το παράδειγμα αποθηκεύει την παρουσίαση με τα ενημερωμένα ονόματα σειρών.

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

## **Ανίχνευση μη υποστηριζόμενων ενσωματωμένων μορφών βιβλιοθήκης εργασίας**

Το Aspose.Slides δεν υποστηρίζει τη μορφή δυαδικής βιβλιοθήκης εργασίας Excel (.xlsb) που μπορεί να ενσωματώνεται σε ορισμένα διαγράμματα. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) στο [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) μαζί με την απαρίθμηση [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) για να ανιχνεύσετε μη υποστηριζόμενες μορφές και να παραλείψετε αυτά τα διαγράμματα. Το παράδειγμα ελέγχει τα σχήματα στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης, παραλείπει τα μη-διάγραμμα σχήματα και εκτυπώνει ένα διαγνωστικό μήνυμα για κάθε διάγραμμα με ενσωματωμένη βιβλιοθήκη εργασίας .xlsb.

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

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Διαβάστε ή τροποποιήστε εδώ τα υποστηριζόμενα δεδομένα βιβλιοθήκης εργασίας διαγράμματος.
finally:
    presentation.dispose()
```

## **Εξωτερική βιβλιοθήκη εργασίας**

Το Aspose.Slides υποστηρίζει τη χρήση εξωτερικών βιβλιοθηκών εργασίας ως πηγή δεδομένων για διαγράμματα.

### **Δημιουργία εξωτερικής βιβλιοθήκης εργασίας**

Χρησιμοποιήστε τα [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) και [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) για να εξάγετε μια ενσωματωμένη βιβλιοθήκη εργασίας διαγράμματος σε αρχείο και να συνδέσετε το διάγραμμα με αυτήν την εξωτερική βιβλιοθήκη.

Το παράδειγμα δημιουργεί ένα διάγραμμα πίτας με προεπιλεγμένα δεδομένα και εξάγει τη βιβλιοθήκη εργασίας του. Ολοκληρώνει τη γραφή του αρχείου πριν εκχωρήσει την εξωτερική βιβλιοθήκη ως πηγή δεδομένων του διαγράμματος και, στη συνέχεια, αποθηκεύει την συνδεδεμένη παρουσίαση.

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

### **Ορισμός εξωτερικής βιβλιοθήκης εργασίας**

Χρησιμοποιώντας τη μέθοδο [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), μπορείτε να εκχωρήσετε μια εξωτερική βιβλιοθήκη εργασίας σε ένα διάγραμμα ως πηγή δεδομένων του. Η μέθοδος μπορεί επίσης να χρησιμοποιηθεί για την ενημέρωση της διαδρομής προς την εξωτερική βιβλιοθήκη (εάν αυτή έχει μετακινηθεί).

Ενώ δεν μπορείτε να επεξεργαστείτε τα δεδομένα σε βιβλιοθήκες εργασίας που αποθηκεύονται σε απομακρυσμένες τοποθεσίες ή πόρους, μπορείτε ακόμη να χρησιμοποιήσετε τέτοιες βιβλιοθήκες ως εξωτερική πηγή δεδομένων. Εάν δοθεί σχετική διαδρομή για μια εξωτερική βιβλιοθήκη εργασίας, μετατρέπεται αυτόματα σε πλήρη διαδρομή.

Το παράδειγμα χρησιμοποιεί μια εξωτερική βιβλιοθήκη εργασίας της οποίας το φύλλο εργασίας με όνομα `Sheet1` περιέχει ένα όνομα σειράς στο B1, ονόματα κατηγοριών στο A2:A4 και αριθμητικές τιμές στο B2:B4. Το παράδειγμα δημιουργεί ένα διάγραμμα πίτας, συνδέει τη βιβλιοθήκη εργασίας και χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) για να αντιστοιχίσει το A1:B4 σε μία σειρά και τρεις κατηγορίες. Αποθηκεύει την παρουσίαση με το συνδεδεμένο διάγραμμα.

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

Η παράμετρος `updateChartData` της [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) ελέγχει εάν η βιβλιοθήκη εργασίας θα φορτωθεί.

* Όταν το `updateChartData` είναι `False`, ενημερώνεται μόνο η διαδρομή της βιβλιοθήκης εργασίας. Τα δεδομένα του διαγράμματος δεν φορτώνονται ή ενημερώνονται από τη βιβλιοθήκη εργασίας-στόχο, επομένως η βιβλιοθήκη μπορεί να είναι μη διαθέσιμη.
* Όταν το `updateChartData` είναι `True`, τα δεδομένα του διαγράμματος ενημερώνονται από τη βιβλιοθήκη εργασίας-στόχο.

Το ακόλουθο παράδειγμα εκχωρεί μια εικονική διεύθυνση URL με `updateChartData` ορισμένο σε `False`. Διατηρεί τα προεπιλεγμένα δεδομένα του διαγράμματος πίτας και αποθηκεύει την παρουσίαση χωρίς να φορτώσει τη μη διαθέσιμη βιβλιοθήκη εργασίας.

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

### **Λήψη διαδρομής εξωτερικής βιβλιοθήκης εργασίας πηγής δεδομένων ενός διαγράμματος**

Για να εντοπίσετε τη βιβλιοθήκη εργασίας που είναι συνδεδεμένη με ένα διάγραμμα, ελέγξτε εάν το διάγραμμα χρησιμοποιεί εξωτερική πηγή δεδομένων και ανακτήστε τη διαδρομή της βιβλιοθήκης εργασίας.

Το παράδειγμα εξετάζει το πρώτο σχήμα στην πρώτη διαφάνεια μιας παρουσίασης με συνδεδεμένη εξωτερική βιβλιοθήκη εργασίας. Εάν πρόκειται για διάγραμμα συνδεδεμένο με εξωτερική βιβλιοθήκη εργασίας, το παράδειγμα εκτυπώνει το [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) στην κονσόλα. Στη συνέχεια αποθηκεύει ένα αντίγραφο της παρουσίασης.

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

### **Επεξεργασία δεδομένων διαγράμματος**

Μπορείτε να επεξεργαστείτε τα δεδομένα σε εξωτερικές βιβλιοθήκες εργασίας με τον ίδιο τρόπο που κάνετε αλλαγές στο περιεχόμενο εσωτερικών βιβλιοθηκών εργασίας. Όταν μια εξωτερική βιβλιοθήκη εργασίας δεν μπορεί να φορτωθεί, ρίχνεται εξαίρεση.

Το παράδειγμα χρησιμοποιεί ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και είναι συνδεδεμένο με μια προσβάσιμη εξωτερική βιβλιοθήκη εργασίας. Ορίζει την τιμή υποστηριζόμενη από το κελί του πρώτου σημείου δεδομένων στην πρώτη σειρά σε 100 και αποθηκεύει την ενημερωμένη παρουσίαση. Η επεξεργασία τιμών κελιών μπορεί να ενημερώσει το συνδεδεμένο εξωτερικό αρχείο XLSX· χρησιμοποιήστε ένα αντίγραφο εάν πρέπει να διατηρήσετε την αρχική βιβλιοθήκη εργασίας.

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

### **Ανάκτηση βιβλιοθήκης εργασίας από τη μνήμη διαγράμματος**

Εάν ένα διάγραμμα χρησιμοποιεί εξωτερική βιβλιοθήκη εργασίας που λείπει ή δεν είναι διαθέσιμη, το Aspose.Slides μπορεί να ανακατασκευάσει τη βιβλιοθήκη εργασίας του διαγράμματος από τα δεδομένα που είναι αποθηκευμένα στη μνήμη της παρουσίασης. Δημιουργήστε ένα [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), καλέστε το [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) και ορίστε το [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) σε `True` πριν ανοίξετε την παρουσίαση.

Το παρακάτω παράδειγμα Python ανακτά δεδομένα βιβλιοθήκης εργασίας για ένα διάγραμμα που είναι το πρώτο σχήμα στην πρώτη διαφάνεια και αναφέρεται σε μη διαθέσιμη εξωτερική βιβλιοθήκη εργασίας. Προσπελάζει τα ανακτημένα δεδομένα μέσω του [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) και του [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # Διαβάστε ή τροποποιήστε εδώ τα ανακτημένα δεδομένα της βιβλιοθήκης εργασίας.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Εάν η εξωτερική βιβλιοθήκη εργασίας δεν είναι διαθέσιμη και η ανάκτηση είναι απενεργοποιημένη, το Aspose.Slides ρίχνει εξαίρεση. Ενεργοποιήστε την ανάκτηση μόνο όταν η χρήση των αποθηκευμένων δεδομένων διαγράμματος αποτελεί αποδεκτή εναλλακτική, επειδή η μνήμη ενδέχεται να μην περιέχει αλλαγές που έγιναν στη εξωτερική βιβλιοθήκη εργασίας μετά την τελευταία ενημέρωση της παρουσίασης.

## **Συχνές Ερωτήσεις**

**Μπορώ να προσδιορίσω εάν ένα συγκεκριμένο διάγραμμα είναι συνδεδεμένο με εξωτερική ή ενσωματωμένη βιβλιοθήκη εργασίας;**

Ναι. Ένα διάγραμμα έχει έναν [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) και μια [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); εάν η πηγή είναι εξωτερική βιβλιοθήκη εργασίας, μπορείτε να διαβάσετε τη πλήρη διαδρομή για να βεβαιωθείτε ότι χρησιμοποιείται εξωτερικό αρχείο.

**Υποστηρίζονται σχετικές διαδρομές προς εξωτερικές βιβλιοθήκες εργασίας και πώς αποθηκεύονται;**

Ναι. Εάν δηλώσετε σχετική διαδρομή, αυτή μετατρέπεται αυτόματα σε απόλυτη διαδρομή. Η παρουσίαση αποθηκεύει τη απόλυτη διαδρομή στο αρχείο PPTX, επομένως η μετακίνηση της βιβλιοθήκης εργασίας μπορεί να απαιτήσει ενημέρωση του συνδέσμου.

**Μπορώ να χρησιμοποιήσω βιβλιοθήκες εργασίας που βρίσκονται σε δικτυακούς πόρους/κοινόχρηστους χώρους;**

Ναι, τέτοιες βιβλιοθήκες μπορούν να χρησιμοποιηθούν ως εξωτερική πηγή δεδομένων. Ωστόσο, η επεξεργασία απομακρυσμένων βιβλιοθηκών εργασίας απευθείας από το Aspose.Slides δεν υποστηρίζεται· μπορούν να χρησιμοποιηθούν μόνο ως πηγή.

**Αντικαθιστά το Aspose.Slides το εξωτερικό XLSX κατά την αποθήκευση της παρουσίασης;**

Η παρουσίαση αποθηκεύει ένα [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Η επεξεργασία δεδομένων διαγράμματος που υποστηρίζονται από κελιά μπορεί επίσης να ενημερώσει το συνδεδεμένο τοπικό αρχείο XLSX. Χρησιμοποιήστε ένα αντίγραφο της βιβλιοθήκης εργασίας εάν το αρχικό πρέπει να παραμείνει αμετάβλητο.

**Τι πρέπει να κάνω εάν το εξωτερικό αρχείο είναι προστατευμένο με κωδικό;**

Το Aspose.Slides δεν δέχεται κωδικό πρόσβασης όταν συνδέεται. Μια κοινή προσέγγιση είναι να αφαιρέσετε την προστασία εκ των προτέρων ή να προετοιμάσετε ένα απρόσφατο αντίγραφο (για παράδειγμα, χρησιμοποιώντας [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) και να συνδέσετε αυτό το αντίγραφο.

**Μπορούν πολλαπλά διαγράμματα να αναφέρονται στην ίδια εξωτερική βιβλιοθήκη εργασίας;**

Ναι. Κάθε διάγραμμα αποθηκεύει το δικό του σύνδεσμο. Εάν όλα δείχνουν στο ίδιο αρχείο, η ενημέρωση αυτού του αρχείου θα αντικατοπτρίζεται σε κάθε διάγραμμα την επόμενη φορά που τα δεδομένα θα φορτωθούν.