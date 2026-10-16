---
title: Přidání trendových čar do grafů v prezentaci v Pythonu
linktitle: Trendová čára
type: docs
url: /cs/python-net/trend-line/
keywords:
- graf
- trendová čára
- exponenciální trendová čára
- lineární trendová čára
- logaritmická trendová čára
- trendová čára klouzavého průměru
- polynomická trendová čára
- mocninná trendová čára
- vlastní trendová čára
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Rychle přidejte a přizpůsobte trendové čáry v grafech PowerPointu pomocí Aspose.Slides pro Python na .NET – praktický průvodce, jak zaujmout své publikum."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat trendové čáry do grafů v prezentaci. Ukazuje, jak vytvořit graf, přidat trendové čáry k sériím grafu a pracovat s několika typy trendových čar, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomické a mocninné.

Také popisuje, jak přidat vlastní čáru do grafu vložením tvaru čáry, a obsahuje krátké FAQ o hodnotách projekce trendové čáry dopředu a dozadu a o tom, zda jsou trendové čáry zachovány při exportu do PDF nebo SVG a při vykreslování grafů jako obrázků.

## **Přidání trendové čáry**

Použijte [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) k přidání trendové čáry k sérii grafu, přičemž typ vyberete pomocí [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). Příklad vytvoří seskupený sloupcový graf s výchozími daty a přidá dvě trendové čáry ke každé ze svých tří sérií.

Exponenciální trendová čára skryje svou rovnici a hodnotu R‑kvadrátu pomocí [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) a [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), zatímco lineární trendová čára je červená. Logaritmická trendová čára používá [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) pro vlastní popisek. Klouzavý průměr používá [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) tří datových bodů a vlastní [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/).

Polynomická trendová čára má [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) tři a rozšíří o jednu kategorii dopředu pomocí [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). Mocninná trendová čára rozšíří o jednu kategorii dozadu pomocí [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

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

## **Nastavení průsečíku trendové čáry**

Použijte [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) k fixaci hodnoty Y trendové čáry při X = 0. Toto nastavení je podporováno pro lineární, exponenciální a polynomické trendové čáry.

Například model nákladů na výrobu může potřebovat začít se známými pevnými náklady 100, i když měření při nenulových objemech výroby naznačují jiný základ. Pro lineární trendovou čáru fixace průsečíku omezuje rovnici `y = ax + b` na `b = 100`; sklon je přizpůsoben datům pod tímto omezením. Nejde jen o posunutí již přizpůsobené čáry. Nastavení průsečíku os řídí, kde se osy grafu setkávají, nikoli koeficienty přizpůsobené trendové čáry.

Následující příklad vytvoří bodový (XY) graf s objemy výroby od 1 do 4 a náklady 170, 200, 230 a 260. Uloží graf s výchozím automatickým průsečím, nastaví průsečík na 100 a uloží druhý soubor PPTX. Tyto dva soubory se liší pouze nastavením průsečíku. Trendová čára zobrazuje svou rovnici a rozšíří se zpět na X = 0.

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

Při automatickém výpočtu tato data dávají `y = 30x + 140`. Nastavení průsečíku na 100 místo toho dává přibližně `y = 43.33x + 100`: přizpůsobená hodnota při nule odpovídá známému základu, zatímco čára již neprochází všemi datovými body.

| Automatický průsečík | Pevný průsečík 100 |
| --- | --- |
| ![Lineární trendová čára s automaticky vypočteným průsečíkem 140](intercept-automatic.png) | ![Lineární trendová čára s pevným průsečíkem 100](intercept-fixed.png) |

Obě obrázky používají stejná data a měřítka os. Trendové čáry jsou rozšířeny zpět na X = 0, aby ukázaly své průsečíky.

Ve výchozím nastavení vlastnost obsahuje `float("nan")`, což představuje nespecifikovaný průsečík místo nuly. Průsečík je pak automaticky vypočítán z dat.

## **Přidání vlastní čáry**

Vlastní čára je tvar nakreslený nad grafem, nikoli trendová čára vypočtená z dat sérií. Tento příklad používá [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) k přidání vodorovné čáry na snímek nad grafem. Pozice čáry je uvedena v souřadnicích snímku, měřených v bodech, takže začíná u levého okraje grafu a leží v polovině výšky grafu. Její šířka odpovídá šířce grafu. [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) dává čáře plnou červenou barvu.

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

## **Často kladené otázky**

**Co znamená 'forward' a 'backward' u trendové čáry?**

Jedná se o délky trendové čáry promítané dopředu/dozadu: pro bodové (XY) grafy — v jednotkách os; pro nebodové grafy — v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zůstane trendová čára zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace na [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/) nebo [SVG](/slides/cs/python-net/render-a-slide-as-an-svg-image/) a vykresluje grafy jako obrázky; trendové čáry, jako součást grafu, jsou během těchto operací zachovány. K dispozici je také metoda k [exportu obrázku grafu](/slides/cs/python-net/create-shape-thumbnails/).