---
title: تنسيق المخططات
type: docs
weight: 60
url: /ar/python-net/chart-formatting/
keywords: "كيانات المخططات، خصائص المخططات، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "تنسيق كيانات المخططات في عروض PowerPoint باستخدام بايثون"
---

## **تنسيق كيانات المخططات**
Aspose.Slides لبايثون عبر .NET يتيح للمطورين إضافة مخططات مخصصة إلى شرائحهم من الصفر. تشرح هذه المقالة كيفية تنسيق كيانات المخططات المختلفة بما في ذلك محور الفئة ومحور القيم.

يوفر Aspose.Slides لبايثون عبر .NET واجهة برمجة تطبيقات بسيطة لإدارة كيانات المخططات المختلفة وتنسيقها باستخدام قيم مخصصة:

1. إنشاء مثيل من الفئة **Presentation**.
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. إضافة مخطط باستخدام بيانات افتراضية مع أي نوع مرغوب (في هذا المثال سنستخدم ChartType.LineWithMarkers).
1. الوصول إلى محور القيمة في المخطط وتعيين الخصائص التالية:
   1. تعيين **تنسيق الخط** لخطوط الشبكة الكبرى لمحور القيمة
   1. تعيين **تنسيق الخط** لخطوط الشبكة الصغرى لمحور القيمة
   1. تعيين **تنسيق الأرقام** لمحور القيمة
   1. تعيين **الوحدات العليا والصغرى والكبرى والصغرى** لمحور القيمة
   1. تعيين **خصائص النص** لبيانات محور القيمة
   1. تعيين **العنوان** لمحور القيمة
   1. تعيين **تنسيق الخط** لمحور القيمة
1. الوصول إلى محور الفئة في المخطط وتعيين الخصائص التالية:
   1. تعيين **تنسيق الخط** لخطوط الشبكة الكبرى لمحور الفئة
   1. تعيين **تنسيق الخط** لخطوط الشبكة الصغرى لمحور الفئة
   1. تعيين **خصائص النص** لبيانات محور الفئة
   1. تعيين **العنوان** لمحور الفئة
   1. تعيين **تحديد التسمية** لمحور الفئة
   1. تعيين **زاوية الدوران** لتسميات محور الفئة
1. الوصول إلى وسيلة إيضاح المخطط وتعيين **خصائص النص** لها
1. تعيين عرض وسيلة إيضاح المخطط دون تداخل مع المخطط
1. الوصول إلى **محور القيمة الثانوي** في المخطط وتعيين الخصائص التالية:
   1. تفعيل **محور القيمة الثانوي**
   1. تعيين **تنسيق الخط** لمحور القيمة الثانوي
   1. تعيين **تنسيق الأرقام** لمحور القيمة الثانوي
   1. تعيين **الوحدات العليا والصغرى والكبرى والصغرى** لمحور القيمة الثانوي
1. الآن رسم سلسلة المخطط الأولى على محور القيمة الثانوي
1. تعيين لون تعبئة الجدار الخلفي للمخطط
1. تعيين لون تعبئة منطقة الرسم للمخطط
1. كتابة العرض المعدل إلى ملف PPTX

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء العرض التقديمي
with slides.Presentation() as pres:

    # الوصول إلى الشريحة الأولى
    slide = pres.slides[0]

    # إضافة المخطط المثال
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # تعيين عنوان المخطط
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chartTitle = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chartTitle.text = "مخطط عينة"
    chartTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chartTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chartTitle.portion_format.font_height = 20
    chartTitle.portion_format.font_bold = 1
    chartTitle.portion_format.font_italic = 1

    # تعيين تنسيق خطوط الشبكة الكبرى لمحور القيم
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # تعيين تنسيق خطوط الشبكة الصغرى لمحور القيم
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # تعيين تنسيق أرقام محور القيم
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # تعيين القيم القصوى والدنيا للمخطط
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # تعيين خصائص نص محور القيمة
    txtVal = chart.axes.vertical_axis.text_format.portion_format
    txtVal.font_bold = 1
    txtVal.font_height = 16
    txtVal.font_italic = 1
    txtVal.fill_format.fill_type = slides.FillType.SOLID 
    txtVal.fill_format.solid_fill_color.color = draw.Color.dark_green
    txtVal.latin_font = slides.FontData("Times New Roman")

    # تعيين عنوان محور القيمة
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    valtitle = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    valtitle.text = "المحور الأساسي"
    valtitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    valtitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    valtitle.portion_format.font_height = 20
    valtitle.portion_format.font_bold = 1
    valtitle.portion_format.font_italic = 1

    # تعيين تنسيق خطوط الشبكة الكبرى لمحور الفئة
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # تعيين تنسيق خطوط الشبكة الصغرى لمحور الفئة
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # تعيين خصائص نص محور الفئة
    txtCat = chart.axes.horizontal_axis.text_format.portion_format
    txtCat.font_bold = 1
    txtCat.font_height = 16
    txtCat.font_italic = 1
    txtCat.fill_format.fill_type = slides.FillType.SOLID 
    txtCat.fill_format.solid_fill_color.color = draw.Color.blue
    txtCat.latin_font = slides.FontData("Arial")

    # تعيين عنوان محور الفئة
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    catTitle = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    catTitle.text = "فئة عينة"
    catTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    catTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    catTitle.portion_format.font_height = 20
    catTitle.portion_format.font_bold = 1
    catTitle.portion_format.font_italic = 1

    # تعيين موضع تسميات محور الفئة
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # تعيين زاوية دوران تسميات محور الفئة
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # تعيين خصائص نص وسائل الإيضاح
    txtleg = chart.legend.text_format.portion_format
    txtleg.font_bold = 1
    txtleg.font_height = 16
    txtleg.font_italic = 1
    txtleg.fill_format.fill_type = slides.FillType.SOLID 
    txtleg.fill_format.solid_fill_color.color = draw.Color.dark_red

    # تعيين عرض وسائل الإيضاح دون تداخل مع المخطط

    chart.legend.overlay = True
                
    # تعيين لون جدار المخطط الخلفي
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red
    # تعيين لون منطقة الرسم
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # حفظ العرض التقديمي
    pres.save("FormattedChart_out.pptx", slides.export.SaveFormat.PPTX)
```



## **تعيين خصائص الخط للمخطط**
Aspose.Slides لبايثون عبر .NET يوفر دعمًا لتعيين الخصائص المتعلقة بالخط للمخطط. يرجى اتباع الخطوات أدناه لتعيين خصائص الخط للمخطط.

- إنشاء كائن من الفئة Presentation.
- إضافة مخطط على الشريحة.
- تعيين ارتفاع الخط.
- حفظ العرض التقديمي المعدل.

مثال توضيحي أدناه.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    pres.save("FontPropertiesForChart.pptx", slides.export.SaveFormat.PPTX)
```




## **تعيين تنسيق الأرقام**
Aspose.Slides لبايثون عبر .NET يوفر واجهة برمجة تطبيقات بسيطة لإدارة تنسيق بيانات المخطط:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. إضافة مخطط باستخدام بيانات افتراضية مع أي نوع مرغوب (هذا المثال يستخدم **ChartType.ClusteredColumn**).
1. تعيين تنسيق الرقم المحدد مسبقًا من القيم المحددة مسبقًا المحتملة.
1. التجول عبر خلايا بيانات المخطط في كل سلسلة مخططة وتعيين تنسيق رقم البيانات للمخطط.
1. حفظ العرض التقديمي.
1. تعيين التنسيق الرقمي المخصص.
1. التجول عبر خلايا بيانات المخطط داخل كل سلسلة مخططة وتعيين تنسيق رقم بيانات مختلف للمخطط.
1. حفظ العرض التقديمي.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء العرض التقديمي
with slides.Presentation() as pres:
    # الوصول إلى الشريحة الأولى في العرض التقديمي
    slide = pres.slides[0]

    # إضافة مخطط عمود متجمع افتراضي
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # الوصول إلى مجموعة سلاسل المخطط
    series = chart.chart_data.series

    # تعيين تنسيق الرقم المحدد مسبقًا
    # التجول عبر كل سلسلة مخططة
    for ser in series:
        # التجول عبر كل خلية بيانات في السلسلة
        for cell in ser.data_points:
            # تعيين تنسيق الرقم
            cell.value.as_cell.preset_number_format = 10 #0.00%

    # حفظ العرض التقديمي
    pres.save("PresetNumberFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

قيم تنسيق الأرقام المحددة مسبقًا الممكنة مع الفهارس المحددة مسبقًا التي يمكن استخدامها هي كما يلي:

|**0**|عام|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;اللون الأحمر$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;اللون الأحمر$-#,##0.00|
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
|**38**|#,##0;الأحمر-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;الأحمر-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **تعيين زوايا حواف المخطط المحدبة**
Aspose.Slides لبايثون عبر .NET توفر دعمًا لتعيين منطقة المخطط. تم إضافة خصائص **IChart.HasRoundedCorners** و **Chart.HasRoundedCorners** في Aspose.Slides.

1. إنشاء كائن من الفئة `Presentation`.
1. إضافة مخطط على الشريحة.
1. تعيين نوع التعبئة ولون تعبئة المخطط
1. تعيين خاصية الزوايا المدورة على صحيح.
1. حفظ العرض التقديمي المعدل.

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

	presentation.save("out.pptx", slides.export.SaveFormat.PPTX)
```