---
title: Adicionar Linhas de Tendência a Gráficos de Apresentação em .NET
linktitle: Linha de Tendência
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
## **Visão Geral**

Este artigo explica como adicionar linhas de tendência a gráficos de apresentação usando Aspose.Slides. Ele mostra como criar um gráfico, adicionar linhas de tendência às séries do gráfico e trabalhar com vários tipos de linhas de tendência, incluindo exponencial, linear, logarítmica, média móvel, polinomial e potência.

Ele também descreve como adicionar uma linha personalizada a um gráfico inserindo uma forma de linha e inclui um pequeno FAQ sobre os valores de projeção da linha de tendência para frente e para trás e se as linhas de tendência são preservadas durante a exportação para PDF ou SVG e ao renderizar gráficos como imagens.

## **Adicionar uma Linha de Tendência**
Aspose.Slides for .NET fornece uma API simples para gerenciar diferentes Linhas de Tendência de gráficos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão e o tipo desejado (este exemplo usa ChartType.ClusteredColumn).
1. Adicionando linha de tendência exponencial para a série 1 do gráfico.
1. Adicionando linha de tendência linear para a série 1 do gráfico.
1. Adicionando linha de tendência logarítmica para a série 2 do gráfico.
1. Adicionando linha de tendência de média móvel para a série 2 do gráfico.
1. Adicionando linha de tendência polinomial para a série 3 do gráfico.
1. Adicionando linha de tendência de potência para a série 3 do gráfico.
1. Grave a apresentação modificada em um arquivo PPTX.

O código a seguir é usado para criar um gráfico com Linhas de Tendência.

```c#
// Criando apresentação vazia
Presentation pres = new Presentation();

// Criando um gráfico de colunas agrupadas
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Adicionando linha de tendência exponencial para a série 1 do gráfico
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Adicionando linha de tendência linear para a série 1 do gráfico
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Adicionando linha de tendência logarítmica para a série 2 do gráfico
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Adicionando linha de tendência de média móvel para a série 2 do gráfico
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Adicionando linha de tendência polinomial para a série 3 do gráfico
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Adicionando linha de tendência de potência para a série 3 do gráfico
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Salvando apresentação
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **Adicionar uma Linha Personalizada**
Aspose.Slides for .NET fornece uma API simples para adicionar linhas personalizadas em um gráfico. Para adicionar uma linha simples a um slide selecionado da apresentação, siga os passos abaixo:

- Crie uma instância da classe Presentation
- Obtenha a referência de um slide usando seu Índice
- Crie um novo gráfico usando o método AddChart exposto pelo objeto Shapes
- Adicione uma AutoShape do tipo Linha usando o método AddAutoShape exposto pelo objeto Shapes
- Defina a Cor das linhas da forma.
- Grave a apresentação modificada como um arquivo PPTX

O código a seguir é usado para criar um gráfico com Linhas Personalizadas.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**O que significam 'forward' e 'backward' para uma linha de tendência?**

São os comprimentos da linha de tendência projetados para frente/para trás: para gráficos de dispersão (XY) — em unidades dos eixos; para gráficos que não são de dispersão — em número de categorias. Apenas valores não negativos são permitidos.

**A linha de tendência será preservada ao exportar a apresentação para PDF ou SVG, ou ao renderizar um slide como imagem?**

Sim. O Aspose.Slides converte apresentações para [PDF](/slides/pt/net/convert-powerpoint-to-pdf/)/[SVG](/slides/pt/net/render-a-slide-as-an-svg-image/) e renderiza gráficos como imagens; as linhas de tendência, como parte do gráfico, são preservadas durante essas operações. Também há um método disponível para [exportar uma imagem do gráfico](/slides/pt/net/create-shape-thumbnails/) em si.