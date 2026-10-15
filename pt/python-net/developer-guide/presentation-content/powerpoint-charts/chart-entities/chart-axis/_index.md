---
title: Personalizar Eixos de Gráficos em Apresentações com Python
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
description: "Descubra como usar Aspose.Slides para Python via .NET para personalizar eixos de gráficos em apresentações PowerPoint e OpenDocument para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar os eixos de gráficos com Aspose.Slides para Python via .NET. Ele abrange valores de eixo calculados, troca de linhas e colunas do gráfico, visibilidade do eixo, intervalos de rótulos de categoria e marcas de escala, categorias de data e formatação, rotação do título, posicionamento do eixo, unidades de exibição e dimensionamento logarítmico.

## **Obter os valores máximos no eixo vertical em gráficos**

Crie uma [Apresentação](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e adicione um gráfico de área com dados padrão. Chame [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) antes de ler os valores de eixo calculados para que o layout do gráfico esteja atualizado.

Leia [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) e [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) para os limites do eixo, e [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) e [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) para os intervalos de marcações. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) e [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) fornecem escalas de unidades de tempo, que são relevantes para eixos de data. O exemplo armazena esses valores em variáveis locais e salva o gráfico.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Trocar os Dados entre Eixos**

Use [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) para trocar os papéis de séries e categorias nos dados do gráfico. Cada categoria anterior torna‑se uma série, e cada série anterior torna‑se uma categoria. Isso altera como os dados são agrupados; não troca os eixos horizontal e vertical. O exemplo usa [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) para vincular os dados padrão a `Sheet1!A1:D5`, incluindo a linha de cabeçalho e a coluna de categorias, antes de trocar linhas e colunas. Ele salva um gráfico com quatro séries e três categorias.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Reverter a Ordem de Plotagem de um Eixo**

Use [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) para reverter um eixo de categoria ou de valor. Por exemplo, um gráfico de barras horizontal pode mostrar as fases do projeto de cima para baixo na mesma ordem da planilha: Planejamento, Desenvolvimento, Teste. Reverter um eixo altera a direção da plotagem; não classifica nem reorganiza os dados da planilha. Em comparação, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) troca os papéis de séries e categorias.

O exemplo a seguir cria um gráfico de barras horizontal com três fases e uma série. Ele salva uma apresentação com três slides: ordem normal, categorias invertidas e valores invertidos. Cada cópia usa o mesmo conjunto de dados, e apenas um eixo é invertido em cada cópia.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # Slide 2: exibir a primeira categoria no topo.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Manter o eixo de valores horizontal na parte inferior.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Slide 3: reverter apenas a escala numérica horizontal.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Reverter um eixo também pode mover o eixo perpendicular para o lado oposto da trama. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) controla onde o outro eixo cruza o eixo que está sendo configurado. No slide 2, definir isso como `MAXIMUM` no eixo de categoria invertido mantém o eixo de valor horizontal na parte inferior. Para um ponto de cruzamento específico, use [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Verifique as configurações de cruzamento ao mudar a direção, especialmente se o gráfico já possui um ponto de cruzamento personalizado. Defina `is_plot_order_reversed` de volta para `False` para restaurar a direção de plotagem normal; as configurações de cruzamento são independentes.

| Ordem normal (slide 1) | Categorias invertidas (slide 2) | Valores invertidos (slide 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| As categorias vão de baixo para cima; os valores aumentam da esquerda para a direita. | Planejamento, Desenvolvimento e Teste vão de cima para baixo. Os valores e a ordem das linhas da planilha permanecem inalterados. | As categorias mantêm sua ordem normal; os valores aumentam da direita para a esquerda. O eixo de categoria cruza em zero à direita. |

## **Desativar o Eixo Vertical para Gráficos de Linha**

Defina [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) como `False` no eixo vertical para ocultá‑lo. O exemplo cria um gráfico de linha com dados padrão e o salva com o eixo vertical oculto.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Desativar o Eixo Horizontal para Gráficos de Linha**

Defina [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) como `False` no eixo horizontal para ocultá‑lo. O exemplo cria um gráfico de linha com dados padrão e o salva com o eixo horizontal oculto.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Alterar um Eixo de Categoria**

Defina [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) para escolher um eixo de categoria de data ou texto. Este exemplo requer `ExistingChart.pptx`, com um gráfico como o primeiro shape no primeiro slide e células de categoria contendo valores de data numéricos do Excel. Ele altera o eixo horizontal para um eixo de data. Definir [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) como `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) como `1` e [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) para meses posiciona as marcações principais em intervalos de um mês.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlar Intervalos de Rótulos do Eixo de Categoria**

Quando um gráfico tem muitas categorias, reduza o número de rótulos de eixo visíveis sem remover categorias ou pontos de dados. Defina [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) como `False` e, em seguida, defina [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) para o intervalo de categoria desejado. Para categorias de texto em sua ordem normal, a contagem começa na primeira categoria:

| Intervalo | Rótulos exibidos no exemplo |
| --- | --- |
| `1` | Categoria 1, Categoria 2, Categoria 3, ... Categoria 24 |
| `2` | Categoria 1, Categoria 3, Categoria 5, ... Categoria 23 |
| `3` | Categoria 1, Categoria 4, Categoria 7, ... Categoria 22 |

Um intervalo de `3` exibe cada terceiro rótulo, deixando dois rótulos ocultos entre os rótulos exibidos. Não remove as colunas correspondentes. O espaçamento automático escolhe um intervalo com base no espaço disponível; não exibe necessariamente cada rótulo.

As marcas de escala têm controles separados. Defina [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) como `False` e use [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) para definir seu intervalo. Por exemplo, `1` mantém uma marca em cada intervalo de categoria enquanto os rótulos aparecem somente a cada terceira categoria. Defina [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) para um estilo visível para que você possa ver o resultado. Definir qualquer propriedade de espaçamento automático de volta para `True` permite que o gráfico escolha aquele intervalo novamente.

O exemplo autônomo a seguir cria 24 categorias e uma série, depois salva três slides em `CategoryAxisIntervals.pptx`: espaçamento automático, espaçamento manual de rótulos com marcas de escala independentes e espaçamento automático restaurado. As duas cópias mantêm os dados originais do gráfico. Nenhuma apresentação de entrada é necessária. O texto dos rótulos horizontais facilita a visualização da densidade.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Slide 2: exibir cada terceiro rótulo, mas manter uma marca de escala para cada categoria.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Slide 3: permitir que o gráfico escolha ambos os intervalos novamente.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Espaçamento automático (slide 1):** Nesta renderização, cada segundo rótulo de categoria é exibido e quebra em duas linhas. O resultado automático pode variar com o tamanho do gráfico, fontes e o renderizador.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Espaçamento manual (slide 2):** Cada terceiro rótulo é exibido em uma linha, enquanto as marcas de escala permanecem em cada intervalo de categoria. Todas as 24 colunas, incluindo as que não têm rótulos, permanecem visíveis com os mesmos valores. O slide 3 restaura a aparência automática mostrada acima.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Escolher o Eixo e Intervalo Correto**

Use este intervalo de contagem de categorias para um eixo de categoria de texto, como o eixo de categoria de um gráfico de coluna, linha, área ou barra. Em um gráfico de coluna, ele é o eixo horizontal. Em um gráfico de barras horizontal, o eixo de categoria é vertical, portanto aplique essas configurações ao [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). O espaçamento das marcas de escala também se aplica a um eixo de série em gráficos que possuem um.

Não use o espaçamento de rótulos de categoria para definir a escala numérica de um eixo de valor. Em um eixo de valor, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) especifica uma diferença de valores: por exemplo, uma unidade principal de `10` produz marcas em 0, 10, 20 e assim por diante quando o eixo começa em zero. Um intervalo de rótulo de categoria de `3` conta posições de categoria, independentemente de seus valores de dados. Gráficos de dispersão e bolha utilizam eixos de valor em vez de um eixo de categoria de texto. Para um eixo de data, use unidades principais baseadas em tempo e escalas conforme descrito em [Alterar um Eixo de Categoria](#change-a-category-axis).

## **Definir o Formato de Data para Valores do Eixo de Categoria**

O exemplo substitui os dados padrão do gráfico por quatro valores anuais. As datas são armazenadas como números seriais OLE Automation na primeira planilha (índice `0`). Defina [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) para um eixo de data, desative [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) e atribua `yyyy` a [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) para que os rótulos de categoria exibam anos de quatro dígitos independentemente da formatação da célula.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir um Ângulo de Rotação para o Título do Eixo do Gráfico**

Habilite [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) no eixo vertical, forneça o texto do título e defina [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) para girar o título. O ângulo é medido em graus; este exemplo salva um gráfico de coluna com o título do eixo de valores rotacionado em 90 graus.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir a Posição do Eixo em um Eixo de Categoria ou Valor**

Use [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) para controlar se o eixo de valor cruza o eixo de categoria entre as categorias ou nos marcadores de categoria. Esta propriedade se aplica a eixos de categoria. O exemplo define isso como `True` no eixo de categoria horizontal de um gráfico de coluna e salva o resultado.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir a Unidade de Exibição em um Eixo de Valor do Gráfico**

Defina [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) para dimensionar os rótulos em um eixo de valor sem alterar os dados subjacentes. Com [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) definido como `MILLIONS`, um valor de 60 000 000 é exibido como 60. O exemplo cria um gráfico de coluna e aplica a unidade de exibição milhões ao seu eixo vertical.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Configurar um Eixo de Valor Logarítmico**

Um eixo de valor logarítmico é útil quando valores positivos abrangem várias ordens de magnitude. Por exemplo, um serviço pode receber 10, 100, 1 000, 10 000 e 100 000 solicitações ao longo de cinco períodos. Em uma escala linear, os valores menores aparecem próximos uns dos outros perto de zero. Uma escala logarítmica facilita a comparação do crescimento relativo: distâncias iguais representam razões iguais em vez de diferenças iguais.

Defina [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) como `True` no eixo de valor e use [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) para escolher a base. Isso altera como os valores existentes são exibidos; não altera os dados nem adiciona uma linha de tendência logarítmica. Uma linha de tendência representa uma relação ajustada nos dados e é um recurso separado.

### **Escolher o Eixo de Valor e a Base**

Para um gráfico de linha ou coluna, o eixo de valor é [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Para um gráfico de barras horizontal, ele é [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Gráficos de dispersão e bolha possuem dois eixos de valor, portanto escolha o eixo horizontal para valores X, o eixo vertical para valores Y, ou ambos. Não aplique dimensionamento logarítmico a um eixo de categoria.

A base logarítmica padrão é `10`. Para gráficos PPTX, use uma base de `2` a `1000`, inclusive; bases fracionárias como `2.5` também são suportadas. Com a base `10`, potências sucessivas como 10, 100, 1 000 e 10 000 são igualmente espaçadas.

### **Comparar Dimensionamento Linear e Logarítmico**

O exemplo autônomo a seguir cria um gráfico de linha com as cinco contagens de solicitações no primeiro slide, depois clona esse slide e habilita um eixo de valor logarítmico base‑10 no segundo. Ambos os slides mantêm os mesmos dados.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Manter o primeiro slide linear e mudar apenas a escala do eixo de valor da cópia.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Escala linear (slide 1):** Distâncias verticais iguais representam diferenças iguais nas contagens de solicitações. O maior valor domina o gráfico, dificultando a distinção dos valores menores.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Escala logarítmica (slide 2):** Distâncias verticais iguais representam razões iguais. Cada período tem dez vezes mais solicitações que o anterior, de modo que os pontos formam uma linha reta ascendente na escala base‑10. Os rótulos do eixo ainda mostram as contagens originais de solicitações.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Tratar Valores Zero e Negativos**

Uma escala logarítmica pode exibir apenas valores estritamente positivos. Verifique os dados antes de habilitá‑la. Se valores zero ou negativos forem significativos, mantenha uma escala linear ou mostre‑os separadamente. Se excluir esses valores for adequado à análise, explique a omissão. Não substitua silenciosamente esses valores por números pequenos positivos, pois isso altera o significado dos dados. Qualquer mínimo ou máximo configurado manualmente para um eixo logarítmico também deve ser positivo.

## **FAQ**

**Como definio o valor onde um eixo cruza o outro (cruzamento de eixos)?**

Use [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) para selecionar o comportamento de cruzamento. Para especificar um valor numérico de cruzamento, defina [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Essas configurações permitem mover o cruzamento do eixo para uma linha de base adequada.

**Como posso posicionar os rótulos das marcas em relação ao eixo?**

Defina [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) usando [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` ou `NONE`. Para controlar as próprias marcas de escala, use [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) ou [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); estes são independentes do posicionamento dos rótulos.