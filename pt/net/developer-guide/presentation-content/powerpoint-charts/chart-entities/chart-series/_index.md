---
title: Gerenciar séries de dados de gráficos em apresentações em .NET
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
- espaço entre séries
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Saiba como gerenciar séries de gráficos, pontos de dados, células da pasta de trabalho, formatação, sobreposição, largura do intervalo e valores negativos em apresentações com C#."
---
## **Visão geral**

Um gráfico armazena seus dados plotados em uma pasta de trabalho de dados do gráfico. Um [IChartSeries](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/) representa um conjunto de valores relacionados, e cada [IChartDataPoint](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/) da série se refere a uma ou mais células da pasta de trabalho. Objetos [IChartCategory](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartcategory/) fornecem os rótulos ou valores de agrupamento compartilhados pelas séries. O nome da série, as categorias e os valores dos pontos estão, portanto, ligados a objetos [IChartDataCell](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/) em vez de serem armazenados apenas como texto de exibição.

Para um gráfico de categoria típico, a pasta de trabalho padrão usa a linha 0 para nomes das séries, a coluna 0 para nomes das categorias e as células restantes para os valores das séries. Os índices de planilha, linha e coluna passados para [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/getcell/) são baseados em zero. Esse layout é útil quando você cria um gráfico com dados padrão, mas não assume que todo gráfico existente o utiliza. Para uma apresentação carregada, inspecione as células referenciadas pelas séries, categorias e pontos de dados antes de alterar os valores da pasta de trabalho.

As configurações de gráfico têm três escopos diferentes:

- Configurações ao nível da série, como [IChartSeries.Format](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/format/), fornecem a aparência padrão para todos os pontos de uma série.
- Configurações de ponto de dados, como [IChartDataPoint.Format](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/format/), substituem a aparência da série para um ponto.
- Configurações de grupo aplicam‑se a séries compatíveis que pertencem ao mesmo [IChartSeriesGroup](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseriesgroup/). Acesse o grupo através de [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/parentseriesgroup/) quando precisar definir opções como sobreposição ou largura do intervalo.

Quando nenhuma preenchimento explícito de ponto ou série está definido, o estilo e o tema do gráfico determinam a aparência automática. Quando há formatação de série e de ponto, a formatação do ponto tem precedência para esse ponto.

![série de gráfico no PowerPoint](chart-series-powerpoint.png)

## **Definir a sobreposição das séries do gráfico**

[IChartSeries.Overlap](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/overlap/) indica o quanto as barras ou colunas se sobrepõem em um gráfico 2D, de -100 a 100 por cento. É uma projeção somente leitura da configuração no grupo de série pai. Defina [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseriesgroup/overlap/) para atualizar todas as séries compatíveis nesse grupo. Essa opção se aplica a tipos de gráfico que exibem barras ou colunas agrupadas; não afeta grupos de séries não relacionados em um gráfico combinado.

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

![Sobreposição das séries](series_overlap.png)

## **Alterar a cor de preenchimento da série**

Use [IChartSeries.Format](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/format/) para definir o preenchimento padrão de uma série inteira. Se um ponto já possuir um preenchimento explícito, sua configuração [IChartDataPoint.Format](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/format/) substitui o preenchimento da série para esse ponto.

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

![Cor da série](series_color.png)

## **Alterar o nome da série**

O nome da série é armazenado na pasta de trabalho de dados do gráfico e normalmente é exibido na legenda. Na pasta de trabalho padrão criada para um gráfico de colunas agrupadas, a célula B1 está na linha 0, coluna 1 e contém o nome da primeira série. As constantes nomeadas no exemplo a seguir tornam essa estrutura explícita:

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

Você também pode atualizar a célula já referenciada por [IChartSeries.Name](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/name/). Essa abordagem evita assumir uma linha e coluna específicas em um gráfico existente:

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

![Nome da série](series_name.png)

## **Obter a cor automática de preenchimento da série**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) devolve a cor calculada a partir do índice da série e do estilo do gráfico. Essa é a cor usada quando o preenchimento da série não foi definido explicitamente. Chamar o método lê a cor calculada; ele não atribui um novo preenchimento.

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

Saída de exemplo para o estilo de gráfico padrão:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

As cores exatas dependem do estilo e do tema do gráfico.

## **Definir preenchimento invertido para uma série de gráfico**

Para séries de barra, coluna e bolha, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/invertifnegative/) pode exibir valores negativos com um preenchimento diferente. Defina o preenchimento regular da série como sólido, habilite a inversão e atribua a cor de valor negativo por meio de [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Números negativos permanecem inalterados na pasta de trabalho; apenas sua cor de exibição muda.

O exemplo a seguir substitui os dados padrão do gráfico por uma única série. A linha 0 da planilha contém o nome da série, a coluna 0 contém os nomes das categorias e a coluna 1 contém os valores:

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

![Preenchimento sólido invertido](inverted_solid_fill_color.png)

Você pode habilitar a inversão para um ponto através de [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). No exemplo a seguir, a inversão está desativada para a série e habilitada apenas para o ponto selecionado. O ponto também recebe um valor negativo para que o efeito seja visível:

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

## **Limpar o valor de um ponto de dados específico**

Para tornar um ponto vazio sem remover os demais, defina sua célula de apoio na pasta de trabalho como `null`. Para um gráfico de colunas, o valor plotado está disponível por meio de [IChartDataPoint.YValue](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/yvalue/). O ponto de dados permanece na mesma posição de categoria, mas o gráfico trata seu valor como em branco de acordo com as configurações de valores em branco do gráfico.

O exemplo a seguir limpa apenas o segundo ponto da primeira série:

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

Gráficos de dispersão usam células X e Y separadas, e gráficos de bolha também usam uma célula de tamanho. Limpe apenas a célula que representa o valor que você pretende remover. Não chame [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapointcollection/clear/) quando desejar manter os demais pontos, pois esse método remove todos os pontos de dados da coleção.

## **Controlar a exibição de células vazias**

Uma célula vazia na pasta de trabalho representa dados ausentes; uma célula contendo `0` representa um valor numérico conhecido. Defina [IChartDataCell.Value](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatacell/value/) como `null` para tornar a célula vazia. Um zero numérico permanece zero independentemente da configuração de célula em branco.

Use [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/displayblanksas/) para escolher como o gráfico exibe células vazias. Essa configuração se aplica a todo o gráfico. Ela altera como os vazios são plotados, sem preencher a célula vazia da pasta de trabalho com zero ou um valor interpolado.

O exemplo autocontido a seguir cria um gráfico de linhas com uma série, limpa o valor do Dia 3 e salva o mesmo gráfico em cada modo. Nenhum arquivo de entrada é necessário. O [IChartDataWorkbook](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/) usa a planilha 0, coluna 0 para rótulos de categoria e coluna 1 para valores; a linha 0 contém o nome da série. Os dados finais são `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Deixe o Dia 3 realmente vazio, mantendo sua categoria e ponto de dados.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Cada arquivo de saída armazena o modo atribuído antes de salvar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Para salvar apenas uma versão, atribua o modo desejado e salve a apresentação uma única vez em vez de iterar sobre os modos.

A comparação abaixo mostra os mesmos dados nos três arquivos. O Dia 3 está vazio na pasta de trabalho em todos os casos:

![Gráficos de linha com dados idênticos: Gap interrompe a linha no Dia 3, Zero reduz a linha a zero, e Span conecta o Dia 2 ao Dia 4.](display_blanks_as.png)

O efeito visível depende do tipo de gráfico. Um gráfico de linha permite comparar facilmente os três modos. Gráficos de barra e coluna não possuem linha para conectar categorias ausentes, portanto `Span` não pode produzir o segmento de conexão mostrado acima; uma coluna ausente e uma coluna de altura zero podem parecer semelhantes. Da mesma forma, um gráfico de dispersão apenas com marcadores não tem linha de conexão. Não espere três resultados distintos para todos os tipos de gráfico; verifique a saída para o tipo que você está usando.

## **Definir a largura do intervalo da série**

A largura do intervalo é o espaço entre clusters adjacentes de barras ou colunas, expresso como percentual da largura da barra ou coluna. Assim como a sobreposição, pertence ao grupo de séries pai em vez de a uma única série. Defina [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) uma vez para o grupo. Um valor maior cria mais espaço entre os clusters; um valor menor os torna mais densos.

O exemplo a seguir altera a largura do intervalo e salva apenas a apresentação final:

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

![Largura do intervalo](gap_width.png)

## **FAQ**

**Quais tipos de gráfico suportam séries de dados?**

Todos os tipos de gráfico representados pela enumeração [ChartType](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/charttype/) usam dados de gráfico, mas suas séries não têm todas a mesma estrutura de valores ou configurações. Por exemplo, gráficos de categoria usam categorias e valores, gráficos de dispersão usam valores X e Y, e gráficos de bolha adicionam tamanhos de bolha. Use o método de criação de ponto de dados que corresponde ao tipo de série. Opções como sobreposição e largura do intervalo aplicam‑se apenas a grupos de barra ou coluna compatíveis.

**O que é um grupo de séries de gráfico?**

Um [IChartSeriesGroup](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseriesgroup/) contém séries compatíveis que compartilham configurações de plotagem ao nível do grupo. Um gráfico combinado pode conter mais de um grupo, portanto alterar o grupo acessado por uma série não altera necessariamente todas as séries do gráfico.

**Um gráfico recém‑criado contém dados padrão?**

Sim. Por padrão, [IShapeCollection.AddChart](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addchart/) cria séries, categorias e valores de exemplo. Você pode editar essas células ou limpar tanto as coleções de séries quanto as de categorias antes de adicionar um conjunto de dados totalmente personalizado. Uma sobrecarga também pode criar um gráfico sem dados padrão.

**Como os objetos do gráfico estão conectados às células da pasta de trabalho?**

Nomes de séries, rótulos de categorias e valores de pontos de dados referenciam células em um [IChartDataWorkbook](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdataworkbook/). Alterar uma célula referenciada atualiza o elemento correspondente do gráfico. Ao criar dados personalizados, mantenha as linhas de categorias e as linhas de valores das séries alinhadas para que cada ponto seja plotado sob a categoria pretendida.

**Como limpar um ponto em vez de toda a série?**

Defina a célula de valor relevante como `null` para manter a posição de categoria do ponto como um ponto vazio. Use [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapointcollection/clear/) somente quando pretender remover todos os pontos daquela série. Se também remover categorias, atualize todas as séries para que seus valores permaneçam alinhados com a coleção de categorias.

**Como os pontos vazios são exibidos?**

O resultado depende do tipo de gráfico e de [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/displayblanksas/). Gráficos suportados podem exibir vazios como intervalos, como valores zero ou conectando pontos vizinhos. Escolha a configuração que corresponde ao significado dos dados ausentes em sua apresentação. Consulte **Controlar a exibição de células vazias** para um exemplo completo e comparação visual.

**Como valores negativos são formatados?**

Para séries de barra, coluna e bolha suportadas, habilite [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/invertifnegative/) e defina [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Você pode sobrescrever o comportamento para um ponto individual com [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Essas propriedades afetam a formatação, não os valores numéricos armazenados.

**Qual formatação prevalece quando tanto a série quanto o ponto são formatados?**

A formatação explícita do ponto de dados tem precedência para esse ponto. Os demais pontos continuam usando a formatação explícita da série ou, quando a formatação da série não está definida, o estilo e tema automáticos do gráfico. Propriedades de grupo como sobreposição e largura do intervalo controlam o layout e não são sobrescritas por formatação ao nível do ponto.

**Existe um limite para a quantidade de séries que um gráfico pode conter?**

Aspose.Slides não impõe um limite fixo separado para a contagem de séries. Na prática, as restrições do arquivo de apresentação, a memória disponível, o tempo de renderização e a legibilidade do gráfico determinam um limite útil.

**O que devo ajustar quando as colunas estão muito próximas ou muito afastadas?**

Defina [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) no grupo de séries pai apropriado. Aumente o valor para ampliar o espaço entre os clusters ou diminua‑o para aproximar os clusters.