---
title: Публичный API и несовместимые изменения в Aspose.Slides for Java 16.1.0
linktitle: Aspose.Slides for Java 16.1.0
type: docs
weight: 200
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides for Java для плавной миграции ваших решений PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

На этой странице перечислены все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) или [удалённые](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides for Java 16.1.0.

{{% /alert %}} 
## **Изменения публичного API**


#### **Методы getRotationAngle() и setRotationAngle() были добавлены в интерфейсы IChartTextBlockFormat и ITextFrameFormat**
Методы getRotationAngle() и setRotationAngle() были добавлены в интерфейсы com.aspose.slides.IChartTextBlockFormat и com.aspose.slides.ITextFrameFormat.
Они предоставляют доступ к пользовательскому вращению, которое применяется к тексту внутри ограничивающего прямоугольника.

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