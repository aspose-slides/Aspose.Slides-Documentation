---
title: Public API i zmiany niekompatybilne wstecz w Aspose.Slides dla Java 16.1.0
linktitle: Aspose.Slides dla Java 16.1.0
type: docs
weight: 200
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides dla Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 
Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) lub [usunięte](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) klasy, metody, właściwości i podobne, oraz inne zmiany wprowadzone w API Aspose.Slides for Java 16.1.0.
{{% /alert %}} 
## **Zmiany w publicznym API**


#### **Do interfejsów IChartTextBlockFormat i ITextFrameFormat dodano metody getRotationAngle() i setRotationAngle()**
Metody getRotationAngle() i setRotationAngle() zostały dodane do interfejsów com.aspose.slides.IChartTextBlockFormat i com.aspose.slides.ITextFrameFormat. Umożliwiają dostęp do niestandardowego obrotu stosowanego do tekstu wewnątrz pola ograniczającego.

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```