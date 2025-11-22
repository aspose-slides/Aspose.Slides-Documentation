---
title: PHPでPowerPointプレゼンテーションチャートを作成または更新
linktitle: チャート作成
type: docs
weight: 10
url: /ja/php-java/create-chart/
keywords: "チャート作成、散布図、円グラフ、ツリーマップ、株価チャート、箱ひげ図、ヒストグラム、ファンネルチャート、サンバースト、マルチカテゴリチャート、PowerPointプレゼンテーション、Java、Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションでチャートを作成"
---

## 概要

この記事では、**JavaでPowerPointプレゼンテーションチャートを作成**する方法について説明します。また**チャートを更新**することも可能です。以下のトピックをカバーしています。

_チャート_: **標準**
- [Java PowerPointチャート作成](#java-create-powerpoint-chart)
- [Java プレゼンテーションチャート作成](#java-create-presentation-chart)
- [Java PowerPointプレゼンテーションチャート作成](#java-create-powerpoint-presentation-chart)

_チャート_: **散布図**
- [Java 散布図作成](#java-create-scattered-chart)
- [Java PowerPoint散布図作成](#java-create-powerpoint-scattered-chart)
- [Java PowerPointプレゼンテーション散布図作成](#java-create-powerpoint-presentation-scattered-chart)

_チャート_: **円グラフ**
- [Java 円グラフ作成](#java-create-pie-chart)
- [Java PowerPoint円グラフ作成](#java-create-powerpoint-pie-chart)
- [Java PowerPointプレゼンテーション円グラフ作成](#java-create-powerpoint-presentation-pie-chart)

_チャート_: **ツリーマップ**
- [Java ツリーマップ作成](#java-create-tree-map-chart)
- [Java PowerPointツリーマップ作成](#java-create-powerpoint-tree-map-chart)
- [Java PowerPointプレゼンテーションツリーマップ作成](#java-create-powerpoint-presentation-tree-map-chart)

_チャート_: **株価**
- [Java 株価チャート作成](#java-create-stock-chart)
- [Java PowerPoint株価チャート作成](#java-create-powerpoint-stock-chart)
- [Java PowerPointプレゼンテーション株価チャート作成](#java-create-powerpoint-presentation-stock-chart)

_チャート_: **箱ひげ図**
- [Java 箱ひげ図作成](#java-create-box-and-whisker-chart)
- [Java PowerPoint箱ひげ図作成](#java-create-powerpoint-box-and-whisker-chart)
- [Java PowerPointプレゼンテーション箱ひげ図作成](#java-create-powerpoint-presentation-box-and-whisker-chart)

_チャート_: **ファンネル**
- [Java ファンネル作成](#java-create-funnel-chart)
- [Java PowerPointファンネル作成](#java-create-powerpoint-funnel-chart)
- [Java PowerPointプレゼンテーションファンネル作成](#java-create-powerpoint-presentation-funnel-chart)

_チャート_: **サンバースト**
- [Java サンバースト作成](#java-create-sunburst-chart)
- [Java PowerPointサンバースト作成](#java-create-powerpoint-sunburst-chart)
- [Java PowerPointプレゼンテーションサンバースト作成](#java-create-powerpoint-presentation-sunburst-chart)

_チャート_: **ヒストグラム**
- [Java ヒストグラム作成](#java-create-histogram-chart)
- [Java PowerPointヒストグラム作成](#java-create-powerpoint-histogram-chart)
- [Java PowerPointプレゼンテーションヒストグラム作成](#java-create-powerpoint-presentation-histogram-chart)

_チャート_: **レーダー**
- [Java レーダー作成](#java-create-radar-chart)
- [Java PowerPointレーダー作成](#java-create-powerpoint-radar-chart)
- [Java PowerPointプレゼンテーションレーダー作成](#java-create-powerpoint-presentation-radar-chart)

_チャート_: **マルチカテゴリ**
- [Java マルチカテゴリ作成](#java-create-multi-category-chart)
- [Java PowerPointマルチカテゴリ作成](#java-create-powerpoint-multi-category-chart)
- [Java PowerPointプレゼンテーションマルチカテゴリ作成](#java-create-powerpoint-presentation-multi-category-chart)

_チャート_: **マップ**
- [Java マップ作成](#java-create-map-chart)
- [Java PowerPointマップ作成](#java-create-powerpoint-map-chart)
- [Java PowerPointプレゼンテーションマップ作成](#java-create-powerpoint-presentation-map-chart)

_アクション_: **チャートを更新**
- [Java PowerPointチャート更新](#java-update-powerpoint-chart)
- [Java プレゼンテーションチャート更新](#java-update-presentation-chart)
- [Java PowerPointプレゼンテーションチャート更新](#java-update-powerpoint-presentation-chart)


## **チャートの作成**
チャートはデータをすばやく可視化し、表やスプレッドシートからはすぐに分からない洞察を得るのに役立ちます。 


**なぜチャートを作成するのか？**

チャートを使用することで

* 大量のデータをプレゼンテーションの単一スライドに集約・要約できる
* データのパターンやトレンドを明らかにできる
* 時間経過や特定の測定単位に対するデータの方向性や勢いを推測できる
* 外れ値、異常、誤り、意味不明なデータなどを検出できる
* 複雑なデータを効果的に伝えることができる

PowerPoint では「挿入」機能でテンプレートを利用して様々な種類のチャートを作成できます。Aspose.Slides を使用すれば、一般的なチャートタイプに基づく標準チャートやカスタムチャートを作成できます。 

{{% alert color="primary" %}} 

チャート作成をサポートするために、Aspose.Slides は [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType) クラスを提供します。このクラスのフィールドは各種チャートタイプに対応しています。

{{% /alert %}} 

### **標準チャートの作成**

_手順: Chart作成_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>手順:</em> PowerPointチャート作成 </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>手順:</em> プレゼンテーションチャート作成 </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>手順:</em> PowerPointプレゼンテーションチャート作成 </strong></a>

_コード手順:_

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. データを付与し、希望するチャートタイプを指定してチャートを追加します。  
4. チャートにタイトルを付けます。  
5. チャートデータのワークシートにアクセスします。  
6. 既定の系列とカテゴリをすべてクリアします。  
7. 新しい系列とカテゴリを追加します。  
8. 系列用の新しいデータを追加します。  
9. 系列に塗りつぶし色を設定します。  
10. 系列にラベルを追加します。  
11. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の PHP コードは標準チャートの作成方法を示しています:
```php
  # PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # デフォルトデータでチャートを追加します
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # チャートのタイトルを設定します
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # 最初の系列に値を表示するよう設定します
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # チャートデータシートのインデックスを設定します
    $defaultWorksheetIndex = 0;
    # チャートデータのワークシートを取得します
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # デフォルトで生成された系列とカテゴリを削除します
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # 新しい系列を追加します
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # 新しいカテゴリを追加します
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # 最初のチャート系列を取得します
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 系列データを設定します
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # 系列の塗りつぶし色を設定します
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 2 番目のチャート系列を取得します
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 系列データを設定します
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # 系列の塗りつぶし色を設定します
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # 新しい系列の各カテゴリにカスタムラベルを作成します
    # 最初のラベルにカテゴリ名を表示するよう設定します
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # 3 番目のラベルに値を表示します
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # チャート付きのプレゼンテーションを保存します
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **散布図の作成**
散布図（別名散布プロットまたは X‑Y グラフ）は、2 つの変数間のパターンや相関関係を確認する際に使用されます。 

散布図を使用する状況

* 対になった数値データがあるとき
* 2 つの変数が相関しやすいとき
* 2 変数の関係性を判定したいとき
* 従属変数に対して独立変数が複数の値を持つとき

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>手順:</em> 散布図作成 </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>手順:</em> PowerPoint散布図作成 </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>手順:</em> PowerPointプレゼンテーション散布図作成 </strong></a>

1. 上記の「[標準チャートの作成](#creating-normal-charts)」手順に従ってください。  
2. 3 番目の手順で、データを付与し、チャートタイプを以下のいずれかに指定します  
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _散布図（マーカーあり）_  
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _滑らかな線とマーカー付き散布図_  
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _滑らかな線のみの散布図_  
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _直線とマーカー付き散布図_  
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _直線のみの散布図_

以下の PHP コードは異なるマーカー系列を持つ散布図の作成例です:
```php
  # PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # デフォルトチャートを作成
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # デフォルトのチャートデータワークシートインデックスを取得
    $defaultWorksheetIndex = 0;
    # チャートデータのワークシートを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # デモ系列を削除
    $chart->getChartData()->getSeries()->clear();
    # 新しい系列を追加
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # 最初のチャート系列を取得
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 系列に新しいポイント (1:3) を追加
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # 新しいポイント (2:10) を追加
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # 系列のタイプを変更
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # チャート系列のマーカーを変更
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # 2 番目のチャート系列を取得
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # そこに新しいポイント (5:2) を追加
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # 新しいポイント (3:1) を追加
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # 新しいポイント (2:2) を追加
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # 新しいポイント (5:1) を追加
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # チャート系列のマーカーを変更
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **円グラフの作成**

円グラフは、特にカテゴリラベルと数値がペアになったデータの全体に対する比率を示すのに適しています。カテゴリやパーツが多数ある場合は、棒グラフの使用を検討してください。

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>手順:</em> 円グラフ作成 </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>手順:</em> PowerPoint円グラフ作成 </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>手順:</em> PowerPointプレゼンテーション円グラフ作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（この場合は [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Pie）を指定してチャートを追加します。  
4. チャートデータ [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) にアクセスします。  
5. 既定の系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 系列用の新しいデータを追加します。  
8. 円グラフのセクターごとにポイントとカスタムカラーを追加します。  
9. 系列のラベルを設定します。  
10. 系列ラベル用のリーダーラインを設定します。  
11. 円グラフスライドの回転角度を設定します。  
12. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の PHP コードは円グラフの作成方法を示しています:
```php
  # PPTX ファイルを表すプレゼンテーションクラスをインスタンス化します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $slides = $pres->getSlides()->get_Item(0);
    # デフォルトデータでチャートを追加します
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # チャートのタイトルを設定します
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # 最初の系列に値を表示するよう設定します
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # チャートデータシートのインデックスを設定します
    $defaultWorksheetIndex = 0;
    # チャートデータのワークシートを取得します
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # デフォルトで生成された系列とカテゴリを削除します
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 新しいカテゴリを追加します
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # 新しい系列を追加します
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # 系列データを設定します
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # 新しいバージョンでは機能しません
    # Adding new points and setting sector color
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # セクタの枠線を設定します
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # セクタの枠線を設定します
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # セクタの枠線を設定します
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # 新しい系列の各カテゴリにカスタムラベルを作成します
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
    # チャートのリーダーラインを表示します
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # パイチャートセクタの回転角度を設定します
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # チャート付きプレゼンテーションを保存します
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **折れ線グラフの作成**

折れ線グラフ（別名折れ線グラフ）は、時間経過に伴う値の変化を示すのに最適です。折れ線グラフを使うと、複数のデータを同時に比較したり、トレンドや異常をハイライトしたりできます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. デフォルトデータと希望のタイプ（この場合は `ChartType::Line`）を指定してチャートを追加します。  
1. チャートデータ IChartDataWorkbook にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいデータを追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の PHP コードは折れ線グラフの作成方法を示しています:
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


デフォルトでは、折れ線グラフのポイントは直線で結ばれます。破線で結びたい場合は、以下のように破線タイプを指定できます:
```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```


### **ツリーマップチャートの作成**

ツリーマップチャートは、売上データなどでカテゴリごとの相対的なサイズを示し、同時に大きな寄与項目に注意を引きつけたいときに適しています。 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>手順:</em> ツリーマップ作成 </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>手順:</em> PowerPointツリーマップ作成 </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>手順:</em> PowerPointプレゼンテーションツリーマップ作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（この場合は [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).TreeMap）を指定してチャートを追加します。  
4. チャートデータ [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) にアクセスします。  
5. 既定の系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 系列用の新しいデータを追加します。  
8. 変更したプレゼンテーションを PPTX ファイルとして保存します

以下の PHP コードはツリーマップチャートの作成方法を示しています:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # ブランチ 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # ブランチ 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
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


### **株価チャートの作成**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>手順:</em> 株価チャート作成 </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>手順:</em> PowerPoint株価チャート作成 </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>手順:</em> PowerPointプレゼンテーション株価チャート作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).OpenHighLowClose）を指定してチャートを追加します。  
4. チャートデータ [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) にアクセスします。  
5. 既定の系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 系列用の新しいデータを追加します。  
8. HiLowLines の書式を指定します。  
9. 変更したプレゼンテーションを PPTX ファイルとして保存します

株価チャート作成サンプル PHP コード:
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
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
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


### **箱ひげ図の作成**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>手順:</em> 箱ひげ図作成 </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>手順:</em> PowerPoint箱ひげ図作成 </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>手順:</em> PowerPointプレゼンテーション箱ひげ図作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).BoxAndWhisker）を指定してチャートを追加します。  
4. チャートデータ [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) にアクセスします。  
5. 既定の系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 系列用の新しいデータを追加します。  
8. 変更したプレゼンテーションを PPTX ファイルとして保存します

以下の PHP コードは箱ひげ図の作成方法を示しています:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
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


### **ファンネルチャートの作成**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>手順:</em> ファンネル作成 </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>手順:</em> PowerPointファンネル作成 </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>手順:</em> PowerPointプレゼンテーションファンネル作成 </strong></a>


1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Funnel）を指定してチャートを追加します。  
4. 変更したプレゼンテーションを PPTX ファイルとして保存します

ファンネルチャート作成サンプル PHP コード:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
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


### **サンバーストチャートの作成**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>手順:</em> サンバースト作成 </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>手順:</em> PowerPointサンバースト作成 </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>手順:</em> PowerPointプレゼンテーションサンバースト作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（この場合は [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).sunburst）を指定してチャートを追加します。  
4. 変更したプレゼンテーションを PPTX ファイルとして保存します

サンバーストチャート作成サンプル PHP コード:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # ブランチ 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # ブランチ 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
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


### **ヒストグラムチャートの作成**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>手順:</em> ヒストグラム作成 </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>手順:</em> PowerPointヒストグラム作成 </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>手順:</em> PowerPointプレゼンテーションヒストグラム作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Histogram）を指定してチャートを追加します。  
4. チャートデータ [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) にアクセスします。  
5. 既定の系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 変更したプレゼンテーションを PPTX ファイルとして保存します

ヒストグラムチャート作成サンプル PHP コード:
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


### **レーダーチャートの作成**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>手順:</em> レーダー作成 </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>手順:</em> PowerPointレーダー作成 </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>手順:</em> PowerPointプレゼンテーションレーダー作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. データを付与し、希望のチャートタイプ（この場合は `ChartType::Radar`）を指定してチャートを追加します。  
4. 変更したプレゼンテーションを PPTX ファイルとして保存します

レーダーチャート作成サンプル PHP コード:
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


### **マルチカテゴリチャートの作成**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>手順:</em> マルチカテゴリ作成 </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>手順:</em> PowerPointマルチカテゴリ作成 </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>手順:</em> PowerPointプレゼンテーションマルチカテゴリ作成 </strong></a>

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).ClusteredColumn）を指定してチャートを追加します。  
4. チャートデータ [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) にアクセスします。  
5. 既定の系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 系列用の新しいデータを追加します。  
8. 変更したプレゼンテーションを PPTX ファイルとして保存します

マルチカテゴリチャート作成サンプル PHP コード:
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
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # 系列を追加
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # チャート付きプレゼンテーションを保存
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **マップチャートの作成**

マップチャートは、領域ごとのデータを可視化する手段です。地域別のデータや数値を比較する際に最適です。

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>手順:</em> マップ作成 </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>手順:</em> PowerPointマップ作成 </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>手順:</em> PowerPointプレゼンテーションマップ作成 </strong></a>

マップチャート作成サンプル PHP コード:
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


### **組み合わせチャートの作成**

組み合わせチャート（コンボチャート）は、1 つのグラフに 2 つ以上のチャートタイプを組み合わせたものです。これにより、複数のデータセット間の関係や違いを強調・比較できます。

![The combination chart](combination_chart.png)

以下の PHP コードは、上記の組み合わせチャートを PowerPoint プレゼンテーションで作成する方法を示します:
```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // チャートのタイトルを設定します。
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // チャートの凡例を設定します。
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // デフォルトで生成された系列とカテゴリを削除します。
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // 新しいカテゴリを追加します。
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // 最初の系列を追加します。
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // 水平軸を設定します。
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // 垂直軸を設定します。
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // 垂直軸の主要グリッド線の色を設定します。
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // セカンダリ水平軸を設定します。
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // セカンダリ垂直軸を設定します。
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```


## **チャートの更新**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>手順:</em> PowerPointチャート更新 </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>手順:</em> プレゼンテーションチャート更新 </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>手順:</em> PowerPointプレゼンテーションチャート更新 </strong></a>

1. 更新対象のチャートが含まれるプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. すべてのシェイプを走査して目的のチャートを見つけます。  
4. チャートデータのワークシートにアクセスします。  
5. 系列データを変更してデータを更新します。  
6. 新しい系列を追加し、データを入力します。  
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。

チャート更新サンプル PHP コード:
```php
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # デフォルトデータでチャートを取得
    $chart = $sld->getShapes()->get_Item(0);
    # チャートデータシートのインデックスを設定
    $defaultWorksheetIndex = 0;
    # チャートデータのワークシートを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # チャートのカテゴリ名を変更
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # 最初のチャート系列を取得
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 系列データを更新中
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// シリーズ名を変更

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # 2番目のチャート系列を取得
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 系列データを更新中
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// シリーズ名を変更

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # 新しい系列を追加
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # 3番目のチャート系列を取得
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # 系列データを設定中
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # チャート付きプレゼンテーションを保存
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **チャートのデータ範囲設定**

チャートのデータ範囲を設定する手順:

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. すべてのシェイプを走査して目的のチャートを見つけます。  
4. チャートデータにアクセスし、範囲を設定します。  
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

データ範囲設定サンプル PHP コード:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **チャートでのデフォルトマーカー使用**

チャートでデフォルトマーカーを使用すると、各系列に自動的に異なるマーカーシンボルが割り当てられます。

デフォルトマーカー自動設定サンプル PHP コード:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # 2番目のチャート系列を取得
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # 系列データを設定中
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
