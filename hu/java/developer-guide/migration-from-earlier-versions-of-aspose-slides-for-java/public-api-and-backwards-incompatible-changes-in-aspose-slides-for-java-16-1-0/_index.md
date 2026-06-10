---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 16.1.0-ban
linktitle: Aspose.Slides for Java 16.1.0
type: docs
weight: 200
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for Java nyilvános API frissítéseit és töréspontjait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 
Ez az oldal felsorolja az összes hozzáadott vagy eltávolított osztályt, metódust, tulajdonságot és így tovább, valamint a Aspose.Slides for Java 16.1.0 API‑val bevezetett egyéb változásokat.
{{% /alert %}} 
## **Nyilvános API változások**

#### **Az getRotationAngle() és a setRotationAngle() metódusok hozzá lettek adva az IChartTextBlockFormat és ITextFrameFormat interfészekhez**
A getRotationAngle() és a setRotationAngle() metódusok hozzá lettek adva a com.aspose.slides.IChartTextBlockFormat és a com.aspose.slides.ITextFrameFormat interfészekhez.
Lehetővé teszik az egyéni forgatás elérését, amely a keretben lévő szövegre van alkalmazva.

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