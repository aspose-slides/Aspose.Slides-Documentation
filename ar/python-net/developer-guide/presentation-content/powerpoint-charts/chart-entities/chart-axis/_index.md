---
title: تخصيص محاور المخططات في العروض التقديمية باستخدام بايثون
linktitle: محور المخطط
type: docs
url: /ar/python-net/chart-axis/
keywords:
- محور المخطط
- المحور الرأسي
- المحور الأفقي
- تخصيص المحور
- معالجة المحور
- إدارة المحور
- خصائص المحور
- القيمة القصوى
- القيمة الدنيا
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيف تستخدم Aspose.Slides for Python عبر .NET لتخصيص محاور المخططات في عروض PowerPoint وOpenDocument للتقارير والمرئيات."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص محاور المخططات باستخدام Aspose.Slides for Python عبر .NET. تتناول القيم المحسوبة للمحاور، تبديل صفوف وأعمدة المخطط، إظهار أو إخفاء المحور، فواصل تسميات الفئة وعلامات الفواصل، الفئات التاريخية وتنسيقها، دوران العنوان، موضع المحور، ووحدات العرض.

## **الحصول على القيم القصوى على المحور الرأسي في المخططات**

إنشاء [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وإضافة مخطط مساحة ببيانات افتراضية. استدعاء [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) قبل قراءة القيم المحسوبة للمحاور لضمان تحديث تخطيط المخطط.

قراءة [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) و[actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) لتحديد حدود المحور، و[actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) و[actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) لفواصل العلامات. توفر [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) و[actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) مقاييس الوحدات الزمنية ذات الصلة بالمحاور التاريخية. يخزن المثال هذه القيم في متغيرات محلية ويحفظ المخطط.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تبديل البيانات بين المحاور**

استخدام [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. هذا يغيّر طريقة تجميع البيانات؛ ولا يبدّل المحاور الأفقية والعمودية. يستخدم المثال [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف الرأس وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ المخطط بأربع سلاسل وثلاث فئات.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعطيل المحور الرأسي للمخططات الخطية**

ضبط [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) إلى `False` على المحور الرأسي لإخفائه. ينشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الرأسي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **تعطيل المحور الأفقي للمخططات الخطية**

ضبط [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) إلى `False` على المحور الأفقي لإخفائه. ينشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير محور الفئة**

ضبط [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) لاختيار محور فئة تاريخية أو نصية. يتطلب هذا المثال ملف `ExistingChart.pptx`، حيث يكون المخطط هو الشكل الأول في الشريحة الأولى وتحتوي خلايا الفئة على قيم تاريخية رقمية من Excel. يغيّر المثال المحور الأفقي إلى محور تاريخي. ضبط [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) إلى `False`، و[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) إلى `1`، و[major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) إلى أشهر يضع العلامات الرئيسية على فواصل شهرية.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **التحكم في فواصل تسميات محور الفئة**

عند وجود العديد من الفئات في المخطط، قلل عدد تسميات المحور الظاهرة دون حذف الفئات أو نقاط البيانات. اضبط [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) إلى `False`، ثم ضبط [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) إلى الفاصل الفئوي المطلوب. بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1, الفئة 2, الفئة 3, ... الفئة 24 |
| `2` | الفئة 1, الفئة 3, الفئة 5, ... الفئة 23 |
| `3` | الفئة 1, الفئة 4, الفئة 7, ... الفئة 22 |

يعرض فاصل `3` كل تسمية ثالثة، مع إخفاء تسمينتين بين كل تسمية مرئية. لا يزيل ذلك الأعمدة المقابلة. يختار التباعد التلقائي فاصلًا بناءً على المساحة المتاحة؛ ولا يُظهر بالضرورة كل تسمية.

علامات الفواصل لها تحكم مستقل. اضبط [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) إلى `False` واستخدم [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) لتعيين فاصلها. على سبيل المثال، `1` يحافظ على علامة فاصل عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. اضبط [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) إلى نمط مرئي لتتمكن من رؤية النتيجة. إعادة تعيين أي من خصائص التباعد التلقائي إلى `True` يسمح للمخطط باختيار ذلك الفاصل مرة أخرى.

ينشئ المثال المستقل التالي 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: تباعد تلقائي، تباعد يدوي للتسميات مع علامات فواصل مستقلة، واستعادة التباعد التلقائي. تحتفظ النسختان بن بيانات المخطط الأصلية. لا يلزم عرض تقديمي إدخالي. يجعل نص التسميات الأفقي الفرق في الكثافة واضحًا.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # الشريحة 2: عرض كل تسمية ثالثة، مع الحفاظ على علامة فاصل لكل فئة.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # الشريحة 3: السماح للمخطط باختيار كلا الفاصلين مرة أخرى.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**تباعد تلقائي (الشريحة 1):** في هذا العرض، تُظهر كل تسمية فئة ثانية وتُكّسّر إلى سطرين. قد يختلف الناتج التلقائي مع حجم المخطط، الخطوط، والمحرك.

![تباعد تلقائي لتسميات الفئات مع جميع الأعمدة الـ24 مرئية](category-axis-automatic.png)

**تباعد يدوي (الشريحة 2):** تُظهر كل تسمية فئة ثالثة على سطر واحد، بينما تظل علامات الفواصل عند كل فاصل فئة. جميع الأعمدة الـ24، بما في ذلك تلك بدون تسميات، تظل مرئية بنفس القيم. الشريحة 3 تستعيد المظهر التلقائي المعروض أعلاه.

![تباعد يدوي لتسميات الفئات بثلاثة مع جميع الأعمدة الـ24 مرئية](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل المتعدد الفئات لمحور فئة نصية، مثل محور فئة عمودي، خطي، مساحي، أو شريطي. في المخطط العمودي يكون هو المحور الأفقي. في المخطط الشريطي الأفقي يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). ينطبق تباعد علامات الفواصل أيضًا على محور سلسلة في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئات لضبط المقياس الرقمي لمحور القيمة. على محور القيمة، يحدد [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) فرق القيم: على سبيل المثال، وحدة رئيسية `10` تنتج علامات عند 0, 10, 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسمية الفئة `3` يعد مواضع الفئات بغض النظر عن قيم البيانات. تستخدم المخططات المتناثرة والفقاعية محاور قيم بدلاً من محور فئة نصية. للمحور التاريخي، استخدم وحدات رئيسية ومقاييس زمنية كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربع قيم سنوية. تُخزن التواريخ كأرقام تسلسلية OLE Automation في ورقة العمل الأولى (الفهرس `0`). اضبط [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) إلى محور تاريخ، عطل [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)، وعيّن `yyyy` إلى [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) حتى تعرض تسميات الفئة سنوات بأربعة أرقام بشكل مستقل عن تنسيق الخلية.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين زاوية دوران لعنوان محور المخطط**

فعّل [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) على المحور الرأسي، قدّم نص العنوان، واضبط [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ المثال مخططًا عموديًا مع دوران عنوان محور القيمة بزاوية 90 درجة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين موضع المحور على محور الفئة أو القيمة**

استخدام [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) للتحكم فيما إذا كان محور القيمة يقاطع محور الفئة بين الفئات أو عند علامات الفئة. تُطبق هذه الخاصية على محاور الفئة. يضبط المثال القيمة إلى `True` على محور الفئة الأفقي في مخطط عمودي ويحفظ النتيجة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين وحدة العرض على محور القيمة في المخطط**

اضبط [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) لتكبير التسميات على محور القيمة دون تغيير البيانات الأساسية. مع ضبط [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) إلى `MILLIONS`، يُعرض القيمة 60,000,000 كـ 60. ينشئ المثال مخططًا عموديًا ويطبق وحدة العرض بالملايين على محوره الرأسي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**كيف يمكنني ضبط القيمة التي يتقاطع عندها محور مع آخر (تقاطع المحور)؟**

استخدم [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) لاختيار سلوك التقاطع. لتحديد قيمة تقاطع رقمية، اضبط [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). تسمح هذه الإعدادات بنقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني موضع تسميات العلامات بالنسبة للمحور؟**

اضبط [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`، `HIGH`، `NEXT_TO`، أو `NONE`. للتحكم في علامات الفواصل نفسها، استخدم [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) أو [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); فهذه منفصلة عن موضع التسميات.