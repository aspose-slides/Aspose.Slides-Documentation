---
title: Aspose.Slides for Java 15.8.0'de Genel API ve Geriye Dönük Uyumlu Olmayan Değişiklikler
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
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for Java 15.8.0 API'siyle tanıtılan [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) veya [kaldırılan](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
#### **IChartSeries ve ChartSeries'e getDoughnutHoleSize(), setDoughnutHoleSize(byte) metodları eklendi**
Donut grafiğindeki deliğin boyutunu belirler.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```