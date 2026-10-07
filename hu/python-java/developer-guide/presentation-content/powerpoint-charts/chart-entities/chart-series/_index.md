---
title: Diagram adat sorozatok kezelése prezentációkban Pythonban
linktitle: Adatsorok
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
description: "Ismerje meg, hogyan kezelje a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket a prezentációkban az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

A diagram a megjelenített adatait egy diagramadat-munkafüzetben tárolja. A [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) egy kapcsolódó értékek halmazát képviseli, és a sorozat minden [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és az adatpont értékek ezért a [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenített szövegként tárolódnak.

Egy tipikus kategória-diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatnevekhez, a 0. oszlopot a kategória-nevekhez, a maradék cellákat pedig a sorozatértékekhez. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) metódusnak átadott munkalap, sor és oszlop indexek nulláral kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre egy diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Egy betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkafüzet értékét.

A diagram beállítások három különböző hatókörrel rendelkeznek:

- Sorozati szintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), az adott sorozat minden adatpontjának alapértelmezett megjelenését biztosítják.
- Adatpont szintű beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), felülbírálják a sorozati megjelenést egyetlen pont esetén.
- Csoport beállítások kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) metódussal érheti el, ha olyan opciókat szeretne beállítani, mint például az átfedés vagy a hézag szélessége.

Ha nincs kifejezetten beállítva pont- vagy sorozatkitöltés, akkor a diagramstílus és a téma határozza meg az automatikus megjelenést. Ha sorozati és pont formázás egyaránt jelen van, a pont formázása él az adott pont esetében.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

A [ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) megadja, hogy a vonalak vagy oszlopok mennyire fedik egymást egy 2D diagramon, -100 és 100 százalék között. Ez a szülő sorozatcsoport beállításának csak olvasható projekciója. Használja a [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) metódust, hogy frissítse a csoport minden kompatibilis sorozatát. Ez az opció olyan diagramtípusokra vonatkozik, amelyek csoportosított vonalakat vagy oszlopokat jelenítenek meg; kombinált diagramok esetén nem befolyásolja a nem kapcsolódó sorozatcsoportokat.

Az alábbi példa beállítja az átfedést azon csoportnál, amelyik az első sorozatot tartalmazza:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

Használja a [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) metódust, hogy az egész sorozatra beállítsa az alapértelmezett kitöltést. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülírja a sorozati kitöltést az adott pontnál.

Az alábbi példa egy egyszínes kék kitöltést alkalmaz az első sorozatra:

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

A sorozat neve a diagramadat-munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett klaszter oszlopdiagramhoz létrehozott munkafüzetben a B1 cella a 0. sor, 1. oszlop pozícióban található, és az első sorozat nevét tartalmazza. A következő példa név változók segítségével expliciten mutatják be a struktúrát:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

Az is frissíthető a már a [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) által hivatkozott cella. Ez a megközelítés elkerüli, hogy feltételezzük egy adott sort és oszlopot egy meglévő diagramban:

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

### **Sorozat létrehozása több cellából álló névvel**

Összetett sorozatnév akkor hasznos, ha a termék neve és a jelentési időszak külön munkafüzetcellákban van tárolva. Például a `Product A` értéket a B1‑ben és a `2026` értéket a C1‑ben egyetlen sorozatnévbe kombinálhatja, miközben mindkét rész továbbra is hivatkozik a forráscelláira.

Használja a [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) metódust a névtartomány lekéréséhez, majd a visszakapott gyűjteményt adja át a [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) metódusnak. A `skipHiddenCells` argumentum határozza meg, hogy a rejtett cellák bekerülnek-e: `True` kizárja őket, `False` pedig beleveszi. Ebben a példában `False`‑t használunk, hogy a teljes névtartományt felvegyük.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák csak a sorozat nevét szállítják; az A2:A3 a kategória címkéket, a B2:B3 pedig a numerikus értékeket adja meg.

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

    # Ez a két cella adja meg a sorozat nevét.
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

Az előállított sorozatnév `Product A 2026`, a két cella értéke között szóköz van. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép mutatja a végeredményt:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **A sorozat automatikus kitöltőszínének lekérdezése**

A [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) visszaadja a sorozatindex és a diagramstílus alapján kiszámított színt. Ez a szín kerül alkalmazásra, ha a sorozat kitöltése nincs kifejezetten definiálva. A metódus csak a kiszámított színt olvassa, nem állít be új kitöltést.

Az alábbi példa kiírja minden alapértelmezett sorozat automatikus színét:

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

Példa kimenet az alapértelmezett diagramstílushoz:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagramstílustól és a témától függnek.

## **Inverz kitöltőszín beállítása egy diagram sorozathoz**

Oszlop-, oszlop- és buborék-sorozatok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) negatív értékeket megjeleníthet más kitöltéssel. Állítsa be a normál sorozatkitöltést egyszínűre, engedélyezze az invertálást, és adja meg a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) metódussal. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa az alapértelmezett diagramadatot egy sorozatra cseréli. A munkalap 0‑s sorában a sorozat neve, a 0‑s oszlopban a kategória-nevek, az 1‑es oszlopban pedig az értékek találhatók:

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

Inverzálást egyetlen ponthoz is engedélyezhet a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) metódussal. Az alábbi példában a sorozatnál tiltottuk az invertálást, csak a kiválasztott pontnál engedélyeztük. A pontnak negatív értéket is adtunk, hogy a hatás látható legyen:

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

Egy pontot üresként hagyhat anélkül, hogy a többi pontot eltávolítaná, ha a mögöttes munkafüzetcellát `None`‑ra állítja. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) metódussal érhető el. Az adatpont ugyanazon kategória pozícióban marad, de a diagram az értékét üresnek tekinti a diagram üres-érték beállításai szerint.

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

A pontdiagramok külön X és Y cellákat használnak, a buborékdiagramok pedig egy méretcellát is. Csak azt a cellát törölje, amely az eltávolítandó értéket tartalmazza. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) metódust, ha a többi pontot meg akarja tartani, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenítésének vezérlése**

A rejtett cellák, amelyek értéket tartalmaznak, külön esetet képeznek az üres celláktól. A rejtett munkalap sorok és oszlopok adatainak felvételével vagy kizárásával kapcsolatosan lásd a [Include Data from Hidden Rows and Columns](/slides/hu/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) oldalt.

Egy üres munkafüzetcellát hiányzó adatként értelmezünk; egy `0` értékű cella ismert numerikus értéket jelent. Hívja a [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) metódust `None`‑val, hogy a cellát üressé tegye. Egy numerikus nulla nulla marad, függetlenül az üres-cellás beállítástól.

Használja a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) metódust, hogy kiválassza, a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja, hogyan kerülnek ábrázolásra a hiányzó értékek, anélkül, hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3‑as nap értékét törli, majd minden módot külön menti. Bemeneti fájlra nincs szükség. A [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) a 0‑s munkalapot, az 0‑s oszlopot a kategória-címkéknek, az 1‑es oszlopot az értékeknek használja; a 0‑s sor tartalmazza a sorozat nevét. A végleges adat `10, 20, empty, 30, 40`.

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

    # Hagyja a 3. napot valóban üresen, miközben megtartja a kategóriát és az adatpontot.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Minden kimeneti fájl a mentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy változatot szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás három fájlban mutatja ugyanazt az adatot. A 3‑as nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagramtípustól függ. Egy vonaldiagramnál könnyű összehasonlítani a három módot. Oszlop- és sávdiagramoknál nincs vonal, amely a hiányzó kategória felett átfedne, ezért a `Span` nem tud egy kapcsolatot létrehozni; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen egy szórásdiagram csak jelölőkkel nem rendelkezik vonallal. Ne számítson három különböző eredményre minden diagramtípusnál; ellenőrizze a kimenetet a saját típusához.

## **A sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv- vagy oszlopcsoportok közti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust egyszer a csoport számára. Nagyobb érték szélesebb távolságot eredményez a csoportok között; kisebb érték sűrűbb elhelyezkedést okoz.

Az alábbi példa módosítja a hézag szélességét, és csak a végleges prezentációt menti:

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

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) felsorolásában szereplő diagramtípus használ diagramadatot, de sorozataik nem minden esetben rendelkeznek azonos értékstruktúrával vagy beállításokkal. Például a kategória-diagramok kategóriákat és értékeket használnak, a szórás-diagramok X és Y értékeket, a buborék-diagramok pedig buborékméreteket. Használja a sorozattípusnak megfelelő adatpont létrehozó metódust. Az átfedés és a hézag szélessége csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkozik.

**Mi az a diagram sorozatcsoport?**

Egy [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezek a cellák szerkeszthetők, vagy a sorozat‑ és kategória‑gyűjtemények törlésével teljesen egyedi adathalmazt adhat a diagramnak. Egy túlterhelés képes diagramot létrehozni alapértelmezett adat nélkül is.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet celláihoz?**

A sorozatnevek, a kategória‑címkék és az adatpont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatok építésekor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat összehangoltan, hogy minden pont a kívánt kategória alá kerüljön.

**Hogyan tudok egy pontot törölni anélkül, hogy az egész sorozatot törölném?**

Állítsa az adott értékcellát `None`‑ra, hogy a pont a kategória‑pozíciója megtartva üres pontként maradjon. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) metódust csak akkor használja, ha az adott sorozat összes pontját el szeretné távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek a kategória‑gyűjteménnyel összhangban maradjanak.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) által beállított értéktől függ. A támogatott diagramok megjeleníthetik az üresek helyét hézagként, nullaként vagy a szomszédos pontok összekapcsolásával. Válassza ki a beállítást, amely a hiányzó adatok jelentését tükrözi a prezentációjában. További részletekért lásd a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) fejezetet.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv-, oszlop- és buborék‑sorozatok esetén hívja a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) metódust, és állítsa be a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) által visszaadott színt. Egyéni pont esetén a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) felülírhatja a viselkedést. Ezek a metódusok a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont egyaránt formázva van?**

Az explicit adatpont‑formázás él az adott pontnál. A többi pont továbbra is az explicit sorozat‑formázást vagy, ha az nincs definiálva, az automatikus diagram‑stílust és témát használja. A csoport‑beállítások, mint az átfedés és a hézag szélessége, a elrendezést szabályozzák, és nem pont‑szintű formázási felülírások.

**Van-e korlátozás a diagramban szereplő sorozatok számára?**

Az Aspose.Slides nem határoz meg különálló, fix sorozatszám‑korlátot. Gyakorlatban a prezentációs fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozzák meg a hasznos felső határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti távolság szélesítéséhez, vagy csökkentse a csoportok közelebb hozatalához.