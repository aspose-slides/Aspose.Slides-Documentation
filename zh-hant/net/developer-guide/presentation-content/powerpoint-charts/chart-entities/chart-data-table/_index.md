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
description: "使用 Aspose.Slides 在 .NET 中自訂 PPT 與 PPTX 的圖表資料表，以提升簡報的效率與吸引力。"
---
## **概覽**

本文說明了如何在 Aspose.Slides 中使用圖表資料表。它展示了如何為圖表顯示資料表，並透過設定字型屬性（例如粗體樣式和字型高度）自訂文字格式。範例示範了載入簡報、加入圖表、啟用圖表資料表、套用字型設定，並儲存更新後的簡報。

它還簡要回答了關於在圖表資料表中顯示圖例鍵、在匯出時保留資料表、使用從現有簡報或範本載入的圖表，以及辨識已啟用資料表的圖表等常見問題。

## **設定圖表資料表的字型屬性**
Aspose.Slides for .NET 提供了在系列顏色中變更類別顏色的支援。

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別物件。
1. 在投影片上新增圖表。
1. 設定圖表資料表。
1. 設定字型高度。
1. 儲存已修改的簡報。

以下提供範例程式碼。

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**我可以在圖表資料表的數值旁顯示小圖例鍵嗎？**

可以。資料表支援 [圖例鍵](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/datatable/showlegendkey/)，您可以開啟或關閉它們。

**匯出簡報為 PDF、HTML 或圖像時，資料表會被保留嗎？**

會。Aspose.Slides 會將圖表渲染為投影片的一部份，因此匯出的 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)/[HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)/[影像](/slides/zh-hant/net/convert-powerpoint-to-png/) 會包含帶有資料表的圖表。

**從範本檔案產生的圖表是否支援資料表？**

會。對於從現有簡報或範本載入的任何圖表，您可以使用圖表的屬性檢查並變更資料表是否[顯示](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/hasdatatable/)。

**我該如何快速找出檔案中哪些圖表已啟用資料表？**

檢查每個圖表的屬性以判斷資料表是否[顯示](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/hasdatatable/)，並遍歷投影片以找出已啟用的圖表。