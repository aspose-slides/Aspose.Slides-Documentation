---
title: Diagramadatcímkék kezelése prezentációkban Python segítségével
linktitle: Adatcímke
type: docs
url: /hu/python-net/chart-data-label/
keywords:
- diagram
- adatcímke
- adatpontosság
- százalék
- címke távolság
- címke hely
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és formázhat diagramadatcímkéket PowerPoint prezentációkban az Aspose.Slides for Python via .NET használatával, hogy vonzóbb diák legyenek."
---
## **Bevezetés**

Az adatcímkék információkat jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk bemutatja, hogyan formázhatja az értékeket, jelenítheti meg a százalékokat, olvashatja a címkeszöveget, szabályozhatja a címkéket a tengely maximumán túl, állíthatja a kategóriatengely címkéinek távolságát, és helyezheti el a kördiagram címkéit.

## **Adatcímkék pontosságának beállítása a diagram adatcímkéknél**

Használja a [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) függvényt a sorozatértékek formázásához. Ez a példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozathoz. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy a mögöttes értékeket megváltoztatná.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Százalékok megjelenítése címkékként**

Halmozott oszlopdiagram esetén számolja ki minden értéket a kategória összegének százalékaként, és rendelje a szöveget a [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) elemhez. Ez a példa az alapértelmezett diagramadatokat használja, és százalékokat jelenít meg két tizedesjeggyel, 8 pontos betűmérettel. A nullára kerekített összegű kategóriákat kihagyja, hogy elkerülje a nullával való osztást. Számolja újra az egyéni címkeszöveget, ha a diagram adatai megváltoznak.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Százalékjel beállítása a diagram adatcímkéknél**

Ha az értékek törtként vannak tárolva, használja a [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) függvényt a százalékok megjelenítéséhez. Állítsa az [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) értékét `False`-ra, hogy a címkeformátumot a forráscelláktól függetlenül alkalmazza.

Ez a példa egy 100%-os halmozott oszlopdiagramot hoz létre piros és kék sorozatokkal négy kategóriában. Minden értékpár összege 1. A `0.0%` címkeformátum a 0.30-at 30.0%-ként jeleníti meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget használ.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Az adatcímkék tényleges szövegének lekérdezése**

Használja a [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) függvényt az adatcímke beállításai által előállított szöveg lekéréséhez. Ez hasznos riportokhoz címkék kinyerésekor, a prezentáció tartalmának keresésekor vagy a generált diagramok validálásakor. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) egyesíti minden kategórianév, sorozatnév és érték. Egy pont százalékosan formázza az értékét, egy másik pedig egyéni szöveget használ a [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)-ból.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

Az adatpontban tárolt szám `0.75` marad, még akkor is, ha a címkéje `75%`-ot mutat a kategória és sorozat nevekkel együtt. Az egyéni szöveg felülírja a generált címkeszöveget. A [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) ebben az esetben is a kapott címkesztringet adja vissza. Ellenőrizze külön a [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) értékét, ahogyan fent is látható, amikor csak a látható címkéket szeretné kinyerni.

## **Adatcímkék kezelése a tengely maximumán túl**

Ha manuálisan korlátozza egy tengely tartományát, egyes adatpontok túlléphetik a maximumot. Használja a [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) függvényt annak szabályozására, hogy megjelenjenek-e az adatcímkék. Ez a beállítás a címkék láthatóságát változtatja; nem módosítja a tengely tartományát vagy a mögöttes adatértékeket.

Az alábbi példa egy 2D csoportos oszlopdiagramot hoz létre 60 és 120 értékekkel. Beállítja a [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) értékét `False`-ra, és a függőleges tengelyen a [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) értékét 100-ra. Az első dia engedélyezi a maximumon túli címkéket; egy másolat letiltja őket. Mindkét dia a `DataLabelsOverMaximum.pptx` fájlba van mentve.

Értékcímkéket engedélyezhet a [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) segítségével. A diagram szintű beállítás önmagában nem aktiválja az értékek megjelenítését, és nem írja felül egy adott címke letiltott értékmutatását. Ez a példa az egész sorozatra engedélyezi az értékeket, és a [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) segítségével a címkéket minden oszlop külső végére helyezi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

Az alábbi képek a Microsoft PowerPoint által renderelt mentett diákot mutatják. `True` esetén a **120** címke látható a felső határon; `False` esetén el van rejtve. A **60** címke továbbra is látható, a tengely maximum **100** marad, és a második adatpont mindkét esetben **120**.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ez a példa egy 2D oszlopdiagramot használ érték tengellyel. Az érték tengely nélküli diagramok, például a kör- és a fánkdiagramok, nem rendelkeznek tengely maximumgal, amelyet így korlátozni lehetne.
{{% /alert %}}

## **Címke távolságának beállítása a tengelytől**

Használja a [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) függvényt a kategóriatengely címkéi és a tengely közötti távolság szabályozásához. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportos oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategóriatengely címkéire hat, nem az egyes adatpontokhoz csatlakozó címkékre.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Címke helyének szabályozása**

Kördiagramon állítsa be az adatcímkék pozícióját a távolság javítása és a vezetővonalak számára hely biztosítása érdekében.

Ez a példa az első adatpont értékét jeleníti meg, a címkét a szelet kívülére helyezi, és módosítja a [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) és [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) eltolásait. Ezek az eltolások a diagram szélességére és magasságára vonatkozóan relatívak.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Kördiagram módosított adatcímke pozícióval](pie-chart-adjusted-label.png)

## **Több sor adatcímke hozzáadása oszlopdiagram fölé**

Ez a példa egy oszlopdiagramot hoz létre, ahol a rajzterület fölött két sor adatcímke van. Az A sorozat a látható oszlopokat jeleníti meg, míg a B és C sorozatok a további címkéket biztosítják. Az oszlopaik a kitöltés és a körvonal eltávolításával vannak elrejtve. Az [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) tulajdonság mindhárom sorozatot ugyanazon kategóriaközéppontokra igazítja.

A [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) beállítások helyet tartanak fenn a címkesorok számára. A [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) kiszámítja az alapértelmezett pozíciókat, ezután a [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) és [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) megőrzik a vízszintes igazítást, és függőleges eltolásokat alkalmaznak a címkék két sorba rendezéséhez. A számok továbbra is adatcímkék maradnak, amelyek a sorozat értékéhez vannak kapcsolva; csak a sorfejlécek külön szöveges alakzatok.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # Rejtse el a B és C oszlopokat, de tartsa meg az adatcímkéket.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Igazítsa a három sorozatot ugyanarra a kategóriaközépre.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Használjon kevesebb rácsvonalat ebben a kompakt példában.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Tartson fenn helyet a diagram felett két sor adatcímkének.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # Tartsa meg az alapértelmezett vízszintes pozíciót. Y egy eltolás a
            # az alapértelmezett címkehelyzetből, a diagrammagasság hányadosaként kifejezve.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Csak a sorfejléc egy külön szöveges alakzat.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Oszlopdiagram két sor adatcímkével a rajzterület fölött](multiple-rows-of-labels.png)

## **FAQ**

**Hogyan lehet megakadályozni, hogy az adatcímkék átfedjék egymást sűrű diagramokon?**

Kombinálja az automatikus címkeelhelyezést, a vezetővonalakat és a csökkentett betűméretet; szükség esetén rejtsen el bizonyos mezőket (például a kategóriát), vagy csak a szélső értékek vagy kulcspontok esetén jelenítse meg a címkéket.

**Hogyan lehet a címkéket csak a nulla, negatív vagy üres értékeknél letiltani?**

Szűrje ki az adatpontokat a címkék engedélyezése előtt, és kapcsolja ki a megjelenítést a 0, negatív vagy hiányzó értékek esetén egy meghatározott szabály szerint.

**Hogyan biztosítható a konzisztens címkestílus PDF-/képfájl exportálásakor?**

Állítsa be kifejezetten a betűtípust és méretet, és ellenőrizze, hogy a betűtípus elérhető legyen a renderelő környezetben a visszaesés elkerülése érdekében.