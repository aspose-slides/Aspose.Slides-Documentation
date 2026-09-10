---
title: Personalizar Gráficos de Bolha em Apresentações Usando Python
linktitle: Gráfico de Bolha
type: docs
url: /pt/python-java/bubble-chart/
keywords:
- gráfico de bolha
- tamanho da bolha
- dimensionamento de tamanho
- representação de tamanho
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Crie e personalize gráficos de bolha poderosos no PowerPoint com Aspose.Slides for Python via Java para melhorar sua visualização de dados facilmente."
---
## **Visão geral**

Este artigo mostra como trabalhar com gráficos de bolha no Aspose.Slides. Ele abrange duas opções específicas de personalização: dimensionar o tamanho das bolhas através do método [setBubbleSizeScale](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) e controlar como os valores de tamanho das bolhas são representados através do método [setBubbleSizeRepresentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

Os exemplos demonstram como criar um gráfico de bolha, ajustar o dimensionamento de tamanho e mudar a representação do tamanho da bolha para usar largura. O artigo também inclui uma breve seção de FAQ que esclarece o suporte ao tipo de gráfico “Bubble with 3-D”, observa que limites práticos do gráfico dependem do desempenho e da versão alvo do PowerPoint, e explica que a exportação preserva a aparência do gráfico através do mecanismo de renderização do Aspose.Slides.

## **Dimensionamento do Tamanho do Gráfico de Bolhas**
Aspose.Slides for Python via Java oferece suporte ao dimensionamento do tamanho de gráficos de bolha por meio dos métodos [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) e [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). O exemplo a seguir mostra como dimensionar os tamanhos das bolhas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Representar Dados como Tamanhos de Gráfico de Bolhas**
Os métodos [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) e [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) estão disponíveis na classe [ChartSeriesGroup](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/). A representação do tamanho da bolha especifica como os valores de tamanho são mostrados no gráfico de bolha. Os valores possíveis são [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/pt/python-java/aspose.slides/bubblesizerepresentationtype/#Area) e [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/pt/python-java/aspose.slides/bubblesizerepresentationtype/#Width). A enumeração [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/pt/python-java/aspose.slides/bubblesizerepresentationtype/) define as formas possíveis de representar os dados como tamanhos de gráfico de bolhas. O exemplo a seguir mostra como representar os tamanhos das bolhas usando largura.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Um “gráfico de bolha com efeito 3-D” é suportado, e como ele difere de um normal?**

Sim. Existe um tipo de gráfico separado, “Bubble with 3-D”. Ele aplica estilo 3-D às bolhas, mas não adiciona um eixo adicional; os dados permanecem X‑Y‑S (tamanho). O tipo está disponível na classe [chart type](https://reference.aspose.com/slides/pt/python-java/aspose.slides/charttype/).

**Existe um limite para a quantidade de séries e pontos em um gráfico de bolha?**

Não há um limite rígido no nível da API; as restrições são determinadas pelo desempenho e pela versão alvo do PowerPoint. Recomenda‑se manter o número de pontos razoável para garantir legibilidade e velocidade de renderização.

**Como a exportação afetará a aparência de um gráfico de bolha (PDF, imagens)?**

A exportação para formatos suportados preserva a aparência do gráfico; a renderização é realizada pelo mecanismo Aspose.Slides. Para formatos raster ou vetor, aplicam‑se as regras gerais de renderização de gráficos (resolução, anti‑aliasing), portanto escolha um DPI suficiente para impressão.