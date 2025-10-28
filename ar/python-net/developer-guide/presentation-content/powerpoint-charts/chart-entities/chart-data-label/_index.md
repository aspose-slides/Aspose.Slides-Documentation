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
- موقع التسمية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخططات في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر .NET لجعل الشرائح أكثر جاذبية."
---

## **نظرة عامة**

تُظهر تسميات البيانات على المخطط تفاصيل حول سلسلة بيانات المخطط أو النقاط الفردية. فهي تُتيح للقراء التعرف بسرعة على سلاسل البيانات وتُسهل فهم المخططات. في Aspose.Slides for Python، يمكنك تمكين، تخصيص، وتنسيق تسميات البيانات لأي مخطط—اختيار ما سيُعرض (القيم، النسب المئوية، أسماء السلاسل أو الفئات)، موضع التسميات، وكيفية مظهرها (الخط، تنسيق الأرقام، الفواصل، خطوط القائد، والمزيد). تُوضح هذه المقالة واجهات برمجة التطبيقات الأساسية وأمثلة تحتاجها لإضافة تسميات واضحة ومفيدة إلى مخططاتك.

## **ضبط دقة تسمية البيانات**

غالبًا ما تُظهر تسميات بيانات المخطط قيمًا رقمية تتطلب دقة ثابتة. يوضح هذا القسم كيفية التحكم في عدد المنازل العشرية لتسميات البيانات في Aspose.Slides عبر تطبيق تنسيق رقم مناسب.

المثال التالي بلغة بايثون يوضح كيفية ضبط الدقة الرقمية لتسميات بيانات المخطط:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **عرض النسب المئوية كتسميات**

مع Aspose.Slides، يمكنك عرض النسب المئوية كتسميات بيانات على المخططات. المثال أدناه يحسب حصة كل نقطة ضمن فئتها ويُنسق التسمية لإظهار النسبة المئوية.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # حفظ العرض التقديمي الذي يحتوي على المخطط.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **إظهار علامة النسبة المئوية مع تسميات بيانات المخطط**

يوضح هذا القسم كيفية عرض النسب المئوية في تسميات البيانات وإضافة علامة النسبة المئوية باستخدام Aspose.Slides. ستتعلم كيفية تمكين قيم النسبة المئوية لسلسلة كاملة أو لنقاط محددة (مناسب للمخططات الدائرية، المخططات الدونوت، ومخططات 100 % المكدسة) وكيفية التحكم في التنسيق عبر خيارات التسمية أو تنسيق رقم مخصص.

المثال التالي بلغة بايثون يوضح كيفية إضافة علامة النسبة المئوية إلى تسمية بيانات المخطط:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:

    # الحصول على مرجع للشفرة بالترتيب.
    slide = presentation.slides[0]

    # إنشاء مخطط PercentsStackedColumn على الشريحة.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # الحصول على دفتر عمل بيانات المخطط.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # إضافة سلسلة جديدة.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # ضبط لون تعبئة السلسلة.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # ضبط خصائص تنسيق التسمية.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # إضافة سلسلة جديدة.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # ضبط نوع التعبئة واللون.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # حفظ العرض التقديمي.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط مسافة التسمية من المحور**

يُظهر هذا القسم كيفية التحكم في المسافة بين تسميات البيانات ومحور المخطط في Aspose.Slides. تعديل هذا الإزاحة يساعد على تجنب التداخل وتحسين قابلية القراءة في الرسومات الكثيفة.

الكود التالي بلغة بايثون يوضح كيفية ضبط مسافة التسمية من محور الفئة عند العمل مع مخطط يعتمد على المحاور:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:
    # الحصول على مرجع للشفرة.
    slide = presentation.slides[0]

    # إنشاء مخطط أعمدة متجمعة على الشريحة.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # ضبط مسافة التسمية من محور الفئة (الأفقي).
    chart.axes.horizontal_axis.label_offset = 500

    # حفظ العرض التقديمي.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **تعديل موضع التسمية**

عند إنشاء مخطط لا يستخدم المحاور، مثل المخطط الدائري، قد تكون تسميات البيانات قريبة جدًا من الحافة. في هذه الحالة، عدل موضع التسمية حتى تُظهر خطوط القائد بوضوح.

الكود التالي بلغة بايثون يوضح كيفية تعديل موضع التسمية على مخطط دائري:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![تم تغيير موضع التسمية](changed_label_position.png)

## **الأسئلة الشائعة**

**كيف يمكنني منع تداخل تسميات البيانات على المخططات الكثيفة؟**

استخدام وضعية التسمية التلقائية، خطوط القائد، وتقليل حجم الخط؛ وإذا لزم الأمر، إخفاء بعض الحقول (مثل الفئة) أو إظهار التسميات فقط للنقاط المتطرفة/المهمة.

**كيف يمكنني تعطيل التسميات للقيم الصفرية أو السلبية أو الفارغة فقط؟**

رشّح نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم التي تساوي 0 أو قيم سلبية أو قيم مفقودة وفق قاعدة محددة.

**كيف أضمن نمط تسمية متسق عند التصدير إلى PDF/الصور؟**

حدّد الخطوط صراحةً (العائلة، الحجم) وتأكد من توفر الخط على جانب العرض لتجنب اللجوء إلى خطوط بديلة.