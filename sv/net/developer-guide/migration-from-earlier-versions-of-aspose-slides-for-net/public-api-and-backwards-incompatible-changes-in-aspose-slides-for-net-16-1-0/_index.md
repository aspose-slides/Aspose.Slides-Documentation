---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 16.1.0
linktitle: Aspose.Slides för .NET 16.1.0
type: docs
weight: 220
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationer."
---
{{% alert color="info" %}} 
Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) klasser, metoder, egenskaper med mera, samt andra förändringar som införts med Aspose.Slides för .NET 16.1.0 API.
{{% /alert %}} 
## **Ändringar i offentligt API**

#### **Egenskapen RotationAngle har lagts till i IChartTextBlockFormat- och ITextFrameFormat-gränssnitten**
Egenskapen RotationAngle har lagts till i gränssnitten Aspose.Slides.Charts.IChartTextBlockFormat och Aspose.Slides.ITextFrameFormat. Den specificerar den anpassade rotation som appliceras på texten inom begränsningsrutan.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


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
#### **OdpException har flyttats från Aspose.Slides.Odp till Aspose.Slides-namnrymden**