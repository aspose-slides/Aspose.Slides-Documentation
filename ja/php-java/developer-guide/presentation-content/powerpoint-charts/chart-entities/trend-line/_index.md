---
title: トレンドライン
type: docs
url: /ja/php-java/trend-line/
---

## **トレンドラインの追加**
Aspose.Slides for PHP via Javaは、さまざまなチャートのトレンドラインを管理するためのシンプルなAPIを提供します:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. デフォルトのデータを持つチャートを追加し、希望するタイプのチャートを追加します（この例ではChartType::ClusteredColumnを使用）。
1. チャート系列1に対して指数トレンドラインを追加します。
1. チャート系列1に対して線形トレンドラインを追加します。
1. チャート系列2に対して対数トレンドラインを追加します。
1. チャート系列2に対して移動平均トレンドラインを追加します。
1. チャート系列3に対して多項式トレンドラインを追加します。
1. チャート系列3に対してパワートレンドラインを追加します。
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

以下のコードは、トレンドライン付きのチャートを作成するために使用されます。

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # クラスター縦棒グラフを作成
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # チャート系列1に対して指数トレンドラインを追加
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # チャート系列1に対して線形トレンドラインを追加
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # チャート系列2に対して対数トレンドラインを追加
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("新しい対数トレンドライン");
    # チャート系列2に対して移動平均トレンドラインを追加
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("新しいトレンドライン名");
    # チャート系列3に対して多項式トレンドラインを追加
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # チャート系列3に対してパワートレンドラインを追加
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # プレゼンテーションを保存
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **カスタムラインの追加**
Aspose.Slides for PHP via Javaは、チャートにカスタムラインを追加するためのシンプルなAPIを提供します。プレゼンテーションの選択したスライドにシンプルなPlainラインを追加するには、以下の手順に従ってください:

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapesオブジェクトが公開するAddChartメソッドを使用して新しいチャートを作成します。
- Shapesオブジェクトが公開するAddAutoShapeメソッドを使用して線型のオートシェイプを追加します。
- 形状のラインの色を設定します。
- 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下のコードは、カスタムライン付きのチャートを作成するために使用されます。

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```