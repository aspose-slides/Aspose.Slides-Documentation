---
title: Aspose.Slides for PHP via Java 15.8.0 的公共 API 和不兼容变更
type: docs
weight: 160
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

此页面列出了在 Aspose.Slides for PHP via Java 15.8.0 API 中添加的所有 [新增](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) 或 [删除](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) 的类、方法、属性等，以及其他变化。

{{% /alert %}} 
## **公共 API 变更**
#### **方法 getDoughnutHoleSize() 和 setDoughnutHoleSize(byte) 被添加到 IChartSeries 和 ChartSeries**
指定甜甜圈图中孔的大小。

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
  $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
  $pres->save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat::Pptx);

```