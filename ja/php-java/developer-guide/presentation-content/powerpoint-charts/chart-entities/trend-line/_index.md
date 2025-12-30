---
title: PHPでプレゼンテーションのチャートにトレンドラインを追加
linktitle: トレンドライン
type: docs
url: /ja/php-java/trend-line/
keywords:
- チャート
- トレンドライン
- 指数トレンドライン
- 線形トレンドライン
- 対数トレンドライン
- 移動平均トレンドライン
- 多項式トレンドライン
- べきトレンドライン
- カスタムトレンドライン
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint のチャートにトレンドラインをすぐに追加・カスタマイズできる、聴衆を惹きつける実用的なガイドです。"
---

## **トレンドラインの追加**
Aspose.Slides for PHP via Java は、さまざまなチャートのトレンドラインを管理するシンプルな API を提供します:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータでチャートを追加し、任意のタイプを指定します（この例では ChartType::ClusteredColumn を使用）。
1. チャート系列 1 に指数トレンドラインを追加します。
1. チャート系列 1 に線形トレンドラインを追加します。
1. チャート系列 2 に対数トレンドラインを追加します。
1. チャート系列 2 に移動平均トレンドラインを追加します。
1. チャート系列 3 に多項式トレンドラインを追加します。
1. チャート系列 3 にべきトレンドラインを追加します。
1. 修正したプレゼンテーションを PPTX ファイルに書き込みます。

以下のコードは、トレンドライン付きのチャートを作成するために使用されます。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # クラスタードカラム チャートを作成
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # チャート系列 1 に指数トレンドラインを追加
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # チャート系列 1 に線形トレンドラインを追加
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # チャート系列 2 に対数トレンドラインを追加
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # チャート系列 2 に移動平均トレンドラインを追加
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # チャート系列 3 に多項式トレンドラインを追加
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # チャート系列 3 にべきトレンドラインを追加
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
Aspose.Slides for PHP via Java は、チャートにカスタムラインを追加するシンプルな API を提供します。プレゼンテーションの選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください:

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します
- インデックスを使用してスライドの参照を取得します
- Shapes オブジェクトが提供する AddChart メソッドを使用して新しいチャートを作成します
- Shapes オブジェクトが提供する AddAutoShape メソッドを使用して、ラインタイプの AutoShape を追加します
- シェイプの線の色を設定します
- 修正したプレゼンテーションを PPTX ファイルとして書き込みます

以下のコードは、カスタムライン付きのチャートを作成するために使用されます。
```php
  # Presentation クラスのインスタンスを作成
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


## **よくある質問**

**トレンドラインの「forward」と「backward」の意味は何ですか？**

それらはトレンドラインを前方/後方に延長した長さです。散布図（XY）チャートの場合は軸の単位で、散布図以外の場合はカテゴリ数で表されます。負の値は使用できません。

**プレゼンテーションを PDF や SVG にエクスポートしたり、スライドを画像にレンダリングしたりした場合、トレンドラインは保持されますか？**

はい。Aspose.Slides はプレゼンテーションを [PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/ja/php-java/render-a-slide-as-an-svg-image/) に変換し、チャートを画像としてレンダリングします。トレンドラインはチャートの一部としてこれらの操作中に保持されます。また、チャート自体の画像を [エクスポート](/slides/ja/php-java/create-shape-thumbnails/)するメソッドも利用可能です。