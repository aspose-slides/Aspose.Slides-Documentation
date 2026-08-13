---
title: Aspose.Slides for Java 16.1.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 16.1.0
type: docs
weight: 200
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 
Bu sayfa, Aspose.Slides for Java 16.1.0 API'siyle tanıtılan [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) veya [kaldırılan](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.
{{% /alert %}} 
## **Genel API Değişiklikleri**

#### **getRotationAngle() ve setRotationAngle() metodları IChartTextBlockFormat ve ITextFrameFormat arayüzlerine eklenmiştir**
getRotationAngle() ve setRotationAngle() metodları com.aspose.slides.IChartTextBlockFormat ve com.aspose.slides.ITextFrameFormat arayüzlerine eklenmiştir.
Bu metodlar, sınırlayıcı kutu içindeki metne uygulanan özel dönüşümü erişilebilir kılar.

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