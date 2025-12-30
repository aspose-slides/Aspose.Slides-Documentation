---
title: PHP を使用してプレゼンテーションのチャート データ シリーズを管理する
linktitle: データシリーズ
type: docs
url: /ja/php-java/chart-series/
keywords:
- チャートシリーズ
- シリーズのオーバーラップ
- シリーズの色
- カテゴリの色
- シリーズ名
- データポイント
- シリーズのギャップ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PowerPoint（PPT/PPTX）向けに PHP でチャート データ シリーズを管理する方法を、実用的なコード例とベストプラクティスとともに学び、データプレゼンテーションを向上させましょう。"
---

シリーズは、チャートにプロットされた数値の行または列です。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Chart Series Overlap を設定する**

[IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) プロパティを使用すると、2D チャート上で棒や列がどの程度重なるか（範囲: -100 から 100）を指定できます。このプロパティは親シリーズ グループのすべてのシリーズに適用されます。これは適切なグループ プロパティの投影です。そのため、このプロパティは読み取り専用です。

`ParentSeriesGroup.Overlap` の読み書き可能なプロパティを使用して、`Overlap` の希望の値を設定します。

1. `[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)` クラスのインスタンスを作成します。
1. スライドにクラスター化された縦棒チャートを追加します。
1. 最初のチャートシリーズにアクセスします。
1. チャートシリーズの `ParentSeriesGroup` にアクセスし、シリーズの希望する Overlap の値を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

この PHP コードは、チャートシリーズの Overlap を設定する方法を示しています。
```php
  $pres = new Presentation();
  try {
    # チャートを追加します
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # シリーズのオーバーラップを設定します
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # プレゼンテーションファイルを書き込みます
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シリーズの色を変更する**

Aspose.Slides for PHP via Java を使用すると、シリーズの色を以下のように変更できます。

1. `[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)` クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したいシリーズにアクセスします。
1. 希望する塗りタイプと塗りの色を設定します。
1. 変更されたプレゼンテーションを保存します。

この PHP コードは、シリーズの色を変更する方法を示しています。
```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シリーズカテゴリの色を変更する**

Aspose.Slides for PHP via Java を使用すると、シリーズカテゴリの色を以下のように変更できます。

1. `[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)` クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したいシリーズカテゴリにアクセスします。
1. 希望する塗りタイプと塗りの色を設定します。
1. 変更されたプレゼンテーションを保存します。

このコードは、シリーズカテゴリの色を変更する方法を示しています。
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シリーズ名を変更する**

デフォルトでは、チャートの凡例名は各列または行の上にあるセルの内容です。

例（サンプル画像）では、

* 列は *Series 1, Series 2,* と *Series 3* です；
* 行は *Category 1, Category 2, Category 3,* と *Category 4* です。

Aspose.Slides for PHP via Java を使用すると、チャートデータと凡例でシリーズ名を更新または変更できます。

この PHP コードは、チャートデータ `ChartDataWorkbook` 内でシリーズ名を変更する方法を示しています。
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


この PHP コードは、`Series` を介して凡例内のシリーズ名を変更する方法を示しています。
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **チャートシリーズの塗りつぶし色を設定する**

Aspose.Slides for PHP via Java を使用すると、プロット領域内のチャートシリーズの自動塗りつぶし色を以下のように設定できます。

1. `[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)` クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. 希望のタイプに基づくデフォルトデータでチャートを追加します（以下の例では `ChartType::ClusteredColumn` を使用しました）。
1. チャートシリーズにアクセスし、塗りつぶし色を Automatic に設定します。
1. プレゼンテーションを PPTX ファイルに保存します。

この PHP コードは、チャートシリーズの自動塗りつぶし色を設定する方法を示しています。
```php
  $pres = new Presentation();
  try {
    # クラスタ化された縦棒チャートを作成します
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # シリーズの塗りつぶし形式を自動に設定します
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # プレゼンテーションファイルを書き込みます
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **チャートシリーズの反転塗りつぶし色を設定する**

Aspose.Slides を使用すると、プロット領域内のチャートシリーズの反転塗りつぶし色を以下のように設定できます。

1. `[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)` クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. 希望のタイプに基づくデフォルトデータでチャートを追加します（以下の例では `ChartType::ClusteredColumn` を使用しました）。
1. チャートシリーズにアクセスし、塗りつぶし色を invert に設定します。
1. プレゼンテーションを PPTX ファイルに保存します。

この PHP コードは、操作を示しています。
```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 新しいシリーズとカテゴリを追加します
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # 最初のチャートシリーズを取得し、シリーズ データを設定します。
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **値が負の場合にシリーズを反転させる**

Aspose.Slides では、`IChartDataPoint.InvertIfNegative` と `ChartDataPoint.InvertIfNegative` プロパティを使用して反転を設定できます。これらのプロパティで反転を設定すると、データポイントが負の値になると色が反転します。

この PHP コードは、操作を示しています。
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **特定のポイントデータをクリアする**

Aspose.Slides for PHP via Java を使用すると、特定のチャートシリーズの `DataPoints` データを以下のようにクリアできます。

1. `[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)` クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. インデックスでチャートの参照を取得します。
4. すべてのチャート `DataPoints` を反復処理し、`XValue` と `YValue` を null に設定します。
5. 特定のチャートシリーズの `DataPoints` をすべてクリアします。
6. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

この PHP コードは、操作を示しています。
```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シリーズのギャップ幅を設定する**

Aspose.Slides for PHP via Java を使用すると、**`GapWidth`** プロパティを介してシリーズのギャップ幅を以下のように設定できます。

1. `[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 任意のチャートシリーズにアクセスします。
1. `GapWidth` プロパティを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

このコードは、シリーズのギャップ幅を設定する方法を示しています。
```php
  # 空のプレゼンテーションを作成します
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドにアクセスします
    $slide = $pres->getSlides()->get_Item(0);
    # デフォルトデータでチャートを追加します
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # チャート データ シートのインデックスを設定します
    $defaultWorksheetIndex = 0;
    # チャート データ ワークシートを取得します
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # シリーズを追加します
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # カテゴリを追加します
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # 2番目のチャートシリーズを取得します
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # シリーズ データを設定します
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # GapWidth の値を設定します
    $series->getParentSeriesGroup()->setGapWidth(50);
    # プレゼンテーションをディスクに保存します
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **FAQ**

**単一のチャートが含められるシリーズの数に制限はありますか？**

Aspose.Slides には、追加できるシリーズ数に固定された上限はありません。実際の上限は、チャートの可読性とアプリケーションで利用可能なメモリにより決まります。

**クラスタ内の列が互いに近すぎる、または離れすぎる場合はどうすればよいですか？**

`GapWidth` 設定をそのシリーズ（または親シリーズ グループ）に対して調整します。値を大きくすると列間のスペースが広がり、値を小さくすると列が近づきます。