---
title: سفارشی‌سازی محورها در نمودارها در ارائه‌ها با پایتون
linktitle: محور نمودار
type: docs
url: /fa/python-net/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دست‌کاری محور
- مدیریت محور
- ویژگی‌های محور
- حداکثر مقدار
- حداقل مقدار
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید از Aspose.Slides برای پایتون از طریق .NET برای سفارشی‌سازی محورها در نمودارها در ارائه‌های PowerPoint و OpenDocument برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **نمای کلی**

این مقاله نحوهٔ سفارشی‌سازی محورها در نمودارها را با Aspose.Slides برای Python در .NET توضیح می‌دهد. مواردی چون مقادیر محاسبه‌شدهٔ محور، تعویض ردیف‌ها و ستون‌های نمودار، قابلیت مشاهدهٔ محور، فواصل برچسب‌های دسته و علامت‌گذاری‌های تیک، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت محور، واحدهای نمایش و مقیاس لگاریتمی را شامل می‌شود.

## **دریافت حداکثر مقادیر در محور عمودی نمودارها**

یک [ارائه](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید و نمودار مساحتی با داده‌های پیش‌فرض اضافه کنید. پیش از خواندن مقادیر محاسبه‌شدهٔ محور، [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) را فراخوانی کنید تا طرح‌بندی نمودار به‌روز باشد.

[actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) و [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) را برای حدهای محور بخوانید و برای فواصل علامت‌گذاری‌ها، [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) و [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) را بررسی کنید. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) و [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) مقیاس‌های واحد زمان را ارائه می‌دهند که برای محورهای تاریخ مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره می‌کند و نمودار را ذخیره می‌نماید.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعویض داده‌ها بین محورها**

از [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دستهٔ قبلی به یک سری تبدیل می‌شود و هر سری قبلی به دسته. این تغییر نحوهٔ گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورهای افقی و عمودی را جابجا نمی‌کند. مثال از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) برای بستن داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل ردیف سرصفحه و ستون دسته، پیش از تعویض ردیف‌ها و ستون‌ها استفاده می‌کند. سپس نموداری با چهار سری و سه دسته ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **غیرفعال‌سازی محور عمودی برای نمودارهای خطی**

[is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) را برای محور عمودی به `False` تنظیم کنید تا مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌نماید.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **غیرفعال‌سازی محور افقی برای نمودارهای خطی**

[is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) را برای محور افقی به `False` تنظیم کنید تا مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌نماید.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **تغییر محور دسته‌ای**

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) را برای انتخاب محور دسته‌ای تاریخ یا متن تنظیم کنید. این مثال نیاز به `ExistingChart.pptx` دارد که در اسلاید اول اولین شکل آن یک نمودار است و سلول‌های دسته شامل مقادیر عددی تاریخ اکسل می‌باشند. محور افقی را به محور تاریخی تغییر می‌دهد. با تنظیم [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) به `False`، [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) به `1` و [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) به ماه‌ها، علامت‌های بزرگ هر ماه یکبار قرار می‌گیرند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کنترل فواصل برچسب محور دسته‌ای**

هنگامی که نمودار دارای تعداد زیادی دسته باشد، می‌توانید تعداد برچسب‌های محور قابل مشاهده را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) را به `False` تنظیم کنید، سپس [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) را به فاصلۀ دلخواه دسته تنظیم کنید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته شروع می‌شود:

| فاصله | برچسب‌های نمایش داده شده در مثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

فاصلهٔ `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب بین برچسب‌های نمایش داده‌شده مخفی می‌مانند. این کار ستون‌های متناظر را حذف نمی‌کند. فاصلهٔ خودکار بر پایهٔ فضای موجود یک مقدار انتخاب می‌کند؛ لزوماً همهٔ برچسب‌ها را نشان نمی‌دهد.

علامت‌گذاری‌ها کنترل‌های جداگانه‌ای دارند. [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) را به `False` تنظیم کنید و با [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) فواصل آن‌ها را تعیین کنید. به عنوان مثال، `1` یک علامت‌گذاری در هر فاصلهٔ دسته نگه می‌دارد در حالی که برچسب‌ها فقط هر سومین دسته ظاهر می‌شوند. [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) را به سبک قابل رؤیت تنظیم کنید تا نتیجه را ببینید. بازگرداندن هر یک از ویژگی‌های فاصلهٔ خودکار به `True` اجازه می‌دهد نمودار دوباره همان فاصله را انتخاب کند.

مثال خودکفا زیر ۲۴ دسته و یک سری ایجاد می‌کند و سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصلهٔ خودکار، فاصلهٔ برچسب دستی با علامت‌گذاری‌های مستقل، و بازگرداندن فاصلهٔ خودکار. دو نسخهٔ کپی داده‌های اصلی نمودار را حفظ می‌کنند. هیچ ارائهٔ ورودی لازم نیست. متن برچسب افقی تفاوت چگالی را به‌وضوح نشان می‌دهد.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # اسلاید 2: هر برچسب سوم را نمایش دهید، اما برای هر دسته یک علامت تیک نگه دارید.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # اسلاید 3: بگذارید نمودار دوباره هردو فاصله را انتخاب کند.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**فاصلهٔ خودکار (اسلاید 1):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجهٔ خودکار ممکن است با اندازهٔ نمودار، قلم‌ها و رندرر متفاوت باشد.

![فاصلهٔ خودکار برچسب‌های دسته با تمام ۲۴ ستون قابل مشاهده](category-axis-automatic.png)

**فاصلهٔ دستی (اسلاید 2):** هر سومین برچسب روی یک خط نمایش داده می‌شود، در حالی که علامت‌گذاری‌ها در هر فاصلهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، از جمله ستون‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده هستند. اسلاید 3 ظاهر خودکار را که در بالا نشان داده شد بازمی‌گرداند.

![فاصلهٔ دستی برچسب‌های دسته به اندازهٔ سه با تمام ۲۴ ستون قابل مشاهده](category-axis-manual.png)

### **انتخاب محور و فاصلهٔ صحیح**

از این فاصلهٔ شمارش دسته برای محور دسته‌ای متنی استفاده کنید، همانند محور دسته‌ای یک نمودار ستونی، خطی، مساحتی یا میله‌ای. در نمودار ستونی، این محور افقی است. در نمودار میله‌ای افقی، محور دسته‌ای عمودی است، بنابراین این تنظیمات را برای [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) اعمال کنید. فاصلهٔ علامت‌گذاری‌ها همچنین برای محور سری در نمودارهایی که دارند، کاربرد دارد.

از فاصلهٔ برچسب دسته برای تنظیم مقیاس عددی محور مقدار استفاده نکنید. در یک محور مقدار، [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) اختلاف مقادیر را مشخص می‌کند: برای مثال، واحد اصلی `10` علامت‌ها را در ۰، ۱۰، ۲۰ و … تولید می‌کند زمانی که محور از صفر شروع شود. فاصلهٔ برچسب دستهٔ `3` به جای مقادیر عددی، موقعیت‌های دسته را می‌شمارد. نمودارهای پراکنش و حباب از محورهای مقدار نه از محور متن دسته‌ای استفاده می‌کنند. برای محور تاریخ، از واحدهای زمان اصلی و مقیاس‌های توضیح داده‌شده در [تغییر محور دسته‌ای](#change-a-category-axis) استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌ای**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌صورت شماره‌های سریال OLE Automation در اولین برگه (اندیس `0`) ذخیره می‌شوند. [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) را به محور تاریخی تنظیم کنید، [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) را غیرفعال کنید و `yyyy` را به [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) اختصاص دهید تا برچسب‌های دسته سال‌های چهاررقمی را مستقل از قالب‌بندی سلول نشان دهند.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم زاویهٔ چرخش برای عنوان محور نمودار**

روی محور عمودی، [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) را فعال کنید، متن عنوان را بدهید و با [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) زاویهٔ چرخش را تنظیم کنید. این زاویه بر حسب درجه اندازه‌گیری می‌شود؛ مثال یک نمودار ستونی را با عنوان محور مقدار که به‌صورت ۹۰ درجه چرخیده است ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم موقعیت محور بر روی محور دسته‌ای یا مقدار**

از [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) برای کنترل این که آیا محور مقدار بین دسته‌ها یا در علامت‌گذاری‌های دسته عبور کند استفاده کنید. این ویژگی به محورهاى دسته‌ای اعمال می‌شود. مثال این ویژگی را روی محور دسته‌ای افقی یک نمودار ستونی به `True` تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم واحد نمایش بر روی محور مقدار نمودار**

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) را تنظیم کنید تا برچسب‌های محور مقدار بدون تغییر داده‌های پایه مقیاس‌بندی شوند. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) به `MILLIONS`، مقدار 60 000 000 به صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر محور عمودی آن اعمال می‌نماید.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **پیکربندی محور مقدار لگاریتمی**

محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت از چندین مرتبهٔ قدر مختلف باشند. برای مثال، سرویسی ممکن است در پنج دوره درخواست‌های ۱۰، ۱۰۰، ۱ ۰۰۰، ۱۰ 000 و ۱۰۰ 000 دریافت کند. در مقیاس خطی، مقادیر کوچک نزدیک به صفر به‌هم می‌چسبند. مقیاس لگاریتمی رشد نسبی آن‌ها را راحت‌تر مقایسه می‌کند: فاصله‌های برابر نمایانگر نسبت‌های برابر نه اختلاف‌های عددی برابر هستند.

[is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) را بر محور مقدار به `True` تنظیم کنید و با [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) پایهٔ موردنظر را انتخاب کنید. این کار نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند رابطهٔ برازش‌شده‌ای در داده‌هاست و ویژگی جداگانه‌ای است.

### **انتخاب محور مقدار و پایه**

برای نمودارهای خطی یا ستونی، محور مقدار [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) است. برای نمودار میله‌ای افقی، این محور [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) است. نمودارهای پراکنش و حباب دو محور مقدار دارند؛ بنابراین می‌توانید محور افقی را برای مقادیر X، محور عمودی را برای مقادیر Y یا هر دو انتخاب کنید. از اعمال مقیاس لگاریتمی بر محور دسته‌ای خودداری کنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX می‌توانید پایه‌ای بین `2` تا `1000`، به‌همراه پایه‌های کسری مانند `2.5`، استفاده کنید. با پایهٔ `10` توان‌های متوالی مانند 10، 100، 1 000 و 10 000 به‌صورت مساوی فاصله‌دار هستند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال خودکفا زیر یک نمودار خطی با پنج تعداد درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی می‌کند و در اسلاید دوم محور مقدار لگاریتمی پایه‑۱۰ را فعال می‌کند. هر دو اسلاید همان داده را حفظ می‌کنند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # اسلاید اول را به‌صورت خطی نگه دارید و فقط مقیاس محور مقدار کپی را تغییر دهید.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**مقیاس خطی (اسلاید 1):** فواصل عمودی برابر نشان‌دهندهٔ اختلافات برابر در تعداد درخواست‌ها هستند. بزرگ‌ترین مقدار بر نمودار حاکم می‌شود و مقادیر کوچکتر را تشخیص سخت می‌شود.

![نمودار خطی در پاورپوینت که پنج تعداد درخواست را بر محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید 2):** فواصل عمودی برابر نشان‌دهندهٔ نسبت‌های برابر هستند. هر دوره ده برابر درخواست دوره قبل دارد، بنابراین نقاط بر مقیاس پایه‑۱۰ یک خط صعودی مستقیم می‌سازند. برچسب‌های محور همچنان شمارش اصلی درخواست‌ها را نشان می‌دهند.

![پنج تعداد درخواست یکسان در پاورپوینت بر محور مقدار لگاریتمی پایه‑۱۰](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

مقیاس لگاریتمی فقط مقادیر مثبت مطلق را نشان می‌دهد. پیش از فعال‌سازی آن داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنا دارند، یا مقیاس خطی را نگه دارید یا آن‌ها را جداگانه نمایش دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌صورت ساکن با اعداد مثبت کوچک جایگزین آن‌ها نشوید، زیرا معنای داده را تغییر می‌دهد. هر حداقل یا حداکثر به‌صورت دستی تنظیم‌شده برای محور لگاریتمی نیز باید مثبت باشد.

## **سؤالات متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر (crossing) را تنظیم کنم؟**

از [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) برای انتخاب رفتار تقاطع استفاده کنید. برای تعیین مقدار عددی تقاطع، [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) را تنظیم کنید. این تنظیمات به شما امکان می‌دهند تقاطع محور را به یک خط مرجع مناسب منتقل کنید.

**چگونه می‌توانم موقعیت برچسب‌های تیک را نسبت به محور تنظیم کنم؟**

[tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) را با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) تنظیم کنید: `LOW`، `HIGH`، `NEXT_TO` یا `NONE`. برای کنترل خود علامت‌های تیک، از [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) یا [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) استفاده کنید؛ این‌ها جدا از موقعیت برچسب‌ها هستند.