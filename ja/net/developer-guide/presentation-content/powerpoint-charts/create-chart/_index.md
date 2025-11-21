---
title: .NETでPowerPointプレゼンテーションのチャートを作成または更新
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
- 複合カテゴリチャート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPointプレゼンテーションのチャートをAspose.Slides for .NETで作成およびカスタマイズします。C#の実用的なコード例でチャートの追加、書式設定、編集を行えます。"
---

## **概要**

本稿では、Aspose.Slides for .NET を使用してチャートを作成およびカスタマイズするための包括的なガイドを提供します。スライドにプログラムでチャートを追加し、データを設定し、特定のデザイン要件に合わせたさまざまな書式設定オプションを適用する方法を学びます。記事全体で、プレゼンテーションとチャートオブジェクトの初期化からシリーズ、軸、凡例の設定まで、各手順を示す詳細なコード例が示されています。本ガイドに従うことで、.NET アプリケーションに動的チャート生成を統合する方法を確実に理解し、データ主導のプレゼンテーション作成プロセスを効率化できます。

## **チャートの作成**

チャートは、データを迅速に可視化し、表やスプレッドシートだけではすぐに分からない洞察を得るのに役立ちます。

**チャートを作成する理由**

チャートを使用すると、次のことが可能になります。

* 大量のデータをプレゼンテーションの単一スライドに集約、要約、圧縮できる
* データのパターンやトレンドを明らかにできる
* 時間経過や特定の測定単位に対するデータの方向性と勢いを推測できる
* 外れ値、異常、誤差、意味のないデータを検出できる
* 複雑なデータを伝達または提示できる

PowerPoint では、*挿入* 機能を使って多くのチャートテンプレートからデザインできます。Aspose.Slides を使用すれば、一般的なチャートタイプに基づく標準チャートとカスタムチャートの両方を作成できます。

{{% alert color="primary" %}} 
[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体は [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) 名前空間にあります。この列挙体の値はさまざまなチャートタイプに対応しています。
{{% /alert %}} 

### **クラスター化縦棒グラフの作成**

このセクションでは、Aspose.Slides for .NET を使用してクラスター化縦棒グラフを作成する方法を説明します。プレゼンテーションの初期化、チャートの追加、タイトル、データ、シリーズ、カテゴリ、スタイリングなどの要素のカスタマイズ方法を学びます。以下の手順で標準的なクラスター化縦棒グラフが生成されます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. データを設定し、`ChartType.ClusteredColumn` タイプを指定してチャートを追加します。  
1. チャートにタイトルを追加します。  
1. チャートのデータ ワークシートにアクセスします。  
1. 既定のシリーズとカテゴリをすべてクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいチャート データを追加します。  
1. チャートシリーズに塗りつぶし色を適用します。  
1. チャートシリーズにラベルを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはクラスター化縦棒グラフの作成方法を示しています:
```c#
// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    // デフォルトデータを持つクラスター化縦棒グラフを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // チャートのタイトルを設定します。
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // 最初の系列に値を表示するように設定します。
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // チャートデータシートのインデックスを設定します。
    int worksheetIndex = 0;

    // チャートデータ ワークブックを取得します。
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

    // 系列のデータを入力します。
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // 系列の塗りつぶし色を設定します。
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // 2 番目のチャート系列を取得します。
    series = chart.ChartData.Series[1];

    // 系列のデータを入力します。
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // 系列の塗りつぶし色を設定します。
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // 最初のラベルにカテゴリ名を表示するよう設定します。
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // 3 番目のラベルに値を表示するよう系列を設定します。
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // プレゼンテーションを PPTX ファイルとしてディスクに保存します。
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```


結果:

![クラスター化縦棒グラフ](clustered_column_chart.png)

### **散布図の作成**

散布図（別名散布プロットまたは x‑y グラフ）は、2 つの変数間のパターンや相関関係を確認する際に頻繁に使用されます。

散布図を使用するケース:

* ペアになった数値データがある場合  
* 2 つの変数が相互にペアになる場合  
* 2 変数が関連しているかどうかを判断したい場合  
* 従属変数に対して独立変数が複数の値を持つ場合  

この C# コードは、異なるマーカー系列を持つ散布図の作成方法を示しています:
```c#
    // Presentation クラスをインスタンス化します。
    using (Presentation presentation = new Presentation())
    {
        // 最初のスライドにアクセスします。
        ISlide slide = presentation.Slides[0];

        // デフォルトの散布図チャートを作成します。
        IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

        // チャートデータシートのインデックスを設定します。
        int worksheetIndex = 0;

        // チャートデータ ワークブックを取得します。
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

        // 2番目のチャート系列を取得します。
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

![散布図](scatter_chart.png)

### **円グラフの作成**

円グラフは、カテゴリラベルと数値が紐付いたデータの部分‑全体関係を示すのに最適です。ただし、項目やラベルが多数ある場合は棒グラフの方が適しています。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データを使用し、`ChartType.Pie` タイプを指定してチャートを追加します。  
1. チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいチャート データを追加します。  
1. 円グラフの各セクタにカスタム色を適用しながら新しいポイントを追加します。  
1. 系列のラベルを設定します。  
1. 系列ラベルにリーダーラインを有効にします。  
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

        // 最初の系列に値を表示するよう設定します。
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

        // 新しい系列の各カテゴリにカスタム ラベルを作成します。
        IDataLabel label1 = series.DataPoints[0].Label;

        label1.DataLabelFormat.ShowValue = true;

        IDataLabel label2 = series.DataPoints[1].Label;
        label2.DataLabelFormat.ShowValue = true;
        label2.DataLabelFormat.ShowLegendKey = true;
        label2.DataLabelFormat.ShowPercentage = true;

        IDataLabel label3 = series.DataPoints[2].Label;
        label3.DataLabelFormat.ShowSeriesName = true;
        label3.DataLabelFormat.ShowPercentage = true;

        // 系列にリーダー ラインを表示させます。
        series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

        // 円グラフのセクタの回転角度を設定します。
        chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

        // プレゼンテーションを PPTX ファイルとしてディスクに保存します。
        presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
    }
```


結果:

![円グラフ](pie_chart.png)

### **折れ線グラフの作成**

折れ線グラフ（別名折れ線チャート）は、時間経過に伴う値の変化を示すのに最適です。折れ線グラフを使用すると、膨大なデータを一度に比較したり、時間経過による変化やトレンドを追跡したり、データ系列の異常を強調したりできます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データを使用し、`ChartType.Line` タイプを指定してチャートを追加します。  
1. チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいチャート データを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは折れ線グラフの作成方法を示しています:
```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```


デフォルトでは、折れ線グラフのポイントは直線で結ばれます。破線で結びたい場合は、次のように破線タイプを指定できます:
```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```


結果:

![折れ線グラフ](line_chart.png)

### **ツリーマップ グラフの作成**

ツリーマップ グラフは、カテゴリごとのデータサイズを相対的に示し、各カテゴリ内で大きな貢献度を持つ項目に注目させたい販売データに最適です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データを使用し、`ChartType.Treemap` タイプを指定してチャートを追加します。  
1. チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいチャート データを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはツリーマップ グラフの作成方法を示しています:
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

![ツリーマップ グラフ](treemap_chart.png)

### **株価チャートの作成**

株価チャートは、始値・高値・安値・終値などの金融データを表示し、市場のトレンドや変動性を分析するのに役立ちます。投資家やアナリストが情報に基づいた判断を下すための重要なインサイトを提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データを使用し、`ChartType.OpenHighLowClose` タイプを指定してチャートを追加します。  
1. チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいチャート データを追加します。  
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

![株価チャート](stock_chart.png)

### **箱ひげ図の作成**

箱ひげ図は、中央値・四分位数・外れ値などの主要な統計指標をまとめてデータの分布を示すのに使用されます。探索的データ分析や統計的研究で、データの変動性や異常を迅速に把握するのに役立ちます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データを使用し、`ChartType.BoxAndWhisker` タイプを指定してチャートを追加します。  
1. チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいチャート データを追加します。  
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


### **ファンネル チャートの作成**

ファンネル チャートは、段階的にデータ量が減少していくプロセスを可視化します。コンバージョン率の分析、ボトルネックの特定、販売やマーケティングプロセスの効率測定に特に有用です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データを使用し、`ChartType.Funnel` タイプを指定してチャートを追加します。  
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

![ファンネル チャート](funnel_chart.png)

### **サンバースト チャートの作成**

サンバースト チャートは階層データを同心円状に可視化し、部分‑全体の関係を示します。入れ子になったカテゴリやサブカテゴリをコンパクトに表現するのに適しています。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データを使用し、`ChartType.Sunburst` タイプを指定してチャートを追加します。  
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

![サンバースト チャート](sunburst_chart.png)

### **ヒストグラム チャートの作成**

ヒストグラムは数値データを範囲（ビン）に分割して分布を表現します。頻度・歪み・散布のパターンや外れ値の検出に役立ちます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. データを設定し、`ChartType.Histogram` タイプを指定してチャートを追加します。  
1. チャート データ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはヒストグラム チャートの作成方法を示しています:
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

![ヒストグラム チャート](histogram_chart.png)

### **レーダー チャートの作成**

レーダー チャートは多変量データを二次元で表現し、複数の変数を同時に比較できます。パフォーマンス指標や属性の強み・弱みを視覚的に把握するのに適しています。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データを使用し、`ChartType.Radar` タイプを指定してチャートを追加します。  
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

![レーダー チャート](radar_chart.png)

### **複合カテゴリ チャートの作成**

複合カテゴリ チャートは、複数のカテゴリグループが絡むデータを同時に表示し、複数次元での比較を可能にします。複雑な多層データセットの傾向や関係性を分析するのに便利です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データを使用し、`ChartType.ClusteredColumn` タイプを指定してチャートを追加します。  
1. チャート データ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズ用の新しいチャート データを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは複合カテゴリ チャートの作成方法を示しています:
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

![複合カテゴリ チャート](multi_category_chart.png)

### **マップ チャートの作成**

マップ チャートは、国・州・都市などの特定の場所に情報をマッピングして地理データを可視化します。地域別トレンドや人口統計、空間分布を明快かつ視覚的に分析するのに適しています。

この C# コードはマップ チャートの作成方法を示しています:
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```


結果:

![マップ チャート](map_chart.png)

### **組み合わせチャートの作成**

組み合わせチャート（コンボチャート）は、単一のグラフ内に2種以上のチャートタイプを組み合わせます。これにより、複数のデータセット間の関係性や差異を強調・比較できます。

![組み合わせチャート](combination_chart.png)

以下の C# コードは、上記の組み合わせチャートを PowerPoint プレゼンテーションに作成する方法を示しています:
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

    // 垂直の主目盛線の色を設定します
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // 2 次水平軸を設定します
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // 2 次垂直軸を設定します
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

Aspose.Slides for .NET を使用すると、チャート データ、書式設定、スタイリングを変更して PowerPoint のチャートを更新できます。この機能により、プレゼンテーションを動的コンテンツで最新の状態に保ち、チャートが現在のデータとビジュアル基準を正確に反映するようにできます。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. すべてのシェイプを走査してチャートを見つけます。  
1. チャートのデータ ワークシートにアクセスします。  
1. シリーズ値を変更してチャート データ系列を修正します。  
1. 新しいシリーズを追加し、そのデータを入力します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはチャートの更新方法を示しています:
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

            // 系列データを設定します。
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


## **チャートのデータ範囲設定**

Aspose.Slides for .NET では、ワークシートの特定範囲をチャート データのソースとして定義できます。これにより、ワークシートの一部をチャートに直接マッピングし、どのセルがシリーズやカテゴリに寄与するかを制御できます。その結果、ワークシートのデータが変更されるたびにチャートを簡単に更新・同期でき、PowerPoint のプレゼンテーションが常に最新かつ正確な情報を反映します。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. すべてのシェイプを走査してチャートを見つけます。  
1. チャート データにアクセスし、範囲を設定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはチャートのデータ範囲設定方法を示しています:
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

デフォルト マーカーを使用すると、各チャート系列に自動的に異なるマーカー記号が割り当てられます。

この C# コードはチャート系列のマーカーを自動的に設定する方法を示しています:
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

Aspose.Slides for .NET は、棒グラフ、折れ線グラフ、円グラフ、エリア グラフ、散布図、ヒストグラム、レーダー グラフなど、幅広いチャートタイプをサポートしています。この柔軟性により、データ可視化のニーズに最適なチャートタイプを選択できます。

**スライドに新しいチャートを追加するには？**

まず [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、インデックスで目的のスライドを取得します。次に、チャートタイプと初期データを指定してチャートを追加するメソッドを呼び出します。この手順でチャートがプレゼンテーションに直接組み込まれます。

**チャートに表示されるデータを更新するには？**

チャートのデータ ワークブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスし、既定の系列とカテゴリをクリアしてからカスタム データを追加します。これにより、プログラムからチャートを最新のデータにリフレッシュできます。

**チャートの外観をカスタマイズできますか？**

はい。Aspose.Slides for .NET では、色、フォント、ラベル、凡例、その他の書式設定要素を変更して、チャートの外観を特定のデザイン要件に合わせて柔軟にカスタマイズできます。