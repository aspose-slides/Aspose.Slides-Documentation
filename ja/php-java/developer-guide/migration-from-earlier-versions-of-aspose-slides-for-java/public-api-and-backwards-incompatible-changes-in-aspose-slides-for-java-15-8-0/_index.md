---
title: Aspose.Slides for PHP via Java 15.8.0の公開APIと後方互換性のない変更
type: docs
weight: 160
url: /ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 15.8.0 APIで追加されたすべての[class](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/)または[削除された](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/)クラス、メソッド、プロパティなど、および他の変更がリストされています。

{{% /alert %}} 
## **公開APIの変更**
#### **メソッド getDoughnutHoleSize()、setDoughnutHoleSize(byte) が IChartSeries と ChartSeries に追加されました**
ドーナツチャートの穴のサイズを指定します。

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
  $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
  $pres->save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat::Pptx);

```