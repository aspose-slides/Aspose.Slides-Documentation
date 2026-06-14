---
title: 在 .NET 中為簡報圖表新增趨勢線
linktitle: 趨勢線
type: docs
url: /zh-hant/net/trend-line/
keywords:
- 圖表
- 趨勢線
- 指數趨勢線
- 線性趨勢線
- 對數趨勢線
- 移動平均趨勢線
- 多項式趨勢線
- 指數次方趨勢線
- 自訂趨勢線
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "快速在 PowerPoint 圖表中使用 Aspose.Slides for .NET 新增與自訂趨勢線 — 實用指南，協助您吸引觀眾。"
---
## **概觀**

本文件說明如何使用 Aspose.Slides 為簡報圖表加入趨勢線。它展示了如何建立圖表、為圖表系列新增趨勢線，並處理多種趨勢線類型，包括指數、線性、對數、移動平均、多項式與指數次方。

此外，亦說明如何透過插入線條形狀的方式為圖表新增自訂線，並包含關於趨勢線向前與向後投射值以及在匯出為 PDF 或 SVG、或將圖表渲染為影像時趨勢線是否會保留的簡短 FAQ。

## **新增趨勢線**
Aspose.Slides for .NET 提供簡易的 API 來管理圖表的不同趨勢線：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的執行個體。
1. 依索引取得投影片的參考。
1. 使用預設資料新增圖表，並指定所需類型（本範例使用 ChartType.ClusteredColumn）。
1. 為圖表系列 1 加入指數趨勢線。
1. 為圖表系列 1 加入線性趨勢線。
1. 為圖表系列 2 加入對數趨勢線。
1. 為圖表系列 2 加入移動平均趨勢線。
1. 為圖表系列 3 加入多項式趨勢線。
1. 為圖表系列 3 加入指數次方趨勢線。
1. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼用於建立帶有趨勢線的圖表。

```c#
// 建立空白簡報
Presentation pres = new Presentation();

// 建立叢集柱狀圖
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// 為圖表系列 1 加入指數趨勢線
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// 為圖表系列 1 加入線性趨勢線
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// 為圖表系列 2 加入對數趨勢線
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// 為圖表系列 2 加入移動平均趨勢線
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// 為圖表系列 3 加入多項式趨勢線
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// 為圖表系列 3 加入指數次方趨勢線
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// 儲存簡報
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **新增自訂線**
Aspose.Slides for .NET 提供簡易的 API 於圖表中加入自訂線。若要在簡報的特定投影片上加入簡單的直線，請依照下列步驟操作：

- 建立 Presentation 類別的執行個體
- 使用索引取得投影片的參考
- 透過 Shapes 物件的 AddChart 方法建立新圖表
- 透過 Shapes 物件的 AddAutoShape 方法加入 Line 類型的 AutoShape
- 設定形狀線條的顏色
- 將修改後的簡報寫入 PPTX 檔案

以下程式碼用於建立帶有自訂線的圖表。

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**趨勢線的「向前」與「向後」是什麼意思？**

它們代表趨勢線向前或向後延伸的長度：對散佈圖（XY）而言，以坐標軸單位表示；對非散佈圖而言，以類別數量表示。只允許非負值。

**在將簡報匯出為 PDF 或 SVG，或將投影片渲染為影像時，趨勢線會被保留嗎？**

會。Aspose.Slides 會將簡報轉換為 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)/[SVG](/slides/zh-hant/net/render-a-slide-as-an-svg-image/)，並將圖表渲染為影像；作為圖表一部份的趨勢線在這些操作中都會被保留。亦提供方法可 [匯出圖表的影像](/slides/zh-hant/net/create-shape-thumbnails/)。