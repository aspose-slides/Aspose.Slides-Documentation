---
title: Öffentliches API und rückwärts inkompatible Änderungen in Aspose.Slides für Java 16.1.0
type: docs
weight: 200
url: /de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) oder [entfernten](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) Klassen, Methoden, Eigenschaften und so weiter auf, sowie andere Änderungen, die mit der Aspose.Slides für Java 16.1.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen an öffentlichem API**


#### **Methoden getRotationAngle() und setRotationAngle() wurden zu den Schnittstellen IChartTextBlockFormat und ITextFrameFormat hinzugefügt**
Methoden getRotationAngle() und setRotationAngle() wurden zu den Schnittstellen com.aspose.slides.IChartTextBlockFormat und com.aspose.slides.ITextFrameFormat hinzugefügt. 
Sie bieten Zugriff auf die benutzerdefinierte Rotation, die auf den Text innerhalb des Begrenzungsrahmens angewendet wird.

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Benutzerdefinierter Titel").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```