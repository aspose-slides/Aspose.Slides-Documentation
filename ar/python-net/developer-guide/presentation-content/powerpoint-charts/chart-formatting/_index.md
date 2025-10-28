---
title: تنسيق المخططات في العروض التقديمية باستخدام بايثون
linktitle: تنسيق المخططات
type: docs
weight: 60
url: /ar/python-net/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخطط
- كيان المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حدود مستديرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides للبايثون عبر .NET وارتقِ بعرض PowerPoint أو OpenDocument الخاص بك إلى مستوى احترافي وجذاب بصريًا."
---

## **نظرة عامة**

يُظهر هذا الدليل كيفية تنسيق مخططات PowerPoint باستخدام Aspose.Slides للبايثون. يتناول تخصيص الكيانات الأساسية للمخطط – مثل المحاور الفئوية ومحور القيم، خطوط الشبكة، التسميات، العناوين، الأساطير، والمحاور الثانوية – ويوضح كيفية التحكم في الخطوط، تنسيقات الأعداد، التعبئات، الحدود، ألوان منطقة الرسم والجدار الخلفي، وزوايا المخطط المستديرة باستخدام عينات شفرة مختصرة قابلة للتنفيذ. باتباع الأمثلة خطوة بخطوة، ستنشئ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، وتضيف وتُكوّن مخططًا، وتحفظ النتيجة إلى ملف PPTX مع تطبيق إعدادات بصرية وتيبوغرافية دقيقة.

## **تنسيق عناصر المخطط**

يسمح Aspose.Slides للبايثون للمطورين بإضافة مخططات مخصصة إلى الشرائح من الصفر. يشرح هذا القسم كيفية تنسيق عناصر المخطط المختلفة، بما في ذلك المحور الفئوي ومحور القيم.

يوفر Aspose.Slides واجهة برمجة تطبيقات بسيطة لإدارة عناصر المخطط وتطبيق تنسيق مخصص:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع للشفرة عبر فهرسها.
1. إضافة مخطط ببيانات افتراضية من النوع المطلوب (في هذا المثال، `ChartType.LINE_WITH_MARKERS`).
1. الوصول إلى محور قيم المخطط وضبط ما يلي:
   1. ضبط **تنسيق الخط** لخطوط شبكة المحور القيمي الرئيسية.
   1. ضبط **تنسيق الخط** لخطوط شبكة المحور القيمي الفرعية.
   1. ضبط **تنسيق العدد** لمحور القيم.
   1. ضبط **الوحدات الدنيا، العليا، الرئيسية، والفرعية** لمحور القيم.
   1. ضبط **خصائص النص** لتسميات محور القيم.
   1. ضبط **العنوان** لمحور القيم.
   1. ضبط **تنسيق الخط** للمحور القيمي.
1. الوصول إلى محور الفئة وضبط ما يلي:
   1. ضبط **تنسيق الخط** لخطوط شبكة محور الفئة الرئيسية.
   1. ضبط **تنسيق الخط** لخطوط شبكة محور الفئة الفرعية.
   1. ضبط **خصائص النص** لتسميات محور الفئة.
   1. ضبط **العنوان** لمحور الفئة.
   1. ضبط **موضع التسمية** لمحور الفئة.
   1. ضبط **زاوية دوران** تسميات محور الفئة.
1. الوصول إلى أسطورة المخطط وضبط **خصائص النص** لها.
1. إظهار أسطورة المخطط دون أن تتداخل مع المخطط.
1. الوصول إلى **محور القيم الثانوي** للمخطط وضبط ما يلي:
   1. تفعيل **محور القيم** الثانوي.
   1. ضبط **تنسيق الخط** للمحور القيمي الثانوي.
   1. ضبط **تنسيق العدد** للمحور القيمي الثانوي.
   1. ضبط **الوحدات الدنيا، العليا، الرئيسية، والفرعية** للمحور القيمي الثانوي.
1. رسم السلسلة الأولى للمخطط على محور القيم الثانوي.
1. ضبط لون تعبئة الجدار الخلفي للمخطط.
1. ضبط لون تعبئة منطقة الرسم للمخطط.
1. كتابة العرض المعدل إلى ملف PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Access the first slide.
    slide = presentation.slides[0]

    # Add a sample chart.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Set the chart title.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Set major gridline format for the value axis.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Set minor gridline format for the value axis.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Set the value axis number format.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Set value-axis maximum, minimum, major unit, and minor unit.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Set value-axis text properties.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Set the value axis title.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Set major gridline format for the category axis.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Set minor gridline format for the category axis.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Set category-axis text properties.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Set the category axis title.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Set the category-axis label position.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Set the category-axis label rotation angle.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Set legend text properties.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Show the chart legend overlapping the chart.
    chart.legend.overlay = True
                
    # Set chart back wall color.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Set the plot area color.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Save the presentation.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط خصائص خط المخطط**

يدعم Aspose.Slides للبايثون ضبط خصائص الخط للمخططات. اتبع الخطوات التالية لتكوين خصائص خط المخطط:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إضافة مخطط إلى الشريحة.
1. ضبط ارتفاع الخط.
1. حفظ العرض المعدل.

كود تجريبي موضح أدناه.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط تنسيق الأرقام**

يوفر Aspose.Slides للبايثون واجهة برمجة تطبيقات بسيطة لإدارة تنسيقات بيانات المخطط:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع للشفرة عبر فهرسها.
1. إضافة مخطط ببيانات افتراضية من أي نوع مطلوب.
1. ضبط تنسيق عدد مسبق من القيم المتاحة.
1. استعراض خلايا بيانات المخطط في كل سلسلة وضبط تنسيق العدد.
1. حفظ العرض.
1. ضبط تنسيق عدد مخصص.
1. استعراض خلايا بيانات المخطط في كل سلسلة وضبط تنسيق عدد مختلف.
1. حفظ العرض.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Add a default clustered column chart.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Set the preset number format.
    # Traverse each chart series.
    for series in chart.chart_data.series:
        # Traverse each data point in the series.
        for cell in series.data_points:
            # Set the number format.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Save the presentation.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

التنسيقات العددية المسبقة المتاحة ومؤشراتها المقابلة مُدرجة أدناه.

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **ضبط حدود مستديرة لمنطقة المخطط**

يدعم Aspose.Slides للبايثون ضبط منطقة المخطط باستخدام الخاصية `Chart.has_rounded_corners`.

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إضافة مخطط إلى الشريحة.
3. ضبط نوع التعبئة ولونها للمخطط.
4. ضبط الخاصية `has_rounded_corners` إلى `True`.
5. حفظ العرض المعدل.

مثال توضيحي أدناه.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يمكنني ضبط تعبئة شبه شفافة للأعمدة/المناطق مع الحفاظ على الحد غير شفاف؟**

نعم. يتم تكوين شفافية التعبئة والحد الخارجي بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصوير الكثيف.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، أوقف مكونات التسمية غير الضرورية (مثل الفئات)، اضبط إزاحة/موضع التسمية، اعرض التسميات لنقاط محددة فقط إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + الأسطورة".

**هل يمكنني تطبيق تعبئة تدرجية أو نمطية للسلاسل؟**

نعم. تتوفر عادةً كل من التعبئات الصلبة والتدرجية/النمطية. في الممارسة، استخدم التدرجات باعتدال وتجنب الجمعات التي تقلل التباين مع الشبكة والنص.