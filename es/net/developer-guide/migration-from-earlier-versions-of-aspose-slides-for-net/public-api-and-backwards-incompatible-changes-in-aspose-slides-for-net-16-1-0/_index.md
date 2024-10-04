---
title: API pública y cambios incompatibles con versiones anteriores en Aspose.Slides para .NET 16.1.0
type: docs
weight: 220
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [agregadas](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) o [eliminadas](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) clases, métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides para .NET 16.1.0.

{{% /alert %}} 
## **Cambios en la API pública**


#### **Se ha agregado la propiedad RotationAngle a las interfaces IChartTextBlockFormat e ITextFrameFormat**
Se ha agregado la propiedad RotationAngle a las interfaces Aspose.Slides.Charts.IChartTextBlockFormat y Aspose.Slides.ITextFrameFormat.
Especifica la rotación personalizada que se aplica al texto dentro del cuadro delimitador.

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Título personalizado").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **OdpException movido del espacio de nombres Aspose.Slides.Odp al espacio de nombres Aspose.Slides**