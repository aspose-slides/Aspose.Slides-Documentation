---
title: Diagram adat sorozatok kezelése prezentációkban Pythonban
linktitle: Adatsorozatok
type: docs
url: /hu/python-java/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- sorozat név
- adatpont
- munkafüzet cella
- sorozat hézag
- negatív érték
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket a prezentációkban az Aspose.Slides Pythonhoz Java segítségével."
---
## **Áttekintés**

Egy diagram a megjelenített értékeket tárolhatja munkafüzetcellákban vagy közvetlenül numerikus literálokként. A [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) egy kapcsolódó értékek halmazát képviseli, és minden [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) egy pontot jelent ebben a sorozatban. A [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) objektumok biztosítják a sorozatok által megosztott címkéket vagy csoportosítási értékeket. Az alapértelmezett adatokkal létrehozott diagramokban a sorozatnevek, kategóriák és pontértékek a [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) objektumokat használják a diagram munkafüzetéből.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0‑s sort a sorozatneveknek, a 0‑s oszlopot a kategórianévnek, a többi cellát pedig a sorozatértékeknek használja. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) metódusnak átadott munkalap-, sor- és oszlopindexek nullával kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt a struktúrát használja. Betöltött prezentáció esetén vizsgálja meg a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) biztosítják az alapértelmezett megjelenést az adott sorozat összes pontjának.
- Adatpont-szintű beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) felülírják a sorozat megjelenését egyetlen pont esetén.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) segítségével érheti el, ha például átfedés vagy hézag szélesség beállítására van szükség.

Ha nincs kifejezetten beállítva pont- vagy sorozat-kitöltés, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, akkor a pont formázása élvez elsőbbséget az adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Sorozatértékek beállítása numerikus literálokkal**

Használjon numerikus literálokat, ha a sorozatértékek alkalmazásadatokból vagy számításokból származnak, és nem igényelnek munkalapcellahivatkozásokat. Hívja meg a [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) metódust a [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) értékkel, mielőtt minden pont [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) eredményét a [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble) segítségével állítaná be.

A gyűjteménybeállítás szabályozza az adott sorozat összes pontértékének forrástípusát. Az egyes pontértékek [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) metódusa jelzi a kiválasztott típust; ezt a gyűjteménybeállítással változtathatja meg. `Worksheet` esetén a [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) használható a hivatkozott cella eléréséhez. `DoubleLiterals` esetén a [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) vagy a `setAsLiteralDouble` használható a szám közvetlen beolvasásához vagy írásához.

Az alábbi példa egy oszlopdiagramot hoz létre alapértelmezett sorozatokkal és kategóriákkal, majd a számított 10, 20 stb. értékeket az első sorozat meglévő pontjaira rendeli. A prezentációt elmenti, újra megnyitja, és kiírja a tárolt értékeket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

A pontérték forrástípusa különálló a [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) beállítástól, amely a diagram belső vagy külső munkafüzetkonfigurációját jelzi. A numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is elérhető a kategóriacímkék, sorozatnevek és a többi sorozat számára. Lásd a [Chart Workbook](/slides/hu/python-java/chart-workbook/) oldalt a munkafüzetkezeléshez.

Szórt és buborékdiagramok esetén használja a [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) és a [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) metódusokat, hogy kiválassza a forrásokat a [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) és a [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue) számára. A buborékdiagramok továbbá a [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) metódust használják a [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize) esetében. Minden alkalmazandó forrást állítson `DoubleLiterals` értékre, mielőtt a `setAsLiteralDouble` metódussal számértékeket rendelne hozzá.

## **A diagram sorozat átfedésének beállítása**

A [ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) megadja, hogy a 2D diagramokban a sávok vagy oszlopok mekkora mértékben fednek át egymást, -100 és 100 százalék között. Ez a beállítás csak olvasható, a szülő sorozatcsoport beállításainak leképezése. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) használatával frissítheti a csoport minden kompatibilis sorozatát. Ez az opció a csoportosított sávok vagy oszlopok megjelenítésére alkalmas diagramtípusoknál; kombinált diagramokban nem befolyásolja a nem kapcsolódó sorozatcsoportokat.

Az alábbi példa beállítja az átfedést annak a csoportnak, amelyik az első sorozatot tartalmazza:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Az új diagram mintasorozatokat, kategóriákat és értékeket tartalmaz.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![The series overlap](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

Használja a [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) metódust, hogy az egész sorozatra alapértelmezett kitöltést állítson be. Ha egy pont már rendelkezik kifejezett kitöltéssel, akkor annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülírja a sorozat kitöltését az adott pontnál.

Az alábbi példa egy tiszta kék kitöltést alkalmaz az első sorozatra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![The color of the series](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagram adat-munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben, amely egy klaszteres oszlopdiagramhoz jön létre, a B1 cella (0‑s sor, 1‑s oszlop) tartalmazza az első sorozat nevét. A következő példában a változók ezt a struktúrát teszik nyilvánvalóvá:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) által már hivatkozott cellát is frissítheti. Ezzel a megközelítéssel nem kell feltételezni egy adott sort és oszlopot egy meglévő diagramon:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![The series name](series_name.png)

### **Sorozat létrehozása több cellából származó névvel**

Összetett sorozatnév akkor hasznos, ha a termék neve és a jelentési időszak külön munkafüzetcellákban van tárolva. Például a `Product A` nevű terméket a B1, a `2026` évszámot a C1 cellában egyetlen sorozatnévvé kombinálhatja, miközben a két rész továbbra is a forráscelláira hivatkozik.

Használja a [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) metódust a névtartomány lekérdezéséhez, majd adja át ezt a gyűjteményt a [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) metódusnak. A `skipHiddenCells` argumentum szabályozza, hogy a rejtett cellák benne legyenek-e: `True` kizárja, `False` pedig belefoglalja őket. Ez a példa `False`‑t használ a névtartomány minden cellájának felvételéhez.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák csak a sorozatnevet tartalmazzák; az A2:A3 a kategóriacímkéket, a B2:B3 pedig a numerikus értékeket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Ezek a két cella biztosítja a sorozat nevét.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # Különálló cellák biztosítják a kategóriákat és a numerikus adatpontokat.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredményül kapott sorozatnév `Product A 2026`, a két cellaérték között egy szóközzel. A jelmagyarázat ezt egy bejegyzésként jeleníti meg mindkét oszlophoz. Az alábbi képen látható a végeredmény:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Az automatikus sorozatszín lekérése**

A [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) visszaadja a sorozat indexe és a diagram stílusa alapján számított színt. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs kifejezetten meghatározva. A metódus meghívása csak a számított színt olvassa, nem állít be új kitöltést.

Az alábbi példa kiírja az egyes alapértelmezett sorozatok automatikus színét:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Példa kimenet az alapértelmezett diagramstílusra:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagram stílusától és témájától függenek.

## **Inverz kitöltőszín beállítása egy diagram sorozathoz**

Sáv-, oszlop- és buborék sorozatok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) használható a negatív értékek más kitöltéssel történő megjelenítésére. Állítsa be a sorozat normál kitöltését szilárd színre, engedélyezze az invertálást, és adja meg a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenített színük változik.

Az alábbi példa az alapértelmezett diagramadatot egy sorozatra cseréli. A 0‑s munkalapsor a sorozatnevet, a 0‑s oszlop a kategórianéveket, az 1‑s oszlop pedig az értékeket tartalmazza:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![The inverted solid fill color](inverted_solid_fill_color.png)

Inverzálást egyetlen pontnál a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) segítségével is engedélyezheti. Az alábbi példában a sorozat esetében az invertálás ki van kapcsolva, csak a kiválasztott pontnál van engedélyezve, amelyhez negatív érték is van rendelve, hogy a hatás látható legyen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Egy adott adatpont értékének törlése**

Egy pont üresen hagyásához, anélkül hogy a többi pontot eltávolítaná, állítsa annak a támogatott munkafüzetcelláját `None`‑ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) metódussal érhető el. Az adatpont ugyanazon kategóriapozícióban marad, de a diagram a beállított üresérték‑kezelésnek megfelelően üresként kezeli.

Az alábbi példa csak a második pontot törli az első sorozatban:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Szórt diagramok esetén külön X és Y cellák vannak, a buborékdiagramok pedig egy méretcellát is használnak. Csak azt a cellát törölje, amely az eltávolítandó értéket tartalmazza. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) metódust, ha a többi pontot megtartani szeretné, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenítésének szabályozása**

Az értékeket tartalmazó rejtett cellák külön esetet jelentenek az üres cellákkal szemben. A rejtett munkalap‑sorok és oszlopok adatainak fel- vagy letiltásához tekintse meg a [Include Data from Hidden Rows and Columns](/slides/hu/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) oldalt.

Egy üres munkafüzetcellát a hiányzó adatként kezelünk; egy `0`‑t tartalmazó cella ismert numerikus értéket jelent. A [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) metódust `None`‑val hívva üres cellát hozhat létre. A numerikus nulla minden esetben nulla marad, függetlenül az üres‑cellakezeléstől.

A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) metódussal választhatja ki, hogyan jelenjenek meg az üres cellák a diagramon. Ez a beállítás az egész diagramra vonatkozik. Megváltoztatja, hogy a hiányzó értékek hogyan legyenek ábrázolva, anélkül, hogy a munkafüzet‑cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3. nap értékét törli, majd minden módhoz elmenti ugyanazt a diagramot. Bemeneti fájlra nincs szükség. A [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) a 0‑s munkalapot, az 0‑s oszlopot használja a kategóriacímkékhez, az 1‑s oszlopot pedig az értékekhez; a 0‑s sor a sorozatnevét tartalmazza. A végső adatsor `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Hagyja a 3. napot igazán üresen, miközben megőrzi a kategóriáját és adatpontját.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok közötti iterálás helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagram típusától függ. Egy vonaldiagramnál könnyű összehasonlítani mindhárom módot. Sáv‑ és oszlopdiagramok esetén nincs vonal, amely összekapcsolna egy hiányzó kategóriát, így a `Span` nem képes a fent látható összekötő szegmenst előállítani; egy hiányzó és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóan, egy csak jelölőkkel rendelkező szórt diagramnak nincs összekötő vonala. Ne számítson három különböző eredményre minden diagramtípusnál; ellenőrizze a kimenetet a saját típusán.

## **A sorozat hézagszélességének beállítása**

A hézagszélesség a szomszédos sáv‑ vagy oszloptömbök közötti távolságot jelenti, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust egyszer a csoporton. A nagyobb érték több helyet hoz létre a tömbök között; a kisebb érték sűrűbbé teszi őket.

Az alábbi példa módosítja a hézagszélességet, és csak a végső prezentációt menti el:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![The gap width](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat-sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ adatokat, de sorozataik nem mindegyiknek azonos értékszerkezete vagy beállítása. Például a kategóriadiagramok kategóriákat és értékeket, a szórt diagramok X és Y értékeket, a buborékdiagramok pedig buborékméreteket használnak. A sorozattípusnak megfelelő adatpont‑létrehozási módszert kell használni. Az olyan opciók, mint az átfedés és a hézagszélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram‑sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több mint egy csoportot tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz-e egy újból létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy mind a sorozat‑, mind a kategóriagyűjteményt törölheti, mielőtt teljesen saját adatkészletet adna hozzá. Egy túlterhelés segítségével olyan diagram is létrehozható, amely nem tartalmaz alapértelmezett adatot.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategóriacímkék és adat‑pont értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adat létrehozásakor tartsa összehangoltan a kategória‑sorokat és a sorozat‑érték‑sorokat, hogy minden pont a megfelelő kategória alá legyen ábrázolva.

**Hogyan töröljek egy pontot anélkül, hogy az egész sorozatot eltávolítanám?**

Állítsa a megfelelő értékcellát `None`‑ra, hogy a pont kategóriapozíciója üres pontként megmaradjon. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) metódust csak akkor használja, ha valóban az egész sorozat összes pontját el akarja távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek továbbra is a kategória‑gyűjteménnyel legyenek összehangolva.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) beállítástól függ. A támogatott diagramok megjeleníthetik a hiányzókat hézagként, nullaértékként vagy a szomszédos pontok összekapcsolásával. Válassza ki a beállítást, amely a hiányzó adatok jelentését tükrözi a prezentációban. Tekintse meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv‑, oszlop‑ és buborék sorozatok esetén hívja meg a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) metódust, és állítsa be a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) által visszaadott színt. Egy egyedi pont formázását a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) segítségével felülbírálhatja. Ezek a módszerek a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

A kifejezett adat‑pont formázás előnyt élvez az adott pont számára. A többi pont továbbra is a kifejezett sorozatformázást vagy, ha az nincs definiálva, a automatikus diagramstílust és témát használja. A csoportbeállítások, például az átfedés és a hézagszélesség, a elrendezést szabályozzák, és nem felülbírálják a pont‑szintű formázást.

**Van korlátozás a diagramban tárolható sorozatok számára?**

Az Aspose.Slides nem szab ki különálló, fix sorozatszám‑korlátot. Gyakorlatilag a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozzák meg a hasznos felső határt.

**Mit kell módosítani, ha az oszlopok túl közel vagy túl messze vannak egymástól?**

Hívja meg a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a klaszterek közötti távolság szélesítéséhez, vagy csökkentse a klaszterek közelebb hozatalához.