---
title: 如何在 .NET 中於簡報建立圖表
linktitle: 建立圖表
type: docs
weight: 30
url: /zh-hant/net/how-to-create-charts-in-a-presentation/
keywords:
- 遷移
- 建立圖表
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 .NET 中使用 Aspose.Slides，透過舊版與新版圖表 API，於 PowerPoint PPT、PPTX 與 ODP 簡報中建立圖表。"
---
{{% alert color="primary" %}} 
已發布全新的 [Aspose.Slides for .NET API](/slides/zh-hant/net/)，現在此單一產品支援從頭建立 PowerPoint 文件以及編輯現有文件的功能。
{{% /alert %}} 
## **支援舊版程式碼**
若要使用在 13.x 之前的 Aspose.Slides for .NET 版本開發的舊版程式碼，您需要對程式碼做少量調整，程式碼即可如同以前般運作。原本在舊版 Aspose.Slides for .NET 中位於 Aspose.Slide 與 Aspose.Slides.Pptx 命名空間的所有類別，現在已合併至單一的 Aspose.Slides 命名空間。請參考以下簡單程式碼片段，了解如何使用舊版 Aspose.Slides API 從頭在簡報中建立一般圖表，並遵循說明步驟遷移至新的合併 API。
## **舊版 Aspose.Slides for .NET 方法**
```c#
//實例化表示 PPTX 檔案的 PresentationEx 類別
using (PresentationEx pres = new PresentationEx())
{
	//存取第一張投影片
	SlideEx sld = pres.Slides[0];

	// 新增具有預設資料的圖表
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//設定圖表標題
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//設定第一系列顯示值
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//設定圖表資料工作表的索引 
	int defaultWorksheetIndex = 0;

	//取得圖表資料工作表
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//刪除預設產生的系列和類別
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//新增系列
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//新增類別
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//取得第一個圖表系列
	ChartSeriesEx series = chart.ChartData.Series[0];

	//現在填入系列資料
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//設定系列的填色
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//取得第二個圖表系列
	series = chart.ChartData.Series[1];

	//現在填入系列資料
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//設定系列的填色
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//為新系列的每個類別建立自訂標籤

	//第一個標籤將顯示類別名稱
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//第二個標籤顯示系列名稱
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//第三個標籤顯示值
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//顯示值和自訂文字
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//儲存包含圖表的簡報
	pres.Write(@"D:\AsposeChart.pptx");
}
```

## **新版 Aspose.Slides for .NET 13.x 方法**
``` csharp
//實例化表示 PPTX 檔案的 Presentation 類別//實例化表示 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();

//存取第一張投影片
ISlide sld = pres.Slides[0];

// 新增具有預設資料的圖表
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//設定圖表標題
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//將第一個系列設定為顯示值
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//設定圖表資料工作表的索引
int defaultWorksheetIndex = 0;

//取得圖表資料工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//刪除預設產生的系列和類別
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//新增系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//新增類別
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//取得第一個圖表系列
IChartSeries series = chart.ChartData.Series[0];

//現在填入系列資料

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//設定系列的填色
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//取得第二個圖表系列
series = chart.ChartData.Series[1];

//現在填入系列資料
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//設定系列的填色
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//為新系列的每個類別建立自訂標籤

//第一個標籤將顯示類別名稱
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//第三個標籤顯示值
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//儲存包含圖表的簡報
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```
請參考以下簡單程式碼片段，了解如何使用舊版 Aspose.Slides API 從頭在簡報中建立散佈圖，並說明如何在新合併 API 中實作相同功能。
## **舊版 Aspose.Slides for .NET 方法**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //建立預設圖表
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //取得預設圖表資料工作表索引
    int defaultWorksheetIndex = 0;

    //存取圖表資料工作表
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //刪除示範系列
    chart.ChartData.Series.Clear();

    //新增系列
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //取得第一個圖表系列
    ChartSeriesEx series = chart.ChartData.Series[0];

    //在此新增新點 (1:3)。
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //新增新點 (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //編輯系列類型
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //變更圖表系列標記
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //取得第二個圖表系列
    series = chart.ChartData.Series[1];

    //在此新增新點 (5:2)。
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //新增新點 (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //新增新點 (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //新增新點 (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //變更圖表系列標記
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```

## **新版 Aspose.Slides for .NET 13.x 方法**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//建立預設圖表
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//取得預設圖表資料工作表索引
int defaultWorksheetIndex = 0;

//存取圖表資料工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//刪除示範系列
chart.ChartData.Series.Clear();

//新增系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//取得第一個圖表系列
IChartSeries series = chart.ChartData.Series[0];

//在此新增新點 (1:3)。
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//新增新點 (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//編輯系列類型
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//變更圖表系列標記
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//取得第二個圖表系列
series = chart.ChartData.Series[1];

//在此新增新點 (5:2)。
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//新增新點 (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//新增新點 (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//新增新點 (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//變更圖表系列標記
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```