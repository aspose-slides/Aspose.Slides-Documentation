---
title: 使用 Python 在簡報中格式化圖表
linktitle: 圖表格式化
type: docs
weight: 60
url: /zh-hant/python-net/chart-formatting/
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
- Python
- Aspose.Slides
description: "了解在 Aspose.Slides for Python via .NET 中的圖表格式化，並透過自訂座標軸、字型、數值格式與圓角圖表邊框，提升您的 PowerPoint 簡報。"
---
## **概述**

本篇說明如何使用 Aspose.Slides 在 PowerPoint 簡報中格式化圖表。它展示了如何自訂圖表的關鍵元素，例如座標軸、格線、標題、圖例、繪圖區域與牆面填色，以提升圖表資料的外觀與可讀性。

同時亦示範了如何為圖表文字設定字型屬性、套用預設數值格式，以及為圖表區域啟用圓角。這些範例共同說明了如何同時控制圖表的視覺樣式與資料呈現方式。

## **格式化圖表實體**

使用 [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) 來格式化圖表標題、座標軸、格線、圖例與繪圖區域。此範例建立一個含標記的折線圖與預設資料，然後對其值軸與類別軸分別套用文字與線條樣式。字型大小與線寬皆以點為單位；類別標籤旋轉 45 度。

值軸使用 [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)，獨立於來源儲存格。其刻度範圍為 -2 到 15，主間隔為 2，次間隔為 0.5。範例也將百分比格式與 [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/)（設定為千）結合，請依據資料的意義與量級調整這些設定。圖例因 [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) 被停用，會位於繪圖區域外側。背牆與地板填色透過 [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) 與 [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) 設定，但僅在 3D 圖表中可見。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **為圖表設定字型屬性**

透過 [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/) 設定圖表文字的預設字型大小。此範例建立一個叢集柱狀圖，字型為 20 點，並使用 [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) 為第一個系列啟用值標籤。具有自行明確字型設定的文字元素可以覆寫圖表的預設設定。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **設定數值格式**

使用 [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) 將內建數值格式套用至圖表工作簿儲存格。此範例建立一個叢集柱狀圖，使用預設的儲存格資料，並將格式索引 10 (`0.00%`) 套用至每個系列的值儲存格。此動作會改變工作簿中值的顯示方式，而不改變底層數字；例如 0.25 會顯示為 25.00%。座標軸與資料標籤的格式可分別設定。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

以下表格列出內建數值格式索引，以及對應於英文（美國）語系的 Excel 範例格式。實際的格式字串與顯示方式可能因應用程式與語系而異，特別是貨幣與日期。部分 Excel 格式亦與 OOXML 標準的預設值不同，詳情請參考[Microsoft 的數值格式實作說明](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)。

| 索引 | 格式 |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **設定圖表區域圓角邊框**

啟用 [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) 以將圖表區域的角落變圓。此範例建立一個叢集柱狀圖，並使用 [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) 為其外框設定實線灰色與單線樣式後儲存簡報。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **編輯既有圖表註解**

圖表可包含自訂形狀，例如說明報表狀態的文字註解。可透過 [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/) 取得這些形狀。其 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) 集合包含圖表所擁有的形狀。

放置於圖表之上的普通文字方塊屬於投影片，即使外觀看起來像圖表的一部份。遍歷 [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) 會找到圖表與普通投影片形狀，但不會列舉圖表內部的各個形狀。圖表標題與資料標籤是獨立的圖表元素，並非此集合中的自訂註解。

下載 [chart-annotations.pptx](chart-annotations.pptx) 並放置於應用程式的工作目錄。其第一張投影片包含一個未分組的註解「Preliminary results」、一條圖表擁有的線條，以及一個普通投影片文字方塊顯示「Slide overlay」。範例會在該投影片上找到第一個圖表，並在報表準備發布時將註解改為「Final results」。它會檢查集合是否為空，且僅編輯那些 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 其 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) 非 `None` 且包含預期文字的項目。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

線條與投影片文字方塊保持不變。以下圖示顯示輸入與儲存後重新開啟的結果：

| 編輯前 | 編輯後 |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
範例僅檢查最高層級的圖表擁有形狀。如果註解位於 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) 之內，亦需檢查該群組的 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) 集合。對於巢狀群組，請以遞迴方式重複此程序，將相同的文字檢查套用至其子形狀。群組本身只是容器，不應視為文字方塊。
{{% /alert %}}

## **常見問題**

**我可以為柱狀圖/區域圖設定半透明填色，同時保持邊框不透明嗎？**

可以。填色透明度與外框是分別設定的，這對於在資訊密集的視覺化中提升格線與資料的可讀性很有幫助。

**當資料標籤互相重疊時，我該怎麼處理？**

減小字型大小、停用非必要的標籤元件（例如類別），調整標籤位置，必要時僅顯示選取點的標籤，或改為「值 + 圖例」的格式。

**我可以為系列套用漸層或圖樣填色嗎？**

可以。系列支援實色、漸層與圖樣填色。實務上建議節制使用漸層，避免與格線或文字的對比度下降。