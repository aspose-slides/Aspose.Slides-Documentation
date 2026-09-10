---
title: Προσαρμογή Αξόνων Διαγράμματος σε Παρουσιάσεις Χρησιμοποιώντας Python
linktitle: Άξονας Διαγράμματος
type: docs
url: /el/python-java/chart-axis/
keywords:
- άξονας διαγράμματος
- κάθετος άξονας
- οριζόντιος άξονας
- προσαρμογή άξονα
- χειρισμός άξονα
- διαχείριση άξονα
- ιδιότητες άξονα
- μέγιστη τιμή
- ελάχιστη τιμή
- γραμμή άξονα
- μορφή ημερομηνίας
- τίτλος άξονα
- θέση άξονα
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για Python μέσω Java για να προσαρμόσετε τους άξονες διαγράμματος σε παρουσιάσεις PowerPoint για αναφορές και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες διαγραμμάτων στο Aspose.Slides. Δείχνει πώς να λάβετε τις πραγματικές τιμές του άξονα, να ανταλλάξετε δεδομένα μεταξύ αξόνων, να κρύψετε τον κάθετο ή τον οριζόντιο άξονα για γραφήματα γραμμής, να αλλάξετε τον τύπο του άξονα κατηγορίας, να ορίσετε τη μορφή ημερομηνίας για τις τιμές του άξονα κατηγορίας, να περιστρέψετε τον τίτλο του άξονα, να ορίσετε τη θέση του άξονα και να ορίσετε τη μονάδα εμφάνισης του άξονα τιμών.

## **Λήψη των Μέγιστων Τιμών στον Κάθετο Άξονα ενός Διαγράμματος**

Aspose.Slides for Python via Java σας επιτρέπει να λάβετε τις ελάχιστες και μέγιστες τιμές σε έναν κάθετο άξονα. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Προσπελάστε την πρώτη διαφάνεια.
1. Προσθέστε ένα διάγραμμα με προεπιλεγμένα δεδομένα.
1. Λάβετε την πραγματική μέγιστη τιμή στον άξονα.
1. Λάβετε την πραγματική ελάχιστη τιμή στον άξονα.
1. Λάβετε την πραγματική κύρια μονάδα του άξονα.
1. Λάβετε την πραγματική δευτερεύουσα μονάδα του άξονα.
1. Λάβετε την πραγματική κλίμακα κύριας μονάδας του άξονα.
1. Λάβετε την πραγματική κλίμακα δευτερεύουσας μονάδας του άξονα.

Αυτό το δείγμα κώδικα — μια υλοποίηση των παραπάνω βημάτων — σας δείχνει πώς να λάβετε τις απαιτούμενες τιμές στην Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # Αποθηκεύει την παρουσίαση
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ανταλλαγή των Δεδομένων μεταξύ Αξόνων**

Το Aspose.Slides σας επιτρέπει να ανταλλάξετε γρήγορα τα δεδομένα μεταξύ των αξόνων — τα δεδομένα που αναπαρίστανται στον κάθετο άξονα (y-axis) μετακινούνται στον οριζόντιο άξονα (x-axis) και αντίστροφα.

Αυτός ο κώδικας Python σας δείχνει πώς να εκτελέσετε την εργασία ανταλλαγής δεδομένων μεταξύ αξόνων σε ένα διάγραμμα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Φορτώνει τα προεπιλεγμένα δεδομένα του διαγράμματος στο βιβλίο εργασίας — η μέθοδος switchRowColumn μετατρέπει το βιβλίο εργασίας,
    # οπότε πρέπει να συμπληρωθεί πρώτα
    workbook = chart.getChartData().getChartDataWorkbook()

    # Αλλάζει σειρές και στήλες
    chart.getChartData().switchRowColumn()

    # Αποθηκεύει την παρουσίαση
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Απενεργοποίηση του Κάθετου Άξονα για Διαγράμματα Γραμμής**

Αυτός ο κώδικας Python σας δείχνει πώς να κρύψετε τον κάθετο άξονα για ένα διάγραμμα γραμμής:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Απενεργοποίηση του Οριζόντιου Άξονα για Διαγράμματα Γραμμής**

Αυτός ο κώδικας σας δείχνει πώς να κρύψετε τον οριζόντιο άξονα για ένα διάγραμμα γραμμής:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αλλαγή του Άξονα Κατηγορίας**

Χρησιμοποιώντας τη μέθοδο [setCategoryAxisType](https://reference.aspose.com/slides/el/python-java/aspose.slides/axis/#setCategoryAxisType), μπορείτε να καθορίσετε τον προτιμώμενο τύπο άξονα κατηγορίας (**date** ή **text**). Αυτός ο κώδικας σε Python επιδεικνύει τη λειτουργία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **Ορισμός της Μορφής Ημερομηνίας για τις Τιμές του Άξονα Κατηγορίας**

Το Aspose.Slides for Python via Java σας επιτρέπει να ορίσετε τη μορφή ημερομηνίας για μια τιμή άξονα κατηγορίας. Η λειτουργία επιδεικνύεται σε αυτόν τον κώδικα Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Γωνίας Περιστροφής για τον Τίτλο Άξονα Διαγράμματος**

Το Aspose.Slides for Python via Java σας επιτρέπει να ορίσετε τη γωνία περιστροφής για τον τίτλο άξονα ενός διαγράμματος. Αυτός ο κώδικας Python επιδεικνύει τη λειτουργία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός της Θέσης του Άξονα σε Άξονα Κατηγορίας ή Τιμής**

Το Aspose.Slides for Python via Java σας επιτρέπει να ορίσετε τη θέση του άξονα σε άξονα κατηγορίας ή τιμής. Αυτός ο κώδικας Python δείχνει πώς να εκτελέσετε την εργασία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός της Μονάδας Εμφάνισης σε Άξονα Τιμής Διαγράμματος**

Το Aspose.Slides for Python via Java σας επιτρέπει να ορίσετε τη μονάδα εμφάνισης ενός άξονα τιμής διαγράμματος. Το άξονα στη συνέχεια κλιμακώνει τις ετικέτες των τιμογραμμών του κατά αυτή τη μονάδα: με [DisplayUnitType.Millions](https://reference.aspose.com/slides/el/python-java/aspose.slides/displayunittype/#Millions), ένας άξονας που φτάνει τα 60.000.000 εμφανίζεται με ετικέτες 0 έως 60. Αυτός ο κώδικας Python επιδεικνύει τη λειτουργία:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Πώς ορίζω την τιμή όπου ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Οι άξονες παρέχουν μια [ρύθμιση διασταύρωσης](https://reference.aspose.com/slides/el/python-java/aspose.slides/axis/#setCrossType): μπορείτε να επιλέξετε να διασταυρωθεί στο μηδέν, στη μέγιστη κατηγορία/τιμή, ή σε συγκεκριμένη αριθμητική τιμή. Αυτό είναι χρήσιμο για μετακίνηση του άξονα X προς τα πάνω ή κάτω ή για τονισμό μιας βασικής γραμμής.

**Πώς μπορώ να τοποθετήσω τις σημειώσεις κλίμακας σε σχέση με τον άξονα (διασταύρωση, έξω, μέσα);**

Ορίστε τη [θέση σημείωσης κλίμακας](https://reference.aspose.com/slides/el/python-java/aspose.slides/axis/#setMajorTickMark) σε "cross", "outside" ή "inside". Αυτό επηρεάζει την αναγνωσιμότητα και βοηθά στη διατήρηση του χώρου, ειδικά σε μικρά διαγράμματα.