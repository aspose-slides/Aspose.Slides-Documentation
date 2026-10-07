---
title: مدیریت سیرهای داده‌ای نمودار در ارائه‌ها با پایتون
linktitle: سیرهای داده‌ای
type: docs
url: /fa/python-net/chart-series/
keywords:
- سیرهای نمودار
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
description: "یاد بگیرید چگونه سیرهای نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با پایتون مدیریت کنید."
---
## **مرور کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده‌های نمودار ذخیره می‌کند. یک [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) یک مجموعه مقادیر مرتبط را نشان می‌دهد و هر [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) در این مجموعه به یک یا چند سلول کتاب‌کار ارجاع می‌دهد. اشیاء [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌کنند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقطه‌ها به اشیاء [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) متصل هستند نه اینکه فقط به‌عنوان متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض ردیف 0 را برای نام‌های سری، ستون 0 را برای نام‌های دسته و بقیه سلول‌ها را برای مقادیر سری استفاده می‌کند. شاخص‌های کاربرگ، ردیف و ستون که به [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) ارسال می‌شوند، صفر‑مبنا هستند. این چیدمان هنگام ایجاد یک نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار، سلول‌های ارجاع‌شده توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار سه حوزه متفاوت دارند:

- تنظیمات سطح سری، همانند [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)، ظاهر پیش‌فرض تمام نقاط در یک سری را فراهم می‌کند.
- تنظیمات نقطه‑داده، همانند [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)، ظاهر سری را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروه برای سری‌های سازگاری که به همان [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) تعلق دارند اعمال می‌شوند. زمانی که نیاز به تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله دارید، از [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) برای دسترسی به گروه استفاده کنید.

زمانی که هیچ پر کردن صریح برای نقطه یا سری تعیین نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. زمانی که هم پر کردن سری و هم پر کردن نقطه موجود باشد، پر کردن نقطه بر آن نقطه اولویت دارد.

![نمودار-سری-پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) میزان همپوشانی میله‌ها یا ستون‌ها را در یک نمودار دو بعدی از ‑100 تا 100 درصد گزارش می‌دهد. این مقدار یک تصویر فقط‑خواندنی از تنظیمات در گروه سری والد است. برای به‌روزرسانی همه سری‌های سازگار در آن گروه، [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) را تنظیم کنید. این گزینه برای انواع نموداری که میله‌ها یا ستون‌ها را به‌صورت گروهی نمایش می‌دهند اعمال می‌شود؛ برای گروه‌های سری نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

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

![همپوشانی سری‌ها](series_overlap.png)

## **تغییر رنگ پر کردن سری**

از [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) برای تنظیم پر کردن پیش‌فرض یک سری کامل استفاده کنید. اگر برای یک نقطه پر کردن صریحی تعیین شده باشد، تنظیم [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) آن، پر کردن سری را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر کردن آبی ثابت را برای اولین سری اعمال می‌کند:

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

![رنگ سری](series_color.png)

## **تغییر نام سری**

نام یک سری در کتاب‌کار داده‌های نمودار ذخیره می‌شود و به‌طور معمول در افسانه (legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد شده برای یک نمودار ستون خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را شامل می‌شود. ثابت‌های نام‌گذاری در مثال زیر این ساختار را صریح می‌کند:

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

همچنین می‌توانید سلول ارجاع‌شده توسط [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) را به‌روزرسانی کنید. این روش از فرض یک ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

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

![نام سری](series_name.png)

### **ایجاد سری با نامی از چندین سلول**

یک نام سری ترکیبی زمانی مفید است که نام محصول و دوره گزارش در سلول‌های جداگانه کتاب‌کار ذخیره شوند. برای مثال می‌توانید `Product A` در B1 و `2026` در C1 را به یک نام سری واحد ترکیب کنید در حالی که هر دو بخش به سلول‌های منبع خود پیوند دارند.

از [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) برای دریافت محدوده نام استفاده کنید، سپس آن مجموعه را به [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/) پاس دهید. آرگومان `skip_hidden_cells` تعیین می‌کند که آیا سلول‌های مخفی شامل شوند یا نه: `True` آنها را حذف می‌کند، در حالی که `False` آنها را شامل می‌شود. این مثال از `False` برای شامل کردن هر سلول در محدوده نام استفاده می‌کند.

مثال زیر یک ارائه با یک سری و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام سری را فراهم می‌کنند؛ A2:A3 برچسب‌های دسته را فراهم می‌کنند و B2:B3 مقادیر عددی را فراهم می‌کنند.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    #    این دو سلول نام سری را فراهم می‌کنند.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    #    سلول‌های جداگانه دسته‌ها و نقاط داده عددی را فراهم می‌کنند.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

نام سری حاصل `Product A 2026` است، با یک فاصله بین دو مقدار سلولی. افسانه این را به‌عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر از ارائه ذخیره‌شده رندر شده است:

![نمودار ستون با مقادیر شمال و جنوب و نام ترکیبی سری Product A 2026 در افسانه](composite_series_name.png)

## **دریافت رنگ پر کردن خودکار سری**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) رنگی را برمی‌گرداند که بر اساس اندیس سری و سبک نمودار محاسبه می‌شود. این همان رنگی است که وقتی پر کردن سری به‌صورت صریح تعریف نشده باشد استفاده می‌شود. فراخوانی متد فقط رنگ محاسبه‌شده را می‌خواند؛ رنگ جدیدی را اختصاص نمی‌دهد.

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

رنگ‌های دقیق بسته به سبک و تم نمودار متفاوت هستند.

## **تنظیم رنگ پر کردن معکوس برای یک سری نمودار**

برای سری‌های میله، ستون و حباب، [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) می‌تواند مقادیر منفی را با پر کردن متفاوتی نمایش دهد. پر کردن معمولی سری را به‌صورت ثابت تنظیم کنید، معکوس کردن را فعال کنید و رنگ مقدار منفی را از طریق [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) اختصاص دهید. اعداد منفی در کتاب‌کار بدون تغییر می‌مانند؛ فقط رنگ نمایش آنها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 کاربرگ نام سری را دارد، ستون 0 نام دسته‌ها و ستون 1 مقادیر را دارد:

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

![رنگ پر شدن ثابت معکوس](inverted_solid_fill_color.png)

می‌توانید معکوس کردن را برای یک نقطه از طریق [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) فعال کنید. در مثال زیر، معکوس برای سری غیرفعال و فقط برای نقطه انتخاب‌شده فعال شده است. همچنین به نقطه مقدار منفی اختصاص داده شده تا اثر قابل مشاهده باشد:

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

## **پاک کردن مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتیبان کتاب‌کار آن را به `None` تنظیم کنید. برای یک نمودار ستون، مقدار ترسیم‌شده از طریق [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) در دسترس است. نقطه داده همچنان در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات مقدار خالی نمودار به‌عنوان خالی در نظر می‌گیرد.

مثال زیر فقط نقطه دوم در اولین سری را پاک می‌کند:

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

نمودارهای پراکنده از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز از یک سلول اندازه استفاده می‌کنند. فقط سلولی را که نمایانگر مقدار مورد نظر برای حذف است پاک کنید. هنگام تمایل به نگه داشتن سایر نقاط، از فراخوانی [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) خودداری کنید؛ زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که دارای مقدار هستند موردی متفاوت نسبت به سلول‌های خالی هستند. برای گنجاندن یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی کاربرگ، به [Include Data from Hidden Rows and Columns](/slides/fa/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی در کتاب‌کار نمایانگر داده‌های گمشده است؛ سلولی که `0` دارد نمایانگر مقدار عددی شناخته‌شده‌ای است. برای خالی کردن یک سلول، مقدار [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) را به `None` تنظیم کنید. صفر عددی صرفاً صفر می‌ماند، صرف‌نظر از تنظیم سلول خالی.

از [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) برای انتخاب نحوه نمایش سلول‌های خالی توسط نمودار استفاده کنید. این تنظیم برای تمام نمودار اعمال می‌شود. این تنظیم تغییر می‌دهد که خلاها چگونه ترسیم شوند، بدون اینکه سلول خالی کتاب‌کار با صفر یا مقدار درون‌یابی پر شود.

مثال خودکفا زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز 3 را خالی می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. کتاب‌کار [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) از کاربرگ 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام سری را نگه می‌دارد. داده نهایی `10, 20, empty, 30, 40` است.

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

    # روز ۳ را واقعا خالی بگذارید، در حالی که دسته‌بندی و نقطه داده آن را نگه می‌دارید.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

هر فایل خروجی حالت اختصاص‑یافته قبل از ذخیره‌سازی را ذخیره می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیره تنها یک نسخه، حالت مطلوب را تنظیم کنید و یک بار ارائه را ذخیره کنید به‌جای تکرار بر روی حالت‌ها.

مقایسه زیر همان داده‌ها را در همهٔ سه فایل نشان می‌دهد. روز 3 در هر حالت در کتاب‌کار خالی است:

![نمودارهای خطی با داده‌های یکسان: Gap خط را در روز 3 قطع می‌کند، Zero خط را به صفر می‌کشاند و Span روز 2 را به روز 4 وصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای میله و ستون خطی برای وصل کردن نقاط از دست رفته ندارند، بنابراین `SPAN` نمی‌تواند بخش اتصال نشان‑داده‌شده در بالا را تولید کند؛ یک ستون گمشده و یک ستون با ارتفاع صفر نیز ممکن است مشابه به نظر برسند. به‌طور مشابه، یک نمودار پراکنده فقط با نشانگرها خط وصل‌کننده ندارند. انتظار نتایج سه‌گانه متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصله سری**

عرض فاصله فاصلۀ بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. مانند همپوشانی، این مقدار به گروه والد سری تعلق دارد نه به یک سری منفرد. برای گروه یک‌بار مقدار [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) را تنظیم کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را متراکم‌تر می‌کند.

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

## **سوالات متداول**

**کدام انواع نمودار از سری‌های داده پشتیبانی می‌کنند؟**

تمامی انواع نمودارهایی که توسط شمارش‌گر [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) نمایان می‌شوند از داده‌های نمودار استفاده می‌کنند، اما سری‌های آن‌ها همگی ساختار یا تنظیمات مقدار یکسانی ندارند. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حباب اندازه حباب را اضافه می‌کنند. از روش ایجاد نقطه‑داده‌ای که با نوع سری مطابقت دارد استفاده کنید. گزینه‌هایی مانند همپوشانی و عرض فاصله تنها برای گروه‌های میله یا ستون سازگار اعمال می‌شوند.

**گروه سری نمودار چیست؟**

یک [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم در سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروه دسترسی‑یافته از طریق یک سری لزوماً همهٔ سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه ایجاد شده دارای داده‌های پیش‌فرض است؟**

بله. به‌طور پیش‌فرض، [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) سری‌ها، دسته‌ها و مقادیر نمونه ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه سری و دسته را پاک کنید. یک بارگذاری‑پذیر (overload) می‌تواند نموداری بدون داده پیش‌فرض نیز ایجاد کند.

**اشیاء نمودار چگونه به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقاط داده به سلول‌های یک [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را هم‌ترازی کنید تا هر نقطه تحت دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای کل سری پاک کنم؟**

سلول مقدار مرتبط را به `None` تنظیم کنید تا موقعیت دسته نقطه به‌عنوان نقطهٔ خالی حفظ شود. از [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) فقط زمانی استفاده کنید که می‌خواهید تمام نقاط آن سری را حذف کنید. اگر دسته‌ها را نیز حذف می‌کنید، هر سری را به‌روزرسانی کنید تا مقادیرشان با مجموعه دسته‌ها هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه بستگی به نوع نمودار و [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) دارد. نمودارهای پشتیبانی‌شده می‌توانند خلاها را به‌عنوان فاصله، مقدار صفر یا اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای داده‌های گمشده در ارائهٔ شما را بازتاب دهد. برای مثال کامل و مقایسهٔ تصویری به بخش [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های میله، ستون و حباب پشتیبانی‌شده، [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) را فعال کنید و [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) بازنویسی کنید. این خصوصیات بر قالب‌بندی تأثیر می‌گذارند، نه بر مقادیر عددی ذخیره‌شده.

**وقتی هم سری و هم نقطه قالب‌بندی شوند، کدام برنده است؟**

قالب‌بندی صریح نقطه‑داده برای آن نقطه اولویت دارد. نقاط دیگر به‌صورت پیش‌فرض از قالب‌بندی صریح سری یا، وقتی قالب‌بندی سری تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. ویژگی‌های گروهی مانند همپوشانی و عرض فاصله بر چیدمان تأثیر می‌گذارند و بازنویسی قالب‌بندی در سطح نقطه نیستند.

**آیا برای تعداد سری‌های یک نمودار محدودیتی وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه‌ موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد معقول هستند.

**چه باید تغییر دهم وقتی ستون‌ها بیش از حد به‌هم نزدیک یا دورند؟**

[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) را در گروه سری والد مربوطه تنظیم کنید. مقدار را افزایش دهید تا فاصله بین خوشه‌ها عریض‌تر شود یا کاهش دهید تا خوشه‌ها به‌هم نزدیک‌تر شوند.