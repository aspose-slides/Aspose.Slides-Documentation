---
title: سفارشی‌سازی محورها در نمودارها در ارائه‌ها با Python
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
description: "کشف کنید که چگونه از Aspose.Slides for Python via .NET برای سفارشی‌سازی محورها در نمودارها در ارائه‌های PowerPoint و OpenDocument برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه محورهای نمودار را در Aspose.Slides for Python via .NET سفارشی کنید. شامل مقادیر محاسبه‌شده محور، تعویض سطرها و ستون‌های نمودار، قابلیت مشاهده محور، فواصل برچسب دسته و علامت‌های تیک، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت محور، واحدهای نمایش و مقیاس لگاریتمی است.

## **دریافت بیشینه مقادیر محور عمودی در نمودارها**

یک [ارائه](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، برای به‌روز کردن چیدمان نمودار، [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) را فراخوانی کنید.

[actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) و [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) را برای تعیین حدود محور بخوانید و [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) و [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) را برای فواصل تیک‌ها استفاده کنید. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) و [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) مقیاس‌های زمان-واحد را فراهم می‌کنند که برای محورهاى تاریخ مربوط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

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

برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار از [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) استفاده کنید. هر دسته قبلی تبدیل به یک سری می‌شود و هر سری قبلی تبدیل به یک دسته می‌شود. این تغییر نحوهٔ گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورهای افقی و عمودی را تعویض نمی‌کند. مثال از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) برای باند کردن داده‌های پیش‌فرض به `Sheet1!A1:D5` استفاده می‌کند که شامل ردیف سرعنوان و ستون دسته است، سپس سطرها و ستون‌ها را تعویض می‌کند. نتیجه یک نمودار با چهار سری و سه دسته است.

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

## **معکوس کردن ترتیب رسم یک محور**

برای معکوس کردن یک محور دسته یا مقدار از [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) استفاده کنید. به عنوان مثال، یک نمودار میله‌ای افقی می‌تواند مراحل پروژه را از بالا به پایین به همان ترتیبی که در صفحه‌گشت نشان داده شده است، نمایش دهد: برنامه‌ریزی، توسعه، تست. معکوس کردن یک محور جهت رسم را تغییر می‌دهد؛ داده‌های کاربرگ را مرتب یا دوباره ترتیب نمی‌دهد. برای مقایسه، [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) نقش سری‌ها و دسته‌ها را تعویض می‌کند.

مثال زیر یک نمودار میله‌ای افقی با سه مرحله و یک سری ایجاد می‌کند. ارائه‌ای با سه اسلاید ذخیره می‌کند: ترتیب عادی، دسته‌های معکوس، و مقادیر معکوس. هر کپی از همان مجموعه داده استفاده می‌کند و فقط یک محور در هر کپی معکوس می‌شود.

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

    # اسلاید ۲: نمایش اولین دسته در بالای صفحه.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # محور مقدار افقی را در پایین نگه‌دارید.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # اسلاید ۳: فقط مقیاس عددی افقی را معکوس کنید.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

معکوس کردن یک محور می‌تواند محور عمود را به سمت مخالف نمودار جابه‌جا کند. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) تعیین می‌کند که محور دیگر در کجا به محور تنظیم‌شده می‌رسد. در اسلاید ۲، تنظیم آن به `MAXIMUM` بر روی محور دسته معکوس، محور مقدار افقی را در پایین نگه می‌دارد. برای نقطهٔ تقاطع خاص، از [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) استفاده کنید. هنگام تغییر جهت، تنظیمات تقاطع را بررسی کنید، به‌ویژه اگر نمودار قبلاً نقطهٔ تقاطع سفارشی داشته باشد. برای بازیابی جهت عادی، `is_plot_order_reversed` را به `False` برگردانید؛ تنظیمات تقاطع مستقل هستند.

| ترتیب عادی (اسلاید ۱) | دسته‌های معکوس (اسلاید ۲) | مقادیر معکوس (اسلاید ۳) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| دسته‌ها از پایین به بالا می‌روند؛ مقادیر از چپ به راست افزایش می‌یابند. | برنامه‌ریزی، توسعه و تست از بالا به پایین نمایش داده می‌شوند. مقادیر و ترتیب ردیف‌های کاربرگ تغییر نکرده‌اند. | دسته‌ها ترتیب عادی خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته در صفر سمت راست تقاطع می‌کند. |

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

در محور عمودی، [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) را به `False` تنظیم کنید تا پنهان شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **غیرفعال کردن محور افقی برای نمودارهای خطی**

در محور افقی، [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) را به `False` تنظیم کنید تا پنهان شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **نمایش یا مخفی کردن خطوط شبکه نمودار**

[show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/) و [show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/) را بخوانید تا متوجه شوید که کدام خطوط شبکه توسط یک محور نشان داده می‌شود. هر دو ویژگی فقط‑خواندنی هستند. برای نمایش خطوط شبکه جزئی، پر کردن خط را در [minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/) به یک پر کردن جامد تغییر دهید و رنگ قابل مشاهده‌ای انتخاب کنید. برای مخفی کردن آن‌ها، نوع پر کردن را به `FillType.NO_FILL` تنظیم کنید. برای خطوط شبکه اصلی، از [major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format` استفاده کنید. تغییر پر کردن، نمایش محور و علامت‌های تیک را حفظ می‌کند.

محور عمودی این نمودار ستونی تجمیعی با خطوط شبکه اصلی نشان‌داده‑شده و خطوط شبکه جزئی مخفی شروع می‌شود. مثال خطوط شبکه جزئی را به رنگ نارنجی نشان می‌دهد، سپس دوباره مخفی می‌کند و ارائه را ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| خطوط شبکه جزئی فعال | خطوط شبکه جزئی مخفی |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **تغییر محور دسته‌بندی**

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) را تنظیم کنید تا یک محور تاریخ یا متن انتخاب شود. این مثال به `ExistingChart.pptx` نیاز دارد که در اسلاید اول اولین شکل آن یک نمودار باشد و سلول‌های دسته مقادیر عددی تاریخ اکسل را داشته باشند. محور افقی را به یک محور تاریخ تغییر می‌دهد. با تنظیم [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) به `False`، [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) به `1` و [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) به ماه‌ها، علامت‌های اصلی در فواصل یک ماهی تنظیم می‌شوند.

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

### **تعیین نوع محور دسته‌بندی از داده‌ها**

پس از پر کردن دسته‌ها، [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/) را فراخوانی کنید، سپس برای بررسی انتخاب، [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) را بخوانید. این روش زمانی مفید است که همان نمودار یا برچسب‌های متنی یا مقادیر عددی تاریخ دریافت کند. متد زمانی که فراخوانی می‌شود نوع را تعیین می‌کند؛ حالت پایداری که بعداً تغییرات داده را مجدداً ارزیابی می‌کند فعال نمی‌کند. پس از جایگزینی دسته‌ها، دوباره آن را فراخوانی کنید.

مثال زیر یک نمودار با دسته‌های متنی ایجاد می‌کند و `TEXT` چاپ می‌کند. سپس مقادیر سلول‌های دسته را با تاریخ‌ها جایگزین می‌کند و دوباره متد را فراخوانی می‌کند که `DATE` چاپ می‌شود. تاریخ‌ها به عنوان مقادیر عددی OLE Automation ذخیره می‌شوند که به‌عنوان تعداد روزهای گذشت از 30 دسامبر 1899 محاسبه می‌شوند نه به‌صورت رشتهٔ تاریخ. [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) کنترل می‌کند که این مقادیر چگونه نمایش داده شوند؛ تبدیل متن به تاریخ عددی را انجام نمی‌دهد. برای اطلاعات بیشتر دربارهٔ سلول‌های دسته، به [Chart Workbook](/slides/fa/python-net/chart-workbook/) مراجعه کنید.

از تعیین خودکار زمانی استفاده کنید که ورودی به وضوح شامل دسته‌های متنی یا تاریخ‌های عددی باشد، همانند این مثال. برای برچسب‌های عددی معمولی، دسته‌های ترکیبی یا داده‌های خالی، صریحاً [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) را برای مطابقت با معنای موردنظر تنظیم کنید. مقادیر صرفاً عددی به تنهایی نشان نمی‌دهند که دسته‌ها نمایانگر تاریخ هستند.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # متن

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # تاریخ

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **کنترل فواصل برچسب محور دسته‌بندی**

هنگامی که یک نمودار دسته‌های زیادی دارد، می‌توانید تعداد برچسب‌های محور قابل مشاهده را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. ابتدا [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) را به `False` تنظیم کنید، سپس [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) را به فاصلهٔ دلخواه دسته تنظیم کنید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته شروع می‌شود:

| فواصل | برچسب‌های نمایش‌داده‑شده در مثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

فاصلهٔ `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب بین آن‌ها مخفی می‌ماند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصله‌گذاری خودکار بر اساس فضای موجود یک فاصله انتخاب می‌کند؛ لزوماً همه برچسب‌ها را نمایش نمی‌دهد.

علامت‌های تیک کنترل‌های جداگانه‌ای دارند. [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) را به `False` تنظیم کنید و با استفاده از [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) فاصلهٔ آن‌ها را تنظیم کنید. به عنوان مثال، مقدار `1` یک علامت تیک در هر فاصلهٔ دسته حفظ می‌کند در حالی که برچسب‌ها فقط هر سومین دسته نمایش داده می‌شوند. برای مشاهده نتیجه، [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) را به یک سبک قابل رؤیت تنظیم کنید. بازگرداندن هر یک از ویژگی‌های فاصله‌گذاری خودکار به `True` اجازه می‌دهد نمودار دوباره همان فاصله را انتخاب کند.

مثال خودکفای زیر ۲۴ دسته و یک سری ایجاد می‌کند، سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصله‌گذاری خودکار، فاصله‌گذاری دستی برچسب‌ها با علامت‌های تیک مستقل، و بازگردانی فاصله‌گذاری خودکار. دو نسخهٔ کپی داده‌های اصلی نمودار را حفظ می‌کنند. ارائهٔ ورودی لازم نیست. متن برچسب‌های افقی تفاوت چگالی را به‌راحتی نشان می‌دهد.

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

    # اسلاید ۳: بگذارید نمودار دوباره هر دو فواصل را انتخاب کند.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**فاصله‌گذاری خودکار (اسلاید ۱):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجهٔ خودکار ممکن است بسته به اندازهٔ نمودار، قلم‌ها و رندر کننده متفاوت باشد.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**فاصله‌گذاری دستی (اسلاید ۲):** هر سومین برچسب روی یک خط نمایش داده می‌شود، در حالی که علامت‌های تیک در هر فاصلهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، حتی آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده هستند. اسلاید ۳ ظاهر خودکار بالا را بازمی‌گرداند.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **انتخاب محور و فاصلهٔ صحیح**

از این فاصلهٔ شمارش دسته برای محور دسته‌بندی متنی استفاده کنید، مانند محور دسته‌بندی یک نمودار ستونی، خطی، مساحتی یا میله‌ای. در نمودار ستونی، این محور افقی است. در نمودار میله‌ای افقی، محور دسته‌بندی عمودی است، بنابراین این تنظیمات را برای [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) اعمال کنید. فاصله‌گذاری علامت‌های تیک همچنین برای محور سری در نمودارهایی که چنین محوری دارند، اعمال می‌شود.

از فاصلهٔ برچسب دسته برای تنظیم مقیاس عددی محور مقدار استفاده نکنید. در یک محور مقدار، [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) اختلافی در مقادیر را مشخص می‌کند: به‌عنوان مثال، یک واحد اصلی `10` علامت‌ها را در 0، 10، 20 و غیره وقتی محور از صفر شروع می‌شود، تولید می‌کند. یک فاصلهٔ برچسب دسته‌ای `3` به‌جای مقادیر عددی، موقعیت‌های دسته را شمرده و صرفاً位置 را شمارش می‌کند. نمودارهای پراکندگی و حباب از محورهاى مقدار استفاده می‌کنند نه از محور دسته‌بندی متنی. برای محور تاریخ، از واحدهای اصلی و مقیاس‌های مبتنی بر زمان همان‌طور که در [تغییر محور دسته‌بندی](#change-a-category-axis) توضیح داده شده است، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌بندی**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان اعداد سریال OLE Automation در اولین کاربرگ (اندیس `0`) ذخیره می‌شوند. [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) را به محور تاریخ تنظیم کنید، [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) را غیرفعال کنید و `yyyy` را به [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) اختصاص دهید تا برچسب‌های دسته سال‌های چهاررقمی را به‌صورت مستقل از قالب‌بندی سلول‌ها نشان دهد.

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

در محور عمودی، ویژگی [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) را فعال کنید، متن عنوان را فراهم کنید و [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) را تنظیم کنید تا عنوان چرخانده شود. زاویه برحسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار که 90 درجه چرخیده ذخیره می‌کند.

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

## **تنظیم موقعیت محور در محور دسته یا مقدار**

از [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) برای کنترل اینکه آیا محور مقدار در بین دسته‌ها یا در علامت‌های تیک دسته به محور دسته تقاطع می‌کند، استفاده کنید. این ویژگی برای محورهای دسته اعمال می‌شود. مثال این ویژگی را روی محور دسته افقی یک نمودار ستونی به `True` تنظیم می‌کند و نتیجه را ذخیره می‌کند.

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

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) را تنظیم کنید تا برچسب‌های محور مقدار بدون تغییر داده‌های پایه مقیاس‌بندی شوند. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) به `MILLIONS`، مقدار 60 000 000 به صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر روی محور عمودی آن اعمال می‌کند.

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

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت طی چندین مرتبهٔ توان متفاوت باشند. به‌عنوان مثال، سرویسی ممکن است در پنج دوره درخواست‌های 10، 100، 1 000، 10 000 و 100 000 دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر جمع می‌شوند. مقیاس لگاریتمی رشد نسبی آن‌ها را راحت‌تر مقایسه می‌کند: فواصل مساوی نشان‌دهندهٔ نسبت‌های مساوی هستند نه تفاضل‌های مساوی.

[is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) را روی محور مقدار به `True` تنظیم کنید و با استفاده از [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) پایهٔ موردنظر را انتخاب کنید. این تغییر نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خطوط روند لگاریتمی اضافه نمی‌کند. خطوط روند رابطهٔ برازش‌شده‌ای در داده‌ها را نشان می‌دهند و ویژگی جداگانه‌ای هستند.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خطی یا ستونی، محور مقدار [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) است. برای یک نمودار میله‌ای افقی، محور مقدار [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) است. نمودارهای پراکندگی و حباب دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی و برای مقادیر Y محور عمودی یا هر دو را می‌توانید انتخاب کنید. برای محور دسته، مقیاس لگاریتمی اعمال نکنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX می‌توانید پایه‌ای از `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایهٔ `10` توان‌های متوالی مانند 10، 100، 1 000 و 10 000 به‌صورت مساوی فواصل دارند.

### **مقایسه مقیاس‌گذاری خطی و لگاریتمی**

مثال خودکفای زیر یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی می‌کند و در اسلاید دوم محور مقدار لگاریتمی با پایهٔ 10 را فعال می‌کند. هر دو اسلاید همان داده‌ها را حفظ می‌کنند.

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

    # اسلاید اول را به صورت خطی نگه داشته و فقط مقیاس محور مقدار نسخه‌ی کپی شده را تغییر دهید.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**مقیاس خطی (اسلاید ۱):** فواصل عمودی مساوی نشان‌دهندهٔ اختلاف‌های مساوی در شمارش درخواست‌ها هستند. مقدار بزرگ‌ترین مقدار نمودار را تسلط می‌دهد و مقادیر کوچکتر را تشخیص سخت می‌شود.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید ۲):** فواصل عمودی مساوی نشان‌دهندهٔ نسبت‌های مساوی هستند. هر دوره ده برابر درخواست دورهٔ قبلی دارد، بنابراین نقاط روی مقیاس پایه‑10 یک خط صعودی صاف تشکیل می‌دهند. برچسب‌های محور هنوز شمارش درخواست‌های اصلی را نشان می‌دهند.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

یک مقیاس لگاریتمی فقط مقادیر مثبت صریح را می‌تواند نمایش دهد. قبل از فعال‌سازی، داده‌ها را بررسی کنید. اگر صفر یا مقادیر منفی معنی‌دار هستند، مقیاس خطی را حفظ کنید یا آنها را جداگانه نمایش دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌صورت ساکن آنها را با عددهای مثبت کوچک جایگزین نکنید، زیرا معنای داده‌ها تغییر می‌کند. هر حداقل یا بیشینهٔ تنظیم‌شدهٔ دستی برای یک محور لگاریتمی نیز باید مثبت باشد.

## **سئوالات متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر (axis crossing) را تعیین کنم؟**

از [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) برای انتخاب رفتار تقاطع استفاده کنید. برای مشخص کردن مقدار عددی تقاطع، [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) را تنظیم کنید. این تنظیمات به شما امکان می‌دهند تقاطع محور را به یک خط پایه مناسب منتقل کنید.

**چگونه می‌توانم موقعیت برچسب‌های تیک را نسبت به محور تنظیم کنم؟**

[tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) را با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) تنظیم کنید: `LOW`، `HIGH`، `NEXT_TO` یا `NONE`. برای کنترل خود علامت‌های تیک، از [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) یا [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) استفاده کنید؛ این‌ها جدا از موقعیت برچسب‌ها هستند.