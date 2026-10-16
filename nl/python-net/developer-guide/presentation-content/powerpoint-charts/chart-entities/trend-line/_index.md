---
title: Trendlijnen toevoegen aan presentatiegrafieken in Python
linktitle: Trendlijn
type: docs
url: /nl/python-net/trend-line/
keywords:
- grafiek
- trendlijn
- exponentiële trendlijn
- lineaire trendlijn
- logaritmische trendlijn
- voortschrijdend gemiddelde trendlijn
- polynomiale trendlijn
- machts trendlijn
- aangepaste trendlijn
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Voeg snel trendlijnen toe aan PowerPoint-grafieken en pas ze aan met Aspose.Slides voor Python via .NET — een praktische gids om uw publiek te boeien."
---
## **Overzicht**

Dit artikel legt uit hoe u trendlijnen aan presentatie‑grafieken kunt toevoegen met Aspose.Slides. Het laat zien hoe u een grafiek maakt, trendlijnen toevoegt aan grafiekseries en werkt met verschillende trendlijntypen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynoom en macht.

Daarnaast wordt beschreven hoe u een aangepaste lijn aan een grafiek toevoegt door een lijnvorm in te voegen, en bevat het een korte FAQ over de waarden voor voort- en terugprojectie van trendlijnen en of trendlijnen behouden blijven bij export naar PDF of SVG en bij het renderen van grafieken als afbeeldingen.

## **Een trendlijn toevoegen**

Gebruik [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) om een trendlijn toe te voegen aan een grafiekserie, en selecteer het type met [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). Het voorbeeld maakt een gegroepeerde kolomgrafiek met standaardgegevens en voegt twee trendlijnen toe aan elk van de drie series.

De exponentiële trendlijn verbergt zijn vergelijking en R‑kwadraat‑waarde via [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) en [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), terwijl de lineaire trendlijn rood is. De logaritmische trendlijn gebruikt [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) voor een aangepast label. Het voortschrijdende gemiddelde gebruikt een [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) van drie datapunten en een aangepaste [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/).

De polynomiale trendlijn heeft een [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) van drie en strekt zich één categorie vooruit uit via [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). De machts‑trendlijn strekt zich één categorie terug uit via [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

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

## **Een trendlijn‑intercept instellen**

Gebruik [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) om de Y‑waarde van een trendlijn vast te leggen bij X = 0. Deze instelling wordt ondersteund voor lineaire, exponentiële en polynomiale trendlijnen.

Bijvoorbeeld, een productiekostmodel moet mogelijk beginnen bij bekende vaste kosten van 100, zelfs wanneer metingen bij niet‑nul productievermogens een ander uitgangspunt suggereren. Voor een lineaire trendlijn dwingt het vastzetten van het intercept de vergelijking `y = ax + b` tot `b = 100`; de helling wordt dan aangepast aan de data onder die beperking. Het verplaatst dus niet simpelweg een reeds aangepaste lijn. Instellingen voor de kruising van de assen bepalen waar de assen elkaar snijden, niet de coëfficiënten van de aangepaste trendlijn.

Het volgende voorbeeld maakt een spreidings‑ (XY‑)grafiek met productievolumes van 1 tot 4 en kosten van 170, 200, 230 en 260. Het slaat de grafiek op met het standaard automatische intercept, stelt het intercept in op 100 en slaat een tweede PPTX op. De twee bestanden verschillen alleen in de intercept‑instelling. De trendlijn toont zijn vergelijking en strekt zich terug uit tot X = 0.

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

Bij automatische berekening leveren deze gegevens `y = 30x + 140`. Het instellen van het intercept op 100 levert ongeveer `y = 43.33x + 100`: de aangepaste waarde bij nul komt overeen met de bekende basislijn, terwijl de lijn niet langer door elk datapunt gaat.

| Automatische intercept | Vaste intercept van 100 |
| --- | --- |
| ![Lineaire trendlijn met een automatisch berekend intercept van 140](intercept-automatic.png) | ![Lineaire trendlijn met een vast intercept van 100](intercept-fixed.png) |

Beide afbeeldingen gebruiken dezelfde gegevens en as‑schalen. De trendlijnen worden teruggestrekt tot X = 0 om hun intercepten te tonen.

Standaard bevat de eigenschap `float("nan")`, wat een niet‑gespecificeerd intercept aangeeft in plaats van nul. Het intercept wordt dan automatisch berekend op basis van de gegevens.

## **Een aangepaste lijn toevoegen**

Een aangepaste lijn is een vorm die over de grafiek wordt getekend in plaats van een trendlijn die uit de series‑data wordt berekend. Dit voorbeeld gebruikt [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) om een horizontale lijn toe te voegen aan de dia boven de grafiek. De positie van de lijn wordt opgegeven in dia‑coördinaten, gemeten in punten, zodat hij begint aan de linkerkant van de grafiek en halverwege de grafiek wordt geplaatst. Zijn breedte komt overeen met de breedte van de grafiek. Het [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) geeft de lijn een effen rode kleur.

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

**Wat betekenen ‘forward’ en ‘backward’ voor een trendlijn?**

Het zijn de lengtes waarmee de trendlijn respectievelijk voorwaarts en achterwaarts wordt geprojecteerd: voor spreidings‑ (XY‑)grafieken — in as‑eenheden; voor niet‑spreidingsgrafieken — in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides converteert presentaties naar [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/) of [SVG](/slides/nl/python-net/render-a-slide-as-an-svg-image/) en rendert grafieken naar afbeeldingen; trendlijnen, als onderdeel van de grafiek, blijven behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om een afbeelding van de grafiek zelf te [exporteren](/slides/nl/python-net/create-shape-thumbnails/).