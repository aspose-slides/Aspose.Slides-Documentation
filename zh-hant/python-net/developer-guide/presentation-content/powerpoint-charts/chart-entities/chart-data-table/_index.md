---
title: 使用 Python 自訂簡報中的圖表資料表
linktitle: 資料表
type: docs
url: /zh-hant/python-net/chart-data-table/
keywords:
- 圖表資料
- 資料表
- 字型屬性
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 簡報中自訂圖表資料表的字型、邊框與圖例鍵。"
---
## **概述**

Aspose.Slides for Python via .NET 讓您可以顯示圖表的資料表並自訂其文字格式、邊框以及圖例鍵。本文說明如何啟用資料表、格式化文字、控制各種邊框，以及顯示或隱藏圖例鍵。範例會將設定好的圖表儲存為 PPTX 檔案。

## **設定字體屬性**

若要顯示圖表的資料表，請將 [has_data_table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/has_data_table/) 設為 `True`。使用 [chart_data_table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/chart_data_table/) 來存取資料表並設定文字格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別載入簡報。
1. 在第一張投影片上新增一個群組柱狀圖。
1. 啟用圖表的資料表。
1. 透過 [font_bold](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/font_bold/) 開啟粗體，並將 [font_height](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/font_height/) 設為 `20`，以取得 20 點的文字大小。
1. 儲存已修改的簡報。

以下示例要求工作目錄中有 `test.pptx`（至少包含一張投影片）。它會在位置 (50, 50) 處加入一個預設資料的圖表，寬度為 600 點，高度為 400 點。儲存的 `output.pptx` 會包含已啟用資料表且套用指定字體設定的圖表。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **自訂資料表邊框**

使用 [Chart.has_data_table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/has_data_table/) 啟用資料表，並透過 [Chart.chart_data_table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/chart_data_table/) 存取。您可以獨立控制三種邊框：

- [has_border_horizontal](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datatable/has_border_horizontal/) 控制水平儲存格邊框。
- [has_border_vertical](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datatable/has_border_vertical/) 控制垂直儲存格邊框。
- [has_border_outline](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datatable/has_border_outline/) 控制資料表的外框。

將每個屬性設為 `True` 以顯示對應邊框，或設為 `False` 以隱藏。以下示例建立一個預設資料的群組柱狀圖，顯示水平邊框與外框，隱藏垂直邊框。此範例不需輸入檔案，圖表位置與大小皆以點為單位指定。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

下表的比較使用相同的圖表資料與圖例鍵設定，分成四種情況。從全部啟用邊框開始，每個變體僅關閉一項邊框屬性。左下角的變體與示例中的邊框設定相同。

![所有邊框均已啟用、未顯示水平邊框、未顯示垂直邊框以及未顯示外框的圖表資料表](data-table-borders.png)

## **顯示或隱藏圖例鍵**

圖例鍵是資料表中系列名稱旁的彩色小標記，用於協助讀者將每一列對應到圖表的系列。將 [show_legend_key](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datatable/show_legend_key/) 設為 `True` 即可顯示這些標記，設為 `False` 則隱藏。

圖表的獨立圖例由 [Chart.has_legend](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/has_legend/) 控制。這兩項設定彼此獨立：隱藏獨立圖例不會影響資料表內的鍵，隱藏資料表的鍵也不會影響獨立圖例。

以下示例建立一個預設資料的圖表，啟用其資料表，並在隱藏獨立圖例的同時顯示資料表內的圖例鍵。所有表格邊框皆明確啟用，無需輸入簡報。若只想隱藏表格的鍵，將 `data_table.show_legend_key` 改為 `False`。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

下表的比較顯示同一資料表在圖例鍵啟用與關閉兩種情況下的差異。所有邊框均保持啟用，且兩種情況下的獨立圖例皆被隱藏。

![左側顯示圖例鍵、右側隱藏圖例鍵的圖表資料表](data-table-legend-keys.png)

## **常見問題**

**我可以在圖表的資料表中顯示圖例鍵嗎？**

可以。將 [show_legend_key](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datatable/show_legend_key/) 設為 `True` 即可顯示圖例鍵，設為 `False` 則隱藏。

**將簡報匯出為 PDF、HTML 或圖像時，資料表會被保留嗎？**

會。Aspose.Slides 會在匯出為 [PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)、[HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/) 或 [images](/slides/zh-hant/python-net/convert-powerpoint-to-png/) 時，將圖表及其顯示的資料表作為投影片的一部份渲染。

**我可以在從範本載入的圖表中使用資料表嗎？**

可以。對於從現有簡報或範本載入的圖表，使用 [has_data_table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/has_data_table/) 來檢查或變更是否顯示資料表。

**如何找出已啟用資料表的圖表？**

遍歷每張投影片上的圖形，識別圖表，並檢查其 [has_data_table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/has_data_table/) 屬性。屬性為 `True` 表示該圖表已啟用資料表。