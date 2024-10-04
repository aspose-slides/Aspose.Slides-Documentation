---
title: API pública y cambios incompatibles con versiones anteriores en Aspose.Slides para Java 16.1.0
type: docs
weight: 200
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

Esta página enumera todas las [agregadas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) o [eliminadas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) clases, métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides para Java 16.1.0.

{{% /alert %}} 
## **Cambios en la API pública**


#### **Los métodos getRotationAngle() y setRotationAngle() se han agregado a las interfaces IChartTextBlockFormat e ITextFrameFormat**
Se han agregado los métodos getRotationAngle() y setRotationAngle() a las interfaces com.aspose.slides.IChartTextBlockFormat y com.aspose.slides.ITextFrameFormat.
Proporcionan acceso a la rotación personalizada que se aplica al texto dentro del cuadro delimitador.

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Título personalizado").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```