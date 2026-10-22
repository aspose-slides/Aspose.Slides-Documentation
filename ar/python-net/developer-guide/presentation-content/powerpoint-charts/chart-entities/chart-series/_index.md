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
description: "تعلم كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا مصنف العمل، التنسيق، التداخل، عرض الفجوة، والقيم السالبة في العروض التقديمية باستخدام بايثون."
---
## **نظرة عامة**

يمكن للمخطط تخزين القيم المرسومة إما في خلايا مصنف العمل أو مباشرةً كقِيَم عددية ثابتة. تمثل [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) مجموعة واحدة من القيم المرتبطة، ويمثل كل [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) نقطة في تلك السلسلة. توفر كائنات [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) التسميات أو قيم التجميع المشتركة بين السلسلات. في المخططات التي تُنشأ ببيانات افتراضية، تُستخدم أسماء السلسلة والفئات وقيم النقاط كائنات [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) من مصنف العمل الخاص بالمخطط.

في مخطط الفئة النموذجي، يستخدم المصنف الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، والخلايا المتبقية لقيم السلاسل. الفهارس الخاصة بالورقة، والصف، والعمود التي تُمرَّر إلى [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) هي فهارس تبدأ من الصفر. هذا التخطيط مفيد عندما تُنشئ مخططًا ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة لعرض تقديمي محمَّل، افحص الخلايا التي تشير إليها السلاسل والفئات ونقاط البيانات قبل تعديل قيم المصنف.

إعدادات المخطط لها ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)، توفر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات النقطة، مثل [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تُطبَّق على السلاسل المتوافقة التي تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). يمكن الوصول إلى المجموعة عبر [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) عندما تحتاج إلى ضبط خيارات مثل التداخل أو عرض الفجوة.

عند عدم تعيين تعبئة صريحة للنقطة أو للسلسلة، يحدد نمط المخطط والموضوع المظهر التلقائي. عندما تكون كل من تنسيقات السلسلة والنقطة موجودة، تكون تنسيق النقطة هو السائد لتلك النقطة.

![مخطط السلسلة PowerPoint](chart-series-powerpoint.png)

## **تعيين قيم السلسلة باستخدام القيم العددية الثابتة**

استخدم القيم العددية الثابتة عندما تكون قيم السلسلة مأخوذة من بيانات التطبيق أو من حسابات ولا تحتاج إلى مراجع خلايا ورقة العمل. قم بتعيين [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) إلى [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) قبل تعيين [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) لكل نقطة عبر [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/).

تتحكم إعدادات المجموعة في نوع مصدر جميع قيم النقاط في تلك السلسلة. تقرّ [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) لكل نقطة النوع المختار؛ غيِّره عبر إعداد المجموعة. مع `WORKSHEET`، استخدم [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) للوصول إلى الخلية المرجعية. مع `DOUBLE_LITERALS`، استخدم `as_literal_double` لقراءة أو كتابة الرقم مباشرة.

المثال التالي ينشئ مخطط أعمدة بسلاسل وفئات افتراضية، ثم يعيّن القيم المحسوبة 10 و20 وهكذا إلى النقاط الموجودة في سطرها الأول. يحفظ العرض التقديمي، ثم يعيد فتحه، ويطبع القيم المخزنة.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

نوع مصدر قيمة النقطة منفصل عن [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)، والذي يحدد ما إذا كان المصنف الداخلي أو الخارجي للمخطط. استخدام القيم العددية الثابتة لا يزيل المصنف المضمّن بحد ذاته. في هذا المثال، يظل المصنف متاحًا لتسميات الفئات، وأسماء السلاسل، والسلاسل الأخرى. راجع [Chart Workbook](/slides/ar/python-net/chart-workbook/) لإدارة المصنف.

بالنسبة لمخططات التشتت والفقاعات، قم بتعيين [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) و[data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) لاختيار المصادر لـ[x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) و[y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/). تستخدم مخططات الفقاعات أيضًا [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) لـ[bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/). عيّن كل مصدر مناسب إلى `DOUBLE_LITERALS` قبل تعيين الأعداد عبر خاصية `as_literal_double` لتلك القيمة.

## **تعيين تداخل سلاسل المخطط**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) يحدِّد مقدار تداخل الأشرطة أو الأعمدة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمائة. وهو تمثيل للقراءة فقط للإعداد في مجموعة السلسلة الأصلية. عيّن [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) لتحديث كل السلاسل المتوافقة في تلك المجموعة. يُطبق هذا الخيار على أنواع المخططات التي تعرض أشرطة أو أعمدة مجموعة؛ ولا يؤثّر على مجموعات السلاسل غير المرتبطة في مخطط مركّب.

المثال التالي يعيّن التداخل للمجموعة التي تحتوي على السلسلة الأولى:

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

![تداخل السلاسل](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كان للنقطة تعبئة صريحة، فإن إعداد [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) يتجاوز تعبئة السلسلة لتلك النقطة.

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

يُخزَّن اسم السلسلة في مصنف بيانات المخطط ويظهر عادةً في المفتاح. في المصنف الافتراضي لإنشاء مخطط أعمدة مجمَّعة، تكون الخلية B1 في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسماة في المثال التالي تجعل هذا الهيكل واضحًا:

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

يمكنك أيضًا تحديث الخلية التي يُشير إليها [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/). يَتجنَّب هذا الأسلوب الافتراض بوجود صف أو عمود معين في مخطط موجود:

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

### **إنشاء سلسلة باسم من خلايا متعددة**

اسم سلسلة مركّب مفيد عندما يُخزَّن اسم المنتج وفترة التقرير في خلايا مصنف منفصلة. على سبيل المثال، يمكنك دمج `Product A` في B1 و`2026` في C1 لتكوين اسم سلسلة واحد مع إبقاء الجزأين مرتبطين بخلايا المصدر.

استخدم [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) لاسترداد نطاق الاسم، ثم مرّر ذلك التجميع إلى [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). يتحكم المتغيّر `skip_hidden_cells` فيما إذا كانت الخلايا المخفية تُضمَّن: `True` تستثنيها، و`False` تُضمّها. يستخدم هذا المثال `False` لتضمين كل الخلايا في نطاق الاسم.

المثال التالي ينشئ عرضًا تقديميًا بسلسلة واحدة ونقطتي بيانات. تُزَوِّد الخلايا B1:C1 باسم السلسلة فقط؛ A2:A3 تزود بتسميات الفئات، وB2:B3 تزود القيم العددية.

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

    # خلايا منفصلة تزود الفئات ونقاط البيانات العددية.
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

اسم السلسلة الناتج هو `Product A 2026` مع مسافة بين القيمتين من الخلية. يعرض المفتاح هذا كقيد واحد لكل العمودين. الصورة أدناه مأخوذة من العرض التقديمي المحفوظ:

![مخطط أعمدة بقيم الشمال والجنوب واسم السلسلة المركب Product A 2026 في المفتاح](composite_series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) يُرجِع اللون المُحتسب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا تُحدَّد تعبئة السلسلة صراحةً. استدعاء الطريقة يقرأ اللون المُحتسب؛ ولا يعيّن تعبئة جديدة.

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

ناتج المثال للنمط الافتراضي للمخطط:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين لون تعبئة عكسي لسلسلة المخطط**

بالنسبة لسلاسل الأشرطة، الأعمدة، والفقاعات، يمكن لـ[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) عرض القيم السالبة بلون تعبئة مختلف. عيّن التعبئة العادية للسلسلة إلى صلبة، فعل الانعكاس، وعيّن لون القيم السالبة عبر [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). تظل الأعداد السالبة دون تغيير في المصنف؛ يتغير لون عرضها فقط.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. يحتوي الصف 0 على اسم السلسلة، العمود 0 على أسماء الفئات، والعمود 1 على القيم:

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

![لون التعبئة العكسي الصلب](inverted_solid_fill_color.png)

يمكنك تمكين الانعكاس لنقطة واحدة عبر [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). في المثال التالي، يُعطَّل الانعكاس للسلسلة ويُفعَّل فقط للنقطة المختارة. تُعيَّن للنقطة أيضًا قيمة سالبة لتظهر التأثير:

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

لجعل نقطة واحدة فارغة دون إزالة باقي النقاط، عيّن خلية المصنف الداعمة لها إلى `None`. بالنسبة لمخطط الأعمدة، تكون القيمة المرسومة متاحة عبر [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). تبقى نقطة البيانات في نفس موضع الفئة، لكن المخطط يتعامل مع قيمتها كخالية وفقًا لإعدادات الخلايا الفارغة في المخطط.

المثال التالي يمسح النقطة الثانية فقط في السلسلة الأولى:

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

تستخدم مخططات التشتت خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية حجم. امسح الخلية التي تمثّل القيمة التي تريد إزالتها فقط. لا تستدعِ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) عندما تريد الحفاظ على بقية النقاط، فهذه الطريقة تحذف كل نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم هي حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من صفوف وأعمدة ورقة العمل المخفية، راجع [Include Data from Hidden Rows and Columns](/slides/ar/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

تمثل الخلية الفارغة في المصنف بيانات مفقودة؛ تمثل الخلية التي تحتوي على `0` قيمة عددية معروفة. عيّن [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) إلى `None` لجعل الخلية فارغة. الصفر الرقمي يظل صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) لاختيار كيفية عرض المخطط للخلايا الفارغة. ينطبق هذا الإعداد على المخطط بأكمله. إنه يغيّر طريقة رسم الفارغ دون ملء خلية المصنف الفارغة بصفر أو قيمة مُستَخلَصة.

المثال التالي المستقل يُنشئ مخطط خطي بسلسلة واحدة، يمسح القيمة لليوم 3، ويحفظ المخطط نفسه بكل وضع. لا يلزم ملف إدخال. يستخدم [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) ورقة عمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحتوي على اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

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

    # اترك اليوم 3 فارغًا فعليًا، مع الحفاظ على فئته ونقطة البيانات.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

كل ملف ناتج يخزن الوضع المعيّن قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و`empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض التقديمي مرة واحدة بدلًا من التكرار عبر الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في الثلاث ملفات. اليوم 3 فارغ في المصنف في كل حالة:

![مخططات الخط مع بيانات متطابقة: Gap يقطع الخط عند اليوم 3، Zero ينزل الخط إلى الصفر، وSpan يربط اليوم 2 باليوم 4.](display_blanks_as.png)

التأثير الظاهر يعتمد على نوع المخطط. يجعل مخطط الخط الثلاثة أوضاع سهلة المقارنة. مخططات الأعمدة والأشرطة لا يوجد فيها خط للربط عبر فئة مفقودة، لذا لا يستطيع `SPAN` إنتاج الجزء المتصل المعروض أعلاه؛ ويمكن أن يبدو العمود المفقود والعمود صفر الارتفاع متشابهين. وبالمثل، مخطط التشتت مع علامات فقط لا يملك خطًا للربط. لا تتوقع ثلاث نتائج مميزة لكل نوع مخطط؛ تحقق من المخرجات للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، يُعبَّر عنه كنسبة مئوية من عرض العمود أو الشريط. مثل التداخل، ينتمي إلى مجموعة السلسلة الأصلية وليس إلى سلسلة واحدة. عيّن [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) مرة واحدة للمجموعة. القيمة الأكبر تُنشئ مساحة أوسع بين المجموعات؛ والقيمة الأصغر تجعلها أكثر كثافة.

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

**ما أنواع المخططات التي تدعم السلاسل البيانية؟**

جميع أنواع المخططات المُمثلة في تعداد [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك جميعًا في نفس بنية القيم أو الإعدادات. على سبيل المثال، تستخدم مخططات الفئة الفئات والقيم، وتستخدم مخططات التشتت قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتوافق مع نوع السلسلة. تنطبق خيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هو مجموعة سلاسل المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) يحتوي على سلاسل متوافقة تشترك في إعدادات رسم على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا قد لا يغيّر تعديل المجموعة التي تُستَخرج من سلسلة واحدة كل السلاسل في المخطط.

**هل يحتوي المخطط المنشئ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، ينشئ [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) سلاسل، فئات، وقيم تجريبية. يمكنك تعديل تلك الخلايا أو مسح كلٍّ من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. يمكن للتحميل الزائد أيضًا إنشاء مخطط بدون بيانات افتراضية.

**كيف ترتبط كائنات المخطط بخلايا المصنف؟**

أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات تشير إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). تغيير خلية مرجعية يحدّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، حافظ على محاذاة صفوف الفئات وصفوف قيم السلسلة بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلاً من كامل السلسلة؟**

عيّن خلية القيمة ذات الصلة إلى `None` لتبقى نقطة البيانات في موضع فئتها كنقطة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) فقط عندما تريد حذف كل النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تبقى قيمها محاذية لمجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

يعتمد النتيجة على نوع المخطط و[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). تدعم المخططات المسموح بها عرض الفارغات كفجوات، كقيم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يتوافق مع معنى البيانات المفقودة في عرضك. راجع [Control the Display of Empty Cells](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة بصرية.

**كيف تُنسق القيم السالبة؟**

بالنسبة لسلاسل الأشرطة، الأعمدة، والفقاعات المدعومة، فعّل [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) واعيين [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). يمكنك تجاوز السلوك لنقطة فردية عبر [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). تُؤثر هذه الخصائص على التنسيق فقط، وليس على القيم الرقمية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

تنسيق النقطة الصريح يهيمن على تلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، إذا لم يُحدَّد تنسيق للسلسلة، نمط المخطط والموضوع التلقائي. تُتحكم خصائص المجموعة مثل التداخل وعرض الفجوة في التخطيط ولا تُعدّ تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن للمخطط احتواؤها؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تحدد قيود ملف العرض التقديمي، الذاكرة المتاحة، وقت التَصْوير، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا أفعل عندما تكون الأعمدة قريبة جدًا من بعضها أو متباعدة جدًا؟**

عيّن [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) على مجموعة السلسلة الأصلية الملائمة. زد القيمة لتوسيع الفجوة بين المجموعات، أو قلّلها لتقريب المجموعات من بعضها البعض.