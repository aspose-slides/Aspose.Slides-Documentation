---
title: Adicionar linhas de tendência a gráficos de apresentação em .NET
linktitle: Linha de tendência
type: docs
url: /pt/net/trend-line/
keywords:
- gráfico
- linha de tendência
- linha de tendência exponencial
- linha de tendência linear
- linha de tendência logarítmica
- linha de tendência de média móvel
- linha de tendência polinomial
- linha de tendência de potência
- linha de tendência personalizada
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Adicione e personalize rapidamente linhas de tendência em gráficos do PowerPoint com Aspose.Slides para .NET — um guia prático para envolver seu público."
---
## **Visão geral**

Este artigo explica como adicionar linhas de tendência a gráficos de apresentação usando Aspose.Slides. Ele mostra como criar um gráfico, adicionar linhas de tendência às séries do gráfico e trabalhar com vários tipos de linhas de tendência, incluindo exponencial, linear, logarítmica, média móvel, polinomial e potência.

Também descreve como adicionar uma linha personalizada a um gráfico inserindo uma forma de linha e inclui um breve FAQ sobre os valores de projeção da linha de tendência para frente e para trás e se as linhas de tendência são preservadas durante a exportação para PDF ou SVG e ao renderizar gráficos como imagens.

## **Adicionar uma linha de tendência**

Use [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) para adicionar uma linha de tendência a uma série de gráfico, selecionando seu tipo com [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). O exemplo cria um gráfico de colunas agrupadas com dados padrão e adiciona duas linhas de tendência a cada uma de suas três séries.

A linha de tendência exponencial oculta sua equação e o valor de R‑quadrado através de [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) e [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), enquanto a linha de tendência linear é vermelha. A linha de tendência logarítmica usa [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) para um rótulo personalizado. A média móvel usa um [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) de três pontos de dados e um [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/) personalizado.

A linha de tendência polinomial tem um [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) de três e se estende uma categoria para a frente através de [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). A linha de tendência de potência se estende uma categoria para trás através de [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **Definir a interceptação da linha de tendência**

Use [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) para fixar o valor Y da linha de tendência em X = 0. Essa configuração é suportada para linhas de tendência linear, exponencial e polinomial.

Por exemplo, um modelo de custo de produção pode precisar começar com custos fixos conhecidos de 100, mesmo quando medições em volumes de produção diferentes de zero sugerem uma base distinta. Para uma linha de tendência linear, fixar a interceptação restringe a equação `y = ax + b` para `b = 100`; a inclinação é ajustada aos dados sob essa restrição. Não move simplesmente uma linha já ajustada. As configurações de cruzamento dos eixos controlam onde os eixos do gráfico se encontram, não os coeficientes da linha de tendência ajustada.

O exemplo a seguir cria um gráfico de dispersão (XY) com volumes de produção de 1 a 4 e custos de 170, 200, 230 e 260. Ele salva o gráfico com a interceptação automática padrão, define a interceptação para 100 e salva um segundo PPTX. Os dois arquivos diferem apenas na configuração da interceptação. A linha de tendência exibe sua equação e se estende de volta a X = 0.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

Com cálculo automático, esses dados produzem `y = 30x + 140`. Definir a interceptação para 100 produz aproximadamente `y = 43.33x + 100`: o valor ajustado em zero coincide com a base conhecida, enquanto a linha deixa de passar por todos os pontos de dados.

| Interceptação automática | Interceptação fixa de 100 |
| --- | --- |
| ![Linha de tendência linear com interceptação calculada automaticamente de 140](intercept-automatic.png) | ![Linha de tendência linear com interceptação fixa de 100](intercept-fixed.png) |

Ambas as imagens usam os mesmos dados e escalas dos eixos. As linhas de tendência são estendidas de volta a X = 0 para mostrar suas interceptações.

Por padrão, a propriedade contém `double.NaN`, que representa uma interceptação não especificada em vez de zero. A interceptação é então calculada automaticamente a partir dos dados.

## **Adicionar uma linha personalizada**

Uma linha personalizada é uma forma desenhada sobre o gráfico, e não uma linha de tendência calculada a partir dos dados da série. Este exemplo usa [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) para adicionar uma linha horizontal ao slide sobre o gráfico. A posição da linha é especificada em coordenadas do slide, medidas em pontos, de modo que ela começa na borda esquerda do gráfico e fica a meio caminho da altura do gráfico. Sua largura corresponde à largura do gráfico. O [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) dá à linha uma cor sólida vermelha.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **Perguntas frequentes**

**O que significam 'forward' e 'backward' para uma linha de tendência?**

São os comprimentos da linha de tendência projetados para frente/para trás: para gráficos de dispersão (XY) — em unidades dos eixos; para gráficos que não são de dispersão — em número de categorias. Apenas valores não negativos são permitidos.

**A linha de tendência será preservada ao exportar a apresentação para PDF ou SVG, ou ao renderizar um slide como imagem?**

Sim. Aspose.Slides converte apresentações para [PDF](/slides/pt/net/convert-powerpoint-to-pdf/) ou [SVG](/slides/pt/net/render-a-slide-as-an-svg-image/) e renderiza gráficos como imagens; as linhas de tendência, como parte do gráfico, são preservadas durante essas operações. Um método também está disponível para [exportar uma imagem do próprio gráfico](/slides/pt/net/create-shape-thumbnails/).