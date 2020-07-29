---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 16.1.0
type: docs
weight: 220
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 16.1.0 API.

{{% /alert %}} 
## **Public API Changes**


#### **Property RotationAngle has been added to IChartTextBlockFormat and ITextFrameFormat interfaces**
Property RotationAngle has been added to interfaces Aspose.Slides.Charts.IChartTextBlockFormat and Aspose.Slides.ITextFrameFormat.
It specifies the custom rotation that is being applied to the text within the bounding box.

{{< highlight java >}}

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


{{< /highlight >}}
#### **OdpException moved from Aspose.Slides.Odp to Aspose.Slides namespace**
