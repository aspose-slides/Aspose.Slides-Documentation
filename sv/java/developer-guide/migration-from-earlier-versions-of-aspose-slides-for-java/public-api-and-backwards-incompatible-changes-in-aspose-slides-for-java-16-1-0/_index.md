---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för Java 16.1.0
linktitle: Aspose.Slides för Java 16.1.0
type: docs
weight: 200
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint-PPT, PPTX- och ODP-presentationslösningar."
---
{{% alert color="primary" %}} 
Denna sida listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) eller [borttagna](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) klasser, metoder, egenskaper osv., samt andra förändringar som införts med Aspose.Slides för Java 16.1.0 API.
{{% /alert %}} 
## **Offentliga API‑ändringar**

#### **Metoderna getRotationAngle() och setRotationAngle() har lagts till i IChartTextBlockFormat‑ och ITextFrameFormat‑gränssnitten**
Metoderna getRotationAngle() och setRotationAngle() har lagts till i gränssnitten com.aspose.slides.IChartTextBlockFormat och com.aspose.slides.ITextFrameFormat.
De ger åtkomst till den anpassade rotation som appliceras på texten inom omgivningsrutan.

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