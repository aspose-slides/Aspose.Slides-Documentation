---
title: مدیریت برچسب‌های دادهٔ نمودار در ارائه‌ها با پایتون
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
description: "یاد بگیرید چگونه برچسب‌های دادهٔ نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Python از طریق .NET اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده اطلاعاتی دربارهٔ سری‌های نمودار و نقاط دادهٔ منفرد را نشان می‌دهند، به خوانندگان کمک می‌کند تا مقادیر را شناسایی کرده و نمودار را درک کنند. این مقاله توضیح می‌دهد چگونه مقادیر را قالب‌بندی کنید، درصدها را نمایش دهید، متن برچسب را بخوانید، برچسب‌ها را فراتر از حداکثر محور کنترل کنید، فاصلهٔ برچسب‌های محور دسته‌بندی را تنظیم کنید و موقعیت برچسب‌های نمودار دایره‌ای را تنظیم کنید.

## **شمارش برچسب‌های دادهٔ قابل مشاهده**

از [count_of_visible_data_labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/count_of_visible_data_labels/) برای بررسی تعداد برچسب‌های داده‌ای که برای نمایش فعال هستند قبل از انتشار یک ارائه استفاده کنید. بر خلاف `len(labels)` که تعداد کل برچسب‌های موجود در مجموعه را برمی‌گرداند، این متد پیش‌فرض‌های سری و تنظیمات برچسب فردی را در نظر می‌گیرد.

این مثال یک نمودار ستونی با یک سری و سه نقطه داده ایجاد می‌کند. به مجموعهٔ [labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/labels/) سری دسترسی پیدا می‌کند و شمارش قابل مشاهده را با تغییر تنظیمات چاپ می‌کند: **0, 3, 2, 3**. شمارش کل **3** باقی می‌ماند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    series_cell = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_cell, chart.type)

    for i in range(3):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    labels = series.labels
    print(f"Total: {len(labels)}; visible: {labels.count_of_visible_data_labels}")  # کل: 3; قابل مشاهده: 0

    labels.default_data_label_format.show_value = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # قابل مشاهده: 3

    labels[1].data_label_format.show_value = False
    print(f"Visible: {labels.count_of_visible_data_labels}")  # قابل مشاهده: 2

    labels[1].data_label_format.show_legend_key = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # قابل مشاهده: 3
```

سلسلهٔ [default_data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/default_data_label_format/) تنظیمات پیش‌فرض را فراهم می‌کند. فعال کردن [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) در آن مقادیر را برای هر سه برچسب نمایش می‌دهد. تنظیم آن به `False` از طریق [data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/data_label_format/) یک برچسب خاص، این تنظیم را برای برچسب انتخاب‌شده بازنویسی می‌کند. فعال کردن [show_legend_key](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_legend_key/) باعث می‌شود آن برچسب دوباره به‌عنوان قابل مشاهده شمارش شود، حتی اگر مقدار آن مخفی بماند.

شمارش قابل مشاهده بازتاب تنظیمات نمایش است. این شمارش میزان هم‌پوشانی، قطع شدن یا خوانایی برچسب‌ها در نمودار رندر شده را اندازه‌گیری نمی‌کند.

## **تنظیم دقت عددی در برچسب‌های دادهٔ نمودار**

از [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) برای قالب‌بندی مقادیر سری استفاده کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده آن را نمایش می‌دهد و برچسب‌های مقدار را برای اولین سری فعال می‌کند. قالب `#,##0.00` جداکننده هزارگان و دو رقم اعشار را بدون تغییر مقادیر زیرین نمایش می‌دهد.

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

برای قالب‌بندی سلول‌های عددی در کتاب‌کار توکار یک نمودار، به [تنظیم قالب‌های سفارشی عدد برای سلول‌های کتاب کار](/slides/fa/python-net/chart-workbook/#set-custom-number-formats-for-workbook-cells) نگاه کنید. آن مثال همچنین نشان می‌دهد برچسب‌های مقدار چگونه قالب‌های سلول منبع را دنبال می‌کنند در حالی که مقادیر عددی ذخیره‌شده حفظ می‌شوند.

## **نمایش درصد به‌عنوان برچسب‌ها**

برای یک نمودار ستونی انباشته، هر مقدار را به‌عنوان درصدی از مجموع دستهٔ مربوطه محاسبه کنید و متن را به [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) اختصاص دهید. این مثال از داده‌های پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در قلم 8 نقطه‌ای نمایش می‌دهد. دسته‌هایی که مجموعشان صفر است برای جلوگیری از تقسیم بر صفر حذف می‌شوند. در صورت تغییر داده‌های نمودار، متن برچسب سفارشی مجدداً محاسبه شود.

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

## **تنظیم علامت درصد با برچسب‌های دادهٔ نمودار**

زمانی که مقادیر به صورت کسری ذخیره می‌شوند، از [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) برای نمایش درصدها استفاده کنید. [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) را به `False` تنظیم کنید تا قالب برچسب به‌صورت مستقل از سلول‌های منبع اعمال شود.

این مثال یک نمودار ستونی 100٪ انباشته با سری‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار به‌جمع می‌رسد به 1. قالب برچسب `0.0%` مقدار 0.30 را به‌صورت 30.0٪ نمایش می‌دهد، در حالی که محور عمودی دو رقم اعشار دارد. هر دو سری متن برچسب سفید با اندازه 10 نقطه‌ای استفاده می‌کنند.

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

از [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) برای بازیابی متنی که توسط تنظیمات یک برچسب داده تولید می‌شود استفاده کنید. این کار هنگام استخراج برچسب‌ها برای گزارش‌ها، جستجو در محتوای ارائه یا اعتبارسنجی نمودارهای تولیدشده مفید است. در مثال زیر، قالب پیش‌فرض [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) نام هر دسته، نام سری و مقدار را ترکیب می‌کند. یک نقطه مقدار را به‌صورت درصد قالب‌بندی می‌کند و دیگری متن سفارشی از [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) استفاده می‌کند.

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

عدد ذخیره‌شده در یک نقطه داده همچنان `0.75` باقی می‌ماند، حتی اگر برچسب آن `75%` را همراه با نام دسته و سری نشان دهد. متن سفارشی متن تولیدشدهٔ برچسب را جایگزین می‌کند. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) رشتهٔ برچسب نهایی را در هر دو حالت برمی‌گرداند. به‌طور جداگانه [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) را بررسی کنید، همان‌طور که در بالا نشان داده شد، وقتی فقط می‌خواهید برچسب‌های قابل مشاهده را استخراج کنید.

## **کنترل برچسب‌های داده فراتر از حداکثر محور**

هنگامی که محدودهٔ محور را به‌صورت دستی محدود می‌کنید، ممکن است برخی نقاط داده از حداکثر آن عبور کنند. از [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) برای کنترل اینکه آیا برچسب‌های دادهٔ آن‌ها نمایش داده شوند یا نه استفاده کنید. این تنظیم قابلیت نمایش برچسب را تغییر می‌دهد؛ محدودهٔ محور یا مقادیر دادهٔ زیرین را تغییر نمی‌دهد.

مثال زیر یک نمودار ستونی خوشه‌ای 2D با مقادیر 60 و 120 ایجاد می‌کند. [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) را روی `False` و [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) را بر روی 100 در محور عمودی تنظیم می‌کند. اسلاید اول اجازه می‌دهد برچسب‌ها فراتر از حداکثر باشند؛ یک نسخهٔ آن اسلاید این برچسب‌ها را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

با [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) برچسب‌های مقدار را فعال کنید. تنظیم در سطح نمودار به‌تنهایی نمایش مقدار را فعال نمی‌کند و یا تنظیم غیر فعال مقدار برچسب فردی را نادیده نمی‌گیرد. این مثال مقادیر را برای کل سری فعال می‌کند و از [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) برای قرار دادن برچسب‌ها در انتهای بیرونی هر ستون استفاده می‌کند.

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

تصاویر زیر اسلایدهای ذخیره‌شده را که توسط Microsoft PowerPoint رندر شده‌اند نشان می‌دهند. با `True`، برچسب **120** در حد بالایی قابل مشاهده است؛ با `False` مخفی می‌شود. برچسب **60** همچنان قابل مشاهده است، حداکثر محور در **100** باقی می‌ماند و نقطه دادهٔ دوم در هر دو حالت **120** می‌ماند.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 نشان می‌دهد](data-labels-over-maximum-true.png) | ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 مخفی می‌کند](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
این مثال از یک نمودار ستونی 2D با محور مقدار استفاده می‌کند. نمودارهایی که محور مقدار ندارند، مانند نمودارهای دایره‌ای و دونات، حداکثر محور برای محدود کردن به این شکل ندارند.
{{% /alert %}}

## **تنظیم فاصله برچسب از محور**

از [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) برای کنترل فاصله بین برچسب‌های محور دسته‌بندی و خود محور استفاده کنید. مقدار این ویژگی درصدی از حداکثر اندازه قلم برچسب‌های محور است. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و مقدار [label_offset] محور افقی را روی 500 تنظیم می‌کند. این تنظیم برچسب‌های محور دسته‌بندی را تحت تأثیر قرار می‌دهد نه برچسب‌های متصل به نقاط دادهٔ منفرد.

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

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را برای بهبود فواصل و ایجاد فضا برای خطوط رهبری تنظیم کنید.

این مثال مقدار اولین نقطه داده را نمایش می‌دهد، برچسب آن را بیرون از قطعه قرار می‌دهد و افست‌های [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) و [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) آن را تنظیم می‌کند. این افست‌ها به ترتیب نسبت به عرض و ارتفاع نمودار بیان شده‌اند.

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

## **قالب‌بندی خطوط رهبری**

هنگامی که برچسب‌های نمودار دایره‌ای در خارج از قطعات خود قرار می‌گیرند، خطوط رهبری به خوانندگان کمک می‌کند تا هر مقدار را با قطعهٔ مناسب مطابقت دهند. یک رنگ متضاد و خط کمی ضخیم‌تر می‌تواند این اتصالات را قابل پیگیری‌تر کند، در حالی که شفافیت و سبک نقطه‌چین خطوط را به‌صورت بصری کم‌تداخل نگه می‌دارد.

از [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) برای قالب‌بندی خطوط رهبری در سطح مجموعهٔ برچسب‌های دادهٔ سری استفاده کنید. تنظیمات در `series.labels.leader_lines_format.line` بر کل مجموعه اعمال می‌شود، نه بر یک برچسب منفرد.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند، مقادیر را در خارج از قطعات نشان می‌دهد و [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/) را فعال می‌کند. دو برچسب را با استفاده از افست‌های [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) و [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) که به‌صورت کسرهای عرض و ارتفاع نمودار بیان شده‌اند، از قطعات خود دورتر می‌برد. ارائه ورودی مورد نیاز نیست.

[fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) خط را با رنگ آبی ثابت و مقدار آلفای 191 از 255 تنظیم می‌کند که تقریباً 25٪ شفافیت می‌دهد. [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) ضخامت را به 2 نقطه تنظیم می‌کند و [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) خط را نقطه‌چین می‌کند.

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

    # دو برچسب را از قطعات خود دورتر منتقل کنید.
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

فعال‌سازی خطوط رهبری تضمین نمی‌کند که برای هر برچسب یک خط ظاهر شود. قابلیت مشاهده به موقعیت برچسب و رفتار چیدمان نمودار بستگی دارد. در این مثال، دو برچسب جابجا شده دارای خطوط رهبری قابل مشاهده هستند؛ برچسب‌هایی که نزدیک به قطعات خود می‌مانند به این خطوط نیازی ندارند.

تصویر زیر `FormattedLeaderLines.pptx` ذخیره‌شده را که با Aspose.Slides رندر شده است نشان می‌دهد:

![نمودار دایره‌ای با خطوط رهبری آبی، نیمه‌شفاف و نقطه‌چین که دو برچسب بیرونی را به قطعات خود متصل می‌کند](formatted-leader-lines.png)

## **افزودن ردیف‌های متعدد برچسب‌های داده در بالای نمودار ستونی**

این مثال یک نمودار ستونی با دو ردیف برچسب داده در بالای ناحیهٔ ترسیم ایجاد می‌کند. سری A ستون‌های قابل مشاهده را نمایش می‌دهد، در حالی که سری‌های B و C برچسب‌های اضافی را فراهم می‌کنند. ستون‌های آن‌ها با حذف پر و خط حاشیه مخفی می‌شوند. ویژگی [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) تمام سه سری را با مراکز دستهٔ یکسان هماهنگ می‌کند.

تنظیمات [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) فضای لازم برای ردیف‌های برچسب را رزرو می‌کند. پس از محاسبه موقعیت‌های پیش‌فرض توسط [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)، افست‌های [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) و [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) تراز افقی را حفظ می‌کند و افست‌های عمودی را برای چیدمان برچسب‌ها در دو ردیف اعمال می‌کند. اعداد همچنان برچسب‌های دادهٔ مرتبط با مقادیر سری‌ها هستند؛ تنها عنوان‌های ردیف به‌صورت اشکال متنی جداگانه هستند.

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
            # ستون‌های B و C را پنهان کنید، اما برچسب‌های داده آن‌ها را نگه دارید.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # تمام سه سری را با مراکز دسته یکسان هم‌راستا کنید.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # برای این مثال فشرده خطوط شبکه کمتری استفاده کنید.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # فضای بالای نمودار را برای دو ردیف برچسب داده اختصاص دهید.
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
            # موقعیت افقی پیش‌فرض را حفظ کنید. Y یک افست از
            # موقعیت پیش‌فرض برچسب است، به‌صورت کسری از ارتفاع نمودار بیان شده.
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

![نمودار ستونی با دو ردیف برچسب داده در بالای ناحیهٔ ترسیم](multiple-rows-of-labels.png)

## **سوالات متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای متراکم جلوگیری کنم؟**

ترکیب جایگذاری خودکار برچسب‌ها، خطوط رهبری و کاهش اندازه قلم؛ در صورت لزوم برخی فیلدها (به‌عنوان مثال، دسته) را مخفی کنید یا فقط برچسب‌ها را برای مقادیر افراطی یا نقاط کلیدی نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

قبل از فعال‌سازی برچسب‌ها نقاط داده را فیلتر کنید و نمایش مقادیر 0، مقادیر منفی یا مقادیر گمشده را بر اساس قانونی تعریف‌شده خاموش کنید.

**چگونه می‌توانم سبک برچسب‌ها را هنگام خروجی به PDF/تصاویر ثابت نگه دارم؟**

به‌صورت صریح خانواده و اندازه قلم را تنظیم کنید و اطمینان حاصل کنید که قلم در محیط رندر موجود است تا از استفادهٔ قلم پیش‌فرض جلوگیری شود.