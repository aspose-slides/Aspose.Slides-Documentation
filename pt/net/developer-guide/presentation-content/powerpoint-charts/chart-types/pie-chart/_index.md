---
title: Personalizar gráficos de pizza em apresentações no .NET
linktitle: Gráfico de pizza
type: docs
url: /pt/net/pie-chart/
keywords:
- gráfico de pizza
- gerenciar gráfico
- personalizar gráfico
- opções de gráfico
- configurações de gráfico
- opções de trama
- cor da fatia
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie e personalize gráficos de pizza no .NET com Aspose.Slides. Configure tramas secundárias, exiba rótulos de dados e aplique cores automáticas nas fatias no PowerPoint."
---
## **Visão geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de trama secundária para gráficos Pie of Pie e Bar of Pie e como habilitar a coloração automática das fatias para um gráfico de pizza padrão.

Os exemplos concentram‑se em tarefas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar configurações de séries e rótulos, substituir os dados padrão do gráfico por categorias e valores personalizados e salvar a apresentação atualizada.

## **Opções de Trama Secundária para Gráficos Pie of Pie e Bar of Pie**

O Aspose.Slides for .NET oferece suporte a opções de trama secundária para gráficos Pie of Pie e Bar of Pie. Essas opções controlam o tamanho da trama secundária e como os pontos de dados são divididos entre as duas tramas.

O exemplo a seguir cria um gráfico Pie of Pie em uma nova apresentação e exibe os valores dos pontos de dados como rótulos. A propriedade [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) define o tamanho da trama secundária para 149 % da trama principal. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) seleciona a divisão baseada em porcentagem e [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) define o limiar para 53 %.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Selecionar Categorias para a Trama Secundária**

Use divisão personalizada quando quiser agrupar categorias específicas na trama secundária independentemente de seus valores percentuais. Por exemplo, um relatório de vendas pode mostrar Online e Events juntos para que os leitores comparem esses dois canais, mesmo que representem 35 % e 10 % das vendas totais.

Defina [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) como [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) e selecione os pontos através de [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). O método [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) da coleção aceita um índice baseado em zero na série ou um objeto de ponto de dados. Neste exemplo, o índice 1 seleciona Online e o ponto no índice 3 seleciona Events. Partners também é adicionado temporariamente, depois excluído usando [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Substitua os dados padrão por vendas por canal.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Selecione Online pelo seu índice baseado em zero e Events pelo seu objeto de ponto de dados.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Exclua Partners da seleção sem excluir seus dados de origem.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) e Events (10) aparecem como fatias distintas na trama secundária. Na trama principal, eles são representados por uma única fatia combinada com valor 45, ao lado de Retail (40) e Partners (15). Remover Partners da seleção personalizada mantém‑o na trama principal; não remove a categoria nem seu valor dos dados de origem do gráfico.

A imagem a seguir mostra a apresentação salva no PowerPoint:

![Gráfico Pie of Pie com Online e Events na trama secundária e seu valor combinado de 45 na trama principal](pie_of_pie_custom.png)

## **Definir Cores Automáticas das Fatias do Gráfico de Pizza**

O Aspose.Slides for .NET pode atribuir automaticamente cores diferentes às fatias do gráfico de pizza. O exemplo a seguir cria um gráfico de pizza com um título centralizado e substitui os dados padrão por três categorias trimestrais e seus valores. A propriedade [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) exibe os valores 20, 50 e 30 como rótulos, enquanto [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) habilita uma cor distinta para cada fatia.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Adicione um título de gráfico centralizado.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Substitua os dados padrão usando a primeira planilha.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Exiba valores e atribua cores diferentes às fatias.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **FAQ**

**As variações Pie of Pie e Bar of Pie são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) uma trama secundária para gráficos de pizza, incluindo os tipos Pie of Pie e Bar of Pie.

**Posso exportar apenas o gráfico como imagem (por exemplo, PNG)?**

Sim, você pode [exportar o próprio gráfico como imagem](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (como PNG) sem exportar a apresentação inteira.