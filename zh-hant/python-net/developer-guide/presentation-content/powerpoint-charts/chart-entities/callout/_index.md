---
title: 使用 Python 管理簡報圖表中的標註
linktitle: 標註
type: docs
url: /zh-hant/python-net/callout/
keywords:
- 圖表標註
- 使用標註
- 資料標籤
- 標籤格式
- Python
- Aspose.Slides
description: "使用簡潔的程式碼範例，在 Aspose.Slides for Python .NET 中建立與樣式化標註，兼容 PPT、PPTX 與 ODP，以自動化簡報工作流程。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表資料標籤的標註（callout）。它展示了如何使用 `show_label_as_data_callout` 屬性將標籤顯示為標註、如何為甜甜圈圖表設定與標註相關的標籤設定，並指出在將簡報匯出為 PDF、HTML5、SVG 與點陣圖格式時，標註及其外觀會被保留。

## **使用標註**
已於 **DataLabelFormat** 類別中新增屬性 **show_label_as_data_callout**，該屬性決定指定圖表的資料標籤是顯示為資料標註還是普通資料標籤。在下方範例中，我們已設定標註。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```



## **為甜甜圈圖設定標註**
Aspose.Slides for Python via .NET 提供支援，可為甜甜圈圖設定系列資料標籤的標註形狀。以下提供示範範例。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.DOUGHNUT, 10, 10, 500, 500, False)
    workBook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = False
    seriesIndex = 0
    while seriesIndex < 15:
        series = chart.chart_data.series.add(workBook.get_cell(0, 0, seriesIndex + 1, "SERIES " + str(seriesIndex)), chart.type)
        series.explosion = 0
        series.parent_series_group.doughnut_hole_size = 20
        series.parent_series_group.first_slice_angle = 351
        seriesIndex += 1
    categoryIndex = 0
    while categoryIndex < 15:
        chart.chart_data.categories.add(workBook.get_cell(0, categoryIndex + 1, 0, "CATEGORY " + str(categoryIndex)))
        i = 0
        while i < len(chart.chart_data.series):
            iCS = chart.chart_data.series[i]
            dataPoint = iCS.data_points.add_data_point_for_doughnut_series(workBook.get_cell(0, categoryIndex + 1, i + 1, 1))
            dataPoint.format.fill.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.solid_fill_color.color = draw.Color.white
            dataPoint.format.line.width = 1
            dataPoint.format.line.style = slides.LineStyle.SINGLE
            dataPoint.format.line.dash_style = slides.LineDashStyle.SOLID
            if i == len(chart.chart_data.series) - 1:
                lbl = dataPoint.label
                lbl.text_format.text_block_format.autofit_type = slides.TextAutofitType.SHAPE
                lbl.data_label_format.text_format.portion_format.font_bold = 1
                lbl.data_label_format.text_format.portion_format.latin_font = slides.FontData("DINPro-Bold")
                lbl.data_label_format.text_format.portion_format.font_height = 12
                lbl.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
                lbl.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.light_gray
                lbl.data_label_format.format.line.fill_format.solid_fill_color.color = draw.Color.white
                lbl.data_label_format.show_value = False
                lbl.data_label_format.show_category_name = True
                lbl.data_label_format.show_series_name = False
                lbl.data_label_format.show_leader_lines = True
                lbl.data_label_format.show_label_as_data_callout = False
                chart.validate_chart_layout()
                lbl.as_i_layoutable.x += 0.5
                lbl.as_i_layoutable.y += 0.5
            i += 1
        categoryIndex +=1 
    pres.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**在將簡報轉換為 PDF、HTML5、SVG 或影像時，標註會被保留嗎？**

是。標註是圖表渲染的一部分，因此當您匯出至[PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh-hant/python-net/export-to-html5/)、[SVG](/slides/zh-hant/python-net/render-a-slide-as-an-svg-image/)或[點陣圖](/slides/zh-hant/python-net/convert-powerpoint-to-png/)時，會與投影片的格式一起被保留。

**自訂字型在標註中是否可使用，且其外觀在匯出時能被保留嗎？**

是。Aspose.Slides 支援將[嵌入字型](/slides/zh-hant/python-net/embedded-font/)放入簡報，並在匯出（例如[PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)）時控制字型嵌入，確保標註在不同系統中保持相同外觀。