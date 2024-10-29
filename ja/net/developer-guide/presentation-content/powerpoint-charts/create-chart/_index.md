---
title: C#または.NETでPowerPointプレゼンテーションチャートを作成または更新
linktitle: チャートを作成または更新
type: docs
weight: 10
url: /ja/net/create-chart/
keywords: "チャートを作成, 散布図, 円グラフ, ツリーマップチャート, 株式チャート, 箱ひげ図, ヒストグラムチャート, ファネルチャート, サンバーストチャート, マルチカテゴリチャート, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションにチャートを作成する"
---

## **チャートを作成**
チャートは、人々がデータを迅速に視覚化し、テーブルやスプレッドシートからはすぐには明らかでない洞察を得るのに役立ちます。

**なぜチャートを作成するのか？**

チャートを使用することで、

* プレゼンテーションの単一スライドに大量のデータを集約、圧縮、要約する
* データのパターンや傾向を明らかにする
* 時間の経過や特定の測定単位に関連してデータの方向性と勢いを推測する
* 異常値、逸脱、誤差、意味のないデータなどを特定する
* 複雑なデータをコミュニケートまたは提示する

PowerPointでは、挿入機能を通じてチャートを作成できます。この機能は、さまざまな種類のチャートをデザインするためのテンプレートを提供します。Aspose.Slidesを使用することで、一般的なチャートタイプに基づく通常のチャートやカスタムチャートを作成することができます。

{{% alert color="primary" %}}

チャートを作成するために、Aspose.Slidesは[Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/)名前空間の下にある[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)列挙体を提供します。この列挙体の値は、さまざまなチャートタイプに対応しています。

{{% /alert %}}

### **通常のチャートを作成する**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを介してスライドの参照を取得します。
1. 一部のデータを使用してチャートを追加し、お好みのチャートタイプを指定します。
1. チャートのタイトルを追加します。
1. チャートデータのワークシートにアクセスします。
1. すべてのデフォルトの系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列の新しいチャートデータを追加します。
1. チャート系列の塗りつぶし色を追加します。
1. チャート系列のラベルを追加します。
1. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このC#コードは、通常のチャートを作成する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation();

// 最初のスライドにアクセス
ISlide sld = pres.Slides[0];

// デフォルトデータを持つチャートを追加
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

// チャートのタイトルを設定
chart.ChartTitle.AddTextFrameForOverriding("サンプルタイトル");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// 最初の系列に値を表示するよう設定
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// チャートデータシートのインデックスを設定
int defaultWorksheetIndex = 0;

// チャートデータワークシートを取得
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// デフォルト生成された系列とカテゴリを削除
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

// 新しい系列を追加
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "系列1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "系列2"), chart.Type);

// 新しいカテゴリを追加
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "カテゴリ1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "カテゴリ2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "カテゴリ3"));

// 最初のチャート系列を取得
IChartSeries series = chart.ChartData.Series[0];

// 系列データを入力する

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// 系列の塗りつぶし色を設定
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// 2番目のチャート系列を取得
series = chart.ChartData.Series[1];

// 系列データを入力
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// 系列の塗りつぶし色を設定
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

// 最初のラベルにカテゴリ名を表示
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

// 系列に3番目のラベルの値を表示するよう設定
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

// PPTXファイルをディスクに保存
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```

### **散布図を作成する**
散布図（散布プロットまたはx-yグラフとも呼ばれる）は、パターンを確認したり、2つの変数の相関関係を示すためによく使用されます。

以下の場合に散布図を使用することを検討できます：

* ペアになった数値データがある
* 2つの変数が互いに良く組み合わさる
* 2つの変数が関連しているかどうかを判断したい
* 独立変数が従属変数に対して複数の値を持っている

このC#コードは、異なるシリーズのマーカーを使用して散布図を作成する方法を示しています：

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

// デフォルトチャートを作成
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

// デフォルトチャートデータワークシートインデックスを取得
int defaultWorksheetIndex = 0;

// チャートデータワークシートを取得
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// デモ系列を削除
chart.ChartData.Series.Clear();

// 新しい系列を追加
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "系列1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "系列2"), chart.Type);

// 最初のチャート系列を取得
IChartSeries series = chart.ChartData.Series[0];

// 系列に新しい点（1:3）を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

// 新しい点（2:10）を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

// 系列タイプを変更
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

// チャート系列マーカーを変更
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

// 2番目のチャート系列を取得
series = chart.ChartData.Series[1];

// チャート系列に新しい点（5:2）を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

// 新しい点（3:1）を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

// 新しい点（2:2）を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

// 新しい点（5:1）を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

// チャート系列マーカーを変更
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

// PPTXファイルをディスクに保存
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```

### **円グラフを作成する**

円グラフは、特にデータにカテゴリラベルが含まれているときに、データ内の部分と全体の関係を示すのに最適です。ただし、データが多くの部分やラベルを含んでいる場合は、代わりに棒グラフを使用することを検討してください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを介してスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、希望するタイプを指定（この場合、`ChartType.Pie`）。
1. チャートデータIChartDataWorkbookにアクセスします。
1. デフォルト系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列の新しいチャートデータを追加します。
1. チャートのセクターにカスタムカラーを追加します。
1. 系列のラベルを設定します。
1. 系列ラベルのリーダーラインを設定します。
1. 円グラフスライドの回転角度を設定します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このC#コードは、円グラフを作成する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスのインスタンスを作成
Presentation presentation = new Presentation();

// 最初のスライドにアクセス
ISlide slides = presentation.Slides[0];

// デフォルトデータを持つチャートを追加
IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// チャートタイトルを設定
chart.ChartTitle.AddTextFrameForOverriding("サンプルタイトル");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// 最初の系列に値を表示するよう設定
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// チャートデータシートのインデックスを設定
int defaultWorksheetIndex = 0;

// チャートデータワークシートを取得
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// デフォルト生成された系列とカテゴリを削除
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

// 新しいカテゴリを追加
chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "第1四半期"));
chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "第2四半期"));
chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "第3四半期"));

// 新しい系列を追加
IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "系列1"), chart.Type);

// 系列データを入力
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// 新しいポイントを追加し、円グラフのセクターの色を設定
// series.IsColorVaried = true;
chart.ChartData.SeriesGroups[0].IsColorVaried = true;

IChartDataPoint point = series.DataPoints[0];
point.Format.Fill.FillType = FillType.Solid;
point.Format.Fill.SolidFillColor.Color = Color.Cyan;

// セクターの境界を設定
point.Format.Line.FillFormat.FillType = FillType.Solid;
point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
point.Format.Line.Width = 3.0;
point.Format.Line.Style = LineStyle.ThinThick;
point.Format.Line.DashStyle = LineDashStyle.DashDot;

IChartDataPoint point1 = series.DataPoints[1];
point1.Format.Fill.FillType = FillType.Solid;
point1.Format.Fill.SolidFillColor.Color = Color.Brown;

// セクターの境界を設定
point1.Format.Line.FillFormat.FillType = FillType.Solid;
point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
point1.Format.Line.Width = 3.0;
point1.Format.Line.Style = LineStyle.Single;
point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

IChartDataPoint point2 = series.DataPoints[2];
point2.Format.Fill.FillType = FillType.Solid;
point2.Format.Fill.SolidFillColor.Color = Color.Coral;

// セクターの境界を設定
point2.Format.Line.FillFormat.FillType = FillType.Solid;
point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
point2.Format.Line.Width = 2.0;
point2.Format.Line.Style = LineStyle.ThinThin;
point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

// 新しい系列の各カテゴリのカスタムラベルを作成
IDataLabel lbl1 = series.DataPoints[0].Label;

// lbl.ShowCategoryName = true;
lbl1.DataLabelFormat.ShowValue = true;

IDataLabel lbl2 = series.DataPoints[1].Label;
lbl2.DataLabelFormat.ShowValue = true;
lbl2.DataLabelFormat.ShowLegendKey = true;
lbl2.DataLabelFormat.ShowPercentage = true;

IDataLabel lbl3 = series.DataPoints[2].Label;
lbl3.DataLabelFormat.ShowSeriesName = true;
lbl3.DataLabelFormat.ShowPercentage = true;

// 系列にチャートのリーダーラインを表示するよう設定
series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

// 円グラフセクターの回転角度を設定
chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

// PPTXファイルをディスクに保存
presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
```

### **折れ線グラフを作成する**

折れ線グラフ（折れ線グラフとも呼ばれる）は、時間の経過による値の変化を示す場合に最適です。折れ線グラフを使用すると、同時に大量のデータを比較したり、時間の経過に伴う変化やトレンドを追跡したり、データ系列の異常を強調したりできます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを介してスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、希望するタイプを指定（この場合、`ChartType.Line`）。
1. チャートデータIChartDataWorkbookにアクセスします。
1. デフォルト系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列の新しいチャートデータを追加します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このC#コードは、折れ線グラフを作成する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);
    
    pres.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

デフォルトでは、折れ線グラフのポイントは直線で結ばれます。ポイントをダッシュで結びたい場合は、次のように好みのダッシュタイプを指定できます：

```c#
IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);

foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

### **ツリーマップチャートを作成する**

ツリーマップチャートは、データカテゴリの相対的なサイズを示したり、各カテゴリに大きな貢献をするアイテムに迅速に注意を引く際に、販売データに最適です。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを介してスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、希望するタイプを指定（この場合、`ChartType.TreeMap`）。
1. チャートデータIChartDataWorkbookにアクセスします。
1. デフォルト系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列の新しいチャートデータを追加します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このC#コードは、ツリーマップチャートを作成する方法を示しています：

```c#
using (Presentation presentation = new Presentation())
{
	IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);
	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	// ブランチ1
	IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "葉1"));
	leaf.GroupingLevels.SetGroupingItem(1, "茎1");
	leaf.GroupingLevels.SetGroupingItem(2, "ブランチ1");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "葉2"));

	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "葉3"));
	leaf.GroupingLevels.SetGroupingItem(1, "茎2");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "葉4"));


	// ブランチ2
	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "葉5"));
	leaf.GroupingLevels.SetGroupingItem(1, "茎3");
	leaf.GroupingLevels.SetGroupingItem(2, "ブランチ2");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "葉6"));

	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "葉7"));
	leaf.GroupingLevels.SetGroupingItem(1, "茎4");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "葉8"));

	IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
	series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 4));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 5));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 3));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 6));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 9));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 9));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 4));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 3));

	series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

	presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

### **株式チャートを作成する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを介してスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、希望するタイプを指定（この場合、`ChartType.OpenHighLowClose`）。
1. チャートデータIChartDataWorkbookにアクセスします。
1. デフォルト系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列の新しいチャートデータを追加します。
1. HiLowLines形式を指定します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このC#コードは、株式チャートを作成する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);
    
	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "A"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "B"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 3, 0, "C"));

	chart.ChartData.Series.Add(wb.GetCell(0, 0, 1, "オープン"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 2, "ハイ"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 3, "ロー"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 4, "クローズ"), chart.Type);

	IChartSeries series = chart.ChartData.Series[0];

	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 1, 72));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 1, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 1, 38));

	series = chart.ChartData.Series[1];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 2, 172));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 2, 57));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 2, 57));

	series = chart.ChartData.Series[2];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 3, 13));

	series = chart.ChartData.Series[3];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 4, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 4, 38));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 4, 50));

	chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
	chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

	foreach (IChartSeries ser in chart.ChartData.Series)
	{
		ser.Format.Line.FillFormat.FillType = FillType.NoFill;
	}

	pres.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

### **箱ひげ図を作成する**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを介してスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、希望するタイプを指定（`ChartType.BoxAndWhisker`）。
1. チャートデータIChartDataWorkbookにアクセスします。
1. デフォルト系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列の新しいチャートデータを追加します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このC#コードは、箱ひげ図を作成する方法を示しています：

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "カテゴリ1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "カテゴリ1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "カテゴリ1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "カテゴリ1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "カテゴリ1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "カテゴリ1"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

		series.QuartileMethod = QuartileMethodType.Exclusive;
		series.ShowMeanLine = true;
		series.ShowMeanMarkers = true;
		series.ShowInnerPoints = true;
		series.ShowOutlierPoints = true;

		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B1", 15));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B2", 41));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B3", 16));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B4", 10));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B5", 23));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B6", 16));

		pres.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
	}
}
```

### **ファネルチャートを作成する**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを介してスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、希望するタイプを指定（`ChartType.Funnel`）。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このC#コードは、ファネルチャートを作成する方法を示しています：

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "カテゴリ1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "カテゴリ2"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "カテゴリ3"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "カテゴリ4"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "カテゴリ5"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "カテゴリ6"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B1", 50));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B2", 100));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B3", 200));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B4", 300));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B5", 400));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B6", 500));

		pres.Save("Funnel.pptx", SaveFormat.Pptx);
	}
}
```

### **サンバーストチャートを作成する**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを介してスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、希望するタイプを指定（この場合、`ChartType.sunburst`）。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このC#コードは、サンバーストチャートを作成する方法を示しています：

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		// ブランチ1
		IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "葉1"));
		leaf.GroupingLevels.SetGroupingItem(1, "茎1");
		leaf.GroupingLevels.SetGroupingItem(2, "ブランチ1");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "葉2"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "葉3"));
		leaf.GroupingLevels.SetGroupingItem(1, "茎2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "葉4"));

		// ブランチ2
		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "葉5"));
		leaf.GroupingLevels.SetGroupingItem(1, "茎3");
		leaf.GroupingLevels.SetGroupingItem(2, "ブランチ2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "葉6"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "葉7"));
		leaf.GroupingLevels.SetGroupingItem(1, "茎4");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "葉8"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
		series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D1", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D2", 5));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D3", 3));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D4", 6));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D5", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D6", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D7", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D8", 3));

		pres.Save("Sunburst.pptx", SaveFormat.Pptx);
	}
}
```

### **ヒストグラムチャートを作成する**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを介してスライドの参照を取得します。 
1. 一部のデータを持つチャートを追加し、希望するチャートタイプ（この場合、`ChartType.Histogram`）を指定します。
1. チャートデータ`IChartDataWorkbook`にアクセスします。
1. デフォルト系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このC#コードは、ヒストグラムチャートを作成する方法を示しています：

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Histogram, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A1", 15));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A2", -41));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A3", 16));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A4", 10));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A5", -23));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A6", 16));

		chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

		pres.Save("Histogram.pptx", SaveFormat.Pptx);
	}
}
```

### **レーダーチャートを作成する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを介してスライドの参照を取得します。 
1. データを持つチャートを追加し、希望するチャートタイプ（この場合、`ChartType.Radar`）を指定します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このC#コードは、レーダーチャートを作成する方法を示しています：

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 400, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

### **マルチカテゴリチャートを作成する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを介してスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、希望するタイプ（ChartType.ClusteredColumn）を指定します。
1. チャートデータIChartDataWorkbookにアクセスします。
1. デフォルト系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列の新しいチャートデータを追加します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このC#コードは、マルチカテゴリチャートを作成する方法を示しています：

```c#
Presentation pres = new Presentation();
ISlide slide = pres.Slides[0];

IChart ch = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
ch.ChartData.Series.Clear();
ch.ChartData.Categories.Clear();

IChartDataWorkbook fact = ch.ChartData.ChartDataWorkbook;
fact.Clear(0);
int defaultWorksheetIndex = 0;

IChartCategory category = ch.ChartData.Categories.Add(fact.GetCell(0, "c2", "A"));
category.GroupingLevels.SetGroupingItem(1, "グループ1");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c3", "B"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c4", "C"));
category.GroupingLevels.SetGroupingItem(1, "グループ2");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c5", "D"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c6", "E"));
category.GroupingLevels.SetGroupingItem(1, "グループ3");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c7", "F"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c8", "G"));
category.GroupingLevels.SetGroupingItem(1, "グループ4");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c9", "H"));

// シリーズを追加
IChartSeries series = ch.ChartData.Series.Add(fact.GetCell(0, "D1", "系列1"),
    ChartType.ClusteredColumn);

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D2", 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D3", 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D4", 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D5", 40));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D6", 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D7", 60));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D8", 70));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D9", 80));

// チャートを含むプレゼンテーションを保存
pres.Save("AsposeChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **マップチャートを作成する**

マップチャートは、データを含む地域の視覚化です。マップチャートは、地理的な領域全体でデータや値を比較するのに最適です。

このC#コードは、マップチャートを作成する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Map, 50, 50, 500, 400);
    pres.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

### **コンビネーションチャートを作成する**

コンビネーションチャート（またはコンボチャート）は、単一のグラフ上に2つ以上のチャートを組み合わせたチャートです。このようなチャートは、データの2組（またはそれ以上）の間の違いを強調表示、比較、レビューすることを可能にします。このようにして、データセットの間の関係を見ることができます。

![combination-chart-ppt](combination-chart-ppt.png)

このC#コードは、PowerPointでコンビネーションチャートを作成する方法を示しています：

```c#
private static void CreateComboChart()
{
    using (Presentation pres = new Presentation())
    {
        IChart chart = CreateChart(pres.Slides[0]);
        AddFirstSeriesToChart(chart);
        AddSecondSeriesToChart(chart);
        pres.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChart(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "系列1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "系列2"), chart.Type);
    
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "カテゴリ1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "カテゴリ2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "カテゴリ3"));

    IChartSeries series = chart.ChartData.Series[0];

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));
    
    series = chart.ChartData.Series[1];
    
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    return chart;
}

private static void AddFirstSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "系列3"), ChartType.ScatterWithSmoothLines);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 0, 1, 3),
        workbook.GetCell(worksheetIndex, 0, 2, 5));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 10),
        workbook.GetCell(worksheetIndex, 1, 4, 13));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 3, 20),
        workbook.GetCell(worksheetIndex, 2, 4, 15));

    series.PlotOnSecondAxis = true;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 5, "系列4"),
        ChartType.ScatterWithStraightLinesAndMarkers);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 5),
        workbook.GetCell(worksheetIndex, 1, 4, 2));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 5, 10),
        workbook.GetCell(worksheetIndex, 1, 6, 7));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 5, 15),
        workbook.GetCell(worksheetIndex, 2, 6, 12));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 3, 5, 12),
        workbook.GetCell(worksheetIndex, 3, 6, 9));
    
    series.PlotOnSecondAxis = true;
}
```

## **チャートの更新**

1. チャートを含むプレゼンテーションを表す[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. スライドのインデックスを介してスライドの参照を取得します。
3. すべてのシェイプをトラバースして、目的のチャートを見つけます。
4. チャートデータワークシートにアクセスします。
5. 系列の値を変更してチャートデータ系列を修正します。
6. 新しい系列を追加して、データを入力します。
7. 修正したプレゼンテーションをPPTXファイルとして書き込む。

このC#コードは、チャートを更新する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation("ExistingChart.pptx");

// 最初のスライドにアクセス
ISlide sld = pres.Slides[0];

// デフォルトデータを持つチャートを追加
IChart chart = (IChart)sld.Shapes[0];

// チャートデータシートのインデックスを設定
int defaultWorksheetIndex = 0;

// チャートデータワークシートを取得
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// チャートカテゴリ名を変更
fact.GetCell(defaultWorksheetIndex, 1, 0, "修正されたカテゴリ1");
fact.GetCell(defaultWorksheetIndex, 2, 0, "修正されたカテゴリ2");

// 最初のチャート系列を取得
IChartSeries series = chart.ChartData.Series[0];

// 系列データを更新
fact.GetCell(defaultWorksheetIndex, 0, 1, "新しい系列1");// 系列名を修正
series.DataPoints[0].Value.Data = 90;
series.DataPoints[1].Value.Data = 123;
series.DataPoints[2].Value.Data = 44;

// 2番目のチャート系列を取得
series = chart.ChartData.Series[1];

// 系列データを更新
fact.GetCell(defaultWorksheetIndex, 0, 2, "新しい系列2");// 系列名を修正
series.DataPoints[0].Value.Data = 23;
series.DataPoints[1].Value.Data = 67;
series.DataPoints[2].Value.Data = 99;

// 新しい系列を追加
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 3, "系列3"), chart.Type);

// 3番目のチャート系列を取得
series = chart.ChartData.Series[2];

// 系列データを入力
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 3, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 30));

chart.Type = ChartType.ClusteredCylinder;

// チャートを含むプレゼンテーションを保存
pres.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
```

## **チャートのデータ範囲を設定する**

1. チャートを含むプレゼンテーションを表す[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. スライドのインデックスを介してスライドの参照を取得します。
3. すべてのシェイプをトラバースして、目的のチャートを見つけます。
4. チャートデータにアクセスし、範囲を設定します。
5. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

このC#コードは、チャートのデータ範囲を設定する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスのインスタンスを作成
Presentation presentation = new Presentation("ExistingChart.pptx");

// デフォルトデータを持つチャートを追加
ISlide slide = presentation.Slides[0];
IChart chart = (IChart)slide.Shapes[0];
chart.ChartData.SetRange("Sheet1!A1:B4");
presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
```

## **チャート内でデフォルトマーカーを使用する**
チャート内でデフォルトマーカーを使用する場合、各チャート系列は自動的に異なるデフォルトマーカーシンボルを取得します。

このC#コードは、チャート系列マーカーを自動的に設定する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;
    chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "系列1"), chart.Type);
    IChartSeries series = chart.ChartData.Series[0];

    chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 1, 24));
    chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 1, 23));
    chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 1, -10));
    chart.ChartData.Categories.Add(fact.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 1, null));

    chart.ChartData.Series.Add(fact.GetCell(0, 0, 2, "系列2"), chart.Type);
    // 2番目のチャート系列を取得
    IChartSeries series2 = chart.ChartData.Series[1];

    // 系列データを入力
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    pres.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```