---
title: JavaでPowerPointプレゼンテーションのチャートを作成または更新する
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
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーション内のチャートを作成およびカスタマイズします。実用的な Java コード例を用いて、チャートの追加、書式設定、編集を行います。"
---
## **概要**

この記事では、Aspose.Slides を使用してチャートを作成およびカスタマイズする方法について包括的に解説します。プログラムでスライドにチャートを追加し、データを設定し、特定のデザイン要件に合わせてさまざまな書式設定オプションを適用する方法を学びます。記事全体で、プレゼンテーションとチャートオブジェクトの初期化から、系列、軸、凡例の設定に至るまで、ステップごとに詳細なコード例が示されています。このガイドに従うことで、動的なチャート生成をアプリケーションに統合し、データ駆動型プレゼンテーションの作成プロセスを効率化する方法を確実に習得できます。

## **チャートの作成**

チャートは、データをすばやく可視化し、表やスプレッドシートからはすぐに分からない洞察を得るのに役立ちます。

**なぜチャートを作成するのか？**

チャートを使用すると、次のことが可能です。

* プレゼンテーションの単一スライドに大量のデータを集約、要約、または凝縮できる
* データのパターンやトレンドを可視化できる
* 時間の経過や特定の測定単位に対するデータの方向性や勢いを推測できる
* 異常値、逸脱、エラー、意味不明なデータなどを発見できる
* 複雑なデータを効果的に伝達・提示できる

PowerPoint では *Insert* 機能を使って多種多様なチャートテンプレートから作成できますが、Aspose.Slides を使用すると、一般的なチャートタイプに基づく標準チャートとカスタムチャートの両方を作成できます。

{{% alert color="info" title="Note" %}}チャートを作成するには、[ChartType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/) クラスを使用します。このクラスのフィールドはさまざまなチャートタイプに対応しています。{{% /alert %}}

### **クラスター化された縦棒グラフの作成**

このセクションでは、Aspose.Slides を使用してクラスター化された縦棒グラフを作成する方法を説明します。プレゼンテーションの初期化、チャートの追加、タイトル、データ、系列、カテゴリ、スタイリングなどの要素のカスタマイズ方法を学びます。以下の手順に従って、標準的なクラスター化縦棒グラフがどのように生成されるかをご確認ください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドへの参照を取得します。
1. データを含むチャートを追加し、`ChartType.ClusteredColumn` タイプを指定します。
1. チャートにタイトルを追加します。
1. チャートのデータ ワークシートにアクセスします。
1. 既定の系列とカテゴリをすべてクリアします。
1. 新しい系列とカテゴリを追加します。
1. 系列の新しいチャート データを追加します。
1. 系列に塗りつぶし色を適用します。
1. 系列にラベルを追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、クラスター化縦棒グラフの作成方法を示しています：

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX ファイルを表すプレゼンテーション クラスのインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);
    
    // デフォルト データでチャートを追加
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // チャートのタイトルを設定
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // チャート データ シートのインデックスを設定
    int defaultWorksheetIndex = 0;
    
    // チャート データ ワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // デフォルトで生成された系列とカテゴリを削除
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // 新しい系列を追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // 新しいカテゴリを追加
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // 最初のチャート系列を取得
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // 系列データを現在設定
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // 系列の塗りつぶし色を設定
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // 2 番目のチャート系列を取得
    series = chart.getChartData().getSeries().get_Item(1);
    
    // 系列データを設定
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // 系列の塗りつぶし色を設定
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // 新しい系列の各カテゴリにカスタム ラベルを作成
    // 最初のラベルにカテゴリ名を表示
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // 3 番目のラベルに値を表示
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Saves the presentation with chart
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **散布図の作成**

散布図（スキャッタ プロットまたは X‑Y グラフとも呼ばれます）は、2 つの変数間のパターンや相関関係を確認する際に頻繁に使用されます。

散布図を使用する場面:

* ペアになった数値データがあるとき
* 2 つの変数が相互に関連しているとき
* 変数間の関係性を判断したいとき
* 従属変数が独立変数の複数の値に対応しているとき

1. [クラスター化された縦棒グラフの作成](#create-clustered-column-charts) の手順に従います。
2. 3 番目の手順で、データを含むチャートを追加し、次のいずれかのチャートタイプを指定します:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _散布図を表します。_
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _曲線で接続された散布図で、データ マーカーが付属します。_
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _曲線で接続された散布図で、データ マーカーは付属しません。_
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _直線で接続された散布図で、データ マーカーが付属します。_
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _直線で接続された散布図で、データ マーカーは付属しません。_

この Java コードは、系列ごとに異なるマーカーを持つ散布図の作成方法を示しています：

```java
import com.aspose.slides.*;

// PPTX ファイルを表すプレゼンテーション クラスのインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // デフォルトのチャートを作成
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // デフォルトのチャート データ ワークシート インデックスを取得
    int defaultWorksheetIndex = 0;
    
    // チャート データ ワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // デモ系列を削除
    chart.getChartData().getSeries().clear();
    
    // 新しい系列を追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // 最初のチャート系列を取得
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // 系列に新しい点 (1:3) を追加
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // 新しい点 (2:10) を追加
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // 系列のタイプを変更
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // チャート系列のマーカーを変更
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // 2 番目のチャート系列を取得
    series = chart.getChartData().getSeries().get_Item(1);
    
    // そこに新しい点 (5:2) を追加
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // 新しい点 (3:1) を追加
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // 新しい点 (2:2) を追加
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // 新しい点 (5:1) を追加
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // チャート系列のマーカーを変更
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **円グラフの作成**

円グラフは、特にカテゴリ ラベルと数値が対応しているデータで、全体に対する各部分の割合を示すのに最適です。ただし、部分やラベルが多数ある場合は、棒グラフの使用を検討してください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType.Pie](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#Pie) タイプを指定します。
4. チャート データ ワークブック [IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/) にアクセスします。
5. デフォルトの系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列の新しいチャート データを追加します。
8. 円グラフのセクタにカスタム色を適用しながら新しいポイントを追加します。
9. 系列のラベルを設定します。
10. 系列ラベルにリーダー ラインを有効にします。
11. 円グラフのセクタの回転角度を設定します。
12. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、円グラフの作成方法を示しています：

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX ファイルを表すプレゼンテーション クラスのインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slides = pres.getSlides().get_Item(0);
    
    // デフォルト データでチャートを追加
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // チャートのタイトルを設定
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // チャート データ シートのインデックスを設定
    int defaultWorksheetIndex = 0;
    
    // チャート データ ワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // デフォルトで生成された系列とカテゴリを削除
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // 新しいカテゴリを追加
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // 新しい系列を追加
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    // 系列データを設定
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
	
    // セクタの枠線を設定
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // セクタの枠線を設定
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // セクタの枠線を設定
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // 新しい系列の各カテゴリにカスタム ラベルを作成
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
    
    // チャートのリーダー ラインを表示
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // 円グラフ セクタの回転角度を設定
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // チャート付きのプレゼンテーションを保存
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **折れ線グラフの作成**

折れ線グラフ（ライン グラフ）は、時間経過に伴う値の変化を示すのに最適です。折れ線グラフを使用すると、多量のデータを一度に比較し、時間に沿った変化やトレンドを追跡し、系列内の異常を強調表示することができます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドへの参照を取得します。
1. デフォルト データを持つチャートを追加し、[ChartType.Line](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#Line) タイプを指定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、折れ線グラフの作成方法を示しています：

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

デフォルトでは、折れ線グラフのポイントは直線で連結されます。ポイントを破線で結びたい場合は、以下のように希望の破線タイプを指定できます：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ツリーマップ グラフの作成**

ツリーマップ グラフは、各カテゴリ内で大きな寄与を持つ項目に注目させながら、データ カテゴリの相対的な大きさを示すのに最適です。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType.Treemap](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#Treemap) タイプを指定します。
4. チャート データ ワークブック [IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/) にアクセスします。
5. デフォルトの系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列の新しいチャート データを追加します。
8. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、ツリーマップ グラフの作成方法を示しています：

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

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType.OpenHighLowClose](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#OpenHighLowClose) タイプを指定します。
4. チャート データ ワークブック [IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/) にアクセスします。
5. デフォルトの系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列の新しいチャート データを追加します。
8. 高低線の書式を指定します。
9. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、株価チャートの作成方法を示しています：

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

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType.BoxAndWhisker](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#BoxAndWhisker) タイプを指定します。
4. チャート データ ワークブック [IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/) にアクセスします。
5. デフォルトの系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列の新しいチャート データを追加します。
8. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、箱ひげ図の作成方法を示しています：

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

### **ファンネル チャートの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType.Funnel](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#Funnel) タイプを指定します。
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、ファンネル チャートの作成方法を示しています：

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

### **サンバースト チャートの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType.Sunburst](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#Sunburst) タイプを指定します。
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、サンバースト チャートの作成方法を示しています：

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

### **ヒストグラム チャートの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType.Histogram](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#Histogram) タイプを指定します。
4. チャート データ ワークブック [IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/) にアクセスします。
5. デフォルトの系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、ヒストグラム チャートの作成方法を示しています：

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

### **レーダー チャートの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. データを含むチャートを追加し、使用したいチャート タイプ（この例では [ChartType.Radar](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#Radar)）を指定します。
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、レーダー チャートの作成方法を示しています：

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

### **マルチカテゴリ チャートの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. デフォルト データを持つチャートを追加し、[ChartType.ClusteredColumn](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/#ClusteredColumn) タイプを指定します。
4. チャート データ ワークブック [IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/) にアクセスします。
5. デフォルトの系列とカテゴリをクリアします。
6. 新しい系列とカテゴリを追加します。
7. 系列の新しいチャート データを追加します。
8. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、マルチカテゴリ チャートの作成方法を示しています：

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
    
    // チャート付きのプレゼンテーションを保存
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **マップ チャートの作成**

マップ チャートは地理データを可視化し、地域ごとの値を比較するのに役立ちます。

この Java コードは、マップ チャートの作成方法を示しています：

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

### **組み合わせチャートの作成**

組み合わせチャート（コンボ チャート）は、単一のグラフ内に 2 種類以上のチャート タイプを組み合わせます。このチャートを使用すると、複数のデータセット間の違いをハイライト、比較、検証でき、相互の関係性を把握しやすくなります。

![The combination chart](combination_chart.png)

以下の Java コードは、上図の組み合わせチャートを PowerPoint プレゼンテーションに作成する方法を示しています：

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

    // チャートタイトルを設定。
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // チャートの凡例を設定。
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // デフォルトで生成された系列とカテゴリを削除。
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // 新しいカテゴリを追加。
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // 最初の系列を追加。
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
    // 水平軸を設定。
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // 垂直軸を設定。
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // 垂直方向の主要グリッドラインの色を設定。
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // セカンダリ水平軸を設定。
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // セカンダリ垂直軸を設定。
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

1. 更新したいチャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. すべてのシェイプを走査して目的のチャートを見つけます。
4. チャート データ ワークシートにアクセスします。
5. 系列の値を変更してチャート データ系列を修正します。
6. 新しい系列を追加し、データを入力します。
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、チャートの更新方法を示しています：

```java
import com.aspose.slides.*;

// 更新するチャートを含むプレゼンテーションを開く
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // スライドからチャートを取得
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // チャート データ シートのインデックスを設定
    int defaultWorksheetIndex = 0;

    // チャート データ ワークシートを取得
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

    // 2 番目のチャート系列を取得
    series = chart.getChartData().getSeries().get_Item(1);

    // 系列データを更新中
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// 系列名を変更
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // 新しい系列を追加中
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // 3 番目のチャート系列を取得
    series = chart.getChartData().getSeries().get_Item(2);

    // 系列データを設定中
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

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. すべてのシェイプを走査して目的のチャートを見つけます。
4. チャート データにアクセスし、範囲を設定します。
5. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、チャートのデータ範囲を設定する方法を示しています：

```java
import com.aspose.slides.*;

// チャートを含むプレゼンテーションを開く
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

## **チャートでデフォルト マーカーを使用する**

チャートでデフォルト マーカーを使用すると、各系列に自動的に異なるマーカー記号が割り当てられます。

この Java コードは、チャート系列のマーカーを自動的に設定する方法を示しています：

```java
import com.aspose.slides.*;

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

    //現在系列データを設定中
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

**Aspose.Slides がサポートしているチャート タイプは何ですか？**

Aspose.Slides は、棒、折れ線、円、エリア、散布図、ヒストグラム、レーダーなど、幅広い [chart types](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/) をサポートしています。この柔軟性により、データ 可視化のニーズに最適なチャート タイプを選択できます。

**スライドに新しいチャートを追加するにはどうすればよいですか？**

新しいチャートを追加するには、まず [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成し、インデックスを使用して目的のスライドを取得します。次に、チャートタイプと初期データを指定してチャートを追加するメソッドを呼び出します。このプロセスにより、チャートがプレゼンテーションに直接組み込まれます。

**チャートに表示されるデータを更新するにはどうすればよいですか？**

チャートのデータは、データ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/)) にアクセスし、既定の系列とカテゴリをクリアしてからカスタム データを追加することで更新できます。これにより、チャートを最新のデータにリフレッシュできます。

**チャートの外観をカスタマイズすることは可能ですか？**

はい。Aspose.Slides は豊富なカスタマイズ オプションを提供します。色、フォント、ラベル、凡例、その他の [formatting elements](/slides/ja/java/chart-entities/) を変更して、チャートの外観を特定のデザイン要件に合わせて調整できます。