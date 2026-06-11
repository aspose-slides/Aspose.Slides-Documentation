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
- trendlinje för glidande medelvärde
- polynomisk trendlinje
- trendlinje för potens
- anpassad trendlinje
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lägg snabbt till och anpassa trendlinjer i PowerPoint- och OpenDocument-diagram med Aspose.Slides för Python via .NET — en praktisk guide och kodexempel för att förbättra prognosnoggrannheten och engagera din publik."
---
## **Översikt**

Den här artikeln förklarar hur du lägger till trendlinjer i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur du skapar ett diagram, lägger till trendlinjer i diagramserier och arbetar med flera trendlinjetyper, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynomisk och potens.

Den beskriver också hur du lägger till en anpassad linje i ett diagram genom att infoga en linjefigur och innehåller en kort FAQ om framåt- och bakåtriktade trendlinjers projektioner samt om trendlinjer bevaras vid export till PDF eller SVG och vid rendering av diagram som bilder.

## **Lägg till trendlinje**
Aspose.Slides för Python via .NET tillhandahåller ett enkelt API för att hantera olika diagramtrendlinjer:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en slides referens genom sitt index.
1. Lägg till ett diagram med standarddata samt valfri önskad typ (detta exempel använder ChartType.CLUSTERED_COLUMN).
1. Lägg till exponentiell trendlinje för diagramserie 1.
1. Lägg till linjär trendlinje för diagramserie 1.
1. Lägg till logaritmisk trendlinje för diagramserie 2.
1. Lägg till glidande medelvärde trendlinje för diagramserie 2.
1. Lägg till polynomisk trendlinje för diagramserie 3.
1. Lägg till potens trendlinje för diagramserie 3.
1. Skriv den ändrade presentationen till en PPTX‑fil.

Följande kod används för att skapa ett diagram med trendlinjer.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapar tom presentation
with slides.Presentation() as pres:

    # Skapar ett grupperat stapeldiagram
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Lägger till exponentiell trendlinje för diagramserie 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Lägger till linjär trendlinje för diagramserie 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Lägger till logaritmisk trendlinje för diagramserie 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Lägger till trendlinje för glidande medelvärde för diagramserie 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Lägger till polynomisk trendlinje för diagramserie 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Lägger till potens trendlinje för diagramserie 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Sparar presentation
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till anpassad linje**
Aspose.Slides för Python via .NET tillhandahåller ett enkelt API för att lägga till anpassade linjer i ett diagram. För att lägga till en enkel rak linje på ett valt bild i presentationen, följ stegen nedan:

- Skapa en instans av Presentation‑klassen
- Hämta referensen till en bild genom att använda dess Index
- Skapa ett nytt diagram med metoden AddChart som tillhandahålls av Shapes‑objektet
- Lägg till en AutoShape av typ Linje med metoden AddAutoShape som tillhandahålls av Shapes‑objektet
- Ange färgen på figurens linjer.
- Skriv den ändrade presentationen som en PPTX‑fil

Följande kod används för att skapa ett diagram med anpassade linjer.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Vad betyder 'forward' och 'backward' för en trendlinje?**

De är längden på trendlinjen som projiceras framåt/bakåt: för spridningsdiagram (XY) — i axelenheter; för icke‑spridningsdiagram — i antal kategorier. Endast icke‑negativa värden är tillåtna.

**Kommer trendlinjen att bevaras vid export av presentationen till PDF eller SVG, eller när en bild renderas som en bild?**

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/sv/python-net/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exportera en bild av diagrammet](/slides/sv/python-net/create-shape-thumbnails/) själv.