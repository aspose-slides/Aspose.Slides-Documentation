---
title: Gerenciar Séries de Dados de Gráficos em Apresentações em Python
linktitle: Séries de Dados
type: docs
url: /pt/python-java/chart-series/
keywords:
- séries de gráfico
- sobreposição de série
- cor da série
- nome da série
- ponto de dados
- célula de planilha
- espaço da série
- valor negativo
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda como gerenciar séries de gráficos, pontos de dados, células de planilha, formatação, sobreposição, largura do espaço e valores negativos em apresentações com Aspose.Slides para Python via Java."
---
## **Visão geral**

Um gráfico armazena seus dados plotados em uma planilha de dados de gráfico. Um [ChartSeries](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/) representa um conjunto de valores relacionados, e cada [ChartDataPoint](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/) na série refere-se a uma ou mais células da planilha. [ChartCategory](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartcategory/) objetos fornecem os rótulos ou valores de agrupamento compartilhados pela série. O nome da série, as categorias e os valores dos pontos estão, portanto, conectados a objetos [ChartDataCell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatacell/) em vez de serem armazenados apenas como texto de exibição.

Para um gráfico de categorias típico, a planilha padrão usa a linha 0 para nomes de série, a coluna 0 para nomes de categoria e as demais células para valores das séries. Os índices de planilha, linha e coluna passados para [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdataworkbook/#getCell) são baseados em zero. Esse layout é útil ao criar um gráfico com dados padrão, mas não presuma que todo gráfico existente o utilize. Para uma apresentação carregada, inspecione as células referenciadas pelas séries, categorias e pontos de dados antes de alterar os valores da planilha.

As configurações do gráfico têm três escopos diferentes:

- Configurações ao nível da série, como [ChartSeries.getFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getFormat), fornecem a aparência padrão para todos os pontos de uma série.
- Configurações de ponto de dados, como [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#getFormat), substituem a aparência da série para um ponto.
- Configurações de grupo aplicam‑se a séries compatíveis que pertencem ao mesmo [ChartSeriesGroup](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/). Acesse o grupo através de [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getParentSeriesGroup) quando precisar definir opções como sobreposição ou largura do espaço.

Quando não há preenchimento explícito de ponto ou série definido, o estilo e o tema do gráfico determinam a aparência automática. Quando há formatação de série e de ponto, a formatação do ponto tem precedência para esse ponto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Definir a Sobreposição da Série de Gráfico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getOverlap) informa o quanto barras ou colunas se sobrepõem em um gráfico 2D, de -100 a 100 por cento. É uma projeção somente leitura da configuração no grupo de série pai. Use [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#setOverlap) para atualizar todas as séries compatíveis nesse grupo. Esta opção se aplica a tipos de gráfico que exibem barras ou colunas agrupadas; não afeta grupos de série não relacionados em um gráfico combinado.

O exemplo a seguir define a sobreposição para o grupo que contém a primeira série:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # O novo gráfico contém séries, categorias e valores de exemplo.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![The series overlap](series_overlap.png)

## **Alterar a Cor de Preenchimento da Série**

Use [ChartSeries.getFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getFormat) para definir o preenchimento padrão de uma série inteira. Se um ponto já possui um preenchimento explícito, sua configuração [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#getFormat) substitui o preenchimento da série para esse ponto.

O exemplo a seguir aplica um preenchimento sólido azul à primeira série:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![The color of the series](series_color.png)

## **Alterar o Nome da Série**

Um nome de série é armazenado na planilha de dados do gráfico e normalmente exibido na legenda. Na planilha padrão criada para um gráfico de colunas agrupadas, a célula B1 está na linha 0, coluna 1 e contém o nome da primeira série. As variáveis nomeadas no exemplo a seguir tornam essa estrutura explícita:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Você também pode atualizar a célula já referenciada por [ChartSeries.getName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getName). Essa abordagem evita supor uma linha ou coluna específica em um gráfico existente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![The series name](series_name.png)

## **Obter a Cor de Preenchimento Automática da Série**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) devolve a cor calculada a partir do índice da série e do estilo do gráfico. Essa é a cor usada quando o preenchimento da série não foi definido explicitamente. Chamar o método lê a cor calculada; não atribui um novo preenchimento.

O exemplo a seguir imprime a cor automática de cada série padrão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Exemplo de saída para o estilo de gráfico padrão:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

As cores exatas dependem do estilo e do tema do gráfico.

## **Definir Cor de Preenchimento Invertida para uma Série de Gráfico**

Para séries de barras, colunas e bolhas, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#setInvertIfNegative) pode exibir valores negativos com um preenchimento diferente. Defina o preenchimento regular da série como sólido, habilite a inversão e atribua a cor para valores negativos através de [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Os números negativos permanecem inalterados na planilha; apenas sua cor de exibição muda.

O exemplo a seguir substitui os dados padrão do gráfico por uma série. A linha 0 da planilha contém o nome da série, a coluna 0 contém os nomes das categorias e a coluna 1 contém os valores:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![The inverted solid fill color](inverted_solid_fill_color.png)

Você pode habilitar a inversão para um ponto através de [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). No exemplo a seguir, a inversão está desativada para a série e ativada apenas para o ponto selecionado. O ponto também recebe um valor negativo para que o efeito seja visível:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Limpar o Valor de um Ponto de Dados Específico**

Para tornar um ponto vazio sem remover os demais, defina a célula de apoio da planilha como `None`. Para um gráfico de colunas, o valor plotado está disponível através de [ChartDataPoint.getValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#getValue). O ponto de dados permanece na mesma posição de categoria, mas o gráfico trata seu valor como em branco de acordo com as configurações de valores em branco do gráfico.

O exemplo a seguir limpa apenas o segundo ponto da primeira série:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gráficos de dispersão usam células X e Y separadas, e gráficos de bolhas também usam uma célula de tamanho. Limpe somente a célula que representa o valor que pretende remover. Não chame [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapointcollection/#clear) quando quiser manter os demais pontos, pois esse método remove todos os pontos de dados da coleção.

## **Definir a Largura do Espaço da Série**

A largura do espaço é o intervalo entre clusters adjacentes de barras ou colunas, expressa como porcentagem da largura da barra ou coluna. Assim como a sobreposição, pertence ao grupo de série pai, não a uma série única. Chame [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#setGapWidth) uma vez para o grupo. Um valor maior cria mais espaço entre os clusters; um valor menor os torna mais densos.

O exemplo a seguir altera a largura do espaço e salva apenas a apresentação final:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![The gap width](gap_width.png)

## **FAQ**

**Quais tipos de gráfico suportam séries de dados?**

Todos os tipos de gráfico representados pela enumeração [ChartType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/charttype/) utilizam dados de gráfico, mas suas séries não possuem todas a mesma estrutura de valores ou configurações. Por exemplo, gráficos de categorias usam categorias e valores, gráficos de dispersão usam valores X e Y, e gráficos de bolhas adicionam tamanhos de bolha. Use o método de criação de ponto de dados que corresponde ao tipo de série. Opções como sobreposição e largura do espaço aplicam‑se apenas a grupos de barras ou colunas compatíveis.

**O que é um grupo de séries de gráfico?**

Um [ChartSeriesGroup](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/) contém séries compatíveis que compartilham configurações de plotagem ao nível do grupo. Um gráfico combinado pode conter mais de um grupo, portanto mudar o grupo acessado por uma série não altera necessariamente todas as séries do gráfico.

**Um gráfico recém‑criado contém dados padrão?**

Sim. Por padrão, [ShapeCollection.addChart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addChart) cria séries, categorias e valores de exemplo. Você pode editar essas células ou limpar as coleções de séries e categorias antes de adicionar um conjunto de dados totalmente personalizado. Uma sobrecarga também pode criar um gráfico sem dados padrão.

**Como os objetos do gráfico estão conectados às células da planilha?**

Os nomes das séries, rótulos de categoria e valores de pontos de dados referenciam células em uma [ChartDataWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdataworkbook/). Alterar uma célula referenciada atualiza o elemento correspondente do gráfico. Ao criar dados personalizados, mantenha as linhas de categoria e as linhas de valores das séries alinhadas para que cada ponto seja plotado sob a categoria pretendida.

**Como limpar um ponto em vez de toda a série?**

Defina a célula de valor correspondente como `None` para manter a posição de categoria do ponto como um ponto vazio. Use [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapointcollection/#clear) somente quando desejar remover todos os pontos daquela série. Se também remover categorias, atualize todas as séries para que seus valores permaneçam alinhados com a coleção de categorias.

**Como os pontos vazios são exibidos?**

O resultado depende do tipo de gráfico e do valor configurado por [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#setDisplayBlanksAs). Gráficos compatíveis podem exibir vazios como lacunas, como valores zero ou conectando pontos vizinhos. Escolha a configuração que corresponde ao significado dos dados ausentes em sua apresentação.

**Como os valores negativos são formatados?**

Para séries de barra, coluna e bolha compatíveis, chame [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#setInvertIfNegative) e defina a cor devolvida por [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Você pode sobrescrever o comportamento para um ponto individual com [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Esses métodos afetam a formatação, não os valores numéricos armazenados.

**Qual formatação prevalece quando tanto a série quanto o ponto são formatados?**

A formatação explícita de ponto de dados tem precedência para esse ponto. Os demais pontos continuam usando a formatação explícita da série ou, quando a formatação da série não está definida, o estilo e tema automáticos do gráfico. Configurações de grupo como sobreposição e largura do espaço controlam o layout e não são sobrescritas por formatação ao nível do ponto.

**Existe um limite para quantas séries um gráfico pode conter?**

Aspose.Slides não impõe um limite fixo separado de contagem de séries. Na prática, as restrições do arquivo de apresentação, memória disponível, tempo de renderização e legibilidade do gráfico determinam um limite útil.

**O que devo mudar quando as colunas estão muito próximas ou muito afastadas?**

Chame [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#setGapWidth) no grupo de série pai apropriado. Aumente o valor para ampliar o espaço entre os clusters, ou diminua‑o para aproximar os clusters.