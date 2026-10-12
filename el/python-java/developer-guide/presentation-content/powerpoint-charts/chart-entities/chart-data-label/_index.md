---
title: Διαχείριση ετικετών δεδομένων διαγράμματος σε παρουσιάσεις χρησιμοποιώντας Python
linktitle: Ετικέτα Δεδομένων
type: docs
url: /el/python-java/chart-data-label/
keywords:
- διάγραμμα
- ετικέτα δεδομένων
- ακρίβεια δεδομένων
- ποσοστό
- απόσταση ετικέτας
- θέση ετικέτας
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Python μέσω Java για πιο ελκυστικές διαφάνειες."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων εμφανίζουν πληροφορίες σχετικά με τις σειρές διαγραμμάτων και τα μεμονωμένα σημεία δεδομένων, βοηθώντας τους αναγνώστες να αναγνωρίσουν τις τιμές και να κατανοήσουν το διάγραμμα. Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε τις τιμές, να εμφανίσετε ποσοστά, να διαβάσετε το κείμενο ετικετών, να ελέγξετε ετικέτες πέρα από το μέγιστο του άξονα, να προσαρμόσετε το διάστημα των ετικετών του άξονα κατηγορίας και να τοποθετήσετε ετικέτες διαγράμματος πίτας.

## **Ορισμός ακρίβειας δεδομένων στις ετικέτες δεδομένων διαγράμματος**

Χρησιμοποιήστε [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) για να μορφοποιήσετε τις τιμές των σειρών. Αυτό το παράδειγμα δημιουργεί ένα διαγράμματος γραμμής με προεπιλεγμένα δεδομένα, εμφανίζει τον πίνακα δεδομένων του και ενεργοποιεί τις ετικέτες τιμών για την πρώτη σειρά. Η μορφή `#,##0.00` εμφανίζει διαχωριστικό χιλιάδων και δύο δεκαδικά ψηφία χωρίς να αλλάζει τις υποκείμενες τιμές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Εμφάνιση ποσοστού ως ετικέτες**

Για ένα στοιβαγμένο διάγραμμα στήλης, υπολογίστε κάθε τιμή ως ποσοστό του συνολικού της κατηγορίας και αντιστοιχίστε το κείμενο στο πλαίσιο κειμένου που επιστρέφεται από [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Αυτό το παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα διαγράμματος και εμφανίζει ποσοστά με δύο δεκαδικά ψηφία σε γραμματοσειρά 8 σημείων. Οι κατηγορίες με σύνολο μηδέν παραλείπονται για να αποφευχθεί η διαίρεση δια του μηδενός. Επαναϋπολογίστε το προσαρμοσμένο κείμενο ετικέτας εάν τα δεδομένα του διαγράμματος αλλάξουν.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός συμβόλου ποσοστού με ετικέτες δεδομένων διαγράμματος**

Όταν οι τιμές αποθηκεύονται ως κλάσματα, χρησιμοποιήστε [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) για να εμφανίσετε ποσοστά. Περάστε `False` στο [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) για να εφαρμόσετε τη μορφοποίηση ετικέτας ανεξάρτητα από τα κελιά προέλευσης.

Αυτό το παράδειγμα δημιουργεί ένα στοίβαγμα 100% στήλης με κόκκινη και μπλε σειρά σε τέσσερις κατηγορίες. Κάθε ζεύγος τιμών αθροίζεται σε 1. Η μορφή ετικέτας `0.0%` εμφανίζει το 0.30 ως 30.0%, ενώ ο κατακόρυφος άξονας χρησιμοποιεί δύο δεκαδικά ψηφία. Και οι δύο σειρές χρησιμοποιούν λευκό κείμενο ετικέτας 10 σημείων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ανάγνωση του πραγματικού κειμένου των ετικετών δεδομένων**

Χρησιμοποιήστε [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) για να λάβετε το κείμενο που παράγεται από τις ρυθμίσεις μιας ετικέτας δεδομένων. Αυτό είναι χρήσιμο όταν εξάγετε ετικέτες για αναφορές, αναζητάτε περιεχόμενο παρουσίασης ή ελέγχετε τα παραγόμενα διαγράμματα. Στο παρακάτω παράδειγμα, η προεπιλεγμένη [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) συνδυάζει το όνομα κάθε κατηγορίας, το όνομα σειράς και την τιμή. Ένα σημείο μορφοποιεί την τιμή του ως ποσοστό, και ένα άλλο χρησιμοποιεί προσαρμοσμένο κείμενο από το [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

Ο αριθμός που αποθηκεύεται σε ένα σημείο δεδομένων παραμένει `0.75`, ακόμη και όταν η ετικέτα του εμφανίζει `75%` μαζί με τα ονόματα κατηγορίας και σειράς. Το προσαρμοσμένο κείμενο αντικαθιστά το παραγόμενο κείμενο ετικέτας. Το [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) επιστρέφει τη δημιουργημένη συμβολοσειρά ετικέτας και στις δύο περιπτώσεις. Ελέγξτε τη [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) ξεχωριστά, όπως φαίνεται παραπάνω, όταν θέλετε να εξάγετε μόνο τις ορατές ετικέτες.

## **Έλεγχος ετικετών δεδομένων πέρα από το μέγιστο του άξονα**

Όταν περιορίζετε το εύρος ενός άξονα χειροκίνητα, ορισμένα σημεία δεδομένων μπορεί να υπερβούν το μέγιστο. Χρησιμοποιήστε [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) για να ελέγξετε αν εμφανίζονται οι ετικέτες δεδομένων τους. Αυτή η ρύθμιση αλλάζει την ορατότητα των ετικετών· δεν αλλάζει το εύρος του άξονα ούτε τις υποκείμενες τιμές δεδομένων.

Το παρακάτω παράδειγμα δημιουργεί ένα 2D σύμπλεγμα διαγράμματος στήλης με τιμές 60 και 120. Περάζει `False` στο [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) και θέτει το μέγιστο σε 100 με το [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) στον κατακόρυφο άξονα. Η πρώτη διαφάνεια επιτρέπει ετικέτες πέρα από το μέγιστο· ένα αντίγραφο αυτής της διαφάνειας τις απενεργοποιεί. Και οι δύο διαφάνειες αποθηκεύονται στο `DataLabelsOverMaximum.pptx`.

Ενεργοποιήστε τις ετικέτες τιμών με το [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Η ρύθμιση σε επίπεδο διαγράμματος δεν ενεργοποιεί την εμφάνιση τιμών από μόνη της ούτε παρακάμπτει την απενεργοποίηση εμφάνισης τιμών μιας μεμονωμένης ετικέτας. Αυτό το παράδειγμα ενεργοποιεί τις τιμές για ολόκληρη τη σειρά και χρησιμοποιεί το [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) για να τοποθετήσει τις ετικέτες στο εξωτερικό άκρο κάθε στήλης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Οι παρακάτω εικόνες δείχνουν τις αποθηκευμένες διαφάνειες όπως αποδίδονται από το Microsoft PowerPoint. Με `True`, η ετικέτα **120** είναι ορατή στο άνω όριο· με `False`, είναι κρυφή. Η ετικέτα **60** παραμένει ορατή, το μέγιστο του άξονα παραμένει **100**, και το δεύτερο σημείο δεδομένων παραμένει **120** και στις δύο περιπτώσεις.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![Διάγραμμα PowerPoint που εμφανίζει την ετικέτα τιμής 120 με μέγιστο άξονα 100](data-labels-over-maximum-true.png) | ![Διάγραμμα PowerPoint που κρύβει την ετικέτα τιμής 120 με μέγιστο άξονα 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Τύπος Διαγράμματος" %}}
Αυτό το παράδειγμα χρησιμοποιεί ένα 2D διάγραμμα στήλης με άξονα τιμών. Διαγράμματα χωρίς άξονα τιμών, όπως τα διαγράμματα πίτας και δαχτυλιδιού, δεν έχουν μέγιστο άξονα που να μπορεί να περιοριστεί με αυτόν τον τρόπο.
{{% /alert %}}

## **Ορισμός απόστασης ετικέτας από άξονα**

Χρησιμοποιήστε [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) για να ελέγξετε την απόσταση μεταξύ των ετικετών του άξονα κατηγορίας και του άξονα. Η τιμή είναι ποσοστό του μέγιστου μεγέθους γραμματοσειράς των ετικετών άξονα. Αυτό το παράδειγμα δημιουργεί ένα σύμπλεγμα διαγράμματος στήλης και θέτει την οριζόντια μετατόπιση ετικέτας άξονα σε 500. Αυτή η ρύθμιση επηρεάζει τις ετικέτες του άξονα κατηγορίας και όχι τις ετικέτες που συνδέονται με μεμονωμένα σημεία δεδομένων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Προσαρμογή θέσης ετικέτας**

Σε διάγραμμα πίτας, προσαρμόστε τις θέσεις των ετικετών δεδομένων για να βελτιώσετε το διάστημα και να δημιουργήσετε χώρο για τις γραμμές οδηγίας.

Αυτό το παράδειγμα εμφανίζει την τιμή του πρώτου σημείου δεδομένων, τοποθετεί την ετικέτα του έξω από το τμήμα και προσαρμόζει τις οριζόντιες και κατακόρυφες μετατοπίσεις χρησιμοποιώντας το [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) και το [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). Αυτές οι μετατοπίσεις είναι σχετικές με το πλάτος και το ύψος του διαγράμματος, αντίστοιχα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Διάγραμμα πίτας με προσαρμοσμένη θέση ετικέτας δεδομένων](pie-chart-adjusted-label.png)

## **Προσθήκη πολλαπλών σειρών ετικετών δεδομένων πάνω από διάγραμμα στήλης**

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα στήλης με δύο σειρές ετικετών δεδομένων πάνω από την περιοχή σχεδίασης. Η Σειρά A εμφανίζει τις ορατές στήλες, ενώ οι Σειρές B και C παρέχουν τις επιπλέον ετικέτες. Οι στήλες τους κρύβονται αφαιρώντας τη γέμιση και το περίγραμμα. Η μέθοδος [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) ευθυγραμμίζει όλες τις τρείς σειρές στο ίδιο κέντρο κατηγορίας.

Οι ρυθμίσεις του [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) διατηρούν χώρο για τις σειρές ετικετών. Μετά τον υπολογισμό των προεπιλεγμένων θέσεων από το [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout), οι μέθοδοι [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) και [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) διατηρούν την οριζόντια στοίχιση και εφαρμόζουν κατακόρυφες μετατοπίσεις για τη διάταξη των ετικετών σε δύο σειρές. Οι αριθμοί παραμένουν ετικέτες δεδομένων συνδεδεμένες με τις τιμές των σειρών· μόνο οι επικεφαλίδες σειρών είναι ξεχωριστά σχήματα κειμένου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # Κρύψτε τις στήλες του B και του C, αλλά διατηρήστε τις ετικέτες δεδομένων τους.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Στοίχιση και των τριών σειρών στα ίδια κέντρα κατηγοριών.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Χρησιμοποιήστε λιγότερες γραμμές πλέγματος για αυτό το συμπαγές παράδειγμα.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Κατανομή χώρου πάνω από το διάγραμμα για δύο σειρές ετικετών δεδομένων.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # Διατηρήστε την προεπιλεγμένη οριζόντια θέση. Το Y είναι μετατόπιση από
            # την προεπιλεγμένη θέση ετικέτας, εκφρασμένη ως κλάσμα του ύψους του διαγράμματος.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Μόνο η επικεφαλίδα της σειράς είναι ξεχωριστό σχήμα κειμένου.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Διάγραμμα στήλης με δύο σειρές ετικετών δεδομένων πάνω από την περιοχή σχεδίασης](multiple-rows-of-labels.png)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να αποτρέψω την επικάλυψη ετικετών δεδομένων σε πυκνά διαγράμματα;**

Συνδυάστε αυτόματη τοποθέτηση ετικετών, γραμμές οδηγίας και μειωμένο μέγεθος γραμματοσειράς· εάν χρειαστεί, κρύψτε ορισμένα πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραίες τιμές ή κρίσιμα σημεία.

**Πώς μπορώ να απενεργοποιήσω τις ετικέτες μόνο για μηδενικές, αρνητικές ή κενές τιμές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές τιμές ή ελλιπείς τιμές σύμφωνα με έναν ορισμένο κανόνα.

**Πώς μπορώ να διασφαλίσω συνεπές στυλ ετικέτας κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά την οικογένεια γραμματοσειράς και το μέγεθος και βεβαιωθείτε ότι η γραμματοσειρά είναι διαθέσιμη στο περιβάλλον απόδοσης για να αποφύγετε εναλλακτικές γραμματοσειρές.