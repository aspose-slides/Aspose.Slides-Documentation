---
title: パイチャート
type: docs
url: /ja/php-java/pie-chart/
---

## **パイオブパイおよびバーオブパイチャートのためのセカンドプロットオプション**
Aspose.Slides for PHP via Javaは、パイオブパイまたはバーオブパイチャートのためのセカンドプロットオプションをサポートしています。このトピックでは、Aspose.Slidesを使用してこれらのオプションを指定する方法を示します。プロパティを指定するには、次の操作を行います。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. チャートのセカンドプロットオプションを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下に示す例では、パイオブパイチャートのさまざまなプロパティを設定しています。

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # スライドにチャートを追加
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # 異なるプロパティを設定
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # プレゼンテーションをディスクに書き込み
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **自動パイチャートスライスの色を設定**
Aspose.Slides for PHP via Javaは、自動パイチャートスライスの色を設定するためのシンプルなAPIを提供しています。サンプルコードは、上記のプロパティを設定するものです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータを持つチャートを追加します。
1. チャートのタイトルを設定します。
1. 最初のシリーズを値を表示するように設定します。
1. チャートデータシートのインデックスを設定します。
1. チャートデータのワークシートを取得します。
1. デフォルトで生成されたシリーズとカテゴリを削除します。
1. 新しいカテゴリを追加します。
1. 新しいシリーズを追加します。

修正されたプレゼンテーションをPPTXファイルに書き込む。

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # デフォルトデータでチャートを追加
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # チャートタイトルを設定
    $chart->getChartTitle()->addTextFrameForOverriding("サンプルタイトル");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # 最初のシリーズを値を表示するように設定
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # チャートデータシートのインデックスを設定
    $defaultWorksheetIndex = 0;
    # チャートデータのワークシートを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # デフォルトで生成されたシリーズとカテゴリを削除
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 新しいカテゴリを追加
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "第1四半期"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "第2四半期"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "第3四半期"));
    # 新しいシリーズを追加
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "シリーズ1"), $chart->getType());
    # シリーズデータをポピュレート
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```