---
title: إدارة تسميات بيانات المخططات في العروض التقديمية باستخدام Python
linktitle: تسمية البيانات
type: docs
url: /ar/python-net/chart-data-label/
keywords:
- مخطط
- تسمية البيانات
- دقة البيانات
- نسبة مئوية
- مسافة التسمية
- موضع التسمية
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم إضافة وتنسيق تسميات بيانات المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ Python عبر .NET للحصول على شرائح أكثر جاذبية."
---
## **مقدمة**

تُظهر تسميات البيانات معلومات حول سلاسل المخططات ونقاط البيانات الفردية، مما يساعد القارئ على التعرف على القيم وفهم المخطط. يوضح هذا المقال كيفية تنسيق القيم، عرض النسب المئوية، قراءة نص التسمية، التحكم في التسميات خارج الحد الأقصى للمحور، ضبط تباعد تسميات محور الفئات، وتحديد موضع تسميات مخطط الفطيرة.

## **ضبط دقة البيانات في تسميات بيانات المخطط**

استخدم [number_format_of_values](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/number_format_of_values/) لتنسيق قيم السلسلة. يُنشئ هذا المثال مخطط خط مع بيانات افتراضية، يعرض جدول البيانات الخاص به، ويفعل تسميات القيم للسلسلة الأولى. يعرض التنسيق `#,##0.00` فاصل الآلاف ومكانين عشريين دون تغيير القيم الأساسية.

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

## **عرض النسبة المئوية كتسميات**

في مخطط أعمدة مكدس، احسب كل قيمة كنسبة مئوية من إجمالي الفئة وقم بتعيين النص إلى [text_frame_for_overriding](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين بخط 8 نقاط. تُتجاوز الفئات التي مجموعها صفر لتجنب القسمة على صفر. أعد حساب نص التسمية المخصص إذا تغيرت بيانات المخطط.

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

## **ضبط علامة النسبة المئوية مع تسميات بيانات المخطط**

عند تخزين القيم ككسور، استخدم [number_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabelformat/number_format/) لعرض النسب المئوية. اضبط [is_number_format_linked_to_source](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) على `False` لتطبيق تنسيق التسمية بشكل مستقل عن خلايا المصدر.

ينشئ هذا المثال مخطط أعمدة مكدس بنسبة 100% مع سلسلتين حمراء وزرقاء عبر أربع فئات. كل زوج من القيم يساوي 1. يعرض تنسيق التسمية `0.0%` القيمة 0.30 كـ30.0%، بينما يستخدم المحور العمودي مكانين عشريين. تستخدم السلسلتان نصًا أبيض بحجم 10 نقاط للتسمية.

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

## **قراءة النص الفعلي لتسميات البيانات**

استخدم [get_actual_label_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) لاسترجاع النص الناتج عن إعدادات تسمية البيانات. يكون هذا مفيدًا عند استخراج التسميات للتقارير، البحث في محتوى العرض التقديمي، أو التحقق من صحة المخططات المُنشأة. في المثال أدناه، يجمع [data label format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabelformat/) الافتراضي كل اسم فئة، اسم سلسلة، والقيمة. تنسق نقطة واحدة قيمتها كنسبة مئوية، وتستخدم أخرى نصًا مخصصًا من [text_frame_for_overriding](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

يبقى الرقم المخزن في نقطة البيانات `0.75`، حتى عندما تعرض تسميتها `75%` مع أسماء الفئة والسلسلة. يستبدل النص المخصص النص المُولد للتسمية. تُعيد [get_actual_label_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) سلسلة التسمية الناتجة في الحالتين. تحقّق من [is_visible](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/is_visible/) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج التسميات الظاهرة فقط.

## **التحكم في تسميات البيانات خارج الحد الأقصى للمحور**

عند تقييد نطاق المحور يدويًا، قد تتجاوز بعض نقاط البيانات الحد الأقصى. استخدم [show_data_labels_over_maximum](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) للتحكم فيما إذا كانت تُظهر تسميات بياناتها. يغيّر هذا الإعداد رؤية التسمية؛ لا يغيّر نطاق المحور ولا القيم الأساسية للبيانات.

يُنشئ المثال أدناه مخطط أعمدة عمودي مزدوج الأبعاد قيمه 60 و120. يضبط [is_automatic_max_value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/axis/is_automatic_max_value/) على `False` و[max_value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/axis/max_value/) على 100 للمحور العمودي. تسمح الشريحة الأولى بالتسميات خارج الحد الأقصى؛ نسخة من تلك الشريحة تعطل ذلك. تُحفظ الشريحتان في `DataLabelsOverMaximum.pptx`.

فعل تسميات القيم باستخدام [show_value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabelformat/show_value/). لا يفعّل الإعداد على مستوى المخطط عرض القيم بحد ذاته ولا يتجاوز تعطيل عرض القيمة لتسمية فردية. يمكّن هذا المثال القيم للسلسلة بأكملها ويستخدم [position](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabelformat/position/) لوضع التسميات عند الطرف الخارجي لكل عمود.

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

تظهر الصور التالية الشريحات المحفوظة التي عَرضتها Microsoft PowerPoint. مع `True` تكون التسمية **120** مرئية عند الحد الأعلى؛ مع `False` تُخفى. تظل التسمية **60** مرئية، يبقى الحد الأقصى للمحور **100**، وتظل نقطة البيانات الثانية **120** في الحالتين.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![مخطط PowerPoint يظهر تسمية القيمة 120 بحد أقصى للمحور 100](data-labels-over-maximum-true.png) | ![مخطط PowerPoint يخفي تسمية القيمة 120 بحد أقصى للمحور 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
هذا المثال يستخدم مخطط عمود ثنائي الأبعاد مع محور قيم. المخططات التي لا تحتوي على محور قيم، مثل مخططات الفطيرة والدوامة، لا تملك حدًا أقصى للمحور لتقيده بهذه الطريقة.
{{% /alert %}}

## **ضبط مسافة التسمية من المحور**

استخدم [label_offset](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/axis/label_offset/) للتحكم في المسافة بين تسميات محور الفئات والمحور. القيمة هي نسبة مئوية من أكبر حجم خط لتسميات المحور. ينشئ هذا المثال مخطط أعمدة مزدوج ويضبط إزاحة تسمية محور الأفقي إلى 500. يؤثر هذا الإعداد على تسميات محور الفئات وليس على التسميات المرتبطة بنقاط البيانات الفردية.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط موقع التسمية**

في مخطط الفطيرة، اضبط مواضع تسميات البيانات لتحسين التباعد وإتاحة مساحة لخطوط التوجيه.

يعرض هذا المثال قيمة نقطة البيانات الأولى، يضع تسميتها خارج الشريحة، ويضبط إزاحتيها [x](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/x/) و[y](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/y/). تُحسب هذه الإزاحات نسبة إلى عرض وارتفاع المخطط على الترتيب.

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

![مخطط فطيرة مع تعديل موضع تسمية البيانات](pie-chart-adjusted-label.png)

## **الأسئلة الشائعة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات المكتظة؟**  
اجمع بين وضع التسميات التلقائي، خطوط التوجيه، وتصغير حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني إلغاء تمكين التسميات للقيم صفر أو السلبية أو الفارغة فقط؟**  
رشّح نقاط البيانات قبل تفعيل التسميات وأوقف العرض للقيم 0، القيم السلبية، أو القيم غير الموجودة وفق قاعدة معرفة.

**كيف أضمن نمط تسمية ثابت عند التصدير إلى PDF/صور؟**  
حدد صراحةً عائلة الخط وحجمه وتحقق من توفر الخط في بيئة العرض لتجنب اللجوء إلى بدائل.