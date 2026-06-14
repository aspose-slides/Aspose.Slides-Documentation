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
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解在 Aspose.Slides for Python（透過 .NET）中的圖表格式化，並以專業且引人注目的樣式提升您的 PowerPoint 或 OpenDocument 簡報。"
---
## **Overview**

本文說明如何使用 Aspose.Slides 於 PowerPoint 簡報中格式化圖表。它展示了如何自訂圖表的關鍵元素，例如座標軸、格線、標題、圖例、繪圖區域以及牆面填充，以提升圖表資料的外觀與可讀性。

同時也示範了如何設定圖表文字的字型屬性、對圖表資料套用預設與自訂的數字格式，並啟用圖表區域的圓角。這些範例共同說明了如何同時控制圖表的視覺樣式與資料呈現方式。

## **Format Chart Elements**

Aspose.Slides for Python 允許開發者從頭建立自訂圖表並加入投影片。本節說明如何格式化各種圖表元素，包括類別軸與值軸。

Aspose.Slides 提供簡易的 API 來管理圖表元素並套用自訂格式：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 新增一個具有預設資料、類型為 `ChartType.LINE_WITH_MARKERS` 的圖表。
1. 取得圖表的值軸並設定以下項目：
   1. 為值軸主要格線設定 **線條格式**。
   1. 為值軸次要格線設定 **線條格式**。
   1. 為值軸設定 **數字格式**。
   1. 為值軸設定 **最小值、最大值、主要單位與次要單位**。
   1. 為值軸標籤設定 **文字屬性**。
   1. 為值軸設定 **標題**。
   1. 為值軸設定 **線條格式**。
1. 取得圖表的類別軸並設定以下項目：
   1. 為類別軸主要格線設定 **線條格式**。
   1. 為類別軸次要格線設定 **線條格式**。
   1. 為類別軸標籤設定 **文字屬性**。
   1. 為類別軸設定 **標題**。
   1. 為類別軸設定 **標籤位置**。
   1. 為類別軸標籤設定 **旋轉角度**。
1. 取得圖表圖例並設定其 **文字屬性**。
1. 顯示圖例且不與圖表重疊。
1. 取得圖表的 **次要值軸** 並設定以下項目：
   1. 啟用次要 **值軸**。
   1. 為次要值軸設定 **線條格式**。
   1. 為次要值軸設定 **數字格式**。
   1. 為次要值軸設定 **最小值、最大值、主要單位與次要單位**。
1. 在次要值軸上繪製第一個圖表系列。
1. 設定圖表背牆的填色。
1. 設定圖表繪圖區域的填色。
1. 將修改後的簡報寫入 PPTX 檔案。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

    # 實例化 Presentation 類別。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 加入範例圖表。
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # 設定圖表標題。
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # 設定值軸主要格線的格式。
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # 設定值軸次要格線的格式。
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # 設定值軸的數字格式。
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # 設定值軸的最大值、最小值、主要單位與次要單位。
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # 設定值軸文字屬性。
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # 設定值軸標題。
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # 設定類別軸主要格線的格式。
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # 設定類別軸次要格線的格式。
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # 設定類別軸文字屬性。
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # 設定類別軸標題。
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # 設定類別軸標籤位置。
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # 設定類別軸標籤旋轉角度。
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # 設定圖例文字屬性。
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # 顯示圖表圖例，併排於圖表上方。
    chart.legend.overlay = True
                
    # 設定圖表背牆顏色。
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # 設定繪圖區域顏色。
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # 儲存簡報。
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Chart Font Properties**

Aspose.Slides for Python 支援設定圖表的字型相關屬性。請依下列步驟配置圖表字型屬性：

1. 實例化一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件。
1. 在投影片上加入圖表。
1. 設定字型高度。
1. 儲存修改後的簡報。

以下提供樣本程式碼。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Numeric Format**

Aspose.Slides for Python 提供簡易的 API 來管理圖表資料格式：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 新增一個具有預設資料的圖表，類型自行決定。
1. 從可用的預設值中選取數字格式。
1. 遍歷每個系列的圖表資料儲存格並設定數字格式。
1. 儲存簡報。
1. 設定自訂數字格式。
1. 再次遍歷每個系列的圖表資料儲存格並設定不同的數字格式。
1. 儲存簡報。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 實例化 Presentation 類別。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 加入預設的叢集柱狀圖。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # 設定預設的數字格式。
    # 遍歷每個圖表系列。
    for series in chart.chart_data.series:
        # 遍歷每個系列的資料點。
        for cell in series.data_points:
            # 設定數字格式。
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # 儲存簡報。
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

以下列出可用的預設數字格式與其對應索引。

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Set Rounded Borders for the Chart Area**

Aspose.Slides for Python 支援透過 `Chart.has_rounded_corners` 屬性設定圖表區域的圓角。

1. 實例化一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件。
2. 在投影片上加入圖表。
3. 設定圖表的填充類型與填充顏色。
4. 將圓角屬性設為 `True`。
5. 儲存修改後的簡報。

以下提供樣本。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I set semi-transparent fills for columns/areas while keeping the border opaque?**

Yes. Fill transparency and the outline are configured separately. This is useful for improving the readability of the grid and data in dense visualizations.

**How can I deal with data labels when they overlap?**

Reduce the font size, disable nonessential label components (for example, categories), set the label offset/position, show labels only for selected points if necessary, or switch the format to "value + legend".

**Can I apply gradient or pattern fills to series?**

Yes. Both solid and gradient/pattern fills are typically available. In practice, use gradients sparingly and avoid combinations that reduce contrast with the grid and text.