---
title: Aspose.Slides for Java 16.1.0'da Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 16.1.0
type: docs
weight: 200
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- geçiş
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for Java 16.1.0 API'siyle tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) veya [kaldırılan](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) sınıfları, metodları, özellikleri ve benzeri öğeleri ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**


#### **getRotationAngle() ve setRotationAngle() metodları IChartTextBlockFormat ve ITextFrameFormat arabirimlerine eklendi**
getRotationAngle() ve setRotationAngle() metodları com.aspose.slides.IChartTextBlockFormat ve com.aspose.slides.ITextFrameFormat arabirimlerine eklenmiştir.
Bu metodlar, sınırlama kutusu içindeki metne uygulanan özel dönüşüme erişim sağlar.

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