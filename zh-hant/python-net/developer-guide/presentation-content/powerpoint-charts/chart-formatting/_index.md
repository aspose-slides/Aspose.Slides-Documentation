---
title: 使用 Python 在簡報中格式化圖表
linktitle: 圖表格式化
type: docs
weight: 60
url: /zh-hant/python-net/chart-formatting/
keywords:
- 格式化圖表
- 圖表格式設定
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
description: "了解在 Aspose.Slides for Python (via .NET) 中的圖表格式設定，並透過自訂坐標軸、字型、數字格式與圓角圖表邊框，提升您的 PowerPoint 簡報。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 在 PowerPoint 簡報中格式化圖表。它展示了如何自訂關鍵圖表元素，例如坐標軸、格線、標題、圖例、繪圖區域以及牆面填充，以提升圖表資料的外觀和可讀性。

它還示範了如何設定圖表文字的字型屬性、對圖表資料套用預設數字格式，以及啟用圖表區域的圓角。這些範例一起說明了如何同時控制圖表的視覺樣式與資料呈現。

如需針對升降區間設定分別的填色與輪廓，請參考[股票圖表示例](/slides/zh-hant/python-net/create-chart/#create-stock-charts)。

## **格式化圖表實體**

使用 [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) 來格式化圖表標題、坐標軸、格線、圖例與繪圖區域。此範例建立一個帶有標記和預設資料的折線圖，然後對其值軸與類別軸套用各自的文字與線條樣式。字型大小和線寬以點為單位指定；類別標籤以 45 度旋轉。

值軸使用 [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)，與來源儲存格無關。其比例從 -2 到 15，主要間隔為 2，次要間隔為 0.5。此範例還結合了百分比格式化，並將 [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) 設為千位，請依據資料的意義與量級調整這些設定。圖例因為已停用 [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/)，因此保持在繪圖區域外。背牆和地板的填充透過 [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) 與 [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) 設定，但這些表面僅在 3D 圖表中可見。

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

## **設定圖表的字型屬性**

透過 [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/) 設定圖表文字的預設字型大小。此範例建立一個叢集柱狀圖，使用 20 點字型，並透過 [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) 為第一系列啟用數值標籤。具有自行明確字型設定的文字元素可以覆寫圖表的預設值。

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

## **重新使用文字框格式設定於圖例**

若要使圖例與投影片標題相匹配，請在標題的第一段落上使用 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) 設定字型。對圖例的 [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) 呼叫 [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/)。它會複製文字框設定、第一段落的格式以及該段落的預設字型屬性。直接套用於個別部分或後續段落的格式則僅保留在來源本身。

此範例使用粗體、深藍色、26 點 Calibri 的標題作為範本。樣式化圖例後，它使用 [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) 將相同的格式套用到另一個說明文字上。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

在已儲存的簡報中，圖例與說明文字在大小、字重與顏色上與標題相匹配。圖例仍顯示系列名稱，說明文字則保留自己的文字內容。如果說明文字中的某個部分已設定明確的字型大小，則該大小優先於複製的段落預設值。

| 複製前 | 複製後 |
| --- | --- |
| ![季度銷售圖表，圖例標籤為普通黑色，說明文字為黑色](legend-formatting-before.png) | ![相同圖表，圖例標籤較大、粗體深藍色，且說明文字相匹配](legend-formatting.png) |

## **設定數字格式**

使用 [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) 將內建數字格式套用到圖表工作簿儲存格。此範例建立一個預設、以儲存格為基礎資料的叢集柱狀圖，並將格式索引 10（`0.00%`）套用到每個系列的值儲存格。這會更改工作簿中顯示的數值方式，而不改變底層數字；例如，0.25 會顯示為 25.00%。坐標軸與資料標籤格式可分別設定。

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

下表列出內建數字格式索引及其在英語（美國）語系下的代表性 Excel 格式。確切的格式字串及顯示方式可能因應用程式與語系而異，特別是貨幣與日期。有些 Excel 格式亦與 OOXML 標準的預設值不同，如 [Microsoft 的數字格式實作說明](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) 所述。

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

啟用 [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) 以使圖表區域的角落變圓。此範例建立一個叢集柱狀圖，並使用 [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) 為其外框設定實心灰色且單線樣式，然後儲存簡報。

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

## **編輯現有圖表註釋**

圖表可以包含自訂形狀，例如說明報告狀態的文字註釋。可透過 [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/) 取得這些形狀。其 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) 集合包含圖表擁有的形狀。

放在圖表上方的普通文字方塊屬於投影片，即使它看起來像圖表的一部份。遍歷 [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) 可以找到圖表和普通投影片形狀，但不會列舉圖表內部的個別形狀。圖表標題與資料標籤是獨立的圖表元素，並非此集合中的自訂註釋。

下載 [chart-annotations.pptx](chart-annotations.pptx) 並放置於應用程式的工作目錄。其第一張投影片包含一個圖表，圖表上有未群組的註釋文字「Preliminary results」、圖表擁有的線條，以及一個普通投影片文字方塊文字為「Slide overlay」。此範例在該投影片上找到第一個圖表，並在報告準備發布時將註釋改為「Final results」。它會檢查集合是否為空，僅編輯具有非 `None` 且包含預期文字的 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) 的 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。

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

線條與投影片文字方塊保持不變。以下影像顯示輸入與儲存後重新開啟的結果：

| 編輯前 | 編輯後 |
| --- | --- |
| ![圖表註釋文字為 Preliminary results](chart-annotations-before.png) | ![圖表註釋文字為 Final results](chart-annotations-after.png) |

{{% alert color="info" title="注意" %}}
此範例僅檢查最高層級的圖表擁有形狀。如果註釋位於 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) 之中，亦需檢查該群組的 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) 集合。對於巢狀群組遞迴執行相同的檢查，對其子形狀套用相同的文字判斷。群組本身只是容器；不要把它當作文字方塊。
{{% /alert %}}

## **常見問題**

**我可以為柱狀圖/區域設定半透明填充，同時保持邊框不透明嗎？**

是的。填充透明度與外框分別設定。此方式有助於提升密集視覺化中格線與資料的可讀性。

**當資料標籤重疊時，我該如何處理？**

縮小字型大小、停用非必要的標籤元件（例如類別）、調整標籤位置、必要時僅顯示選取點的標籤，或改用「數值 + 圖例」的格式。

**我可以對系列套用漸層或圖案填充嗎？**

可以。系列支援實心、漸層與圖案填充。實務上請斟酌使用漸層，且避免使用會降低格線與文字對比度的組合。