---
title: PHP を使用したプレゼンテーションで 3D チャートをカスタマイズする
linktitle: 3D チャート
type: docs
url: /ja/php-java/3d-chart/
keywords:
- 3D チャート
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java で 3-D チャートを作成・カスタマイズする方法を学び、PPT および PPTX ファイルをサポートし、プレゼンテーションを今すぐ強化しましょう。"
---

## **3D チャートの RotationX、RotationY、DepthPercents プロパティの設定**
Aspose.Slides for PHP via Java は、これらのプロパティを設定するためのシンプルな API を提供します。このドキュメントでは、**X、Y 回転、DepthPercents** などのさまざまなプロパティの設定方法を紹介します。サンプルコードは、上記プロパティの設定方法を示しています。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルト データでチャートを追加します。
1. Rotation3D プロパティを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。
```php
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # デフォルトデータでチャートを追加
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # チャートデータシートのインデックスを設定
    $defaultWorksheetIndex = 0;
    # チャートデータのワークシートを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # シリーズを追加
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # カテゴリを追加
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Rotation3D プロパティを設定
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # 2 番目のチャートシリーズを取得
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # シリーズデータを現在設定中
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # OverLap 値を設定
    $series->getParentSeriesGroup()->setOverlap(100);
    # プレゼンテーションをディスクに保存
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **よくある質問**

**Aspose.Slidesで3Dモードをサポートするチャート タイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D などの 3D カラム チャート バリアントをサポートしており、[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) クラスで公開されている関連 3D タイプも含まれます。最新かつ正確なリストは、インストール済みバージョンの API リファレンス内の [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) メンバーをご確認ください。

**レポートや Web 用に 3D チャートのラスタ 画像を取得できますか？**

はい。チャートを画像にエクスポートするには [chart API](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) を使用するか、スライド全体を PNG や JPEG 形式に変換するには [/slides/php-java/convert-powerpoint-to-png/](/slides/ja/php-java/convert-powerpoint-to-png/) を使用します。これにより、ピクセル単位で正確なプレビューが必要な場合や、PowerPoint を使用せずにドキュメント、ダッシュボード、Web ページにチャートを埋め込む場合に便利です。

**大規模な 3D チャートの作成とレンダリングのパフォーマンスはどの程度ですか？**

パフォーマンスはデータ量と視覚的な複雑さに依存します。最適な結果を得るためには、3D 効果を最小限に抑え、壁面やプロット領域に重いテクスチャを使用しないようにし、可能であればシリーズごとのデータポイント数を制限し、対象の表示または印刷要件に合わせた解像度とサイズで出力することを推奨します。