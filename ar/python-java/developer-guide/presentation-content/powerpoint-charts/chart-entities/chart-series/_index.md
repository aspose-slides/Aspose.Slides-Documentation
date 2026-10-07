---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام بايثون
linktitle: سلاسل البيانات
type: docs
url: /ar/python-java/chart-series/
keywords:
- سلسلة المخطط
- تراكب السلاسل
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
description: "تعرف على كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيق، التراكب، عرض الفجوة، والقيم السلبية في العروض التقديمية باستخدام Aspose.Slides للـ بايثون عبر جافا."
---
## **نظرة عامة**

يقوم المخطط بتخزين البيانات المرسومة في دفتر بيانات المخطط. تمثل [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) مجموعة واحدة من القيم المرتبطة، وتشير كل [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) في السلسلة إلى خلية أو أكثر في دفتر العمل. توفر كائنات [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) التسميات أو قيم التجميع التي تشترك فيها السلاسل. وبالتالي فإن اسم السلسلة والفئات وقيم النقاط مرتبطة بكائنات [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) بدلاً من تخزينها كنص عرض فقط.

بالنسبة إلى مخطط فئة نموذجي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، والخلايا المتبقية لقيم السلاسل. فهارس ورقة العمل والصف والعمود التي تُمرَّر إلى [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) تبدأ من الصفر. هذا التخطيط مفيد عند إنشاء مخطط ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. في عرض تقديمي تم تحميله، افحص الخلايا التي تشير إليها السلاسل والفئات ونقاط البيانات قبل تغيير قيم دفتر العمل.

لإعدادات المخطط ثلاثة نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat)، توفر المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)، تتجاوز مظهر السلسلة لنقطة واحدة.
- تنطبق إعدادات المجموعة على السلاسل المتوافقة التي تنتمي إلى نفس [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/). قم بالوصول إلى المجموعة عبر [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) عندما تحتاج إلى ضبط خيارات مثل التراكب أو عرض الفجوة.

عند عدم تحديد تعبئة صريحة للنقطة أو السلسلة، يحدد نمط المخطط والموضوع المظهر التلقائي. عندما تكون كل من تنسيقات السلسلة والنقطة موجودة، تتفوق تنسيق النقطة لتلك النقطة.

![سلسلة المخطط PowerPoint](chart-series-powerpoint.png)

## **ضبط تراكب سلسلة المخطط**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) يُبلغ عن مقدار تراكب الأشرطة أو الأعمدة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمائة. وهو إسقاط للقراءة فقط لإعداد المجموعة الأصلية للسلسلة. استخدم [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) لتحديث كل السلاسل المتوافقة في تلك المجموعة. ينطبق هذا الخيار على أنواع المخططات التي تُظهر أشرطة أو أعمدة مُجمعة؛ ولا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

المثال التالي يضبط التراكب للمجموعة التي تحتوي على السلسلة الأولى:

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

![تراكب السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كان للنقطة تعبئة صريحة بالفعل، فإن إعداد [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) يتجاوز تعبئة السلسلة لتلك النقطة.

المثال التالي يطبق تعبئة زرقاء صلبة على السلسلة الأولى:

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

يُخزن اسم السلسلة في دفتر بيانات المخطط وعادةً ما يُعرض في المفتاح. في دفتر العمل الافتراضي المُنشأ لمخطط أعمدة مُجمَّعة، تكون الخلية B1 في الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. المتغيّرات المُسمّاة في المثال التالي تجعل هذا الهيكل صريحًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

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

يمكنك أيضًا تحديث الخلية التي يشير إليها [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName). ي避免 هذا النهج الافتراض بوجود صف وعمود معينين في مخطط موجود:

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

اسم سلسلة مركّب مفيد عندما يكون اسم المنتج وفترة التقرير مخزنين في خلايا دفتر عمل منفصلة. على سبيل المثال، يمكنك دمج `Product A` في B1 و`2026` في C1 في اسم سلسلة واحد مع إبقاء الجزأين مرتبطين بخلايا المصدر الخاصة بهما.

استخدم [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) لاسترجاع نطاق الاسم، ثم مرّر ذلك التجميع إلى [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add). المتغيّر `skipHiddenCells` يتحكم فيما إذا كانت الخلايا المخفيّة تُضمّن: `True` يستثنيها، بينما `False` يضمّنها. يستخدم هذا المثال `False` لتضمين كل الخلايا في نطاق الاسم.

المثال التالي ينشئ عرض تقديمي بسلسلة واحدة ونقطتي بيانات. الخلايا B1:C1 تُزود فقط باسم السلسلة؛ A2:A3 تزود تسميات الفئات؛ وB2:B3 تزود القيم الرقمية.

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

    # هاتان الخليتان توفران اسم السلسلة.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # خلايا منفصلة توفر الفئات ونقاط البيانات الرقمية.
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

اسم السلسلة الناتج هو `Product A 2026`، مع مسافة بين القيمتين من الخليتين. يعرض المفتاح هذا كمدخل واحد لكل العمودين. الصورة أدناه توضح النتيجة:

![مخطط عمودي بقيم شمال وجنوب والاسم المركّب للسلسلة Product A 2026 في المفتاح](composite_series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) يُعيد اللون المحتسب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لا تُحدَّد تعبئة السلسلة صراحةً. استدعاء الطريقة يقرأ اللون المحتسب؛ ولا يُعيّن تعبئة جديدة.

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

ناتج مثال لنمط المخطط الافتراضي:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **ضبط لون التعبئة المعكوس لسلسلة المخطط**

للسلاسل الشريطية والعمودية والفقاعية، يمكن لـ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) عرض القيم السالبة بتعبئة مختلفة. اضبط تعبئة السلسلة العادية إلى صلبة، فعّل الانعكاس، وعيّن لون القيمة السالبة عبر [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). تظل الأرقام السالبة دون تغيير في دفتر العمل؛ يتغيّر لون عرضها فقط.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 من ورقة العمل يحتوي على اسم السلسلة، العمود 0 يحتوي على أسماء الفئات، والعمود 1 يحتوي على القيم:

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

![لون التعبئة الصلبة المعكوس](inverted_solid_fill_color.png)

يمكنك تمكين الانعكاس لنقطة واحدة عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). في المثال التالي، يُعطل الانعكاس للسلسلة ويُفعّل فقط للنقطة المحددة. تُعيّن النقطة أيضًا قيمة سالبة لتظهر التأثير:

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

لجعل نقطة واحدة فارغة دون إزالة باقي النقاط، اضبط خلية دفتر العمل الداعمة لها إلى `None`. بالنسبة إلى مخطط عمودي، القيمة المرسومة متوفرة عبر [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue). تبقى نقطة البيانات في نفس موضع الفئة، لكن المخطط يتعامل مع قيمتها كفراغ وفقًا لإعدادات الفراغ في المخطط.

المثال التالي يمسح فقط النقطة الثانية في السلسلة الأولى:

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

مخططات تبعثر تستخدم خلايا X وY منفصلة، ومخططات الفقاعات تستخدم أيضًا خلية الحجم. امسح فقط الخلية التي تمثّل القيمة التي تريد إزالتها. لا تستدعِ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) عندما تريد الاحتفاظ بالنقاط الأخرى، لأن هذه الطريقة تُزيل كل نقاط البيانات من التجميع.

## **التحكم في عرض الخلايا الفارغة**

الخلايا المخفيّة التي تحتوي على قيم هي حالة منفصلة عن الخلايا الفارغة. لتضمين أو استبعاد البيانات من الصفوف والأعمدة المخفيّة في ورقة العمل، راجع [Include Data from Hidden Rows and Columns](/slides/ar/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

الخلية الفارغة في دفتر العمل تمثّل بيانات مفقودة؛ الخلية التي تحتوي على `0` تمثّل قيمة رقمية معروفة. استدعِ [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) مع `None` لجعل الخلية فارغة. الصفر الرقمي يبقى صفرًا بغض النظر عن إعداد الخلايا الفارغة.

استخدم [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) لاختيار كيفية عرض المخطط للخلايا الفارغة. يطبق هذا الإعداد على المخطط بأكمله. يغيّر طريقة رسم الفراغات دون ملء الخلية الفارغة بالصفر أو قيمة مُقاربة.

المثال التالي المستقل يُنشئ مخططًا خطيًا بسلسلة واحدة، يمسح القيمة للّ يوم 3، ويحفظ المخطط نفسه بكل وضع. لا يلزم ملف إدخال. يستخدم [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) ورقة العمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

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

    # اجعل اليوم 3 فارغًا فعليًا، مع الاحتفاظ بفئته ونقطة البيانات الخاصة به.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

كل ملف ناتج يُخزّن الوضع المُحدد قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و`empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض تقديمي مرة واحدة بدلاً من التكرار عبر الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في جميع الملفات الثلاثة. اليوم 3 فارغ في دفتر العمل في كل حالة:

![مخططات خطية ببيانات متطابقة: الفجوة تقطع الخط في اليوم 3، الصفر يُسقط الخط إلى الصفر، والامتداد يربط اليوم 2 باليوم 4.](display_blanks_as.png)

التأثير المرئي يعتمد على نوع المخطط. يجعل مخطط الخط الثلاثة أوضاع سهلة المقارنة. مخططات الشريط والعمود لا تحتوي على خط لربط الفئات المفقودة، لذا لا يمكن لـ `Span` إنتاج الجزء المتصل كما هو موضح أعلاه؛ يمكن أن يبدو العمود المفقود والعمود ذو الارتفاع صفر متشابهين. بالمثل، مخطط التبعثر مع العلامات فقط لا يحتوي على خط متصل. لا تتوقع ثلاث نتائج مميزة لكل نوع مخطط؛ تحقق من النتيجة للنوع الذي تستخدمه.

## **ضبط عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، معبرًا عنها كنسبة مئوية من عرض العمود أو الشريط. مثل التراكب، يتبع مجموعة السلاسل الأصلية وليس سلسلة واحدة. استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) مرة واحدة للمجموعة. القيمة الأكبر تخلق مساحة أكبر بين المجموعات؛ القيمة الأصغر تجعلها أكثر كثافة.

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

![عرض الفجوة](gap_width.png)

## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات التي تمثّلها تعداد [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) تستخدم بيانات المخطط، لكن سلاسلها لا تشترك دائماً في بنية القيم أو الإعدادات نفسها. على سبيل المثال، تستخدم مخططات الفئات الفئات والقيم، ومخططات التبعثر قيم X وY، ومخططات الفقاعات تضيف أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تطابق نوع السلسلة. تنطبق خيارات مثل التراكب وعرض الفجوة فقط على مجموعات الشريط أو العمود المتوافقة.

**ما هو مجموعة سلاسل المخطط؟**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) يحتوي على سلاسل متوافقة تتشارك إعدادات رسم على مستوى المجموعة. يمكن لمخطط مركّب أن يحتوي على أكثر من مجموعة، لذا تعديل المجموعة التي تُوصل عبر سلسلة لا يعني بالضرورة تعديل كل السلاسل في المخطط.

**هل يحتوي المخطط المُنشأ حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، تقوم [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) بإنشاء سلاسل وعناصر فئة وقيم عينة. يمكنك تحرير تلك الخلايا أو مسح كلٍّ من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. يمكن أيضًا استدعاء نسخة م overload لإنشاء مخطط دون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

تُشير أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات إلى خلايا في [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/). تعديل خلية مُشار إليها يُحدّث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، حافظ على توافق صفوف الفئات وصفوف قيم السلسلة بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف أقوم بمسح نقطة واحدة بدلاً من مسح السلسلة بأكملها؟**

اضبط خلية القيمة المعنية إلى `None` للاحتفاظ بموضع الفئة الخاصة بالنقطة كنقطة فارغة. استخدم [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) فقط عندما ترغب في إزالة جميع النقاط من تلك السلسلة. إذا أزلت أيضًا الفئات، فحدّث كل السلاسل بحيث تظل قيمها متوافقة مع مجموعة الفئات.

**كيف تُعرض النقاط الفارغة؟**

النتيجة تعتمد على نوع المخطط والقيمة المكوّنة عبر [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs). يمكن للمخططات المدعومة عرض الفراغات كفجوات، كقيم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يطابق معنى البيانات المفقودة في عرضك التقديمي. راجع [التحكم في عرض الخلايا الفارغة](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة بصرية.

**كيف يتم تنسيق القيم السالبة؟**

بالنسبة للسلاسل الشريطية والعمودية والفقاعية المدعومة، استدعِ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) واضبط اللون الذي يُعيده [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). يمكنك تجاوز السلوك لنقطة فردية عبر [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). هذه الأساليب تؤثر على التنسيق فقط، لا على القيم الرقمية المخزّنة.

**أي تنسيق ينتصر عندما تُنسّق كل من السلسلة والنقطة؟**

تَسود تنسيق نقطة البيانات الصريح لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، عندما لا يُحدَّد تنسيق السلسلة، النمط والموضوع التلقائي للمخطط. إعدادات المجموعة مثل التراكب وعرض الفجوة تتحكم في التخطيط ولا تُعدّ تعديل تنسيق على مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

Aspose.Slides لا يفرض حدًا ثابتًا منفصلًا لعدد السلاسل. في الواقع، تحدد قيود ملف العرض التقديمي، الذاكرة المتاحة، زمن الإخراج، وقابلية قراءة المخطط حدًا عمليًا.

**ماذا يجب أن أغيّر عندما تكون الأعمدة متقاربة جدًا أو متباعدة جدًا؟**

استدعِ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) على مجموعة السلاسل الأصلية المناسبة. زد القيمة لتوسيع المسافة بين المجموعات، أو قلّلها لتقريب المجموعات من بعضها.