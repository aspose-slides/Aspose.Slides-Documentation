---
title: Personalizar Gráficos de Bolhas em Apresentações no .NET
linktitle: Gráfico de Bolhas
type: docs
url: /pt/net/bubble-chart/
keywords:
- gráfico de bolhas
- tamanho da bolha
- dimensionamento de tamanho
- representação de tamanho
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie e personalize gráficos de bolhas poderosos no PowerPoint com Aspose.Slides para .NET e melhore sua visualização de dados facilmente."
---
## **Visão geral**

Este artigo mostra como trabalhar com gráficos de bolhas no Aspose.Slides. Ele cobre duas opções específicas de personalização: dimensionar o tamanho das bolhas através da propriedade `BubbleSizeScale` e controlar como os valores de tamanho das bolhas são representados através da propriedade `BubbleSizeRepresentation`.

Os exemplos demonstram como criar um gráfico de bolhas, ajustar o dimensionamento de tamanho e alternar a representação do tamanho das bolhas para usar a largura. O artigo também inclui uma breve seção de FAQ que esclarece o suporte ao tipo de gráfico “Bubble with 3-D”, observa que os limites práticos de gráficos dependem do desempenho e da versão alvo do PowerPoint, e explica que a exportação preserva a aparência do gráfico por meio do mecanismo de renderização do Aspose.Slides.

## **Dimensionamento de Tamanho de Gráfico de Bolhas**
O Aspose.Slides para .NET oferece suporte ao dimensionamento de tamanho de gráficos de bolhas. No Aspose.Slides para .NET as propriedades **IChartSeries.BubbleSizeScale** e **IChartSeriesGroup.BubbleSizeScale** foram adicionadas. A seguir, um exemplo de amostra é apresentado.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Representar Dados como Tamanhos de Gráfico de Bolhas**
A propriedade **BubbleSizeRepresentation** foi adicionada às interfaces IChartSeries, IChartSeriesGroup e às classes relacionadas. **BubbleSizeRepresentation** especifica como os valores de tamanho das bolhas são representados no gráfico de bolhas. Os valores possíveis são: **BubbleSizeRepresentationType.Area** e **BubbleSizeRepresentationType.Width**. Consequentemente, o enum **BubbleSizeRepresentationType** foi adicionado para especificar as maneiras possíveis de representar dados como tamanhos de gráfico de bolhas. O código de exemplo é apresentado abaixo.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Um "gráfico de bolhas com efeito 3-D" é suportado, e como ele difere de um normal?**

Sim. Existe um tipo de gráfico separado, "Bubble with 3-D". Ele aplica estilização 3-D às bolhas, mas não adiciona um eixo adicional; os dados permanecem X-Y-S (tamanho). O tipo está disponível na enumeração [chart type](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/charttype/).

**Existe um limite para o número de séries e pontos em um gráfico de bolhas?**

Não há um limite rígido no nível da API; as restrições são determinadas pelo desempenho e pela versão alvo do PowerPoint. Recomenda‑se manter o número de pontos razoável para legibilidade e velocidade de renderização.

**Como a exportação afetará a aparência de um gráfico de bolhas (PDF, imagens)?**

A exportação para formatos suportados preserva a aparência do gráfico; a renderização é realizada pelo motor Aspose.Slides. Para formatos raster/vetor, aplicam‑se as regras gerais de renderização de gráficos (resolução, anti‑aliasing), portanto escolha um DPI suficiente para impressão.