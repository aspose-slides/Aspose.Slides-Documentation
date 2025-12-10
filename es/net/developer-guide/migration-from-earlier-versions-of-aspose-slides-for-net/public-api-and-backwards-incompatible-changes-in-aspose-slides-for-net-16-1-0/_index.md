---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 16.1.0
linktitle: Aspose.Slides para .NET 16.1.0
type: docs
weight: 220
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}}

Esta página enumera todas las clases, métodos, propiedades y demás que se han [añadido](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) o [eliminado](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/), y otros cambios introducidos con la API de Aspose.Slides para .NET 16.1.0.

{{% /alert %}}
## **Cambios en la API pública**


#### **Se ha añadido la propiedad RotationAngle a las interfaces IChartTextBlockFormat e ITextFrameFormat**
La propiedad RotationAngle se ha añadido a las interfaces Aspose.Slides.Charts.IChartTextBlockFormat y Aspose.Slides.ITextFrameFormat.
Especifica la rotación personalizada que se está aplicando al texto dentro del cuadro delimitador.

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
#### **OdpException se ha movido de Aspose.Slides.Odp al espacio de nombres Aspose.Slides**