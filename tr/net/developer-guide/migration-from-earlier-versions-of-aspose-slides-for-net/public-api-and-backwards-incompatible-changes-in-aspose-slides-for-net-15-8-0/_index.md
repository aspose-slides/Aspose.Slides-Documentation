---
title: Aspose.Slides for .NET 15.8.0'de Genel API ve Geriye Uyumlu Olmayan Değişiklikler
linktitle: Aspose.Slides for .NET 15.8.0
type: docs
weight: 190
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 
Bu sayfa, Aspose.Slides for .NET 15.8.0 API'siyle tanıtılan [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) veya [kaldırılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.
{{% /alert %}} 
## **Public API Değişiklikleri**
#### **DoughnutHoleSize Özelliği IChartSeries ve ChartSeries'e Eklendi**
Doughnut grafiğindeki deliğin boyutunu belirtir.
``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```