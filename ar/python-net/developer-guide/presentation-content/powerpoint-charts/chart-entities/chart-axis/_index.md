---
title: "تخصيص محاور المخطط في العروض التقديمية باستخدام بايثون"
linktitle: "محور المخطط"
type: docs
url: /ar/python-net/chart-axis/
keywords:
- "محور المخطط"
- "محور عمودي"
- "محور أفقي"
- "تخصيص المحور"
- "التلاعب بالمحور"
- "إدارة المحور"
- "خصائص المحور"
- "القيمة القصوى"
- "القيمة الدنيا"
- "خط المحور"
- "تنسيق التاريخ"
- "عنوان المحور"
- "موضع المحور"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "Python"
- "Aspose.Slides"
description: "اكتشف كيفية استخدام Aspose.Slides للبايثون عبر .NET لتخصيص محاور المخطط في عروض PowerPoint وOpenDocument لإنشاء تقارير وتصورات."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص محاور المخطط باستخدام Aspose.Slides للـ Python عبر .NET. وتغطي قيم المحور المحسوبة، تبديل صفوف وأعمدة المخطط، رؤية المحور، فواصل تسميات الفئات وعلامات الفواصل، فئات التاريخ وتنسيقها، دوران العنوان، موضع المحور، وحدات العرض، والتمثيل اللوغاريتمي.

## **الحصول على القيم القصوى على المحور العمودي في المخططات**

قم بإنشاء [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وأضف مخطط منطقة ببيانات افتراضية. استدعِ [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) قبل قراءة قيم المحور المحسوبة لضمان أن تخطيط المخطط محدث.

اقرأ [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) و[actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) لتحديد حدود المحور، و[actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) و[actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) لفواصل العلامات. توفر [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) و[actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) مقاييس الوحدات الزمنية، وهي ذات صلة بمحاور التاريخ. المثال يخزن هذه القيم في متغيرات محلية ويحفظ المخطط.

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

استخدم [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. هذا يغيّر طريقة تجميع البيانات؛ ولا يبدل المحاور الأفقية والعمودية. يستخدم المثال [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف الرأس وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ مخططًا بأربع سلاسل وثلاث فئات.

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

## **عكس ترتيب الرسم لمحور**

استخدم [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) لعكس محور فئة أو قيمة. على سبيل المثال، يمكن لمخطط شريطي أفقي أن يُظهر مراحل المشروع من الأعلى إلى الأسفل بنفس ترتيب ورقة العمل: التخطيط، التطوير، الاختبار. عكس المحور يغيّر اتجاه الرسم؛ ولا يقوم بفرز أو إعادة ترتيب بيانات المصنف. بالمقارنة، [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) يبدل أدوار السلاسل والفئات.

المثال التالي ينشئ مخطط شريطي أفقي بثلاث مراحل وسلسلة واحدة. يحفظ عرضًا تقديميًا بثلاث شرائح: الترتيب الطبيعي، الفئات المعكوسة، والقيم المعكوسة. كل نسخة تستخدم نفس مجموعة البيانات، ويتم عكس محور واحد فقط في كل نسخة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # الشريحة 2: عرض الفئة الأولى في الأعلى.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # احتفظ بمحور القيمة الأفقي في الأسفل.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # الشريحة 3: عكس مقياس الأرقام الأفقي فقط.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

يمكن لعكس المحور أيضًا نقل المحور المتقاطع إلى الجانب المقابل من الرسم. تتحكم [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) في مكان تقاطع المحور الآخر مع المحور المكوَّن. في الشريحة 2، يؤدي تعيينه إلى `MAXIMUM` على محور الفئة المعكوس الحفاظ على محور القيمة الأفقي في الأسفل. لتحديد نقطة تقاطع معينة، استخدم [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). راجع إعدادات التقاطع عند تغيير الاتجاه، خاصةً إذا كان المخطط يحتوي بالفعل على نقطة تقاطع مخصصة. عِد بـ `is_plot_order_reversed` إلى `False` لاستعادة اتجاه الرسم الطبيعي؛ إعدادات التقاطع مستقلة.

| الترتيب الطبيعي (الشريحة 1) | الفئات المعكوسة (الشريحة 2) | القيم المعكوسة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريطي أفقي بترتيب فئة ومحور قيمة طبيعي](axis-order-normal.png) | ![مخطط شريطي أفقي مع عرض الفئات من الأعلى إلى الأسفل](axis-order-categories-reversed.png) | ![مخطط شريطي أفقي مع محور قيمة معكوس والصفر على اليمين](axis-order-values-reversed.png) |
| الفئات تُعرض من الأسفل إلى الأعلى؛ القيم تزداد من اليسار إلى اليمين. | التخطيط، التطوير، والاختبار تُعرض من الأعلى إلى الأسفل. القيم وترتيب صفوف المصنف لم يتغيرا. | الفئات تحتفظ بترتيبها الطبيعي؛ القيم تزداد من اليمين إلى اليسار. يتقاطع محور الفئة عند الصفر على اليمين. |

## **تعطيل المحور العمودي لمخططات الخط**

عيّن [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) إلى `False` على المحور العمودي لإخفائه. ينشئ المثال مخطط خط ببيانات افتراضية ويحفظه مع إخفاء المحور العمودي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **تعطيل المحور الأفقي لمخططات الخط**

عيّن [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) إلى `False` على المحور الأفقي لإخفائه. ينشئ المثال مخطط خط ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **إظهار أو إخفاء خطوط الشبكة في المخطط**

اقرأ [show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/) و[show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/) للتحقق من الخطوط التي يعرضها المحور. كلا الخصائص للقراءة فقط. لإظهار خطوط الشبكة الصغرى، عيّن تعبئة الخط في [minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/) إلى تعبئة صلبة واختر لونًا مرئيًا. لإخفائها، عيّن نوع التعبئة إلى `FillType.NO_FILL`. بالنسبة للخطوط الكبيرة، استخدم [major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format`. يضمن تغيير التعبئة الحفاظ على رؤية المحور وعلامات الفواصل.

المحور العمودي لهذا المخطط العمودي المجمّع يبدأ بخطوط شبكة كبرى مرئية وخطوط شبكة صغرى مخفية. يُظهر المثال الخطوط الصغرى باللون البرتقالي، ثم يخفيها مرة أخرى قبل حفظ العرض التقديمي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| خطوط الشبكة الصغرى مفعلة | خطوط الشبكة الصغرى مخفية |
| --- | --- |
| ![خطوط شبكة صغرى برتقالية بين خطوط الشبكة الكبيرة على المحور العمودي](minor-gridlines-enabled.png) | ![نفس المخطط العمودي مع ظهور خطوط الشبكة الكبيرة فقط](minor-gridlines-hidden.png) |

## **تغيير محور الفئة**

عيّن [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) لاختيار محور فئة تاريخية أو نصية. يتطلب هذا المثال ملف `ExistingChart.pptx`، حيث يكون المخطط هو الشكل الأول في الشريحة الأولى وتحتوي خلايا الفئة على قيم تاريخية رقمية من Excel. يغيّر المحور الأفقي إلى محور تاريخ. عيّن [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) إلى `False`، و[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) إلى `1`، و[major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) إلى شهور لتحديد العلامات الكبرى على فواصل شهرية.

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

### **تحديد نوع محور الفئة من البيانات**

استدعِ [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/) بعد تعبئة الفئات، ثم اقرأ [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) للتحقق من الاختيار. هذا مفيد عندما يتلقى المخطط إما تسميات نصية أو قيم تاريخ رقمية. الطريقة تحدد النوع عند الاستدعاء؛ ولا تُفعّل وضعًا مستمرًا يُعيد التقييم عندما تتغير البيانات لاحقًا. استدعِها مرة أخرى بعد استبدال الفئات.

المثال التالي ينشئ مخططًا بفئات نصية ويطبع `TEXT`. ثم يستبدل قيم خلايا الفئة بالتواريخ ويستدعي الطريقة مرة أخرى، حيث يطبع `DATE`. تُخزن التواريخ كقيم رقمية من نوع OLE Automation، محسوبة هنا كعدد الأيام منذ 30 ديسمبر 1899، وليس كسلاسل تاريخية. يتحكم [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) في طريقة عرض تلك القيم؛ ولا يحول النص إلى تواريخ رقمية. لمزيد من المعلومات حول خلايا الفئة، راجع [Chart Workbook](/slides/ar/python-net/chart-workbook/).

استخدم التحديد التلقائي عندما يكون الإدخال معروفًا بأنه يحتوي على فئات نصية أو تواريخ رقمية، كما في هذا المثال. بالنسبة للتسميات الرقمية العادية أو الفئات المختلطة أو البيانات الفارغة، عيّن صراحةً [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) ليتطابق مع المعنى المقصود. القيم الرقمية وحدها لا تثبت أن الفئات تمثل تواريخ.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # نص

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # تاريخ

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **التحكم في فواصل تسميات محور الفئة**

عند وجود العديد من الفئات في المخطط، قلل عدد التسميات الظاهرة على المحور دون إزالة الفئات أو نقاط البيانات. عيّن [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) إلى `False`، ثم عيّن [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) إلى الفاصل الفئوي المطلوب. للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، … الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، … الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، … الفئة 22 |

الفاصل `3` يعرض كل تسمية ثالثة، ويخفي اثنتين بين كل تسمية معروضة. لا يُزيل الأعمدة المقابلة. يختار التباعد التلقائي فاصلًا بناءً على المساحة المتاحة؛ ولا يُظهر بالضرورة كل تسمية.

علامات الفواصل لها تحكم منفصل. عيّن [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) إلى `False` واستخدم [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) لتحديد فاصلها. على سبيل المثال، `1` يبقي علامة فاصل عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. عيّن [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) إلى نمط مرئي لتتمكن من رؤية النتيجة. إعادة تعيين أي من خصائص التباعد التلقائي إلى `True` يسمح للمخطط باختيار الفاصل مرة أخرى.

المثال المستقل التالي ينشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: تباعد تلقائي، تباعد يدوي للتسميات مع علامات فواصل مستقلة، وإرجاع التباعد التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم عرض تقديمي إدخالي. يُظهر النص الأفقي للتسميات الفرق في الكثافة بوضوح.

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

    # الشريحة 3: السماح للمخطط باختيار كلتا الفواصل مرة أخرى.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**التباعد التلقائي (الشريحة 1):** في هذا العرض، تُظهر كل تسمية فئة ثانية وتُلتف إلى سطرين. قد يختلف الناتج التلقائي باختلاف حجم المخطط، الخطوط، وأداة العرض.

![تباعد تسميات الفئات التلقائي مع إظهار جميع الأعمدة الـ 24](category-axis-automatic.png)

**التباعد اليدوي (الشريحة 2):** تُظهر كل تسمية ثالثة على سطر واحد، بينما تبقى علامات الفواصل عند كل فاصل فئة. تظل جميع الأعمدة الـ 24، بما فيها غير المعروضة، مرئية بنفس القيم. تُعيد الشريحة 3 استعادة المظهر التلقائي المعروض أعلاه.

![فاصل تسميات فئة يدوي بثلاثة مع إظهار جميع الأعمدة الـ 24](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل العددي للفئات النصية، مثل محور الفئة في مخطط عمودي، خطي، مساحي أو شريطي. في المخطط العمودي، يكون هو المحور الأفقي. في المخطط الشريطي الأفقي، يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). ينطبق تباعد علامات الفواصل أيضًا على محور السلسلة في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئة لتعيين المقياس الرقمي لمحور القيمة. على محور القيمة، يحدد [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) الفرق بين القيم: على سبيل المثال، وحدة كبرى `10` تُنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسميات الفئة `3` يعد مواضع الفئات بغض النظر عن قيم بياناتها. تستخدم مخططات التشتت والفقاعات محاور قيم بدلاً من محور فئة نصية. بالنسبة لمحور التاريخ، استخدم الوحدات الكبرى والمقاييس الزمنية كما هو موضح في [Change a Category Axis](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يقوم المثال باستبدال بيانات المخطط الافتراضية بأربعة قيم سنوية. تُخزن التواريخ كأرقام تسلسلية OLE Automation في أول ورقة عمل (الفهرس `0`). عيّن [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) إلى محور تاريخ، عطل [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)، وعيّن `yyyy` إلى [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) حتى تُظهر تسميات الفئة السنوات بأربعة أرقام بغض النظر عن تنسيق الخلية.

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

## **تعيين زاوية الدوران لعنوان محور المخطط**

فعّل [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) على المحور العمودي، قدّم نص العنوان، وعيّن [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) لدوران العنوان. تُقاس الزاوية بالدرجات؛ يحفظ المثال مخططًا عموديًا بعنوان محور القيمة مدورًا بـ 90 درجة.

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

استخدم [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) للتحكم فيما إذا كان محور القيمة يتقاطع مع محور الفئة بين الفئات أو عند علامات الفئات. تنطبق هذه الخاصية على محاور الفئة. يعيّن المثال الخاصية إلى `True` على محور الفئة الأفقي لمخطط عمودي ويحفظ النتيجة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين وحدة العرض على محور قيمة المخطط**

عيّن [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) لتكبير أو تصغير التسميات على محور القيمة دون تغيير البيانات الأصلية. عندما تُعيَّن [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) إلى `MILLIONS`، يُعرض القيمة 60 000 000 كـ 60. ينشئ المثال مخططًا عموديًا ويطبق وحدة العرض بالملايين على محوره العمودي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **تهيئة محور قيمة لوغاريتمي**

محور قيمة لوغاريتمي مفيد عندما تمتد القيم الموجبة عبر عدة أوامر من الحجم. على سبيل المثال، قد تتلقى خدمة 10، 100، 1 000، 10 000، و100 000 طلبًا عبر خمس فترات. على مقياس خطي، تظهر القيم الأصغر متقاربة قرب الصفر. يسهّل المقياس اللوغاريتمي مقارنة النمو النسبي: المسافات المتساوية تمثل نسبًا متساوية بدلاً من اختلافات متساوية.

عيّن [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) إلى `True` على محور القيمة واستخدم [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) لتحديد القاعدة. يغيّر هذا طريقة عرض القيم الحالية؛ ولا يغير البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مُناسبة في البيانات وهو خاصية منفصلة.

### **اختر محور القيمة والقاعدة**

في مخطط خط أو عمودي، يكون محور القيمة هو [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). في مخطط شريطي أفقي، يكون هو [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). تتوفر مخططات التشتت والفقاعات على محورين قيم، لذا اختر المحور الأفقي لقيم X، والمحور العمودي لقيم Y، أو كلاهما. لا تُطبق التدرج اللوغاريتمي على محور الفئة.

القيمة الافتراضية للقاعدة اللوغاريتمية هي `10`. لمخططات PPTX، يمكنك اختيار قاعدة من `2` إلى `1000` (شاملة)؛ وتدعم القواعد الكسرية مثل `2.5`. مع القاعدة `10`، تكون القوى المتتالية مثل 10، 100، 1 000، و10 000 متساوية التباعد.

### **قارن بين التدرج الخطي واللوغاريتمي**

المثال المستقل التالي ينشئ مخطط خط مع خمس عدادات طلب في الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعل محور قيمة لوغاريتمي بقاعدة 10 في الشريحة الثانية. تحتفظ كلتا الشريحتين بنفس البيانات.

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

    # احتفظ بالشريحة الأولى خطية وغير مقياس محور القيمة فقط في النسخة.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**المقياس الخطي (الشريحة 1):** تمثل المسافات العمودية المتساوية اختلافات متساوية في عدد الطلبات. تهيمن القيمة الأكبر على المخطط، ما صعوبة تمييز القيم الأصغر.

![مخطط خط في PowerPoint يُظهر خمس عدادات طلب على محور قيمة خطي](value-axis-linear.png)

**المقياس اللوغاريتمي (الشريحة 2):** تمثل المسافات العمودية المتساوية نسبًا متساوية. كل فترة لديها عشرة أضعاف الطلبات مقارنة بالسابقة، لذا تشكل النقاط خطًا مستقيمًا صاعدًا على مقياس القاعدة 10. لا تزال تسميات المحور تُظهر عدد الطلبات الأصلي.

![نفس خمس عدادات الطلب في PowerPoint على محور قيمة لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسالبة**

يمكن للمقياس اللوغاريتمي عرض قيم موجبة فقط. تحقق من البيانات قبل تفعيله. إذا كانت القيم الصفرية أو السالبة ذات معنى، احتفظ بالمقياس الخطي أو اعرضها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسر الحذف. لا تستبدلها بصمت بأعداد موجبة صغيرة، لأن ذلك يغيّر معنى البيانات. يجب أن تكون أي قيم دنيا أو قصوى مُكوَّنة يدويًا لمحور لوغاريتمي أيضًا موجبة.

## **الأسئلة الشائعة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها أحد المحاور مع الآخر (تقاطع المحاور)؟**

استخدم [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) لاختيار سلوك التقاطع. لتحديد قيمة تقاطع رقمية، عيّن [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). تسمح هذه الإعدادات بنقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني تموضع تسميات العلامات بالنسبة للمحور؟**

عيّن [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`، `HIGH`، `NEXT_TO` أو `NONE`. للتحكم في علامات الفواصل نفسها، استخدم [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) أو [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); هذه منفصلة عن تموضع التسميات.