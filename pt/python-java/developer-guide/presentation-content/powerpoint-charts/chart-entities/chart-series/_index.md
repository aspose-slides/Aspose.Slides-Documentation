---
title: Gerenciar séries de dados de gráficos em apresentações em Python
linktitle: Séries de Dados
type: docs
url: /pt/python-java/chart-series/
keywords:
- séries de gráfico
- sobreposição de séries
- cor da série
- nome da série
- ponto de dados
- célula da pasta de trabalho
- lacuna da série
- valor negativo
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda a gerenciar séries de gráficos, pontos de dados, células da pasta de trabalho, formatação, sobreposição, largura da lacuna e valores negativos em apresentações com Aspose.Slides para Python via Java."
---
## **Visão geral**

Um gráfico armazena seus dados plotados em uma pasta de trabalho de dados de gráfico. Um [ChartSeries](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/) representa um conjunto de valores relacionados, e cada [ChartDataPoint](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/) na série refere‑se a uma ou mais células da pasta de trabalho. Objetos [ChartCategory](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartcategory/) fornecem os rótulos ou valores de agrupamento compartilhados pelas séries. O nome da série, as categorias e os valores dos pontos estão, portanto, conectados a objetos [ChartDataCell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatacell/) em vez de serem armazenados apenas como texto de exibição.

Para um gráfico de categoria típico, a pasta de trabalho padrão usa a linha 0 para nomes de séries, a coluna 0 para nomes de categorias e as células restantes para valores das séries. Os índices de planilha, linha e coluna passados para [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdataworkbook/#getCell) são baseados em zero. Esse layout é útil quando você cria um gráfico com dados padrão, mas não presuma que todo gráfico existente o utilize. Para uma apresentação carregada, examine as células referenciadas por séries, categorias e pontos de dados antes de alterar os valores da pasta de trabalho.

As configurações do gráfico têm três escopos diferentes:

- Configurações em nível de série, como [ChartSeries.getFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getFormat), fornecem a aparência padrão para todos os pontos de uma série.
- Configurações de ponto de dados, como [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#getFormat), substituem a aparência da série para um ponto.
- Configurações de grupo aplicam‑se a séries compatíveis que pertencem ao mesmo [ChartSeriesGroup](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/). Acesse o grupo através de [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getParentSeriesGroup) quando precisar definir opções como sobreposição ou largura de lacuna.

Quando nenhum preenchimento explícito de ponto ou série é definido, o estilo e o tema do gráfico determinam a aparência automática. Quando há formatação tanto de série quanto de ponto, a formatação do ponto tem precedência para esse ponto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Definir a Sobreposição da Série do Gráfico**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getOverlap) informa o quanto barras ou colunas se sobrepõem em um gráfico 2D, de –100 até 100 por cento. É uma projeção somente‑leitura da configuração no grupo de séries pai. Use [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#setOverlap) para atualizar todas as séries compatíveis nesse grupo. Essa opção aplica‑se a tipos de gráfico que exibem barras ou colunas agrupadas; não afeta grupos de séries não relacionados em um gráfico combinado.

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

    # O novo gráfico contém séries de amostra, categorias e valores.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![A sobreposição da série](series_overlap.png)

## **Alterar a Cor de Preenchimento da Série**

Use [ChartSeries.getFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getFormat) para definir o preenchimento padrão para uma série inteira. Se um ponto já possuir um preenchimento explícito, sua configuração [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#getFormat) substitui o preenchimento da série para esse ponto.

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

![A cor da série](series_color.png)

## **Alterar o Nome da Série**

Um nome de série é armazenado na pasta de trabalho de dados do gráfico e normalmente exibido na legenda. Na pasta de trabalho padrão criada para um gráfico de colunas agrupadas, a célula B1 está na linha 0, coluna 1 e contém o nome da primeira série. As variáveis nomeadas no exemplo a seguir tornam essa estrutura explícita:

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

Você também pode atualizar a célula já referenciada por [ChartSeries.getName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getName). Essa abordagem evita assumir uma linha e coluna específicas em um gráfico existente:

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

![O nome da série](series_name.png)

## **Obter a Cor Automática de Preenchimento da Série**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) devolve a cor calculada a partir do índice da série e do estilo do gráfico. Essa é a cor usada quando o preenchimento da série não foi definido explicitamente. Chamando o método lê a cor calculada; ele não atribui um novo preenchimento.

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

Saída de exemplo para o estilo de gráfico padrão:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

As cores exatas dependem do estilo e do tema do gráfico.

## **Definir Preenchimento Invertido para uma Série do Gráfico**

Para séries de barra, coluna e bolha, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#setInvertIfNegative) pode exibir valores negativos com um preenchimento diferente. Defina o preenchimento regular da série como sólido, habilite a inversão e atribua a cor de valor negativo através de [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Números negativos permanecem inalterados na pasta de trabalho; apenas a cor de exibição muda.

O exemplo a seguir substitui os dados de gráfico padrão por uma única série. A linha 0 da planilha contém o nome da série, a coluna 0 contém nomes de categorias e a coluna 1 contém os valores:

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

![A cor de preenchimento sólido invertido](inverted_solid_fill_color.png)

Você pode habilitar a inversão para um ponto através de [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). No exemplo a seguir, a inversão está desativada para a série e habilitada apenas para o ponto selecionado. O ponto também recebe um valor negativo para que o efeito seja visível:

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

Para tornar um ponto vazio sem remover os demais, defina sua célula de apoio na pasta de trabalho como `None`. Para um gráfico de colunas, o valor plotado está disponível através de [ChartDataPoint.getValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#getValue). O ponto de dados permanece na mesma posição de categoria, mas o gráfico trata seu valor como vazio conforme as configurações de valores vazios do gráfico.

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

Gráficos de dispersão usam células X e Y separadas, e gráficos de bolha também usam uma célula de tamanho. Limpe apenas a célula que representa o valor que você pretende remover. Não chame [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapointcollection/#clear) quando desejar manter os demais pontos, pois esse método remove todos os pontos de dados da coleção.

## **Controlar a Exibição de Células Vazias**

Uma célula vazia da pasta de trabalho representa dados ausentes; uma célula contendo `0` representa um valor numérico conhecido. Chame [ChartDataCell.setValue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatacell/#setValue) com `None` para tornar uma célula vazia. Um zero numérico permanece zero independentemente da configuração de célula vazia.

Use [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#setDisplayBlanksAs) para escolher como o gráfico exibe células vazias. Essa configuração aplica‑se ao gráfico inteiro. Ela altera a forma como os vazios são plotados, sem preencher a célula vazia da pasta de trabalho com zero ou um valor interpolado.

O exemplo autônomo a seguir cria um gráfico de linhas com uma série, limpa o valor do Dia 3 e salva o mesmo gráfico em cada modo. Nenhum arquivo de entrada é necessário. O [ChartDataWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdataworkbook/) usa a planilha 0, coluna 0 para rótulos de categoria e coluna 1 para valores; a linha 0 contém o nome da série. Os dados finais são `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Deixe o Dia 3 realmente vazio, enquanto mantém sua categoria e ponto de dados.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cada arquivo de saída armazena o modo atribuído antes da gravação: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Para salvar apenas uma versão, atribua o modo desejado e salve a apresentação uma única vez, em vez de iterar sobre os modos.

A comparação abaixo mostra os mesmos dados nos três arquivos. O Dia 3 está vazio na pasta de trabalho em todos os casos:

![Gráficos de linha com dados idênticos: Gap interrompe a linha no Dia 3, Zero faz a linha cair a zero e Span conecta o Dia 2 ao Dia 4.](display_blanks_as.png)

O efeito visível depende do tipo de gráfico. Um gráfico de linha facilita a comparação dos três modos. Gráficos de barra e coluna não possuem linha para conectar entre categorias ausentes, portanto `Span` não pode produzir o segmento de conexão mostrado acima; uma coluna ausente e uma coluna de altura zero também podem parecer iguais. Da mesma forma, um gráfico de dispersão apenas com marcadores não tem linha de conexão. Não espere três resultados distintos para todos os tipos de gráfico; verifique a saída para o tipo que você utiliza.

## **Definir a Largura da Lacuna da Série**

A largura da lacuna é o espaço entre clusters adjacentes de barras ou colunas, expressa como porcentagem da largura da barra ou coluna. Como a sobreposição, ela pertence ao grupo de séries pai em vez de a uma única série. Chame [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#setGapWidth) uma vez para o grupo. Um valor maior cria mais espaço entre os clusters; um valor menor os torna mais densos.

O exemplo a seguir altera a largura da lacuna e salva apenas a apresentação final:

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

![A largura da lacuna](gap_width.png)

## **FAQ**

**Quais tipos de gráfico suportam séries de dados?**

Todos os tipos de gráfico representados pela enumeração [ChartType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/charttype/) utilizam dados de gráfico, mas suas séries não têm todas a mesma estrutura de valores ou configurações. Por exemplo, gráficos de categoria usam categorias e valores, gráficos de dispersão usam valores X e Y, e gráficos de bolha adicionam tamanhos de bolha. Use o método de criação de ponto de dados que corresponde ao tipo de série. Opções como sobreposição e largura de lacuna aplicam‑se apenas a grupos de barra ou coluna compatíveis.

**O que é um grupo de séries de gráfico?**

Um [ChartSeriesGroup](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/) contém séries compatíveis que compartilham configurações de plotagem em nível de grupo. Um gráfico combinado pode conter mais de um grupo, portanto alterar o grupo acessado por uma série não altera necessariamente todas as séries do gráfico.

**Um gráfico recém‑criado contém dados padrão?**

Sim. Por padrão, [ShapeCollection.addChart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addChart) cria séries, categorias e valores de exemplo. Você pode editar essas células ou limpar as coleções de séries e categorias antes de adicionar um conjunto de dados totalmente personalizado. Uma sobrecarga também pode criar um gráfico sem dados padrão.

**Como os objetos de gráfico estão conectados às células da pasta de trabalho?**

Nomes de séries, rótulos de categoria e valores de pontos de dados referenciam células em um [ChartDataWorkbook](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdataworkbook/). Alterar uma célula referenciada atualiza o elemento de gráfico correspondente. Ao construir dados personalizados, mantenha as linhas de categoria e as linhas de valores das séries alinhadas para que cada ponto seja plotado sob a categoria pretendida.

**Como limpar apenas um ponto em vez de toda a série?**

Defina a célula de valor relevante como `None` para manter a posição de categoria do ponto como um ponto vazio. Use [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapointcollection/#clear) somente quando pretender remover todos os pontos daquela série. Se também remover categorias, atualize todas as séries para que seus valores permaneçam alinhados com a coleção de categorias.

**Como os pontos vazios são exibidos?**

O resultado depende do tipo de gráfico e do valor configurado em [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#setDisplayBlanksAs). Gráficos compatíveis podem exibir vazios como lacunas, como valores zero ou conectando pontos vizinhos. Escolha a configuração que corresponde ao significado dos dados ausentes em sua apresentação. Consulte **Controlar a Exibição de Células Vazias** para um exemplo completo e comparação visual.

**Como os valores negativos são formatados?**

Para séries de barra, coluna e bolha suportadas, chame [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#setInvertIfNegative) e defina a cor retornada por [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Você pode sobrescrever o comportamento para um ponto individual com [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Esses métodos afetam a formatação, não os valores numéricos armazenados.

**Qual formatação prevalece quando tanto a série quanto o ponto são formatados?**

A formatação explícita de ponto de dados tem precedência para esse ponto. Os demais pontos continuam usando a formatação explícita da série ou, quando a formatação da série não está definida, o estilo e tema automáticos do gráfico. Configurações de grupo, como sobreposição e largura de lacuna, controlam o layout e não substituem formatações em nível de ponto.

**Existe um limite para a quantidade de séries que um gráfico pode conter?**

Aspose.Slides não impõe um limite fixo separado para a contagem de séries. Na prática, as restrições do arquivo de apresentação, memória disponível, tempo de renderização e legibilidade do gráfico determinam um limite útil.

**O que devo ajustar quando as colunas estão muito próximas ou muito distantes?**

Chame [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartseriesgroup/#setGapWidth) no grupo de séries pai apropriado. Aumente o valor para ampliar o espaço entre os clusters ou diminua‑o para aproximar os clusters.