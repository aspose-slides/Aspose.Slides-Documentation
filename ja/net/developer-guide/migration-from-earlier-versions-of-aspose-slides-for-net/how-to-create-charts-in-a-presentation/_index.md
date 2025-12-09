---
title: .NET でプレゼンテーションのチャートを作成する方法
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
description: "Aspose.Slides を使用して、.NET で PowerPoint PPT、PPTX、ODP プレゼンテーションにチャートを作成する方法（レガシー API とモダン API の両方）を学びます。"
---

{{% alert color="primary" %}} 
新しい [Aspose.Slides for .NET API](/slides/ja/net/) がリリースされ、この単一製品で、PowerPoint ドキュメントをゼロから生成し、既存のドキュメントを編集する機能がサポートされました。
{{% /alert %}} 
## **レガシーコードのサポート**
13.x 以前の Aspose.Slides for .NET バージョンで開発されたレガシーコードを使用するには、コードにいくつか小さな変更を加える必要がありますが、コードは従来通りに動作します。旧 Aspose.Slides for .NET の Aspose.Slide および Aspose.Slides.Pptx 名前空間に存在していたすべてのクラスは、現在単一の Aspose.Slides 名前空間に統合されています。以下のシンプルなコードスニペットを参照し、レガシー Aspose.Slides API を使用してプレゼンテーション内でゼロから普通のチャートを作成する方法と、新しい統合 API への移行手順をご確認ください。
## **レガシー Aspose.Slides for .NET のアプローチ**
```c#
//PPTX ファイルを表す PresentationEx クラスのインスタンスを作成する
using (PresentationEx pres = new PresentationEx())
{
	//最初のスライドにアクセスする
	SlideEx sld = pres.Slides[0];

	// デフォルト データでチャートを追加する
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//チャート タイトルを設定する
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//最初の系列に値の表示を設定する
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//チャート データ シートのインデックスを設定する
	int defaultWorksheetIndex = 0;

	//チャート データ ワークシートを取得する
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//デフォルトで生成された系列とカテゴリを削除する
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//新しい系列を追加する
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//新しいカテゴリを追加する
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//最初のチャート系列を取得する
	ChartSeriesEx series = chart.ChartData.Series[0];

	//系列データを現在設定中
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//系列の塗りつぶし色を設定する
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//2 番目のチャート系列を取得する
	series = chart.ChartData.Series[1];

	//系列データを現在設定中
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//系列の塗りつぶし色を設定する
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//新しい系列の各カテゴリにカスタム ラベルを作成する

	//最初のラベルはカテゴリ名を表示する
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//2 番目のラベルに系列名を表示する
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//3 番目のラベルに値を表示する
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//値とカスタムテキストを表示する
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//チャート付きのプレゼンテーションを保存する
	pres.Write(@"D:\AsposeChart.pptx");
}
```


## **新しい Aspose.Slides for .NET 13.x のアプローチ**
```csharp
//PPTX ファイルを表す Presentation クラスのインスタンスを作成する//PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();

//最初のスライドにアクセスする
ISlide sld = pres.Slides[0];

// デフォルト データでチャートを追加する
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//チャート タイトルを設定する
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//最初の系列に値の表示を設定する
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//チャート データ シートのインデックスを設定する
int defaultWorksheetIndex = 0;

//チャート データ ワークシートを取得する
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//デフォルトで生成された系列とカテゴリを削除する
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//新しい系列を追加する
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//新しいカテゴリを追加する
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//最初のチャート系列を取得する
IChartSeries series = chart.ChartData.Series[0];

//系列データを設定中
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//系列の塗りつぶし色を設定する
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//2 番目のチャート系列を取得する
series = chart.ChartData.Series[1];

//系列データを設定中
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//系列の塗りつぶし色を設定する
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//新しい系列の各カテゴリにカスタム ラベルを作成する

//最初のラベルはカテゴリ名を表示する
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//3 番目のラベルに値を表示する
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//チャート付きのプレゼンテーションを保存する
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

以下のシンプルなコードスニペットを参照し、レガシー Aspose.Slides API を使用してプレゼンテーション内でゼロから散布図チャートを作成する方法と、新しい統合 API でそれを実現する方法をご確認ください。
## **レガシー Aspose.Slides for .NET のアプローチ**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //デフォルトのチャートを作成する
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //デフォルトのチャート データ ワークシート インデックスを取得する
    int defaultWorksheetIndex = 0;

    //チャート データ ワークシートにアクセスする
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //デモ系列を削除する
    chart.ChartData.Series.Clear();

    //新しい系列を追加する
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //最初のチャート系列を取得する
    ChartSeriesEx series = chart.ChartData.Series[0];

    //新しいポイント (1:3) を追加する
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //新しいポイント (2:10) を追加する
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //系列の種類を編集する
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //チャート系列のマーカーを変更する
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //2 番目のチャート系列を取得する
    series = chart.ChartData.Series[1];

    //新しいポイント (5:2) を追加する
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //新しいポイント (3:1) を追加する
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //新しいポイント (2:2) を追加する
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //新しいポイント (5:1) を追加する
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //チャート系列のマーカーを変更する
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **新しい Aspose.Slides for .NET 13.x のアプローチ**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//デフォルトのチャートを作成する
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//デフォルトのチャート データ ワークシート インデックスを取得する
int defaultWorksheetIndex = 0;

//チャート データ ワークシートにアクセスする
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//デモ系列を削除する
chart.ChartData.Series.Clear();

//新しい系列を追加する
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//最初のチャート系列を取得する
IChartSeries series = chart.ChartData.Series[0];

//そこに新しいポイント (1:3) を追加する
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//新しいポイント (2:10) を追加する
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//系列のタイプを編集する
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//チャート系列のマーカーを変更する
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//2 番目のチャート系列を取得する
series = chart.ChartData.Series[1];

//そこに新しいポイント (5:2) を追加する
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//新しいポイント (3:1) を追加する
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//新しいポイント (2:2) を追加する
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//新しいポイント (5:1) を追加する
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//チャート系列のマーカーを変更する
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```
