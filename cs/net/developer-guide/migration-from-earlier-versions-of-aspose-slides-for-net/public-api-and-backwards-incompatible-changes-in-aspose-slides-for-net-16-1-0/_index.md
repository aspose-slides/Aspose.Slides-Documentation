---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 16.1.0
linktitle: Aspose.Slides pro .NET 16.1.0
type: docs
weight: 220
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a zásadní změny v Aspose.Slides pro .NET a hladce migrujte své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 
Tato stránka uvádí všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) nebo [odstraněné](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides pro .NET 16.1.0.
{{% /alert %}} 
## **Změny veřejného API**

#### **Vlastnost RotationAngle byla přidána do rozhraní IChartTextBlockFormat a ITextFrameFormat**
Vlastnost RotationAngle byla přidána do rozhraní Aspose.Slides.Charts.IChartTextBlockFormat a Aspose.Slides.ITextFrameFormat.  
Určuje vlastní rotaci, která se aplikuje na text v rámci ohraničujícího rámečku.

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
#### **OdpException přesunuta z Aspose.Slides.Odp do jmenného prostoru Aspose.Slides**