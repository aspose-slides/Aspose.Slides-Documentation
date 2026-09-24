---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام بايثون
linktitle: سلسلة البيانات
type: docs
url: /ar/python-net/chart-series/
keywords:
- سلسلة المخطط
- تداخل السلسلة
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة البيانات
- فجوة السلسلة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السالبة في العروض التقديمية باستخدام بايثون."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في دفتر بيانات المخطط. تمثل [ChartSeries](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/) مجموعة واحدة من القيم المرتبطة، وكل [ChartDataPoint](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/) في السلسلة يشير إلى خلية أو أكثر في دفتر العمل. تُوفر كائنات [ChartCategory](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. وبالتالي يتم ربط اسم السلسلة والفئات وقيم النقاط بـ [ChartDataCell](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatacell/) بدلاً من تخزينها كنص عرض فقط.

بالنسبة إلى مخطط فئات نموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، وتُملأ الخلايا المتبقية بقيم السلاسل. المؤشرات الخاصة بورقة العمل والصف والعمود التي تُمرَّر إلى [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) هي صفرية. يُفيد هذا التخطيط عندما تُنشئ مخططًا ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. للمُستَند المُحمَّل، تحقق من الخلايا التي تُشير إليها السلاسل والفئات ونقاط البيانات قبل تعديل قيم دفتر العمل.

إعدادات المخطط لها ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/format/)، توفّر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقاط البيانات، مثل [ChartDataPoint.format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/format/)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/). يمكنك الوصول إلى المجموعة عبر [ChartSeries.parent_series_group](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/parent_series_group/) عندما تحتاج إلى تعيين خيارات مثل التداخل أو عرض الفجوة.

عند عدم تعيين تعبئة صريحة للنقطة أو السلسلة، يحدد نمط المخطط والموضوع المظهر التلقائي. عندما تكون هناك تنسيقات لسلسلة ونقطة معاً، تكون تنسيق النقطة هو السائد لتلك النقطة.

![سلسلة المخطط في PowerPoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة المخطط**

[ChartSeries.overlap](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/overlap/) يوضح مدى تداخل الأعمدة أو الأشرطة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمئة. هو إسقاط للقراءة فقط للإعداد على مجموعة السلاسل الأصلية. اضبط [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/overlap/) لتحديث كل السلاسل المتوافقة في تلك المجموعة. ينطبق هذا الخيار على أنواع المخططات التي تعرض أشرطة أو أعمدة مجمّعة؛ ولا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركّب.

المثال التالي يضبط التداخل للمجموعة التي تحتوي على السلسلة الأولى:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # المخطط الجديد يحتوي على سلاسل وعينات وفئات وقيم.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![تداخل السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [ChartSeries.format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/format/) لتعيين تعبئة افتراضية لسلسلة كاملة. إذا كانت النقطة لديها تعبئة صريحة بالفعل، فإن إعداد [ChartDataPoint.format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/format/) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبق تعبئة صلبة زرقاء على السلسلة الأولى:

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

يُخزّن اسم السلسلة في دفتر بيانات المخطط ويُظهر عادةً في وسيلة الإيضاح. في دفتر العمل الافتراضي المُنشأ لمخطط عمود مُجمّع، الخلية B1 هي الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسماة في المثال التالي تجعل هذا الهيكل واضحاً:

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

يمكنك أيضاً تعديل الخلية التي يشير إليها [ChartSeries.name](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/name/) بالفعل. يَتجنّب هذا النهج الافتراض بوجود صف أو عمود معين في مخطط موجود:

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

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) يُعيد اللون المحسوب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا يتم تعريف تعبئة السلسلة صراحة. استدعاء الطريقة يقرأ اللون المحسوب؛ لا يعيّن تعبئة جديدة.

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

مثال على الإخراج لنمط المخطط الافتراضي:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين لون تعبئة عكسي لسلسلة المخطط**

بالنسبة لسلاسل الأشرطة، الأعمدة، والفقاعات، يمكن لـ [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/invert_if_negative/) عرض القيم السالبة بتعبئة مختلفة. اضبط تعبئة السلسلة العادية إلى صلبة، وفعل العكس، وعين لون القيمة السالبة عبر [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). تُبقى الأرقام السالبة دون تغيير في دفتر العمل؛ يتغيّر لون عرضها فقط.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 يحتوي على اسم السلسلة، العمود 0 يحتوي على أسماء الفئات، والعمود 1 يحتوي على القيم:

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

![لون التعبئة الصلب العكسي](inverted_solid_fill_color.png)

يمكنك تفعيل العكس لنقطة واحدة عبر [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). في المثال التالي، يُعطَّل العكس للسلسلة ويُفعَّل فقط للنقطة المحددة. تُعطي النقطة أيضاً قيمة سالبة لتظهر التأثير:

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

لجعل نقطة واحدة فارغة دون إزالة باقي النقاط، اضبط خلية دفتر العمل الداعمة لها إلى `None`. بالنسبة إلى مخطط عمودي، القيمة المرسومة متاحة عبر [ChartDataPoint.value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/value/). تبقى نقطة البيانات في نفس موقع الفئة، لكن المخطط يتعامل مع قيمتها كفراغ وفقاً لإعدادات الفراغ في المخطط.

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

تستخدم المخططات النقطية خلايا X وY منفصلة، وتستخدم المخططات الفقاعية أيضاً خلية حجم. امسح فقط الخلية التي تمثل القيمة التي ترغب في إزالتها. لا تستخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapointcollection/clear/) عندما تريد الإبقاء على بقية النقاط، لأن هذه الطريقة تزيل كل نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

تمثل الخلية الفارغة في دفتر العمل بيانات مفقودة؛ الخلية التي تحتوي على `0` تمثل قيمة عددية معروفة. اضبط [ChartDataCell.value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatacell/value/) إلى `None` لجعل الخلية فارغة. الصفر الرقمي يبقى صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [Chart.display_blanks_as](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/display_blanks_as/) لاختيار طريقة عرض المخطط للخلايا الفارغة. ينطبق هذا الإعداد على المخطط كاملًا. يغيّر طريقة رسم الفراغات دون ملء الخلية الفارغة بصفر أو قيمة مُقَربة.

المثال التالي المستقل ينشئ مخطط خط يحتوي على سلسلة واحدة، يمسح القيمة لليوم 3، ويحفظ المخطط نفسه بكل وضعية. لا تحتاج إلى ملف إدخال. يستخدم [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/) ورقة العمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحوي اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

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

    # اترك اليوم 3 فارغًا حقًا، مع الحفاظ على فئته ونقطة البيانات.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

كل ملف إخراج يُخزّن الوضع المحدد قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و `empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ المُستَند مرة واحدة بدلاً من التكرار عبر جميع الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في الملفات الثلاثة. اليوم 3 فارغ في دفتر العمل في كل الحالات:

![مخططات الخط مع بيانات متطابقة: “Gap” يقطع الخط عند اليوم 3، “Zero” يخفض الخط إلى الصفر، و“Span” يربط اليوم 2 باليوم 4.](display_blanks_as.png)

التأثير المرئي يعتمد على نوع المخطط. يجعل مخطط الخط جميع الأوضاع الثلاثة سهلة المقارنة. المخططات الشريطية والعمودية لا تملك خطًا لتوصيل الفجوة، لذا لا يمكن لـ `SPAN` إنتاج الجزء المتصل الموضح أعلاه؛ يمكن أن يبدو العمود المفقود وعمود الصفر بنفس الشكل. بالمثل، لا يحتوي مخطط التبعثر مع علامات فقط على خط توصيل. لا تتوقع ثلاث نتائج متميزة لكل نوع مخطط؛ تحقق من الإخراج للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلسلة**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتقاربة، معبرًا عنها بنسبة من عرض الشريط أو العمود. مثل التداخل، تنتمي إلى مجموعة السلسلة الأصلية وليس إلى سلسلة واحدة. اضبط [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) مرة واحدة للمجموعة. القيمة الأكبر تُنشئ مساحة أكبر بين المجموعات؛ والقيمة الأصغر تجعلها أكثر كثافة.

المثال التالي يغيّر عرض الفجوة ويحفظ العرض النهائي فقط للمستَند:

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

**أي أنواع المخططات تدعم سلاسل البيانات؟**

جميع أنواع المخططات التي يمثلها تعداد [ChartType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك كلها في نفس بنية القيم أو الإعدادات. على سبيل المثال، تستخدم مخططات الفئات الفئات والقيم، وتستخدم مخططات التبعثر قيم X وY، وتضيف المخططات الفقاعية أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. الخيارات مثل التداخل وعرض الفجوة تنطبق فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هي مجموعة سلاسل المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/) تحتوي على سلاسل متوافقة تشترك في إعدادات رسم على مستوى المجموعة. يمكن أن يحتوي مخطط مركب على أكثر من مجموعة، لذا قد لا يغيّر تعديل المجموعة التي يتم الوصول إليها عبر سلسلة واحدة كل السلاسل في المخطط.

**هل يحتوي المخطط الذي تم إنشاؤه حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، [ShapeCollection.add_chart](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_chart/) ينشئ سلاسل وعناصر فئة وقيم نموذجية. يمكنك تحرير تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة تمامًا. يمكن أيضًا استدعاء طريقة ذات وسائط بديلة لإنشاء مخطط دون بيانات افتراضية.

**كيف تُربط كائنات المخطط بخلايا دفتر العمل؟**

تشير أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/). تعديل خلية مُشار إليها يُحدِّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على أن تكون صفوف الفئات وصفوف قيم السلاسل متراوحة بحيث تُرسَم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلاً من سلاسل بأكملها؟**

اضبط خلية القيمة ذات الصلة إلى `None` لتبقى النقطة في موضع الفئة كقيمة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapointcollection/clear/) فقط عندما تريد إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل لضمان بقاء قيمها متطابقة مع مجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

النتيجة تعتمد على نوع المخطط و [Chart.display_blanks_as](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/display_blanks_as/). تدعم المخططات المتاحة عرض الفراغات كفجوات أو كقيم صفرية أو بربط النقاط المجاورة. اختر الإعداد الذي يتماشى مع معنى البيانات المفقودة في عرضك. راجع [Control the Display of Empty Cells](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة بصرية.

**كيف تُنسق القيم السالبة؟**

بالنسبة لسلاسل الأشرطة، الأعمدة، والفقاعات المدعومة، فعل [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/invert_if_negative/) وعين [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). يمكنك تجاوز السلوك لنقطة فردية باستخدام [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). هذه الخصائص تؤثر على التنسيق فقط، لا على القيم العددية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

يتفوّق تنسيق النقطة الصريح لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، عندما لا يُعرَّف تنسيق السلسلة، نمط المخطط والموضوع التلقائي. تتحكم خصائص المجموعة مثل التداخل وعرض الفجوة في التخطيط ولا تُعدّ تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن للمخطط احتواؤها؟**

لا يفرض Aspose.Slides حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تحدد قيود ملف العرض، الذاكرة المتاحة، زمن التقديم، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا يجب تعديل عندما تكون الأعمدة قريبة جدًا من بعضها أو متباعدة جدًا؟**

اضبط [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) على مجموعة السلاسل الأصلية المناسبة. زد القيمة لتوسيع الفجوة بين المجموعات، أو قلّلها لتقريب المجموعات من بعضها.