---
title: Cambios en la API pública e incompatibilidades retroactivas en Aspose.Slides para Java 16.1.0
linktitle: Aspose.Slides para Java 16.1.0
type: docs
weight: 200
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revisa las actualizaciones de la API pública y los cambios de ruptura en Aspose.Slides para Java para migrar sin problemas tus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 
Esta página enumera todos los [añadidos](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) o [eliminados](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) clases, métodos, propiedades y demás, y otros cambios introducidos con la API Aspose.Slides for Java 16.1.0.
{{% /alert %}} 
## **Cambios de la API pública**

#### **Se han añadido los métodos getRotationAngle() y setRotationAngle() a las interfaces IChartTextBlockFormat y ITextFrameFormat**
Se han añadido los métodos getRotationAngle() y setRotationAngle() a las interfaces com.aspose.slides.IChartTextBlockFormat y com.aspose.slides.ITextFrameFormat. Proporcionan acceso a la rotación personalizada que se aplica al texto dentro del recuadro delimitador.

``` java
import com.aspose.slides.*;




Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```