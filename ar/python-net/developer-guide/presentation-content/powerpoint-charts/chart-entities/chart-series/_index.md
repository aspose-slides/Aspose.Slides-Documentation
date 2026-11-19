---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام Python
linktitle: سلاسل البيانات
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
description: "تعلم كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا مصنف العمل، التنسيق، التداخل، عرض الفجوة، والقيم السلبية في العروض التقديمية باستخدام Python."
---
## **نظرة عامة**

يمكن للمخطط تخزين القيم المرسومة إما في خلايا مصنف العمل أو مباشرة كقواعد عددية. يمثل [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) مجموعة واحدة من القيم ذات الصلة، ويمثل كل [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) نقطة في تلك السلسلة. توفر كائنات [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. في المخططات التي تم إنشاؤها ببيانات افتراضية، تُستخدم أسماء السلاسل والفئات وقيم النقاط كائنات [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) من مصنف المخطط.

للمخطط الفئوي النموذجي، يستخدم المصنف الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، وتُملأ الخلايا المتبقية بقيم السلاسل. فهارس ورقة العمل والصف والعمود التي تُمرّر إلى [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) تبدأ من الصفر. يُعدّ هذا التخطيط مفيدًا عند إنشاء مخطط ببيانات افتراضية، ولكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة لعروض تقديمية محمّلة، تحقق من الخلايا التي تشير إليها السلاسل والفئات ونقاط البيانات قبل تعديل قيم المصنف.

تحتوي إعدادات المخطط على ثلاثة نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)، توفر المظهر الافتراضي لكل النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تُطبق على سلاسل متوافقة تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). يمكن الوصول إلى المجموعة عبر [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) عندما تحتاج إلى ضبط خيارات مثل التداخل أو عرض الفجوة.

عند عدم تعيين تعبئة صريحة للنقطة أو السلسلة، يحدد نمط المخطط والسمة المظهر التلقائي. عندما تكون هناك تنسيقات لكل من السلسلة والنقطة، تتفوّق تنسيق النقطة على تلك الخاصة بالسلسلة لتلك النقطة.

![chart-series-powerpoint](chart-series-powerpoint.png)

لمخطط أسطواني مُجَمّع، راجع كيف يؤثّر [تغيير نوع السلسلة ثلاثية الأبعاد أو شكل العمود](/slides/ar/python-net/3d-chart/#change-the-3d-series-type-and-bar-shape) على السلسلة الأولى.

## **تعيين قيم السلسلة باستخدام القواعد العددية**

استخدم القواعد العددية عندما تأتي قيم السلسلة من بيانات التطبيق أو الحسابات ولا تحتاج إلى مراجع خلايا ورقة العمل. اضبط [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) إلى [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) قبل تعيين [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) كل نقطة عبر [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/).

تحكم إعدادات المجموعة بنوع مصدر جميع قيم النقاط في تلك السلسلة. كل نقطة تُظهر [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) النوع المحدد؛ غيّره عبر إعداد المجموعة. مع `WORKSHEET`، استخدم [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) للوصول إلى الخلية المرجعية. مع `DOUBLE_LITERALS`، استخدم `as_literal_double` لقراءة أو كتابة الرقم مباشرة.

المثال التالي ينشئ مخطط أعمدة مع سلاسل وفئات افتراضية، ثم يعيّن القيم المحسوبة 10 و 20 وما إلى ذلك للنقاط الموجودة في سلسلته الأولى. يحفظ العرض، يفتحّه مرة أخرى، ويطبع القيم المخزّنة.

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

نوع مصدر قيمة النقطة منفصل عن [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)، الذي يحدّد تكوين المصنف الداخلي أو الخارجي للمخطط. استخدام القواعد العددية لا يُزيل المصنف المُضمّن بحد ذاته. في هذا المثال يظل المصنف متوفرًا لتسميات الفئات، وأسماء السلاسل، والسلسلة الأخرى. راجع [Chart Workbook](/slides/ar/python-net/chart-workbook/) لإدارة المصنف.

للمخططات النقطية والفقاعية، اضبط [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) و [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) لاختيار المصادر لـ [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) و [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/). تستخدم المخططات الفقاعية أيضًا [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) لـ [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/). اضبط كل مصدر مناسب إلى `DOUBLE_LITERALS` قبل تعيين الأرقام عبر خاصية `as_literal_double` الخاصة به.

## **تعيين تداخل سلسلة المخطط**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) يُظهر مقدار تداخل الأشرطة أو الأعمدة في مخطط ثنائي الأبعاد، من ‑100 إلى 100 ٪. هو إسقاط للقراءة فقط لإعداد المجموعة الأصلية. اضبط [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) لتحديث كل السلاسل المتوافقة في تلك المجموعة. هذا الخيار يُطبق على أنواع المخططات التي تعرض أشرطة أو أعمدة مُجَمّعة؛ ولا يُؤثر على مجموعات السلاسل غير المتعلقة في مخطط مركب.

المثال التالي يضبط التداخل للمجموعة التي تحتوي السلسلة الأولى:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # المخطط الجديد يحتوي على سلاسل تجريبية، فئات، وقيم.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The series overlap](series_overlap.png)

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

![The color of the series](series_color.png)

## **تغيير اسم السلسلة**

يُخزن اسم السلسلة في مصنف بيانات المخطط ويُظهر عادةً في الأسطورة. في المصنف الافتراضي المُنشأ لمخطط أعمدة مُجَمّع، تكون الخلية B1 في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسماة في المثال التالي تجعل هذا الهيكل واضحًا:

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

يمكنك أيضًا تحديث الخلية التي يشير إليها [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/). يتيح هذا النهج التجنب من الافتراض بشأن صف وعمود معينين في مخطط موجود:

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

![The series name](series_name.png)

### **إنشاء سلسلة باسم من خلايا متعددة**

يكون اسم السلسلة المركب مفيدًا عندما يُخزّن اسم المنتج وفترة التقرير في خلايا مصنف منفصلة. على سبيل المثال، يمكنك دمج `Product A` في B1 و `2026` في C1 في اسم سلسلة واحد مع إبقاء الجزأين مرتبطين بخلايا المصدر.

استخدم [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) لاسترداد نطاق الأسماء، ثم مرّر ذلك النطاق إلى [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). تُتحكم الخاصية `skip_hidden_cells` فيما إذا كانت الخلايا المخفية تُضمّن: `True` تستثنيها، و `False` تضمّنها. يستخدم هذا المثال `False` لتضمين كل خلية في نطاق الاسم.

المثال التالي ينشئ عرضًا تقديميًا بسلسلة واحدة ونقطتي بيانات. تُزوّد الخلايا B1:C1 فقط باسم السلسلة؛ تُزوّد A2:A3 تسميات الفئات؛ وتُزوّد B2:B3 القيم العددية.

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

    # هاتان الخليتان تزودان باسم السلسلة.
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

اسم السلسلة الناتج هو `Product A 2026` مع مسافة بين القيمتين. تُظهر الأسطورة ذلك كإدخال واحد لكلا العمودين. تم إنشاء الصورة أدناه من العرض المحفوظ:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) يُعيد اللون المحسوب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا تكون تعبئة السلسلة مُحددة صراحة. استدعاء الطريقة يقرأ اللون المحسوب؛ ولا يعين تعبئة جديدة.

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

الألوان الدقيقة تعتمد على نمط المخطط والسمة.

## **تعيين لون تعبئة عكسي لسلسلة المخطط**

للسلاسل الشريطية والعمودية والفقاعية، يمكن لـ [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) عرض القيم السالبة بتعبئة مختلفة. اضبط تعبئة السلسلة العادية إلى صلبة، فعّل العكس، وعين لون القيمة السالبة عبر [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). تُظل الأرقام السالبة دون تغيير في المصنف؛ يتغيّر لون عرضها فقط.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. يحتوي الصف 0 من ورقة العمل على اسم السلسلة، والعمود 0 على أسماء الفئات، والعمود 1 على القيم:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

يمكنك تمكين العكس لنقطة واحدة عبر [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). في المثال التالي يُعطَّل العكس للسلسلة ويُفعَّل فقط للنقطة المختارة. تُعيّن النقطة أيضًا قيمة سالبة لتظهر التأثير:

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

لجعل نقطة واحدة فارغة دون إزالة باقي النقاط، اضبط خلية المصنف الداعمة لها إلى `None`. في مخطط الأعمدة، تتوفر القيمة المرسومة عبر [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). تبقى نقطة البيانات في نفس موضع الفئة، لكن المخطط يتعامل مع قيمتها كخالية وفقًا لإعدادات الخلايا الفارغة في المخطط.

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

تستخدم المخططات النقطية خلايا X و Y منفصلة، وتستخدم المخططات الفقاعية أيضًا خلية حجم. امسح فقط الخلية التي تمثّل القيمة التي تريد إزالتها. لا تستدعي [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) عندما تريد إبقاء النقاط الأخرى، لأن تلك الطريقة تُزيل كل نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم هي حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من الصفوف والأعمدة المخفية في ورقة العمل، راجع [Include Data from Hidden Rows and Columns](/slides/ar/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

تمثّل الخلية الفارغة في المصنف بيانات مفقودة؛ وتمثّل الخلية التي تحتوي على `0` قيمة عددية معروفة. اضبط [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) إلى `None` لجعل الخلية فارغة. يبقى الصفر العددي صفرًا بغض النظر عن إعداد الخلية الفارغة.

استخدم [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) لاختيار كيفية عرض المخطط للخلايا الفارغة. يطبق هذا الإعداد على المخطط بأكمله. يغيّر طريقة رسم الفجوات دون ملء الخلية الفارغة بالصفر أو بقيمة مُستنتَجة.

المثال التالي المستقل يُنشئ مخطط خط واحد، يمسح القيمة لليوم 3، ويحفظ المخطط نفسه بكل وضع. لا يلزم ملف إدخال. يستخدم [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) ورقة العمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

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

    # اترك اليوم الثالث فارغًا فعليًا، مع الحفاظ على فئته ونقطة البيانات الخاصة به.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

كل ملف إخراج يُخزن الوضع المُعيّن قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و `empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض مرة واحدة بدلاً من التكرار على الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في الملفات الثلاثة. اليوم 3 فارغ في المصنف في كل حالة:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

يعتمد التأثير الظاهر على نوع المخطط. يُسهل مخطط الخط مقارنة جميع الأوضاع الثلاثة. لا تُظهر المخططات الشريطية والعمودية خطًا يُربط عبر فئة مفقودة، لذا لا يمكن لـ `SPAN` إنتاج الجزء المتصل أعلاه؛ قد يبدو العمود المفقود وعمود الصفر مرتين متشابهين. وبنفس الطريقة، لا يُظهر مخطط النقط مع العلامات سوى نقاط منفصلة دون خط ربط. لا تتوقع ثلاث نتائج متميزة لكل نوع مخطط؛ تحقق من النتيجة للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتقاربة، معبرًا عنها كنسبة مئوية من عرض العمود أو الشريط. مثل التداخل، ينتمي إلى مجموعة السلسلة الأصلية وليس إلى سلسلة واحدة. اضبط [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) مرة واحدة للمجموعة. القيمة الأكبر تُنشئ مساحة أكبر بين المجموعات؛ والقيمة الأصغر تجعلها أكثر كثافة.

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

النتيجة:

![The gap width](gap_width.png)

## **إظهار أو إخفاء خطوط السلسلة**

خطوط السلسلة تربط بصريًا أجزاء المخطط ذات الصلة. استخدم [ChartSeriesGroup.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/has_series_lines/) لإظهارها أو إخفائها في المخططات المدعومة من شريط مكدس وPie of Pie. في مخططات الشريط والعمود المكدسة ذات البعدين، تربط الحدود المتقابلة عبر الفئات. في مخططات Pie of Pie وBar of Pie، تربط المخطط الأساسي بالمخطط الثانوي. لا يُعدّ هذا الإعداد موصِّلًا عامًا لأنواع المخططات الأخرى.

الوصول إلى المجموعة يتم عبر [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). يطبق الإعداد على كل سلسلة في تلك المجموعة. [ChartSeries.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/has_series_lines/) للقراءة فقط ويعكس إعداد المجموعة؛ غيّر خاصية المجموعة لتحديثه.

المثال التالي يُنشئ مخططًا واحدًا من النوع [ChartType.PIE_OF_PIE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ببيانات افتراضية. يحفظ المخطط نفسه مع تمكين خطوط السلسلة ثم مع تعطيلها، مُنتجًا عرضين للمقارنة.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 400)
    series = chart.chart_data.series[0]
    series_group = series.parent_series_group

    series_group.has_series_lines = True
    presentation.save("series_lines_enabled.pptx", slides.export.SaveFormat.PPTX)

    series_group.has_series_lines = False
    presentation.save("series_lines_disabled.pptx", slides.export.SaveFormat.PPTX)
```

| تمكين خطوط السلسلة | تعطيل خطوط السلسلة |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| الخطان المتصلان يربطان الفطيرة الرئيسية بالفطيرة الثانوية. | يبقى كلا الفتيرتين مرئيتين، لكن خطوط الربط مخفية. |

خطوط السلسلة تختلف عن خطوط قائد تسمية البيانات، التي تربط التسميات بنقاط البيانات؛ وخطوط الشبكة، التي تُظهر الفواصل على محاور المخطط؛ وخطوط مخطط الخط، التي تمثل قيم البيانات. لا يتحكم هذا الإعداد في تلك العناصر.

## **الأسئلة الشائعة**

**أي أنواع المخططات تدعم سلاسل البيانات؟**

جميع أنواع المخططات التي يُمثّلها تعداد [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك جميعًا في نفس هيكل القيم أو الإعدادات. على سبيل المثال، تستخدم مخططات الفئات الفئات والقيم، وتستخدم المخططات النقطية قيم X و Y، وتضيف المخططات الفقاعية أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تُطبَّق الخيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هي مجموعة سلسلة المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) تحتوي على سلاسل متوافقة تشارك إعدادات الرسم على مستوى المجموعة. يمكن أن يحتوي مخطط مركب على أكثر من مجموعة، لذا لا يغيّر تعديل المجموعة التي يتم الوصول إليها عبر سلسلة واحدة بالضرورة كل السلاسل في المخطط.

**هل يحتوي المخطط الذي تم إنشاؤه حديثًا على بيانات افتراضية؟**

نعم. بشكلٍ افتراضي، يُنشئ [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) سلاسل وعلامات فئات وقيم نموذجية. يمكنك تعديل تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. يمكن أيضًا استدعاء نسخة مفرِّطة لإنشاء مخطط بدون بيانات افتراضية.

**كيف ترتبط كائنات المخطط بخلايا المصنف؟**

تشير أسماء السلاسل، وتسميات الفئات، وقيم نقاط البيانات إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). يحدّث تعديل خلية مرجعية العنصر المقابل في المخطط. عند بناء بيانات مخصصة، حافظ على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أقوم بمسح نقطة واحدة بدلاً من السلسلة بأكملها؟**

اضبط خلية القيمة ذات الصلة إلى `None` للاحتفاظ بموضع فئة النقطة كنقطة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) فقط عندما تريد إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل سلسلة لتبقى قيمها محاذية مع مجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

النتيجة تعتمد على نوع المخطط و[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). يمكن للمخططات المدعومة عرض الفجوات كفراغات، أو كقيم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يتوافق مع معنى البيانات المفقودة في عرضك. راجع [Control the Display of Empty Cells](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة بصرية.

**كيف يُنسَّق القيم السالبة؟**

بالنسبة للسلاسل الشريطية والعمودية والفقاعية المدعومة، فعِّل [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) واضبط [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). يمكنك تجاوز السلوك لنقطة فردية باستخدام [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). هذه الخصائص تؤثر على التنسيق، وليس على القيم العددية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

يتفوّق تنسيق نقطة البيانات الصريح على تلك الخاصة بالسلسلة لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، عندما لا يُحدّد تنسيق السلسلة، نمط المخطط والسمات التلقائية. تُتحكم خصائص المجموعة مثل التداخل وعرض الفجوة في التخطيط ولا تُعتبر تجاوزات لتنسيق المستوى النقطي.

**هل هناك حد لعدد السلاسل التي يمكن للمخطط احتواؤها؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تحدّ قيود ملف العرض، والذاكرة المتاحة، ووقت التصيّر، وقابلية قراءة المخطط الحد المفيد.

**ماذا يجب تعديل عندما تكون الأعمدة قريبة جدًا من بعضها أو متباعدة كثيرًا؟**

اضبط [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) على مجموعة السلسلة الأصلية المناسبة. زد القيمة لتوسيع الفجوة بين المجموعات، أو قلّلها لتقريبها.