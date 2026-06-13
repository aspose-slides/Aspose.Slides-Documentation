---
title: قالب‌سازی نمودارها در ارائه‌ها با استفاده از Python
linktitle: قالب‌بندی نمودار
type: docs
weight: 60
url: /fa/python-net/chart-formatting/
keywords:
- قالب‌سازی نمودار
- قالب‌بندی نمودار
- موجودیت نمودار
- ویژگی‌های نمودار
- تنظیمات نمودار
- گزینه‌های نمودار
- ویژگی‌های قلم
- حاشیه گرد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "قالب‌بندی نمودارها را در Aspose.Slides برای Python از طریق .NET بیاموزید و ارائهٔ PowerPoint یا OpenDocument خود را با استایل‌های حرفه‌ای و چشم‌نواز ارتقا دهید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides قالب‌بندی کنیم. این مقاله نشان می‌دهد چگونه عناصر کلیدی نمودار مانند محورها، خطوط شبکه، عناوین، راهنما، ناحیه طرح، و پرکردن دیوارها را سفارشی کنیم تا ظاهر و قابلیت خواندن داده‌های نمودار بهبود یابد.

همچنین نشان می‌دهد چگونه ویژگی‌های قلم را برای متن نمودار تنظیم کنیم، قالب‌های عددی پیش‌تنظیم‌شده و سفارشی را برای داده‌های نمودار اعمال کنیم، و گوشه‌های گرد برای ناحیه نمودار فعال کنیم. این مثال‌ها نحوه کنترل هم سبک بصری و هم ارائه داده‌های نمودارها در یک ارائه را نشان می‌دهند.

## **قالب‌بندی عناصر نمودار**

Aspose.Slides for Python به توسعه‌دهندگان اجازه می‌دهد تا نمودارهای سفارشی را از ابتدا به اسلایدهای خود اضافه کنند. این بخش توضیح می‌دهد چگونه عناصر مختلف نمودار، از جمله محورهای دسته‌بندی و مقدار، قالب‌بندی شوند.

Aspose.Slides یک API ساده برای مدیریت عناصر نمودار و اعمال قالب‌بندی سفارشی فراهم می‌کند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک نمودار با داده‌های پیش‌فرض از نوع مورد نظر اضافه کنید (در این مثال، `ChartType.LINE_WITH_MARKERS`).
1. به محور مقدار نمودار دسترسی پیدا کنید و موارد زیر را تنظیم کنید:
   1. **فرمت خط** برای خطوط شبکه اصلی محور مقدار تنظیم کنید.
   1. **فرمت خط** برای خطوط شبکه فرعی محور مقدار تنظیم کنید.
   1. **قالب عددی** برای محور مقدار تنظیم کنید.
   1. **حداقل، حداکثر، واحدهای اصلی و فرعی** برای محور مقدار تنظیم کنید.
   1. **ویژگی‌های متن** برای برچسب‌های محور مقدار تنظیم کنید.
   1. **عنوان** برای محور مقدار تنظیم کنید.
   1. **فرمت خط** برای محور مقدار تنظیم کنید.
1. به محور دسته‌بندی نمودار دسترسی پیدا کنید و موارد زیر را تنظیم کنید:
   1. **فرمت خط** برای خطوط شبکه اصلی محور دسته‌بندی تنظیم کنید.
   1. **فرمت خط** برای خطوط شبکه فرعی محور دسته‌بندی تنظیم کنید.
   1. **ویژگی‌های متن** برای برچسب‌های محور دسته‌بندی تنظیم کنید.
   1. **عنوان** برای محور دسته‌بندی تنظیم کنید.
   1. **موقعیت‌گذاری برچسب** برای محور دسته‌بندی تنظیم کنید.
   1. **زاویه چرخش** برای برچسب‌های محور دسته‌بندی تنظیم کنید.
1. به راهنمای نمودار دسترسی پیدا کنید و **ویژگی‌های متن** آن را تنظیم کنید.
1. راهنمای نمودار را بدون هم‌پوشانی با نمودار نمایش دهید.
1. به **محور مقدار ثانویه** نمودار دسترسی پیدا کنید و موارد زیر را تنظیم کنید:
   1. **محور مقدار ثانویه** را فعال کنید.
   1. **فرمت خط** برای محور مقدار ثانویه تنظیم کنید.
   1. **قالب عددی** برای محور مقدار ثانویه تنظیم کنید.
   1. **حداقل، حداکثر، واحدهای اصلی و فرعی** برای محور مقدار ثانویه تنظیم کنید.
1. سری اول نمودار را بر روی محور مقدار ثانویه رسم کنید.
1. رنگ پرکردن دیوار پشت نمودار را تنظیم کنید.
1. رنگ پرکردن ناحیه طرح نمودار را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را در یک فایل PPTX بنویسید.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

    # ایجاد نمونه‌ای از کلاس Presentation.
    with slides.Presentation() as presentation:

        # دسترسی به اولین اسلاید.
        slide = presentation.slides[0]

        # اضافه کردن یک نمودار نمونه.
        chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

        # تنظیم عنوان نمودار.
        chart.has_title = True
        chart.chart_title.add_text_frame_for_overriding("")
        chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
        chart_title.text = "Sample Chart"
        chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
        chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
        chart_title.portion_format.font_height = 20
        chart_title.portion_format.font_bold = 1
        chart_title.portion_format.font_italic = 1

        # تنظیم قالب خطوط شبکه اصلی برای محور مقدار.
        chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
        chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
        chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
        chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

        # تنظیم قالب خطوط شبکه فرعی برای محور مقدار.
        chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
        chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
        chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

        # تنظیم قالب عددی محور مقدار.
        chart.axes.vertical_axis.is_number_format_linked_to_source = False
        chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
        chart.axes.vertical_axis.number_format = "0.0%"

        # تنظیم حداکثر، حداقل، واحد اصلی و واحد فرعی محور مقدار.
        chart.axes.vertical_axis.is_automatic_major_unit = False
        chart.axes.vertical_axis.is_automatic_max_value = False
        chart.axes.vertical_axis.is_automatic_minor_unit = False
        chart.axes.vertical_axis.is_automatic_min_value = False

        chart.axes.vertical_axis.max_value = 15
        chart.axes.vertical_axis.min_value = -2
        chart.axes.vertical_axis.minor_unit = 0.5
        chart.axes.vertical_axis.major_unit = 2.0

        # تنظیم ویژگی‌های متن محور مقدار.
        vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
        vertical_axis_portion_format.font_bold = 1
        vertical_axis_portion_format.font_height = 16
        vertical_axis_portion_format.font_italic = 1
        vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
        vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
        vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

        # تنظیم عنوان محور مقدار.
        chart.axes.vertical_axis.has_title = True
        chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
        vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
        vertical_axis_title.text = "Primary Axis"
        vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
        vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
        vertical_axis_title.portion_format.font_height = 20
        vertical_axis_title.portion_format.font_bold = 1
        vertical_axis_title.portion_format.font_italic = 1

        # تنظیم قالب خطوط شبکه اصلی برای محور دسته‌بندی.
        chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
        chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
        chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

        # تنظیم قالب خطوط شبکه فرعی برای محور دسته‌بندی.
        chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
        chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
        chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

        # تنظیم ویژگی‌های متن محور دسته‌بندی.
        horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
        horizontal_axis_portion_format.font_bold = 1
        horizontal_axis_portion_format.font_height = 16
        horizontal_axis_portion_format.font_italic = 1
        horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
        horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
        horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

        # تنظیم عنوان محور دسته‌بندی.
        chart.axes.horizontal_axis.has_title = True
        chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

        horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
        horizontal_axis_title.text = "Sample Category"
        horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
        horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
        horizontal_axis_title.portion_format.font_height = 20
        horizontal_axis_title.portion_format.font_bold = 1
        horizontal_axis_title.portion_format.font_italic = 1

        # تنظیم موقعیت برچسب محور دسته‌بندی.
        chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

        # تنظیم زاویه چرخش برچسب محور دسته‌بندی.
        chart.axes.horizontal_axis.tick_label_rotation_angle = 45

        # تنظیم ویژگی‌های متن راهنمای نمودار.
        legend_portion_format = chart.legend.text_format.portion_format
        legend_portion_format.font_bold = 1
        legend_portion_format.font_height = 16
        legend_portion_format.font_italic = 1
        legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
        legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

        # نمایش راهنمای نمودار به‌صورت همپوشانی با نمودار.
        chart.legend.overlay = True
                
        # تنظیم رنگ دیوار پشت نمودار.
        chart.back_wall.thickness = 1
        chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
        chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

        chart.floor.format.fill.fill_type = slides.FillType.SOLID
        chart.floor.format.fill.solid_fill_color.color = draw.Color.red

        # تنظیم رنگ ناحیه طرح.
        chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
        chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

        # ذخیره ارائه.
        presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم ویژگی‌های قلم نمودار**

Aspose.Slides for Python از تنظیم ویژگی‌های مربوط به قلم برای نمودارها پشتیبانی می‌کند. برای پیکربندی ویژگی‌های قلم نمودار، مراحل زیر را دنبال کنید:

1. یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک نمودار به اسلاید اضافه کنید.
1. ارتفاع قلم را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

یک کد نمونه در ادامه ارائه شده است.

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

## **تنظیم قالب عددی**

Aspose.Slides for Python یک API ساده برای مدیریت قالب‌های دادهٔ نمودار فراهم می‌کند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک نمودار با داده‌های پیش‌فرض از هر نوع دلخواه اضافه کنید.
1. یک قالب عددی پیش‌تنظیم‌شده از مقادیر پیش‌تنظیم موجود تنظیم کنید.
1. سلول‌های دادهٔ نمودار در هر سری را مرور کنید و قالب عددی را تنظیم کنید.
1. ارائه را ذخیره کنید.
1. یک قالب عددی سفارشی تنظیم کنید.
1. سلول‌های دادهٔ نمودار در هر سری را مرور کنید و قالب عددی متفاوتی تنظیم کنید.
1. ارائه را ذخیره کنید.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# ایجاد نمونه‌ای از کلاس Presentation.
with slides.Presentation() as presentation:
    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # اضافه کردن یک نمودار ستونی خوشه‌ای پیش‌فرض.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # تنظیم قالب عددی پیش‌تنظیم‌شده.
    # مرور هر سری نمودار.
    for series in chart.chart_data.series:
        # مرور هر نقطه داده در سری.
        for cell in series.data_points:
            # تنظیم قالب عددی.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # ذخیره ارائه.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

قالب‌های عددی پیش‌تنظیم‌شدهٔ موجود و اندیس‌های متناظر آن‌ها در زیر فهرست شده‌اند.

|**0**|عمومی|
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

## **تنظیم حاشیه‌های گرد برای ناحیه نمودار**

Aspose.Slides for Python از پیکربندی ناحیه نمودار با استفاده از ویژگی `Chart.has_rounded_corners` پشتیبانی می‌کند.

1. یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. یک نمودار به اسلاید اضافه کنید.
3. نوع پر شدن و رنگ پر شدن نمودار را تنظیم کنید.
4. ویژگی گوشه‌های‌گرد را به `True` تنظیم کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

یک نمونه در ادامه ارائه شده است.

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

## **پرسش‌های متداول**

**آیا می‌توانم پرشدن نیمه‌شفاف برای ستون‌ها/ناحیه‌ها تنظیم کنم در حالی که حاشیه را مات نگه دارم؟**

بله. شفافیت پرشده و خط خارجی به طور جداگانه پیکربندی می‌شوند. این کار برای بهبود خوانایی شبکه و داده‌ها در نمایش‌های پراکندگی زیاد مفید است.

**چگونه می‌توانم با برچسب‌های داده هنگام هم‌پوشانی آن‌ها برخورد کنم؟**

اندازه قلم را کاهش دهید، اجزای غیرضروری برچسب‌ها (مانند دسته‌ها) را غیرفعال کنید، جابجایی/موقعیت برچسب را تنظیم کنید، در صورت لزوم فقط برچسب‌های نقاط انتخابی را نشان دهید، یا قالب را به «مقدار + راهنما» تغییر دهید.

**آیا می‌توانم پرکردن گرادیان یا الگو را به سری‌ها اعمال کنم؟**

بله. هر دو نوع پرشدن یکدست و گرادیان/الگو معمولاً موجود هستند. در عمل، از گرادیان‌ها به‌طور محدود استفاده کنید و از ترکیباتی که کنتراست با شبکه و متن را کاهش می‌دهند، جلوگیری کنید.