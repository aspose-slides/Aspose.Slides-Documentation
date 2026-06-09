---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para .NET 15.8.0
linktitle: Aspose.Slides para .NET 15.8.0
type: docs
weight: 190
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
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
description: "Revise as atualizações da API pública e alterações incompatíveis no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Esta página lista todas as classes, métodos, propriedades etc. [added](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) ou [removed](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) e outras alterações introduzidas na API do Aspose.Slides for .NET 15.8.0.
{{% /alert %}} 
## **Alterações na API Pública**
#### **A propriedade DoughnutHoleSize foi adicionada a IChartSeries e ChartSeries**
Especifica o tamanho do buraco em um gráfico de rosquinha.
``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```