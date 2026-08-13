---
title: Android で PowerPoint プレゼンテーションのチャートを作成または更新
linktitle: チャートを作成または更新
type: docs
weight: 10
url: /ja/androidjava/create-chart/
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
- ファネルチャート
- サンバーストチャート
- ヒストグラムチャート
- レーダーチャート
- マルチカテゴリチャート
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PowerPoint プレゼンテーションのチャートを作成およびカスタマイズします。実用的な Java コード例でチャートを追加、書式設定、編集できます。"
---
## **概要**

本記事では、Aspose.Slides を使用してチャートを作成およびカスタマイズするための包括的なガイドを提供します。スライドにプログラムでチャートを追加し、データを設定し、特定のデザイン要件に合わせてさまざまな書式設定オプションを適用する方法を学びます。記事全体を通して、プレゼンテーションとチャートオブジェクトの初期化から系列、軸、凡例の設定まで、各ステップを示す詳細なコード例が掲載されています。このガイドに従うことで、アプリケーションに動的チャート生成を統合する確固たる理解が得られ、データドリブンなプレゼンテーション作成プロセスを効率化できます。

## **チャートの作成**

チャートは、テーブルやスプレッドシートからはすぐには分からないデータをすばやく視覚化し、洞察を得るのに役立ちます。

**なぜチャートを作成するのか？**

* プレゼンテーションの単一スライド上で大量のデータを集約、圧縮、または要約する  
* データのパターンやトレンドを明らかにする  
* 時間経過や特定の測定単位に対するデータの方向性と勢いを推測する  
* 外れ値、異常、逸脱、エラー、意味のないデータなどを検出する  
* 複雑なデータを伝える・提示する  

PowerPoint では、挿入機能を使ってさまざまなチャートテンプレートからチャートを作成できます。Aspose.Slides を使用すれば、一般的なチャートタイプに基づく標準チャートやカスタムチャートを作成できます。

{{% alert color="info" %}} 
チャート作成のために、Aspose.Slides は [ChartType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ChartType) クラスを提供しています。このクラスのフィールドはさまざまなチャートタイプに対応しています。  
{{% /alert %}} 

### **標準チャートの作成**

_ステップ: チャートの作成_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>手順:</em> Java で PowerPoint チャートを作成</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>手順:</em> Java でプレゼンテーション チャートを作成</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーション チャートを作成</strong></a>

_コード手順:_

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. データを指定してチャートを追加し、希望のチャートタイプを指定します。  
4. チャートにタイトルを追加します。  
5. チャートデータのワークシートにアクセスします。  
6. 既定の系列とカテゴリをすべてクリアします。  
7. 新しい系列とカテゴリを追加します。  
8. 系列用の新しいチャートデータを追加します。  
9. 系列の塗りつぶし色を設定します。  
10. 系列のラベルを追加します。  
11. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、標準チャートの作成方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    chart.setTitle(true);
    
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
    
    //新しい系列の各カテゴリにカスタムラベルを作成します
    // 最初のラベルにカテゴリ名を表示します
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

### **散布図の作成**

散布図（散布プロットまたは X-Y グラフとも呼ばれる）は、パターンを確認したり、2 つの変数間の相関を示したりする際に使用されます。

次の場合に散布図を使用したいかもしれません。

* 数値データがペアになっている  
* 相関のある 2 つの変数がある  
* 2 変数が関連しているかを判断したい  
* 従属変数に対して複数の値を持つ独立変数がある  

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>手順:</em> Java で散布図を作成</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>手順:</em> Java で PowerPoint 散布図を作成</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーション散布図を作成</strong></a>

1. 上記の[標準チャートの作成](#creating-normal-charts)で示した手順に従ってください。  
2. 3 番目の手順では、データを指定してチャートを追加し、以下のいずれかのチャートタイプを指定します。  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _散布チャートを表します。_  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _曲線で接続された散布チャート（データマーカー付き）を表します。_  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _曲線で接続された散布チャート（データマーカーなし）を表します。_  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _直線で接続された散布チャート（データマーカー付き）を表します。_  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _直線で接続された散布チャート（データマーカーなし）を表します。_  

この Java コードは、異なるマーカー系列を持つ散布図の作成方法を示しています。

```java
import com.aspose.slides.*;

// PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide slide = pres.getSlides().get_Item(0);

    // デフォルトのチャートを作成します
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // デフォルトのチャートデータワークシートのインデックスを取得します
    int defaultWorksheetIndex = 0;
    
    // チャートデータのワークシートを取得します
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

円グラフは、データの全体に対する部分の関係を示すのに最適です。特に、カテゴリラベルと数値が対応している場合に有効です。ただし、項目やラベルが多数ある場合は、棒グラフの使用を検討してください。

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>手順:</em> Java で円グラフを作成</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>手順:</em> Java で PowerPoint 円グラフを作成</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーション円グラフを作成</strong></a>

1. Presentation クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（この場合は [ChartType].Pie）でチャートを追加します。  
4. チャートデータの [IChartDataWorkbook] にアクセスします。  
5. 既定の系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 系列用の新しいチャートデータを追加します。  
8. チャートに新しいポイントを追加し、円グラフのセクターにカスタムカラーを設定します。  
9. 系列のラベルを設定します。  
10. 系列ラベルのリーダーラインを設定します。  
11. 円グラフスライドの回転角度を設定します。  
12. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

この Java コードは、円グラフの作成方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    
    //シリーズのデータを設定します
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // 新しいバージョンでは動作しません
    // 新しいポイントを追加し、セクタの色を設定します
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // セクタの枠線を設定します
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // セクタの枠線を設定します
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // セクタの枠線を設定します
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
    
    // 円グラフのセクタの回転角度を設定します
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // チャート付きのプレゼンテーションを保存します
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **折れ線グラフの作成**

折れ線グラフ（ライングラフとも呼ばれる）は、時間の経過に伴う値の変化を示すのに最適です。折れ線グラフを使用すると、複数のデータを同時に比較したり、時間経過による変化やトレンドを追跡したり、系列内の異常を強調したりできます。

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（この場合は `ChartType.Line`）でチャートを追加します。  
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、折れ線グラフの作成方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

デフォルトでは、折れ線グラフの点は直線の連続で結ばれます。点を破線で結びたい場合は、次のように希望の破線タイプを指定できます。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **ツリーマップチャートの作成**

ツリーマップチャートは、売上データで各カテゴリの相対的なサイズを示しつつ、各カテゴリ内で大きく貢献している項目に迅速に注目させたい場合に最適です。

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>手順:</em> Java でツリーマップチャートを作成</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>手順:</em> Java で PowerPoint ツリーマップチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーションツリーマップチャートを作成</strong></a>

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（この場合は [ChartType].TreeMap）でチャートを追加します。  
4. チャートデータの [IChartDataWorkbook] にアクセスします。  
5. 既定の系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 系列用の新しいチャートデータを追加します。  
8. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、ツリーマップチャートの作成方法を示しています。

```java
import com.aspose.slides.*;

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

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>手順:</em> Java で株価チャートを作成</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>手順:</em> Java で PowerPoint 株価チャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーション株価チャートを作成</strong></a>

1. Presentation クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（[ChartType].OpenHighLowClose）でチャートを追加します。  
4. チャートデータの [IChartDataWorkbook] にアクセスします。  
5. 既定の系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 系列用の新しいチャートデータを追加します。  
8. HiLowLines の書式を指定します。  
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

株価チャート作成に使用するサンプル Java コードは以下です。

```java
import com.aspose.slides.*;

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

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>手順:</em> Java で箱ひげ図を作成</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>手順:</em> Java で PowerPoint 箱ひげ図を作成</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>手順:</em> Javaで PowerPoint プレゼンテーション箱ひげ図を作成</strong></a>

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（[ChartType].BoxAndWhisker）でチャートを追加します。  
4. チャートデータの [IChartDataWorkbook] にアクセスします。  
5. 既定の系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 系列用の新しいチャートデータを追加します。  
8. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、箱ひげ図の作成方法を示しています。

```java
import com.aspose.slides.*;

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

### **ファネルチャートの作成**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>手順:</em> Java でファネルチャートを作成</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>手順:</em> Java で PowerPoint ファネルチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーションファネルチャートを作成</strong></a>

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（[ChartType].Funnel）でチャートを追加します。  
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

Java コードは、ファネルチャートの作成方法を示しています。

```java
import com.aspose.slides.*;

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

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>手順:</em> Java でサンバーストチャートを作成</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>手順:</em> Java で PowerPoint サンバーストチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーションサンバーストチャートを作成</strong></a>

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（この場合は [ChartType].sunburst）でチャートを追加します。  
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、サンバーストチャートの作成方法を示しています。

```java
import com.aspose.slides.*;

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

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>手順:</em> Java でヒストグラムチャートを作成</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>手順:</em> Java で PowerPoint ヒストグラムチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーションヒストグラムチャートを作成</strong></a>

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（[ChartType].Histogram）でチャートを追加します。  
4. チャートデータの [IChartDataWorkbook] にアクセスします。  
5. 既定の系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、ヒストグラムチャートの作成方法を示しています。

```java
import com.aspose.slides.*;

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

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **レーダーチャートの作成**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>手順:</em> Java でレーダーチャートを作成</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>手順:</em> Java で PowerPoint レーダーチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーションレーダーチャートを作成</strong></a>

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. データを指定してチャートを追加し、希望のチャートタイプ（この場合は `ChartType.Radar`）を指定します。  
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、レーダーチャートの作成方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **マルチカテゴリチャートの作成**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>手順:</em> Java でマルチカテゴリチャートを作成</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>手順:</em> Java で PowerPoint マルチカテゴリチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーションマルチカテゴリチャートを作成</strong></a>

1. Presentation クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. デフォルトデータと希望のタイプ（[ChartType].ClusteredColumn）でチャートを追加します。  
4. チャートデータの [IChartDataWorkbook] にアクセスします。  
5. 既定の系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. 系列用の新しいチャートデータを追加します。  
8. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、マルチカテゴリチャートの作成方法を示しています。

```java
import com.aspose.slides.*;

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
    
    // Save presentation with chart
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **マップチャートの作成**

マップチャートは、データを含む領域を視覚化したものです。地理的領域間でデータや値を比較するのに最適です。

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>手順:</em> Java でマップチャートを作成</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>手順:</em> Java で PowerPoint マップチャートを作成</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーションマップチャートを作成</strong></a>

この Java コードは、マップチャートの作成方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **コンビネーションチャートの作成**

コンビネーションチャート（コンボチャート）は、単一のグラフ内に 2 つ以上のチャートタイプを組み合わせたものです。このチャートを使用すると、複数のデータセット間の違いを強調、比較、または検証でき、関係性の把握に役立ちます。

![コンビネーションチャート](combination_chart.png)

以下の Java コードは、上記のコンビネーションチャートを PowerPoint プレゼンテーションで作成する方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // 垂直軸の主要グリッド線の色を設定します。
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>手順:</em> Java で PowerPoint チャートを更新</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>手順:</em> Java でプレゼンテーションチャートを更新</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>手順:</em> Java で PowerPoint プレゼンテーションチャートを更新</strong></a>

1. 更新したいチャートを含むプレゼンテーションを表す [Presentation] クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. すべてのシェイプを走査して目的のチャートを見つけます。  
4. チャートデータのワークシートにアクセスします。  
5. 系列の値を変更してチャートデータ系列を修正します。  
6. 新しい系列を追加し、データを入力します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、チャートの更新方法を示しています。

```java
import com.aspose.slides.*;

// 更新するチャートを含むプレゼンテーションを開きます
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // スライドからチャートを取得します
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // チャートデータシートのインデックスを設定します
    int defaultWorksheetIndex = 0;

    // チャートデータのワークシートを取得します
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

## **チャートのデータ範囲の設定**

1. チャートを含むプレゼンテーションを表す [Presentation] クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. すべてのシェイプを走査して目的のチャートを見つけます。  
4. チャートデータにアクセスし、範囲を設定します。  
5. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、チャートのデータ範囲を設定する方法を示しています。

```java
import com.aspose.slides.*;

// チャートを含むプレゼンテーションを開きます
Presentation pres = new Presentation("ExistingChart.pptx");
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

チャートでデフォルトマーカーを使用すると、各系列に自動的に異なるデフォルトマーカーシンボルが割り当てられます。

この Java コードは、チャート系列のマーカーを自動的に設定する方法を示しています。

```java
import com.aspose.slides.*;

//チャートを含むプレゼンテーションを開きます
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
    //2 番目のチャート系列を取得します
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //系列データを設定します
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

## **よくある質問**

### Aspose.Slides がサポートするチャートタイプは何ですか？

Aspose.Slides は、棒、折れ線、円、エリア、散布、ヒストグラム、レーダーなどを含む幅広い [チャートタイプ](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/charttype/) をサポートしています。この柔軟性により、データ可視化のニーズに最適なチャートタイプを選択できます。

### 新しいチャートをスライドに追加するには？

チャートを追加するには、まず [Presentation] クラスのインスタンスを作成し、インデックスで目的のスライドを取得し、チャートタイプと初期データを指定してチャートを追加するメソッドを呼び出します。このプロセスにより、チャートがプレゼンテーションに直接統合されます。

### チャートに表示されるデータを更新するには？

チャートのデータは、チャートのデータワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/)) にアクセスし、既定の系列とカテゴリをクリアした後、カスタムデータを追加することで更新できます。これにより、最新のデータを反映するようにチャートをリフレッシュできます。

### チャートの外観をカスタマイズできますか？

はい、Aspose.Slides は豊富なカスタマイズオプションを提供しています。色、フォント、ラベル、凡例、およびその他の [formatting elements](/slides/ja/androidjava/chart-entities/) を変更して、チャートの外観を特定のデザイン要件に合わせて調整できます。