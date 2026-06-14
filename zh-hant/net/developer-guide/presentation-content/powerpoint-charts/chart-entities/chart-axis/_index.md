---
title: 在 .NET 中自訂簡報的圖表軸
linktitle: 圖表軸
type: docs
url: /zh-hant/net/chart-axis/
keywords:
- 圖表軸
- 垂直軸
- 水平軸
- 自訂軸
- 操作軸
- 管理軸
- 軸屬性
- 最大值
- 最小值
- 軸線
- 日期格式
- 軸標題
- 軸位置
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 簡報中自訂圖表軸，以用於報告與視覺化。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中自訂圖表軸。它展示了如何取得實際軸值、在軸之間交換資料、隱藏折線圖的垂直或水平軸、變更類別軸類型、設定類別軸值的日期格式、旋轉軸標題、設定軸位置，以及在值軸上顯示單位標籤。

## **取得圖表垂直軸的最大值**

Aspose.Slides for .NET 允許您取得垂直軸的最小值與最大值。請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 存取第一張投影片。  
3. 新增一個包含預設資料的圖表。  
4. 取得軸的實際最大值。  
5. 取得軸的實際最小值。  
6. 取得軸的實際主要單位。  
7. 取得軸的實際次要單位。  
8. 取得軸的實際主要單位比例。  
9. 取得軸的實際次要單位比例。  

此範例程式碼 — 以上步驟的實作 — 示範了如何在 C# 中取得所需的值：

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// 儲存簡報
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **在軸之間交換資料**

Aspose.Slides 允許您快速交換軸之間的資料——垂直軸 (y 軸) 的資料會移至水平軸 (x 軸)，反之亦然。

以下 C# 程式碼示範了在圖表軸之間執行資料交換的方式：

```c#
// 建立空白簡報
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// 切換列與欄
	chart.ChartData.SwitchRowColumn();
		   
	// 儲存簡報
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **在折線圖中停用垂直軸**

以下 C# 程式碼示範了如何隱藏折線圖的垂直軸：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **在折線圖中停用水平軸**

以下程式碼示範了如何隱藏折線圖的水平軸：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **變更類別軸**

使用 **CategoryAxisType** 屬性，您可以指定想要的類別軸類型（**date** 或 **text**）。以下 C# 程式碼示範此操作：

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

## **設定類別軸值的日期格式**

Aspose.Slides for .NET 允許您設定類別軸值的日期格式。以下 C# 程式碼示範此操作：

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

## **設定圖表軸標題的旋轉角度**

Aspose.Slides for .NET 允許您設定圖表軸標題的旋轉角度。以下 C# 程式碼示範此操作：

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **設定類別或值軸上的軸位置**

Aspose.Slides for .NET 允許您設定類別或值軸的軸位置。以下 C# 程式碼示範如何執行此任務：

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **在圖表值軸上啟用顯示單位標籤**

Aspose.Slides for .NET 允許您設定圖表在其值軸上顯示單位標籤。以下 C# 程式碼示範此操作：

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**How do I set the value at which one axis crosses the other (axis crossing)?**

軸提供了 [crossing setting](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/axis/crosstype/)：您可以選擇在零、在最大類別/值，或在特定數值處交叉。此功能可用於將 X 軸向上或向下移動，或強調基線。

**How can I position tick labels relative to the axis (alongside, outside, inside)?**

將 [label position](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/axis/majortickmark/) 設為「cross」「outside」或「inside」即可。此設定會影響可讀性，並有助於節省空間，尤其在小型圖表上。