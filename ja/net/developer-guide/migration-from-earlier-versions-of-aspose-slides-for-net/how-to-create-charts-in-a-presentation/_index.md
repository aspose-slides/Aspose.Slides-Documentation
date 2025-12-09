---
title: .NET でプレゼンテーションにチャートを作成する方法
linktitle: チャートの作成
type: docs
weight: 30
url: /ja/net/how-to-create-charts-in-a-presentation/
keywords:
- 移行
- チャート作成
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して、.NET で PowerPoint PPT、PPTX、ODP プレゼンテーションにレガシーおよびモダンチャート API の両方でチャートを作成する方法を学びます。"
---

{{% alert color="primary" %}} 
新しい [Aspose.Slides for .NET API](/slides/ja/net/) がリリースされ、現在この単一製品は最初から PowerPoint ドキュメントを生成し、既存のものを編集する機能をサポートしています。
{{% /alert %}} 
## **レガシーコードのサポート**
Aspose.Slides for .NET 13.x より前のバージョンで開発されたレガシーコードを使用するには、コードにいくつかの小さな変更を加える必要がありますが、コードは以前と同様に動作します。旧 Aspose.Slides for .NET の Aspose.Slide と Aspose.Slides.Pptx 名前空間に存在したすべてのクラスは、現在単一の Aspose.Slides 名前空間に統合されています。レガシー Aspose.Slides API を使用してプレゼンテーションで最初から通常のチャートを作成する簡単なコードスニペットを以下に示しますので、新しい統合 API への移行手順をご確認ください。
## **レガシー Aspose.Slides for .NET アプローチ**
```c#
//PPTX ファイルを表す PresentationEx クラスをインスタンス化
using (PresentationEx pres = new PresentationEx())
{
	//最初のスライドにアクセス
	SlideEx sld = pres.Slides[0];

	// デフォルトデータでチャートを追加
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//チャートのタイトルを設定
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//最初のシリーズに値の表示を設定
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//チャートデータシートのインデックスを設定
	int defaultWorksheetIndex = 0;

	//チャートデータのワークシートを取得
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//デフォルトで生成されたシリーズとカテゴリを削除
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//新しいシリーズを追加
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//新しいカテゴリを追加
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//最初のチャートシリーズを取得
	ChartSeriesEx series = chart.ChartData.Series[0];

	//シリーズデータを現在設定
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//シリーズの塗りつぶし色を設定
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//2 番目のチャートシリーズを取得
	series = chart.ChartData.Series[1];

	//シリーズデータを現在設定
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//シリーズの塗りつぶし色を設定
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//新しいシリーズの各カテゴリにカスタムラベルを作成

	//最初のラベルはカテゴリ名を表示
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//2 番目のラベルにシリーズ名を表示
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//3 番目のラベルに値を表示
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//値とカスタムテキストを表示
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//チャート付きのプレゼンテーションを保存
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **新しい Aspose.Slides for .NET 13.x アプローチ**
``` csharp
//PPTX ファイルを表す Presentation クラスをインスタンス化//PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation pres = new Presentation();

//Access first slide
ISlide sld = pres.Slides[0];

// Add chart with default data
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Setting chart Title
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Set first series to Show Values
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

//Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Delete default generated series and categories
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Adding new series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Adding new categories
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Take first chart series
IChartSeries series = chart.ChartData.Series[0];

//Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Setting fill color for series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Take second chart series
series = chart.ChartData.Series[1];

//Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Setting fill color for series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//create custom labels for each of categories for new series
//first label will be show Category name
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Show value for third label
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Save presentation with chart
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```


レガシー Aspose.Slides API を使用してプレゼンテーションで最初から散布図チャートを作成する簡単なコードスニペットを以下に示しますので、新しい統合 API での実現方法をご確認ください。
## **レガシー Aspose.Slides for .NET アプローチ**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //デフォルトのチャートを作成
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //デフォルトのチャートデータワークシートインデックスを取得
    int defaultWorksheetIndex = 0;

    //チャートデータワークシートにアクセス
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //デモシリーズを削除
    chart.ChartData.Series.Clear();

    //新しいシリーズを追加
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //最初のチャートシリーズを取得
    ChartSeriesEx series = chart.ChartData.Series[0];

    //そこに新しいポイント (1:3) を追加.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //新しいポイント (2:10) を追加
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //シリーズのタイプを編集
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //チャートシリーズのマーカーを変更
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //2 番目のチャートシリーズを取得
    series = chart.ChartData.Series[1];

    //そこに新しいポイント (5:2) を追加.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //新しいポイント (3:1) を追加
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //新しいポイント (2:2) を追加
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //新しいポイント (5:1) を追加
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //チャートシリーズのマーカーを変更
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **新しい Aspose.Slides for .NET 13.x アプローチ**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//デフォルトのチャートを作成
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//デフォルトのチャートデータワークシートインデックスを取得
int defaultWorksheetIndex = 0;

//チャートデータワークシートにアクセス
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//デモシリーズを削除
chart.ChartData.Series.Clear();

//新しいシリーズを追加
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//最初のチャートシリーズを取得
IChartSeries series = chart.ChartData.Series[0];

//そこに新しいポイント (1:3) を追加.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//新しいポイント (2:10) を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//シリーズのタイプを編集
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//チャートシリーズのマーカーを変更
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//2 番目のチャートシリーズを取得
series = chart.ChartData.Series[1];

//そこに新しいポイント (5:2) を追加.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//新しいポイント (3:1) を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//新しいポイント (2:2) を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//新しいポイント (5:1) を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//チャートシリーズのマーカーを変更
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```
