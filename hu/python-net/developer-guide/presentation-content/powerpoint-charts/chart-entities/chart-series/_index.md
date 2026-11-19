---
title: Diagram sorozatok kezelése prezentációkban Pythonban
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
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket a prezentációkban Python segítségével."
---
## **Áttekintés**

Egy diagram tárolhatja a megjelenített értékeket a munkafüzet celláiban vagy közvetlenül numerikus literálokként. A [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) egy kapcsolódó értékkészletet képvisel, és minden [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) egy pontot jelent ebben a sorozatban. A [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) objektumok biztosítják a címkéket vagy a sorozatok által megosztott csoportosítási értékeket. Az alapértelmezett adatokkal létrehozott diagramokban a sorozatnevek, kategóriák és pontértékek a diagram munkafüzetéből származó [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) objektumokat használják.

Egy tipikus kategóriadiagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatneveknek, a 0. oszlopot a kategórianévnek, a maradék cellákat pedig a sorozatértékeknek. A [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) számára átadott munkalap‑, sor‑ és oszlopt indexek nulla‑alapúak. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre egy diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit megváltoztatná.

A diagram beállításai három különböző hatókörben érvényesülnek:

- Sorozat‑szintű beállítások, például a [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), az alapértelmezett megjelenést biztosítják az összes pont számára egy sorozatban.
- Adatpont‑szintű beállítások, például a [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), felülírják a sorozat megjelenését egy adott pontnál.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) segítségével érheti el, ha például átfedés vagy hézag szélesség beállítására van szükség.

Ha nincs kifejezetten beállítva pont‑ vagy sorozat‑kitöltés, a diagramstílus és a téma határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása meg van adva, a pont formázása elsőbbséget élvez az adott pontnál.

![diagram-sorozat-powerpoint](chart-series-powerpoint.png)

Csoportos hengerdiagram esetén tekintse meg, hogy a [changing the 3D series type or bar shape](/slides/hu/python-net/3d-chart/#change-the-3d-series-type-and-bar-shape) hogyan befolyásolja az első sorozatot.

## **Sorozatértékek beállítása numerikus literálokkal**

Használjon numerikus literálokat, ha a sorozatértékek az alkalmazás adataiból vagy számításaiból származnak, és nincs szükség munkalap‑cellahivatkozásra. Állítsa a [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) értékét [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/)‑re, mielőtt minden pont [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) tulajdonságát a [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/) segítségével rendeli hozzá.

A gyűjteménybeállítás vezérli az összes pont értékének forrástípusát az adott sorozatban. Minden pont [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) a kiválasztott típust jelzi; a gyűjteménybeállítással módosítható. `WORKSHEET` esetén a [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) segítségével érheti el a hivatkozott cellát. `DOUBLE_LITERALS` esetén az `as_literal_double` használatával olvashatja vagy írhatja a számot közvetlenül.

Az alábbi példa egy oszlopdiagramot hoz létre alapértelmezett sorozatokkal és kategóriákkal, majd a számított 10, 20 stb. értékeket rendeli az első sorozat meglévő pontjaihoz. Elmenti a prezentációt, újra megnyitja, és kiírja a tárolt értékeket.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

A pontérték forrástípus különálló a [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)-tól, amely a diagram belső vagy külső munkafüzet‑konfigurációját azonosítja. A numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is elérhető a kategóriacímkék, sorozatnevek és a többi sorozat számára. Lásd a [Chart Workbook](/slides/hu/python-net/chart-workbook/)‑t a munkafüzet‑kezeléshez.

Szórt és buborékdiagramok esetén állítsa a [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) és a [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) értékét a [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) és [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/) forrásainak kiválasztásához. A buborékdiagramok a [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) segítségével határozzák meg a [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/) forrását. Minden alkalmazandó forrást állítson `DOUBLE_LITERALS`‑re, mielőtt a számokat a `as_literal_double` tulajdonsággal rendeli hozzá.

## **A diagram sorozat átfedésének beállítása**

A [ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) azt jelzi, hogy a sávok vagy oszlopok mennyire fedik át egymást egy 2D diagramon, -100 és 100 százalék között. Ez a beállítás csak olvasható, és a szülő sorozatcsoport beállításának kivetítése. A [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) módosításával frissítheti az összes kompatibilis sorozatot az adott csoportban. Ez a lehetőség azokra a diagramtípusokra vonatkozik, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; nem érinti a kombinációs diagramok nem kapcsolódó sorozatcsoportjait.

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

![A sorozat átfedése](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

Használja a [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)‑t az egész sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) beállítása felülírja a sorozat kitöltését az adott pontnál.

Az alábbi példa egy egységes kék kitöltést alkalmaz az első sorozatra:

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

A sorozat neve a diagram adat‑munkafüzetben van tárolva, és általában a jelmagyarázatban jelenik meg. Egy csoportosított oszlopdiagram alapértelmezett munkafüzetében a B1 cella (0‑sor, 1‑oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a névkonstansok egyértelművé teszik ezt a struktúrát:

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

A [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) által már hivatkozott cellát is frissítheti. Ez a megközelítés elkerüli, hogy egy adott sorra és oszlopra feltételezést tegyen egy már létező diagram esetén:

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

### **Sorozat létrehozása több cellából származó névvel**

Összetett sorozatnév hasznos, ha a termék neve és a jelentési időszak külön cellákban van tárolva. Például a `Product A` értéket a B1‑ben és a `2026` értéket a C1‑ben egyetlen sorozatnévvé egyesítheti, miközben mindkét rész továbbra is a forráscellához kapcsolódik.

Használja a [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/)‑t a névtartomány lekéréséhez, majd adja át ezt a gyűjteményt a [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/)‑nak. A `skip_hidden_cells` argumentum szabályozza, hogy a rejtett cellák bele legyenek-e foglalva: `True` kizárja őket, míg `False` belefoglalja. Ez a példa `False`‑t használ, hogy minden cellát belevegyen a névtartományba.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák csak a sorozatnevét szolgáltatják; az A2:A3 a kategóriacímkéket, a B2:B3 a numerikus értékeket adja.

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

    # Ez a két cella adja meg a sorozat nevét.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Külön cellák adják meg a kategóriákat és a numerikus adatpontokat.
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

Az eredményül kapott sorozatnév `Product A 2026`, egy szóközzel a két cellaérték között. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép a mentett prezentációból lett renderelve:

![Oszlopdiagram északi és déli értékekkel, valamint a `Product A 2026` összetett sorozatnévvel a jelmagyarázatban](composite_series_name.png)

## **Az automatikus sorozat‑kitöltőszín lekérdezése**

A [ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) visszaadja a sorozat indexéből és a diagramstílusból számított színt. Ez a szín akkor használatos, ha a sorozat kitöltése nem lett kifejezetten definiálva. A metódus hívása csak a számított színt olvassa; nem állít be új kitöltést.

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

Példa kimenet az alapértelmezett diagramstílusra:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagramstílustól és a témától függenek.

## **Invertált kitöltőszín beállítása egy diagram sorozathoz**

Sáv-, oszlop- és buborék‑sorozatok esetén a [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negatív értékeket másik kitöltéssel jeleníthet meg. Állítsa be a szabályos sorozatkitöltést szilárdra, engedélyezze az invertálást, és adja meg a negatív érték színét a [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa egy sorozattal helyettesíti az alapértelmezett diagramadatokat. Az 0. munkalap sorában a sorozat neve, az 0. oszlopban a kategórianevek, az 1. oszlopban pedig az értékek találhatók:

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

Inverziót egy pontnál a [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) segítségével is aktiválhatja. Az alábbi példában az inverzió a sorozatnál le van tiltva, csak a kiválasztott pontnál van engedélyezve. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

Egy pont üresen hagyásához anélkül, hogy a többi pontot eltávolítaná, állítsa a háttér‑munkafüzet‑cellát `None`‑ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/)‑n keresztül érhető el. Az adatpont a ugyanazon kategóriapozícióban marad, de a diagram a beállított üres‑érték szabályok szerint üresként kezeli.

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

A szórt diagramok X és Y cellákat, a buborékdiagramok pedig egy méretcellát használnak. Csak azt a cellát törölje, amely az eltávolítandó értéket tartalmazza. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)‑t, ha a többi pontot meg szeretné tartani, mivel ez a metódus minden adatpontot eltávolít a gyűjteményből.

## **Üres cellák megjelenésének szabályozása**

A rejtett, értéket tartalmazó cellák külön esetet képeznek az üres celláktól. A rejtett munkalapsorok és -oszlopok adatainak fel‑ vagy kizárásához tekintse meg a [Include Data from Hidden Rows and Columns](/slides/hu/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) oldalt.

Egy üres munkafüzet‑cellát hiányzó adatnak tekintünk; a `0` értéket tartalmazó cella ismert numerikus értéket jelent. A [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/)‑t `None`‑ra állítva üressé teheti a cellát. A numerikus nulla minden esetben megmarad, függetlenül az üres‑cellás beállítástól.

Használja a [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)‑t, hogy kiválassza, a diagram hogyan jeleníti meg az üres cellákat. Ez a beállítás az egész diagramra vonatkozik. Megváltoztatja, hogyan kerülnek a hiányzó helyek ábrázolásra, anélkül, hogy az üres munkafüzet‑cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3. nap értékét törli, és minden mód esetén elmenti ugyanazt a diagramot. Nem szükséges bemeneti fájl. A [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) a 0‑as munkalapon, 0‑as oszlopban a kategóriacímkéket, 1‑es oszlopban az értékeket használja; a 0‑as sor a sorozat nevét tartalmazza. A végső adatok: `10, 20, empty, 30, 40`.

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

    # Hagyd a 3. napot valódi üresen, miközben megtartod a kategóriáját és adatpontját.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és egyszer mentse el a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: Gap szünetet okoz a vonalon a 3. napnál, Zero a vonalat nullára viszi, a Span összeköti a 2. és 4. napot.](display_blanks_as.png)

A látható hatás a diagramtípustól függ. A vonaldiagram három módot könnyen összehasonlíthatóvá tesz. Oszlop- és sávdiagramok esetén nincs vonal a hiányzó kategória áthidalásához, így a `SPAN` nem tudja előállítani a fenti összekötő szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop is hasonlónak tűnhet. Hasonlóképp, egy csak jelölőkkel rendelkező szórt diagramnak nincs összekötő vonala. Ne várjon három különálló eredményt minden diagramtípusnál; ellenőrizze a kimenetet az adott típusnál.

## **A sorozat hézag szélességének beállítása**

A hézag szélesség a szomszédos sáv‑ vagy oszlopklaszterek közötti térköz, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Állítsa be egyszer a [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)‑t a csoportra. A nagyobb érték nagyobb térközt hoz létre a klaszterek között; a kisebb érték sűrűbbé teszi azokat.

Az alábbi példa módosítja a hézag szélességét, és csak a végső prezentációt menti el:

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

![A hézag szélessége](gap_width.png)

## **Sorozatvonalak megjelenítése vagy elrejtése**

A sorozatvonalak vizuálisan összekötik a diagram kapcsolódó részeit. Használja a [ChartSeriesGroup.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/has_series_lines/)‑t a támogatott halmozott sáv‑ és OfPie diagramokon való megjelenítésük vagy elrejtésük érdekében. Két dimenziós halmozott sáv‑ és oszlopdiagramokban a sorozatvonalak a megfelelő halmozási határokat kötik össze a kategóriák között. Pie of Pie és Bar of Pie diagramokban a fő ábrát kötik össze a másodlagos ábrával. Ez a beállítás nem általános összekötő más diagramtípusokhoz.

A csoportot a [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) segítségével érheti el. A beállítás minden sorozatra vonatkozik ebben a csoportban. A [ChartSeries.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/has_series_lines/) csak olvasható, és a szülőcsoport beállítását tükrözi; a csoport tulajdonságának módosításával frissíthető.

Az alábbi példa egy [ChartType.PIE_OF_PIE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) diagramot hoz létre alapértelmezett adatokkal. Elmenti ugyanazt a diagramot sorozatvonalakkal engedélyezve, majd letiltva, így két prezentációt kap összehasonlításra.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 400)
    series = chart.chart_data.series[0]
    series_group = series.parent_series_group

    series_group.has_series_lines = True
    presentation.save("series_lines_enabled.pptx", slides.export.SaveFormat.PPTX)

    series_group.has_series_lines = False
    presentation.save("series_lines_disabled.pptx", slides.export.SaveFormat.PPTX)
```

| Sorozatvonalak engedélyezve | Sorozatvonalak letiltva |
| --- | --- |
| ![Pie of Pie diagram sorozatvonalakkal](series_lines_enabled.png) | ![Pie of Pie diagram sorozatvonalak nélkül](series_lines_disabled.png) |
| A két vonal a fő kördiagramot köti össze a másodlagos kördiagrammal. | Mindkét kördiagram látható, de a csatlakozó vonalak rejtve vannak. |

A sorozatvonalak különböznek az adatcímke vezetővonalaitól, amely címkéket köt a data pontjaikhoz; a rácsvonalaktól, amelyek a diagram tengelye mentén jelölik az intervallumokat; valamint a vonaldiagram vonalaitól, amelyek az adatértékeket reprezentálják. Ez a beállítás nem szabályozza ezeket az elemeket.

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes diagramtípus, amelyet a [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) felsorolja, használ diagramadatokat, de sorozataik nem mindegyiküknek ugyanaz a értékszerkezete vagy beállításai. Például a kategóriadiagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborékdiagramok pedig buborékméreteket. Használja a sorozattípusnak megfelelő adat‑pont létrehozási módszert. Az olyan opciók, mint az átfedés és a hézag szélesség, csak a kompatibilis sáv‑ vagy oszlopsorozatokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinációs diagram több mint egy csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint a [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategóriagyűjteményeket is kiürítheti egy teljesen egyedi adatkészlet hozzáadása előtt. Egy overload segítségével létrehozható diagram alapértelmezett adatok nélkül is.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet‑cellákhoz?**

A sorozatnevek, kategóriacímkék és adat‑pont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyedi adat létrehozásakor tartsa összehangoltan a kategória‑sorokat és a sorozat‑érték‑sorokat, hogy minden pont a megfelelő kategória alatt jelenjen meg.

**Hogyan törölhetek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `None`‑ra, hogy a pont kategóriapozíciója üres pontként maradjon. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) csak akkor használatos, ha az összes pontot el kívánja távolítani az adott sorozatból, mivel ez a metódus minden adatpontot eltávolít a gyűjteményből.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)-tól függ. A támogatott diagramok üres értékeket jeleníthetnek meg hézagokként, nullákként vagy a szomszédos pontok összekapcsolásával. Válassza ki a saját prezentációja adatcéljának megfelelő beállítást. Tekintse meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv‑, oszlop‑ és buborék‑sorozatok esetén engedélyezze a [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) beállítást, és adja meg a [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) színét. Egyetlen pontnál a [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) felülbírálhatja a viselkedést. Ezek a tulajdonságok a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha a sorozat és a pont is formázva van?**

A kifejezett adat‑pont formázás előnyben részesül az adott pontnál. A többi pont továbbra is az explicit sorozat‑formázást vagy, ha az nincs definiálva, az automatikus diagramstílust és témát használja. A csoport‑tulajdonságok, mint az átfedés és a hézag szélesség, az elrendezést szabályozzák, és nem pont‑szintű formázási felülírások.

**Van korlátozás arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem határoz meg külön álló fix sorozatszám‑korlátot. Gyakorlatban a prezentáció‑fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl messze vannak egymástól?**

Állítsa be a megfelelő szülő sorozatcsoporton a [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)‑t. Növelje az értéket a klaszterek közötti térköz növeléséhez, vagy csökkentse, ha a klasztereket közelebb szeretné hozni.