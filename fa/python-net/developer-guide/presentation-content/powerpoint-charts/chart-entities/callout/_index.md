---
title: "مدیریت حاشیه‌نویسی‌ها در نمودارهای ارائه با پایتون"
linktitle: "حاشیه‌نویسی"
type: docs
url: /fa/python-net/callout/
keywords:
- "حاشیه‌نویسی نمودار"
- "استفاده از حاشیه‌نویسی"
- "برچسب داده"
- "قالب برچسب"
- "پایتون"
- "Aspose.Slides"
description: "ایجاد و استایل دهی حاشیه‌نویسی‌ها در Aspose.Slides برای Python .NET با مثال‌های کد مختصر، سازگار با PPT، PPTX و ODP برای خودکارسازی جریان کار ارائه‌ها."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با حاشیه‌نویسی‌ها برای برچسب‌های دادهٔ نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه از خصوصیت `show_label_as_data_callout` برای نمایش برچسب‌ها به‌صورت حاشیه‌نویسی استفاده شود، چگونه تنظیمات مربوط به حاشیه‌نویسی برچسب‌ها برای نمودار دونات پیکربندی شود، و اشاره می‌کند که حاشیه‌نویسی‌ها و ظاهر آن‌ها هنگام صادرات ارائه‌ها به فرمت‌های PDF، HTML5، SVG و تصاویر رستری حفظ می‌شوند.

## **استفاده از حاشیه‌نویسی‌ها**
ویژگی جدید **show_label_as_data_callout** به کلاس **DataLabelFormat** افزوده شده است که تعیین می‌کند برچسب دادهٔ نمودار مشخص شده به‌صورت حاشیه‌نویسی یا به‌صورت برچسب داده نمایش داده شود. در مثال زیر، حاشیه‌نویسی‌ها تنظیم شده‌اند.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم حاشیه‌نویسی برای نمودار دونات**
Aspose.Slides برای Python از طریق .NET امکان تنظیم شکل حاشیه‌نویسی برچسب دادهٔ سری برای نمودار دونات را فراهم می‌کند. نمونه کد زیر ارائه شده است.

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

## **سوالات متداول**
**آیا حاشیه‌نویسی‌ها هنگام تبدیل یک ارائه به PDF، HTML5، SVG یا تصاویر حفظ می‌شوند؟**

بله. حاشیه‌نویسی‌ها بخشی از رندر نمودار هستند، بنابراین هنگام صادرات به [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/)، [HTML5](/slides/fa/python-net/export-to-html5/)، [SVG](/slides/fa/python-net/render-a-slide-as-an-svg-image/) یا [raster images](/slides/fa/python-net/convert-powerpoint-to-png/)، آن‌ها همراه با قالب‌بندی اسلاید حفظ می‌شوند.

**آیا قلم‌های سفارشی در حاشیه‌نویسی‌ها کار می‌کنند و آیا می‌توان ظاهر آن‌ها را هنگام صادرات حفظ کرد؟**

بله. Aspose.Slides از [embedding fonts](/slides/fa/python-net/embedded-font/) به ارائه پشتیبانی می‌کند و فرآیند وارد کردن قلم‌ها را در صادرات‌ها مانند [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/) کنترل می‌نماید، به‌طوری‌که حاشیه‌نویسی‌ها در سیستم‌های مختلف ظاهر یکسانی داشته باشند.