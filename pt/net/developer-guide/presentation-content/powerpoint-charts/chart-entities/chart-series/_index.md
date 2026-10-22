---
title: Gerenciar séries de dados de gráfico em apresentações no .NET
linktitle: Séries de dados
type: docs
url: /pt/net/chart-series/
keywords:
- série de gráfico
- sobreposição de séries
- cor da série
- cor da categoria
- nome da série
- ponto de dados
- espaçamento da série
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a gerenciar séries de gráficos, pontos de dados, células de pasta de trabalho, formatação, sobreposição, largura do intervalo e valores negativos em apresentações com C#."
---
## **Visão geral**

Um gráfico pode armazenar seus valores plotados em células da pasta de trabalho ou diretamente como literais numéricos. Um [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) representa um conjunto de valores relacionados, e cada [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) representa um ponto nessa série. Objetos [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) fornecem os rótulos ou valores de agrupamento compartilhados pelas séries. Em gráficos criados com dados padrão, nomes de séries, categorias e valores de pontos usam objetos [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) da pasta de trabalho do gráfico.

Para um gráfico de categoria típico, a pasta de trabalho padrão usa a linha 0 para nomes de séries, a coluna 0 para nomes de categorias e as demais células para valores das séries. Os índices de planilha, linha e coluna passados para [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) são baseados em zero. Esse layout é útil ao criar um gráfico com dados padrão, mas não suponha que todo gráfico existente o utilize. Para uma apresentação carregada, inspecione as células referenciadas pelas séries, categorias e pontos de dados antes de alterar os valores da pasta de trabalho.

- Configurações ao nível da série, como [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), fornecem a aparência padrão para todos os pontos de uma série.  
- Configurações de ponto de dados, como [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), substituem a aparência da série para um ponto.  
- Configurações de grupo aplicam‑se a séries compatíveis que pertencem ao mesmo [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/). Acesse o grupo através de [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) quando precisar definir opções como sobreposição ou largura do intervalo.

Quando não há preenchimento explícito de ponto ou série definido, o estilo e o tema do gráfico determinam a aparência automática. Quando há formatação tanto da série quanto do ponto, a formatação do ponto tem precedência para esse ponto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Definir valores da série usando literais numéricos**

Use literais numéricos quando os valores da série provêm de dados ou cálculos da aplicação e não necessitam de referências a células da planilha. Defina [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) para [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) antes de atribuir o [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) de cada ponto via [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/).

A configuração da coleção controla o tipo de origem de todos os valores dos pontos nessa série. O [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) de cada ponto indica o tipo selecionado; altere‑o através da configuração da coleção. Com `Worksheet`, use [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) para acessar a célula referenciada. Com `DoubleLiterals`, use `AsLiteralDouble` para ler ou gravar o número diretamente.

O exemplo a seguir cria um gráfico de colunas com séries e categorias padrão, depois atribui valores calculados de 10, 20 e assim por diante aos pontos existentes da sua primeira série. Ele salva a apresentação, reabre‑a e imprime os valores armazenados.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

O tipo de origem do valor do ponto é separado de [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/), que identifica a configuração da pasta de trabalho interna ou externa do gráfico. Usar literais numéricos não remove, por si só, a pasta de trabalho incorporada. Neste exemplo, a pasta de trabalho continua disponível para rótulos de categoria, nomes de séries e as outras séries. Consulte [Chart Workbook](/slides/pt/net/chart-workbook/) para gerenciamento da pasta de trabalho.

Para gráficos de dispersão e bolha, defina [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) e [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) para escolher as origens de [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) e [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Gráficos de bolha também usam [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) para [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). Defina cada origem aplicável para `DoubleLiterals` antes de atribuir números através da propriedade `AsLiteralDouble` desse valor.

## **Definir a sobreposição da série do gráfico**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) indica o quanto barras ou colunas se sobrepõem em um gráfico 2D, de -100 a 100 por cento. É uma projeção somente leitura da configuração no grupo de séries pai. Defina [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) para atualizar todas as séries compatíveis nesse grupo. Esta opção se aplica a tipos de gráfico que exibem barras ou colunas agrupadas; não afeta grupos de séries não relacionados em um gráfico combinado.

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

// O novo gráfico contém séries de exemplo, categorias e valores.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

O resultado:

![A sobreposição da série](series_overlap.png)

## **Alterar a cor de preenchimento da série**

Use [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) para definir o preenchimento padrão de toda a série. Se um ponto já possui um preenchimento explícito, sua configuração [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) substitui o preenchimento da série para esse ponto.

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

![A cor da série](series_color.png)

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

Você também pode atualizar a célula já referenciada por [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/). Essa abordagem evita assumir uma linha e coluna específicas em um gráfico existente:

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

![O nome da série](series_name.png)

### **Criar uma série com nome a partir de várias células**

Um nome de série composto é útil quando o nome de um produto e o período de relatório são armazenados em células distintas da pasta de trabalho. Por exemplo, você pode combinar `Product A` em B1 e `2026` em C1 em um único nome de série mantendo ambas as partes vinculadas às suas células de origem.

Use [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) para recuperar o intervalo de nomes, depois passe essa coleção para [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). O argumento `skipHiddenCells` controla se células ocultas são incluídas: `true` as exclui, enquanto `false` as inclui. Este exemplo usa `false` para incluir todas as células no intervalo de nomes.

O exemplo a seguir cria uma apresentação com uma série e dois pontos de dados. As células B1:C1 fornecem apenas o nome da série; A2:A3 fornecem os rótulos de categoria, e B2:B3 fornecem os valores numéricos.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Essas duas células fornecem o nome da série.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Células separadas fornecem as categorias e os pontos de dados numéricos.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

O nome da série resultante é `Product A 2026`, com um espaço entre os dois valores das células. A legenda exibe isso como uma única entrada para ambas as colunas. A imagem abaixo foi renderizada a partir da apresentação salva:

![Gráfico de colunas com valores Norte e Sul e o nome de série composto Product A 2026 na legenda](composite_series_name.png)

## **Obter a cor automática de preenchimento da série**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) devolve a cor calculada a partir do índice da série e do estilo do gráfico. Esta é a cor usada quando o preenchimento da série não foi definido explicitamente. Chamar o método lê a cor calculada; não atribui um novo preenchimento.

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

## **Definir cor de preenchimento invertida para uma série de gráfico**

Para séries de barras, colunas e bolhas, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) pode exibir valores negativos com um preenchimento diferente. Defina o preenchimento regular da série como sólido, habilite a inversão e atribua a cor para valores negativos através de [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Números negativos permanecem inalterados na pasta de trabalho; apenas a cor de exibição muda.

O exemplo a seguir substitui os dados de gráfico padrão por uma única série. A linha 0 da planilha contém o nome da série, a coluna 0 contém os nomes de categoria e a coluna 1 contém os valores:

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

![A cor de preenchimento sólido invertida](inverted_solid_fill_color.png)

Você pode habilitar a inversão para um ponto através de [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). No exemplo a seguir, a inversão está desativada para a série e ativada apenas para o ponto selecionado. O ponto também recebe um valor negativo para que o efeito seja visível:

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

Para tornar um ponto vazio sem remover os demais pontos, defina sua célula de apoio na pasta de trabalho como `null`. Para um gráfico de colunas, o valor plotado está disponível através de [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). O ponto de dados permanece na mesma posição de categoria, mas o gráfico trata seu valor como vazio de acordo com as configurações de valor em branco do gráfico.

O exemplo a seguir limpa apenas o segundo ponto na primeira série:

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

Gráficos de dispersão usam células X e Y separadas, e gráficos de bolha também usam uma célula de tamanho. Limpe apenas a célula que representa o valor que deseja remover. Não chame [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) quando quiser manter os outros pontos, porque esse método remove todos os pontos de dados da coleção.

## **Controlar a exibição de células vazias**

Células ocultas que contêm valores são um caso separado das células vazias. Para incluir ou excluir dados de linhas e colunas ocultas da planilha, veja [Include Data from Hidden Rows and Columns](/slides/pt/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Uma célula vazia da pasta de trabalho representa dados ausentes; uma célula contendo `0` representa um valor numérico conhecido. Defina [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) para `null` a fim de tornar a célula vazia. Um zero numérico continua sendo zero independentemente da configuração de célula em branco.

Use [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) para escolher como o gráfico exibe células vazias. Essa configuração aplica‑se a todo o gráfico. Ela altera como os vazios são plotados, sem preencher a célula vazia da pasta de trabalho com zero ou valor interpolado.

O exemplo autônomo a seguir cria um gráfico de linhas com uma série, limpa o valor do Dia 3 e salva o mesmo gráfico em cada modo. Nenhum arquivo de entrada é necessário. O [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) usa a planilha 0, coluna 0 para rótulos de categoria e coluna 1 para valores; a linha 0 contém o nome da série. Os dados finais são `10, 20, empty, 30, 40`.

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

A comparação abaixo mostra os mesmos dados em todos os três arquivos. O Dia 3 está vazio na pasta de trabalho em todos os casos:

![Gráficos de linha com dados idênticos: Gap interrompe a linha no Dia 3, Zero reduz a linha a zero, e Span conecta o Dia 2 ao Dia 4.](display_blanks_as.png)

O efeito visível depende do tipo de gráfico. Um gráfico de linha facilita a comparação dos três modos. Gráficos de barras e colunas não têm linha para conectar uma categoria ausente, portanto `Span` não pode produzir o segmento de conexão exibido acima; uma coluna ausente e uma coluna com altura zero podem parecer semelhantes. Da mesma forma, um gráfico de dispersão apenas com marcadores não tem linha de conexão. Não espere três resultados distintos para todos os tipos de gráfico; verifique a saída para o tipo que você usa.

## **Definir a largura do intervalo da série**

A largura do intervalo é o espaço entre clusters adjacentes de barras ou colunas, expressa como porcentagem da largura da barra ou coluna. Como a sobreposição, ela pertence ao grupo de séries pai e não a uma única série. Defina [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) uma vez para o grupo. Um valor maior cria mais espaço entre clusters; um valor menor os torna mais densos.

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

![A largura do intervalo](gap_width.png)

## **Perguntas frequentes**

**Quais tipos de gráfico suportam séries de dados?**

Todos os tipos de gráfico representados pela enumeração [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) utilizam dados de gráfico, mas suas séries não compartilham a mesma estrutura de valores ou configurações. Por exemplo, gráficos de categoria usam categorias e valores, gráficos de dispersão usam valores X e Y, e gráficos de bolha adicionam tamanhos de bolha. Use o método de criação de ponto de dados que corresponde ao tipo de série. Opções como sobreposição e largura do intervalo aplicam‑se apenas a grupos de barras ou colunas compatíveis.

**O que é um grupo de séries de gráfico?**

Um [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) contém séries compatíveis que compartilham configurações de plotagem ao nível do grupo. Um gráfico combinado pode conter mais de um grupo, de modo que mudar o grupo acessado por uma série não altera necessariamente todas as séries do gráfico.

**Um gráfico recém‑criado contém dados padrão?**

Sim. Por padrão, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) cria séries, categorias e valores de amostra. Você pode editar essas células ou limpar as coleções de séries e categorias antes de adicionar um conjunto de dados totalmente personalizado. Uma sobrecarga também pode criar um gráfico sem dados padrão.

**Como os objetos de gráfico estão conectados às células da pasta de trabalho?**

Nomes de séries, rótulos de categoria e valores de pontos de dados referenciam células em um [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Alterar uma célula referenciada atualiza o elemento correspondente no gráfico. Ao criar dados personalizados, mantenha as linhas de categoria e as linhas de valores das séries alinhadas para que cada ponto seja plotado sob a categoria pretendida.

**Como limpo um ponto em vez de toda a série?**

Defina a célula de valor relevante como `null` para manter a posição de categoria do ponto como vazio. Use [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) somente quando desejar remover todos os pontos daquela série. Se também remover categorias, atualize cada série para que seus valores permaneçam alinhados com a coleção de categorias.

**Como os pontos vazios são exibidos?**

O resultado depende do tipo de gráfico e de [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Gráficos suportados podem exibir vazios como lacunas, como valores zero ou conectando pontos vizinhos. Escolha a configuração que corresponda ao significado dos dados ausentes em sua apresentação. Veja [Controlar a exibição de células vazias](#controlar-a-exibição-de-células-vazias) para um exemplo completo e comparação visual.

**Como os valores negativos são formatados?**

Para séries de barras, colunas e bolhas suportadas, habilite [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) e defina [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Você pode sobrescrever o comportamento para um ponto individual com [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Essas propriedades afetam a formatação, não os valores numéricos armazenados.

**Qual formatação prevalece quando tanto a série quanto o ponto são formatados?**

A formatação explícita do ponto de dados tem precedência para esse ponto. Os demais pontos continuam usando a formatação explícita da série ou, quando a formatação da série não está definida, o estilo e tema automáticos do gráfico. Propriedades de grupo como sobreposição e largura do intervalo controlam o layout e não sobrescrevem formatações de ponto.

**Existe um limite para a quantidade de séries que um gráfico pode conter?**

Aspose.Slides não impõe um limite fixo separado para séries. Na prática, restrições do arquivo de apresentação, memória disponível, tempo de renderização e legibilidade do gráfico determinam um limite útil.

**O que devo alterar quando as colunas estão muito próximas ou muito afastadas?**

Defina [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) no grupo de séries pai apropriado. Aumente o valor para ampliar o espaço entre clusters ou diminua‑o para aproximar os clusters.