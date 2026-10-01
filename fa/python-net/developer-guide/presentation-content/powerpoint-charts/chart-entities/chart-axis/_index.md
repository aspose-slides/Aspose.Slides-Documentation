---
title: سفارشی‌سازی محورهای نمودار در ارائه‌ها با پایتون
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
description: "کشف کنید که چگونه می‌توان از Aspose.Slides برای پایتون از طریق .NET برای سفارشی‌سازی محورهای نمودار در ارائه‌های PowerPoint و OpenDocument برای گزارش‌ها و تجسم‌ها استفاده کرد."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان محورهای نمودار را با Aspose.Slides برای Python via .NET سفارشی کرد. موضوعات شامل مقادیر محاسبه‌شده محور، تعویض ردیف‌ها و ستون‌های نمودار، قابلیت نمایش محور، بازه‌های برچسب دسته و علامت‌گذاری، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت‌یابی محور و واحدهای نمایش می‌شود.

## **دریافت بیشترین مقادیر محور عمودی در نمودارها**

یک [ارائه](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) را صدا بزنید تا طرح‌بندی نمودار به‌روز شود.

[actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) و [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) را برای حدهای محور بخوانید و برای بازه‌های علامت‌گذاری، [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) و [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) را بررسی کنید. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) و [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) مقیاس‌های زمان‑واحد را ارائه می‌دهند که برای محورهای تاریخ مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

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

## **تبادلی داده‌ها بین محور‌ها**

از [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی تبدیل به یک سری می‌شود و هر سری قبلی تبدیل به یک دسته می‌شود. این تغییر نحوهٔ گروه‌بندی داده‌ها را تحت تأثیر قرار می‌دهد؛ محورهای افقی و عمودی را تعویض نمی‌کند. مثال از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) برای اتصال داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل ردیف سرعنوان و ستون دسته، پیش از تعویض ردیف و ستون استفاده می‌کند. سپس نموداری با چهار سری و سه دسته ذخیره می‌شود.

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

در محور عمودی، [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) را روی `False` تنظیم کنید تا مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با محور عمودی مخفی ذخیره می‌کند.

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

در محور افقی، [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) را روی `False` تنظیم کنید تا مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با محور افقی مخفی ذخیره می‌کند.

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

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) را تنظیم کنید تا یک محور دسته‌ای تاریخ یا متن انتخاب شود. این مثال به فایل `ExistingChart.pptx` نیاز دارد که در اولین اسلاید اولین شکل آن، یک نمودار دارد و سلول‌های دسته مقدارهای تاریخ عددی اکسل را دربر می‌گیرد. محور افقی را به یک محور تاریخ تبدیل می‌کند. با تنظیم [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) روی `False`، [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) روی `1` و [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) روی ماه، علامت‌های اصلی را در بازه‌های یک‑ماه تنظیم می‌کند.

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

## **کنترل بازهٔ برچسب‌های محور دسته‌ای**

هنگامیکه نمودار دارای تعداد زیادی دسته باشد، می‌توانید تعداد برچسب‌های قابل‌نمایش محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. ابتدا [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) را روی `False` تنظیم کنید، سپس [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) را به بازهٔ دلخواه دسته تنظیم کنید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| بازه | برچسب‌های نمایش‑داده‑شده در مثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

یک بازهٔ `3` هر سومین برچسب را نمایش می‌دهد و دو برچسب بین هر دو برچسب نمایش‌یافته مخفی می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصلهٔ خودکار بر پایهٔ فضای موجود یک بازهٔ مناسب انتخاب می‌کند؛ لزوماً تمام برچسب‌ها نمایش داده نمی‌شوند.

علامت‌گذاری‌ها کنترل جداگانه‌ای دارند. با تنظیم [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) روی `False` و استفاده از [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) می‌توانید بازهٔ آن‌ها را تعیین کنید. برای مثال، مقدار `1` یک علامت‌گذاری در هر بازهٔ دسته ایجاد می‌کند در حالی که برچسب‌ها فقط هر سومین دسته را نشان می‌دهند. [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) را به یک سبک قابل‌مشاهده تنظیم کنید تا نتیجه را ببینید. بازگرداندن هر یک از ویژگی‌های فاصلهٔ خودکار به `True` اجازه می‌دهد نمودار بازهٔ قبلی را انتخاب کند.

مثال مستقل زیر ۲۴ دسته و یک سری ایجاد کرده و سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصلهٔ خودکار، فاصلهٔ دستی برچسب‌ها با علامت‌گذاری‌های مستقل، و بازگشت به فاصلهٔ خودکار. دو نسخهٔ کپی داده‌های اصلی نمودار را حفظ می‌کنند. ارائهٔ ورودی نیازی نیست. متن برچسب افقی تفاوت در تراکم را به‌راحتی نشان می‌دهد.

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

    # اسلاید ۲: هر سومین برچسب را نمایش بده، اما برای هر دسته یک علامت‌گذاری نگه دار.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # اسلاید ۳: بگذار نمودار دوباره هر دو بازه را انتخاب کند.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**فاصلهٔ خودکار (اسلاید ۱):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و به دو خط می‌پیوندد. نتیجهٔ خودکار می‌تواند بسته به سایز نمودار، فونت‌ها و رندرر متفاوت باشد.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**فاصلهٔ دستی (اسلاید ۲):** هر سومین برچسب بر روی یک خط نمایش داده می‌شود، در حالی که علامت‌گذاری‌ها در هر بازهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، حتی آن‌هایی که برچسب ندارند، با مقادیر یکسان قابل مشاهده‌اند. اسلاید ۳ دوباره ظاهر خودکار نشان‑داده‌شده در بالا را بازمی‌گرداند.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **انتخاب محور و بازهٔ صحیح**

از این بازهٔ شمارش دسته برای محور دسته‌ای متنی استفاده کنید، مانند محور دسته‌ای یک نمودار ستونی، خطی، ناحیه‌ای یا میله‌ای. در یک نمودار ستونی، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته‌ای عمودی است، بنابراین این تنظیمات را برای [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) اعمال کنید. فاصلهٔ علامت‌گذاری نیز برای محور سری در نمودارهایی که دارای یک محور سری هستند کاربرد دارد.

از فاصلهٔ برچسب دسته برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در یک محور مقدار، [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) اختلافی در مقادیر را مشخص می‌کند؛ برای مثال، یک واحد اصلی `10` علامت‌ها را در ۰، ۱۰، ۲۰ و غیره تولید می‌کند وقتی محور از صفر شروع می‌شود. بازهٔ برچسب دسته `3` به جای مقادیر داده‌ای، موقعیت‌های دسته را می‌شمارد. نمودارهای پراکندگی و حبابی از محورهای مقدار استفاده می‌کنند نه از محور دسته‌ای متن. برای یک محور تاریخ، از واحدهای اصلی زمان‑محور و مقیاس‌ها همان‌طور که در [تغییر محور دسته‌ای](#change-a-category-axis) شرح داده شد، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌ای**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌صورت شماره سریال OLE Automation در اولین جدول کاری (شاخص `0`) ذخیره می‌شوند. [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) را روی محور تاریخ تنظیم کنید، [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) را غیرفعال کنید و `yyyy` را به [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) اختصاص دهید تا برچسب‌های دسته به صورت سال‌های چهاررقمی جدا از قالب‌بندی سلول نمایش داده شوند.

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

در محور عمودی، [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) را فعال کنید، متن عنوان را فراهم کنید و [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) را تنظیم کنید تا عنوان چرخانده شود. زاویه به درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی با عنوان محور مقدار که به‌صورت ۹۰ درجه چرخیده ذخیره می‌کند.

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

## **تنظیم موقعیت محور بر روی یک محور دسته‌ای یا مقدار**

از [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) برای کنترل اینکه آیا محور مقدار بین دسته‌ها یا در علامت‌های دسته عبور کند استفاده کنید. این ویژگی به محورهای دسته‌ای اعمال می‌شود. مثال این ویژگی را روی `True` برای محور دسته‌ای افقی یک نمودار ستونی تنظیم می‌کند و نتیجه را ذخیره می‌کند.

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

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) را تنظیم کنید تا برچسب‌های محور مقدار بدون تغییر داده‌های پایه مقیاس‌بندی شوند. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) روی `MILLIONS`، مقدار 60,000,000 به شکل 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد کرده و واحد نمایش میلیون‌ها را بر محور عمودی آن اعمال می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**چگونه مقدار عبور یک محور را نسبت به محور دیگر تنظیم کنم (crossing)؟**

از [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) برای انتخاب رفتار عبور استفاده کنید. برای تعیین مقدار عددی عبور، [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) را تنظیم کنید. این تنظیمات به شما اجازه می‌دهند عبور محور را به یک خط پایه مناسب منتقل کنید.

**چگونه می‌توانم موقعیت برچسب‌های علامت را نسبت به محور تنظیم کنم؟**

[تیک‌لبل‑پوزیشن](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) را با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) تنظیم کنید: `LOW`، `HIGH`، `NEXT_TO` یا `NONE`. برای کنترل خود علامت‌گذاری‌ها، از [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) یا [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) استفاده کنید؛ اینها جدا از موقعیت برچسب‌ها هستند.