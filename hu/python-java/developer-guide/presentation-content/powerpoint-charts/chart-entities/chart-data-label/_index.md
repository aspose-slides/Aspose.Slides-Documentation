---
title: Diagram adatcímkék kezelése prezentációkban Python használatával
linktitle: Adatcímke
type: docs
url: /hu/python-java/chart-data-label/
keywords:
- diagram
- adatcímke
- adatpont pontosság
- százalék
- címke távolság
- címke helye
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá és formázhat diagram adatcímkéket PowerPoint prezentációkban az Aspose.Slides for Python via Java segítségével, hogy vonzóbb diák legyenek."
---
## **Bevezetés**

Az adatcímkék információt jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk bemutatja, hogyan formázzuk az értékeket, jelenítsünk meg százalékokat, olvassuk a címkeszöveget, kezeljük a címkéket a tengely maximumán túl, állítsuk be a kategória tengely címkéinek távolságát, és helyezzük el a kördiagram címkéit.

## **Adatpontosság beállítása a diagram adatcímkéiben**

Használja a [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) módszert a sorozatértékek formázásához. Ez a példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, megjeleníti annak adat táblázatát, és engedélyezi az értékcímkéket az első sorozathoz. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a mögöttes értékeket.

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

## **Százalék megjelenítése címkeként**

Halmozott oszlopdiagram esetén számolja ki minden értéket a kategória összes értékének százalékaként, és rendelje a szöveget a [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) által visszaadott szövegkerethez. Ez a példa az alapértelmezett diagramadatokat használja, és a százalékokat két tizedesjeggyel, 8 pontos betűmérettel jeleníti meg. A nulla összegű kategóriákat kihagyja, hogy elkerülje a nullával osztást. Ha a diagram adatai megváltoznak, számolja újra az egyéni címkeszöveget.

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

## **Százalékjel beállítása a diagram adatcímkéknél**

Ha az értékek törtként vannak tárolva, használja a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) módszert a százalékok megjelenítéséhez. Adja át a `False` értéket a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) metódusnak, hogy a címke formátuma független legyen a forráscelláktól.

Ez a példa egy 100 %-os halmozott oszlopdiagramot hoz létre piros és kék sorozattal négy kategóriában. Minden értékpár összege 1. A `0.0%` címkeformátum a 0.30‑at 30.0 %-ként jeleníti meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget használ.

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

## **Az adatcímkék tényleges szövegének kiolvasása**

Használja a [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) módszert a címke beállításai által előállított szöveg lekéréséhez. Ez hasznos jelentésekhez való címkék kinyerésekor, a prezentáció tartalmának keresésekor vagy a generált diagramok ellenőrzésekor. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) egyesíti minden kategória nevét, sorozat nevét és értékét. Az egyik pont értékét százalékosan formázza, a másik egyedi szöveget használ a [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) segítségével.

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

A data pontban tárolt szám továbbra is `0.75`, még akkor is, ha a címkéje `75%`‑et mutat a kategória- és sorozatnevekkel együtt. Az egyedi szöveg felülírja a generált címkeszöveget. A [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) mindkét esetben visszaadja a kapott címkesztringet. Ellenőrizze külön a [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) állapotot, ahogyan fent látható, ha csak a látható címkéket kívánja kinyerni.

## **Adatcímkék kezelése a tengely maximumán túl**

Ha egy tengely tartományát kézzel korlátozza, egyes adatpontok meghaladhatják a maximumot. Használja a [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) módszert annak szabályozására, hogy ezek a címkék megjelenjenek-e. Ez a beállítás csak a címke láthatóságát változtatja, nem módosítja a tengely tartományát vagy a mögöttes adatértékeket.

Az alábbi példa egy 2D csoportosított oszlopdiagramot hoz létre 60 és 120 értékekkel. `False`‑t ad át a [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) metódusnak, majd a függőleges tengelyen a [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) segítségével 100‑ra állítja a maximumot. Az első dia megengedi a címkék megjelenítését a maximumon túl, egy másolat pedig letiltja őket. Mindkét dia a `DataLabelsOverMaximum.pptx` fájlban van mentve.

Az értékcímkék engedélyezéséhez használja a [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) metódust. A diagramra vonatkozó beállítás egyedül nem jeleníti meg az értékek megjelenítését, és nem írja felül egy adott címke letiltott értékmegjelenítését sem. Ez a példa minden sorozatra engedélyezi az értékek megjelenítését, és a [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) segítségével a címkéket az oszlopok külső végére helyezi.

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

Az alábbi képek a Microsoft PowerPoint által renderelt mentett diákot mutatják. `True` esetén a **120** címke látható a felső határnál; `False` esetén rejtve van. A **60** címke továbbra is látható, a tengely maximuma **100** marad, és a második adatpont mindkét esetben **120**.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ez a példa egy 2D oszlopdiagramot használ érték tengellyel. Az érték tengely nélküli diagramok, például a kör- és fánkdiagramok, nem rendelkeznek tengelymaximumszabállyal, amelyet ilyen módon korlátozhatnánk.
{{% /alert %}}

## **Címke távolságának beállítása a tengelytől**

Használja a [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) módszert a kategória tengely címkéi és a tengely közti távolság szabályozásához. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500‑ra állítja. Ez a beállítás a kategória tengely címkéire vonatkozik, nem pedig az egyes adatpontokhoz kapcsolt címkékre.

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

## **Címke helyének módosítása**

Kördiagram esetén állítsa be az adatcímkék pozícióját a távolság javítása és a vezető vonalak számára hely biztosítása érdekében.

Ez a példa az első adatpont értékét jeleníti meg, a címkét a szelet kívülre helyezi, és a [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) és [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) segítségével állítja be a vízszintes és függőleges eltolásokat. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva vannak.

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

![Kördiagram a módosított adatcímkével](pie-chart-adjusted-label.png)

## **Több sor adatcímke hozzáadása oszlopdiagram fölé**

Ez a példa egy oszlopdiagramot hoz létre két sor adatcímkével a rajzterület felett. Az A sorozat a látható oszlopokat jeleníti meg, míg a B és C sorozatok a kiegészítő címkéket biztosítják. Az oszlopaikat úgy rejtik el, hogy eltávolítják a kitöltést és a körvonalat. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) metódus az összes három sorozatot azonos kategória középpontokhoz igazítja.

A [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) beállításai helyet tartanak a címkesorok számára. A [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) az alapértelmezett pozíciókat kiszámítva, a [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) és [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) megőrzik a vízszintes igazítást és függőleges eltolásokat alkalmaznak a címkék két sorba rendezéséhez. A számok továbbra is a sorozatértékekhez kapcsolódó adatcímkék maradnak; csak a sorfejlécek külön szöveg alakzatok.

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
            # Rejtsd el a B és C oszlopokat, de tartsd meg az adatcímkéiket.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Igazítsd a három sorozatot ugyanazon kategóriaközéppontokhoz.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Kevesebb rácsvonalat használj ebben a kompakt példában.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Foglalj helyet a grafikon felett két sor adatcímkének.
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
            # Tartsd meg az alapértelmezett vízszintes pozíciót. Y egy eltolás a
            # alapértelmezett címkepozíciótól, a diagrammagasság hányadában kifejezve.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Csak a sorfejléc egy külön szöveg alakzet.
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

![Oszlopdiagram két sor adatcímkével a rajzterület felett](multiple-rows-of-labels.png)

## **GYIK**

**Hogyan akadályozhatom meg az adatcímkék átfedését sűrű diagramoknál?**  
Kombináljon automatikus címkelépítést, vezető vonalakat és kisebb betűméretet; szükség esetén rejtse el egyes mezőket (például a kategóriát), vagy csak a szélső értékek vagy kulcspontok esetén jelenítsen meg címkéket.

**Hogyan tilthatom le a címkéket csak nullára, negatív vagy üres értékek esetén?**  
Szűrje le az adatpontokat a címkék engedélyezése előtt, és a szabály szerint kapcsolja ki a megjelenítést a 0‑ás, negatív vagy hiányzó értékeknél.

**Hogyan biztosíthatom a konzisztens címkestílust PDF/képek exportálásakor?**  
Határozza meg expliciten a betűcsaládot és méretet, és ellenőrizze, hogy a betűtípus elérhető legyen a renderelő környezetben, hogy elkerülje a helyettesítést.