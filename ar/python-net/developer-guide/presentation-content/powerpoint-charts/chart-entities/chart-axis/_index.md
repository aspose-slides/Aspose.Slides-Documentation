---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام بايثون
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
description: "اكتشف كيف تستخدم Aspose.Slides لبايثون عبر .NET لتخصيص محاور المخطط في عروض PowerPoint و OpenDocument للتقارير والتصورات."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تخصيص محاور المخطط باستخدام Aspose.Slides for Python عبر .NET. وتغطي القيم المحسوبة للمحور، تبديل صفوف وأعمدة المخطط، إظهار المحور، فواصل تسميات الفئات وعلامات الفواصل، الفئات التاريخية وتنسيقها، تدوير العنوان، موضع المحور، وحدات العرض، والقياس اللوغاريتمي.

## **الحصول على القيم القصوى على المحور العمودي في المخططات**

قم بإنشاء [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وأضف مخطط منطقة ببيانات افتراضية. استدعِ [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) قبل قراءة قيم المحور المحسوبة حتى يكون تخطيط المخطط محدثًا.

اقرأ [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) و[actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) لحدود المحور، و[actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) و[actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) لفواصل العلامات. توفر [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) و[actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) مقاييس وحدة الوقت، والتي تكون ذات صلة بمحاور التاريخ. يخزن المثال هذه القيم في متغيرات محلية ويحفظ المخطط.

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

استخدم [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. يغيّر هذا طريقة تجميع البيانات؛ لا يبدل المحاور الأفقية والعمودية. يستخدم المثال [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف الرأس وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ مخططًا بأربع سلاسل وثلاث فئات.

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

## **إخفاء المحور العمودي للمخططات الخطية**

اضبط [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) على `False` للمحور العمودي لإخفائه. ينشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور العمودي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **إخفاء المحور الأفقي للمخططات الخطية**

اضبط [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) على `False` للمحور الأفقي لإخفائه. ينشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

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

اضبط [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) لاختيار محور فئة تاريخية أو نصية. يتطلب هذا المثال وجود ملف `ExistingChart.pptx`، مع مخطط كأول شكل في الشريحة الأولى وخلايا الفئة تحتوي على قيم تاريخ إكسل رقمية. يغيّر المحور الأفقي إلى محور تاريخ. ضبط [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) على `False`، و[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) على `1`، و[major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) على الأشهر يضع الفواصل الرئيسية كل شهر.

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

عند وجود الكثير من الفئات في المخطط، قلل عدد تسميات المحور الظاهرة دون إزالة الفئات أو نقاط البيانات. اضبط [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) على `False`، ثم اضبط [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) على الفاصل الفئوي المطلوب. بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1, الفئة 2, الفئة 3, ... الفئة 24 |
| `2` | الفئة 1, الفئة 3, الفئة 5, ... الفئة 23 |
| `3` | الفئة 1, الفئة 4, الفئة 7, ... الفئة 22 |

فاصل `3` يعرض كل تسمية ثالثة، ويخفي علامتين بين كل تسمية ظاهرّة. لا يزيل الأعمدة المقابلة. يختار التباعد التلقائي فاصلًا بناءً على المساحة المتاحة؛ ولا يعرض بالضرورة كل تسمية.

علامات الفواصل لها تحكم منفصل. اضبط [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) على `False` واستخدم [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) لتحديد فواصلها. على سبيل المثال، `1` يبقي علامة فاصل عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. اضبط [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) على نمط مرئي لتتمكن من رؤية النتيجة. إعادة ضبط أي خاصية تباعد تلقائي إلى `True` يسمح للمخطط باختيار الفاصل مرة أخرى.

إنشاء المثال المستقل التالي 24 فئة وسلسلة واحدة، ثم حفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: تباعد تلقائي، تباعد يدوي للتسميات مع علامات فواصل مستقلة، وإعادة التباعد التلقائي. النسختان تحتفظان ببيانات المخطط الأصلي. لا يلزم عرض تقديمي إدخالي. يساعد نص التسمية الأفقي على رؤية الاختلاف في الكثافة بسهولة.

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

    # الشريحة 2: إظهار كل تسمية ثالثة، مع إبقاء علامة فاصل لكل فئة.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # الشريحة 3: السماح للمخطط باختيار الفواصل مرة أخرى.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**التباعد التلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتلتف إلى سطرين. قد يختلف الناتج التلقائي حسب حجم المخطط، الخطوط، وملف العرض.

![تباعد تلقائي لتسميات الفئات مع ظهور جميع الأعمدة الـ24](category-axis-automatic.png)

**التباعد اليدوي (الشريحة 2):** تُعرض كل تسمية ثالثة في سطر واحد، بينما تبقى علامات الفواصل عند كل فاصل فئة. تبقى جميع الأعمدة الـ24، بما في ذلك تلك التي لا تحمل تسميات، مرئية بنفس القيم. تستعيد الشريحة 3 المظهر التلقائي المعروض أعلاه.

![فاصل تسميات الفئة اليدوي ثلاثة مع ظهور جميع الأعمدة الـ24](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل بناءً على عدد الفئات لمحور فئة نصية، مثل محور فئة عمود، خط، منطقة، أو شريط. في مخطط عمود، يكون هو المحور الأفقي. في مخطط شريط أفقي، يكون محور الفئة عموديًا، لذا طبق هذه الإعدادات على [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). ينطبق تباعد العلامة أيضًا على محور سلسلة في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئة لتعيين مقياس عددي لمحور القيمة. على محور القيمة، يحدد [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) فرق القيم: على سبيل المثال، وحدة رئيسية مقدارها `10` تنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. بينما فاصل تسميات الفئة `3` يعد مواضع الفئات بغض النظر عن قيم البيانات. تستخدم مخططات التشتت والفقاعات محاور قيمة بدلاً من محور فئة نصية. بالنسبة للمحور الزمني، استخدم الوحدات الرئيسية والملائمات الزمنية كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **ضبط تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربعة قيم سنوية. تُخزن التواريخ كأرقام تسلسلية OLE Automation في ورقة العمل الأولى (الفهرس `0`). اضبط [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) إلى محور تاريخ، عطل [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)، وعيّن `yyyy` إلى [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) حتى تعرض تسميات الفئة سنوات بأربعة أرقام بغض النظر عن تنسيق الخلية.

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

## **ضبط زاوية الدوران لعناوين محور المخطط**

فعّل [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) على المحور العمودي، قدم نص العنوان، واضبط [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) لتدوير العنوان. الزاوية تُقاس بالدرجات؛ يحفظ المثال مخطط عمود بعنوان محور القيمة مدورًا بزاوية 90 درجة.

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

## **ضبط موضع المحور على محور فئة أو قيمة**

استخدم [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) للتحكم فيما إذا كان محور القيمة يعبر محور الفئة بين الفئات أو عند علامات الفئة. تُطبق هذه الخاصية على محاور الفئات. يضبط المثال الخاصية إلى `True` على محور الفئة الأفقي لمخطط عمود ويحفظ النتيجة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط وحدة العرض على محور قيمة المخطط**

اضبط [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) لتكبير/تصغير التسميات على محور القيمة دون تغيير البيانات الأساسية. مع ضبط [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) إلى `MILLIONS`، تُعرض القيمة 60,000,000 كـ 60. ينشئ المثال مخطط عمود ويطبق وحدة العرض بالملايين على محوره العمودي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **تكوين محور قيمة لوغاريتمي**

محور قيمة لوغاريتمي مفيد عندما تمتد القيم الإيجابية عبر عدة أوامر من الحجم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1,000، 10,000، و100,000 طلبًا خلال خمس فترات. على مقياس خطي، تظهر القيم الأصغر متقاربة قرب الصفر. يجعل المقياس اللوغاريتمي النمو النسبي أسهل للمقارنة: تمثل المسافات المتساوية نسبًا متساوية بدلاً من فروق متساوية.

اضبط [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) إلى `True` على محور القيمة واستخدم [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) لاختيار القاعدة. يغير هذا طريقة عرض القيم الحالية؛ لا يغيّر البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مُلائمة في البيانات وهو ميزة منفصلة.

### **اختر محور القيمة والقاعدة**

للمخطط الخط أو العمود، يكون محور القيمة هو [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). للمخطط الشريطي الأفقي، يكون هو [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). تحتوي مخططات التشتت والفقاعات على محوري قيمة، لذا اختر المحور الأفقي لقيم X، والمحور العمودي لقيم Y، أو كليهما. لا تُطبق المقياس اللوغاريتمي على محور فئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. لملفات PPTX، يمكن استخدام قاعدة من `2` إلى `1000` شاملة؛ تُدعم القواعد الكسرية مثل `2.5`. مع القاعدة `10`، تكون القوى المتتالية مثل 10، 100، 1,000، و10,000 متساوية التباعد.

### **قارن بين المقياس الخطي واللوغاريتمي**

ينشئ المثال المستقل التالي مخططًا خطيًا بخمس عدادات طلب في الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعل محور قيمة لوغاريتمي بقاعدة 10 في الشريحة الثانية. تحتفظ كلتا الشريحتين بنفس البيانات.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # احتفظ بالشريحة الأولى خطية وقم بتغيير مقياس محور القيمة للنسخة فقط.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**المقياس الخطي (الشريحة 1):** تمثل المسافات العمودية المتساوية اختلافات متساوية في عدد الطلبات. تهيمن القيمة الأكبر على المخطط، ما يجعل القيم الأصغر صعبة التمييز.

![مخطط خطي في PowerPoint يُظهر خمس عدادات طلب على محور قيمة خطي](value-axis-linear.png)

**المقياس اللوغاريتمي (الشريحة 2):** تمثل المسافات العمودية المتساوية نسبًا متساوية. كل فترة تحتوي على عشر مرات الطلبات مقارنةً بالسابقة، لذا تشكل النقاط خطًا مستقيمًا صاعدًا على مقياس قاعدة 10. لا تزال تسميات المحور تُظهر عدد الطلبات الأصلي.

![نفس خمس عدادات الطلب في PowerPoint على محور قيمة لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسلبية**

يمكن للمقياس اللوغاريتمي عرض قيم موجبة فقط. تحقق من البيانات قبل تفعيله. إذا كانت القيم صفرًا أو سلبية ذات معنى، احتفظ بالمقياس الخطي أو اعرضها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسّر الإزالة. لا تستبدلها صمتًا بأعداد موجبة صغيرة، لأن ذلك يغير معنى البيانات. أي حد أدنى أو أقصى تم تكوينه يدويًا لمحور لوغاريتمي يجب أن يكون موجبا أيضًا.

## **الأسئلة المتكررة**

**كيف يمكنني ضبط القيمة التي يعبر عندها محور واحد المحور الآخر (عبر المحور)؟**

استخدم [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) لاختيار سلوك العبور. لتحديد قيمة عبور عددية، اضبط [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). تتيح لك هذه الإعدادات نقل عبور المحور إلى خط أساسي مناسب.

**كيف يمكنني موضع تسميات العلامات بالنسبة للمحور؟**

اضبط [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`، `HIGH`, `NEXT_TO` أو `NONE`. للتحكم في علامات الفواصل نفسها، استخدم [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) أو [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); هذه مستقلة عن موضع التسميات.