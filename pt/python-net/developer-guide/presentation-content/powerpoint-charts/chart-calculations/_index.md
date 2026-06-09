---
title: Otimizar cálculos de gráficos para apresentações em Python
linktitle: Cálculos de Gráficos
type: docs
weight: 50
url: /pt/python-net/chart-calculations/
keywords:
- cálculos de gráfico
- elementos de gráfico
- posição do elemento
- posição real
- elemento filho
- elemento pai
- valores do gráfico
- valor real
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Compreenda os cálculos de gráficos, atualizações de dados e controle de precisão no Aspose.Slides para Python via .NET para PPT, PPTX e ODP, com exemplos práticos de código."
---
## **Visão geral**

Aspose.Slides oferece APIs para trabalhar com cálculos de gráficos e dados de layout em apresentações. Este artigo mostra como recuperar os valores reais dos elementos do gráfico, incluindo a posição e o tamanho reais dos elementos que implementam `ActualLayout` e os valores reais dos eixos do gráfico. Ele também explica que esses valores são preenchidos após a validação do layout do gráfico.

Além disso, o artigo demonstra como obter a posição real dos elementos pai do gráfico e como ocultar componentes do gráfico, como o título, eixos, legenda e linhas de grade. Juntos, esses exemplos ajudam a inspecionar as informações de layout do gráfico e a controlar a visibilidade dos elementos do gráfico em apresentações do PowerPoint programaticamente.

## **Calcular valores reais dos elementos do gráfico**
Aspose.Slides for Python via .NET fornece uma API simples para obter essas propriedades. Isso ajudará a calcular os valores reais dos elementos do gráfico. Os valores reais incluem a posição dos elementos que herdam a classe [IActualLayout](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/iactuallayout/) (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) e os valores reais dos eixos (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **Calcular posição real dos elementos pai do gráfico**
Aspose.Slides for Python via .NET fornece uma API simples para obter essas propriedades. As propriedades de IActualLayout fornecem informações sobre a posição real do elemento pai do gráfico. É necessário chamar o método IChart.ValidateChartLayout() anteriormente para preencher as propriedades com valores reais.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **Ocultar informações do gráfico**
Este tópico ajuda a entender como ocultar informações do gráfico. Usando Aspose.Slides for Python via .NET, você pode ocultar **Título, Eixo Vertical, Eixo Horizontal** e **Linhas de Grade** do gráfico. O exemplo de código abaixo mostra como usar essas propriedades.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Ocultando o título do gráfico
    chart.has_title = False

    # Ocultando o eixo de valores
    chart.axes.vertical_axis.is_visible = False

    # Visibilidade do eixo de categorias
    chart.axes.horizontal_axis.is_visible = False

    # Ocultando a legenda
    chart.has_legend = False

    # Ocultando linhas principais da grade
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Definindo a cor da linha da série
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**As pastas de trabalho externas do Excel funcionam como fonte de dados e como isso afeta o recálculo?**

Sim. Um gráfico pode referenciar uma pasta de trabalho externa: ao conectar ou atualizar a fonte externa, fórmulas e valores são obtidos dessa pasta de trabalho, e o gráfico reflete as alterações durante as operações de abertura/edição. A API permite [especificar a pasta de trabalho externa](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/) e gerenciar os dados vinculados.

**Posso calcular e exibir linhas de tendência sem implementar a regressão eu mesmo?**

Sim. [Linhas de Tendência](/slides/pt/python-net/trend-line/) (linear, exponencial e outras) são adicionadas e atualizadas pelo Aspose.Slides; seus parâmetros são recalculados a partir dos dados da série automaticamente, portanto não é necessário implementar seus próprios cálculos.

**Se uma apresentação contém vários gráficos com links externos, posso controlar qual pasta de trabalho cada gráfico usa para os valores calculados?**

Sim. Cada gráfico pode apontar para sua própria [pasta de trabalho externa](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/set_external_workbook/), ou você pode criar/substituir uma pasta de trabalho externa por gráfico independentemente das demais.