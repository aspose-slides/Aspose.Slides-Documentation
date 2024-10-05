---
title: プレゼンテーションにチャートを作成する方法
type: docs
weight: 30
url: /net/how-to-create-charts-in-a-presentation/
---

{{% alert color="primary" %}} 

新しい[Aspose.Slides for .NET API](/slides/net/)がリリースされ、これによりこの単一製品はゼロからPowerPointドキュメントを生成し、既存のものを編集する機能をサポートします。

{{% /alert %}} 
## **レガシーコードのサポート**
Aspose.Slides for .NETの13.x以前のバージョンで開発されたレガシーコードを使用するには、いくつかの軽微な変更をコードに加える必要があり、その後は以前と同様に動作します。以前のAspose.Slides for .NETにあったAspose.SlideおよびAspose.Slides.Pptx名前空間内のすべてのクラスは、現在は単一のAspose.Slides名前空間に統合されています。以下のレガシーAspose.Slides APIを使用してプレゼンテーションからゼロから通常のチャートを作成するための簡単なコードスニペットを見て、新しい統合APIへの移行手順に従ってください。
## **レガシーAspose.Slides for .NETアプローチ**
```c#
//PPTXファイルを表すPresentationExクラスをインスタンス化
using (PresentationEx pres = new PresentationEx())
{
	//最初のスライドにアクセス
	SlideEx sld = pres.Slides[0];

	//デフォルトデータでチャートを追加
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//チャートタイトルの設定
	chart.ChartTitle.Text.Text = "サンプルタイトル";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//最初の系列を値を表示するように設定
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//チャートデータシートのインデックスを設定
	int defaultWorksheetIndex = 0;

	//チャートデータワークシートを取得
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//デフォルト生成された系列とカテゴリを削除
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//新しい系列を追加
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.Type);

	//新しいカテゴリを追加
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "カテゴリ 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "カテゴリ 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "カテゴリ 3"));

	//最初のチャート系列を取得
	ChartSeriesEx series = chart.ChartData.Series[0];

	//系列データをポップulate
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//系列の塗りつぶし色を設定
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//第二のチャート系列を取得
	series = chart.ChartData.Series[1];

	//系列データをポップulate
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//系列の塗りつぶし色を設定
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//新しい系列の各カテゴリのカスタムラベルを作成

	//最初のラベルはカテゴリ名を表示
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//第二ラベルに系列名を表示
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//第三ラベルに値を表示
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//値とカスタムテキストを表示
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "私のテキスト";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//チャートを含むプレゼンテーションを保存
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **新しいAspose.Slides for .NET 13.xアプローチ**
``` csharp
//PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();

//最初のスライドにアクセス
ISlide sld = pres.Slides[0];

//デフォルトデータでチャートを追加
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//チャートタイトルの設定
//chart.ChartTitle.TextFrameForOverriding.Text = "サンプルタイトル";
chart.ChartTitle.AddTextFrameForOverriding("サンプルタイトル");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//最初の系列を値を表示するように設定
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//チャートデータシートのインデックスを設定
int defaultWorksheetIndex = 0;

//チャートデータワークシートを取得
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//デフォルト生成された系列とカテゴリを削除
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//新しい系列を追加
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.Type);

//新しいカテゴリを追加
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "カテゴリ 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "カテゴリ 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "カテゴリ 3"));

//最初のチャート系列を取得
IChartSeries series = chart.ChartData.Series[0];

//系列データをポップulate
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//系列の塗りつぶし色を設定
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//第二のチャート系列を取得
series = chart.ChartData.Series[1];

//系列データをポップulate
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//系列の塗りつぶし色を設定
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//新しい系列の各カテゴリのカスタムラベルを作成

//最初のラベルはカテゴリ名を表示
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//第三ラベルに値を表示
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//チャートを含むプレゼンテーションを保存
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

以下のレガシーAspose.Slides APIを使用してプレゼンテーションからゼロから散布図を作成するための簡単なコードスニペットを見て、新しい統合APIでそれを達成する方法を確認してください。

## **レガシーAspose.Slides for .NETアプローチ**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //デフォルトのチャートを作成
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //デフォルトチャートデータワークシートインデックスを取得
    int defaultWorksheetIndex = 0;

    //チャートデータワークシートにアクセス
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //デモ系列を削除
    chart.ChartData.Series.Clear();

    //新しい系列を追加
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "系列 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "系列 2"), chart.Type);

    //最初のチャート系列を取得
    ChartSeriesEx series = chart.ChartData.Series[0];

    //新しいポイント(1:3)を追加
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //新しいポイント(2:10)を追加
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //系列のタイプを編集
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //チャート系列マーカーを変更
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //第二のチャート系列を取得
    series = chart.ChartData.Series[1];

    //新しいポイント(5:2)を追加
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //新しいポイント(3:1)を追加
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //新しいポイント(2:2)を追加
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //新しいポイント(5:1)を追加
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //チャート系列マーカーを変更
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **新しいAspose.Slides for .NET 13.xアプローチ**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//デフォルトのチャートを作成
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//デフォルトチャートデータワークシートインデックスを取得
int defaultWorksheetIndex = 0;

//チャートデータワークシートにアクセス
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//デモ系列を削除
chart.ChartData.Series.Clear();

//新しい系列を追加
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "系列 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "系列 2"), chart.Type);

//最初のチャート系列を取得
IChartSeries series = chart.ChartData.Series[0];

//新しいポイント(1:3)を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//新しいポイント(2:10)を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//系列のタイプを編集
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//チャート系列マーカーを変更
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//第二のチャート系列を取得
series = chart.ChartData.Series[1];

//新しいポイント(5:2)を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//新しいポイント(3:1)を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//新しいポイント(2:2)を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//新しいポイント(5:1)を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//チャート系列マーカーを変更
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```