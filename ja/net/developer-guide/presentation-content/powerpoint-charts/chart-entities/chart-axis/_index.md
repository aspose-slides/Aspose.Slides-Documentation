---
title: チャート軸
type: docs
url: /ja/net/chart-axis/
keywords: "PowerPoint チャート軸, プレゼンテーションチャート, C#, .NET, チャート軸の操作, チャートデータ"
description: "C# または .NET で PowerPoint のチャート軸を編集"
---

## **チャートの垂直軸の最大値を取得**
Aspose.Slides for .NET を使用すると、垂直軸の最小値と最大値を取得できます。次の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータのチャートを追加します。
1. 軸上の実際の最大値を取得します。
1. 軸上の実際の最小値を取得します。
1. 軸の実際の主要単位を取得します。
1. 軸の実際の副単位を取得します。
1. 軸の実際の主要単位スケールを取得します。
1. 軸の実際の副単位スケールを取得します。

このサンプルコード（上記手順の実装）は、C# で必要な値を取得する方法を示しています。
```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// プレゼンテーションを保存します
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```


## **軸間のデータ交換**
Aspose.Slides を使用すると、軸間のデータを簡単に入れ替えることができます。垂直軸（y 軸）のデータが水平軸（x 軸）に、逆も同様に移動します。

この C# コードは、チャートの軸間でデータを入れ替える方法を示しています：
```c#
// 空のプレゼンテーションを作成
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//行と列を入れ替えます
		   
	// プレゼンテーションを保存します
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```


## **折れ線グラフの垂直軸を無効化**
この C# コードは、折れ線グラフの垂直軸を非表示にする方法を示しています：
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **折れ線グラフの水平軸を無効化**
このコードは、折れ線グラフの水平軸を非表示にする方法を示しています：
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **カテゴリ軸の変更**
**CategoryAxisType** プロパティを使用すると、希望するカテゴリ軸のタイプ（**date** または **text**）を指定できます。この C# のコードはその操作を示しています：
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```


## **カテゴリ軸の値の日時形式を設定**
Aspose.Slides for .NET を使用すると、カテゴリ軸の値に対して日付形式を設定できます。この操作は以下の C# コードで示しています：
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **チャート軸タイトルの回転角度設定**
Aspose.Slides for .NET を使用すると、チャート軸タイトルの回転角度を設定できます。この C# コードはその操作を示しています：
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **カテゴリ軸または値軸の位置設定**
Aspose.Slides for .NET を使用すると、カテゴリ軸または値軸の位置を設定できます。この C# コードはその手順を示しています：
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```


## **チャート値軸に表示単位ラベルを有効化**
Aspose.Slides for .NET を使用すると、チャートの値軸に単位ラベルを表示するように設定できます。この C# コードはその操作を示しています：
```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**軸が他の軸と交差する値（軸の交差点）を設定するにはどうすればよいですか？**

軸は [crossing setting](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) を提供しています。0、カテゴリ/値の最大、または特定の数値で交差させるかを選択できます。これにより、X 軸を上下にずらしたり、基準線を強調したりすることが可能です。

**軸に対する目盛ラベルの位置（軸側、外側、内側）を設定するにはどうすればよいですか？**

[label position](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) を "cross"、"outside"、または "inside" に設定します。これにより可読性が向上し、特に小さなチャートでのスペース節約に役立ちます。