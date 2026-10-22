---
title: قالب‌بندی نمودارها در ارائه‌ها با استفاده از پایتون
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/python-net/chart-formatting/
keywords:
- قالب‌بندی نمودار
- قالب‌بندی نمودار
- موجودیت نمودار
- ویژگی‌های نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- ویژگی‌های قلم
- حاشیه گرد
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "قالب‌بندی نمودارها را در Aspose.Slides برای پایتون از طریق .NET بیاموزید و ارائه PowerPoint خود را با محورها، قلم‌ها، قالب‌های عددی و حاشیه‌های گرد سفارشی بهبود ببخشید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides قالب‌بندی کنیم. این مقاله نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، راهنماها، ناحیه نمودار و پر کردن دیوارها را سفارشی کنیم تا ظاهر و قابلیت خواندن داده‌های نمودار بهبود یابد.

همچنین نشان می‌دهد چگونه ویژگی‌های قلم برای متن نمودار را تنظیم کنیم، قالب‌های عددی پیش‌تنظیم‌شده را بر داده‌های نمودار اعمال کنیم و گوشه‌های ناحیه نمودار را گرد کنیم. این مثال‌ها با هم نشان می‌دهند چگونه سبک بصری و ارائه داده‌های نمودار را در یک ارائه کنترل کنیم.

## **قالب‌بندی موجودیت‌های نمودار**

از [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) برای قالب‌بندی عناوین نمودار، محورها، خطوط شبکه، راهنماها و ناحیه نمودار استفاده کنید. این مثال یک نمودار خطی با نشانگرها و داده پیش‌فرض ایجاد می‌کند، سپس سبک‌های متن و خط متفاوتی را برای محور مقدار و محور دسته‌بندی اعمال می‌کند. اندازه‌های قلم و ضخامت خطوط بر حسب پوینت تعیین می‌شود؛ برچسب‌های دسته‌بندی به‌صورت ۴۵ درجه چرخانده می‌شوند.

محور مقدار از [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) به‌صورت مستقل از سلول‌های منبع استفاده می‌کند. مقیاس آن از -۲ تا ۱۵ است، با فواصل اصلی ۲ و فواصل جزئی ۰.۵. این مثال همچنین قالب‌بندی درصد را با [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) که بر روی هزارگان تنظیم شده ترکیب می‌کند، بنابراین این تنظیمات را بر وفق داده معنی و بزرگی داده‌های خود تنظیم کنید. راهنما به‌دلیل غیرفعال بودن [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) در خارج از ناحیه نمودار می‌ماند. پر کردن دیوار پشت و کف از طریق [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) و [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) پیکربندی می‌شود، اما این سطوح تنها در نمودارهای سه‌بعدی قابل مشاهده هستند.

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

## **تنظیم ویژگی‌های قلم برای یک نمودار**

اندازه قلم پیش‌فرض برای متن نمودار را از طریق [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/) تنظیم کنید. این مثال یک نمودار ستونی خوشه‌ای با قلم ۲۰ پوینت ایجاد می‌کند و برچسب‌های مقدار را برای اولین سری از طریق [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) فعال می‌سازد. المان‌های متنی که تنظیمات قلم صریح خود را دارند می‌توانند پیش‌فرض نمودار را بازنویسی کنند.

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

## **تنظیم قالب عددی**

از [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) برای اعمال قالب عددی داخلی به سلول‌های کتاب کار نمودار استفاده کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض سلولی ایجاد می‌کند و اندیس قالب ۱۰ (`0.00%`) را به هر سلول مقدار سری اعمال می‌نماید. این کار نحوه نمایش مقادیر را در کتاب کار بدون تغییر عددهای زیرین تغییر می‌دهد؛ برای مثال، ۰٫۲۵ به صورت ۲۵٫۰۰٪ نمایش داده می‌شود. قالب‌های محور و برچسب داده‌ها می‌توانند به‌صورت جداگانه پیکربندی شوند.

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

جدول زیر ایندکس‌های قالب عددی داخلی را همراه با قالب‌های نمایشی Excel برای منطقه انگلیسی (ایالات متحده) فهرست می‌کند. رشته‌های قالب دقیق و نمایش آنها می‌تواند بسته به برنامه و منطقه مختلف باشد، به‌ویژه برای ارز و تاریخ‌ها. برخی قالب‌های Excel نیز با پیش‌فرض‌های استاندارد OOXML متفاوت هستند، همان‌طور که در [یادداشت‌های پیاده‌سازی قالب عددی مایکروسافت](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توضیح داده شده است.

| شاخص | قالب |
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

## **تنظیم کادرهای گرد ناحیه نمودار**

با فعال‌سازی [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) گوشه‌های ناحیه نمودار را گرد کنید. این مثال یک نمودار ستونی خوشه‌ای می‌سازد و از [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) برای دادن رنگ خاکستری ثابت و سبک خط تک به حاشیه آن استفاده می‌کند قبل از ذخیره‌سازی ارائه.

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

## **ویرایش حاشیه‌نویسی‌های موجود در نمودار**

یک نمودار می‌تواند شامل اشکال سفارشی باشد، مانند حاشیه‌نویسی متنی که وضعیت یک گزارش را توضیح می‌دهد. این اشکال را از طریق [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/) دسترسی پیدا کنید. مجموعه [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) آن شامل اشکال مالکیت‌دار توسط نمودار است.

یک جعبه متن عادی که بر روی نمودار قرار می‌گیرد متعلق به اسلاید است، حتی اگر شبیه بخشی از نمودار به نظر برسد. پیمایش [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) نمودار و اشکال عادی اسلاید را پیدا می‌کند، اما اشکال فردی داخل نمودار را فهرست نمی‌کند. عناوین نمودار و برچسب‌های داده عناصر جداگانه‌ای از نمودار هستند، نه حاشیه‌نویسی‌های سفارشی در این مجموعه.

فایل [chart-annotations.pptx](chart-annotations.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اسلاید اول آن یک نمودار با حاشیه‌نویسی بدون گروه «Preliminary results»، خطی متعلق به نمودار و جعبه متن اسلایدی «Slide overlay» دارد. مثال اولین نمودار را در آن اسلاید می‌یابد و حاشیه‌نویسی را به «Final results» تغییر می‌دهد هنگامی که گزارش آماده انتشار باشد. ابتدا بررسی می‌کند که مجموعه خالی نیست و فقط یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) با [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) که مقدار `None` نیست و متن مورد انتظار را در خود دارد ویرایش می‌کند.

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

خط و جعبه متن اسلاید بدون تغییر می‌مانند. تصاویر زیر ورودی و نتیجه ذخیره‌شده‌ پس از باز کردن مجدد را نشان می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
مثال فقط اشکال سطح بالای متعلق به نمودار را بررسی می‌کند. اگر حاشیه‌نویسی داخل یک [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) باشد، مجموعه [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) آن گروه را نیز بررسی کنید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو تکرار کنید و همان بررسی‌های متنی را برای اشکال فرزند آنها اعمال کنید. یک گروه خود یک محفظه است؛ آن را به‌عنوان جعبه متن درنظر نگیرید.
{{% /alert %}}

## **سؤالات متداول**

**آیا می‌توانم پر کردن‌های نیمه‌شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که حاشیه کاملاً مات باقی بماند؟**

بله. شفافیت پر کردن و حاشیه به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در نمایش‌های پرشلوغ مفید است.

**چگونه می‌توانم با برچسب‌های داده که همپوشانی دارند کنار بیایم؟**

اندازه قلم را کاهش دهید، مؤلفه‌های غیرضروری برچسب (مثلاً دسته‌ها) را غیرفعال کنید، موقعیت برچسب را تنظیم کنید، در صورت لزوم فقط برای نقاط منتخب برچسب نشان دهید، یا قالب را به «value + legend» تغییر دهید.

**آیا می‌توانم پر کردن‌های گرادیان یا طرح را به سری‌ها اعمال کنم؟**

بله. سری‌ها از پر کردن‌های ثابت، گرادیان و طرح پشتیبانی می‌کنند. در عمل، از گرادیان‌ها به‌طور محدود استفاده کنید و ترکیب‌هایی که کنتراست با شبکه و متن را کاهش می‌دهند، پرهیز کنید.