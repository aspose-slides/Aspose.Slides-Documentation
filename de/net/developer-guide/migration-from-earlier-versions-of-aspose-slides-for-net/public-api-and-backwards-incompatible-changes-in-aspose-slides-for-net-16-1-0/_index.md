---
title: Öffentliche API und nicht rückwärtskompatible Änderungen in Aspose.Slides für .NET 16.1.0
type: docs
weight: 220
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) Klassen, Methoden, Eigenschaften usw. auf sowie andere Änderungen, die mit der Aspose.Slides für .NET 16.1.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen an der öffentlichen API**


#### **Die Eigenschaft RotationAngle wurde zu den Schnittstellen IChartTextBlockFormat und ITextFrameFormat hinzugefügt**
Die Eigenschaft RotationAngle wurde zu den Schnittstellen Aspose.Slides.Charts.IChartTextBlockFormat und Aspose.Slides.ITextFrameFormat hinzugefügt.
Sie gibt die benutzerdefinierte Drehung an, die auf den Text innerhalb des Begrenzungsrahmens angewendet wird.

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Benutzerdefinierter Titel").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **OdpException wurde von Aspose.Slides.Odp in den Aspose.Slides Namespace verschoben**