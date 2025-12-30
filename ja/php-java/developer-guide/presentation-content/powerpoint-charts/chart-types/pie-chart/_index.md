---
title: PHP を使用したプレゼンテーションの円グラフのカスタマイズ
linktitle: 円グラフ
type: docs
url: /ja/php-java/pie-chart/
keywords:
- 円グラフ
- チャートの管理
- チャートのカスタマイズ
- チャート オプション
- チャート設定
- プロット オプション
- スライスの色
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して円グラフを作成およびカスタマイズする方法を学び、PowerPoint へエクスポートでき、数秒でデータストーリーテリングを強化します。"
---

## **パイ・オブ・パイ および バー・オブ・パイ チャートの第2プロットオプション**

Aspose.Slides for PHP via Java は、Pie of Pie または Bar of Pie チャートの第2プロットオプションをサポートするようになりました。このトピックでは、Aspose.Slides を使用してこれらのオプションを指定する方法を示します。プロパティを指定するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラス オブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの第2プロットオプションを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例では、Pie of Pie チャートのさまざまなプロパティを設定しています。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # スライドにチャートを追加
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # 異なるプロパティを設定
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # プレゼンテーションをディスクに書き込む
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **自動パイチャートスライスの色を設定**

Aspose.Slides for PHP via Java は、自動パイチャートスライスの色を設定するためのシンプルな API を提供します。サンプルコードは、上記のプロパティ設定を適用しています。

1. Presentation クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. チャートのタイトルを設定します。
1. 最初の系列を値を表示するように設定します。
1. チャートデータシートのインデックスを設定します。
1. チャートデータのワークシートを取得します。
1. デフォルトで生成された系列とカテゴリを削除します。
1. 新しいカテゴリを追加します。
1. 新しい系列を追加します。

変更したプレゼンテーションを PPTX ファイルに書き込みます。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # デフォルト データでチャートを追加
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # チャートのタイトルを設定
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # 最初の系列を値の表示に設定
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # チャート データ シートのインデックスを設定
    $defaultWorksheetIndex = 0;
    # チャート データのワークシートを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # デフォルトで生成された系列とカテゴリを削除
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 新しいカテゴリを追加
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # 新しい系列を追加
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # 系列データを現在設定しています
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


## **よくある質問**

**'Pie of Pie' および 'Bar of Pie' バリエーションはサポートされていますか？**

はい、ライブラリは [supports](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) ピチャートの二次プロット（'Pie of Pie' および 'Bar of Pie' タイプを含む）をサポートしています。

**チャートだけを画像（例: PNG）としてエクスポートできますか？**

はい、全体のプレゼンテーションを含めずに、チャート自体を画像（PNG など）として [export the chart itself as an image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) することができます。