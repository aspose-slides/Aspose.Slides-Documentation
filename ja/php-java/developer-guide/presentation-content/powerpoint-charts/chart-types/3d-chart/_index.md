---
title: 3Dチャート
type: docs
url: /php-java/3d-chart/
---

## **3DチャートのRotationX、RotationY、およびDepthPercentsプロパティを設定する**
Aspose.Slides for PHP via Javaは、これらのプロパティを設定するためのシンプルなAPIを提供します。この次の記事は、**X、Y回転、DepthPercents**などの異なるプロパティを設定する方法を示します。サンプルコードは、上記のプロパティを設定する方法を適用します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータを持つチャートを追加します。
1. Rotation3Dプロパティを設定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

```php
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # デフォルトデータを持つチャートを追加
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # チャートデータシートのインデックスを設定
    $defaultWorksheetIndex = 0;
    # チャートデータワークブックを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # シリーズを追加
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "シリーズ1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "シリーズ2"), $chart->getType());
    # カテゴリを追加
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "カテゴリ1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "カテゴリ2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "カテゴリ3"));
    # Rotation3Dプロパティを設定
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # 二番目のチャートシリーズを取得
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # シリーズデータを populating 
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # OverLap値を設定
    $series->getParentSeriesGroup()->setOverlap(100);
    # プレゼンテーションをディスクに書き込む
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```