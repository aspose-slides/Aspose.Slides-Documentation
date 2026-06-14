---
title: 在 .NET 中格式化簡報圖表
linktitle: 圖表格式化
type: docs
weight: 60
url: /zh-hant/net/chart-formatting/
keywords:
- 格式化圖表
- 圖表格式化
- 圖表實體
- 圖表屬性
- 圖表設定
- 圖表選項
- 字型屬性
- 圓角邊框
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 中的圖表格式化，並以專業、引人注目的樣式提升您的 PowerPoint 簡報。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在 PowerPoint 簡報中格式化圖表。它展示了如何自訂圖表的關鍵元素，如座標軸、格線、標題、圖例、繪圖區域以及牆面填色，以提升圖表資料的外觀與可讀性。

此外，本文還示範了如何設定圖表文字的字型屬性、套用預設與自訂的數字格式至圖表資料，以及啟用圖表區域的圓角。這些範例共同說明了如何同時掌控簡報中圖表的視覺樣式與資料呈現方式。

## **格式化圖表實體**
Aspose.Slides for .NET 讓開發人員從頭建立自訂圖表。本文章說明如何格式化不同的圖表實體，包括圖表類別軸與值軸。

Aspose.Slides for .NET 提供簡易的 API 來管理不同的圖表實體並以自訂值進行格式化：

1. 建立 **Presentation** 類別的實例。
1. 依索引取得投影片的參照。
1. 加入具有預設資料的圖表，並選擇任意所需類型（本範例使用 ChartType.LineWithMarkers）。
1. 存取圖表值軸，並設定以下屬性：
   1. 設定值軸主要格線的 **Line format**
   1. 設定值軸次要格線的 **Line format**
   1. 設定值軸的 **Number Format**
   1. 設定值軸的 **Min, Max, Major and Minor units**
   1. 設定值軸資料的 **Text Properties**
   1. 設定值軸的 **Title**
   1. 設定值軸的 **Line Format**
1. 存取圖表類別軸，並設定以下屬性：
   1. 設定類別軸主要格線的 **Line format**
   1. 設定類別軸次要格線的 **Line format**
   1. 設定類別軸資料的 **Text Properties**
   1. 設定類別軸的 **Title**
   1. 設定類別軸的 **Label Positioning**
   1. 設定類別軸標籤的 **Rotation Angle**
1. 存取圖表圖例，並設定其 **Text Properties**
1. 設定顯示圖例且不與圖表重疊
1. 存取圖表的 **Secondary Value Axis**，並設定以下屬性：
   1. 啟用次要 **Value Axis**
   1. 設定次要值軸的 **Line Format**
   1. 設定次要值軸的 **Number Format**
   1. 設定次要值軸的 **Min, Max, Major and Minor units**
1. 現在在次要值軸上繪製第一個圖表系列
1. 設定圖表背牆的填色
1. 設定圖表繪圖區域的填色
1. 將已修改的簡報寫入 PPTX 檔案

```c#
// 實例化簡報// 實例化簡報
Presentation pres = new Presentation();

// Accessing the first slide
// 存取第一張投影片
ISlide slide = pres.Slides[0];

// Adding the sample chart
// 加入範例圖表
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Setting Chart Titile
// 設定圖表標題
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Major grid lines format for value axis
// 設定值軸主要格線格式
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Setting Minor grid lines format for value axis
// 設定值軸次要格線格式
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting value axis number format
// 設定值軸數字格式
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Setting chart maximum, minimum values
// 設定圖表最大值與最小值
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Setting Value Axis Text Properties
// 設定值軸文字屬性
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Setting value axis title
// 設定值軸標題
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Setting value axis line format : Now Obselete
// 設定值軸線條格式：已過時
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Setting Major grid lines format for Category axis
// 設定類別軸主要格線格式
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Setting Minor grid lines format for Category axis
// 設定類別軸次要格線格式
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting Category Axis Text Properties
// 設定類別軸文字屬性
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Setting Category Titile
// 設定類別標題
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting category axis lable position
// 設定類別軸標籤位置
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Setting category axis lable rotation angle
// 設定類別軸標籤旋轉角度
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Setting Legends Text Properties
// 設定圖例文字屬性
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Set show chart legends without overlapping chart
// 設定顯示圖例且不與圖表重疊

chart.Legend.Overlay = true;
            
// Ploting first series on secondary value axis
// 在次要值軸上繪製第一個系列
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Setting chart back wall color
// 設定圖表背牆顏色
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
// 設定繪圖區顏色
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
// 儲存簡報
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```



## **設定圖表的字型屬性**
Aspose.Slides for .NET 提供設定圖表相關字型屬性的支援。請依照以下步驟設定圖表的字型屬性。

- 實例化 Presentation 類別物件。
- 在投影片上新增圖表。
- 設定字型高度。
- 儲存已修改的簡報。

以下提供範例程式碼。

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```




## **設定數值格式**
Aspose.Slides for .NET 提供簡易的 API 以管理圖表資料格式：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
1. 依索引取得投影片的參照。
1. 加入具有預設資料的圖表，並選擇任意所需類型（本範例使用 **ChartType.ClusteredColumn**）。
1. 從可用的預設值中設定預設數字格式。
1. 遍歷每個圖表系列中的圖表資料儲存格，並設定圖表資料的數字格式。
1. 儲存簡報。
1. 設定自訂數字格式。
1. 遍歷每個圖表系列內的圖表資料儲存格，設定不同的圖表資料數字格式。
1. 儲存簡報。

```c#
// 實例化簡報// 實例化簡報
Presentation pres = new Presentation();

// 存取第一張簡報投影片
ISlide slide = pres.Slides[0];

// 新增預設的叢集柱形圖
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// 存取圖表系列集合
IChartSeriesCollection series = chart.ChartData.Series;

// 設定預設的數字格式
// 遍歷每個圖表系列
foreach (ChartSeries ser in series)
{
    // 遍歷系列中的每個資料儲存格
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // 設定數字格式
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// 儲存簡報
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

以下列出可使用的預設數字格式值及其對應的索引：

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **設定圖表區域圓角邊框**
Aspose.Slides for .NET 提供設定圖表區域的支援。已在 Aspose.Slides 中加入 **IChart.HasRoundedCorners** 與 **Chart.HasRoundedCorners** 屬性。

1. 實例化 `Presentation` 類別物件。
1. 在投影片上新增圖表。
1. 設定圖表的填充類型與填充顏色
1. 將圓角屬性設為 True。
1. 儲存已修改的簡報。

以下提供範例程式碼。

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**我可以為柱狀/區域設定半透明填色，同時保持邊框不透明嗎？**

可以。填充透明度與輪廓是分別設定的。這在密集的視覺化圖表中有助於提升格線與資料的可讀性。

**當資料標籤重疊時，我該如何處理？**

降低字型大小、停用非必要的標籤元件（例如類別）、設定標籤的偏移/位置，必要時僅顯示選取點的標籤，或改用「值 + 圖例」的格式。

**我可以對系列套用漸層或圖案填色嗎？**

可以。通常皆可使用實色與漸層/圖案填色。實務上，請節制使用漸層，避免與格線及文字的對比度降低的組合。