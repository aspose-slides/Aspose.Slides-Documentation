---
title: Gerenciar Rótulos de Dados de Gráficos em Apresentações com Python
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
description: "Aprenda a adicionar e formatar rótulos de dados de gráficos em apresentações PowerPoint usando Aspose.Slides para Python via .NET para slides mais envolventes."
---
## **Introdução**

Os rótulos de dados exibem informações sobre as séries do gráfico e pontos de dados individuais, ajudando os leitores a identificar valores e compreender o gráfico. Este artigo explica como formatar valores, exibir porcentagens, ler o texto do rótulo, controlar rótulos além do máximo do eixo, ajustar o espaçamento dos rótulos do eixo de categorias e posicionar rótulos em gráficos de pizza.

## **Definir Precisão dos Dados nos Rótulos do Gráfico**

Use [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) para formatar os valores da série. Este exemplo cria um gráfico de linhas com dados padrão, exibe sua tabela de dados e habilita rótulos de valores para a primeira série. O formato `#,##0.00` exibe separador de milhar e duas casas decimais sem alterar os valores subjacentes.

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

Para um gráfico de colunas empilhadas, calcule cada valor como porcentagem do total da sua categoria e atribua o texto a [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Este exemplo usa os dados padrão do gráfico e exibe porcentagens com duas casas decimais em fonte de 8 pontos. Categorias com total zero são ignoradas para evitar divisão por zero. Recalcule o texto do rótulo personalizado se os dados do gráfico mudarem.

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

## **Definir Símbolo de Porcentagem nos Rótulos do Gráfico**

Quando os valores são armazenados como frações, use [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) para exibir porcentagens. Defina [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) como `False` para aplicar o formato do rótulo independentemente das células de origem.

Este exemplo cria um gráfico de colunas empilhadas 100 % com séries vermelha e azul em quatro categorias. Cada par de valores soma 1. O formato de rótulo `0.0%` exibe 0.30 como 30.0 %, enquanto o eixo vertical usa duas casas decimais. Ambas as séries usam texto de rótulo branco, 10 pt.

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

Use [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) para recuperar o texto produzido pelas configurações de um rótulo de dados. Isso é útil ao extrair rótulos para relatórios, pesquisar conteúdo da apresentação ou validar gráficos gerados. No exemplo abaixo, o [formato padrão de rótulo de dados](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) combina o nome de cada categoria, o nome da série e o valor. Um ponto formata seu valor como porcentagem e outro usa texto personalizado de [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

O número armazenado em um ponto de dados permanece `0.75`, mesmo quando seu rótulo mostra `75 %` junto com os nomes da categoria e da série. Texto personalizado substitui o texto gerado do rótulo. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) devolve a string de rótulo resultante em ambos os casos. Verifique [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) separadamente, como mostrado acima, quando quiser extrair apenas rótulos visíveis.

## **Controlar Rótulos de Dados Além do Máximo do Eixo**

Ao limitar manualmente o intervalo de um eixo, alguns pontos de dados podem exceder seu máximo. Use [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) para controlar se seus rótulos de dados são exibidos. Essa configuração altera a visibilidade dos rótulos; não altera o intervalo do eixo nem os valores subjacentes.

O exemplo abaixo cria um gráfico de colunas agrupadas 2D com valores 60 e 120. Ele define [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) como `False` e [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) como 100 no eixo vertical. O primeiro slide permite rótulos além do máximo; uma cópia desse slide os desabilita. Ambos os slides são salvos em `DataLabelsOverMaximum.pptx`.

Habilite rótulos de valor com [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). A configuração a nível de gráfico não habilita a exibição de valor por si só nem sobrescreve a exibição desativada de um rótulo individual. Este exemplo habilita valores para toda a série e usa [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) para colocar os rótulos na extremidade externa de cada coluna.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

As imagens a seguir mostram os slides salvos renderizados pelo Microsoft PowerPoint. Com `True`, o rótulo **120** aparece na borda superior; com `False`, ele fica oculto. O rótulo **60** permanece visível, o máximo do eixo continua em **100** e o segundo ponto de dados permanece **120** em ambos os casos.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Este exemplo usa um gráfico de colunas 2D com eixo de valores. Gráficos sem eixo de valores, como pizza e rosca, não possuem um máximo de eixo a ser limitado dessa forma.
{{% /alert %}}

## **Definir Distância do Rótulo em Relação ao Eixo**

Use [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) para controlar a distância entre os rótulos do eixo de categorias e o eixo. O valor é uma porcentagem do tamanho máximo da fonte dos rótulos do eixo. Este exemplo cria um gráfico de colunas agrupadas e define o deslocamento do rótulo do eixo horizontal para 500. Essa configuração afeta os rótulos do eixo de categorias, não os rótulos anexados a pontos de dados individuais.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajustar Localização do Rótulo**

Em um gráfico de pizza, ajuste as posições dos rótulos de dados para melhorar o espaçamento e criar espaço para as linhas de ligação.

Este exemplo exibe o valor do primeiro ponto de dados, coloca seu rótulo fora da fatia e ajusta seus deslocamentos [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) e [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/). Esses deslocamentos são relativos à largura e à altura do gráfico, respectivamente.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Formatar Linhas de Ligação**

Quando os rótulos de gráficos de pizza ficam fora das fatias, as linhas de ligação ajudam os leitores a associar cada valor à fatia correta. Uma cor contrastante e uma linha ligeiramente mais grossa podem tornar essas conexões mais fáceis de seguir, enquanto transparência e estilo tracejado mantêm as linhas discretas.

Use [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) para formatar linhas de ligação no nível da coleção de rótulos de dados da série. As configurações em `series.labels.leader_lines_format.line` aplicam‑se à coleção, e não a um rótulo individual.

Este exemplo cria um gráfico de pizza com dados padrão, exibe valores fora das fatias e habilita [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/). Ele move dois rótulos mais longe de suas fatias usando os deslocamentos [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) e [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/), expressos como frações da largura e altura do gráfico. Nenhuma apresentação de entrada é necessária.

O [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) da linha define uma cor azul sólida com valor alfa 191 de 255, resultando em aproximadamente 25 % de transparência. [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) define a espessura para 2 pontos, e [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) deixa a linha tracejada.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # Mova dois rótulos mais longe de suas fatias.
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

Habilitar linhas de ligação não garante que uma linha apareça para cada rótulo. A visibilidade depende da posição do rótulo e do comportamento de layout do gráfico. Neste exemplo, os dois rótulos deslocados têm linhas de ligação visíveis; os rótulos que permanecem próximos às suas fatias não precisam delas.

A imagem a seguir mostra o `FormattedLeaderLines.pptx` salvo e renderizado com Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **Adicionar Várias Linhas de Rótulos de Dados Acima de um Gráfico de Colunas**

Este exemplo cria um gráfico de colunas com duas linhas de rótulos de dados acima da área de plotagem. A Série A exibe as colunas visíveis, enquanto as Séries B e C fornecem os rótulos adicionais. Suas colunas são ocultas removendo o preenchimento e o contorno. A propriedade [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) alinha as três séries nos mesmos centros de categoria.

As configurações de [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) reservam espaço para as linhas de rótulos. Após [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) calcular as posições padrão, [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) e [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) preservam o alinhamento horizontal e aplicam deslocamentos verticais para organizar os rótulos em duas linhas. Os números permanecem rótulos de dados vinculados aos valores das séries; apenas os cabeçalhos das linhas são formas de texto separadas.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # Oculte as colunas de B e C, mas mantenha seus rótulos de dados.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Alinhe as três séries ao mesmo centro de categoria.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Use menos linhas de grade para este exemplo compacto.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Reserve espaço acima da área de plotagem para duas linhas de rótulos de dados.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # Mantenha a posição horizontal padrão. Y é um deslocamento de
            # a posição padrão do rótulo, expressa como fração da altura do gráfico.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Apenas o cabeçalho da linha é uma forma de texto separada.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **FAQ**

**Como impedir que os rótulos de dados se sobreponham em gráficos densos?**

Combine posicionamento automático de rótulos, linhas de ligação e tamanho de fonte reduzido; se necessário, oculte alguns campos (por exemplo, a categoria) ou mostre rótulos apenas para valores extremos ou pontos-chave.

**Como desativar rótulos apenas para valores zero, negativos ou vazios?**

Filtre os pontos de dados antes de habilitar rótulos e desative a exibição para valores 0, negativos ou ausentes conforme uma regra definida.

**Como garantir um estilo de rótulo consistente ao exportar para PDF/imagens?**

Defina explicitamente a família e o tamanho da fonte e verifique se a fonte está disponível no ambiente de renderização para evitar fallback.