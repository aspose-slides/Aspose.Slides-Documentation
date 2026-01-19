---
title: تنسيق المخططات في العروض التقديمية باستخدام Python
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/python-net/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخططات
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
description: "تعلم تنسيق المخططات في Aspose.Slides للبايثون عبر .NET وارتقِ بعرض PowerPoint أو OpenDocument الخاص بك بأناقة احترافية وجذابة."
---

## **نظرة عامة**

يوضح هذا الدليل كيفية تنسيق مخططات PowerPoint باستخدام Aspose.Slides للـPython. يشرح كيفية تخصيص الكيانات الأساسية للمخطط — مثل محاور الصنف والقيمة، خطوط الشبكة، التسميات، العناوين، الأساطير، والمحاور الثانوية — ويظهر كيفية التحكم في الخطوط، تنسيقات الأرقام، التعبئة، الحدود، ألوان منطقة الرسم والخلفية، وزوايا المخطط المستديرة باستخدام عينات شفرة مختصرة وقابلة للتنفيذ. باتباع الأمثلة خطوة بخطوة، ستقوم بإنشاء [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، إضافة وتكوين مخطط، وحفظ النتيجة إلى PPTX مع تطبيق إعدادات بصرية وطباعة دقيقة.

## **تنسيق عناصر المخطط**

يتيح Aspose.Slides للـPython للمطورين إضافة مخططات مخصصة إلى الشرائح من الصفر. يشرح هذا القسم كيفية تنسيق عناصر المخطط المختلفة، بما في ذلك محاور الصنف والقيمة.

Aspose.Slides يوفر واجهة برمجة تطبيقات بسيطة لإدارة عناصر المخطط وتطبيق تنسيق مخصص:

1. إنشاء نسخة من فئة [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع للشرحة بواسطة الفهرس الخاص بها.
1. إضافة مخطط ببيانات افتراضية من النوع المطلوب (في هذا المثال، `ChartType.LINE_WITH_MARKERS`).
1. الوصول إلى محور القيمة للمخطط وتعيين ما يلي:
   1. تعيين **تنسيق الخط** لخطوط الشبكة الرئيسية لمحور القيمة.
   1. تعيين **تنسيق الخط** لخطوط الشبكة الثانوية لمحور القيمة.
   1. تعيين **تنسيق الرقم** لمحور القيمة.
   1. تعيين **الحد الأدنى، الحد الأقصى، الوحدات الرئيسية والثانوية** لمحور القيمة.
   1. تعيين **خصائص النص** لتسميات محور القيمة.
   1. تعيين **العنوان** لمحور القيمة.
   1. تعيين **تنسيق الخط** لمحور القيمة.
1. الوصول إلى محور الصنف للمخطط وتعيين ما يلي:
   1. تعيين **تنسيق الخط** لخطوط الشبكة الرئيسية لمحور الصنف.
   1. تعيين **تنسيق الخط** لخطوط الشبكة الثانوية لمحور الصنف.
   1. تعيين **خصائص النص** لتسميات محور الصنف.
   1. تعيين **العنوان** لمحور الصنف.
   1. تعيين **موضع التسمية** لمحور الصنف.
   1. تعيين **زاوية الدوران** لتسميات محور الصنف.
1. الوصول إلى أسطورة المخطط وتعيين **خصائص النص** الخاصة بها.
1. إظهار أسطورة المخطط دون تداخلها مع المخطط.
1. الوصول إلى **محور القيمة الثانوي** للمخطط وتعيين ما يلي:
   1. تمكين **محور القيمة الثانوي**.
   1. تعيين **تنسيق الخط** لمحور القيمة الثانوي.
   1. تعيين **تنسيق الرقم** لمحور القيمة الثانوي.
   1. تعيين **الحد الأدنى، الحد الأقصى، الوحدات الرئيسية والثانوية** لمحور القيمة الثانوي.
1. رسم السلسلة الأولى للمخطط على محور القيمة الثانوي.
1. تعيين لون تعبئة الجدار الخلفي للمخطط.
1. تعيين لون تعبئة منطقة الرسم للمخطط.
1. كتابة العرض المعدل إلى ملف PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن Presentation.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة مخطط مثال.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # ضبط عنوان المخطط.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # ضبط تنسيق خطوط الشبكة الرئيسية لمحور القيمة.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # ضبط تنسيق خطوط الشبكة الثانوية لمحور القيمة.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # ضبط تنسيق أرقام محور القيمة.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # ضبط الحد الأقصى والحد الأدنى ووحدة الرئيسة ووحدة الثانوية لمحور القيمة.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # ضبط خصائص نص محور القيمة.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # ضبط عنوان محور القيمة.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # ضبط تنسيق خطوط الشبكة الرئيسية لمحور الفئة.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # ضبط تنسيق خطوط الشبكة الثانوية لمحور الفئة.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # ضبط خصائص نص محور الفئة.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # ضبط عنوان محور الفئة.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # ضبط موضع تسمية محور الفئة.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # ضبط زاوية تدوير تسمية محور الفئة.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # ضبط خصائص نص وسيلة الإيضاح.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # إظهار وسيلة الإيضاح فوق المخطط.
    chart.legend.overlay = True
                
    # ضبط لون الجدار الخلفي للمخطط.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # ضبط لون منطقة الرسم.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # حفظ العرض التقديمي.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين خصائص خط المخطط**

يدعم Aspose.Slides للـPython تعيين خصائص الخط للمخططات. اتبع الخطوات أدناه لتكوين خصائص خط المخطط:

1. إنشاء كائن [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إضافة مخطط إلى الشريحة.
1. تعيين ارتفاع الخط.
1. حفظ العرض المعدل.

يتم توفير عينة شفرة أدناه.
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


## **تعيين تنسيق الأرقام**

توفر Aspose.Slides للـPython واجهة برمجة تطبيقات بسيطة لإدارة تنسيقات بيانات المخطط:

1. إنشاء نسخة من فئة [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع للشرحة بواسطة الفهرس الخاص بها.
1. إضافة مخطط ببيانات افتراضية من أي نوع مطلوب.
1. تعيين تنسيق رقم مسبق من القيم المسبقة المتاحة.
1. استعراض خلايا بيانات المخطط في كل سلسلة وتعيين تنسيق الرقم.
1. حفظ العرض.
1. تعيين تنسيق رقم مخصص.
1. استعراض خلايا بيانات المخطط في كل سلسلة وتعيين تنسيق رقم مختلف.
1. حفظ العرض.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء كائن فئة Presentation.
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة مخطط عمودي مجمع افتراضي.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # تعيين تنسيق الرقم المسبق.
    # استعراض كل سلسلة في المخطط.
    for series in chart.chart_data.series:
        # استعراض كل نقطة بيانات في السلسلة.
        for cell in series.data_points:
            # تعيين تنسيق الرقم.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # حفظ العرض التقديمي.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```


التنسيقات الرقمية المسبقة المتاحة ومؤشراتها المقابلة مدرجة أدناه.

|**0**|عام|
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
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **تعيين حدود مستديرة لمنطقة المخطط**

يدعم Aspose.Slides للـPython تكوين منطقة المخطط باستخدام الخاصية `Chart.has_rounded_corners`.

1. إنشاء كائن [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إضافة مخطط إلى الشريحة.
3. تعيين نوع التعبئة ولون التعبئة للمخطط.
4. تعيين خاصية الزوايا المستديرة إلى `True`.
5. حفظ العرض المعدل.

يتم توفير عينة أدناه.
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

**هل يمكنني تعيين تعبئة نصف شفافة للأعمدة/المناطق مع الحفاظ على الحدود غير شفافة؟**

نعم. يتم تكوين شفافية التعبئة والحدود بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، أوقف مكونات التسمية غير الضرورية (مثل الفئات)، اضبط إزاحة/موضع التسمية، أعرض التسميات فقط للنقاط المختارة إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + الأسطورة".

**هل يمكنني تطبيق تعبئة تدرجية أو نمطية للسلسلات؟**

نعم. عادةً ما تكون التعبئة الصلبة والتدرجية/النمطية متاحة. في الممارسة العملية، استخدم التدرجات بشكل معتدل وتجنب الجمع بينهما إذا كان ذلك يقلل من التباين مع الشبكة والنص.