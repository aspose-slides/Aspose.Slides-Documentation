---
title: Adicionar linhas de tendência a gráficos de apresentação em Python
linktitle: Linha de tendência
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

Este artigo explica como adicionar linhas de tendência a gráficos de apresentação usando Aspose.Slides. Ele mostra como criar um gráfico, adicionar linhas de tendência às séries do gráfico e trabalhar com vários tipos de linha de tendência, incluindo exponencial, linear, logarítmica, média móvel, polinomial e potência.

Ele também descreve como adicionar uma linha personalizada a um gráfico inserindo uma forma de linha e inclui uma breve FAQ sobre valores de projeção da linha de tendência para frente e para trás e se as linhas de tendência são preservadas ao exportar para PDF ou SVG e ao renderizar gráficos como imagens.

## **Adicionar uma linha de tendência**

Aspose.Slides for Python via Java fornece uma API simples para gerenciar diferentes linhas de tendência de gráficos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um gráfico com dados padrão e o tipo desejado (este exemplo usa [ChartType.ClusteredColumn](https://reference.aspose.com/slides/pt/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Adicionar uma linha de tendência exponencial à série 1 do gráfico.
1. Adicionar uma linha de tendência linear à série 1 do gráfico.
1. Adicionar uma linha de tendência logarítmica à série 2 do gráfico.
1. Adicionar uma linha de tendência de média móvel à série 2 do gráfico.
1. Adicionar uma linha de tendência polinomial à série 3 do gráfico.
1. Adicionar uma linha de tendência de potência à série 3 do gráfico.
1. Salvar a apresentação modificada em um arquivo PPTX.

O código a seguir cria um gráfico com linhas de tendência.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Crie uma instância da classe Presentation.
presentation = Presentation()
try:
    # Crie um gráfico de colunas agrupadas.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Adicione uma linha de tendência exponencial à série 1 do gráfico.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Adicione uma linha de tendência linear à série 1 do gráfico.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Adicione uma linha de tendência logarítmica à série 2 do gráfico.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Adicione uma linha de tendência de média móvel à série 2 do gráfico.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Adicione uma linha de tendência polinomial à série 3 do gráfico.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Adicione uma linha de tendência de potência à série 3 do gráfico.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Salve a apresentação.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Adicionar uma linha personalizada**

Aspose.Slides for Python via Java fornece uma API simples para adicionar linhas personalizadas a um gráfico. Para adicionar uma linha simples a um gráfico em um slide selecionado, siga estas etapas:

- Criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
- Obter uma referência a um slide pelo seu índice.
- Criar um novo gráfico usando o método [addChart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addChart) da classe [ShapeCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/).
- Adicionar uma forma de linha usando o método [addAutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addAutoShape) com [ShapeType.Line](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#Line).
- Definir a cor da linha da forma.
- Salvar a apresentação modificada em um arquivo PPTX.

O código a seguir cria um gráfico com uma linha personalizada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Crie uma instância da classe Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**O que significam 'forward' e 'backward' para uma linha de tendência?**

São os comprimentos da linha de tendência projetados para a frente ou para trás: para gráficos de dispersão (XY), são medidos em unidades dos eixos; para gráficos que não são de dispersão, são medidos no número de categorias. Apenas valores não negativos são permitidos.

**A linha de tendência será preservada ao exportar a apresentação para PDF ou SVG, ou ao renderizar um slide como imagem?**

Sim. Aspose.Slides converte apresentações para [PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/pt/python-java/render-a-slide-as-an-svg-image/) e renderiza gráficos em imagens; as linhas de tendência, como parte do gráfico, são preservadas durante essas operações. Também há um método disponível para [exportar uma imagem do gráfico](/slides/pt/python-java/create-shape-thumbnails/) propriamente dito.