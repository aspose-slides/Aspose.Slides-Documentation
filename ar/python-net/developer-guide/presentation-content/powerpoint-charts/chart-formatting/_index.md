---
title: تنسيق المخططات في العروض التقديمية باستخدام بايثون
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/python-net/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخطط
- عنصر المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حد مستدير
- PowerPoint
- OpenDocument
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides للبايثون عبر .NET وارتقِ بعرض PowerPoint أو OpenDocument الخاص بك إلى مستوى احترافي مع تصميم جذاب ولافت للانتباه."
---

## **نظرة عامة**

يُظهر هذا الدليل كيفية تنسيق مخططات PowerPoint باستخدام Aspose.Slides for Python. يشرح الخطوات لتخصيص الكيانات الأساسية للمخطط — مثل محاور الفئات والقيم، وخطوط الشبكة، والتسميات، والعناوين، والأساطير، والمحاور الثانوية — ويظهر كيفية التحكم في الخطوط، وتنسيقات الأرقام، والتعبئات، والحدود، وألوان مساحة الرسم والجدار الخلفي، والزوايا المستديرة للمخطط باستخدام نماذج شفرة مختصرة قابلة للتنفيذ. باتباع الأمثلة خطوة بخطوة، ستتمكن من إنشاء [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، إضافة وتكوين مخطط، وحفظ النتيجة كملف PPTX مع تطبيق إعدادات بصرية وطباعة دقيقة.

## **تنسيق عناصر المخطط**

يتيح Aspose.Slides for Python للمطورين إضافة مخططات مخصصة إلى الشرائح من الصفر. يشرح هذا القسم كيفية تنسيق عناصر المخطط المختلفة، بما في ذلك محوري الفئة والقيمة.

يوفر Aspose.Slides واجهة برمجية بسيطة لإدارة عناصر المخطط وتطبيق تنسيقات مخصصة:

1. إنشاء مثيل من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة عبر فهرسها.
1. إضافة مخطط ببيانات افتراضية من النوع المطلوب (في هذا المثال، `ChartType.LINE_WITH_MARKERS`).
1. الوصول إلى محور القيم للمخطط وتعيين ما يلي:
   1. تعيين **تنسيق الخط** لخطوط الشبكة الرئيسية لمحور القيم.
   1. تعيين **تنسيق الخط** لخطوط الشبكة الثانوية لمحور القيم.
   1. تعيين **تنسيق الرقم** لمحور القيم.
   1. تعيين **الوحدات الدنيا والعليا، والرئيسية والثانوية** لمحور القيم.
   1. تعيين **خصائص النص** لتسميات محور القيم.
   1. تعيين **العنوان** لمحور القيم.
   1. تعيين **تنسيق الخط** لمحور القيم.
1. الوصول إلى محور الفئة للمخطط وتعيين ما يلي:
   1. تعيين **تنسيق الخط** لخطوط الشبكة الرئيسية لمحور الفئة.
   1. تعيين **تنسيق الخط** لخطوط الشبكة الثانوية لمحور الفئة.
   1. تعيين **خصائص النص** لتسميات محور الفئة.
   1. تعيين **العنوان** لمحور الفئة.
   1. تعيين **وضعية التسميات** لمحور الفئة.
   1. تعيين **زاوية الدوران** لتسميات محور الفئة.
1. الوصول إلى أسطورة المخطط وتعيين **خصائص النص** لها.
1. إظهار أسطورة المخطط دون تغطية المخطط.
1. الوصول إلى **محور القيمة الثانوي** للمخطط وتعيين ما يلي:
   1. تمكين **محور القيمة الثانوي**.
   1. تعيين **تنسيق الخط** لمحور القيمة الثانوي.
   1. تعيين **تنسيق الرقم** لمحور القيمة الثانوي.
   1. تعيين **الوحدات الدنيا والعليا، والرئيسية والثانوية** لمحور القيمة الثانوي.
1. رسم السلسلة الأولى للمخطط على محور القيمة الثانوي.
1. تعيين لون تعبئة الجدار الخلفي للمخطط.
1. تعيين لون تعبئة مساحة الرسم للمخطط.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء فئة Presentation.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة مخطط تجريبي.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # تعيين عنوان المخطط.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # تعيين تنسيق خطوط الشبكة الرئيسية لمحور القيم.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # تعيين تنسيق خطوط الشبكة الثانوية لمحور القيم.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # تعيين تنسيق الأرقام لمحور القيم.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # تعيين الحد الأقصى، الحد الأدنى، الوحدة الرئيسية، والوحدة الثانوية لمحور القيم.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # تعيين خصائص نص محور القيم.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # تعيين عنوان محور القيم.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # تعيين تنسيق خطوط الشبكة الرئيسية لمحور الفئة.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # تعيين تنسيق خطوط الشبكة الثانوية لمحور الفئة.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # تعيين خصائص نص محور الفئة.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # تعيين عنوان محور الفئة.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # تعيين موضع تسميات محور الفئة.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # تعيين زاوية دوران تسميات محور الفئة.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # تعيين خصائص نص المفتاح.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # إظهار مفتاح المخطط متراكبًا على المخطط.
    chart.legend.overlay = True
                
    # تعيين لون الجدار الخلفي للمخطط.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # تعيين لون منطقة الرسم.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # حفظ العرض التقديمي.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين خصائص خط المخطط**

يدعم Aspose.Slides for Python تعيين الخصائص المتعلقة بالخط للمخططات. اتبع الخطوات أدناه لتكوين خصائص خط المخطط:

1. إنشاء كائن [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إضافة مخطط إلى الشريحة.
1. تعيين ارتفاع الخط.
1. حفظ العرض التقديمي المعدل.

نموذج الشفرة موضح أدناه.
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

يوفر Aspose.Slides for Python واجهة برمجية بسيطة لإدارة تنسيقات بيانات المخطط:

1. إنشاء مثيل من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة عبر فهرسها.
1. إضافة مخطط ببيانات افتراضية من أي نوع مطلوب.
1. تعيين تنسيق رقم مسبق من القيم المتاحة.
1. استعراض خلايا بيانات المخطط في كل سلسلة وتعيين تنسيق الرقم.
1. حفظ العرض التقديمي.
1. تعيين تنسيق رقم مخصص.
1. استعراض خلايا بيانات المخطط في كل سلسلة وتعيين تنسيق رقم مختلف.
1. حفظ العرض التقديمي.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة مخطط أعمدة مجمعة افتراضي.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # تعيين تنسيق الرقم المسبق.
    # التنقل عبر كل سلسلة في المخطط.
    for series in chart.chart_data.series:
        # التنقل عبر كل نقطة بيانات في السلسلة.
        for cell in series.data_points:
            # تعيين تنسيق الرقم.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # حفظ العرض التقديمي.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```


القيم المسبقة لتنسيق الأرقام ومؤشراتها المقابلة مدرجة أدناه.

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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **تعيين حدود مستديرة لمنطقة المخطط**

يدعم Aspose.Slides for Python تكوين منطقة المخطط باستخدام الخاصية `Chart.has_rounded_corners`.

1. إنشاء كائن [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إضافة مخطط إلى الشريحة.
3. تعيين نوع التعبئة ولون التعبئة للمخطط.
4. تعيين خاصية الزوايا المستديرة إلى `True`.
5. حفظ العرض التقديمي المعدل.

نموذج توضيحي موضح أدناه.
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


## **الأسئلة المتكررة**

**هل يمكنني تعيين تعبئة شبه شفافة للأعمدة/المناطق مع الحفاظ على حد غير شفاف؟**

نعم. يتم تكوين شفافية التعبئة والحد الخارجي بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، أو عطل مكونات التسميات غير الضرورية (مثل الفئات)، أو اضبط إزاحة/موضع التسمية، أو اعرض التسميات للنقاط المحددة فقط إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + الأسطورة".

**هل يمكنني تطبيق تعبئة تدرج لوني أو نمطية على السلاسل؟**

نعم. عادةً ما تكون كل من التعبئات الصلبة والتدرجية/النمطية متاحة. في الممارسة العملية، استخدم التدرجات بحذر وتجنب الجمع بينها بما يقلل التباين مع الشبكة والنص.