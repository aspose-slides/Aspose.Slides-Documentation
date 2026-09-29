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
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Egy diagram a megjelenített adatokat egy diagramadat‑munkafüzetben tárolja. A [ChartSeries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/) egy összefüggő értékcsoportot képvisel, és a sorozat minden [ChartDataPoint](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosító értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért a [ChartDataCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenő szövegként tárolódnak.

Egy tipikus kategóriadiagram esetén az alapértelmezett munkafüzet a 0. sorban tárolja a sorozatneveket, a 0. oszlopban a kategórianéveket, a maradék cellákban pedig a sorozatértékeket. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#getCell)‑nek átadott munkalap, sor és oszlop indexek nullával kezdődnek. Ez a felépítés akkor hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de nem szabad azt feltételezni, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén a sorozatok, kategóriák és adatpontok által hivatkozott cellákat ellenőrizze, mielőtt a munkafüzet értékeket megváltoztatná.

A diagram beállításainak három különböző hatóköre van:

- Sorozatszintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getFormat), az adott sorozat összes pontjának alapértelmezett megjelenését biztosítják.
- Adatpont szintű beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getFormat), egy pont esetén felülbírálják a sorozat megjelenését.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/)‑hez tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getParentSeriesGroup)‑on keresztül érheti el, ha például átfedés vagy hézag szélesség opciókat szeretne beállítani.

Ha nincs kifejezett pont- vagy sorozatterület beállítva, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázás jelen van, a pont formázása veszi el a felülbírálást az adott pontnál.

![diagram sorozat PowerPoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedés beállítása**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getOverlap) megmondja, hogy a sávok vagy oszlopok mennyire fednek át egy 2D diagramon, -100 és 100 százalék között. Ez csak olvasható leképezése a szülő sorozatcsoport beállításának. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setOverlap) használatával frissítheti az adott csoport minden kompatibilis sorozatát. Ez a beállítás a csoportos sávokat vagy oszlopokat megjelenítő diagramtípusokra vonatkozik; a kombinált diagramokban a nem kapcsolódó sorozatcsoportokat nem befolyásolja.

Az alábbi példa beállítja az átfedést azon csoportban, amely az első sorozatot tartalmazza:

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

    # Az új diagram minta sorozatokat, kategóriákat és értékeket tartalmaz.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A sorozat átfedése](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

A [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getFormat) segítségével állíthatja be egy egész sorozat alapértelmezett kitöltését. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülbírálja a sorozat kitöltését az adott pontnál.

Az alábbi példa szilárd kék kitöltést alkalmaz az első sorozatra:

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

![A sorozat színe](series_color.png)

## **A sorozat nevének módosítása**

Egy sorozat neve a diagram adatmunkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben, amely egy csoportos oszlopdiagramhoz készül, a B1 cella a 0. sorban, 1. oszlopban található, és az első sorozat nevét tartalmazza. Az alábbi példában a megnevezett változók egyértelműen bemutatják ezt a felépítést:

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

Frissítheti azt a cellát is, amelyre már a [ChartSeries.getName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getName) hivatkozik. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy meglévő diagramban:

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

![A sorozat neve](series_name.png)

## **Az automatikus sorozat kitöltőszín lekérése**

A [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor kerül felhasználásra, ha a sorozat kitöltése nincs kifejezetten meghatározva. A metódus meghívása csak a kiszámított színt olvassa, nem rendel hozzá új kitöltést.

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

Példa kimenet az alapértelmezett diagram stílusra:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagram stílusától és témájától függnek.

## **Inverz kitöltőszín beállítása diagram sorozathoz**

Sáv-, oszlop- és buborék sorozatok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#setInvertIfNegative) negatív értékeket másik kitöltéssel jeleníthet meg. Állítsa be a szabályos sorozat kitöltését szilárdra, engedélyezze az invertálást, és adja meg a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenő színük változik.

Az alábbi példa felcseréli az alapértelmezett diagram adatokat egy sorozatra. A munkalap 0. sora tartalmazza a sorozat nevét, a 0. oszlop a kategória neveket, az 1. oszlop pedig az értékeket:

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

![Az invertált szilárd kitöltőszín](inverted_solid_fill_color.png)

A invertálást egy pont esetén a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) segítségével engedélyezheti. Az alábbi példában a sorozatra le van tiltva az invertálás, csak a kiválasztott pontra van engedélyezve. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

Ahhoz, hogy egy pontot üressé tegyen anélkül, hogy a többi pontot eltávolítaná, a háttércelláját `None`‑ra állítsa. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getValue)‑on keresztül érhető el. Az adatpont ugyanazon kategóriapozícióban marad, de a diagram a beállított üres‑érték szabályok szerint üresnek kezeli a value‑t.

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

A szórt diagramok külön X és Y cellákat használnak, a buborék diagramok pedig egy méret cellát is. Csak a törlendő értéket reprezentáló cellát tisztítsa ki. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapointcollection/#clear)‑t, ha a többi pontot meg szeretné tartani, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenésének vezérlése**

A rejtett, értéket tartalmazó cellák külön esetet jelentenek az üres celláktól. A rejtett munkalap sorok és oszlopok adatait tartalmazni vagy kizárni a [Include Data from Hidden Rows and Columns](/slides/hu/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) lapon talál.

Egy üres munkafüzet cella hiányzó adatot jelöl; a `0` értéket tartalmazó cella ismert numerikus értéket jelent. A [ChartDataCell.setValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#setValue)‑t `None`‑val hívva üressé tehet egy cellát. A numerikus nulla továbbra is nulla marad függetlenül az üres‑cella beállítástól.

A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setDisplayBlanksAs) segítségével választhatja ki, hogyan jelenítse meg a diagram az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja, hogyan ábrázolják a hiányzó helyeket, anélkül, hogy az üres munkafüzet cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3. nap értékét, és minden módnál elmenti ugyanazt a diagramot. Bemeneti fájlra nincs szükség. A [ChartDataWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/) az 0. munkalapot, a 0. oszlopot a kategória címkéknek, az 1. oszlopot az értékeknek használja; az 0. sor a sorozat nevét tartalmazza. A végső adatok: `10, 20, empty, 30, 40`.

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

    # A 3. napot valóban hagyja üresen, miközben megtartja a kategóriáját és adatpontját.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok sorozatos iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap üres a munkafüzetben minden esetben:

![Vonal diagramok azonos adatokkal: Gap szakad a vonalat a 3. napnál, Zero a vonalat nullára viszi, Span összeköti a 2. és 4. napot.](display_blanks_as.png)

A látható hatás a diagram típusától függ. A vonaldiagram könnyűvé teszi a három mód összehasonlítását. Az oszlop- és sávdiagramoknak nincs vonala, amely összekötné a hiányzó kategóriát, így a `Span` nem tudja előállítani a fent látható kapcsolódó szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóan, egy csak jelölőkkel rendelkező szórt diagramnak sincs összekötő vonala. Ne várjon három különböző eredményt minden diagramtípusra; ellenőrizze a kimenetet a saját típusával.

## **A sorozat hézag szélességének beállítása**

A hézag szélesség a szomszédos sáv- vagy oszlopcsoportok közti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez is a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. A [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setGapWidth)‑et egyszer kell meghívni a csoportra. Nagyobb érték több helyet hoz létre a csoportok között; kisebb érték sűrűbbé teszi őket.

Az alábbi példa módosítja a hézag szélességet, és csak a végső prezentációt menti:

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

![A hézag szélessége](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Minden, a [ChartType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/charttype/) felsorolás által képviselt diagramtípus használ diagramadatokat, de sorozataik nem mindegyike rendelkezik ugyanazzal az értékstruktúrával vagy beállításokkal. Például a kategóriadiagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket adnak hozzá. Használja a sorozattípussal megegyező adatpont‑létrehozási módszert. Az átfedés és a hézag‑szélesség opciók csak a kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több mint egy csoportot is tartalmazhat, ezért egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addChart) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti vagy törölheti a sorozat‑ és kategória‑gyűjteményeket, mielőtt teljesen egyedi adatcsoportot adna hozzá. Egy túlterhelés (overload) képes diagramot létrehozni alapértelmezett adatok nélkül is.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet celláihoz?**

A sorozatnevek, kategória címkék és adatpont értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyedi adat építésekor tartsa a kategória‑sorokat és a sorozat‑érték sorokat összehangoltan, hogy minden pont a megfelelő kategóriára legyen ábrázolva.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

A megfelelő értékcellát `None`‑ra állítsa, hogy a pont kategóriapozíciója üres pontként maradjon. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapointcollection/#clear)‑t csak akkor használja, ha az adott sorozat összes pontját el akarja távolítani. Ha kategóriákat is törli, frissítse minden sorozatot, hogy az értékek a kategória‑gyűjteménnyel szinkronban maradjanak.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setDisplayBlanksAs)‑ban konfigurált értéktől függ. A támogatott diagramok megjeleníthetik a hiányzó pontokat hézagként, nulla értékként vagy a szomszédos pontok összekapcsolásával. Válassza a beállítást, amely a hiányzó adatok jelentését a prezentációjában legjobban tükrözi. Tekintse meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt a teljes példa és vizuális összehasonlítás érdekében.

**Hogyan formázottak a negatív értékek?**

A támogatott sáv-, oszlop- és buboréksorozatok esetén hívja a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#setInvertIfNegative)‑t, és állítsa be a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) által visszaadott színt. Egy egyedi pontnál a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative)‑vel felülbírálhatja a viselkedést. Ezek a metódusok a formázásra, nem a tárolt numerikus értékekre vonatkoznak.

**Melyik formázás nyer, ha egy sorozatot és egy pontot is formáztak?**

A kifejezett adatpont‑formázás felülbírálja a sorozati formázást az adott pontnál. A többi pont továbbra a sorozat explicit formázását vagy, ha az nincs definiálva, az automatikus diagram stílust és témát használja. A csoportbeállítások, mint az átfedés és a hézag‑szélesség, az elrendezést szabályozzák, és nem pont‑szintű formázási felülbírálások.

**Van korlát arra, hogy egy diagram hány sorozatot tartalmazhat?**

Az Aspose.Slides nem alkalmaz különálló, fix sorozatszám‑korlátot. Gyakorlatban a prezentáció fájlkorlátozások, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setGapWidth)‑t a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti hézag szélesítéséhez, vagy csökkentse, hogy a csoportok közelebb kerüljenek egymáshoz.