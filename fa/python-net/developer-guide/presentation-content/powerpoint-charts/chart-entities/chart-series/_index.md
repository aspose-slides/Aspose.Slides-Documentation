---
title: مدیریت سری داده‌های نمودار در ارائه‌ها با پایتون
linktitle: سری داده‌ها
type: docs
url: /fa/python-net/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- رنگ دسته
- نام سری
- نقطه داده
- فاصله سری
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "آموزش نحوه مدیریت سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی در ارائه‌ها با پایتون."
---
## **مرور کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب کار داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [ChartDataPoint](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/) در این مجموعه به یک یا چند سلول کتاب کار ارجاع می‌دهد. اشیاء [ChartCategory](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌کنند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقطه‌ها به اشیاء [ChartDataCell](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatacell/) متصل هستند نه اینکه فقط به‌صورت متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، کتاب کار پیش‌فرض از ردیف 0 برای نام مجموعه‌ها، ستون 0 برای نام دسته‌ها و سلول‌های باقی‌مانده برای مقادیر مجموعه‌ها استفاده می‌کند. اندیس‌های ورق کار، ردیف و ستون که به متد [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) ارسال می‌شوند، از صفر شروع می‌شوند. این طرح‌بندی زمانی مفید است که یک نمودار با داده‌های پیش‌فرض ایجاد می‌کنید، اما نباید فرض کنید که همهٔ نمودارهای موجود از آن استفاده می‌کنند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب کار، سلول‌های ارجاع‌شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه دامنه متفاوت هستند:

- تنظیمات سطح مجموعه‌ (Series)، مانند [ChartSeries.format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/format/)، ظاهر پیش‌فرض تمام نقاط در یک مجموعه را فراهم می‌کنند.
- تنظیمات نقطه داده، مانند [ChartDataPoint.format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/format/)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروه بر روی مجموعه‌های سازگار که به همان [ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند هم‌پوشانی یا عرض فضای خالی، می‌توانید گروه را از طریق [ChartSeries.parent_series_group](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/parent_series_group/) دسترسی پیدا کنید.

وقتی پرکردن صریح برای نقطه یا مجموعه تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. هنگامی که هم قالب‌بندی مجموعه و هم نقاط موجود باشد، قالب‌بندی نقطه برای آن نقطه اولویت دارد.

![نمودار-سری-پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی مجموعه نمودار**

[ChartSeries.overlap](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/overlap/) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار دو‌بعدی تا چه اندازه (از -100 تا 100 درصد) همپوشانی دارند. این یک پیش‌نمایش فقط‑خواندنی از تنظیمات در گروه مجموعه والد است. برای به‌روزرسانی تمام مجموعه‌های سازگار در آن گروه، [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/overlap/) را تنظیم کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی را نمایش می‌دهند اعمال می‌شود؛ بر گروه‌های مجموعه نامرتبط در یک نمودار ترکیبی تأثیر ندارد.

مثال زیر همپوشانی گروهی که شامل اولین مجموعه است را تنظیم می‌کند:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # نمودار جدید شامل مجموعه‌های نمونه، دسته‌ها و مقادیر است.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![همپوشانی مجموعه](series_overlap.png)

## **تغییر رنگ پرکردن مجموعه**

از [ChartSeries.format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/format/) برای تنظیم پرکردن پیش‌فرض یک مجموعهٔ کامل استفاده کنید. اگر یک نقطه قبلاً پرکردن صریح داشته باشد، تنظیم [ChartDataPoint.format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/format/) آن، پرکردن مجموعه را برای آن نقطه بازنویسی می‌کند.

مثال زیر پرکردن ممتد آبی‌رنگ را به اولین مجموعه اعمال می‌کند:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![رنگ مجموعه](series_color.png)

## **تغییر نام مجموعه**

نام یک مجموعه در کتاب کار داده‌های نمودار ذخیره می‌شود و معمولاً در راهنمای نمودار نمایش داده می‌شود. در کتاب کار پیش‌فرض ایجاد شده برای یک نمودار ستون خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را داراست. ثابت‌های نام‌گذاری شده در مثال زیر این ساختار را به‌وضوح نشان می‌دهند:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

همچنین می‌توانید سلولی را که قبلاً توسط [ChartSeries.name](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/name/) ارجاع شده است، به‌روزرسانی کنید. این روش از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![نام مجموعه](series_name.png)

## **دریافت رنگ پرکردن خودکار مجموعه**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) رنگی را برمی‌گرداند که از شاخص مجموعه و سبک نمودار محاسبه شده است. این همان رنگی است که وقتی پرکردن مجموعه به‌طور صریح تعریف نشده باشد استفاده می‌شود. فراخوانی این متد رنگ محاسبه‌شده را می‌خواند؛ در حالی که پرکردن جدیدی اختصاص نمی‌دهد.

مثال زیر رنگ خودکار هر مجموعه پیش‌فرض را چاپ می‌کند:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

خروجی مثال برای سبک پیش‌فرض نمودار:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

رنگ‌های دقیق بستگی به سبک و تم نمودار دارند.

## **تنظیم رنگ پرکردن معکوس برای یک مجموعه نمودار**

برای مجموعه‌های میله‌ای، ستونی و حبابی، [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/invert_if_negative/) می‌تواند مقادیر منفی را با پرکردن متفاوتی نشان دهد. پرکردن معمولی مجموعه را به حالت ممتد تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) اختصاص دهید. اعداد منفی در کتاب کار بدون تغییر باقی می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 ورق کار شامل نام مجموعه، ستون 0 شامل نام دسته‌ها و ستون 1 شامل مقادیر است:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![رنگ پرکردن ممتد معکوس](inverted_solid_fill_color.png)

می‌توانید معکوس‌سازی را برای یک نقطه از طریق [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) فعال کنید. در مثال زیر، معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال است. همچنین به نقطه مقدار منفی اختصاص داده می‌شود تا اثر قابل مشاهده باشد:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **پاک‌سازی مقدار نقطه دادهٔ خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتوانهٔ کتاب کار آن را به `None` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [ChartDataPoint.value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/value/) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات مقدار خالی نمودار به‌صورت خالی در نظر می‌گیرد.

مثال زیر فقط نقطهٔ دوم در اولین مجموعه را پاک می‌کند:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

نمودارهای پراکنده از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حبابی همچنین از یک سلول سایز استفاده می‌کنند. فقط سلولی را که نمایانگر مقداری است که قصد حذف آن را دارید پاک کنید. هنگام نگه داشتن نقاط دیگر، از فراخوانی [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapointcollection/clear/) خودداری کنید، زیرا این روش تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

یک سلول خالی در کتاب کار نشانگر دادهٔ گمشده است؛ سلولی که مقدار `0` دارد نمایانگر مقدار عددی شناخته‌شده است. برای خالی کردن سلول، [ChartDataCell.value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatacell/value/) را به `None` تنظیم کنید. صفر عددی صرفاً صفر می‌ماند بدون توجه به تنظیم سلول خالی.

از [Chart.display_blanks_as](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/display_blanks_as/) برای انتخاب نحوهٔ نمایش سلول‌های خالی در نمودار استفاده کنید. این تنظیم برای تمام نمودار اعمال می‌شود. این تنظیم نحوهٔ ترسیم خالی‌ها را تغییر می‌دهد بدون اینکه سلول خالی کتاب کار را با صفر یا مقدار درونی‌سازی شده پر کند.

مثال خود‌محافظ زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز 3 را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. فایل ورودی لازم نیست. [ChartDataWorkbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/) از ورق کار 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را نگه می‌دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # روز ۳ را واقعاً خالی بگذارید، در حالی که دسته و نقطه داده آن را حفظ می‌کنید.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

هر فایل خروجی حالت اختصاص‑دهی شده قبل از ذخیره را ذخیره می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ یک نسخه تنها، حالت موردنظر را اختصاص دهید و ارائه را یکبار ذخیره کنید به‌جای تکرار بر روی حالت‌ها.

مقایسهٔ زیر همان داده‌ها را در هر سه فایل نشان می‌دهد. روز 3 در هر صورت در کتاب کار خالی است:

![نمودارهای خطی با داده‌های یکسان: Gap خط را در روز 3 قطع می‌کند، Zero خط را به صفر می‌کوبد، و Span روز 2 را به روز 4 متصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی مقایسهٔ سه حالت را آسان می‌کند. نمودارهای میله‌ای و ستونی خطی برای اتصال بین یک دستهٔ گمشده ندارند، بنابراین `SPAN` نمی‌تواند قطعهٔ اتصال نشان داده‌شده در بالا را تولید کند؛ یک ستون گمشده و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به نظر برسند. به‌طور مشابه، یک نمودار پراکنده فقط با نشانگرها خط اتصال ندارد. انتظار نتایج سه‌گانهٔ متفاوت برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصلهٔ مجموعه**

عرض فاصله (Gap width) فضا بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. مشابه همپوشانی، این تنظیم به گروه مجموعهٔ والد تعلق دارد نه به یک مجموعه. برای گروه، یک‌بار [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) را تنظیم کنید. مقدار بزرگ‌تر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آن‌ها را متراکم‌تر می‌کند.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائهٔ نهایی را ذخیره می‌کند:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![عرض فاصله](gap_width.png)

## **سؤال‌های متداول**

**کدام انواع نمودار از مجموعه داده‌ها پشتیبانی می‌کنند؟**

تمام انواع نمودار که توسط شمارش [ChartType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/charttype/) نمایش داده می‌شوند از داده‌های نمودار استفاده می‌کنند، اما مجموعه‌های آن‌ها همگی ساختار یا تنظیمات یکسانی ندارند. به عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y استفاده می‌کنند و نمودارهای حبابی علاوه بر این اندازه حباب را نیز دارند. از روش ایجاد نقطه داده‌ای که با نوع مجموعه سازگار است استفاده کنید. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های میله‌ای یا ستونی سازگار اعمال می‌شوند.

**یک گروه مجموعهٔ نمودار چیست؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات ترسیم سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروه دسترسی‌یافته از طریق یک مجموعه لزوماً همهٔ مجموعه‌های موجود در نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه ایجاد‌شده شامل داده‌های پیش‌فرض است؟**

بله. به‌صورت پیش‌فرض، [ShapeCollection.add_chart](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_chart/) مجموعه‌های نمونه، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملا سفارشی، هر دو مجموعه و دسته‌ها را پاک کنید. یک بارگذاری نیز می‌تواند نموداری بدون دادهٔ پیش‌فرض ایجاد کند.

**اشیاء نمودار چگونه به سلول‌های کتاب کار متصل هستند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت دادهٔ سفارشی، ردیف‌های دسته و ردیف‌های مقدار مجموعه را هم‌راستا نگه دارید تا هر نقطه تحت دستهٔ موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای تمام مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `None` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط زمانی از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapointcollection/clear/) استفاده کنید که می‌خواهید تمام نقاط آن مجموعه حذف شوند. اگر دسته‌ها را نیز حذف می‌کنید، هر مجموعه را به‌روزرسانی کنید تا مقادیر آن‌ها با مجموعه دسته هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و [Chart.display_blanks_as](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/display_blanks_as/) وابسته است. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله‌ها، به‌عنوان مقادیر صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنای دادهٔ گمشده در ارائهٔ شما سازگار باشد. برای مثال کامل و مقایسهٔ بصری به [کنترل نمایش سلول‌های خالی](#control-the-display-of-empty-cells) مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های میله‌ای، ستونی و حبابی پشتیبانی‌شده، [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/invert_if_negative/) را فعال کنید و [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ فردی با [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) بازنویسی کنید. این ویژگی‌ها فقط بر قالب‌بندی تأثیر می‌گذارند، نه بر مقادیر عددی ذخیره‌شده.

**زمانی که هم مجموعه و هم نقطه قالب‌بندی شوند، کدام فرمت برتری دارد؟**

قالب‌بندی صریح نقطه داده برای آن نقطه اولویت دارد. نقاط دیگر همچنان از قالب صریح مجموعه استفاده می‌کنند یا اگر قالب مجموعه تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. ویژگی‌های گروه مانند همپوشانی و عرض فاصله فقط رچوب‌بندی را کنترل می‌کنند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌هایی که یک نمودار می‌تواند داشته باشد وجود دارد؟**

Aspose.Slides محدودیتی ثابت برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد معقولی هستند.

**هنگامی که ستون‌ها خیلی نزدیک یا خیلی دور از یکدیگر هستند، چه باید تغییر دهم؟**

[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) را در گروه مجموعهٔ والد مناسب تنظیم کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها بیشتر شود یا آن را کاهش دهید تا خوشه‌ها به‌هم نزدیک‌تر شوند.