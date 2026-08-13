---
title: Публичный API и несовместимые изменения в Aspose.Slides for Java 15.8.0
linktitle: Aspose.Slides for Java 15.8.0
type: docs
weight: 160
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Обзор обновлений публичного API и несовместимых изменений в Aspose.Slides for Java для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}}

Эта страница перечисляет все [added](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) или [removed](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides for Java 15.8.0.

{{% /alert %}}
## **Изменения публичного API**
#### **Методы getDoughnutHoleSize(), setDoughnutHoleSize(byte) были добавлены в IChartSeries и ChartSeries**
Указывает размер отверстия в кольцевой диаграмме.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```