---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام بايثون
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
description: "تعلم كيفية إدارة سلاسل المخططات، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السالبة في العروض التقديمية باستخدام بايثون."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في دفتر بيانات المخطط. يمثل [ChartSeries](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/) مجموعة واحدة من القيم المرتبطة، وكل [ChartDataPoint](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/) في السلسلة يشير إلى خلية أو أكثر في دفتر العمل. توفر كائنات [ChartCategory](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartcategory/) الملصقات أو قيم التجميع المشتركة بين السلاسل. لذلك يتم ربط اسم السلسلة والفئات وقيم النقاط بكائنات [ChartDataCell](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatacell/) بدلاً من تخزينها كنص عرض فقط.

بالنسبة إلى مخطط الفئات النموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، وبقية الخلايا لقيم السلسلة. الفهارس الخاصة بورقة العمل والصف والعمود التي تُمرَّر إلى [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) هي صفرية. هذا التخطيط مفيد عندما تنشئ مخططًا ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة إلى عرض تقديمي محمَّل، افحص الخلايا التي تشير إليها السلاسل والفئات ونقاط البيانات قبل تغيير قيم دفتر العمل.

لإعدادات المخطط ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/format/)، توفر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [ChartDataPoint.format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/format/)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/). يمكن الوصول إلى المجموعة عبر [ChartSeries.parent_series_group](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/parent_series_group/) عندما تحتاج إلى تعيين خيارات مثل التداخل أو عرض الفجوة.

عندما لا يتم ضبط تعبئة صريحة للنقطة أو السلسلة، فإن نمط المخطط والموضوع يحددان المظهر التلقائي. عندما تكون كل من تنسيق السلسلة وتنسيق النقطة موجودين، يأخذ تنسيق النقطة الأسبقية لتلك النقطة.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ضبط تداخل سلسلة المخطط**

[ChartSeries.overlap](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/overlap/) يُظهر مقدار تداخل الأشرطة أو الأعمدة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمائة. وهو إسقاط للقراءة فقط لإعداد التداخل في مجموعة السلاسل الأصلية. اضبط [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/overlap/) لتحديث كل السلاسل المتوافقة في تلك المجموعة. ينطبق هذا الخيار على أنواع المخططات التي تعرض أشرطة أو أعمدة مجمَّعة؛ ولا يؤثر على مجموعات السلاسل غير المتصلة في مخطط مركب.

المثال التالي يضبط التداخل للمجموعة التي تحتوي على السلسلة الأولى:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # المخطط الجديد يحتوي على سلاسل عينات وفئات وقيم.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![The series overlap](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [ChartSeries.format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/format/) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كان للنقطة تعبئة صريحة، فإن إعداد [ChartDataPoint.format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/format/) يتجاوز تعبئة السلسلة لتلك النقطة.

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

يُخزن اسم السلسلة في دفتر بيانات المخطط وعادةً ما يُعرض في وسيلة الإيضاح. في دفتر العمل الافتراضي الذي يُنشأ لمخطط عمود مجمع، الخلية B1 هي الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسماة في المثال التالي تجعل هذا الهيكل واضحًا:

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

يمكنك أيضًا تحديث الخلية التي يشير إليها [ChartSeries.name](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/name/). يبتعد هذا النهج عن الافتراض بوجود صف وعمود معينين في مخطط موجود:

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

## **الحصول على لون تعبئة السلسلة التلقائي**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) يُعيد اللون المُحسب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا تُحدد تعبئة السلسلة صراحة. قراءة الطريقة تُعيد اللون المحسوب؛ ولا تُعيّن تعبئة جديدة.

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

مخرجات المثال لنمط المخطط الافتراضي:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين لون تعبئة عكسي لسلسلة المخطط**

بالنسبة إلى السلاسل الشريطية والعمودية والفقاعية، يمكن لـ [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/invert_if_negative/) عرض القيم السالبة بتعبئة مختلفة. اضبط تعبئة السلسلة العادية لتكون صلبة، وفعل الانعكاس، وعيّن لون القيمة السالبة عبر [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). تظل الأرقام السالبة دون تغيير في دفتر العمل؛ فقط يتغير لون عرضها.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 في ورقة العمل يحتوي على اسم السلسلة، العمود 0 يحتوي على أسماء الفئات، والعمود 1 يحتوي على القيم:

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

يمكنك تمكين الانعكاس لنقطة واحدة عبر [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). في المثال التالي، يكون الانعكاس معطلًا للسلسلة ومفعلًا فقط للنقطة المحددة. تُعيّن النقطة أيضًا قيمة سالبة لتوضيح التأثير:

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

لجعل نقطة واحدة فارغة دون إزالة النقاط الأخرى، اضبط خلية دفتر العمل الداعمة لها إلى `None`. بالنسبة إلى مخطط عمودي، القيمة المرسومة متاحة عبر [ChartDataPoint.value](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/value/). تبقى نقطة البيانات في نفس موضع الفئة، لكن المخطط يعامل قيمتها كفارغة وفقًا لإعدادات القيم الفارغة للمخطط.

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

تستخدم مخططات التبعثر خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية حجم. امسح الخلية التي تمثل القيمة التي ترغب في إزالتها فقط. لا تُستدعِ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapointcollection/clear/) عندما تريد الاحتفاظ بالنقاط الأخرى، لأن هذه الطريقة تُزيل كل نقاط البيانات من المجموعة.

## **ضبط عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، يُعبَّر عنها كنسبة مئوية من عرض العمود أو الشريط. مثل التداخل، يخص مجموعة السلاسل الأصلية وليس سلسلة واحدة. اضبط [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) مرة واحدة للمجموعة. قيمة أكبر تُنشئ مساحة أكبر بين المجموعات؛ قيمة أصغر تجعلها أضيق.

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

![The gap width](gap_width.png)

## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات الممثلة في تعداد [ChartType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك جميعًا في نفس هيكل القيم أو الإعدادات. على سبيل المثال، تستخدم مخططات الفئات الفئات والقيم، وتستخدم مخططات التبعثر قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقاط البيانات التي تتطابق مع نوع السلسلة. تنطبق خيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هي مجموعة سلسلة المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/) تحتوي على سلاسل متوافقة تشترك في إعدادات رسم على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا تغيير المجموعة من خلال سلسلة واحدة لا يغيّر بالضرورة كل السلاسل في المخطط.

**هل يحتوي المخطط المنشأ حديثًا على بيانات افتراضية؟**

نعم. افتراضيًا، [ShapeCollection.add_chart](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_chart/) ينشئ سلاسل وعلاقات وفئات عينات. يمكنك تعديل تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة تمامًا. يمكن أيضًا لاستدعاء بديل إنشاء مخطط دون بيانات افتراضية.

**كيف ترتبط كائنات المخطط بخلايا دفتر العمل؟**

أسماء السلاسل وتسمية الفئات وقيم نقاط البيانات تُشير إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/). تعديل خلية مُشار إليها يُحدث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلاً من مسح السلسلة كاملة؟**

اضبط خلية القيمة ذات الصلة إلى `None` لتُبقي موقع الفئة للنقطة كنقطة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapointcollection/clear/) فقط عندما تريد إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تظل قيمها مُحاذاة مع مجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

النتيجة تعتمد على نوع المخطط وإعداد [Chart.display_blanks_as](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/display_blanks_as/). يمكن للمخططات المدعومة عرض الفارغ كفجوة أو كقيمة صفر أو بربط النقاط المجاورة. اختر الإعداد الذي يتوافق مع معنى البيانات المفقودة في عرضك.

**كيف تُنسق القيم السالبة؟**

للأشرطة والأعمدة والفقاعات المدعومة، فعّل [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/invert_if_negative/) واضبط [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). يمكنك تجاوز السلوك لنقطة فردية عبر [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). هذه الخصائص تؤثر على التنسيق فقط، لا على القيم العددية المخزنة.

**أي تنسيق ينتصر عندما تُنسق كل من السلسلة والنقطة؟**

التنسيق الصريح لنقطة البيانات يتفوّق على أي تنسيق للسلسلة لتلك النقطة. تستمر باقي النقاط في استخدام تنسيق السلسلة الصريح أو، إذا لم يُحدَّد تنسيق للسلسلة، نمط المخطط والموضوع التلقائي. خصائص المجموعة مثل التداخل وعرض الفجوة تتحكم في التخطيط ولا تُعدّ تعديلات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تحديات حجم ملف العرض، الذاكرة المتاحة، وقت التصيير، وقابلية قراءة المخطط تحدد الحد العملي.

**ماذا أفعل عندما تكون الأعمدة قريبة جدًا أو متباعدة كثيرًا؟**

اضبط [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) في مجموعة السلاسل الأصلية المناسبة. زد القيمة لتوسيع المسافة بين المجموعات، أو قلّلها لجعل المجموعات أقرب إلى بعضها.