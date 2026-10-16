---
title: Adicionar Linhas de Tendência a Gráficos de Apresentação em Python
linktitle: Linha de Tendência
type: docs
url: /pt/python-net/trend-line/
keywords:
- gráfico
- linha de tendência
- linha de tendência exponencial
- linha de tendência linear
- linha de tendência logarítmica
- linha de tendência de média móvel
- linha de tendência polinomial
- linha de tendência de potência
- linha de tendência personalizada
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Adicione e personalize rapidamente linhas de tendência em gráficos do PowerPoint com Aspose.Slides para Python via .NET — um guia prático para envolver seu público."
---
## **Visão Geral**

Este artigo explica como adicionar linhas de tendência a gráficos em apresentações usando Aspose.Slides. Ele mostra como criar um gráfico, adicionar linhas de tendência às séries do gráfico e trabalhar com vários tipos de linhas de tendência, incluindo exponencial, linear, logarítmica, média móvel, polinomial e potência.

Ele também descreve como adicionar uma linha personalizada a um gráfico inserindo uma forma de linha e inclui um breve FAQ sobre os valores de projeção da linha de tendência para frente e para trás e se as linhas de tendência são preservadas durante a exportação para PDF ou SVG e ao renderizar gráficos como imagens.

## **Adicionar uma Linha de Tendência**

Use [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) para adicionar uma linha de tendência a uma série de gráfico, selecionando seu tipo com [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). O exemplo cria um gráfico de colunas agrupadas com dados padrão e adiciona duas linhas de tendência a cada uma de suas três séries.

A linha de tendência exponencial oculta sua equação e o valor de R‑quadrado através de [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) e [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), enquanto a linha de tendência linear é vermelha. A linha de tendência logarítmica usa [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) para um rótulo personalizado. A média móvel usa um [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) de três pontos de dados e um [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/) personalizado.

A linha de tendência polinomial tem um [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) de três e estende uma categoria para frente através de [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). A linha de tendência de potência estende uma categoria para trás através de [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

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

## **Definir o Intercepto da Linha de Tendência**

Use [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) para fixar o valor de Y de uma linha de tendência em X = 0. Essa configuração é suportada para linhas de tendência linear, exponencial e polinomial.

Por exemplo, um modelo de custo de produção pode precisar iniciar com custos fixos conhecidos de 100, mesmo quando medições em volumes de produção diferentes de zero sugerem uma linha de base distinta. Para uma linha de tendência linear, fixar o intercepto restringe a equação `y = ax + b` para `b = 100`; a inclinação é ajustada aos dados sob essa restrição. Isso não apenas move uma linha já ajustada. As configurações de cruzamento dos eixos controlam onde os eixos do gráfico se encontram, não os coeficientes da linha de tendência ajustada.

O exemplo a seguir cria um gráfico de dispersão (XY) com volumes de produção de 1 a 4 e custos de 170, 200, 230 e 260. Ele salva o gráfico com o intercepto automático padrão, define o intercepto como 100 e salva um segundo PPTX. Os dois arquivos diferem apenas na configuração do intercepto. A linha de tendência exibe sua equação e se estende até X = 0.

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

Com cálculo automático, esses dados produzem `y = 30x + 140`. Definir o intercepto como 100 produz aproximadamente `y = 43.33x + 100`: o valor ajustado em zero corresponde à linha de base conhecida, enquanto a linha deixa de passar por todos os pontos de dados.

| Intercepto automático | Intercepto fixo de 100 |
| --- | --- |
| ![Linha de tendência linear com um intercepto calculado automaticamente de 140](intercept-automatic.png) | ![Linha de tendência linear com um intercepto fixo de 100](intercept-fixed.png) |

Ambas as imagens usam os mesmos dados e escalas dos eixos. As linhas de tendência são estendidas até X = 0 para mostrar seus interceptos.

Por padrão, a propriedade contém `float(\"nan\")`, que representa um intercepto não especificado em vez de zero. O intercepto é então calculado automaticamente a partir dos dados.

## **Adicionar uma Linha Personalizada**

Uma linha personalizada é uma forma desenhada sobre o gráfico, em vez de uma linha de tendência calculada a partir dos dados da série. Este exemplo usa [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) para adicionar uma linha horizontal ao slide sobre o gráfico. A posição da linha é especificada em coordenadas do slide, medida em pontos, de modo que inicia na borda esquerda do gráfico e fica a meio caminho para baixo do gráfico. Sua largura corresponde à largura do gráfico. O [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) define a linha com uma cor vermelha sólida.

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

**O que significam 'forward' e 'backward' para uma linha de tendência?**

São os comprimentos da linha de tendência projetados para frente ou para trás: para gráficos de dispersão (XY) — em unidades dos eixos; para gráficos que não são de dispersão — em número de categorias. Apenas valores não negativos são permitidos.

**A linha de tendência será preservada ao exportar a apresentação para PDF ou SVG, ou ao renderizar um slide como imagem?**

Sim. Aspose.Slides converte apresentações para [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/) ou [SVG](/slides/pt/python-net/render-a-slide-as-an-svg-image/) e renderiza gráficos como imagens; linhas de tendência, como parte do gráfico, são preservadas durante essas operações. Também há um método disponível para [exportar uma imagem do gráfico](/slides/pt/python-net/create-shape-thumbnails/) propriamente dito.