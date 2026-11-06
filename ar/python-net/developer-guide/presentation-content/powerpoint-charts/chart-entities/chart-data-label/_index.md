---
title: إدارة ملصقات بيانات المخططات في العروض التقديمية باستخدام بايثون
linktitle: ملصق البيانات
type: docs
url: /ar/python-net/chart-data-label/
keywords:
- مخطط
- ملصق بيانات
- دقة البيانات
- نسبة مئوية
- مسافة الملصق
- موقع الملصق
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق ملصقات بيانات المخططات في عروض PowerPoint باستخدام Aspose.Slides لبايثون عبر .NET للحصول على شرائح أكثر جاذبية."
---
## **المقدمة**

تُظهر ملصقات البيانات معلومات حول سلاسل المخططات ونقاط البيانات الفردية، مما يساعد القارئ على تحديد القيم وفهم المخطط. يشرح هذا المقال كيفية تنسيق القيم، عرض النسب المئوية، قراءة نص الملصق، التحكم في الملصقات خارج الحد الأقصى للمحور، ضبط تباعد ملصقات محور الفئة، وتحديد موقع ملصقات المخططات الدائرية.

## **عدد ملصقات البيانات المرئية**

استخدم [count_of_visible_data_labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/count_of_visible_data_labels/) للتحقق من عدد ملصقات البيانات المفعلة للعرض قبل نشر العرض التقديمي. على عكس `len(labels)` التي تُرجع العدد الإجمالي للملصقات في المجموعة، يأخذ هذا الإعداد في الاعتبار القيم الافتراضية للسلسلة وإعدادات كل ملصق على حدة.

ينشئ هذا المثال مخططًا عموديًا بسلسلة واحدة وثلاث نقاط بيانات. يصل إلى مجموعة [labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/labels/) الخاصة بالسلسلة ويطبع عدد الملصقات المرئية مع تغيير الإعدادات: **0, 3, 2, 3**. يبقى العدد الإجمالي **3**.

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
    print(f"Total: {len(labels)}; visible: {labels.count_of_visible_data_labels}")  # الإجمالي: 3; مرئي: 0

    labels.default_data_label_format.show_value = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # مرئي: 3

    labels[1].data_label_format.show_value = False
    print(f"Visible: {labels.count_of_visible_data_labels}")  # مرئي: 2

    labels[1].data_label_format.show_legend_key = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # مرئي: 3
```

توفر [default_data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/default_data_label_format/) الخاصة بالسلسلة الإعدادات الافتراضية. يؤدي تمكين [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) هناك إلى عرض القيم للملصقات الثلاثة. ضبطه على `False` عبر [data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/data_label_format/) لملصق واحد يتجاوز هذا الإعداد للملصق المحدد. تمكين [show_legend_key](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_legend_key/) يجعل ذلك الملصق يُحسب كمرئي مرة أخرى، رغم أن قيمته لا تزال مخفية.

يعكس العدد المرئي إعدادات الوضوح. ولا يقيس ما إذا كانت الملصقات متداخلة أو مقصَّة أو قابلة للقراءة في المخطط المُعالج.

## **تحديد دقة البيانات في ملصقات مخطط البيانات**

استخدم [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) لتنسيق قيم السلسلة. ينشئ هذا المثال مخططًا خطيًا ببيانات افتراضية، يعرض جدول البيانات الخاص به، ويفعل ملصقات القيم للسلسلة الأولى. يعرض التنسيق `#,##0.00` فاصل الآلاف ومكانين عشريين دون تغيير القيم الأساسية.

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

لتنسيق الخلايا الرقمية في دفتر العمل المدمج بالمخطط، راجع [Set Custom Number Formats for Workbook Cells](/slides/ar/python-net/chart-workbook/#set-custom-number-formats-for-workbook-cells). يُظهر ذلك المثال أيضًا ملصقات القيم التي تتبع تنسيقات الخلايا المصدر مع الحفاظ على القيم الرقمية المخزنة.

## **عرض النسبة المئوية كملصقات**

في مخطط عمودي مكدس، احسب كل قيمة كنسبة مئوية من مجموع الفئة وعيّن النص إلى [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين بخط بحجم 8 نقاط. تُستبعد الفئات التي مجموعها صفر لتجنب القسمة على صفر. احسب نص الملصق المخصص مرة أخرى إذا تغيرت بيانات المخطط.

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

## **تعيين علامة النسبة المئوية في ملصقات مخطط البيانات**

عندما تُخزَّن القيم ككسور، استخدم [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) لعرض النسب المئوية. اضبط [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) على `False` لتطبيق تنسيق الملصق بشكل مستقل عن خلايا المصدر.

ينشئ هذا المثال مخططًا عموديًا مكدسًا بنسبة 100% مع سلسلتين حمراء وزرقاء عبر أربع فئات. كل زوج من القيم يساوي 1. يعرِض تنسيق الملصق `0.0%` القيمة 0.30 كـ 30.0%، بينما يستخدم المحور الرأسي مكانين عشريين. تستخدم السلسلتان نصًا أبيض بحجم 10 نقاط للملصقات.

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

## **قراءة النص الفعلي لملصقات البيانات**

استخدم [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) لاسترجاع النص الذي تنتجه إعدادات ملصق البيانات. يكون هذا مفيدًا عند استخراج الملصقات للتقارير، بحث محتوى العرض التقديمي، أو التحقق من صحة المخططات المولدة. في المثال أدناه، يجمع تنسيق [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) الافتراضي بين اسم كل فئة، اسم السلسلة، والقيمة. إحدى النقاط تُنسيق قيمتها كنسبة مئوية، وأخرى تستخدم نصًا مخصصًا من [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

تبقى القيمة المخزنة في نقطة البيانات `0.75`، حتى عندما يُظهر ملصقها `75%` مع اسم الفئة والسلسلة. يستبدل النص المخصص النص المُولد للملصق. تُعيد [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) سلسلة الملصق الناتجة في كلا الحالتين. تحقق من [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج الملصقات المرئية فقط.

## **التحكم في ملصقات البيانات خارج الحد الأقصى للمحور**

عند تحديد نطاق المحور يدويًا، قد تتجاوز بعض نقاط البيانات الحد الأقصى له. استخدم [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) للتحكم ما إذا كانت ملصقات بياناتها ظاهرة. يغيّر هذا الإعداد رؤية الملصق؛ ولا يغيّر نطاق المحور أو القيم الأساسية للبيانات.

ينشئ المثال أدناه مخططًا عموديًا مزدوجًا ثنائي الأبعاد بقيم 60 و120. يضبط [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) على `False` و[max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) على 100 للمحور الرأسي. يسمح الشريحة الأولى بالملصقات التي تتجاوز الحد الأقصى؛ نسخة تلك الشريحة تعطلها. تُحفظ كلتا الشريحتين في `DataLabelsOverMaximum.pptx`.

فعّل ملصقات القيم باستخدام [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). لا يفعّل إعداد المستوى المخطط عرض القيم بحد ذاته ولا يتجاوز إيقاف عرض القيم لملصق فردي. يمكّن هذا المثال القيم لجميع السلسلة ويستخدم [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) لوضع الملصقات عند الطرف الخارجي لكل عمود.

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

تُظهر الصور التالية الشرائح المحفوظة التي تم عرضها بواسطة Microsoft PowerPoint. عند `True`، يكون الملصق **120** مرئيًا عند الحد العلوي؛ عند `False`، يكون مخفيًا. يظل الملصق **60** مرئيًا، يبقى الحد الأقصى للمحور **100**، وتظل نقطة البيانات الثانية **120** في الحالتين.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
يستخدم هذا المثال مخططًا عموديًا ثنائي الأبعاد مع محور قيم. المخططات التي لا تحتوي على محور قيم، مثل المخططات الدائرية ومخططات الدونات، لا تملك حدًا أقصى للمحور يمكن تقييدها بهذه الطريقة.
{{% /alert %}}

## **تعيين مسافة الملصق من المحور**

استخدم [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) للتحكم في المسافة بين ملصقات محور الفئة والمحور. القيمة هي نسبة مئوية من الحد الأقصى لحجم خط ملصقات المحور. ينشئ هذا المثال مخططًا عموديًا مزدوجًا ويضبط إزاحة ملصق المحور الأفقي إلى 500. يؤثر هذا الإعداد على ملصقات محور الفئة بدلاً من الملصقات المرتبطة بنقاط البيانات الفردية.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعديل موقع الملصق**

في المخطط الدائري، قم بتعديل مواقع ملصقات البيانات لتحسين التباعد وإتاحة مساحة لخطوط الربط.

يعرض هذا المثال قيمة أول نقطة بيانات، يضع ملصقها خارج القطعة، ويضبط إزاحتيها [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) و[y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/). هذه الإزاحات نسبية إلى عرض وارتفاع المخطط على التوالي.

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

![مخطط دائري مع موقع ملصق بيانات مُعدّل](pie-chart-adjusted-label.png)

## **تنسيق خطوط الربط**

عندما تكون ملصقات المخطط الدائري خارج القطع، تساعد خطوط الربط القارئ على مطابقة كل قيمة مع القطعة الصحيحة. يمكن للون المتباين والخط السميك قليلًا أن يجعل هذه الاتصالات أسهل للمتابعة، بينما الشفافية والنمط المتقطّع يحافظان على أن تكون الخطوط غير بارزة بصريًا.

استخدم [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) لتنسيق خطوط الربط على مستوى مجموعة ملصقات البيانات للسلسلة. تُطبق الإعدادات في `series.labels.leader_lines_format.line` على المجموعة، وليس على كل ملصق على حدة.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية، يعرض القيم خارج القطع، ويفعل [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/). ينقل ملصقين بعيدًا عن قطعهما باستخدام إزاحتيّ [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) و[y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/)، معبرًا عنها ككسر من عرض وارتفاع المخطط. لا يلزم عرض تقديمي كمدخل.

تحدد [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) للخط لونًا أزرق صلبًا بقيمة ألفا 191 من 255، مما يعطي تقريبًا 25% شفافية. يحدد [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) السماكة إلى نقطتين، وتُجعل [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) الخط متقطعًا.

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

    # نقل ملصقين بعيدًا عن الشرائح
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

تفعيل خطوط الربط لا يضمن ظهور خط لكل ملصق. تعتمد الرؤية على موضع الملصق وسلوك تخطيط المخطط. في هذا المثال، يحتوي الملصقان المنفصلان على خطوط ربط مرئية؛ الملصقات التي تظل قريبة من قطعها لا تحتاج إليها.

تُظهر الصورة التالية الملف المحفوظ `FormattedLeaderLines.pptx` المعروض بواسطة Aspose.Slides:

![مخطط دائري بخطوط ربط زرقاء شبه شفافة ومتقطعة تربط ملصقين خارجيين بقطعهما](formatted-leader-lines.png)

## **إضافة صفوف متعددة من ملصقات البيانات فوق مخطط عمودي**

ينشئ هذا المثال مخططًا عموديًا مع صفين من ملصقات البيانات فوق منطقة الرسم. تعرض السلسلة A الأعمدة المرئية، بينما توفر السلسلة B والسلسلة C الملصقات الإضافية. تُخفى أعمدتهما بإزالة التعبئة والحدود. خاصية [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) تُحاذِّ القِيَّم الثلاث للسلسلات مع نفس مراكز الفئة.

إعدادات [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) تحجز مساحة لصفوف الملصقات. بعد أن تحسب [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) المواقع الافتراضية، تُحافظ [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) و[y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) على المحاذاة الأفقية وتطبق إزاحات عمودية لترتيب الملصقات في صفين. تظل الأرقام ملصقات بيانات مرتبطة بقيم السلاسل؛ فقط عناوين الصفوف هي أشكال نصية منفصلة.

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
            # إخفاء أعمدة B و C، مع الحفاظ على ملصقات البيانات الخاصة بها.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # محاذاة السلاسل الثلاثة مع مراكز الفئات نفسها.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # استخدام خطوط شبكة أقل لهذا المثال المدمج.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # تخصيص مساحة فوق منطقة الرسم لصفين من ملصقات البيانات.
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
            # الحفاظ على الموضع الأفقي الافتراضي. Y هو إزاحة من
            # موضع الملصق الافتراضي، معبرًا عنه ككسر من ارتفاع المخطط.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # عنوان الصف فقط هو شكل نصي منفصل.
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

![مخطط عمودي مع صفين من ملصقات البيانات فوق منطقة الرسم](multiple-rows-of-labels.png)

## **الأسئلة المتكررة**

**كيف يمكنني منع تداخل ملصقات البيانات في المخططات المكتظة؟**  
اجمع بين وضع الملصقات التلقائي، خطوط الربط، وتقليل حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض الملصقات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني تعطيل الملصقات فقط للقيم الصفرية أو السالبة أو الفارغة؟**  
قم بترشيح نقاط البيانات قبل تفعيل الملصقات وأوقف العرض للقيم الصفرية، والقيم السالبة، أو القيم المفقودة وفقًا لقاعدة محددة.

**كيف أضمن أسلوبًا موحدًا للملصقات عند التصدير إلى PDF/صور؟**  
حدد صراحةً عائلة الخط وحجمه وتأكد من توفر الخط في بيئة العرض لتجنب الاعتماد على الخطوط الاحتياطية.