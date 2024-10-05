---
title: チャート系列
type: docs
url: /php-java/chart-series/
keywords: "チャート系列, 系列の色, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションにおけるチャート系列"
---

系列は、チャートにプロットされた数値の行または列です。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャートシリーズのオーバーラップを設定する**

[IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) プロパティを使用すると、2D チャート上でバーや列の重なり具合を指定できます（範囲: -100 から 100）。このプロパティは親系列グループのすべての系列に適用されます: これは適切なグループプロパティの投影です。したがって、このプロパティは読み取り専用です。

`ParentSeriesGroup.Overlap` の読み書き可能プロパティを使用して、`Overlap` の好ましい値を設定します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドにクラスタ化された縦棒グラフを追加します。
1. 最初のチャート系列にアクセスします。
1. チャート系列の `ParentSeriesGroup` にアクセスし、系列の好ましいオーバーラップ値を設定します。
1. 修正したプレゼンテーションを PPTX ファイルに書き込みます。

この PHP コードは、チャート系列のオーバーラップを設定する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # チャートを追加
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # 系列のオーバーラップを設定
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # プレゼンテーションファイルをディスクに書き込む
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **系列の色を変更する**
Aspose.Slides for PHP via Java は、次のように系列の色を変更できます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したい系列にアクセスします。
1. 好みの塗りつぶしタイプと塗りつぶし色を設定します。
1. 修正したプレゼンテーションを保存します。

この PHP コードは、系列の色を変更する方法を示しています：

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

## **系列のカテゴリの色を変更する**
Aspose.Slides for PHP via Java は、次のように系列のカテゴリの色を変更できます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したい系列カテゴリにアクセスします。
1. 好みの塗りつぶしタイプと塗りつぶし色を設定します。
1. 修正したプレゼンテーションを保存します。

このコードは、系列カテゴリの色を変更する方法を示しています：

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

## **系列の名前を変更する**

デフォルトでは、チャートの凡例名は、各列または行のデータの上にあるセルの内容です。

私たちの例（サンプル画像）では、

* 列は *系列 1, 系列 2,* および *系列 3*;
* 行は *カテゴリ 1, カテゴリ 2, カテゴリ 3,* および *カテゴリ 4*。

Aspose.Slides for PHP via Java は、チャートデータと凡例で系列名を更新または変更できます。

この PHP コードは、`ChartDataWorkbook` のチャートデータで系列名を変更する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("新しい名前");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

この PHP コードは、`Series` を通じて凡例の系列名を変更する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("新しい名前");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **チャートシリーズの塗りつぶし色を設定する**

Aspose.Slides for PHP via Java は、プロットエリア内のチャート系列の自動塗りつぶし色を次のように設定できます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスによってスライドの参照を取得します。
1. 自分の好みのタイプに基づいてデフォルトデータを持つチャートを追加します（以下の例では、`ChartType::ClusteredColumn` を使用しています）。
1. チャート系列にアクセスし、塗りつぶし色を自動に設定します。
1. プレゼンテーションを PPTX ファイルに保存します。

この PHP コードは、チャート系列の自動塗りつぶし色を設定する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # クラスタ化された縦棒グラフを作成
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # 系列の塗りつぶし形式を自動に設定
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # プレゼンテーションファイルをディスクに書き込む
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **チャートシリーズの塗りつぶし色を反転させる**

Aspose.Slides は、プロットエリア内のチャート系列の塗りつぶし色を反転する方法を次のように設定できます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスによってスライドの参照を取得します。
1. 自分の好みのタイプに基づいてデフォルトデータを持つチャートを追加します（以下の例では、`ChartType::ClusteredColumn` を使用しています）。
1. チャート系列にアクセスし、填立色を反転色に設定します。
1. プレゼンテーションを PPTX ファイルに保存します。

この PHP コードは操作を示しています：

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 新しい系列とカテゴリを追加
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "系列 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "カテゴリ 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "カテゴリ 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "カテゴリ 3"));
    # 最初のチャート系列を取得し、その系列データを設定
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

## **値が負のときに系列を反転させる**

Aspose.Slides は、`IChartDataPoint.InvertIfNegative` と `ChartDataPoint.InvertIfNegative` プロパティを通じて反転を設定できます。プロパティを使用して反転が設定されると、負の値を取得したときにデータポイントはその色を反転させます。

この PHP コードは操作を示しています：

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

## **特定のデータポイントのデータをクリアする**

Aspose.Slides for PHP via Java は、特定のチャート系列の `DataPoints` データをクリアすることを次のように許可します：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. インデックスを介してチャートの参照を取得します。
4. すべてのチャート `DataPoints` を繰り返し、 `XValue` と `YValue` を null に設定します。
5. 特定のチャート系列に対してすべての `DataPoints` をクリアします。
6. 修正したプレゼンテーションを PPTX ファイルに書き込みます。

この PHP コードは操作を示しています：

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

## **系列のギャップ幅を設定する**

Aspose.Slides for PHP via Java は、**`GapWidth`** プロパティを通じて系列のギャップ幅を設定できる方法を次のように示します：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータを持つチャートを追加します。
1. 任意のチャート系列にアクセスします。
1. `GapWidth` プロパティを設定します。
1. 修正したプレゼンテーションを PPTX ファイルに書き込みます。

このコードは、系列のギャップ幅を設定する方法を示しています：

```php
  # 空のプレゼンテーションを作成
  $pres = new Presentation();
  try {
    # プレゼンテーションの最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # デフォルトデータを持つチャートを追加
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # チャートデータシートのインデックスを設定
    $defaultWorksheetIndex = 0;
    # チャートデータワークシートを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 系列を追加
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "系列 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "系列 2"), $chart->getType());
    # カテゴリを追加
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "カテゴリ 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "カテゴリ 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "カテゴリ 3"));
    # 2 番目のチャート系列を取得
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 系列データを設定
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # ギャップ幅の値を設定
    $series->getParentSeriesGroup()->setGapWidth(50);
    # プレゼンテーションをディスクに保存
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```