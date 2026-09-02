---
title: Diagram adat sorozatok kezelése prezentációkban Pythonban
linktitle: Adatsorozatok
type: docs
url: /hu/python-net/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- kategória szín
- sorozat neve
- adatpont
- sorozat hézag
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban Python segítségével."
---
## **Áttekintés**

A diagram a megjelenített adatokat egy diagramadat-könyvben tárolja. Egy [ChartSeries](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/) egy kapcsolódó értékkészletet képvisel, és a sorozat minden [ChartDataPoint](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/) egy vagy több munkafüzetcella hivatkozását tartalmazza. A [ChartCategory](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [ChartDataCell](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenített szövegként tárolódnak.

Egy tipikus kategória-diagram esetén az alapértelmezett munkafüzet a 0‑s sort használja a sorozatnevekhez, az 0‑s oszlopot a kategórianevekhez, a maradék cellák pedig a sorozatértékekhez. A [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) számára megadott munkalap-, sor- és oszlopt indexek nullán alapulnak. Ez a felépítés akkor hasznos, amikor alapértelmezett adatú diagramot hoz létre, de nem feltételezhető, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagram beállításai három különböző hatókörben léteznek:

- Sorozatszintű beállítások, mint a [ChartSeries.format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/format/), az egy sorozat összes pontjának alapértelmezett megjelenését határozzák meg.
- Adatpont beállítások, mint a [ChartDataPoint.format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/format/), felülbírálják a sorozat megjelenését egy adott pontnál.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.parent_series_group](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/parent_series_group/) segítségével érheti el, ha az olyan beállításokat kell megadnia, mint az átfedés vagy a részes szélesség.

Ha nincs kifejezett pont- vagy sorozattöltés beállítva, a diagram stílus és téma határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása meg van adva, a pont formázása él az adott pontra vonatkozóan.

![diagram-sorozat-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

[ChartSeries.overlap](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/overlap/) azt jelzi, hogy a 2D diagramon a sávok vagy oszlopok mekkora mértékben fednek át egymást, -100 és 100 százalék között. Ez egy csak olvasható leképezése a szülő sorozatcsoport beállításának. A [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/overlap/) beállításával frissítheti az összes kompatibilis sorozatot abban a csoportban. Ez a lehetőség olyan diagramtípusokra vonatkozik, amelyek csoportosított sávokat vagy oszlopokat jelenítenek meg; nem befolyásolja a kombinált diagramok nem kapcsolódó sorozatcsoportjait.

Az alábbi példa beállítja az átfedést arra a csoportra, amely az első sorozatot tartalmazza:

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

Használja a [ChartSeries.format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/format/) metódust az egész sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, akkor annak [ChartDataPoint.format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/format/) beállítása felülírja a sorozat kitöltését az adott pontra vonatkozóan.

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

![A sorozat színe](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagramadat-munkafüzetben van tárolva, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzet egy csoportosított oszlopdiagram esetén a B1 cella a 0‑s sorban, 1‑s oszlopban található, és az első sorozat nevét tartalmazza. Az alábbi példában a névkonstansok egyértelművé teszik ezt a struktúrát:

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

A cellát közvetlenül is frissítheti a [ChartSeries.name](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/name/) által már hivatkozott helyen. Ez a megközelítés elkerüli, hogy egy meglévő diagram meghatározott sorára és oszlopára feltételezésekkel éljen:

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

## **Az automatikus sorozat kitöltőszín lekérdezése**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor használatos, amikor a sorozat kitöltése nincs kifejezetten definiálva. A metódus meghívása csak a számított színt olvassa, nem állít be új kitöltést.

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

Példa kimenet az alapértelmezett diagramstílushoz:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagram stílusától és témájától függenek.

## **Invertált kitöltőszín beállítása egy diagram sorozathoz**

Sáv-, oszlop- és buborék sorozatok esetén a [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negatív értékeket megjeleníthet más kitöltéssel. Állítsa be a normál sorozatkitöltést szilárdra, engedélyezze az invertálást, és adja meg a negatív érték színét a [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenített színük módosul.

Az alábbi példa a alapértelmezett diagramadatot egy sorozattal helyettesíti. A munkalap 0‑s sora a sorozat nevét, a 0‑s oszlop a kategórianeveket, az 1‑s oszlop pedig az értékeket tartalmazza:

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

![Az invertált szilárd kitöltőszín](inverted_solid_fill_color.png)

Az invertálást egy pont esetében a [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) segítségével is engedélyezheti. Az alábbi példában az invertálás a sorozatra ki van kapcsolva, csak a kiválasztott pontra van bekapcsolva. A pont negatív értéket is kap, hogy a hatás látható legyen:

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

Egy pont üresként való megjelenítéséhez anélkül, hogy a többi pontot eltávolítaná, állítsa a mögöttes munkafüzetcellát `None`‑ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.value](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/value/) segítségével érhető el. Az adatpont a kategória pozíciójában marad, de a diagram a beállított „üres érték” szabályok szerint kezeli a pontot üresként.

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

A szórási diagramok külön X és Y cellákat, a buborék diagramok pedig egy méretcellát használnak. Csak azt a cellát törölje, amely az eltávolítani kívánt értéket tartalmazza. Ne hívja meg a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metódust, ha a többi pontot meg szeretné tartani, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **A sorozat részes szélességének beállítása**

A részes szélesség a szomszédos sáv- vagy oszlopcsoportok közötti távolságot jelenti, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoport tulajdonsága, nem egyetlen sorozaté. A [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) beállítása egyszerűen a csoport számára elegendő. A nagyobb érték több helyet hoz létre a csoportok között; a kisebb érték sűrűbbé teszi őket.

Az alábbi példa módosítja a részes szélességet, és csak a végső prezentációt menti:

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

![A részes szélesség](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/charttype/) felsorolásban szereplő diagramtípus használ diagramadatokat, de sorozataik nem mindegyiknek azonos értékstruktúrája vagy beállítása. Például a kategória diagramok kategóriákat és értékeket használnak, a szórás diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket adnak hozzá. Használja azt a adatpont‑létrehozási módszert, amely a sorozattípusnak megfelel. Az olyan beállítások, mint az átfedés és a részes szélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek ugyanazokat a csoport‑szintű ábrázolási beállításokat osztják meg. Egy kombinált diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.add_chart](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_chart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategória‑gyűjteményeket törölheti, mielőtt teljesen saját adatkészletet adna hozzá. Egy túlterhelés lehetővé teszi diagram létrehozását alapértelmezett adatok nélkül is.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategória címkék és adatpontértékek a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Ha egyedi adatot épít, tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat összehangoltan, hogy minden pont a kívánt kategória alá kerüljön.

**Hogyan törlök egy pontot anélkül, hogy a teljes sorozatot törölném?**

Állítsa a releváns értékcellát `None`‑ra, így a pont kategória‑pozíciója megmarad üres pontként. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metódust csak akkor használja, ha az adott sorozat összes pontját el kívánja távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek továbbra is illeszkedjenek a kategória‑gyűjteményhez.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [Chart.display_blanks_as](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/display_blanks_as/) beállítástól függ. A támogatott diagramok megjeleníthetik az üresek közti hézagot, nulláértékként, vagy a szomszédos pontok összekapcsolásával. Válassza ki azt a beállítást, amely a hiányzó adatok jelentését a prezentációban legjobban tükrözi.

**Hogyan formázzák a negatív értékek?**

A támogatott sáv‑, oszlop‑ és buborék sorozatok esetén engedélyezze a [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/invert_if_negative/) lehetőséget, és állítsa be a [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) színt. Egyedi pontnál a [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) felülbírálhatja a viselkedést. Ezek a tulajdonságok a formázásra vonatkoznak, a tárolt numerikus értékekre nem.

**Melyik formázás érvényes, ha egy sorozat és egy pont is formázva van?**

Az explicit adatpont‑formázás él az adott pontra vonatkozóan. A többi pont továbbra is az explicit sorozat‑formátumot használja, vagy ha az nincs definiálva, az automatikus diagramstílust és témát. A csoport‑tulajdonságok, mint az átfedés és a részes szélesség, a elrendezést szabályozzák, nem pont‑szintű formázási felülbírálások.

**Van korlátozás arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem alkalmaz különálló, rögzített sorozatszám‑korlátot. Gyakorlatban a prezentáció fájlmérete, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos határt.

**Mit kell változtatni, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Állítsa be a megfelelő szülő sorozatcsoporton a [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) értékét. Növelje az értéket a csoportok közti térszélesség bővítéséhez, vagy csökkentse, ha közelebb szeretné hozni őket.