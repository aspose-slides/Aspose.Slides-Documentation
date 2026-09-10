---
title: Προσαρμογή διαγραμμάτων πίτας σε παρουσιάσεις χρησιμοποιώντας Python μέσω Java
linktitle: Διάγραμμα Πίτας
type: docs
url: /el/python-java/pie-chart/
keywords:
- διάγραμμα πίτας
- διαχείριση διαγράμματος
- προσαρμογή διαγράμματος
- επιλογές διαγράμματος
- ρυθμίσεις διαγράμματος
- επιλογές απεικόνισης
- χρώμα τμήματος
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα πίτας σε Python μέσω Java με Aspose.Slides, εξαγώγιμα σε PowerPoint, ενισχύοντας την αφήγηση των δεδομένων σας σε λίγα δευτερόλεπτα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με διαγράμματα πίτας στο Aspose.Slides. Εμφανίζει πώς να διαμορφώσετε τις επιλογές δευτερεύουσας απεικόνισης για τα διαγράμματα Pie of Pie και Bar of Pie, καθώς και πώς να ενεργοποιήσετε την αυτόματη χρωματιστική των τμημάτων για ένα τυπικό διάγραμμα πίτας.

Τα παραδείγματα εστιάζουν σε πρακτικά βήματα προσαρμογής διαγράμματος, όπως η προσθήκη διαγράμματος σε μια διαφάνεια, η προσαρμογή των σειρών και των ρυθμίσεων ετικετών, η αντικατάσταση των προεπιλεγμένων δεδομένων διαγράμματος με προσαρμοσμένες κατηγορίες και τιμές, και η αποθήκευση της ενημερωμένης παρουσίασης.

## **Δευτερεύουσες Επιλογές Απεικόνισης για Διαγράμματα Pie of Pie και Bar of Pie**

Aspose.Slides for Python via Java υποστηρίζει δευτερεύουσες επιλογές απεικόνισης για τα διαγράμματα Pie of Pie και Bar of Pie. Αυτή η ενότητα δείχνει πώς να καθορίσετε αυτές τις επιλογές χρησιμοποιώντας το Aspose.Slides. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο [Παρουσίαση](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Προσθέστε ένα διάγραμμα στη διαφάνεια.
3. Καθορίστε τις δευτερεύουσες επιλογές απεικόνισης του διαγράμματος.
4. Γράψτε την παρουσίαση στο δίσκο.

Το παρακάτω παράδειγμα ορίζει διαφορετικές ιδιότητες ενός διαγράμματος Pie of Pie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

    # Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
presentation = Presentation()
try:
    # Προσθέστε ένα διάγραμμα στη διαφάνεια.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Ορίστε διαφορετικές ιδιότητες.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Αυτόματων Χρωμάτων Τμημάτων Διαγράμματος Πίτας**

Το Aspose.Slides for Python via Java παρέχει ένα απλό API για τον ορισμό αυτόματων χρωμάτων τμημάτων διαγράμματος πίτας. Το παρακάτω παράδειγμα δείχνει πώς να εφαρμόσετε αυτές τις ρυθμίσεις.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) .
2. Προσπελάστε την πρώτη διαφάνεια.
3. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα.
4. Ορίστε τον τίτλο του διαγράμματος.
5. Ορίστε το ευρετήριο του φύλλου εργασίας δεδομένων του διαγράμματος.
6. Αποκτήστε το βιβλίο εργασίας δεδομένων του διαγράμματος.
7. Διαγράψτε τις προεπιλεγμένες σειρές και κατηγορίες.
8. Προσθέστε νέες κατηγορίες.
9. Προσθέστε μια νέα σειρά.
10. Ορίστε η νέα σειρά να εμφανίζει τιμές.
11. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
presentation = Presentation()
try:
    # Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Ορίστε τον τίτλο του διαγράμματος.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Ορίστε το ευρετήριο του φύλλου εργασίας δεδομένων του διαγράμματος.
    default_worksheet_index = 0

    # Αποκτήστε το βιβλίο εργασίας δεδομένων του διαγράμματος.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Διαγράψτε τις προεπιλεγμένες σειρές και κατηγορίες.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Προσθέστε νέες κατηγορίες.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Προσθέστε μια νέα σειρά.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Συμπληρώστε τα δεδομένα της σειράς.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Ορίστε τη νέα σειρά να εμφανίζει τιμές.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζονται οι παραλλαγές 'Pie of Pie' και 'Bar of Pie';**

Ναι, η βιβλιοθήκη [υποστηρίζει](https://reference.aspose.com/slides/el/python-java/aspose.slides/charttype/) μια δευτερεύουσα απεικόνιση για διαγράμματα πίτας, περιλαμβανομένων των τύπων 'Pie of Pie' και 'Bar of Pie'.

**Μπορώ να εξάγω μόνο το διάγραμμα ως εικόνα (π.χ., PNG);**

Ναι, μπορείτε να [εξάγετε το ίδιο το διάγραμμα ως εικόνα](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/#getImage) (π.χ. PNG) χωρίς ολόκληρη την παρουσίαση.