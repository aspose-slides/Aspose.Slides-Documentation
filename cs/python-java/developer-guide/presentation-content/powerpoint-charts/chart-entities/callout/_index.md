---
title: Správa popisků v grafech prezentací pomocí Pythonu
linktitle: Popisek
type: docs
url: /cs/python-java/callout/
keywords:
- popisek grafu
- použití popisku
- datový popisek
- formát popisku
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvářejte a formátujte popisky v Aspose.Slides pro Python via Java pomocí stručných příkladů kódu, kompatibilních s PPT a PPTX, pro automatizaci pracovních postupů prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s popisky (callouts) u datových popisků diagramu v Aspose.Slides. Ukazuje, jak použít metodu [setShowLabelAsDataCallout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) k zobrazení popisků jako popisků s šipkou, jak nastavit související nastavení popisku pro donutový graf a uvádí, že popisky a jejich vzhled jsou zachovány při exportu prezentací do PDF, HTML5, SVG a rastrových formátů obrázků.

## **Používání popisků**

Metody [getShowLabelAsDataCallout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) a [setShowLabelAsDataCallout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) třídy [DataLabelFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabelformat/) určují, zda je datový popisek diagramu zobrazen jako popisek s šipkou nebo jako běžný datový popisek.

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

## **Nastavení popisku pro donutový graf**

Aspose.Slides pro Python via Java podporuje nastavení tvaru popisku řady dat pro donutový graf. Následující příklad to demonstruje.

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

## **Často kladené otázky**

**Jsou popisky zachovány při převodu prezentace do PDF, HTML5, SVG nebo obrázků?**

Ano. Popisky jsou součástí vykreslování diagramu, takže při exportu do [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/cs/python-java/export-to-html5/), [SVG](/slides/cs/python-java/render-a-slide-as-an-svg-image/) nebo [rastrových obrázků](/slides/cs/python-java/convert-powerpoint-to-png/) jsou zachovány spolu s formátováním snímku.

**Fungují v popiscích vlastní písma a lze jejich vzhled zachovat při exportu?**

Ano. Aspose.Slides podporuje [vkládání písem](/slides/cs/python-java/embedded-font/) do prezentace a řídí vkládání písem během exportu, například do [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/), což zajišťuje, že popisky vypadají stejně na různých systémech.