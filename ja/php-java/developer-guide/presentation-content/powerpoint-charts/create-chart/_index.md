---
title: PHPでPowerPointプレゼンテーションのチャートを作成または更新
linktitle: チャートの作成または更新
type: docs
weight: 10
url: /ja/php-java/create-chart/
keywords:
- チャートを追加
- チャートを作成
- チャートを編集
- チャートを変更
- チャートを更新
- 散布図
- 円グラフ
- 折れ線グラフ
- ツリーマップチャート
- 株価チャート
- 箱ひげ図
- ファンネルチャート
- サンバーストチャート
- ヒストグラムチャート
- レーダーチャート
- マルチカテゴリチャート
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint プレゼンテーションのチャートを作成・カスタマイズします。実用的なコード例でチャートの追加、書式設定、編集が可能です。"
---
## **概要**

この記事では、Aspose.Slides を使用してチャートを作成およびカスタマイズする方法について包括的なガイドを提供します。スライドにプログラムでチャートを追加し、データを設定し、特定のデザイン要件に合わせてさまざまな書式設定オプションを適用する方法を学びます。記事全体で、プレゼンテーションとチャート オブジェクトの初期化からシリーズ、軸、凡例の構成まで、各手順を示す詳細なコード例が示されています。このガイドに従うことで、動的なチャート生成をアプリケーションに統合し、データ主導のプレゼンテーション作成プロセスを効率化する方法を確実に理解できます。

## **チャートの作成**

チャートは、データを迅速に視覚化し、表やスプレッドシートからはすぐにはわからない洞察を得るのに役立ちます。

**チャートを作成する理由**

チャートを使用すると、次のことが可能です。

* プレゼンテーションの 1 つのスライドに大量のデータを集約、要約、またはまとめる
* データのパターンや傾向を明らかにする
* 時間の経過や特定の測定単位に対するデータの方向性と勢いを推測する
* 異常値、偏差、エラー、意味のないデータなどを発見する
* 複雑なデータを伝達または提示する

PowerPoint では、*挿入* 機能を使用して多数のチャート テンプレートからデザインできます。Aspose.Slides を使用すれば、一般的なチャート タイプに基づく通常のチャートとカスタム チャートの両方を作成できます。

{{% alert color="info" title="Note" %}}
チャートを作成するには、[ChartType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/) クラスを使用します。このクラスのフィールドはさまざまなチャート タイプに対応しています。
{{% /alert %}}

### **クラスター化縦棒グラフの作成**

このセクションでは、Aspose.Slides を使用してクラスター化縦棒グラフを作成する方法を説明します。プレゼンテーションの初期化、チャートの追加、タイトル、データ、シリーズ、カテゴリ、スタイリングなどの要素のカスタマイズ方法を学びます。以下の手順に従って、標準的なクラスター化縦棒グラフがどのように生成されるかをご確認ください。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドへの参照を取得します。
1. データを含むチャートを追加し、`ChartType::ClusteredColumn` タイプを指定します。
1. チャートにタイトルを追加します。
1. チャートのデータ ワークシートにアクセスします。
1. 既定のシリーズおよびカテゴリをすべてクリアします。
1. 新しいシリーズとカテゴリを追加します。
1. チャート シリーズ用の新しいデータを追加します。
1. チャート シリーズに塗りつぶし色を適用します。
1. チャート シリーズにラベルを追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、クラスター化縦棒グラフの作成方法を示しています:

```php
  # PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # デフォルト データでチャートを追加します
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # チャートのタイトルを設定します
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # 最初のシリーズに値を表示するよう設定します
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # チャート データ シートのインデックスを設定します
    $defaultWorksheetIndex = 0;
    # チャート データ ワークシートを取得します
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # デフォルトで生成されたシリーズとカテゴリを削除します
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # 新しいシリーズを追加します
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # 新しいカテゴリを追加します
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # 最初のチャートシリーズを取得します
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # シリーズ データを設定します
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # シリーズの塗りつぶし色を設定します
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 2 番目のチャートシリーズを取得します
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # シリーズ データを設定します
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # シリーズの塗りつぶし色を設定します
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # 新しいシリーズの各カテゴリにカスタム ラベルを作成します
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
    # チャート付きでプレゼンテーションを保存します
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **散布図の作成**

散布図（散布プロットまたは x‑y グラフとも呼ばれます）は、2 つの変数間のパターンや相関関係を確認する際に使用されます。

散布図を使用するシナリオ:

* ペアになった数値データがある場合
* 2 つの変数が相互に適合する場合
* 2 つの変数が関連しているかどうかを判断したい場合
* 従属変数に対して複数の値を持つ独立変数がある場合

1. [クラスター化縦棒グラフの作成](#create-clustered-column-charts) の手順に従います。
2. 3 番目の手順で、データを含むチャートを追加し、次のいずれかのチャート タイプを指定します:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _散布図を表します。_
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _曲線で結ばれ、データ マーカーを持つ散布図を表します。_
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _曲線で結ばれ、データ マーカーのない散布図を表します。_
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _直線で結ばれ、データ マーカーを持つ散布図を表します。_
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _直線で結ばれ、データ マーカーのない散布図を表します。_

この PHP コードは、各シリーズに異なるマーカーを使用した散布図の作成方法を示しています:

```php
  # PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $slide = $pres->getSlides()->get_Item(0);
    # デフォルトのチャートを作成します
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # デフォルトのチャート データ ワークシートのインデックスを取得します
    $defaultWorksheetIndex = 0;
    # チャート データ ワークシートを取得します
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # デモシリーズを削除します
    $chart->getChartData()->getSeries()->clear();
    # 新しいシリーズを追加します
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # 最初のチャートシリーズを取得します
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # シリーズに新しい点 (1:3) を追加します
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # 新しい点 (2:10) を追加します
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # シリーズのタイプを変更します
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # チャートシリーズのマーカーを変更します
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # 2 番目のチャートシリーズを取得します
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # そこに新しい点 (5:2) を追加します
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # 新しい点 (3:1) を追加します
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # 新しい点 (2:2) を追加します
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # 新しい点 (5:1) を追加します
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # チャートシリーズのマーカーを変更します
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

円グラフは、特にカテゴリ ラベルと数値が含まれるデータにおいて、全体に対する各部分の比率を示すのに最適です。ただし、パーツやラベルが多数ある場合は、棒グラフの使用を検討してください。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType::Pie](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#Pie) タイプを指定します。
4. チャート データ ワークブック [ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/) にアクセスします。
5. 既定のシリーズとカテゴリをクリアします。
6. 新しいシリーズとカテゴリを追加します。
7. チャート シリーズ用の新しいデータを追加します。
8. 円グラフのセクタにカスタム カラーを適用しながら新しいポイントを追加します。
9. シリーズのラベルを設定します。
10. ラベルにリーダー ラインを有効にします。
11. 円グラフセクタの回転角度を設定します。
12. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、円グラフの作成方法を示しています:

```php
  # PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $slides = $pres->getSlides()->get_Item(0);
    # デフォルト データでチャートを追加します
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # チャートのタイトルを設定します
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # 最初のシリーズに値を表示するよう設定します
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # チャート データ シートのインデックスを設定します
    $defaultWorksheetIndex = 0;
    # チャート データ ワークシートを取得します
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # デフォルトで生成されたシリーズとカテゴリを削除します
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 新しいカテゴリを追加します
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # 新しいシリーズを追加します
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # シリーズ データを設定します
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # 新しいバージョンでは動作しません
    # 新しいポイントを追加し、セクタの色を設定します
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
    # 新しいシリーズの各カテゴリにカスタム ラベルを作成します
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
    # チャートのリーダー ラインを表示します
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # 円グラフ セクタの回転角度を設定します
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # チャート付きでプレゼンテーションを保存します
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **折れ線グラフの作成**

折れ線グラフ（折れ線チャート）は、時間の経過に伴う値の変化を示すのに最適です。折れ線グラフを使用すると、大量のデータを一度に比較したり、時間経過による変化やトレンドを追跡したり、データ シリーズの異常を強調したりできます。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドへの参照を取得します。
1. デフォルト データを持つチャートを追加し、[ChartType::Line](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#Line) タイプを指定します。
1. チャート データ ワークブック ([ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/)) にアクセスします。
1. 既定のシリーズとカテゴリをクリアします。
1. 新しいシリーズとカテゴリを追加します。
1. チャート シリーズ用の新しいデータを追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、折れ線グラフの作成方法を示しています:

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

デフォルトでは、折れ線グラフのポイントは直線で連結されます。ポイントを破線で結びたい場合は、以下のように希望の破線タイプを指定できます:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ツリーマップ グラフの作成**

ツリーマップ グラフは、売上データで各カテゴリ内の大きな貢献項目に注目しながら、データ カテゴリの相対的なサイズを示すのに最適です。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType::Treemap](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#Treemap) タイプを指定します。
4. チャート データ ワークブック [ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/) にアクセスします。
5. 既定のシリーズとカテゴリをクリアします。
6. 新しいシリーズとカテゴリを追加します。
7. チャート シリーズ用の新しいデータを追加します。
8. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、ツリーマップ グラフの作成方法を示しています:

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

### **株価グラフの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType::OpenHighLowClose](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#OpenHighLowClose) タイプを指定します。
4. チャート データ ワークブック [ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/) にアクセスします。
5. 既定のシリーズとカテゴリをクリアします。
6. 新しいシリーズとカテゴリを追加します。
7. チャート シリーズ用の新しいデータを追加します。
8. 高低線の書式を指定します。
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、株価グラフの作成方法を示しています:

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
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
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

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType::BoxAndWhisker](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#BoxAndWhisker) タイプを指定します。
4. チャート データ ワークブック [ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/) にアクセスします。
5. 既定のシリーズとカテゴリをクリアします。
6. 新しいシリーズとカテゴリを追加します。
7. チャート シリーズ用の新しいデータを追加します。
8. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、箱ひげ図の作成方法を示しています:

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

### **ファンネル グラフの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType::Funnel](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#Funnel) タイプを指定します。
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、ファンネル グラフの作成方法を示しています:

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

### **サンバースト グラフの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType::Sunburst](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#Sunburst) タイプを指定します。
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、サンバースト グラフの作成方法を示しています:

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

### **ヒストグラム グラフの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType::Histogram](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#Histogram) タイプを指定します。
4. チャート データ ワークブック [ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/) にアクセスします。
5. 既定のシリーズとカテゴリをクリアします。
6. 新しいシリーズとカテゴリを追加します。
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、ヒストグラム グラフの作成方法を示しています:

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

### **レーダー グラフの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. データを含むチャートを追加し、[ChartType::Radar](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#Radar) タイプを指定します。
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、レーダー グラフの作成方法を示しています:

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

### **マルチカテゴリ グラフの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType::ClusteredColumn](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/#ClusteredColumn) タイプを指定します。
4. チャート データ ワークブック [ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/) にアクセスします。
5. 既定のシリーズとカテゴリをクリアします。
6. 新しいシリーズとカテゴリを追加します。
7. チャート シリーズ用の新しいデータを追加します。
8. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、マルチカテゴリ グラフの作成方法を示しています:

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
    # シリーズを追加
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # チャート付きでプレゼンテーションを保存
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **マップ グラフの作成**

マップ グラフは地理データを視覚化し、地域間の値を比較するのに役立ちます。

この PHP コードは、マップ グラフの作成方法を示しています:

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

### **複合グラフの作成**

複合グラフ（コンボ グラフ）は、単一のグラフ内に 2 つ以上のチャート タイプを組み合わせます。このグラフを使用すると、複数のデータセット間の違いを強調、比較、検証でき、両者の関係性を把握しやすくなります。

![The combination chart](combination_chart.png)

以下の PHP コードは、上記の複合グラフを PowerPoint プレゼンテーションに作成する方法を示しています:

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

    // デフォルトで生成されたシリーズとカテゴリを削除します。
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // 新しいカテゴリを追加します。
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // 最初のシリーズを追加します。
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

    // 垂直軸の主要グリッドラインの色を設定します。
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // 二次水平軸を設定します。
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // 二次垂直軸を設定します。
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

1. 更新対象のチャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. すべてのシェイプを走査して目的のチャートを見つけます。
4. チャートのデータ ワークシートにアクセスします。
5. シリーズ値を変更してチャート データ シリーズを修正します。
6. 新しいシリーズを追加し、データを入力します。
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、チャートの更新方法を示しています:

```php
  $pres = new Presentation();
  try {
    # 最初のスライド マーカーにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # デフォルト データでチャートを取得
    $chart = $sld->getShapes()->get_Item(0);
    # チャート データ シートのインデックスを設定
    $defaultWorksheetIndex = 0;
    # チャート データ ワークシートを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # チャートのカテゴリ名を変更
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # 最初のチャート シリーズを取得
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # シリーズ データを更新
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// シリーズ名を変更

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # 2 番目のチャート シリーズを取得
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # シリーズ データを更新
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// シリーズ名を変更

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # 新しいシリーズを追加
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # 3 番目のチャート シリーズを取得
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # シリーズ データを設定
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # チャート付きでプレゼンテーションを保存
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **チャートのデータ範囲の設定**

チャートのデータ範囲を設定する手順:

1. 対象チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. すべてのシェイプを走査して目的のチャートを見つけます。
4. チャート データにアクセスし、範囲を設定します。
5. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、チャートのデータ範囲を設定する方法を示しています:

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

## **チャートでデフォルト マーカーを使用する**

チャートでデフォルト マーカーを使用すると、各チャート シリーズに自動的に異なるマーカー記号が割り当てられます。

この PHP コードは、チャート シリーズのマーカーを自動的に設定する方法を示しています:

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
    # 2 番目のチャートシリーズを取得
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # 今、シリーズ データを設定
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

## **FAQ**

**Aspose.Slides がサポートするチャート タイプは何ですか？**

Aspose.Slides は、バー、折れ線、円、エリア、散布図、ヒストグラム、レーダーなど、幅広い [chart types](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/) をサポートしています。この柔軟性により、データ可視化のニーズに最適なチャート タイプを選択できます。

**スライドに新しいチャートを追加するにはどうすればよいですか？**

まず [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、インデックスで目的のスライドを取得します。その後、チャート タイプと初期データを指定してチャートを追加するメソッドを呼び出します。これにより、チャートがプレゼンテーションに直接組み込まれます。

**チャートに表示されるデータを更新するにはどうすればよいですか？**

チャートのデータ ワークブック ([ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/)) にアクセスし、既定のシリーズとカテゴリをクリアしてから、カスタム データを追加します。これにより、最新のデータを反映するようにチャートをリフレッシュできます。

**チャートの外観をカスタマイズできますか？**

はい。Aspose.Slides は豊富なカスタマイズ オプションを提供します。カラー、フォント、ラベル、凡例、その他の [formatting elements](/slides/ja/php-java/chart-entities/) を変更して、デザイン要件に合わせてチャートの外観を調整できます。