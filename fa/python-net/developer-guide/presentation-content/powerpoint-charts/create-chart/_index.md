---
title: ایجاد یا به‌روزرسانی نمودارهای ارائه پاورپوینت در پایتون
linktitle: ایجاد یا به‌روزرسانی نمودارها
type: docs
weight: 10
url: /fa/python-net/create-chart/
keywords:
- افزودن نمودار
- ایجاد نمودار
- ویرایش نمودار
- تغییر نمودار
- به‌روزرسانی نمودار
- نمودار پراکنده
- نمودار پای
- نمودار خطی
- نمودار درخت‌نقشه
- نمودار سهام
- نمودار جعبه‌ای و ویسکر
- نمودار قیفی
- نمودار خورشیدگرد
- نمودار هیستوگرام
- نمودار رادار
- نمودار چنددسته‌ای
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارها در ارائه‌های پاورپوینت با استفاده از Aspose.Slides برای پایتون از طریق .NET. افزودن، قالب‌بندی و ویرایش نمودارها با مثال‌های کد عملی در پایتون."
---
## **مرور کلی**

این مقاله راهنمایی جامع برای ایجاد و سفارشی‌سازی نمودارها با استفاده از Aspose.Slides برای Python از طریق .NET ارائه می‌دهد. شما یاد می‌گیرید چگونه به‌صورت برنامه‌نویسی یک نمودار را به اسلاید اضافه کنید، آن را با داده‌ها پر کنید و گزینه‌های قالب‌بندی مختلفی را اعمال کنید تا مطابق با نیازهای طراحی خاص شما باشد. در طول مقاله، مثال‌های کد دقیق هر گام را نشان می‌دهند، از مقداردهی اولیهٔ ارائه و شیء نمودار تا پیکربندی سری‌ها، محورها و افسانه‌ها. با پیروی از این راهنما، درک جامعی از ادغام تولید دینامیک نمودار در برنامه‌های Python خود به دست می‌آورید و فرآیند ایجاد ارائه‌های مبتنی بر داده را ساده‌سازی می‌کنید.

## **ایجاد نمودار**

نمودارها به افراد کمک می‌کنند تا داده‌ها را به سرعت تصور کرده و بینش‌هایی به دست آورند که ممکن است از یک جدول یا صفحه‌گسترده به‌وضوح نشان داده نشود.

**چرا نمودار ایجاد کنیم؟**

با استفاده از نمودارها می‌توانید:

* مقادیر زیاد داده را در یک اسلاید خلاصه یا فشرده کنید؛
* الگوها و روندهای داده را آشکار کنید؛
* جهت و مومنتوم داده را در طول زمان یا نسبت به یک واحد اندازه‌گیری خاص استنتاج کنید؛
* ناهنجاری‌ها، انحراف‌ها، خطاها و داده‌های بی‌معنی را شناسایی کنید؛
* داده‌های پیچیده را به‌صورت قابل‌فهم ارائه یا انتقال دهید.

در PowerPoint می‌توانید از عملکرد *Insert* برای ایجاد نمودارها استفاده کنید که قالب‌های متنوعی برای طراحی انواع مختلف نمودارها فراهم می‌کند. با Aspose.Slides می‌توانید هر دو نوع نمودارهای معمول (بر پایهٔ انواع رایج نمودار) و نمودارهای سفارشی را ایجاد کنید.

{{% alert color="info" title="Note" %}}
از شمارشگر [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) در ماژول [aspose.slides.charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) استفاده کنید. مقادیر این شمارشگر به انواع مختلف نمودارها مربوط می‌شوند.
{{% /alert %}}

### **ایجاد نمودارهای ستونی خوشه‌ای**

این مثال از [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) برای ایجاد یک نمودار ستونی خوشه‌ای که دو سری را در سه دسته مقایسه می‌کند، استفاده می‌کند. سری‌ها از پرکننده‌های قرمز و سبز استفاده می‌کنند و برچسب‌های جداگانه نام دسته‌ها، نام سری‌ها و مقادیر را نشان می‌دهند. شاخص برگه ۰ به اولین برگه در کارگردان کتاب‌کار نمودار اشاره دارد.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series[0]

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    series = chart.chart_data.series[1]

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 60)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The Clustered Column chart](clustered_column_chart.png)

### **ایجاد نمودارهای پراکندگی**

نمودارهای پراکندگی (که به‌عنوان نمودارهای scatter یا گراف‌های x‑y نیز شناخته می‌شوند) معمولاً برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

از نمودار پراکندگی زمانی استفاده کنید که:

* داده‌های عددی جفت‌دار داشته باشید؛
* دو متغیر داشته باشید که به‌خوبی با یکدیگر جفت می‌شوند؛
* بخواهید تعیین کنید آیا دو متغیر با هم مرتبط هستند یا خیر؛
* یک متغیر مستقل داشته باشید که برای یک متغیر وابسته چند مقدار دارد.

این مثال دو مجموعهٔ مقادیر x‑y را رسم می‌کند. سری اول از خطوط مستقیم با علامت‌گرهای ستاره‌ای استفاده می‌کند، در حالی که سری دوم از خطوط صاف با علامت‌گرهای دایره‌ای استفاده می‌کند؛ هر دو از یک [size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/size/) برابر ۱۰ استفاده می‌کنند. ویژگی [symbol](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/symbol/) شکل علامت‌گر را کنترل می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 1, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 1, 3, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    series = chart.chart_data.series[0]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 2, 3)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 2, 10)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    series = chart.chart_data.series[1]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 4, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 5, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The Scatter chart](scatter_chart.png)

### **ایجاد نمودارهای پای**

نمودارهای پای بهترین استفاده را برای نشان دادن رابطهٔ بخش‑به‑کل در داده‌ها دارند، به‌ویژه زمانی که داده‌ها شامل برچسب‌های دسته‌ای با مقادیر عددی باشند. با این حال، اگر داده‌های شما قسمت‌ها یا برچسب‌های زیادی داشته باشد، ممکن است بخواهید به‌جای آن از نمودار میله‌ای استفاده کنید.

این مثال یک نمودار پای با سه مقدار فصلی ایجاد می‌کند. هر برش دارای پرکننده و مرز سفارشی است و برچسب‌ها ترکیبی‌های مختلفی از مقادیر، درصدها و اطلاعات سری را نمایش می‌دهند. ویژگی [first_slice_angle](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/first_slice_angle/) اولین برش را در زاویای ۱۸۰ درجه آغاز می‌کند.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    category_cell = workbook.get_cell(0, 1, 0, "1st Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "2nd Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "3rd Qtr")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_pie_series(value_cell)

    chart.chart_data.series_groups[0].is_color_varied = True

    first_slice = series.data_points[0]
    first_slice.format.fill.fill_type = slides.FillType.SOLID
    first_slice.format.fill.solid_fill_color.color = draw.Color.cyan

    first_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    first_slice.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    first_slice.format.line.width = 3.0
    first_slice.format.line.style = slides.LineStyle.THIN_THICK
    first_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH

    second_slice = series.data_points[1]
    second_slice.format.fill.fill_type = slides.FillType.SOLID
    second_slice.format.fill.solid_fill_color.color = draw.Color.brown

    second_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    second_slice.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    second_slice.format.line.width = 3.0
    second_slice.format.line.style = slides.LineStyle.SINGLE
    second_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    third_slice = series.data_points[2]
    third_slice.format.fill.fill_type = slides.FillType.SOLID
    third_slice.format.fill.solid_fill_color.color = draw.Color.coral

    third_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    third_slice.format.line.fill_format.solid_fill_color.color = draw.Color.red
    third_slice.format.line.width = 2.0
    third_slice.format.line.style = slides.LineStyle.THIN_THIN
    third_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    first_label = series.data_points[0].label
    first_label.data_label_format.show_value = True

    second_label = series.data_points[1].label
    second_label.data_label_format.show_value = True
    second_label.data_label_format.show_legend_key = True
    second_label.data_label_format.show_percentage = True

    third_label = series.data_points[2].label
    third_label.data_label_format.show_series_name = True
    third_label.data_label_format.show_percentage = True

    series.labels.default_data_label_format.show_leader_lines = True

    chart.chart_data.series_groups[0].first_slice_angle = 180

    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The Pie chart](pie_chart.png)

برای بهبود خوانایی برچسب‌های خارج از پای، به [Format Leader Lines](/slides/fa/python-net/chart-data-label/#format-leader-lines) برای مثال موقعیت‌دهی برچسب‌ها و سفارشی‌سازی رنگ، عرض، شفافیت و سبک خط‌ها مراجعه کنید.

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به‌عنوان نمودارهای line نیز شناخته می‌شوند) بهترین استفاده را در موقعیت‌هایی دارند که می‌خواهید تغییرات مقدار را در طول زمان نشان دهید. با استفاده از یک نمودار خطی می‌توانید مقدار زیادی داده را همزمان مقایسه کنید، تغییرات و روندها را در طول زمان پیگیری کنید، ناهنجاری‌های سری داده را برجسته کنید و غیره.

این مثال از [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) برای ایجاد یک نمودار خطی با سری‌ها و دسته‌های پیش‌فرض استفاده می‌کند، سپس ارائه را به‌صورت PPTX ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    presentation.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

به‌صورت پیش‌فرض، نقاط یک نمودار خطی با خطوط مستقیم ادامه‌دار به هم متصل می‌شوند. اگر می‌خواهید نقاط به‌جای خطوط پیوسته با خط‌خطی (dash) متصل شوند، ویژگی [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) را به مقدار دلخواهی از [LineDashStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) تنظیم کنید:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH
```

نتیجه:

![The Line chart](line_chart.png)

### **ایجاد نمودارهای درخت‌نقشه (Tree Map)**

نمودارهای درخت‌نقشه بهترین استفاده را برای داده‌های فروش دارند زمانی که می‌خواهید اندازه نسبی دسته‌های داده را نشان دهید و سریعاً توجه را به اقلامی که به‌صورت بزرگ‌عامل در هر دسته هستند، جلب کنید.

این مثال یک درخت‌نقشه با هشت برگ که در چهار شاخه و دو زیرشاخه گروه‌بندی شده‌اند، ایجاد می‌کند. روش [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) شاخه‌ها را در سطح گروه‌بندی ۱ و زیرشاخه‌ها را در سطح ۲ اختصاص می‌دهد. مقادیر نسبت به اندازه مستطیل‌ها تعیین می‌شوند، در حالی که برچسب‌های دسته و برچسب‌های والد متقاطع ساختار سلسله‌مراتبی را نشان می‌دهند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # شاخه 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # شاخه 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("Treemap.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The Treemap chart](treemap_chart.png)

### **ایجاد نمودارهای آبشاری (Waterfall)**

نمودار آبشاری نشان می‌دهد که چگونه تغییرات مثبت و منفی به مقدار نهایی کمک می‌کنند. به‌عنوان مثال، یک تجزیه سود می‌تواند با درآمد آغاز شود، هزینه‌ها را کم کند و سپس درآمدهای دیگر را اضافه کند. ستون‌های تغییر بین مقدار قبلی و مقدار جدید شناور می‌شوند، در حالی که ستون‌های کل از صفر تا مقدار انباشته‌شده گسترش می‌یابند.

جدول زیر از مقادیر به‌هزار دلار آمریکا استفاده می‌کند:

| دسته | مقدار کتاب کاری | نوع ستون |
| --- | ---: | --- |
| Revenue | 1000 | Increase |
| Cost of sales | -400 | Decrease |
| Gross profit | 600 | Intermediate total |
| Operating expenses | -200 | Decrease |
| Other income | 50 | Increase |
| Net profit | 450 | Final total |

برای مشخص کردن یک نقطه به‌عنوان کل میانی یا نهایی، ویژگی [set_as_total](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/set_as_total/) آن را روی `True` تنظیم کنید. مقدار واقعی انباشته‌شده را در خانهٔ کتاب‌کار آن نقطه وارد کنید: `600` برای سود ناخالص (`1000 - 400`) و `450` برای سود خالص (`600 - 200 + 50`). این ویژگی فقط ستون را به‌عنوان کل علامت‌گذاری می‌کند؛ محاسبه یا پرکردن مقدار سلول را انجام نمی‌دهد. از صفر به‌عنوان جایگزین استفاده نکنید و برای یک نقطهٔ کل مقدار دیگری اضافه نکنید. یک ستون کلی مقدار انباشته‌شده را بدون افزودن مجدد به مقدار جاری نمایش می‌دهد.

این مثال کامل C# یک نمودار ایجاد می‌کند که از عضو `Waterfall` در [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) استفاده می‌کند، داده‌های پیش‌فرض را پاک می‌کند و کتاب‌کار جاسازی‌شده را پر می‌کند. شاخص برگه `0` اولین برگه را انتخاب می‌کند؛ ستون A شامل نام‌های دسته و ستون B شامل مقادیر است. هر خانهٔ مقدار با [add_data_point_for_waterfall_series](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/add_data_point_for_waterfall_series/) اضافه می‌شود. شاخص‌های نقطه‌شدهٔ صفر‑محور `2` و `5` کل‌های میانی و نهایی را شناسایی می‌کنند. فعال‌سازی [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) مقادیر را بر روی ستون‌ها نمایش می‌دهد. نیازی به ارائهٔ ورودی یا کتاب‌کار نیست.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.WATERFALL, 20, 20, 680, 200)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Profit breakdown (USD thousands)")
    chart.chart_title.overlay = False
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Profit")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.WATERFALL)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, categories[i])
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_waterfall_series(value_cell)

    # نقطه‌های سوم و ششم نمایانگر کل هستند، نه تغییرات اضافی.
    series.data_points[2].set_as_total = True
    series.data_points[5].set_as_total = True
    series.show_connector_lines = True
    series.labels.default_data_label_format.show_value = True

    presentation.save("WaterfallChart.pptx", slides.export.SaveFormat.PPTX)
```

ویژگی سطح‑سری [show_connector_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/show_connector_lines/) را روی `True` تنظیم کنید تا خطوطی که ستون‌های متوالی را به هم متصل می‌کنند، نمایش داده شود و مقدار جاری راحت‌تر دنبال شود. برای مخفی‌سازی این خطوط، مقداردهی در مثال را به `series.show_connector_lines = False` قبل از ذخیرهٔ فایل تغییر دهید. این فقط دیدار خط را تغییر می‌دهد، نه داده یا مجموع‌ها.

ارائهٔ ذخیره‌شده سود ناخالص ۶۰۰ و سود خالص ۴۵۰ را نشان می‌دهد، که هر دو مجموع از صفر استخراج شده‌اند:

![Waterfall chart showing revenue, costs, gross profit of 600, and net profit of 450, with value labels and connector lines](waterfall_chart.png)

### **ایجاد نمودارهای سهام (Stock)**

نمودارهای سهام برای نمایش داده‌های مالی مانند قیمت‌های باز، بالا، پایین و بسته استفاده می‌شوند و به تحلیل روندهای بازار و نوسان‌ها کمک می‌کنند. این نمودارها بینش‌های اساسی دربارهٔ عملکرد سهام فراهم می‌کنند و به سرمایه‌گذاران و تحلیل‌گران کمک می‌کنند تصمیمات آگاهانه بگیرند.

این مثال یک نمودار open‑high‑low‑close با چهار سری به ترتیب و سه دسته ایجاد می‌کند. ویژگی [has_up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/has_up_down_bars/) نوارهای بالا/پایین را فعال می‌کند و [hi_low_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/hi_low_lines_format/) خطوط بالا‑پایین را که محدودهٔ قیمتی را نشان می‌دهند، کنترل می‌کند، در حالی که خطوط سری‌های منفرد و خطوط شبکه افقی جزئی پنهان هستند.

مدیر [up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/up_down_bars/) اشیای [up_bars_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/up_bars_format/) و [down_bars_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/down_bars_format/) را جداگانه افشا می‌کند. از ویژگی‌های [fill](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/fill/) و [line](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/line/) هر شیء برای تنظیم پرکننده و حاشیه به‌طور مستقل استفاده کنید. این مثال نوارهای سبز با حاشیهٔ سبز تیره برای بازه‌های صعودی و نوارهای نارنجی‑قرمز با حاشیهٔ قرمز تیره برای بازه‌های نزولی استفاده می‌کند.

مقادیر عددی برای همهٔ چهار سری در هر دسته فراهم کنید، به‌طوری که High و Low مقادیر Open و Close را در بر بگیرند. نوارها Close را نسبت به Open **در همان دسته** مقایسه می‌کنند، نه با دستهٔ قبلی: A از ۷۲ به ۲۵ کاهش می‌یابد، در حالی که B از ۲۵ به ۳۸ صعود می‌کند و C از ۳۸ به ۵۰ صعود می‌کند. مقادیر مساوی Open و Close هیچ بازهٔ پرشده‌ای نشان نمی‌دهند. نوارهای بالا/پایین بازهٔ Open‑Close را پوشش می‌دهند؛ خطوط بالا‑پایین بازهٔ Low‑High را. این نوارها جزو گروه سری هستند و نه سری‌های معمولی نمودار میله‌ای.

این قالب‌بندی همچنین با نمودارهای [LINE and LINE_WITH_MARKERS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) که حداقل دو سری در همان گروه و مقادیر عددی متناظر برای هر دسته دارند، کار می‌کند. برای این نمودارهای خطی غیر‑پشته‌ای، نوارهای بالا/پایین اولین و آخرین سری را مقایسه می‌کنند: مقدار نهایی بالاتر یک نوار بالا، مقدار نهایی کمتر یک نوار پایین ایجاد می‌کند. معکوس کردن این سری‌ها طبقه‌بندی را معکوس می‌کند. مثال زیر از [OPEN_HIGH_LOW_CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) استفاده می‌کند؛ فرض نکنید سایر انواع سهام، خط‑پشته یا ۳‑بعدی از همان تنظیمات داده یا تفسیر بازه استفاده می‌کنند.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 150, False)

    workbook = chart.chart_data.chart_data_workbook

    category_cell = workbook.get_cell(0, 1, 0, "A")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "B")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "C")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Open")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 2, "High")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 3, "Low")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 4, "Close")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)

    series = chart.chart_data.series[0]
    value_cell = workbook.get_cell(0, 1, 1, 72)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 1, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 1, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[1]
    value_cell = workbook.get_cell(0, 1, 2, 172)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[2]
    value_cell = workbook.get_cell(0, 1, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 3, 13)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[3]
    value_cell = workbook.get_cell(0, 1, 4, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 4, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 4, 50)
    series.data_points.add_data_point_for_stock_series(value_cell)

    up_down_bars = chart.chart_data.series_groups[0].up_down_bars
    up_down_bars.has_up_down_bars = True

    up_down_bars.up_bars_format.fill.fill_type = slides.FillType.SOLID
    up_down_bars.up_bars_format.fill.solid_fill_color.color = draw.Color.lime_green
    up_down_bars.up_bars_format.line.fill_format.fill_type = slides.FillType.SOLID
    up_down_bars.up_bars_format.line.fill_format.solid_fill_color.color = draw.Color.dark_green
    up_down_bars.up_bars_format.line.width = 2

    up_down_bars.down_bars_format.fill.fill_type = slides.FillType.SOLID
    up_down_bars.down_bars_format.fill.solid_fill_color.color = draw.Color.orange_red
    up_down_bars.down_bars_format.line.fill_format.fill_type = slides.FillType.SOLID
    up_down_bars.down_bars_format.line.fill_format.solid_fill_color.color = draw.Color.dark_red
    up_down_bars.down_bars_format.line.width = 2
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for stock_series in chart.chart_data.series:
        stock_series.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("Stock-chart.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه، خروجی از PowerPoint:

![Stock chart with an orange-red falling interval for A and green rising intervals for B and C](stock_chart.png)

### **ایجاد نمودارهای جعبه‌ای و ویسکر (Box and Whisker)**

نمودارهای جعبه‌ای و ویسکر برای نمایش توزیع داده‌ها با خلاصه‌سازی معیارهای آماری کلیدی مانند میانه، چارک‌ها و نقاط دورافتاده استفاده می‌شوند. این نمودارها به‌ویژه در تحلیل اکتشافی داده‌ها و مطالعات آماری برای درک سریع تغییرپذیری داده‌ها و شناسایی ناهنجاری‌ها مفید هستند.

این مثال یک نمودار جعبه‌ای و ویسکر بر پایهٔ شش مقدار ایجاد می‌کند. ویژگی [quartile_method](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/quartile_method/) محاسبهٔ چارک‌های انحصاری را انتخاب می‌کند. همچنین خطوط میانگین، علامت‌گرهای میانگین، نقاط داخلی و نقاط دورافتاده فعال می‌شوند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    value_cell = workbook.get_cell(0, "B1", 15)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 41)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 10)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 23)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)

    presentation.save("BoxAndWhisker.pptx", slides.export.SaveFormat.PPTX)
```

### **ایجاد نمودارهای قیفی (Funnel)**

نمودارهای قیفی برای تصویربرداری فرآیندهایی استفاده می‌شوند که شامل مراحل متوالی هستند، به‌طوری که حجم داده‌ها در هر قدم کاهش می‌یابد. این نمودارها برای تحلیل نرخ تبدیل، شناسایی موانع و پیگیری کارایی فرآیندهای فروش یا بازاریابی مفید هستند.

این مثال از [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) برای افزودن یک نمودار قیفی به اولین اسلاید یک ارائه موجود استفاده می‌کند. داده‌های پیش‌فرض را با شش دسته و مقادیری بین ۵۰ تا ۵۰۰ جایگزین می‌کند، سپس ارائه به‌روزرسانی‌شده را ذخیره می‌کند. ارائهٔ ورودی باید حداقل یک اسلاید داشته باشد.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    value_cell = workbook.get_cell(0, "B1", 50)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 100)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 200)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 300)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 400)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 500)
    series.data_points.add_data_point_for_funnel_series(value_cell)

    presentation.save("Funnel.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The Funnel chart](funnel_chart.png)

### **ایجاد نمودارهای خورشیدگرد (Sunburst)**

نمودارهای خورشیدگرد برای تصویربرداری داده‌های سلسله‌مراتبی استفاده می‌شوند و سطوح را به‌صورت حلقه‌های متحدالمرکز نمایش می‌دهند. این نمودارها به‌وضوح روابط بخش‑به‑کل را نشان می‌دهند و برای نمایش دسته‌ها و زیرمجموعه‌های تو در تو در قالبی واضح و فشرده مناسب هستند.

این مثال یک نمودار خورشیدگرد با هشت برگ که در چهار شاخه و دو زیرشاخه گروه‌بندی شده‌اند، ایجاد می‌کند. روش [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) شاخه‌ها را در سطح گروه‌بندی ۱ و زیرشاخه‌ها را در سطح ۲ اختصاص می‌دهد. برچسب‌های دسته‌بندی بخش‌ها را شناسایی می‌کند و مقادیر اندازه‌های نسبی آنها را تعیین می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # شاخه 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # شاخه 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)

    presentation.save("Sunburst.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The Sunburst chart](sunburst_chart.png)

### **ایجاد نمودارهای هیستوگرام (Histogram)**

نمودارهای هیستوگرام نشان می‌دهند که مقادیر عددی چگونه در بازه‌ها (بین‌ها) توزیع شده‌اند. برای گزارش‌های ماهیانهٔ زمان‌های پردازش سفارش، از عرض بین ثابت و آستانه‌های یکسان استفاده کنید تا بازه‌ها سازگار بمانند و توزیع‌ها راحت‌تر مقایسه شوند.

محور افقی را با [aggregation_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/aggregation_type/) به یکی از حالت‌های [AxisAggregationType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axisaggregationtype/) تنظیم کنید. ویژگی [bin_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/bin_width/) فقط برای `BY_BIN_WIDTH` اعمال می‌شود؛ [number_of_bins](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_of_bins/) فقط برای `BY_NUMBER_OF_BINS` اعمال می‌شود. از `AUTOMATIC` برای اجازه به نمودار جهت انتخاب بین‌ها استفاده کنید.

#### **استفاده از عرض بین ثابت**

این مثال زمان‌های پردازش را به بازه‌های ۱۰ دقیقه‌ای گروه‌بندی می‌کند، با بین‌های جداگانه برای زمان‌های ≤۱۰ دقیقه و >۴۰ دقیقه. این بین‌ها را با [is_underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_underflow_bin/) و [is_overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_overflow_bin/) فعال کنید. هنگام ارائهٔ آستانه‌های صریح برای [underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/underflow_bin/) و [overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/overflow_bin/) ، ویژگی‌های [is_automatic_underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_underflow_bin/) و [is_automatic_overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_overflow_bin/) را روی `False` تنظیم کنید.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 680, 200)

    chart.has_legend = False
    chart.has_title = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.get_cell(0, i, 0, value)
        series.data_points.add_data_point_for_histogram_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.aggregation_type = charts.AxisAggregationType.BY_BIN_WIDTH
    axis.bin_width = 10
    axis.is_underflow_bin = True
    axis.is_automatic_underflow_bin = False
    axis.underflow_bin = 10
    axis.is_overflow_bin = True
    axis.is_automatic_overflow_bin = False
    axis.overflow_bin = 40

    presentation.save("Histogram-bin-width.pptx", slides.export.SaveFormat.PPTX)
```

ارائه در PowerPoint تعداد بین‌ها را **3, 4, 4, 4, و 2** نشان می‌دهد. بین زیرجریان شامل `5, 10, 10` است، بنابراین آستانه‌اش شامل است. بین فوق‌جریان تنها `41, 50` را شامل می‌شود، بنابراین آستانه‌اش حذف‌کننده است؛ مقادیر برابر با `40` در بازهٔ قبلی می‌مانند. بین‌های داخلی مقادیر بزرگ‌تر از حد پایین و کمتر یا مساوی حد بالای خود را دارند.

![Histogram with 10-minute bins and explicit underflow and overflow thresholds](histogram_bin_width.png)

#### **تعیین تعداد بین‌ها**

برای جزئیات ثابت به‌جای بازه‌های ثابت، برای همان داده پنج بین درخواست کنید. این مثال بین‌های زیرجریان و فوق‌جریان را غیرفعال می‌کند. نمودار عرض را از بازه داده تعیین می‌کند، بنابراین مرزها می‌توانند بین گزارش‌ها متفاوت باشند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 680, 200)

    chart.has_legend = False
    chart.has_title = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.get_cell(0, i, 0, value)
        series.data_points.add_data_point_for_histogram_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.aggregation_type = charts.AxisAggregationType.BY_NUMBER_OF_BINS
    axis.number_of_bins = 5

    presentation.save("Histogram-bin-count.pptx", slides.export.SaveFormat.PPTX)
```

پنج بین تعداد **4, 4, 4, 4, و 1** دارند. این توزیع را با نتیجهٔ عرض ثابت بالا مقایسه کنید: مقادیر ورودی یکسان‌اند اما مرزها متفاوت‌اند.

![Histogram with five bins calculated from the same data](histogram_bin_count.png)

### **ایجاد نمودارهای رادار (Radar)**

نمودارهای رادار برای نمایش داده‌های چندمتغیره در قالب دو‑بعدی استفاده می‌شوند و امکان مقایسهٔ سادهٔ چندین متغیر را به‌طور همزمان فراهم می‌کنند. این نمودارها برای شناسایی الگوها، قوت‌ها و ضعف‌ها در میان معیارهای عملکرد یا ویژگی‌های مختلف بسیار مفیدند.

این مثال از [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) برای ایجاد یک نمودار رادار با سری‌ها و دسته‌های پیش‌فرض استفاده می‌کند، سپس ارائه را به‌صورت PPTX ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_chart(charts.ChartType.RADAR, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The Radar chart](radar_chart.png)

### **ایجاد نمودارهای چنددسته‌ای (Multi-Category)**

نمودارهای چنددسته‌ای برای نمایش داده‌هایی استفاده می‌شوند که بیش از یک گروه‌بندی دسته‌ای دارند و امکان مقایسهٔ مقادیر در چندین بُعد به‌صورت همزمان را می‌دهند. این نمودارها به‌ویژه هنگام نیاز به تجزیه و تحلیل روندها و روابط در مجموعه‌های دادهٔ چندلایهٔ پیچیده مفیدند.

این مثال یک نمودار ستونی خوشه‌ای با هشت دسته که در چهار جفت مرتب شده‌اند، ایجاد می‌کند. روش [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) به هر جفت یک برچسب مشترک در سطح گروه‌بندی ۱ می‌دهد و محور دسته‌ها هم برچسب‌های تک‌تک و هم گروهی تولید می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.get_cell(0, "c2", "A")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group1")
    category_cell = workbook.get_cell(0, "c3", "B")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c4", "C")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group2")
    category_cell = workbook.get_cell(0, "c5", "D")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c6", "E")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group3")
    category_cell = workbook.get_cell(0, "c7", "F")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c8", "G")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group4")
    category_cell = workbook.get_cell(0, "c9", "H")
    category = chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, "D1", "Series 1")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    value_cell = workbook.get_cell(worksheet_index, "D2", 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D3", 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D4", 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D5", 40)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D6", 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D7", 60)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D8", 70)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D9", 80)
    series.data_points.add_data_point_for_bar_series(value_cell)

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The multi category chart](multi_category_chart.png)

#### **حذف برچسب یک فصل**

فایل [quarters.pptx](quarters.pptx) را دانلود کنید و در پوشهٔ کاری قرار دهید. نمودار آن نه ماه و یک سری فروش با مقادیر ۱۰ تا ۱۸ را نشان می‌دهد. محور دسته‌ها سه برچسب فصل دارد: Q1 شامل Jan–Mar، Q2 شامل Apr–Jun و Q3 شامل Jul–Sep.

ماه آوریل دستهٔ چهارم است و نقطه‌ای است که Q2 به‌طور صریح تنظیم شده بود. بر روی مجموعهٔ [grouping_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/grouping_levels/) ماه آوریل، روش [delete_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/delete_grouping_item/) را فراخوانی کنید. این سطح نسبت به آوریل است: سطح ۱ فصل آن و سطح ۰ خود ماه است. این متد نمی‌تواند دستهٔ برگ در سطح ۰ را حذف کند.

```python
import aspose.slides as slides

with slides.Presentation("quarters.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    april = chart.chart_data.categories[3]
    april.grouping_levels.delete_grouping_item(1)
    
    presentation.save("quarters-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("quarters-updated.pptx") as reopened:
    data = reopened.slides[0].shapes[0].chart_data
    print(", ".join(str(month.as_cell.value) for month in data.categories))
    print(", ".join(str(point.value.data) for point in data.series[0].data_points))
```

نمودار بازگشایی‌شده ماه‌های اصلی (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) و مقادیر فروش (`10, 11, 12, 13, 14, 15, 16, 17, 18`) را به همان ترتیب چاپ می‌کند. فایل `quarters-updated.pptx` را در PowerPoint باز کنید تا برچسب‌های محور را مقایسه کنید. برچسب Q2 و مرز گروه قبل از آوریل حذف می‌شوند، بنابراین Q1 از ژانویه تا ژوئن ادامه دارد. Q3 همچنان از ژوئیه آغاز می‌شود.

![Quarter labels before and after removal. On the left, Q2 spans April through June. On the right, Q1 spans January through June.](quarter-label-comparison.png)

### **ایجاد نمودارهای نقشه (Map)**

نمودارهای نقشه برای تصویربرداری داده‌های جغرافیایی با نسبت دادن اطلاعات به مکان‌های خاصی مانند کشورها، ایالت‌ها یا شهرها استفاده می‌شوند. این نمودارها برای تحلیل روندهای منطقه‌ای، داده‌های جمعیتی و توزیع‌های مکانی به‌صورت واضح و بصری موثر هستند.

این مثال از [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) برای ایجاد یک نمودار نقشه با داده‌های جغرافیایی پیش‌فرض استفاده می‌کند و آن را برای مشاهده در PowerPoint ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.MAP, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![The Map chart](map_chart.png)

{{% alert color="info" title="Note" %}}
تصویر بالا ارائهٔ ذخیره‌شده را در PowerPoint نشان می‌دهد. Aspose.Slides نمودار نقشه و داده‌های آن را به‌درستی می‌نویسد، اما خود نمودارهای نقشه را رسم نمی‌کند: وقتی اسلایدی که شامل یک نمودار نقشه است به تصویر تبدیل یا به PDF یا SVG تبدیل می‌شود، ناحیهٔ نمودار خالی می‌ماند. سایر اشکال در همان اسلاید تحت تأثیر قرار نمی‌گیرند.
{{% /alert %}}

### **ایجاد نمودارهای ترکیبی (Combination)**

نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما اجازه می‌دهد تا تفاوت‌ها یا شباهت‌های بین دو یا چند مجموعهٔ داده را برجسته، مقایسه یا بررسی کنید و روابط بین آنها را شناسایی نمایید.

![The combination chart](combination_chart.png)

این مثال دو سری ستونی خوشه‌ای را با یک سری خطی در چهار دسته ترکیب می‌کند. ستون‌ها از محور عمودی اصلی استفاده می‌کنند، در حالی که [plot_on_second_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/plot_on_second_axis/) خط را بر روی محور عمودی ثانویه در سمت راست قرار می‌دهد. توابع کمکی عنوان، افسانه، برچسب‌های محور و خطوط شبکه را پیکربندی می‌کنند.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)

def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    portion_format = chart.chart_title.text_frame_for_overriding.paragraphs[0].paragraph_format.default_portion_format
    portion_format.font_bold = slides.NullableBool.FALSE
    portion_format.font_height = 18

    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 4, 0, "Category 4")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 4.3)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 2.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 3.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 1, 4.5)
    series.data_points.add_data_point_for_bar_series(value_cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 2.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 4.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 1.8)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 2, 2.8)
    series.data_points.add_data_point_for_bar_series(value_cell)

def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    value_cell = workbook.get_cell(worksheet_index, 1, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 3, 3.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 3, 5.0)
    series.data_points.add_data_point_for_line_series(value_cell)

    series.plot_on_second_axis = True

def set_primary_axes_format(chart):
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)

def set_secondary_axes_format(chart):
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12


create_combo_chart()
```

## **به‌روزرسانی نمودارها**

Aspose.Slides برای Python از طریق .NET به شما امکان به‌روزرسانی نمودارهای PowerPoint را با تغییر داده‌های نمودار، قالب‌بندی و استایل می‌دهد. این قابلیت فرآیند نگه‌دارندهٔ به‌روز بودن ارائه‌ها با محتوای دینامیک را ساده می‌کند و اطمینان می‌دهد که نمودارها دقیقاً داده‌ها و استانداردهای بصری فعلی را منعکس می‌کنند.

این مثال نمودار با نام "My chart" را در اولین اسلاید یک ارائه موجود به‌روزرسانی می‌کند. این مثال به دو سری ستونی با هر سه نقطهٔ داده نیاز دارد، به‌طوری که برچسب‌های دسته در ستون A و نام‌های سری در ردیف اول اولین برگه باشند. مثال از [get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) برای تغییر سلول‌های کتاب‌کار استفاده می‌کند، مقادیر سری‌ها را به‌روزرسانی می‌کند، یک سری سوم اضافه می‌کند و نمودار را به سیلندرهای خوشه‌ای از طریق [type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/type/) تغییر می‌دهد.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            worksheet_index = 0

            workbook = chart.chart_data.chart_data_workbook

            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.chart_data.series[0]

            workbook.get_cell(worksheet_index, 0, 1, "New_Series 1")
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            series = chart.chart_data.series[1]

            workbook.get_cell(worksheet_index, 0, 2, "New_Series 2")
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
            series = chart.chart_data.series.add(series_name_cell, chart.type)

            value_cell = workbook.get_cell(worksheet_index, 1, 3, 20)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 2, 3, 50)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 3, 3, 30)
            series.data_points.add_data_point_for_bar_series(value_cell)

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

    presentation.save("AsposeChartModified.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم محدودهٔ داده برای یک نمودار**

برای بررسی محدوده‌ای که قبلاً توسط یک نمودار موجود استفاده شده است، به [Retrieve a Chart's Data Range](/slides/fa/python-net/chart-workbook/#retrieve-a-charts-data-range) مراجعه کنید.

Aspose.Slides برای Python از طریق .NET انعطاف‌پذیری تعریف یک محدودهٔ دادهٔ خاص از یک برگه کاری را به‌عنوان منبع دادهٔ نمودار شما فراهم می‌کند. این بدین معنی است که می‌توانید به‌طور مستقیم بخشی از برگه کاری خود را به نمودار مرتبط کنید و کنترل کنید کدام سلول‌ها به سری‌ها و دسته‌های نمودار شما کمک می‌کنند. در نتیجه می‌توانید به‌راحتی نمودارهایتان را با تغییرات جدید داده‌ها به‌روز کنید و همگام‌سازی کنید تا ارائه‌های PowerPoint شما اطلاعات دقیق و به‌روز را منعکس کنند.

این مثال از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) برای تنظیم منبع دادهٔ نمودار با نام "My chart" در اولین اسلاید یک ارائهٔ موجود به `Sheet1!A1:B4` استفاده می‌کند. کتاب‌کار نمودار باید آن برگه را داشته باشد و یک محدودهٔ پرشده با عنوان سری در ردیف اول، برچسب‌های دسته در ستون A و سه مقدار در ستون B داشته باشد.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **استفاده از نشانگرهای پیش‌فرض در نمودارها**

هنگامی که از نشانگرهای پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌صورت خودکار یک نماد نشانگر پیش‌فرض متفاوت دریافت می‌کند.

این مثال از [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) برای ایجاد یک نمودار با دو سری خطی و یک افسانه استفاده می‌کند. تنظیمات [marker](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/marker/) نمادهای نشانگر اختصاص داده شده خودکار را حفظ می‌کند. سری اول شامل یک مقدار منفی و یک مقدار گمشده (نمایش داده‌شده به‌صورت `None`) است، در حالی که سری دوم برای هر دسته یک مقدار دارد.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(0, 1, 0, "C1")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 1, 1, 24)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 2, 0, "C2")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 2, 1, 23)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 3, 0, "C3")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 3, 1, -10)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 4, 0, "C4")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 4, 1, None)
    series.data_points.add_data_point_for_line_series(value_cell)

    series_name_cell = workbook.get_cell(0, 0, 2, "Series 2")
    second_series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(0, 1, 2, 30)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 10)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 60)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 4, 2, 40)
    second_series.data_points.add_data_point_for_line_series(value_cell)

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول (FAQ)**

**کدام انواع نمودارها توسط Aspose.Slides برای Python از طریق .NET پشتیبانی می‌شوند؟**

Aspose.Slides برای Python از طریق .NET انواع گسترده‌ای از نمودارها از جمله نوار، خط، پای، ناحیه، پراکندگی، هیستوگرام، رادار و بسیاری دیگر را پشتیبانی می‌کند. این انعطاف‌پذیری به شما اجازه می‌دهد تا مناسب‌ترین نوع نمودار را برای نیازهای تصویربرداری دادهٔ خود انتخاب کنید.

**چگونه یک نمودار جدید به اسلاید اضافه کنم؟**

برای افزودن یک نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد می‌کنید، اسلاید موردنظر را با استفاده از شاخص آن بازیابی می‌کنید و سپس متد افزودن نمودار را فراخوانی می‌کنید، نوع نمودار و داده‌های اولیه را مشخص می‌کنید. این فرآیند نمودار را مستقیماً در ارائهٔ شما یکپارچه می‌سازد.

**چگونه می‌توان داده‌های نمایش داده‌شده در یک نمودار را به‌روزرسانی کرد؟**

می‌توانید داده‌های یک نمودار را با دسترسی به کتاب‌کار دادهٔ آن ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))، پاک کردن هر سری و دستهٔ پیش‌فرض، و سپس افزودن داده‌های سفارشی خود به‌روزرسانی کنید. این امکان به شما اجازه می‌دهد تا به‌صورت برنامه‌نویسی نمودار را به‌روز کنید تا جدیدترین داده‌ها را منعکس کند.

**آیا می‌توان ظاهر نمودار را سفارشی کرد؟**

بله، Aspose.Slides برای Python از طریق .NET گزینه‌های سفارشی‌سازی گسترده‌ای ارائه می‌دهد. می‌توانید رنگ‌ها، فونت‌ها، برچسب‌ها، افسانه‌ها و سایر عناصر قالب‌بندی را تغییر دهید تا ظاهر نمودار را مطابق نیازهای طراحی خاص خود تنظیم کنید.

ویژگی مرتبط: [Create editable charts](/slides/fa/features/create-charts/).