---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام بايثون
linktitle: سلسلة البيانات
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
- العرض التقديمي
- Python
- Java
- Aspose.Slides
description: "تعرّف على كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السلبية في العروض التقديمية باستخدام Aspose.Slides لبايثون عبر جافا."
---
## **نظرة عامة**

يمكن للمخطط تخزين القيم المرسومة إما في خلايا دفتر العمل أو مباشرةً كقوام رقمية. يمثل [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) مجموعة واحدة من القيم المرتبطة، ويُمثل كل [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) نقطة في تلك المجموعة. تُوفر كائنات [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. في المخططات التي تم إنشاؤها بالبيانات الافتراضية، تُستخدم أسماء السلاسل والفئات وقيم النقاط كائنات [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) من دفتر عمل المخطط.

للمخطط الفئوي النموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، العمود 0 لأسماء الفئات، وتُملأ الخلايا المتبقية بقيم السلاسل. الفهارس للورقة والصف والعمود التي تُمرَّر إلى [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) تبدأ من الصفر. هذا التخطيط مفيد عند إنشاء مخطط بالبيانات الافتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة للعرض المُحمَّل، افحص الخلايا التي تُشير إليها السلاسل والفئات ونقاط البيانات قبل تعديل قيم دفتر العمل.

لإعدادات المخطط ثلاثة نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat)، تُحدد الشكل الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)، تتجاوز شكل السلسلة لنقطة واحدة.
- إعدادات المجموعة تُطبق على السلاسل المتوافقة التي تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/). يُمكن الوصول إلى المجموعة عبر [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) عندما تحتاج إلى ضبط خيارات مثل التداخل أو عرض الفجوة.

عند عدم تحديد تعبئة صريحة للنقطة أو السلسلة، يحدد نمط المخطط والموضوع المظهر التلقائي. عندما تكون كل من تنسيقات السلسلة والنقطة موجودة، تُعطى تنسيق النقطة أولوية لتلك النقطة.

![سلسلة المخطط في PowerPoint](chart-series-powerpoint.png)

## **تعيين قيم السلسلة باستخدام القوام الرقمية**

استخدم القوام الرقمية عندما تأتي قيم السلسلة من بيانات التطبيق أو الحسابات ولا تحتاج إلى مراجع خلايا ورقة العمل. استدعِ [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) مع [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) قبل تعيين نتيجة [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) لكل نقطة عبر [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble).

تتحكم إعدادات المجموعة في نوع المصدر لجميع قيم النقاط في تلك السلسلة. تُظهر طريقة [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) لكل قيمة نوع المصدر المختار؛ غيّره عبر إعدادات المجموعة. مع `Worksheet`، استخدم [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) للوصول إلى الخلية المرجعية. مع `DoubleLiterals`، استخدم [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) أو `setAsLiteralDouble` لقراءة أو كتابة الرقم مباشرة.

المثال التالي ينشئ مخطط عمودي بسلاسل وفئات افتراضية، ثم يعيّن القيم المحسوبة 10، 20، وهكذا للنقاط الموجودة في السلسلة الأولى. يحفظ العرض، يُعيد فتحه، ويطبع القيم المخزنة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

نوع مصدر قيمة النقطة منفصل عن [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType)، الذي يحدد تكوين دفتر العمل الداخلي أو الخارجي للمخطط. استخدام القوام الرقمية لا يزيل دفتر العمل المضمّن بحد ذاته. في هذا المثال، يبقى دفتر العمل متاحًا لتسميات الفئات، أسماء السلاسل، والسلاسل الأخرى. راجع [Chart Workbook](/slides/ar/python-java/chart-workbook/) لإدارة دفتر العمل.

بالنسبة لمخططات التشتت والفقاعة، استخدم [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) و[setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) لاختيار المصادر لـ [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) و[getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue). كما تستخدم مخططات الفقاعات [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) لـ [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize). عيّن كل مصدر مناسب إلى `DoubleLiterals` قبل تعيين الأرقام عبر طريقة `setAsLiteralDouble` لتلك القيمة.

## **تعيين تداخل سلاسل المخطط**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) تُظهر مقدار تداخل الأشرطة أو الأعمدة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمئة. هي تمثيل للقراءة فقط للإعداد على مجموعة السلاسل الأصلية. استخدم [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) لتحديث كل السلاسل المتوافقة في تلك المجموعة. يُطبق هذا الخيار على أنواع المخططات التي تُظهر أشرطة أو أعمدة مُجموعة؛ ولا يؤثر على مجموعات السلاسل غير المتعلقة في مخطط مركب.

المثال التالي يعيّن التداخل للمجموعة التي تحتوي على السلسلة الأولى:

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

    # المخطط الجديد يحتوي على سلاسل تجريبية، فئات، وقيم.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![تداخل السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كان لدى نقطة تعبئة صريحة، فإن إعداد [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يُطبق تعبئة صلبة زرقاء على السلسلة الأولى:

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

![لون السلسلة](series_color.png)

## **تغيير اسم السلسلة**

يُخزن اسم السلسلة في دفتر بيانات المخطط ويُعرض عادةً في المفتاح. في دفتر العمل الافتراضي الذي يُنشأ لمخطط عمودي مُجمّع، الخلية B1 هي الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. المتغيرات المسماة في المثال التالي تجعل هذا الهيكل واضحًا:

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

يمكنك أيضًا تحديث الخلية التي يُشير إليها [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName). يَتَجنب هذا النهج الافتراض بوجود صف وعمود معينين في مخطط موجود:

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

![اسم السلسلة](series_name.png)

### **إنشاء سلسلة باسم من خلايا متعددة**

اسم سلسلة مركب مفيد عندما يُخزن اسم المنتج وفترة التقرير في خلايا دفتر عمل منفصلة. على سبيل المثال، يمكنك دمج `Product A` في B1 و`2026` في C1 لتكوين اسم سلسلة واحد مع الحفاظ على ارتباط كلا الجزأين بخلايا المصدر.

استخدم [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) لاسترداد نطاق الاسم، ثم مرّر ذلك التجميع إلى [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add). يتحكم معامل `skipHiddenCells` فيما إذا كانت الخلايا المخفية تُضمّن: `True` يستثنيها، و`False` يضمّنها. يستخدم هذا المثال `False` لتضمين كل الخلايا في نطاق الاسم.

المثال التالي ينشئ عرضًا بسلسلة واحدة ونقطتي بيانات. تُزوّد الخلايا B1:C1 باسم السلسلة فقط؛ A2:A3 تُزوّد تسميات الفئات، وB2:B3 تُزوّد القيم الرقمية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # هذان الخليتان توفران اسم السلسلة.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # خلايا منفصلة تُزوّد الفئات ونقاط البيانات الرقمية.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

اسم السلسلة الناتج هو `Product A 2026`، مع مسافة بين القيمتين من الخليتين. يُظهر المفتاح هذا كإدخال واحد لكل العمودين. تُظهر الصورة أدناه النتيجة:

![مخطط عمودي مع قيم الشمال والجنوب والاسم المركب للسلسلة Product A 2026 في المفتاح](composite_series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) تُرجع اللون المُحسب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا يُحدَّد تعبئة السلسلة صراحة. استدعاء الطريقة يقرأ اللون المُحسب؛ لا يعيّن تعبئة جديدة.

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

مخرجات المثال للنمط الافتراضي للمخطط:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين لون تعبئة عكسي لسلسلة المخطط**

بالنسبة لسلاسل الأشرطة، الأعمدة، والفقاعات، يمكن لـ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) عرض القيم السالبة بتعبئة مختلفة. عيّن تعبئة السلسلة العادية إلى صلبة، فعّل الانعكاس، وعيّن لون القيمة السالبة عبر [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). تظل الأرقام السالبة غير معدّلة في دفتر العمل؛ يتغيّر فقط لون عرضها.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 في ورقة العمل يحتوي على اسم السلسلة، العمود 0 على أسماء الفئات، والعمود 1 على القيم:

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

![لون التعبئة الصلبة العكسي](inverted_solid_fill_color.png)

يمكنك تمكين الانعكاس لنقطة واحدة عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). في المثال التالي يُعطل الانعكاس للسلسلة ويُفعَّل فقط للنقطة المحددة. تُعيَّن النقطة أيضًا قيمة سالبة لتكون النتيجة مرئية:

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

## **مسح قيمة نقطة بيانات محددة**

لإفراغ نقطة واحدة دون إزالة النقاط الأخرى، عيّن خلية دفتر العمل الداعمة لها إلى `None`. بالنسبة لمخطط عمودي، تُتاح القيمة المرسومة عبر [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue). تظل نقطة البيانات في موضع الفئة نفسه، لكن المخطط يتعامل مع قيمتها كفراغ وفقًا لإعدادات القيم الفارغة في المخطط.

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

تستخدم مخططات التشتت خلايا X وY منفصلة، وتستخدم مخططات الفقاعات خلية حجم أيضًا. امسح الخلية التي تمثل القيمة التي تريد إزالتها فقط. لا تستدعِ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) عندما تريد الإبقاء على باقي النقاط، لأن هذه الطريقة تُزيل كل النقاط من التجميع.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفية التي تحتوي على قيم تُعَد حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من صفوف و أعمدة ورقة العمل المخفية، راجع [Include Data from Hidden Rows and Columns](/slides/ar/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

تمثل الخلية الفارغة في دفتر العمل بيانات مفقودة؛ بينما تمثل الخلية التي تحتوي على `0` قيمة عددية معروفة. استدعِ [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) مع `None` لجعل الخلية فارغة. يبقى الصفر الرقمي صفرًا بغض النظر عن إعداد الخلايا الفارغة.

استخدم [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) لاختيار كيفية عرض المخطط للخلايا الفارغة. يُطبق هذا الإعداد على المخطط بأكمله. يغيّر طريقة رسم الفارغات دون ملء خلية دفتر العمل الفارغة بصفر أو بقيمة مُستنتَجة.

المثال التالي المستقل يُنشئ مخطط خط بسلسلة واحدة، يمسح القيمة لليوم 3، ويحفظ المخطط نفسه بكل وضع. لا يلزم ملف إدخال. يستخدم [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) ورقة 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # اترك اليوم الثالث فارغًا فعليًا، مع الحفاظ على فئته ونقطة البيانات الخاصة به.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

كل ملف إخراج يُخزّن الوضع المحدد قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و`empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض مرة واحدة بدلاً من التكرار على الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في جميع الملفات الثلاثة. اليوم 3 فارغ في دفتر العمل في كل حالة:

![مخططات الخط مع بيانات مطابقة: Gap يقطع الخط عند اليوم 3، Zero يخفض الخط إلى الصفر، وSpan يربط اليوم 2 باليوم 4.](display_blanks_as.png)

التأثير المرئي يعتمد على نوع المخطط. يجعل مخطط الخط جميع الأوضاع الثلاثة سهل المقارنة. لا تُظهر المخططات الشريطية والعمودية أي خط لتوصيل الفئات المفقودة، لذا لا يمكن لـ `Span` إنتاج الجزء المتصل كما في الأعلى؛ وقد تبدو العمود المفقود والعمود صفر الارتفاع متشابهين. بالمثل، لا يُظهر مخطط التشتت مع العلامات فقط خطًا موصلا. لا تتوقع ثلاث ناتج متميزة لكل نوع مخطط؛ تحقق من النتيجة للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، معبرًا عنها بنسبة مئوية من عرض العمود أو الشريط. مثل التداخل، ينتمي إلى مجموعة السلاسل الأصلية وليس إلى سلسلة واحدة. استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) مرة واحدة للمجموعة. قيمة أكبر تُنشئ مساحة أكبر بين المجموعات؛ قيمة أصغر تجعلها أكثر كثافة.

المثال التالي يغيّر عرض الفجوة ويحفظ العرض النهائي فقط:

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

![عرض الفجوة](gap_width.png)

## **الأسئلة الشائعة**

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات الممثَّلة في تعداد [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) تستخدم بيانات المخطط، لكن سلاسِلها لا تشترك دائمًا في نفس بنية القيم أو الإعدادات. على سبيل المثال، تستخدم المخططات الفئوية فئات وقيم، وتستخدم مخططات التشتت قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تُطبق خيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هو مجموعة سلاسل المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) يحتوي على سلاسل متوافقة تشترك في إعدادات الرسم على مستوى المجموعة. يمكن أن يحتوي مخطط مركب على أكثر من مجموعة، لذا تغيير المجموعة التي يتم الوصول إليها عبر سلسلة معينة لا يغيّر بالضرورة كل السلاسل في المخطط.

**هل يحتوي المخطط الذي تم إنشاؤه حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، تُنشئ [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) سلاسل وفئات وقيم نموذجية. يمكنك تعديل تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة تمامًا. يمكن أيضًا وجود نسخة زائدة تُنشئ مخططًا دون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

تُشير أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/). تحديث خلية مُشار إليها يُحدِّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، حافظ على محاذاة صفوف الفئات وصفوف قيم السلاسل بحيث تُرسم كل نقطة تحت الفئة المستهدفة.

**كيف أقوم بمسح نقطة واحدة بدلاً من مسح السلسلة بأكملها؟**

عيّن خلية القيمة ذات الصلة إلى `None` للاحتفاظ بموقع الفئة للنقطة كقيمة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) فقط عندما تريد إزالة كل النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل لتظل قيمها مُنسَّقة مع مجموعة الفئات.

**كيف يُعرض النقاط الفارغة؟**

النتيجة تعتمد على نوع المخطط والقيمة المُكوَّنة عبر [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs). يمكن للمخططات الداعمة عرض الفراغات كفجوات أو كقيمة صفر أو بربط النقاط المجاورة. اختر الإعداد الذي يعكس معنى البيانات المفقودة في العرض الخاص بك. راجع [Control the Display of Empty Cells](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة بصرية.

**كيف يتم تنسيق القيم السالبة؟**

بالنسبة للسلاسل المدعومة من الأشرطة والاعمدة والفقاعات، استدعِ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) واضبط اللون الذي تُرجعه [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). يمكنك تجاوز السلوك لنقطة معينة باستخدام [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). هذه الطرق تؤثر على التنسيق فقط، وليس على القيم الرقمية المخزنة.

**أي تنسيق يفوز عندما يتم تنسيق كل من السلسلة والنقطة؟**

يأخذ تنسيق نقطة البيانات الصريح أولوية لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، عندما لا يُحدَّد تنسيق السلسلة، نمط المخطط والموضوع التلقائي. تتحكم إعدادات المجموعة مثل التداخل وعرض الفجوة في التخطيط ولا تُعدّ تجاوزات تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تحدد قيود ملف العرض، الذاكرة المتاحة، زمن التقديم، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا أفعل عندما تكون الأعمدة قريبة جدًا أو متباعدة كثيرًا؟**

استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) على مجموعة السلاسل الأصلية المناسبة. زد القيمة لتوسيع المسافة بين المجموعات، أو قللها لجعل المجموعات أقرب إلى بعضها.