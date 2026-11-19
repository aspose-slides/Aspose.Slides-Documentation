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
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با پایتون مدیریت کنید."
---
## **بررسی کلی**

یک نمودار می‌تواند مقادیر ترسیم‌شده خود را در سلول‌های کتاب‌کار یا به‌صورت مقادیر عددی صریح ذخیره کند. یک [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) یک مجموعه از مقادیر مرتبط را نشان می‌دهد و هر [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) یک نقطه در آن مجموعه را نشان می‌دهد. اشیاء [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) برچسب‌ها یا مقادیر گروه‌بندی‌شده‌ای را که بین مجموعه‌ها مشترک است ارائه می‌دهند. در نمودارهایی که با داده‌های پیش‌فرض ساخته می‌شوند، نام‌های مجموعه، دسته‌ها و مقادیر نقاط از اشیاء [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) کتاب‌کار نمودار استفاده می‌کنند.

برای یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض از ردیف 0 برای نام‌های مجموعه، ستون 0 برای نام‌های دسته و بقیه سلول‌ها برای مقادیر مجموعه استفاده می‌کند. اندیس‌های ورق، ردیف و ستون که به ‎[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/)‎ پاس می‌شوند، صفر‑مبنا هستند. این قالب هنگام ایجاد نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار، سلول‌های مرجع توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه حوزه متفاوت هستند:

- تنظیمات سطح مجموعه، مانند ‎[ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)‎، ظاهر پیش‌فرض همه نقاط در یک مجموعه را فراهم می‌کند.
- تنظیمات نقطه‑داده، مانند ‎[ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)‎، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی برای مجموعه‌های سازگاری که به همان ‎[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/)‎ تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی همچون همپوشانی یا عرض فاصله، از ‎[ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/)‎ استفاده کنید.

وقتی پر کردن صریح برای نقطه یا مجموعه‌ای تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم تنظیمات نقطه موجود باشد، تنظیمات نقطه برتری دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

برای یک نمودار استوانه‌ای خوشه‌ای، نگاه کنید که چگونه ‎[changing the 3D series type or bar shape](/slides/fa/python-net/3d-chart/#change-the-3d-series-type-and-bar-shape)‎ بر اولین مجموعه تأثیر می‌گذارد.

## **تنظیم مقادیر مجموعه با مقادیر عددی صریح**

وقتی مقادیر مجموعه از داده‌های برنامه یا محاسبات می‌آیند و نیازی به ارجاع به سلول‌های ورق ندارند، از مقادیر عددی صریح استفاده کنید. قبل از اختصاص ‎[value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/)‎ برای هر نقطه، ‎[data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/)‎ را روی ‎[DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/)‎ قرار دهید و از ‎[as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/)‎ استفاده کنید.

تنظیم کلکسیون، نوع منبع تمام مقادیر نقاط در آن مجموعه را کنترل می‌کند. ‎[value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/)‎ هر نقطه نوع انتخاب‌شده را گزارش می‌دهد؛ آن را از طریق تنظیم کلکسیون تغییر دهید. با ‎`WORKSHEET`‎ از ‎[as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/)‎ برای دسترسی به سلول مرجع استفاده کنید. با ‎`DOUBLE_LITERALS`‎ از ‎`as_literal_double`‎ برای خواندن یا نوشتن مستقیم عدد استفاده کنید.

مثال زیر یک نمودار ستونی با مجموعه‌ها و دسته‌های پیش‌فرض ایجاد می‌کند، سپس مقادیر محاسبه‌شده 10، 20 و ادامهٔ آن را به نقاط موجود مجموعهٔ اول اختصاص می‌دهد. سپس ارائه را ذخیره، دوباره باز و مقادیر ذخیره‌شده را چاپ می‌کند.

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

منبع نوع مقدار نقطه جدا از ‎[ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)‎ است که پیکربندی کتاب‌کار داخلی یا خارجی نمودار را شناسایی می‌کند. استفاده از مقادیر عددی صریح به‌تنهایی کتاب‌کار توکار را حذف نمی‌کند. در این مثال، کتاب‌کار برای برچسب‌های دسته، نام‌های مجموعه و سایر مجموعه‌ها در دسترس باقی می‌ماند. برای مدیریت کتاب‌کار به ‎[Chart Workbook](/slides/fa/python-net/chart-workbook/)‎ مراجعه کنید.

برای نمودارهای پراکنده و حبابی، ‎[data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/)‎ و ‎[data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/)‎ را تنظیم کنید تا منابع ‎[x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/)‎ و ‎[y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/)‎ انتخاب شوند. نمودارهای حبابی همچنین از ‎[data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/)‎ برای ‎[bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/)‎ استفاده می‌کنند. هر منبع مربوطه را قبل از اختصاص اعداد به ‎`as_literal_double`‎ آن مقدار، روی ‎`DOUBLE_LITERALS`‎ قرار دهید.

## **تنظیم همپوشانی مجموعهٔ نمودار**

‎[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/)‎ مقدار همپوشانی میله‌ها یا ستون‌ها در یک نمودار دو‑بعدی را از ‎-100‎ تا ‎100‎ درصد گزارش می‌دهد. این یک پیش‌بینی فقط‑خواندنی از تنظیم در گروه‌پدر مجموعه است. برای به‌روزرسانی تمام مجموعه‌های سازگار در آن گروه، ‎[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/)‎ را تنظیم کنید. این گزینه برای انواع نمودارهایی که میله یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ بر گروه‌های مجموعهٔ نامرتبط در یک نمودار ترکیبی تأثیری ندارد.

مثال زیر همپوشانی گروهی که شامل اولین مجموعه است را تنظیم می‌کند:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # نمودار جدید شامل نمونه‌های مجموعه، دسته‌ها و مقادیر است.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The series overlap](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از ‎[ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)‎ برای تنظیم پر کردن پیش‌فرض کل یک مجموعه استفاده کنید. اگر نقطه‌ای پر کردن صریح داشته باشد، تنظیم ‎[ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)‎ آن، پر کردن مجموعه را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر کردن آبی صلب را به اولین مجموعه اعمال می‌کند:

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

نام یک مجموعه در کتاب‌کار دادهٔ نمودار ذخیره می‌شود و معمولاً در راهنمایی نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد‌شده برای یک نمودار ستونی خوشه‌ای، سلول ‎B1‎ (ردیف 0، ستون 1) نام اولین مجموعه را دارد. ثابت‌های نام‌گذاری در مثال زیر این ساختار را واضح می‌کند:

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

همچنین می‌توانید سلول مرجع توسط ‎[ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/)‎ را به‌روزرسانی کنید. این روش از فرض ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

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

### **ایجاد مجموعه‌ای با نام از چند سلول**

یک نام مجموعهٔ ترکیبی زمانی مفید است که نام محصول و دورهٔ گزارش در سلول‌های جداگانه کتاب‌کار ذخیره شوند. برای مثال می‌توانید ‎`Product A`‎ در ‎B1‎ و ‎`2026`‎ در ‎C1‎ را به یک نام مجموعه ترکیبی ترکیب کنید و هر دو قسمت به سلول‌های منبع خود مرتبط بمانند.

از ‎[ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/)‎ برای دریافت محدودهٔ نام استفاده کنید، سپس آن مجموعه را به ‎[ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/)‎ پاس دهید. آرگومان ‎`skip_hidden_cells`‎ تعیین می‌کند آیا سلول‌های مخفی شامل شوند یا نه: ‎`True`‎ آن‌ها را حذف می‌کند، ‎`False`‎ شامل می‌شود. این مثال از ‎`False`‎ برای شامل‌کردن تمام سلول‌ها در محدودهٔ نام استفاده می‌کند.

مثال زیر یک ارائه با یک مجموعه و دو نقطه داده ایجاد می‌کند. سلول‌های ‎B1:C1‎ فقط نام مجموعه را فراهم می‌کنند؛ ‎A2:A3‎ برچسب‌های دسته و ‎B2:B3‎ مقادیر عددی را فراهم می‌کنند.

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

    # این دو سلول نام مجموعه را فراهم می‌کنند.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # سلول‌های جداگانه دسته‌ها و نقاط دادهٔ عددی را فراهم می‌کنند.
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

نام مجموعهٔ نتیجۀ تولید شده ‎`Product A 2026`‎ است که بین دو مقدار سلولی یک فاصله دارد. راهنمایی آن را به‌عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر از ارائهٔ ذخیره‌شده رندر شده است:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **دریافت رنگ پر کردن خودکار مجموعه**

‎[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/)‎ رنگی را بر می‌گرداند که بر اساس اندیس مجموعه و سبک نمودار محاسبه می‌شود. این رنگ زمانی استفاده می‌شود که پر کردن مجموعه به‌صورت صریح تعریف نشده باشد. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی اختصاص نمی‌دهد.

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

رنگ‌های دقیق بسته به سبک و تم نمودار متفاوت است.

## **تنظیم رنگ پر کردن معکوس برای مجموعهٔ نمودار**

برای مجموعه‌های میله، ستون و حباب، ‎[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/)‎ می‌تواند مقادیر منفی را با یک پر کردن متفاوت نشان دهد. پر کردن معمولی مجموعه را به صورت صلب تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق ‎[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)‎ اختصاص دهید. اعداد منفی در کتاب‌کار تعیی‌ نشده می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر دادهٔ پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 ورق شامل نام مجموعه است، ستون 0 شامل نام‌های دسته و ستون 1 شامل مقادیر:

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

می‌توانید معکوس‌سازی را برای یک نقطهٔ خاص از طریق ‎[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)‎ فعال کنید. در مثال زیر، معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال است. نقطه همچنین مقدار منفی اختصاص یافته تا اثر قابل مشاهده باشد:

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

## **پاک کردن مقدار نقطهٔ دادهٔ خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتیبان کتاب‌کار آن را به ‎`None`‎ مقداردهی کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق ‎[ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/)‎ در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات مقدار خالی نمودار به‌عنوان خالی در نظر می‌گیرد.

مثال زیر فقط نقطهٔ دوم مجموعهٔ اول را پاک می‌کند:

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

نمودارهای پراکنده از سلول‌های جداگانهٔ X و Y استفاده می‌کنند و نمودارهای حبابی نیز از سلول اندازه استفاده می‌کنند. فقط سلول نمایانگر مقدار هدف را پاک کنید. برای حذف همه نقاط از یک مجموعه، ‎[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)‎ را صدا بزنید؛ این متد تمام نقاط را حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که مقدار دارند موردی متفاوت از سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی ورق، به ‎[Include Data from Hidden Rows and Columns](/slides/fa/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)‎ مراجعه کنید.

یک سلول خالی کتاب‌کار نشان‌دهنده دادهٔ گمشده است؛ یک سلول حاوی ‎`0`‎ نشان‌دهنده مقدار عددی شناخته‌شده است. برای خالی کردن سلول، ‎[ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/)‎ را به ‎`None`‎ تنظیم کنید. صفر عددی صرفاً صفر می‌ماند بدون توجه به تنظیم خالی‌سلول.

از ‎[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)‎ برای انتخاب نحوهٔ نمایش سلول‌های خالی استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود و نحوهٔ ترسیم خالی‌ها را تغییر می‌دهد بدون این‌که سلول کتاب‌کار را با صفر یا مقدار درون‌خطی پر کند.

مثال خود‑محافظ زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز ۳ را خالی می‌کند و هر حالت را ذخیره می‌کند. نیازی به فایل ورودی نیست. ‎[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)‎ از ورق 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را دارد. دادهٔ نهایی ‎`10, 20, empty, 30, 40`‎ است.

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

    # روز ۳ را به‌صورت واقعی خالی بگذارید، در حالی که دسته‌بندی و نقطه دادهٔ آن را حفظ می‌کنید.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

هر فایل خروجی حالت انتساب‑شده قبل از ذخیره را ذخیره می‌کند: ‎`empty_cells_Gap.pptx`‎، ‎`empty_cells_Zero.pptx`‎ و ‎`empty_cells_Span.pptx`‎. برای ذخیرهٔ تنها یک نسخه، حالت مطلوب را تنظیم کنید و یک‌بار ارائه را ذخیره کنید به جای تکرار بر روی حالت‌ها.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در هر حالت در کتاب‌کار خالی است:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی هر سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای میله و ستون خطی برای اتصال قسمت‌های گمشده ندارند، بنابراین ‎`SPAN`‎ نمی‌تواند قطعهٔ متصل‌شدهٔ بالا را تولید کند؛ یک ستون گمشده و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار پراکنده فقط نقطه‌ها دارد و خط وصل‌کننده‌ای وجود ندارد. انتظار نتایج سه‌گانه متفاوت برای هر نوع نمودار را نداشته باشید؛ خروجی نوع استفاده‌شده را بررسی کنید.

## **تنظیم عرض فاصلهٔ مجموعه**

عرض فاصله، فضای بین خوشه‌های میله یا ستونی مجاور است که به‌عنوان درصدی از عرض میله یا ستون بیان می‌شود. مانند همپوشانی، این تنظیم به گروه‌پدر مجموعه تعلق دارد نه به یک مجموعهٔ منفرد. ‎[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)‎ را یکبار برای گروه تنظیم کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را متراکم می‌کند.

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

## **نمایش یا مخفی‌سازی خطوط مجموعه**

خطوط مجموعه، بخش‌های مرتبط یک نمودار را به صورت بصری به هم متصل می‌کنند. برای نمایش یا مخفی‌سازی آن‌ها در نمودارهای میلهٔ پشته‌ای و OfPie پشتیبانی‌شده، از ‎[ChartSeriesGroup.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/has_series_lines/)‎ استفاده کنید. در نمودارهای میلهٔ پشته‌ای و ستونی دو‑بعدی، این خطوط مرزهای پشتهٔ متناظر را در میان دسته‌ها به‌هم متصل می‌کنند. در نمودارهای Pie of Pie و Bar of Pie، این خطوط نمودار اصلی را به نمودار ثانویه متصل می‌کنند. این تنظیم برای سایر انواع نمودارهای عمومی کاربردی نیست.

گروه را از طریق ‎[ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/)‎ دریافت کنید. این تنظیم برای تمام مجموعه‌ها در آن گروه اعمال می‌شود. ‎[ChartSeries.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/has_series_lines/)‎ فقط‑خواندنی است و تنظیمات گروه پدر را منعکس می‌کند؛ برای به‌روزرسانی آن، ویژگی گروه را تغییر دهید.

مثال زیر یک نمودار ‎[ChartType.PIE_OF_PIE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‎ با داده‌های پیش‌فرض ایجاد می‌کند، سپس همان نمودار را یک بار با خطوط مجموعه فعال و یک بار غیرفعال ذخیره می‌کند تا دو ارائه برای مقایسه تولید شود.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 400)
    series = chart.chart_data.series[0]
    series_group = series.parent_series_group

    series_group.has_series_lines = True
    presentation.save("series_lines_enabled.pptx", slides.export.SaveFormat.PPTX)

    series_group.has_series_lines = False
    presentation.save("series_lines_disabled.pptx", slides.export.SaveFormat.PPTX)
```

| خطوط مجموعه فعال | خطوط مجموعه غیرفعال |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| دو خط اصلی پای را به پای ثانویه متصل می‌کنند. | هر دو پای قابل مشاهده هستند، اما خطوط اتصال مخفی هستند. |

خطوط مجموعه با خطوط راهنما برای برچسب‌های داده، که برچسب‌ها را به نقاط داده متصل می‌کنند؛ خطوط شبکه که فواصل را روی محورهای نمودار نشان می‌دهند؛ و خطوط در نمودار خطی که مقادیر داده را نشان می‌دهند متفاوت هستند. این تنظیم آن‌ها را کنترل نمی‌کند.

## **سوالات متداول**

**کدام انواع نمودار از مجموعه‌های داده پشتیبانی می‌کنند؟**

همهٔ انواع نمودار که توسط ‎[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‎ تعریف شده‌اند از داده‌های نمودار استفاده می‌کنند، اما ساختار مقدار یا تنظیمات مجموعه‌های آن‌ها یکسان نیست. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y و نمودارهای حبابی از اندازه‌های حباب. روش ایجاد نقطه‑داده‌ای را انتخاب کنید که با نوع مجموعه مطابقت داشته باشد. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های میله یا ستون سازگار اعمال می‌شوند.

**گروه مجموعهٔ نمودار چیست؟**

یک ‎[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/)‎ شامل مجموعه‌های سازگاری است که تنظیمات ترسیم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروه دستیابی‌شده از طریق یک مجموعه لزوماً تمام مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‌ساخته شامل داده‌های پیش‌فرض می‌شود؟**

بله. به‌صورت پیش‌فرض، ‎[ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/)‎ مجموعه‌ها، دسته‌ها و مقادیر نمونه ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه و دسته‌ها را خالی کنید. یک بارگذاری دیگر می‌تواند نمودار را بدون داده‌های پیش‌فرض نیز ایجاد کند.

**نمودارها چگونه به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه‑داده به سلول‌های یک ‎[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)‎ ارجاع می‌دهند. تغییر سلول مرجع عنصر مربوط به نمودار را به‌روزرسانی می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را هم‌راستا نگه دارید تا هر نقطه زیر دستهٔ موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مربوطه را به ‎`None`‎ تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط زمانی ‎[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)‎ را فراخوانی کنید که می‌خواهید تمام نقاط آن مجموعه حذف شوند، زیرا این متد تمام نقاط مجموعه را پاک می‌کند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و ‎[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)‎ بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای دادهٔ گمشده در ارائهٔ شما را منعکس کند. برای مثال کامل و مقایسهٔ بصری به ‎[Control the Display of Empty Cells](#control-the-display-of-empty-cells)‎ مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های میله، ستون و حباب پشتیبانی‌شده، ‎[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/)‎ را فعال کنید و ‎[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)‎ را تنظیم کنید. می‌توانید رفتار یک نقطهٔ منفرد را با ‎[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)‎ بازنویسی کنید. این ویژگی‌ها فقط قالب‌بندی را تحت‌تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**در صورت وجود قالب‌بندی هم برای مجموعه و هم برای نقطه، کدام برنده می‌شود؟**

قالب‌بندی صریح نقطه‑داده برای آن نقطه برتری دارد. نقاط دیگر همچنان از قالب صریح مجموعه یا، در صورت عدم تعریف قالب مجموعه، از سبک و تم خودکار نمودار استفاده می‌کنند. ویژگی‌های گروهی مانند همپوشانی و عرض فاصله طرح‌بندی را کنترل می‌کنند و بازنویسی قالب‌بندی در سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیتی ثابت برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد عملی هستند.

**اگر ستون‌ها بیش از حد نزدیک یا دور باشند، چه کاری باید انجام دهم؟**

‎[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)‎ را در گروه‌پدر مناسب تنظیم کنید. مقدار را برای افزایش فاصله بین خوشه‌ها یا برای کاهش آن و نزدیک‌تر کردن خوشه‌ها تغییر دهید.