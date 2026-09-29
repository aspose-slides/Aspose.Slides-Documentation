---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها با پایتون
linktitle: برچسب داده
type: docs
url: /fa/python-net/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- موقعیت برچسب
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای پایتون از طریق .NET اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده اطلاعاتی دربارهٔ سری‌های نمودار و نقاط دادهٔ فردی نمایش می‌دهند و به خوانندگان کمک می‌کنند ارزش‌ها را شناسایی کرده و نمودار را درک کنند. این مقاله توضیح می‌دهد چگونه مقادیر را قالب‌بندی کنیم، درصدها را نمایش دهیم، متن برچسب را بخوانیم، برچسب‌ها را فراتر از حداکثر محور کنترل کنیم، فاصلهٔ برچسب‌های محور دسته‌بندی را تنظیم کنیم و مکان برچسب‌های نمودار دایره‌ای را تعیین کنیم.

## **تنظیم دقت داده در برچسب‌های داده نمودار**

از [number_format_of_values](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chartseries/number_format_of_values/) برای قالب‌بندی مقادیر سری‌ها استفاده کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده‌های آن را نمایش می‌دهد و برچسب‌های مقدار را برای اولین سری فعال می‌سازد. قالب `#,##0.00` جداکنندهٔ هزارها و دو رقم اعشار را نمایش می‌دهد بدون اینکه مقادیر اصلی تغییر کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **نمایش درصد به عنوان برچسب‌ها**

برای یک نمودار ستونی پشته‌ای، هر مقدار را به‌عنوان درصدی از مجموع دستهٔ خود محاسبه کنید و متن را به [text_frame_for_overriding](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) اختصاص دهید. این مثال از داده‌های پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در قلم ۸ نقطه‌ای نشان می‌دهد. دسته‌های با مجموع صفر نادیده گرفته می‌شوند تا از تقسیم بر صفر جلوگیری شود. اگر داده‌های نمودار تغییر کنند، متن برچسب سفارشی را دوباره محاسبه کنید.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم علامت درصد با برچسب‌های داده نمودار**

هنگامی که مقادیر به صورت کسر ذخیره می‌شوند، از [number_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabelformat/number_format/) برای نمایش درصدها استفاده کنید. برای اعمال قالب برچسب به‌طور مستقل از سلول‌های منبع، [is_number_format_linked_to_source](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) را به `False` تنظیم کنید.

این مثال یک نمودار ستونی پشته‌ای 100٪ با سری‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار به 1 می‌رسد. قالب برچسب `0.0%`، مقدار 0.30 را به‌عنوان 30.0٪ نمایش می‌دهد، در حالی که محور عمودی از دو رقم اعشار استفاده می‌کند. هر دو سری از متن برچسب سفید با اندازهٔ ۱۰ نقطه استفاده می‌کنند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **خواندن متن واقعی برچسب‌های داده**

از [get_actual_label_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) برای بازیابی متنی که توسط تنظیمات یک برچسب داده تولید شده است استفاده کنید. این کار هنگام استخراج برچسب‌ها برای گزارش‌ها، جستجو در محتوای ارائه یا اعتبارسنجی نمودارهای تولید شده مفید است. در مثال زیر، [data label format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabelformat/) پیش‌فرض هر نام دسته، نام سری و مقدار را ترکیب می‌کند. یک نقطه مقدار خود را به‌عنوان درصد قالب‌بندی می‌کند و دیگری از متن سفارشی از [text_frame_for_overriding](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) استفاده می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

عدد ذخیره‌شده در یک نقطه داده همچنان `0.75` باقی می‌ماند، حتی اگر برچسب آن `75%` را همراه با نام‌های دسته و سری نشان دهد. متن سفارشی متن برچسب تولید شده را جایگزین می‌کند. [get_actual_label_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) در هر دو حالت رشتهٔ برچسب حاصل را برمی‌گرداند. برای استخراج فقط برچسب‌های قابل مشاهده، همان‌طور که در بالا نشان داده شد، به‌صورت جداگانه [is_visible](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabel/is_visible/) را بررسی کنید.

## **کنترل برچسب‌های داده فراتر از حداکثر محور**

زمانی که بازهٔ محور را به‌صورت دستی محدود می‌کنید، ممکن است برخی نقاط داده از حداکثر آن فراتر روند. از [show_data_labels_over_maximum](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) برای کنترل نمایش برچسب‌های دادهٔ آن‌ها استفاده کنید. این تنظیم نمایش برچسب را تغییر می‌دهد؛ بازهٔ محور یا مقادیر دادهٔ زیرین را تغییر نمی‌دهد.

مثال زیر یک نمودار ستونی خوشه‌ای 2D با مقادیر 60 و 120 ایجاد می‌کند. بر روی محور عمودی، [is_automatic_max_value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/axis/is_automatic_max_value/) را به `False` و [max_value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/axis/max_value/) را به 100 تنظیم می‌کند. اسلاید اول برچسب‌هایی فراتر از حداکثر را اجازه می‌دهد؛ یک کپی از آن اسلاید این برچسب‌ها را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

برچسب‌های مقدار را با [show_value](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabelformat/show_value/) فعال کنید. تنظیم سطح نمودار به تنهایی نمایش مقدار را فعال نمی‌کند و تنظیم غیرفعال کردن نمایش مقدار برای یک برچسب خاص را بازنویسی نمی‌کند. این مثال مقادیر را برای تمام سری فعال می‌کند و با استفاده از [position](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabelformat/position/) برچسب‌ها را در انتهای بیرونی هر ستون قرار می‌دهد.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

تصاویر زیر اسلایدهای ذخیره‌شده را که توسط Microsoft PowerPoint رندر شده‌اند نشان می‌دهند. با مقدار `True`، برچسب **120** در مرز بالایی قابل مشاهده است؛ با مقدار `False`، مخفی می‌شود. برچسب **60** قابل مشاهده می‌ماند، حداکثر محور در **100** باقی می‌ماند و نقطه دادهٔ دوم در هر دو حالت **120** می‌ماند.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
این مثال از یک نمودار ستونی 2D با محور مقدار استفاده می‌کند. نمودارهایی که محور مقدار ندارند، مانند نمودارهای دایره‌ای و دونات، حداکثر محور ندارند که بتوان به این شکل محدودشان کرد.
{{% /alert %}}

## **تنظیم فاصله برچسب از محور**

از [label_offset](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/axis/label_offset/) برای کنترل فاصله میان برچسب‌های محور دسته‌بندی و محور استفاده کنید. مقدار برحسب درصدی از حداکثر اندازهٔ قلم برچسب‌های محور است. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و فاصلهٔ برچسب محور افقی را به 500 تنظیم می‌کند. این تنظیم بر برچسب‌های محور دسته‌بندی اثر می‌گذارد نه بر برچسب‌های متصل به نقاط دادهٔ فردی.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم مکان برچسب**

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را تنظیم کنید تا فاصله بهبود یابد و فضای کافی برای خطوط راهنمایی فراهم شود.

این مثال مقدار اولین نقطه داده را نمایش می‌دهد، برچسب آن را بیرون از قطعه قرار می‌دهد و جابجایی‌های [x](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabel/x/) و [y](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datalabel/y/) آن را تنظیم می‌کند. این جابجایی‌ها به ترتیب نسبت به عرض و ارتفاع نمودار هستند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **سوالات متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای شلوغ جلوگیری کنم؟**

از ترکیب جایگذاری خودکار برچسب‌ها، خطوط راهنما و کاهش اندازه قلم استفاده کنید؛ در صورت لزوم برخی فیلدها (مثلاً دسته) را پنهان کنید یا فقط برای مقادیر افراطی یا نقاط کلیدی برچسب‌ها را نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

نقاط داده را قبل از فعال‌سازی برچسب‌ها فیلتر کنید و نمایش مقادیر 0، مقادیر منفی یا مقادیر گمشده را بر اساس یک قانون تعریف‌شده غیرفعال نمایید.

**چگونه می‌توانم اطمینان حاصل کنم که سبک برچسب‌ها در هنگام خروجی به PDF/تصاویر ثابت بماند؟**

به‌صورت صریح خانوادهٔ قلم و اندازهٔ آن را تنظیم کنید و اطمینان حاصل کنید که قلم در محیط رندر موجود است تا از استفادهٔ جایگزین جلوگیری شود.