---
title: Diagram adatsorok kezelése prezentációkban Pythonban
linktitle: Adatsorok
type: docs
url: /hu/python-net/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- kategória szín
- sorozat név
- adatpont
- sorozat rés
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, résztávolságot és negatív értékeket a prezentációkban Python segítségével."
---
## **Áttekintés**

A diagram a megjelenített adatokat egy diagramadat-munkafüzetben tárolja. A [ChartSeries](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/) egy kapcsolódó értékkészletet képvisel, és a sorozat minden [ChartDataPoint](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. Ennek eredményeként a sorozat neve, a kategóriák és a pontértékek a [ChartDataCell](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatacell/) objektumokhoz kapcsolódnak, nem csupán megjelenő szövegként tárolódnak.

Egy tipikus kategória-diagram esetén az alapértelmezett munkafüzet a 0‑s sort használja a sorozatnevekhez, a 0‑s oszlopot a kategórianévhez, a maradék cellákat pedig a sorozatértékekhez. A [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) számára átadott munkalap-, sor- és oszlopindexek nullával kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén vizsgálja meg a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például a [ChartSeries.format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/format/), a sorozat összes pontjának alapértelmezett megjelenését határozzák meg.
- Adatpontos beállítások, például a [ChartDataPoint.format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/format/), felülbírálják a sorozat megjelenését egyetlen pont esetén.
- Csoportbeállítások vonatkoznak a kompatibilis sorozatokra, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/) csoporthoz tartoznak. A csoportot a [ChartSeries.parent_series_group](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/parent_series_group/) segítségével érheti el, ha például az átfedés vagy a résztávolság beállítására van szüksége.

Ha nincs kifejezetten beállítva pont- vagy sorozatkitöltés, a diagramstílus és a téma határozza meg a automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása felülírja a sorozatét.

![diagram-sorozat-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozatának átfedésének beállítása**

A [ChartSeries.overlap](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/overlap/) megadja, hogy a sávok vagy oszlopok milyen mértékben fedik át egymást egy 2D diagramon, -100‑tól 100 %-ig. Ez a beállítás csak a szülő sorozatcsoport beállításának csak‑olvasású leképezése. A [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/overlap/) beállításával frissítheti a csoport összes kompatibilis sorozatát. Ez a lehetőség olyan diagramtípusokra vonatkozik, amelyek csoportosított sávokat vagy oszlopokat jelenítenek meg; nem befolyásolja a kombinált diagramok nem kapcsolódó sorozatcsoportjait.

Az alábbi példában beállítja az átfedést arra a csoportra, amelyik az első sorozatot tartalmazza:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Az új diagram mintasorozatokat, kategóriákat és értékeket tartalmaz.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A sorozat átfedése](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

A [ChartSeries.format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/format/) segítségével állíthatja be egy teljes sorozat alapértelmezett kitöltését. Ha egy pont már rendelkezik kifejezett kitöltéssel, a [ChartDataPoint.format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/format/) beállítása felülbírálja a sorozat kitöltését az adott pontnál.

Az alábbi példa egy szilárd kék kitöltést alkalmaz az első sorozatra:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A sorozat színe](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagram adat-munkafüzetben van tárolva, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben, amely a csoportosított oszlopdiagramhoz jön létre, a B1 cella (0‑s sor, 1‑s oszlop) tartalmazza az első sorozat nevét. Az alábbi példában szereplő névkonstansok egyértelművé teszik ezt a struktúrát:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

A cellát közvetlenül a [ChartSeries.name](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/name/) segítségével is frissítheti. Ez a megközelítés elkerüli, hogy egy adott sor és oszlop feltételezésére építsen egy meglévő diagramban:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A sorozat neve](series_name.png)

## **Az automatikus sorozat színének lekérése**

A [ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) visszaadja a sorozatindexből és a diagramstílusból kiszámított színt. Ez a szín akkor kerül felhasználásra, ha a sorozat kitöltése nincs kifejezetten meghatározva. A metódus csak a kiszámított színt olvassa, nem állít be új kitöltést.

Az alábbi példa kiírja minden alapértelmezett sorozat automatikus színét:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Példa kimenet az alapértelmezett diagramstílushoz:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagramstílustól és a témától függenek.

## **Inverz kitöltőszín beállítása egy diagram sorozathoz**

Sáv‑, oszlop‑ és buborék‑sorozatok esetén a [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/invert_if_negative/) képes negatív értékeket külön kitöltéssel megjeleníteni. Állítsa be a szabályos sorozat kitöltését szilárd színre, engedélyezze az inverziót, és adja meg a negatív értékek színét a [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) használatával. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példában az alapértelmezett diagramadatot egy sorozatra cseréli. Az 0‑s munkalap sorában a sorozat neve, az 0‑s oszlopban a kategórianevek, az 1‑s oszlopban pedig az értékek találhatók:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az inverz szilárd kitöltőszín](inverted_solid_fill_color.png)

Egyetlen pont inverzióját a [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) segítségével engedélyezheti. Az alábbi példában a sorozatra vonatkozó inverzió le van tiltva, csak a kiválasztott pontnál van engedélyezve. A pont negatív értéket is kap, hogy a hatás látható legyen:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Egy konkrét adatpont értékének törlése**

Egy pont üresre állításához a többi pontot érintés nélkül, állítsa annak háttércelláját `None`‑ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.value](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/value/) segítségével érhető el. Az adatpont a kategória pozíciójában marad, de a diagram a értékét üresnek tekinti a diagram üres‑érték beállításai szerint.

Az alábbi példa csak a második pontot törli az első sorozatban:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

A szórt diagramok külön X és Y cellákat használnak, a buborék diagramok pedig egy méretcellát is. Törölje csak azt a cellát, amely a törölni kívánt értéket tartalmazza. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metódust, ha a többi pontot meg akarja tartani, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Üres cellák megjelenésének vezérlése**

Egy üres munkafüzetcella hiányzó adatot jelent; egy `0`‑t tartalmazó cella ismert numerikus értéket jelent. Állítsa a [ChartDataCell.value](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatacell/value/)‑t `None`‑ra, hogy a cella üres legyen. A numerikus nulla továbbra is nulla marad, függetlenül az üres‑cella beállítástól.

A [Chart.display_blanks_as](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/display_blanks_as/) segítségével választhatja ki, hogy a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja, hogy a hiányzó értékek hogyan kerülnek ábrázolásra, anélkül, hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy sorozatot tartalmazó vonaldiagramot hoz létre, a 3. nap értékét törli, és minden módot külön fájlba ment. Bemeneti fájlra nincs szükség. A [ChartDataWorkbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/) a 0‑s munkalapot, 0‑s oszlopot a kategóriacímkékhez, 1‑s oszlopot az értékekhez használja; a 0‑s sor a sorozat nevét tartalmazza. A végső adatsor `10, 20, empty, 30, 40`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Hagyja a 3. napot valóban üresen, miközben megtartja a kategóriáját és az adatpontot.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Minden kimeneti fájl a mentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: A Gap mód szüneteli a vonalat a 3. napon, a Zero mód a vonalat nullára vágja, a Span mód összeköti a 2. és 4. napot.](display_blanks_as.png)

A látható hatás a diagramtípustól függ. A vonaldiagram három mód esetén is könnyen összehasonlítható. A sáv‑ és oszlopdiagramok esetén nincs vonal, amely összekötné a hiányzó kategóriát, így a `SPAN` nem hozhat létre összekötő szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen a csak jelölőkkel rendelkező szórt diagramnak nincs kapcsolódó vonala. Ne várjon három különálló eredményt minden diagramtípusnál; ellenőrizze a kimenetet a saját típusában.

## **A sorozat résztávolságának beállítása**

A résztávolság a szomszédos sáv‑ vagy oszlopcsoportok közötti térközt jelenti, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez is a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. A [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) egyszeri beállításával a teljes csoportra vonatkozik. A nagyobb érték több helyet hoz létre a csoportok között; a kisebb érték sűrűbb elrendezést eredményez.

Az alábbi példa módosítja a résztávolságot, és csak a végső prezentációt menti:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A résztávolság](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat-sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/charttype/) felsorolással definiált diagramtípus használ diagramadatot, de a sorozataik nem mindegyiknek ugyanaz a struktúrája vagy beállításai. Például a kategóriadiagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket. A sorozattípusnak megfelelő adatpontos létrehozási metódust kell alkalmazni. Az olyan opciók, mint az átfedés és a résztávolság, csak a kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Egy frissen létrehozott diagram tartalmaz-e alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.add_chart](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_chart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy törölheti a sorozat‑ és kategória‑gyűjteményeket, mielőtt saját adatkészletet adna hozzá. Egy túlterhelés (overload) segítségével alapértelmezett adatok nélkül is létrehozható diagram.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategóriacímkék és adatpont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatok építésekor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat összehangoltan, hogy minden pont a kívánt kategória alá legyen ábrázolva.

**Hogyan töröljek egy pontot anélkül, hogy az egész sorozatot törölném?**

Állítsa a megfelelő értékcellát `None`‑ra, így a pont a kategóriapozícióját megtartja üres pontként. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metódust csak akkor használja, ha az adott sorozat minden pontját el akarja távolítani. Ha a kategóriákat is eltávolítja, frissítse az összes sorozatot, hogy az értékek a kategória‑gyűjteménnyel összhangban maradjanak.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [Chart.display_blanks_as](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/display_blanks_as/) beállítástól függ. A támogatott diagramok megjeleníthetik az üreseket hézagként, nulla‑értékként vagy a szomszédos pontok összekötésével. Válassza ki azt a beállítást, amely a hiányzó adatok jelentésének leginkább megfelel a prezentációjában. Tekintse meg a **Üres cellák megjelenésének vezérlése** szakaszt a teljes példa és vizuális összehasonlítás érdekében.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv‑, oszlop‑ és buborék‑sorozatok esetén engedélyezze a [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/invert_if_negative/) lehetőséget, és állítsa be a [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)‑t. Egy egyedi pont viselkedését a [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) segítségével felülbírálhatja. Ezek a tulajdonságok a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha a sorozat és a pont is formázott?**

Az explicit adatpont‑formázás felülírja a sorozat formázását az adott pontnál. A többi pont továbbra is az explicit sorozatformátumot vagy, ha az nincs definiálva, az automatikus diagramstílust és témát használja. A csoport‑tulajdonságok, mint az átfedés és a résztávolság, elrendezési beállítások, nem pont‑szintű formázási felülírások.

**Van korlát arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem tartalmaz külön, fix sorozatszám‑korlátot. Gyakorlatban a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit változtassak, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Állítsa be a [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)‑t a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közötti távolság növeléséhez, vagy csökkentse, ha a csoportok közelebb szeretné kerülni egymáshoz.