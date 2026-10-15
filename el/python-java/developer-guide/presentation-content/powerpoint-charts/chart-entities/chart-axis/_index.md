---
title: Προσαρμογή Αξόνων Διαγραμμάτων σε Παρουσιάσεις με Python
linktitle: Άξονας Διαγράμματος
type: docs
url: /el/python-java/chart-axis/
keywords:
- άξονας διαγράμματος
- κατακόρυφος άξονας
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
description: "Ανακαλύψτε πώς να χρησιμοποιήσετε το Aspose.Slides για Python μέσω Java για να προσαρμόσετε τους άξονες διαγραμμάτων σε παρουσιάσεις PowerPoint για αναφορές και οπτικοποιήσεις."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσαρμόσετε τους άξονες διαγραμμάτων με το Aspose.Slides για Python μέσω Java. Καλύπτει υπολογισμένες τιμές άξονα, εναλλαγή σειρών και στηλών διαγράμματος, ορατότητα άξονα, διαστήματα ετικετών κατηγορίας και σημείων στίγματος, κατηγορίες ημερομηνίας και μορφοποίηση, περιστροφή τίτλου, τοποθέτηση άξονα, μονάδες εμφάνισης και λογαριθμική κλιμάκωση.

## **Λήψη των Μέγιστων Τιμών στον Κατακόρυφο Άξονα ενός Διαγράμματος**

Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) και προσθέστε ένα διάγραμμα περιοχής με προεπιλεγμένα δεδομένα. Κλήστε το [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) πριν διαβάσετε τις υπολογισμένες τιμές άξονα ώστε η διάταξη του διαγράμματος να είναι ενημερωμένη.

Διαβάστε τα [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) και [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) για τα όρια του άξονα, και τα [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) και [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) για τα διαστήματα των σημείων στίγματος. Τα [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) και [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) παρέχουν κλίμακες μονάδας χρόνου, οι οποίες είναι σχετικές με άξονες ημερομηνίας. Το παράδειγμα αποθηκεύει αυτές τις τιμές σε τοπικές μεταβλητές και αποθηκεύει το διάγραμμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ανταλλαγή των Δεδομένων μεταξύ Αξόνων**

Χρησιμοποιήστε το [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) για να ανταλλάξετε τους ρόλους των σειρών και των κατηγοριών στα δεδομένα του διαγράμματος. Κάθε παλιά κατηγορία γίνεται σειρά, και κάθε παλιά σειρά γίνεται κατηγορία. Αυτό αλλάζει τον τρόπο ομαδοποίησης των δεδομένων· δεν ανταλλάσσει τους οριζόντιους και κατακόρυφους άξονες. Το παράδειγμα χρησιμοποιεί το [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) για να συνδέσει τα προεπιλεγμένα δεδομένα με `Sheet1!A1:D5`, συμπεριλαμβανομένης της γραμμής κεφαλίδας και της στήλης κατηγορίας, πριν την ανταλλαγή σειρών και στηλών. Αποθηκεύει ένα διάγραμμα με τέσσερις σειρές και τρεις κατηγορίες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αναστροφή της Σειράς Σχεδίασης ενός Άξονα**

Χρησιμοποιήστε το [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) για να αντιστρέψετε έναν άξονα κατηγορίας ή τιμής. Για παράδειγμα, ένα οριζόντιο ραβδόγραμμα μπορεί να εμφανίζει τα στάδια του έργου από πάνω προς τα κάτω με την ίδια σειρά όπως στο φύλλο εργασίας: Σχεδιασμός, Ανάπτυξη, Δοκιμή. Η αντιστροφή ενός άξονα αλλάζει την κατεύθυνση σχεδίασης· δεν ταξινομεί ή αναδιατάσσει τα δεδομένα του βιβλίου εργασίας. Σε σύγκριση, το [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) ανταλλάσσει τους ρόλους των σειρών και των κατηγοριών.

Το παρακάτω παράδειγμα δημιουργεί ένα οριζόντιο ραβδόγραμμα με τρία στάδια και μία σειρά. Αποθηκεύει μια παρουσίαση με τρεις διαφάνειες: κανονική σειρά, αντεστραμμένες κατηγορίες και αντεστραμμένες τιμές. Κάθε αντίγραφο χρησιμοποιεί το ίδιο σύνολο δεδομένων, και μόνο ένας άξονας είναι αντεστραμμένος σε κάθε αντίγραφο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Διαφάνεια 2: εμφάνιση της πρώτης κατηγορίας στην κορυφή.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # Διατήρηση του οριζόντιου άξονα τιμών στο κάτω μέρος.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Διαφάνεια 3: αντιστροφή μόνο της οριζόντιας αριθμητικής κλίμακας.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η αντιστροφή ενός άξονα μπορεί επίσης να μετακινήσει τον κάθετο άξονα στην αντίθετη πλευρά του διαγράμματος. Το [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) ελέγχει πού ο άλλος άξονας διασχίζει τον άξονα που διαμορφώνεται. Στη διαφάνεια 2, καλώντας το με [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) στον αντεστραμμένο άξονα κατηγορίας διατηρεί τον οριζόντιο άξονα τιμής στο κάτω μέρος. Για ένα συγκεκριμένο σημείο διασταύρωσης, χρησιμοποιήστε το [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Ελέγξτε τις ρυθμίσεις διασταύρωσης όταν αλλάζετε κατεύθυνση, ιδιαίτερα αν το διάγραμμα έχει ήδη προσαρμοσμένο σημείο διασταύρωσης. Καλέστε το [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) με `False` για να επαναφέρετε τη φυσική κατεύθυνση σχεδίασης· οι ρυθμίσεις διασταύρωσης είναι ξεχωριστές.

| Κανονική σειρά (διαφάνεια 1) | Αντεστραμμένες κατηγορίες (διαφάνεια 2) | Αντεστραμμένες τιμές (διαφάνεια 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| Οι κατηγορίες τρέχουν από κάτω προς πάνω· οι τιμές αυξάνονται από αριστερά προς δεξιά. | Σχεδιασμός, Ανάπτυξη και Δοκιμή τρέχουν από πάνω προς κάτω. Οι τιμές και η σειρά γραμμών του βιβλίου εργασίας παραμένουν αμετάβλητες. | Οι κατηγορίες διατηρούν τη φυσική τους σειρά· οι τιμές αυξάνονται από δεξιά προς αριστερά. Ο άξονας κατηγορίας διασχίζει στο μηδέν στα δεξιά. |

## **Απενεργοποίηση του Κατακόρυφου Άξονα για Διαγράμματα Γραμμής**

Καλέστε το [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) με `False` στον κατακόρυφο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον κατακόρυφο άξονα κρυμμένο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Απενεργοποίηση του Οριζόντιου Άξονα για Διαγράμματα Γραμμής**

Καλέστε το [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) με `False` στον οριζόντιο άξονα για να τον κρύψετε. Το παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με προεπιλεγμένα δεδομένα και το αποθηκεύει με τον οριζόντιο άξονα κρυμμένο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αλλαγή Άξονα Κατηγορίας**

Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) για να επιλέξετε άξονα κατηγορίας σε μορφή ημερομηνίας ή κειμένου. Αυτό το παράδειγμα απαιτεί το `ExistingChart.pptx`, με ένα διάγραμμα ως το πρώτο σχήμα στην πρώτη διαφάνεια και κελιά κατηγορίας που περιέχουν αριθμητικές τιμές ημερομηνίας Excel. Αλλάζει τον οριζόντιο άξονα σε άξονα ημερομηνίας. Καλώντας το [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) με `False`, το [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) με `1` και το [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) με [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) τοποθετεί τα κύρια σημεία στίγματος σε ενδιάμεσα ενός μήνα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Έλεγχος Διαστημάτων Ετικετών Άξονα Κατηγορίας**

Όταν ένα διάγραμμα έχει πολλές κατηγορίες, μειώστε τον αριθμό των ορατών ετικετών άξονα χωρίς να αφαιρέσετε κατηγορίες ή σημεία δεδομένων. Καλέστε το [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) με `False`, μετά περάστε το επιθυμητό διάστημα κατηγορίας στο [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Για κειμενικές κατηγορίες στη φυσική τους σειρά, η μέτρηση αρχίζει από την πρώτη κατηγορία:

| Διάστημα | Ετικέτες που εμφανίζονται στο παράδειγμα |
| --- | --- |
| `1` | Κατηγορία 1, Κατηγορία 2, Κατηγορία 3, … Κατηγορία 24 |
| `2` | Κατηγορία 1, Κατηγορία 3, Κατηγορία 5, … Κατηγορία 23 |
| `3` | Κατηγορία 1, Κατηγορία 4, Κατηγορία 7, … Κατηγορία 22 |

Ένα διάστημα `3` εμφανίζει κάθε τρίτη ετικέτα, αφήνοντας δύο ετικέτες κρυμμένες μεταξύ των εμφανιζόμενων. Δεν αφαιρεί τις αντίστοιχες στήλες. Η αυτόματη διάστημα επιλέγει ένα διάστημα βάσει του διαθέσιμου χώρου· δεν εμφανίζει απαραίτητα κάθε ετικέτα.

Τα σημεία στίγματος έχουν ξεχωριστούς ελέγχους. Καλέστε το [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) με `False` και χρησιμοποιήστε το [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) για να ορίσετε το διάστημά τους. Για παράδειγμα, `1` διατηρεί ένα σημείο στίγματος σε κάθε διάστημα κατηγορίας ενώ οι ετικέτες εμφανίζονται μόνο κάθε τρίτη κατηγορία. Χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) με ένα ορατό στυλ ώστε να δείτε το αποτέλεσμα. Κάνοντας ξανά κλήση σε οποιοδήποτε setter αυτόματης διάστασης με `True` αφήνει το διάγραμμα να επιλέξει ξανά αυτό το διάστημα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί 24 κατηγορίες και μία σειρά, έπειτα αποθηκεύει τρεις διαφάνειες σε `CategoryAxisIntervals.pptx`: αυτόματη διάστημα, χειροκίνητη διάσταση ετικετών με ανεξάρτητα σημεία στίγματος, και επαναφορά της αυτόματης διάστασης. Τα δύο αντίγραφα διατηρούν τα αρχικά δεδομένα του διαγράμματος. Δεν απαιτείται εμετάσθιση παρουσίασης. Το οριζόντιο κείμενο των ετικετών κάνει τη διαφορά στην πυκνότητα εύκολα ορατή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # Διαφάνεια 2: εμφάνιση κάθε τρίτης ετικέτας, αλλά διατήρηση σημείου στίγματος για κάθε κατηγορία.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Διαφάνεια 3: άδεια στο διάγραμμα να επιλέξει ξανά και τα δύο διαστήματα.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Αυτόματη διάσταση (διαφάνεια 1):** Σε αυτήν την απόδοση, κάθε δεύτερη ετικέτα κατηγορίας εμφανίζεται και προσαρμόζεται σε δύο γραμμές. Το αυτόματο αποτέλεσμα μπορεί να διαφέρει ανάλογα με το μέγεθος του διαγράμματος, τις γραμματοσειρές και τον renderer.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Χειροκίνητη διάσταση (διαφάνεια 2):** Κάθε τρίτη ετικέτα εμφανίζεται σε μία γραμμή, ενώ τα σημεία στίγματος παραμένουν σε κάθε διάστημα κατηγορίας. Όλες οι 24 στήλες, συμπεριλαμβανομένων αυτών χωρίς ετικέτες, παραμένουν εμφανείς με τις ίδιες τιμές. Η διαφάνεια 3 επαναφέρει την αυτόματη εμφάνιση που φαίνεται παραπάνω.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Επιλέξτε τον Σωστό Άξονα και Διάστημα**

Χρησιμοποιήστε αυτό το διάστημα καταμέτρησης κατηγοριών για έναν άξονα κατηγορίας κειμένου, όπως ο άξονας κατηγορίας ενός ραβδογράμματος, γραμμικού, περιοχής ή στήλης. Σε διάγραμμα στήλης, είναι ο οριζόντιος άξονας. Σε οριζόντιο ραβδόγραμμα, ο άξονας κατηγορίας είναι κατακόρυφος, οπότε εφαρμόστε αυτές τις ρυθμίσεις στον άξονα που επιστρέφεται από το [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Η διάσταση σημείων στίγματος ισχύει επίσης για άξονα σειράς σε διαγράμματα που έχουν τέτοιο.

Μη χρησιμοποιείτε τη διάσταση ετικετών κατηγορίας για να ορίσετε την αριθμητική κλίμακα ενός άξονα τιμής. Σε άξονα τιμής, το [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) καθορίζει μια διαφορά τιμών: για παράδειγμα, μια κύρια μονάδα `10` παράγει σημεία στίγματος στο 0, 10, 20 κ.λπ. όταν ο άξονας ξεκινά στο μηδέν. Ένα διάστημα ετικέτας κατηγορίας `3` μετράει θέσεις κατηγοριών, ανεξάρτητα από τις τιμές τους. Διαγράμματα διασποράς και φυσαλίδων χρησιμοποιούν άξονες τιμής αντί για άξονα κατηγορίας κειμένου. Για άξονα ημερομηνίας, χρησιμοποιήστε χρονικές κύριες μονάδες και κλίμακες όπως περιγράφεται στην ενότητα [Αλλαγή Άξονα Κατηγορίας](#αλλαγή-άξονα-κατηγορίας).

## **Ορισμός Μορφής Ημερομηνίας για Τιμές Άξονα Κατηγορίας**

Το παράδειγμα αντικαθιστά τα προεπιλεγμένα δεδομένα διαγράμματος με τέσσερις ετήσιες τιμές. Οι ημερομηνίες αποθηκεύονται ως σειριακοί αριθμοί OLE Automation στο πρώτο φύλλο εργασίας (δείκτης `0`), υπολογιζόμενοι ως ο αριθμός ημερών από τις 30 Δεκεμβρίου 1899 για αυτές τις ημερομηνίες. Χρησιμοποιήστε το [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) με [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), καλέστε το [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) με `False`, και περάστε `yyyy` στο [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) ώστε οι ετικέτες κατηγορίας να εμφανίζουν τετραψήφια έτη ανεξάρτητα από τη μορφοποίηση των κελιών.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Γωνίας Περιστροφής για Τίτλο Άξονα Διαγράμματος**

Καλέστε το [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) με `True` στον κατακόρυφο άξονα, δώστε το κείμενο του τίτλου και ορίστε τη γωνία περιστροφής στη μορφοποίηση του μπλοκ κειμένου του τίτλου. Η γωνία μετριέται σε μοίρες· αυτό το παράδειγμα αποθηκεύει ένα διάγραμμα στήλης με τον τίτλο του άξονα τιμής του περιστραμμένο κατά 90 μοίρες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Θέσης Άξονα σε Άξονα Κατηγορίας ή Τιμής**

Χρησιμοποιήστε το [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) για να ελέγξετε αν ο άξονας τιμής διασχίζει τον άξονα κατηγορίας μεταξύ των κατηγοριών ή στα σημεία στίγματος κατηγορίας. Αυτή η ρύθμιση εφαρμόζεται σε άξονες κατηγορίας. Το παράδειγμα το ορίζει σε `True` στον οριζόντιο άξονα κατηγορίας ενός διαγράμματος στήλης και αποθηκεύει το αποτέλεσμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Μονάδας Εμφάνισης σε Άξονα Τιμής Διαγράμματος**

Χρησιμοποιήστε το [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) για να κλιμακώσετε τις ετικέτες ενός άξονα τιμής χωρίς να αλλάξετε τα υποκείμενα δεδομένα. Με το [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) ορισμένο σε `Millions`, η τιμή 60 000 000 εμφανίζεται ως 60. Το παράδειγμα δημιουργεί ένα διάγραμμα στήλης και εφαρμόζει τη μονάδα εμφάνισης εκατομμυρίων στον κατακόρυφο άξονά του.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Διαμόρφωση Λογαριθμικού Άξονα Τιμής**

Ένας λογαριθμικός άξονας τιμής είναι χρήσιμος όταν θετικές τιμές καλύπτουν πολλές τάξεις μεγέθους. Για παράδειγμα, μια υπηρεσία μπορεί να λάβει 10, 100, 1 000, 10 000 και 100 000 αιτήσεις σε πέντε περιόδους. Σε γραμμική κλίμακα, οι μικρότερες τιμές εμφανίζονται κοντά μεταξύ τους κοντά στο μηδέν. Μια λογαριθμική κλίμακα κάνει την σχετική τους ανάπτυξη πιο συγκρίσιμη: ίσες αποστάσεις αντιπροσωπεύουν ίσους λόγους αντί για ίσες διαφορές.

Καλέστε το [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) με `True` στον άξονα τιμής και χρησιμοποιήστε το [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) για να επιλέξετε τη βάση. Αυτό αλλάζει τον τρόπο εμφάνισης των υφιστάμενων τιμών· δεν αλλάζει τα δεδομένα ή προσθέτει λογαριθμική γραμμή τάσης. Μια γραμμή τάσης αποτελεί ξεχωριστή λειτουργία.

### **Επιλέξτε τον Άξονα Τιμής και τη Βάση**

Για διάγραμμα γραμμής ή στήλης, ο άξονας τιμής επιστρέφεται από το [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Για οριζόντιο ραβδόγραμμα, επιστρέφεται από το [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Τα διαγράμματα διασποράς και φυσαλίδων έχουν δύο άξονες τιμής, οπότε επιλέξτε τον οριζόντιο άξονα για τις τιμές X, τον κατακόρυφο για τις τιμές Y, ή και τους δύο. Μην εφαρμόζετε λογαριθμική κλιμάκωση σε άξονα κατηγορίας.

Η προεπιλεγμένη λογαριθμική βάση είναι `10`. Για διαγράμματα PPTX, χρησιμοποιήστε βάση από `2` μέχρι `1000`, συμπεριλαμβανομένων· υποστηρίζονται επίσης κλασματικές βάσεις όπως `2.5`. Με βάση `10`, οι επόμενες δυνάμεις όπως 10, 100, 1 000 και 10 000 είναι εξίσου διαστήματα.

### **Σύγκριση Γραμμικής και Λογαριθμικής Κλίμακας**

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα διάγραμμα γραμμής με τις πέντε καταμετρήσεις αιτήσεων στη πρώτη διαφάνεια, έπειτα κλωνοποιεί αυτήν τη διαφάνεια και ενεργοποιεί λογαριθμικό άξονα τιμής βάσης‑10 στη δεύτερη. Και οι δύο διαφάνειες διατηρούν τα ίδια δεδομένα.

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Διατηρήστε την πρώτη διαφάνεια γραμμική και αλλάξτε μόνο την κλίμακα του άξονα τιμών του αντιγράφου.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Γραμμική κλίμακα (διαφάνεια 1):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσες διαφορές στις μετρήσεις αιτήσεων. Η μεγαλύτερη τιμή κυριαρχεί στο διάγραμμα, καθιστώντας τις μικρότερες τιμές δύσκολα διακρίσιμες.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Λογαριθμική κλίμακα (διαφάνεια 2):** Ίσες κατακόρυφες αποστάσεις αντιπροσωπεύουν ίσους λόγους. Κάθε περίοδος έχει δέκα φορές περισσότερες αιτήσεις από την προηγούμενη, οπότε τα σημεία σχηματίζουν μια ευθεία άνοδική γραμμή στη βάση‑10. Οι ετικέτες του άξονα εξακολουθούν να δείχνουν τις αρχικές μετρήσεις αιτήσεων.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Διαχείριση Μηδενικών και Αρνητικών Τιμών**

Μια λογαριθμική κλίμακα μπορεί να εμφανίσει μόνο αυστηρά θετικές τιμές. Ελέγξτε τα δεδομένα πριν την ενεργοποιήσετε. Εάν μηδενικές ή αρνητικές τιμές έχουν νόημα, διατηρήστε τη γραμμική κλίμακα ή προβάλετε τες ξεχωριστά. Εάν η εξαίρεση αυτών των τιμών είναι κατάλληλη για την ανάλυση, εξηγήστε την παράλειψη. Μη τις αντικαθιστάτε σιωπηλά με μικρές θετικές τιμές, καθώς αυτό αλλάζει το νόημα των δεδομένων. Οποιαδήποτε χειροκίνητα ρυθμισμένη ελάχιστη ή μέγιστη τιμή για λογαριθμικό άξονα πρέπει επίσης να είναι θετική.

## **Συχνές Ερωτήσεις**

**Πώς ορίζω την τιμή στην οποία ένας άξονας διασχίζει τον άλλο (διασταύρωση άξονα);**

Χρησιμοποιήστε το [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) για να επιλέξετε τη συμπεριφορά διασταύρωσης. Για να καθορίσετε αριθμητική τιμή διασταύρωσης, χρησιμοποιήστε το [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Αυτές οι ρυθμίσεις σας επιτρέπουν να μετακινήσετε τη διασταύρωση άξονα σε κατάλληλη βάση.

**Πώς μπορώ να τοποθετήσω τις ετικέτες σημείων στίγματος σε σχέση με τον άξονα;**

Καλέστε το [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) χρησιμοποιώντας το [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ή `None`. Για να ελέγξετε τα ίδια τα σημεία στίγματος, χρησιμοποιήστε το [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) ή το [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); αυτά είναι ξεχωριστά από τη θέση των ετικετών.