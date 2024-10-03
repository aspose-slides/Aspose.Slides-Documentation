---
title: Публичный API и несовместимые изменения в Aspose.Slides для PHP через Java 15.8.0
type: docs
weight: 160
url: /ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) или [удаленных](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) классов, методов, свойств и так далее, а также других изменений, внедренных в API Aspose.Slides для PHP через Java 15.8.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Методы getDoughnutHoleSize(), setDoughnutHoleSize(byte) были добавлены в IChartSeries и ChartSeries**
Указывает размер отверстия в круговой диаграмме.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
  $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
  $pres->save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat::Pptx);

```