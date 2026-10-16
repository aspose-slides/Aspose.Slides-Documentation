---
title: PowerPoint‑prezentációk diagramjainak létrehozása vagy frissítése Pythonban
linktitle: Diagramok létrehozása vagy frissítése
type: docs
weight: 10
url: /hu/python-java/create-chart/
keywords:
- diagram hozzáadása
- diagram létrehozása
- diagram szerkesztése
- diagram módosítása
- diagram frissítése
- szórt diagram
- kördiagram
- vonaldiagram
- fa térkép diagram
- részvénydiagram
- doboz‑ és szakáll diagram
- tölcsér diagram
- napkör diagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Készítsen és testreszabjon diagramokat PowerPoint‑prezentációkban az Aspose.Slides for Python via Java használatával. Adjon hozzá diagramokat, formázza és szerkessze őket gyakorlati Python kódrészletekkel."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt arról, hogyan hozhatunk létre és testreszabhatunk diagramokat az Aspose.Slides for Python via Java használatával. Megtanulhatja, hogyan adjon programozott módon diagramot egy diára, töltse fel adatokal, és alkalmazzon különféle formázási beállításokat, hogy megfeleljen a specifikus tervezési követelményeinek. A cikk során részletes kódrészletek mutatják be minden lépést, a prezentáció és a diagramobjektum inicializálásától a sorok, tengelyek és jelmagyarázatok konfigurálásáig. Az útmutató követésével alapos megértést szerezhet a dinamikus diagramgenerálás integrálásáról Python alkalmazásaiban, ezzel leegyszerűsítve az adat‑alapú prezentációk létrehozását.

## **Diagram létrehozása**

A diagramok segítik az embereket az adatok gyors megjelenítésében és olyan betekintések nyerésében, amelyek egy táblázatból vagy számolótáblából nem lennének azonnal egyértelműek.

**Miért készítsünk diagramokat?**

A diagramok segítségével:

* nagy mennyiségű adatot aggregálhat, sűríthet vagy összefoglalhat egyetlen dián egy prezentációban;
* mintákat és trendeket tárhat fel az adatokban;
* meghatározhatja az adatok időbeli vagy adott mérőegységhez viszonyított irányát és lendületét;
* észlelhet kiejtések, anomáliák, eltérések, hibák és értelmetlen adatokat;
* komplex adatokat kommunikálhat vagy prezentálhat.

PowerPointban a diagramok létrehozhatók a *Insert* (Beszúrás) funkcióval, amely sablonokat kínál számos diagramtípus megtervezéséhez. Az Aspose.Slides használatával létrehozhat mind szabványos diagramokat (népszerű diagramtípusokon alapulva), mind egyedi diagramokat.

{{% alert color="info" title="Note" %}}
Használja a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) felsorolást a [asposeslides.api](https://reference.aspose.com/slides/python-java/aspose.slides/) csomagban. Ennek a felsorolásnak az értékei különböző diagramtípusoknak felelnek meg.
{{% /alert %}}

### **Csoportosított oszlopdiagramok létrehozása**

Ez a példa a [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) metódust használja egy csoportosított oszlopdiagram létrehozásához, amely két sorozatot hasonlít össze három kategóriában. A sorozatok piros és zöld kitöltéssel jelennek meg, az egyedi címkék pedig a kategóraneveket, sorozatneveket és értékeket mutatják. A 0‑s munkalap‑index az beágyazott diagrammunkafüzet első lapjára hivatkozik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().get_Item(0)

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    series = chart.getChartData().getSeries().get_Item(1)

    value_cell = workbook.getCell(worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    series.getFormat().getFill().getSolidFillColor().setColor(color)

    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A csoportosított oszlopdiagram](clustered_column_chart.png)

### **Pontdiagramok létrehozása**

A pontdiagramok (más néven scatter plot vagy x‑y grafikon) gyakran használatosak minták keresésére vagy két változó közötti korreláció bemutatására.

Használjon pontdiagramot, ha:

* Párosított numerikus adatjai vannak.
* Két változó jól párosítható egymással.
* Meg akarja állapítani, hogy a két változó összefügg-e.
* Van egy független változó, amely több értéket vesz fel egy függő változó esetén.

Ez a példa két x‑y értékkészletet ábrázol. Az első sorozat egyenes vonalakkal és csillag‑markerekkel jelenik meg, a második sima vonalakkal és kör‑markerekkel; mindkettő 10‑es markerméretet használ, amelyet a [setSize](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSize) állít be. A [setSymbol](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSymbol) metódus szabályozza a jelölő alakját.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()

    series_name_cell = workbook.getCell(worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    x_value_cell = workbook.getCell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.getCell(worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.getCell(worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    series = chart.getChartData().getSeries().get_Item(1)

    x_value_cell = workbook.getCell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.getCell(worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.getCell(worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A pontdiagram](scatter_chart.png)

### **Kördiagramok létrehozása**

A kördiagramok leginkább az adatok része‑egész viszonyának bemutatására alkalmasak, különösen akkor, ha a data kategóriákat numerikus értékekkel látják el. Ha az adatok sok részre vagy címkére oszlanak, érdemes inkább oszlopdiagramot használni.

Ez a példa három negyedéves értékkel hoz létre egy kördiagramot. Minden szelet egyedi kitöltéssel és szegéllyel rendelkezik, a címkék pedig különböző kombinációban jelenítik meg az értékeket, százalékokat és sorozatinformációkat. A [setFirstSliceAngle](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setFirstSliceAngle) metódus az első szeletet 180 fokban indítja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    category_cell = workbook.getCell(0, 1, 0, "1st Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(value_cell)

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    first_slice = series.getDataPoints().get_Item(0)
    first_slice.getFormat().getFill().setFillType(FillType.Solid)
    first_slice.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    first_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    first_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    first_slice.getFormat().getLine().setWidth(3.0)
    first_slice.getFormat().getLine().setStyle(LineStyle.ThinThick)
    first_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDash)

    second_slice = series.getDataPoints().get_Item(1)
    second_slice.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(165, 42, 42)
    second_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    second_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_slice.getFormat().getLine().setWidth(3.0)
    second_slice.getFormat().getLine().setStyle(LineStyle.Single)
    second_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_slice = series.getDataPoints().get_Item(2)
    third_slice.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(255, 127, 80)
    third_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    third_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_slice.getFormat().getLine().setWidth(2.0)
    third_slice.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    first_label = series.getDataPoints().get_Item(0).getLabel()
    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    presentation.save("PieChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A kördiagram](pie_chart.png)

A körön kívüli címkék olvashatóságának javításához tekintse meg a [Format Leader Lines](/slides/hu/python-java/chart-data-label/#format-leader-lines) példát, amely a címkék pozícionálását és a vonalak színének, vastagságának, átlátszóságának és szaggatottságának testreszabását mutatja be.

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven line graph) leginkább olyan helyzetekben hasznosak, ahol az értékek időbeli változását szeretné bemutatni. Egy vonaldiagram segítségével egyszerre összehasonlíthat nagy mennyiségű adatot, nyomon követheti az időbeli változásokat és trendeket, kiemelheti a sorozatok anomáliáit, és még sok mást.

Ez a példa a [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) metódussal hoz létre egy vonaldiagramot az alapértelmezett sorozatokkal és kategóriákkal, majd PPTX‑ként menti a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alapértelmezés szerint a vonaldiagram pontjai egyenes, folytonos vonallal vannak összekötve. Ha a pontok közötti kapcsolatot szaggatott vonallal szeretné, hívja meg a [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) metódust a [LineDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) egyik értékével:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)
finally:
    presentation.dispose()
```

Az eredmény:

![A vonaldiagram](line_chart.png)

### **Fa térkép diagramok létrehozása**

A fa térkép diagramok leginkább értékesítési adatok esetén használandók, amikor a kategóriák relatív méretét és a legnagyobb hozzájárulók gyors kiemelését szeretné megjeleníteni.

Ez a példa egy fa térképet hoz létre nyolc levéllel, amely négy szárra és két ágra van csoportosítva. A [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) metódus az 1‑es szintű csoportosításnál a szárakat, a 2‑es szintnél pedig az ágakat rendeli hozzá. Az értékek határozzák meg a relatív téglalapméreteket, míg a kategória‑címkék és a átfedő szülőcímkék jelölik a hierarchiát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Treemap, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Ág 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # Ág 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A fa térkép diagram](treemap_chart.png)

### **Vízáfall diagramok létrehozása**

A vízáfall diagram megmutatja, hogy a pozitív és negatív változások hogyan járulnak hozzá a végső értékhez. Például egy profit‑szemlélet a bevétellel kezdődhet, majd a költségek levonásával és egyéb bevételek hozzáadásával alakul ki. A változó oszlopok a korábbi és az új futó értékek között lebegnek, míg a teljes oszlopok a nullától a felhalmozott értékig terjednek.

Az alábbi példa ezer amerikai dollárban megadott összegeket használ:

| Kategória | Munkafüzet érték | Oszlop típusa |
| --- | ---: | --- |
| Revenue | 1000 | Increase |
| Cost of sales | -400 | Decrease |
| Gross profit | 600 | Intermediate total |
| Operating expenses | -200 | Decrease |
| Other income | 50 | Increase |
| Net profit | 450 | Final total |

Egy pont közbenső vagy végső összegként való megjelöléséhez hívja meg a [setSetAsTotal](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setSetAsTotal) metódust **True** értékkel. Adja meg a tényleges felhalmozott összeget a pont munkafüzet‑cellájában: `600` a bruttó profithoz (`1000 - 400`) és `450` a nettó profithoz (`600 - 200 + 50`). A metódus csak megjelöli az oszlopot összegként; nem számolja ki vagy tölti fel a cella értékét. Ne használjon nullát helyőrzőként, és ne adjon meg más változást egy összeg‑pont számára. A teljes oszlop csak a felhalmozott értéket jeleníti meg, anélkül, hogy újra hozzáadná azt a futó értékhez.

Ez a teljes Python példa a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) **Waterfall** tagjával hoz létre egy diagramot, törli az alapértelmezett adatokat, és feltölti a beágyazott munkafüzetet. A 0‑s munkalap‑index az első munkalapot választja; az A oszlop a kategórianéveket, a B oszlop az értékeket tartalmazza. Minden értékcellát a [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#addDataPointForWaterfallSeries) metódussal adunk hozzá. A 0‑alapú pontindexek `2` és `5` a köztes és a végső összegeket jelölik. A [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) **True**‑val való hívása megjeleníti az összegeket az oszlopokon. Nincs bemeneti prezentáció vagy munkafüzet szükséges.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Waterfall, 20, 20, 680, 200)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)")
    chart.getChartTitle().setOverlay(False)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Profit")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Waterfall)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, categories[i])
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(worksheet_index, i + 1, 1, values[i])
        series.getDataPoints().addDataPointForWaterfallSeries(value_cell)

    # A harmadik és a hatodik pont összegként jelenik meg, nem további változásként.
    series.getDataPoints().get_Item(2).setSetAsTotal(True)
    series.getDataPoints().get_Item(5).setSetAsTotal(True)
    series.setShowConnectorLines(True)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("WaterfallChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A sorozatszintű [setShowConnectorLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setShowConnectorLines) **True**‑ra állítása megjeleníti a szomszédos oszlopokat összekötő vonalakat, megkönnyítve a futó érték nyomon követését. Ezeknek a vonalaknak a elrejtéséhez cserélje ki a metódushívást a példában `series.setShowConnectorLines(False)`‑ra a mentés előtt. Ez csak a vonalak láthatóságát változtatja, az adatot vagy az összegeket nem.

A mentett prezentáció 600‑as bruttó profitot és 450‑as nettó profitot mutat, mindkét összeg nulláról indul:

![A vízáfall diagram a bevételt, költségeket, 600‑as bruttó profitot és 450‑as nettó profitot, értékcímkékkel és összekötő vonalakkal ábrázolva](waterfall_chart.png)

### **Részvénydiagramok létrehozása**

A részvénydiagramok pénzügyi adatokat, például nyitó, legmagasabb, legalacsonyabb és záró árakat ábrázolják, segítve a piaci trendek és volatilitás elemzését. Alapvető betekintést nyújtanak a részvény‑teljesítménybe, támogatva a befektetőket és elemzőket a tájékozott döntéshozatalban.

Ez a példa egy nyitó‑magas‑alacsony‑záró (OHLC) diagramot hoz létre négy sorozattal ebben a sorrendben és három kategóriával. A [setUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#setUpDownBars) metódus engedélyezi a fel‑le csíkokat, a [getHiLowLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getHiLowLinesFormat) szabályozza a magas‑alacsony vonalakat, míg az egyes sorozat‑vonalak és a kisebb vízszintes rácsvonalak el vannak rejtve.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, False)

    workbook = chart.getChartData().getChartDataWorkbook()

    category_cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)

    series = chart.getChartData().getSeries().get_Item(0)
    value_cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(1)
    value_cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(2)
    value_cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(3)
    value_cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for stock_series in chart.getChartData().getSeries():
        stock_series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("Stock-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A részvénydiagram](stock_chart.png)

### **Doboz‑ és szakáll diagramok létrehozása**

A doboz‑ és szakáll diagramok az adat eloszlását jelenítik meg kulcsfontosságú statisztikai mutatók – például medián, kvartilisek és esetleges kiugró értékek – összefoglalásával. Különösen hasznosak felderítő adatelemzések és statisztikai tanulmányok során, hogy gyorsan megértsük az adatvariabilitást és az esetleges anomáliákat.

Ez a példa hat értékkel hoz létre egy doboz‑ és szakáll diagramot. A [setQuartileMethod](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setQuartileMethod) metódus az exkluzív kvartilis‑számítást választja. A példa engedélyezi a közép‑vonalakat, a közép‑markereket, a belső pontokat és a kiugró pontokat is.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.BoxAndWhisker, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    value_cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tölcsér diagramok létrehozása**

A tölcsér diagramok a folyamatok szekvenciális szakaszainak vizualizálására szolgálnak, ahol az adatmennyiség minden lépésnél csökken. Különösen hasznosak a konverziós arányok elemzésében, a szűk keresztmetszetek azonosításában és az értékesítési vagy marketing folyamatok hatékonyságának nyomon követésében.

Ez a példa a [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) használatával tölcsér diagramot ad az existing prezentáció első diájához. A alapértelmezett adatot hat kategóriával és 50‑tól 500‑ig terjedő értékekkel helyettesíti, majd menti a frissített prezentációt. A bemeneti prezentációban legalább egy dia kötelező.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    value_cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A tölcsér diagram](funnel_chart.png)

### **Sunburst diagramok létrehozása**

A Sunburst diagramok hierarchikus adatokat ábrázolnak, a szinteket koncentrikus gyűrűkként jelenítve. Segítenek a rész‑egész kapcsolatok bemutatásában, és ideálisak a beágyazott kategóriák és alcsoportok tömör, áttekinthető megjelenítéséhez.

Ez a példa egy Sunburst diagramot hoz létre nyolc levéllel, amely négy szárra és két ágra van csoportosítva. A [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) metódus az 1‑es szintű szárakat, a 2‑es szintű ágakat rendeli hozzá. A kategória‑címkék az egyes szegmeneteket jelölik, az értékek pedig a relatív méreteket határozzák meg.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Sunburst, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Ág 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # Ág 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A Sunburst diagram](sunburst_chart.png)

### **Hisztogram diagramok létrehozása**

A hisztogram diagramok megmutatják, hogyan oszlanak a numerikus értékek az intervallumok (binok) között. Havi jelentésekben a megrendelés‑feldolgozási időkről érdemes állandó bin‑szélességet és küszöböket használni, így az intervallumok konzisztensnek maradnak, és a megoszlások könnyebben összehasonlíthatók.

Hívja a [setAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAggregationType) metódust a vízszintes tengelyen a [AxisAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axisaggregationtype/) egyik módjával. A [setBinWidth](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setBinWidth) csak a `ByBinWidth` esetén alkalmazható; a [setNumberOfBins](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberOfBins) csak a `ByNumberOfBins` esetén. Az `Automatic` használatával a diagram maga választja ki a bin‑eket.

#### **Fix bin szélesség használata**

Ez a példa a feldolgozási időket 10‑perces intervallumokba sorolja, külön binokkal a 10 perc vagy annál kevesebb, illetve a 40 perc feletti időkre. Az ilyen bin‑eket a [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) és a [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin) engedélyezi. Ha explicit küszöböket ad meg a [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) és a [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin) segítségével, akkor a [setAutomaticUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticUnderflowBin) és a [setAutomaticOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticOverflowBin) metódusokat `False`‑ra állítsa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByBinWidth)
    axis.setBinWidth(10.0)
    axis.setUnderflowBin(True)
    axis.setAutomaticUnderflowBin(False)
    axis.setUnderflowBin(10.0)
    axis.setOverflowBin(True)
    axis.setAutomaticOverflowBin(False)
    axis.setOverflowBin(40.0)

    presentation.save("Histogram-bin-width.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A PowerPoint‑ban megjelenített prezentáció a **3, 4, 4, 4, és 2** bin‑számot mutatja. Az alulcsökkenő bin tartalmazza a `5, 10, 10` értékeket, így a küszöb inkluzív. A felülcsökkenő bin csak a `41, 50` értékeket tartalmazza, ezért a küszöb exkluzív; a `40`‑es értékek az előző intervallumban maradnak. A belső bin‑ek értéke nagyobb, mint az alsó határ, és kisebb vagy egyenlő a felső határral.

![Hisztogram 10‑perces bin‑ekkel és explicit alul‑ és felülcsökkenő küszöbökkel](histogram_bin_width.png)

#### **Határozd meg a binok számát**

Rögzített részletességi szint helyett, ha a bin‑ek számát szeretné meghatározni, kérje ki öt bin‑t ugyanarra az adatra. Ez a példa letiltja az alul‑ és felülcsökkenő bin‑eket. A diagram a szélességet az adat‑tartományból számolja, így a határok jelentések között változhatnak.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByNumberOfBins)
    axis.setNumberOfBins(5)

    presentation.save("Histogram-bin-count.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az öt bin **4, 4, 4, 4, és 1** értéket tartalmaz. Hasonlítsa össze ezt az eloszlást a fenti fix‑szélességű eredménnyel: a bemeneti értékek azonosak, de a határok különböznek.

![Hisztogram öt bin‑nel, azonos adatok alapján számítva](histogram_bin_count.png)

### **Radar diagramok létrehozása**

A radar diagramok többváltozós adatokat ábrázolnak kétdimenziós formában, lehetővé téve több változó egyszerre történő könnyű összehasonlítását. Különösen hasznosak a minták, erősségek és gyengeségek azonosításában több teljesítménymutató vagy attribútum esetén.

Ez a példa a [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) metódussal hoz létre egy radar diagramot az alapértelmezett sorozatokkal és kategóriákkal, majd PPTX‑ként menti a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addChart(ChartType.Radar, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A radar diagram](radar_chart.png)

### **Többkategóriás diagramok létrehozása**

A többkategóriás diagramok olyan adatokat jelenítenek meg, amelyek több kategória‑csoportot tartalmaznak, lehetővé téve az értékek több dimenzióban való egyidejű összehasonlítását. Különösen hasznosak, ha összetett, több rétegű adathalmazok trendjeit és összefüggéseit kell elemezni.

Ez a példa egy csoportosított oszlopdiagramot hoz létre nyolc kategóriával, amely négy párra van rendezve. A [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) metódus minden párhoz megosztott címkét ad az 1‑es csoportosítási szinten, így a kategóriatengely egyaránt tartalmaz egyéni és csoportcímkéket.

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

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    category_cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    category_cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    category_cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    category_cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    value_cell = workbook.getCell(worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A többkategória diagram](multi_category_chart.png)

### **Térkép diagramok létrehozása**

A térkép diagramok földrajzi adatokat ábrázolnak, információkat térképezve konkrét helyekre, mint például országok, államok vagy városok. Különösen hasznosak a regionális trendek, demográfiai adatok és térbeli eloszlások elemzésében, egyértelmű és vizuálisan vonzó módon.

Ez a példa a [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) segítségével hoz létre egy térkép diagramot az alapértelmezett földrajzi adatokkal, és PowerPointban megtekinthető formában menti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Map, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A térkép diagram](map_chart.png)

{{% alert color="info" title="Note" %}}
A fenti kép a mentett prezentáció PowerPoint‑ban megnyitott állapotát mutatja. Az Aspose.Slides helyesen írja a térkép diagramot és annak adatait, de maga a diagram nem kerül renderelésre: amikor egy diát, amely ilyen diagramot tartalmaz, képpé, PDF‑vé vagy SVG‑vé konvertálnak, a diagramterület üres marad. A dián lévő egyéb alakzatok ezzel nem érintettek.
{{% /alert %}}

### **Kombinált diagramok létrehozása**

A kombinált diagram (vagy combo diagram) két vagy több diagramtípust egyesít egyetlen ábrában. Ez a diagram lehetővé teszi, hogy kiemelje, összehasonlítsa vagy megvizsgálja a különböző adatcsoportok közti eltéréseket, segítve a köztük lévő kapcsolatok azonosítását.

![A kombinált diagram](combination_chart.png)

Ez a példa két csoportosított oszlop sorozatot és egy vonal sorozatot kombinál négy kategóriában. Az oszlopok az elsődleges függőleges tengelyhez tartoznak, míg a [setPlotOnSecondAxis](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setPlotOnSecondAxis) a vonalat a jobb oldalon található második függőleges tengelyre helyezi. A segédfüggvények konfigurálják a címet, a jelmagyarázatot, a tengelycímkéket és a rácsvonalakat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # Állítsa be a diagram címét.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Állítsa be a diagram jelmagyarázatát.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Törölje az alapértelmezett generált sorozatokat és kategóriákat.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Új kategóriák hozzáadása.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # Az első sorozat hozzáadása.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # A vízszintes tengely beállítása.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # A függőleges tengely beállítása.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # A függőleges fő rácsvonalak színének beállítása.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Másodlagos vízszintes tengely beállítása.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Másodlagos függőleges tengely beállítása.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **Diagramok frissítése**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy PowerPoint diagramokat frissítsen a diagramadatok, formázás és stílus módosításával. Ez a funkcionalitás leegyszerűsíti a prezentációk dinamikus tartalommal való naprakészen tartását, és biztosítja, hogy a diagramok pontosan tükrözzék az aktuális adatokat és vizuális szabványokat.

Ez a példa frissíti a “My chart” nevű diagramot a meglévő prezentáció első diáján. Két oszlop‑sorozat szükséges, mindegyik három adatponttal, a kategória‑címkék az A oszlopban, a sorozatnevek az első munkalap első sorában. A példa a [getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) metódussal módosítja a munkafüzet celláit, frissíti a sorozatértékeket, hozzáad egy harmadik sorozatot, és a [setType](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setType) segítségével a diagramot csoportosított hengerekké változtatja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartType, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            worksheet_index = 0

            workbook = chart.getChartData().getChartDataWorkbook()

            workbook.getCell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.getCell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.getChartData().getSeries().get_Item(0)

            workbook.getCell(worksheet_index, 0, 1, "New_Series 1")
            series.getDataPoints().get_Item(0).getValue().setData(90)
            series.getDataPoints().get_Item(1).getValue().setData(123)
            series.getDataPoints().get_Item(2).getValue().setData(44)

            series = chart.getChartData().getSeries().get_Item(1)

            workbook.getCell(worksheet_index, 0, 2, "New_Series 2")
            series.getDataPoints().get_Item(0).getValue().setData(23)
            series.getDataPoints().get_Item(1).getValue().setData(67)
            series.getDataPoints().get_Item(2).getValue().setData(99)

            series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
            series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

            value_cell = workbook.getCell(worksheet_index, 1, 3, 20)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 2, 3, 50)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 3, 3, 30)
            series.getDataPoints().addDataPointForBarSeries(value_cell)

            chart.setType(ChartType.ClusteredCylinder)

    presentation.save("AsposeChartModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Adattartomány beállítása egy diagramhoz**

A már meglévő diagram által használt tartomány megtekintéséhez lásd a [Retrieve a Chart's Data Range](/slides/hu/python-java/chart-workbook/#retrieve-a-charts-data-range) oldalt.

Az Aspose.Slides for Python via Java rugalmasságot biztosít, hogy egy munkalap konkrét adattartományát definiálja diagramadatai forrásaként. Ez azt jelenti, hogy közvetlenül leképezheti a munkalap egy részét a diagramra, ellenőrizve, hogy mely cellák járulnak hozzá a sorozatokhoz és a kategóriákhoz. Ennek eredményeként könnyen frissítheti és szinkronizálhatja a diagramokat a munkalap legújabb adatváltozásaival, biztosítva, hogy a PowerPoint prezentációk aktuális és pontos információkat tükrözzenek.

Ez a példa a [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) használatával állítja be a “My chart” nevű diagram adatforrását az első dián egy meglévő prezentációban `Sheet1!A1:B4`‑re. A diagram munkafüzetnek tartalmaznia kell ezt a munkalapot, valamint egy sorozat‑fejlécet az első sorban, kategória‑címkéket az A oszlopban, és három értéket a B oszlopban.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Alapértelmezett jelölők használata diagramokban**

Alapértelmezett jelölők használatakor minden diagramsorozat automatikusan más‑más alapértelmezett jelölő szimbólummal rendelkezik.

Ez a példa a [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) segítségével hoz létre egy diagramot két vonal‑sorozattal és egy jelmagyarázattal. A [getMarker](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getMarker) által elérhető jelölő beállítások megtartják az automatikusan hozzárendelt jelölő szimbólumokat. Az első sorozat negatív és hiányzó értéket (None) tartalmaz, míg a második minden kategóriához értéket ad.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    series_name_cell = workbook.getCell(0, 0, 2, "Series 2")
    second_series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Milyen diagramtípusokat támogat az Aspose.Slides for Python via Java?**

Az Aspose.Slides for Python via Java széles körű diagramtípusokat támogat, többek között oszlop, vonal, kör, terület, pont, hisztogram, radar és még sok más. Ez a rugalmasság lehetővé teszi, hogy az adatvizualizációs igényeknek leginkább megfelelő típusokat válassza.

**Hogyan adhatok hozzá új diagramot egy diára?**

Új diagram hozzáadásához először hozza létre a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztály egy példányát, szerezze be a kívánt diát az indexével, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagramtípust és a kezdeti adatokat. Ez a folyamat közvetlenül integrálja a diagramot a prezentációba.

**Hogyan frissíthetem egy diagramon megjelenített adatokat?**

A diagram adatait a [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) elérésével, az alapértelmezett sorozatok és kategóriák törlésével, majd saját adatainak hozzáadásával frissítheti. Ez lehetővé teszi, hogy programozottan frissítse a diagramot a legújabb adatokkal.

**Lehetséges-e a diagram megjelenésének testreszabása?**

Igen, az Aspose.Slides for Python via Java kiterjedt testreszabási lehetőségeket biztosít. Módosíthat színeket, betűtípusokat, címkéket, jelmagyarázatokat és más formázási elemeket, hogy a diagram megjelenését az Ön specifikus tervezési követelményeihez igazítsa.