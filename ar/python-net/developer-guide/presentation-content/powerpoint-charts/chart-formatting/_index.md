---
title: تنسيق المخططات في العروض التقديمية باستخدام Python
linktitle: تنسيق المخططات
type: docs
weight: 60
url: /ar/python-net/chart-formatting/
keywords:
- تنسيق مخطط
- تنسيق المخطط
- كيان المخطط
- خصائص المخطط
- إعدادات المخططات
- خيارات المخطط
- خصائص الخط
- حدود مستديرة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرّف على تنسيق المخططات في Aspose.Slides for Python عبر .NET وارتقِ بعرض PowerPoint التقديمي باستخدام محاور مخصّصة، خطوط، تنسيقات رقمية، وحدود مخطط مستديرة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق المخططات في عروض PowerPoint باستخدام Aspose.Slides. تُظهر كيفية تخصيص عناصر المخطط الأساسية مثل المحاور، خطوط الشبكة، العناوين، وسيلة الإيضاح، منطقة الرسم، وتعبئة الجدران لتحسين مظهر وقراءة بيانات المخطط.

كما تُظهر كيفية تعيين خصائص الخط لنص المخطط، وتطبيق تنسيقات عددية مسبقة الإعداد لبيانات المخطط، وتفعيل الزوايا الدائرية لمنطقة المخطط. معًا، تُظهر هذه الأمثلة كيفية التحكم في كلٍ من النمط البصري وعرض البيانات للمخططات في العرض التقديمي.

## **تنسيق كيانات المخطط**

استخدم [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) لتنسيق عناوين المخطط، المحاور، خطوط الشبكة، وسيلة الإيضاح، ومنطقة الرسم. تُنشئ هذه المثال مخطط خط مع علامات وبيانات افتراضية، ثم تُطبق أنماط نصية وخطية منفصلة على محوري القيمة والفئة. يتم تحديد أحجام الخطوط وعرض الخطوط بالنقاط؛ ويتم تدوير تسميات الفئات بزاوية 45 درجة.

يستخدم المحور القيمي [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) بشكل مستقل عن الخلايا المصدرية. يمتد نطاقه من -2 إلى 15، مع فواصل رئيسية بقيمة 2 وفواصل فرعية بقيمة 0.5. يجمع المثال أيضًا تنسيق النسبة المئوية مع [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) المضبوط على الآلاف، لذا قم بتكييف هذه الإعدادات وفق معنى وحجم بياناتك. تبقى وسيلة الإيضاح خارج منطقة الرسم لأن [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) معطلة. يتم تكوين تعبئة الجدار الخلفي والأرضية عبر [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) و [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/)، ولكن هذه الأسطح تظهر فقط في المخططات ثلاثية الأبعاد.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين خصائص الخط للمخطط**

قم بتعيين حجم الخط الافتراضي لنص المخطط عبر [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). تُنشئ هذه المثال مخطط أعمدة متجمع بحجم خط يبلغ 20 نقطة وتُفعل تسميات القيم للسلسلة الأولى عبر [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). يمكن لعناصر النص التي لديها إعدادات خط صريحة خاصة بها أن تتجاوز الإعداد الافتراضي للمخطط.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين التنسيق الرقمي**

استخدم [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) لتطبيق تنسيق رقمي مدمج على خلايا دفتر عمل المخطط. تُنشئ هذه المثال مخطط أعمدة متجمع ببيانات افتراضية مدعومة بالخلايا وتطبق مؤشر التنسيق 10 (`0.00%`) على كل خلية قيمة للسلسلة. يغيّر ذلك طريقة عرض القيم في دفتر العمل دون تغيير الأرقام الأساسية؛ على سبيل المثال، يتم عرض 0.25 كـ 25.00%. يمكن تكوين تنسيقات المحور وتنسيقات تسميات البيانات بشكل منفصل.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

القائمة التالية تُظهر مؤشرات التنسيقات الرقمية المدمجة مع صيغ Excel تمثيلية للغة الإنجليزية (الولايات المتحدة). قد تختلف سلاسل التنسيق الدقيقة وعرضها حسب التطبيق واللغة، خصوصًا للعملات والتواريخ. بعض صيغ Excel تختلف أيضًا عن القيم الافتراضية في معيار OOXML، كما هو موضح في [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| الفهرس | الصيغة |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **تعيين حدود مستديرة لمنطقة المخطط**

فعِّل [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) لجعل زوايا منطقة المخطط مستديرة. تُنشئ هذه المثال مخطط أعمدة متجمع وتستخدم [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) لإعطاء حدوده لونًا رماديًا صلبًا ونمط خط واحد قبل حفظ العرض التقديمي.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **تحرير تعليقات المخطط الحالية**

يمكن للمخطط أن يحتوي على أشكال مخصصة، مثل تعليق نصي يشرح حالة تقرير معين. يمكنك الوصول إلى هذه الأشكال عبر [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). تحتوي مجموعة [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) الخاصة به على الأشكال المملوكة للمخطط.

مربع نص عادي موضع فوق المخطط يخص الشريحة، حتى وإن بدا كجزء من المخطط. التكرار عبر [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) يكتشف المخطط والأشكال العادية في الشريحة، لكنه لا يُدرج الأشكال الفردية داخل المخطط. عناوين المخطط وتسمية البيانات هي عناصر مخطط منفصلة، وليست تعليقات مخصصة في هذه المجموعة.

حمّل ملف [chart-annotations.pptx](chart-annotations.pptx) وضعه في دليل عمل التطبيق. تحتوي شريحته الأولى على مخطط يضم تعليقًا غير مجموعة يُقرأ "Preliminary results"، وخطًا مملوكًا للمخطط، ومربع نص شريحة عادي يُقرأ "Slide overlay". يُحدد المثال المخطط الأول على تلك الشريحة ويغيّر التعليق إلى "Final results" عندما يكون التقرير جاهزًا للنشر. يتحقق من وجود مجموعة فارغة ولا يعدّل سوى [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) يحتوي على [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) غير `None` ويحتوي على النص المتوقع.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

يبقى الخط ومربع النص في الشريحة دون تغيير. تُظهر الصور التالية المدخل والنتيجة المحفوظة التي تم فتحها مرة أخرى:

| قبل التحرير | بعد التحرير |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
يفحص المثال فقط الأشكال المملوكة للمخطط على المستوى الأعلى. إذا كان التعليق داخل [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، فافحص مجموعة [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) الخاصة بذلك التجمع أيضًا. كرر ذلك بصورة متكررة للمجموعات المتداخلة، مع تطبيق نفس فحوصات النص على الأشكال الفرعية. التجمع نفسه هو حاوية؛ لا تُعامِلها كمربع نص.
{{% /alert %}}

## **FAQ**

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المناطق مع الحفاظ على حدود غير شفافة؟**

نعم. يتم تكوين شفافية التعبئة والحد الخارجي بشكل منفصل. هذا مفيد لتحسين وضوح الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، عطل مكونات التسمية غير الضرورية (مثل الفئات)، عدّل موضع التسمية، أظهر التسميات فقط للنقاط المحددة إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + وسيلة الإيضاح".

**هل يمكنني تطبيق تعبئات تدرجية أو نمطية للسلسلات؟**

نعم. تدعم السلسلات تعبئات صلبة، تدرجية، ونمطية. عمليًا، استخدم التدرجات بشكل محدود وتجنب التركيبات التي تقلل التباين مع الشبكة والنص.