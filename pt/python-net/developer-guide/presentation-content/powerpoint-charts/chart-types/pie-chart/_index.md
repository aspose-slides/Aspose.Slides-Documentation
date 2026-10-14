---
title: Personalizar gráficos de pizza em apresentações com Python
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
- apresentação
- Python
- Aspose.Slides
description: Crie e personalize gráficos de pizza em Python com Aspose.Slides. Configure gráficos secundários, exiba rótulos de dados e aplique cores automáticas nas fatias no PowerPoint.
---
## **Visão geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de gráfico secundário para gráficos Pie of Pie e Bar of Pie e como habilitar a coloração automática de fatias para um gráfico de pizza padrão.

Os exemplos concentram‑se em tarefas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar configurações de séries e rótulos, substituir os dados padrão do gráfico por categorias e valores personalizados e salvar a apresentação atualizada.

## **Opções de Gráfico Secundário para Pie of Pie e Bar of Pie**

Aspose.Slides for Python via .NET oferece suporte a opções de gráfico secundário para gráficos Pie of Pie e Bar of Pie. Essas opções controlam o tamanho do gráfico secundário e como os pontos de dados são distribuídos entre os dois gráficos.

O exemplo a seguir cria um gráfico Pie of Pie em uma nova apresentação e exibe os valores dos pontos de dados como rótulos. A propriedade [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) define o tamanho do gráfico secundário como 149 % do gráfico principal. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) seleciona a divisão baseada em porcentagem, e [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) define o limite para 53 %.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Exibir valores e configurar o gráfico secundário.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Selecionar Categorias para o Gráfico Secundário**

Use divisão personalizada quando quiser agrupar categorias específicas no gráfico secundário independentemente de seus valores percentuais. Por exemplo, um relatório de vendas pode mostrar Online e Events juntos para que os leitores comparem esses dois canais, embora eles representem 35 % e 10 % das vendas totais.

Defina [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) como [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) e selecione os pontos através de [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). O método [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) da coleção aceita um índice baseado em zero na série ou um objeto de ponto de dados. Neste exemplo, o índice 1 seleciona Online e o ponto no índice 3 seleciona Events. Partners também é adicionado temporariamente, depois excluído usando [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Substituir os dados padrão por vendas por canal.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Selecionar Online pelo seu índice baseado em zero e Events pelo seu objeto de ponto de dados.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Excluir Partners da seleção sem excluir seus dados de origem.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) e Events (10) aparecem como fatias separadas no gráfico secundário. No gráfico principal, eles são representados por uma única fatia combinada com valor 45, ao lado de Retail (40) e Partners (15). Remover Partners da seleção personalizada mantém‑o no gráfico principal; ele não é removido da categoria nem do seu valor nos dados de origem do gráfico.

A imagem a seguir mostra a apresentação salva no PowerPoint:

![Gráfico Pie of Pie com Online e Events no gráfico secundário e seu valor combinado de 45 no gráfico principal](pie_of_pie_custom.png)

## **Definir Cores Automáticas para Fatias de Gráfico de Pizza**

Aspose.Slides for Python via .NET pode atribuir automaticamente cores diferentes às fatias de um gráfico de pizza. O exemplo a seguir cria um gráfico de pizza com um título centralizado e substitui os dados padrão por três categorias trimestrais e seus valores. A propriedade [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) exibe os valores 20, 50 e 30 como rótulos, enquanto [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) habilita uma cor distinta para cada fatia.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Adicionar um título centrado ao gráfico.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Substituir os dados padrão usando a primeira planilha.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Exibir valores e atribuir cores diferentes às fatias.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**As variações Pie of Pie e Bar of Pie são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) um gráfico secundário para gráficos de pizza, incluindo os tipos Pie of Pie e Bar of Pie.

**Posso exportar apenas o gráfico como imagem (por exemplo, PNG)?**

Sim, você pode [exportar o próprio gráfico como imagem](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (como PNG) sem exportar toda a apresentação.