---
title: تنسيق المخططات في العروض باستخدام بايثون
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
  - عرض تقديمي
  - Python
  - Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides لبايثون عبر .NET وارتقِ بعرض PowerPoint الخاص بك باستخدام محاور مخصصة، خطوط، تنسيقات رقمية، وحدود مخطط مستديرة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق المخططات في عروض PowerPoint باستخدام Aspose.Slides. تُظهر كيفية تخصيص العناصر الأساسية للمخطط مثل المحاور، خطوط الشبكة، العناوين، وسائط الإيضاح، منطقة الرسم، وتعبئات الجدار لتحسين مظهر وقراءة بيانات المخطط.

كما تُظهر كيفية ضبط خصائص الخط لنص المخطط، وتطبيق تنسيقات عددية مُعَدَّة مسبقًا على بيانات المخطط، وتمكين الزوايا المستديرة لمنطقة المخطط. معًا، تُظهر هذه الأمثلة كيفية التحكم في كل من النمط البصري وعرض البيانات للمخططات في عرض تقديمي.

للحصول على تعبئات وخطوط خارجية منفصلة للفترات الصاعدة والهابطة، راجع [مثال مخطط الأسهم](/slides/ar/python-net/create-chart/#create-stock-charts).

## **تنسيق كائنات المخطط**

استخدم [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) لتنسيق عناوين المخطط، والمحاور، وخطوط الشبكة، ووسائط الإيضاح، ومنطقة الرسم. ينشئ هذا المثال مخططًا خطيًا مع علامات وبيانات افتراضية، ثم يطبق أنماط نص وخط منفصلة على محوري القيمة والفئة. تُحدد أحجام الخطوط وعرض الخطوط بالنقاط؛ تُدور تسميات الفئات بزاوية 45 درجة.

يستخدم محور القيمة [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) بشكل مستقل عن خلايا المصدر. يمتد نطاقه من -2 إلى 15، مع فواصل رئيسية بقيمة 2 وفواصل فرعية بقيمة 0.5. يجمع المثال أيضًا تنسيق النسبة المئوية مع [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) مضبوطًا على الآلاف، لذا عدّل هذه الإعدادات وفقًا لمعنى وحجم بياناتك. يظل وسائط الإيضاح خارج منطقة الرسم لأن [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) معطَّل. يتم تكوين تعبئات الجدار الخلفي والأرضية عبر [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) و[floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/)، لكن هذه الأسطح تُظهر فقط في المخططات ثلاثية الأبعاد.

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

## **ضبط خصائص الخط لمخطط**

قم بتعيين حجم الخط الافتراضي لنص المخطط عبر [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). ينشئ المثال مخطط أعمدة متجمع بحجم خط 20 نقطة ويمكّن تسميات القيم للسلسلة الأولى عبر [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). يمكن لعناصر النص ذات إعدادات الخط الصريحة الخاصة بها أن تتجاوز الإعداد الافتراضي للمخطط.

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

## **إعادة استخدام تنسيق إطار النص لوسائط إيضاح المخطط**

لمطابقة وسائط الإيضاح مع عنوان الشريحة، اضبط الخط عبر [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) في الفقرة الأولى للعنوان. استدعِ [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) على [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/). ينسخ ذلك إعدادات إطار النص، تنسيق الفقرة الأولى، وخصائص الخط الافتراضية لتلك الفقرة. يبقى التنسيق المطبق مباشرةً على الأجزاء الفردية أو على الفقرات اللاحقة محليًا في المصدر.

يستخدم المثال عنوانًا بالخط العريض، اللون الأزرق الداكن، بحجم 26 نقطة من خط Calibri كقالب. بعد تنسيق وسائط الإيضاح، يستخدم [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) لتطبيق نفس التنسيق على تسمية توضيحية منفصلة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

في العرض التقديمي المحفوظ، يتطابق وسائط الإيضاح والتسمية التوضيحية مع العنوان في الحجم والوزن واللون. لا يزال وسائط الإيضاح يعرض أسماء السلاسل، وتحتفظ التسمية التوضيحية بنصها الخاص. إذا كان جزء من التسمية التوضيحية يحتوي بالفعل على حجم خط صريح، فإن ذلك الحجم له الأسبقية على حجم الفقرة المنسوخ.

| قبل النسخ | بعد النسخ |
| --- | --- |
| ![مخطط مبيعات ربع السنوية مع تسميات وسائط إيضاح سوداء عادية وتسمية توضيحية سوداء](legend-formatting-before.png) | ![نفس المخطط مع تسميات وسائط إيضاح زرقاء داكنة أكبر وعريضة وتسمية توضيحية مطابقة](legend-formatting.png) |

## **ضبط التنسيق الرقمي**

استخدم [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) لتطبيق تنسيق رقمي مدمج على خلايا دفتر عمل المخطط. ينشئ هذا المثال مخطط أعمدة متجمع مع بيانات افتراضية مدعومة بالخلايا ويطبق مؤشر التنسيق 10 (`0.00%`) على كل خلية قيمة سلسلة. يغير ذلك طريقة عرض القيم في دفتر العمل دون تعديل الأرقام الأساسية؛ على سبيل المثال، يُعرض 0.25 كـ 25.00٪. يمكن تكوين تنسيقات المحور وتنسيقات تسميات البيانات بشكل منفصل.

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

القائمة التالية تُظهر مؤشرات التنسيقات الرقمية المدمجة مع صيغ Excel النموذجية للمنطقة الإنجليزية (الولايات المتحدة). قد تختلف سلاسل التنسيق الدقيقة وعرضها حسب التطبيق والمنطقة، خاصةً للعملات والتواريخ. بعض صيغ Excel تختلف أيضًا عن القيم الافتراضية في معيار OOXML، كما هو موضح في [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| المؤشر | التنسيق |
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

## **ضبط زوايا منطقة المخطط المستديرة**

فعِّل [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) لتقويس زوايا منطقة المخطط. ينشئ المثال مخطط أعمدة متجمع ويستخدم [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) لإعطاء حدودها لونًا رماديًا صلبًا ونمط خط أحادي قبل حفظ العرض التقديمي.

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

يمكن للمخطط أن يحتوي على أشكال مخصصة، مثل تعليق نصي يوضح حالة تقرير. يمكن الوصول إلى هذه الأشكال عبر [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). تحتوي مجموعة [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) على الأشكال المملوكة للمخطط.

صندوق النص العادي الموضوع فوق المخطط يخص الشريحة، حتى وإن بدا وكأنه جزء من المخطط. يتيح التكرار عبر [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) العثور على المخطط والأشكال العادية في الشريحة، لكنه لا يُعدّ الأشكال الفردية داخل المخطط. عناوين المخطط وتسميات البيانات هي عناصر مخطط منفصلة، ليست تعليقات مخصصة في هذه المجموعة.

نزل [chart-annotations.pptx](chart-annotations.pptx) وضعه في دليل العمل الخاص بالتطبيق. يحتوي شريحته الأولى على مخطط مع تعليق غير مجمع يُظهر "Preliminary results"، وخط مملوك للمخطط، وصندوق نص عادي في الشريحة يُظهر "Slide overlay". يجد المثال أول مخطط في تلك الشريحة ويُغيّر التعليق إلى "Final results" عندما يكون التقرير جاهزًا للنشر. يتحقق من وجود مجموعة فارغة ولا يعدل سوى [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) يملك [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) غير `None` ويحتوي على النص المتوقع.

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

يبقى الخط وصندوق النص في الشريحة دون تغيير. تُظهر الصور التالية المُدخل والنتيجة المُحَفَّظة بعد إعادة الفتح:

| قبل التعديل | بعد التعديل |
| --- | --- |
| ![تعليق المخطط يقرأ "Preliminary results"](chart-annotations-before.png) | ![تعليق المخطط يقرأ "Final results"](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
يتفقد المثال الأشكال المملوكة للمخطط على المستوى الأعلى فقط. إذا كان التعليق داخل [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)، فافحص مجموعة [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) الخاصة بتلك المجموعة أيضًا. كرّر ذلك بشكل متكرر للمجموعات المتداخلة، مع تطبيق نفس الفحوصات النصية على الأشكال التابعة لها. المجموعة نفسها هي حاوية؛ لا تعاملها كصندوق نص.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المناطق مع الحفاظ على الحد غير شفاف؟**

نعم. يتم تكوين شفافية التعبئة والحد بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، عطل مكونات التسمية غير الضرورية (مثل الفئات)، اضبط موضع التسمية، أعرض التسميات فقط للنقاط المختارة إذا لزم الأمر، أو غيّر التنسيق إلى "value + legend".

**هل يمكنني تطبيق تعبئات تدرجية أو نمطية على السلاسل؟**

نعم. تدعم السلاسل تعبئات صلبة، وتدرجية، ونمطية. في الممارسة العملية، استخدم التدرجات باعتدال وتجنب التركيبات التي تقلل التباين مع الشبكة والنص.