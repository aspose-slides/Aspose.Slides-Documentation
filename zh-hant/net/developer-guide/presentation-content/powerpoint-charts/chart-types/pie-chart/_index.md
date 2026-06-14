---
title: 在 .NET 中自訂簡報的圓餅圖
linktitle: 圓餅圖
type: docs
url: /zh-hant/net/pie-chart/
keywords:
- 圓餅圖
- 管理圖表
- 自訂圖表
- 圖表選項
- 圖表設定
- 繪圖選項
- 切片顏色
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 .NET 使用 Aspose.Slides 建立與自訂圓餅圖，可匯出為 PowerPoint，讓您在數秒內提升資料敘事效果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圓餅圖。它展示了如何為「Pie of Pie」與「Bar of Pie」圖表設定次要圖區選項，並說明如何為標準圓餅圖啟用自動切片著色。

範例著重於實務的圖表自訂步驟，例如將圖表加入投影片、調整系列與標籤設定、以自訂類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **「Pie of Pie」與「Bar of Pie」圖表的次要圖區選項**
Aspose.Slides for .NET 現在支援「Pie of Pie」或「Bar of Pie」圖表的次要圖區選項。在本主題中，我們將透過範例說明如何使用 Aspose.Slides 指定這些選項。請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的物件。
1. 在投影片上新增圖表。
1. 指定圖表的次要圖區選項。
1. 將簡報寫入磁碟。

以下範例中，我們設定了 Pie of Pie 圖表的不同屬性。

```c#
// 建立 Presentation 類別的實例
Presentation presentation = new Presentation();

// 在投影片上新增圖表
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// 設定不同的屬性
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// 將簡報寫入磁碟
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```

## **設定自動圓餅圖切片顏色**
Aspose.Slides for .NET 提供簡易的 API 以設定自動圓餅圖切片顏色。範例程式碼套用了前述屬性的設定。

1. 建立 Presentation 類別的實例。
1. 存取第一張投影片。
1. 加入使用預設資料的圖表。
1. 設定圖表標題。
1. 將第一個系列設定為顯示數值。
1. 設定圖表資料工作表的索引。
1. 取得圖表資料工作表。
1. 刪除預設產生的系列與類別。
1. 新增類別。
1. 新增系列。

將修改後的簡報寫入 PPTX 檔案。

```c#
// 實例化代表 PPTX 檔案的 Presentation 類別
using (Presentation presentation = new Presentation())
{
	// 實例化代表 PPTX 檔案的 Presentation 類別
	Presentation presentation = new Presentation();

	// 存取第一張投影片
	ISlide slides = presentation.Slides[0];

	// 使用預設資料新增圖表
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// 設定圖表標題
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// 將第一個系列設定為顯示數值
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// 設定圖表資料工作表的索引
	int defaultWorksheetIndex = 0;

	// 取得圖表資料工作表
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// 刪除預設產生的系列與類別
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// 新增類別
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// 新增系列
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// 現在填入系列資料
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **常見問題**

**是否支援「Pie of Pie」與「Bar of Pie」變體？**

是的，該函式庫 [支援](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/charttype/) 圓餅圖的次要圖區，包括「Pie of Pie」與「Bar of Pie」類型。

**我可以僅將圖表匯出為影像（例如 PNG）嗎？**

是的，您可以 [將圖表本身匯出為影像](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getimage/)（例如 PNG），而不必匯出整個簡報。