---
title: Diagram adatcímkék kezelése prezentációkban Python használatával
linktitle: Adatcímke
type: docs
url: /hu/python-net/chart-data-label/
keywords:
- diagram
- adatcímke
- adatpontoság
- százalék
- címke távolság
- címke helye
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan adhatsz hozzá és formázhatsz diagram adatcímkéket PowerPoint prezentációkban az Aspose.Slides for Python via .NET segítségével, hogy vonzóbb diák készülhessenek."
---
## **Bevezetés**

Az adatcímkék információt jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk elmagyarázza, hogyan formázhatja az értékeket, jelenítheti meg a százalékokat, olvashatja a címkeszöveget, állíthatja be a kategória tengelycímkék távolságát, és pozícionálhatja a kördiagram címkéit.

## **Adatpontoság beállítása a diagram adatcímkéiben**

Használja a [number_format_of_values](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/number_format_of_values/) függvényt a sorozatértékek formázásához. Ez a példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozathoz. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a mögöttes értékeket.

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

## **Százalék megjelenítése címkeként**

Halmozott oszlopdiagram esetén számolja ki minden értéket a kategória összegének százalékában, és rendelje a szöveget a [text_frame_for_overriding](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)-hez. Ez a példa az alapértelmezett diagramadatokat használja, és a százalékokat két tizedesjeggyel, 8 pontos betűmérettel jeleníti meg. A nulla összegű kategóriákat kihagyja, hogy elkerülje a nullával való osztást. Számolja újra az egyéni címkeszöveget, ha a diagram adatai megváltoznak.

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

Ha az értékek törtként vannak tárolva, használja a [number_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabelformat/number_format/) függvényt a százalékok megjelenítéséhez. Állítsa az [is_number_format_linked_to_source](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) értékét `False`-ra, hogy a címkek formátuma független legyen a forráscelláktól.

Ez a példa egy 100%-os halmozott oszlopdiagramot hoz létre piros és kék sorozatokkal négy kategóriában. Minden értéspár összege 1. A címkeformátum `0.0%` 0.30-at 30.0%-ként jelenít meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget használ.

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

## **Az adatcímkék tényleges szövegének olvasása**

Használja a [get_actual_label_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) függvényt a diagramcímke beállításai által előállított szöveg lekérdezéséhez. Ez akkor hasznos, amikor címkéket von ki jelentésekhez, a prezentáció tartalmát keresik, vagy a generált diagramokat ellenőrzik. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabelformat/) összefűzi a kategórianév, a sorozatnév és az érték minden elemét. Az egyik pont az értékét százalékban formázza, a másik a [text_frame_for_overriding](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)-et egyéni szövegét használja.

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

Az adatpontban tárolt szám `0.75` marad, még akkor is, ha a címkéje `75%`-ot mutat a kategória- és sorozatnevekkel együtt. Az egyéni szöveg felülírja a generált címkeszöveget. A [get_actual_label_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) bármelyik esetben a kapott címkesztringet adja vissza. Ellenőrizze külön a [is_visible](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/is_visible/) értékét, ahogyan fent is látható, ha csak a látható címkéket szeretné kinyerni.

## **Címke távolságának beállítása egy tengelytől**

Használja a [label_offset](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/axis/label_offset/) függvényt a kategóriatengely címkéi és a tengely közötti távolság szabályozásához. Az érték a tengelycímkék maximális betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategóriatengely címkéire vonatkozik, nem pedig az egyes adatpontokhoz kapcsolt címkékre.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Címke helyének módosítása**

Egy kördiagramon állítsa be az adatcímkék pozícióját a térköz javítása és a vezetővonalak számára hely biztosítása érdekében.

Ez a példa megjeleníti az első adatpont értékét, a címkét a szelet kívülre helyezi, és módosítja a [x](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/x/) és [y](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/y/) eltolásait. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva vannak.

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

![Kördiagram a módosított adatcímke pozícióval](pie-chart-adjusted-label.png)

## **GYIK**

**Hogyan akadályozhatom meg az adatcímkék átfedését sűrű diagramokon?**

Használjon automatikus címkeelhelyezést, vezetővonalakat és kisebb betűméretet; szükség esetén rejtse el egyes mezőket (például a kategóriát), vagy csak a szélső értékekhez vagy kulcspontokhoz jelenítse meg a címkéket.

**Hogyan tilthatom le a címkéket csak a nulla, negatív vagy üres értékek esetén?**

Szűrje a adatpontokat a címkék engedélyezése előtt, és kapcsolja ki a megjelenítést a 0, negatív vagy hiányzó értékekre egy meghatározott szabály szerint.

**Hogyan biztosíthatom a címkestílus konzisztenciáját PDF/képek exportálásakor?**

Állítsa be kifejezetten a betűcsaládot és a méretet, és ellenőrizze, hogy a betűtípus elérhető legyen a megjelenítő környezetben, hogy elkerülje a visszahelyettesítést.