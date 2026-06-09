---
title: Alterações de API Pública e Incompatíveis Retroativas no Aspose.Slides para .NET 16.1.0
linktitle: Aspose.Slides para .NET 16.1.0
type: docs
weight: 220
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
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
description: "Revise as atualizações da API pública e as mudanças que quebram compatibilidade no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Esta página lista todas as classes, métodos, propriedades e afins [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) ou [removidos](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/), e outras alterações introduzidas com a Aspose.Slides for .NET 16.1.0 API.
{{% /alert %}} 
## **Alterações da API Pública**


#### **A propriedade RotationAngle foi adicionada às interfaces IChartTextBlockFormat e ITextFrameFormat**
A propriedade RotationAngle foi adicionada às interfaces Aspose.Slides.Charts.IChartTextBlockFormat e Aspose.Slides.ITextFrameFormat.
Ela especifica a rotação personalizada que está sendo aplicada ao texto dentro da caixa delimitadora.

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **OdpException movido do namespace Aspose.Slides.Odp para o namespace Aspose.Slides**