---
title: إدارة تسميات بيانات المخطط في العروض التقديمية باستخدام بايثون
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
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint باستخدام Aspose.Slides للغة بايثون عبر .NET للحصول على شرائح أكثر جاذبية."
---
## **مقدمة**

تظهر تسميات البيانات معلومات حول سلاسل المخطط ونقاط البيانات الفردية، مما يساعد القارئ على تحديد القيم وفهم المخطط. توضح هذه المقالة كيفية تنسيق القيم، وعرض النسب المئوية، وقراءة نص التسمية، والتحكم في التسميات التي تتجاوز الحد الأقصى للمحور، وضبط تباعد تسميات محور الفئة، وتحديد موضع تسميات مخطط الفطيرة.

## **تحديد دقة القيم في تسميات بيانات المخطط**

استخدم [تنسيق_الرقم_للقيم](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) لتنسيق قيم السلسلة. تُنشئ هذه الأمثلة مخططًا خطيًا ببيانات افتراضية، تعرض جدول البيانات الخاص به، وتُفعِّل تسميات القيم للسلسلة الأولى. التنسيق `#,##0.00` يظهر فاصل الآلاف ومكانين عشريين دون تغيير القيم الأساسية.

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

## **عرض النسبة المئوية كعلامات**

لمخطط عمودي مكدس، احسب كل قيمة كنسبة مئوية من إجمالي الفئة وعيِّن النص إلى [إطار_النص_لتجاوز_الإعدادات](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). تستخدم هذه الأمثلة بيانات مخطط افتراضية وتعرض النسب المئوية بدقتين عشريتين بخط بحجم 8 نقاط. تُتخطى الفئات التي يكون مجموعها صفرًا لتجنّب قسمة على الصفر. أعد حساب نص التسمية المخصص إذا تغيرت بيانات المخطط.

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

## **تعيين علامة النسبة المئوية في تسميات بيانات المخطط**

عند تخزين القيم ككسور، استخدم [تنسيق_الرقم](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) لعرض النسب المئوية. عيّن [هل_تنسيق_الرقم_مرتبطة_بالمصدر](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) إلى `False` لتطبيق تنسيق التسمية بشكل مستقل عن خلايا المصدر.

تُنشئ هذه الأمثلة مخطط عمودي مكدس 100% بألوان حمراء وزرقاء عبر أربع فئات. كل زوج من القيم يساوي 1. تنسيق التسمية `0.0%` يُظهر 0.30 كـ30.0%، بينما يستخدم المحور العمودي دقتين عشريتين. كلا السلسلتين تستخدم نص تسمية أبيض بحجم 10 نقاط.

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

استخدم [الحصول_على_نص_التسمية_الفعلية](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) لاسترداد النص الذي ينتجه إعدادات تسمية البيانات. يكون هذا مفيدًا عند استخراج التسميات للتقارير، أو البحث في محتوى العروض التقديمية، أو التحقق من صحة المخططات المُولدة. في المثال أدناه، يجمع [تنسيق_تسمية_البيانات](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) الافتراضي كل اسم فئة، اسم السلسلة، والقيمة. تنسّق نقطة واحدة قيمتها كنسبة مئوية، والأخرى تستخدم نصًا مخصصًا من [إطار_النص_لتجاوز_الإعدادات](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

تظل القيمة المخزنة في نقطة البيانات `0.75`، حتى عندما تعرض تسميتها `75%` مع أسماء الفئة والسلسلة. يستبدل النص المخصص النص المُولد للتسمية. تُعيد [الحصول_على_نص_التسمية_الفعلية](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) سلسلة التسمية الناتجة في كلتا الحالتين. تحقّق من [هل_التسمية_مرئية](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج التسميات المرئية فقط.

## **التحكم في تسميات البيانات التي تتجاوز الحد الأقصى للمحور**

عند تحديد نطاق المحور يدويًا، قد تتجاوز بعض نقاط البيانات قيمته القصوى. استخدم [إظهار_تسميات_البيانات_فوق_الحد_الأقصى](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) للتحكم فيما إذا كانت تُظهر تسميات بياناتها. لا يغيّر هذا الإعداد رؤية التسمية؛ ولا يغيّر نطاق المحور أو قيم البيانات الأساسية.

تنشئ الأمثلة أدناه مخطط عمودي مجموعتي 2D بقيم 60 و120. تُعيّن [هل_القيمة_القصوى_تلقائية](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) إلى `False` و[القيمة_القصوى](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) إلى 100 على المحور العمودي. تسمح الشريحة الأولى بتسميات تتجاوز الحد الأقصى؛ نسخة من تلك الشريحة تُعرّف تعطيلها. تُحفظ كلتا الشريحتين في `DataLabelsOverMaximum.pptx`.

فعِّل تسميات القيم باستخدام [إظهار_القيمة](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). لا يقوم إعداد مستوى المخطط بتمكين عرض القيمة بمفرده ولا يتجاوز إيقاف عرض قيمة تسمية فردية. تُفعّل هذه الأمثلة القيم لكل السلسلة وتستخدم [الموضع](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) لوضع التسميات عند الطرف الخارجي لكل عمود.

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

توضح الصور التالية الشريحات المحفوظة التي عُرضت بواسطة Microsoft PowerPoint. عند `True` تكون التسمية **120** مرئية عند الحد العلوي؛ وعند `False` تُخفى. تظل التسمية **60** مرئية، ويظل الحد الأقصى للمحور **100**، وتبقى نقطة البيانات الثانية **120** في الحالتين.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
هذا المثال يستخدم مخطط عمودي 2D مع محور قيمة. المخططات التي لا تمتلك محور قيمة، مثل مخططات الفطيرة والدونات، لا تملك حدًا أقصى للمحور يمكن تقييده بهذه الطريقة.
{{% /alert %}}

## **تحديد مسافة التسمية عن المحور**

استخدم [إزاحة_التسمية](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) للتحكم بالمسافة بين تسميات محور الفئة والمحور. القيمة هي نسبة مئوية من الحد الأقصى لحجم خط تسميات المحور. تُنشئ هذه الأمثلة مخطط عمودي مجموعتي وتعيّن إزاحة تسمية المحور الأفقي إلى 500. يؤثر هذا الإعداد على تسميات محور الفئة وليس على التسميات المرتبطة بنقاط البيانات الفردية.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط موضع التسمية**

في مخطط الفطيرة، اضبط مواضع تسميات البيانات لتحسين التباعد وإتاحة مساحة لخطوط الربط.

تعرض هذه الأمثلة قيمة أول نقطة بيانات، وتضع تسميتها خارج القطاع، وتضبط إزاحتيها في الاتجاهين [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) و[y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/). تُعبر هذه الإزاحات عن نسب من عرض وارتفاع المخطط على التوالي.

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

## **تنسيق خطوط الربط**

عند وضع تسميات مخطط الفطيرة خارج القطاعات، تساعد خطوط الربط القارئ على ربط كل قيمة بالقطاع الصحيح. يمكن للون متباين وخط سميك قليلاً أن يجعل هذه الروابط أسهل للمتابعة، بينما يضمن الشفافية والنمط المتقطّع أن تكون الخطوط غير بارزة بصريًا.

استخدم [تنسيق_خطوط_الربط](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) لتنسيق خطوط الربط على مستوى مجموعة تسميات البيانات للسلسلة. تُطبق الإعدادات في `series.labels.leader_lines_format.line` على المجموعة ككل، وليس على تسمية فردية.

تنشئ هذه الأمثلة مخطط فطيرة ببيانات افتراضية، وتعرض القيم خارج القطاعات، وتفعيل [إظهار_خطوط_الربط](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/). تُبعد علامتان عن قطعهما باستخدام إزاحتي [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) و[y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/)، معبرتين عن كسر من عرض وارتفاع المخطط. لا يلزم تقديم عرض تقديمي كمدخل.

يحدد [تنسيق_الملء](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) للخط لونًا أزرق صلبًا مع قيمة ألفا 191 من 255، أي تقريبًا 25% شفافية. يحدد [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) السماكة بـ2 نقطة، ويجعل [نمط_الشرط](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) الخط متقطعًا.

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

    # نقل تسميتين بعيدًا عن شرائحهما.
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

إن تفعيل خطوط الربط لا يضمن ظهور خط لكل تسمية. تعتمد الرؤية على موضع التسمية وسلوك تخطيط المخطط. في هذه الأمثلة، للعلامتين المنقولتين خطوط ربط مرئية؛ أما التسميات القريبة من قطاعاتها فلا تحتاج إلى ذلك.

تُظهر الصورة التالية ملف `FormattedLeaderLines.pptx` المحفوظ والمُعرض بواسطة Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **إضافة عدة صفوف من تسميات البيانات أعلى مخطط عمودي**

تنشئ هذه الأمثلة مخططًا عموديًا بصفين من تسميات البيانات أعلى منطقة الرسم. تعرض السلسلة A الأعمدة المرئية، بينما توفر السلسلة B والسلسلة C التسميات الإضافية. تُخفي أعمدتهما بإزالة التعبئة والحد. يضمن خاصية [التداخل](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) محاذاة الثلاث سلاسل مع مراكز الفئات نفسها.

تُخصص إعدادات [منطقة_الرسم](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) مساحة لصفوف التسميات. بعد أن يحسب [التحقق_من_تخطيط_المخطط](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) المواضع الافتراضية، تُحافظ إزاحتا [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) و[y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) على المحاذاة الأفقية وتُطبق إزاحات رأسية لترتيب التسميات في صفين. تظل الأرقام تسميات بيانات مرتبطة بقيم السلسلة؛ فقط عناوين الصفوف هي أشكال نصية منفصلة.

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
            # إخفاء أعمدة B و C، مع الحفاظ على تسميات البيانات الخاصة بهما.
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

    # حجز مساحة فوق المنطقة الرسم لصفين من تسميات البيانات.
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
            # الاحتفاظ بالموقع الأفقي الافتراضي. Y هو إزاحة من
            # الموضع الافتراضي للتسمية، معبرًا عنه كنسبة من ارتفاع المخطط.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # العنوان الصفّي هو الشكل النصي المنفصل الوحيد.
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

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **الأسئلة المتكررة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات الكثيفة؟**

اجمع بين وضع تلقائي للتسمية، خطوط الربط، وتقليل حجم الخط؛ وإذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني تعطيل التسميات للقيم الصفرية، السلبية، أو الفارغة فقط؟**

صفي نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم 0، القيم السلبية، أو القيم المفقودة وفق قاعدة مُحددة.

**كيف أضمن نمط تسمية ثابت عند التصدير إلى PDF/صور؟**

حدد صراحةً عائلة الخط وحجمه وتحقق من توفر الخط في بيئة العرض لتجنّب الاعتماد على خطوط احتياطية.