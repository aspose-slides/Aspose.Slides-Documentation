---
title: إدارة تسميات بيانات المخطط في العروض التقديمية باستخدام بايثون
linktitle: تسمية البيانات
type: docs
url: /ar/python-net/chart-data-label/
keywords:
- مخطط
- تسمية بيانات
- دقة البيانات
- نسبة مئوية
- مسافة التسمية
- موقع التسمية
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint التقديمية باستخدام Aspose.Slides للبايثون عبر .NET للحصول على شرائح أكثر جاذبية."
---
## **المقدمة**

تُظهر تسميات البيانات معلومات حول سلاسل المخطط والنقاط الفردية، مما يساعد القارئ على تحديد القيم وفهم المخطط. يشرح هذا المقال كيفية تنسيق القيم، عرض النسب المئوية، قراءة نص التسمية، ضبط تباعد تسميات محور الفئة، وتحديد موضع تسميات المخطط الدائري.

## **تعيين دقة البيانات في تسميات مخطط البيانات**

استخدم [number_format_of_values](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/number_format_of_values/) لتنسيق قيم السلسلة. يُنشئ هذا المثال مخططًا خطيًا ببيانات افتراضية، يعرض جدول البيانات الخاص به، ويفعل تسميات القيم للسلسلة الأولى. يُظهر التنسيق `#,##0.00` فاصل الآلاف ومكانين عشريين دون تغيير القيم الأساسية.

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

في مخطط الأعمدة المتراكبة، احسب كل قيمة كنسبة مئوية من إجمالي الفئة الخاصة بها وعيّن النص إلى [text_frame_for_overriding](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). يستخدم هذا المثال بيانات المخطط الافتراضية ويظهر النسب المئوية بمكانين عشريين بخط بحجم 8 نقاط. يتم تخطي الفئات التي مجموعها صفر لتجنب القسمة على الصفر. أعد حساب نص التسمية المخصص إذا تغيرت بيانات المخطط.

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

## **تعيين علامة النسبة المئوية مع تسميات مخطط البيانات**

عند تخزين القيم ككسر، استخدم [number_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabelformat/number_format/) لعرض النسب المئوية. اضبط [is_number_format_linked_to_source](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) على `False` لتطبيق تنسيق التسمية بشكل مستقل عن الخلايا المصدرية.

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

استخدم [get_actual_label_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) لاسترجاع النص الذي تنتجه إعدادات تسمية البيانات. يكون ذلك مفيدًا عند استخراج التسميات للتقارير، البحث في محتوى العرض التقديمي، أو التحقق من صحة المخططات المُنشأة. في المثال أدناه، يدمج [تنسيق تسمية البيانات](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabelformat/) الافتراضي كل من اسم الفئة، اسم السلسلة، والقيمة. أحد النقطين ينسق قيمته كنسبة مئوية، وآخر يستخدم نصًا مخصصًا من [text_frame_for_overriding](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

يظل الرقم المخزن في نقطة البيانات `0.75`، حتى عندما تُظهر تسميةه `75%` مع أسماء الفئة والسلسلة. النص المخصص يستبدل النص المُولَّد للتسمية. تُعيد الدالة [get_actual_label_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) سلسلة التسمية الناتجة في كلتا الحالتين. تحقق من [is_visible](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/is_visible/) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج التسميات المرئية فقط.

## **تعيين مسافة التسمية من المحور**

استخدم [label_offset](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/axis/label_offset/) للتحكم في المسافة بين تسميات محور الفئة والمحور. القيمة هي نسبة مئوية من الحد الأقصى لحجم الخط لتسميات المحور. ينشئ هذا المثال مخطط أعمدة مجمع ويضبط إزاحة تسمية المحور الأفقي إلى 500. يؤثر هذا الإعداد على تسميات محور الفئة بدلاً من التسميات المرتبطة بنقاط البيانات الفردية.

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

في مخطط دائري، اضبط مواضع تسميات البيانات لتحسين التباعد وإفساح المجال لخطوط التوصيل.

يعرض هذا المثال قيمة نقطة البيانات الأولى، يضع تسميتها خارج الشريحة، ويضبط إزاحتَيها في الاتجاهين [x](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/x/) و[y](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabel/y/). هذه الإزاحات نسبية إلى عرض المخطط وارتفاعه على التوالي.

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

![مخطط دائري مع موضع تسمية بيانات معدَّل](pie-chart-adjusted-label.png)

## **الأسئلة الشائعة**

**كيف يمكنني منع تسميات البيانات من التداخل في المخططات الكثيفة؟**

اخلط بين وضع التسمية التلقائي، خطوط التوصيل، وتقليل حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (على سبيل المثال، الفئة) أو اعرض التسميات فقط للقيم المتطرفة أو النقاط الرئيسة.

**كيف يمكنني تعطيل التسميات للقيم الصفرية أو السلبية أو الفارغة فقط؟**

قم بتصفية نقاط البيانات قبل تفعيل التسميات وأوقف العرض للقيم التي تساوي 0، أو القيم السلبية، أو القيم الغائبة وفق قاعدة محددة.

**كيف يمكنني ضمان نمط تسمية موحد عند التصدير إلى PDF/صور؟**

حدد صراحةً عائلة الخط وحجمه وتحقق من توفر الخط في بيئة العرض لتجنب الاعتماد على خط احتياطي.