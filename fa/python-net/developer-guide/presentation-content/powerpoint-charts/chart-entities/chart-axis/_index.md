---
title: سفارشی‌سازی محورها در نمودارهای ارائه‌ها با پایتون
linktitle: محور نمودار
type: docs
url: /fa/python-net/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دستکاری محور
- مدیریت محور
- ویژگی‌های محور
- مقدار بیشینه
- مقدار کمینه
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "کشف کنید چگونه از Aspose.Slides برای پایتون از طریق .NET برای سفارشی‌سازی محورها در نمودارهای PowerPoint و OpenDocument برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان محورهای نمودار را در Aspose.Slides for Python via .NET سفارشی کرد. موضوعات شامل مقادیر محاسبه‌شده محور، جابه‌جایی ردیف‌ها و ستون‌های نمودار، نمایش یا مخفی‌سازی محور، فواصل برچسب‌های دسته و علامت‌گذاری‌ها، دسته‌های تاریخی و قالب‌بندی آن‌ها، چرخش عنوان، موقعیت‌یابی محور، واحدهای نمایش، و مقیاس لگاریتمی می‌شود.

## **دریافت مقادیر بیشینه در محور عمودی نمودارها**

یک [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، برای به‌روز شدن چیدمان نمودار، [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) را فراخوانی کنید.

برای محدودیت‌های محور، [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) و [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) را بخوانید و برای فواصل علامت‌گذاری‌ها، [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) و [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) را استفاده کنید. مقادیر [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) و [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) مقیاس‌های زمان‑واحد را ارائه می‌دهند که برای محورهای تاریخی مهم هستند. مثال این مقادیر را در متغیرهای محلی ذخیره می‌کند و نمودار را ذخیره می‌کند.

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

## **جابه‌جایی داده‌ها بین محورها**

از [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی به یک سری تبدیل می‌شود و هر سری قبلی به یک دسته. این کار فقط گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورهای افقی و عمودی را جابجا نمی‌کند. در مثال، برای بایند کردن داده‌های پیش‌فرض به `Sheet1!A1:D5` (شامل ردیف سرعنوان و ستون دسته) قبل از جابجایی ردیف‌ها و ستون‌ها، از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) استفاده می‌شود. سپس یک نمودار با چهار سری و سه دسته ذخیره می‌کند.

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

## **معکوس کردن ترتیب رسم محور**

از [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) برای معکوس کردن یک محور دسته یا مقدار استفاده کنید. به عنوان مثال، یک نمودار میله‌ای افقی می‌تواند مراحل پروژه را از بالا به پایین به همان ترتیب برگه کاری نشان دهد: برنامه‌ریزی، توسعه، آزمون. معکوس کردن محور جهت رسم را تغییر می‌دهد؛ داده‌های برگه کاری را مرتب یا جابه‌جا نمی‌کند. برای مقایسه، [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) نقش سری‌ها و دسته‌ها را تعویض می‌کند.

مثال زیر یک نمودار میله‌ای افقی با سه مرحله و یک سری ایجاد می‌کند. یک ارائه شامل سه اسلاید ذخیره می‌شود: ترتیب عادی، دسته‌ها معکوس، و مقادیر معکوس. هر نسخه از همان مجموعه داده استفاده می‌کند و تنها یک محور در هر نسخه معکوس می‌شود.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # اسلاید ۲: نمایش اولین دسته در بالا.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # محور مقدار افقی را در پایین نگه دارید.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # اسلاید ۳: فقط مقیاس عددی افقی را معکوس کنید.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

معکوس کردن محور می‌تواند محور عمودی را به سمت مخالف نمودار منتقل کند. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) تعیین می‌کند که محور دیگر در کجا با محور تنظیم‌شده تقاطع داشته باشد. در اسلاید ۲، تنظیم آن روی `MAXIMUM` برای محور دسته معکوس، محور مقدار افقی را در پایین نگه می‌دارد. برای یک نقطه تقاطع خاص، از [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) استفاده کنید. هنگام تغییر جهت، تنظیمات تقاطع را بررسی کنید، به‌ویژه اگر نمودار نقطه تقاطع سفارشی دارد. برای بازگرداندن جهت رسم عادی، `is_plot_order_reversed` را به `False` تنظیم کنید؛ تنظیمات تقاطع مستقل هستند.

| ترتیب عادی (اسلاید ۱) | دسته‌ها معکوس (اسلاید ۲) | مقادیر معکوس (اسلاید ۳) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| دسته‌ها از پایین به بالا حرکت می‌کنند؛ مقادیر از چپ به راست افزایش می‌یابند. | برنامه‌ریزی، توسعه و آزمون از بالا به پایین حرکت می‌کنند. مقادیر و ترتیب ردیف‌های کتاب کار بدون تغییر باقی می‌مانند. | دسته‌ها ترتیب عادی خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته در صفر سمت راست تقاطع می‌شود. |

## **مخفی‌سازی محور عمودی برای نمودارهای خطی**

بر محور عمودی، [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) را برابر `False` قرار دهید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **مخفی‌سازی محور افقی برای نمودارهای خطی**

بر محور افقی، [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) را برابر `False` قرار دهید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **تغییر محور دسته**

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) را تنظیم کنید تا یک محور تاریخی یا متنی انتخاب شود. این مثال به فایل `ExistingChart.pptx` نیاز دارد که در اسلاید اول اولین شکل، یک نمودار دارد و سلول‌های دسته شامل مقادیر عددی تاریخ اکسل هستند. محور افقی به یک محور تاریخی تبدیل می‌شود. با تنظیم [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) برابر `False`، [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) برابر `1` و [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) برابر ماه، علامت‌گذاری‌های اصلی هر یک ماه قرار می‌گیرد.

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

## **کنترل فواصل برچسب‌های محور دسته**

وقتی یک نمودار شامل تعداد زیادی دسته باشد، می‌توانید تعداد برچسب‌های محور قابل مشاهده را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) را به `False` تنظیم کنید، سپس [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) را به فواصل موردنظر تنظیم کنید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته شروع می‌شود:

| فواصل | برچسب‌های نمایش‌داده‌شده در مثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

فاصله `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب بین آن‌ها مخفی می‌ماند؛ این کار ستون‌های متناظر را حذف نمی‌کند. فاصله‌گذاری خودکار بر اساس فضای موجود یک فواصل انتخاب می‌کند و لزوماً تمام برچسب‌ها را نشان نمی‌دهد.

علامت‌گذاری‌ها کنترل جداگانه‌ای دارند. [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) را به `False` تنظیم کنید و با استفاده از [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) فواصل آن‌ها را تنظیم کنید. به عنوان مثال، `1` باعث می‌شود علامت‌گذاری در هر فاصلۀ دسته باقی بماند در حالی که برچسب‌ها هر سومین دسته نشان داده می‌شوند. برای مشاهده نتیجه، [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) را به یک سبک قابل رؤیت تنظیم کنید. بازگرداندن هر یک از ویژگی‌های فاصله‌گذاری خودکار به `True` اجازه می‌دهد نمودار دوباره آن فواصل را انتخاب کند.

مثال مستقل زیر ۲۴ دسته و یک سری ایجاد می‌کند و سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصله‌گذاری خودکار، فاصله‌گذاری دستی برچسب‌ها با علامت‌گذاری‌های مستقل، و بازگشت به فاصله‌گذاری خودکار. دو نسخه داده‌های اولیه نمودار را حفظ می‌کنند و نیازی به ارائه ورودی نیست. متن برچسب افقی تفاوت چگالی را deutlich نشان می‌دهد.

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

    # اسلاید ۲: هر سومین برچسب را نشان دهید، اما برای هر دسته یک علامت تیک نگه دارید.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # اسلاید ۳: اجازه دهید نمودار دوباره هر دو فاصلۀ برچسب و علامت‌گذاری را انتخاب کند.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**فاصله‌گذاری خودکار (اسلاید ۱):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجه خودکار ممکن است بسته به اندازه نمودار، قلم‌ها و رندر متفاوت باشد.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**فاصله‌گذاری دستی (اسلاید ۲):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که علامت‌گذاری‌ها در هر فاصلۀ دسته باقی می‌مانند. تمام ۲۴ ستون، حتی آن‌هایی که برچسب ندارند، با مقادیر یکسان قابل مشاهده‌اند. اسلاید ۳ ظاهر خودکار نشان داده‌شده در بالا را باز می‌گرداند.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **انتخاب محور و فاصلۀ صحیح**

از این فاصلۀ شمارش‑دسته برای یک محور دسته متنی، مانند محور دستهٔ یک نمودار ستونی، خطی، ناحیه‌ای یا میله‌ای استفاده کنید. در نمودار ستونی، این محور افقی است. در نمودار میلهی افقی، محور دسته عمودی است، بنابراین این تنظیمات را به [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) اعمال کنید. فاصله‌گذاری علامت‌گذاری‌ها نیز برای محور سری در نمودارهایی که دارای آن هستند، اعمال می‌شود.

از فاصله‌گذاری برچسب دسته برای تنظیم مقیاس عددی محور مقدار استفاده نکنید. در یک محور مقدار، [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) اختلاف مقدار را مشخص می‌کند: به عنوان مثال، یک واحد اصلی `10` علامت‌ها را در ۰، ۱۰، ۲۰ و ... تولید می‌کند وقتی محور از صفر شروع شود. یک فاصلۀ برچسب دسته `3` به جای مقادیر عددی، موقعیت‌های دسته را می‌شمارد. نمودارهای پراکندگی و حبابی از محورهای مقدار استفاده می‌کنند نه از محور دسته متنی. برای محور تاریخی، از واحدهای اصلی مبتنی بر زمان و مقیاس‌ها همان‌طور که در [تغییر محور دسته](#change-a-category-axis) توضیح داده شده است، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌صورت شماره‌های سریال OLE Automation در اولین کاربرگ (شاخص `0`) ذخیره می‌شوند. [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) را به محور تاریخی تنظیم کنید، [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) را غیرفعال کنید و `yyyy` را به [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) اختصاص دهید تا برچسب‌های دسته سال‌های چهار رقمی را مستقل از قالب‌گذاری سلول‌ها نمایش دهند.

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

## **تنظیم زاویه چرخش برای عنوان محور نمودار**

در محور عمودی، [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) را فعال کنید، متن عنوان را فراهم کنید و [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) را تنظیم کنید تا عنوان چرخانده شود. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی با عنوان محور مقدار که ۹۰ درجه چرخیده است را ذخیره می‌کند.

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

## **تنظیم موقعیت محور در یک محور دسته یا مقدار**

از [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) برای کنترل این‌که آیا محور مقدار بین دسته‌ها یا در علامت‌گذاری‌های دسته عبور کند استفاده کنید. این ویژگی برای محورهای دسته اعمال می‌شود. مثال آن را روی محور دسته افقی یک نمودار ستونی برابر `True` تنظیم کرده و نتیجه را ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم واحد نمایش بر محور مقدار نمودار**

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) را تنظیم کنید تا برچسب‌های محور مقدار بدون تغییر داده‌های زیرین مقیاس‌بندی شوند. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) به `MILLIONS`، مقدار 60,000,000 به صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را به محور عمودی آن اعمال می‌نماید.

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

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت در چندین مرتبه توان متفاوت باشند. به عنوان مثال، یک سرویس ممکن است در پنج دوره ۱۰، ۱۰۰، ۱,۰۰۰، ۱۰,۰۰۰ و ۱۰۰,۰۰۰ درخواست دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر جمع می‌شوند. مقیاس لگاریتمی رشد نسبی آن‌ها را راحت‌تر مقایسه می‌کند: فاصله‌های برابر نشان‌دهندۀ نسبت‌های برابر هستند نه اختلاف‌های عددی برابر.

بر محور مقدار، [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) را برابر `True` تنظیم کنید و با [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) پایه را انتخاب کنید. این کار نحوه نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند ویژگی جداگانه‌ای است.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خطی یا ستونی، محور مقدار [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) است. برای نمودار میله‌ای افقی، [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) است. نمودارهای پراکندگی و حبابی دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو را انتخاب کنید. مقیاس لگاریتمی را بر محور دسته اعمال نکنید.

پایه پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX، می‌توانید پایه‌ای بین `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایه `10`، توان‌های متوالی مانند 10، 100، 1,000 و 10,000 به‌صورت مساوی فاصله‌گذاری می‌شوند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال مستقل زیر یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی می‌کند و در اسلاید دوم محور مقدار لگاریتمی پایه‑10 را فعال می‌نماید. هر دو اسلاید همان داده‌ها را حفظ می‌کنند.

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

    # اسلاید اول را به حالت خطی نگه دارید و فقط مقیاس محور مقدار نسخه کپی را تغییر دهید.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**مقیاس خطی (اسلاید ۱):** فواصل عمودی مساوی نشان‌دهندۀ اختلاف‌های مساوی در شمارش درخواست‌ها هستند. مقدار بزرگتر بخش عمدهٔ نمودار را اشغال می‌کند و مقادیر کوچکتر را تشخیص دشوار می‌سازد.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید ۲):** فواصل عمودی مساوی نشان‌دهندۀ نسبت‌های مساوی هستند. هر دوره ده برابر دورهٔ پیشین درخواست دارد، بنابراین نقاط بر روی مقیاس لگاریتمی پایه‑10 یک خط صعودی مستقیم می‌سازند. برچسب‌های محور هنوز شمارش درخواست‌های اصلی را نشان می‌دهند.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

مقیاس لگاریتمی فقط مقادیر مثبت صریح را می‌تواند نمایش دهد. پیش از فعال‌سازی، داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنادار هستند، مقیاس خطی را حفظ کنید یا آن‌ها را جداگانه نشان دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را شرح دهید. به‌صورتی که به‌صورت ساکن با اعداد مثبت کوچک جایگزین نکنید، زیرا معنای داده را تغییر می‌دهد. هر حداقل یا حداکثر به‌صورت دستی تنظیم‌شده برای محور لگاریتمی نیز باید مثبت باشد.

## **سوالات متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر را تنظیم کنم؟**

از [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) برای انتخاب رفتار تقاطع استفاده کنید. برای مشخص کردن مقدار عددی تقاطع، [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) را تنظیم کنید. این تنظیمات به شما امکان می‌دهد تقاطع محور را به یک مبنای مناسب منتقل کنید.

**چگونه می‌توانم موقعیت برچسب‌های علامت را نسبت به محور تنظیم کنم؟**

[tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) را با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) تنظیم کنید: `LOW`، `HIGH`، `NEXT_TO` یا `NONE`. برای کنترل خود علامت‌های tick، از [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) یا [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) استفاده کنید؛ این‌ها جدا از موقعیت‌گذاری برچسب‌ها هستند.