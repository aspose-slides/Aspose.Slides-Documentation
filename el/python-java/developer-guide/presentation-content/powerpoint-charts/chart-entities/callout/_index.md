---
title: Διαχείριση Υποσημειώσεων σε Διαγράμματα Παρουσίασης με Python
linktitle: Υποσημείωση
type: docs
url: /el/python-java/callout/
keywords:
- υποσημείωση διαγράμματος
- χρήση υποσημείωσης
- ετικέτα δεδομένων
- μορφή ετικέτας
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε και μορφοποιήστε υποσημειώσεις στο Aspose.Slides για Python μέσω Java με σύντομες παραδείγματα κώδικα, συμβατά με PPT και PPTX για την αυτοματοποίηση των ροών εργασίας παρουσίασης."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εργάζεστε με υποσημειώσεις για τις ετικέτες δεδομένων διαγράμματος στο Aspose.Slides. Δείχνει πώς να χρησιμοποιήσετε τη μέθοδο [setShowLabelAsDataCallout](https://reference.aspose.com/slides/el/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) για να εμφανίσετε ετικέτες ως υποσημειώσεις, πώς να διαμορφώσετε τις ρυθμίσεις ετικετών σχετικές με τις υποσημειώσεις για ένα διάγραμμα δακτυλίου, και σημειώνει ότι οι υποσημειώσεις και η εμφάνισή τους διατηρούνται όταν οι παρουσιάσεις εξάγονται σε PDF, HTML5, SVG και μορφές ραστερ εικόνων.

## **Χρήση Υποσημειώσεων**

Οι μέθοδοι [getShowLabelAsDataCallout](https://reference.aspose.com/slides/el/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) και [setShowLabelAsDataCallout](https://reference.aspose.com/slides/el/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) της κλάσης [DataLabelFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/datalabelformat/) καθορίζουν εάν μια ετικέτα δεδομένων διαγράμματος εμφανίζεται ως υποσημείωση ή ως κανονική ετικέτα δεδομένων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400)
    labels = chart.getChartData().getSeries().get_Item(0).getLabels()
    default_label_format = labels.getDefaultDataLabelFormat()
    default_label_format.setShowValue(True)
    default_label_format.setShowLabelAsDataCallout(True)
    labels.get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(False)

    presentation.save("DisplayCharts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Υποσημείωσης για Διάγραμμα Δακτυλίου**

Το Aspose.Slides for Python μέσω Java υποστηρίζει τον ορισμό του σχήματος υποσημείωσης ετικέτας δεδομένων σειράς για ένα διάγραμμα δακτυλίου. Το παρακάτω παράδειγμα το αποδεικνύει.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat, TextAutofitType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, False)
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(False)

    for series_index in range(15):
        series_cell = workbook.getCell(0, 0, series_index + 1, f"SERIES {series_index}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        series.setExplosion(0)
        series.getParentSeriesGroup().setDoughnutHoleSize(jpype.JByte(20))
        series.getParentSeriesGroup().setFirstSliceAngle(351)

    for category_index in range(15):
        category_cell = workbook.getCell(0, category_index + 1, 0, f"CATEGORY {category_index}")
        chart.getChartData().getCategories().add(category_cell)
        for i in range(chart.getChartData().getSeries().size()):
            series = chart.getChartData().getSeries().get_Item(i)
            data_cell = workbook.getCell(0, category_index + 1, i + 1, jpype.JInt(1))
            data_point = series.getDataPoints().addDataPointForDoughnutSeries(data_cell)
            data_point.getFormat().getFill().setFillType(FillType.Solid)
            line_format = data_point.getFormat().getLine()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)
            line_format.setWidth(1)
            line_format.setStyle(LineStyle.Single)
            line_format.setDashStyle(LineDashStyle.Solid)
            if i == chart.getChartData().getSeries().size() - 1:
                label = data_point.getLabel()
                label.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape)
                label_format = label.getDataLabelFormat()
                portion_format = label_format.getTextFormat().getPortionFormat()
                portion_format.setFontBold(NullableBool.True_)
                font = FontData("DINPro-Bold")
                portion_format.setLatinFont(font)
                portion_format.setFontHeight(12)
                portion_format.getFillFormat().setFillType(FillType.Solid)
                portion_format.getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)
                label_format.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.WHITE)
                label_format.setShowValue(False)
                label_format.setShowCategoryName(True)
                label_format.setShowSeriesName(False)
                label_format.setShowLeaderLines(True)
                label_format.setShowLabelAsDataCallout(False)
                chart.validateChartLayout()
                label.setX(label.getX() + 0.5)
                label.setY(label.getY() + 0.5)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι υποσημειώσεις κατά τη μετατροπή μιας παρουσίασης σε PDF, HTML5, SVG ή εικόνες;**

Ναι. Οι υποσημειώσεις είναι μέρος της απόδοσης του διαγράμματος, έτσι όταν εξάγετε σε [PDF](/slides/el/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/el/python-java/export-to-html5/), [SVG](/slides/el/python-java/render-a-slide-as-an-svg-image/), ή [raster images](/slides/el/python-java/convert-powerpoint-to-png/), διατηρούνται μαζί με τη μορφοποίηση της διαφάνειας.

**Λειτουργούν προσαρμοσμένες γραμματοσειρές στις υποσημειώσεις και μπορεί να διατηρηθεί η εμφάνισή τους κατά την εξαγωγή;**

Ναι. Το Aspose.Slides υποστηρίζει την [ενσωμάτωση γραμματοσειρών](/slides/el/python-java/embedded-font/) στην παρουσίαση και ελέγχει την ενσωμάτωση γραμματοσειρών κατά τις εξαγωγές όπως το [PDF](/slides/el/python-java/convert-powerpoint-to-pdf/), εξασφαλίζοντας ότι οι υποσημειώσεις φαίνονται ίδιες σε διαφορετικά συστήματα.