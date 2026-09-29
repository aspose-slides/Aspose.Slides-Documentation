---
title: Diagram adatcímkék kezelése bemutatókban Python segítségével
linktitle: Adatcímke
type: docs
url: /hu/python-net/chart-data-label/
keywords:
- diagram
- adatcímke
- adatpont pontosság
- százalék
- címke távolság
- címke hely
- PowerPoint
- bemutató
- Python
- Aspose.Slides
description: "Tanulja meg hozzáadni és formázni a diagram adatcímkéket a PowerPoint bemutatókban az Aspose.Slides for Python via .NET használatával, hogy vonzóbb diákat hozzon létre."
---
## **Bevezetés**

Az adatcímkék információt jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasót az értékek azonosításában és a diagram megértésében. Ez a cikk bemutatja, hogyan formázhatja az értékeket, jeleníthet meg százalékokat, olvashatja a címke szöveget, kezelheti a címkéket a tengely maximuma felett, állíthatja be a kategóriatengely címke távolságát, és elhelyezheti a kördiagram címkéit.

## **Az adatcímkék pontosságának beállítása a diagram adatcímkéiben**

Használja a [number_format_of_values](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/number_format_of_values/) metódust a sorozat értékek formázásához. Ez a példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozatra. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná az alapértékeket.

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

## **Százalékos értékek megjelenítése címkeként**

Egy halmozott oszlopdiagram esetén számítsa ki minden értéket a kategóriaösszeg százalékaként, és rendelje a szöveget a [text_frame_for_overriding](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) mezőhöz. Ez a példa az alapértelmezett diagram adatokat használja, és két tizedesjegy pontossággal, 8 pontos betűmérettel jeleníti meg a százalékokat. A nulla összegű kategóriákat kihagyja, hogy elkerülje a nullával való osztást. A diagram adatai megváltoznak, újraszámolja az egyéni címke szöveget.

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

## **Százalékjel beállítása diagram adatcímkékkel**

Ha az értékek törtként vannak tárolva, használja a [number_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabelformat/number_format/) beállítást a százalékos megjelenítéshez. Állítsa az [is_number_format_linked_to_source](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) értékét `False`‑ra, hogy a címke formátuma független legyen a forráscelláktól.

Ez a példa egy 100 %‑os halmozott oszlopdiagramot hoz létre piros és kék sorozattal négy kategóriában. Minden értékpár összege 1. A `0.0%` címkeformátum 0.30‑at 30.0 %-ként jelenít meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget kap.

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

Használja a [get_actual_label_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) metódust az adatcímke beállításai által előállított szöveg lekéréséhez. Ez hasznos jelentések címkéinek kinyerésénél, a bemutató tartalmának keresésénél vagy a generált diagramok ellenőrzésénél. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabelformat/) minden kategórianév, sorozatnév és érték kombinációját jeleníti meg. Egy pont az értékét százalékos formátumban, egy másik pedig a [text_frame_for_overriding](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) egyéni szövegét használja.

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

A datapontban tárolt szám továbbra is `0.75`, még ha a címkéje `75%`‑ot is mutat a kategória- és sorozatnevekkel együtt. Az egyéni szöveg felülírja a generált címket. A [get_actual_label_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) mindkét esetben a kapott címkesztringet adja vissza. Ellenőrizze külön a [is_visible](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/is_visible/) állapotát, ahogy fent is látható, ha csak a látható címkéket szeretné kinyerni.

## **Adatcímkék vezérlése a tengely maximuma felett**

Ha manuálisan korlátozza a tengely tartományát, egyes adatpontok meghaladhatják a maximális értéket. Használja a [show_data_labels_over_maximum](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) beállítást annak szabályozására, hogy ezek a címkék megjelenjenek-e. Ez a beállítás a címke láthatóságát változtatja; nem módosítja a tengely tartományát vagy az alapadat-értékeket.

Az alábbi példa egy 2D csoportosított oszlopdiagramot hoz létre 60 és 120 értékekkel. A függőleges tengelyen az [is_automatic_max_value](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/axis/is_automatic_max_value/) értéke `False`, a [max_value](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/axis/max_value/) pedig 100. Az első dián a címkék a maximum felett is megjelennek; egy másolatban ezt letiltja. Mindkét diát a `DataLabelsOverMaximum.pptx` fájlba menti.

Aktiválja az értékcímkéket a [show_value](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabelformat/show_value/) segítségével. A diagram szintű beállítás önmagában nem jeleníti meg az értékeket, és nem írja felül egyetlen egyedi címke letiltott megjelenítését sem. Ez a példa minden sorozatra engedélyezi az értékek megjelenítését, és a [position](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabelformat/position/) segítségével a címkéket az oszlopok külső végére helyezi.

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

Az alábbi képek a Microsoft PowerPoint által renderelt mentett diákat mutatják. `True` esetén a **120** címke látható a felső határon; `False` esetén rejtve van. A **60** címke továbbra is látható, a tengely maximuma **100** marad, és a második adatpont **120** mindkét esetben megmarad.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ez a példa egy 2D oszlopdiagramot használ értéktengellyel. Az olyan diagramok, mint a kör- vagy fánkdiagram, nem rendelkeznek értéktengellyel, így nem korlátozhatók ilyen módon.
{{% /alert %}}

## **Címke távolság beállítása a tengelytől**

Használja a [label_offset](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/axis/label_offset/) beállítást a kategória tengely címkék és a tengely közötti távolság szabályozásához. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategóriatengely címkéire vonatkozik, nem az egyedi adatpontok címkéire.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Címke helyének finomhangolása**

Kördiagram esetén a adatcímkék pozícióját állítsa be a jobb térköz és a vezetővonalak helyének biztosítása érdekében.

Ez a példa megjeleníti az első adatpont értékét, a címkét a szelet kívül helyezi, és a [x](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/x/) és [y](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/y/) eltolásokat állítja be. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva vannak.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **GYIK**

**Hogyan lehet megakadályozni, hogy a sűrű diagramokon az adatcímkék átfedjék egymást?**  
Kombináljon automatikus címkeelhelyezést, vezetővonalakat és kisebb betűméretet; szükség esetén rejtsen el néhány mezőt (például a kategóriát), vagy csak a szélső értékekhez illetve kulcspontokhoz jelenítsen meg címkéket.

**Hogyan tilthatók le a címkék csak a nulla, negatív vagy üres értékeknél?**  
Szűrje le az adatpontokat a címkék engedélyezése előtt, és kapcsolja ki a megjelenítést 0, negatív vagy hiányzó értékek esetén egy meghatározott szabály szerint.

**Hogyan biztosítható a konzisztens címkestílus PDF‑/képfájlok exportálásakor?**  
Állítsa be kifeexplicit a betűcsaládot és a méretet, és ellenőrizze, hogy a betűkészlet elérhető legyen a renderelő környezetben, hogy elkerülje a helyettesítő betűket.