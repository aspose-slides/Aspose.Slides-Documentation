---
title: Personalizar Gráficos de Pizza em Apresentações com Python
linktitle: Gráfico de Pizza
type: docs
url: /pt/python-net/pie-chart/
keywords:
- gráfico de pizza
- gerenciar gráfico
- personalizar gráfico
- opções de gráfico
- configurações de gráfico
- opções de plotagem
- cor da fatia
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a criar e personalizar gráficos de pizza em Python com Aspose.Slides, exportáveis para PowerPoint e OpenDocument, impulsionando sua narrativa de dados em segundos."
---
## **Visão geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de plotagem secundária para os gráficos Pie of Pie e Bar of Pie, e como habilitar a coloração automática das fatias para um gráfico de pizza padrão.

Os exemplos se concentram em etapas práticas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar configurações de séries e rótulos, substituir os dados padrão do gráfico por categorias e valores personalizados e salvar a apresentação atualizada.

## **Opções de Plotagem Secundária para Gráficos Pie of Pie e Bar of Pie**
Aspose.Slides for Python via .NET agora oferece suporte a opções de plotagem secundária para gráficos Pie of Pie ou Bar of Pie. Neste tópico, veremos com um exemplo como especificar essas opções usando Aspose.Slides. Para especificar as propriedades, siga as etapas abaixo:

1. Instanciar o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Adicionar um gráfico ao slide.
1. Especificar as opções de plotagem secundária do gráfico.
1. Gravar a apresentação no disco.

No exemplo abaixo, definimos diferentes propriedades do gráfico Pie of Pie.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Criar uma instância da classe Presentation
with slides.Presentation() as presentation:
    # Adicionar gráfico ao slide
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Definir diferentes propriedades
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Salvar a apresentação no disco
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Definir cores automáticas das fatias do gráfico de pizza**
Aspose.Slides for Python via .NET fornece uma API simples para definir cores automáticas das fatias de um gráfico de pizza. O código de exemplo aplica a definição das propriedades mencionadas acima.

1. Criar uma instância da classe Presentation.
1. Acessar o primeiro slide.
1. Adicionar um gráfico com dados padrão.
1. Definir o título do gráfico.
1. Definir a primeira série para Mostrar Valores.
1. Definir o índice da planilha de dados do gráfico.
1. Obter a planilha de dados do gráfico.
1. Excluir as séries e categorias geradas por padrão.
1. Adicionar novas categorias.
1. Adicionar novas séries.

Gravar a apresentação modificada em um arquivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation que representa um arquivo PPTX
with slides.Presentation() as presentation:
	# Acessar o primeiro slide
	slide = presentation.slides[0]

	# Adicionar gráfico com dados padrão
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Definir o título do gráfico
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Definir a primeira série para Mostrar Valores
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Definir o índice da planilha de dados do gráfico
	defaultWorksheetIndex = 0

	# Obter a planilha de dados do gráfico
	fact = chart.chart_data.chart_data_workbook

	# Excluir as séries e categorias geradas por padrão
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Adicionar novas categorias
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Adicionar nova série
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Agora preenchendo os dados da série
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**As variações 'Pie of Pie' e 'Bar of Pie' são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/charttype/) uma plotagem secundária para gráficos de pizza, incluindo os tipos 'Pie of Pie' e 'Bar of Pie'.

**Posso exportar apenas o gráfico como imagem (por exemplo, PNG)?**

Sim, você pode [exportar o próprio gráfico como uma imagem](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/get_image/) (como PNG) sem a apresentação completa.