---
title: Διαχείριση ετικετών δεδομένων διαγράμματος σε παρουσιάσεις χρησιμοποιώντας Python
linktitle: Ετικέτα δεδομένων
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
description: "Μάθετε πώς να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων διαγραμμάτων σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Python μέσω Java για πιο ελκυστικές διαφάνειες."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων εμφανίζουν πληροφορίες σχετικά με τις σειρές του διαγράμματος και μεμονωμένα σημεία δεδομένων, βοηθώντας τους αναγνώστες να αναγνωρίζουν τις τιμές και να κατανοούν το διάγραμμα. Αυτό το άρθρο εξηγεί πώς να μορφοποιείτε τις τιμές, να εμφανίζετε ποσοστά, να διαβάζετε το κείμενο της ετικέτας, να ελέγχετε ετικέτες πέρα από το μέγιστο του άξονα, να ρυθμίζετε το διάστιχο ετικετών του άξονα κατηγορίας και να τοποθετείτε ετικέτες σε διάγραμμα πίτας.

## **Count Visible Data Labels**

Χρησιμοποιήστε [getCountOfVisibleDataLabels](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCountOfVisibleDataLabels) για να ελέγξετε πόσες ετικέτες δεδομένων είναι ενεργοποιημένες για εμφάνιση πριν από τη δημοσίευση μιας παρουσίασης. Σε αντίθεση με το [getCount](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCount), το οποίο επιστρέφει το συνολικό αριθμό ετικετών στη συλλογή, λαμβάνει υπόψη τις προεπιλογές της σειράς και τις ατομικές ρυθμίσεις ετικέτας.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα στήλης με μία σειρά και τρία σημεία δεδομένων. Πρόσβαση στη συλλογή ετικετών της σειράς μέσω του [getLabels](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getLabels) και εκτυπώνει τον ορατό αριθμό καθώς αλλάζουν οι ρυθμίσεις: **0, 3, 2, 3**. Ο συνολικός αριθμός παραμένει **3**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    series_cell = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    for i in range(3):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JDouble((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    labels = series.getLabels()
    print(f"Total: {labels.getCount()}; visible: {labels.getCountOfVisibleDataLabels()}")  # Σumoλο: 3; ορατό: 0

    labels.getDefaultDataLabelFormat().setShowValue(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # Ορατό: 3

    labels.get_Item(1).getDataLabelFormat().setShowValue(False)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # Ορατό: 2

    labels.get_Item(1).getDataLabelFormat().setShowLegendKey(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # Ορατό: 3
finally:
    presentation.dispose()
```

Η μέθοδος [getDefaultDataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getDefaultDataLabelFormat) της σειράς παρέχει τις προεπιλεγμένες ρυθμίσεις. Περάστ `True` στη [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) εκεί εμφανίζει τιμές για όλες τις τρεις ετικέτες. Περάστ `False` μέσω του [getDataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getDataLabelFormat) μιας ετικέτας παρακάμπτει αυτή τη ρύθμιση για την επιλεγμένη ετικέτα. Περάστ `True` στη [setShowLegendKey](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLegendKey) κάνει ξανά την ετικέτα ορατή, ακόμη και αν η τιμή της παραμένει κρυφή.

Ο ορατός αριθμός αντανακλά τις ρυθμίσεις ορατότητας. Δεν μετράει εάν οι ετικέτες επικάθονται, αποκόπτονται ή είναι αναγνώσιμες στο αποδιδόμενο διάγραμμα.

## **Set Data Precision in Chart Data Labels**

Χρησιμοποιήστε [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) για να μορφοποιήσετε τις τιμές της σειράς. Αυτό το παράδειγμα δημιουργεί ένα γράφημα γραμμής με προεπιλεγμένα δεδομένα, εμφανίζει τον πίνακα δεδομένων του και ενεργοποιεί ετικέτες τιμών για την πρώτη σειρά. Η μορφή `#,##0.00` εμφανίζει διαχωριστικό χιλιάδων και δύο δεκαδικά ψηφία χωρίς να αλλάζει τις υποκείμενες τιμές.

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

Για να μορφοποιήσετε τα αριθμητικά κελιά σε ενσωματωμένο βιβλίο εργασίας του διαγράμματος, δείτε [Set Custom Number Formats for Workbook Cells](/slides/el/python-java/chart-workbook/#set-custom-number-formats-for-workbook-cells). Το παράδειγμα αυτό δείχνει επίσης ετικέτες τιμών που ακολουθούν τις μορφές των πηγαίων κελιών διατηρώντας τις αποθηκευμένες αριθμητικές τιμές.

## **Display Percentage as Labels**

Για ένα στοίβαγμα στήλης, υπολογίστε κάθε τιμή ως ποσοστό του συνολικού της κατηγορίας και αντιστοιχίστε το κείμενο στο πλαίσιο κειμένου που επιστρέφει η [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Αυτό το παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα διαγράμματος και εμφανίζει ποσοστά με δύο δεκαδικά ψηφία σε γραμματοσειρά των 8 σημείων. Κατηγορίες με σύνολο μηδέν παραλείπονται για να αποφευχθεί διαίρεση με το μηδέν. Επαναυπολογίστε το προσαρμοσμένο κείμενο ετικέτας αν τα δεδομένα του διαγράμματος αλλάξουν.

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

## **Set Percentage Sign with Chart Data Labels**

Όταν οι τιμές αποθηκεύονται ως κλάσματα, χρησιμοποιήστε [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) για να εμφανίσετε ποσοστά. Περάστε `False` στη [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) για να εφαρμόσετε τη μορφή ετικέτας ανεξάρτητα από τα πηγαία κελιά.

Αυτό το παράδειγμα δημιουργεί ένα 100 % στοίβαγμα στήλης με κόκκινη και μπλε σειρά σε τέσσερις κατηγορίες. Κάθε ζεύγος τιμών αθροίζει στο 1. Η μορφή ετικέτας `0.0%` εμφανίζει το 0.30 ως 30,0 %, ενώ ο κατακόρυφος άξονας χρησιμοποιεί δύο δεκαδικά ψηφία. Και οι δύο σειρές χρησιμοποιούν λευκό κείμενο ετικέτας 10 σημείων.

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

## **Read the Actual Text of Data Labels**

Χρησιμοποιήστε [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) για να ανακτήσετε το κείμενο που παράγεται από τις ρυθμίσεις μιας ετικέτας δεδομένων. Αυτό είναι χρήσιμο κατά την εξαγωγή ετικετών για αναφορές, την αναζήτηση περιεχομένου παρουσίασης ή την επικύρωση παραγόμενων διαγραμμάτων. Στο παρακάτω παράδειγμα, η προεπιλεγμένη [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) συνδυάζει το όνομα κάθε κατηγορίας, το όνομα σειράς και την τιμή. Ένα σημείο μορφοποιεί την τιμή του ως ποσοστό, ενώ ένα άλλο χρησιμοποιεί προσαρμοσμένο κείμενο από τη [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Ο αριθμός που αποθηκεύεται σε σημείο δεδομένων παραμένει `0.75`, ακόμα κι όταν η ετικέτα του δείχνει `75%` μαζί με τα ονόματα κατηγορίας και σειράς. Το προσαρμοσμένο κείμενο αντικαθιστά το δημιουργημένο κείμενο ετικέτας. Η [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) επιστρέφει το τελικό κείμενο ετικέτας σε κάθε περίπτωση. Ελέγξτε ξεχωριστά το [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible), όπως φαίνεται παραπάνω, όταν θέλετε να εξάγετε μόνο τις ορατές ετικέτες.

## **Control Data Labels Beyond the Axis Maximum**

Όταν περιορίζετε το εύρος ενός άξονα χειροκίνητα, ορισμένα σημεία δεδομένων ενδέχεται να υπερβούν το μέγιστο του. Χρησιμοποιήστε [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) για να ελέγξετε εάν οι ετικέτες τους θα εμφανίζονται. Αυτή η ρύθμιση αλλάζει την ορατότητα των ετικετών· δεν αλλάζει το εύρος του άξονα ούτε τις υποκείμενες τιμές των δεδομένων.

Το παρακάτω παράδειγμα δημιουργεί ένα 2Δ ομαδοποιημένο γράφημα στήλης με τιμές 60 και 120. Ορίζει `False` στη [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) και θέτει το μέγιστο σε 100 με τη [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) στον κατακόρυφο άξονα. Η πρώτη διαφάνεια επιτρέπει ετικέτες πέρα από το μέγιστο· ένα αντίγραφο της διαφάνειας τις απενεργοποιεί. Και οι δύο διαφάνειες αποθηκεύονται στο `DataLabelsOverMaximum.pptx`.

Ενεργοποιήστε ετικέτες τιμών με τη [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Η ρύθμιση σε επίπεδο διαγράμματος δεν ενεργοποιεί την εμφάνιση τιμών από μόνη της ούτε παρακάμπτει την απενεργοποίηση εμφάνισης τιμής μιας ατομικής ετικέτας. Αυτό το παράδειγμα ενεργοποιεί τις τιμές για όλη τη σειρά και χρησιμοποιεί τη [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) για να τοποθετήσει τις ετικέτες στο εξωτερικό άκρο κάθε στήλης.

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
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}

Αυτό το παράδειγμα χρησιμοποιεί ένα 2Δ γράφημα στήλης με άξονα τιμών. Διαγράμματα χωρίς άξονα τιμών, όπως τα διαγράμματα πίτας και δαχτυλίνου, δεν έχουν μέγιστο άξονα που να μπορεί να περιοριστεί με αυτόν τον τρόπο.

{{% /alert %}}

## **Set Label Distance from an Axis**

Χρησιμοποιήστε τη [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) για να ελέγξετε την απόσταση μεταξύ των ετικετών του άξονα κατηγορίας και του άξονα. Η τιμή εκφράζεται ως ποσοστό του μέγιστου μεγέθους γραμματοσειράς των ετικετών του άξονα. Αυτό το παράδειγμα δημιουργεί ένα ομαδοποιημένο γράφημα στήλης και ορίζει την απόσταση ετικετών του οριζόντιου άξονα σε 500. Η ρύθμιση αυτή επηρεάζει τις ετικέτες του άξονα κατηγορίας αντί των ετικετών που συνδέονται με μεμονωμένα σημεία δεδομένων.

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

## **Adjust Label Location**

Σε ένα γράφημα πίτας, προσαρμόστε τις θέσεις των ετικετών δεδομένων για να βελτιώσετε το διάστιχο και να δημιουργήσετε χώρο για τις γραμμές οδηγού.

Αυτό το παράδειγμα εμφανίζει την τιμή του πρώτου σημείου δεδομένων, τοποθετεί την ετικέτα του έξω από το τμήμα και προσαρμόζει τις οριζόντιες και κατακόρυφες μετατοπίσεις του χρησιμοποιώντας τις [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) και [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). Οι μετατοπίσεις είναι σχετικές με το πλάτος και το ύψος του διαγράμματος αντίστοιχα.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Format Leader Lines**

Όταν οι ετικέτες του διαγράμματος πίτας βρίσκονται έξω από τα τμήματα τους, οι γραμμές οδηγού βοηθούν τους αναγνώστες να συνδέσουν κάθε τιμή με το σωστό τμήμα. Ένα έντονο χρώμα και μια ελαφρώς παχύτερη γραμμή μπορούν να κάνουν αυτές τις συνδέσεις πιο ευανάγνωστες, ενώ η διαφάνεια και το διακεκομμένο στυλ κρατούν τις γραμμές λιγότερο ενοχλητικές οπτικά.

Χρησιμοποιήστε τη [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) για να μορφοποιήσετε τις γραμμές οδηγού σε επίπεδο συλλογής ετικετών δεδομένων της σειράς. Οι ρυθμίσεις στο `series.getLabels().getLeaderLinesFormat().getLine()` εφαρμόζονται στη συλλογή, όχι σε ατομική ετικέτα.

Αυτό το παράδειγμα δημιουργεί ένα γράφημα πίτας με προεπιλεγμένα δεδομένα, εμφανίζει τις τιμές έξω από τα τμήματα και ενεργοποιεί το [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines). Μετακινεί δύο ετικέτες πιο μακριά από τα τμήματά τους χρησιμοποιώντας τις [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) και [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) μετατοπίσεις, εκφρασμένες ως κλάσματα του πλάτους και του ύψους του διαγράμματος. Δεν απαιτείται εισερχόμενη παρουσίαση.

Η [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) της γραμμής ορίζει ένα συμπαγές μπλε χρώμα με τιμή άλφα 191 από 255, προσδίδοντας περίπου 25 % διαφάνεια. Η [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) ορίζει το πάχος σε 2 σημεία και η [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) κάνει τη γραμμή διακεκομμένη.

```python
import jpype
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # Μετακινήστε δύο ετικέτες πιο μακριά από τα τμήματά τους.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η ενεργοποίηση των γραμμών οδηγού δεν εγγυάται ότι θα εμφανιστεί γραμμή για κάθε ετικέτα. Η ορατότητα εξαρτάται από τη θέση της ετικέτας και τη συμπεριφορά διάταξης του διαγράμματος. Στο παράδειγμα αυτό, οι δύο μετατοπισμένες ετικέτες έχουν ορατές γραμμές οδηγού· οι ετικέτες που παραμένουν κοντά στα τμήματά τους δεν τις χρειάζονται.

Η παρακάτω εικόνα δείχνει το αποθηκευμένο `FormattedLeaderLines.pptx` όπως αποδίδεται από το Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **Add Multiple Rows of Data Labels Above a Column Chart**

Αυτό το παράδειγμα δημιουργεί ένα γράφημα στήλης με δύο σειράς ετικετών δεδομένων πάνω από την περιοχή σχεδίασης. Η Σειρά A εμφανίζει τις ορατές στήλες, ενώ οι Σειρές B και C παρέχουν τις πρόσθετες ετικέτες. Οι στήλες τους είναι κρυμμένες αφαιρώντας το γέμισμα και το περίγραμμα. Η μέθοδος [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) ευθυγραμμίζει και τις τρεις σειρές στα ίδια κέντρα κατηγορίας.

Οι ρυθμίσεις του [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) κρατούν χώρο για τις σειρές ετικετών. Μετά το [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) που υπολογίζει τις προεπιλεγμένες θέσεις, οι μέθοδοι [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) και [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) διατηρούν την οριζόντια στοίχιση και εφαρμόζουν κατακόρυφες μετατοπίσεις για να οργανώσουν τις ετικέτες σε δύο σειρές. Οι αριθμοί παραμένουν ετικέτες δεδομένων συνδεδεμένες με τις τιμές των σειρών· μόνο οι επικεφαλίδες των σειρών είναι ξεχωριστά σχήματα κειμένου.

```python
import jpype
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

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
            # Απόκρυψη των στηλών B και C, αλλά διατήρηση των ετικετών δεδομένων.
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

    # Χρήση λιγότερων γραμμών πλέγματος για αυτό το συμπαγές παράδειγμα.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Δέσμευση χώρου πάνω από το γράφημα για δύο σειρές ετικετών δεδομένων.
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
            # Διατήρηση της προεπιλεγμένης οριζόντιας θέσης. Το Y είναι μια μετατόπιση από
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

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **FAQ**

**Πώς μπορώ να αποτρέψω την επικάλυψη ετικετών δεδομένων σε πυκνά διαγράμματα;**

Συνδυάστε αυτόματη τοποθέτηση ετικετών, γραμμές οδηγού και μείωση μεγέθους γραμματοσειράς· εάν χρειαστεί, αποκρύψτε κάποια πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραίες ή κεντρικές τιμές.

**Πώς μπορώ να απενεργοποιήσω ετικέτες μόνο για τιμές μηδέν, αρνητικές ή κενές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές ή ελλιπείς σύμφωνα με έναν καθορισμένο κανόνα.

**Πώς μπορώ να εξασφαλίσω συνεπή στυλ ετικετών κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά την οικογένεια γραμματοσειράς και το μέγεθος και βεβαιωθείτε ότι η γραμματοσειρά είναι διαθέσιμη στο περιβάλλον απόδοσης για να αποφύγετε εναλλακτικές.