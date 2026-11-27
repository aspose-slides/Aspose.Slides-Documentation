---
title: قالب‌بندی نمودارها در ارائه‌ها با استفاده از پایتون
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/python-net/chart-formatting/
keywords:
- قالب نمودار
- قالب‌بندی نمودار
- موجودیت نمودار
- ویژگی‌های نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- ویژگی‌های قلم
- حاشیه گرد
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "در Aspose.Slides برای پایتون از طریق .NET قالب‌بندی نمودارها را بیاموزید و ارائه PowerPoint خود را با محورهای سفارشی، قلم‌ها، قالب‌های عددی و حاشیه‌های گرد نمودار ارتقا دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با استفاده از Aspose.Slides نمودارها را در ارائه‌های PowerPoint قالب‌بندی کنید. این مقاله نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محور‌ها، خطوط شبکه، عناوین، افسانه‌ها، ناحیه تصویر و پرکن‌های دیوار را سفارشی کنید تا ظاهر و خوانایی داده‌های نمودار بهبود یابد. همچنین نشان می‌دهد چگونه ویژگی‌های قلم برای متن نمودار را تنظیم کنید، قالب‌های عددی پیش‌تنظیم را به داده‌های نمودار اعمال کنید و گوشه‌های گرد برای ناحیه نمودار فعال کنید. این مثال‌ها به‌طور مشترک نشان می‌دهند چگونه سبک بصری و ارائه داده‌های نمودارها را در یک ارائه کنترل کنید. برای پرکن‌ها و خطوط مرزی جداگانه در فواصل صعودی و نزولی، مثال [نمودار سهام](/slides/fa/python-net/create-chart/#create-stock-charts) را ببینید.

## **قالب‌بندی موجودیت‌های نمودار**

از [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) برای قالب‌بندی عناوین نمودار، محورها، خطوط شبکه، افسانه‌ها و ناحیه تصویر استفاده کنید. این مثال یک نمودار خطی با نشانگرها و داده‌های پیش‌فرض ایجاد می‌کند، سپس سبک‌های متن و خط جداگانه‌ای را به محور مقدار و محور دسته‌بندی آن اعمال می‌کند. اندازه‌های قلم و عرض خطوط به واحد نقطه مشخص شده‌اند؛ برچسب‌های دسته‌بندی به اندازه 45 درجه چرخیده‌اند. محور مقدار از [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) به‌ طور مستقل از سلول‌های منبع استفاده می‌کند. مقیاس آن از -2 تا 15 است، با فواصل اصلی 2 و فواصل جزئی 0.5. این مثال همچنین قالب‌بندی درصدی را با [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) تنظیم‌شده بر روی هزارها ترکیب می‌کند، بنابراین این تنظیمات را مطابق معنی و مقیاس داده‌های خود تنظیم کنید. افسانه به دلیل غیرفعال بودن [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) در خارج از ناحیه تصویر می‌ماند. پرکن‌های دیوار پس‌زمینه و کف از طریق [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) و [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) پیکربندی می‌شوند، اما این سطوح فقط در نمودارهای سه‌بعدی قابل مشاهده هستند.

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

اندازه قلم پیش‌فرض برای متن نمودار را از طریق [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/) تنظیم کنید. این مثال یک نمودار ستونی خوشه‌ای با قلم 20 پوینت ایجاد می‌کند و برچسب‌های مقدار برای سری اول را از طریق [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) فعال می‌سازد. عناصر متنی که تنظیمات قلم صریح خود را دارند می‌توانند پیش‌فرض نمودار را بازنویسی کنند.

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

## **بازاستفاده از قالب‌بندی فریم متن برای افسانه نمودار**

برای هماهنگ کردن افسانه با عنوان اسلاید، قلم را از طریق [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) در پاراگراف اول عنوان تنظیم کنید. بر روی [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) افسانه، متد [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) را فراخوانی کنید. این متد تنظیمات فریم متن، قالب‌بندی پاراگراف اول و ویژگی‌های قلم پیش‌فرض آن پاراگراف را کپی می‌کند. قالب‌بندی که مستقیماً به بخش‌های جداگانه یا پاراگراف‌های بعدی اعمال می‌شود، به منبع محلی می‌ماند. این مثال از عنوانی با قلم بولد، رنگ سرگیجه‌ای، 26 پوینت Calibri به عنوان الگو استفاده می‌کند. پس از استایل‌دهی به افسانه، از [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) برای اعمال همان قالب‌بندی به یک کپشن جداگانه استفاده می‌کند.

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

در ارائه ذخیره‌شده، افسانه و کپشن از نظر اندازه، وزن و رنگ با عنوان مطابقت دارند. افسانه هنوز نام‌های سری‌ها را نمایش می‌دهد و کپشن متن خود را حفظ می‌کند. اگر بخشی در کپشن قبلاً اندازه قلم صریح داشته باشد، آن اندازه بر پیش‌فرض پاراگراف کپی‌شده ارجحیت دارد.

| قبل از کپی | بعد از کپی |
| --- | --- |
| ![Quarterly sales chart with regular black legend labels and a black caption](legend-formatting-before.png) | ![The same chart with larger, bold navy legend labels and a matching caption](legend-formatting.png) |

## **تنظیم قالب عددی**

از [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) برای اعمال قالب عددی پیش‌فرض به سلول‌های کتاب کاری نمودار استفاده کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض و پشتیبانی شده توسط سلول‌ها ایجاد می‌کند و اندیس قالب 10 (`0.00%`) را به هر سلول مقدار سری اعمال می‌نماید. این کار نحوه نمایش مقادیر در کتاب کاری را بدون تغییر اعداد پایه تغییر می‌دهد؛ به‌عنوان مثال، 0.25 به‌صورت 25.00% نمایش داده می‌شود. قالب‌های محور و برچسب‌های داده می‌توانند به‌ طور جداگانه پیکربندی شوند.

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

جدول زیر ایندکس‌های قالب عددی پیش‌ساخته را همراه با قالب‌های نمونهٔ Excel برای محل‌گذاری انگلیسی (ایالات متحده) فهرست می‌کند. رشته‌های قالب دقیق و نمایش آنها می‌تواند بسته به برنامه و محل‌گذاری متفاوت باشد، به‌ویژه برای ارز و تاریخ‌ها. برخی قالب‌های Excel نیز با پیش‌فرض‌های استاندارد OOXML متفاوت هستند، همان‌طور که در [یادداشت‌های پیاده‌سازی قالب عددی مایکروسافت](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) توضیح داده شده است.

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

## **تنظیم مرزهای گرد ناحیه نمودار**

با فعال‌سازی [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) گوشه‌های ناحیه نمودار را گرد کنید. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و از [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) برای دادن یک رنگ خاکستری یکدست و سبک خط تک‌خطی به کادر آن استفاده می‌کند قبل از ذخیرهٔ ارائه.

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

یک نمودار می‌تواند شامل اشکال سفارشی باشد، مانند یک حاشیه‌نویسی متنی که وضعیت یک گزارش را توضیح می‌دهد. به این اشکال از طریق [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/) دسترسی پیدا کنید. مجموعهٔ [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) آن شامل اشکال متعلق به نمودار است. یک جعبه متن عادی که بر روی نمودار قرار می‌گیرد، متعلق به اسلاید است، حتی اگر شبیه بخشی از نمودار به نظر برسد. پیمایش از طریق [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) نمودار و اشکال عادی اسلاید را می‌یابد، اما اشکال فردی داخل نمودار را فهرست نمی‌کند. عناوین نمودار و برچسب‌های داده عناصر جداگانه‌ای از نمودار هستند و نه حاشیه‌نویسی‌های سفارشی در این مجموعه. فایل [chart-annotations.pptx](chart-annotations.pptx) را دانلود کنید و در دایرکتوری کاری برنامه قرار دهید. اسلاید اول آن شامل یک نمودار با یک حاشیه‌نویسی گروه‌بندی‌نشده با متن «نتایج اولیه»، یک خط متعلق به نمودار و یک جعبه متن عادی اسلاید با متن «پوشش اسلاید» است. این مثال اولین نمودار را در آن اسلاید پیدا می‌کند و حاشیه‌نویسی را به «نتایج نهایی» تغییر می‌دهد هنگامی که گزارش آماده انتشار باشد. این مثال برای مجموعهٔ خالی بررسی می‌کند و فقط یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) را که دارای [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) غیر `None` و شامل متن مورد انتظار است، ویرایش می‌کند.

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

خط و جعبه متن اسلاید بدون تغییر باقی می‌مانند. تصاویر زیر ورودی و نتیجهٔ ذخیره‌شده و بازگشایی‌شده را نشان می‌دهند:

| قبل از ویرایش | بعد از ویرایش |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
این مثال فقط اشکال سطح بالای متعلق به نمودار را بررسی می‌کند. اگر یک حاشیه‌نویسی داخل یک [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) باشد، مجموعهٔ [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) آن گروه را نیز بررسی کنید. این کار را به‌صورت بازگشتی برای گروه‌های تو در تو تکرار کنید و بررسی‌های متنی یکسان را بر روی اشکال فرزندشان اعمال کنید. یک گروه خود یک مخزن است؛ آن را به‌عنوان جعبهٔ متن در نظر نگیرید.
{{% /alert %}}

## **سؤالات متداول**

**آیا می‌توان پرکن‌های نیمه‌شفاف برای ستون‌ها/ناحیه‌ها تنظیم کرد در حالی که حاشیه‌ها مات باقی می‌مانند؟**

بله. شفافیت پرکن و خط دور به‌صورت جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در تجسم‌های پرحجم مفید است.

**چگونه می‌توانم با برچسب‌های داده که همپوشانی دارند مقابله کنم؟**

اندازه قلم را کاهش دهید، مؤلفه‌های غیرضروری برچسب (برای مثال، دسته‌ها) را غیرفعال کنید، موقعیت برچسب را تنظیم کنید، در صورت نیاز فقط برای نقاط انتخاب شده برچسب‌ها را نمایش دهید، یا قالب را به «مقدار + افسانه» تغییر دهید.

**آیا می‌توان پرکن‌های گرادیان یا الگو را به سری‌ها اعمال کرد؟**

بله. سری‌ها از پرکن‌های جامد، گرادیانی و الگو پشتیبانی می‌کنند. در عمل، از گرادیان‌ها به‌طور محدود استفاده کنید و از ترکیب‌هایی که کنتراست با شبکه و متن را کاهش می‌دهند، پرهیز کنید.