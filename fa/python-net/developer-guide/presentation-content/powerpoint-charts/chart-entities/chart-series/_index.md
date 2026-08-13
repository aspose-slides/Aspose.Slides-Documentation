---
title: مدیریت مجموعه داده‌های نمودار در ارائه‌ها با پایتون
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
- Python
- Aspose.Slides
description: "چگونه مجموعه‌های نمودار، نقاط داده، سلول‌های کارنامه، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با پایتون مدیریت کنید."
---
## **بررسی کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کارنامه داده نمودار (chart data workbook) ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/) نمایان‌گر یک مجموعه از مقادیر مرتبط است و هر [ChartDataPoint](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/) در این مجموعه به یک یا چند سلول کارنامه اشاره می‌کند. اشیاء [ChartCategory](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌آورند. نام مجموعه، دسته‌ها و مقادیر نقاط بنابراین به اشیاء [ChartDataCell](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatacell/) متصل هستند و فقط به‌عنوان متن نمایشی ذخیره نمی‌شوند.

برای یک نمودار دسته‌ای معمولی، کارنامه پیش‌فرض ردیف 0 را برای نام‌های مجموعه، ستون 0 را برای نام‌های دسته، و بقیه سلول‌ها را برای مقادیر مجموعه استفاده می‌کند. اندیس‌های کاربرگ، ردیف و ستون که به [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) پاس داده می‌شوند، صفر‑مبنایی هستند. این قالب زمانی مفید است که نمودار را با داده‌های پیش‌فرض ایجاد می‌کنید، اما فرض نکنید هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، سلول‌های ارجاع‌شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را قبل از تغییر مقادیر کارنامه بررسی کنید.

تنظیمات نمودار در سه دامنه مختلف هستند:

- تنظیمات در سطح مجموعه، مانند [ChartSeries.format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/format/)، ظاهر پیش‌فرض همه نقاط یک مجموعه را تعیین می‌کند.
- تنظیمات نقطه داده، مانند [ChartDataPoint.format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/format/)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی بر مجموعه‌های سازگاری که به همان [ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/) تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی مانند overlap یا gap width، از [ChartSeries.parent_series_group](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/parent_series_group/) استفاده کنید.

زمانی که پر کردن صریح یک نقطه یا مجموعه تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم نقطه موجود باشد، تنظیمات نقطه برای آن نقطه اولویت دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم Overlap مجموعه نمودار**

[ChartSeries.overlap](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/overlap/) گزارش می‌دهد که نوارها یا ستون‌ها تا چه حد در یک نمودار 2D هم‌پوشانی دارند؛ مقدار بین -100 تا 100 درصد است. این یک پیش‌بینی فقط‑خواندنی از تنظیمات در گروه مجموعه والد است. برای به‌روزرسانی تمام مجموعه‌های سازگار در آن گروه، [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/overlap/) را تنظیم کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی نمایش می‌دهند، اعمال می‌شود؛ در نمودار ترکیبی که گروه‌های غیرمرتبط وجود دارد، تأثیری ندارد.

مثال زیر overlap را برای گروهی که شامل اولین مجموعه است، تنظیم می‌کند:

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

![The series overlap](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از [ChartSeries.format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/format/) برای تنظیم پر کردن پیش‌فرض کل یک مجموعه استفاده کنید. اگر برای یک نقطه پر کردن صریحی تعریف شده باشد، تنظیمات [ChartDataPoint.format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/format/) آن نقطه، پر کردن مجموعه را برای همان نقطه بازنویسی می‌کند.

مثال زیر پر کردن ثابت آبی را برای اولین مجموعه اعمال می‌کند:

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

## **تغییر نام مجموعه**

نام یک مجموعه در کارنامه داده نمودار ذخیره می‌شود و به‌طور معمول در افسانه (legend) نمایش داده می‌شود. در کارنامه پیش‌فرض ساخته‌شده برای یک نمودار ستون خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را شامل می‌شود. ثابت‌های نام‌گذاری در مثال زیر این ساختار را به‌صورت صریح نشان می‌دهند:

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

همچنین می‌توانید سلولی که توسط [ChartSeries.name](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/name/) ارجاع داده شده است، به‌روزرسانی کنید. این روش از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

## **دریافت رنگ پر کردن خودکار مجموعه**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) رنگ محاسبه‌شده بر پایهٔ اندیس مجموعه و سبک نمودار را برمی‌گرداند. این همان رنگی است که وقتی پر کردن مجموعه به‌صورت صریح تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی اختصاص نمی‌دهد.

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

خروجی نمونه برای سبک پیش‌فرض نمودار:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

رنگ‌های دقیق بستگی به سبک و تم نمودار دارند.

## **تنظیم رنگ پر کردن معکوس برای یک مجموعه نمودار**

برای مجموعه‌های نوار، ستون و حباب، [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/invert_if_negative/) می‌تواند مقادیر منفی را با پر کردن متفاوت نشان دهد. پر کردن معمولی مجموعه را به حالت ثابت (solid) تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) اختصاص دهید. اعداد منفی در کارنامه تغییری نمی‌کنند؛ فقط رنگ نمایششان تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 کاربرگ شامل نام مجموعه، ستون 0 شامل نام‌های دسته و ستون 1 شامل مقادیر است:

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

می‌توانید معکوس‌سازی را برای یک نقطه از طریق [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) فعال کنید. در مثال زیر، معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب شده فعال می‌شود. این نقطه همچنین مقدار منفی دریافت می‌کند تا اثر قابل مشاهده باشد:

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

## **پاک‌سازی مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتیبان کارنامه آن را به `None` تنظیم کنید. برای یک نمودار ستون، مقدار ترسیم‌شده از طریق [ChartDataPoint.value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/value/) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات مقدار خالی نمودار به‌عنوان خالی در نظر می‌گیرد.

مثال زیر تنها نقطه دوم در اولین مجموعه را پاک می‌کند:

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

نمودارهای پراکنده از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حبابی نیز از یک سلول اندازه استفاده می‌کنند. فقط سلولی را که نمایانگر مقداری است که می‌خواهید حذف کنید، پاک کنید. هنگام نیاز به نگه داشتن نقاط دیگر، از فراخوانی [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapointcollection/clear/) خودداری کنید؛ این متد تمام نقاط را از مجموعه حذف می‌کند.

## **تنظیم عرض فاصله (Gap Width) مجموعه**

عرض فاصله (gap width) فضای بین خوشه‌های نوار یا ستون مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه overlap، این تنظیم به گروه مجموعه والد تعلق دارد نه به یک مجموعه منفرد. برای گروه یک‌بار [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) را تنظیم کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را فشرده‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائه نهایی را ذخیره می‌کند:

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

## **سوالات متداول**

**کدام انواع نمودار از سری‌های داده پشتیبانی می‌کنند؟**

تمام انواع نمودارهای نشان داده‌شده توسط enumeration [ChartType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/charttype/) از داده‌های نمودار استفاده می‌کنند، اما ساختار یا تنظیمات ارزش‌های آن‌ها یکسان نیست. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حبابی اندازه حباب‌ها را اضافه می‌کنند. از روش ایجاد نقطه داده‌ای که با نوع مجموعه مطابقت دارد، استفاده کنید. گزینه‌هایی مانند overlap و gap width فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**یک گروه مجموعه نمودار چیست؟**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات رسم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی پیدا می‌کنید، لزوماً تمام مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‌ساخته شامل داده‌های پیش‌فرض است؟**

بله. به‌صورت پیش‌فرض، [ShapeCollection.add_chart](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_chart/) مجموعه‌های نمونه، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید آن سلول‌ها را ویرایش کنید یا هر دو مجموعه و دسته را قبل از افزودن مجموعه دادهٔ کاملاً سفارشی پاک کنید. یک overload نیز می‌تواند نمودار را بدون داده‌های پیش‌فرض ایجاد کند.

**چگونه اشیای نمودار به سلول‌های کارنامه متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را طوری هم‌راستا کنید که هر نقطه تحت دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `None` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط وقتی می‌خواهید تمام نقاط یک مجموعه را حذف کنید، از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapointcollection/clear/) استفاده کنید؛ این متد تمام نقاط را از مجموعه حذف می‌کند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و [Chart.display_blanks_as](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/display_blanks_as/) وابسته است. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، به‌عنوان مقدار صفر یا با اتصال نقاط مجاور نمایش دهند. تنظیمی را انتخاب کنید که معنای داده‌های فقدان‌دار در ارائهٔ شما باشد.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های نوار، ستون و حباب پشتیبانی‌شده، [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/invert_if_negative/) را فعال کنید و [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) بازنویسی کنید. این ویژگی‌ها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**وقتی هم مجموعه و هم نقطه قالب‌بندی شوند، کدام یک برتری دارد؟**

قالب‌بندی صریح نقطه داده برای همان نقطه اولویت دارد. نقاط دیگر همچنان از قالب صریح مجموعه یا، اگر قالب مجموعه تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. ویژگی‌های گروهی مانند overlap و gap width کنترل چیدمان را بر عهده دارند و بازنویسی‌های سطح‑نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه در دسترس، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد معقولی هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها خیلی نزدیک یا خیلی دور هستند؟**

[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) را در گروه مجموعهٔ والد مناسب تنظیم کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها بیشتر شود یا کاهش دهید تا خوشه‌ها به‌یکدیگر نزدیک‌تر شوند.