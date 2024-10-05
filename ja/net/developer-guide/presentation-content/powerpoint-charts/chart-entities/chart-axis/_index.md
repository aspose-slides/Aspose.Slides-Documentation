---
title: チャートの軸
type: docs
url: /net/chart-axis/
keywords: "PowerPoint チャート軸, プレゼンテーションチャート, C#, .NET, チャート軸の操作, チャートデータ"
description: "C#または.NETでPowerPointチャートの軸を編集する"
---


## **チャートの垂直軸の最大値を取得する**
Aspose.Slides for .NETでは、垂直軸上の最小値と最大値を取得することができます。次の手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータを持つチャートを追加します。
1. 軸上の実際の最大値を取得します。
1. 軸上の実際の最小値を取得します。
1. 軸の実際の主要単位を取得します。
1. 軸の実際の副単位を取得します。
1. 軸の実際の主要単位スケールを取得します。
1. 軸の実際の副単位スケールを取得します。

このサンプルコードは、上記の手順の実装を示しており、C#で必要な値を取得する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// プレゼンテーションを保存
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```


## **軸間でデータを入れ替える**
Aspose.Slidesでは、軸間でデータを迅速に入れ替えることができます—垂直軸（y軸）に表示されているデータが水平軸（x軸）に移動し、その逆も同様です。

このC#コードは、チャート上の軸間でデータを入れ替える作業を行う方法を示しています：

```c#
// 空のプレゼンテーションを作成
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// 行と列を入れ替え
	chart.ChartData.SwitchRowColumn();
		   
	// プレゼンテーションを保存
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **線チャートの垂直軸を無効にする**

このC#コードは、線チャートの垂直軸を非表示にする方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **線チャートの水平軸を無効にする**

このコードは、線チャートの水平軸を非表示にする方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **カテゴリー軸の変更**

**CategoryAxisType**プロパティを使用して、好みのカテゴリー軸タイプ（**date**または**text**）を指定できます。このC#コードは、その操作を示しています：

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

## **カテゴリー軸値に対する日付形式の設定**
Aspose.Slides for .NETでは、カテゴリー軸値の日付形式を設定することができます。この操作は、次のC#コードで示されています：

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

## **チャート軸タイトルの回転角度を設定する**
Aspose.Slides for .NETでは、チャート軸タイトルの回転角度を設定することができます。このC#コードは、その操作を示しています：

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
    chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **カテゴリーまたは値軸の位置を設定する**
Aspose.Slides for .NETでは、カテゴリーまたは値軸の位置を設定することができます。このC#コードは、その作業を行う方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **チャート値軸に表示単位ラベルを有効にする**
Aspose.Slides for .NETでは、チャートの値軸に単位ラベルを表示するように構成することができます。このC#コードは、その操作を示しています：

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```