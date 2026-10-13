---
title: ایجاد یا به‌روزرسانی نمودارهای ارائه PowerPoint در Python
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
- نمودار دایره‌ای
- نمودار خطی
- نمودار درختی
- نمودار سهام
- نمودار جعبه‌ای و ویسکر
- نمودار قیفی
- نمودار خورشیدی
- نمودار هیستوگرام
- نمودار رادار
- نمودار چنددسته‌ای
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارها در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Python از طریق .NET. افزودن، قالب‌بندی و ویرایش نمودارها با مثال‌های کد عملی در Python."
---
## **نمای کلی**

این مقاله یک راهنمای جامع در مورد نحوه ایجاد و سفارشی‌سازی نمودارها با استفاده از Aspose.Slides برای Python از طریق .NET ارائه می‌دهد. شما یاد خواهید گرفت که چگونه به‌صورت برنامه‌نویسی، یک نمودار را به اسلاید اضافه کنید، آن را با داده‌ها پر کنید و گزینه‌های قالب‌بندی مختلفی را اعمال کنید تا با الزامات طراحی خاص شما مطابقت داشته باشد. در طول مقاله، مثال‌های کد دقیق هر مرحله را نشان می‌دهند، از مقداردهی اولیه ارائه و شی نمودار تا پیکربندی سری‌ها، محورها و افسانه‌ها. با دنبال کردن این راهنما، درک محکمی از چگونگی یکپارچه‌سازی تولید نمودارهای پویا در برنامه‌های Python خود به دست می‌آورید و فرآیند ایجاد ارائه‌های مبتنی بر داده را ساده می‌کنید.

## **ایجاد نمودار**

نمودارها به افراد کمک می‌کنند تا به‌سرعت داده‌ها را تجسم کنند و بینش‌هایی به‌دست آورند که ممکن است از یک جدول یا صفحه‌گسترده به‌سرعت واضح نباشند.

**چرا نمودار ایجاد کنیم؟**

* داده‌های بزرگ را در یک اسلاید از ارائه جمع‌آوری، فشرده‌سازی یا خلاصه کنید؛  
* الگوها و روندهای داده را آشکار کنید؛  
* جهت و شتاب داده را در طول زمان یا نسبت به یک واحد اندازه‌گیری خاص استنتاج کنید؛  
* نقاط دور از نُرمال، انحرافات، خطاها و داده‌های غیرمنطقی را شناسایی کنید؛  
* داده‌های پیچیده را ارتباط یا ارائه دهید.

در PowerPoint می‌توانید نمودارها را از طریق عملکرد *Insert* ایجاد کنید که قالب‌های مختلفی برای طراحی انواع نمودارها فراهم می‌کند. با استفاده از Aspose.Slides می‌توانید هر دو نوع نمودارهای معمولی (بر پایه انواع نمودارهای محبوب) و نمودارهای سفارشی را ایجاد کنید.

{{% alert color="info" title="Note" %}}
از شمرده‌سازی [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) در ماژول [aspose.slides.charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) استفاده کنید. مقادیر این شمرده‌سازی با انواع مختلف نمودارها مطابقت دارند.
{{% /alert %}}

### **ایجاد نمودارهای ستون خوشه‌ای**

این مثال از [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) برای ایجاد یک نمودار ستون خوشه‌ای استفاده می‌کند که دو سری را در سه دسته مقایسه می‌کند. سری‌ها از پر کردن‌های قرمز و سبز استفاده می‌کنند و برچسب‌های فردی نام دسته‌ها، نام سری‌ها و مقادیر را نشان می‌دهند. شماره شیت ۰ به اولین شیت در کتاب‌کار جاسازی‌شده نمودار اشاره دارد.

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

![نمودار ستون خوشه‌ای](clustered_column_chart.png)

### **ایجاد نمودارهای پراکنده**

نمودارهای پراکنده (که به‌عنوان نمودار پراکندگی یا گراف xy نیز شناخته می‌شوند) اغلب برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

از یک نمودار پراکنده استفاده کنید وقتی:

* داده‌های عددی جفت‌شده دارید.  
* دو متغیر دارید که به‌خوبی با هم جفت می‌شوند.  
* می‌خواهید تعیین کنید آیا دو متغیر مرتبط هستند یا نه.  
* یک متغیر مستقل دارید که برای متغیر وابسته مقادیر متعددی دارد.

این مثال دو مجموعه مقدار x-y را رسم می‌کند. سری اول از خطوط مستقیم با نشانگرهای ستاره‌ای استفاده می‌کند، در حالی که سری دوم از خطوط صاف با نشانگرهای دایره‌ای بهره می‌گیرد؛ هر دو از [size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/size/) مقدار ۱۰ استفاده می‌کنند. ویژگی [symbol](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/symbol/) شکل نشانگر را کنترل می‌کند.

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

![نمودار پراکنده](scatter_chart.png)

### **ایجاد نمودارهای دایره‌ای**

نمودارهای دایره‌ای برای نشان دادن رابطه بخش به کل در داده‌ها بهترین هستند، به‌ویژه زمانی که داده‌ها شامل برچسب‌های دسته‌ای با مقادیر عددی هستند. با این حال، اگر داده‌های شما شامل بخش‌ها یا برچسب‌های زیادی باشد، ممکن است به‌جای آن استفاده از نمودار میله‌ای را در نظر بگیرید.

این مثال یک نمودار دایره‌ای با سه مقدار فصلی ایجاد می‌کند. هر برش پر کردن و حاشیه سفارشی دارد و برچسب‌ها ترکیبی‌های مختلفی از مقدار، درصد و اطلاعات سری را نمایش می‌دهند. ویژگی [first_slice_angle](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/first_slice_angle/) اولین برش را به شروع در ۱۸۰ درجه تنظیم می‌کند.

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

![نمودار دایره‌ای](pie_chart.png)

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به‌عنوان گراف‌های خطی نیز شناخته می‌شوند) بهترین گزینه در موقعیت‌هایی هستند که می‌خواهید تغییرات مقدار را بر گذشت زمان نشان دهید. با استفاده از نمودار خطی می‌توانید حجم وسیعی از داده‌ها را یک‌جا مقایسه کنید، تغییرات و روندها را در طول زمان پیگیری کنید، ناهنجاری‌ها را در سری داده‌ها برجسته کنید و غیره.

این مثال از [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) برای ایجاد یک نمودار خطی با سری‌ها و دسته‌های پیش‌فرض استفاده می‌کند، سپس ارائه را به‌صورت PPTX ذخیره می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    presentation.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

به‌صورت پیش‌فرض، نقاط در یک نمودار خطی با خطوط صاف و پیوسته به‌هم متصل می‌شوند. اگر می‌خواهید نقاط به‌جای آن با خط تیره متصل شوند، [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) را به مقداری از [LineDashStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) تنظیم کنید.

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

![نمودار خطی](line_chart.png)

### **ایجاد نمودارهای درختی**

نمودارهای درختی بهترین گزینه برای داده‌های فروش هستند وقتی می‌خواهید اندازه نسبی دسته‌های داده را نشان دهید و سریعاً توجه را به آیتم‌های بزرگ‌سهم در هر دسته جلب کنید.

این مثال یک درخت‌نقشه با هشت برگ گروه‌بندی‌شده در چهار ساقه و دو شاخه ایجاد می‌کند. متد [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) ساقه‌ها را در سطح گروه‌بندی ۱ و شاخه‌ها را در سطح ۲ تخصیص می‌دهد. مقادیر اندازه نسبی مستطیل‌ها را تعیین می‌کنند، در حالی که برچسب‌های دسته و برچسب‌های والد همپوشانی سلسله‌مراتب را شناسایی می‌کنند.

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

![نمودار درختی](treemap_chart.png)

### **ایجاد نمودارهای آبشاری**

نمودار آبشاری نشان می‌دهد که چگونه تغییرات مثبت و منفی به مقدار نهایی کمک می‌کنند. برای مثال، تجزیه سود می‌تواند با درآمد شروع شود، هزینه‌ها را کم کند و سایر درآمدها را اضافه کند. ستون‌های تغییر بین مقدار قبلی و مقدار جدید جاری شناور می‌شوند، در حالی که ستون‌های کل از صفر تا مقدار تجمعی امتداد دارند.

| Category | Workbook value | Column type |
| --- | ---: | --- |
| درآمد | 1000 | افزایش |
| هزینه فروش | -400 | کاهش |
| سود ناخالص | 600 | کل میانی |
| هزینه‌های عملیاتی | -200 | کاهش |
| سایر درآمد | 50 | افزایش |
| سود خالص | 450 | کل نهایی |

برای علامت‌گذاری یک نقطه به‌عنوان کل میانی یا نهایی، ویژگی [set_as_total](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/set_as_total/) آن را به `True` تنظیم کنید. مقدار تجمعی واقعی را در سلول کتاب‌کار آن نقطه قرار دهید: `600` برای سود ناخالص (`1000 - 400`) و `450` برای سود خالص (`600 - 200 + 50`). این ویژگی ستون را به‌عنوان کل علامت‌گذاری می‌کند؛ محاسبه یا پرکردن مقدار سلول را انجام نمی‌دهد. از صفر به‌عنوان جایگزین استفاده نکنید یا تغییر دیگری برای نقطه کل فراهم نکنید. یک ستون کل مقدار تجمعی را بدون افزودن دوباره به مقدار جاری نمایش می‌دهد.

این مثال کامل C# یک نمودار با استفاده از عضو `Waterfall` از [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ایجاد می‌کند، داده‌های پیش‌فرض را پاک می‌کند و کتاب‌کار جاسازی‌شده را پر می‌کند. شماره شیت `0` اولین شیت را انتخاب می‌کند؛ ستون A شامل نام‌های دسته و ستون B شامل مقادیر است. هر سلول مقدار با [add_data_point_for_waterfall_series](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/add_data_point_for_waterfall_series/) اضافه می‌شود. ایندکس‌های نقطه‌ای مبتنی بر صفر `2` و `5` کل‌های میانی و نهایی را شناسایی می‌کنند. فعال‌سازی [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) مقادیر را روی ستون‌ها نمایش می‌دهد. نیازی به ارائه یا کتاب‌کار ورودی نیست.

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

    # نقطه‌های سوم و ششم به عنوان مجموع‌ها محسوب می‌شوند، نه تغییرات اضافه.
    series.data_points[2].set_as_total = True
    series.data_points[5].set_as_total = True
    series.show_connector_lines = True
    series.labels.default_data_label_format.show_value = True

    presentation.save("WaterfallChart.pptx", slides.export.SaveFormat.PPTX)
```

ویژگی سطح سری [show_connector_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/show_connector_lines/) را به `True` تنظیم کنید تا خطوطی که ستون‌های متوالی را وصل می‌کنند نشان داده شوند و مقدار جاری راحت‌تر دنبال شود. برای مخفی کردن این خطوط، انتساب را در مثال به `series.show_connector_lines = False` قبل از ذخیره‌سازی تغییر دهید. این فقط نمای خطوط را تغییر می‌دهد، نه داده‌ها یا کل‌ها.

ارائه ذخیره‌شده سود ناخالص 600 و سود خالص 450 را نشان می‌دهد، با هر دو کل که از صفر ترسیم شده‌اند:

![نمودار آبشاری](waterfall_chart.png)

### **ایجاد نمودارهای سهام**

نمودارهای سهام برای نمایش داده‌های مالی مانند قیمت‌های باز، بالا، پایین و بسته استفاده می‌شوند و به تحلیل روندهای بازار و نوسان کمک می‌کنند. آن‌ها بینش‌های اساسی درباره عملکرد سهام ارائه می‌دهند و به سرمایه‌گذاران و تحلیل‌گران کمک می‌کنند تا تصمیمات آگاهی‌بخش بگیرند.

این مثال یک نمودار باز-بالا-پایین-بسته با چهار سری به ترتیب و سه دسته ایجاد می‌کند. ویژگی [has_up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/has_up_down_bars/) نوارهای بالا/پایین را فعال می‌کند و [hi_low_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/hi_low_lines_format/) خطوط بالا-پایین که دامنه‌های قیمتی را نشان می‌دهند کنترل می‌کند، در حالی که خطوط سری‌های فردی و خطوط شبکه افقی جزئی مخفی هستند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

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

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for stock_series in chart.chart_data.series:
        stock_series.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("Stock-chart.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![نمودار سهام](stock_chart.png)

### **ایجاد نمودارهای جعبه‌ای و ویسکر**

نمودارهای جعبه‌ای و ویسکر برای نمایش توزیع داده‌ها با خلاصه‌سازی معیارهای آماری کلیدی مانند میانه، چارک‌ها و مقادیر دوری احتمالی استفاده می‌شوند. آن‌ها به‌ویژه در تحلیل اکتشافی داده‌ها و مطالعات آماری برای درک سریع تغییرپذیری داده‌ها و شناسایی ناهنجاری‌ها مفیدند.

این مثال یک نمودار جعبه‌ای و ویسکر از شش مقدار ایجاد می‌کند. ویژگی [quartile_method](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/quartile_method/) روش محاسبه چارک انحصاری را انتخاب می‌کند. مثال همچنین خطوط میانگین، نشانگرهای میانگین، نقاط داخلی و نقاط دوری را فعال می‌کند.

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

### **ایجاد نمودارهای قیفی**

نمودارهای قیفی برای تجسم فرآیندی که شامل مراحل متوالی است استفاده می‌شوند، که حجم داده‌ها با پیشرفت از یک گام به گام بعدی کاهش می‌یابد. این نمودارها به‌ویژه برای تجزیه و تحلیل نرخ تبدیل، شناسایی گلوگاه‌ها و پیگیری کارایی فرآیندهای فروش یا بازاریابی مفیدند.

این مثال از [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) برای افزودن یک نمودار قیفی به اولین اسلاید یک ارائه موجود استفاده می‌کند. داده‌های پیش‌فرض را با شش دسته و مقادیری بین ۵۰ تا ۵۰۰ جایگزین می‌کند، سپس ارائه به‌روزرسانی‌شده را ذخیره می‌کند. ارائه ورودی باید حداقل یک اسلاید داشته باشد.

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

![نمودار قیفی](funnel_chart.png)

### **ایجاد نمودارهای خورشیدی**

نمودارهای خورشیدی برای تجسم داده‌های سلسله‌مراتبی استفاده می‌شوند، سطوح را به صورت حلقه‌های متحدالمرکز نمایش می‌دهند. آن‌ها به بیان روابط بخش به کل کمک می‌کنند و برای نمایاندن دسته‌ها و زیرمجموعه‌های تودرتو در قالبی واضح و فشرده ایده‌آل هستند.

این مثال یک نمودار خورشیدی با هشت برگ گروه‌بندی‌شده در چهار ساقه و دو شاخه ایجاد می‌کند. متد [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) ساقه‌ها را در سطح گروه‌بندی ۱ و شاخه‌ها را در سطح ۲ تخصیص می‌دهد. برچسب‌های دسته بخش‌ها را شناسایی می‌کنند و مقادیر اندازه نسبی آن‌ها را تعیین می‌کند.

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

![نمودار خورشیدی](sunburst_chart.png)

### **ایجاد نمودارهای هیستوگرام**

نمودارهای هیستوگرام برای نشان دادن توزیع داده‌های عددی با گروه‌بندی مقادیر به بازه‌ها یا سطل‌ها استفاده می‌شوند. آن‌ها برای شناسایی الگوهای داده مانند فراوانی، کشیدگی و پراکندگی، و همچنین برای کشف نقاط دوری در یک مجموعه داده مفیدند.

این مثال یک هیستوگرام از شش مقدار عددی، از جمله مقادیر منفی، ایجاد می‌کند. تنظیم [aggregation_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/aggregation_type/) به حالت خودکار به نمودار اجازه می‌دهد که سطل‌های مورد استفاده برای نمایش توزیع را تعیین کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    value_cell = workbook.get_cell(0, "A1", 15)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A2", -41)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A3", 16)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A4", 10)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A5", -23)
    series.data_points.add_data_point_for_histogram_series(value_cell)
    value_cell = workbook.get_cell(0, "A6", 16)
    series.data_points.add_data_point_for_histogram_series(value_cell)

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("Histogram.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![نمودار هیستوگرام](histogram_chart.png)

### **ایجاد نمودارهای رادار**

نمودارهای رادار برای نمایش داده‌های چندمتغیره در قالب دو‑بعدی استفاده می‌شوند که امکان مقایسه آسان چند متغیر به‌صورت همزمان را فراهم می‌کنند. آن‌ها برای شناسایی الگوها، نقاط قوت و ضعف در میان معیارهای عملکرد یا ویژگی‌های متعدد مفیدند.

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

![نمودار رادار](radar_chart.png)

### **ایجاد نمودارهای چنددسته‌ای**

نمودارهای چنددسته‌ای برای نمایش داده‌هایی استفاده می‌شوند که شامل بیش از یک گروه‌بندی دسته‌ای هستند و به شما امکان می‌دهند مقادیر را در چند بُعد به‌صورت همزمان مقایسه کنید. این نمودارها به‌ویژه هنگام تحلیل روندها و روابط در داده‌های پیچیده و چندلایه مفیدند.

این مثال یک نمودار ستون خوشه‌ای با هشت دسته که در چهار جفت تنظیم شده‌اند، ایجاد می‌کند. متد [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) به هر جفت یک برچسب مشترک در سطح گروه‌بندی ۱ می‌دهد و محور دسته با برچسب‌های فردی و گروهی تولید می‌کند.

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

![نمودار چنددسته‌ای](multi_category_chart.png)

### **ایجاد نمودارهای نقشه**

نمودارهای نقشه برای تجسم داده‌های جغرافیایی با نگاشت اطلاعات به مکان‌های خاصی مانند کشورها، استان‌ها یا شهرها استفاده می‌شوند. آن‌ها برای تحلیل روندهای منطقه‌ای، داده‌های جمعیتی و توزیع‌های مکانی به‌صورت واضح و بصری جذاب مفیدند.

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

![نمودار نقشه](map_chart.png)

{{% alert color="info" title="Note" %}}
عکس بالا ارائه ذخیره‌شده را که در PowerPoint باز شده نشان می‌دهد. Aspose.Slides نمودار نقشه و داده‌های آن را به‌درستی می‌نویسد، اما خود نمودارهای نقشه را رسم نمی‌کند: زمانی که اسلاید حاوی آن به تصویر رندر شود یا به PDF یا SVG تبدیل شود، ناحیه نمودار خالی می‌ماند. سایر اشکال روی همان اسلاید تحت تأثیر نیستند.
{{% /alert %}}

### **ایجاد نمودارهای ترکیبی**

نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما امکان می‌دهد تا تفاوت‌های دو یا چند مجموعه داده را برجسته، مقایسه یا بررسی کنید و روابط بین آن‌ها را شناسایی کنید.

![نمودار ترکیبی](combination_chart.png)

این مثال دو سری ستون خوشه‌ای را با یک سری خطی در چهار دسته ترکیب می‌کند. ستون‌ها از محور عمودی اصلی استفاده می‌کنند، در حالی که [plot_on_second_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/plot_on_second_axis/) خط را روی محور عمودی ثانوی در سمت راست قرار می‌دهد. توابع کمکی عنوان، افسانه، برچسب‌های محور و خطوط شبکه را پیکربندی می‌کنند.

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

Aspose.Slides برای Python از طریق .NET به شما امکان می‌دهد تا نمودارهای PowerPoint را با تغییر داده‌های نمودار، قالب‌بندی و استایل به‌روز کنید. این قابلیت فرآیند نگه‌داشتن ارائه‌ها به‌روز با محتوای پویا را ساده می‌کند و اطمینان می‌دهد که نمودارها به‌درستی داده‌های فعلی و استانداردهای بصری را منعکس می‌کنند.

این مثال نمودار با نام "My chart" را در اولین اسلاید یک ارائه موجود به‌روز می‌کند. این نیاز به دو سری ستونی با هر کدام سه نقطه داده دارد، با برچسب‌های دسته در ستون A و نام‌های سری در ردیف اول شیت اول. مثال از [get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) برای تغییر سلول‌های کتاب‌کار استفاده می‌کند، مقادیر سری‌ها را به‌روز می‌کند، یک سری سوم اضافه می‌کند و نمودار را به استوانه‌های خوشه‌ای از طریق [type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/type/) تغییر می‌دهد.

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

## **تنظیم محدوده داده برای یک نمودار**

برای بررسی محدوده‌ای که قبلاً توسط یک نمودار موجود استفاده شده است، به [Retrieve a Chart's Data Range](/slides/fa/python-net/chart-workbook/#retrieve-a-charts-data-range) مراجعه کنید.

Aspose.Slides برای Python از طریق .NET انعطاف‌پذیری تعریف یک محدوده داده خاص از یک شیت را به‌عنوان منبع داده‌های نمودار شما فراهم می‌کند. این به این معناست که می‌توانید بخش خاصی از شیت خود را مستقیماً به نمودار نگاشت کنید و کنترل کنید که کدام سلول‌ها به سری‌ها و دسته‌های نمودار کمک می‌کنند. در نتیجه، می‌توانید به‌ راحتی نمودارهای خود را با آخرین تغییرات داده در شیت به‌روز و همگام کنید و اطمینان حاصل کنید که ارائه‌های PowerPoint شما اطلاعات جاری و دقیق را نشان می‌دهند.

این مثال از [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) برای تنظیم منبع دادهٔ نمودار با نام "My chart" در اولین اسلاید یک ارائه موجود به `Sheet1!A1:B4` استفاده می‌کند. کتاب‌کار نمودار باید آن شیت و یک بازه پرشده با سرصفحهٔ سری در ردیف اول، برچسب‌های دسته در ستون A و سه مقدار در ستون B را داشته باشد.

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

این مثال از [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) برای ایجاد یک نمودار با دو سری خطی و یک افسانه استفاده می‌کند. تنظیمات [marker](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/marker/) نمادهای نشانگر به‌صورت خودکار اختصاص یافته را حفظ می‌کند. سری اول شامل یک مقدار منفی و یک مقدار گمشده است که با `None` نشان داده می‌شود، در حالی که سری دوم برای هر دسته یک مقدار دارد.

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

## **FAQ**

**چه انواع نمودارهایی توسط Aspose.Slides برای Python از طریق .NET پشتیبانی می‌شود؟**

Aspose.Slides برای Python از طریق .NET انواع گسترده‌ای از نمودارها را پشتیبانی می‌کند، از جمله نوار، خط، دایره‌ای، مساحت، پراکنده، هیستوگرام، رادار و بسیاری دیگر. این انعطاف‌پذیری به شما اجازه می‌دهد تا مناسب‌ترین نوع نمودار را برای نیازهای تجسم داده خود انتخاب کنید.

**چگونه یک نمودار جدید به اسلاید اضافه کنم؟**

برای افزودن نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد می‌کنید، اسلاید مورد نظر را با استفاده از ایندکس آن بازیابی می‌کنید، سپس متد افزودن نمودار را فراخوانی می‌کنید و نوع نمودار و داده‌های اولیه را مشخص می‌کنید. این فرآیند نمودار را مستقیماً به ارائه شما ادغام می‌کند.

**چگونه می‌توانم داده‌های نمایش‌داده‌شده در یک نمودار را به‌روزرسانی کنم؟**

می‌توانید داده‌های یک نمودار را با دسترسی به کتاب‌کار داده‌های آن ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))، پاک‌کردن هر سری و دسته پیش‌فرض، و سپس افزودن داده‌های سفارشی‌تان به‌روز کنید. این امکان را می‌دهد که برنامه‌نویسی نمودار را برای بازتاب جدیدترین داده‌ها تازه‌سازی کنید.

**آیا امکان سفارشی‌سازی ظاهر نمودار وجود دارد؟**

بله، Aspose.Slides برای Python از طریق .NET گزینه‌های سفارشی‌سازی گسترده‌ای را فراهم می‌کند. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، افسانه‌ها و سایر عناصر قالب‌بندی را برای تطبیق ظاهر نمودار با نیازهای طراحی خاص خود تغییر دهید.