---
title: Personalizar Eixos de Gráfico em Apresentações com Python
linktitle: Eixo de Gráfico
type: docs
url: /pt/python-net/chart-axis/
keywords:
- eixo de gráfico
- eixo vertical
- eixo horizontal
- personalizar eixo
- manipular eixo
- gerenciar eixo
- propriedades do eixo
- valor máximo
- valor mínimo
- linha do eixo
- formato de data
- título do eixo
- posição do eixo
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Descubra como usar o Aspose.Slides for Python via .NET para personalizar os eixos de gráfico em apresentações PowerPoint e OpenDocument para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar os eixos de gráficos no Aspose.Slides. Ele mostra como obter os valores reais dos eixos, trocar dados entre os eixos, ocultar o eixo vertical ou horizontal em gráficos de linhas, alterar o tipo do eixo de categoria, definir o formato de data para os valores do eixo de categoria, girar o título de um eixo, definir a posição do eixo e exibir um rótulo de unidade no eixo de valores.

## **Obtendo os valores máximos no eixo vertical em gráficos**
Aspose.Slides for Python via .NET permite que você obtenha os valores mínimo e máximo em um eixo vertical. Siga estas etapas:

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Obtenha o valor máximo real no eixo.
1. Obtenha o valor mínimo real no eixo.
1. Obtenha a unidade principal real do eixo.
1. Obtenha a unidade secundária real do eixo.
1. Obtenha a escala da unidade principal real do eixo.
1. Obtenha a escala da unidade secundária real do eixo.

Este código de exemplo — uma implementação das etapas acima — mostra como obter os valores necessários em Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Salva a apresentação
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Trocando os dados entre eixos**
Aspose.Slides permite que você troque rapidamente os dados entre os eixos — os dados representados no eixo vertical (eixo y) são movidos para o eixo horizontal (eixo x) e vice‑versa.

Este código Python mostra como realizar a troca de dados entre os eixos em um gráfico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Cria apresentação vazia
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Troca linhas e colunas
            
    # Salva a apresentação
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Desativando o eixo vertical em gráficos de linhas**

Este código Python mostra como ocultar o eixo vertical em um gráfico de linhas:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Desativando o eixo horizontal em gráficos de linhas**

Este código mostra como ocultar o eixo horizontal em um gráfico de linhas:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Alterando o eixo de categoria**

Usando a propriedade **CategoryAxisType**, você pode especificar o tipo de eixo de categoria desejado (**date** ou **text**). Este código em Python demonstra a operação:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Definindo o formato de data para o valor do eixo de categoria**
Aspose.Slides for Python via .NET permite definir o formato de data para um valor de eixo de categoria. A operação é demonstrada neste código Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Definindo o ângulo de rotação para o título do eixo do gráfico**
Aspose.Slides for Python via .NET permite definir o ângulo de rotação para o título de um eixo de gráfico. Este código Python demonstra a operação:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Definindo a posição do eixo em um eixo de categoria ou valor**
Aspose.Slides for Python via .NET permite definir a posição do eixo em um eixo de categoria ou de valor. Este código Python mostra como realizar a tarefa:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Habilitando a exibição do rótulo de unidade no eixo de valores do gráfico**
Aspose.Slides for Python via .NET permite configurar um gráfico para mostrar um rótulo de unidade no seu eixo de valores. Este código Python demonstra a operação:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Como defino o valor no qual um eixo cruza o outro (cruzamento de eixos)?**

Os eixos fornecem uma [configuração de cruzamento](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/axis/cross_type/): você pode escolher cruzar no zero, no máximo da categoria/valor ou em um valor numérico específico. Isso é útil para deslocar o eixo X para cima ou para baixo ou para destacar uma linha de base.

**Como posiciono os rótulos de marcações em relação ao eixo (ao lado, fora, dentro)?**

Defina a [posição do rótulo](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/axis/major_tick_mark/) como "cross", "outside" ou "inside". Isso afeta a legibilidade e ajuda a economizar espaço, especialmente em gráficos pequenos.