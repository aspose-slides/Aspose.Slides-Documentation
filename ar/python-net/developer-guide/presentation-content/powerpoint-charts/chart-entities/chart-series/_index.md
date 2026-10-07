---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام Python
linktitle: سلاسل البيانات
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
- العرض التقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السلبية في العروض التقديمية باستخدام Python."
---
## **نظرة عامة**

يقوم المخطط بتخزين البيانات المرسومة في دفتر بيانات المخطط. تمثل [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) مجموعة واحدة من القيم المرتبطة، وتشير كل [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) في السلسلة إلى خلية أو أكثر في دفتر العمل. توفر كائنات [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) الملصقات أو قيم التجميع المشتركة بين السلاسل. وبالتالي يتم ربط اسم السلسلة والفئات وقيم النقاط بـ [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) بدلاً من تخزينها كنص عرض فقط.

للمخطط الفئوي النموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، العمود 0 لأسماء الفئات، والخلايا المتبقية لقيم السلسلة. الفهارس للورقة والصف والعمود التي تُمرَّر إلى [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) تُحسب من الصفر. هذا التخطيط مفيد عندما تنشئ مخططًا ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. للعرض المحمل، افحص الخلايا التي تشير إليها السلاسل والفئات ونقاط البيانات قبل تغيير قيم دفتر العمل.

إعدادات المخطط لها ثلاث نطاقات مختلفة:

- إعدادات مستوى السلسلة، مثل [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)، توفر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). ادخل المجموعة عبر [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) عندما تحتاج إلى ضبط خيارات مثل التداخل أو عرض الفجوة.

عند عدم تحديد تعبئة صريحة للنقطة أو السلسلة، يحدّ نمط المخطط والموضوع المظهر التلقائي. عندما تكون كل من تنسيقات السلسلة والنقطة موجودة، تكون تنسيق النقطة هو السائد لتلك النقطة.

![سلسلة المخطط PowerPoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة المخطط**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) يُبلغ عن مقدار تداخل الأشرطة أو الأعمدة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمئة. هو إسقاط للقراءة فقط للإعداد على مجموعة السلسلة الأصل. اضبط [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) لتحديث كل السلاسل المتوافقة في تلك المجموعة. هذا الخيار ينطبق على أنواع المخططات التي تعرض أشرطة أو أعمدة مجمّعة؛ لا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

المثال التالي يحدد التداخل للمجموعة التي تحتوي على السلسلة الأولى:

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

الناتج:

![تداخل السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كان لدى نقطة تعبئة صريحة بالفعل، فإن إعداد [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) يتجاوز تعبئة السلسلة لتلك النقطة.

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

الناتج:

![لون السلسلة](series_color.png)

## **تغيير اسم السلسلة**

يُخزن اسم السلسلة في دفتر بيانات المخطط وعادةً ما يُظهر في المفتاح. في دفتر العمل الافتراضي المُنشأ لمخطط عمود مُجمع، تكون الخلية B1 في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. تجعل الثوابت المسماة في المثال التالي هذا الهيكل صريحًا:

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

يمكنك أيضًا تحديث الخلية التي يشير إليها بالفعل [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/). يوفّر هذا النهج تجنّب افتراض صف وعمود معينين في مخطط موجود:

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

الناتج:

![اسم السلسلة](series_name.png)

### **إنشاء سلسلة باسم من خلايا متعددة**

اسم السلسلة المركب مفيد عندما يُخزن اسم المنتج وفترة التقرير في خلايا دفتر عمل منفصلة. على سبيل المثال، يمكنك دمج `Product A` في B1 و `2026` في C1 في اسم سلسلة واحد مع الحفاظ على ربط الجزأين بخلايا المصدر.

استخدم [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) لاسترجاع نطاق الاسم، ثم مرّر هذا التجميع إلى [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). يتحكم معامل `skip_hidden_cells` ما إذا كانت الخلايا المخفية تُضمّن: `True` تُستثنيها، بينما `False` تُضمّنها. يستخدم هذا المثال `False` لتضمين كل الخلايا في نطاق الاسم.

المثال التالي ينشئ عرضًا تقديميًا بسلسلة واحدة ونقطتي بيانات. توفر الخلايا B1:C1 اسم السلسلة فقط؛ الخلايا A2:A3 توفر ملصقات الفئات، والخلايا B2:B3 توفر القيم الرقمية.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # هاتان الخليتان تزودان اسم السلسلة.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # خلايا منفصلة تزود الفئات ونقاط البيانات الرقمية.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

اسم السلسلة الناتج هو `Product A 2026` مع مساحة بين القيمتين الخلويتين. يُظهر المفتاح ذلك كإدخال واحد للعمودين. الصورة أدناه تم توليدها من العرض المحفوظ:

![مخطط عمود مع قيم الشمال والجنوب والاسم المركب للسلسلة Product A 2026 في الأسطورة](composite_series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) يرجّع اللون المحسوب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا تُحدَّد تعبئة السلسلة صراحة. استدعاء الطريقة يقرأ اللون المحسوب؛ لا يُعيّن تعبئة جديدة.

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

مخرجات مثال لنمط المخطط الافتراضي:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين لون تعبئة عكسي لسلسلة المخطط**

بالنسبة لسلاسل الأشرطة والأعمدة والفقاعات، يمكن لـ [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) عرض القيم السالبة بتعبئة مختلفة. اضبط تعبئة السلسلة العادية إلى صلبة، فعّل الانعكاس، وعيّن لون القيمة السالبة عبر [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). تبقى الأرقام السالبة دون تغيير في دفتر العمل؛ فقط يتغير لون عرضها.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. يحتوي الصف 0 من الورقة على اسم السلسلة، العمود 0 على أسماء الفئات، والعمود 1 على القيم:

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

الناتج:

![لون التعبئة الصلبة العكسي](inverted_solid_fill_color.png)

يمكنك تمكين الانعكاس لنقطة واحدة عبر [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). في المثال التالي، يُعطَّل الانعكاس للسلسلة ويُفعَّل فقط للنقطة المختارة. تُعطى النقطة قيمة سالبة لتظهر التأثير:

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

لجعل نقطة واحدة فارغة دون إزالة النقاط الأخرى، اضبط خلية دفتر العمل الداعمة لها إلى `None`. بالنسبة لمخطط عمودي، تكون القيمة المرسومة متاحة عبر [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). تبقى نقطة البيانات في نفس موضع الفئة، لكن المخطط يتعامل مع قيمتها كخالية وفقًا لإعدادات القيم الخالية للمخطط.

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

تستخدم مخططات التناثر خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية حجم. امسح فقط الخلية التي تمثل القيمة التي ترغب في إزالتها. لا تستدعِ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) عندما تريد الحفاظ على النقاط الأخرى، لأن هذه الطريقة تُزيل كل نقطة بيانات من التجميع.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم تُعدّ حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من الصفوف والأعمدة المخفية في الورقة، راجع [Include Data from Hidden Rows and Columns](/slides/ar/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

تمثل الخلية الفارغة في دفتر العمل بيانات مفقودة؛ الخلية التي تحتوي على `0` تمثل قيمة عددية معروفة. اضبط [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) إلى `None` لجعل الخلية فارغة. الصفر العددي يبقى صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) لاختيار كيفية عرض المخطط للخلايا الفارغة. هذا الإعداد ينطبق على المخطط بأكمله. يغيّر طريقة رسم الفراغات دون ملء الخلية الفارغة بالصفر أو قيمة مُق interpolated.

المثال المستقل التالي ينشئ مخطط خط بسلسلة واحدة، يمسح القيمة لليوم 3، ويحفظ المخطط نفسه بكل وضع. لا يلزم ملف إدخال. يستخدم [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) الورقة 0، العمود 0 لملصقات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

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

    # اترك اليوم 3 فارغًا فعليًا مع الاحتفاظ بفئته ونقطة البيانات.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

كل ملف إخراج يخزن الوضع المحدد قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و `empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، حدّد الوضع المطلوب واحفظ العرض مرة واحدة بدلاً من التكرار على الوضعيات.

المقارنة أدناه تُظهر نفس البيانات في الملفات الثلاثة. اليوم 3 فارغ في دفتر العمل في كل حالة:

![مخططات الخط مع بيانات متطابقة: الفجوة تقطع الخط عند اليوم 3، الصفر يخفّض الخط إلى الصفر، والاتصال يربط اليوم 2 إلى اليوم 4.](display_blanks_as.png)

التأثير المرئي يعتمد على نوع المخطط. يجعل مخطط الخط جميع الوضعيات الثلاثة سهلة المقارنة. لا تمتلك مخططات الأعمدة والبار خطوطًا للربط عبر فئة مفقودة، لذا لا يمكن لـ `SPAN` إنتاج الجزء المتصل الموضح أعلاه؛ قد يبدو العمود المفقود والعمود صفر الارتفاع متشابهين. بالمثل، لا يمتلك مخطط التناثر مع علامات فقط خطًا ربطيًا. لا تتوقع ثلاث نتائج متميزة لكل نوع مخطط؛ تحقق من النتيجة للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، يُعبر عنها كنسبة مئوية من عرض الشريط أو العمود. مثل التداخل، فهو ينتمي إلى مجموعة السلسلة الأصل بدلاً من سلسلة واحدة. اضبط [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) مرة واحدة للمجموعة. قيمة أكبر تُنشئ مساحة أكبر بين المجموعات؛ قيمة أصغر تجعلها أكثر كثافة.

المثال التالي يغيّر عرض الفجوة ويحفظ العرض النهائي فقط:

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

الناتج:

![عرض الفجوة](gap_width.png)

## **الأسئلة المتكررة**

**أي أنواع المخططات تدعم سلاسل البيانات؟**

جميع أنواع المخططات التي تمثّلها تعداد [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تتشارك نفس بنية القيم أو الإعدادات. على سبيل المثال، تستخدم المخططات الفئوية الفئات والقيم، وتستخدم مخططات التناثر قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تنطبق خيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هي مجموعة سلسلة المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) يحتوي على سلاسل متوافقة تشترك في إعدادات الرسم على مستوى المجموعة. يمكن أن يحتوي مخطط مركب على أكثر من مجموعة، لذا تعديل المجموعة عبر سلسلة واحدة لا يعني بالضرورة تعديل كل السلاسل في المخطط.

**هل يحتوي المخطط المُنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، يُنشئ [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) سلاسل وعناصر فئة وقيم عينة. يمكنك تعديل تلك الخلايا أو مسح كل من تجميعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. يمكن أيضًا تراكب لإنشاء مخطط بدون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

تُشير أسماء السلاسل، وملصقات الفئات، وقيم نقاط البيانات إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). تعديل خلية مُشار إليها يُحدّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، حافظ على توافق صفوف الفئات وصفوف قيم السلسلة بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلاً من مسح السلسلة بالكامل؟**

اضبط خلية القيمة ذات الصلة إلى `None` للحفاظ على موضع الفئة للنقطة كقيمة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) فقط عندما ترغب في إزالة كل النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تظل قيمها متطابقة مع تجميع الفئات.

**كيف يتم عرض النقاط الفارغة؟**

النتيجة تعتمد على نوع المخطط و[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). يمكن للمخططات المدعومة عرض الفراغات كفجوات، أو كقيم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يتناسب مع معنى البيانات المفقودة في عرضك. راجع [التحكم في عرض الخلايا الفارغة](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة بصرية.

**كيف تُشكل القيم السالبة؟**

بالنسبة للسلاسل المدعومة من الأشرطة والأعمدة والفقاعات، فعّل [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) واضبط [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). يمكنك تجاوز السلوك لنقطة فردية عبر [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). هذه الخصائص تؤثر على التنسيق فقط، لا على القيم العددية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

يتفوّق تنسيق نقطة البيانات الصريح لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، عندما لا يُحدَّد تنسيق السلسلة، النمط والموضوع الافتراضي للمخطط. تتحكم خصائص المجموعة مثل التداخل وعرض الفجوة في التخطيط ولا تُعتبر تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، يحدّ قيود ملف العرض، الذاكرة المتاحة، زمن التنفيذ، وقابلية قراءة المخطط من عدد السلاسل المفيد.

**ماذا يجب أن أغير عندما تكون الأعمدة متقاربة جدًا أو متباعدة جدًا؟**

اضبط [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) على مجموعة السلاسل الأصلية المناسبة. زِد القيمة لتوسيع الفجوة بين المجموعات، أو قلّها لتقريب المجموعات من بعضها البعض.