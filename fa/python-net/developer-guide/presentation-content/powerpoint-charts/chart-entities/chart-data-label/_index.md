---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها با Python
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
description: "یاد بگیرید چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Python via .NET اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **معرفی**

برچسب‌های داده اطلاعاتی دربارهٔ سری‌های نمودار و نقاط دادهٔ فردی نمایش می‌دهند و به خوانندگان کمک می‌کنند مقادیر را شناسایی کرده و نمودار را درک کنند. این مقاله توضیح می‌دهد چگونه مقادیر را قالب‌بندی کنیم، درصدها را به‌عنوان برچسب نمایش دهیم، متن برچسب را بخوانیم، برچسب‌ها را خارج از حداکثر محور کنترل کنیم، فاصلهٔ برچسب محور دسته‌بندی را تنظیم کنیم و موقعیت برچسب‌های نمودار دایره‌ای را تعیین کنیم.

## **تنظیم دقت داده در برچسب‌های داده نمودار**

از [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) برای قالب‌بندی مقادیر سری‌ها استفاده کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده‌ها را نمایش می‌دهد و برچسب‌های مقدار را برای سری اول فعال می‌کند. قالب `#,##0.00` یک جداکنندهٔ هزارگان و دو رقم اعشار را بدون تغییر مقادیر اصلی نشان می‌دهد.

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

## **نمایش درصد به‌عنوان برچسب‌ها**

برای یک نمودار ستونی انباشته، هر مقدار را به‌عنوان درصدی از مجموع دستهٔ مربوطه محاسبه کنید و متن را به [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) اختصاص دهید. این مثال از داده‌های پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در یک فونت ۸ نقطه‌ای نمایش می‌دهد. دسته‌هایی که مجموعشان صفر است برای جلوگیری از تقسیم بر صفر نادیده گرفته می‌شوند. اگر داده‌های نمودار تغییر کند، متن برچسب سفارشی باید دوباره محاسبه شود.

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

زمانی که مقادیر به‌صورت کسر ذخیره می‌شوند، از [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) برای نمایش درصدها استفاده کنید. برای اعمال قالب برچسب مستقل از سلول‌های منبع، [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) را به `False` تنظیم کنید.

این مثال یک نمودار ستونی ۱۰۰٪ انباشته با سری‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار به مجموع ۱ می‌رسد. قالب برچسب `0.0%` مقدار 0.30 را به‌صورت 30.0% نشان می‌دهد و محور عمودی دو رقم اعشار دارد. هر دو سری از متن برچسب سفید با اندازهٔ ۱۰ نقطه استفاده می‌کنند.

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

از [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) برای بازیابی متنی که تنظیمات برچسب داده تولید می‌کند، استفاده کنید. این کار هنگام استخراج برچسب‌ها برای گزارش‌ها، جستجوی محتوای ارائه یا اعتبارسنجی نمودارهای تولید شده مفید است. در مثال زیر، قالب پیش‌فرض [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) نام هر دسته، نام سری و مقدار را ترکیب می‌کند. یک نقطه مقدار خود را به‌صورت درصد قالب‌بندی می‌کند و نقطهٔ دیگر متن سفارشی را از [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) می‌گیرد.

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

عدد ذخیره‌شده در یک نقطه داده همچنان `0.75` می‌ماند، حتی زمانی که برچسب آن `75%` را همراه با نام دسته و سری نشان می‌دهد. متن سفارشی متن برچسب تولید‌شده را جایگزین می‌کند. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) در هر دو حالت رشتهٔ نهایی برچسب را برمی‌گرداند. همانطور که در بالا نشان داده شد، برای استخراج فقط برچسب‌های قابل مشاهده، به‌طور جداگانه [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) را بررسی کنید.

## **کنترل برچسب‌های داده خارج از حداکثر محور**

زمانی که بازهٔ محور را به‌صورت دستی محدود می‌کنید، ممکن است برخی نقاط داده از حداکثر آن فراتر بروند. از [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) برای کنترل نمایش برچسب‌های دادهٔ این نقاط استفاده کنید. این تنظیم فقط نمایانی برچسب را تغییر می‌دهد؛ بازهٔ محور یا مقادیر دادهٔ اصلی را تغییر نمی‌دهد.

مثال زیر یک نمودار ستونی خوشه‌ای ۲‑بعدی با مقادیر ۶۰ و ۱۲۰ می‌سازد. برای محور عمودی، [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) را به `False` و [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) را به ۱۰۰ تنظیم می‌کند. اسلاید اول اجازه می‌دهد برچسب‌ها پشت حداکثر ظاهر شوند؛ نسخهٔ کپی شده آن این قابلیت را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

برچسب‌های مقدار را با [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) فعال کنید. تنظیم سطح نمودار به‌تنهایی نمایش مقدار را فعال نمی‌کند و تنظیم برچسب فردی که نمایش مقدار غیرفعال است را نیز نادیده نمی‌گیرد. این مثال مقادیر را برای تمام سری فعال می‌کند و با استفاده از [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) برچسب‌ها را در انتهای بیرونی هر ستون قرار می‌دهد.

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

تصاویر زیر اسلایدهای ذخیره‌شده را که توسط Microsoft PowerPoint رندر شده‌اند نشان می‌دهند. با `True`، برچسب **120** در مرز بالا قابل دیده شدن است؛ با `False`، مخفی می‌شود. برچسب **60** همچنان دیده می‌شود، حداکثر محور در **100** باقی می‌ماند و نقطهٔ دادهٔ دوم در هر دو حالت **120** است.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 نشان می‌دهد](data-labels-over-maximum-true.png) | ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 مخفی می‌کند](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
این مثال از یک نمودار ستونی ۲‑بعدی با محور مقدار استفاده می‌کند. نمودارهایی که محور مقدار ندارند، مانند نمودارهای دایره‌ای و دونات، حداکثر محوری برای محدود کردن به این روش ندارند.
{{% /alert %}}

## **تنظیم فاصلهٔ برچسب از محور**

از [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) برای کنترل فاصله بین برچسب‌های محور دسته‌بندی و خود محور استفاده کنید. مقدار به‌صورت درصدی از حداکثر اندازهٔ قلم برچسب‌های محور محاسبه می‌شود. این مثال یک نمودار ستونی خوشه‌ای می‌سازد و مقدار جابه‌جایی برچسب محور افقی را روی ۵۰۰ تنظیم می‌کند. این تنظیم برچسب‌های محور دسته‌بندی را تحت تأثیر قرار می‌دهد نه برچسب‌های الصاق‌شده به نقاط دادهٔ فردی.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم موقعیت برچسب**

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را برای بهبود فاصله‌ها و ایجاد فضا برای خطوط راهنما تنظیم کنید.

این مثال مقدار اولین نقطه داده را نمایش می‌دهد، برچسب آن را بیرون از قطعه قرار می‌دهد و جابه‌جایی‌های [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) و [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) آن را تنظیم می‌کند. این جابه‌جایی‌ها به‌صورت نسبی به عرض و ارتفاع نمودار هستند.

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

![نمودار دایره‌ای با موقعیت برچسب داده تنظیم‌شده](pie-chart-adjusted-label.png)

## **قالب‌بندی خطوط راهنما**

زمانی که برچسب‌های نمودار دایره‌ای خارج از قطعاتشان قرار دارند، خطوط راهنما به خوانندگان کمک می‌کند هر مقدار را با قطعهٔ صحیح مرتبط کنند. یک رنگ کنتراستدار و کمی ضخیم‌تر شدن خط می‌تواند این ارتباط را قابل پیگیری‌تر کند، در حالی که شفافیت و سبک خط‌چین ظاهر خطوط را کم‌تداخل نگه می‌دارد.

از [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) برای قالب‌بندی خطوط راهنما در سطح مجموعهٔ برچسب‌های دادهٔ سری استفاده کنید. تنظیمات موجود در `series.labels.leader_lines_format.line` بر تمام مجموعه اعمال می‌شود نه بر یک برچسب منفرد.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض می‌سازد، مقادیر را خارج از قطعات نمایش می‌دهد و [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/) را فعال می‌کند. دو برچسب با استفاده از جابه‌جایی‌های [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) و [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) به‌صورت کسری از عرض و ارتفاع نمودار دورتر از قطعاتشان حرکت می‌کنند. هیچ ارائهٔ ورودی لازم نیست.

[fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) خط را با رنگ آبی صلح‌آمیز و مقدار آلفای ۱۹۱ از ۲۵۵ (حدود ۲۵٪ شفافیت) تنظیم می‌کند. [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) ضخامت را به ۲ پوینت می‌برد و [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) خط را خط‌چین می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # دو برچسب را دورتر از قطعاتشان حرکت دهید.
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

فعال‌سازی خطوط راهنما تضمین نمی‌کند که برای هر برچسب یک خط ظاهر شود. نمایانی بستگی به موقعیت برچسب و رفتار چیدمان نمودار دارد. در این مثال، دو برچسب جابه‌جا شده خطوط راهنمای قابل مشاهده دارند؛ برچسب‌هایی که نزدیک به قطعاتشان می‌مانند نیازی به آن‌ها ندارند.

تصویر زیر `FormattedLeaderLines.pptx` ذخیره‌شده را که با Aspose.Slides رندر شده نشان می‌دهد:

![نمودار دایره‌ای با خطوط راهنمای آبی، نیمه‌شفاف، خط‌چین که دو برچسب بیرونی را به قطعاتشان متصل می‌کند](formatted-leader-lines.png)

## **افزودن چند ردیف برچسب داده بالای نمودار ستونی**

این مثال یک نمودار ستونی با دو ردیف برچسب داده بالای ناحیهٔ رسم ایجاد می‌کند. سری A ستون‌های قابل مشاهده را نمایش می‌دهد، در حالی که سری B و سری C برچسب‌های اضافی را فراهم می‌کنند. ستون‌های آن‌ها با حذف پر و کمرنگ کردن خط مرزی مخفی می‌شوند. ویژگی [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) تمام سه سری را در مراکز یکسان دسته‌ها هم‌راستا می‌کند.

تنظیمات [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) فضای لازم برای ردیف‌های برچسب را محفوظ می‌دارد. پس از محاسبهٔ موقعیت‌های پیش‌فرض توسط [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)، جابه‌جایی‌های [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) و [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) تراز افقی را حفظ می‌کنند و جابه‌جایی‌های عمودی را برای چیدمان برچسب‌ها در دو ردیف اعمال می‌کنند. اعداد همچنان برچسب‌های دادهٔ پیوند‌شده به مقادیر سری‌ها باقی می‌مانند؛ تنها سرصفحه‌های ردیف به‌صورت شکل‌های متنی جداگانه هستند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # ستون‌های B و C را مخفی کنید، اما برچسب‌های دادهٔ آن‌ها را نگه دارید.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # هم‌راستا کردن هر سه سری با مراکز یکسان دسته‌ها.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # استفاده از خطوط شبکه کمتر برای این مثال فشرده.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # رزرو فضای بالای نمودار برای دو ردیف برچسب داده.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # موقعیت افقی پیش‌فرض را حفظ کنید. Y یک جابجایی است از
            # موقعیت پیش‌فرض برچسب، بیان‌شده به‌عنوان کسری از ارتفاع نمودار.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # فقط عنوان ردیف یک شکل متنی جداگانه است.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![نمودار ستونی با دو ردیف برچسب داده بالای ناحیهٔ رسم](multiple-rows-of-labels.png)

## **سوالات متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای متراکم جلوگیری کنم؟**

جای‌گذاری خودکار برچسب‌ها، خطوط راهنما و کاهش اندازهٔ قلم را ترکیب کنید؛ در صورت لزوم برخی فیلدها (مثلاً دسته) را مخفی کنید یا فقط برای مقادیر انتهایی یا نقاط کلیدی برچسب‌ها را نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

قبل از فعال‌سازی برچسب‌ها، نقاط داده را فیلتر کنید و نمایش مقادیر ۰، مقادیر منفی یا مقادیر گمشده را براساس قانون تعریف‌شده غیرفعال کنید.

**چگونه می‌توانم سبک برچسب را هنگام خروجی به PDF/تصاویر ثابت نگه دارم؟**

به‌طور صریح خانواده و اندازهٔ قلم را تنظیم کنید و اطمینان حاصل کنید که قلم موردنظر در محیط رندر موجود است تا از استفاده از قلم پیش‌فرض جلوگیری شود.