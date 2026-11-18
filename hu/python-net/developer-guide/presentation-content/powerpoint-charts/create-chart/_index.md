---
title: PowerPoint prezentációs diagramok létrehozása vagy frissítése Pythonban
linktitle: Diagramok létrehozása vagy frissítése
type: docs
weight: 10
url: /hu/python-net/create-chart/
keywords:
- diagram hozzáadása
- diagram létrehozása
- diagram szerkesztése
- diagram módosítása
- diagram frissítése
- szórt diagram
- tortadiagram
- vonaldiagram
- fa térkép diagram
- részvénydiagram
- doboz és szakábra diagram
- tölcsérdiagram
- napkitörés diagram
- hisztogram diagram
- radar diagram
- többcsoportos diagram
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for Python via .NET segítségével. Diagramok hozzáadása, formázása és szerkesztése gyakorlati Python kódpéldákkal."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt arról, hogyan hozhatunk létre és testreszabhatunk diagramokat az Aspose.Slides for Python via .NET segítségével. Megtanulja, hogyan adhat programozott módon diagramot egy diára, töltheti fel adatokka­l, és alkalmazhat különféle formázási beállításokat a konkrét tervezési követelményekhez. A cikk során részletes kódpéldák szemléltetik az egyes lépéseket, a prezentáció és a diagramobjektum inicializálásától a sorozatok, tengelyek és jelmagyarázatok konfigurálásáig. Az útmutató követésével alapos megértést szerez a dinamikus diagramgenerálás Python‑alkalmazásokba való integrálásáról, megkönnyítve az adatvezérelt prezentációk létrehozását.

## **Diagram létrehozása**

A diagramok segítik az embereket az adatok gyors megjelenítésében és olyan betekintések megszerzésében, amelyek egy táblázatból vagy táblázatkezelőből nem egyértelműek.

**Miért érdemes diagramot készíteni?**

Diagramokkal:

* nagy mennyiségű adatot összesíthet, sűríthet vagy összefoglalhat egyetlen dia‑dián;
* mintákat és trendeket tárhat fel az adatokban;
* meghatározhatja az adat irányát és lendületét az idő függvényében vagy egy adott mérőegységhez viszonyítva;
* felderítheti a kiugró, rendellenes, eltérő, hibás vagy értelmetlen adatokat;
* bonyolult adatokat kommunikálhat vagy prezentálhat.

A PowerPointban a *Beszúrás* funkcióval hozhatunk létre diagramokat, amely különféle sablonokat kínál a diagramtípusok megtervezéséhez. Az Aspose.Slides segítségével mind szabványos, mind egyedi diagramok létrehozhatók.

{{% alert color="info" title="Note" %}}

Használja a [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) felsorolást a [aspose.slides.charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) modulban. Ennek az enumerációnak az értékei a különböző diagramtípusoknak felelnek meg.

{{% /alert %}}

### **Halmozott oszlopdiagram létrehozása**

Ez a példa a [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) metódust használja egy halmozott oszlopdiagram létrehozásához, amely három kategóriában két sorozatot hasonlít össze. A sorozatok piros és zöld kitöltéssel rendelkeznek, az egyes címkék a kategória‑neveket, sorozatneveket és értékeket mutatják. A 0‑ás munkalap‑index az beágyazott diagram‑munkafüzet első lapjára hivatkozik.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series[0]

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    series = chart.chart_data.series[1]

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 60)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A halmozott oszlopdiagram](clustered_column_chart.png)

### **Szórásdiagramok létrehozása**

A szórásdiagramok (más néven szórási diagramok vagy xy‑grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korreláció demonstrálására.

Szórásdiagramot akkor használjon, ha:

* párosított numerikus adatai vannak;
* két változó jól párosítható egymással;
* meg szeretné határozni, hogy a két változó összefügg-e;
* van egy független változója, amely több értéket tartalmaz egy függő változóhoz.

Ez a példa két x‑y értékcsoportot ábrázol. Az első sorozat egyenes vonalakat csillag‑jelölőkkel, a második sima vonalakat kör‑jelölőkkel használ; mindkettő 10‑es [size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/size/) paraméterrel. A [symbol](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/symbol/) tulajdonság vezérli a jelölő alakját.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 1, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 1, 3, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    series = chart.chart_data.series[0]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 2, 3)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 2, 10)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    series = chart.chart_data.series[1]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 4, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 5, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szórásdiagram](scatter_chart.png)

### **Tortadiagramok létrehozása**

A tortadiagramok leginkább arra alkalmasak, hogy a rész‑egész viszonyt ábrázolják, különösen, ha a adatok kategória‑címkékkel és numerikus értékekkel rendelkeznek. Ha azonban sok rész vagy címke van, érdemesebb lehet oszlopdiagramot használni.

Ez a példa egy három negyedéves értéket tartalmazó tortadiagramot hoz létre. Minden szelet egyedi kitöltéssel és szegéllyel rendelkezik, a címkék pedig különféle kombinációkat mutatnak az értékek, a százalékok és a sorozatinformációk tekintetében. A [first_slice_angle](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/first_slice_angle/) tulajdonság 180 fokra állítja az első szelet kiindulási szögét.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    category_cell = workbook.get_cell(0, 1, 0, "1st Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "2nd Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "3rd Qtr")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_pie_series(value_cell)

    chart.chart_data.series_groups[0].is_color_varied = True

    first_slice = series.data_points[0]
    first_slice.format.fill.fill_type = slides.FillType.SOLID
    first_slice.format.fill.solid_fill_color.color = draw.Color.cyan

    first_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    first_slice.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    first_slice.format.line.width = 3.0
    first_slice.format.line.style = slides.LineStyle.THIN_THICK
    first_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH

    second_slice = series.data_points[1]
    second_slice.format.fill.fill_type = slides.FillType.SOLID
    second_slice.format.fill.solid_fill_color.color = draw.Color.brown

    second_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    second_slice.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    second_slice.format.line.width = 3.0
    second_slice.format.line.style = slides.LineStyle.SINGLE
    second_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    third_slice = series.data_points[2]
    third_slice.format.fill.fill_type = slides.FillType.SOLID
    third_slice.format.fill.solid_fill_color.color = draw.Color.coral

    third_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    third_slice.format.line.fill_format.solid_fill_color.color = draw.Color.red
    third_slice.format.line.width = 2.0
    third_slice.format.line.style = slides.LineStyle.THIN_THIN
    third_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    first_label = series.data_points[0].label
    first_label.data_label_format.show_value = True

    second_label = series.data_points[1].label
    second_label.data_label_format.show_value = True
    second_label.data_label_format.show_legend_key = True
    second_label.data_label_format.show_percentage = True

    third_label = series.data_points[2].label
    third_label.data_label_format.show_series_name = True
    third_label.data_label_format.show_percentage = True

    series.labels.default_data_label_format.show_leader_lines = True

    chart.chart_data.series_groups[0].first_slice_angle = 180

    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A tortadiagram](pie_chart.png)

A torta kívül eső címkék olvashatóságának javításához tekintse meg a [Format Leader Lines](/slides/hu/python-net/chart-data-label/#format-leader-lines) példát, amely a címkék pozícióját és a vonalak színét, vastagságát, átlátszóságát és szaggatottságát szabályozza.

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonal‑grafikonok) leginkább akkor használandók, ha az értékek időbeli változását kívánja bemutatni. Egy vonaldiagram segítségével egyszerre nagy mennyiségű adatot hasonlíthat össze, nyomon követheti az időbeli változásokat és trendeket, kiemelheti a sorozatok anomáliáit, és még sok minden mást.

Ez a példa a [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) metódust használja egy vonaldiagram létrehozásához az alapértelmezett sorozatokkal és kategóriákkal, majd PPTX‑ként menti a prezentációt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    presentation.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

Alapértelmezés szerint a vonaldiagram pontjai egyenes, folytonos vonalakkal vannak összekötve. Ha gondolatjelekkel szeretné összekötni a pontokat, állítsa a [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) értékét a [LineDashStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) egyik elemére:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH
```

Az eredmény:

![A vonaldiagram](line_chart.png)

### **Fa térkép diagramok létrehozása**

A fa‑térkép diagramok leginkább eladási adatoknál használandók, amikor a kategóriák relatív méretét szeretné bemutatni, és gyorsan felhívni a figyelmet az egyes kategóriák nagy hozzájárulására.

Ez a példa egy nyolc levélből álló fa‑térképet hoz létre, négy szárra és két ágra csoportosítva. A [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) metódus az 1‑es szintű csoportosításnál a szárakat, a 2‑es szinten pedig az ágakat rendeli hozzá. Az értékek határozzák meg a relatív téglalap‑méreteket, míg a kategória‑címkék és a átfedő szülőcímkék a hierarchiát jelzik.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Ág 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # Ág 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("Treemap.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A fa‑térkép diagram](treemap_chart.png)

### **Vízforduló diagramok létrehozása**

A vízforduló diagram azt mutatja, hogyan járulnak hozzá a pozitív és negatív változások az eredő értékhez. Például egy nyereségszegmens a bevételből indul, levonja a költségeket, majd hozzáad egyéb bevételeket. A változásos oszlopok a korábbi és az új futó értékek között úsznak, míg a teljes oszlopok a nullától a felhalmozott értékig terjednek.

Az alábbi példa ezres amerikai dollárban megadott összegeket használ:

| Kategória | Munkafüzet‑érték | Oszlop‑típus |
| --- | ---: | --- |
| Bevétel | 1000 | Növekedés |
| Értékesítési költség | -400 | Csökkenés |
| Bruttó nyereség | 600 | Köztes összeg |
| Üzemeltetési költségek | -200 | Csökkenés |
| Egyéb bevételek | 50 | Növekedés |
| Nettó nyereség | 450 | Végső összeg |

Egy pont közbenső vagy végső összegként való megjelöléséhez állítsa be a [set_as_total](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/set_as_total/) tulajdonságot `True`‑ra. A pont munkafüzet‑cellájában adja meg a tényleges felhalmozott összeget: `600` a bruttó nyereséghez (`1000 - 400`) és `450` a nettó nyereséghez (`600 - 200 + 50`). A tulajdonság csak megjelöli az oszlopot összegként; nem számolja ki vagy tölti ki a cella értékét. Ne használjon helyettesítő nullát, vagy adjon meg más változást egy összeg‑pontnál. A teljes oszlop a felhalmozott értéket mutatja anélkül, hogy újra hozzáadná a futó értékhez.

Ez a teljes C# példa a `Waterfall` tagot használja a [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑ból, törli az alapértelmezett adatokat, és kitölti a beágyazott munkafüzetet. A 0‑ás munkalap‑index az első munkalapot választja; az A oszlop a kategória‑neveket, a B oszlop az értékeket tartalmazza. Minden értékcellát a [add_data_point_for_waterfall_series](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/add_data_point_for_waterfall_series/) metódussal adunk hozzá. A 0‑alapú pontindexek `2` és `5` a köztes és a végső összegeket jelölik. A [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) engedélyezése megjeleníti az összegeket az oszlopokon. Nincs szükség bemeneti prezentációra vagy munkafüzetre.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.WATERFALL, 20, 20, 680, 200)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Profit breakdown (USD thousands)")
    chart.chart_title.overlay = False
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Profit")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.WATERFALL)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, categories[i])
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_waterfall_series(value_cell)

    # A harmadik és a hatodik pont az összeséget jelöli, nem további változást.
    series.data_points[2].set_as_total = True
    series.data_points[5].set_as_total = True
    series.show_connector_lines = True
    series.labels.default_data_label_format.show_value = True

    presentation.save("WaterfallChart.pptx", slides.export.SaveFormat.PPTX)
```

Állítsa a sorozatszintű [show_connector_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/show_connector_lines/) tulajdonságot `True`‑ra, hogy a szomszédos oszlopokat összekötő vonalak megjelenjenek, és a futó érték nyomon követése egyszerűbb legyen. A vonalak elrejtéséhez cserélje a példában a hozzárendelést `series.show_connector_lines = False`‑ra a mentés előtt. Ez csak a vonalak láthatóságát módosítja, az adatot vagy az összegeket nem.

Az elmentett prezentáció a 600-as bruttó nyereséget és a 450-es nettó nyereséget mutatja, mindkét összeg nulláról indul:

![Vízforduló diagram, amely a bevételt, költségeket, 600-as bruttó nyereséget és 450-es nettó nyereséget ábrázolja, értékcímkékkel és összekötő vonalakkal](waterfall_chart.png)

### **Részvénydiagramok létrehozása**

A részvénydiagramok pénzügyi adatokat jelenítenek meg, például nyitó, magas, alacsony és záró árakat, segítve a piaci trendek és volatilitás elemzését. Lényeges betekintést nyújtanak a részvény teljesítményébe, támogatva a befektetőket és elemzőket a tájékozott döntések meghozatalában.

Ez a példa egy nyitó‑magas‑alacsony‑záró diagramot hoz létre négy sorozattal ebben a sorrendben, és három kategóriával. A [has_up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/has_up_down_bars/) tulajdonság engedélyezi a fel‑le oszlopokat, a [hi_low_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/hi_low_lines_format/) szabályozza a magas‑alacsony vonalakat, míg az egyes sorozat‑vonalak és a kisebb vízszintes rácsvonalak rejtve maradnak.

Az [up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/up_down_bars/) menedzser külön [up_bars_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/up_bars_format/) és [down_bars_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/down_bars_format/) objektumot tesz elérhetővé. Használja mindkét objektum [fill](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/fill/) és [line](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/line/) tulajdonságait a kitöltés és a körvonal önálló beállításához. Ez a példa zöld oszlopot sötétzöld körvonallal a növekvő intervallumokhoz, valamint narancssárga‑vörös oszlopot sötétvörös körvonallal a csökkenő intervallumokhoz használ.

Adjon numerikus értékeket mind a négy sorozathoz minden kategóriánál, a High és Low a Open és Close közé zárja. Az oszlopok a Close‑t az Open‑nel **azon a kategórián belül** hasonlítják össze, nem az előző kategóriával: az A 72‑ről 25‑re csökken, míg a B 25‑ről 38‑ra emelkedik, a C pedig 38‑ról 50‑re. Azonos Open és Close értékek esetén nem látható kitöltött intervallum. A fel‑le oszlopok az Open‑Close‑et fedik le; a magas‑alacsony vonalak a Low‑High‑t. Ezek az oszlopok a sorozatcsoporthoz tartoznak, nem a hagyományos oszlopdiagram‑sorozatokhoz.

Ez a formázás [LINE és LINE_WITH_MARKERS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) diagramoknál is működik, ha legalább két sorozat van ugyanabban a csoportban, és minden kategóriához numerikus értékek tartoznak. Az ilyen nem halmozott vonaldiagramoknál a fel‑le oszlopok az első és az utolsó sorozatot hasonlítják össze: a magasabb utolsó érték fel‑oszlopot, a kisebb utolsó érték le‑oszlopot eredményez. A sorozatok megcserélése a besorolást is megcseréli. Az alábbi példa a [OPEN_HIGH_LOW_CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) diagramot használja; ne feltételezze, hogy más részvény‑, halmozott‑vonal‑ vagy 3D‑variánsok ugyanazt az adat‑elrendezést vagy intervallum‑értelmezést alkalmazzák.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 150, False)

    workbook = chart.chart_data.chart_data_workbook

    category_cell = workbook.get_cell(0, 1, 0, "A")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "B")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "C")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Open")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 2, "High")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 3, "Low")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 4, "Close")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)

    series = chart.chart_data.series[0]
    value_cell = workbook.get_cell(0, 1, 1, 72)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 1, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 1, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[1]
    value_cell = workbook.get_cell(0, 1, 2, 172)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[2]
    value_cell = workbook.get_cell(0, 1, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 3, 13)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[3]
    value_cell = workbook.get_cell(0, 1, 4, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 4, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 4, 50)
    series.data_points.add_data_point_for_stock_series(value_cell)

    up_down_bars = chart.chart_data.series_groups[0].up_down_bars
    up_down_bars.has_up_down_bars = True

    up_down_bars.up_bars_format.fill.fill_type = slides.FillType.SOLID
    up_down_bars.up_bars_format.fill.solid_fill_color.color = draw.Color.lime_green
    up_down_bars.up_bars_format.line.fill_format.fill_type = slides.FillType.SOLID
    up_down_bars.up_bars_format.line.fill_format.solid_fill_color.color = draw.Color.dark_green
    up_down_bars.up_bars_format.line.width = 2

    up_down_bars.down_bars_format.fill.fill_type = slides.FillType.SOLID
    up_down_bars.down_bars_format.fill.solid_fill_color.color = draw.Color.orange_red
    up_down_bars.down_bars_format.line.fill_format.fill_type = slides.FillType.SOLID
    up_down_bars.down_bars_format.line.fill_format.solid_fill_color.color = draw.Color.dark_red
    up_down_bars.down_bars_format.line.width = 2
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for stock_series in chart.chart_data.series:
        stock_series.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("Stock-chart.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény, PowerPoint‑ből exportálva:

![Részvénydiagram, ahol A esetén narancssárga‑vörös csökkenő intervallum, B‑nél és C‑nél zöld emelkedő intervallumok láthatók](stock_chart.png)

### **Doboz‑ és szakábra diagramok létrehozása**

A doboz‑ és szakábra diagramok az adateloszlást mutatják, a mediánt, kvartiliseket és esetleges kiugró értékeket összefoglalva. Különösen hasznosak feltáró adat‑elemzésnél és statisztikai tanulmányoknál, gyorsan megérteni az adat‑variabilitást és az esetleges anomáliákat.

Ez a példa hat értékkel hoz létre egy doboz‑ és szakábra diagramot. A [quartile_method](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/quartile_method/) tulajdonság az exkluzív kvartilis‑számítást választja. A példa engedélyezi a közép‑vonalakat, közép‑jelölőket, belső pontokat és kiugró pontokat is.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    value_cell = workbook.get_cell(0, "B1", 15)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 41)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 10)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 23)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)

    presentation.save("BoxAndWhisker.pptx", slides.export.SaveFormat.PPTX)
```

### **Tölcsérdiagramok létrehozása**

A tölcsérdiagramok a folyamatok szekvenciális szakaszainak vizualizálására szolgálnak, ahol az adat‑mennyiség csökken a lépésről lépésre haladva. Különösen hasznosak a konverziós ráták elemzésében, a szűk keresztmetszetek azonosításában és az értékesítési vagy marketing folyamatok hatékonyságának nyomon követésében.

Ez a példa a [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) metódust használja egy tölcsérdiagram hozzáadásához egy meglévő prezentáció első diájához. Lecseréli az alapértelmezett adatokat hat kategóriára és 50‑tól 500‑ig terjedő értékekre, majd menti a frissített prezentációt. A bemeneti prezentációnak legalább egy diát kell tartalmaznia.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    value_cell = workbook.get_cell(0, "B1", 50)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 100)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 200)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 300)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 400)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 500)
    series.data_points.add_data_point_for_funnel_series(value_cell)

    presentation.save("Funnel.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A tölcsérdiagram](funnel_chart.png)

### **Napkitörés diagramok létrehozása**

A napkitörés diagramok a hierarchikus adatokat jelenítik meg, a szinteket koncentrikus gyűrűkként ábrázolva. Segítenek a rész‑egész kapcsolatok illusztrálásában, és ideálisak beágyazott kategóriák és alkategóriák tiszta, tömör ábrázolására.

Ez a példa egy napkitörés diagramot hoz létre nyolc levélből, négy szárra és két ágra csoportosítva. A [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) metódus az 1‑es szinten a szárakat, a 2‑es szinten az ágakat rendeli hozzá. A kategória‑címkék a szegmenseket azonosítják, az értékek pedig a relatív méreteket határozzák meg.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Ág 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # Ág 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)

    presentation.save("Sunburst.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A napkitörés diagram](sunburst_chart.png)

### **Hisztogram diagramok létrehozása**

A hisztogram diagramok megmutatják, hogyan oszlanak el a numerikus értékek intervallumok (bin‑ek) között. Havi jelentésekben a megrendelés‑feldolgozási időkre vonatkozóan használja ugyanazt a bin‑szélességet és küszöböket, hogy az intervallumok konzisztensnek maradjanak, és az eloszlások összehasonlíthatók legyenek.

Állítsa a vízszintes tengely [aggregation_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/aggregation_type/) tulajdonságát a [AxisAggregationType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axisaggregationtype/) egyik módjára. A [bin_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/bin_width/) csak a `BY_BIN_WIDTH` esetén érvényes; a [number_of_bins](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_of_bins/) csak a `BY_NUMBER_OF_BINS` esetén. Használja az `AUTOMATIC`‑ot, hogy a diagram maga válassza ki a bin‑eket.

#### **Fix bin‑szélesség használata**

Ez a példa a feldolgozási időket 10‑perces intervallumokra csoportosítja, külön bin‑ekkel a 10 perc alatti vagy egyenlő és a 40 perc fölötti értékeknek. Engedélyezze ezeket a bin‑eket a [is_underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_underflow_bin/) és [is_overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_overflow_bin/) használatával. Ha explicit [underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/underflow_bin/) és [overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/overflow_bin/) küszöböket ad meg, állítsa az [is_automatic_underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_underflow_bin/) és [is_automatic_overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_overflow_bin/) értékét `False`‑ra.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 680, 200)

    chart.has_legend = False
    chart.has_title = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.get_cell(0, i, 0, value)
        series.data_points.add_data_point_for_histogram_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.aggregation_type = charts.AxisAggregationType.BY_BIN_WIDTH
    axis.bin_width = 10
    axis.is_underflow_bin = True
    axis.is_automatic_underflow_bin = False
    axis.underflow_bin = 10
    axis.is_overflow_bin = True
    axis.is_automatic_overflow_bin = False
    axis.overflow_bin = 40

    presentation.save("Histogram-bin-width.pptx", slides.export.SaveFormat.PPTX)
```

A PowerPoint‑ban megjelenített prezentáció **3, 4, 4, 4, és 2** darab bin‑t mutat. Az underflow bin tartalmazza a `5, 10, 10` értékeket, így a küszöb inkluzív. Az overflow bin csak a `41, 50` értékeket tartalmazza, ezért a küszöb exkluzív; a `40`‑nal egyenlő értékek az előző intervallumban maradnak. A belső bin‑ek a saját alsó határuknál nagyobb, felső határuknál pedig kisebb vagy egyenlő értékeket tartalmaznak.

![Hisztogram 10‑perces bin‑ekkel és explicit underflow és overflow küszöbökkel](histogram_bin_width.png)

#### **Bin‑szám meghatározása**

Fix részletesség helyett, fix intervallumok helyett kérje ki öt bin‑t ugyanezen adatokhoz. Ez a példa letiltja az underflow és overflow bin‑eket. A diagram a szélességet az adat‑tartományból számolja ki, így a határok jelentésről jelentésre változhatnak.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 680, 200)

    chart.has_legend = False
    chart.has_title = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.get_cell(0, i, 0, value)
        series.data_points.add_data_point_for_histogram_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.aggregation_type = charts.AxisAggregationType.BY_NUMBER_OF_BINS
    axis.number_of_bins = 5

    presentation.save("Histogram-bin-count.pptx", slides.export.SaveFormat.PPTX)
```

Az öt bin‑nek **4, 4, 4, 4, és 1** darab eleme van. Hasonlítsa össze ezt az eloszlást a fenti fix‑szélességű eredménnyel: a bemeneti értékek azonosak, de a határok különböznek.

![Hisztogram öt bin‑nel, amely ugyanabból az adatból számolódik](histogram_bin_count.png)

### **Radar diagramok létrehozása**

A radar diagramok többváltozós adatot két dimenzióban jelenítenek meg, lehetővé téve több változó egyszerre történő összehasonlítását. Különösen hasznosak minták, erősségek és gyengeségek azonosításához több teljesítménymutató vagy attribútum esetén.

Ez a példa a [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) metódust használja egy radar diagram létrehozásához az alapértelmezett sorozatokkal és kategóriákkal, majd PPTX‑ként menti a prezentációt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_chart(charts.ChartType.RADAR, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A radar diagram](radar_chart.png)

### **Többcsoportos diagramok létrehozása**

A többcsoportos diagramok olyan adatot jelenítenek meg, amely több kategória‑csoportot is tartalmaz, lehetővé téve az értékek több dimenzióban történő egyszerre történő összehasonlítását. Különösen hasznosak összetett, többrétegű adatkészletek trendjeinek és kapcsolataik elemzésében.

Ez a példa egy halmozott oszlopdiagramot hoz létre nyolc kategóriával, négy párosra rendezve. A [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) metódus minden párhoz egy közös címkét ad a 1‑es csoportosítási szinten, így a kategória‑tengely egyaránt tartalmaz egyéni és csoportos címkéket.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.get_cell(0, "c2", "A")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group1")
    category_cell = workbook.get_cell(0, "c3", "B")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c4", "C")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group2")
    category_cell = workbook.get_cell(0, "c5", "D")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c6", "E")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group3")
    category_cell = workbook.get_cell(0, "c7", "F")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c8", "G")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group4")
    category_cell = workbook.get_cell(0, "c9", "H")
    category = chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, "D1", "Series 1")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    value_cell = workbook.get_cell(worksheet_index, "D2", 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D3", 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D4", 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D5", 40)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D6", 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D7", 60)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D8", 70)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D9", 80)
    series.data_points.add_data_point_for_bar_series(value_cell)

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A többcsoportos diagram](multi_category_chart.png)

#### **Negyedéves címke eltávolítása**

Töltse le a [quarters.pptx](quarters.pptx) fájlt, és helyezze el a munkakönyvtárban. Ennek a diagramnak kilenc hónapja és egyetlen értékesítési sorozata van 10‑től 18‑ig terjedő értékekkel. A kategóriatengely három negyedéves címkét tartalmaz: Q1 az Jan‑Mar‑ra, Q2 az Apr‑Jun‑ra, Q3 a Jul‑Sep‑re terjed.

Az április a negyedik kategória, ahol a Q2 kifejezetten be lett állítva. Hívja meg a [delete_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/delete_grouping_item/) metódust április [grouping_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/grouping_levels/) gyűjteményén. A szint áprilishoz viszonyítva: az 1‑es szint a negyedév, a 0‑es szint maga a hónap. A metódus nem tudja eltávolítani a 0‑es szintű levél‑kategóriát.

```python
import aspose.slides as slides

with slides.Presentation("quarters.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    april = chart.chart_data.categories[3]
    april.grouping_levels.delete_grouping_item(1)
    
    presentation.save("quarters-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("quarters-updated.pptx") as reopened:
    data = reopened.slides[0].shapes[0].chart_data
    print(", ".join(str(month.as_cell.value) for month in data.categories))
    print(", ".join(str(point.value.data) for point in data.series[0].data_points))
```

Az újranyitott diagram az eredeti hónapokat (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) és értékeket (`10, 11, 12, 13, 14, 15, 16, 17, 18`) ugyanabban a sorrendben jeleníti meg. Nyissa meg a `quarters-updated.pptx` fájlt a PowerPointban a tengelycímkék összehasonlításához. A Q2 címke és az április előtti csoporthatár eltűnik, így a Q1 januártól júniusig terjed. A Q3 továbbra is júliusban kezdődik.

![Negyedéves címkék eltávolítása előtt és után. Bal oldalon a Q2 áprilistól júniusig terjed. Jobb oldalon a Q1 januártól júniusig terjed.](quarter-label-comparison.png)

### **Térkép diagramok létrehozása**

A térkép diagramok földrajzi adatok vizualizálására szolgálnak, az információkat konkrét helyekhez – például országokhoz, államokhoz vagy városokhoz – rendelve. Különösen hasznosak regionális trendek, demográfiai adatok és térbeli eloszlások elemzésében egyértelmű, vizuálisan vonzó módon.

Ez a példa a [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) metódust használja egy térkép‑diagram létrehozásához az alapértelmezett földrajzi adatokkal, és menti a megtekintéshez a PowerPointban.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.MAP, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A térkép diagram](map_chart.png)

{{% alert color="info" title="Note" %}}

A fenti kép a PowerPointban megnyitott mentett prezentációt mutatja. Az Aspose.Slides helyesen írja ki a térkép‑diagramot és annak adatait, de a térkép‑diagramot maga nem rajzolja: ha egy olyan diát, amely tartalmaz ilyet, képpé rendereli vagy PDF‑re, SVG‑re konvertálja, a diagramterület üres marad. A dián lévő egyéb alakzatok nem érintettek.

{{% /alert %}}

### **Kombinált diagramok létrehozása**

A kombinált (vagy combo) diagram több diagramtípust egyesít egyetlen ábrában. Ez a diagram lehetővé teszi két vagy több adathalmaz kiemelését, összehasonlítását vagy vizsgálatát, segítve a köztük lévő összefüggések feltárását.

![A kombinált diagram](combination_chart.png)

Ez a példa két halmozott oszlop‑sorozatot és egy vonal‑sorozatot kombinál négy kategórián. Az oszlopok az elsődleges függőleges tengelyt használják, míg a [plot_on_second_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/plot_on_second_axis/) a vonalat a jobb oldalon lévő másodlagos függőleges tengelyre helyezi. A segédfüggvények konfigurálják a címet, jelmagyarázatot, tengelycímkéket és rácsvonalakat.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)

def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    portion_format = chart.chart_title.text_frame_for_overriding.paragraphs[0].paragraph_format.default_portion_format
    portion_format.font_bold = slides.NullableBool.FALSE
    portion_format.font_height = 18

    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 4, 0, "Category 4")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 4.3)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 2.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 3.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 1, 4.5)
    series.data_points.add_data_point_for_bar_series(value_cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 2.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 4.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 1.8)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 2, 2.8)
    series.data_points.add_data_point_for_bar_series(value_cell)

def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    value_cell = workbook.get_cell(worksheet_index, 1, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 3, 3.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 3, 5.0)
    series.data_points.add_data_point_for_line_series(value_cell)

    series.plot_on_second_axis = True

def set_primary_axes_format(chart):
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)

def set_secondary_axes_format(chart):
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12


create_combo_chart()
```

## **Diagramok frissítése**

Az Aspose.Slides for Python via .NET lehetővé teszi a PowerPoint diagramok frissítését a diagram‑adatok, formázás és stílus módosításával. Ez a funkció leegyszerűsíti a prezentációk dinamikus tartalommal való naprakészen tartását, és biztosítja, hogy a diagramok pontosan tükrözzék a jelenlegi adatokat és vizuális szabványokat.

Ez a példa frissíti a „My chart” nevű diagramot egy meglévő prezentáció első diáján. Két oszlop‑sorozatra van szükség, mindegyik három adatponttal, a kategória‑címkék az A oszlopban, a sorozatnevek az első munkalap első sorában. A példa a [get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) metódust használja a munkafüzet‑cellák módosításához, frissíti a sorozatértékeket, hozzáad egy harmadik sorozatot, és a [type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/type/) segítségével a diagramot halmozott hengerekké változtatja.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            worksheet_index = 0

            workbook = chart.chart_data.chart_data_workbook

            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.chart_data.series[0]

            workbook.get_cell(worksheet_index, 0, 1, "New_Series 1")
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            series = chart.chart_data.series[1]

            workbook.get_cell(worksheet_index, 0, 2, "New_Series 2")
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
            series = chart.chart_data.series.add(series_name_cell, chart.type)

            value_cell = workbook.get_cell(worksheet_index, 1, 3, 20)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 2, 3, 50)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 3, 3, 30)
            series.data_points.add_data_point_for_bar_series(value_cell)

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

    presentation.save("AsposeChartModified.pptx", slides.export.SaveFormat.PPTX)
```

## **Adattartomány beállítása egy diagramhoz**

A már meglévő diagram által használt tartomány megtekintéséhez lásd a [Retrieve a Chart's Data Range](/slides/hu/python-net/chart-workbook/#retrieve-a-charts-data-range) cikket.

Az Aspose.Slides for Python via .NET rugalmasságot biztosít egy munkalap adott adattartományának diagram‑adatforrásként történő meghatározásához. Ez azt jelenti, hogy közvetlenül a munkalap egy részét leképezheti a diagramra, így szabályozva, mely cellák járulnak hozzá a sorozatokhoz és kategóriákhoz. Ennek eredményeként könnyen frissítheti és szinkronizálhatja diagramjait a munkalap legújabb adatváltozásaival, biztosítva, hogy a PowerPoint‑prezentációk naprakész és pontos információkat tükrözzenek.

Ez a példa a [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) metódust használja a „My chart” nevű diagram adatforrásának `Sheet1!A1:B4`‑re állításához egy meglévő prezentáció első diáján. A diagram‑munkafüzetnek tartalmaznia kell azt a munkalapot és egy feltöltött tartományt, amely első sorban sorozat‑fejlécet, A oszlopban kategória‑címkéket, B oszlopban három értéket tartalmaz.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **Alapértelmezett jelölők használata diagramokban**

Alapértelmezett jelölők használatakor minden diagram‑sorozat automatikusan különböző alapértelmezett jelölőszimbólumot kap.

Ez a példa a [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) metódust használja egy két vonal‑sorozatot és egy jelmagyarázatot tartalmazó diagram létrehozásához. A [marker](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/marker/) beállítások megtartják a automatikusan hozzárendelt jelölőszimbólumokat. Az első sorozat egy negatív értéket és egy hiányzó értéket (`None`) tartalmaz, míg a másik minden kategóriához értéket ad.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(0, 1, 0, "C1")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 1, 1, 24)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 2, 0, "C2")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 2, 1, 23)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 3, 0, "C3")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 3, 1, -10)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 4, 0, "C4")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 4, 1, None)
    series.data_points.add_data_point_for_line_series(value_cell)

    series_name_cell = workbook.get_cell(0, 0, 2, "Series 2")
    second_series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(0, 1, 2, 30)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 10)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 60)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 4, 2, 40)
    second_series.data_points.add_data_point_for_line_series(value_cell)

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Milyen diagramtípusokat támogat az Aspose.Slides for Python via .NET?**

Az Aspose.Slides for Python via .NET széles körű diagramtípusokat támogat, beleértve az oszlop, vonal, torta, terület, szórás, hisztogram, radar és sok más típust. Ez a rugalmasság lehetővé teszi a legmegfelelőbb diagramtípus kiválasztását az adat‑vizualizációs igényekhez.

**Hogyan adhatok új diagramot egy diához?**

Új diagram hozzáadásához először hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból, szerezze meg a kívánt diát annak indexe alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagramtípust és a kezdeti adatokat. Ez a folyamat közvetlenül integrálja a diagramot a prezentációba.

**Hogyan frissíthetem a diagramon megjelenített adatokat?**

A diagram adatait a [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) elérésével, az alapértelmezett sorozatok és kategóriák törlésével, majd a saját adatainak hozzáadásával frissítheti. Ez lehetővé teszi a diagram programozott frissítését a legújabb adatok tükrözésére.

**Lehet-e testre szabni a diagram megjelenését?**

Igen, az Aspose.Slides for Python via .NET kiterjedt testreszabási lehetőségeket kínál. Módosíthatja a színeket, betűtípusokat, címkéket, jelmagyarázatot és egyéb formázási elemeket, hogy a diagram megjelenése megfeleljen a konkrét tervezési követelményeknek.

Kapcsolódó funkció: [Create editable charts](/slides/hu/features/create-charts/).