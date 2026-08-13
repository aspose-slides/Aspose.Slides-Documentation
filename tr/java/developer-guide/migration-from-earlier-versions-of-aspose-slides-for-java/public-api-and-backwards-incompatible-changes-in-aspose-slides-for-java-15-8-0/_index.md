---
title: Aspose.Slides for Java 15.8.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
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
description: "Aspose.Slides for Java'da genel API güncellemelerini ve kırıcı değişiklikleri gözden geçirerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 
Bu sayfa, Aspose.Slides for Java 15.8.0 API'siyle tanıtılan eklenen [added](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) veya kaldırılan [removed](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) sınıfları, metodları, özellikleri ve benzeri diğer değişiklikleri listeler.
{{% /alert %}} 
## **Public API Değişiklikleri**
#### **getDoughnutHoleSize(), setDoughnutHoleSize(byte) metodları IChartSeries ve ChartSeries'e eklendi**
Donut grafiğindeki deliğin boyutunu belirtir.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```