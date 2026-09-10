---
title: Otimizar Cálculos de Gráficos para Apresentações em Python via Java
linktitle: Cálculos de Gráficos
type: docs
weight: 50
url: /pt/python-java/chart-calculations/
keywords:
- cálculos de gráficos
- elementos do gráfico
- posição do elemento
- posição real
- elemento filho
- elemento pai
- valores do gráfico
- valor real
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Entenda cálculos de gráficos, atualizações de dados e controle de precisão no Aspose.Slides for Python via Java para PPT e PPTX, com exemplos práticos de código Python."
---
## **Visão geral**

Aspose.Slides fornece APIs para trabalhar com cálculos de gráficos e dados de layout em apresentações. Este artigo mostra como recuperar os valores reais dos elementos do gráfico, incluindo a posição e tamanho reais dos elementos do gráfico e os valores reais dos eixos do gráfico. Também explica que esses valores são preenchidos após a validação do layout do gráfico.

Além disso, o artigo demonstra como obter a posição real dos elementos principais do gráfico e como ocultar componentes do gráfico, como o título, eixos, legenda e linhas de grade. Juntos, esses exemplos ajudam a inspecionar as informações de layout do gráfico e controlar a visibilidade dos elementos do gráfico em apresentações do PowerPoint programaticamente.

## **Calcular Valores Reais dos Elementos do Gráfico**
Aspose.Slides for Python via Java fornece uma API simples para obter essas propriedades. Métodos da classe [Axis](https://reference.aspose.com/slides/pt/python-java/aspose.slides/axis/) fornecem informações sobre os valores reais dos eixos do gráfico ([getActualMaxValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/pt/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/pt/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/pt/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/pt/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Chame o método [Chart.validateChartLayout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#validateChartLayout) primeiro para preencher essas propriedades com os valores reais.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Calcular a Posição Real dos Elementos Principais do Gráfico**
Aspose.Slides for Python via Java fornece uma API simples para obter essas propriedades. Métodos da classe [ChartPlotArea](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartplotarea/) fornecem informações sobre a posição real e o tamanho da área de plotagem do gráfico ([getActualX](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartplotarea/#getActualHeight)). Chame o método [Chart.validateChartLayout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#validateChartLayout) primeiro para preencher essas propriedades com os valores reais.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Ocultar Elementos do Gráfico**
Esta seção explica como ocultar informações de um gráfico. Usando Aspose.Slides for Python via Java, você pode ocultar o **Título, Eixo Vertical, Eixo Horizontal** e **Linhas de Grade**. O exemplo de código a seguir mostra como usar essas propriedades.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Ocultar o título do gráfico.
    chart.setTitle(False)

    # Ocultar o eixo de valores.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Ocultar o eixo de categorias.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Ocultar a legenda.
    chart.setLegend(False)

    # Ocultar as linhas de grade principais.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Manter apenas a primeira série. Remover do final mantém os índices restantes válidos.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Definir a cor da linha da série.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Os livros de Excel externos funcionam como fonte de dados, e como isso afeta o recálculo?**

Sim. Um gráfico pode referenciar um livro externo: ao conectar ou atualizar a fonte externa, fórmulas e valores são obtidos desse livro, e o gráfico reflete as atualizações durante operações de abertura/edição. A API permite que você [especifique o caminho do livro de trabalho externo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#setExternalWorkbook) e gerencie os dados vinculados.

**Posso calcular e exibir linhas de tendência sem implementar a regressão eu mesmo?**

Sim. [Linhas de tendência](/slides/pt/python-java/trend-line/) (lineares, exponenciais e outras) são adicionadas e atualizadas pelo Aspose.Slides; seus parâmetros são recalculados a partir dos dados da série automaticamente, portanto você não precisa implementar seus próprios cálculos.

**Se uma apresentação tem múltiplos gráficos com links externos, posso controlar qual livro de trabalho cada gráfico usa para valores calculados?**

Sim. Cada gráfico pode apontar para seu próprio [livro de trabalho externo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#setExternalWorkbook), ou você pode criar/substituir um livro de trabalho externo por gráfico independentemente dos demais.