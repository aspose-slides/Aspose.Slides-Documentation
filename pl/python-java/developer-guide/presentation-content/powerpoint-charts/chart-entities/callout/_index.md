---
title: Zarządzanie dymkami w wykresach prezentacji przy użyciu Pythona
linktitle: Dymek
type: docs
url: /pl/python-java/callout/
keywords:
- dymek wykresu
- użycie dymka
- etykieta danych
- format etykiety
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Tworzenie i stylizacja dymków w Aspose.Slides for Python via Java przy użyciu zwięzłych przykładów kodu, kompatybilnych z PPT i PPTX, aby automatyzować przepływy pracy prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z dymkami dla etykiet danych wykresu w Aspose.Slides. Pokazuje, jak używać metody [setShowLabelAsDataCallout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) do wyświetlania etykiet jako dymków, jak skonfigurować ustawienia etykiet związane z dymkami dla wykresu pierścieniowego oraz zauważa, że dymki i ich wygląd są zachowywane podczas eksportu prezentacji do formatów PDF, HTML5, SVG i obrazów rastrowych.

## **Używanie dymków**

Metody [getShowLabelAsDataCallout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) i [setShowLabelAsDataCallout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) klasy [DataLabelFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datalabelformat/) określają, czy etykieta danych wykresu jest wyświetlana jako dymek, czy jako zwykła etykieta danych.

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

## **Ustawianie dymka dla wykresu pierścieniowego**

Aspose.Slides for Python via Java obsługuje ustawianie kształtu dymka etykiety danych serii dla wykresu pierścieniowego. Poniższy przykład to demonstruje.

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

## **FAQ**

**Czy dymki są zachowywane przy konwertowaniu prezentacji do PDF, HTML5, SVG lub obrazów?**

Tak. Dymki są częścią renderowania wykresu, więc przy eksporcie do [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/pl/python-java/export-to-html5/), [SVG](/slides/pl/python-java/render-a-slide-as-an-svg-image/) lub [obrazów rastrowych](/slides/pl/python-java/convert-powerpoint-to-png/), są zachowywane wraz z formatowaniem slajdu.

**Czy niestandardowe czcionki działają w dymkach i czy ich wygląd może być zachowany przy eksporcie?**

Tak. Aspose.Slides obsługuje [osadzanie czcionek](/slides/pl/python-java/embedded-font/) w prezentacji i kontroluje osadzanie czcionek podczas eksportu, takiego jak [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/), zapewniając, że dymki wyglądają tak samo na różnych systemach.