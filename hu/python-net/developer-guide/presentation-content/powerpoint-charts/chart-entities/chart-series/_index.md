---
title: Diagram adat sorozatok kezelése prezentációkban Pythonban
linktitle: Adatsorozat
type: docs
url: /hu/python-net/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- kategória szín
- sorozat név
- adatpont
- sorozat hézag
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban Python segítségével."
---
## **Áttekintés**

A diagram tárolhatja a megjelenített értékeket a munkafüzet celláiban vagy közvetlenül numerikus literálokként. A [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) egy kapcsolódó értékcsoportot képvisel, és minden [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) egy pontot jelent ebben a sorozatban. A [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. Az alapértelmezett adatokkal létrehozott diagramok esetén a sorozatnevek, kategóriák és pontértékek a diagram munkafüzetéből származó [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) objektumokat használják.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0. sort a sorozatneveknek, a 0. oszlopot a kategórianéveknek, a maradék cellákat pedig a sorozatértékeknek használja. A [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) metódusnak átadott munkalap‑, sor‑ és oszlopindexek nullára indulnak. Ez a felépítés hasznos, ha alapértelmezett adattal hoz létre diagramot, de ne vegye alapul, hogy minden meglévő diagram ezt a felépítést használja. Betöltött prezentáció esetén ellenőrizze a sorozat, kategória és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit megváltoztatná.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Az egy sorozatra vonatkozó beállítások, például a [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), egy sorozat összes pontjának alapértelmezett megjelenését adják.
- Az adatpont beállítások, például a [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), felülírják a sorozat megjelenését egy adott pontnál.
- A csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) tartoznak. A csoporthoz a [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) használatával férhet hozzá, ha olyan opciókat kell beállítania, mint az átfedés vagy a hézag szélessége.

Ha nincs kifejezetten megadva pont‑ vagy sorozat‑kitöltés, a diagram stílusa és témája határozza meg a automatikus megjelenítést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása él az adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A sorozat értékek beállítása numerikus literálokkal**

Használjon numerikus literálokat, ha a sorozatértékek alkalmazás‑adatokból vagy számításokból származnak, és nincs szükség munkalap‑cellahivatkozásokra. Állítsa a [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) értékét [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/)‑re, mielőtt minden pont [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) tulajdonságát a [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/) segítségével állítaná be.

A gyűjtemény‑beállítás irányítja az adott sorozat összes pontértékének forrástípusa. Minden egyes pont [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) a kiválasztott típust jelzi; ezt a gyűjtemény‑beállítással módosíthatja. `WORKSHEET` esetén a [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) használatával érheti el a hivatkozott cellát. `DOUBLE_LITERALS` esetén az `as_literal_double` segítségével olvashat vagy írhat számot közvetlenül.

Az alábbi példa egy oszlopdiagramot hoz létre alapértelmezett sorozatokkal és kategóriákkal, majd a meglévő első sorozat pontjaira 10, 20 stb. számított értékeket rendeli hozzá. Elmenti a prezentációt, újra megnyitja, és kiírja a tárolt értékeket.

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

A pontérték forrástípusa elkülönül a [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)‑től, amely a diagram belső vagy külső munkafüzet‑konfigurációját azonosítja. Numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is elérhető a kategória címkék, a sorozatnevek és a többi sorozat számára. Lásd a [Chart Workbook](/slides/hu/python-net/chart-workbook/) oldalt a munkafüzet‑kezeléshez.

Szórt és buborék diagramok esetén állítsa be a [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) és a [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) értékét, hogy kiválassza az [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) és [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/) forrását. A buborék diagramok továbbá a [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/)‑t használják a [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/) meghatározásához. Minden alkalmazandó forrást állítson `DOUBLE_LITERALS`‑re, mielőtt a számot a `as_literal_double` tulajdonságán keresztül rendeli hozzá.

## **A diagram sorozat átfedésének beállítása**

A [ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) megadja, hogy a 2D diagramokban a sávok vagy oszlopok milyen mértékben fednek át egymás felett, –100‑tól 100‑ig százalékban. Ez egy csak‑olvasható leképezése a szülő sorozatcsoport beállításának. Állítsa be a [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/)‑t, hogy minden kompatibilis sorozatot frissítsen az adott csoportban. Ez a lehetőség a csoportos sáv‑ vagy oszlop‑típusú diagramokra vonatkozik; a kombinált diagramok nem‑kapcsolódó sorozatcsoportjait nem befolyásolja.

Az alábbi példa beállítja az átfedést a első sorozatot tartalmazó csoportra:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Az új diagram minta sorozatokat, kategóriákat és értékeket tartalmaz.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az sorozat átfedése](series_overlap.png)

## **A sorozat kitöltőszín megváltoztatása**

Használja a [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)‑t, hogy az egész sorozathoz alapértelmezett kitöltést állítson be. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) beállítása felülírja a sorozat kitöltését az adott pontnál.

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

## **A sorozat nevének megváltoztatása**

A sorozat neve a diagram adat‑munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett, csoportosított oszlopdiagramhoz létrehozott munkafüzetben a B1 cella (0. sor, 1. oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a névkonstansok ezt a struktúrát teszik egyértelművé:

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

A cellát közvetlenül is frissítheti a [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) által már hivatkozott helyen. Ez a megközelítés elkerüli a meglévő diagram sor‑ és oszlop‑indexek feltételezését:

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

### **Sorozat létrehozása több cella nevéből**

Összetett sorozatnév hasznos, ha a termék neve és a jelentési időszak külön munkafüzet‑cellákban van tárolva. Például a `Product A` (B1) és a `2026` (C1) értékeket egyetlen sorozatnévbe fűzheti, miközben mindkét rész továbbra is forrás‑cella‑hivatkozással rendelkezik.

Használja a [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/)‑t a névtartomány lekéréséhez, majd ezt a gyűjteményt adja át a [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/)‑nak. A `skip_hidden_cells` argumentum szabályozza, hogy a rejtett cellák bekerüljenek-e: `True` kizárja őket, `False` pedig beleveszi. Ebben a példában `False`‑t használunk, hogy a névtartomány minden cellája szerepeljen.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák csak a sorozatnevet szolgálják; az A2:A3 a kategória címkéket, a B2:B3 pedig a numerikus értékeket adja.

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

    # Ezek a két cella szolgáltatja a sorozat nevét.
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

Az eredményül kapott sorozatnév `Product A 2026`, a két cellaérték között szóközzel. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép a mentett prezentációból származik:

![Oszlopdiagram északi és déli értékekkel, valamint a Product A 2026 összetett sorozatnévvel a jelmagyarázatban](composite_series_name.png)

## **Az automatikus sorozat kitöltőszín lekérése**

A [ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs kifejezetten meghatározva. A metódus meghívása az automatikusan kiszámított színt olvassa, nem állít be új kitöltést.

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

A pontos színek a diagram stílusától és témájától függenek.

## **Negatív értékek kitöltőszínének invertálása egy diagram sorozatban**

Sáv‑, oszlop‑ és buborék sorozatok esetén a [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) megjelenítheti a negatív értékeket egy eltérő kitöltéssel. Állítsa be a szabályos sorozatkitöltést szilárd színűre, engedélyezze az invertálást, és adja meg a negatív érték színét a [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)‑vel. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa az alapértelmezett diagramadatot egy sorozattal helyettesíti. A 0‑s sor a sorozatnevet, a 0‑s oszlop a kategórianeveket, az 1‑es oszlop pedig az értékeket tartalmazza:

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

Az invertálást egy pontnál is engedélyezheti a [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)‑vel. Az alábbi példában a sorozat szintjén letiltottuk az invertálást, és csak a kiválasztott pontnál kapcsoltuk be. A pontnak negatív értéket is adtunk, hogy a hatás látható legyen:

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

Egy pont üresre állításához anélkül, hogy a többi pontot eltávolítaná, állítsa a mögöttes munkafüzet‑celláját `None`‑ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/)‑n keresztül érhető el. Az adatpont a kategória pozíciójában marad, de a diagram a értékét üresnek tekinti a diagram üres‑érték beállításai szerint.

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

A szórt diagramok külön X‑ és Y‑cellákat használnak, a buborék diagramok pedig egy méret‑cellát is. Csak azt a cellát törölje, amely a törlendő értéket tartalmazza. Ne hívja meg a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)‑t, ha a többi pontot megtartani szeretné, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenítésének szabályozása**

A rejtett cellák, amelyek értéket tartalmaznak, különböznek az üres celláktól. A rejtett munkalap‑sorok és -oszlopok adatait be vagy ki kell venni, lásd a [Include Data from Hidden Rows and Columns](/slides/hu/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) szekciót.

Az üres munkafüzet‑cellát hiányzó adatként kell kezelni; a `0`‑t tartalmazó cella ismert numerikus értéket jelent. Állítsa a [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/)‑t `None`‑ra, hogy a cella üres legyen. Egy numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellás beállítástól.

Használja a [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)‑t, hogy kiválassza, a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás az egész diagramra vonatkozik. Megváltoztatja, hogyan ábrázolják a hiányzó értékeket, anélkül hogy az üres munkafüzet‑cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy sorozatos vonaldiagramot hoz létre, törli a 3. nap értékét, és a három mód mindegyikével elmenti a diagramot. Nem szükséges bemeneti fájl. A [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) a 0‑s munkalapot, a 0‑s oszlopot a kategóriacímkéknek, az 1‑es oszlopot az értékeknek használja; a 0‑s sor a sorozat nevét tartalmazza. A végső adatsor: `10, 20, üres, 30, 40`.

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

    # Hagyja a 3. napot valóban üresen, miközben megtartja annak kategóriáját és adatpontját.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót akar menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok ciklikus végrehajtása helyett.

Az alábbi összehasonlítás ugyanazt a adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: a Gap megszakítja a vonalat a 3. napon, a Zero a vonalat nullához viszi, a Span összeköti a 2. napot a 4‑gyel.](display_blanks_as.png)

A látható hatás a diagram típusa szerint változik. Egy vonaldiagram esetén mindhárom mód könnyen összehasonlítható. Oszlop‑ és sávdiagramok esetén nincs vonal, amely áthidalná a hiányzó kategóriát, így a `SPAN` nem hozhat létre egy felsőbb szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen egy csupán jelölőkkel rendelkező szórt diagramnak nincs összekötő vonala. Ne számítson három különböző eredményre minden diagramtípusnál; ellenőrizze a kimenetet a saját típusához.

## **A sorozat hézag‑szélességének beállítása**

A hézag‑szélesség a szomszédos sáv‑ vagy oszlopcsoportok között lévő távolság, a sáv‑ vagy oszlop‑szélesség százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. A [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) egyszeri beállítása a csoportra elegendő. Nagyobb érték nagyobb távolságot hoz létre a csoportok között; kisebb érték sűrűbb elrendezést eredményez.

Az alábbi példa megváltoztatja a hézag‑szélességet, és csak a végleges prezentációt menti el:

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

![A hézag‑szélesség](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat‑sorozatokat?**

Az összes [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) felsorolásban szereplő diagramtípus használ diagramadatokat, de a sorozataik nem mindegyiknek ugyanaz a értékszerkezete vagy beállítása. Például a kategória diagramok kategóriákat és értékeket használnak, a szórt diagramok X‑ és Y‑értékeket, a buborék diagramok pedig buborék‑méreteket is. Használja a sorozattípusnak megfelelő adat‑pont létrehozási metódust. Az olyan opciók, mint az átfedés és a hézag‑szélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több mint egy csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Egy újonnan létrehozott diagram tartalmaz-e alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategória‑gyűjteményeket törölheti egy teljesen egyedi adatkészlet hozzáadása előtt. Egy overload segítségével diagramot is létrehozhat alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzet‑cellákhoz?**

A sorozatnevek, kategória‑címkék és adat‑pont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) celláira hivatkoznak. A hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatépítéskor tartsa összehangoltan a kategória‑sorokat és a sorozat‑érték‑sorokat, hogy minden pont a kívánt kategória alatt jelenjen meg.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `None`‑ra, hogy a pont kategória‑pozíciója üres pontként maradjon. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)‑t csak akkor használja, ha az összes pontot el szeretné távolítani az adott sorozatból. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékeik továbbra is a kategória‑gyűjteménnyel legyenek összehangolva.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusa és a [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) beállítástól függ. A támogatott diagramok megjeleníthetik az üreseknek megfelelően a hézagot, a nullákat, vagy a szomszédos pontok összekapcsolását. Válassza ki a hiányzó adatok jelentésének megfelelő beállítást a prezentációban. Tekintse meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) szekciót a teljes példáért és vizuális összehasonlításért.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv‑, oszlop‑ és buborék sorozatok esetén engedélyezze a [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/)‑t, és állítsa be a [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)‑t. Egy egyéni pont viselkedését a [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)‑vel felülbírálhatja. Ezek a tulajdonságok a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha a sorozat és a pont is formázva van?**

Az explicit adat‑pont formázás elsőbbséget élvez az adott pontnál. A többi pont továbbra is az explicit sorozat‑formátumot használja, vagy ha a sorozat‑formátum nincs definiálva, az automatikus diagram‑stílus és téma szerint. A csoport‑tulajdonságok, mint az átfedés és a hézag‑szélesség, elrendezést szabályoznak, nem pedig pont‑szintű formázási felülírások.

**Van korlátozás arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem alkalmaz különálló rögzített sorozatszám‑korlátot. Gyakorlatban a prezentációfájl‑korlátozások, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Állítsa be a [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)‑t a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti távolság szélesítéséhez, vagy csökkentse, hogy a csoportok közelebb kerüljenek egymáshoz.