---
title: Přidání čar trendu do grafů v prezentacích v Pythonu
linktitle: Čára trendu
type: docs
url: /cs/python-net/trend-line/
keywords:
- graf
- čára trendu
- exponenciální čára trendu
- lineární čára trendu
- logaritmická čára trendu
- čára trendu klouzavý průměr
- polynomická čára trendu
- mocninná čára trendu
- vlastní čára trendu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Rychle přidejte a upravte čáry trendu v grafech PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET — praktický průvodce a ukázky kódu ke zlepšení přesnosti předpovědí a zaujmutí vašeho publika."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat do grafů v prezentaci čáry trendu. Ukazuje, jak vytvořit graf, přidat čáry trendu k sériím grafu a pracovat s několika typy čar trendu, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomické a mocninné.

Také popisuje, jak do grafu přidat vlastní čáru vložením tvaru čáry, a obsahuje krátké FAQ o hodnotách projekce čáry trendu dopředu a dozadu a o tom, zda jsou čáry trendu zachovány při exportu do PDF nebo SVG a při vykreslování grafů jako obrázků.

## **Přidání čáry trendu**
Aspose.Slides for Python via .NET poskytuje jednoduché API pro správu různých čar trendu v grafech:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte referenci snímku podle jeho indexu.
3. Přidejte graf s výchozími daty a libovolným požadovaným typem (v tomto příkladu se používá ChartType.CLUSTERED_COLUMN).
4. Přidání exponenciální čáry trendu pro sérii grafu 1.
5. Přidání lineární čáry trendu pro sérii grafu 1.
6. Přidání logaritmické čáry trendu pro sérii grafu 2.
7. Přidání čáry trendu klouzavý průměr pro sérii grafu 2.
8. Přidání polynomické čáry trendu pro sérii grafu 3.
9. Přidání mocninné čáry trendu pro sérii grafu 3.
10. Zapište upravenou prezentaci do souboru PPTX.

Následující kód slouží k vytvoření grafu s čarami trendu.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvoření prázdné prezentace
with slides.Presentation() as pres:

    # Vytvoření seskupeného sloupcového grafu
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Přidání exponenciální čáry trendu pro sérii grafu 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Přidání lineární čáry trendu pro sérii grafu 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Přidání logaritmické čáry trendu pro sérii grafu 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Přidání čáry trendu klouzavý průměr pro sérii grafu 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Přidání polynomické čáry trendu pro sérii grafu 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Přidání mocninné čáry trendu pro sérii grafu 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Uložení prezentace
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání vlastní čáry**
Aspose.Slides for Python via .NET poskytuje jednoduché API pro přidání vlastních čar do grafu. Pro přidání jednoduché rovné čáry do vybraného snímku prezentace postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy Presentation
- Získejte referenci snímku pomocí jeho Indexu
- Vytvořte nový graf pomocí metody AddChart, která je k dispozici v objektu Shapes
- Přidejte AutoShape typu Line pomocí metody AddAutoShape, která je k dispozici v objektu Shapes
- Nastavte barvu čar tvaru.
- Zapište upravenou prezentaci jako soubor PPTX

Následující kód slouží k vytvoření grafu s vlastními čarami.

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

## **Často kladené dotazy**

**Co znamená ‚dopředu‘ a ‚dozadu‘ u čáry trendu?**

Jedná se o délky čáry trendu promítnuté dopředu/dozadu: u rozptylových (XY) grafů — v jednotkách osy; u jiných grafů — v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zůstane čára trendu zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace do [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/cs/python-net/render-a-slide-as-an-svg-image/) a vykresluje grafy jako obrázky; čáry trendu jako součást grafu jsou během těchto operací zachovány. K dispozici je také metoda pro [export obrázku grafu](/slides/cs/python-net/create-shape-thumbnails/).