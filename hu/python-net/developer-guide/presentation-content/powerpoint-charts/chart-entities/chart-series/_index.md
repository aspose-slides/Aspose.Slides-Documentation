---
title: Diagram adat sorozatok kezelése prezentációkban Pythonban
linktitle: Adatsorozatok
type: docs
url: /hu/python-net/chart-series/
keywords:
- diagram sorozat
- sorozat átfedése
- sorozat színe
- kategória színe
- sorozat neve
- adatpont
- sorozat hézag
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban Python segítségével."
---
## **Áttekintés**

Egy diagram a ábrázolt adatokat egy diagramadat-munkafüzetben tárolja. Egy [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) egy kapcsolódó értékcsoportot képvisel, és a sorozatban lévő minden [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) objektumok biztosítják a sorozatok által megosztott címkéket vagy csoportosító értékeket. Így a sorozat neve, a kategóriák és a pontértékek a [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenő szövegként tárolódnak.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatneveknek, a 0. oszlopot a kategórianévnek, a többi cellát pedig a sorozatértékeknek. A [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) számára megadott munkalap, sor és oszlop indexek nullával kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hozunk létre egy diagramot, de ne feltételezzük, hogy minden létező diagram ezt használja. Betöltött prezentáció esetén vizsgáld meg a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzetértékeket módosítanád.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például a [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) adja meg az alapértelmezett megjelenést az összes pont számára egy sorozatban.
- Adatpont szintű beállítások, például a [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) felülírják a sorozat megjelenését egyetlen pont esetén.
- Csoportbeállítások alkalmazhatók azokra a kompatibilis sorozatokra, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) tartoznak. A csoporthoz a [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) használatával férhetsz hozzá, ha például átfedés vagy részsáv szélesség beállítására van szükség.

Ha nincs kifejezetten beállítva pont- vagy sorozatkitöltés, a diagramstílus és a téma határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása előnyben részesül az adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) azt jelzi, hogy a sávok vagy oszlopok mennyire fednek át egy 2D diagramon, -100 és 100 százalék között. Ez csak olvasható leképezése a beállításnak a szülő sorozatcsoporton. A [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) beállításával frissítheted a csoportban lévő minden kompatibilis sorozatot. Ez az opció olyan diagramtípusokra vonatkozik, amelyek csoportosított sávokat vagy oszlopokat jelenítenek meg; nem befolyásolja a kombinált diagram nem kapcsolódó sorozatcsoportjait.

A következő példa beállítja az átfedést arra a csoportra, amelyik az első sorozatot tartalmazza:

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

## **A sorozat kitöltőszín megváltoztatása**

Használd a [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) metódust az egész sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) beállítása felülírja a sorozat kitöltését az adott pontnál.

A következő példa egy szilárd kék kitöltést alkalmaz az első sorozatra:

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

## **A sorozat nevének megváltoztatása**

A sorozat neve a diagram adatmunkafüzetében tárolódik, és általában a jelmagyarázatban jelenik meg. Alapértelmezett munkafüzetben egy klaszteres oszlopdiagram esetén a B1 cella a 0. sor, 1. oszlop helyén a első sorozat nevét tartalmazza. A következő példa állandó konstansai ezt a struktúrát explicit módon jelenítik meg:

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

A [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) által már hivatkozott cellát is frissítheted. Ez a megközelítés elkerüli, hogy egy meglévő diagram esetén egy adott sorra és oszlopra támaszkodj:

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

### **Sorozat létrehozása több cellából álló névvel**

Egy összetett sorozatnév akkor hasznos, ha a terméknév és a jelentési időszak külön munkafüzetcellákban van tárolva. Például a `Product A` értéket a B1, a `2026` értéket pedig a C1 cellában egyesítheted egyetlen sorozatnévvé, miközben mindkét rész továbbra is a forráscelláira hivatkozik.

Használd a [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) metódust a névtartomány lekérdezéséhez, majd add át ezt a gyűjteményt a [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/) metódusnak. A `skip_hidden_cells` argumentum szabályozza, hogy a rejtett cellák is szerepeljenek-e: a `True` kizárja őket, a `False` pedig belefoglalja őket. Ez a példa `False`-t használ, hogy a névtartomány minden cellája szerepeljen.

A következő példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 tartomány csak a sorozat nevét adja meg; az A2:A3 a kategóriacímkéket, a B2:B3 pedig a numerikus értékeket tartalmazza.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Ezek a két cella biztosítják a sorozat nevét.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Különálló cellák biztosítják a kategóriákat és a numerikus adatpontokat.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

Az eredményül kapott sorozatnév `Product A 2026`, a két cellaérték között szóközzel. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép a mentett prezentációból lett renderelve:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Az automatikus sorozatkitöltőszín lekérdezése**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) visszaadja a sorozat indexéből és a diagramstílusból kiszámított színt. Ez a szín akkor kerül felhasználásra, ha a sorozat kitöltése nincs kifejezetten definiálva. A metódus meghívása csak a számított színt olvassa, nem állít be új kitöltést.

A következő példa kiírja minden alapértelmezett sorozat automatikus színét:

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

Sáv, oszlop és buboréksorozatok esetén a [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) a negatív értékeket másik kitöltéssel jelenítheti meg. Állítsd be a szabályos sorozatkitöltést szilárdra, engedélyezd az inverziót, és add meg a negatív érték színét a [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

A következő példa az alapértelmezett diagramadatot egy sorozatra cseréli. A munkalap 0. sora a sorozat nevét, az 0. oszlop a kategória neveket, az 1. oszlop pedig az értékeket tartalmazza:

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

Inverziót egy pont számára a [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) használatával is engedélyezheted. Az alábbi példában az inverzió le van tiltva a sorozatra, és csak a kiválasztott pontra van bekapcsolva. A pont negatív értéket is kap, így a hatás látható:

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

## **Egy adott adatpont értékének törlése**

Egy pont üresre állításához a többi pontot megtartva állítsd be a mögöttes munkafüzetcella értékét `None`‑ra. Oszlopdiagram esetén a ábrázolt érték a [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) segítségével érhető el. Az adatpont ugyanazt a kategóriapozíciót megtartja, de a diagram a értéket üresként kezeli a diagram üresérték-beállításai szerint.

A következő példa csak a második pontot törli az első sorozatban:

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

A szórt diagramok külön X és Y cellákat használnak, a buborékdiagramok pedig egy méretcellát is. Csak azt a cellát töröld, amelyik a megszüntetni kívánt értéket tartalmazza. Ne hívd a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metódust, ha a többi pontot meg akarod tartani, mert ez a módszer az összes adatpontot eltávolítja a gyűjteményből.

## **Üres cellák megjelenésének vezérlése**

A rejtett, de értéket tartalmazó cellák külön esetet képeznek az üres celláktól. A rejtett munkalapsorok és -oszlopok adatainak fel- vagy letiltásához lásd az [Include Data from Hidden Rows and Columns](/slides/hu/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) témakört.

Egy üres munkafüzetcellát hiányzó adatként értelmeznek; egy `0` értékű cella ismert numerikus értéket jelent. A [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) beállításával `None`‑ra teheted a cellát üresre. Egy numerikus nulla továbbra is nulla marad, függetlenül az ürescellás beállítástól.

Használd a [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) metódust, hogy kiválaszd, a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás az egész diagramra vonatkozik. Megváltoztatja, hogyan ábrázolják az üres helyeket, anélkül, hogy a munkafüzet üres celláját nullával vagy interpolált értékkel töltené fel.

A következő önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3. nap értékét törli, majd minden módot elment a diagramra. Nem szükséges bemeneti fájl. A [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) a 0. munkalapot, az 0. oszlopot a kategóriacímkéknek, az 1. oszlopot az értékeknek használja; a 0. sor tartalmazza a sorozat nevét. A végső adatsor `10, 20, empty, 30, 40`.

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

    # Hagyd a 3. napot valóban üresen, miközben megtartod a kategóriáját és az adatpontját.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretnél menteni, állítsd be a kívánt módot, és egyszer mentsd a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás mindhárom fájlban azonos adatot mutat. A 3. nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagramtípustól függ. Egy vonaldiagram esetén az összes három mód könnyen összehasonlítható. Sáv- és oszlopdiagramok esetén nincs vonal, amely a hiányzó kategória fölött átkötne, így a `SPAN` nem tudja előállítani a fenti csatlakozási szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen, egy csak jelölőkkel rendelkező szórt diagramnak nincs csatlakozó vonala. Ne számíts három különböző eredményre minden diagramtípus esetén; ellenőrizd a kimenetet a használt típussal.

## **A sorozat részsávszélességének beállítása**

A részsávszélesség a szomszédos sáv- vagy oszloptömbök közötti távolság, amely a sáv vagy oszlop szélességének százalékában van megadva. Az átfedéshez hasonlóan ez a beállítás a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. A [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) egyszeri beállításával a csoport egészére vonatkozik. Nagyobb érték több helyet hoz létre a csoportok között; kisebb érték sűrűbb elrendezést eredményez.

A következő példa módosítja a részsávszélességet, és csak a végső prezentációt menti el:

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

Az összes, a [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) felsorolásban szereplő diagramtípus használ diagramadatot, de sorozataik nem mindegyik rendelkezik azonos értékstruktúrával vagy beállításokkal. Például a kategóriadiagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborékdiagramok pedig buborékméreteket. Alkalmazd a sorozattípusnak megfelelő adatpont‑létrehozó metódust. Az olyan opciók, mint az átfedés és a részsávszélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtat minden diagram‑sorozaton.

**Tartalmaz egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint a [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheted, vagy a sorozat‑ és kategória‑gyűjteményeket törölheted, mielőtt teljesen egyedi adatkészletet adnál hozzá. Egy overload segítségével diagramot is létrehozhatsz alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, a kategóriacímkék és az adatpont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatok építésekor tartsd a kategóriasorokat és a sorozat‑érték‑sorokat összehangoltan, hogy minden pont a kívánt kategória alá legyen ábrázolva.

**Hogyan törölhetek egy pontot anélkül, hogy a teljes sorozatot törölném?**

Állítsd be a megfelelő értékcellát `None`‑ra, hogy a pont kategóriapozíciója üres pontként maradjon. Használd a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metódust csak akkor, ha az összes pontot el akarod távolítani az adott sorozatból. Ha a kategóriákat is eltávolítod, frissíts minden sorozatot, hogy értékük a kategóriagyűjteménnyel összhangban maradjon.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) beállítástól függ. A támogatott diagramok megjeleníthetik az üres helyeket hézagként, nullaként, vagy összekötve a szomszédos pontokkal. Válaszd ki azt a beállítást, amely a hiányzó adat jelentését a prezentációdban leginkább tükrözi. Lásd a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv-, oszlop- és buboréksorozatok esetén engedélyezd a [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) lehetőséget, és állítsd be a [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) színt a negatív értékekhez. Egy egyedi pont formázását a [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) használatával felülbírálhatod. Ezek a tulajdonságok a formázásra, nem a tárolt numerikus értékekre hatnak.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

A kifejezett adatpont‑formázás előnyben részesül az adott pontnál. A többi pont továbbra is a sorozat explicit formázását vagy, ha a sorozat formázása nincs definiálva, a automatikus diagramstílust és témát használja. A csoport‑tulajdonságok, mint az átfedés és a részsávszélesség, az elrendezést szabályozzák, és nem pont‑szintű formázás‑felülírások.

**Van korlátozás arra, hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem alkalmaz különálló, rögzített sorozatszám‑korlátot. Gyakorlatban a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl messze vannak egymástól?**

Állítsd be a [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) értékét a megfelelő szülő sorozatcsoporton. Növeld az értéket a csoportok közötti tér növeléséhez, vagy csökkentsd, hogy a csoportok közelebb kerüljenek egymáshoz.