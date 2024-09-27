---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 15.8.0
type: docs
weight: 160
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

Эта страница содержит все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) или [удаленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) классы, методы, свойства и т.д., а также другие изменения, внесенные с API Aspose.Slides для Java 15.8.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Методы getDoughnutHoleSize(), setDoughnutHoleSize(byte) были добавлены в IChartSeries и ChartSeries**
Указывает размер отверстия в круговой диаграмме.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```