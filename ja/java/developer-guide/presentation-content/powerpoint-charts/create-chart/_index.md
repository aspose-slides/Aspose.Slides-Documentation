---
title: Java で PowerPoint プレゼンテーション チャートの作成または更新
linktitle: チャートの作成または更新
type: docs
weight: 10
url: /ja/java/create-chart/
keywords:
- チャートの追加
- チャートの作成
- チャートの編集
- チャートの変更
- チャートの更新
- 散布図チャート
- 円グラフ
-折れ線グラフ
- ツリーマップチャート
- 株価チャート
- 箱ひげ図チャート
- ファンネルチャート
- サンバーストチャート
- ヒストグラムチャート
- レーダーチャート
- マルチカテゴリチャート
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint プレゼンテーション内のチャートを作成およびカスタマイズします。実用的な Java のコード例でチャートの追加、書式設定、編集が可能です。"
---

## 概要

この記事では、Java で **PowerPoint プレゼンテーション チャートを作成**する方法を説明します。また、**Java でチャートを更新**する方法も示します。以下のトピックを取り上げています。

_チャート_: **通常**
- [Java で PowerPoint チャートを作成](#java-create-powerpoint-chart)
- [Java でプレゼンテーションチャートを作成](#java-create-presentation-chart)
- [Java で PowerPoint プレゼンテーションチャートを作成](#java-create-powerpoint-presentation-chart)

_チャート_: **散布図**
- [Java で散布図を作成](#java-create-scattered-chart)
- [Java で PowerPoint 散布図を作成](#java-create-powerpoint-scattered-chart)
- [Java で PowerPoint プレゼンテーション散布図を作成](#java-create-powerpoint-presentation-scattered-chart)

_チャート_: **円グラフ**
- [Java で円グラフを作成](#java-create-pie-chart)
- [Java で PowerPoint 円グラフを作成](#java-create-powerpoint-pie-chart)
- [Java で PowerPoint プレゼンテーション円グラフを作成](#java-create-powerpoint-presentation-pie-chart)

_チャート_: **ツリーマップ**
- [Java でツリーマップチャートを作成](#java-create-tree-map-chart)
- [Java で PowerPoint ツリーマップチャートを作成](#java-create-powerpoint-tree-map-chart)
- [Java で PowerPoint プレゼンテーションツリーマップチャートを作成](#java-create-powerpoint-presentation-tree-map-chart)

_チャート_: **株価**
- [Java で株価チャートを作成](#java-create-stock-chart)
- [Java で PowerPoint 株価チャートを作成](#java-create-powerpoint-stock-chart)
- [Java で PowerPoint プレゼンテーション株価チャートを作成](#java-create-powerpoint-presentation-stock-chart)

_チャート_: **箱ひげ図**
- [Java で箱ひげ図を作成](#java-create-box-and-whisker-chart)
- [Java で PowerPoint 箱ひげ図を作成](#java-create-powerpoint-box-and-whisker-chart)
- [Java で PowerPoint プレゼンテーション箱ひげ図を作成](#java-create-powerpoint-presentation-box-and-whisker-chart)

_チャート_: **ファンネル**
- [Java でファンネルチャートを作成](#java-create-funnel-chart)
- [Java で PowerPoint ファンネルチャートを作成](#java-create-powerpoint-funnel-chart)
- [Java で PowerPoint プレゼンテーションファンネルチャートを作成](#java-create-powerpoint-presentation-funnel-chart)

_チャート_: **サンバースト**
- [Java でサンバーストチャートを作成](#java-create-sunburst-chart)
- [Java で PowerPoint サンバーストチャートを作成](#java-create-powerpoint-sunburst-chart)
- [Java で PowerPoint プレゼンテーションサンバーストチャートを作成](#java-create-powerpoint-presentation-sunburst-chart)

_チャート_: **ヒストグラム**
- [Java でヒストグラムチャートを作成](#java-create-histogram-chart)
- [Java で PowerPoint ヒストグラムチャートを作成](#java-create-powerpoint-histogram-chart)
- [Java で PowerPoint プレゼンテーションヒストグラムチャートを作成](#java-create-powerpoint-presentation-histogram-chart)

_チャート_: **レーダー**
- [Java でレーダーチャートを作成](#java-create-radar-chart)
- [Java で PowerPoint レーダーチャートを作成](#java-create-powerpoint-radar-chart)
- [Java で PowerPoint プレゼンテーションレーダーチャートを作成](#java-create-powerpoint-presentation-radar-chart)

_チャート_: **マルチカテゴリ**
- [Java でマルチカテゴリチャートを作成](#java-create-multi-category-chart)
- [Java で PowerPoint マルチカテゴリチャートを作成](#java-create-powerpoint-multi-category-chart)
- [Java で PowerPoint プレゼンテーションマルチカテゴリチャートを作成](#java-create-powerpoint-presentation-multi-category-chart)

_チャート_: **マップ**
- [Java でマップチャートを作成](#java-create-map-chart)
- [Java で PowerPoint マップチャートを作成](#java-create-powerpoint-map-chart)
- [Java で PowerPoint プレゼンテーションマップチャートを作成](#java-create-powerpoint-presentation-map-chart)

_アクション_: **チャートの更新**
- [Java で PowerPoint チャートを更新](#java-update-powerpoint-chart)
- [Java でプレゼンテーションチャートを更新](#java-update-presentation-chart)
- [Java で PowerPoint プレゼンテーションチャートを更新](#java-update-powerpoint-presentation-chart)


## **チャートの作成**
チャートは、データをすばやく可視化し、洞察を得るのに役立ちます。テーブルやスプレッドシートだけではすぐには分からないことも明らかにします。 


**なぜチャートを作成するのか？**

チャートを使用すると

* 大量のデータを 1 つのスライドに集約、要約、または縮小できる
* データのパターンや傾向を明らかにできる
* 時間の経過や特定の測定単位に対するデータの方向性と勢いを推測できる
* 外れ値、異常、偏差、エラー、意味のないデータなどを検出できる
* 複雑なデータを伝達または提示できる

PowerPoint では、挿入機能を使用してテンプレートからさまざまな種類のチャートをデザインできます。Aspose.Slides を使用すると、一般的なチャートタイプに基づく標準チャートとカスタムチャートの両方を作成できます。 

{{% alert color="primary" %}} 

チャートを作成できるように、Aspose.Slides は [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType) クラスを提供します。このクラスのフィールドはさまざまなチャートタイプに対応しています。 

{{% /alert %}} 

### **通常のチャートを作成**

_手順: Create PowerPoint Chart in Java_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>手順:</em> Java で PowerPoint チャートを作成</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>手順:</em> Java でプレゼンテーションチャートを作成</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーションチャートを作成</strong></a>

_コード手順:_

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. データを指定してチャートを追加し、希望のチャートタイプを指定します。 
4. チャートにタイトルを追加します。 
5. チャート データ ワークシートにアクセスします。
6. 既定の系列とカテゴリをすべてクリアします。
7. 新しい系列とカテゴリを追加します。
8. 系列用に新しいチャート データを追加します。
9. 系列の塗りつぶし色を設定します。
10. 系列のラベルを追加します。 
11. 修正したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、通常のチャートの作成方法を示します:
```java
// PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 既定データでチャートを追加します
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // チャートのタイトルを設定します
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // 最初の系列に値を表示するよう設定します
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // チャートデータシートのインデックスを設定します
    int defaultWorksheetIndex = 0;
    
    // チャートデータのワークシートを取得します
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // デフォルトで生成された系列とカテゴリを削除します
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // 新しい系列を追加します
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // 新しいカテゴリを追加します
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // 最初のチャート系列を取得します
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // 系列データを設定します
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // 系列の塗りつぶし色を設定します
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // 2 番目のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(1);
    
    // 系列データを設定します
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // 系列の塗りつぶし色を設定します
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //新しい系列の各カテゴリにカスタム ラベルを作成します
    // 最初のラベルにカテゴリ名を表示するよう設定します
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // 3 番目のラベルに値を表示します
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // チャート付きのプレゼンテーションを保存します
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **散布図チャートを作成**
散布図（散布プロットまたは X‑Y グラフとも呼ばれます）は、2 つの変数間のパターンや相関を確認する際に頻繁に使用されます。 

散布図を使用すべき状況

* ペアになった数値データがあるとき
* 2 つの変数が相互に結びついているとき
* 2 つの変数が関連しているか判定したいとき
* 従属変数に対して独立変数が複数の値を持つとき

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>手順:</em> Java で散布図を作成</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>手順:</em> Java で PowerPoint 散布図を作成</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーション散布図を作成</strong></a>

1. 上記の [通常のチャートを作成](#creating-normal-charts) の手順に従います
2. 3 番目の手順で、以下のいずれかのチャートタイプを指定してチャートを追加します
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _散布マーカー付きチャート_
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _曲線で接続された散布チャート（マーカー付き）_
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _曲線で接続された散布チャート（マーカーなし）_
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _直線で接続された散布チャート（マーカー付き）_
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _直線で接続された散布チャート（マーカーなし）_

この Java コードは、異なるマーカー系列を持つ散布図の作成方法を示します: 
```java
// PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide slide = pres.getSlides().get_Item(0);

    // デフォルトのチャートを作成します
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // デフォルトのチャート データ ワークシート インデックスを取得します
    int defaultWorksheetIndex = 0;
    
    // チャート データ ワークシートを取得します
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // デモ系列を削除します
    chart.getChartData().getSeries().clear();
    
    // 新しい系列を追加します
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // 最初のチャート系列を取得します
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // 系列に新しいポイント (1:3) を追加します
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // 新しいポイント (2:10) を追加します
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // 系列のタイプを変更します
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // チャート系列のマーカーを変更します
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
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
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **円グラフを作成**

円グラフは、データの全体に対する部分の関係を示すのに最適です。特にカテゴリごとに数値がある場合に有効です。ただし、カテゴリが多数ある場合は棒グラフの方が適しています。

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>手順:</em> Java で円グラフを作成</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>手順:</em> Java で PowerPoint 円グラフを作成</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーション円グラフを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルト データと希望のタイプ（この場合は [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Pie）でチャートを追加します。
4. チャート データ [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用に新しいチャート データを追加します。
8. 円グラフの各セクタにカスタムカラーを設定しながら新しいポイントを追加します。
9. 系列のラベルを設定します。
10. 系列ラベルのリーダーラインを設定します。
11. 円グラフスライドの回転角度を設定します。
12. 修正したプレゼンテーションを PPTX ファイルとして書き出します

この Java コードは、円グラフの作成方法を示します:
```java
// PPTX ファイルを表すプレゼンテーション クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide slides = pres.getSlides().get_Item(0);
    
    // デフォルトデータでチャートを追加します
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // チャートのタイトルを設定します
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // 最初の系列に値を表示するよう設定します
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // チャート データ シートのインデックスを設定します
    int defaultWorksheetIndex = 0;
    
    // チャート データ ワークシートを取得します
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // デフォルトで生成された系列とカテゴリを削除します
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // 新しいカテゴリを追加します
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // 新しい系列を追加します
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //シリーズデータを設定します
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // 新しいバージョンでは機能しません
    // 新しいポイントを追加し、セクタの色を設定します
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // セクタの境界線を設定します
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // セクタの境界線を設定します
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // セクタの境界線を設定します
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // 新しい系列の各カテゴリにカスタムラベルを作成します
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // チャートのリーダーラインを表示します
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // パイチャートセクタの回転角度を設定します
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // チャート付きのプレゼンテーションを保存します
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **折れ線グラフを作成**

折れ線グラフ（折れ線グラフ）は、時間の経過に伴う値の変化を示すのに最適です。折れ線グラフを使用すると、複数のデータを同時に比較したり、時間経過による変化や傾向を追跡したり、データ系列の異常をハイライトしたりできます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドを取得します。
1. デフォルト データと希望のタイプ（この場合は `ChartType.Line`）でチャートを追加します。
1. チャート データ IChartDataWorkbook にアクセスします。
1. 既定の系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. 系列用に新しいチャート データを追加します。
1. 修正したプレゼンテーションを PPTX ファイルとして書き出します

この Java コードは、折れ線グラフの作成方法を示します:
```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


デフォルトでは、折れ線グラフのポイントは直線で結ばれます。破線で結びたい場合は、以下のように破線タイプを指定できます:
```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```


### **ツリーマップチャートを作成**

ツリーマップチャートは、売上データなどでカテゴリの相対的な大きさを示しつつ、各カテゴリの大きな貢献項目に注目させる際に最適です。 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>手順:</em> Java でツリーマップチャートを作成</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>手順:</em> Java で PowerPoint ツリーマップチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーションツリーマップチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルト データと希望のタイプ（この場合は [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).TreeMap）でチャートを追加します。
4. チャート データ [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用に新しいチャート データを追加します。
8. 修正したプレゼンテーションを PPTX ファイルとして書き出します

この Java コードは、ツリーマップチャートの作成方法を示します:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //ブランチ 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //ブランチ 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **株価チャートを作成**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>手順:</em> Java で株価チャートを作成</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>手順:</em> Java で PowerPoint 株価チャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>手順:</em> Javaで PowerPoint プレゼンテーション株価チャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルト データと希望のタイプ（[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).OpenHighLowClose）でチャートを追加します。
4. チャート データ [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用に新しいチャート データを追加します。
8. HiLowLines の書式を指定します。
9. 修正したプレゼンテーションを PPTX ファイルとして書き出します

株価チャート作成用のサンプル Java コード:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **箱ひげ図を作成**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>手順:</em> Java で箱ひげ図を作成</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>手順:</em> Javaで PowerPoint 箱ひげ図を作成</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>手順:</em> Javaで PowerPoint プレゼンテーション箱ひげ図を作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルト データと希望のタイプ（[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).BoxAndWhisker）でチャートを追加します。
4. チャート データ [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用に新しいチャート データを追加します。
8. 修正したプレゼンテーションを PPTX ファイルとして書き出します

この Java コードは、箱ひげ図の作成方法を示します:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
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

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **ファンネルチャートを作成**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>手順:</em> Javaで ファンネルチャートを作成</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>手順:</em> Javaで PowerPoint ファンネルチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>手順:</em> Javaで PowerPoint プレゼンテーションファンネルチャートを作成</strong></a>


1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルト データと希望のタイプ（[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Funnel）でチャートを追加します。
4. 修正したプレゼンテーションを PPTX ファイルとして書き出します

ファンネルチャート作成用の Java コード:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **サンバーストチャートを作成**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>手順:</em> Javaで サンバーストチャートを作成</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>手順:</em> Javaで PowerPoint サンバーストチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>手順:</em> Javaで PowerPoint プレゼンテーションサンバーストチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルト データと希望のタイプ（この場合は [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).sunburst）でチャートを追加します。
4. 修正したプレゼンテーションを PPTX ファイルとして書き出します

この Java コードは、サンバーストチャートの作成方法を示します:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //ブランチ 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //ブランチ 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **ヒストグラムチャートを作成**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>手順:</em> Javaで ヒストグラムチャートを作成</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>手順:</em> Javaで PowerPoint ヒストグラムチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>手順:</em> Javaで PowerPoint プレゼンテーションヒストグラムチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. デフォルト データと希望のタイプ（[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Histogram）でチャートを追加します。
4. チャート データ [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 修正したプレゼンテーションを PPTX ファイルとして書き出します

この Java コードは、ヒストグラムチャートの作成方法を示します:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **レーダーチャートを作成**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>手順:</em> Javaで レーダーチャートを作成</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>手順:</em> Javaで PowerPoint レーダーチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>手順:</em> Javaで PowerPoint プレゼンテーションレーダーチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。 
3. データを指定し、希望のタイプ（この場合は `ChartType.Radar`）でチャートを追加します。
4. 修正したプレゼンテーションを PPTX ファイルとして書き出します

この Java コードは、レーダーチャートの作成方法を示します:
```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **マルチカテゴリチャートを作成**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>手順:</em> Javaで マルチカテゴリチャートを作成</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>手順:</em> Javaで PowerPoint マルチカテゴリチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>手順:</em> Javaで PowerPoint プレゼンテーションマルチカテゴリチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。 
3. デフォルト データと希望のタイプ（[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).ClusteredColumn）でチャートを追加します。
4. チャート データ [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用に新しいチャート データを追加します。
8. 修正したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、マルチカテゴリチャートの作成方法を示します:
```java
Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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

    // シリーズを追加
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // チャート付きのプレゼンテーションを保存
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **マップチャートを作成**

マップチャートは、データを含む領域を可視化するものです。地理的領域ごとのデータや数値の比較に最適です。

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>手順:</em> Javaで マップチャートを作成</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>手順:</em> Javaで PowerPoint マップチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>手順:</em> Javaで PowerPoint プレゼンテーションマップチャートを作成</strong></a>

この Java コードは、マップチャートの作成方法を示します:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **組み合わせチャートを作成**

組み合わせチャート（コンボチャート）は、単一のグラフに 2 つ以上のチャートタイプを組み合わせたものです。このチャートを使用すると、複数データセット間の違いをハイライト、比較、検証でき、相関関係を特定しやすくなります。

![The combination chart](combination_chart.png)

以下の Java コードは、上記の組み合わせチャートを PowerPoint プレゼンテーションに作成する方法を示します:
```java
static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // チャートのタイトルを設定します。
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // チャートの凡例を設定します。
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // デフォルトで生成された系列とカテゴリを削除します。
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // 新しいカテゴリを追加します。
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // 最初の系列を追加します。
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // 水平軸を設定します。
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // 垂直軸を設定します。
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // 垂直方向のメジャーグリッドラインの色を設定します。
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // 副水平軸を設定します。
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // 副垂直軸を設定します。
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```


## **チャートの更新**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>手順:</em> Javaで PowerPoint チャートを更新</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>手順:</em> Javaで プレゼンテーションチャートを更新</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>手順:</em> Javaで PowerPoint プレゼンテーションチャートを更新</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成し、更新対象のチャートが含まれるプレゼンテーションを表します。 
2. インデックスでスライドの参照を取得します。
3. すべてのシェイプを走査して目的のチャートを見つけます。
4. チャート データ ワークシートにアクセスします。
5. 系列の値を変更してチャート データ 系列を修正します。
6. 新しい系列を追加し、データを入力します。
7. 修正したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、チャートの更新方法を示します:
```java
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // デフォルト データでチャートを取得します
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // チャート データ シートのインデックスを設定します
    int defaultWorksheetIndex = 0;

    // チャート データ ワークシートを取得します
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // チャートのカテゴリ名を変更します
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // 最初のチャート系列を取得します
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // 系列データを更新します
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// 系列名を変更します
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // 2番目のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(1);

    // 系列データを更新します
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// 系列名を変更します
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // 新しい系列を追加します
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // 3番目のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(2);

    // 系列データを設定します
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // チャート付きのプレゼンテーションを保存します
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **チャートのデータ範囲を設定する**

チャートのデータ範囲を設定する手順:

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. すべてのシェイプを走査して目的のチャートを見つけます。
4. チャート データにアクセスし、範囲を設定します。
5. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、チャートのデータ範囲を設定する方法を示します:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **チャートでデフォルトマーカーを使用する**
チャートでデフォルトマーカーを使用すると、各系列に自動的に異なるデフォルトマーカー シンボルが割り当てられます。

この Java コードは、チャート系列のマーカーを自動的に設定する方法を示します:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // 系列データを設定します
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Aspose.Slides がサポートするチャートタイプは何ですか？**

Aspose.Slides は、バー、折れ線、円、エリア、散布、ヒストグラム、レーダーなど、幅広い [chart types](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) をサポートしています。この柔軟性により、データ可視化のニーズに最適なチャートタイプを選択できます。

**スライドに新しいチャートを追加するにはどうすればよいですか？**

チャートを追加するには、まず [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成し、インデックスで目的のスライドを取得し、チャートタイプと初期データを指定してチャートを追加するメソッドを呼び出します。このプロセスにより、チャートがプレゼンテーションに直接組み込まれます。

**チャートに表示されるデータを更新するには？**

チャートのデータは、データ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)) にアクセスし、既定の系列とカテゴリをクリアしてからカスタム データを追加することで更新できます。これにより、最新のデータを反映したチャートにリフレッシュできます。

**チャートの外観をカスタマイズできますか？**

はい、Aspose.Slides では豊富なカスタマイズオプションが用意されています。色、フォント、ラベル、凡例、その他の [formatting elements](/slides/ja/java/chart-entities/) を変更して、チャートの外観をデザイン要件に合わせて調整できます。