---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام Python
linktitle: سلسلة البيانات
type: docs
url: /ar/python-net/chart-series/
keywords:
- سلسلة مخطط
- تداخل السلسلة
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة بيانات
- فجوة السلسلة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيقات، التداخل، عرض الفجوة، والقيم السالبة في العروض التقديمية باستخدام Python."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في دفتر عمل بيانات المخطط. تمثل [ChartSeries](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/) مجموعة واحدة من القيم المرتبطة، وكل [ChartDataPoint](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/) في السلسلة يشير إلى خلية أو أكثر في دفتر العمل. توفر كائنات [ChartCategory](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. وبالتالي يتم ربط اسم السلسلة، الفئات، وقيم النقاط بكائنات [ChartDataCell](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatacell/) بدلاً من تخزينها كنص عرض فقط.

في مخطط الفئة النموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، العمود 0 لأسماء الفئات، وتُستخدم الخلايا المتبقية لقيم السلاسل. الفهارس للورقة، الصف، والعمود التي تُمرَّر إلى [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) هي صفرية الأساس. هذا التخطيط مفيد عندما تنشئ مخططاً ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة للعرض التقديمي المحمّل، افحص الخلايا التي تشير إليها السلاسل، الفئات، ونقاط البيانات قبل تعديل قيم دفتر العمل.

إعدادات المخطط لها ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/format/)، تُوفر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات النقطة، مثل [ChartDataPoint.format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/format/)، تتخطى مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تُطبق على السلاسل المتوافقة التي تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/). احصل على المجموعة عبر [ChartSeries.parent_series_group](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/parent_series_group/) عندما تحتاج إلى ضبط خيارات مثل التداخل أو عرض الفجوة.

عندما لا يتم تعيين تعبئة صريحة للنقطة أو السلسلة، تحدد نمط المخطط والموضوع المظهر التلقائي. عندما تكون كل من تنسيقات السلسلة والنقطة موجودة، تكون تنسيق النقطة هو المتفوق لتلك النقطة.

![سلسلة المخطط في PowerPoint](chart-series-powerpoint.png)

## **ضبط تداخل سلسلة المخطط**

[ChartSeries.overlap](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/overlap/) يُظهر مقدار تداخل الأعمدة أو الأعمدة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمائة. إنه إسقاط قراءة‑فقط للإعداد في مجموعة السلاسل الأصلية. اضبط [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/overlap/) لتحديث كل السلاسل المتوافقة في تلك المجموعة. يُطبق هذا الخيار على أنواع المخططات التي تعرض أعمدة أو أشرطة مجموعة؛ ولا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

المثال التالي يحدد التداخل للمجموعة التي تحتوي على السلسلة الأولى:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # المخطط الجديد يحتوي على سلاسل عينة، فئات، وقيم.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تداخل السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [ChartSeries.format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/format/) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كانت النقطة لديها تعبئة صريحة، فإن إعداد [ChartDataPoint.format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/format/) يتخطى تعبئة السلسلة لتلك النقطة.

المثال التالي يطبق تعبئة زرقاء صلبة على السلسلة الأولى:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![لون السلسلة](series_color.png)

## **تغيير اسم السلسلة**

يُخزن اسم السلسلة في دفتر عمل بيانات المخطط ويُعرض عادةً في وسيلة الإيضاح. في دفتر العمل الافتراضي المُنشأ لمخطط أعمدة مزدوجة، الخلية B1 هي الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. تُوضح الثوابت المسماة في المثال التالي هذا الهيكل:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

يمكنك أيضاً تحديث الخلية التي يشير إليها بالفعل [ChartSeries.name](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/name/). يضمن هذا النهج عدم الافتراض بصف أو عمود معين في مخطط موجود:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![اسم السلسلة](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) يُعيد اللون المُحسب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا يتم تعريف تعبئة السلسلة صراحة. استدعاء الطريقة يقرأ اللون المُحسب؛ لا يُنشئ تعبئة جديدة.

المثال التالي يطبع اللون التلقائي لكل سلسلة افتراضية:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

مخرجات المثال للنمط الافتراضي للمخطط:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين لون تعبئة مقلوب لسلسلة المخطط**

لسلاسل الشريط، العمود، والفقاعة، يمكن أن تُظهر [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/invert_if_negative/) القيم السالبة بتعبئة مختلفة. اضبط تعبئة السلسلة العادية لتكون صلبة، فعّل الانعكاس، وعيّن لون القيمة السالبة عبر [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). تبقى الأرقام السالبة دون تغيير في دفتر العمل؛ يتغير لون العرض فقط.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 في الورقة يحتوي على اسم السلسلة، العمود 0 يحتوي على أسماء الفئات، والعمود 1 يحتوي على القيم:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![لون التعبئة الصلب المقلوب](inverted_solid_fill_color.png)

يمكنك تمكين الانعكاس لنقطة واحدة عبر [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). في المثال التالي، يُعطل الانعكاس للسلسلة ويُفعل فقط للنقطة المحددة. تُعيّن النقطة أيضاً قيمة سالبة لتكون النتيجة مرئية:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **مسح قيمة نقطة بيانات محددة**

لجعل نقطة واحدة فارغة دون إزالة باقي النقاط، اضبط خلية دفتر العمل الداعمة لها إلى `None`. في مخطط العمود، القيمة المرسومة متوفرة عبر [ChartDataPoint.value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/value/). تبقى نقطة البيانات في نفس موقع الفئة، لكن المخطط يتعامل مع قيمتها كفراغ وفقاً لإعدادات القيم الفارغة في المخطط.

المثال التالي يمسح فقط النقطة الثانية في السلسلة الأولى:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

تستخدم مخططات التشتت خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضاً خلية حجم. امسح فقط الخلية التي تمثل القيمة التي تريد إزالتها. لا تستدعِ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapointcollection/clear/) عندما تريد الاحتفاظ بالنقاط الأخرى، لأن هذه الطريقة تُزيل كل نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم هي حالة مختلفة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من الصفوف والأعمدة المخفية في الورقة، راجع [Include Data from Hidden Rows and Columns](/slides/ar/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

تمثل الخلية الفارغة في دفتر العمل بيانات مفقودة؛ الخلية التي تحتوي على `0` تمثل قيمة عددية معروفة. اضبط [ChartDataCell.value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatacell/value/) إلى `None` لجعل الخلية فارغة. الصفر العددي يظل صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [Chart.display_blanks_as](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/display_blanks_as/) لاختيار كيفية عرض المخطط للخلايا الفارغة. ينطبق هذا الإعداد على المخطط كله. يغيّر طريقة رسم الفراغات دون ملء الخلية الفارغة بصفر أو قيمة مُقربة.

المثال المستقل التالي ينشئ مخططًا خطيًا بسلسلة واحدة، يمسح القيمة لليوم 3، ويحفظ المخطط نفسه بكل وضع. لا يلزم ملف إدخال. يستخدم [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/) الورقة 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # اترك اليوم 3 فارغًا فعليًا، مع الاحتفاظ بفئته ونقطة البيانات الخاصة به.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

كل ملف إخراج يخزن الوضع المعيّن قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و `empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض التقديمي مرة واحدة بدلًا من التكرار على كل وضع.

المقارنة أدناه تُظهر نفس البيانات في جميع الملفات الثلاثة. اليوم 3 فارغ في دفتر العمل في كل حالة:

![مخططات خطية ببيانات متطابقة: الفجوة تقطع الخط عند اليوم 3، الصفر يُخفض الخط إلى الصفر، والامتداد (SPAN) يربط اليوم 2 باليوم 4.](display_blanks_as.png)

يعتمد التأثير الظاهر على نوع المخطط. يجعل مخطط الخط جميع الأوضاع الثلاثة سهلة المقارنة. لا تمتلك مخططات الشريط والعمود خطًا لربط الفئات المفقودة، لذا لا يستطيع `SPAN` إنشاء الجزء المتصل كما في الأعلى؛ قد يبدوا العمود المفقود وعمود الصفر بنفس الشكل. بالمثل، مخطط التشتت مع العلامات فقط لا يملك خطًا موصولًا. لا تتوقع ثلاث نتائج مميزة لكل نوع مخطط؛ تحقق من الإخراج للنوع الذي تستخدمه.

## **ضبط عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأعمدة أو الأشرطة المتقاربة، يُعبر عنها كنسبة مئوية من عرض العمود أو الشريط. مثل التداخل، ينتمي إلى مجموعة السلاسل الأصلية وليس إلى سلسلة واحدة. اضبط [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) مرة واحدة للمجموعة. القيمة الأكبر تُنشئ مساحة أكبر بين المجموعات؛ القيمة الأصغر تجعلها أكثر تكتًّ.

المثال التالي يغيّر عرض الفجوة ويحفظ العرض التقديمي النهائي فقط:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![عرض الفجوة](gap_width.png)

## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات الممثلة في تعداد [ChartType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/charttype/) تستخدم بيانات المخطط، لكن السلاسل الخاصة بها لا تشترك جميعًا في هيكل القيم أو الإعدادات نفسها. على سبيل المثال، تستخدم مخططات الفئات الفئات والقيم، ومخططات التشتت قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تنطبق خيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأعمدة أو الأشرطة المتوافقة.

**ما هو مجموعة سلاسل المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/) يحتوي على سلاسل متوافقة تشترك في إعدادات رسم على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا تغيير المجموعة التي تُصل عبر سلسلة واحدة لا يغيّر بالضرورة كل السلاسل في المخطط.

**هل يحتوي المخطط المُنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، تُنشئ [ShapeCollection.add_chart](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_chart/) سلاسل، فئات، وقيم تجريبية. يمكنك تحرير تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. يمكن للتحميل الزائد أيضًا إنشاء مخطط بدون بيانات افتراضية.

**كيف ترتبط كائنات المخطط بخلايا دفتر العمل؟**

أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات تشير إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/). تعديل خلية مشار إليها يُحدِّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف يمكن مسح نقطة واحدة بدلاً من السلسلة بأكملها؟**

عيّن خلية القيمة ذات الصلة إلى `None` للاحتفاظ بموقع الفئة للنقطة كقيمة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapointcollection/clear/) فقط عندما ترغب في إزالة جميع النقاط من تلك السلسلة. إذا قمت أيضًا بإزالة الفئات، حدّث كل السلاسل بحيث تبقى قيمها متوافقة مع مجموعة الفئات.

**كيف يتم عرض النقاط الفارغة؟**

يعتمد النتيجة على نوع المخطط و[Chart.display_blanks_as](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/display_blanks_as/). يمكن للمخططات المدعومة عرض الفراغات كفجوات، كقيم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يتوافق مع معنى البيانات المفقودة في عرضك. راجع [التحكم في عرض الخلايا الفارغة](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة مرئية.

**كيف يتم تنسيق القيم السالبة؟**

للسلاسل المدعومة من نوع شريط، عمود، أو فقاعة، فعّل [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/invert_if_negative/) وعيّن [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). يمكنك تجاوز السلوك لنقطة فردية عبر [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). تؤثر هذه الخصائص في التنسيق فقط، وليس القيم العددية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

تنسيق النقطة الصريح يتفوق على تلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، عندما لا يُعرَّف تنسيق السلسلة، النمط والموضوع التلقائي للمخطط. تتحكم خصائص المجموعة مثل التداخل وعرض الفجوة في التخطيط ولا تُعدّ تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

Aspose.Slides لا يفرض حداً ثابتاً منفصلاً لعدد السلاسل. في الواقع، تقيّد قيود ملف العرض التقديمي، الذاكرة المتاحة، وقت التقديم، وقابلية قراءة المخطط تحدد الحد المفيد.

**ماذا أفعل عندما تكون الأعمدة متقاربة جدًا أو متباعدة جدًا؟**

اضبط [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) على مجموعة السلاسل الأصلية المناسبة. زد القيمة لتوسيع الفجوة بين المجموعات، أو قللها لجعل المجموعات أقرب إلى بعضها.