---
title: ドーナツチャート
type: docs
weight: 30
url: /ja/php-java/doughnut-chart/
---

## **ドーナツチャートの中心の隙間を変更する**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java は、ドーナツチャートの穴のサイズを指定することをサポートするようになりました。このトピックでは、ドーナツチャートの穴のサイズを指定する方法を例を使って見ていきます。

{{% /alert %}} 

ドーナツチャートの穴のサイズを指定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) オブジェクトをインスタンス化します。
1. スライドにドーナツチャートを追加します。
1. ドーナツチャートの穴のサイズを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例では、ドーナツチャートの穴のサイズを設定しています。

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # プレゼンテーションをディスクに書き込む
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```