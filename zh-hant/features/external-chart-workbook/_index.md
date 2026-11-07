---
title: 將圖表連結至外部活頁簿
description: 將圖表資料連結至外部活頁簿並重新整理。
type: docs
url: /zh-hant/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **概觀**

將圖表指向外部活頁簿，而不是將所有來源資料嵌入簡報中。您可以設定活頁簿路徑，並選擇是否從該檔案更新圖表。已儲存的圖表亦能攜帶快取的顯示資料。

## **使用範例**

此 C# 範例使用 Aspose.Slides for .NET。建立一個有效的 sales 活頁簿，North = 55、South = 40，並將其寫入輸出目錄旁的 sales.xlsx。將圖表的 North 值重設為 20，然後將圖表連結至活頁簿的絕對路徑並重新整理：North 會再次變為 55。明確的範圍包含標題列和兩筆資料列。重新開啟或更新連結的圖表時，請保留 sales.xlsx；簡報不會嵌入此外部檔案。無需提供輸入檔案。它會儲存 *external-chart-workbook.pptx* 與 *external-chart-workbook.png*。請使用[安裝說明](/slides/zh-hant/net/installation/)。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **常見問題**

### **當連結的檔案遺失時，我能讀取所有快取的值嗎？**

Aspose.Slides for .NET 26.11 能在未開啟連結活頁簿的情況下[直接讀取已儲存的圖表值](/slides/zh-hant/net/chart-workbook/#read-cached-chart-values-without-a-workbook)。這包括普通值、X/Y 值、氣泡大小以及分類值（若快取存在）。快取資料可能缺失或過時；它並非 **完整的** 活頁簿。從來源重新整理仍需要可用的 **受支援的** 活頁簿。對於其他 SDK 與版本，請參閱相應的圖表指南。

### **如果外部活頁簿被搬移會發生什麼情況？**

請將圖表的外部活頁簿路徑更新為新位置，並確保在簡報處理的任何位置皆可取得該檔案。當快取資料缺失時，請勿依賴其執行完整的資料存取操作。

### **連結時，我能選擇是否重新整理快取的圖表資料嗎？**

可以。設定連結時可選擇是否更新圖表資料。重新整理需要可用的 **受支援的** 活頁簿；若跳過重新整理，則僅記錄連結而不會從該檔案讀取新值。

## **指南**

- [在 .NET 簡報中管理圖表活頁簿](/slides/zh-hant/net/chart-workbook/)

相關功能：[填寫可編輯圖表的資料](/slides/zh-hant/features/chart-data-binding/)