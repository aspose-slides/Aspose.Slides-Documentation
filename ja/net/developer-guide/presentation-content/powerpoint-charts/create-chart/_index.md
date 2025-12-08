---
title: C# で PowerPoint プレゼンテーションのチャートを作成または更新する
linktitle: チャートの作成または更新
type: docs
weight: 10
url: /ja/net/create-chart/
keywords:
- チャートを追加
- チャートを作成
- チャートを編集
- チャートを変更
- チャートを更新
- 散布図チャート
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
- PowerPoint プレゼンテーション
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションでチャートを作成およびカスタマイズする方法を学びます。プレゼンテーション内のチャートの追加、書式設定、編集を実践的な C# コード例とともに解説します。"
---

## **概要**

本記事では、Aspose.Slides for .NET を使用してチャートを作成およびカスタマイズする方法について包括的に解説します。スライドにプログラムでチャートを追加し、データを入力し、特定のデザイン要件に合わせてさまざまな書式設定オプションを適用する方法を学びます。記事全体で、プレゼンテーションとチャートオブジェクトの初期化から、系列、軸、凡例の設定まで、各ステップを示す詳細なコード例が掲載されています。このガイドに従うことで、.NET アプリケーションに動的チャート生成を統合し、データ駆動型プレゼンテーションの作成プロセスを効率化する方法を確実に習得できます。

## **チャートの作成**

チャートは、データをすばやく視覚化し、表やスプレッドシートからはすぐに分からない洞察を得るのに役立ちます。

**なぜチャートを作成するのか？**

チャートを使用すると、次のことが可能です。

* 大量のデータを 1 つのスライドに集約、要約、または圧縮できる
* データのパターンやトレンドを明らかにできる
* 時間の経過や特定の測定単位に対するデータの方向性や勢いを推測できる
* 異常値、逸脱、エラー、意味のないデータを検出できる
* 複雑なデータを伝達または提示できる

PowerPoint では、*挿入* 機能を使って多くのチャートテンプレートからチャートを作成できます。Aspose.Slides を使用すれば、一般的なチャートタイプに基づく標準チャートとカスタムチャートの両方を作成できます。

{{% alert color="primary" %}} 
[Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) 名前空間の [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体を使用します。この列挙体の値はさまざまなチャートタイプに対応しています。
{{% /alert %}} 

### **クラスター化列グラフの作成**

このセクションでは、Aspose.Slides for .NET を使用してクラスター化列グラフを作成する方法を説明します。プレゼンテーションの初期化、チャートの追加、タイトル、データ、系列、カテゴリ、スタイリングなどの要素のカスタマイズ方法を学びます。以下の手順で標準的なクラスター化列グラフが生成されます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. データを付与し、`ChartType.ClusteredColumn` タイプを指定してチャートを追加します。  
1. チャートにタイトルを追加します。  
1. チャートのデータワークシートにアクセスします。  
1. 既定の系列とカテゴリをすべてクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. 系列に塗りつぶし色を適用します。  
1. 系列にラベルを追加します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはクラスター化列グラフの作成方法を示しています:
```c#
// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    // デフォルトデータを持つクラスター化列グラフを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // チャートのタイトルを設定します。
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // 最初の系列に値を表示させます。
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // チャートデータシートのインデックスを設定します。
    int worksheetIndex = 0;

    // チャートデータブックを取得します。
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // デフォルトで生成された系列とカテゴリを削除します。
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // 新しい系列を追加します。
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // 新しいカテゴリを追加します。
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // 最初のチャート系列を取得します。
    IChartSeries series = chart.ChartData.Series[0];

    // 系列データを入力します。
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // 系列の塗りつぶし色を設定します。
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // 2 番目のチャート系列を取得します。
    series = chart.ChartData.Series[1];

    // 系列データを入力します。
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // 系列の塗りつぶし色を設定します。
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // 最初のラベルにカテゴリ名を表示させます。
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // 系列の3番目のラベルに値を表示させます。
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // プレゼンテーションを PPTX ファイルとしてディスクに保存します。
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```


結果:

![The Clustered Column chart](clustered_column_chart.png)

### **散布図の作成**

散布図（別名散布プロットまたは XY グラフ）は、2 つの変数間のパターンや相関関係を確認する際によく使用されます。

散布図を使用するケース:

* 対となった数値データがあるとき  
* 2 つの変数が相関しやすいとき  
* 2 つの変数が関連しているかどうかを判断したいとき  
* 従属変数に対して独立変数が複数の値を持つとき

この C# コードは、異なるマーカー系列を持つ散布図の作成方法を示します:
```c#
 // Presentation クラスのインスタンスを作成します。
 using (Presentation presentation = new Presentation())
 {
     // 最初のスライドにアクセスします。
     ISlide slide = presentation.Slides[0];

     // デフォルトの散布図を作成します。
     IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

     // チャートデータシートのインデックスを設定します。
     int worksheetIndex = 0;

     // チャートデータブックを取得します。
     IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

     // デフォルトの系列を削除します。
     chart.ChartData.Series.Clear();

     // 新しい系列を追加します。
     chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
     chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

     // 最初のチャート系列を取得します。
     IChartSeries series = chart.ChartData.Series[0];

     // 系列に新しいポイント (1:3) を追加します。
     series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

     // 新しいポイント (2:10) を追加します。
     series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

     // 系列のタイプを変更します。
     series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

     // チャート系列のマーカーを変更します。
     series.Marker.Size = 10;
     series.Marker.Symbol = MarkerStyleType.Star;

     // 2 番目のチャート系列を取得します。
     series = chart.ChartData.Series[1];

     // チャート系列に新しいポイント (5:2) を追加します。
     series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

     // 新しいポイント (3:1) を追加します。
     series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

     // 新しいポイント (2:2) を追加します。
     series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

     // 新しいポイント (5:1) を追加します。
     series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

     // チャート系列のマーカーを変更します。
     series.Marker.Size = 10;
     series.Marker.Symbol = MarkerStyleType.Circle;

     // プレゼンテーションを PPTX ファイルとしてディスクに保存します。
     presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
 }
```


結果:

![The Scatter chart](scatter_chart.png)

### **円グラフの作成**

円グラフは、データの全体に対する部分の関係を示すのに最適です。特に、カテゴリラベルと数値が対になっている場合に有効です。ただし、項目やラベルが多数ある場合は、棒グラフの使用を検討してください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドを取得します。  
1. デフォルトデータを持つチャートを追加し、`ChartType.Pie` タイプを指定します。  
1. チャートのデータワークブック（[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)）にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. チャートに新しいポイントを追加し、円グラフのセクタにカスタムカラーを適用します。  
1. 系列のラベルを設定します。  
1. 系列ラベルにリーダーラインを有効にします。  
1. 円グラフの回転角度を設定します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは円グラフの作成方法を示します:
```c#
// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    // デフォルトデータでチャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // チャートのタイトルを設定します。
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // 最初の系列に値を表示させます。
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // チャートデータシートのインデックスを設定します。
    int worksheetIndex = 0;

    // チャートデータブックを取得します。
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // デフォルトで生成された系列とカテゴリを削除します。
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // 新しいカテゴリを追加します。
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // 新しい系列を追加します。
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // 系列データを入力します。
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // セクタの色を設定します。
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // セクタの枠線を設定します。
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // セクタの枠線を設定します。
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // セクタの枠線を設定します。
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // 新しい系列の各カテゴリにカスタムラベルを作成します。
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // 系列にリーダーラインを表示させます。
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // 円グラフのセクタの回転角度を設定します。
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // プレゼンテーションを PPTX ファイルとしてディスクに保存します。
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```


結果:

![The Pie chart](pie_chart.png)

### **折れ線グラフの作成**

折れ線グラフ（別名折れ線チャート）は、時間経過に伴う値の変化を示すのに最適です。大量のデータを一度に比較したり、時間軸上の変化やトレンドを追跡したり、データ系列の異常を強調したりする際に便利です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) のインスタンスを作成します。  
1. スライドをインデックスで取得します。  
1. デフォルトデータを持つチャートを追加し、`ChartType.Line` タイプを指定します。  
1. チャートのデータワークブック（[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)）にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは折れ線グラフの作成方法を示します:
```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```


デフォルトでは、折れ線グラフのポイントは直線で連結されます。ダッシュで接続したい場合は、次のようにダッシュタイプを指定できます:
```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```


結果:

![The Line chart](line_chart.png)

### **ツリーマップ グラフの作成**

ツリーマップ グラフは、売上データなどでカテゴリ間の相対的なサイズを示し、各カテゴリ内で大きく貢献している項目に注目させる際に有効です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) のインスタンスを作成します。  
1. スライドをインデックスで取得します。  
1. デフォルトデータを持つチャートを追加し、`ChartType.Treemap` タイプを指定します。  
1. チャートのデータワークブック（[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)）にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはツリーマップ グラフの作成方法を示します:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // ブランチ 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // ブランチ 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```


結果:

![The Treemap chart](treemap_chart.png)

### **株価 グラフの作成**

株価グラフは、始値・高値・安値・終値などの財務データを表示し、市場トレンドやボラティリティの分析に使用されます。投資家やアナリストが情報に基づいた意思決定を行うための重要なインサイトを提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) のインスタンスを作成します。  
1. スライドをインデックスで取得します。  
1. デフォルトデータを持つチャートを追加し、`ChartType.OpenHighLowClose` タイプを指定します。  
1. チャートのデータワークブック（[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)）にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. HiLowLines の書式を指定します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは株価グラフの作成方法を示します:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```


結果:

![The Stock chart](stock_chart.png)

### **箱ひげ図の作成**

箱ひげ図は、中央値・四分位数・外れ値などの主要統計指標を要約し、データの分布を示すために使用されます。探索的データ分析や統計研究で、データの変動性や異常を迅速に把握するのに役立ちます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) のインスタンスを作成します。  
1. スライドをインデックスで取得します。  
1. デフォルトデータを持つチャートを追加し、`ChartType.BoxAndWhisker` タイプを指定します。  
1. チャートのデータワークブック（[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)）にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは箱ひげ図の作成方法を示します:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```


### **ファンネル グラフの作成**

ファンネル グラフは、段階的に減少していくプロセスを可視化し、コンバージョン率の分析やボトルネックの特定、販売・マーケティングプロセスの効率測定に役立ちます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) のインスタンスを作成します。  
1. スライドをインデックスで取得します。  
1. デフォルトデータを持つチャートを追加し、`ChartType.Funnel` タイプを指定します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはファンネル グラフの作成方法を示します:
```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```


結果:

![The Funnel chart](funnel_chart.png)

### **サンバースト グラフの作成**

サンバースト グラフは階層データを同心円状に表示し、部分と全体の関係を示します。入れ子になったカテゴリやサブカテゴリをコンパクトに表現するのに最適です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) のインスタンスを作成します。  
1. スライドをインデックスで取得します。  
1. デフォルトデータを持つチャートを追加し、`ChartType.Sunburst` タイプを指定します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはサンバースト グラフの作成方法を示します:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // ブランチ 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // ブランチ 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```


結果:

![The Sunburst chart](sunburst_chart.png)

### **ヒストグラム グラフの作成**

ヒストグラムは数値データを区間（ビン）に分けて分布を示し、頻度・偏り・散らばりなどのパターンや外れ値の検出に役立ちます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) のインスタンスを作成します。  
1. スライドをインデックスで取得します。  
1. データを付与し、`ChartType.Histogram` タイプを指定してチャートを追加します。  
1. チャートのデータワークブック（[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)）にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはヒストグラムの作成方法を示します:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```


結果:

![The Histogram chart](histogram_chart.png)

### **レーダー グラフの作成**

レーダー グラフは多変量データを二次元で表示し、複数変数を同時に比較できるようにします。パフォーマンス指標や属性間の強み・弱みを特定するのに有用です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) のインスタンスを作成します。  
1. スライドをインデックスで取得します。  
1. データを付与し、`ChartType.Radar` タイプを指定してチャートを追加します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはレーダー グラフの作成方法を示します:
```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```


結果:

![The Radar chart](radar_chart.png)

### **マルチカテゴリ グラフの作成**

マルチカテゴリ グラフは複数のカテゴリグループを同時に比較できるため、複合的なデータ分析やトレンド・関係性の把握に適しています。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) のインスタンスを作成します。  
1. スライドをインデックスで取得します。  
1. デフォルトデータを持つチャートを追加し、`ChartType.ClusteredColumn` タイプを指定します。  
1. チャートのデータワークブック（[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)）にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはマルチカテゴリ グラフの作成方法を示します:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // 系列を追加します。
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // チャートを含むプレゼンテーションを保存します。
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```


結果:

![The multi category chart](multi_category_chart.png)

### **マップ グラフの作成**

マップ グラフは国・州・都市などの地理的領域にデータをマッピングし、地域別トレンドや人口統計、空間分布を視覚的に分析するのに有効です。

この C# コードはマップ グラフの作成方法を示します:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```


結果:

![The Map chart](map_chart.png)

### **組み合わせ グラフの作成**

組み合わせグラフ（コンボ グラフ）は、単一のグラフ内に複数のチャートタイプを組み合わせます。これにより、複数データセット間の違いを強調・比較・検証でき、相互の関係性を把握しやすくなります。

![The combination chart](combination_chart.png)

以下の C# コードは、上記の組み合わせグラフを PowerPoint に作成する方法を示します:
```c#
private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // チャートのタイトルを設定します
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // チャートの凡例を設定します
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // デフォルトで生成された系列とカテゴリを削除します
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 新しいカテゴリを追加します
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // 最初の系列を追加します
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // 水平軸を設定します
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // 垂直軸を設定します
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // 垂直の主要グリッドラインの色を設定します
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // 二次水平軸を設定します
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // 二次垂直軸を設定します
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```


## **チャートの更新**

Aspose.Slides for .NET を使用すると、チャートデータ、書式設定、スタイルを変更して PowerPoint のチャートを更新できます。この機能により、プレゼンテーションを動的コンテンツで最新の状態に保ち、チャートが現在のデータと視覚基準を正確に反映するようにできます。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. すべてのシェイプを走査してチャートを見つけます。  
1. チャートのデータワークシートにアクセスします。  
1. 系列の値を変更してチャートデータ系列を修正します。  
1. 新しい系列を追加し、データを入力します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはチャートの更新方法を示します:
```c#
const string chartName = "My chart";

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // チャート データ シートのインデックスを設定します。
            int worksheetIndex = 0;

            // チャート データ ワークブックを取得します。
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // チャートのカテゴリ名を変更します。
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // 最初のチャート系列を取得します。
            IChartSeries series = chart.ChartData.Series[0];

            // 系列データを更新します。
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // 系列名を変更しています。
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // 2 番目のチャート系列を取得します。
            series = chart.ChartData.Series[1];

            // 系列データを更新します。
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // 系列名を変更しています。
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // 新しい系列を追加します。
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // 系列データを入力します。
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // チャートを含むプレゼンテーションを保存します。
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```


## **チャートのデータ範囲の設定**

Aspose.Slides for .NET では、ワークシートの特定範囲をチャートデータのソースとして定義できます。これにより、ワークシートの一部セルだけを系列やカテゴリにマッピングでき、ワークシートの変更をチャートに即座に反映させることが容易になります。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. すべてのシェイプを走査してチャートを見つけます。  
1. チャートデータにアクセスし、範囲を設定します。  
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはチャートのデータ範囲設定方法を示します:
```c#
const string chartName = "My chart";

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```


## **チャートでデフォルト マーカーを使用する**

デフォルト マーカーを使用すると、各系列に自動的に異なるマーカー記号が割り当てられます。

この C# コードは系列マーカーを自動設定する方法を示します:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // 系列データを入力します。
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Aspose.Slides for .NET がサポートするチャートタイプは何ですか？**

Aspose.Slides for .NET は、棒、折れ線、円、エリア、散布、ヒストグラム、レーダーなど多数のチャートタイプをサポートしています。これにより、データ可視化のニーズに最適なチャートタイプを選択できます。

**スライドに新しいチャートを追加するにはどうすればよいですか？**

まず [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、インデックスで目的のスライドを取得します。その後、チャート追加メソッドにチャートタイプと初期データを指定して呼び出すことで、チャートをプレゼンテーションに直接組み込めます。

**チャートに表示されるデータを更新するにはどうすればよいですか？**

チャートのデータワークブック（[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)）にアクセスし、既定の系列とカテゴリをクリアした上でカスタムデータを追加します。これにより、プログラムからチャートを最新データにリフレッシュできます。

**チャートの外観をカスタマイズできますか？**

はい。Aspose.Slides for .NET では、色、フォント、ラベル、凡例、その他書式設定要素を変更して、チャートの外観を特定のデザイン要件に合わせて細かく調整できます。
