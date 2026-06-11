---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 16.1.0
linktitle: Aspose.Slides dla .NET 16.1.0
type: docs
weight: 220
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zapoznaj się z aktualizacjami publicznego API i zmianami niekompatybilnymi wstecz w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 
Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w interfejsie API Aspose.Slides for .NET 16.1.0 API.
{{% /alert %}} 
## **Zmiany w publicznym API**

#### **Właściwość RotationAngle została dodana do interfejsów IChartTextBlockFormat i ITextFrameFormat**
Właściwość RotationAngle została dodana do interfejsów Aspose.Slides.Charts.IChartTextBlockFormat i Aspose.Slides.ITextFrameFormat.
Określa ona niestandardowy obrót stosowany do tekstu w ramach pola ograniczającego.

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
#### **OdpException przeniesiono z Aspose.Slides.Odp do przestrzeni nazw Aspose.Slides**