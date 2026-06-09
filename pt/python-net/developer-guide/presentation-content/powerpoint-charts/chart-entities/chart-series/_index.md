---
title: Gerenciar séries de dados de gráfico em Python
linktitle: Séries de Dados
type: docs
url: /pt/python-net/chart-series/
keywords:
- séries de gráfico
- sobreposição de séries
- cor da série
- cor da categoria
- nome da série
- ponto de dados
- espaço entre séries
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a gerenciar séries de dados de gráficos em Python para PowerPoint (PPT/PPTX) com exemplos práticos de código e melhores práticas para melhorar suas apresentações de dados."
---
## **Visão geral**

Este artigo descreve o papel do [ChartSeries](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartseries/) no Aspose.Slides para Python, enfatizando como os dados são estruturados e visualizados dentro de apresentações. Esses objetos fornecem os elementos fundamentais que definem conjuntos individuais de pontos de dados, categorias e parâmetros de aparência em um gráfico. Ao trabalhar com [ChartSeries](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartseries/), os desenvolvedores podem integrar perfeitamente fontes de dados subjacentes e manter controle total sobre como as informações são exibidas, resultando em apresentações dinâmicas e orientadas por dados que transmitem claramente insights e análises.

Uma série é uma linha ou coluna de números plotados em um gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Definir sobreposição de série**

A propriedade [ChartSeries.overlap](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartseries/overlap/) controla como barras e colunas se sobrepõem em um gráfico 2D, especificando um intervalo de -100 a 100. Como a propriedade está associada ao grupo de séries e não a uma série individual, ela é somente leitura no nível da série. Para configurar valores de sobreposição, use a propriedade de leitura/gravação `parent_series_group.overlap`, que aplica a sobreposição especificada a todas as séries desse grupo.

Abaixo está um exemplo em Python que demonstra como criar uma apresentação, adicionar um gráfico de colunas em cluster, acessar a primeira série do gráfico, configurar a definição de sobreposição e, em seguida, salvar o resultado como um arquivo PPTX:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adicionar um gráfico de colunas em cluster com dados padrão.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Definir a sobreposição da série.
        series.parent_series_group.overlap = series_overlap

    # Salvar o arquivo de apresentação no disco.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![The series overlap](series_overlap.png)

## **Alterar cor de preenchimento da série**

O Aspose.Slides simplifica a personalização das cores de preenchimento das séries de gráficos, permitindo que você destaque pontos de dados específicos e crie gráficos visualmente atraentes. Isso é feito através do objeto [Format](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/format/), que suporta vários tipos de preenchimento, configurações de cores e outras opções avançadas de estilo. Depois de adicionar um gráfico a um slide e acessar a série desejada, basta obter a série e aplicar a cor de preenchimento apropriada. Além de preenchimentos sólidos, você também pode usar preenchimentos em degradê ou padrão para maior flexibilidade de design. Depois de definir as cores de acordo com seus requisitos, salve a apresentação para finalizar a aparência atualizada.

O exemplo de código Python a seguir mostra como mudar a cor da primeira série:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adicionar um gráfico de colunas em cluster com dados padrão.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Definir a cor da primeira série.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Salvar o arquivo de apresentação no disco.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![The color of the series](series_color.png)

## **Renomear uma série**

O Aspose.Slides oferece uma maneira simples de modificar os nomes das séries de gráficos, facilitando a rotulagem dos dados de forma clara e significativa. Ao acessar a célula de planilha relevante nos dados do gráfico, os desenvolvedores podem personalizar como os dados são apresentados. Essa modificação é particularmente útil quando os nomes das séries precisam ser atualizados ou esclarecidos com base no contexto dos dados. Após renomear a série, a apresentação pode ser salva para persistir as alterações.

Abaixo está um trecho de código Python demonstrando esse processo em ação.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adicionar um gráfico de colunas em cluster com dados padrão.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Definir o nome da primeira série.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Salvar o arquivo de apresentação no disco.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

O código Python a seguir mostra uma maneira alternativa de mudar o nome da série:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adicionar um gráfico de colunas em cluster com dados padrão.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Definir o nome da primeira série.
    series.name.as_cells[0].value = series_name

    # Salvar o arquivo de apresentação no disco.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```

O resultado:

![The series name](series_name.png)

## **Obter cor automática de preenchimento da série**

O Aspose.Slides para Python permite obter a cor automática de preenchimento para séries de gráficos dentro de uma área de plotagem. Após criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/), você pode obter uma referência ao slide desejado pelo índice e, em seguida, adicionar um gráfico usando o tipo de sua preferência (como `ChartType.CLUSTERED_COLUMN`). Ao acessar as séries no gráfico, você pode obter a cor automática de preenchimento.

O código Python abaixo demonstra esse processo em detalhes.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adicionar um gráfico de colunas em cluster com dados padrão.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Obter a cor de preenchimento da série.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```

Saída de exemplo:

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Definir cores de preenchimento invertidas para uma série**

Quando sua série de dados contém valores positivos e negativos, colorir todas as colunas ou barras da mesma forma pode dificultar a leitura do gráfico. O Aspose.Slides para Python permite atribuir uma cor de preenchimento invertida — um preenchimento separado aplicado automaticamente a pontos de dados que ficam abaixo de zero — para que valores negativos se destaquem imediatamente. Nesta seção você aprenderá como habilitar essa opção, escolher uma cor adequada e salvar a apresentação atualizada.

O exemplo de código a seguir demonstra a operação:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Adicionar novas categorias.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Adicionar uma nova série.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Preencher os dados da série.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Definir as configurações de cor para a série.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![The inverted solid fill color](inverted_solid_fill_color.png)

É possível inverter a cor de preenchimento para um único ponto de dados em vez de toda a série. Basta acessar o `ChartDataPoint` desejado e definir sua propriedade `invert_if_negative` como `True`.

O exemplo de código a seguir mostra como fazer isso:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Limpar dados de pontos de dados específicos**

Às vezes, um gráfico contém valores de teste, outliers ou entradas obsoletas que precisam ser removidos sem reconstruir toda a série. O Aspose.Slides para Python permite selecionar qualquer ponto de dados pelo índice, limpar seu conteúdo e atualizar instantaneamente o plot, de modo que os pontos restantes se deslocem e os eixos sejam redimensionados automaticamente.

O exemplo de código a seguir demonstra a operação:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir largura de intervalo da série**

A largura do espaço controla a quantidade de espaço vazio entre colunas ou barras adjacentes — espaços maiores enfatizam categorias individuais, enquanto espaços menores criam um aspecto mais denso e compacto. Por meio do Aspose.Slides para Python, você pode ajustar finamente esse parâmetro para toda a série, obtendo exatamente o equilíbrio visual que sua apresentação requer sem alterar os dados subjacentes.

O exemplo de código a seguir mostra como definir a largura do espaço para uma série:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Criar uma apresentação vazia.
with slides.Presentation() as presentation:

    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar um gráfico com dados padrão.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Salvar a apresentação no disco.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # Definir o valor de gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Salvar a apresentação no disco.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![The gap width](gap_width.png)

## **FAQ**

**Existe um limite para quantas séries um único gráfico pode conter?**

O Aspose.Slides não impõe um limite fixo ao número de séries que você adiciona. O teto prático é definido pela legibilidade do gráfico e pela memória disponível para sua aplicação.

**E se as colunas dentro de um cluster estiverem muito próximas ou muito afastadas?**

Ajuste a configuração [gap_width](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartseries/gap_width/) para essa série (ou seu grupo de séries pai). Aumentar o valor amplia o espaço entre as colunas, enquanto diminuí-lo as aproxima.