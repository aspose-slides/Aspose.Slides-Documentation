---
title: Diagram adatcímkék kezelése prezentációkban Python használatával
linktitle: Adatcímke
type: docs
url: /hu/python-java/chart-data-label/
keywords:
- diagram
- adatcímke
- adatprecizió
- százalék
- címke távolság
- címke helye
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan adjon hozzá és formázzon diagram adatcímkéket PowerPoint prezentációkban az Aspose.Slides for Python via Java használatával, hogy még figyelemfelkeltőbb diák legyenek."
---
## **Bevezetés**

Az adatcímkék információkat jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk bemutatja, hogyan formázhatók az értékek, hogyan jeleníthetők meg a százalékok, hogyan olvasható a címkeszöveg, hogyan vezérelhetők a címkék a tengely maximumán túli értékek esetén, hogyan állítható be a kategóriatengely címkéinek távolsága, és hogyan helyezhetők el a kördiagram címkék.

## **Adatprecizió beállítása a diagram adatcímkéiben**

Használja a [setNumberFormatOfValues](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) metódust a sorozatértékek formázásához. Ez a példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozathoz. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a mögöttes értékeket.

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

Halmozott oszlopdiagram esetén számítsa ki minden értéket a kategória összegének százalékaként, és rendelje a szöveget a [getTextFrameForOverriding](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) által visszaadott szövegkerethez. Ez a példa az alapértelmezett diagramadatokat használja, és a százalékokat két tizedesjeggyel, 8 pontos betűmérettel jeleníti meg. A nulla összeggel rendelkező kategóriák ki vannak hagyva a nullával való osztás elkerülése érdekében. Számolja újra az egyedi címkeszöveget, ha a diagram adatai megváltoznak.

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

## **Százalékjel beállítása a diagram adatcímkékkel**

Ha az értékek törtként tárolódnak, használja a [setNumberFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabelformat/#setNumberFormat) metódust a százalékok megjelenítéséhez. Adjon át `False` értéket a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) metódusnak, hogy a címkeformátumot a forráscelláktól függetlenül alkalmazza.  
Ez a példa egy 100%-os halmozott oszlopdiagramot hoz létre piros és kék sorozatokkal négy kategóriában. Minden értéspár összege 1. A `0.0%` címkeformátum 0.30-at 30,0%-ként jelenít meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget használ.

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

## **Az adatcímkék tényleges szövegének olvasása**

Használja a [getActualLabelText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabel/#getActualLabelText) metódust az adatcímke beállításai által előállított szöveg lekéréséhez. Ez akkor hasznos, amikor címkéket von ki jelentésekhez, a bemutató tartalmát keresik, vagy a generált diagramokat ellenőrzik. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabelformat/) egyesíti minden kategórianév, sorozatnév és érték. Egy pont az értékét százalékos formátumban jeleníti meg, egy másik a [getTextFrameForOverriding](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) által biztosított egyéni szöveget használja.

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

Az adatpontban tárolt szám továbbra is `0.75` marad, még akkor is, ha a címkéje `75%`-ot mutat a kategória- és sorozatnevekkel együtt. Az egyéni szöveg felülírja a generált címkeszöveget. A [getActualLabelText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabel/#getActualLabelText) minden esetben visszaadja a kapott címke karakterláncot. Ellenőrizze külön a [isVisible](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabel/#isVisible) állapotát, ahogyan fent látható, ha csak a látható címkéket szeretné kinyerni.

## **Adatcímkék kezelése a tengely maximumán túl**

Ha kézzel korlátozza egy tengely tartományát, egyes adatpontok meghaladhatják a maximumot. Használja a [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) metódust annak szabályozására, hogy a címkék megjelenjenek-e. Ez a beállítás a címke láthatóságát változtatja; nem változtatja meg a tengely tartományát vagy a mögöttes adatértékeket.  
Az alábbi példa egy 2D csoportos oszlopdiagramot hoz létre 60 és 120 értékekkel. `False` értéket ad át a [setAutomaticMaxValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/#setAutomaticMaxValue) metódusnak, és a függőleges tengelyen a [setMaxValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/#setMaxValue) segítségével 100-ra állítja a maximumot. Az első dia engedélyezi a maximumot meghaladó címkéket; egy másolat kikapcsolja őket. Mindkét dia `DataLabelsOverMaximum.pptx`‑ben van mentve.  
Az értékcímkéket a [setShowValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabelformat/#setShowValue) metódussal engedélyezheti. A diagram szintű beállítás önmagában nem aktiválja az értékek megjelenítését, és nem írja felül egy adott címke letiltott értékmegjelenítését. Ez a példa a teljes sorozatra engedélyezi az értékeket, és a [setPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabelformat/#setPosition) segítségével a címkéket az oszlopok külső végére helyezi.

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

Az alábbi képek a Microsoft PowerPoint által renderelt mentett diákot mutatják. `True` esetén a **120** címke látható a felső határnál; `False` esetén rejtve van. A **60** címke továbbra is látható, a tengely maximum **100** marad, és a második adatpont mindkét esetben **120**.  

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint diagram, amely a 120 értékcímkét mutatja 100 tengelymaximum mellett](data-labels-over-maximum-true.png) | ![PowerPoint diagram, amely elrejti a 120 értékcímkét 100 tengelymaximum mellett](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ez a példa egy 2D oszlopdiagramot használ értéktengellyel. Az értéktengellyel nem rendelkező diagramok, például a kör- és a gyűrűdiagram, nem rendelkeznek ilyen módon korlátozható tengelymaximumszal.
{{% /alert %}}

## **Címke távolság beállítása egy tengelytől**

Használja a [setLabelOffset](https://reference.aspose.com/slides/hu/python-java/aspose.slides/axis/#setLabelOffset) metódust a kategóriatengely-címkék és a tengely közötti távolság szabályozásához. Az érték a tengelycímkék maximális betűméretének százaléka. Ez a példa egy csoportos oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategóriatengely címkéire hat, nem pedig az egyes adatpontokhoz csatolt címkékre.

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

Kördiagramon állítsa be az adatcímkék pozícióját a térköz javítása és a vezető vonalak számára hely biztosítása érdekében.  
Ez a példa az első adatpont értékét jeleníti meg, a címkét a szelet kívülre helyezi, és a [setX](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabel/#setX) és [setY](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabel/#setY) segítségével állítja be a vízszintes és függőleges eltolásokat. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva relatívak.

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

![Kördiagram a módosított adatcímke pozícióval](pie-chart-adjusted-label.png)

## **GYIK**

**Hogyan lehet megakadályozni az adatcímkék átfedését sűrű diagramokon?**  
Kombinálja az automatikus címkeelhelyezést, a vezető vonalakat és a kisebb betűméretet; szükség esetén rejtse el bizonyos mezőket (például a kategóriát), vagy csak extrém értékekhez vagy kulcspontokhoz jelenítsen meg címkéket.

**Hogyan kapcsolhatom ki a címkéket csak a nulla, negatív vagy üres értékeknél?**  
Szűrje a adatpontokat a címkék engedélyezése előtt, és a meghatározott szabály alapján kapcsolja ki a megjelenítést a 0, negatív vagy hiányzó értékeknél.

**Hogyan biztosítható a következetes címkestílus PDF/képek exportálásakor?**  
Határozza meg explicit módon a betűcsaládot és méretet, és ellenőrizze, hogy a betűtípus elérhető-e a renderelési környezetben, hogy elkerülje a helyettesítést.