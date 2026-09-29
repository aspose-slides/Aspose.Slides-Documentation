---
title: مدیریت داده‌های سری نمودار در ارائه‌ها با پایتون
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
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با پایتون مدیریت کنید."
---
## **بررسی کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب کار داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [ChartDataPoint](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/) در این سری به یک یا چند سلول کتاب کار ارجاع می‌دهد. اشیاء [ChartCategory](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک توسط سری‌ها را فراهم می‌کنند. بنابراین نام سری، دسته‌ها و مقادیر نقاط به اشیاء [ChartDataCell](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatacell/) متصل هستند نه اینکه فقط به‌صورت متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، کتاب کار پیش‌فرض ردیف ۰ را برای نام‌های سری، ستون ۰ را برای نام‌های دسته و بقیه سلول‌ها را برای مقادیر سری استفاده می‌کند. اندیس‌های کاربرگ، ردیف و ستون که به متد [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) پاس داده می‌شوند، از صفر شروع می‌شوند. این چیدمان هنگام ایجاد نمودار با داده‌های پیش‌فرض مفید است، اما نباید فرض کنید هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب کار، سلول‌هایی را که توسط سری‌ها، دسته‌ها و نقاط داده ارجاع داده می‌شوند، بررسی کنید.

تنظیمات نمودار سه حوزه متفاوت دارند:

- تنظیمات سطح‑سری، مانند [ChartSeries.format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/format/)، ظاهر پیش‌فرض برای تمام نقاط یک سری را فراهم می‌کند.
- تنظیمات نقطه‑داده، مانند [ChartDataPoint.format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/format/)، ظاهر سری را برای یک نقطه نادیده می‌گیرد.
- تنظیمات گروهی به سری‌های سازگاری که به همان [ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/) تعلق دارند، اعمال می‌شود. هنگامی که نیاز به تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله دارید، از [ChartSeries.parent_series_group](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/parent_series_group/) دسترسی پیدا کنید.

هنگامی که پر شدن صریح برای نقطه یا سری تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هر دو قالب‌بندی سری و نقطه وجود داشته باشد، قالب‌بندی نقطه برای آن نقطه برتری دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

[ChartSeries.overlap](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/overlap/) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار دو‑بعدی تا چه اندازه همپوشانی دارند؛ مقدار از ‎‑100 تا ۱۰۰ درصد است. این مقدار یک پروجکشن فقط‑خواندنی از تنظیمات گروه سری والد است. برای به‌روزرسانی هر سری سازگار در آن گروه، [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/overlap/) را تنظیم کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی را نشان می‌دهند اعمال می‌شود؛ اما بر گروه‌های سری نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر همپوشانی گروهی که شامل اولین سری است را تنظیم می‌کند:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # نمودار جدید شامل سری‌های نمونه، دسته‌ها و مقادیر است.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The series overlap](series_overlap.png)

## **تغییر رنگ پر کردن سری**

از [ChartSeries.format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/format/) برای تنظیم پر کردن پیش‌فرض یک سری کامل استفاده کنید. اگر یک نقطه قبلاً پر شدن صریح داشته باشد، تنظیم [ChartDataPoint.format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/format/) آن، پر کردن سری را برای آن نقطه نادیده می‌گیرد.

مثال زیر یک پر کردن ثابت آبی را برای اولین سری اعمال می‌کند:

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

![The color of the series](series_color.png)

## **تغییر نام سری**

نام سری در کتاب کار داده‌های نمودار ذخیره می‌شود و معمولاً در افسانه (legend) نشان داده می‌شود. در کتاب کار پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف ۰ و ستون ۱ قرار دارد و نام اولین سری را شامل می‌شود. ثابت‌های نام‌گذاری در مثال زیر این ساختار را به‌صورت صریح نشان می‌دهند:

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

همچنین می‌توانید سلول ارجاع‌شده توسط [ChartSeries.name](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/name/) را به‌روزرسانی کنید. این روش از فرض کردن ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

![The series name](series_name.png)

## **دریافت رنگ پر کردن خودکار سری**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) رنگی را برمی‌گرداند که بر اساس اندیس سری و سبک نمودار محاسبه می‌شود. این رنگ زمانی استفاده می‌شود که پر کردن سری به‌صورت صریح تعریف نشده باشد. فراخوانی این متد تنها رنگ محاسبه‌شده را می‌خواند؛ پر شدن جدیدی را اختصاص نمی‌دهد.

مثال زیر رنگ خودکار هر سری پیش‌فرض را چاپ می‌کند:

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

خروجی نمونه برای سبک پیش‌فرض نمودار:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

رنگ‌های دقیق بستگی به سبک و تم نمودار دارد.

## **تنظیم رنگ پر کردن معکوس برای یک سری نمودار**

برای سری‌های میله، ستون و حباب، [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/invert_if_negative/) می‌تواند مقادیر منفی را با رنگ پر کردن متفاوتی نشان دهد. پر کردن عادی سری را به حالت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) اختصاص دهید. اعداد منفی در کتاب کار بدون تغییر می‌مانند؛ تنها رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف ۰ کاربرگ شامل نام سری، ستون ۰ شامل نام دسته‌ها و ستون ۱ شامل مقادیر است:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه خاص از طریق [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) معکوس‌سازی را فعال کنید. در مثال زیر، معکوس‌سازی برای سری غیرفعال و فقط برای نقطه انتخاب‌شده فعال می‌شود. نقطه نیز مقدار منفی دریافت می‌کند تا اثر قابل مشاهده باشد:

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

## **پاک‌سازی مقدار نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف بقیه نقاط، سلول پشتوانهٔ کتاب کار آن را به `None` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [ChartDataPoint.value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/value/) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات مقدار خالی نمودار به‌عنوان خالی در نظر می‌گیرد.

مثال زیر فقط دومین نقطه در اولین سری را پاک می‌کند:

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

نمودارهای پراکندگی از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حباب نیز یک سلول اندازه دارند. فقط سلولی را که نمایانگر مقدار مورد نظر برای حذف است پاک کنید. وقتی می‌خواهید نقاط دیگر را حفظ کنید، از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapointcollection/clear/) استفاده نکنید؛ این متد تمام نقاط دادهٔ مجموعه را حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که مقدار دارند موردی متفاوت نسبت به سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی کاربرگ، به [Include Data from Hidden Rows and Columns](/slides/fa/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی کتاب کار نشان‌دهنده دادهٔ گمشده است؛ یک سلول حاوی `0` نشان‌دهنده مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، [ChartDataCell.value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatacell/value/) را به `None` تنظیم کنید. صفر عددی صرفاً صفر می‌ماند، صرف‌نظر از تنظیمات سلول خالی.

از [Chart.display_blanks_as](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/display_blanks_as/) برای انتخاب نحوهٔ نمایش سلول‌های خالی توسط نمودار استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. این تنظیم نحوهٔ ترسیم خالی‌ها را تغییر می‌دهد بدون اینکه سلول خالی کتاب کار را با صفر یا مقدار درونی‌سازی پر کند.

مثال خودمحافظ زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز ۳ را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [ChartDataWorkbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/) از کاربرگ ۰، ستون ۰ برای برچسب‌های دسته و ستون ۱ برای مقادیر استفاده می‌کند؛ ردیف ۰ نام سری را نگه می‌دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    # روز ۳ را به‌طور واقعی خالی بگذارید، در حالی که دسته و نقطه دادهٔ آن را نگه می‌دارید.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

هر فایل خروجی حالت اختصاص‌یافته قبل از ذخیره‌سازی را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت موردنظر را تنظیم کنید و یک بار ارائه را ذخیره کنید به‌جای تکرار بر روی حالت‌ها.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در کتاب کار در هر حالت خالی است:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

اثر قابل‌مشاهده بستگی به نوع نمودار دارد. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای میله و ستونی خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین `SPAN` نمی‌تواند بخش اتصال نشان‑داده‌شده را تولید کند؛ یک ستون گمشده و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار پراکندگی فقط با نشانگرها خط اتصال ندارد. انتظار نتایج متفاوت برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصله سری**

عرض فاصله فضا بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. مشابه همپوشانی، این تنظیم به گروه سری والد تعلق دارد نه به یک سری. یک بار برای گروه [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) تنظیم کنید. مقدار بزرگ‌تر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آن‌ها را متراکم‌تر می‌کند.

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

![The gap width](gap_width.png)

## **FAQ**

**Which chart types support data series?**

همهٔ انواع نموداری که توسط شمارش‌گر [ChartType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/charttype/) نمایان می‌شوند از داده‌های نمودار استفاده می‌کنند، اما سری‌های آن‌ها ساختار مقدار یا تنظیمات یکسانی ندارند. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حباب اندازه حباب را اضافه می‌کنند. از روش ایجاد نقطه‑داده‌ای که با نوع سری مطابقت دارد استفاده کنید. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های میله یا ستون سازگار اعمال می‌شوند.

**What is a chart series group?**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری دسترسی پیدا می‌کنید لزوماً همهٔ سری‌های نمودار را تحت تأثیر قرار نمی‌دهد.

**Does a newly created chart contain default data?**

بله. به‌صورت پیش‌فرض، متد [ShapeCollection.add_chart](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_chart/) سری‌ها، دسته‌ها و مقادیر نمونه ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعهٔ دادهٔ کاملاً سفارشی، هر دو مجموعهٔ سری و دسته را پاک کنید. یک overload نیز امکان ایجاد نمودار بدون دادهٔ پیش‌فرض را فراهم می‌کند.

**How are chart objects connected to workbook cells?**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه‑داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/) ارجاع می‌دهند. تغییر سلول ارجاع‌شده عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت دادهٔ سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را طوری تنظیم کنید که هر نقطه زیر دستهٔ موردنظر رسم شود.

**How do I clear one point instead of the whole series?**

سلول مقدار مربوطه را به `None` تنظیم کنید تا موقعیت دستهٔ نقطه به عنوان یک نقطهٔ خالی حفظ شود. از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapointcollection/clear/) فقط زمانی استفاده کنید که قصد حذف تمام نقاط از آن سری را داشته باشید. اگر دسته‌ها را نیز حذف می‌کنید، هر سری را به‌روز کنید تا مقادیرشان با مجموعهٔ دسته‌ها هم‌راستا بماند.

**How are empty points displayed?**

نتیجه وابسته به نوع نمودار و [Chart.display_blanks_as](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/display_blanks_as/) است. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنی دادهٔ گمشده در ارائهٔ شما مطابقت دارد. برای مثال کامل و مقایسهٔ تصویری به بخش [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**How are negative values formatted?**

برای سری‌های میله، ستون و حباب پشتیبانی‌شده، [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/invert_if_negative/) را فعال کنید و [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) بازنویسی کنید. این ویژگی‌ها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**Which formatting wins when both a series and a point are formatted?**

قالب‌بندی صریح نقطه‑داده برای آن نقطه برتری دارد. سایر نقاط به قالب‌بندی صریح سری یا، وقتی قالب‌بندی سری تعریف نشده باشد، به سبک و تم خودکار نمودار ادامه می‌دهند. ویژگی‌های گروهی مانند همپوشانی و عرض فاصله مرتبط با چیدمان هستند و جایگزین‌های سطح نقطه نیستند.

**Is there a limit to how many series a chart can contain?**

Aspose.Slides محدودیت شمار ثابت برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد معقول هستند.

**What should I change when columns are too close together or too far apart?**

[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) را در گروه سری والد مناسب تنظیم کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها گسترده شود یا کاهش دهید تا خوشه‌ها به‌یکدیگر نزدیک‌تر شوند.