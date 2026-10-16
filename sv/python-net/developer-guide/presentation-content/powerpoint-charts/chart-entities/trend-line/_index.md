---
title: Lägg till trendlinjer i presentationsdiagram i Python
linktitle: Trendlinje
type: docs
url: /sv/python-net/trend-line/
keywords:
- diagram
- trendlinje
- exponentiell trendlinje
- linjär trendlinje
- logaritmisk trendlinje
- glidande medelvärdes trendlinje
- polynomtrendlinje
- potenstrendlinje
- anpassad trendlinje
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lägg snabbt till och anpassa trendlinjer i PowerPoint‑diagram med Aspose.Slides för Python via .NET — en praktisk guide för att engagera din publik."
---
## **Översikt**

Den här artikeln förklarar hur man lägger till trendlinjer i presentationsdiagram med Aspose.Slides. Den visar hur man skapar ett diagram, lägger till trendlinjer i diagramserier och arbetar med flera typer av trendlinjer, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynom och potens.

Den beskriver också hur man lägger till en anpassad linje i ett diagram genom att infoga ett linjeformat, och innehåller en kort FAQ om framåt‑ och bakåt‑projektion av trendlinjer samt om trendlinjer bevaras vid export till PDF eller SVG och vid rendering av diagram som bilder.

## **Lägg till en trendlinje**

Använd [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) för att lägga till en trendlinje i en diagramserie och välj dess typ med [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). Exemplet skapar ett grupperat stapeldiagram med standarddata och lägger till två trendlinjer för var och en av dess tre serier.

Den exponentiella trendlinjen döljer sin ekvation och R‑kvadrat‑värde via [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) och [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), medan den linjära trendlinjen är röd. Den logaritmiska trendlinjen använder [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) för en anpassad etikett. Det glidande medelvärdet använder en [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) på tre datapunkter och ett anpassat [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/).

Den polynomiska trendlinjen har en [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) på tre och sträcker sig en kategori framåt via [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). Potens‑trendlinjen sträcker sig en kategori bakåt via [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

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

## **Ställ in ett intercept för trendlinjen**

Använd [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) för att fixera en trendlinjes Y‑värde vid X = 0. Denna inställning stöds för linjära, exponentiella och polynomiska trendlinjer.

Ett exempel är en produktionskostnadsmodell som kan behöva börja med kända fasta kostnader på 100, även när mätningar vid icke‑noll produktionsvolymer tyder på ett annat grundvärde. För en linjär trendlinje begränsar fixering av interceptet ekvationen `y = ax + b` till `b = 100`; lutningen anpassas till data under den begränsningen. Det flyttar inte bara en redan anpassad linje. Inställningar för axelöverskridning styr var diagramaxlarna möts, inte koefficienterna för den anpassade trendlinjen.

Följande exempel skapar ett spridningsdiagram (XY) med produktionsvolymer från 1 till 4 och kostnader på 170, 200, 230 och 260. Det sparar diagrammet med standardinställning för automatiskt intercept, sätter interceptet till 100 och sparar en andra PPTX. De två filerna skiljer sig endast i interceptinställningen. Trendlinjen visar sin ekvation och sträcker sig tillbaka till X = 0.

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

Med automatisk beräkning ger dessa data `y = 30x + 140`. Att sätta interceptet till 100 i stället ger ungefär `y = 43.33x + 100`: det anpassade värdet vid noll matchar det kända grundvärdet, medan linjen inte längre passerar genom varje datapunkt.

| Automatiskt intercept | Fast intercept på 100 |
| --- | --- |
| ![Linjär trendlinje med automatiskt beräknat intercept på 140](intercept-automatic.png) | ![Linjär trendlinje med fast intercept på 100](intercept-fixed.png) |

Båda bilderna använder samma data och axelskala. Trendlinjerna sträcks tillbaka till X = 0 för att visa sina intercept.

Som standard innehåller egenskapen `float("nan")`, vilket representerar ett ospecificerat intercept snarare än noll. Interceptet beräknas då automatiskt från datan.

## **Lägg till en anpassad linje**

En anpassad linje är en form som ritas ovanpå diagrammet istället för en trendlinje beräknad från seriedata. Detta exempel använder [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) för att lägga till en horisontell linje på bilden ovanför diagrammet. Linjens position anges i bildkoordinater, mätt i punkter, så den börjar vid diagrammets vänstra kant och ligger halvvägs ner i diagrammet. Dess bredd matchar diagrammets bredd. [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) ger linjen en solid röd färg.

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

## **FAQ**

**Vad betyder 'forward' och 'backward' för en trendlinje?**

De är längderna på trendlinjen som projiceras framåt/bakåt: för spridningsdiagram (XY) — i enhetsvärden på axeln; för icke‑spridningsdiagram — i antal kategorier. Endast icke‑negativa värden är tillåtna.

**Kommer trendlinjen att bevaras vid export av presentationen till PDF eller SVG, eller vid rendering av en bild?**

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/) eller [SVG](/slides/sv/python-net/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exportera en bild av diagrammet](/slides/sv/python-net/create-shape-thumbnails/) själva.