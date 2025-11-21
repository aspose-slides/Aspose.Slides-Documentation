---
title: .NET のプレゼンテーションでチャートを作成する方法
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
description: "Aspose.Slides を使用して、.NET で PowerPoint PPT、PPTX、ODP プレゼンテーションにチャートを作成する方法を、レガシーおよびモダンチャート API の両方で学びます。"
---

{{% alert color="primary" %}} 
新しい[Aspose.Slides for .NET API](/slides/ja/net/)がリリースされ、現在この単一製品は、PowerPointドキュメントをゼロから生成し、既存のものを編集する機能をサポートしています。
{{% /alert %}} 
## **レガシーコードのサポート**
13.x以前のAspose.Slides for .NETバージョンで開発されたレガシーコードを使用するには、コードに少し変更を加える必要があり、以前と同様に動作します。旧Aspose.Slides for .NETのAspose.SlideおよびAspose.Slides.Pptx名前空間に存在したすべてのクラスは、現在単一のAspose.Slides名前空間に統合されています。レガシーAspose.Slides APIを使用してプレゼンテーション内でゼロから標準チャートを作成する以下の簡単なコードスニペットを確認し、新しい統合APIへの移行手順をご覧ください。
## **レガシー Aspose.Slides for .NET アプローチ**
```c#
/*PPTX ファイルを表す PresentationEx クラスのインスタンスを作成*/
using (PresentationEx pres = new PresentationEx())
{
	/*最初のスライドにアクセス*/
	SlideEx sld = pres.Slides[0];

	/* デフォルト データでチャートを追加*/
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	/*チャートのタイトルを設定*/
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	/*最初の系列で値を表示*/
	chart.ChartData.Series[0].Labels.ShowValue = true;

	/*チャート データ シートのインデックスを設定*/
	int defaultWorksheetIndex = 0;

	/*チャート データ ワークシートを取得*/
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	/*デフォルトで生成された系列とカテゴリを削除*/
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	/*新しい系列を追加*/
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	/*新しいカテゴリを追加*/
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	/*最初のチャート系列を取得*/
	ChartSeriesEx series = chart.ChartData.Series[0];

	/*現在、系列データに値を設定*/
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	/*系列の塗りつぶしカラーを設定*/
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	/*2番目のチャート系列を取得*/
	series = chart.ChartData.Series[1];

	/*現在、系列データに値を設定*/
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	/*系列の塗りつぶしカラーを設定*/
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	/*新しい系列の各カテゴリにカスタム ラベルを作成*/

	/*最初のラベルはカテゴリ名を表示*/
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	/*2番目のラベルは系列名を表示*/
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	/*3番目のラベルは値を表示*/
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	/*値とカスタムテキストを表示*/
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	/*チャート付きプレゼンテーションを保存*/
	pres.Write(@"D:\AsposeChart.pptx");
}
```


## **新しい Aspose.Slides for .NET 13.x アプローチ**
``` csharp
//PPTX ファイルを表す Presentation クラスのインスタンスを作成//PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();

//最初のスライドにアクセス
ISlide sld = pres.Slides[0];

// デフォルト データでチャートを追加
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//チャートのタイトルを設定
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//最初の系列で値を表示
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//チャート データ シートのインデックスを設定
int defaultWorksheetIndex = 0;

//チャート データ ワークシートを取得
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//デフォルトで生成された系列とカテゴリを削除
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//新しい系列を追加
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//新しいカテゴリを追加
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//最初のチャート系列を取得
IChartSeries series = chart.ChartData.Series[0];

//現在、系列データに値を設定

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//系列の塗りつぶしカラーを設定
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//2番目のチャート系列を取得
series = chart.ChartData.Series[1];

//現在、系列データに値を設定
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//系列の塗りつぶしカラーを設定
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//新しい系列の各カテゴリにカスタム ラベルを作成

//最初のラベルはカテゴリ名を表示
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//3番目のラベルは値を表示
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//チャート付きプレゼンテーションを保存
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```



レガシーAspose.Slides APIを使用してプレゼンテーション内でゼロから散布図チャートを作成する以下の簡単なコードスニペットを確認し、新しい統合APIでの実装方法をご覧ください。

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

    //デモ系列を削除
    chart.ChartData.Series.Clear();

    //新しい系列を追加
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //最初のチャート系列を取得
    ChartSeriesEx series = chart.ChartData.Series[0];

    //新しいポイント (1:3) を追加
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //新しいポイント (2:10) を追加
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //系列のタイプを編集
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //チャート系列のマーカーを変更
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //2番目のチャート系列を取得
    series = chart.ChartData.Series[1];

    //新しいポイント (5:2) を追加
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

    //チャート系列のマーカーを変更
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

//デフォルトのチャートデータワークシートのインデックスを取得
int defaultWorksheetIndex = 0;

//チャートデータワークシートにアクセス
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//デモ系列を削除
chart.ChartData.Series.Clear();

//新しい系列を追加
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//最初のチャート系列を取得
IChartSeries series = chart.ChartData.Series[0];

//新しいポイント (1:3) を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//新しいポイント (2:10) を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//系列のタイプを編集
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//チャート系列のマーカーを変更
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//2番目のチャート系列を取得
series = chart.ChartData.Series[1];

//新しいポイント (5:2) を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//新しいポイント (3:1) を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//新しいポイント (2:2) を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//新しいポイント (5:1) を追加
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//チャート系列のマーカーを変更
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```
