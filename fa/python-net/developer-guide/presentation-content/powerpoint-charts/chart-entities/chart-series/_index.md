---
title: مدیریت سری‌های دادهٔ نمودار در ارائه‌ها با پایتون
linktitle: سری‌های داده
type: docs
url: /fa/python-net/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- رنگ دسته‌بندی
- نام سری
- نقطه داده
- فاصله سری
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با پایتون مدیریت کنید."
---
## **بررسی کلی**

یک نمودار می‌تواند مقادیر ترسیم‌شده خود را در سلول‌های کتاب کار یا به‌صورت عددی ثابت ذخیره کند. یک [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) یک مجموعه از مقادیر مرتبط را نشان می‌دهد و هر [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) یک نقطه در آن مجموعه را نمایان می‌کند. اشیاء [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک توسط مجموعه‌ها را فراهم می‌آورند. در نمودارهایی که با داده‌های پیش‌فرض ایجاد می‌شوند، نام‌های مجموعه، دسته‌بندی‌ها و مقادیر نقاط از اشیاء [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) کتاب کار نمودار استفاده می‌کنند.

برای یک نمودار دسته‌ای معمولی، کتاب کار پیش‌فرض ردیف 0 را برای نام‌های مجموعه، ستون 0 را برای نام‌های دسته‌بندی و بقیهٔ سلول‌ها را برای مقادیر مجموعه استفاده می‌کند. اندیس‌های Worksheet، row و column که به ‎[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/)‎ پاس داده می‌شوند صفر‑محور هستند. این طرح‌بندی زمانی مفید است که نموداری با داده‌های پیش‌فرض ایجاد می‌کنید، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب کار، سلول‌های اشاره شده توسط مجموعه‌ها، دسته‌بندی‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه دامنه متفاوت هستند:

- تنظیمات سطح مجموعه، مانند [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)، ظاهر پیش‌فرض تمام نقاط در یک مجموعه را فراهم می‌کند.
- تنظیمات نقطه داده، مانند [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی برای مجموعه‌های سازگاری که به همان [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله، از ‎[ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/)‎ استفاده کنید.

زمانی که پرکنندهٔ صریح نقطه یا مجموعه‌ای تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم نقطه موجود باشد، تنظیمات نقطه برای آن نقطه اولویت دارد.

![نمودار سری‌ها در پاورپوینت](chart-series-powerpoint.png)

## **تنظیم مقادیر مجموعه با استفاده از عددهای ثابت**

از عددهای ثابت زمانی استفاده کنید که مقادیر مجموعه از داده یا محاسبهٔ برنامه می‌آیند و نیازی به ارجاع به سلول‌های Worksheet ندارند. قبل از اختصاص هر ‎[value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/)‎ نقطه از طریق ‎[as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/)‎، ‎[data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/)‎ را به ‎[DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/)‎ تنظیم کنید.

تنظیم مجموعه منبع تمام مقادیر نقاط در آن مجموعه را کنترل می‌کند. ‎[value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/)‎ هر نقطه، نوع انتخاب‌شده را گزارش می‌دهد؛ آن را از طریق تنظیم مجموعه تغییر دهید. با ‎`WORKSHEET`‎، برای دسترسی به سلول ارجاع‌داده‌شده از ‎[as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/)‎ استفاده کنید. با ‎`DOUBLE_LITERALS`‎، با استفاده از ‎`as_literal_double`‎ عدد را به‌صورت مستقیم بخوانید یا بنویسید.

مثال زیر یک نمودار ستونی با مجموعه‌ها و دسته‌بندی‌های پیش‌فرض ایجاد می‌کند، سپس مقادیر محاسبه شدهٔ ۱۰، ۲۰ و غیره را به نقاط موجود اولین مجموعه اختصاص می‌دهد. سپس ارائه را ذخیره، باز می‌کند و مقادیر ذخیره‌شده را چاپ می‌کند.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

نوع منبع مقدار نقطه جدا از ‎[ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)‎ است که پیکربندی کتاب کار داخلی یا خارجی نمودار را شناسایی می‌کند. استفاده از عددهای ثابت به‌تنهایی کتاب کار توکار را حذف نمی‌کند. در این مثال، کتاب کار برای برچسب‌های دسته‌بندی، نام‌های مجموعه و سایر مجموعه‌ها در دسترس باقی می‌ماند. برای مدیریت کتاب کار به ‎[کتاب کار نمودار](/slides/fa/python-net/chart-workbook/)‎ مراجعه کنید.

برای نمودارهای پراکنده و حبابی، ‎[data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/)‎ و ‎[data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/)‎ را تنظیم کنید تا منابع ‎[x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/)‎ و ‎[y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/)‎ را انتخاب کنید. نمودارهای حبابی همچنین از ‎[data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/)‎ برای ‎[bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/)‎ استفاده می‌کنند. هر منبع قابل اعمال را قبل از اختصاص اعداد از طریق ویژگی ‎`as_literal_double`‎ به ‎`DOUBLE_LITERALS`‎ تنظیم کنید.

## **تنظیم همپوشانی مجموعه‌های نمودار**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) نشان می‌دهد که چقدر نوارها یا ستون‌ها در یک نمودار دو‑بعدی با یکدیگر همپوشانی دارند، از ‑۱۰۰ تا ۱۰۰ درصد. این یک پیش‌بینی فقط‑خواندنی از تنظیمات در گروه والد مجموعه است. برای به‌روزرسانی همهٔ مجموعه‌های سازگار در آن گروه، ‎[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/)‎ را تنظیم کنید. این گزینه برای انواع نمودارهایی که نوارها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ برای گروه‌های مجموعهٔ نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر همپوشانی گروهی که حاوی اولین مجموعه است تنظیم می‌کند:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # نمودار جدید شامل مجموعه‌های نمونه، دسته‌بندی‌ها و مقادیر است.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![همپوشانی مجموعه‌ها](series_overlap.png)

## **تغییر رنگ پرکننده مجموعه**

از ‎[ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)‎ برای تنظیم پرکنندهٔ پیش‌فرض یک مجموعه کامل استفاده کنید. اگر یک نقطه قبلاً پرکنندهٔ صریح داشته باشد، تنظیم ‎[ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)‎ آن، پرکنندهٔ مجموعه را برای آن نقطه بازنویسی می‌کند.

مثال زیر پرکنندهٔ آبی ثابت را به اولین مجموعه اعمال می‌کند:

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

نام یک مجموعه در کتاب کار دادهٔ نمودار ذخیره می‌شود و به‌طور معمول در افسانه نمایش داده می‌شود. در کتاب کار پیش‌فرض ایجاد‌شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را شامل می‌شود. ثابت‌های نام‌گذاری در مثال زیر این ساختار را به‌وضوح نشان می‌دهند:

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

همچنین می‌توانید سلولی که توسط ‎[ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/)‎ ارجاع داده شده است به‌روزرسانی کنید. این رویکرد از فرض یک ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

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

### **ایجاد مجموعه‌ای با نامی از چندین سلول**

یک نام ترکیبی برای مجموعه زمانی مفید است که نام محصول و دورهٔ گزارش در سلول‌های جداگانه‌ای از کتاب کار ذخیره شوند. به‌عنوان مثال می‌توانید `Product A` در B1 و `2026` در C1 را به یک نام مجموعه ترکیبی ترکیب کنید در حالی که هر دو بخش به سلول‌های منبع خود پیوند دارند.

از ‎[ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/)‎ برای بازیابی بازهٔ نام استفاده کنید، سپس آن مجموعه را به ‎[ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/)‎ پاس دهید. آرگومان ‎`skip_hidden_cells`‎ تعیین می‌کند که آیا سلول‌های پنهان شامل شوند یا نه: ‎`True`‎ آن‌ها را حذف می‌کند، در حالی که ‎`False`‎ آن‌ها را شامل می‌شود. این مثال از ‎`False`‎ برای شامل کردن تمام سلول‌های بازهٔ نام استفاده می‌کند.

مثال زیر یک ارائه با یک مجموعه و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام مجموعه را تأمین می‌کنند؛ A2:A3 برچسب‌های دسته‌بندی را تأمین می‌کنند و B2:B3 مقادیر عددی را فراهم می‌کنند.

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

    # این دو سلول نام سری را فراهم می‌کنند.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # سلول‌های جداگانه دسته‌بندی‌ها و نقاط داده عددی را فراهم می‌کنند.
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

نام مجموعه حاصل `Product A 2026` است، با یک فاصله بین دو مقدار سلولی. افسانه این را به‌عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر از ارائهٔ ذخیره شده رندر شده است:

![نمودار ستونی با مقادیر شمال و جنوب و نام ترکیبی مجموعه Product A 2026 در افسانه](composite_series_name.png)

## **دریافت رنگ پرکننده خودکار مجموعه**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) رنگی را برمی‌گرداند که بر اساس شمارهٔ مجموعه و سبک نمودار محاسبه می‌شود. این همان رنگی است که هنگامی که پرکنندهٔ مجموعه به‌صورت صریح تعریف نشده باشد استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ مقدار جدیدی برای پرکننده اختصاص نمی‌دهد.

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

رنگ‌های دقیق به سبک و تم نمودار بستگی دارند.

## **تنظیم رنگ پرکننده معکوس برای یک مجموعه نمودار**

برای مجموعه‌های میله، ستون و حباب، ‎[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/)‎ می‌تواند مقادیر منفی را با پرکننده‌ای متفاوت نمایش دهد. پرکنندهٔ معمولی مجموعه را به‌صورت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق ‎[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)‎ اختصاص دهید. اعداد منفی در کتاب کار به همان صورت می‌مانند؛ فقط رنگ نمایش آنها تغییر می‌کند.

مثال زیر دادهٔ پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 Worksheet نام مجموعه را دارد، ستون 0 نام‌های دسته‌بندی و ستون 1 مقادیر را دارد:

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

![رنگ پرکننده ثابت معکوس‌شده](inverted_solid_fill_color.png)

می‌توانید معکوس‌سازی را برای یک نقطه از طریق ‎[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)‎ فعال کنید. در مثال زیر، معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطهٔ منتخب فعال است. نقطه نیز مقدار منفی اختصاص یافته تا اثر مشاهده شود:

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

برای خالی کردن یک نقطه بدون حذف سایر نقاط، سلول کتاب کار پشتیبان آن را به ‎`None`‎ تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق ‎[ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/)‎ در دسترس است. نقطه داده در همان موقعیت دسته‌بندی می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی مطابق تنظیمات خالی‌سازی نمودار در نظر می‌گیرد.

مثال زیر فقط نقطه دوم در اولین مجموعه را پاک‌سازی می‌کند:

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

نمودارهای پراکنده از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حبابی نیز از سلول اندازه استفاده می‌کنند. فقط سلولی را که نمایانگر مقدار مورد نظر برای حذف است پاک کنید. هنگام نیاز به نگه‌داشتن سایر نقاط، از ‎[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)‎ استفاده نکنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که حاوی مقادیر هستند موردی جداگانه نسبت به سلول‌های خالی‌اند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی Worksheet، به ‎[شامل کردن داده‌ها از ردیف‌ها و ستون‌های پنهان](/slides/fa/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)‎ مراجعه کنید.

یک سلول خالی کتاب کار نشان‌دهندهٔ دادهٔ مفقود است؛ سلولی که `0` دارد نشان‌دهندهٔ مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، ‎[ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/)‎ را به ‎`None`‎ تنظیم کنید. عدد صفر عددی باقی می‌ماند صرف‌نظر از تنظیم خالی‌سازی سلول.

از ‎[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)‎ برای انتخاب نحوهٔ نمایش سلول‌های خالی در نمودار استفاده کنید. این تنظیم برای تمام نمودار اعمال می‌شود. نحوهٔ ترسیم خالی‌ها را بدون پر کردن سلول خالی با صفر یا مقدار درون‌یابی‌شده تغییر می‌دهد.

مثال خودمحافظ زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز ۳ را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. ‎[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)‎ از Worksheet 0، ستون 0 برای برچسب‌های دسته‌بندی و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

    # روز ۳ را به‌طور واقعی خالی بگذارید، در حالی که دسته‌بندی و نقطه دادهٔ آن را نگه می‌دارید.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

هر فایل خروجی حالت اختصاص داده‌شده پیش از ذخیره را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت دلخواه را تنظیم کنید و یک‌بار ارائه را ذخیره کنید به جای تکرار بر روی حالت‌ها.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در کتاب کار در هر حالت خالی است:

![نمودارهای خطی با داده‌های یکسان: Gap خط را در روز ۳ قطع می‌کند، Zero خط را به صفر می‌کشاند و Span روز ۲ را به روز ۴ وصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی تمام سه حالت را به راحتی مقایسه می‌کند. نمودارهای میله و ستونی خطی برای وصل کردن بین یک دسته‌ی مفقود ندارند، بنابراین ‎`SPAN`‎ نمی‌تواند قطعهٔ متصل نشان داده‌شده در بالا را تولید کند؛ یک ستون مفقود و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به نظر برسند. به‌طور مشابه، یک نمودار پراکنده فقط با نشانگرها خطی برای اتصال ندارد. انتظار نتایج سه‌گانه متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصله مجموعه**

عرض فاصله، فضا بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. همانند همپوشانی، به‌جای یک مجموعه، به گروه والد مجموعه تعلق دارد. برای گروه یک‌بار ‎[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)‎ را تنظیم کنید. مقدار بزرگ‌تر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آن‌ها را متراکم‌تر می‌سازد.

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

## **پرسش‌های متداول**

**کدام انواع نمودار از مجموعه داده پشتیبانی می‌کنند؟**

تمامی انواع نمودار که توسط ‎[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‎ نشان داده می‌شوند از داده‌های نمودار استفاده می‌کنند، اما مجموعه‌های آن‌ها ساختار یا تنظیمات مقدار یکسانی ندارند. برای مثال، نمودارهای دسته‌ای از دسته‌بندی‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حبابی از اندازهٔ حباب. از روش ایجاد نقطه داده‌ای استفاده کنید که با نوع مجموعه مطابقت دارد. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های میله یا ستونی سازگار اعمال می‌شوند.

**یک گروه مجموعهٔ نمودار چیست؟**

یک ‎[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/)‎ شامل مجموعه‌های سازگاری است که تنظیمات ترسیم در سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی پیدا می‌کنید لزوماً همهٔ مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‌ساخته‌شده داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، ‎[ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/)‎ مجموعه‌ها، دسته‌بندی‌ها و مقادیر نمونه ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه و دسته‌بندی‌ها را پاک کنید. یک overload نیز می‌تواند نموداری بدون داده پیش‌فرض ایجاد کند.

**چگونه اشیای نمودار به سلول‌های کتاب کار متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته‌بندی و مقادیر نقطه داده به سلول‌های یک ‎[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)‎ ارجاع می‌دهند. تغییر یک سلول ارجاعی، عنصر مربوطهٔ نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته‌بندی و ردیف‌های مقدار مجموعه را هم‌راستا نگه دارید تا هر نقطه زیر دسته‌بندی موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای تمام مجموعه پاک‌کنم؟**

سلول مقدار مربوطه را به ‎`None`‎ تنظیم کنید تا موقعیت دسته‌بندی نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط زمانی که می‌خواهید تمام نقاط یک مجموعه حذف شوند، از ‎[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)‎ استفاده کنید. اگر دسته‌بندی‌ها را نیز حذف می‌کنید، هر مجموعه را به‌گونه‌ای به‌روز کنید که مقادیر آن با مجموعه دسته‌بندی‌ها هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و ‎[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)‎ بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، به‌عنوان مقدار صفر یا با وصل کردن نقاط مجاور نمایش دهند. تنظیمی را انتخاب کنید که با معنی دادهٔ گمشده در ارائهٔ شما مطابقت داشته باشد. برای مثال کامل و مقایسهٔ بصری به ‎[کنترل نمایش سلول‌های خالی](#control-the-display-of-empty-cells)‎ مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های میله، ستون و حباب پشتیبانی‌شده، ‎[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/)‎ را فعال کنید و ‎[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)‎ را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ فردی با ‎[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)‎ بازنویسی کنید. این ویژگی‌ها تنها قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**زمانی که هم مجموعه و هم نقطه قالب‌بندی شوند، کدام یک برتری دارد؟**

قالب‌بندی صریح نقطه داده برای آن نقطه اولویت دارد. سایر نقاط همچنان از قالب صریح مجموعه یا، هنگامی که قالب مجموعه تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. ویژگی‌های گروهی مانند همپوشانی و عرض فاصله کنترل چیدمان هستند و بازنویسی قالب‌بندی سطح نقطه ندارند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت شمارشی ثابت جداگانه‌ای برای مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه در دسترس، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد قابل استفاده هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا دور از یکدیگر هستند؟**

‎[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)‎ را در گروه والد مناسب تنظیم کنید. مقدار را برای گسترش فضا بین خوشه‌ها افزایش دهید یا برای نزدیک‌تر شدن خوشه‌ها کاهش دهید.