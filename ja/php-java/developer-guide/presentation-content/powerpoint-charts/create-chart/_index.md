---
title: PowerPointプレゼンテーションチャートの作成または更新
linktitle: チャートを作成
type: docs
weight: 10
url: /php-java/create-chart/
keywords: "チャートを作成, 散布図, 円グラフ, ツリーマップチャート, 株価チャート, 箱ひげ図, ヒストグラムチャート, ファネルチャート, サンバーストチャート, マルチカテゴリチャート, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションでチャートを作成"
---

## 概要

この記事では、Javaで**PowerPointプレゼンテーションチャートを作成する方法**について説明します。また、**チャートを更新する方法**にも触れます。以下のトピックをカバーしています。

_チャート_: **通常**
- [JavaでPowerPointチャートを作成](#java-create-powerpoint-chart)
- [Javaでプレゼンテーションチャートを作成](#java-create-presentation-chart)
- [JavaでPowerPointプレゼンテーションチャートを作成](#java-create-powerpoint-presentation-chart)

_チャート_: **散布**
- [Javaで散布図を作成](#java-create-scattered-chart)
- [JavaでPowerPoint散布図を作成](#java-create-powerpoint-scattered-chart)
- [JavaでPowerPointプレゼンテーション散布図を作成](#java-create-powerpoint-presentation-scattered-chart)

_チャート_: **円グラフ**
- [Javaで円グラフを作成](#java-create-pie-chart)
- [JavaでPowerPoint円グラフを作成](#java-create-powerpoint-pie-chart)
- [JavaでPowerPointプレゼンテーション円グラフを作成](#java-create-powerpoint-presentation-pie-chart)

_チャート_: **ツリーマップ**
- [Javaでツリーマップチャートを作成](#java-create-tree-map-chart)
- [JavaでPowerPointツリーマップチャートを作成](#java-create-powerpoint-tree-map-chart)
- [JavaでPowerPointプレゼンテーションツリーマップチャートを作成](#java-create-powerpoint-presentation-tree-map-chart)

_チャート_: **株価**
- [Javaで株価チャートを作成](#java-create-stock-chart)
- [JavaでPowerPoint株価チャートを作成](#java-create-powerpoint-stock-chart)
- [JavaでPowerPointプレゼンテーション株価チャートを作成](#java-create-powerpoint-presentation-stock-chart)

_チャート_: **箱ひげ図**
- [Javaで箱ひげ図を作成](#java-create-box-and-whisker-chart)
- [JavaでPowerPoint箱ひげ図を作成](#java-create-powerpoint-box-and-whisker-chart)
- [JavaでPowerPointプレゼンテーション箱ひげ図を作成](#java-create-powerpoint-presentation-box-and-whisker-chart)

_チャート_: **ファネル**
- [Javaでファネルチャートを作成](#java-create-funnel-chart)
- [JavaでPowerPointファネルチャートを作成](#java-create-powerpoint-funnel-chart)
- [JavaでPowerPointプレゼンテーションファネルチャートを作成](#java-create-powerpoint-presentation-funnel-chart)

_チャート_: **サンバースト**
- [Javaでサンバーストチャートを作成](#java-create-sunburst-chart)
- [JavaでPowerPointサンバーストチャートを作成](#java-create-powerpoint-sunburst-chart)
- [JavaでPowerPointプレゼンテーションサンバーストチャートを作成](#java-create-powerpoint-presentation-sunburst-chart)

_チャート_: **ヒストグラム**
- [Javaでヒストグラムチャートを作成](#java-create-histogram-chart)
- [JavaでPowerPointヒストグラムチャートを作成](#java-create-powerpoint-histogram-chart)
- [JavaでPowerPointプレゼンテーションヒストグラムチャートを作成](#java-create-powerpoint-presentation-histogram-chart)

_チャート_: **レーダー**
- [Javaでレーダーチャートを作成](#java-create-radar-chart)
- [JavaでPowerPointレーダーチャートを作成](#java-create-powerpoint-radar-chart)
- [JavaでPowerPointプレゼンテーションレーダーチャートを作成](#java-create-powerpoint-presentation-radar-chart)

_チャート_: **マルチカテゴリ**
- [Javaでマルチカテゴリチャートを作成](#java-create-multi-category-chart)
- [JavaでPowerPointマルチカテゴリチャートを作成](#java-create-powerpoint-multi-category-chart)
- [JavaでPowerPointプレゼンテーションマルチカテゴリチャートを作成](#java-create-powerpoint-presentation-multi-category-chart)

_チャート_: **マップ**
- [Javaでマップチャートを作成](#java-create-map-chart)
- [JavaでPowerPointマップチャートを作成](#java-create-powerpoint-map-chart)
- [JavaでPowerPointプレゼンテーションマップチャートを作成](#java-create-powerpoint-presentation-map-chart)

_アクション_: **チャートの更新**
- [JavaでPowerPointチャートを更新](#java-update-powerpoint-chart)
- [Javaでプレゼンテーションチャートを更新](#java-update-presentation-chart)
- [JavaでPowerPointプレゼンテーションチャートを更新](#java-update-powerpoint-presentation-chart)


## **チャートを作成**

チャートは人々がデータを迅速に視覚化し、表やスプレッドシートからはすぐに明らかでない洞察を得るのに役立ちます。 


**チャートを作成する理由**

チャートを使用することで、あなたは

* プレゼンテーションの単一スライドに大量のデータを集約、凝縮、または要約する
* データのパターンや傾向を明らかにする
* 時間経過や特定の測定単位に関するデータの方向性やモメンタムを推測する
* 外れ値、異常、逸脱、エラー、意味のないデータなどを指摘する
* 複雑なデータを伝えるまたは提示する

PowerPointでは、挿入機能を介してチャートを作成できます。この機能は、さまざまなタイプのチャートを設計するためのテンプレートを提供します。Aspose.Slidesを使用すると、通常のチャート（一般的なチャートタイプに基づいた）とカスタムチャートを作成できます。

{{% alert color="primary" %}} 

チャートを作成することを可能にするために、Aspose.Slidesは[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType)クラスを提供します。このクラス内のフィールドは、異なるチャートタイプに対応しています。

{{% /alert %}} 

### **通常のチャートを作成する**

_手順: チャートを作成_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>手順:</em> PowerPointチャートを作成 </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>手順:</em> プレゼンテーションチャートを作成 </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>手順:</em> PowerPointプレゼンテーションチャートを作成 </strong></a>

_コード手順:_

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドのリファレンスを取得します。
3. いくつかのデータを持つチャートを追加し、お好みのチャートタイプを指定します。 
4. チャートのタイトルを追加します。 
5. チャートデータワークシートにアクセスします。
6. すべてのデフォルト系列とカテゴリをクリアします。
7. 新しい系列とカテゴリを追加します。
8. チャート系列のために新しいチャートデータを追加します。
9. チャート系列のために塗りつぶし色を追加します。
10. チャート系列のためにラベルを追加します。 
11. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このPHPコードは、通常のチャートを作成する方法を示しています：

```php
  # PPTXファイルを表すプレゼンテーションクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # デフォルトデータを持つチャートを追加
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # チャートタイトルを設定
    $chart->getChartTitle()->addTextFrameForOverriding("サンプルタイトル");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # 最初の系列に値を表示するよう設定
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # チャートデータシートのインデックスを設定
    $defaultWorksheetIndex = 0;
    # チャートデータワークシートを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # デフォルト生成された系列とカテゴリを削除
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # 新しい系列を追加
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "系列 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "系列 2"), $chart->getType());
    # 新しいカテゴリを追加
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "カテゴリ 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "カテゴリ 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "カテゴリ 3"));
    # 最初のチャート系列を取得
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 系列データをポピュレート
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # 系列の塗りつぶし色を設定
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 二番目のチャート系列を取得
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 系列データをポピュレート
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # 系列の塗りつぶし色を設定
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # 新しい系列の各カテゴリにカスタムラベルを作成
    # 最初のラベルにカテゴリ名を表示するよう設定
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # 三番目のラベルに値を表示するよう設定
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # チャートを持つプレゼンテーションを保存
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **散布チャートを作成する**
散布チャート（散布図またはx-yグラフとも呼ばれる）は、パターンを確認したり、2つの変数間の相関関係を示したりするために使用されます。

次のような場合に散布チャートを使用することをお勧めします。

* 対になった数値データがあるとき
* よく組み合わさる2つの変数があるとき
* 2つの変数が関連しているかどうかを判断したいとき
* 独立変数が従属変数に対して複数の値を持つとき

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>手順:</em> 散布チャートを作成 </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>手順:</em> PowerPoint散布チャートを作成 </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>手順:</em> PowerPointプレゼンテーション散布チャートを作成 </strong></a>

1. 上記の[通常のチャートを作成する](#creating-normal-charts)手順に従ってください。
2. 三番目の手順では、いくつかのデータを持つチャートを追加し、次のいずれかの型のチャートタイプを指定します。
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _散布チャートを表します。_
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _データマーカーが付いた曲線でつながれた散布チャートを表します。_
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _データマーカーなしで曲線でつながれた散布チャートを表します。_
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _データマーカーが付いた直線でつながれた散布チャートを表します。_
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _データマーカーなしで直線でつながれた散布チャートを表します。_

このPHPコードは、異なるマーカーの系列を持つ散布チャートを作成する方法を示しています：

```php
  # PPTXファイルを表すプレゼンテーションクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # デフォルトチャートを作成
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # デフォルトチャートデータワークシートインデックスを取得
    $defaultWorksheetIndex = 0;
    # チャートデータワークシートを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # デモシリーズを削除
    $chart->getChartData()->getSeries()->clear();
    # 新しい系列を追加
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "系列 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "系列 2"), $chart->getType());
    # 最初のチャート系列を取得
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 系列に新しいポイント(1:3)を追加
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # 新しいポイント(2:10)を追加
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # 系列タイプを変更
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # チャート系列マーカーを変更
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # 二番目のチャート系列を取得
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 新しいポイント(5:2)を追加
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # 新しいポイント(3:1)を追加
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # 新しいポイント(2:2)を追加
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # 新しいポイント(5:1)を追加
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # チャート系列マーカーを変更
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **円グラフを作成する**

円グラフはデータの部分対全体の関係を示すのに最適です。特に、データが数値のラベルを含むカテゴリを持つ場合に有効です。ただし、データに多くの部分やラベルが含まれる場合は、代わりに棒グラフを使用することを検討してください。

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>手順:</em> 円グラフを作成 </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>手順:</em> PowerPoint円グラフを作成 </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>手順:</em> PowerPointプレゼンテーション円グラフを作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドのリファレンスを取得します。
3. デフォルトデータを持つチャートを追加し、希望の型（この場合は[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Pie）とともに追加します。
4. チャートデータの[IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)にアクセスします。
5. デフォルトの系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. チャート系列のために新しいチャートデータを追加します。
8. チャートの新しいポイントを追加し、円グラフのセクターにカスタム色を追加します。
9. 系列のラベルを設定します。
10. 系列ラベルのリーダーラインを設定します。
11. 円グラフスライドの回転角度を設定します。
12. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このPHPコードは、円グラフを作成する方法を示しています：

```php
  # PPTXファイルを表すプレゼンテーションクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slides = $pres->getSlides()->get_Item(0);
    # デフォルトデータを持つチャートを追加
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # チャートタイトルを設定
    $chart->getChartTitle()->addTextFrameForOverriding("サンプルタイトル");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # 最初の系列に値を表示するよう設定
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # チャートデータシートのインデックスを設定
    $defaultWorksheetIndex = 0;
    # チャートデータワークシートを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # デフォルト生成されたシリーズとカテゴリを削除
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 新しいカテゴリを追加
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "第1四半期"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "第2四半期"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "第3四半期"));
    # 新しい系列を追加
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "系列 1"), $chart->getType());
    # 系列データをポピュレート
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # 新しいポイントを追加し、セクターの色を設定
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # セクターの境界を設定
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # セクターの境界を設定
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # セクターの境界を設定
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # 新しい系列の各カテゴリにカスタムラベルを作成
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # チャートのリーダーラインを表示
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # 円グラフのセクターの回転角度を設定
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # チャートを持つプレゼンテーションを保存
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **折れ線チャートを作成する**

折れ線チャート（折れ線グラフとも呼ばれる）は、時間の経過による値の変化を示す場合に最適です。折れ線チャートを使用すると、多くのデータを一度に比較したり、時間の経過に伴う変化や傾向を追ったり、データ系列の異常を強調表示したりできます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを介してスライドのリファレンスを取得します。
1. デフォルトデータを持つチャートを追加し、希望の型（この場合は`ChartType::Line`）とともに追加します。
1. チャートデータのIChartDataWorkbookにアクセスします。
1. デフォルトの系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列のために新しいチャートデータを追加します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このPHPコードは、折れ線チャートを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

デフォルトでは、折れ線チャートのポイントは直線で結ばれています。ポイントをダッシュで結ぶようにしたい場合は、次のようにお好みのダッシュタイプを指定できます：

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **ツリーマップチャートを作成する**

ツリーマップチャートは、データのカテゴリの相対的なサイズを示し、（同時に）各カテゴリに大きな寄与をするアイテムに迅速に注意を引くために、販売データに最適です。

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>手順:</em> ツリーマップチャートを作成 </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>手順:</em> PowerPointツリーマップチャートを作成 </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>手順:</em> PowerPointプレゼンテーションツリーマップチャートを作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドのリファレンスを取得します。
3. デフォルトデータを持つチャートを追加し、希望の型（この場合は[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).TreeMap）とともに追加します。
4. チャートデータの[IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)にアクセスします。
5. デフォルトの系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. チャート系列のために新しいチャートデータを追加します。
8. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このPHPコードは、ツリーマップチャートを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # ブランチ1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "葉 1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "茎 1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "ブランチ 1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "葉 2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "葉 3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "茎 2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "葉 4"));
    # ブランチ2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "葉 5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "茎 3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "ブランチ 2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "葉 6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "葉 7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "茎 4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "葉 8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **株価チャートを作成する**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>手順:</em> 株価チャートを作成 </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>手順:</em> PowerPoint株価チャートを作成 </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>手順:</em> PowerPointプレゼンテーション株価チャートを作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドのリファレンスを取得します。
3. デフォルトデータを持つチャートを追加し、希望の型（[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).OpenHighLowClose）とともに追加します。
4. チャートデータの[IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)にアクセスします。
5. デフォルトの系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. チャート系列のために新しいチャートデータを追加します。
8. HiLowLinesフォーマットを指定します。
9. 修正したプレゼンテーションをPPTXファイルに書き込みます。

株価チャートを作成するために使用されるサンプルPHPコード：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "オープン"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "ハイ"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "ロー"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "クローズ"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **箱ひげ図を作成する**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>手順:</em> 箱ひげ図を作成 </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>手順:</em> PowerPoint箱ひげ図を作成 </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>手順:</em> PowerPointプレゼンテーション箱ひげ図を作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドのリファレンスを取得します。
3. デフォルトデータを持つチャートを追加し、希望の型（[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).BoxAndWhisker）とともに追加します。
4. チャートデータの[IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)にアクセスします。
5. デフォルトの系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. チャート系列のために新しいチャートデータを追加します。
8. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このPHPコードは、箱ひげ図を作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "カテゴリ 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "カテゴリ 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "カテゴリ 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "カテゴリ 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "カテゴリ 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "カテゴリ 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ファネルチャートを作成する**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>手順:</em> ファネルチャートを作成 </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>手順:</em> PowerPointファネルチャートを作成 </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>手順:</em> PowerPointプレゼンテーションファネルチャートを作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドのリファレンスを取得します。
3. デフォルトデータを持つチャートを追加し、希望の型（[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Funnel）とともに追加します。
4. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このPHPコードは、ファネルチャートを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "カテゴリ 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "カテゴリ 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "カテゴリ 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "カテゴリ 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "カテゴリ 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "カテゴリ 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **サンバーストチャートを作成する**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>手順:</em> サンバーストチャートを作成 </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>手順:</em> PowerPointサンバーストチャートを作成 </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>手順:</em> PowerPointプレゼンテーションサンバーストチャートを作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドのリファレンスを取得します。
3. デフォルトデータを持つチャートを追加し、希望の型（この場合は[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).sunburst）とともに追加します。
4. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このPHPコードは、サンバーストチャートを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # ブランチ1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "葉 1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "茎 1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "ブランチ 1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "葉 2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "葉 3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "茎 2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "葉 4"));
    # ブランチ2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "葉 5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "茎 3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "ブランチ 2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "葉 6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "葉 7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "茎 4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "葉 8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ヒストグラムチャートを作成する**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>手順:</em> ヒストグラムチャートを作成 </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>手順:</em> PowerPointヒストグラムチャートを作成 </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>手順:</em> PowerPointプレゼンテーションヒストグラムチャートを作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドのリファレンスを取得します。
3. デフォルトデータを持つチャートを追加し、希望の型（[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Histogram）とともに追加します。
4. チャートデータの[IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)にアクセスします。
5. デフォルトの系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このPHPコードは、ヒストグラムチャートを作成する方法を示しています：

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **レーダーチャートを作成する**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>手順:</em> レーダーチャートを作成 </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>手順:</em> PowerPointレーダーチャートを作成 </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>手順:</em> PowerPointプレゼンテーションレーダーチャートを作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドのリファレンスを取得します。 
3. データを持つチャートを追加し、希望のチャートタイプ（この場合は`ChartType::Radar`）を指定します。
4. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このPHPコードは、レーダーチャートを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **マルチカテゴリチャートを作成する**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>手順:</em> マルチカテゴリチャートを作成 </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>手順:</em> PowerPointマルチカテゴリチャートを作成 </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>手順:</em> PowerPointプレゼンテーションマルチカテゴリチャートを作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドのリファレンスを取得します。 
3. デフォルトデータを持つチャートを追加し、希望の型（[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).ClusteredColumn）とともに追加します。
4. チャートデータの[IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)にアクセスします。
5. デフォルトの系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. チャート系列のために新しいチャートデータを追加します。
8. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このPHPコードは、マルチカテゴリチャートを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "グループ 1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "グループ 2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "グループ 3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "グループ 4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # 系列を追加
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "系列 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # チャートを持つプレゼンテーションを保存
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **マップチャートを作成する**

マップチャートは、データを含むエリアの視覚化です。マップチャートは、地理的領域間のデータや値を比較するのに最適です。

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>手順:</em> マップチャートを作成 </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>手順:</em> PowerPointマップチャートを作成 </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>手順:</em> PowerPointプレゼンテーションマップチャートを作成 </strong></a>

このPHPコードは、マップチャートを作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **組み合わせチャートを作成する**

組み合わせチャート（またはコンボチャート）は、2つ以上のチャートを単一のグラフで組み合わせたものです。このようなチャートを使用すると、2セット以上のデータの間の違いを強調表示、比較、または確認できます。この方法で、データセット間の関係を確認できます（あれば）。

![combination-chart-ppt](combination-chart-ppt.png)

このPHPコードは、PowerPointで組み合わせチャートを作成する方法を示しています：

```php

```

## **チャートの更新**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>手順:</em> PowerPointチャートを更新 </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>手順:</em> プレゼンテーションチャートを更新 </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>手順:</em> PowerPointプレゼンテーションチャートを更新 </strong></a>

1. 更新したいチャートが含まれているプレゼンテーションを表す[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスをインスタンス化します。
2. インデックスを使用してスライドのリファレンスを取得します。
3. すべてのシェイプをトラバースして、目的のチャートを見つけます。
4. チャートデータワークシートにアクセスします。
5. 系列データを変更することによりチャートデータの系列を修正します。
6. 新しい系列を追加し、その中にデータをポピュレートします。
7. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このPHPコードは、チャートを更新する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # デフォルトデータを持つチャートを取得
    $chart = $sld->getShapes()->get_Item(0);
    # チャートデータシートのインデックスを設定
    $defaultWorksheetIndex = 0;
    # チャートデータワークシートを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # チャートカテゴリ名を変更
    $fact->getCell($defaultWorksheetIndex, 1, 0, "修正されたカテゴリ 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "修正されたカテゴリ 2");
    # 最初のチャート系列を取得
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 系列データを更新
    $fact->getCell($defaultWorksheetIndex, 0, 1, "新規系列1");// 系列名を修正

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # 二番目のチャート系列を取得
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 系列データを更新
    $fact->getCell($defaultWorksheetIndex, 0, 2, "新規系列2");// 系列名を修正

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # 新しい系列を追加
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "系列 3