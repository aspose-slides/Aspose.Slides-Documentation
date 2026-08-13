---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für Java 16.1.0
linktitle: Aspose.Slides für Java 16.1.0
type: docs
weight: 200
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die Breaking Changes in Aspose.Slides for Java, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 
Diese Seite listet alle [hinzugefügt](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) oder [entfernt](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for Java 16.1.0 API eingeführt wurden.
{{% /alert %}} 
## **Öffentliche API-Änderungen**

#### **Methoden getRotationAngle() und setRotationAngle() wurden zu den Schnittstellen IChartTextBlockFormat und ITextFrameFormat hinzugefügt**
Methoden getRotationAngle() und setRotationAngle() wurden zu den Schnittstellen com.aspose.slides.IChartTextBlockFormat und com.aspose.slides.ITextFrameFormat hinzugefügt.
Sie bieten Zugriff auf die benutzerdefinierte Rotation, die auf den Text innerhalb des Begrenzungsrahmens angewendet wird.

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