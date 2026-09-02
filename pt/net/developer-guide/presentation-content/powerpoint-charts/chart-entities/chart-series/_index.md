---
title: Gerenciar séries de dados de gráfico em apresentações no .NET
linktitle: Séries de Dados
type: docs
url: /pt/net/chart-series/
keywords:
- séries de gráfico
- sobreposição de séries
- cor da série
- cor da categoria
- nome da série
- ponto de dados
- espaço da série
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Saiba como gerenciar séries de gráfico, pontos de dados, células da planilha, formatação, sobreposição, largura do espaço e valores negativos em apresentações com C#."
---
## **Visão geral**

Um gráfico armazena seus dados plotados em uma planilha de dados de gráfico. Um [IChartSeries](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/) representa um conjunto de valores relacionados, e cada [IChartDataPoint](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/) na série refere‑se a uma ou mais células da planilha. Objetos [IChartCategory](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartcategory/) fornecem os rótulos ou valores de agrupamento compartilhados pelas séries. O nome da série, as categorias e os valores dos pontos estão, portanto, conectados a objetos [IChartDataCell](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/) em vez de serem armazenados apenas como texto de exibição.

Para um gráfico de categoria típico, a planilha padrão usa a linha 0 para nomes de séries, a coluna 0 para nomes de categoria e as células restantes para os valores das séries. Índices de planilha, linha e coluna passados para [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/getcell/) são baseados em zero. Esse layout é útil quando você cria um gráfico com dados padrão, mas não presuma que todo gráfico existente o utilize. Para uma apresentação carregada, inspecione as células referenciadas pelas séries, categorias e pontos de dados antes de alterar os valores da planilha.

As configurações de gráfico têm três escopos diferentes:

- Configurações em nível de série, como [IChartSeries.Format](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/format/), fornecem a aparência padrão para todos os pontos de uma série.
- Configurações de ponto de dados, como [IChartDataPoint.Format](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/format/), substituem a aparência da série para um ponto.
- Configurações de grupo se aplicam a séries compatíveis que pertencem ao mesmo [IChartSeriesGroup](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseriesgroup/). Acesse o grupo através de [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/parentseriesgroup/) quando precisar definir opções como sobreposição ou largura do intervalo.

Quando nenhum preenchimento explícito de ponto ou série está definido, o estilo e o tema do gráfico determinam a aparência automática. Quando há formatação tanto da série quanto do ponto, a formatação do ponto tem precedência para esse ponto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Definir a Sobreposição da Série de Gráfico**

[IChartSeries.Overlap](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/overlap/) informa quanto barras ou colunas se sobrepõem em um gráfico 2D, de -100 a 100 por cento. É uma projeção somente‑leitura da configuração no grupo de séries pai. Defina [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseriesgroup/overlap/) para atualizar todas as séries compatíveis naquele grupo. Essa opção se aplica a tipos de gráfico que exibem barras ou colunas agrupadas; não afeta grupos de séries não relacionados em um gráfico combinado.

O exemplo a seguir define a sobreposição para o grupo que contém a primeira série:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// O novo gráfico contém séries, categorias e valores de exemplo.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

O resultado:

![The series overlap](series_overlap.png)

## **Alterar a Cor de Preenchimento da Série**

Use [IChartSeries.Format](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/format/) para definir o preenchimento padrão de uma série inteira. Se um ponto já possuir um preenchimento explícito, sua configuração [IChartDataPoint.Format](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/format/) sobrescreve o preenchimento da série para esse ponto.

O exemplo a seguir aplica um preenchimento sólido azul à primeira série:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

O resultado:

![The color of the series](series_color.png)

## **Alterar o Nome da Série**

Um nome de série é armazenado na planilha de dados do gráfico e normalmente exibido na legenda. Na planilha padrão criada para um gráfico de colunas agrupadas, a célula B1 está na linha 0, coluna 1 e contém o nome da primeira série. As constantes nomeadas no exemplo a seguir tornam essa estrutura explícita:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Você também pode atualizar a célula já referenciada por [IChartSeries.Name](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/name/). Essa abordagem evita assumir uma linha ou coluna específica em um gráfico existente:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

O resultado:

![The series name](series_name.png)

## **Obter a Cor Automática de Preenchimento da Série**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) devolve a cor calculada a partir do índice da série e do estilo do gráfico. Essa é a cor usada quando o preenchimento da série não foi definido explicitamente. Chamar o método lê a cor calculada; não atribui um novo preenchimento.

O exemplo a seguir imprime a cor automática de cada série padrão:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Exemplo de saída para o estilo de gráfico padrão:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

As cores exatas dependem do estilo e do tema do gráfico.

## **Definir Cor de Preenchimento Invertida para uma Série de Gráfico**

Para séries de barra, coluna e bolha, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/invertifnegative/) pode exibir valores negativos com um preenchimento diferente. Defina o preenchimento regular da série como sólido, habilite a inversão e atribua a cor para valores negativos por meio de [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Números negativos permanecem inalterados na planilha; apenas sua cor de exibição muda.

O exemplo a seguir substitui os dados de gráfico padrão por uma única série. A linha 0 da planilha contém o nome da série, a coluna 0 contém os nomes das categorias e a coluna 1 contém os valores:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

O resultado:

![The inverted solid fill color](inverted_solid_fill_color.png)

É possível habilitar a inversão para um ponto através de [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). No exemplo a seguir, a inversão está desativada para a série e ativada apenas para o ponto selecionado. O ponto também recebe um valor negativo para que o efeito seja visível:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Limpar o Valor de um Ponto de Dados Específico**

Para tornar um ponto vazio sem remover os demais, defina sua célula de apoio na planilha como `null`. Em um gráfico de colunas, o valor plotado está disponível através de [IChartDataPoint.YValue](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/yvalue/). O ponto de dados permanece na mesma posição de categoria, mas o gráfico trata seu valor como em branco conforme as configurações de valores em branco do gráfico.

O exemplo a seguir limpa somente o segundo ponto da primeira série:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Gráficos de dispersão usam células X e Y separadas, e gráficos de bolha também utilizam uma célula de tamanho. Limpe apenas a célula que representa o valor que deseja remover. Não chame [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapointcollection/clear/) quando quiser manter os outros pontos, pois esse método remove todos os pontos de dados da coleção.

## **Definir a Largura do Espaço da Série**

A largura do espaço é o intervalo entre clusters adjacentes de barras ou colunas, expressa como porcentagem da largura da barra ou coluna. Assim como a sobreposição, pertence ao grupo de séries pai em vez de a uma única série. Defina [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) uma vez para o grupo. Um valor maior cria mais espaço entre os clusters; um valor menor os torna mais densos.

O exemplo a seguir altera a largura do espaço e salva apenas a apresentação final:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

O resultado:

![The gap width](gap_width.png)

## **FAQ**

**Quais tipos de gráfico suportam séries de dados?**

Todos os tipos de gráfico representados pela enumeração [ChartType](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/charttype/) utilizam dados de gráfico, mas suas séries nem sempre têm a mesma estrutura de valores ou configurações. Por exemplo, gráficos de categoria usam categorias e valores, gráficos de dispersão usam valores X e Y, e gráficos de bolha adicionam tamanhos de bolha. Use o método de criação de ponto de dados que corresponda ao tipo de série. Opções como sobreposição e largura do intervalo se aplicam apenas a grupos de barras ou colunas compatíveis.

**O que é um grupo de séries de gráfico?**

Um [IChartSeriesGroup](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseriesgroup/) contém séries compatíveis que compartilham configurações de plotagem ao nível do grupo. Um gráfico combinado pode conter mais de um grupo, portanto, alterar o grupo acessado por meio de uma série não altera necessariamente todas as séries do gráfico.

**Um gráfico recém‑criado contém dados padrão?**

Sim. Por padrão, [IShapeCollection.AddChart](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addchart/) cria séries, categorias e valores de exemplo. Você pode editar essas células ou limpar as coleções de séries e categorias antes de adicionar um conjunto de dados totalmente personalizado. Uma sobrecarga também pode criar um gráfico sem dados padrão.

**Como os objetos de gráfico são conectados às células da planilha?**

Nomes de séries, rótulos de categoria e valores de pontos de dados referenciam células em um [IChartDataWorkbook](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/). Alterar uma célula referenciada atualiza o elemento correspondente do gráfico. Ao criar dados personalizados, mantenha as linhas de categorias e as linhas de valores de séries alinhadas para que cada ponto seja plotado na categoria desejada.

**Como limpo um ponto em vez de toda a série?**

Defina a célula de valor relevante como `null` para manter a posição da categoria do ponto como um ponto vazio. Use [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapointcollection/clear/) apenas quando desejar remover todos os pontos daquela série. Se também remover categorias, atualize todas as séries para que seus valores permaneçam alinhados com a coleção de categorias.

**Como os pontos vazios são exibidos?**

O resultado depende do tipo de gráfico e de [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/displayblanksas/). Gráficos compatíveis podem exibir vazios como intervalos, como valores zero ou conectando pontos vizinhos. Escolha a configuração que corresponda ao significado dos dados ausentes em sua apresentação.

**Como os valores negativos são formatados?**

Para séries de barra, coluna e bolha suportadas, habilite [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/invertifnegative/) e defina [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Você pode sobrescrever o comportamento para um ponto individual com [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Essas propriedades afetam a formatação, não os valores numéricos armazenados.

**Qual formatação prevalece quando tanto a série quanto um ponto são formatados?**

A formatação explícita de ponto de dados tem precedência para esse ponto. Outros pontos continuam usando a formatação explícita da série ou, quando a formatação da série não está definida, o estilo e tema automáticos do gráfico. Propriedades de grupo como sobreposição e largura do intervalo controlam o layout e não são substituições de formatação ao nível do ponto.

**Existe um limite para a quantidade de séries que um gráfico pode conter?**

Aspose.Slides não impõe um limite fixo separado para a contagem de séries. Na prática, restrições do arquivo de apresentação, memória disponível, tempo de renderização e legibilidade do gráfico determinam um limite útil.

**O que devo ajustar quando as colunas estão muito próximas ou muito distantes?**

Defina [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) no grupo de séries pai apropriado. Aumente o valor para ampliar o espaço entre os clusters ou diminua para aproximá‑los.