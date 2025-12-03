---
title: JavaでPowerPointプレゼンテーションチャートを作成または更新
linktitle: チャートの作成または更新
type: docs
weight: 10
url: /ja/java/create-chart/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint プレゼンテーションのチャートを作成およびカスタマイズします。実用的な Java のコード例でチャートの追加、書式設定、編集が可能です。"
---

## 概要

この記事では、**Java で PowerPoint プレゼンテーション チャートを作成する方法**について説明します。Java でチャートを**更新することも可能**です。以下のトピックを取り上げます。

_チャート_: **標準**
- [JavaでPowerPointチャートを作成](#java-create-powerpoint-chart)
- [Javaでプレゼンテーションチャートを作成](#java-create-presentation-chart)
- [JavaでPowerPointプレゼンテーションチャートを作成](#java-create-powerpoint-presentation-chart)

_チャート_: **散布図**
- [Javaで散布図チャートを作成](#java-create-scattered-chart)
- [JavaでPowerPoint散布図チャートを作成](#java-create-powerpoint-scattered-chart)
- [JavaでPowerPointプレゼンテーション散布図チャートを作成](#java-create-powerpoint-presentation-scattered-chart)

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
- [Javaで箱ひげ図チャートを作成](#java-create-box-and-whisker-chart)
- [JavaでPowerPoint箱ひげ図チャートを作成](#java-create-powerpoint-box-and-whisker-chart)
- [JavaでPowerPointプレゼンテーション箱ひげ図チャートを作成](#java-create-powerpoint-presentation-box-and-whisker-chart)

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


## **チャートの作成**
チャートはデータをすばやく可視化し、テーブルやスプレッドシートからはすぐに分からない洞察を得るのに役立ちます。 


**チャートを作成する理由は？**

チャートを使用すると

* 大量のデータをプレゼンテーションの 1 スライドに集約、要約、圧縮できる
* データのパターンや傾向を明らかにできる
* 時間経過や特定の測定単位に対するデータの方向性や勢いを推測できる
* 異常値、逸脱、エラー、意味のないデータなどを検出できる
* 複雑なデータを伝達または提示できる

PowerPoint では、挿入機能を使用して多くのテンプレートからチャートを作成できます。Aspose.Slides を使用すると、一般的なチャートタイプに基づく標準チャートとカスタムチャートの両方を作成できます。 

{{% alert color="primary" %}} 

チャートを作成できるように、Aspose.Slides は [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType) クラスを提供します。このクラスのフィールドはさまざまなチャートタイプに対応しています。 

{{% /alert %}} 

### **標準チャートの作成**

_手順: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>手順:</em> JavaでPowerPointチャートを作成</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>手順:</em> Javaでプレゼンテーションチャートを作成</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーションチャートを作成</strong></a>

_コード手順:_

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. データを指定してチャートを追加し、希望のチャートタイプを指定します。 
4. チャートにタイトルを追加します。 
5. チャートデータのワークシートにアクセスします。
6. 既定の系列とカテゴリをすべてクリアします。
7. 新しい系列とカテゴリを追加します。
8. 系列用に新しいチャートデータを追加します。
9. 系列の塗りつぶし色を追加します。
10. 系列のラベルを追加します。 
11. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは標準チャートの作成方法を示しています:
```java
// PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);
    
    // デフォルトデータでチャートを追加します
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
    
    // 系列データを入力します
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // 系列の塗りつぶし色を設定します
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // 2 番目のチャート系列を取得します
    series = chart.getChartData().getSeries().get_Item(1);
    
    // 系列データを入力します
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // 系列の塗りつぶし色を設定します
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // 新しい系列の各カテゴリにカスタムラベルを作成します
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


### **散布図チャートの作成**
散布図（散布プロットまたは x‑y グラフ）は、2 つの変数間のパターンや相関関係を確認する際に使用されます。 

以下の場合に散布図を使用するとよいでしょう

* ペアになった数値データがあるとき
* 2 つの変数が相互に関連しているとき
* 2 つの変数が関連しているかどうかを判定したいとき
* 従属変数に対して独立変数が複数の値を持つとき

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>手順:</em> Javaで散布図チャートを作成</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>手順:</em> JavaでPowerPoint散布図チャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーション散布図チャートを作成</strong></a>

1. [標準チャートの作成](#creating-normal-charts) で示した手順に従ってください
2. 3 番目の手順で、チャートを追加するときに次のいずれかのタイプを指定します
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _散布チャートを表します。_
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _滑らかな線で結び、データ マーカー付きの散布チャートを表します。_
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _滑らかな線で結び、データ マーカーなしの散布チャートを表します。_
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _直線で結び、データ マーカー付きの散布チャートを表します。_
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _直線で結び、データ マーカーなしの散布チャートを表します。_

この Java コードは、異なるマーカー系列を使用した散布図の作成方法を示しています: 
```java
// PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide slide = pres.getSlides().get_Item(0);

    // デフォルトのチャートを作成します
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // デフォルトのチャートデータワークシートインデックスを取得します
    int defaultWorksheetIndex = 0;
    
    // チャートデータワークシートを取得します
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


### **円グラフの作成**

円グラフは、データの全体に対する部分の割合を示すのに最適です。特に、カテゴリラベルと数値が対応している場合に有用です。ただし、項目やラベルが多数ある場合は、棒グラフの使用をご検討ください。

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>手順:</em> Javaで円グラフを作成</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>手順:</em> JavaでPowerPoint円グラフを作成</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーション円グラフを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと目的のタイプ（この場合は [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Pie）でチャートを追加します。
4. チャートデータの [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用に新しいチャートデータを追加します。
8. 円グラフのセクターにカスタムカラーを設定しながら新しいポイントを追加します。
9. 系列のラベルを設定します。
10. 系列ラベル用にリーダーラインを設定します。
11. 円グラフスライドの回転角度を設定します。
12. 変更したプレゼンテーションを PPTX ファイルに書き出します

この Java コードは円グラフの作成方法を示しています:
```java
    // PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
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
        
        // チャートデータシートのインデックスを設定します
        int defaultWorksheetIndex = 0;
        
        // チャートデータのワークシートを取得します
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
        
        //系列のデータを入力します
        series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
        series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
        series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
        
        // 新しいバージョンでは動作しません
        // Adding new points and setting sector color
        // series.IsColorVaried = true;
        chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
        
        IChartDataPoint point = series.getDataPoints().get_Item(0);
        point.getFormat().getFill().setFillType(FillType.Solid);
        point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
        // セクターの枠線を設定します
        point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
        point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
        point.getFormat().getLine().setWidth(3.0);
        point.getFormat().getLine().setStyle(LineStyle.ThinThick);
        point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
        
        IChartDataPoint point1 = series.getDataPoints().get_Item(1);
        point1.getFormat().getFill().setFillType(FillType.Solid);
        point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
        
        // セクターの枠線を設定します
        point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
        point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
        point1.getFormat().getLine().setWidth(3.0);
        point1.getFormat().getLine().setStyle(LineStyle.Single);
        point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
        
        IChartDataPoint point2 = series.getDataPoints().get_Item(2);
        point2.getFormat().getFill().setFillType(FillType.Solid);
        point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
        
        // セクターの枠線を設定します
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
        
        // 円グラフセクターの回転角度を設定します
        chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
        
        // チャート付きのプレゼンテーションを保存します
        pres.save("PieChart_out.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
```


### **折れ線グラフの作成**

折れ線グラフ（ライン グラフ）は、時間の経過に伴う値の変化を示すのに最適です。折れ線グラフを使用すると、複数のデータセットを同時に比較したり、時間経過による変化やトレンドを追跡したり、データ系列の異常を強調したりできます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータと目的のタイプ（この場合は `ChartType.Line`）でチャートを追加します。
1. チャートデータの IChartDataWorkbook にアクセスします。
1. 既定の系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. 系列用に新しいチャートデータを追加します。
1. 変更したプレゼンテーションを PPTX ファイルに書き出します

この Java コードは折れ線グラフの作成方法を示しています:
```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


デフォルトでは、折れ線グラフのポイントは直線で結ばれます。ポイントを破線で結びたい場合は、次のように破線タイプを指定します:
```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```


### **ツリーマップチャートの作成**

ツリーマップチャートは、売上データなどでカテゴリの相対的なサイズを示し、かつ各カテゴリ内の大きな貢献項目にすばやく注目させたいときに最適です。 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>手順:</em> Javaでツリーマップチャートを作成</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>手順:</em> JavaでPowerPointツリーマップチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーションツリーマップチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと目的のタイプ（この場合は [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).TreeMap）でチャートを追加します。
4. チャートデータの [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用に新しいチャートデータを追加します。
8. 変更したプレゼンテーションを PPTX ファイルに書き出します

この Java コードはツリーマップチャートの作成方法を示しています:
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


### **株価チャートの作成**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>手順:</em> Javaで株価チャートを作成</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>手順:</em> JavaでPowerPoint株価チャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーション株価チャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと目的のタイプ（[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).OpenHighLowClose）でチャートを追加します。
4. チャートデータの [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用に新しいチャートデータを追加します。
8. HiLowLines の形式を指定します。
9. 変更したプレゼンテーションを PPTX ファイルに書き出します

株価チャートの作成に使用するサンプル Java コード:
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


### **箱ひげ図の作成**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>手順:</em> Javaで箱ひげ図チャートを作成</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>手順:</em> JavaでPowerPoint箱ひげ図チャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーション箱ひげ図チャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと目的のタイプ（[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).BoxAndWhisker）でチャートを追加します。
4. チャートデータの [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用に新しいチャートデータを追加します。
8. 変更したプレゼンテーションを PPTX ファイルに書き出します

この Java コードは箱ひげ図の作成方法を示しています:
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


### **ファンネルチャートの作成**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>手順:</em> Javaでファンネルチャートを作成</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>手順:</em> JavaでPowerPointファンネルチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーションファンネルチャートを作成</strong></a>


1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと目的のタイプ（[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Funnel）でチャートを追加します。
4. 変更したプレゼンテーションを PPTX ファイルに書き出します

ファンネルチャートの作成例:
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


### **サンバーストチャートの作成**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>手順:</em> Javaでサンバーストチャートを作成</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>手順:</em> JavaでPowerPointサンバーストチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーションサンバーストチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと目的のタイプ（この場合は [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).sunburst）でチャートを追加します。
4. 変更したプレゼンテーションを PPTX ファイルに書き出します

この Java コードはサンバーストチャートの作成方法を示しています:
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


### **ヒストグラムチャートの作成**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>手順:</em> Javaでヒストグラムチャートを作成</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>手順:</em> JavaでPowerPointヒストグラムチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーションヒストグラムチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと目的のタイプ（[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Histogram）でチャートを追加します。
4. チャートデータの [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 変更したプレゼンテーションを PPTX ファイルに書き出します

この Java コードはヒストグラムチャートの作成方法を示しています:
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


### **レーダーチャートの作成**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>手順:</em> Javaでレーダーチャートを作成</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>手順:</em> JavaでPowerPointレーダーチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーションレーダーチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。 
3. データを指定し、希望のチャートタイプ（この場合は `ChartType.Radar`）でチャートを追加します。
4. 変更したプレゼンテーションを PPTX ファイルに書き出します

この Java コードはレーダーチャートの作成方法を示しています:
```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **マルチカテゴリチャートの作成**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>手順:</em> Javaでマルチカテゴリチャートを作成</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>手順:</em> JavaでPowerPointマルチカテゴリチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーションマルチカテゴリチャートを作成</strong></a>

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。 
3. デフォルトデータと目的のタイプ（[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).ClusteredColumn）でチャートを追加します。
4. チャートデータの [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) にアクセスします。
5. 既定の系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列用に新しいチャートデータを追加します。
8. 変更したプレゼンテーションを PPTX ファイルに書き出します。

この Java コードはマルチカテゴリチャートの作成方法を示しています:
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

    // 系列を追加
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


### **マップチャートの作成**

マップチャートは、データを含む領域を視覚化したものです。地理的領域間でデータや数値を比較するのに最適です。

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>手順:</em> Javaでマップチャートを作成</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>手順:</em> JavaでPowerPointマップチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーションマップチャートを作成</strong></a>

この Java コードはマップチャートの作成方法を示しています:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **組み合わせチャートの作成**

組み合わせチャート（コンボチャート）は、単一のグラフに 2 つ以上のチャートタイプを組み合わせます。このチャートを使用すると、複数のデータセット間の違いをハイライト、比較、検証でき、相互関係の把握に役立ちます。

![The combination chart](combination_chart.png)

以下の Java コードは、上図の組み合わせチャートを PowerPoint プレゼンテーションで作成する方法を示しています:
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

    // 垂直軸の主要グリッドラインの色を設定します。
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // 副次水平軸を設定します。
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // 副次垂直軸を設定します。
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>手順:</em> JavaでPowerPointチャートを更新</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>手順:</em> Javaでプレゼンテーションチャートを更新</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>手順:</em> JavaでPowerPointプレゼンテーションチャートを更新</strong></a>

1. 更新したいチャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスをインスタンス化します。 
2. インデックスを使用してスライドの参照を取得します。
3. すべてのシェイプを走査して目的のチャートを見つけます。
4. チャートデータのワークシートにアクセスします。
5. 系列データの値を変更してチャートデータ系列を修正します。
6. 新しい系列を追加し、データを設定します。
7. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードはチャートの更新方法を示しています:
```java
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // デフォルトデータのチャートを取得
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // チャートデータシートのインデックスを設定
    int defaultWorksheetIndex = 0;

    // チャートデータのワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // チャートのカテゴリ名を変更
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // 最初のチャート系列を取得
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // 系列データを更新中
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// 系列名を変更
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // 2番目のチャート系列を取得
    series = chart.getChartData().getSeries().get_Item(1);

    // 系列データを更新中
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// 系列名を変更
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // 新しい系列を追加中
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // 3番目のチャート系列を取得
    series = chart.getChartData().getSeries().get_Item(2);

    // 系列データを入力中
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // チャート付きのプレゼンテーションを保存
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **チャートのデータ範囲の設定**

チャートのデータ範囲を設定する手順は次のとおりです。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスをインスタンス化します。
2. インデックスを使用してスライドの参照を取得します。
3. すべてのシェイプを走査して目的のチャートを見つけます。
4. チャートデータにアクセスし、範囲を設定します。
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この Java コードはチャートのデータ範囲の設定方法を示しています:
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

チャートでデフォルトマーカーを使用すると、各系列に自動的に異なるマーカー記号が割り当てられます。

この Java コードはチャート系列マーカーを自動的に設定する方法を示しています:
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
    //2番目のチャート系列を取得
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //系列データを入力中
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

**Aspose.Slides がサポートするチャートの種類は？**

Aspose.Slides は、バー、ライン、円、エリア、散布図、ヒストグラム、レーダーなど、幅広い [chart types](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) をサポートしています。この柔軟性により、データ可視化の要件に最適なチャートタイプを選択できます。

**スライドに新しいチャートを追加する方法は？**

まず、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成し、インデックスで目的のスライドを取得します。その後、チャートタイプと初期データを指定してチャート追加メソッドを呼び出すことで、チャートをプレゼンテーションに直接組み込めます。

**チャートに表示されるデータを更新するには？**

チャートのデータブック（[IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)）にアクセスし、既定の系列とカテゴリをクリアしたうえでカスタムデータを追加することで、最新データに刷新できます。

**チャートの外観をカスタマイズできますか？**

はい。Aspose.Slides は豊富なカスタマイズオプションを提供します。色、フォント、ラベル、凡例、その他の [formatting elements](/slides/ja/java/chart-entities/) を変更して、デザイン要件に合わせてチャートの外観を調整できます。