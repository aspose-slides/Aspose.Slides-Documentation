---
title: تنسيق الرسوم البيانية في العروض التقديمية باستخدام بايثون
linktitle: تنسيق الرسم البياني
type: docs
weight: 60
url: /ar/python-net/chart-formatting/
keywords:
- تنسيق الرسم البياني
- تنسيق الرسوم البيانية
- كيان الرسم البياني
- خصائص الرسم البياني
- إعدادات الرسم البياني
- خيارات الرسم البياني
- خصائص الخط
- حد مستدير
- PowerPoint
- OpenDocument
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "تعلم تنسيق الرسوم البيانية في Aspose.Slides للبايثون عبر .NET وارتقِ بعرض PowerPoint أو OpenDocument الخاص بك إلى مستوى احترافي مع تنسيقات بصرية جذابة."
---

## **نظرة عامة**

يُظهر هذا الدليل كيفية تنسيق الرسوم البيانية في PowerPoint باستخدام Aspose.Slides للبايثون. يشرح تخصيص كيانات الرسم البياني الأساسية—مثل محوري الفئة والقيمة، خطوط الشبكة، التسميات، العناوين، وسيلة الإيضاح، والمحاور الثانوية—ويُظهر كيفية التحكم في الخطوط، تنسيقات الأرقام، التعبئات، الحدود، ألوان مساحة الرسم والخلفية، وزوايا حواف الرسم المستديرة عبر أمثلة شفرة مختصرة قابلة للتنفيذ. باتباع الأمثلة خطوةً بخطوة، ستُنشئ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، وتضيف وتُكوّن رسمًا بيانيًا، وتحفظ النتيجة إلى PPTX مع تطبيق إعدادات بصرية وطباعة دقيقة.

## **تنسيق عناصر الرسم البياني**

يتيح Aspose.Slides للبايثون للمطورين إضافة رسوم بيانية مخصصة إلى الشرائح من الصفر. يشرح هذا القسم كيفية تنسيق عناصر الرسم البياني المتنوعة، بما في ذلك محوري الفئة والقيمة.

يوفر Aspose.Slides واجهة برمجة تطبيقات بسيطة لإدارة عناصر الرسم البياني وتطبيق تنسيقات مخصصة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة حسب الفهرس.
1. إضافة رسم بياني ببيانات افتراضية من النوع المطلوب (في هذا المثال، `ChartType.LINE_WITH_MARKERS`).
1. الوصول إلى محور القيمة وتعيين ما يلي:
   1. تعيين **تنسيق الخط** لخطوط شبكة المحور القيمي الرئيسية.
   1. تعيين **تنسيق الخط** لخطوط شبكة المحور القيمي الثانوية.
   1. تعيين **تنسيق الرقم** لمحور القيمة.
   1. تعيين **الوحدات الحد الأدنى، الحد الأعلى، الوحدات الرئيسية والثانوية** لمحور القيمة.
   1. تعيين **خصائص النص** لتسميات محور القيمة.
   1. تعيين **العنوان** لمحور القيمة.
   1. تعيين **تنسيق الخط** لمحور القيمة.
1. الوصول إلى محور الفئة وتعيين ما يلي:
   1. تعيين **تنسيق الخط** لخطوط شبكة محور الفئة الرئيسية.
   1. تعيين **تنسيق الخط** لخطوط شبكة محور الفئة الثانوية.
   1. تعيين **خصائص النص** لتسميات محور الفئة.
   1. تعيين **العنوان** لمحور الفئة.
   1. تعيين **موضع التسمية** لمحور الفئة.
   1. تعيين **زاوية الدوران** لتسميات محور الفئة.
1. الوصول إلى وسيلة إيضاح الرسم البياني وتعيين **خصائص النص** لها.
1. إظهار وسيلة إيضاح الرسم البياني دون أن تتقاطع مع الرسم.
1. الوصول إلى **محور القيمة الثانوي** وتعيين ما يلي:
   1. تمكين **محور القيمة** الثانوي.
   1. تعيين **تنسيق الخط** لمحور القيمة الثانوي.
   1. تعيين **تنسيق الرقم** لمحور القيمة الثانوي.
   1. تعيين **الوحدات الحد الأدنى، الحد الأعلى، الوحدات الرئيسية والثانوية** للمحور الثانوي.
1. رسم سلسلة البيانات الأولى على محور القيمة الثانوي.
1. تعيين لون تعبئة جدار الخلفية للرسم البياني.
1. تعيين لون تعبئة مساحة الرسم.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن Presentation.
with slides.Presentation() as presentation:

    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة رسم بياني تجريبي.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # تعيين عنوان الرسم البياني.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # تعيين تنسيق الخط الرئيسي للشبكة لمحور القيم.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # تعيين تنسيق الخط الثانوي للشبكة لمحور القيم.
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

    # تعيين تنسيق الخط الرئيسي للشبكة لمحور الفئة.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # تعيين تنسيق الخط الثانوي للشبكة لمحور الفئة.
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

    # تعيين موضع تسمية محور الفئة.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # تعيين زاوية دوران تسمية محور الفئة.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # تعيين خصائص نص وسيلة الإيضاح.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # إظهار وسيلة إيضاح الرسم البياني فوق الرسم.
    chart.legend.overlay = True
                
    # تعيين لون جدار الخلفية للرسم البياني.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # تعيين لون تعبئة مساحة الرسم.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # حفظ العرض التقديمي.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين خصائص الخط للرسم البياني**

يدعم Aspose.Slides للبايثون إعداد خصائص الخط للرسم البياني. اتبع الخطوات أدناه لضبط خصائص خط الرسم البياني:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إضافة رسم بياني إلى الشريحة.
1. تعيين ارتفاع الخط.
1. حفظ العرض التقديمي المعدل.

الكود النموذجي موضح أدناه.

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

يوفر Aspose.Slides للبايثون واجهة برمجة تطبيقات بسيطة لإدارة تنسيقات بيانات الرسم البياني:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة حسب الفهرس.
1. إضافة رسم بياني ببيانات افتراضية من أي نوع مطلوب.
1. تعيين تنسيق أرقام مسبق من القيم المتاحة.
1. استعراض خلايا بيانات الرسم في كل سلسلة وتعيين تنسيق الأرقام.
1. حفظ العرض التقديمي.
1. تعيين تنسيق أرقام مخصص.
1. استعراض خلايا بيانات الرسم في كل سلسلة وتعيين تنسيق مختلف.
1. حفظ العرض التقديمي.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء كائن Presentation.
with slides.Presentation() as presentation:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة رسم بياني عمودي مجمع افتراضي.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # تعيين تنسيق الأرقام المسبق.
    # استعراض كل سلسلة من الرسم البياني.
    for series in chart.chart_data.series:
        # استعراض كل نقطة بيانات في السلسلة.
        for cell in series.data_points:
            # تعيين تنسيق الأرقام.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # حفظ العرض التقديمي.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

الصيغ الرقمية المسبقة المتاحة ومؤشراتها موضحان أدناه.

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

## **تعيين حدود مستديرة لمنطقة الرسم البياني**

يدعم Aspose.Slides للبايثون تكوين منطقة الرسم البياني باستخدام الخاصية `Chart.has_rounded_corners`.

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إضافة رسم بياني إلى الشريحة.
3. تعيين نوع التعبئة ولونها للرسم.
4. تعيين الخاصية `has_rounded_corners` إلى `True`.
5. حفظ العرض التقديمي المعدل.

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

**هل يمكنني تعيين تعبئة شبه شفافة للأعمدة/المناطق مع الحفاظ على الحدود غير شفافة؟**

نعم. يتم تكوين شفافية التعبئة والحدود بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني معالجة تسميات البيانات عندما تتقاطع؟**

قلل حجم الخط، عطل المكونات غير الضرورية للتسمية (مثل الفئات)، عدل إزاحة/موضع التسمية، اعرض التسميات فقط للنقاط المحددة إذا لزم الأمر، أو غيّر الصيغة إلى "القيمة + وسيلة الإيضاح".

**هل يمكنني تطبيق تعبئة تدرجية أو نمطية على السلاسل؟**

نعم. تتوفر تعبئات صلبة وتدرجية/نمطية عادةً. في الممارسة العملية، استخدم التدرجات باعتدال وتجنب الجمع بينهما بحيث لا يقلل التباين مع الشبكة والنص.