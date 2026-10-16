---
title: Adicionar linhas de tendência a gráficos de apresentação em Python
linktitle: Linha de Tendência
type: docs
url: /pt/python-java/trend-line/
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
- Java
- Aspose.Slides
description: "Adicione e personalize rapidamente linhas de tendência em gráficos do PowerPoint com Aspose.Slides para Python via Java — um guia prático para envolver seu público."
---
## **Visão geral**

Este artigo explica como adicionar linhas de tendência a gráficos de apresentação usando Aspose.Slides. Ele demonstra como criar um gráfico, adicionar linhas de tendência às séries do gráfico e trabalhar com vários tipos de linha de tendência, incluindo exponencial, linear, logarítmica, média móvel, polinomial e potência.

Ele também descreve como adicionar uma linha personalizada a um gráfico inserindo uma forma de linha e inclui uma breve FAQ sobre os valores de projeção da linha de tendência para frente e para trás e se as linhas de tendência são preservadas durante a exportação para PDF ou SVG e ao renderizar gráficos como imagens.

## **Adicionar uma linha de tendência**

Use [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) para adicionar uma linha de tendência a uma série de gráfico, selecionando seu tipo com [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). O exemplo cria um gráfico de colunas agrupadas com dados padrão e adiciona duas linhas de tendência a cada uma de suas três séries.

A linha de tendência exponencial oculta sua equação e o valor de R‑quadrado através de [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) e [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue), enquanto a linha de tendência linear é vermelha. A linha de tendência logarítmica usa [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) para um rótulo personalizado. A média móvel usa um [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) de três pontos de dados e um [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName) personalizado.

A linha de tendência polinomial tem ordem três, definida por meio de [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) e estende uma categoria para frente através de [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). A linha de tendência de potência estende uma categoria para trás através de [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir a intercepção da linha de tendência**

Use [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) para fixar o valor de Y de uma linha de tendência em X = 0. Essa configuração é suportada para linhas de tendência lineares, exponenciais e polinomiais.

Por exemplo, um modelo de custo de produção pode precisar começar com custos fixos conhecidos de 100, mesmo quando medições em volumes de produção diferentes de zero sugerem uma linha de base distinta. Para uma linha de tendência linear, fixar a intercepção restringe a equação `y = ax + b` para `b = 100`; a inclinação é ajustada aos dados sob essa restrição. Isso não move simplesmente uma linha já ajustada. As configurações de cruzamento dos eixos controlam onde os eixos do gráfico se encontram, não os coeficientes da linha de tendência ajustada.

O exemplo a seguir cria um gráfico de dispersão (XY) com volumes de produção de 1 a 4 e custos de 170, 200, 230 e 260. Ele salva o gráfico com a intercepção automática padrão, define a intercepção para 100 e salva um segundo PPTX. Os dois arquivos diferem apenas na configuração da intercepção. A linha de tendência exibe sua equação e se estende de volta a X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Com cálculo automático, esses dados produzem `y = 30x + 140`. Definir a intercepção para 100 produz aproximadamente `y = 43.33x + 100`: o valor ajustado em zero corresponde à linha de base conhecida, enquanto a linha não passa mais por todos os pontos de dados.

| Intercepção automática | Intercepção fixa de 100 |
| --- | --- |
| ![Linha de tendência linear com intercepção calculada automaticamente de 140](intercept-automatic.png) | ![Linha de tendência linear com intercepção fixa de 100](intercept-fixed.png) |

Ambas as imagens usam os mesmos dados e escalas de eixo. As linhas de tendência são estendidas de volta a X = 0 para mostrar suas intercepções.

Por padrão, [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) retorna `NaN`, que representa uma intercepção não especificada em vez de zero. A intercepção é então calculada automaticamente a partir dos dados.

## **Adicionar uma linha personalizada**

Uma linha personalizada é uma forma desenhada sobre o gráfico em vez de uma linha de tendência calculada a partir dos dados da série. Este exemplo usa [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) para adicionar uma linha horizontal ao slide sobre o gráfico. A posição da linha é especificada em coordenadas do slide, medidas em pontos, de modo que começa na borda esquerda do gráfico e fica a meio caminho para baixo do gráfico. Sua largura corresponde à largura do gráfico. O método [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) fornece acesso à formatação da linha usada para aplicar uma cor vermelha sólida.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**O que significam 'forward' e 'backward' para uma linha de tendência?**

São os comprimentos da linha de tendência projetados para frente ou para trás: para gráficos de dispersão (XY) — em unidades de eixo; para gráficos que não são de dispersão — em número de categorias. Apenas valores não negativos são permitidos.

**A linha de tendência será preservada ao exportar a apresentação para PDF ou SVG, ou ao renderizar um slide como imagem?**

Sim. Aspose.Slides converte apresentações para [PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/) ou [SVG](/slides/pt/python-java/render-a-slide-as-an-svg-image/) e renderiza gráficos como imagens; as linhas de tendência, como parte do gráfico, são preservadas durante essas operações. Também há um método disponível para [exportar uma imagem do gráfico](/slides/pt/python-java/create-shape-thumbnails/) propriamente dito.