---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 16.1.0 verzióban
linktitle: Aspose.Slides for .NET 16.1.0
type: docs
weight: 220
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for .NET nyilvános API frissítéseit és töréspontjait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 
Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) osztályt, metódust, tulajdonságot és hasonlókat, valamint a Aspose.Slides for .NET 16.1.0 API-val bevezetett egyéb változásokat.
{{% /alert %}} 
## **Nyilvános API változások**

#### **A RotationAngle tulajdonság hozzáadva az IChartTextBlockFormat és ITextFrameFormat interfészekhez**
A RotationAngle tulajdonság hozzá lett adva az Aspose.Slides.Charts.IChartTextBlockFormat és Aspose.Slides.ITextFrameFormat interfészekhez.
Ez határozza meg a szövegre alkalmazott egyéni forgatást a körülhatároló keretben.

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
#### **Az OdpException áthelyezve az Aspose.Slides.Odp névtérből az Aspose.Slides névtérbe**