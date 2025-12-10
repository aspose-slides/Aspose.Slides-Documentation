---
title: PowerPoint プレゼンテーションのチャートを .NET で作成または更新
linktitle: チャートの作成または更新
type: docs
weight: 10
url: /ja/net/create-chart/
keywords:
- チャートの追加
- チャートの作成
- チャートの編集
- チャートの変更
- チャートの更新
- 散布図
- 円グラフ
- 折れ線グラフ
- ツリーマップ
- 株価チャート
- 箱ひげ図
- ファンネルチャート
- サンバーストチャート
- ヒストグラム
- レーダーチャート
- マルチカテゴリチャート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションのチャートを作成およびカスタマイズします。実用的な C# コード例でチャートの追加、書式設定、編集が可能です。"
---

## **Overview**

この記事では、Aspose.Slides for .NET を使用してチャートを作成およびカスタマイズする方法について包括的に解説します。スライドにプログラムでチャートを追加し、データを設定し、特定のデザイン要件に合わせてさまざまな書式設定オプションを適用する方法を学びます。記事全体で、プレゼンテーションとチャート オブジェクトの初期化からシリーズ、軸、凡例の設定まで、各手順を示す詳細なコード例が掲載されています。このガイドに従うことで、.NET アプリケーションに動的なチャート生成を統合し、データ駆動型プレゼンテーションの作成プロセスを効率化する方法を確実に習得できます。

## **Create a Chart**

チャートは、データをすばやく視覚化し、表やスプレッドシートからはすぐに分かりにくい洞察を得るのに役立ちます。

**チャートを作成する理由**

チャートを使用すると、次のことが可能です。

* プレゼンテーションの単一スライドに大量のデータを集約、要約、または凝縮できる  
* データのパターンやトレンドを明らかにできる  
* 時間や特定の測定単位に対するデータの方向性と勢いを推測できる  
* 外れ値、異常、偏差、エラー、意味のないデータを検出できる  
* 複雑なデータを伝達または提示できる  

PowerPoint では *Insert* 機能を使用してチャートを作成でき、多くのチャートテンプレートが提供されています。Aspose.Slides を使用すれば、一般的なチャートタイプに基づく標準チャートとカスタムチャートの両方を作成できます。

{{% alert color="primary" %}} 

[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体は [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) 名前空間にあります。この列挙体の値はさまざまなチャートタイプに対応しています。

{{% /alert %}} 

### **Create Clustered Column Charts**

このセクションでは、Aspose.Slides for .NET を使用してクラスター化列チャートを作成する方法を説明します。プレゼンテーションの初期化、チャートの追加、タイトル、データ、シリーズ、カテゴリ、スタイリングなどの要素のカスタマイズ方法を学びます。以下の手順で標準的なクラスター化列チャートが生成されます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. データを含むチャートを追加し、`ChartType.ClusteredColumn` タイプを指定します。  
1. チャートにタイトルを追加します。  
1. チャートのデータ ワークシートにアクセスします。  
1. 既定のシリーズとカテゴリをすべてクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいデータを追加します。  
1. シリーズに塗りつぶし色を適用します。  
1. シリーズにラベルを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはクラスター化列チャートの作成方法を示しています:
```c#
// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    // デフォルト データでクラスタ化列チャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // チャートのタイトルを設定します。
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // 最初の系列に値を表示させます。
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // チャート データシートのインデックスを設定します。
    int worksheetIndex = 0;

    // チャート データ ワークブックを取得します。
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

    // 最初のラベルにカテゴリ名を表示します。
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // 系列の3番目のラベルに値を表示します。
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

### **Create Scatter Charts**

散布図（散布プロットまたは x‑y グラフとも呼ばれる）は、変数間のパターンや相関関係を確認するためによく使用されます。

散布図を使用する場面:

* 対になった数値データがあるとき  
* 2 つの変数がペアで扱えるとき  
* 2 つの変数が関連しているかどうかを判断したいとき  
* 従属変数に対して複数の独立変数の値があるとき  

この C# コードは、異なるマーカー シリーズを持つ散布図の作成方法を示しています:
```c#
// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    // デフォルトの散布図チャートを作成します。
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // チャート データシートのインデックスを設定します。
    int worksheetIndex = 0;

    // チャート データ ワークブックを取得します。
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

### **Create Pie Charts**

円グラフは、特にカテゴリ ラベルと数値が対応しているデータで、全体に対する部分の関係を示すのに最適です。ただし、パーツやラベルが多数ある場合は、棒グラフの使用を検討してください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. 既定データでチャートを追加し、`ChartType.Pie` タイプを指定します。  
1. チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいデータを追加します。  
1. チャートに新しいポイントを追加し、円グラフのセクタにカスタム色を適用します。  
1. シリーズのラベルを設定します。  
1. ラベルにリーダー線を有効にします。  
1. 円グラフの回転角度を設定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは円グラフの作成方法を示しています:
```c#
// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    // デフォルト データでチャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // チャートのタイトルを設定します。
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // 最初の系列に値を表示させます。
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // チャート データシートのインデックスを設定します。
    int worksheetIndex = 0;

    // チャート データ ワークブックを取得します。
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

### **Create Line Charts**

折れ線グラフは、時間経過に伴う値の変化を示すのに最適です。折れ線グラフを使用すると、膨大なデータを一度に比較し、時間に伴う変化やトレンドを追跡し、データ系列の異常を強調表示することができます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. 既定データでチャートを追加し、`ChartType.Line` タイプを指定します。  
1. チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいデータを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは折れ線グラフの作成方法を示しています:
```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```


既定では、折れ線グラフのポイントは直線で連結されます。ダッシュ線で連結したい場合は、以下のようにダッシュタイプを指定できます:
```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```


結果:

![The Line chart](line_chart.png)

### **Create Tree Map Charts**

ツリーマップは、販売データなどでカテゴリ間の相対的なサイズを示し、各カテゴリ内の大きな貢献項目に注意を引く際に最適です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. 既定データでチャートを追加し、`ChartType.Treemap` タイプを指定します。  
1. チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいデータを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはツリーマップの作成方法を示しています:
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

### **Create Stock Charts**

株価チャートは、始値・高値・安値・終値などの金融データを表示し、市場のトレンドやボラティリティを分析するのに役立ちます。投資家やアナリストが情報に基づいた意思決定を行うための重要なインサイトを提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンス를作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. 既定データでチャートを追加し、`ChartType.OpenHighLowClose` タイプを指定します。  
1. チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいデータを追加します。  
1. HiLowLines の書式を指定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは株価チャートの作成方法を示しています:
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

### **Create Box and Whisker Charts**

箱ひげ図は、中央値、四分位数、外れ値などの主要な統計指標を要約してデータの分布を示すために使用されます。探索的データ分析や統計研究で、データのばらつきや異常を迅速に把握するのに非常に有用です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. 既定データでチャートを追加し、`ChartType.BoxAndWhisker` タイプを指定します。  
1. チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいデータを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは箱ひげ図の作成方法を示しています:
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


### **Create Funnel Charts**

ファンネル チャートは、段階的にデータ量が減少していくプロセスを可視化します。コンバージョン率の分析、ボトルネックの特定、販売やマーケティングの効率追跡に特に有用です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. 既定データでチャートを追加し、`ChartType.Funnel` タイプを指定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはファンネル チャートの作成方法を示しています:
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

### **Create Sunburst Charts**

サンバースト チャートは階層データを同心円状のリングで表現し、部分と全体の関係を視覚的に示します。入れ子構造のカテゴリやサブカテゴリをコンパクトに表現するのに最適です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. 既定データでチャートを追加し、`ChartType.Sunburst` タイプを指定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはサンバースト チャートの作成方法を示しています:
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

### **Create Histogram Charts**

ヒストグラムは数値データを区間（ビン）に分けて分布を可視化します。頻度、歪度、散布などのパターンや外れ値の検出に役立ちます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. データを含むチャートを追加し、`ChartType.Histogram` タイプを指定します。  
1. チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはヒストグラムの作成方法を示しています:
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

### **Create Radar Charts**

レーダー チャートは多変量データを二次元で表現し、複数変数を同時に比較できます。パフォーマンス指標や属性の強み・弱みを把握するのに有用です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. データを含むチャートを追加し、`ChartType.Radar` タイプを指定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはレーダー チャートの作成方法を示しています:
```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```


結果:

![The Radar chart](radar_chart.png)

### **Create Multi-Category Charts**

マルチカテゴリ チャートは、複数のカテゴリ グループを同時に比較できるため、複雑なデータ構造でのトレンドや関係性の分析に適しています。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. 既定データでチャートを追加し、`ChartType.ClusteredColumn` タイプを指定します。  
1. チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいデータを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはマルチカテゴリ チャートの作成方法を示しています:
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

    // チャート付きでプレゼンテーションを保存します。
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```


結果:

![The multi category chart](multi_category_chart.png)

### **Create Map Charts**

マップ チャートは国や州、市などの地理的領域にデータをマッピングし、地域別トレンドや人口統計、空間分布を視覚的に分析できます。

この C# コードはマップ チャートの作成方法を示しています:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```


結果:

![The Map chart](map_chart.png)

### **Create Combination Charts**

コンビネーション チャート（コンボ チャート）は、1 つのグラフに 2 種類以上のチャート タイプを組み合わせます。複数データセットの違いを強調、比較、検証でき、相互の関係性を把握しやすくなります。

![The combination chart](combination_chart.png)

以下の C# コードは、上記のコンビネーション チャートを PowerPoint プレゼンテーションに作成する方法を示しています:
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

    // 垂直軸の主要グリッド線の色を設定します
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


## **Update Charts**

Aspose.Slides for .NET を使用すると、チャート データ、書式設定、スタイルを変更して PowerPoint のチャートを更新できます。この機能により、動的コンテンツでプレゼンテーションを最新の状態に保ち、チャートが現在のデータとビジュアル基準を正確に反映できるようになります。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. すべてのシェイプを走査してチャートを見つけます。  
1. チャートのデータ ワークシートにアクセスします。  
1. シリーズ値を変更してチャート データ シリーズを修正します。  
1. 新しいシリーズを追加し、データを入力します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはチャートの更新方法を示しています:
```c#
const string chartName = "My chart";

// PPTX ファイルを表す Presentation クラスのインスタンスを生成します。
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // チャート データシートのインデックスを設定します。
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

    // チャート付きでプレゼンテーションを保存します。
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```


## **Set Data Range for a Chart**

Aspose.Slides for .NET では、ワークシートの特定範囲をチャート データのソースとして定義できます。これにより、ワークシートの一部をチャートに直接マッピングし、どのセルがシリーズやカテゴリに寄与するかを制御できます。その結果、ワークシートの最新データ変更に合わせてチャートを簡単に更新・同期でき、PowerPoint プレゼンテーションが常に正確な情報を反映します。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. すべてのシェイプを走査してチャートを見つけます。  
1. チャート データにアクセスし、範囲を設定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはチャートのデータ範囲を設定する方法を示しています:
```c#
const string chartName = "My chart";

// PPTX ファイルを表す Presentation クラスのインスタンスを生成します。
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


## **Use Default Markers in Charts**

チャートでデフォルト マーカーを使用すると、各シリーズに自動で異なるマーカー記号が割り当てられます。

この C# コードはシリーズのマーカーを自動設定する方法を示しています:
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

**Aspose.Slides for .NET がサポートするチャート タイプは何ですか？**

Aspose.Slides for .NET は、棒、折れ線、円、エリア、散布、ヒストグラム、レーダーなど、幅広いチャート タイプをサポートしています。この柔軟性により、データ可視化のニーズに最適なチャート タイプを選択できます。

**スライドに新しいチャートを追加するにはどうすればよいですか？**

まず [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、インデックスで目的のスライドを取得します。その後、チャート追加メソッドを呼び出し、チャート タイプと初期データを指定します。この手順でチャートがプレゼンテーションに直接組み込まれます。

**チャートに表示されているデータを更新するには？**

チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスし、既定のシリーズやカテゴリをクリアしてからカスタム データを追加します。これにより、プログラムからチャートを最新データにリフレッシュできます。

**チャートの外観をカスタマイズできますか？**

はい。Aspose.Slides for .NET は豊富なカスタマイズ オプションを提供します。色、フォント、ラベル、凡例、その他の書式設定要素を変更して、チャートの外観を特定のデザイン要件に合わせて調整できます。