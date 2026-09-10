---
title: "Felhívások kezelése a prezentáció diagramjaiban Python használatával"
linktitle: "Felhívás"
type: docs
url: /hu/python-java/callout/
keywords:
- diagram felhívás
- felhívás használata
- adatcímke
- címkeformátum
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Hozzon létre és formázzon felhívásokat az Aspose.Slides for Python via Java-ban, rövid kódrészletekkel, PPT és PPTX kompatibilitással a prezentációs munkafolyamatok automatizálásához."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet használni a felhívásokat a diagram adatcímkéknél az Aspose.Slides-ban. Bemutatja, hogyan kell használni a [setShowLabelAsDataCallout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) módszert a címkék felhívásként történő megjelenítéséhez, hogyan kell beállítani a felhívásra vonatkozó címke‑beállításokat egy gyűrűdiagramhoz, és megjegyzi, hogy a felhívások és megjelenésük megmarad, amikor a bemutatókat PDF, HTML5, SVG és raszteres képformátumokra exportálják.

## **Felhívások használata**

A [DataLabelFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabelformat/) osztály [getShowLabelAsDataCallout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) és [setShowLabelAsDataCallout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) módszerei határozzák meg, hogy a diagram adatcímkéje felhívásként vagy szabályos adatcímkéként jelenik‑e meg.

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

## **Felhívás beállítása gyűrűdiagramhoz**

Az Aspose.Slides for Python via Java támogatja a sorozat adatcímke felhívás alakjának beállítását egy gyűrűdiagramhoz. Az alábbi példa ezt demonstrálja.

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

## **GYIK**

**Megmaradnak a felhívások, ha a bemutatót PDF‑re, HTML5‑re, SVG‑re vagy képekre konvertálják?**

Igen. A felhívások a diagram megjelenítésének részét képezik, ezért amikor exportál a [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/hu/python-java/export-to-html5/), [SVG](/slides/hu/python-java/render-a-slide-as-an-svg-image/) vagy [raszteres képek](/slides/hu/python-java/convert-powerpoint-to-png/) formátumba, megmaradnak a dia formázásával együtt.

**Működnek‑e az egyedi betűtípusok a felhívásokban, és megőrizhető‑e a megjelenésük exportáláskor?**

Igen. Az Aspose.Slides támogatja a [betűtípusok beágyazását](/slides/hu/python-java/embedded-font/) a prezentációba, és kezeli a betűtípus beágyazását az olyan exportok során, mint a [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/), biztosítva, hogy a felhívások minden rendszerben ugyanúgy nézzenek ki.