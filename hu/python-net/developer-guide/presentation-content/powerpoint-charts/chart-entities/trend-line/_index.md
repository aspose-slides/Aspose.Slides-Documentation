---
title: Trendvonalak hozzáadása a prezentáció diagramokhoz Pythonban
linktitle: Trendvonal
type: docs
url: /hu/python-net/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgó átlag trendvonal
- polinomiális trendvonal
- hatvány trendvonal
- egyéni trendvonal
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Gyorsan adjon hozzá és testreszabjon trendvonalakat a PowerPoint-diagramokban az Aspose.Slides for Python (via .NET) segítségével – gyakorlati útmutató, amely segít lekötni a közönséget."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet trendvonalakat hozzáadni a prezentáció diagramokhoz az Aspose.Slides használatával. Bemutatja, hogyan hozhatunk létre diagramot, hogyan adhatunk trendvonalakat a diagram sorozataihoz, és hogyan dolgozhatunk többféle trendvonal típussal, köztük exponenciális, lineáris, logaritmikus, mozgó átlag, polinomiális és hatvány.

Leírja továbbá, hogyan adhatunk egy egyéni vonalat a diagramhoz egy vonal alakzat beillesztésével, és egy rövid GYIK-ot is tartalmaz a trendvonal előre és hátra vetítési értékeiről, valamint arról, hogy a trendvonalak megmaradnak-e a PDF vagy SVG formátumba exportálás során, illetve a diagramok képként történő megjelenítésekor.

## **Trendvonal hozzáadása**

Használja a [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) metódust trendvonal hozzáadásához egy diagram sorozatához, a típusának kiválasztásához a [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/) segítségével. A példa egy klaszterelt oszlopdiagramot hoz létre alapértelmezett adatokkal, és minden három sorozatához két trendvonalat ad hozzá.

Az exponenciális trendvonal elrejti az egyenletét és az R-négyzet értékét a [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) és a [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/) segítségével, míg a lineáris trendvonal piros. A logaritmikus trendvonal a [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/)‑t használja egy egyéni felirathoz. A mozgó átlag egy három adatpontból álló [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) használ, és egy egyéni [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/).

A polinomiális trendvonal [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) három, és egy kategóriát előre nyújt a [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/) segítségével. A hatvány trendvonal egy kategóriát hátra nyújt a [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/) használatával.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Trendvonal metszéspont beállítása**

Használja a [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) metódust a trendvonal Y értékének X = 0‑nál rögzítéséhez. Ez a beállítás támogatott lineáris, exponenciális és polinomiális trendvonalak esetén.

Például egy termelési költség modellnek 100 ismert fix költségnél kell kezdődnie, még akkor is, ha a nem nulla termelési mennyiségeknél végzett mérések más kiindulási pontot jelölnek. Egy lineáris trendvonal esetén a metszéspont rögzítése a `y = ax + b` egyenletet `b = 100`‑ra korlátozza; a meredekség a korlátozás mellett lesz illesztve az adatokra. Ez nem egyszerűen mozgat egy már illesztett vonalat. A tengelykeresztelés beállítások irányítják, ahol a diagram tengelyei találkoznak, nem pedig a trendvonal illesztett együtthatóit.

Az alábbi példa egy szórt (XY) diagramot hoz létre, amely 1‑4 közötti termelési mennyiségeket és 170, 200, 230 és 260 költségeket tartalmaz. A diagramot az alapértelmezett automatikus metszésponttal menti, beállítja a metszéspontot 100‑ra, és egy második PPTX‑et ment. A két fájl csak a metszéspont beállításában különbözik. A trendvonal megjeleníti az egyenletét, és visszanyúlik X = 0‑ig.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

Automatikus számítással ezek az adatok `y = 30x + 140`‑at eredményeznek. Ha a metszéspontot 100‑ra állítjuk, akkor megközelítőleg `y = 43.33x + 100` jön létre: a nulla helyen illesztett érték egyezik a ismert kiindulási ponttal, míg a vonal már nem halad át minden adatponton.

| Automatikus metszéspont | Fix metszéspont 100 |
| --- | --- |
| ![Lineáris trendvonal automatikusan számított metszésponttal 140](intercept-automatic.png) | ![Lineáris trendvonal 100-as fix metszésponttal](intercept-fixed.png) |

Mindkét kép ugyanazt az adatot és tengely skálát használja. A trendvonalak visszanyúlnak X = 0‑ig, hogy megmutassák a metszéspontjaikat.

Alapértelmezés szerint a tulajdonság `float("nan")` értéket tartalmaz, ami egy nem meghatározott metszéspontot jelöl, nem nullát. A metszéspont ezután automatikusan lesz kiszámítva az adatokból.

## **Egyéni vonal hozzáadása**

Egy egyéni vonal egy alakzat, amely a diagram felett van megrajzolva, nem pedig a sorozat adatból számított trendvonal. Ez a példa a [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) metódust használja egy vízszintes vonal hozzáadásához a diára a diagram fölött. A vonal pozíciója a diának koordinátáiban, pontokban megadott, ezért a diagram bal szélénél kezdődik és a diagram közepénél áll. Szélessége megegyezik a diagram szélességével. A [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) a vonalat egy szilárd piros színnel látja el.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Mit jelent a 'forward' és a 'backward' egy trendvonalnál?**

Az előre vagy hátra vetített trendvonal hosszát jelentik: szórt (XY) diagramok esetén – tengelyegységekben; nem szórt diagramok esetén – kategóriák számban. Csak nem negatív értékek engedélyezettek.

**Megmarad a trendvonal a prezentáció PDF vagy SVG formátumba exportálásakor, illetve a dia képként történő renderelésekor?**

Igen. Az Aspose.Slides prezentációkat [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/) vagy [SVG](/slides/hu/python-net/render-a-slide-as-an-svg-image/) formátumba konvertál, és diagramokat képekbe renderel; a trendvonalak, mint a diagram részei, megmaradnak ezek során. Egy metódus is elérhető a diagram [képének exportálásához](/slides/hu/python-net/create-shape-thumbnails/).