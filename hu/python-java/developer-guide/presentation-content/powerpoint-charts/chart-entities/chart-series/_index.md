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
- sorozat rés
- negatív érték
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhetők a diagram sorozatok, adatpontok, munkafüzet cellák, formázás, átfedés, részsávszélesség és negatív értékek a prezentációkban az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Egy diagram az ábrázolt adatokat egy diagramadat-munkafüzetben tárolja. Egy [ChartSeries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/) egy kapcsolódó értékhalmazt képvisel, és a sorozat minden [ChartDataPoint](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, kategóriái és pontértékei ezért [ChartDataCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/) objektumokhoz kapcsolódnak, nemcsak megjelenítési szövegként tárolódnak.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0. sorban tárolja a sorozatneveket, az 0. oszlopban a kategórianéveket, a többi cella pedig a sorozatértékeket. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#getCell) számára megadott munkalap-, sor- és oszlindexek nullával kezdődnek. Ez a felépítés akkor hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagram beállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getFormat) alapértelmezett megjelenést ad minden pontnak egy sorozaton belül.
- Adatpont beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getFormat) felülírja a sorozat megjelenését egy adott pontnál.
- Csoport beállítások kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getParentSeriesGroup) segítségével érheti el, ha például átfedés vagy részsáv szélesség beállítására van szükség.

Ha nincs kifejezetten megadva pont- vagy sorozattöltés, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása élvez elsőbbséget az adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozatának átfedésének beállítása**

A [ChartSeries.getOverlap](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getOverlap) megadja, hogy a 2D diagramban a sávok vagy oszlopok mennyire fedik egymást, -100 és 100 százalék között. Ez egy csak olvasható leképezés a beállításra a szülő sorozatcsoportban. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setOverlap) használatával frissítheti az adott csoport minden kompatibilis sorozatát. Ez az opció az összevont sávok vagy oszlopok megjelenítését támogató diagramtípusokra vonatkozik; nem befolyásolja a kombinált diagram nem kapcsolódó sorozatcsoportjait.

A következő példa beállítja az átfedést arra a csoportra, amelyik az első sorozatot tartalmazza:

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

![A sorozat átfedése](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

A [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getFormat) segítségével állítható be az egész sorozatra vonatkozó alapértelmezett kitöltés. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülírja a sorozat kitöltését az adott pontnál.

A következő példa szilárd kék kitöltést alkalmaz az első sorozatra:

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

A sorozat neve a diagramadat-munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzet egy halmozott oszlopdiagramhoz a B1 cella (0. sor, 1. oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a változónevek ezt a struktúrát teszik egyértelművé:

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

A cellát, amelyre a [ChartSeries.getName](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getName) már hivatkozik, közvetlenül is frissítheti. Ez a megközelítés nem tesz fel feltételezést egy adott sorra vagy oszlopra egy meglévő diagramon:

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

## **Az automatikus sorozatkitöltő szín lekérdezése**

A [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) visszaadja a sorozatindex alapján és a diagramstílusból számított színt. Ez a szín akkor használatos, amikor a sorozat kitöltése nincs kifejezetten meghatározva. A metódus meghívása csak a számított színt olvassa; nem rendeli hozzá új kitöltést.

A következő példa kiírja az alapértelmezett sorozatok automatikus színét:

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

A pontos színek a diagramstílustól és a témától függenek.

## **Invertált kitöltőszín beállítása egy diagram sorozathoz**

Sáv-, oszlop- és buboréksorozatok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#setInvertIfNegative) lehetővé teszi, hogy a negatív értékek más kitöltéssel jelenjenek meg. Állítsa be a szabályos sorozat kitöltését szilárdra, engedélyezze az invertert, és adja meg a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenési színük módosul.

A következő példa az alapértelmezett diagramadatot egy sorozatra cseréli. A munkalap 0. sorában a sorozat neve, az 0. oszlopban a kategória nevek, az 1. oszlopban pedig az értékek szerepelnek:

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

Invertert egy pontnál a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) segítségével is engedélyezheti. Az alábbi példában az invertert a sorozatra letiltották, csak a kiválasztott pontnál engedélyezték. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

Egy pont üresre állításához a többi pont megtartása mellett állítsa a mögöttes munkafüzetcellát `None`-ra. Oszlopdiagram esetén a ábrázolt érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getValue) segítségével érhető el. Az adatpont ugyanazon kategóriahelyen marad, de a diagram a beállított „blank-value” beállítás szerint üresként kezeli az értéket.

A következő példa csak a második pontot törli az első sorozatban:

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

Szétszórt diagramok külön X és Y cellákat használnak, a buborékdiagramok pedig egy méretcellát is. Törölje csak azt a cellát, amelyik az eltávolítandó értéket tartalmazza. Ne hívja meg a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapointcollection/#clear) metódust, ha a többi pontot meg akarja tartani, mivel ez a metódus minden adatpontot eltávolít a gyűjteményből.

## **A sorozat részsávszélességének beállítása**

A részsávszélesség a szomszédos sáv- vagy oszlopcsoportok közötti távolságot jelenti, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a beállítás a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setGapWidth) a csoportra. Nagyobb érték több helyet hoz létre a csoportok között, kisebb érték sűrűbbé teszi őket.

A következő példa megváltoztatja a részsávszélességet, és csak a végleges prezentációt menti:

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

![A részsávszélesség](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagramadatokat, de sorozataik nem mindegyiknek ugyanaz a értékstruktúrája vagy beállításai. Például a kategória diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborékdiagramok pedig buborékméreteket. Használja az adatpont‑létrehozó metódust, amely megfelel a sorozat típusának. Az olyan opciók, mint az átfedés és a részsávszélesség, csak a kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addChart) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy törölheti a sorozat‑ és kategóriagyűjteményeket, mielőtt teljesen egyéni adatkészletet adna hozzá. Egy túlterhelés segítségével diagramot hozhat létre alapértelmezett adatok nélkül is.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategóriacímkék és adatpont‑értékek olyan cellákra hivatkoznak, amelyek egy [ChartDataWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/) részei. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatok építésekor tartsa a kategóriasorokat és a sorozat‑érték sorokat összehangoltan, hogy minden pont a megfelelő kategória alatt legyen ábrázolva.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `None`-ra, hogy a pont kategóriahelye üres pontként maradjon. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapointcollection/#clear) metódust csak akkor használja, ha a sorozat összes pontját el akarja távolítani. Ha a kategóriákat is törli, frissítse minden sorozatot, hogy értékeik továbbra is igazodjanak a kategóriagyűjteményhez.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setDisplayBlanksAs) beállítástól függ. A támogatott diagramok megjeleníthetik az üresek helyét hézagként, nullaként, vagy a szomszédos pontok összekapcsolásával. Válassza azt a beállítást, amely a hiányzó adatok jelentésének leginkább megfelel a prezentációjában.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv‑, oszlop‑ és buborék‑sorozatok esetén hívja meg a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#setInvertIfNegative) metódust, és állítsa be a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) által visszaadott színt. Egyedi pontnál a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) felülírhatja a viselkedést. Ezek a metódusok a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha mind a sorozat, mind a pont formázva van?**

Az explicit adatpont‑formázás előnyt élvez az adott pontnál. A többi pont továbbra is az explicit sorozat‑formázást, vagy ha az nincs definiálva, a automatikus diagramstílust és témát használja. A csoportszintű beállítások, mint az átfedés és a részsávszélesség, az elrendezést szabályozzák, és nem pontszintű formázási felülírások.

**Van korlát arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem szab elő különálló, rögzített sorozatszám‑korlátot. Gyakorlatban a prezentációfájl mérete, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a használható határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setGapWidth) megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közötti tér növeléséhez, vagy csökkentse, ha közelebb akarja hozni őket.