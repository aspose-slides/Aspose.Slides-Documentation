---
title: 在 .NET 中自訂簡報的圖表資料表
linktitle: 資料表
type: docs
url: /zh-hant/net/chart-data-table/
keywords:
- 圖表資料
- 資料表
- 字型屬性
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 與 C# 在 PowerPoint 簡報中自訂圖表資料表的字型、邊框與圖例鍵。"
---
## **概述**

Aspose.Slides for .NET 允許您顯示圖表的資料表格並自訂其文字格式、邊框和圖例鍵。本文說明如何啟用資料表、格式化文字、控制各種邊框，以及顯示或隱藏圖例鍵。範例會將配置好的圖表儲存為 PPTX 檔案。

## **設定字型屬性**

若要顯示圖表的資料表，將 [HasDataTable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/hasdatatable/) 設為 `true`。使用 [ChartDataTable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/chartdatatable/) 來存取表格並設定其文字格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別載入簡報。
1. 在第一張投影片上新增一個叢集直條圖。
1. 啟用圖表的資料表。
1. 使用 [FontBold](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/fontbold/) 啟用粗體，並將 [FontHeight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/fontheight/) 設為 `20` 以使用 20 點字體。
1. 儲存已修改的簡報。

以下示例需要工作目錄中有至少一張投影片的 `test.pptx`。它會在位置 (50, 50) 處新增一個使用預設資料的圖表，寬度為 600 點，高度為 400 點。儲存的 `output.pptx` 包含已啟用資料表且套用指定字型設定的圖表。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **自訂資料表格邊框**

使用 [IChart.HasDataTable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/hasdatatable/) 啟用表格，並透過 [IChart.ChartDataTable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/chartdatatable/) 存取。您可以獨立控制三種邊框：

- [HasBorderHorizontal](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/idatatable/hasborderhorizontal/) 控制水平儲存格邊框。
- [HasBorderVertical](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/idatatable/hasbordervertical/) 控制垂直儲存格邊框。
- [HasBorderOutline](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/idatatable/hasborderoutline/) 控制表格的外圍邊框。

將每個屬性設為 `true` 以顯示其邊框，或設為 `false` 以隱藏。以下示例建立一個使用預設資料的叢集直條圖，顯示水平邊框與外圍邊框，隱藏垂直邊框。此示例不需要輸入檔案。圖表的位置與尺寸以點為單位指定。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

以下比較在四種情況下皆使用相同的圖表資料與圖例鍵設定。從全部啟用邊框開始，每個其餘變體僅關閉一種邊框屬性。左下角的變體與範例中的邊框設定相同。

![啟用所有邊框、未啟用水平邊框、未啟用垂直邊框以及未啟用外圍邊框的圖表資料表](data-table-borders.png)

## **顯示或隱藏圖例鍵**

圖例鍵是資料表中系列名稱旁的彩色小標記。它們可協助讀者將每個表格列對應到圖表系列。將 [ShowLegendKey](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/idatatable/showlegendkey/) 設為 `true` 以顯示這些標記，或設為 `false` 以隱藏。

圖表的獨立圖例由 [IChart.HasLegend](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/haslegend/) 控制。這些設定彼此獨立：隱藏獨立圖例不會隱藏資料表內的鍵，隱藏表格鍵也不會隱藏獨立圖例。

以下示例建立一個使用預設資料的圖表，啟用其資料表，並在隱藏獨立圖例的同時顯示其中的圖例鍵。所有表格邊框均明確啟用。此示例不需要輸入簡報。若要僅隱藏表格的鍵，請將 `dataTable.ShowLegendKey` 改為 `false`。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

以下比較顯示相同的表格，分別啟用與關閉圖例鍵。所有邊框仍保持啟用，且獨立圖表圖例在兩種情況下皆被隱藏。

![左側顯示圖例鍵、右側隱藏圖例鍵的圖表資料表](data-table-legend-keys.png)

## **常見問題**

**我可以在圖表的資料表中顯示圖例鍵嗎？**

可以。將 [ShowLegendKey](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/datatable/showlegendkey/) 設為 `true` 以顯示圖例鍵，或設為 `false` 以隱藏。

**在將簡報匯出為 PDF、HTML 或影像時，資料表會被保留嗎？**

會。Aspose.Slides 在匯出為 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)、[HTML](/slides/zh-hant/net/convert-powerpoint-to-html/) 或 [images](/slides/zh-hant/net/convert-powerpoint-to-png/) 時，會將圖表及其顯示的資料表作為投影片的一部分進行渲染。

**我可以對從範本載入的圖表資料表進行操作嗎？**

可以。對於從現有簡報或範本載入的圖表，可使用 [HasDataTable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/hasdatatable/) 來檢查或變更其資料表是否顯示。

**我該如何找出啟用了資料表的圖表？**

遍歷每張投影片上的形狀，識別圖表，並檢查其 [HasDataTable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/hasdatatable/) 屬性。值為 `true` 表示資料表已啟用。