---
title: Aspose.Slides for .NET 16.1.0'de Genel API ve Geriye Yönelik Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 16.1.0
type: docs
weight: 220
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
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
Bu sayfa, Aspose.Slides for .NET 16.1.0 API'siyle tanıtılan eklenen veya kaldırılan sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.
{{% /alert %}} 
## **Genel API Değişiklikleri**

#### **RotationAngle Özelliği IChartTextBlockFormat ve ITextFrameFormat Arayüzlerine Eklendi**
RotationAngle özelliği Aspose.Slides.Charts.IChartTextBlockFormat ve Aspose.Slides.ITextFrameFormat arayüzlerine eklenmiştir. Bu özellik, sınırlayıcı kutu içinde metne uygulanan özel dönüşü belirtir.

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
#### **OdpException Aspose.Slides.Odp'dan Aspose.Slides Ad alanına Taşındı**