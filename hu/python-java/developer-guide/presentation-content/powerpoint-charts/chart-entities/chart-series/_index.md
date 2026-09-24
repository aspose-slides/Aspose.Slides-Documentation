---
title: Diagram adatsorozatok kezelése prezentációkban Pythonban
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
description: "Ismerje meg, hogyan kezelje a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket a prezentációkban az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

A diagram a megjelenített adatait egy diagramadat-munkafüzetben tárolja. A [ChartSeries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/) egy kapcsolódó értékekből álló halmazt képvisel, és a sorozatban lévő egyes [ChartDataPoint](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosító értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [ChartDataCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenítési szövegként tárolják őket.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0. sorban a sorozatneveket, a 0. oszlopban a kategórianéveket és a többi cellában a sorozatértékeket használja. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#getCell) metódusnak átadott munkalap, sor és oszlop indexek nullával kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adattal hoz létre diagramot, de ne feltételezze, hogy minden létező diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit megváltoztatná.

A diagram beállításai három különböző hatókörbe sorolhatók:

- Sorozatszintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getFormat) alapértelmezett megjelenését biztosítják egy sorozat összes pontjának.
- Adatpont-szintű beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getFormat) felülírják a sorozat megjelenését egyetlen pontnál.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getParentSeriesGroup) segítségével érheti el, ha például átfedés vagy hézag szélesség opciókat kell beállítania.

Ha nincs kifejezett pont- vagy sorozatkitöltés beállítva, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása elsőbbséget élvez az adott pontnál.

![diagram-sorozat-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

A [ChartSeries.getOverlap](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getOverlap) azt jelzi, hogy a sávok vagy oszlopok milyen mértékben fednek át egy 2D-diagramon, -100‑tól 100‑ig terjedő százalékban. Ez a szülő sorozatcsoport beállításának csak olvasható vetülete. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setOverlap) segítségével frissítheti a csoport összes kompatibilis sorozatát. Ez a lehetőség azoknál a diagramtípusoknál alkalmazandó, amelyek csoportosított sávokat vagy oszlopokat jelenítenek meg; nem érintődik a kombinált diagramok nem kapcsolódó sorozatcsoportjait.

Az alábbi példa beállítja az átfedést annak a csoportnak, amely az első sorozatot tartalmazza:

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

A [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getFormat) segítségével állíthatja be az egész sorozat alapértelmezett kitöltését. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülírja a sorozat kitöltését az adott pontnál.

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

A sorozat neve a diagram adatmunkafüzetben tárolódik, és általában a legendában jelenik meg. Az alapértelmezett munkafüzetben, amely egy klaszterezett oszlopdiagramhoz jön létre, a B1 cella a 0. sor, 1. oszlop helyén tartalmazza az első sorozat nevét. Az alábbi példában a névvel ellátott változók egyértelműen feltüntetik ezt a struktúrát:

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

A cellát közvetlenül a [ChartSeries.getName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getName) hivatkozza. Ezzel a megközelítéssel elkerülhető egy adott sor és oszlop feltételezése egy már létező diagramban:

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

A [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor használatos, ha a sorozat kitöltése nincs kifejezetten meghatározva. A metódus meghívása csak a számított színt olvassa; új kitöltést nem rendel hozzá.

Az alábbi példa kiírja az alapértelmezett sorozatok automatikus színét:

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

Az alapértelmezett diagramstílus példakimenete:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagram stílusától és témájától függenek.

## **Invertáló kitöltőszín beállítása egy diagram sorozathoz**

Sáv-, oszlop- és buborék-sorozatoknál a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#setInvertIfNegative) negatív értékeket külön kitöltéssel jeleníthet meg. Állítsa be a szabályos sorozat kitöltését szilárdra, engedélyezze az inverterítést, és adja meg a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa egy sorozattal helyettesíti az alapértelmezett diagram adatokat. A munkalap 0‑án a sorozatnév a sor 0‑ban, a kategória nevek az oszlop 0‑ban, az értékek pedig az oszlop 1‑ben találhatók:

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

Az inverterítést egy pontnál a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) segítségével engedélyezheti. Az alábbi példában az inverterítást a sorozatra letiltják, és csak a kiválasztott pontnál engedélyezik. A pontnak negatív értéket is adnak, hogy a hatás látható legyen:

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

Annak érdekében, hogy egy pont üres maradjon a többi pont eltávolítása nélkül, állítsa a mögöttes munkafüzetcellát `None`‑ra. Oszlopdiagramnél a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getValue) segítségével érhető el. Az adatpont a kategória ugyanazon pozíciójában marad, de a diagram a értékét üresnek kezeli a diagram üres‑érték beállításai szerint.

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

A szórásdiagramok külön X és Y cellákat használnak, a buborékdiagramok pedig méretcellát is. Törölje csak azt a cellát, amely a törlendő értéket tartalmazza. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapointcollection/#clear) metódust, ha a többi pontot meg szeretné tartani, mert ez a metódus minden adatpontot eltávolít a gyűjteményből.

## **Üres cellák megjelenítésének vezérlése**

Egy üres munkafüzetcellát hiányzó adatként értelmez a diagram; egy `0` értékű cella ismert numerikus értéket jelent. A [ChartDataCell.setValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#setValue) metódussal `None`‑t adva a cellának, üres lesz. Egy numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellát beállító opciótól.

A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setDisplayBlanksAs) segítségével választhatja ki, hogyan jelenjenek meg az üres cellák. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja, hogyan ábrázolják a hiányzó adatokat anélkül, hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3. nap értékét, és minden módot külön fájlba ment. Bemeneti fájlra nincs szükség. A [ChartDataWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/) a 0‑ás munkalapot, az 0‑ás oszlopot használja a kategóriacímkékhez, az 1‑es oszlopot az értékekhez; a 0‑ás sor tartalmazza a sorozat nevét. A végső adatsor: `10, 20, empty, 30, 40`.

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

    # Hagyja a 3. napot valóban üresen, miközben megtartja a kategóriáját és az adatpontot.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Minden kimeneti fájl a mentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás mindhárom fájlban azonos adatot mutat. A 3. nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: Gap szaggatja a vonalat a 3. napnál, Zero leejti a vonalat nullára, és Span összeköti a 2. napot a 4.-gyel.](display_blanks_as.png)

A látható hatás a diagram típusától függ. Egy vonaldiagram esetén könnyen összehasonlítható mindhárom mód. Sáv- és oszlopdiagramok esetén nincs vonal a hiányzó kategória áthidalására, így a `Span` nem tud egyesíteni; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen egy szórásdiagram csak jelölőkkel szintén nem rendelkezik összekötő vonallal. Ne számítson három különböző eredményre minden diagramtípusnál; ellenőrizze a kimenetet a saját típusához.

## **A sorozat hézag szélességének beállítása**

A hézag szélesség a szomszédos sáv- vagy oszlopklaszterek közötti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a beállítás a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust egyszer a csoporton. A nagyobb érték több helyet hoz létre a klaszterek között; a kisebb érték szorosabbá teszi őket.

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

![A hézag szélessége](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Minden, a [ChartType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/charttype/) felsoroló által képviselt diagramtípus használ diagramadatot, de sorozataik nem mindegyiknek ugyanaz a értékstruktúrája vagy beállítása. Például a kategória diagramok kategóriákat és értékeket, a szórás diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket használnak. Az adatpont létrehozási módszert a sorozattípusnak megfelelően kell választani. Az átfedés és hézag szélesség opciók csak kompatibilis sáv- vagy oszloptáblákra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtat minden sorozaton a diagramon.

**Egy újonnan létrehozott diagram tartalmaz alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addChart) minta sorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti vagy törölheti a sorozat- és kategória-gyűjteményeket, mielőtt teljesen egyedi adatkészletet adna meg. Egy túlterheléskelletel diagramot is létrehozhat alapértelmezett adat nélkül.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategóriacímkék és adatpontértékek a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása a megfelelő diagramelemet frissíti. Egyedi adatok építésekor tartsa a kategória sorokat és a sorozat‑érték sorokat összehangoltan, hogy minden pont a megfelelő kategória alatt legyen ábrázolva.

**Hogyan törthetem egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `None`‑ra, hogy a pont kategória pozíciója üres pontként maradjon. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapointcollection/#clear) metódust csak akkor használja, ha minden pontot el akar távolítani az adott sorozatból. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek továbbra is szinkronban legyenek a kategória‑gyűjteménnyel.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setDisplayBlanksAs) által konfigurált értéktől függ. A támogatott diagramok üres helyeket jeleníthetnek meg hézagként, nullaként vagy a szomszédos pontok összekapcsolásával. Válassza ki a beállítást, amely a hiányzó adatok jelentését tükrözi az Ön prezentációjában. Lásd a **Üres cellák megjelenítésének vezérlése** részt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv-, oszlop- és buborék‑sorozatoknál hívja meg a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#setInvertIfNegative) metódust, és állítsa be a színt a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) által visszaadott értékkel. Egy egyedi pontnál a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) segítségével felülbírálhatja a viselkedést. Ezek a metódusok a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha a sorozat és a pont is formázva van?**

Az explicit adatpont‑formázás elsőbbséget élvez az adott pontnál. A többi pont továbbra is használja a kifejezett sorozat‑formátumot, vagy ha a sorozat formátuma nincs definiálva, akkor az automatikus diagramstílus és téma beállításait. A csoportbeállítások, mint az átfedés és hézag szélesség, a elrendezésre vonatkoznak, és nem felülírják a pont‑szintű formázást.

**Van korlát arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem alkalmaz különálló, rögzített sorozatszám‑korlátot. Gyakorlatban a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a használható felső határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl messze vannak egymástól?**

Hívja meg a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a klaszterek közötti tér szélesítéséhez, vagy csökkentse, ha a klasztereket közelebb szeretné hozni.