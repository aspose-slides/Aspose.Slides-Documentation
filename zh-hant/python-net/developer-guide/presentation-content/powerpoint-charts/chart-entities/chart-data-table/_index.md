---
title: 自訂 Python 圖表資料表
linktitle: 資料表
type: docs
url: /zh-hant/python-net/chart-data-table/
keywords:
- 圖表資料
- 資料表
- 字型屬性
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中自訂 PPT、PPTX 及 ODV 的圖表資料表，以提升簡報的效率與吸引力。"
---
## **概述**

本文說明如何在 Aspose.Slides 中操作圖表資料表。它展示了如何為圖表顯示資料表，並透過設定字型屬性（例如粗體樣式和字型高度）自訂文字格式。範例示範了載入簡報、添加圖表、啟用圖表資料表、套用字型設定，並儲存更新後的簡報。

它還包含有關在圖表資料表中顯示圖例鍵、在匯出時保留資料表、處理從現有簡報或範本載入的圖表，以及識別已啟用資料表的圖表等常見問題的簡短回答。

## **設定圖表資料表的字型屬性**
Aspose.Slides for Python via .NET 提供了變更系列顏色中類別顏色的支援。

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別物件。
1. 在投影片上加入圖表。
1. 設定圖表資料表。
1. 設定字型高度。
1. 儲存已修改的簡報。

以下提供範例。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以在圖表資料表的數值旁顯示小圖例鍵嗎？**

是的。資料表支援[legend keys](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datatable/show_legend_key/)，您可以開啟或關閉它們。

**在將簡報匯出為 PDF、HTML 或影像時，資料表會被保留嗎？**

是的。Aspose.Slides 會將圖表渲染為投影片的一部分，因此匯出的[PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/)/[image](/slides/zh-hant/python-net/convert-powerpoint-to-png/)會包含帶有資料表的圖表。

**從範本檔案中取得的圖表是否支援資料表？**

是的。對於任何從現有簡報或範本載入的圖表，您都可以使用圖表的屬性檢查並變更資料表是否[顯示](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/has_data_table/)。

**如何快速找出檔案中哪些圖表已啟用資料表？**

檢查每個圖表的屬性以判斷資料表是否[顯示](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/has_data_table/)，並遍歷投影片以識別已啟用資料表的圖表。