---
title: Gerenciar Rótulos de Dados de Gráfico em Apresentações com Python
linktitle: Rótulo de Dados
type: docs
url: /pt/python-net/chart-data-label/
keywords:
- gráfico
- rótulo de dados
- precisão de dados
- porcentagem
- distância do rótulo
- localização do rótulo
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a adicionar e formatar rótulos de dados de gráfico em apresentações PowerPoint usando Aspose.Slides para Python via .NET para slides mais envolventes."
---
## **Introdução**

Os rótulos de dados exibem informações sobre as séries de gráfico e pontos de dados individuais, ajudando os leitores a identificar valores e a entender o gráfico. Este artigo explica como formatar valores, exibir porcentagens, ler o texto do rótulo, ajustar o espaçamento dos rótulos do eixo de categorias e posicionar rótulos em gráficos de pizza.

## **Definir Precisão de Dados nos Rótulos de Dados do Gráfico**

Use [number_format_of_values](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartseries/number_format_of_values/) para formatar os valores das séries. Este exemplo cria um gráfico de linha com dados padrão, exibe sua tabela de dados e habilita os rótulos de valor para a primeira série. O formato `#,##0.00` exibe um separador de milhar e duas casas decimais sem alterar os valores subjacentes.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Exibir Porcentagem como Rótulos**

Para um gráfico de colunas empilhadas, calcule cada valor como uma porcentagem do total da sua categoria e atribua o texto a [text_frame_for_overriding](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Este exemplo usa os dados padrão do gráfico e exibe porcentagens com duas casas decimais em uma fonte de 8 pontos. Categorias com total zero são ignoradas para evitar divisão por zero. Recalcule o texto do rótulo personalizado se os dados do gráfico forem alterados.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Sinal de Porcentagem nos Rótulos de Dados do Gráfico**

Quando os valores são armazenados como frações, use [number_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabelformat/number_format/) para exibir porcentagens. Defina [is_number_format_linked_to_source](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) como `False` para aplicar o formato do rótulo independentemente das células de origem.

Este exemplo cria um gráfico de colunas empilhadas 100% com séries vermelha e azul em quatro categorias. Cada par de valores soma 1. O formato de rótulo `0.0%` exibe 0,30 como 30,0%, enquanto o eixo vertical usa duas casas decimais. Ambas as séries usam texto de rótulo branco, tamanho 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ler o Texto Real dos Rótulos de Dados**

Use [get_actual_label_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) para obter o texto gerado pelas configurações de um rótulo de dados. Isso é útil ao extrair rótulos para relatórios, pesquisar conteúdo de apresentações ou validar gráficos gerados. No exemplo abaixo, o [formato padrão de rótulo de dados](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabelformat/) combina o nome de cada categoria, o nome da série e o valor. Um ponto formata seu valor como porcentagem e outro usa texto personalizado de [text_frame_for_overriding](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

O número armazenado em um ponto de dados permanece `0.75`, mesmo quando seu rótulo exibe `75%` juntamente com os nomes da categoria e da série. Texto personalizado substitui o texto de rótulo gerado. [get_actual_label_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) retorna a string de rótulo resultante em ambos os casos. Verifique [is_visible](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabel/is_visible/) separadamente, como mostrado acima, quando desejar extrair apenas rótulos visíveis.

## **Definir Distância do Rótulo a partir de um Eixo**

Use [label_offset](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/axis/label_offset/) para controlar a distância entre os rótulos do eixo de categorias e o eixo. O valor é uma porcentagem do tamanho máximo da fonte dos rótulos do eixo. Este exemplo cria um gráfico de colunas agrupadas e define o deslocamento do rótulo do eixo horizontal para 500. Essa configuração afeta os rótulos do eixo de categorias, e não os rótulos associados a pontos de dados individuais.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajustar Posicionamento do Rótulo**

Em um gráfico de pizza, ajuste as posições dos rótulos de dados para melhorar o espaçamento e liberar espaço para linhas de ligação.

Este exemplo exibe o valor do primeiro ponto de dados, coloca seu rótulo fora da fatia e ajusta seus deslocamentos [x](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabel/x/) e [y](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datalabel/y/). Esses deslocamentos são relativos à largura e à altura do gráfico, respectivamente.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Gráfico de pizza com posição de rótulo de dados ajustada](pie-chart-adjusted-label.png)

## **Perguntas Frequentes**

**Como posso evitar que os rótulos de dados se sobreponham em gráficos densos?**

Combine posicionamento automático de rótulos, linhas de ligação e redução do tamanho da fonte; se necessário, oculte alguns campos (por exemplo, a categoria) ou exiba rótulos apenas para valores extremos ou pontos‑chave.

**Como posso desabilitar rótulos apenas para valores zero, negativos ou vazios?**

Filtre os pontos de dados antes de habilitar os rótulos e desative a exibição para valores zero, valores negativos ou valores ausentes de acordo com uma regra definida.

**Como garantir um estilo de rótulo consistente ao exportar para PDF/imagens?**

Defina explicitamente a família e o tamanho da fonte e verifique se a fonte está disponível no ambiente de renderização para evitar substituição.