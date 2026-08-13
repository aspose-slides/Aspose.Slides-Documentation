---
title: "Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 16.1.0"
linktitle: "Aspose.Slides für .NET 16.1.0"
type: docs
weight: 220
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- Migration
- Legacy-Code
- moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über öffentliche API-Updates und breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 
Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 16.1.0 API eingeführt wurden.
{{% /alert %}} 
## **Öffentliche API-Änderungen**

#### **Die Eigenschaft RotationAngle wurde zu den Schnittstellen IChartTextBlockFormat und ITextFrameFormat hinzugefügt**
Die Eigenschaft RotationAngle wurde zu den Schnittstellen Aspose.Slides.Charts.IChartTextBlockFormat und Aspose.Slides.ITextFrameFormat hinzugefügt. Sie gibt die benutzerdefinierte Drehung an, die auf den Text innerhalb des Begrenzungsrahmens angewendet wird.

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
#### **OdpException von Aspose.Slides.Odp in den Aspose.Slides-Namespace verschoben**