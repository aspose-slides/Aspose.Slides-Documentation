---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 16.1.0
linktitle: Aspose.Slides pro Java 16.1.0
type: docs
weight: 200
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a zásadní změny v Aspose.Slides pro Java, abyste hladce migrovali své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 
Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) nebo [odstraněné](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v rozhraní Aspose.Slides pro Java 16.1.0 API.
{{% /alert %}} 
## **Změny veřejného API**

#### **Metody getRotationAngle() a setRotationAngle() byly přidány do rozhraní IChartTextBlockFormat a ITextFrameFormat**
Metody getRotationAngle() a setRotationAngle() byly přidány do rozhraní com.aspose.slides.IChartTextBlockFormat a com.aspose.slides.ITextFrameFormat. Poskytují přístup k vlastní rotaci, která se aplikuje na text v rámci ohraničujícího rámečku.

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