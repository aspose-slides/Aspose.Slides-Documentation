---
title: Gerenciar rótulos de dados de gráficos em apresentações com Python
linktitle: Rótulo de dados
type: docs
url: /pt/python-net/chart-data-label/
keywords:
- gráfico
- rótulo de dados
- precisão de dados
- percentual
- distância do rótulo
- localização do rótulo
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a adicionar e formatar rótulos de dados em gráficos em apresentações PowerPoint e OpenDocument usando Aspose.Slides for Python via .NET para slides mais envolventes."
---
## **Visão geral**

Os rótulos de dados em um gráfico exibem detalhes sobre as séries de dados do gráfico ou pontos de dados individuais. Eles permitem que os leitores identifiquem rapidamente as séries de dados e também tornam os gráficos mais fáceis de entender. No Aspose.Slides for Python, você pode habilitar, personalizar e formatar rótulos de dados para qualquer gráfico—escolhendo o que exibir (valores, percentuais, nomes de séries ou categorias), onde posicionar os rótulos e como eles aparecem (fonte, formato numérico, separadores, linhas de ligação e muito mais). Este artigo descreve as APIs essenciais e exemplos que você precisa para adicionar rótulos claros e informativos aos seus gráficos.

## **Definir a precisão dos rótulos de dados**

Os rótulos de dados de gráficos geralmente exibem valores numéricos que exigem precisão consistente. Esta seção mostra como controlar o número de casas decimais dos rótulos de dados no Aspose.Slides aplicando um formato numérico adequado.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Exibir percentuais como rótulos**

Com o Aspose.Slides, você pode exibir percentuais como rótulos de dados em gráficos. O exemplo abaixo calcula a participação de cada ponto dentro da sua categoria e formata o rótulo para mostrar o percentual.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Crie uma instância da classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Salve a apresentação contendo o gráfico.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Mostrar o símbolo de porcentagem nos rótulos de dados do gráfico**

Esta seção mostra como exibir percentuais nos rótulos de dados do gráfico e incluir o símbolo de porcentagem usando o Aspose.Slides. Você aprenderá a habilitar valores percentuais para séries inteiras ou pontos específicos (ideal para gráficos de pizza, rosca e empilhados 100%) e como controlar a formatação por meio das opções de rótulo ou de um formato numérico personalizado.

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Crie uma instância da classe Presentation.
with slides.Presentation() as presentation:

    # Obtenha uma referência ao slide por índice.
    slide = presentation.slides[0]

    # Crie um gráfico PercentsStackedColumn no slide.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Obtenha a pasta de trabalho de dados do gráfico.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Adicione uma nova série.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Defina a cor de preenchimento da série.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Defina as propriedades de formato do rótulo.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Adicione uma nova série.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Defina o tipo de preenchimento e a cor.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Salve a apresentação.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir a distância do rótulo a partir do eixo**

Esta seção mostra como controlar a distância entre os rótulos de dados e o eixo do gráfico no Aspose.Slides. Ajustar esse deslocamento ajuda a evitar sobreposições e melhora a legibilidade em visualizações densas.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Crie uma instância da classe Presentation.
with slides.Presentation() as presentation:
    # Obtenha uma referência ao slide.
    slide = presentation.slides[0]

    # Crie um gráfico de colunas agrupadas no slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Defina a distância do rótulo do eixo de categoria (horizontal).
    chart.axes.horizontal_axis.label_offset = 500

    # Salve a apresentação.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajustar a posição do rótulo**

Quando você cria um gráfico que não utiliza eixos, como um gráfico de pizza, os rótulos de dados podem ficar muito próximos da borda. Nesse caso, ajuste a posição do rótulo para que as linhas de ligação sejam exibidas claramente.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Posição do rótulo alterada](changed_label_position.png)

## **Perguntas frequentes**

**Como posso evitar que rótulos de dados se sobreponham em gráficos densos?**

Combine posicionamento automático de rótulos, linhas de ligação e redução do tamanho da fonte; se necessário, oculte alguns campos (por exemplo, a categoria) ou exiba rótulos apenas para pontos extremos/chave.

**Como posso desativar rótulos apenas para valores zero, negativos ou vazios?**

Filtre os pontos de dados antes de habilitar os rótulos e desative a exibição para valores 0, valores negativos ou valores ausentes de acordo com uma regra definida.

**Como garantir um estilo de rótulo consistente ao exportar para PDF/imagens?**

Defina explicitamente as fontes (família, tamanho) e verifique se a fonte está disponível no lado de renderização para evitar substituição.