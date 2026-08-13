---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla Java 16.1.0
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
description: "Przejrzyj aktualizacje publicznego API i zmiany niekompatybilne w Aspose.Slides dla Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) lub [usunięte](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for Java 16.1.0.

{{% /alert %}} 
## **Zmiany publicznego API**


#### **Metody getRotationAngle() i setRotationAngle() zostały dodane do interfejsów IChartTextBlockFormat i ITextFrameFormat**
Metody getRotationAngle() i setRotationAngle() zostały dodane do interfejsów com.aspose.slides.IChartTextBlockFormat oraz com.aspose.slides.ITextFrameFormat.
Zapewniają dostęp do niestandardowego obrotu, który jest stosowany do tekstu wewnątrz ramki.

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