---
title: Personalizar eixos de gráficos em apresentações em .NET
linktitle: Eixo de Gráfico
type: docs
url: /pt/net/chart-axis/
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
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra como usar Aspose.Slides para .NET para personalizar eixos de gráficos em apresentações PowerPoint para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar os eixos de gráficos com Aspose.Slides para .NET. Ele abrange valores de eixo calculados, troca de linhas e colunas do gráfico, visibilidade do eixo, intervalos de rótulo de categoria e marcações, categorias de data e formatação, rotação do título, posicionamento do eixo, unidades de exibição e dimensionamento logarítmico.

## **Obter os valores máximos no eixo vertical dos gráficos**

Crie uma [Apresentação](https://reference.aspose.com/slides/net/aspose.slides/presentation/) e adicione um gráfico de área com dados padrão. Chame [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) antes de ler os valores de eixo calculados para que o layout do gráfico esteja atualizado.

Leia [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) e [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) para os limites do eixo, e [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) e [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) para os intervalos de marcação. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) e [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) fornecem escalas de unidades de tempo, que são relevantes para eixos de data. O exemplo armazena esses valores em variáveis locais e salva o gráfico.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **Trocar os dados entre eixos**

Use [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) para trocar as funções de séries e categorias nos dados do gráfico. Cada categoria anterior se torna uma série, e cada série anterior se torna uma categoria. Isso altera como os dados são agrupados; não troca os eixos horizontal e vertical. O exemplo usa [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) para vincular os dados padrão a `Sheet1!A1:D5`, incluindo a linha de cabeçalho e a coluna de categoria, antes de trocar linhas e colunas. Ele salva um gráfico com quatro séries e três categorias.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **Reverter a ordem de plotagem de um eixo**

Use [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) para reverter um eixo de categoria ou de valor. Por exemplo, um gráfico de barras horizontal pode mostrar as fases do projeto de cima para baixo na mesma ordem da planilha: Planejamento, Desenvolvimento, Teste. Reverter um eixo altera a direção da plotagem; não classifica nem reorganiza os dados da pasta de trabalho. Em comparação, [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) troca as funções de séries e categorias.

O exemplo a seguir cria um gráfico de barras horizontal com três fases e uma série. Ele salva uma apresentação com três slides: ordem normal, categorias revertidas e valores revertidos. Cada cópia usa o mesmo conjunto de dados, e apenas um eixo é revertido em cada cópia.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Slide 2: exibir a primeira categoria no topo.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Manter o eixo de valores horizontal na parte inferior.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Slide 3: reverter apenas a escala numérica horizontal.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Reverter um eixo também pode mover o eixo perpendicular para o lado oposto da trama. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) controla onde o outro eixo cruza o eixo que está sendo configurado. No slide 2, defini‑lo como `Maximum` no eixo de categoria revertido mantém o eixo de valor horizontal na parte inferior. Para um ponto de cruzamento específico, use [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Verifique as configurações de cruzamento ao mudar a direção, especialmente se o gráfico já possui um ponto de cruzamento personalizado. Defina `IsPlotOrderReversed` de volta para `false` para restaurar a direção normal de plotagem; as configurações de cruzamento são independentes.

| Ordem normal (slide 1) | Categorias revertidas (slide 2) | Valores revertidos (slide 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| As categorias vão de baixo para cima; os valores aumentam da esquerda para a direita. | Planejamento, Desenvolvimento e Teste vão de cima para baixo. Os valores e a ordem das linhas da pasta de trabalho permanecem inalterados. | As categorias mantêm sua ordem normal; os valores aumentam da direita para a esquerda. O eixo de categoria cruza em zero à direita. |

## **Desativar o eixo vertical para gráficos de linha**

Defina [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) como `false` no eixo vertical para ocultá‑lo. O exemplo cria um gráfico de linha com dados padrão e o salva com o eixo vertical oculto.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **Desativar o eixo horizontal para gráficos de linha**

Defina [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) como `false` no eixo horizontal para ocultá‑lo. O exemplo cria um gráfico de linha com dados padrão e o salva com o eixo horizontal oculto.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **Alterar um eixo de categoria**

Defina [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) para escolher um eixo de categoria de data ou texto. Este exemplo requer `ExistingChart.pptx`, com um gráfico como o primeiro objeto no primeiro slide e células de categoria contendo valores de data numéricos do Excel. Ele altera o eixo horizontal para um eixo de data. Definindo [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) como `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) como `1` e [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) como meses, posiciona as marcas maiores em intervalos de um mês.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **Controlar intervalos de rótulo do eixo de categoria**

Quando um gráfico tem muitas categorias, reduza o número de rótulos de eixo visíveis sem remover categorias ou pontos de dados. Defina [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) como `false` e, em seguida, defina [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) para o intervalo de categoria desejado. Para categorias de texto na ordem normal, a contagem começa na primeira categoria:

| Intervalo | Rótulos exibidos no exemplo |
| --- | --- |
| `1` | Categoria 1, Categoria 2, Categoria 3, … Categoria 24 |
| `2` | Categoria 1, Categoria 3, Categoria 5, … Categoria 23 |
| `3` | Categoria 1, Categoria 4, Categoria 7, … Categoria 22 |

Um intervalo de `3` exibe a cada terceiro rótulo, deixando dois rótulos ocultos entre os exibidos. Não remove as colunas correspondentes. O espaçamento automático escolhe um intervalo com base no espaço disponível; não exibe necessariamente todos os rótulos.

As marcas de escala têm controles separados. Defina [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) como `false` e use [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) para definir seu intervalo. Por exemplo, `1` mantém uma marca de escala a cada intervalo de categoria enquanto os rótulos aparecem apenas a cada terceira categoria. Defina [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) para um estilo visível para que você possa ver o resultado. Definir qualquer propriedade de espaçamento automático de volta para `true` permite que o gráfico escolha novamente esse intervalo.

O exemplo autônomo a seguir cria 24 categorias e uma série, então salva três slides em `CategoryAxisIntervals.pptx`: espaçamento automático, espaçamento manual de rótulos com marcas de escala independentes e espaçamento automático restaurado. As duas cópias mantêm os dados originais do gráfico. Não é necessária uma apresentação de entrada. O texto do rótulo horizontal facilita a visualização da densidade.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Slide 2: mostrar cada terceiro rótulo, mas manter uma marca de escala para cada categoria.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Slide 3: deixar o gráfico escolher ambos os intervalos novamente.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Espaçamento automático (slide 1):** Nesta renderização, cada segundo rótulo de categoria é exibido e quebra em duas linhas. O resultado automático pode variar com o tamanho do gráfico, fontes e renderizador.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Espaçamento manual (slide 2):** Cada terceiro rótulo é exibido em uma linha, enquanto as marcas de escala permanecem a cada intervalo de categoria. Todas as 24 colunas, inclusive as sem rótulos, permanecem visíveis com os mesmos valores. O slide 3 restaura a aparência automática mostrada acima.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Escolher o eixo e o intervalo corretos**

Use este intervalo de contagem de categorias para um eixo de categoria de texto, como o eixo de categoria de um gráfico de colunas, linhas, áreas ou barras. Em um gráfico de colunas, ele é o eixo horizontal. Em um gráfico de barras horizontal, o eixo de categoria é vertical, portanto aplique estas configurações a [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). O espaçamento de marcações também se aplica a um eixo de série em gráficos que o possuam.

Não use o espaçamento de rótulo de categoria para definir a escala numérica de um eixo de valor. Em um eixo de valor, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) especifica uma diferença em valores: por exemplo, uma unidade maior de `10` produz marcas em 0, 10, 20 etc., quando o eixo começa em zero. Um intervalo de rótulo de categoria de `3` conta posições de categoria, independentemente dos valores dos dados. Gráficos de dispersão e de bolhas usam eixos de valor em vez de um eixo de categoria de texto. Para um eixo de data, use unidades e escalas de tempo maiores conforme descrito em [Alterar um eixo de categoria](#alterar-um-eixo-de-categoria).

## **Definir o formato de data para valores do eixo de categoria**

O exemplo substitui os dados padrão do gráfico por quatro valores anuais. As datas são armazenadas como números de série OLE Automation na primeira planilha (índice `0`). Defina [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) para um eixo de data, desative [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) e atribua `yyyy` a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) para que os rótulos de categoria exibam anos de quatro dígitos independentemente da formatação da célula.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **Definir um ângulo de rotação para o título do eixo do gráfico**

Habilite [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) no eixo vertical, forneça o texto do título e defina [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) para girar o título. O ângulo é medido em graus; este exemplo salva um gráfico de colunas com o título do eixo de valores girado em 90 graus.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **Definir a posição do eixo em um eixo de categoria ou de valor**

Use [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) para controlar se o eixo de valor cruza o eixo de categoria entre categorias ou em marcas de categoria. Esta propriedade se aplica a eixos de categoria. O exemplo define isso como `true` no eixo de categoria horizontal de um gráfico de colunas e salva o resultado.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **Definir a unidade de exibição em um eixo de valor do gráfico**

Defina [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) para dimensionar os rótulos em um eixo de valor sem alterar os dados subjacentes. Com [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) definido como `Millions`, um valor de 60 000 000 é exibido como 60. O exemplo cria um gráfico de colunas e aplica a unidade de exibição em milhões ao seu eixo vertical.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **Configurar um eixo de valor logarítmico**

Um eixo de valor logarítmico é útil quando valores positivos abrangem várias ordens de magnitude. Por exemplo, um serviço pode receber 10, 100, 1 000, 10 000 e 100 000 solicitações ao longo de cinco períodos. Em uma escala linear, os valores menores aparecem agrupados perto de zero. Uma escala logarítmica facilita a comparação do crescimento relativo: distâncias iguais representam proporções iguais, não diferenças iguais.

Defina [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) como `true` no eixo de valor e use [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) para escolher a base. Isso altera a forma como os valores existentes são exibidos; não modifica os dados nem adiciona uma linha de tendência logarítmica. Uma linha de tendência representa um relacionamento ajustado nos dados e é um recurso separado.

### **Escolher o eixo de valor e a base**

Para um gráfico de linhas ou colunas, o eixo de valor é [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Para um gráfico de barras horizontal, ele é [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Gráficos de dispersão e bolhas têm dois eixos de valor, portanto escolha o eixo horizontal para valores X, o eixo vertical para valores Y ou ambos. Não aplique escala logarítmica a um eixo de categoria.

A base logarítmica padrão é `10`. Para gráficos PPTX, use uma base de `2` a `1000`, inclusive; bases fracionárias como `2,5` também são suportadas. Com a base `10`, potências sucessivas como 10, 100, 1 000 e 10 000 são igualmente espaçadas. 

### **Comparar dimensionamento linear e logarítmico**

O exemplo autônomo a seguir cria um gráfico de linhas com as cinco contagens de solicitações no primeiro slide, então duplica esse slide e habilita um eixo de valor logarítmico base 10 no segundo. Ambos os slides mantêm os mesmos dados.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Manter o primeiro slide linear e alterar apenas a escala do eixo de valores da cópia.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Escala linear (slide 1):** Distâncias verticais iguais representam diferenças iguais nas contagens de solicitações. O maior valor domina o gráfico, dificultando a distinção dos valores menores.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Escala logarítmica (slide 2):** Distâncias verticais iguais representam razões iguais. Cada período tem dez vezes mais solicitações que o anterior, de modo que os pontos formam uma linha reta ascendente na escala base 10. Os rótulos do eixo ainda mostram as contagens originais.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Tratar valores zero e negativos**

Uma escala logarítmica pode exibir apenas valores estritamente positivos. Verifique os dados antes de habilitá‑la. Se valores zero ou negativos forem significativos, mantenha uma escala linear ou mostre‑os separadamente. Se a exclusão desses valores for apropriada para a análise, explique a omissão. Não os substitua silenciosamente por números positivos pequenos, pois isso altera o significado dos dados. Qualquer mínimo ou máximo configurado manualmente para um eixo logarítmico também deve ser positivo.

## **FAQ**

**Como definir o valor no qual um eixo cruza o outro (cruzamento de eixo)?**

Use [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) para selecionar o comportamento de cruzamento. Para especificar um valor de cruzamento numérico, defina [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Essas configurações permitem mover o cruzamento do eixo para uma linha de base adequada.

**Como posicionar os rótulos das marcas em relação ao eixo?**

Defina [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) usando [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` ou `None`. Para controlar as próprias marcas de escala, use [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) ou [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); estes são independentes do posicionamento dos rótulos.