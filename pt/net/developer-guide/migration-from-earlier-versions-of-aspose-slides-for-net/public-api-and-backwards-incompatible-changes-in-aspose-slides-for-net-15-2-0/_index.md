---
title: API Pública e Alterações Incompatíveis em Versões Anteriores no Aspose.Slides para .NET 15.2.0
linktitle: Aspose.Slides para .NET 15.2.0
type: docs
weight: 140
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Revise as atualizações da API pública e as mudanças que quebram compatibilidade no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentações PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 
Esta página lista todas as classes, métodos, propriedades etc. [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) ou [removidos](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/), e outras mudanças introduzidas com a API Aspose.Slides para .NET 15.2.0.
{{% /alert %}} 
## **Alterações da API Pública**
#### **Métodos AddDataPointForDoughnutSeries foram adicionados**
As duas sobrecargas do método IChartDataPointCollection.AddDataPointForDoughnutSeries() foram adicionadas para inserir pontos de dados nas séries do tipo de gráfico Rosquinha.
#### **Classe Aspose.Slides.SmartArt.SmartArtShape foi herdada da classe Aspose.Slides.GeometryShape**
A classe Aspose.Slides.SmartArt.SmartArtShape foi herdada da classe Aspose.Slides.GeometryShape. Essa mudança aprimora o modelo de objetos do Aspose.Slides e adiciona novos recursos à classe SmartArtShape.
#### **Métodos para remover ponto de dados de gráfico e categoria de gráfico por índice foram adicionados**
O método IChartDataPointCollection.RemoveAt(int index) foi adicionado para remover um ponto de dados de gráfico por seu índice.
O método IChartCategoryCollection.RemoveAt(int index) foi adicionado para remover uma categoria de gráfico por seu índice.
#### **Valor PptXPptY foi adicionado à enumeração Aspose.Slides.Animation.PropertyType**
O valor PptXPptY foi adicionado à enumeração Aspose.Slides.Animation.PropertyType no contexto de correção de um problema de serialização.
#### **Método System.Drawing.Color GetAutomaticSeriesColor() foi adicionado ao Aspose.Slides.Charts.IChartSeries**
O método GetAutomaticSeriesColor retorna uma cor automática da série com base no índice da série e no estilo do gráfico. Essa cor é usada por padrão se FillType for igual a NotDefined.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```