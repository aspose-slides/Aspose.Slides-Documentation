---
title: Βελτιστοποίηση Υπολογισμών Διαγραμμάτων για Παρουσιάσεις σε Python μέσω Java
linktitle: Υπολογισμοί Διαγραμμάτων
type: docs
weight: 50
url: /el/python-java/chart-calculations/
keywords:
- υπολογισμοί διαγραμμάτων
- στοιχεία διαγράμματος
- θέση στοιχείου
- πραγματική θέση
- θυγατρικό στοιχείο
- γονικό στοιχείο
- τιμές διαγράμματος
- πραγματική τιμή
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Κατανοήστε τους υπολογισμούς διαγραμμάτων, τις ενημερώσεις δεδομένων και τον έλεγχο ακρίβειας στο Aspose.Slides για Python μέσω Java για PPT και PPTX, με πρακτικά παραδείγματα κώδικα Python."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει API για εργασία με υπολογισμούς διαγραμμάτων και δεδομένα διάταξης σε παρουσιάσεις. Αυτό το άρθρο δείχνει πώς να ανακτήσετε τις πραγματικές τιμές των στοιχείων διαγράμματος, συμπεριλαμβανομένης της πραγματικής θέσης και του μεγέθους των στοιχείων διαγράμματος καθώς και των πραγματικών τιμών των αξόνων του διαγράμματος. Εξηγεί επίσης ότι αυτές οι τιμές γεμίζουν μετά την επικύρωση της διάταξης του διαγράμματος.

## **Υπολογισμός Πραγματικών Τιμών Στοιχείων Διαγράμματος**
Το Aspose.Slides for Python via Java παρέχει ένα απλό API για λήψη αυτών των ιδιοτήτων. Οι μέθοδοι της κλάσης [Axis](https://reference.aspose.com/slides/el/python-java/aspose.slides/axis/) παρέχουν πληροφορίες για τις πραγματικές τιμές των αξόνων του διαγράμματος ([getActualMaxValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/el/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/el/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/el/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/el/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/el/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Καλέστε τη μέθοδο [Chart.validateChartLayout](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#validateChartLayout) πρώτα για να γεμίσετε αυτές τις ιδιότητες με πραγματικές τιμές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Υπολογισμός Πραγματικής Θέσης Γονικών Στοιχείων Διαγράμματος**
Το Aspose.Slides for Python via Java παρέχει ένα απλό API για λήψη αυτών των ιδιοτήτων. Οι μέθοδοι της κλάσης [ChartPlotArea](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartplotarea/) παρέχουν πληροφορίες για τη πραγματική θέση και το μέγεθος της περιοχής σχεδίασης του διαγράμματος ([getActualX](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartplotarea/#getActualHeight)). Καλέστε τη μέθοδο [Chart.validateChartLayout](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/#validateChartLayout) πρώτα για να γεμίσετε αυτές τις ιδιότητες με πραγματικές τιμές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Απόκρυψη Στοιχείων Διαγράμματος**
Αυτή η ενότητα εξηγεί πώς να αποκρύψετε πληροφορίες από ένα διάγραμμα. Χρησιμοποιώντας το Aspose.Slides for Python via Java, μπορείτε να αποκρύψετε τον **Τίτλο, τον Κάθετο Άξονα, τον Οριζόντιο Άξονα** και τις **Γραμμές Πλέγματος**. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να χρησιμοποιήσετε αυτές τις ιδιότητες.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Απόκρυψη του τίτλου του διαγράμματος.
    chart.setTitle(False)

    # Απόκρυψη του άξονα τιμών.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Απόκρυψη του άξονα κατηγοριών.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Απόκρυψη του υποσημειώματος.
    chart.setLegend(False)

    # Απόκρυψη των κύριων γραμμών πλέγματος.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Διατήρηση μόνο της πρώτης σειράς. Η αφαίρεση από το τέλος διατηρεί έγκυρους τους υπόλοιπους δείκτες.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Ορισμός του χρώματος γραμμής της σειράς.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορούν τα εξωτερικά βιβλία εργασίας Excel να λειτουργήσουν ως πηγή δεδομένων και πώς αυτό επηρεάζει τον επανυπολογισμό;**

Ναι. Ένα διάγραμμα μπορεί να αναφέρεται σε εξωτερικό βιβλίο εργασίας: όταν συνδέεστε ή ανανεώνετε την εξωτερική πηγή, οι φόρμουλες και οι τιμές λαμβάνονται από εκείνο το βιβλίο, και το διάγραμμα αντανακλά τις ενημερώσεις κατά τις λειτουργίες ανοίγματος/επεξεργασίας. Το API σας επιτρέπει να [specify the external workbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#setExternalWorkbook) και να διαχειριστείτε τα συνδεδεμένα δεδομένα.

**Μπορώ να υπολογίσω και να εμφανίσω γραμμές τάσης χωρίς να υλοποιήσω τη παλινδρόμηση μόνος μου;**

Ναι. Τα [Trendlines](/slides/el/python-java/trend-line/) (γραμμικές, εκθετικές και άλλες) προστίθενται και ενημερώνονται από το Aspose.Slides· οι παράμετροι τους επαναϋπολογίζονται αυτόματα από τα δεδομένα της σειράς, έτσι δεν χρειάζεται να υλοποιήσετε τους δικούς σας υπολογισμούς.

**Αν μια παρουσίαση έχει πολλά διαγράμματα με εξωτερικούς συνδέσμους, μπορώ να ελέγξω ποιο βιβλίο εργασίας χρησιμοποιεί κάθε διάγραμμα για τις υπολογιζόμενες τιμές;**

Ναι. Κάθε διάγραμμα μπορεί να δείχνει στο δικό του [external workbook](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#setExternalWorkbook), ή μπορείτε να δημιουργήσετε/αντικαταστήσετε ένα εξωτερικό βιβλίο εργασίας ανά διάγραμμα ανεξάρτητα από τα άλλα.