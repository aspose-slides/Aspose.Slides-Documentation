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
description: "Ismerje meg, hogyan kezelje a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, rés szélességet és negatív értékeket a prezentációkban Python segítségével."
---
## **Áttekintés**

A diagram a megjelenített adatokat egy diagram adat munkafüzetben tárolja. Egy [ChartSeries](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/) egy kapcsolódó értékcsoportot képvisel, és a sorozat minden [ChartDataPoint](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [ChartDataCell](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenő szövegként tárolódnak.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0‑s sort használja a sorozatneveknek, a 0‑s oszlopot a kategórianévnek, a maradék cellákat pedig a sorozatértékeknek. A [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) számára átadott munkalap, sor és oszlop indexek nulláral kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hozunk létre diagramot, de nem szabad azt feltételezni, hogy minden létező diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozat, a kategóriák és az adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagram beállításai három különböző hatókörben léteznek:

- Sorozatszintű beállítások, például a [ChartSeries.format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/format/), amely az adott sorozat összes pontjának alapértelmezett megjelenését adja meg.
- Adatpont szintű beállítások, például a [ChartDataPoint.format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/format/), mely felülírja a sorozat megjelenését egy adott pontnál.
- Csoport beállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.parent_series_group](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/parent_series_group/) segítségével érheti el, amikor olyan beállításokat kell megadnia, mint az átfedés vagy a rés szélessége.

Ha nincs kifejezetten megadva pont- vagy sorozatterület kitöltés, a diagram stílusa és témája határozza meg a automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása él az adott pontra nézve.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

A [ChartSeries.overlap](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/overlap/) megadja, hogy a sávok vagy oszlopok mekkora fokban fednek át egy 2D diagramon, -100 és 100 százalék között. Ez egy csak olvasható leképezése a szülő sorozatcsoport beállításának. Állítsa be a [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/overlap/) értékét, hogy frissítse az adott csoport minden kompatibilis sorozatát. Ez a beállítás olyan diagramtípusokra vonatkozik, amelyek csoportosított sávokat vagy oszlopokat jelenítenek meg; kombinált diagram esetén a nem kapcsolódó sorozatcsoportokat nem érinti.

Az alábbi példa beállítja az átfedést az első sorozatot tartalmazó csoportra:

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

![The series overlap](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

Használja a [ChartSeries.format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/format/) metódust az egész sorozatra vonatkozó alapértelmezett kitöltés beállításához. Ha egy pont már rendelkezik explicit kitöltéssel, a [ChartDataPoint.format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/format/) beállítása felülírja a sorozat kitöltését az adott pontnál.

Az alábbi példa szilárd kék kitöltést alkalmaz az első sorozatra:

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

![The color of the series](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagram adat munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben, amely egy csoportosított oszlopdiagramhoz jön létre, a B1 cella (0‑s sor, 1‑s oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a névkonstansok ezt a struktúrát teszik egyértelművé:

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

Frissítheti azt a cellát is, amelyre a [ChartSeries.name](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/name/) már hivatkozik. Ez a megközelítés elkerüli a konkrét sor és oszlop feltételezését egy meglévő diagram esetén:

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

![The series name](series_name.png)

## **Az automatikus sorozat szín lekérése**

A [ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín az, amelyik akkor használatos, ha a sorozat kitöltése nincs kifejezetten definiálva. A metódus hívása csak a számított színt adja vissza; nem állít be új kitöltést.

Az alábbi példa kiírja az alapértelmezett sorozatok automatikus színét:

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

Példa kimenet az alapértelmezett diagram stílusra:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagram stílusától és témájától függenek.

## **Invertált kitöltőszín beállítása egy diagram sorozathoz**

Sáv-, oszlop- és buborék sorozatok esetén a [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/invert_if_negative/) lehetővé teszi, hogy a negatív értékek másik kitöltéssel jelenjenek meg. Állítsa be a normál sorozat kitöltését szilárdra, engedélyezze az invertálást, és adja meg a negatív érték színét a [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) segítségével. A munkafüzetben a negatív számok változatlanok maradnak; csak a megjelenítés színe változik.

Az alábbi példa az alapértelmezett diagram adatot egy sorozatra cseréli. A 0‑s sor tartalmazza a sorozat nevét, az 0‑s oszlop a kategórianéveket, az 1‑s oszlop pedig az értékeket:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

A negatív érték invertálását egy pontnál a [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) segítségével is engedélyezheti. Az alábbi példában a sorozatra vonatkozó invertálás ki van kapcsolva, a kiválasztott pontnál pedig be van kapcsolva, amelynek negatív értéket is adunk a hatás láthatóságához:

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

Egy pont üresen hagyásához, a többi pontot megőrizve, állítsa a mögöttes munkafüzet cellát `None`-ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.value](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/value/) segítségével érhető el. Az adatpont a ugyanazon kategória pozíciójában marad, de a diagram a értékét üresként kezeli a diagram üres-érték beállításai szerint.

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

A szórt diagramok külön X és Y cellákat használnak, a buborék diagramok pedig egy méret cellát is. Törölje csak azt a cellát, amely a törlendő értéket tartalmazza. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metódust, ha a többi pontot meg szeretné tartani, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenítésének szabályozása**

A rejtett cellák, amelyek értéket tartalmaznak, külön esetet képeznek az üres celláktól. A rejtett munkalap sorok és oszlopok adatainak fel- vagy letiltásához tekintse meg a [Include Data from Hidden Rows and Columns](/slides/hu/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) cikket.

Egy üres munkafüzetcellát hiányzó adatokként kezelünk; egy `0` értékű cella ismert numerikus értéket jelent. Állítsa a [ChartDataCell.value](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatacell/value/) értékét `None`-ra, hogy a cella üres legyen. Egy numerikus nulla marad nulla függetlenül az üres-cellát beállító opciótól.

Használja a [Chart.display_blanks_as](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/display_blanks_as/) beállítást a diagram üres cellák megjelenítési módjának kiválasztásához. Ez a beállítás a teljes diagramra vonatkozik, és anélkül módosítja a grafikon adatpontjait, hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3. nap értékét törli, majd a diagramot minden mód szerint elmenti. Nem szükséges bemeneti fájl. A [ChartDataWorkbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/) a 0‑s munkalapot, a 0‑s oszlopot használja a kategória címkéknek, az 1‑s oszlopot az értékeknek; a 0‑s sor tartalmazza a sorozat nevét. A végső adatsor: `10, 20, empty, 30, 40`.

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

    # Hagyja a 3. napot valóban üresen, miközben megtartja a kategóriáját és az adatpontját.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy változatot akar menteni, állítsa be a kívánt módot, és mentse a prezentációt egyszer a módok sorozatos iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap a munkafüzetben minden esetben üres:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagram típusától függ. Egy vonaldiagram esetén mindhárom mód könnyen összehasonlítható. Sáv- és oszlopdiagramok esetén nincs vonal a hiányzó kategória összekapcsolásához, így a `SPAN` nem hozhat létre kapcsolódó szegmenst, ahogy a fenti ábrán látható; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen a pontokkal csak markerrel rendelkező szórt diagramnak sincs összekötő vonala. Nem minden diagramtípus esetén kell három különálló eredményt várni; ellenőrizze a kimenetet a saját diagramtípusán.

## **A sorozat rés-szélességének beállítása**

A rés-szélesség a szomszédos sáv- vagy oszlopcsoportok közötti távolságot jelenti, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Állítsa be a [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) értékét egyszer a csoportra. Nagyobb érték szélesebb réset hoz létre a csoportok között; kisebb érték sűrűbbé teszi őket.

Az alábbi példa módosítja a rés-szélességet, és csak a végső prezentációt menti:

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

![The gap width](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/charttype/) felsorolásban szereplő diagramtípus használ diagram adatot, de sorozataik nem mindegyiknek ugyanaz a struktúrája vagy beállításai. Például a kategória diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig a buborék méreteket. Használja azt az adatpont‑létrehozó módszert, amely a sorozat típusához illeszkedik. Az átfedés és a rés-szélesség csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkozik.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/) olyan kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű megjelenítési beállításokkal rendelkeznek. Egy kombinált diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.add_chart](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_chart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy törölheti a sorozat‑ és kategória‑gyűjteményeket, mielőtt teljesen egyedi adatot adna hozzá. Egy overload segítségével diagramot is létrehozhat alapértelmezett adat nélkül.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, a kategória címkék és az adatpont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyedi adat létrehozásakor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat igazítva, hogy minden pont a kívánt kategória alá kerüljön.

**Hogyan törölhetek egyetlen pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `None`‑ra, hogy a pont kategória‑pozíciója üres pontként maradjon. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metódust csak akkor használja, ha az adott sorozat összes pontját el szeretné távolítani. Ha a kategóriákat is törli, frissítse minden sorozatot, hogy az értékek továbbra is összehangoltak legyenek a kategória‑gyűjteménnyel.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [Chart.display_blanks_as](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/display_blanks_as/) beállítástól függ. A támogatott diagramok üresek megjeleníthetők részként, nulla értékként vagy a szomszédos pontok összekapcsolásával. Válassza azt a beállítást, amely a hiányzó adatok jelentését tükrözi a prezentációjában. A teljes példa és vizuális összehasonlításért tekintse meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv‑, oszlop‑ és buborék sorozatok esetén engedélyezze a [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/invert_if_negative/) beállítást, és adja meg a [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) színét. Egy adott pont viselkedését felülírhatja a [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) segítségével. Ezek a tulajdonságok a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha a sorozat és a pont is formázva van?**

A kifejezett adatpont‑formázás él az adott pontnál. A többi pont a kifejezett sorozatformázást vagy, ha az nincs definiálva, a automatikus diagramstílust és témát használja. A csoport‑szintű tulajdonságok, mint az átfedés és a rés‑szélesség, a elrendezést szabályozzák, és nem felülírják a pont‑szintű formázást.

**Van korlát arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem határoz meg különálló fix sorozatszám‑korlátot. A gyakorlatban a prezentáció fájlmérete, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos határt.

**Mit kell változtatni, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Állítsa be a [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) értékét a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közötti távolság növeléséhez, vagy csökkentse, ha közelebb szeretné őket hozni.