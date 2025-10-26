---
title: إدارة ملصقات بيانات المخطط في العروض التقديمية باستخدام بايثون
linktitle: ملصق البيانات
type: docs
url: /ar/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-data-label/
keywords:
- مخطط
- ملصق البيانات
- دقة البيانات
- نسبة مئوية
- مسافة الملصق
- موقع الملصق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرّف على كيفية إضافة وتنسيق ملصقات بيانات المخطط في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET للحصول على شرائح أكثر جذبًا."
---

## **نظرة عامة**

توفر ملصقات البيانات على المخطط تفاصيل حول سلسلة البيانات أو نقاط البيانات الفردية. تمكّن القرّاء من التعرف بسرعة على سلاسل البيانات وتجعلهام أسهل للفهم. في Aspose.Slides للبايثون، يمكنك تمكين وتخصيص وتنسيق ملصقات البيانات لأي مخطط—باختيار ما يتم عرضه (القيم، النسب المئوية، أسماء السلاسل أو الفئات)، ومكان وضع الملصقات، وكيفية ظهورها (الخط، تنسيق الأرقام، الفواصل، خطوط القائد، وأكثر). يوضح هذا المقال واجهات برمجة التطبيقات الأساسية والأمثلة التي تحتاجها لإضافة ملصقات واضحة ومعلوماتية إلى مخططاتك.

## **تعيين دقة ملصق البيانات**

غالبًا ما تعرض ملصقات بيانات المخطط قيمًا رقمية تحتاج إلى دقة ثابتة. يوضح هذا القسم كيفية التحكم في عدد المنازل العشرية لملصقات البيانات في Aspose.Slides عن طريق تطبيق تنسيق عدد مناسب.

المثال التالي بايثون يوضح كيفية تعيين الدقة الرقمية لملصقات بيانات المخطط:

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

## **عرض النسب المئوية كملصقات**

مع Aspose.Slides، يمكنك عرض النسب المئوية كملصقات بيانات على المخططات. يحسب المثال أدناه حصة كل نقطة ضمن فئتها ويُنسق الملصق لعرض النسبة المئوية.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Create an instance of the Presentation class.
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

    # Save the presentation containing the chart.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **إظهار علامة النسبة المئوية مع ملصقات بيانات المخطط**

يوضح هذا القسم كيفية عرض النسب المئوية في ملصقات بيانات المخطط وإضافة علامة النسبة المئوية باستخدام Aspose.Slides. ستتعلم كيفية تمكين قيم النسبة المئوية لسلسلة كاملة أو نقاط معينة (مثالي للمخططات الدائرية، المخططات الحلزونية، ومخططات 100% المتراكمة) وكيفية التحكم في التنسيق من خلال خيارات الملصق أو تنسيق عدد مخصص.

المثال التالي بايثون يوضح كيفية إضافة علامة النسبة المئوية إلى ملصق البيانات في المخطط:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Get a slide reference by index.
    slide = presentation.slides[0]

    # Create a PercentsStackedColumn chart on the slide.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Get the chart data workbook.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Add a new series.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Set the series fill color.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Set label format properties.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Add a new series.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Set the fill type and color.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Save the presentation.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين مسافة الملصق من المحور**

يوضح هذا القسم كيفية التحكم في المسافة بين ملصقات البيانات ومحور المخطط في Aspose.Slides. يساعد تعديل هذا الإزاحة في منع التداخل وتحسين قابلية القراءة في الرسومات الكثيفة.

الكود التالي بايثون يوضح كيفية تعيين مسافة الملصق من محور الفئة عند العمل مع مخطط يعتمد على المحاور:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    # Get a slide reference.
    slide = presentation.slides[0]

    # Create a clustered column chart on the slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Set the label distance from the category (horizontal) axis.
    chart.axes.horizontal_axis.label_offset = 500

    # Save the presentation.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط موضع الملصق**

عند إنشاء مخطط لا يستخدم محاور، مثل المخطط الدائري، قد تكون ملصقات البيانات قريبة جدًا من الحافة. في تلك الحالة، اضبط موضع الملصق بحيث تُظهر خطوط القائد بوضوح.

الكود التالي بايثون يوضح كيفية ضبط موضع الملصق في مخطط دائري:

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

![Changed label position](changed_label_position.png)

## **الأسئلة المتكررة**

**كيف يمكنني منع تداخل ملصقات البيانات في المخططات الكثيفة؟**

اجمع بين وضع الملصقات التلقائي، خطوط القائد، وتقليل حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض الملصقات فقط للنقاط المتطرفة/المفتاحية.

**كيف يمكنني تعطيل الملصقات للقيم الصفرية أو السالبة أو الفارغة فقط؟**

قم بترشيح نقاط البيانات قبل تمكين الملصقات وأوقف العرض للقيم التي تساوي 0 أو القيم السالبة أو القيم المفقودة وفق قاعدة محددة.

**كيف أضمن تنسيقًا ثابتًا للملصق عند التصدير إلى PDF/صور؟**

حدد الخطوط صراحةً (العائلة، الحجم) وتأكد من توفر الخط على جانب العرض لتفادي الاعتماد على خطوط بديلة.