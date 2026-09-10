---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية بلغة بايثون
linktitle: سلاسل البيانات
type: docs
url: /ar/python-java/chart-series/
keywords:
- سلسلة المخطط
- تداخل السلسلة
- لون السلسلة
- اسم السلسلة
- نقطة البيانات
- خلية دفتر العمل
- فجوة السلسلة
- قيمة سلبية
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعرف على كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السلبية في العروض التقديمية باستخدام Aspose.Slides للبايثون عبر الجافا."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في دفتر بيانات المخطط. يمثل [ChartSeries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/) مجموعة واحدة من القيم المرتبطة، ويشير كل [ChartDataPoint](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapoint/) في السلسلة إلى خلية أو أكثر في دفتر العمل. توفر كائنات [ChartCategory](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. لذلك يتم ربط اسم السلسلة والفئات وقيم النقاط بكائنات [ChartDataCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/) بدلاً من أن تُخزن كنص عرض فقط.

في مخطط الفئة النموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، وتُستخدم الخلايا المتبقية لقيم السلسلة. الفهارس الخاصة بورقة العمل والصف والعمود التي تُمرّر إلى [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/#getCell) تعتمد على الصفر. يساعد هذا التخطيط عند إنشاء مخطط ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. في عرض تم تحميله، افحص الخلايا التي تشير إليها السلاسل والفئات والنقاط قبل تعديل قيم دفتر العمل.

لإعدادات المخطط ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.getFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#getFormat)، تُحدد المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات النقطة، مثل [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapoint/#getFormat)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تُطبق على سلاسل متوافقة تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/). يمكن الوصول إلى المجموعة عبر [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#getParentSeriesGroup) عندما تحتاج لتعيين خيارات مثل التداخل أو عرض الفجوة.

عند عدم تعيين تعبئة صريحة للنقطة أو للسلسلة، تحدد نمط المخطط والموضوع المظهر التلقائي. عندما تكون صياغة السلسلة وصياغة النقطة موجودتين، تتفوق صياغة النقطة لتلك النقطة.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة المخطط**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#getOverlap) يُبلغ عن مقدار تداخل الأشرطة أو الأعمدة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمائة. هو إسقاط للقراءة فقط للإعداد على مجموعة السلسلة الأصلية. استخدم [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/#setOverlap) لتحديث كل السلاسل المتوافقة في تلك المجموعة. يُطبق هذا الخيار على أنواع المخططات التي تعرض أشرطة أو أعمدة مجمعة؛ ولا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

المثال التالي يُعيّن التداخل للمجموعة التي تحتوي على السلسلة الأولى:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # يحتوي المخطط الجديد على سلاسل وعناصر فئة وقيم تجريبية.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![The series overlap](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [ChartSeries.getFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#getFormat) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كانت النقطة لديها تعبئة صريحة بالفعل، فإن إعداد [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapoint/#getFormat) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبق تعبئة صلبة زرقاء على السلسلة الأولى:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![The color of the series](series_color.png)

## **تغيير اسم السلسلة**

يُخزن اسم السلسلة في دفتر بيانات المخطط وعادةً ما يُعرض في وسيلة الإيضاح. في دفتر العمل الافتراضي الذي يُنشأ لمخطط عمود متجمع، الخلية B1 هي في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. المتغيّرات المسماة في المثال التالي تجعل تلك البنية صريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يمكنك أيضًا تحديث الخلية التي يشير إليها [ChartSeries.getName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#getName). يَتَجنّب هذا النهج افتراض صف وعمود معينين في مخطط موجود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![The series name](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) يُعيد اللون المحتسب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لم تُحدَّد تعبئة السلسلة صراحة. استدعاء الطريقة يقرأ اللون المحتسب؛ لا يعيّن تعبئة جديدة.

المثال التالي يطبع اللون التلقائي لكل سلسلة افتراضية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

مثال الإخراج لنمط المخطط الافتراضي:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين تعبئة معكوسة للسلسلة**

بالنسبة لسلاسل الأشرطة والأعمدة والفقاعات، يمكن لـ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#setInvertIfNegative) عرض القيم السالبة بتعبئة مختلفة. عيّن تعبئة السلسلة العادية صلبة، فعّل الانعكاس، وعيّن لون القيمة السالبة عبر [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). لا تُغيّر الأرقام السالبة في دفتر العمل؛ يتغيّر لون عرضها فقط.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. يحتوي الصف 0 من ورقة العمل على اسم السلسلة، العمود 0 على أسماء الفئات، والعمود 1 على القيم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![The inverted solid fill color](inverted_solid_fill_color.png)

يمكنك تمكين الانعكاس لنقطة واحدة عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). في المثال التالي، يُعطَّل الانعكاس للسلسلة ويُفعَّل فقط للنقطة المحددة. تُعطى النقطة أيضًا قيمة سالبة لكي يكون التأثير مرئيًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مسح قيمة نقطة بيانات معينة**

لجعل نقطة واحدة فارغة دون إزالة النقاط الأخرى، اضبط خلية دفتر العمل الداعمة إلى `None`. بالنسبة لمخطط العمود، القيمة المرسومة متوفرة عبر [ChartDataPoint.getValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapoint/#getValue). تبقى نقطة البيانات في نفس موضع الفئة، لكن المخطط يعامل قيمتها كفراغ وفقًا لإعدادات القيم الفارغة للمخطط.

المثال التالي يمسح النقطة الثانية فقط في السلسلة الأولى:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تستخدم مخططات التبعثر خلايا X وY منفصلة، وتستخدم مخططات الفقاعات أيضًا خلية حجم. امسح الخلية التي تمثل القيمة التي تريد إزالتها فقط. لا تستدعِ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapointcollection/#clear) عندما تريد إبقاء النقاط الأخرى، لأن هذه الطريقة تزيل كل نقطة بيانات من المجموعة.

## **تعيين عرض فجوة السلسلة**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، يُعبَّر عنها كنسبة مئوية من عرض العمود أو الشريط. مثل التداخل، ينتمي إلى مجموعة السلسلة الأصلية وليس إلى سلسلة واحدة. استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/#setGapWidth) مرة واحدة للمجموعة. القيمة الأكبر تُنشئ مساحة أكبر بين المجموعات؛ والقيمة الأصغر تجعلها أكثر كثافة.

المثال التالي يغيّر عرض الفجوة ويحفظ العرض التقديمي النهائي فقط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![The gap width](gap_width.png)

## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات الممثلة بعداد [ChartType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك جميعًا في نفس بنية القيم أو الإعدادات. على سبيل المثال، تستخدم مخططات الفئات الفئات والقيم، وتستخدم مخططات التبعثر قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. الخيارات مثل التداخل وعرض الفجوة تُطبق فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هي مجموعة سلاسل المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/) يحتوي على سلاسل متوافقة تشترك في إعدادات رسم على مستوى المجموعة. يمكن للمخطط المركب أن يحتوي على أكثر من مجموعة، لذا فإن تغيير المجموعة عبر سلسلة لا يعني بالضرورة تغيير كل السلاسل في المخطط.

**هل يحتوي المخطط المنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، [ShapeCollection.addChart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addChart) ينشئ سلاسل وعناصر فئة وقيم عينة. يمكنك تعديل تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. يمكن أيضًا للتحميل الزائد إنشاء مخطط بدون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات تشير إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/). تعديل خلية مُشار إليها يُحدث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على محاذاة صفوف الفئات وصفوف قيم السلسلة بحيث تُرسَم كل نقطة تحت الفئة المقصودة.

**كيف أمسح نقطة واحدة بدلاً من سلسلة كاملة؟**

اضبط خلية القيمة المعنية إلى `None` لتبقى نقطة الفئة في موضعها كنقطة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapointcollection/#clear) فقط عندما تريد إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تظل قيمها متوافقة مع مجموعة الفئات.

**كيف تُعرَض النقاط الفارغة؟**

النتيجة تعتمد على نوع المخطط والقيمة المُكوَّنة عبر [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#setDisplayBlanksAs). يمكن للمخططات المدعومة عرض الفارغات كفجوات، أو كقِيَم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يطابق معنى البيانات المفقودة في عرضك التقديمي.

**كيف يتم تنسيق القيم السالبة؟**

بالنسبة للسلاسل المدعومة من الأشرطة والأعمدة والفقاعات، استدعِ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#setInvertIfNegative) واضبط اللون الذي يُرجعه [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). يمكنك تجاوز السلوك لنقطة فردية باستخدام [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). هذه الطرق تؤثّر على التنسيق، لا على القيم العددية المخزنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

التنسيق الصريح للنقطة يتفوق لتلك النقطة. النقاط الأخرى تستمر في استخدام تنسيق السلسلة الصريح أو، عندما لا يُحدَّد تنسيق السلسلة، النمط والموضوع التلقائي للمخطط. إعدادات المجموعة مثل التداخل وعرض الفجوة تتحكم في التخطيط ولا تُعتبر تجاوزات لتنسيق النقطة.

**هل هناك حد لعدد السلاسل التي يمكن للمخطط استيعابها؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تُحدِّد قيود ملف العرض، والذاكرة المتاحة، ووقت التقديم، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا ينبغي تعديل عندما تكون الأعمدة قريبة جدًا أو متباعدة جدًا؟**

استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/#setGapWidth) على مجموعة السلسلة الأصلية المناسبة. زد القيمة لتوسيع الفجوة بين المجموعات، أو قلِّلها لجعل المجموعات أقرب إلى بعضها.