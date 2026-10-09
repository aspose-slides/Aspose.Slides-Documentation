---
title: PowerPoint プレゼンテーションのチャートを作成または更新する (.NET)
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションのチャートを作成およびカスタマイズします。実用的な C# のコード例でチャートを追加、書式設定、編集できます。"
---
## **概要**

この記事では、Aspose.Slides for .NET を使用してチャートを作成およびカスタマイズする方法について包括的に解説します。スライドにプログラムでチャートを追加し、データを設定し、特定のデザイン要件に合わせてさまざまな書式設定オプションを適用する方法を学びます。記事全体で、プレゼンテーションとチャート オブジェクトの初期化から系列、軸、凡例の設定まで、各ステップを示す詳細なコード例が掲載されています。このガイドに従うことで、.NET アプリケーションに動的なチャート生成を統合し、データ駆動型プレゼンテーションの作成プロセスを効率化する方法をしっかりと習得できます。

## **チャートの作成**

チャートは、データを素早く視覚化し、表やスプレッドシートではすぐに分からない洞察を得るのに役立ちます。

**なぜチャートを作成するのか？**

チャートを使用すると、次のことが可能です。

* プレゼンテーションの 1 枚のスライドに大量のデータを集約、要約、または凝縮できる
* データのパターンやトレンドを明らかにできる
* 時間の経過や特定の測定単位に対するデータの方向性や勢いを推測できる
* 外れ値、異常、偏差、エラー、意味のないデータを発見できる
* 複雑なデータを効果的に伝達できる

PowerPoint では *挿入* 機能を使って多くのチャートテンプレートからチャートを作成できます。Aspose.Slides を使用すると、一般的なチャートタイプに基づく標準チャートと、カスタムチャートの両方を作成できます。

{{% alert color="info" %}} 
[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体は、[Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) 名前空間にあります。この列挙体の値はさまざまなチャートタイプに対応しています。
{{% /alert %}}

### **クラスター化された縦棒グラフの作成**

このセクションでは、Aspose.Slides for .NET を使用してクラスター化された縦棒グラフを作成する方法を説明します。プレゼンテーションの初期化、チャートの追加、タイトル、データ、系列、カテゴリ、スタイリングなどの要素のカスタマイズ方法を学びます。以下の手順に従って、標準的なクラスター化縦棒グラフがどのように生成されるかをご確認ください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `ChartType.ClusteredColumn` タイプを指定してデータ付きのチャートを追加します。  
1. チャートにタイトルを追加します。  
1. チャートのデータ ワークシートにアクセスします。  
1. すべての既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. チャート系列の新しいデータを追加します。  
1. チャート系列に塗りつぶし色を適用します。  
1. チャート系列にラベルを追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはクラスター化縦棒グラフの作成方法を示しています：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    // デフォルトデータでクラスター化縦棒チャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // チャートのタイトルを設定します。
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // チャート データ シートのインデックスを設定します。
    int worksheetIndex = 0;

    // チャート データ ブックを取得します。
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

散布図（別名散布プロットまたは x‑y グラフ）は、2 つの変数間のパターンや相関関係を確認するために頻繁に使用されます。

次の場合に散布図を使用します。

* ペアになった数値データがあるとき  
* 2 つの変数がよくペアになるとき  
* 2 変数が関連しているかどうかを判断したいとき  
* 従属変数に対して複数の独立変数の値があるとき  

この C# コードは、異なるマーカー系列を持つ散布図の作成方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    // デフォルトの散布図チャートを作成します。
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // チャート データ シートのインデックスを設定します。
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

![散布図](scatter_chart.png)

### **円グラフの作成**

円グラフは、データの全体に対する部分の関係を示すのに最適です。特に、カテゴリ ラベルと数値が組み合わさったデータに適しています。ただし、要素やラベルが多数ある場合は、棒グラフの使用を検討してください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `ChartType.Pie` タイプを指定して既定データのチャートを追加します。  
1. チャートのデータ ブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. チャート系列の新しいデータを追加します。  
1. 円グラフのセクターにカスタムカラーを適用しながら新しいポイントを追加します。  
1. 系列のラベルを設定します。  
1. 系列ラベルにリーダーラインを有効にします。  
1. 円グラフの回転角度を設定します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは円グラフの作成方法を示しています：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

    // チャート データ シートのインデックスを設定します。
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

    // セクターの色を設定します。
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // セクターの枠線を設定します。
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // セクターの枠線を設定します。
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // セクターの枠線を設定します。
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

    // 円グラフのセクターの回転角度を設定します。
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // プレゼンテーションを PPTX ファイルとしてディスクに保存します。
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

結果:

![円グラフ](pie_chart.png)

### **折れ線グラフの作成**

折れ線グラフ（別名折れ線チャート）は、時間経過に伴う値の変化を示すのに最適です。折れ線グラフを使用すると、大量のデータを一度に比較したり、時間にわたる変化やトレンドを追跡したり、系列内の異常を強調したりできます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `ChartType.Line` タイプを指定して既定データのチャートを追加します。  
1. チャートのデータ ブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. チャート系列の新しいデータを追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは折れ線グラフの作成方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

デフォルトでは、折れ線グラフの点は直線で連結されます。点を破線で結びたい場合は、次のように破線タイプを指定できます：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    foreach (IChartSeries series in lineChart.ChartData.Series)
    {
        series.Format.Line.DashStyle = LineDashStyle.Dash;
    }
}
```

結果:

![折れ線グラフ](line_chart.png)

### **ツリーマップチャートの作成**

ツリーマップチャートは、売上データなどでカテゴリごとのデータサイズの相対的な大きさを示し、各カテゴリ内で大きな貢献をしている項目に注意を引きやすくするのに最適です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `ChartType.Treemap` タイプを指定して既定データのチャートを追加します。  
1. チャートのデータ ブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. チャート系列の新しいデータを追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはツリーマップチャートの作成方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![ツリーマップチャート](treemap_chart.png)

### **株価チャートの作成**

株価チャートは、始値・高値・安値・終値などの金融データを表示し、市場トレンドやボラティリティを分析するために使用されます。投資家やアナリストが情報に基づいた意思決定を行うための重要なインサイトを提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `ChartType.OpenHighLowClose` タイプを指定して既定データのチャートを追加します。  
1. チャートのデータ ブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. チャート系列の新しいデータを追加します。  
1. HiLowLines の書式を指定します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは株価チャートの作成方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

箱ひげ図は、中央値、四分位数、外れ値などの主要な統計指標を要約してデータの分布を表示します。探索的データ分析や統計調査で、データの変動性や異常を迅速に把握するのに役立ちます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `ChartType.BoxAndWhisker` タイプを指定して既定データのチャートを追加します。  
1. チャートのデータ ブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. チャート系列の新しいデータを追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは箱ひげ図の作成方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

### **ファンネルチャートの作成**

ファンネルチャートは、ステップが進むにつれてデータ量が減少するプロセスを可視化する際に使用します。コンバージョン率の分析やボトルネックの特定、販売やマーケティングプロセスの効率追跡に特に有用です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `ChartType.Funnel` タイプを指定して既定データのチャートを追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはファンネルチャートの作成方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![ファンネルチャート](funnel_chart.png)

### **サンバーストチャートの作成**

サンバーストチャートは階層データを同心円状のリングで表現し、部分と全体の関係を示します。入れ子構造のカテゴリやサブカテゴリをコンパクトかつ明瞭に表現するのに最適です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `ChartType.Sunburst` タイプを指定して既定データのチャートを追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはサンバーストチャートの作成方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![サンバーストチャート](sunburst_chart.png)

### **ヒストグラムチャートの作成**

ヒストグラムチャートは、数値データを区間（ビン）に分けて分布を表します。頻度、歪み、散らばりなどのパターンや、データセット内の外れ値を特定するのに役立ちます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `ChartType.Histogram` タイプを指定してデータ付きのチャートを追加します。  
1. チャートのデータ ブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはヒストグラムチャートの作成方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![ヒストグラムチャート](histogram_chart.png)

### **レーダー チャートの作成**

レーダー チャートは、複数の変数を二次元で同時に比較できるように表示します。パフォーマンス指標や属性の強み・弱みを視覚的に把握するのに適しています。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `ChartType.Radar` タイプを指定してデータ付きのチャートを追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはレーダー チャートの作成方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

結果:

![レーダー チャート](radar_chart.png)

### **マルチカテゴリ チャートの作成**

マルチカテゴリ チャートは、複数のカテゴリ グループを同時に表示し、複数次元にわたる値を比較できるようにします。複合的で階層的なデータセットのトレンドや関係性を分析する際に便利です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `ChartType.ClusteredColumn` タイプを指定して既定データのチャートを追加します。  
1. チャートのデータ ブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスします。  
1. 既定の系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. チャート系列の新しいデータを追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはマルチカテゴリ チャートの作成方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![マルチカテゴリ チャート](multi_category_chart.png)

### **地図チャートの作成**

地図チャートは、国や州、都市などの特定の場所に情報をマッピングすることで地理データを可視化します。地域別のトレンドや人口統計データ、空間分布を視覚的に把握するのに有効です。

この C# コードは地図チャートの作成方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

結果:

![地図チャート](map_chart.png)

{{% alert color="info" %}} 
上図は PowerPoint で開いた保存済みプレゼンテーションを示します。Aspose.Slides は地図チャートとそのデータを書き出しますが、画像や PDF、SVG へレンダリングした場合はチャート領域が空白になります。同じスライド内の他の図形は影響を受けません。
{{% /alert %}}

### **組み合わせチャートの作成**

組み合わせチャート（コンボチャート）は、1 つのグラフ内に 2 つ以上のチャート タイプを組み合わせます。このチャートを使用すると、複数のデータセット間の違いをハイライト、比較、検証でき、相互関係を把握しやすくなります。

![組み合わせチャート](combination_chart.png)

以下の C# コードは、上図の組み合わせチャートを PowerPoint プレゼンテーションに作成する方法を示しています：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

    // チャートのタイトルを設定します。
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // チャートの凡例を設定します。
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // デフォルトで生成された系列とカテゴリを削除します。
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 新しいカテゴリを追加します。
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // 最初の系列を追加します。
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
    // 水平軸を設定します。
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // 垂直軸を設定します。
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // 垂直の主要グリッドラインの色を設定します。
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // 二次水平軸を設定します。
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // 二次垂直軸を設定します。
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

Aspose.Slides for .NET を使用すると、チャート データ、書式設定、スタイルを変更して PowerPoint のチャートを更新できます。この機能により、プレゼンテーションを動的コンテンツで最新の状態に保ち、チャートが現在のデータとビジュアル標準を正確に反映するようにできます。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. すべてのシェイプを走査してチャートを見つけます。  
1. チャートのデータ ワークシートにアクセスします。  
1. 系列の値を変更してチャート データ系列を修正します。  
1. 新しい系列を追加し、そのデータを入力します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはチャートの更新方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

            // 系列のデータを更新します。
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // 系列名を変更しています。
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // 2 番目のチャート系列を取得します。
            series = chart.ChartData.Series[1];

            // 系列のデータを更新します。
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

## **チャートのデータ範囲の設定**

既存のチャートで使用されている範囲を確認するには、[Retrieve a Chart's Data Range](/slides/ja/net/chart-workbook/#retrieve-a-charts-data-range) を参照してください。

Aspose.Slides for .NET は、ワークシート内の特定のデータ範囲をチャート データのソースとして定義する柔軟性を提供します。これにより、ワークシートの一部を直接チャートにマッピングでき、どのセルが系列やカテゴリに貢献するかを制御できます。その結果、ワークシートの最新データ変更に合わせてチャートを簡単に更新・同期でき、PowerPoint のプレゼンテーションが常に正確な情報を反映します。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. すべてのシェイプを走査してチャートを見つけます。  
1. チャート データを取得し、範囲を設定します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードはチャートのデータ範囲を設定する方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

チャートでデフォルト マーカーを使用すると、各系列に自動的に異なる既定のマーカー記号が割り当てられます。

この C# コードは、チャート系列のマーカーを自動的に設定する方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

Aspose.Slides for .NET は、棒グラフ、折れ線グラフ、円グラフ、エリア グラフ、散布図、ヒストグラム、レーダー チャートなど、多種多様なチャートタイプをサポートしています。この柔軟性により、データ可視化のニーズに最適なチャートタイプを選択できます。

**スライドに新しいチャートを追加するにはどうすればよいですか？**

まず [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、インデックスで目的のスライドを取得します。その後、チャートを追加するメソッドを呼び出し、チャートタイプと初期データを指定します。このプロセスでチャートがプレゼンテーションに直接組み込まれます。

**チャートに表示されるデータを更新するにはどうすればよいですか？**

チャートのデータ ブック ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) にアクセスし、既定の系列やカテゴリをクリアした上でカスタム データを追加します。これにより、最新のデータを反映するようにプログラムでチャートを更新できます。

**チャートの外観をカスタマイズできますか？**

はい。Aspose.Slides for .NET は豊富なカスタマイズ オプションを提供します。色、フォント、ラベル、凡例、その他の書式設定要素を変更して、チャートの外観を特定のデザイン要件に合わせて調整できます。