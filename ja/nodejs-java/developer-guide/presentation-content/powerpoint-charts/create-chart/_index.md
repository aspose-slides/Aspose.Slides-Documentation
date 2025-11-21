---
title: JavaScript で PowerPoint プレゼンテーション チャートを作成または更新
linktitle: チャートの作成
type: docs
weight: 10
url: /ja/nodejs-java/create-chart/
keywords: "チャートの作成、散布図チャート、円グラフチャート、ツリーマップチャート、株価チャート、箱ひげチャート、ヒストグラムチャート、ファンネルチャート、サンバーストチャート、マルチカテゴリチャート、PowerPoint プレゼンテーション、Java、Aspose.Slides for Node.js via Java"
description: "JavaScript で PowerPoint プレゼンテーションにチャートを作成"
---

## 概要

この記事では、Javaで**PowerPointプレゼンテーションチャートを作成**する方法について説明します。また、**JavaScriptでチャートを更新**することもできます。以下のトピックをカバーしています。

_チャート_: **通常**
- [JavaでPowerPointチャートを作成](#java-create-powerpoint-chart)
- [Javaでプレゼンテーションチャートを作成](#java-create-presentation-chart)
- [JavaでPowerPointプレゼンテーションチャートを作成](#java-create-powerpoint-presentation-chart)

_チャート_: **散布図**
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

_チャート_: **箱ひげ**
- [Javaで箱ひげチャートを作成](#java-create-box-and-whisker-chart)
- [JavaでPowerPoint箱ひげチャートを作成](#java-create-powerpoint-box-and-whisker-chart)
- [JavaでPowerPointプレゼンテーション箱ひげチャートを作成](#java-create-powerpoint-presentation-box-and-whisker-chart)

_チャート_: **ファンネル**
- [Javaでファンネルチャートを作成](#java-create-funnel-chart)
- [JavaでPowerPointファンネルチャートを作成](#java-create-powerpoint-funnel-chart)
- [JavaでPowerPointプレゼンテーションファンネルチャートを作成](#java-create-powerpoint-presentation-funnel-chart)

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

_チャート_: **複数カテゴリ**
- [Javaで複数カテゴリチャートを作成](#java-create-multi-category-chart)
- [JavaでPowerPoint複数カテゴリチャートを作成](#java-create-powerpoint-multi-category-chart)
- [JavaでPowerPointプレゼンテーション複数カテゴリチャートを作成](#java-create-powerpoint-presentation-multi-category-chart)

_チャート_: **地図**
- [Javaで地図チャートを作成](#java-create-map-chart)
- [JavaでPowerPoint地図チャートを作成](#java-create-powerpoint-map-chart)
- [JavaでPowerPointプレゼンテーション地図チャートを作成](#java-create-powerpoint-presentation-map-chart)

_アクション_: **チャートの更新**
- [JavaでPowerPointチャートを更新](#java-update-powerpoint-chart)
- [Javaでプレゼンテーションチャートを更新](#java-update-presentation-chart)
- [JavaでPowerPointプレゼンテーションチャートを更新](#java-update-powerpoint-presentation-chart)


## **チャートの作成**
チャートは、データをすばやく可視化し、テーブルやスプレッドシートだけではすぐに分からない洞察を得るのに役立ちます。


**なぜチャートを作成するのか？**

チャートを使用すると

* 大量のデータを 1 つのスライドに集約、要約、圧縮できる
* データのパターンやトレンドを明らかにできる
* 時間経過や特定の測定単位に対するデータの方向性と勢いを推測できる
* 外れ値、異常、誤差、意味のないデータなどを検出できる
* 複雑なデータを伝達または提示できる

PowerPoint では、挿入機能を使用してテンプレートからさまざまな種類のチャートをデザインできます。Aspose.Slides を使用すると、一般的なチャートタイプに基づく標準チャートと、カスタムチャートの両方を作成できます。

{{% alert color="primary" %}}

チャート作成をサポートするために、Aspose.Slides は [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType) クラスを提供します。このクラスのフィールドはさまざまなチャートタイプに対応しています。

{{% /alert %}}

### **標準チャートの作成**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>手順:</em> JavaScriptでPowerPointチャートを作成</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>手順:</em> JavaScriptでプレゼンテーションチャートを作成</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーションチャートを作成</strong></a>

_Code Steps:_

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. データを指定し、希望するチャートタイプを選択してチャートを追加します。
4. チャートにタイトルを追加します。
5. チャートデータのワークシートにアクセスします。
6. 既定の系列とカテゴリをすべてクリアします。
7. 新しい系列とカテゴリを追加します。
8. 系列用の新しいチャートデータを追加します。
9. 系列の塗りつぶし色を設定します。
10. 系列のラベルを追加します。
11. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。

この JavaScript コードは、標準チャートの作成方法を示しています:
```javascript
// PPTX ファイルを表すプレゼンテーション クラスをインスタンス化します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスします
    var sld = pres.getSlides().get_Item(0);
    // デフォルト データでチャートを追加します
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // チャートのタイトルを設定します
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // 最初の系列に値を表示するよう設定します
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // チャート データシートのインデックスを設定します
    var defaultWorksheetIndex = 0;
    // チャート データ ワークシートを取得します
    var fact = chart.getChartData().getChartDataWorkbook();
    // デフォルトで生成された系列とカテゴリを削除します
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // 新しい系列を追加します
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // 新しいカテゴリを追加します
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // 最初のチャート系列を取得します
    var series = chart.getChartData().getSeries().get_Item(0);
    // 系列データを設定します
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // 系列の塗りつぶし色を設定します
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // 2 番目のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(1);
    // 系列データを設定します
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // 系列の塗りつぶし色を設定します
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // 新しい系列の各カテゴリにカスタム ラベルを作成します
    // 最初のラベルでカテゴリ名を表示します
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // 3 番目のラベルで値を表示します
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // チャート付きのプレゼンテーションを保存します
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **散布図チャートの作成**
散布図（別名散布プロットまたは X‑Y グラフ）は、2 つの変数間のパターンや相関を確認するために頻繁に使用されます。

以下の場合に散布図を使用することがあります

* 対になっている数値データがあるとき
* 2 つの変数が相互に関連しているとき
* 2 つの変数の関係性を判断したいとき
* 従属変数に対して独立変数が複数の値を持つとき

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>手順:</em> JavaScriptで散布図を作成</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>手順:</em> JavaScriptでPowerPoint散布図を作成</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーション散布図を作成</strong></a>

1. 上記の [標準チャートの作成](#creating-normal-charts) 手順を参照してください。
2. 3 番目の手順で、データを指定し、以下のいずれかのチャートタイプを選択します。
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _散布マーカー付きチャートを表します。_
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _スムーズ曲線で接続された散布チャート（マーカー付き）を表します。_
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _スムーズ曲線で接続された散布チャート（マーカーなし）を表します。_
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _直線で接続された散布チャート（マーカー付き）を表します。_
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _直線で接続された散布チャート（マーカーなし）を表します。_

この JavaScript コードは、異なるマーカー系列を使用した散布図の作成方法を示しています:
```javascript
// PPTX ファイルを表すプレゼンテーション クラスをインスタンス化します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスします
    var slide = pres.getSlides().get_Item(0);
    // デフォルトのチャートを作成します
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // デフォルトのチャートデータ ワークシート インデックスを取得します
    var defaultWorksheetIndex = 0;
    // チャート データ ワークシートを取得します
    var fact = chart.getChartData().getChartDataWorkbook();
    // デモ系列を削除します
    chart.getChartData().getSeries().clear();
    // 新しい系列を追加します
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // 最初のチャート系列を取得します
    var series = chart.getChartData().getSeries().get_Item(0);
    // 系列に新しいポイント (1:3) を追加します
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // 新しいポイント (2:10) を追加します
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // 系列のタイプを変更します
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // チャート系列のマーカーを変更します
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // 2 番目のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(1);
    // そこに新しいポイント (5:2) を追加します
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // 新しいポイント (3:1) を追加します
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // 新しいポイント (2:2) を追加します
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // 新しいポイント (5:1) を追加します
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // チャート系列のマーカーを変更します
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **円グラフの作成**

円グラフは、データの全体に対する構成比を示すのに最適です。特に、カテゴリラベルと数値が対応している場合に有効です。ただし、項目やラベルが多数ある場合は、棒グラフの使用を検討してください。

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>手順:</em> JavaScriptで円グラフを作成</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>手順:</em> JavaScriptでPowerPoint円グラフを作成</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーション円グラフを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルトデータと希望するタイプ（この場合は [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Pie）でチャートを追加します。
4. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用の新しいチャートデータを追加します。
8. 円グラフのセクタにカスタム色を設定し、新しいポイントを追加します。
9. 系列ラベルを設定します。
10. 系列ラベル用のリーダーラインを設定します。
11. 円グラフの回転角度を設定します。
12. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。

この JavaScript コードは、円グラフの作成方法を示しています:
```javascript
// PPTX ファイルを表すプレゼンテーション クラスをインスタンス化します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスします
    var slides = pres.getSlides().get_Item(0);
    // デフォルト データでチャートを追加します
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // チャートのタイトルを設定します
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // 最初の系列に値を表示するよう設定します
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // チャート データシートのインデックスを設定します
    var defaultWorksheetIndex = 0;
    // チャート データ ワークシートを取得します
    var fact = chart.getChartData().getChartDataWorkbook();
    // デフォルトで生成された系列とカテゴリを削除します
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // 新しいカテゴリを追加します
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // 新しい系列を追加します
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // 系列データを設定します
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // 新バージョンでは機能しません
    // 新しいポイントを追加し、セクタの色を設定します
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // セクタの境界線を設定します
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // セクタの境界線を設定します
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // セクタの境界線を設定します
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // 新しい系列の各カテゴリにカスタム ラベルを作成します
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // チャートのリーダー ラインを表示します
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // パイチャート セクタの回転角度を設定します
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // チャート付きのプレゼンテーションを保存します
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **折れ線グラフの作成**

折れ線グラフ（別名ライングラフ）は、時間経過による数値の変化を示すのに最適です。複数のデータセットを同時に比較したり、トレンドや異常を強調したりできます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドを取得します。
1. デフォルトデータと希望するタイプ（この場合は `ChartType.Line`）でチャートを追加します。
1. IChartDataWorkbook にアクセスします。
1. 既定の系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. 系列用の新しいチャートデータを追加します。
1. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。

この JavaScript コードは、折れ線グラフの作成方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


デフォルトでは、折れ線グラフのポイントは直線で連結されます。破線で連結したい場合は、次のようにダッシュタイプを指定します:
```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```


### **ツリーマップチャートの作成**

ツリーマップチャートは、売上データなどでカテゴリごとの相対的なサイズを示し、同時に大きな貢献度を持つ項目に注意を引きやすくします。

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>手順:</em> JavaScriptでツリーマップチャートを作成</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>手順:</em> JavaScriptでPowerPointツリーマップチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーションツリーマップチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルトデータと希望するタイプ（この場合は [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).TreeMap）でチャートを追加します。
4. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用の新しいチャートデータを追加します。
8. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します

この JavaScript コードは、ツリーマップチャートの作成方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // ブランチ 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // ブランチ 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **株価チャートの作成**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>手順:</em> JavaScriptで株価チャートを作成</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>手順:</em> JavaScriptでPowerPoint株価チャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーション株価チャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルトデータと希望するタイプ（[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).OpenHighLowClose）でチャートを追加します。
4. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用の新しいチャートデータを追加します。
8. HiLowLines の書式を指定します。
9. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します

株価チャート作成サンプル JavaScript コード:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **箱ひげチャートの作成**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>手順:</em> JavaScriptで箱ひげチャートを作成</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>手順:</em> JavaScriptでPowerPoint箱ひげチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーション箱ひげチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルトデータと希望するタイプ（[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).BoxAndWhisker）でチャートを追加します。
4. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用の新しいチャートデータを追加します。
8. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します

この JavaScript コードは、箱ひげチャートの作成方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **ファンネルチャートの作成**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>手順:</em> JavaScriptでファンネルチャートを作成</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>手順:</em> JavaScriptでPowerPointファンネルチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーションファンネルチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルトデータと希望するタイプ（[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Funnel）でチャートを追加します。
4. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します

ファンネルチャート作成 JavaScript コード:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **サンバーストチャートの作成**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>手順:</em> JavaScriptでサンバーストチャートを作成</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>手順:</em> JavaScriptでPowerPointサンバーストチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーションサンバーストチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルトデータと希望するタイプ（この場合は [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).sunburst）でチャートを追加します。
4. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します

サンバーストチャート作成 JavaScript コード:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // ブランチ 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // ブランチ 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **ヒストグラムチャートの作成**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>手順:</em> JavaScriptでヒストグラムチャートを作成</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>手順:</em> JavaScriptでPowerPointヒストグラムチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーションヒストグラムチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルトデータと希望するタイプ（[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Histogram）でチャートを追加します。
4. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します

ヒストグラムチャート作成 JavaScript コード:
```javascript
var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```


### **レーダーチャートの作成**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>手順:</em> JavaScriptでレーダーチャートを作成</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>手順:</em> JavaScriptでPowerPointレーダーチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーションレーダーチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. データを指定し、希望するタイプ（この場合は `ChartType.Radar`）でチャートを追加します。
4. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します

レーダーチャート作成 JavaScript コード:
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **複数カテゴリチャートの作成**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>手順:</em> JavaScriptで複数カテゴリチャートを作成</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>手順:</em> JavaScriptでPowerPoint複数カテゴリチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーション複数カテゴリチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルトデータと希望するタイプ（[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).ClusteredColumn）でチャートを追加します。
4. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用の新しいチャートデータを追加します。
8. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します

複数カテゴリチャート作成 JavaScript コード:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // 系列を追加
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // チャート付きでプレゼンテーションを保存
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **地図チャートの作成**

地図チャートは、エリアに対するデータの可視化です。地域ごとのデータや数値を比較するのに最適です。

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>手順:</em> JavaScriptで地図チャートを作成</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>手順:</em> JavaScriptでPowerPoint地図チャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーション地図チャートを作成</strong></a>

この JavaScript コードは、地図チャートの作成方法を示しています:
```javascript
let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **組み合わせチャートの作成**

組み合わせチャート（コンボチャート）は、1 つのグラフに 2 つ以上のチャートタイプを組み合わせます。これにより、複数のデータセット間の違いをハイライト、比較、検証でき、関係性を把握しやすくなります。

![The combination chart](combination_chart.png)

以下の JavaScript コードは、上図の組み合わせチャートを PowerPoint プレゼンテーションに作成する方法を示しています:
```js
function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // チャートのタイトルを設定します。
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // チャートの凡例を設定します。
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // デフォルトで生成された系列とカテゴリを削除します。
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // 新しいカテゴリを追加します。
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // 最初の系列を追加します。
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // 水平軸を設定します。
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // 垂直軸を設定します。
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // 垂直軸の主要グリッドラインの色を設定します。
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // 第二水平軸を設定します。
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // 第二垂直軸を設定します。
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```


## **チャートの更新**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>手順:</em> JavaScriptでPowerPointチャートを更新</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>手順:</em> JavaScriptでプレゼンテーションチャートを更新</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>手順:</em> JavaScriptでPowerPointプレゼンテーションチャートを更新</strong></a>

1. 更新対象のチャートが含まれるプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. すべてのシェイプを走査して目的のチャートを見つけます。
4. チャートデータのワークシートにアクセスします。
5. 系列データを変更してチャートデータ系列を更新します。
6. 新しい系列を追加し、データを設定します。
7. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。

チャート更新の JavaScript コード:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var sld = pres.getSlides().get_Item(0);
    // デフォルトデータのチャートを取得
    var chart = sld.getShapes().get_Item(0);
    // チャートデータシートのインデックスを設定
    var defaultWorksheetIndex = 0;
    // チャートデータワークシートを取得
    var fact = chart.getChartData().getChartDataWorkbook();
    // チャートのカテゴリ名を変更
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // 最初のチャート系列を取得
    var series = chart.getChartData().getSeries().get_Item(0);
    // 系列データを更新
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// シリーズ名を変更
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // 2番目のチャート系列を取得
    series = chart.getChartData().getSeries().get_Item(1);
    // 系列データを更新
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// シリーズ名を変更
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // 新しい系列を追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // 3番目のチャート系列を取得
    series = chart.getChartData().getSeries().get_Item(2);
    // 系列データを設定
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // チャート付きのプレゼンテーションを保存
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **チャートのデータ範囲設定**

チャートのデータ範囲を設定する手順:

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. すべてのシェイプを走査して目的のチャートを見つけます。
4. チャートデータにアクセスし、範囲を設定します。
5. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。

データ範囲設定の JavaScript コード:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **チャートのデフォルトマーカー使用**

チャートでデフォルトマーカーを使用すると、各系列に自動的に異なるマーカー記号が割り当てられます。

デフォルトマーカーを自動設定する JavaScript コード:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // 2 番目のチャート系列を取得します
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // 系列データを設定中
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
